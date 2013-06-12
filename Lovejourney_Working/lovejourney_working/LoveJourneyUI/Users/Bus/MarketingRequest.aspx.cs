using System;
using System.Collections.Generic;
using System.Linq;


using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Net;


public partial class Users_Bus_MarketingRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fupload.HasFile)
        {
            try
            {
                DataTable dtExcel = new DataTable();
                string path = Path.Combine(Server.MapPath("~/Cars/"), fupload.FileName);
                //string path = path.combine(Server.MapPath("emails" + fupload.FileName));

                fupload.SaveAs(path);
                // Connection String to Excel Workbook
                string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = excelConnectionString;
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                connection.Open();
                OleDbConnection con = new OleDbConnection(excelConnectionString);
                string query = "Select * from [Sheet1$]";
                OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                data.Fill(dtExcel);
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    string toEmail = dtExcel.Rows[i]["Emails"].ToString();
                    string Body = "<html><head><style type='text/css'> </style></head><body>" +
                          "<table style='border:1px solid blue;width:800px;'>" +
                       "<tr><td>" +
               Editor.Text.ToString() +
               "</td></tr>" +
               "</table></body></html>";

                    SendEmail(toEmail, txtEmail.Text.ToString(), txtpwd.Text.ToString(), txtSubject.Text.ToString(), Body, txthost.Text.ToString(), txtport.Text.ToString());
                    lblsentmail.Text = "Sent Mail to All";
                }

                // Create DbDataReader to Data Worksheet
                //DbDataReader dr = command.ExecuteReader();
                // SQL Server Connection String
                //string sqlConnectionString = @"Server=USER-PC;Integrated Security=SSPI;DataBase=LJ;User id=sa;PassWord=123;";
                // Bulk Copy to SQL Server 
                //SqlBulkCopy bulkInsert = new SqlBulkCopy(sqlConnectionString);
                //bulkInsert.DestinationTableName = "tbl_ExcelToDB";
                //bulkInsert.WriteToServer(dr);
            }
            catch (Exception ex)
            {

                lblsentmail.Text = ex.Message;

            }
        }
    }



    public static bool SendEmail(string pTo, string pEmail, string ppwd, string pSubject, string pBody, string phost, string pport)
    {
        try
        {

            string UserID = pEmail;
            string Password = ppwd;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(pEmail, "");
            MailAddress toAddress = new MailAddress(pTo, "");
            message.From = fromAddress;
            message.To.Add(toAddress);
            message.Subject = pSubject;
            message.Body = pBody;
            message.IsBodyHtml = true;

            if (pEmail != "")
            {
                MailAddress ccAddress = new MailAddress(pEmail);
                message.CC.Add(ccAddress);
            }

            //smtpClient.Host = "182.18.148.59";
            smtpClient.Host = phost;
            smtpClient.Port = Convert.ToInt32(pport);
            smtpClient.Credentials = new NetworkCredential(UserID, Password);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}