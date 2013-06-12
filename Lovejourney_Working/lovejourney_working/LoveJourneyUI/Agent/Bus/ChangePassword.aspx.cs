using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCurrentPassword.Focus();
            if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }


            Panel men1 = (Panel)this.Master.FindControl("Menu1");
            men1.Visible = false;
        }
        this.Page.Title = "LoveJourney - ChangePassword";
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                ClsBAL obj = new ClsBAL();
                string msg = obj.ChangePassword(Convert.ToInt32(Session["UserID"].ToString()), txtPassword.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString()), txtCurrentPassword.Text.Trim().ToString());
                lblMsg.InnerHtml = msg;
            }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
}