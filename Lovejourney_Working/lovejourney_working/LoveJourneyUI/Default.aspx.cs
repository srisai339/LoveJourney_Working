using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Net;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

public partial class Bus : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
        pnl.Visible = false;
        if (Session["UserID"] != null)
        {
            string page = Request.Url.ToString().ToLower();

            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                if (page.Contains("default.aspx"))
                {
                    User_menu.Visible = false;
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;
                   HtmlGenericControl div = (HtmlGenericControl)this.Master.FindControl("divid");
                }
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                if (page.Contains("default.aspx"))
                {
                    User_menu.Visible = false;
                    string url = "AgentMasterPage.master";
                    this.MasterPageFile = url;


                }
            }
            else if (Session["Role"].ToString() == "CSE")
            {
                if (page.Contains("default.aspx"))
                {
                    User_menu.Visible = false; 
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;

                }
            }
            else if (Session["Role"].ToString() == "User")
            {
                if (page.Contains("default.aspx"))
                {
                    User_menu.Visible = true;
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;

                }
            }
            else
            {
                User_menu.Visible = true;
            }

          
        }
        else
        {
            User_menu.Visible = true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null)
        {

            string str = Request.QueryString["Type"];
            if (str != null)
            {
                seachbus.Text = "Search Your Tour Here";
            }
        }
        
    }
    protected string invokeGetRequest(string requestUrl, string contentType)
    {
        string completeUrl = requestUrl;
        string responseString;
        try
        {
            HttpWebRequest request1 = WebRequest.Create(completeUrl) as HttpWebRequest;
            request1.ContentType = contentType;
            request1.Method = @"GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse();
            using (BufferedStream buffer = new BufferedStream(httpWebResponse.GetResponseStream()))
            {
                using (StreamReader reader = new StreamReader(buffer))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            //StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            //string responseString = reader.ReadToEnd();
            return responseString;
        }
        catch (WebException ex)
        {
            //reading the custom messages sent by the server
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            return "Failed with exception message:" + ex.Message;
        }
    }
}