using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;


public partial class Agent_Masters_RemaindersMasters : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;
            BindRemainder();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        try
        {
            int id = Convert.ToInt32(Session["UserID"]);
            objBal = new Class1();
            objBal.Description1 = txtDescription.Text;

            objBal.ScreenInd = Master123.Remainders;
            objBal.id = id;

            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                BindRemainder();
                txtDescription.Text = "";
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

    private void BindRemainder()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetRemainder;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;

                    gvRemainders.DataSource = objDataset.Tables[0];
                    gvRemainders.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvRemainders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label Description = (Label)row.FindControl("Description");
                txtDescription.Text = Description.Text;
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnCancel.Visible = true ;
            }
            if (e.CommandName == "Delete")
            {

                Control ct2 = e.CommandSource as Control;
                GridViewRow row = ct2.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                id = Convert.ToInt32(lblid.Text);
                Label Description = (Label)row.FindControl("Description");
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeleteRemainders;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    
                    BindRemainder();
                }

            }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateRemainder;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.Description1 = txtDescription.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";
                txtDescription.Text = "";
                BindRemainder();


            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void gvRemainders_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Updating a row in a Gridview
    }
  

    protected void gvRemainders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnRemainderBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentDashBoard.aspx"); 
    }
}