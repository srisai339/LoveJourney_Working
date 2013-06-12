using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUsername.Focus();
        }
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Login";
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            objManabusBAL.userName = Convert.ToString(txtUsername.Text);
            objManabusBAL.password = Convert.ToString(txtPasword.Text);

            if (objManabusBAL.CheckUser() == "Valid User")
            {
                if (Session["Role"] != null)
                {

                    if (Session["Role"].ToString() == "Admin")
                    {
                        Session["Balance"] = "";
                        Response.Redirect("~/Users/AdminDb/AdminDb.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Agent" )
                    {
                        System.Data.DataSet ds = objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                        Session["Balance"] = ds.Tables[0].Rows[0]["Balance"].ToString();
                        Session["View"] = "AgentView";
                        string ss = ds.Tables[0].Rows[0]["Status"].ToString();
                        if (ss.ToUpper().ToString() != "HOLD")
                        {
                            Response.Redirect("~/Default.aspx", false);
                        }
                        else
                        {
                            lblMsg.Text = "Your account is on HOLD. Please contact the administrator.";
                            lblMsg.ForeColor = System.Drawing.Color.White;
                            Session["UserID"] = null;
                        }
                    }
                    else if (Session["Role"].ToString() == "CSE")
                    {
                        Session["Balance"] = "";
                        Response.Redirect("~/Users/AdminDb/AdminDb.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
                    {
                        System.Data.DataSet ds = objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                        Session["Balance"] = ds.Tables[0].Rows[0]["Balance"].ToString();
                        Session["View"] = "AgentView";
                        string ss = ds.Tables[0].Rows[0]["Status"].ToString();
                        if (ss.ToUpper().ToString() != "HOLD")
                        {
                            Response.Redirect("~/Users/AdminDb/AdminDb.aspx", false);
                        }
                        else
                        {
                            lblMsg.Text = "Your account is on HOLD. Please contact the administrator.";
                            lblMsg.ForeColor = System.Drawing.Color.White;
                            Session["UserID"] = null;
                        }
                       
                    }
                    else if (Session["Role"].ToString() == "User")
                    {
                        System.Data.DataSet ds = objManabusBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                        string ss = ds.Tables[0].Rows[0]["Status"].ToString();
                        if (ss.ToUpper().ToString() != "HOLD")
                        {
                            Session["Balance"] = "";
                            Response.Redirect("~/Default.aspx", false);
                        }
                        else
                        {
                            lblMsg.Text = "Your account is on HOLD. Please contact the administrator."; lblMsg.ForeColor = System.Drawing.Color.White;
                            Session["UserID"] = null;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "UserName / Password Is Incorrect.";
                        lblMsg.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            else
            {
                lblMsg.Text = "UserName / Password Is Incorrect.";
                lblMsg.ForeColor = System.Drawing.Color.White;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw ex;
        }
    }

}