using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Drawing.Design;
using COM;
using System.Data.SqlClient;
using System;

public partial class Rechargemethods : System.Web.UI.Page
{
    #region Global Variables
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    static string ipaddr;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populate(sender, e);
        }
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
                number = random.Next(11);
                builder.Append(number);
            }

            return builder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void getip()
    {

        ipaddr = Page.Request.UserHostAddress;

    }

    protected void Guestmobilerecharge()
    {
        try
        {

            getip();
            string MobileNumber, Provider, balance, Email;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.getrecharge;
            _objMaster.Parameter = "RequestID";
            _objMaster.RequestID = Session["Order_Id"].ToString();
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

                    ViewState["Mobile"] = MobileNumber.ToString();
                    ViewState["provider"] = Provider.ToString();
                    ViewState["balance"] = balance.ToString();
                    ViewState["Email"] = Email.ToString();

                    # region Mobile code                 


     string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


            string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();

            string[] s = result.Split('|');
        

            stream.Dispose();
            reader.Dispose();


            if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
            {   

                            //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In Process...<img src=\"images/loading123.gif\" border=0></div>");
                            //Response.Flush();
                         
                         //   getstatus();

                            //if (Session["GetStatus"].ToString() == "Success ")
                            //{
                                AdminiBalance();

                               Session["TranscationId"] = s[1].ToString();
                                Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);
                                #region Insert Data into Database

                                _objMaster = new clsMasters();

                                _objMaster.ScreenInd = Masters.getGuestrecharge1;
                                _objMaster.Parameter = "update";
                                _objMaster.RequestID = Session["Order_Id"].ToString();
                                _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                                Session["TransactionID"] = Convert.ToString(s[1].ToString());
                                _objMaster.Status = "SUCCESS";
                                Session["Status"] = "Successfully Recharge";

                                _objMaster.IP = ipaddr;
                                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                                if (_objMaster.fnUpdateRecord() == true)
                                {

                                  

                                    try
                                    {
                                        string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                               "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                               "<td valign='top' width='100%'>" +
                               "<table width='100%'><tr><td valign='top'" +
                              " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                              "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                              "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                              "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                              "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                               "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                               "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                               "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                             "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                             "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                              "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                              "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                              "</table></body></html>" +
                              "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                               "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                        MailSender.SendEmail(Email, "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                    }
                                    catch (Exception ex)
                                    {
                                        //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                        //Response.Redirect("Error.aspx", false);

                                    }

                                    try
                                    {
                                        //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                        //"&message= Thank You for usinglovejourney.in to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
                                        //"&sid=lovejourney.in&mtype=N";
                                        //HttpWebRequest oReq1 = null;
                                        //HttpWebResponse oRes1 = null;
                                        //StreamReader oStream1 = null;
                                        //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
                                        //oReq1.Method = "GET";
                                        //oReq1.Timeout = 20000;
                                        //oRes1 = (HttpWebResponse)oReq1.GetResponse();
                                        //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
                                        //string strMessage1 = oStream1.ReadToEnd().ToString();
                                    }
                                    catch (ArgumentException ex)
                                    {
                                       // LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                                        //Response.Redirect("Error.aspx", false);
                                    }
                                    // Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                    // Response.Redirect("Success.aspx", false);
                                    //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Success.aspx';", true);
                                    Response.Redirect("~/SuccessRecharge.aspx", false);
                                }
                                #endregion
                            }
                            else
                            {
                                // Response.Flush();
                                //  Response.Redirect("~/Success.aspx", false);
                             //   Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                AdminiBalance();

                                _objMaster = new clsMasters();
                                _objMaster.ScreenInd = Masters.getGuestrecharge1;
                                _objMaster.Parameter = "update";
                                _objMaster.RequestID = Session["Order_Id"].ToString();
                                _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                                Session["TransactionID"] = Convert.ToString(s[1].ToString());
                                _objMaster.Status = "Failure";
                                Session["Status"] = "Recharge Failure";

                                Session["errorcode"] = s[0].ToString();
                                Session["errorDecsription"] = s[4].ToString();


                                _objMaster.IP = ipaddr;
                                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                                _objMaster.fnUpdateRecord();



                              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Success.aspx';", true);
                                Response.Redirect("~/SuccessRecharge.aspx", false);

                            }                    
                    }
                    //else
                    //{
                    //    Message.Text = strMessage.ToString();
                    //}
               // }
            }

            else
            {
                //Mpe1.Show();
                //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
        }
        catch (Exception ex)
        {
          //  LogError("redirect.aspx", "Guestmobilerecharge", DateTime.Now, ex.Message.ToString());
        }
                    #endregion
    }


    protected void guestD2HRecharge()
    {
        try
        {

            getip();
            string CustomerID, Provider, balance, Email;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.getrechargeD2H;
            _objMaster.Parameter = "RequestID";
            _objMaster.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    CustomerID = _objDataSet.Tables[0].Rows[0]["Customer_ID"].ToString();
                    Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                    balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                    Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();


                    # region Mobile code

                    string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


                    string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);

                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);

                    var result = reader.ReadToEnd();

                    string[] s = result.Split('|');


                    stream.Dispose();
                    reader.Dispose();


                    if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
                    {                   

                        //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In Process...<img src=\"images/loading123.gif\" border=0></div>");
                        //Response.Flush();
                        // System.Threading.Thread.Sleep(1000);                


                       // getstatus();

                        //if (Session["GetStatus"].ToString() == "Success ")
                        //{
                            AdminiBalance();
                            #region Insert Data into Database

                            _objMaster = new clsMasters();

                            _objMaster.ScreenInd = Masters.getrecharge2;
                            _objMaster.Parameter = "update";
                            _objMaster.RequestID = Session["Order_Id"].ToString();
                            _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());
                            _objMaster.Status = "SUCCESS";
                            Session["Status"] = "Successfully Recharge";
                            _objMasters.Amount = Convert.ToDouble(balance);

                            _objMaster.IP = ipaddr;
                            _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());
                            if (_objMaster.fnUpdateRecord() == true)
                            {

                                //Mpe1.Show();


                                //lblMessage.Text = "Recharge has Been Success";

                                try
                                {
                                    string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                           "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                           "<td valign='top' width='100%'>" +
                           "<table width='100%'><tr><td valign='top'" +
                          " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Customer ID:</span>" + CustomerID + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                           "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                           "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                           "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                         "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                         "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                          "</table></body></html>" +
                          "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                           "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                    MailSender.SendEmail(Email, "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                }
                                catch (Exception ex)
                                {
                                   // LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                   // Response.Redirect("Error.aspx", false);

                                }

                                //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Success.aspx';", true);

                                Response.Redirect("~/SuccessRecharge.aspx", false);
                            #endregion
                            }
                        }
                        else
                        {
                          //  Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                            AdminiBalance();
                            _objMaster = new clsMasters();
                            _objMaster.ScreenInd = Masters.getrecharge2;
                            _objMaster.Parameter = "update";
                            _objMaster.RequestID = Session["Order_Id"].ToString();
                            _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());
                            _objMaster.Status = "Failure";
                            Session["Status"] = "Recharge Failure";
                            _objMaster.Amount = Convert.ToDouble(balance);

                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();

                            _objMaster.IP = ipaddr;
                            _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());
                            _objMaster.fnUpdateRecord();

                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = '~/Agent/Recharge/Failure.aspx';", true);
                            Response.Redirect("~/SuccessRecharge.aspx", false);

                        }
                    }
                   
               // }

            }

            else
            {
                //Mpe1.Show();
                //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
        }
        catch (Exception ex)
        {
            //LogError("redirect.aspx", "guestD2HRecharge", DateTime.Now, ex.Message.ToString());
        }
                    #endregion

    }


    protected void guestDataCardRecharge()
    {
        try
        {

            getip();
            string MobileNumber, Provider, balance, Email;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.getguestDatacardrecharge;
            _objMaster.Parameter = "RequestID";
            _objMaster.RequestID = Session["Order_Id"].ToString();
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

                    string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


                    string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);

                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);

                    var result = reader.ReadToEnd();

                    string[] s = result.Split('|');


                    stream.Dispose();
                    reader.Dispose();


                    if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
                    {
                      

                        //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In Process...<img src=\"images/loading123.gif\" border=0></div>");
                        //Response.Flush();


                        // System.Threading.Thread.Sleep(1000);

                       


                       // getstatus();

                        //if (Session["GetStatus"].ToString() == "Success ")
                        //{

                            AdminiBalance();
                            #region Insert Data into Database
                            _objMaster = new clsMasters();

                            _objMaster.ScreenInd = Masters.UpdateGuestrecharge3;
                            _objMaster.Parameter = "update";
                            _objMaster.RequestID = Session["Order_Id"].ToString();
                            _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());

                            _objMaster.Amount = Convert.ToDouble(balance);
                            _objMaster.Status = "SUCCESS";
                            Session["Status"] = "Successfully Recharge";

                            _objMaster.IP = ipaddr;
                            _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());
                            if (_objMaster.fnUpdateRecord() == true)
                            {

                                //Mpe1.Show();
                                //lblMessage.Text = "Recharge has Been Success";

                                try
                                {
                                    string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                           "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                           "<td valign='top' width='100%'>" +
                           "<table width='100%'><tr><td valign='top'" +
                          " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                           "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                           "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                           "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                         "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                         "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                          "</table></body></html>" +
                          "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                           "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                    MailSender.SendEmail(Email, "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                }
                                catch (Exception ex)
                                {
                                    //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                    //Response.Redirect("Error.aspx", false);

                                }

                                try
                                {
                                    //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                    //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
                                    //"&sid=LoveJourney&mtype=N";
                                    //HttpWebRequest oReq1 = null;
                                    //HttpWebResponse oRes1 = null;
                                    //StreamReader oStream1 = null;
                                    //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
                                    //oReq1.Method = "GET";
                                    //oReq1.Timeout = 10000;
                                    //oRes1 = (HttpWebResponse)oReq1.GetResponse();
                                    //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
                                    //string strMessage1 = oStream1.ReadToEnd().ToString();
                                }
                                catch (ArgumentException ex)
                                {
                                    //LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                                    //Response.Redirect("Error.aspx", false);
                                }

                                Response.Redirect("~/SuccessRecharge.aspx", false);
                                //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Success.aspx';", true);
                            #endregion
                            }
                        }
                        else
                        {
                            //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                            AdminiBalance();
                            _objMaster = new clsMasters();
                            _objMaster.ScreenInd = Masters.UpdateGuestrecharge3;
                            _objMaster.Parameter = "update";
                            _objMaster.RequestID = Session["Order_Id"].ToString();
                            _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());
                            _objMaster.Status = "Failure";
                            Session["Status"] = "Recharge Failure";

                         Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();

                            _objMaster.Amount = Convert.ToDouble(balance);
                            _objMaster.IP = ipaddr;
                            _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());
                            _objMaster.fnUpdateRecord();

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Success.aspx';", true);
                            Response.Redirect("~/SuccessRecharge.aspx", false);
                        }
                    }                 

            }


            else
            {
                //Mpe1.Show();
                //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }

        }
        catch (Exception ex)
        {
           // LogError("redirect.aspx", "guestDataCardRecharge", DateTime.Now, ex.Message.ToString());
        }
                    #endregion
    }

    void populate(Object sender, EventArgs e)
    {
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Identify;
            _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        Session["RechargeUserType1"] = _objDataSet.Tables[0].Rows[0]["Type2"].ToString();
                    }
                }
            }
            _objMasters.ScreenInd = Masters.Identify1;
            _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        Session["RechargeUserType1"] = _objDataSet.Tables[0].Rows[0]["Type"].ToString();
                    }
                }
            }


            if (Session["RechargeUserType1"].ToString() == "Guest")
            {


                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.Identify;
                _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);



                _objDataSet = new DataSet();
                _objDataSet = (DataSet)_objMasters.fnGetData();

                if (_objDataSet != null)
                {
                    if (_objDataSet.Tables.Count > 0)
                    {
                        if (_objDataSet.Tables[0].Rows.Count > 0)
                        {
                            if (_objDataSet.Tables[0].Rows[0]["Type"].ToString() == "Mobile")
                            {
                                Guestmobilerecharge();

                            }
                            else if (_objDataSet.Tables[0].Rows[0]["Type"].ToString() == "DTH")
                            {
                                guestD2HRecharge();
                            }
                            else if (_objDataSet.Tables[0].Rows[0]["Type"].ToString() == "DataCard")
                            {
                                guestDataCardRecharge();

                            }
                        }
                    }
                }

                else
                {
                    Message.Text = "<br>Security Error. Illegal access detected";
                    /*
                        Here you need to simply ignore this and dont need
                        to perform any operation in this condition
                    */
                }
            }

            else if (Session["RechargeUserType1"].ToString() == "User")
            {



                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.Identify1;
                _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);

                _objDataSet = new DataSet();
                _objDataSet = (DataSet)_objMasters.fnGetData();

                if (_objDataSet != null)
                {
                    if (_objDataSet.Tables.Count > 0)
                    {
                        if (_objDataSet.Tables[0].Rows.Count > 0)
                        {
                            if (_objDataSet.Tables[0].Rows[0]["Type1"].ToString() == "Mobile")
                            {

                                Usermobilerecharge();

                            }
                            else if (_objDataSet.Tables[0].Rows[0]["Type1"].ToString() == "DTH")
                            {
                                UserD2HRecharge();


                            }
                            else if (_objDataSet.Tables[0].Rows[0]["Type1"].ToString() == "DataCard")
                            {
                                UserDataCardRecharge();

                            }
                        }
                    }
                }

                else
                {
                    Message.Text = "<br>Security Error. Illegal access detected";
                    /*
                        Here you need to simply ignore this and dont need
                        to perform any operation in this condition
                    */
                }
            }
        }
        catch (Exception ex)
        {
           // LogError("redirect.aspx", "populate", DateTime.Now, ex.Message.ToString());
        }
    }
    //protected void getstatus()
    //{
    //    try
    //    {


    //        string URL1 = "http://www.bulksel.com/trans_status.php?user=kass9378&pass=bus80111&mobileno=8008419101&newid=" + Session["Order_Id"];

    //        HttpWebRequest oReq2 = null;
    //        HttpWebResponse oRes2 = null;
    //        StreamReader oStream2 = null;
    //        oReq2 = (HttpWebRequest)WebRequest.Create(URL1);
    //        oReq2.Method = "GET";
    //        oReq2.Timeout = 20000;
    //        oRes2 = (HttpWebResponse)oReq2.GetResponse();
    //        oStream2 = new StreamReader(oRes2.GetResponseStream(), Encoding.GetEncoding(1252));

    //        string strMessage2 = oStream2.ReadToEnd().ToString();



    //        string[] s1 = strMessage2.Split('|');



    //        Session["GetStatus"] = s1[0].ToString();

    //        if (s1[0].ToString() == "Pending")
    //        {
    //            getstatus();
    //        }
    //        else
    //        {
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //       // LogError("redirect.aspx", "getstatus", DateTime.Now, ex.Message.ToString());
    //    }

    //}

    protected void Usermobilerecharge()
    {
        try
        {
            getip();

            # region Mobile code         


           string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


            string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();

            string[] s = result.Split('|');
        

            stream.Dispose();
            reader.Dispose();


            if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
            {
                   // LogError("Redirect.aspx", "RequestAccepted", DateTime.Now, "RequestAccepted");

                    //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In process...<img src=\"images/loading123.gif\" border=0></div>");
                    //Response.Flush();
                  

                 //   getstatus();

                    //if (Session["GetStatus"].ToString() == "Success ")
                    //{
                        AdminiBalance();
                        //LogError("Redirect.aspx", "Success", DateTime.Now, "Success");

                     

                        Session["TransactionID"] = Convert.ToString(s[1].ToString());

                      
                        _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.getrecharge1;
                        _objMaster.Mobile_Num = Convert.ToString(Session["RMobileNumber"]);
                        _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                        _objMaster.Provider_Name = Convert.ToString(Session["RProviderName"]);
                        _objMaster.E_Mail = Convert.ToString(Session["REmailMobile"]);
                        _objMaster.Amount = Convert.ToDouble(Session["RRechargeAmount"]);
                        _objMaster.Payment = "Deposit";
                        _objMaster.RequestID = Session["Order_Id"].ToString();
                        _objMaster.TransactionID = Convert.ToString(Session["TransactionID"]);

                        _objMaster.Parameter = "update";

                        _objMaster.IP = ipaddr;
                        _objMaster.Status = "SUCCESS";
                        Session["Status"] = "Successfully Recharge";

                        _objMaster.CreatedBy = "NA";
                        _objMaster.ModifiedBy = "NA";
                        _objMaster.ModifiedDate = "NA";
                        _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                        _objMaster.fnUpdateRecord();
                    

                        //Mpe1.Show();

                        //lblMessage.Text = "Recharge has Been Success";

                        try
                        {
                            string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                   "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                   "<td valign='top' width='100%'>" +
                   "<table width='100%'><tr><td valign='top'" +
                  " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                  "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + Session["RMobileNumber"] + "</td>" +
                  "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + Session["RRechargeAmount"] + "</td></tr></table></td></tr>" +
                   "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                   "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                   "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                 "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                 "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                  "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                  "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                  "</table></body></html>" +
                  "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                   "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                            MailSender.SendEmail(Session["REmailMobile"].ToString(), "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                        }
                        catch (Exception ex)
                        {
                            //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                            //Response.Redirect("Error.aspx", false);

                        }

                        try
                        {
                            //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + Session["RMobileNumber"] +
                            //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + Session["RMobileNumber"] + " for Rs" + " " + Session["RRechargeAmount"] + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
                            //"&sid=LoveJourney&mtype=N";
                            //HttpWebRequest oReq1 = null;
                            //HttpWebResponse oRes1 = null;
                            //StreamReader oStream1 = null;
                            //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
                            //oReq1.Method = "GET";
                            //oReq1.Timeout = 20000;
                            //oRes1 = (HttpWebResponse)oReq1.GetResponse();
                            //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
                            //string strMessage1 = oStream1.ReadToEnd().ToString();
                        }
                        catch (ArgumentException ex)
                        {
                            //LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                            //Response.Redirect("Error.aspx", false);
                        }



                        //  Response.Redirect("Masters/RechargeSucces.aspx", false);
                        //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);


                       // Response.Redirect("~/SuccessRecharge.aspx", false);
                        Response.Redirect("~/Users/Recharge/RechargeSucces.aspx", false);

                    }
                    else
                    {


                        //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                        AdminiBalance();
                        _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.getrecharge1;
                        _objMaster.Parameter = "update";
                        _objMaster.RequestID = Session["Order_Id"].ToString();
                        _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                        Session["TransactionID"] = Convert.ToString(s[1].ToString());
                        _objMaster.Status = "Failure";
                        Session["Status"] = "Recharge Failure";
                        _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                        _objMaster.fnUpdateRecord();

                       Session["errorcode"] = s[0].ToString();
                       Session["errorDecsription"] = s[4].ToString();

                        AddAmountoUserswhenRechargefailed();
                        Response.Redirect("~/SuccessRecharge.aspx", false);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);

                    }

                        #endregion
               //}
              
            //}
            //else
            //{
            //    Message.Text = strMessage.ToString();
            //}
        }
        catch (Exception ex)
        {
          //  LogError("redirect.aspx", "Usermobilerecharge", DateTime.Now, ex.Message.ToString());
        }
    }
    protected void UserD2HRecharge()
    {

        try
        {

            getip();
            string CustomerID, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getrechargeD2Hagent;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        CustomerID = _objDataSet.Tables[0].Rows[0]["Customer_ID"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();


                        # region Mobile code
                        lblRequestID.Text = "KAA" + GenerateRandomNumber(11);


                         string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


                        string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] +"|"+ Session["RMobileNumber"] +"|"+ Session["RRechargeAmount"] + "&Hash=" + pwhash;
                        byte[] bytes = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = bytes.Length;

                        Stream requestStream = request.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);

                        WebResponse response = request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(stream);

                        var result = reader.ReadToEnd();

                        string[] s = result.Split('|');


                        stream.Dispose();
                        reader.Dispose();


                        if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
                        {
                              
                                //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In Process...<img src=\"images/loading123.gif\" border=0></div>");
                                //Response.Flush();                              

                               // getstatus();

                                //if (Session["GetStatus"].ToString() == "Success ")
                                //{
                                    AdminiBalance();
                                    #region Insert Data into Database

                                    _objMasters = new clsMasters();

                                    _objMasters.ScreenInd = Masters.getagentrecharge2;
                                    _objMasters.Parameter = "update";
                                    _objMasters.RequestID = Session["Order_Id"].ToString();
                                    _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                                    Session["TransactionID"] = Convert.ToString(s[1].ToString());

                                    _objMasters.Amount = Convert.ToDouble(balance);
                                    _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                                    _objMasters.IP = ipaddr;
                                    _objMasters.Status = "SUCCESS";
                                    Session["Status"] = "Successfully Recharge";
                                    _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                                    if (_objMasters.fnUpdateRecord() == true)
                                    {

                                        //Mpe1.Show();


                                        //lblMessage.Text = "Recharge has Been Success";

                                        try
                                        {
                                            string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                                   "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                                   "<td valign='top' width='100%'>" +
                                   "<table width='100%'><tr><td valign='top'" +
                                  " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                                  "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Customer ID:</span>" + CustomerID + "</td>" +
                                  "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                                   "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                                   "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                                   "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                                 "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                                 "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                                  "</table></body></html>" +
                                  "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                                   "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                            MailSender.SendEmail(Email, "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                        }
                                        catch (Exception ex)
                                        {
                                            //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                            //Response.Redirect("Error.aspx", false);

                                        }

                                        //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);

                                        Response.Redirect("~/SuccessRecharge.aspx", false);


                                    #endregion
                                    }
                                }
                                else
                                {
                                  //  Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                    AdminiBalance();
                                    _objMasters = new clsMasters();
                                    _objMasters.ScreenInd = Masters.getagentrecharge2;
                                    _objMasters.Parameter = "update";
                                    _objMasters.RequestID = Session["Order_Id"].ToString();
                                    _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                                    Session["TransactionID"] = Convert.ToString(s[1].ToString());

                                    _objMasters.Amount = Convert.ToDouble(balance);
                                    _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                                    _objMasters.IP = ipaddr;
                                    _objMasters.Status = "Failure";
                                    Session["Status"] = "Recharge Failure";

                                    _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                                    _objMasters.fnUpdateRecord();
                                    Session["errorcode"] = s[0].ToString();
                                    Session["errorDecsription"] = s[4].ToString();

                                    AddAmountoUserswhenRechargefailed();
                                    Response.Redirect("~/SuccessRecharge.aspx", false);
                                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);

                                }
                            }
                           
                        //else
                        //{
                        //    Message.Text = strMessage.ToString();
                        //}
                   // }
                }
                else
                {
                    //Mpe1.Show();
                    //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                }
            }

            else
            {
                //Mpe1.Show();
                //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
                        #endregion
        }
        catch (Exception ex)
        {
           // LogError("redirect.aspx", "UserD2HRecharge", DateTime.Now, ex.Message.ToString());
        }
    }
    protected void UserDataCardRecharge()
    {
        try
        {
            getip();
            string MobileNumber, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getagentDatacardrecharge;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        MobileNumber = _objDataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();


                        # region Mobile code
                         string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


                        string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
                        byte[] bytes = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = bytes.Length;

                        Stream requestStream = request.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);

                        WebResponse response = request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(stream);

                        var result = reader.ReadToEnd();

                        string[] s = result.Split('|');


                        stream.Dispose();
                        reader.Dispose();


                        if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
                        {
                                #region Show Loading

                                //Response.Write("<div id=\"loading\" style=\"position:absolute; width:100%; text-align:center; top:300px;\">In Process...<img src=\"images/loading123.gif\" border=0></div>");
                                //Response.Flush();
                                #endregion


                              //  getstatus();

                                //if (Session["GetStatus"].ToString() == "Success ")
                                //{
                                    AdminiBalance();
                                    #region Insert Data into Database

                                    _objMasters = new clsMasters();

                                    _objMasters.ScreenInd = Masters.getrecharge3;
                                    _objMasters.Parameter = "update";
                                    _objMasters.RequestID = Session["Order_Id"].ToString();
                                    _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                                    Session["TransactionID"] = Convert.ToString(s[1].ToString());

                                    _objMasters.Amount = Convert.ToDouble(balance);
                                    _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                                    _objMasters.Status = "SUCCESS";
                                    Session["Status"] = "Successfully Recharge";
                                    _objMasters.IP = ipaddr;
                                    _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());
                                    if (_objMasters.fnUpdateRecord() == true)
                                    {

                                        //Mpe1.Show();


                                        //lblMessage.Text = "Recharge has Been Success";

                                        try
                                        {
                                            string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                                   "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                                   "<td valign='top' width='100%'>" +
                                   "<table width='100%'><tr><td valign='top'" +
                                  " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                                  "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                                  "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                                   "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                                   "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                                   "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                                 "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                                 "<td align='left' valign='top'> <p> Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                                  "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                                  "</table></body></html>" +
                                  "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                                   "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                            MailSender.SendEmail(Email, "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                        }
                                        catch (Exception ex)
                                        {
                                            //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                            //Response.Redirect("Error.aspx", false);

                                        }

                                        try
                                        {
                                            //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                            //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
                                            //"&sid=LoveJourney&mtype=N";
                                            //HttpWebRequest oReq1 = null;
                                            //HttpWebResponse oRes1 = null;
                                            //StreamReader oStream1 = null;
                                            //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
                                            //oReq1.Method = "GET";
                                            //oReq1.Timeout = 20000;
                                            //oRes1 = (HttpWebResponse)oReq1.GetResponse();
                                            //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
                                            //string strMessage1 = oStream1.ReadToEnd().ToString();
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            //LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                                            //Response.Redirect("Error.aspx", false);
                                        }
                                        //Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);

                                        Response.Redirect("~/SuccessRecharge.aspx", false);

                                    #endregion
                                    }
                                }
                                else
                                {
                                  //  Response.Write("<script>document.getElementById('loading').style.display='none';</script>");
                                    AdminiBalance();

                                    _objMasters = new clsMasters();

                                    _objMasters.ScreenInd = Masters.getrecharge3;
                                    _objMasters.Parameter = "update";
                                    _objMasters.RequestID = Session["Order_Id"].ToString();
                                    _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                                    Session["TransactionID"] = Convert.ToString(s[1].ToString());

                                    _objMasters.Amount = Convert.ToDouble(balance);
                                    _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                                    _objMasters.Status = "Failure";
                                    Session["Status"] = "Recharge Failure";

                                    _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                                    _objMasters.IP = ipaddr;

                                    _objMasters.fnUpdateRecord();

                            
                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();
                                    AddAmountoUserswhenRechargefailed();



                                    Response.Redirect("~/SuccessRecharge.aspx", false);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "starScript", "window.location = 'Masters/RechargeSucces.aspx';", true);


                                }
                            }
                           
                       // }
                    //    else
                    //    {
                    //        Message.Text = strMessage.ToString();
                    //    }
                    //}
                }
            }
            else
            {
                //Mpe1.Show();
                //lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
                        #endregion

        }


        catch (Exception ex)
        {
           // LogError("redirect.aspx", "UserDataCardRecharge", DateTime.Now, ex.Message.ToString());
        }
    }



    protected void AddAmountoUserswhenRechargefailed()
    {
        try
        {
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.AddAmounttoUsersRechargeFailed;
            _objMaster.amountewallet = Convert.ToDecimal(Session["RRechargeAmount"].ToString());
            _objMaster.UserID = Convert.ToInt32(Session["UserID"].ToString());
            _objMaster.fnUpdateRecord();
        }
        catch (Exception ex)
        {
          //  LogError("redirect.aspx", "AddAmountoUserswhenRechargefailed", DateTime.Now, ex.Message.ToString());
        }
    }
    protected void AdminiBalance()
    {
        try
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/PartnerBalance");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&Hash=428EC1E88E87E1FEADB2F8FFBD2260E7C8FEDB3B";
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            Session["FinalAdminBalance"] = result;

            stream.Dispose();
            reader.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}