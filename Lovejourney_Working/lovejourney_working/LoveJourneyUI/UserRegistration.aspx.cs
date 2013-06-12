using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
public partial class UserRegistration : System.Web.UI.Page
{
    ClsBAL objBal;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new ClsBAL();
            string message = "";

  
           
                message = objBal.AddAgent(txtName.Text.Trim(),
                    "",Convert.ToDateTime("1/1/1989"),
                    txtCity.Text.Trim().ToString(),
                    ddlState.SelectedItem.Text.ToString(),
                    txtAddress.Text.Trim().ToString(),
                    txtPinCode.Text.Trim().ToString(),
                    txtMobileNo.Text.Trim().ToString(),
                     "", "", txtEmailId.Text.Trim().ToString(), "", "", "Approved",
                    txtUsername.Text.Trim().ToString(),
                    txtPassword.Text.Trim().ToString(),
                    0,
                   0, Convert.ToInt32("0"),"User",ddlcountry.SelectedValue,"","","","","","");

                lblMsg.Text = message;
             
                lblMsg.Visible = true;

                if (message == "Agent registration is completed successfully.")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    mail();
                    lblMsg.Text = "User registration is completed successfully";
                }
                lblMsg.ForeColor = System.Drawing.Color.Red;
          
        }
        catch (Exception ex)
        {
            
        }
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
                                         "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/images/logo.gif' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                         "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Buses * Hotels * Recharge</td></tr>" +
                                         "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>Thank you for registering with LoveJourney!</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td align='center' valign='middle'><strong>Your New Account Login Information</strong><br />Please keep the following information for your records:<br /><strong>User Name:</strong> <a href='#'>" + txtUsername.Text.Trim().ToString() + "</a><br /><strong>Password:</strong> " + txtPassword.Text.Trim().ToString() + "<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>Please use this  username/password combination the next time you log on.<br />If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr> <tr><td height='30' align='center' valign='middle'><strong>Login to your account  online using the following link:</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><strong><a href='http://lovejourney.in/Login.aspx'>http://lovejourney.in/Login.aspx&nbsp;</a></strong><br /><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                         "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                         "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                         "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);

    }
}