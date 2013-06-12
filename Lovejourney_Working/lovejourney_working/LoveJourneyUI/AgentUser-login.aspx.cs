using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class AgentUser_login : System.Web.UI.Page
{
    ClsBAL objBal;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void mail()
    {

        //string Body = "Dear <b>" + txtName.Text + "</b>," +
        //"<br /><br />Let us welcome you recharge with lovejourney.in . " +
        // "Following are your login details. <br/> <br/>" +
        //" Email ID :<b>" + txtEmailId.Text.Trim() + "</b><br />" +
        //" Password : <b>" + txtPassword.Text.Trim() + "</b><br/>" +
        //"<br /><br />you have successfully registered in www.lovejourney.in and please" +
        //"do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
        //"should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://info@lovejourney.in'> lovejourney.in</a>" +
        //"<br /><br />";

        //MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);


        string Body = "<html><head><title>LOVE JOURNEY - Registry Creation Account Mail</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding:0;       margin:0;font-family:Arial, Helvetica, sans-serif;font-size:12px;font-weight:normal;color:#000;'>" +
                                         "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/Newimages/New_Logo.png' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                         "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Bus * Hotel * Recharge * Car</td></tr>" +
                                         "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>Thank you for registering with LoveJourney!</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td align='center' valign='middle'><strong>Your New Account Login Information</strong><br />Please keep the following information for your records:<br /><strong>User Name:</strong> <a href='#'>" + txtUserName1.Text.Trim().ToString() + "</a><br /><strong>Password:</strong> " + txtPassword.Text.Trim().ToString() + "<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>Please use this  username/password combination the next time you log on.<br />If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr> <tr><td height='30' align='center' valign='middle'><strong>Login to your account  online using the following link:</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><strong><a href='http://lovejourney.in/Login.aspx'>http://lovejourney.in/Login.aspx&nbsp;</a></strong><br /><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                         "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                         "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                         "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);

    }
    protected void lbtnNewUser_Click(object sender, EventArgs e)
    {
        pnlUser.Visible = true;
        pnlAgent.Visible = false;
    }
    protected void lnkNewagent_Click(object sender, EventArgs e)
    {
        pnlAgent.Visible = true;
        pnlUser.Visible = false;
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            lblAgent.Text = obj.InsertAgentRequest(txtAgentName1.Text.ToString(), txtAgentEmail.Text.ToString(), txtOrganization.Text.ToString(), txtAgentMobilno.Text.ToString(),
                 txtAgentCity.Text.ToString(), ddlAgentState.SelectedItem.Text.ToString(), txtComments.Text.ToString(), txtDistrict.Text, "Agent","","","","","","");
            lblAgent.ForeColor = System.Drawing.Color.Green;
            mail1();
            txtAgentName1.Text = txtAgentEmail.Text = txtOrganization.Text = txtAgentMobilno.Text = txtAgentCity.Text = txtComments.Text = "";
            ddlAgentState.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }

    }
    protected void mail1()
    {

        //string Body = "Dear <b>" + txtName.Text + "</b>," +
        //"<br /><br />Let us welcome you recharge with lovejourney.in . " +
        // "Following are your login details. <br/> <br/>" +
        //" Email ID :<b>" + txtEmailId.Text.Trim() + "</b><br />" +
        //" Password : <b>" + txtPassword.Text.Trim() + "</b><br/>" +
        //"<br /><br />you have successfully registered in www.lovejourney.in and please" +
        //"do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
        //"should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://info@lovejourney.in'> lovejourney.in</a>" +
        //"<br /><br />";

        //MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);


        string Body = "<html><head><title>LOVE JOURNEY - Registry Creation Account Mail</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding:0;       margin:0;font-family:Arial, Helvetica, sans-serif;font-size:12px;font-weight:normal;color:#000;'>" +
                                         "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/Newimages/New_Logo.png' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                         "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Buses * Hotels * Recharge * Cabs</td></tr>" +
                                         "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>Thank you for Agent registering with LoveJourney!</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td align='center' valign='middle'><strong>Your New Account Login Information</strong><br />Your Details are Given Below:<br /><strong> Name:</strong> <a href='#'>" + txtAgentName1.Text.ToString() + "</a><br /><strong>Email Id:</strong> " + txtAgentEmail.Text.ToString() + "<br /> <strong>Organization:</strong> " + txtOrganization.Text.ToString() + "<br /><strong>Mobile No:</strong> " + txtAgentMobilno.Text.ToString() + "<br />  <strong>City:</strong> " + txtAgentCity.Text.ToString() + "<br />     <strong>Organization:</strong> " + txtOrganization.Text.ToString() + "<br />  <strong>State:</strong> " + ddlAgentState.SelectedItem.Text.ToString() + "<br />         </td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>Admin Will be contact you soon.......<br />If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +

                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                         "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                         "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                         "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtAgentEmail.Text.ToString(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);

    }

    protected void btnUser_Click1(object sender, EventArgs e)
    {
        try
        {
            objBal = new ClsBAL();
            string message = "";



            message = objBal.AddAgent(txtName.Text.Trim(),
                "", Convert.ToDateTime("1/1/1989"),
                txtCity.Text.Trim().ToString(),
                ddlState.SelectedItem.Text.ToString(),
                txtAddress.Text.Trim().ToString(),
                txtPinCode.Text.Trim().ToString(),
                txtMobileNo.Text.Trim().ToString(),
                 "", "", txtEmailId.Text.Trim().ToString(), "", "", "Approved",
                txtUserName1.Text.Trim().ToString(),
                txtPassword.Text.Trim().ToString(),
                0,
               0, Convert.ToInt32("0"), "User", ddlcountry.SelectedValue, "", "", "", "", "", "");

            lblUser.Text = message;

            lblUser.Visible = true;

            if (message == "Agent registration is completed successfully.")
            {
                lblUser.ForeColor = System.Drawing.Color.Green;
               mail();
                lblUser.Text = "User registration is completed successfully";
                lblUser.ForeColor = System.Drawing.Color.Green;
                txtName.Text = txtCity.Text = txtAddress.Text = txtPinCode.Text = txtMobileNo.Text = txtEmailId.Text = txtUserName1.Text = txtPassword.Text = "";
                ddlcountry.ClearSelection();
                ddlState.ClearSelection();
            }
            lblUser.ForeColor = System.Drawing.Color.Red;

        }
        catch (Exception ex)
        {

        }

    }
    protected void btnUserCancel_Click(object sender, EventArgs e)
    {
        pnlUser.Visible = false;
    }
    protected void btnAgentcancel_Click(object sender, EventArgs e)
    {
        pnlAgent.Visible = false;

    }


    protected void btnUserLog_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            objManabusBAL.userName = Convert.ToString(txtUserName.Text);
            objManabusBAL.password = Convert.ToString(txtUserPassword.Text);

            if (objManabusBAL.CheckUser() == "Valid User")
            {
                if (Session["Role"] != null)
                {

                    
                   
                   
                  
                     if (Session["Role"].ToString() == "User")
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
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Session["UserID"] = null;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw ex;
        }
    }


    protected void btnAgentLogin_Click(object sender, EventArgs e)
    {

        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            objManabusBAL.userName = Convert.ToString(txtAgentName.Text);
            objManabusBAL.password = Convert.ToString(txtAgentPassword.Text);

            if (objManabusBAL.CheckUser() == "Valid User")
            {
                if (Session["Role"] != null)
                {

                    
                     if (Session["Role"].ToString() == "Agent")
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
                            lblEmpMsg.Text = "Your account is on HOLD. Please contact the administrator.";
                            lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                            Session["UserID"] = null;
                        }
                    }
                   
                   
                   
                    else
                    {
                        lblEmpMsg.Text = "UserName / Password Is Incorrect.";
                        lblEmpMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                lblEmpMsg.Text = "UserName / Password Is Incorrect.";
                lblEmpMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw ex;
        }
    }

    protected void txtAgentPassword_TextChanged(object sender, EventArgs e)
    {
       
        btnAgentLogin_Click(sender, e);
        
    }
    
}