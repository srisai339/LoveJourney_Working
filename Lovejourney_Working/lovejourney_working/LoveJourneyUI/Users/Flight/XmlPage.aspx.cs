using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;


public partial class Users_Bus_XmlPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnclick_Click(object sender, EventArgs e)
    {
        try
        {
            FnLocationtoXml();
        }
        catch (Exception ex)
        {

            lblmsg.Visible = true;
            lblmsg.Text = ex.Message;
        }
    }
    public void FnLocationtoXml()
    {
        string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection con = new SqlConnection(Constring);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_IFReports", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TableName", "DomAirportCodes");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DsLoc = new DataSet();
            da.Fill(DsLoc);

            string DirectoryPath = Server.MapPath("~/App_Data");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/" + "Airports.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (!dir1.Exists)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                XmlElement rootNode = XmlDoc.CreateElement("Airports");
                XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }


            StreamWriter XmlData = new StreamWriter(Server.MapPath("~/App_Data/" + "Airports.xml"), false);
            DsLoc.WriteXml(XmlData);
            XmlData.Close();
            lblmsg.Visible = true;
            lblmsg.Text = " All flights list Uploaded to XML Successfully";

        }
        finally
        {
            con.Close();
        }

    }
}