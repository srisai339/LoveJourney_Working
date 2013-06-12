using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class UserMasterPage : System.Web.UI.MasterPage
{
    ClsBAL objManabusBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        string page = Request.Url.ToString().ToLower();

        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        if (Request.UserAgent.IndexOf("AppleWebKit") > 0) { Request.Browser.Adapters.Clear(); }

        //if (!IsPostBack)
        {
            //if (Session["UserID"] != null && Session["Role"] != null)
            //{
            if (Session["UserID"].ToString() != "INVALID USER"
                && (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "Agent" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee"))
            {
                if (Session["UserName"] != null)
                {
                    if (page.Contains("frmflightsavailability.aspx"))
                    {
                        pnlflights.Visible = true;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("default.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = true;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("carprint.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }

                    else if (page.Contains("deposits.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("dmrreport.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }

                    else if (page.Contains("profile.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("logindetails.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("carticket.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("carbooking.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("cab_cancel.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("cabs_guestbookings.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }


                    else if (page.Contains("cab.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("cab_agentbookins.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("cabs_userbookings.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("carresult.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("passenger info.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }

                    else if (page.Contains("frmcity.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }

                    else if (page.Contains("frmcarmaster.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    else if (page.Contains("dmr.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    else if (page.Contains("frmcardescriptionmaster.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = true;
                    }
                    if (page.Contains("frmintflightsavailability.aspx"))
                    {
                        pnlflights.Visible = true;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    if (page.Contains("allagentreports.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = false;
                        pnlCars.Visible = false;
                    }
                    if (page.Contains("hotels.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = true;
                        pnlCars.Visible = false;
                    }
                    if (page.Contains("contactus.aspx"))
                    {
                        pnlflights.Visible = false;
                        pnl.Visible = false;
                        pnlhotels.Visible = true;
                        pnlCars.Visible = false;
                    }
                    showmenus();
                    lblUsername.Text = "Welcome <b>" + Session["UserName"].ToString() + "</b>";
                    if (Session["Role"].ToString() == "Distributor")
                    {
                        lblDbBal.Text = "Your balance is : " + " " + Session["Balance"].ToString();

                    }
                }
            }
            //else if (Session["Role"].ToString() == "User")
            //{
            //    if (Session["UserName"] != null)
            //    {
            //        showmenus();
            //        lblUsername.Text = "Welcome <b>" + Session["UserName"].ToString() + "</b>";
            //    }
            //}
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
            //}
            //else
            //{
            //    Response.Redirect("~/Default.aspx", false);
            //}
        }
    }
    
    //protected void showmenus()
    //{
    //    if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
    //    {
    //        viewagents.Visible = true; agentdeposits.Visible = true; agentrequests.Visible = true; fundtransferreport.Visible = true; stopservices.Visible = true; Rolemaster.Visible = true;

    //        aupdateflights.Visible = true;
    //        liuserreports.Visible = false;
    //        lidashboard.Visible = true;
    //        libuses.Visible = true;
    //        liflights.Visible = true;
    //        lihotels.Visible = true;
    //        lirecharge.Visible = true;
    //        if (Session["Role"].ToString() == "Admin")
    //        {
    //            licse.Visible = true;
    //            users.Visible = true;
    //        }
    //        else
    //        {
    //            licse.Visible = false;
    //        }
    //        if (Session["Role"].ToString() == "Admin")
    //        {
    //            commissionslab.Visible = true;
    //        }
    //        else
    //        {
    //            commissionslab.Visible = false;
    //        }
    //        liagents.Visible = true;
    //        lipromocode.Visible = true;
    //        lifeedback.Visible = true;
    //        lichangepassword.Visible = true;
    //        lisubmenuBooking.Visible = true;
    //        lisubmenusettings.Visible = true;
    //        lisubmenuReports.Visible = true;
    //        liReports1.Visible = true;
    //        Cars.Visible = false;
    //        movietickets.Visible = false;
    //        Cashcoupon.Visible = true;
    //        liuserinfo.Visible = true;
    //        li3.Visible = true;
    //        Tddmr.Visible = true;
    //        if (Session["Role"].ToString() == "Admin")
    //        {
    //            pendingRequest.Visible = true;
    //        }
    //        else
    //        {
    //            pendingRequest.Visible = false;
    //        }
    //    }
    //    else if (Session["Role"].ToString() == "User")
    //    {
    //        viewagents.Visible = false; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; Rolemaster.Visible = false;
    //        Tddmr.Visible = false;
    //        aupdateflights.Visible = false;
    //        li3.Visible = false;
    //        liuserreports.Visible = true;
    //        lidashboard.Visible = false;
    //        libuses.Visible = true;
    //        liflights.Visible = true;
    //        lihotels.Visible = true;
    //        lirecharge.Visible = false;
    //        licse.Visible = false;
    //        liagents.Visible = false;
    //        lipromocode.Visible = false;
    //        lifeedback.Visible = false;
    //        lichangepassword.Visible = true;
    //        lisubmenuBooking.Visible = false;
    //        lisubmenusettings.Visible = false;
    //        lisubmenuReports.Visible = false;
    //        liReports1.Visible = false;
    //        li1.Visible = true;
    //        movietickets.Visible = false;
    //        utilities.Visible = false;
    //        Cashcoupon.Visible = false;
    //        liuserinfo.Visible = false;
    //        FeedBack.Visible = true;
    //        BookTicket.Visible = true;
    //        PrintTicket.Visible = true;
    //        CancelTicket.Visible = true;
    //        li7.Visible = false;
    //        li8.Visible = false;
    //        lisubmenuAgentReports.Visible = false;
    //        users.Visible = false;
    //    }
    //    else if (Session["Role"].ToString() == "Distributor")
    //    {
    //        viewagents.Visible = true; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; Rolemaster.Visible = false;

    //        aupdateflights.Visible = false;
    //        liuserreports.Visible = true;
    //        lidashboard.Visible = true;
    //        libuses.Visible = true;
    //        liflights.Visible = true;
    //        lihotels.Visible = true;
    //        lirecharge.Visible = true;
    //        licse.Visible = false;
    //        users.Visible = false;
    //        commissionslab.Visible = false;
    //        liagents.Visible = true;
    //        lipromocode.Visible = false;
    //        lifeedback.Visible = false;
    //        lichangepassword.Visible = true;
    //        lisubmenuBooking.Visible = true;
    //        lisubmenusettings.Visible = false;
    //        lisubmenuReports.Visible = false;
    //        liReports1.Visible = false;
    //        Cars.Visible = false;
    //        movietickets.Visible = false;
    //        Cashcoupon.Visible = false;
    //        liuserinfo.Visible = false;
    //        li3.Visible = false;
    //        Tddmr.Visible = false;
    //    }
    //}

    protected void showmenus()
    {
        if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
        {
            viewagents.Visible = true; agentdeposits.Visible = true; agentrequests.Visible = true; fundtransferreport.Visible = true; stopservices.Visible = true; emprequest.Visible = true;
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
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

            liagents.Visible = true;
            lipromocode.Visible = true;
            lifeedback.Visible = true;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenusettings.Visible = true;
            lisubmenuReports.Visible = true;
            liReports1.Visible = true;
            Cars.Visible = true;
            movietickets.Visible = false;
            Cashcoupon.Visible = true;
            liuserinfo.Visible = true;
            //tddmr.Visible = true;
            AgentRequests1.Visible = false;
            if (Session["Role"].ToString() == "CSE")
            {
                liagents.Visible = false;
                liuserinfo.Visible = false;
                Cashcoupon.Visible = false;
                lipromocode.Visible = false;
                emp.Visible = false;
                lisubmenuReports.Visible = false;
                lisubmenusettings.Visible = false;
                Guestbookings.Visible = false;
                li3.Visible = false;
                li4.Visible = false;
                liuserreports.Visible = false;
                aupdateflights.Visible = false;


            }
            if (Session["Role"].ToString() == "Admin")
            {
                pendingRequest.Visible = true;
                Cars.Visible =true;
            }
            else
            {
                pendingRequest.Visible = false;
            }

        }
        else if (Session["Role"].ToString() == "User")
        {
            viewagents.Visible = false; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; emprequest.Visible = false;
            Cars.Visible = true;
            city.Visible = car.Visible = cardetails.Visible = false;
           // tddmr.Visible = false;
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
            lisubmenuBooking.Visible = false;
            lisubmenusettings.Visible = false;
            lisubmenuReports.Visible = false;
            liReports1.Visible = false;
            li1.Visible = true;
            movietickets.Visible = false;
            utilities.Visible = false;
            Cashcoupon.Visible = false;
            liuserinfo.Visible = false;
            FeedBack.Visible = true;
            BookTicket.Visible = true;
            PrintTicket.Visible = false;
            CancelTicket.Visible = true;
            AgentRequests1.Visible = false;
            pendingRequest.Visible = false;
            Tddmr.Visible = false;
            agentbookings.Visible = false;
            PrintTicket.Visible = true;
            aupdateflights.Visible = false;
            li3.Visible = false;
            emp.Visible = false;
            lisubmenuAgentReports.Visible = false;
            liCabBooking.Visible = liAgentCabBooking.Visible =liGusetBooking.Visible= false;
        }
        else if (Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
        {
            viewagents.Visible = true; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false; emprequest.Visible = false;

            emp.Visible = false;
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = false;

            commissionslab.Visible = false;
            liagents.Visible = true;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenusettings.Visible = false;
            lisubmenuReports.Visible = false;
            liReports1.Visible = false;
            Cars.Visible = true;
            movietickets.Visible = false;
            Cashcoupon.Visible = false;
            liuserinfo.Visible = false;
            aupdateflights.Visible = false;
            city.Visible = car.Visible = cardetails.Visible = false;
            if (Session["Role"].ToString() == "Employee")
            {
                AgentRequests1.Visible = true;
                viewagents.Visible = false;
                agentrequestsfromemp.Visible = true;
                empRequests.Visible = false;
            }

            if (Session["Role"].ToString() == "Distributor")
            {
                DistDeposits.Visible = DistDmr.Visible = DistProfile.Visible = DistLoginHistory.Visible = true;
                empRequests.Visible = false;
                li3.Visible = false;
                li1.Visible = true;
                liReports1.Visible = true;
                Guestbookings.Visible = false;
            }
           

            else
            {
                AgentRequests1.Visible = false;
            }
            if (Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                li3.Visible = li4.Visible = liuserreports.Visible = li5.Visible = li7.Visible = lisubmenuAgentReports.Visible=false;
            }
            pendingRequest.Visible = false;
            liCabBooking.Visible = liAgentCabBooking.Visible = false;
            Cars.Visible = true;

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
