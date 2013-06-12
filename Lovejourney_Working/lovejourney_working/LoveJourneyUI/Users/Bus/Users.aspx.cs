using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.IO;

public partial class Users_Users : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    DataSet ObjDataset1;
    DataTable ObjDatatable;
    DataView ObjDataview;
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnNewUser);
        if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - Users";

            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "CSE")
                {                    
                        tdmsg.Visible = true;
                        //  tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        MVUsers.ActiveViewIndex = 0;
                        MVUsers.Visible = false;
                        CheckPermission("CSE", Session["Role"].ToString());
                        BindUsers();
                        btnSaveUD.Visible = true;
                        btnCancel.Visible = true;
                        btnUpdateUD.Visible = false;
                   
                }
                else
                {
                    BindUsers();
                    btnSaveUD.Visible = true;
                    btnCancel.Visible = true;
                    btnUpdateUD.Visible = false;
                    MVUsers.ActiveViewIndex = 0;
                    MVUsers.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            MVUsers.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                MVUsers.Visible = false;

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
                            MVUsers.Visible = true;
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
    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "User";
            ObjDataset = (DataSet)objBAL.GetPerByUser();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = ObjDataset.Tables[0];
                    ViewState["AddUser"] = ObjDataset.Tables[0].Rows[0]["Add"].ToString();
                    ViewState["ViewUser"] = ObjDataset.Tables[0].Rows[0]["View"].ToString();
                    ViewState["DeleteUser"] = ObjDataset.Tables[0].Rows[0]["Delete"].ToString();
                    ViewState["EditUser"] = ObjDataset.Tables[0].Rows[0]["Edit"].ToString();
                    ViewState["PermissionUser"] = ObjDataset.Tables[0].Rows[0]["Permission"].ToString();
                }
                else
                {
                    ViewState["UserPermissions"] = null;
                }
            }
            else
            {
                ViewState["UserPermissions"] = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BindUsers()
    {
        try
        {
            objBAL = new ClsBAL();

            ObjDataset = objBAL.GetUsers();
            if (ObjDataset != null)
            {
                ViewState["Users"] = ObjDataset.Tables[0];
                GvUsers.Visible = true;
                GvUsers.DataSource = ObjDataset.Tables[0];
                GvUsers.DataBind();
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    lbtnXport2Xcel.Visible = true;
                }
                else
                {
                    lbtnXport2Xcel.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "BindUsers", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            if (ObjDataset != null) { ObjDataset = null; }
            if (ObjDataset1 != null) { ObjDataset1 = null; }
            if (ObjDatatable != null) { ObjDatatable = null; }
            if (ObjDataview != null) { ObjDataview = null; }
        }
    }

    protected void BindRoles()
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            //objBAL = new ClsBAL();
            //ObjDataset = objBAL.GetRoles();
            //if (ObjDataset != null)
            //{
            //    if (ObjDataset.Tables[0].Rows.Count > 0)
            //    {
            //        ViewState["Roles"] = ObjDataset.Tables[0];
            //        ddlRole.DataSource = ObjDataset.Tables[0];
            //        ddlRole.DataTextField = "Role";
            //        ddlRole.DataValueField = "ID";
            //        ddlRole.DataBind();
            //        ddlRole.Items.Insert(0, "--Select--");
            //    }
            //}
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "BindRoles", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            if (ObjDataset != null) { ObjDataset = null; }
            if (ObjDataset1 != null) { ObjDataset1 = null; }
            if (ObjDatatable != null) { ObjDatatable = null; }
            if (ObjDataview != null) { ObjDataview = null; }
        }
    }

    private void ClaerFields()
    {
        try
        {
            txtCnfrmPswd.Text = txtName.Text = txtPassword.Text = txtUsername.Text = "";
            // ddlRole.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbtnNewUser_Click(object sender, EventArgs e)
    {
        try
        {
            Cleardata();
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            //if (ViewState["UserPermissions"] != null)
            //{
            //    if (ViewState["AddUser"].ToString() == "1")
            //    {
            //if (ViewState["Roles"] != null)
            //{
            //    ddlRole.DataSource = ViewState["Roles"];
            //    ddlRole.DataTextField = "Role";
            //    ddlRole.DataValueField = "ID";
            //    ddlRole.DataBind();
            //    ddlRole.Items.Insert(0, "--Select--");
            //}
            //else
            //{
            //    BindRoles();
            //}
            btnSaveUD.Visible = true;
            btnCancel.Visible = true;
            btnUpdateUD.Visible = false;
            MVUsers.ActiveViewIndex = 1;
            MVUsers.Visible = true;
            txtUsername.Enabled = true;
            // }
            //    else
            //    {
            //        tdmsg.Visible = true;
            //        tdmsg.Style.Add("background-color:#E77471;", "");
            //        lblMainMsg.Text = "   No Permission to Add Users.Please Contact Administrator for further details...";
            //        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            //        MVUsers.ActiveViewIndex = 0;
            //        MVUsers.Visible = true;
            //    }
            //}
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "lbtnNewUser_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            if (ViewState["Users"] != null)
            {
                GvUsers.DataSource = ViewState["Users"];
                GvUsers.DataBind();
            }
            else
            {
                BindUsers();
            }

            btnSaveUD.Visible = true;

            btnCancel.Visible = true;
            btnUpdateUD.Visible = false;
            txtCnfrmPswd.TextMode = TextBoxMode.Password;
            txtPassword.TextMode = TextBoxMode.Password;

            MVUsers.ActiveViewIndex = 0;
            MVUsers.Visible = true;
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnCancel_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            txtUsername.Text = "";
            txtName.Text = "";
            ddlRole.SelectedIndex = 0;
            lblID.Text = "";
            txtPassword.Text = "";
            txtCnfrmPswd.Text = "";
        }
    }

    protected void btnSaveUD_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            string message = "";
          
            objBAL = new ClsBAL();
         message =   objBAL.AddAgent(txtName.Text.Trim(), "", Convert.ToDateTime("1/1/1900"), txtCity.Text.Trim().ToString(),
         ddlState.SelectedItem.Text.ToString(),
         txtAddress.Text.Trim().ToString(),
         txtPinCode.Text.Trim().ToString(),
         txtMobileNo.Text.Trim().ToString(),
          "", "", txtEmailId.Text.Trim().ToString(), "", "", "1",
         txtUsername.Text.Trim().ToString(),
         txtPassword.Text.Trim().ToString(),
         0,
        0, Convert.ToInt32("0"), "CSE", ddlcountry.SelectedValue,"","","","","","");

            // lblMainMsg.Text = message;


         if (message == "Agent registration is completed successfully.")
         {
             Label1.Text = "CSE Registration is Completed Successfully";

             mail();
             BindUsers();
             Cleardata();

             MVUsers.ActiveViewIndex = 0;
             MVUsers.Visible = true;
             lblMainMsg.ForeColor = System.Drawing.Color.Green;

         }
         else
         {
             lblMainMsg.ForeColor = System.Drawing.Color.Red;
             tdmsg.Visible = true;
             lblMainMsg.Text = message;
         }
   
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnSaveUD_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void Cleardata()
    {
        txtName.Text = txtUsername.Text = txtPassword.Text = txtAddress.Text = txtCity.Text = txtPinCode.Text = txtMobileNo.Text = txtEmailId.Text = "";
        ddlState.SelectedIndex = 0; ddlcountry.SelectedIndex = 0;
    }
    protected void mail()
    {

        //string Body = "Dear <b>" + txtName.Text + "</b>," +
        //"<br /><br />Let us welcome you  with lovejourney.in . " +
        // "Following are your login details. <br/> <br/>" +
        //" Email ID :<b>" + txtEmailId.Text.Trim() + "</b><br />" +
        //" Password : <b>" + txtPassword.Text.Trim() + "</b><br/>" +
        //"<br /><br />you have successfully registered in www.lovejourney.in and please" +
        //"do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
        //"should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://info@lovejourney.in'> lovejourney.in</a>" +
        //"<br /><br />";

        //MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);


        string Body = "<html><head><title>LOVE JOURNEY - Registry Creation Account Mail</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding:0;       margin:0;font-family:Arial, Helvetica, sans-serif;font-size:12px;font-weight:normal;color:#000;'>" +
                                       "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/images/logo.gif' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                       "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Buses * Hotels * Recharge</td></tr>" +
                                       "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>you have successfully registered in www.lovejourney.in by the admin  </strong></td></tr>" +
                                       "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td align='center' valign='middle'><strong>Your New User Account Login Information</strong><br />Please keep the following information for your records:<br /><strong>User Name:</strong> <a href='#'>" + txtUsername.Text.Trim().ToString() + "</a><br /><strong>Password:</strong> " + txtPassword.Text.Trim().ToString() + "<br /></td></tr>" +
                                       "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>Please use this  username/password combination the next time you log on.<br />If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +
                                       "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr> <tr><td height='30' align='center' valign='middle'><strong>Login to your account  online using the following link:</strong></td></tr>" +
                                       "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><strong><a href='http://lovejourney.in/Login.aspx'>http://lovejourney.in/Login.aspx&nbsp;</a></strong><br /><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                       "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                       "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                       "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                       "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);

    }
    protected void GvUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Change")
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            // int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.      
            // GridViewRow row = GvUsers.Rows[index];
            try
            {
                //if (ViewState["UserPermissions"] != null)
                //{
                //if (ViewState["EditUser"].ToString() == "1")
                //{
                GridViewRow gRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                // GridViewRow gRow = (GridViewRow)(Label)e.CommandSource;
                Label lblUserName1 = (Label)gRow.FindControl("lblUserName");
                Label lblName1 = (Label)gRow.FindControl("lblName");
                LinkButton lblRoleID1 = (LinkButton)gRow.FindControl("lblRoleID");
                Label lblID1 = (Label)gRow.FindControl("lblID");
                Label lblPassword1 = (Label)gRow.FindControl("lblPassword");

                Label lblEmailId = (Label)gRow.FindControl("lblEmailId");
                Label lblAddress = (Label)gRow.FindControl("lblAddress");
                Label lblCity = (Label)gRow.FindControl("lblCity");
                Label lblState = (Label)gRow.FindControl("lblState");
                Label lblCountry = (Label)gRow.FindControl("lblCountry");
                Label lblPinCode = (Label)gRow.FindControl("lblPinCode");
                Label lblMobileNo = (Label)gRow.FindControl("lblMobileNo");


                txtUsername.Text = lblUserName1.Text;
                txtName.Text = lblName1.Text;
                ddlRole.SelectedValue = lblRoleID1.Text;
                lblID.Text = lblID1.Text;
                txtPassword.Text = lblPassword1.Text;
                txtCnfrmPswd.Text = lblPassword1.Text;
                txtCnfrmPswd.TextMode = TextBoxMode.SingleLine;
                txtPassword.TextMode = TextBoxMode.SingleLine;

                txtUsername.Enabled = false;

                txtEmailId.Text = lblEmailId.Text;
                txtAddress.Text = lblAddress.Text;
                txtCity.Text = lblCity.Text;
                ddlState.Text = lblState.Text;
                ddlcountry.Text = lblCountry.Text;
                txtPinCode.Text = lblPinCode.Text;
                txtMobileNo.Text = lblMobileNo.Text;

                btnSaveUD.Visible = false;
                btnCancel.Visible = true;
                btnUpdateUD.Visible = true;
                BindRoles();
                MVUsers.ActiveViewIndex = 1;
                MVUsers.Visible = true;
                //}
                //else
                //{
                //    tdmsg.Visible = true;
                //    tdmsg.Style.Add("background-color:#E77471;", "");
                //    lblMainMsg.Text = "   No Permission to Edit Users.Please Contact Administrator for further details...";
                //    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                //    MVUsers.ActiveViewIndex = 0;
                //    MVUsers.Visible = true;
                //}
                // }

            }
            catch (Exception ex)
            {
                objBAL.Logerror(this.Page.ToString(), "GvUsers_RowCommand_Change", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
                throw;
            }
            #region TEst
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script language='javascript'>");
            //sb.Append(@"$(document).ready(function () {");
            //sb.Append(@"$('[id$='txtUsername']').val =");
            //sb.Append(lblUserName1.Text);
            //sb.Append(@";$('[id$='txtName']').val = ");
            //sb.Append(lblName1.Text);
            //sb.Append(@";$('[id$='txtPassword']').val =");
            //sb.Append(lblPassword1.Text);
            //sb.Append(@";$('[id$='txtCnfrmPswd']').val =");
            //sb.Append(lblPassword1.Text);
            //sb.Append(@";$('[id$='ddlRole']').val =");
            //sb.Append(lblRoleID1.Text);
            //sb.Append(@"$('.adduser').show('slow');");
            //sb.Append(@"$('.abc').hide('slow');");
            //sb.Append(@"$('[id$='btnSaveUD']').hide('slow');");
            //sb.Append(@"$('[id$='btnUpdateUD']').show('slow');");
            //sb.Append(@"});});");            
            //sb.Append(@"</script>");

            //ScriptManager.RegisterStartupScript(GvUsers, GvUsers.GetType(), "JSCR", sb.ToString(), false);
            #endregion
        }
        if (e.CommandName == "Remove")
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            try
            {
                //if (ViewState["UserPermissions"] != null)
                //{
                //if (ViewState["DeleteUser"].ToString() == "1")
                //{
                GridViewRow gRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                // GridViewRow gRow = (GridViewRow)(Label)e.CommandSource;

                Label lblID1 = (Label)gRow.FindControl("lblID");
                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(lblID1.Text);
                objBAL.modifiedBy = Convert.ToInt32(1);
                if (objBAL.DeleteUser())
                {
                    tdmsg.Visible = true;
                   // tdmsg.Style.Add("background-color:#6CC417;", "");
                    lblMainMsg.Text = "User details Deleted Successfully....";
                    lblMainMsg.ForeColor = System.Drawing.Color.Green;
                    BindUsers();
                    MVUsers.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                   // tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "OOPS...Failed to Delete user setails....";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                }
                //}
                //else
                //{
                //    tdmsg.Visible = true;
                //    tdmsg.Style.Add("background-color:#E77471;", "");
                //    lblMainMsg.Text = "   No Permission to delete Users.Please Contact Administrator for further details...";
                //    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                //    MVUsers.ActiveViewIndex = 0;
                //    MVUsers.Visible = true;
                //}
                // }
            }
            catch (Exception ex)
            {
                objBAL.Logerror(this.Page.ToString(), "GvUsers_RowCommand_Remove", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
                throw;
            }

        }
        if (e.CommandName == "Permissions")
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            try
            {
                GridViewRow gRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                Label lblUserName1 = (Label)gRow.FindControl("lblUserName");
                Label lblName1 = (Label)gRow.FindControl("lblName");
                Label lblRole1 = (Label)gRow.FindControl("lblRole");
                Label lblID1 = (Label)gRow.FindControl("lblID");
                Label lblPassword1 = (Label)gRow.FindControl("lblPassword");
                lblRolePer.Text = lblRole1.Text;
                lblUserNamePer.Text = lblUserName1.Text;
                lblUserID.Text = lblID1.Text;
                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(lblID1.Text);
                ObjDataset = (DataSet)objBAL.GetScreens();
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Screens"] = ObjDataset.Tables[0];

                        ObjDataset1 = (DataSet)objBAL.GetUserPermissions();
                        if (ObjDataset1 != null)
                        {
                            ViewState["Permissions"] = ObjDataset1.Tables[0];
                        }

                        GvPermissions.DataSource = ObjDataset.Tables[0];
                        GvPermissions.DataBind();
                        MVUsers.ActiveViewIndex = 2;
                    }
                    else
                    {
                        ViewState["Permissions"] = null;
                        objBAL = new ClsBAL();
                        ObjDataset1 = (DataSet)objBAL.GetScreens();
                        if (ObjDataset1 != null)
                        {
                            GvPermissions.DataSource = ObjDataset1.Tables[0];
                            GvPermissions.DataBind();
                            MVUsers.ActiveViewIndex = 2;
                        }
                    }

                }
                else
                {
                    ViewState["Permissions"] = null;
                    objBAL = new ClsBAL();
                    ObjDataset1 = (DataSet)objBAL.GetScreens();
                    if (ObjDataset1 != null)
                    {
                        GvPermissions.DataSource = ObjDataset1.Tables[0];
                        GvPermissions.DataBind();
                        MVUsers.ActiveViewIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                objBAL.Logerror(this.Page.ToString(), "GvUsers_RowCommand_Permissions", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
                throw;
            }
            finally
            {
                if (ObjDataset != null) { ObjDataset = null; }
                if (ObjDataset1 != null) { ObjDataset1 = null; }
                if (ObjDatatable != null) { ObjDatatable = null; }
                if (ObjDataview != null) { ObjDataview = null; }
            }
        }
    }

    protected void GvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblScreenID1 = (Label)e.Row.FindControl("lblScreenID");
            Label lblScreenName1 = (Label)e.Row.FindControl("lblScreenName");
            CheckBox ChkAdd1 = (CheckBox)e.Row.FindControl("ChkAdd");
            //CheckBox ChkView1 = (CheckBox)e.Row.FindControl("ChkView");
            //CheckBox ChkDelete1 = (CheckBox)e.Row.FindControl("ChkDelete");
            //CheckBox ChkEdit1 = (CheckBox)e.Row.FindControl("ChkEdit");
            //CheckBox ChkPermissions1 = (CheckBox)e.Row.FindControl("ChkPermissions");
            //CheckBox ChkReports1 = (CheckBox)e.Row.FindControl("ChkReports");
            //  Button l = (Button)e.Row.FindControl("btnDelete");

            // l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete this record?'");

            DataTable dt = (DataTable)ViewState["Permissions"];

            int i;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (lblScreenName1.Text == dt.Rows[i]["ScreenName"].ToString() && dt.Rows[i]["Book"].ToString() == "1")
                {
                    ChkAdd1.Checked = true;
                }
            }

            //if (ViewState["Permissions"] == null)
            //{
            //    if (lblScreenName1.Text == "Ticket")
            //    {
            //        ChkAdd1.Text = "Book";
            //        ChkEdit1.Text = "Cancel";
            //        ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //    }
            //    if (lblScreenName1.Text == "Office Pickup Ticket") { ChkAdd1.Visible = ChkDelete1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Home Delivery Ticket") { ChkAdd1.Visible = ChkDelete1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Customer Request") { ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Customer Inquiry") { ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Tentative Booking") { ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Commission") { ChkDelete1.Visible = ChkPermissions1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Coupon") { ChkDelete1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Report") { ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false; }
            //    if (lblScreenName1.Text == "Transaction") { ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false; }
            //}
            //else
            //{
            //    DataTable dt = (DataTable)ViewState["Permissions"];

            //    if (lblScreenName1.Text == "Ticket" && dt.Rows[0]["ScreenName"].ToString() == "Ticket")
            //    {
            //        ChkAdd1.Text = "Book";
            //        //ChkEdit1.Text = "Cancel";
            //        //ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[0]["Book"].ToString() == "1")
            //        {
            //            ChkAdd1.Checked = true;
            //        }
            //        else if (dt.Rows[0]["Book"].ToString() == "0")
            //        { 
            //            ChkAdd1.Checked = false; 
            //        }
            //        //if (dt.Rows[0]["Cancel"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[0]["Cancel"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[0]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[0]["View"].ToString() == "0") { ChkView1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Office Pickup Ticket")
            //    {
            //        ChkAdd1.Visible = false;
            //            //= ChkDelete1.Visible = ChkPermissions1.Visible 
            //        if (dt.Rows[1]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[1]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[1]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[1]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[1]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[1]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[1]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[1]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[1]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[1]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Home Delivery Ticket")
            //    {
            //        ChkAdd1.Visible = false;
            //            //= ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[2]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[2]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        if (dt.Rows[2]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[2]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[2]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[2]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[2]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[2]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[2]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[2]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Customer Request")
            //    {
            //        ChkAdd1.Visible  = false;
            //            //= ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible
            //        if (dt.Rows[3]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[1]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[3]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[3]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[3]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[3]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[3]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[3]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[3]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[3]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Customer Enquiry")
            //    {
            //       // ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[4]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[4]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[4]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[4]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[4]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[4]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[4]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[4]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[4]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[4]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Tentative Booking")
            //    {
            //      //  ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[5]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[5]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[5]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[5]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[5]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[5]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[5]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[5]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[5]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[5]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "User")
            //    {
            //        if (dt.Rows[6]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[6]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[6]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[1]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[6]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[6]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[6]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[6]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[6]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[6]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }
            //    }
            //    if (lblScreenName1.Text == "Commission")
            //    {
            //        ChkDelete1.Visible = ChkPermissions1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[7]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[7]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[7]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[7]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[7]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[7]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[7]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[7]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[7]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[7]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Coupon")
            //    {
            //        ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[8]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[1]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[8]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[8]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[8]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[8]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[8]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[8]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[8]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[8]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Report")
            //    {
            //        ChkAdd1.Visible = ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[9]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[9]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[9]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[9]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[9]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[9]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[9]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[9]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[9]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[9]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Transaction")
            //    {
            //        ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[10]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[10]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[10]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[10]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[10]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[10]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //        //if (dt.Rows[10]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //        //else if (dt.Rows[10]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //        //if (dt.Rows[10]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //        //else if (dt.Rows[10]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Recharge")
            //    {
            //        //ChkAdd1.Text = "Do Recharge"; ChkEdit1.Text = "Operator"; ChkDelete1.Text = "List Of Amounts"; ChkPermissions1.Text = "Commission";
            //        //ChkView1.Text = "Daily Reports"; ChkReports1.Text = "";

            //        // ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[0]["Book"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[0]["Book"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[0]["Cancel"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[0]["Cancel"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[0]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[0]["View"].ToString() == "0") { ChkView1.Checked = false; }

            //    }
            //    if (lblScreenName1.Text == "Operator")
            //    {
            //        ChkAdd1.Text = "Add";

            //        ChkEdit1.Visible = ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //        if (dt.Rows[0]["Book"].ToString() == "1") { ChkAdd1.Checked = true; }
            //        else if (dt.Rows[0]["Book"].ToString() == "0") { ChkAdd1.Checked = false; }
            //        //if (dt.Rows[0]["Cancel"].ToString() == "1") { ChkEdit1.Checked = true; }
            //        //else if (dt.Rows[0]["Cancel"].ToString() == "0") { ChkEdit1.Checked = false; }
            //        //if (dt.Rows[0]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //        //else if (dt.Rows[0]["View"].ToString() == "0") { ChkView1.Checked = false; }

            //    }
            #region Code
            //    //for (int i = 0; i < 11; i++)
            //    //{
            //    //    if (i == 0)
            //    //    {
            //    //        ChkAdd1.Text = "Book";
            //    //        ChkEdit1.Text = "Cancel";
            //    //        ChkDelete1.Visible = ChkPermissions1.Visible = false;
            //    //        if (dt.Rows[0]["Book"].ToString() == "1") { ChkAdd1.Checked = true; }
            //    //        else if (dt.Rows[0]["Book"].ToString() == "0") { ChkAdd1.Checked = false; }
            //    //        if (dt.Rows[0]["Cancel"].ToString() == "1") { ChkEdit1.Checked = true; }
            //    //        else if (dt.Rows[0]["Cancel"].ToString() == "0") { ChkEdit1.Checked = false; }
            //    //    }
            //    //    if (dt.Rows[i]["Add"].ToString() == "1") { ChkAdd1.Checked = true; }
            //    //    else if (dt.Rows[i]["Add"].ToString() == "0") { ChkAdd1.Checked = false; }
            //    //    if (dt.Rows[i]["Edit"].ToString() == "1") { ChkEdit1.Checked = true; }
            //    //    else if (dt.Rows[i]["Edit"].ToString() == "0") { ChkEdit1.Checked = false; }
            //    //    if (dt.Rows[10]["View"].ToString() == "1") { ChkView1.Checked = true; }
            //    //    else if (dt.Rows[i]["View"].ToString() == "0") { ChkView1.Checked = false; }
            //    //    if (dt.Rows[i]["Delete"].ToString() == "1") { ChkDelete1.Checked = true; }
            //    //    else if (dt.Rows[i]["Delete"].ToString() == "0") { ChkDelete1.Checked = false; }
            //    //    if (dt.Rows[i]["Permission"].ToString() == "1") { ChkPermissions1.Checked = true; }
            //    //    else if (dt.Rows[i]["Permission"].ToString() == "0") { ChkPermissions1.Checked = false; }
            //    //    ChkDelete1.Visible = ChkEdit1.Visible = ChkPermissions1.Visible = false;
            //    //}
            #endregion
            //}
        }
    }

    protected void btnSavePermissions_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            foreach (GridViewRow row in GvPermissions.Rows)
            {
                Label lblScrnID = (Label)row.FindControl("lblScreenID");
                Label lblScrnName = (Label)row.FindControl("lblScreenName");
                CheckBox ChkAdd1 = (CheckBox)row.FindControl("ChkAdd");
                //CheckBox ChkView1 = (CheckBox)row.FindControl("ChkView");
                //CheckBox ChkDelete1 = (CheckBox)row.FindControl("ChkDelete");
                //CheckBox ChkEdit1 = (CheckBox)row.FindControl("ChkEdit");
                //CheckBox ChkPermissions1 = (CheckBox)row.FindControl("ChkPermissions");
                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(lblUserID.Text);
                objBAL.screenID = Convert.ToInt32(lblScrnID.Text);
                //if (lblScrnName.Text == "Ticket")
                //{
                //    if (ChkAdd1.Checked == true)
                //    {
                //        objBAL.book = Convert.ToInt32(1);
                //    }
                //    else if (ChkAdd1.Checked == false)
                //    {
                //        objBAL.book = Convert.ToInt32(0);
                //    }
                //if (ChkEdit1.Checked)
                //{
                //    objBAL.cancel = Convert.ToInt32(1);
                //}
                //else if (ChkEdit1.Checked == false)
                //{
                //    objBAL.cancel = Convert.ToInt32(0);
                //}
                //}
                //else
                //{
                if (ChkAdd1.Checked == true)
                {
                    objBAL.book = Convert.ToInt32(1);
                }
                else if (ChkAdd1.Checked == false)
                {
                    objBAL.book = Convert.ToInt32(0);
                }
                //if (ChkEdit1.Checked)
                //{
                //    objBAL.edit = Convert.ToInt32(1);
                //}
                //else if (ChkEdit1.Checked == false)
                //{
                //    objBAL.edit = Convert.ToInt32(0);
                //}
                // }
                //if (ChkDelete1.Checked == true)
                //{
                //    objBAL.delete = Convert.ToInt32(1);
                //}
                //else if (ChkDelete1.Checked == false)
                //{
                //    objBAL.delete = Convert.ToInt32(0);
                //}

                //if (ChkPermissions1.Checked == true)
                //{
                //    objBAL.permissions = Convert.ToInt32(1);
                //}
                //else if (true)
                //{
                //    objBAL.permissions = Convert.ToInt32(0);
                //}
                //if (ChkView1.Checked == true)
                //{
                //    objBAL.view = Convert.ToInt32(1);
                //}
                //else if (ChkView1.Checked == false)
                //{
                //    objBAL.view = Convert.ToInt32(0);
                //}
                objBAL.createdBy = Convert.ToInt32(1);
                objBAL.modifiedBy = Convert.ToInt32(1);
                if (objBAL.AddPermissions())
                {
                    tdmsg.Visible = true;
                  //  tdmsg.Style.Add("background-color:#6CC417;", "");
                    lblMainMsg.Text = "Permissions details saved Successfully....";
                    lblMainMsg.ForeColor = System.Drawing.Color.Green;
                    MVUsers.ActiveViewIndex = 0;
                }
                else
                {
                    tdmsg.Visible = true;
                   // tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "OOPS...Failed to set Permissions setails....";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnSavePermissions_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            MVUsers.ActiveViewIndex = 0;
            MVUsers.Visible = true;
        }
    }

    protected void btnCancelPermissions_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            MVUsers.ActiveViewIndex = 0;
            MVUsers.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdateUD_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            objBAL = new ClsBAL();
            objBAL.UpdateAgentByAgent(txtName.Text.Trim(), "", Convert.ToDateTime("1/1/1900"), txtCity.Text.Trim().ToString(),
               ddlState.SelectedItem.Text.ToString(),
               txtAddress.Text.Trim().ToString(),
               txtPinCode.Text.Trim().ToString(),
               txtMobileNo.Text.Trim().ToString(),
                "", "", txtEmailId.Text.Trim().ToString(), "", "", "1",
               txtPassword.Text.Trim().ToString(),
               Convert.ToInt32(lblID.Text),
              0, 0);
            //if (ViewState["Users"] != null)
            //{
            //    ObjDatatable = (DataTable)ViewState["Users"];

            //    ObjDataview = new DataView(ObjDatatable);
            //    ObjDataview.RowFilter = "UserName='" + Convert.ToString(txtUsername.Text) + "'";
            //    if (ObjDataview.Count > 0)
            //    {
            //        tdmsg.Visible = true;
            //        tdmsg.Style.Add("background-color:#E77471;", "");
            //        lblMainMsg.Text = "Username not Available ...";
            //        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            //        //GvCommissions.DataSource = ViewState["Roles"];
            //        //GvCommissions.DataBind();
            //    }
            //    else
            //    {
            //        objBAL = new ClsBAL();
            //        objBAL.ID = Convert.ToInt32(lblID.Text);
            //        objBAL.userName = txtUsername.Text;
            //        objBAL.password = txtPassword.Text;
            //        objBAL.name = txtName.Text;
            //        objBAL.roleId = Convert.ToInt32(ddlRole.SelectedValue);
            //        objBAL.modifiedBy = Convert.ToInt32(Session["UserID"]);
            //        if (objBAL.UpdateUser())
            //        {
            tdmsg.Visible = true;
          //  tdmsg.Style.Add("background-color:#6CC417;", "");
            lblMainMsg.Text = "User details updated Successfully....";
            lblMainMsg.ForeColor = System.Drawing.Color.Green;
            BindUsers();
            MVUsers.ActiveViewIndex = 0;
            MVUsers.Visible = true;
            //        }
            //        else
            //        {
            //            tdmsg.Visible = true;
            //            tdmsg.Style.Add("background-color:#E77471;", "");
            //            lblMainMsg.Text = "OOPS...Failed to update user setails....";
            //            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            //            MVUsers.Visible = true;
            //        }
            //    }
            // }

        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnUpdateUD_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //string imgAsc = @" <img src='images\asc.jpg' title='Ascending' />";
        //string imgDes = @" <img src='images\des.jpg' title='Descendng' />";

        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    foreach (TableCell cell in e.Row.Cells)
        //    {
        //        LinkButton lbSort = (LinkButton)cell.Controls[0];
        //        if (lbSort.Text == GvUsers.SortExpression)
        //        {
        //            if (GvUsers.SortDirection == SortDirection.Ascending)
        //                lbSort.Text += imgAsc;
        //            else
        //                lbSort.Text += imgDes;
        //        }
        //    }
        //}
    }

    protected void GvUsers_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["Users"] as DataTable;
            if (GvUsers.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    GvUsers.DataSource = dataview;
                    GvUsers.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC")) sortDirection = "DESC";
            }
        }

        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Its Confirms that an HtmlForm control is rendered for the specified .net server control at run time. */
    }

    public static void Export(string fileName, GridView gv)
    {
        string style = @"<style> .text { mso-number-format:\@; } </style> ";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
        "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                // Create a form to contain the grid
                Table table = new Table();

                // add the header row to the table
                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                // add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                // add the footer row to the table
                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                // render the table into the htmlwriter
                table.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is Button)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Button).Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }

    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            string[] arr = new string[6];
            arr[0] = "Password"; arr[1] = "CreatedBy"; arr[2] = "ModifiedBy";
            arr[3] = "Role"; arr[4] = "ModifiedDate"; arr[5] = "Status";
            DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["Users"], arr);
            GridViewExportUtil.ExportToExcel("Users.xls", dtExport, true);
        }
        catch (Exception ex)
        {

            throw ex;
        }

        //Export the grid data to excel sheet
        //Export("Users.xls", this.GvUsers);
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            GvUsers.AllowPaging = true;
            if (ViewState["Users"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvUsers.PageSize = 40;
                    GvUsers.PageIndex = 0;
                    GvUsers.DataSource = ViewState["Users"];
                    GvUsers.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvUsers.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvUsers.PageIndex = 0;
                    GvUsers.DataSource = ViewState["Users"];
                    GvUsers.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvUsers.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvUsers.PageIndex = 0;
                    GvUsers.DataSource = ViewState["Users"];
                    GvUsers.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvUsers.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvUsers.PageIndex = 0;
                    GvUsers.DataSource = ViewState["Users"];
                    GvUsers.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvUsers.PageIndex = e.NewPageIndex;
            if (ViewState["Users"] != null)
            {
                GvUsers.DataSource = ViewState["Users"];
                GvUsers.DataBind();
            }
            else
            {
                BindUsers();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                BindUsers();
            }
            else
            {
                if (ViewState["Users"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("ID");
                    dtt.Columns.Add("UserName");
                    dtt.Columns.Add("Name");
                    dtt.Columns.Add("Password");
                    dtt.Columns.Add("Role");
                    dtt.Columns.Add("EmailId");

                    dtt.Columns.Add("Address");
                    dtt.Columns.Add("City");
                    dtt.Columns.Add("State");
                    dtt.Columns.Add("Country");
                    dtt.Columns.Add("PinCode");
                    dtt.Columns.Add("MobileNo");

                    //  dtt.Columns.Add("RoleId");


                    DataTable DtCommission = (DataTable)ViewState["Users"];
                    DataRow[] dr = DtCommission.Select("UserName like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Name like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Role like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["ID"] = row["ID"].ToString();
                            ddd["UserName"] = row["UserName"].ToString();
                            ddd["Name"] = row["Name"].ToString();
                            ddd["Password"] = row["Password"].ToString();
                            ddd["Role"] = row["Role"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();

                            ddd["Address"] = row["Address"].ToString();
                            ddd["City"] = row["City"].ToString();
                            ddd["State"] = row["State"].ToString();
                            ddd["Country"] = row["Country"].ToString();
                            ddd["PinCode"] = row["PinCode"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            // ddd["RoleId"] = row["RoleId"].ToString();

                            dtt.Rows.Add(ddd);
                        }
                    }
                    //if (dtt.Rows.Count > 0)
                    //{
                    GvUsers.DataSource = dtt;
                    GvUsers.DataBind();
                    //}
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    //protected void GvPermissions_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {

    //        Label lblScreenID1 = (Label)e.Row.FindControl("lblScreenID");
    //        Label lblScreenName1 = (Label)e.Row.FindControl("lblScreenName");
    //        CheckBox ChkAdd1 = (CheckBox)e.Row.FindControl("ChkAdd");
    //    }
    //}
    protected void ddlservice_SelectedIndexChanged(object sender, EventArgs e)
    {
        objBAL = new ClsBAL();

        if (ddlservice.SelectedValue == "ALL")
        {
            ObjDataset = objBAL.GetScreens();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {

                        GvPermissions.DataSource = ObjDataset.Tables[0];
                        GvPermissions.DataBind();
                        MVUsers.ActiveViewIndex = 2;
                    }

                }
            }
        }
        else
        {

            ObjDataset = objBAL.getscreenbyservice(ddlservice.SelectedValue);
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {

                        GvPermissions.DataSource = ObjDataset.Tables[0];
                        GvPermissions.DataBind();
                        MVUsers.ActiveViewIndex = 2;
                    }

                }
            }

        }
    }
}