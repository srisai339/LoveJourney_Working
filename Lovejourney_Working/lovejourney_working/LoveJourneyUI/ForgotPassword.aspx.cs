using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Net;
using System.IO;
using System.Text;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUsername.Focus();
        }
        lblMsg.Text = "";
        lblMsg.ForeColor = System.Drawing.Color.Red;
        this.Page.Title = "LoveJourney - ForgotPassword";
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            string message = obj.ForgotPassword(txtUsername.Text.Trim().ToString(), txtPasword.Text.Trim().ToString());
            if (message == "UserName you entered is invalid." || message == "EmailId you provided is not exists in the database.")
            {
                lblMsg.Text = message;
            }
            else
            {
                string body = "HI " + txtUsername.Text.ToString() + ",<br/><br/>" + "Your password is " + message + "<br/>" + "<br/><br/>Thanks & Regards,<br/>LoveJourney Team.";
                Mailsender.SendEmail(txtPasword.Text.ToString(), "", "", "LoveJourney Account Password", body);
                lblMsg.Text = "Password has been sent to your email id.";
                txtPasword.Text = txtUsername.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    
    }

   
}