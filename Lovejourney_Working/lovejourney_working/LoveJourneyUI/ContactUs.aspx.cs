using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class ContactUs : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objManabusBAL;
    DataSet ObjDataset;
    string masterpage1;

    #endregion
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {

                this.MasterPageFile = "UserMasterPage.master";
                masterpage1 ="UserMasterPage.master";
            }
            else if (Session["Role"].ToString() == "Agent")
            {

                this.MasterPageFile = "AgentMasterPage.master";
                 masterpage1 = "AgentMasterPage.master";
            }

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtName.Focus();
            if (masterpage1 == "AgentMasterPage.master")
            {
                Panel pnl = (Panel)this.Master.FindControl("Menu1");
                Panel pnl1 = (Panel)this.Master.FindControl("pnlflights");
                Panel pnl2 = (Panel)this.Master.FindControl("pnlhotels");
                pnl.Visible = pnl2.Visible = pnl1.Visible = false;
            }
            else
            {
                Panel pnl = (Panel)this.Master.FindControl("Menu1");
                Panel pnl1 = (Panel)this.Master.FindControl("pnlflights");
                Panel pnl2 = (Panel)this.Master.FindControl("pnlhotels");

            }
        }
        this.Page.Title = "LoveJourney - Contact Us";
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