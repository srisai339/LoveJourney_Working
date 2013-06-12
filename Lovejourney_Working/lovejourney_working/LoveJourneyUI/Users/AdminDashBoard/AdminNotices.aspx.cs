using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class AdminDashBoard_AdminNotices : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
            BindAdminNotices();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        objBal=new Class1();
        try
        {
            int id = Convert.ToInt32(Session["UserID"]);
            objBal = new Class1();
            objBal.Notices = txtAdminNotices.Text;

            objBal.ScreenInd = Master123.InsertAdminNotice;
            objBal.id = id;

            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                txtAdminNotices.Text = "";
                BindAdminNotices();
               
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
    private void  BindAdminNotices()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetAdminNotice;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvAdminNotices.DataSource = objDataset.Tables[0];
                    gvAdminNotices.DataBind();
                    
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvAdminNotices_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAdminNotices_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAdminNotices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblAdminNotices = (Label)row.FindControl("lblAdminNotices");
                txtAdminNotices.Text = lblAdminNotices.Text;
                
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
                Label lblAdminNotices = (Label)row1.FindControl("lblAdminNotices");
                id = Convert.ToInt32(lblid.Text);
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeleteAdminNotice;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    lblmsg.Text = "You have successfully deleted Your Record";
                    BindAdminNotices();
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
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = false;
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateAdminNotice;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.Notices = txtAdminNotices.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";
                txtAdminNotices.Text="";
                BindAdminNotices();


            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAdminNotices.Text = "";
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }
    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AdminDb/AdminDb.aspx");
    }
}