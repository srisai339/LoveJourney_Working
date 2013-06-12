using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;


public partial class SelectBus : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            string page = Request.Url.ToString().ToLower();
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                if (page.Contains("selectbus.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;
                   // HtmlGenericControl div = (HtmlGenericControl)this.Master.FindControl("divid");
                }
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                if (page.Contains("selectbus.aspx"))
                {
                    string url = "BusMasterpage.master";
                    this.MasterPageFile = url;

                }
            }
            else if (Session["Role"].ToString() == "CSE")
            {
                if (page.Contains("selectbus.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;

                }
            }
            else if (Session["Role"].ToString() == "User")
            {
                if (page.Contains("selectbus.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;
                }
            }
           
          
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
        }
    }   

    
}