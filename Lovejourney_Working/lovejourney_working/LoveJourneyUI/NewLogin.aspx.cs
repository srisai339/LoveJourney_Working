﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class NewLogin : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection(@"Server=LOVEJOURNEY-PC\SQLEXPRESS;Integrated Security=SSPI;DataBase=lovejourney;User id=sa;PassWord=123;");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkNewEmployee_Click(object sender, EventArgs e)
    {
        pnlEmployee.Visible = true;
        pnlCoorporate.Visible = false;
    }
    protected void lbtnNewUser_Click(object sender, EventArgs e)
    {
        pnlEmployee.Visible = false;
        pnlCoorporate.Visible = true;
    }

    protected void btncorlog_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnEmpCancel_Click(object sender, EventArgs e)
    {

        pnlEmployee.Visible = false;
    }
    protected void btnCoorporateCancel_Click(object sender, EventArgs e)
    {
        pnlCoorporate.Visible = false;
    }
    protected void btnCoorporate_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            lblCorporate.Text = obj.InsertAgentRequest(txtCorName.Text.ToString(), txtCorEmail.Text.ToString(), txtcorOrganization.Text.ToString(), txtCorMobileNo.Text.ToString(),
                 txtCorCity.Text.ToString(), ddlCorState.SelectedItem.Text.ToString(), txtComments.Text.ToString(), txtCorDist.Text, "coorporate", "", "", "","","","");
            lblCorporate.ForeColor = System.Drawing.Color.Green;
            txtCorName.Text = txtCorEmail.Text = txtcorOrganization.Text = txtCorMobileNo.Text = txtCorCity.Text = txtComments.Text = txtCorDist.Text = "";
            ddlCorState.ClearSelection();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }

    }

    protected void btnEmp_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            string filename = Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath("~/saveresumes/" + filename));
            string pathname = "~/saveresumes/" + filename;


            string filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/savedocs/" + filename1));
            string pathname1 = "~/savedocs/" + filename1;




            lblEmp.Text = obj.InsertEmpRequest(txtEmpName.Text.ToString(), txtEmpEmail.Text.ToString(), "", txtEmpMobileNo.Text.ToString(),
                txtEmpCity.Text.ToString(), ddlState.SelectedItem.Text.ToString(), "", "", "Emp", "", "", "", filename, pathname, filename1, pathname1,txtQualification.Text,txtEmpAddress.Text);


            lblEmp.ForeColor = System.Drawing.Color.Green;
            txtEmpName.Text = txtEmpEmail.Text = txtEmpMobileNo.Text = txtEmpCity.Text = txtCorCity.Text = txtComments.Text = txtCorDist.Text =txtEmpAddress.Text= txtEmpPinCode.Text=txtQualification.Text="";
            ddlState.ClearSelection();
            ddlEmpcountry.ClearSelection();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }


    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(fuImage.PostedFile.FileName);
        fuImage.SaveAs(Server.MapPath("saveresumes" + filename));
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into tbl_AgentRequests(FileName,FilePath) values(@Name,@Path)", con);
        cmd.Parameters.AddWithValue("@Name", filename);
        cmd.Parameters.AddWithValue("@Path", "saveresumes" + filename);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void btnQualification_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.SaveAs(Server.MapPath("savedocs" + filename));
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into tbl_AgentRequests(DocName,DocPath) values(@Doc,@DocPath)", con);
        cmd.Parameters.AddWithValue("@Doc", filename);
        cmd.Parameters.AddWithValue("@DocPath", "saveresumes" + filename);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        ClsBAL objManabusBAL = new ClsBAL();    
        objManabusBAL.userName = Convert.ToString(txtEmpLoginName.Text);
        objManabusBAL.password = Convert.ToString(txtEmpPassword.Text);

        if (objManabusBAL.CheckUser() == "Valid User")
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Employee" || Session["Role"].ToString() == "BSD"||Session["Role"].ToString() == "CSE")
                {
                    System.Data.DataSet ds = objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                    Session["Balance"] = ds.Tables[0].Rows[0]["Balance"].ToString();
                    Session["View"] = "AgentView";
                    string ss = ds.Tables[0].Rows[0]["Status"].ToString();
                    if (ss.ToUpper().ToString() != "HOLD")
                    {
                        Response.Redirect("~/Users/AdminDb/AdminDb.aspx", false);
                    }
                    else
                    {
                        lblEmpMsg.Text = "Your account is on HOLD. Please contact the administrator.";
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                        Session["UserID"] = null;
                    }

                }
            }
           
        }
        else
        {
            lblEmpMsg.Text = "UserName/Password Incorrect.";
            lblEmpMsg.ForeColor = System.Drawing.Color.Red;
            Session["Role"] = null;
            Session["UserID"] = null;



        }
    }



    protected void txtEmpPassword_TextChanged(object sender, EventArgs e)
    {
        Button2_Click(sender, e);
    }
}