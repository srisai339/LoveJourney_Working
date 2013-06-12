using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FilghtsAPILayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;

public partial class Agent_Bus_LoginDetails : System.Web.UI.Page
{
    clsMasters _objMasters;
    DataSet _objDataset;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getlogindetails();
        }
        this.Page.Title = "LoveJourney - LoginHistory";
        //Panel men1 = (Panel)this.Master.FindControl("Menu1");
        //men1.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       

        getlogindetails();

    }
    protected void gvLoginHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLoginHistory.PageIndex = e.NewPageIndex;
        if (ViewState["LoginHistory"] != null)
        {
            gvLoginHistory.DataSource = ViewState["LoginHistory"];
            gvLoginHistory.DataBind();
        }
        else
        {
            getlogindetails();
        }
    }
    protected void getlogindetails()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.loginDetails;
            _objMasters.UserID = Convert.ToInt32(Session["UserID"].ToString());

            if (txtDate.Text == "")
            {
                txtDate.Text = "1/1/1900";
            }
            if (txttodate.Text == "")
            {
                txttodate.Text = "1/1/1900";
            }

            _objMasters.From12 =Convert.ToDateTime(txtDate.Text);
            _objMasters.To12 = Convert.ToDateTime(txttodate.Text);
            _objDataset = (DataSet)_objMasters.fnGetData();
            if (_objDataset != null)
            {
                if (_objDataset.Tables.Count > 0)
                {
                    if (_objDataset.Tables[0].Rows.Count > 0)
                    {
                        gvLoginHistory.DataSource = _objDataset.Tables[0];
                        gvLoginHistory.DataBind();
                        ViewState["LoginHistory"] = _objDataset.Tables[0];
                        gvLoginHistory.Visible = true;
                        lblmsg.Visible = false;
                        trpaging.Visible = true;
                    }
                    else
                    {
                        lblmsg.Text = "No Data Found";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                        gvLoginHistory.Visible = false;
                        trpaging.Visible = false;
                    }
                }
                else
                {
                    trpaging.Visible = false;
                    lblmsg.Text = "No Data Found";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Visible = true;
                }
            }
            else
            {
                trpaging.Visible = false;
                lblmsg.Text = "No Data Found";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }
            if (txtDate.Text == "1/1/1900")
            {
                txtDate.Text = "";
            }
            if (txttodate.Text == "1/1/1900")
            {
                txttodate.Text = "";
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Visible = true;
        }
    }
    protected void ddlpaging_SelectedIndexChanged(object sender, EventArgs e)
    {
          
        try
        {
            lblpaging.Visible = true;


            if (ddlpaging.SelectedIndex == 0)
            {
                gvLoginHistory.DataSource = ViewState["LoginHistory"];
                gvLoginHistory.DataBind();
            }
            else if (ddlpaging.SelectedValue == "1")
            {

                gvLoginHistory.PageSize = 40;
                gvLoginHistory.DataSource = ViewState["LoginHistory"];
                gvLoginHistory.DataBind();
            }

            else if (ddlpaging.SelectedValue == "2")
            {
                gvLoginHistory.PageSize = 80;
                gvLoginHistory.DataSource = ViewState["LoginHistory"];
                gvLoginHistory.DataBind();

            }
            else if (ddlpaging.SelectedValue == "3")
            {
                gvLoginHistory.PageSize = 120;
                gvLoginHistory.DataSource = ViewState["LoginHistory"];
                gvLoginHistory.DataBind();

            }
          

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}