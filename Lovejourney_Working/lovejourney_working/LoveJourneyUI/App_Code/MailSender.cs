using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
//using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;


//[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
/// <summary>
/// Summary description for MailSender
/// </summary>
public class MailSender
{

    public MailSender()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool SendEmail(string pTo, string pBCc, string pFrom, string pSubject, string pBody)
    {
        try
        {
            string smtphostname = ConfigurationSettings.AppSettings["smtpClientHost"].ToString();
            string smtpClientPort = ConfigurationSettings.AppSettings["smtpClientPort"].ToString();
            string UserID = ConfigurationSettings.AppSettings["UserID"].ToString();
            string Password = ConfigurationSettings.AppSettings["Password"].ToString();

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(UserID, "");
            MailAddress toAddress = new MailAddress(pTo, "");
            message.From = fromAddress;
            message.To.Add(toAddress);
            message.Subject = pSubject;
            message.Body = pBody;
            message.IsBodyHtml = true;

            if (pBCc != "")
            {
                MailAddress ccAddress = new MailAddress(pBCc);
                message.CC.Add(ccAddress);
            }

            //smtpClient.Host = "182.18.148.59";
            smtpClient.Host = smtphostname;
            smtpClient.Port = Convert.ToInt32(smtpClientPort);
            smtpClient.Credentials = new NetworkCredential(UserID, Password);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //public static bool SendEmail(string pTo, string pBCc, string pFrom, string pSubject, string pBody)
    //{
    //    try
    //    {
    //        SmtpClient smtpClient = new SmtpClient();
    //        MailMessage message = new MailMessage();
    //        MailAddress fromAddress = new MailAddress(pFrom, "info@lovejourney.in");
    //        MailAddress toAddress = new MailAddress(pTo, "");
    //        MailAddress cc = null;
    //        if (pBCc == "")
    //        {
    //            if (pTo != "")
    //                cc = new MailAddress("info@lovejourney.in", "RECHARGE12$RAJA");
    //        }
    //        else
    //            cc = new MailAddress(pBCc, "info@lovejourney.in");
    //        message.From = fromAddress;
    //        message.To.Add(toAddress);
    //        if (cc != null)
    //            message.Bcc.Add(cc);
    //        message.Subject = pSubject;
    //        message.Body = pBody;
    //        message.IsBodyHtml = true;
    //        smtpClient.Host = "mail.lovejourney.in";
    //        smtpClient.Port = 25;
    //        smtpClient.UseDefaultCredentials = true;

    //        smtpClient.Credentials = new NetworkCredential("info@lovejourney.in", "RECHARGE12$RAJA");
    //        smtpClient.Send(message);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

}
