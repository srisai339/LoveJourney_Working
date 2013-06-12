using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class Agent_MasterPage : System.Web.UI.MasterPage
{
    ClsBAL objManabusBAL;
  //  DataSet ObjDataset;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0) { Request.Browser.Adapters.Clear(); }
        ClsBAL objManabusBAL = new ClsBAL();
        //if (!IsPostBack)
        {
            if (Session["UserID"] != null && Session["Role"] != null)
            {
                if (Session["UserID"].ToString() != "INVALID USER"
                    && Session["Role"].ToString() == "Agent")
                {
                    if (Session["UserName"] != null)
                    {
                        lblUsername.Text = "Welcome <b>" + Session["UserName"].ToString() + " </b>";

                        System.Data.DataSet ds = objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                        Session["Balance"] = ds.Tables[0].Rows[0]["Balance"].ToString();


                        Session["BusAgentStatus"] = ds.Tables[0].Rows[0]["Buses"].ToString();
                        Session["HotelsAgentStatus"] = ds.Tables[0].Rows[0]["Hotels"].ToString();
                        Session["RechargeAgentStatus"] = ds.Tables[0].Rows[0]["Recharge"].ToString();
                        Session["InterNationalFlightsAgentStatus"] = ds.Tables[0].Rows[0]["InterNationalFlights"].ToString();
                        Session["DomesticFlighsAgentStatus"] = ds.Tables[0].Rows[0]["DomesticFlighs"].ToString();

                        lblBalance.Text = "" + Session["Balance"].ToString();
                    }
                    if (!IsPostBack)
                    {
                        imgAgentLogo.ImageUrl = "~/ActualImage.ashx?ID=" + Session["UserID"].ToString();
                        if (Session["View"].ToString() == "AgentView")
                        {
                            CustomerView.Visible = false; AgentView.Visible = true;
                        }
                        else if (Session["View"].ToString() == "CustomerView")
                        {
                            CustomerView.Visible = true; AgentView.Visible = false;
                        }
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
    protected void ibtnSwitch_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["View"].ToString() == "AgentView")
        {
            CustomerView.Visible = true; AgentView.Visible = false;
            ibtnSwitch.CommandName = "CustomerView";
            Session["View"] = "CustomerView";
        }
        else if (Session["View"].ToString() == "CustomerView")
        {
            CustomerView.Visible = false; AgentView.Visible = true;
            ibtnSwitch.CommandName = "AgentView";
            Session["View"] = "AgentView";
        }
    }
    protected void lbtnDeposits_Click(object sender, EventArgs e)
    {
        //lbtnDeposits.Font.Bold = true;
        //lbtnDeposits.ForeColor = System.Drawing.Color.Red;
        //lbtnBus.Font.Bold = lbtnProfile.Font.Bold = lbtnChangePassword.Font.Bold = false;
        Response.Redirect("~/Agent/Bus/Deposits.aspx", false);
    }
    protected void lbtnProfile_Click(object sender, EventArgs e)
    {
    //    lbtnProfile.Font.Bold = true;
    //    lbtnBus.Font.Bold = lbtnDeposits.Font.Bold = lbtnChangePassword.Font.Bold = false;
        Response.Redirect("~/Agent/Bus/Profile.aspx", false);
    }
    protected void lbtnChangePassword_Click(object sender, EventArgs e)
    {
        //lbtnChangePassword.Font.Bold = true;
        //lbtnBus.Font.Bold = lbtnDeposits.Font.Bold = lbtnProfile.Font.Bold = false;
        Response.Redirect("~/Agent/Bus/ChangePassword.aspx", false);
    }
    protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "LogOut") 
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
    protected void lnkButtonFeedBack_Click(object sender, EventArgs e)
    {
        mp3.Show();

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
