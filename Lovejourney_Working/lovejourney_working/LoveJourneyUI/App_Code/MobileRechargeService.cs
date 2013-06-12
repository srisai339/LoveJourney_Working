using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BAL;
using System.Net;
using System.Data;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for MobileRechargeService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MobileRechargeService : System.Web.Services.WebService {

    clsMasters _objMaster;
    DataSet _objDataSet;

    public MobileRechargeService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }   

    [WebMethod]
    public Boolean MobileRecharge(String CouponNumber, String MobileNumber, Int16 RechargeAmount, String Order_Id, String IPAddr)
    {
        Boolean isRechargeSuccess = false;
        
        string Provider = String.Empty, balance = String.Empty, Email = String.Empty, requestId = String.Empty;
        _objMaster = new clsMasters();
        _objMaster.ScreenInd = Masters.getrecharge;
        _objMaster.Parameter = "RequestID";
       // _objMaster.RequestID = Session["Order_Id"].ToString();
        _objMaster.RequestID = Order_Id.ToString();
        _objDataSet = new DataSet();
        _objDataSet = (DataSet)_objMaster.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                MobileNumber = _objDataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();

                
                

                # region Mobile code
             //   requestId = "KAA" + GenerateRandomNumber(11);



             //   string URL = "http://www.bulksel.com/api_reach_bulksel.php?user=kass9378&pass=bus80111&mobileno=918008419101&newid=" + requestId + "&message=BS " +
             //Provider + " " + MobileNumber + " " + balance;


             //   HttpWebRequest oReq = null;
             //   HttpWebResponse oRes = null;
             //   StreamReader oStream = null;
             //   oReq = (HttpWebRequest)WebRequest.Create(URL);
             //   oReq.Method = "GET";
             //   oReq.Timeout = 10000;
             //   oRes = (HttpWebResponse)oReq.GetResponse();
             //   oStream = new StreamReader(oRes.GetResponseStream(), Encoding.GetEncoding(1252));


             //   string strMessage = oStream.ReadToEnd().ToString();

             //   Session["strMessage"] = strMessage.ToString();
             //   string[] s = strMessage.Split('d');
             //   if (s[0].ToString() == "Request Accepte")
             //   {
             //       #region Insert Data into Database

             //       _objMaster = new clsMasters();

             //       _objMaster.ScreenInd = Masters.getGuestrecharge1;
             //       _objMaster.Parameter = "update";
             //       _objMaster.RequestID = Session["Order_Id"].ToString();
             //       _objMaster.TransactionID = Convert.ToString(s[1].ToString());
             //       Session["TransactionID"] = Convert.ToString(s[1].ToString());


             //       _objMaster.IP = IPAddr;

             //       if (_objMaster.fnUpdateRecord() == true)
             //       {   

             //           isRechargeSuccess = true;
             //           //lblMessage.Text = "Recharge has Been Success";

             //           try
             //           {
             //               string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
             //      "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
             //      "<td valign='top' width='100%'>" +
             //      "<table width='100%'><tr><td valign='top'" +
             //     " &nbsp;<img src='http://rechargeraja.com/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
             //     "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
             //     "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " </span></td></tr>" +
             //     "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
             //     "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
             //      "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
             //      "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
             //      "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
             //    "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
             //    "<td align='left' valign='top'> <p>  </p> Hyderabad - 90</td></tr>" +
             //     "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
             //     "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
             //     "</table></body></html>" +
             //     "<br />Again, we thank you for registering with <b>www.rechargeraja.com</b> and please " +
             //      "do not hesitate to write to us at <a href='mailto:info@rechargerajanow.com'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.rechargeraja.com'>rechargeraja.com</a> " + "<br /><br />";

             //               MailSender.SendEmail(Email, "info@rechargerajanow.com", "info@rechargerajanow.com", "rechargeraja-Recharge", body);

             //           }
             //           catch (Exception ex)
             //           {
             //               isRechargeSuccess = false;
             //               //throw ex;
             //           }

             //           try
             //           {
             //               string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
             //               "&message= Thank You for usingrechargeraja.com to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@rechargerajanow.com" +
             //               "&sid=rechargeraja&mtype=N";
             //               HttpWebRequest oReq1 = null;
             //               HttpWebResponse oRes1 = null;
             //               StreamReader oStream1 = null;
             //               oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
             //               oReq1.Method = "GET";
             //               oReq1.Timeout = 10000;
             //               oRes1 = (HttpWebResponse)oReq1.GetResponse();
             //               oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
             //               string strMessage1 = oStream1.ReadToEnd().ToString();
             //           }
             //           catch (ArgumentException ex)
             //           {
             //               //LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
             //               //Response.Redirect("Error.aspx", false);
             //           }

             //           isRechargeSuccess = true;
             //           //Response.Redirect("Success.aspx", false);

             //       }
             //       #endregion
             //   }
             //   else
             //   {
             //       isRechargeSuccess = false;
             //       //Response.Redirect("RechargeFailure.aspx", false);
             //       //LogError("redirect.aspx", "API", DateTime.Now, Session["strMessage"].ToString());
             //       _objMaster = new clsMasters();
             //       _objMaster.ScreenInd = Masters.Mobilenew;
             //       _objMaster.Mobile_Num = Convert.ToString(MobileNumber); //txtMobile.Text.Trim();
             //       _objMaster.Provider_Name = Convert.ToString(Provider);
             //       _objMaster.E_Mail = Convert.ToString(Email);
             //       _objMaster.Amount = Convert.ToDouble(balance);
             //       _objMaster.Payment = Convert.ToString("Deposited");
             //       _objMaster.RequestID = requestId.Trim();
             //       _objMaster.TransactionID = Convert.ToString(Session["strMessage"]);

             //       _objMaster.IP = IPAddr;
             //       _objMaster.Status = "Failure";//strMessage.Substring(strMessage.IndexOf("<status>") + 8, 7);
             //       _objMaster.CreatedBy = "NA";
             //       _objMaster.ModifiedBy = "NA";
             //       _objMaster.ModifiedDate = "NA";
             //       _objMaster.fnInsertRecord();
             //       // Response.Redirect("Error.aspx", false);
             //   }

                #endregion

            }
            else
            {
                isRechargeSuccess = false;
                //Response.Redirect("RechargeFailure.aspx", false);
                //LogError("redirect.aspx", "API", DateTime.Now, Session["strMessage"].ToString());
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.Mobilenew;
                _objMaster.Mobile_Num = MobileNumber; //txtMobile.Text.Trim();
                _objMaster.Provider_Name = Provider;
                _objMaster.E_Mail = Email;
                _objMaster.Amount = Convert.ToDouble(balance);
                _objMaster.Payment = Convert.ToString("Deposited");
                _objMaster.RequestID = requestId.Trim();
                _objMaster.TransactionID = Convert.ToString(Session["strMessage"]);

                _objMaster.IP = IPAddr;
                _objMaster.Status = "Failure";//strMessage.Substring(strMessage.IndexOf("<status>") + 8, 7);
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                // Response.Redirect("Error.aspx", false);
            }
        }


        else
        {
            isRechargeSuccess = false;
            //Mpe1.Show();
            //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

        }
                

        return isRechargeSuccess;
    }

    protected string GenerateRandomNumber(int count)
    {
        try
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            int number;
            for (int i = 0; i < count; i++)
            {
                number = random.Next(10);
                builder.Append(number);
            }

            return builder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
