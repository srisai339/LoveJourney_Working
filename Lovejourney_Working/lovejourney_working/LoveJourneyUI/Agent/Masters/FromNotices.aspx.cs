using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Agent_Masters_FromNotices : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;
            BindNotices();
            if (Request.QueryString["id"] != null)
            {
                
               btnBack.Visible = true;
            }
            
                

        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
         try
          {
            int id = Convert.ToInt32(Session["UserID"]);       
            objBal = new Class1();
            objBal.Notices=txtNotices.Text;
            
            objBal.ScreenInd = Master123.InsertNotices;
            objBal.id = id;

            if (objBal.fnInsertRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Saved  Your Notices";
                txtNotices.Text = "";
                BindNotices();
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
    private void BindNotices()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetNotices;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    

                    //gvRemainders.Visible = false;
                    gvNotices.DataSource = objDataset.Tables[0];
                    gvNotices.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void gvNotices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblHotelName = (Label)row.FindControl("lblHotelName");
                txtNotices.Text = lblHotelName.Text;
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnCancel.Visible = true ;

            }
            if (e.CommandName == "Delete")
            {
                Control ct2 = e.CommandSource as Control;
                GridViewRow row1 = ct2.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblHotelName = (Label)row1.FindControl("lblHotelName");
                id = Convert.ToInt32(lblid.Text);
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeleteNotices;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    lblmsg.Text = "You have successfully deleted Your Record";
                    BindNotices();
                }


            }
            

            
            


        }
        catch (Exception ex)
        {
            
            throw ex;
        }

    }
    protected void gvNotices_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateNotices;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.Notices = txtNotices.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                lblmsg.Text = "You have Sucessfully Updated Your Record";
                txtNotices.Text = "";
                BindNotices();
                

            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtNotices.Text = "";
    }
    protected void gvNotices_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentDashBoard.aspx"); 
    }
}