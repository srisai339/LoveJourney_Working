using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class Users_Flight_MasterPage : System.Web.UI.MasterPage
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
                    && Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
                {
                    if (Session["UserName"] != null)
                    {
                        
                            showmenus();
                            lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                        
                    }
                }
                else if (Session["UserID"].ToString() != "INVALID USER"
                   && Session["Role"].ToString() == "CSE")
                {
                    if (Session["UserName"] != null)
                    {
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    }
                }
                else if (Session["Role"].ToString() == "User")
                {
                    showmenus();
                    lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    showmenus();
                    lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    if (Session["Role"].ToString() == "Distributor")
                    {
                        lblDbBal.Text = "Your balance is : " + " " + Session["Balance"].ToString();

                    }
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
            aupdateflights.Visible = true;
            liuserreports.Visible = false;
            Cashcoupon.Visible = true;
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
          //  licse.Visible = true;
            liagents.Visible = true;
            lipromocode.Visible = true;
            lifeedback.Visible = true;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenuSettings.Visible = true;        
            lisubmenuReports.Visible = true;
            liReports1.Visible = true;
            liuserinfo.Visible = true;
            li1.Visible = true;
            Tddmr.Visible = true;
            if (Session["Role"].ToString() == "Admin")
            {
                pendingRequest.Visible = true;
            }
            else
            {
                pendingRequest.Visible = false;
            }
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
            if (Session["Role"].ToString() == "CSE")
            {
                liagents.Visible = false;
                liuserinfo.Visible = false;
                Cashcoupon.Visible = false;
                lipromocode.Visible = false;
                lisubmenuReports.Visible = false;
                lisubmenuSettings.Visible = false;
                li1.Visible = false;
                lifeedback.Visible = false;
                guestbookings.Visible = false;
                aupdateflights.Visible = false;
                


            }
           
        }
        else if (Session["Role"].ToString() == "User")
        {
            Tddmr.Visible = false;
            aupdateflights.Visible = false;
            liuserreports.Visible = true;
            Cashcoupon.Visible = false;
            lidashboard.Visible = false;
            libuses.Visible = true ;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = false;
            licse.Visible = false;
            liagents.Visible = false;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenuSettings.Visible = false;         
            lisubmenuReports.Visible = false;
            liReports1.Visible = false;
            li1.Visible = false;
            liuserinfo.Visible = false;
           // Td1.Visible = true;
            movietickets.Visible = false;
            utilities.Visible = false;
            FeedBack.Visible = true;
            viewagents.Visible = false; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false;
            lisubmenuSettings.Visible = true;
        }
        else if (Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
        {
            viewagents.Visible = true; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; 
            Tddmr.Visible = false;
            aupdateflights.Visible = false;
            liuserreports.Visible = true;
            Cashcoupon.Visible = false;
            lidashboard.Visible = false;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = false;
            liagents.Visible = true;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenuSettings.Visible = false;
            lisubmenuReports.Visible = false;
            liReports1.Visible = false;
            li1.Visible = false;
            liuserinfo.Visible = false;
            // Td1.Visible = true;
            movietickets.Visible = false;
            utilities.Visible = false;
            FeedBack.Visible = false;
            liuserreports.Visible = false;
            lidashboard.Visible = true  ;
            Tddmr.Visible = true;
            if (Session["Role"].ToString() == "Employee")
            {
                AgentRequests1.Visible = true;
                viewagents.Visible = false;
                agentrequestsfromemp.Visible = true;
                emprequest.Visible = false;
            }

            if (Session["Role"].ToString() == "Distributor")
            {
                AgentRequests1.Visible = false;
                viewagents.Visible = true;
                agentrequestsfromemp.Visible = false;
                emprequest.Visible = false;
                DistDeposits.Visible = DistDmr.Visible = DistProfile.Visible = DistLoginHistory.Visible = true;
            }
            else
            {
                AgentRequests1.Visible = false;
            }
            pendingRequest.Visible = false;
        }
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
