using System;
using System.Configuration;
using System.Net.Mail;
using System.Net;

public class Mailsender
{
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
    public static bool SendMail(string pTo, string pBCc, string pFrom, string pSubject, string pBody)
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
            message.IsBodyHtml = false;

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

    public static bool SendErrorEmail(string pTo, string pBCc, string pFrom, string pSubject, string pBody)
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
                string[] addresses = pBCc.Split(';');
                foreach (string item in addresses)
                {
                    MailAddress ccAddress = new MailAddress(item);
                    message.CC.Add(ccAddress);
                }
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
}