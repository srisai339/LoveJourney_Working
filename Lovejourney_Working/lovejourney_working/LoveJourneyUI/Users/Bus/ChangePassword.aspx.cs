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
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        if (!IsPostBack) 
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    tblmain.Visible = true;
                    txtCurrentPassword.Focus();
                }
                else
                {
                    tdmsg.Visible = true; tdmsg.Style.Add("background-color:#E77471;", ""); tblmain.Visible = false;
                    lblMainMsg.Text = "  No access permission to this page. Please contact the Administrator for further details. ";
                    CheckPermission("ChangePassword", Session["Role"].ToString());                 
                    txtCurrentPassword.Focus();
                    
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }



           
        }
        this.Page.Title = "LoveJourney - Change Password";
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            tblmain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                tblmain.Visible = false;

                ClsBAL objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                DataSet objDataSet = (DataSet)objBAL.GetPerByUser();
                if (objDataSet != null)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserPermissions"] = objDataSet.Tables[0];
                        ViewState["Book"] = objDataSet.Tables[0].Rows[0]["Book"].ToString();
                    }
                    else { ViewState["UserPermissions"] = null; }
                }
                else { ViewState["UserPermissions"] = null; }

                if (ViewState["UserPermissions"] != null)
                {
                    if (ViewState["Book"] != null)
                    {
                        if (ViewState["Book"].ToString() == "1")
                        {
                            tblmain.Visible = true;
                            tdmsg.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            string msg = obj.ChangePassword(Convert.ToInt32(Session["UserID"].ToString()), txtPassword.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString()), txtCurrentPassword.Text.Trim().ToString());
            lblMsg.InnerHtml = msg;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
}