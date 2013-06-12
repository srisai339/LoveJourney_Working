using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Users_AdminDB_AdminDBMarkUp : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
            BindAdminMarkUp();
        }

    }

    private void BindAdminMarkUp()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetAdminMarkup;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvMarkUp.DataSource = objDataSet.Tables[0];
                    gvMarkUp.DataBind();


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvMarkUp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblType = (Label)row.FindControl("lblType");
                Label MarkUpPrice = (Label)row.FindControl("lblMarkupAmount");
                txtAmount.Text = MarkUpPrice.Text;
                //ddltype.SelectedItem = MarkUpPrice.Text;

                //ddltype.Items.FindByText(GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["Role"].ToString().Trim()).Selected = true;
                ddltype.SelectedValue = lblType.Text;

                btnUpdate.Visible = true;
                Button1.Visible = false;
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
                objBal.ScreenInd = Master123.DeleteAdminMarkUp;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    lblmsg.Text = "You have successfully deleted Your Record";
                    BindAdminMarkUp();
                }


            }






        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    protected void gvMarkUp_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvMarkUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateAdminMarkUp;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.Type = ddltype.SelectedItem.Text;
            objBal.MarkupAmount = txtAmount.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";


                txtAmount.Text = "";
                ddlAddSubtract.ClearSelection();
                ddltype.ClearSelection();
                BindAdminMarkUp();
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                Button1.Visible = true;

            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAmount.Text = "";
        btnCancel.Visible = false;
        btnUpdate.Visible = false;
        ddltype.ClearSelection();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new Class1();
            objBal.ScreenInd = Master123.InsertAdminMarkup;
            objBal.Type = ddltype.SelectedItem.Text;
            objBal.MarkupAmount = txtAmount.Text;
            objBal.AddSubtract = ddlAddSubtract.SelectedItem.ToString();
            objBal.Role = Session["Role"].ToString();
            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                txtAmount.Text = "";
                ddltype.ClearSelection();
                BindAdminMarkUp();

            }
            else
            {
                lblmsg.Text = "You can not to be saved your details";
            }

        }
        catch
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new Class1();
            objBal.ScreenInd = Master123.InsertAdminMarkup;
            objBal.Type = ddltype.SelectedItem.Text;
            objBal.MarkupAmount = txtAmount.Text;
            objBal.AddSubtract = ddlAddSubtract.SelectedItem.ToString();
            objBal.Role = Session["Role"].ToString();
            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                txtAmount.Text = "";
                ddltype.ClearSelection();
                ddlAddSubtract.ClearSelection();
                BindAdminMarkUp();

            }
            else
            {
                lblmsg.Text = "You can not to be saved your details";
            }

        }
        catch
        {

        }
    }
}