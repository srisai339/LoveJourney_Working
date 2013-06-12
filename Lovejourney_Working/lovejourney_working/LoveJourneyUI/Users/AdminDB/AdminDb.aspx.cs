using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Users_AdminDB_AdminDb : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
        {
            if (Session["Role"].ToString() == "Admin")
            {
                if (!IsPostBack)
                {
                    lblAdmin.Text = "Welcome To  Admin";
                    Panel pnl = (Panel)this.Master.FindControl("pnl");
                    pnl.Visible = false;
                    BindRemainders();
                    Notices.Visible = true;
                }
            }
            else
            {
                Notices.Visible = false;
                lblAdmin.Text = " Welcome To " + " " + Session["UserName"].ToString();
                Panel pnl = (Panel)this.Master.FindControl("pnl");
                pnl.Visible = false;
                grid.Visible = false;

            }

        }
        else
        {
            Response.Redirect("~/Default.aspx",false);
        }
    }
    private void BindRemainders()
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
                    gvRemainders.DataSource = objDataSet.Tables[0];
                    gvRemainders.DataBind();


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void lbtnNoticeMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AdminDashBoard/AdminNotices.aspx");
    }
    protected void lbtnMarkup_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AdminDb/AdminDBMarkUp.aspx");
    }
    protected void lbtnRemainder_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AdminDashBoard/AdminRemainders.aspx");
    }
}