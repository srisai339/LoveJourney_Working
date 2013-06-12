using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BAL;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;
using System.Web;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;


public partial class Users_Recharge_MasterPage : System.Web.UI.MasterPage
{
    ClsBAL objManabusBAL;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0) { Request.Browser.Adapters.Clear(); }

        //if (!IsPostBack)
        {
            if (Session["UserID"] != null && Session["Role"] != null)
            {
                if (Session["UserID"].ToString() != "INVALID USER"
                    && Session["Role"].ToString() == "Admin")
                {
                    if (Session["UserName"] != null)
                    { 
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                        BalanceCheck();
                    }
                }
                else if (Session["Role"].ToString() == "CSE")
                {
                    if (Session["UserName"] != null)
                    {
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                        //BalanceCheck();
                    }
                }
                else if (Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
                {
                    showmenus();
                    lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    if (Session["Role"].ToString() == "Distributor")
                    {
                        lblDbBal.Text = "Your balance is : " + " " + Session["Balance"].ToString();

                    }
                }
                else if (Session["Role"].ToString() == "User")
                {
                    showmenus();
                    lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }

    protected void showmenus()
    {
        if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
        {
            viewagents.Visible = true; agentdeposits.Visible = true; agentrequests.Visible = true; fundtransferreport.Visible = true; stopservices.Visible = true; 
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
           // licse.Visible = true;
            liagents.Visible = true;
            lipromocode.Visible = true;
            lifeedback.Visible = true;
            lichangepassword.Visible = true;
            lisubmenurecharge.Visible = true;
            lisubmenumasters.Visible = true;
            lisubmenuStatus.Visible = true;
            lisubmenuReports.Visible = true;
            liuserreports.Visible = false;
            liReports1.Visible = true;
            liuserinfo.Visible = true;
            Cashcoupon.Visible = true;
            if (Session["Role"].ToString() == "Admin")
            {
                licse.Visible = true;
            }
            else
            {
                licse.Visible = false;
            }
            if (Session["Role"].ToString() == "Admin")
            {
                commissionslab.Visible = true;
            }
            else
            {
                commissionslab.Visible = false;
            }
            Tddmr.Visible = true;
            AgentRequests1.Visible = false;
            if (Session["Role"].ToString() == "Admin")
            {
                pendingRequest.Visible = true;
            }
            else
            {
                pendingRequest.Visible = false;
            }
            if (Session["Role"].ToString() == "CSE")
            {
                liagents.Visible = false;
                liuserinfo.Visible = false;
                Cashcoupon.Visible = false;
                lipromocode.Visible = false;
               
                lifeedback.Visible = false;
                lisubmenuReports.Visible = false;
                lisubmenumasters.Visible = false;
                lisubmenuStatus.Visible = false;
                lisubmenuReports.Visible = false;
                liuserreports.Visible = false;
              

            }
           
        }
        else if(Session["Role"].ToString() == "User")
        {
            Tddmr.Visible = false;
            lidashboard.Visible = false;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = false;
            licse.Visible = false;
            liagents.Visible = false;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenurecharge.Visible = true;
            lisubmenumasters.Visible = false;
            lisubmenuStatus.Visible = true;
            lisubmenuReports.Visible = false;
            liuserreports.Visible = true;
            liReports1.Visible = false;
            FeedBack.Visible = true;
            movietickets.Visible = false;
            utilities.Visible = false;
            liuserinfo.Visible = false;
            Cashcoupon.Visible = false;

         viewagents.Visible = false; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; 
        }
        else if (Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
        {
            viewagents.Visible = true; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false;
            Tddmr.Visible = true;
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = false;
            liagents.Visible = true;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenurecharge.Visible = true;
            lisubmenumasters.Visible = false;
            lisubmenuStatus.Visible = true;
            lisubmenuReports.Visible = false;
            liuserreports.Visible = true;
            liReports1.Visible = false;
            FeedBack.Visible = false;
            movietickets.Visible = false;
            utilities.Visible = false;
            liuserinfo.Visible = false;
            Cashcoupon.Visible = false;
            if (Session["Role"].ToString() == "Employee")
            {
                AgentRequests1.Visible = true;
                viewagents.Visible = false;
                agentrequestsfromemp.Visible = true;
                empRequests.Visible = false;
            }

            if (Session["Role"].ToString() == "Distributor")
            {
                emprequest.Visible = empRequests.Visible = false;
                city.Visible = carmaster.Visible = cardetails.Visible = policy.Visible = false;
                DistDeposits.Visible = DistDmr.Visible = DistProfile.Visible = DistLoginHistory.Visible = true;
            }
            else
            {
                AgentRequests1.Visible = false;

            }
            pendingRequest.Visible = false;
            if (Session["Role"].ToString() == "Employee" || Session["Role"].ToString() == "BSD")
            {

                lisubmenumasters.Visible = lisubmenuReports.Visible = liuserreports.Visible = false;
                emprequest.Visible = false;
                if (Session["Role"].ToString() == "BSD")
                {
                    empRequests.Visible = true;
                }
            }
        }
    }

    protected void BalanceCheck()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/PartnerBalance");
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        string postData = "PartnerId=10118&Hash=428EC1E88E87E1FEADB2F8FFBD2260E7C8FEDB3B";
        byte[] bytes = Encoding.UTF8.GetBytes(postData);
        request.ContentLength = bytes.Length;

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);

        WebResponse response = request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
    
        var result = reader.ReadToEnd();
        lblbalance.Text ="Your balance is :" + " "+ result;

        stream.Dispose();
        reader.Dispose();
   

        //HttpWebRequest oReq1 = null;
        //HttpWebResponse oRes1 = null;
        //StreamReader oStream1 = null;

        //string Pwd = "10118" + "A8JW8FX7KQ7PY5ZT2S1V";

        //string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd, "sha1");
     
        //string Hash = pwhash + "love@123";


        //oReq1 = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/PartnerBalance?&PartnerId=" + "10118" + "&Hash=" + pwhash);


        //oReq1.Method = "GET";
        //oReq1.Timeout = 10000;
        //oRes1 = (HttpWebResponse)oReq1.GetResponse();
        //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
        //string strMessage1 = oStream1.ReadToEnd().ToString();

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create
        //    ("http://www.payintegra.com/PartnerBalance?PartnerId=" + "10118" + "&Hash=" + "A8JW8FX7KQ7PY5ZT2S1Vlove@123");
        //request.Method = "GET";
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //DataSet ds1 = null;
        //if (response.StatusCode == HttpStatusCode.OK)
        //{
        //    StreamReader responseReader = new StreamReader(response.GetResponseStream());
        //    string responseData = responseReader.ReadToEnd();
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(responseData);
        //    XmlNodeReader xmlReader = new XmlNodeReader(doc);
        //    ds1 = new DataSet();
        //    ds1.ReadXml(xmlReader);
        //}
       // return strMessage1;
    }

    protected void lbtnlogout_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
                Session.Abandon();
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Menu3_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
    {
        if (e.Item.Value == "LogOut")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.name = txtName.Text;
            objManabusBAL.emailId = txtEmail.Text;
            objManabusBAL.mobileNo = txtPhone.Text;
            objManabusBAL.comments = txtComments.Text;
            if (objManabusBAL.AddFeedback())
            {

                lblmsg.Text = "Feedback submitted successfully to admin. Thanks for your feedback.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                txtName.Text = txtEmail.Text = txtPhone.Text = txtComments.Text = "";
            }
            else
            {
                lblmsg.Text = "Failed to send feedback. Please find try again.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        catch (Exception ex)
        {
            throw ex;
        }
    }
}