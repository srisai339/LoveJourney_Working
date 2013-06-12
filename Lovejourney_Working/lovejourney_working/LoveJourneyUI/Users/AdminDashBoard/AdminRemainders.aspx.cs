using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class AdminDashBoard_AdminRemainders : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
            BindAdminRemainder();
        }
        


    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
         objBal = new Class1();
         try
         {
             int id = Convert.ToInt32(Session["UserID"]);
             objBal = new Class1();
             objBal.AdminRemainder = txtAdminRemainders.Text;


             objBal.ScreenInd = Master123.InsertAdminRemainder;
             objBal.id = id;

             if (objBal.fnInsertRecord() == true)
             {
                 lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                 txtAdminRemainders.Text = "";
                 BindAdminRemainder();

             }
             else
             {
                 lblmsg.Text = "You can not to be saved your details";
             }
         }
         catch (Exception ex)
         {

         }

    }
    private void BindAdminRemainder()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetAdminRemainder;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvAdminRemainders.DataSource = objDataSet.Tables[0];
                    gvAdminRemainders.DataBind();
                    

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void gvAdminRemainders_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAdminRemainders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAdminRemainders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblAdminRemainders = (Label)row.FindControl("lblAdminRemainders");
                txtAdminRemainders.Text = lblAdminRemainders.Text;
                
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnCancel.Visible = true;

            }
            if (e.CommandName == "Delete")
            {
                Control ct2 = e.CommandSource as Control;
                GridViewRow row1 = ct2.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblAdminRemainders = (Label)row1.FindControl("lblAdminRemainders");
                id = Convert.ToInt32(lblid.Text);
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeleteAdminRemainder;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    lblmsg.Text = "You have successfully deleted Your Record";
                    BindAdminRemainder();
                }


            }






        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateAdminRemainder;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.AdminRemainder = txtAdminRemainders.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";
                txtAdminRemainders.Text = "";
                BindAdminRemainder();

                
            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AdminDb/AdminDb.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnCancel.Visible = false;
        btnUpdate.Visible = false;
        txtAdminRemainders.Text = "";
    }
}