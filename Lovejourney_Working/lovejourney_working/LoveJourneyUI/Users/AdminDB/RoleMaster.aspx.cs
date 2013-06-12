using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Users_AdminDB_RoleMaster : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
            BindRole();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        objBal = new Class1();
        try
        {
            int id = Convert.ToInt32(Session["UserID"]);
            objBal = new Class1();
            objBal.Role= txtRole.Text;
          

            objBal.ScreenInd = Master123.InsertRole;
            objBal.Createdby= id;

            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                BindRole();
                txtRole.Text = "";
              

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
    private void BindRole()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetRole;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvRole.DataSource = objDataset.Tables[0];
                    gvRole.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblRole = (Label)row.FindControl("lblRole");
                txtRole.Text = lblRole.Text;

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
                Label lblRole = (Label)row1.FindControl("lblRole");
                id = Convert.ToInt32(lblid.Text);
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeleteRole;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    lblmsg.Text = "You have successfully deleted Your Record";
                    BindRole();
                }


            }






        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    protected void gvRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvRole_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateRole;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.Role = txtRole.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";
                txtRole.Text = "";
                BindRole();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;


            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtRole.Text = "";
    }
}