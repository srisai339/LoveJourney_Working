//using System;
//using System.Collections.Generic;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Text;
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

namespace EBS
{
    public partial class Response : System.Web.UI.Page
    {
        #region Global Variables
        clsMasters _objMaster;
        clsMasters _objMasters;
        DataSet _objDataSet;
        clsUserAuthentication _objUserAuth;
        static string Checked = "null";
        static string ipaddr;

        string MerchantRefNo = string.Empty;
        string ResponseMessage = string.Empty;
        string ResponseCode = string.Empty;
        string IsFlagged = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            string sQS;
            //string[] aQS;
            //string lsDetail1, lsDetail2, lsDetail;
           // string pwd = "ebskey";
           string pwd = "91fd335602ba035c96e9ec6f427082aa";
            
            string DR = Request.QueryString["DR"].ToString();

         

           // string DR = "IXc9laP5EPzkG8rJUEkT9GPYZKb+340d1KINeq1DJAbrqc5GeRs3RVwRJ7YShbNZUyaxTmSW46lexsfKVHpZGaEckYB8lZxGvToGUG9WVbC2b86UjHu125hgs12+1Ql5j0PVxNN9JqB32SFu+2e9n2eDeWfaVS3KZKnENgwdth3GL8LGG3rbDq5YXYEfOxqAYAmvoOTNxuyHt+yBl6uKqGOdRsToe5dPnIXXo1zBh8q2asX6Rj7jd/xOFtrZV+uhlq1kYZdvUrREXZz6/P0QxRAZioRGzjf1AyYhXA6i/NgCKixXHSR3r15FScNIqyb74SeGq19oOSp5+lDqFGZZfz8Vb+tGJYxSwOFM4Og362rqjHd+YvQpFSIwl0MUInW5PZprjS0zGMmSMOIpnUNDXuevflzn1yRkTgGztwdakfplA6k1118CerVjt6K2c1z4grA936AdbSW2JkQEnyp0krr3GAOV+v3ug6l1WDyPdyN+vvaWAhJAgxd15QpuDVeZ1uTvO42XjjFPetnskmtzyNZH0GmWSjQo91f7/dqV4kpgLOCe//iVmnTbws23K8ueosn6Pbh4jgGix0wRXgySz2Nw0xXwHDEsdKZSIuLOVyxn3Zdx5JzdAseuc/P2vzH8xDCJ6GVcvD+7eeyv1+ZqAnOpT26eJ3vIPskxVWiSePXpMiZUSY4RcL6K3Gy+j+O3Ib4uZ85XbrzJ0e+yT4pcv8q7KQWb02vJ/0iD25HrSlCpNkE3lcxctoASzz1sZ48CLg==";

            DR = DR.Replace(' ', '+');
            sQS = Base64Decode(DR);
            DR = RC4.Decrypt(pwd, sQS, false);
            Session["DR"] = DR.ToString();


           


            if (Session["DR"] != null)
            {
                string str = Session["DR"].ToString();
                string[] words = str.Split('&');

                string msgid1 = words[0].ToString();
               // ResponseCode = msgid1.Substring(msgid1.IndexOf("ResponseCode=") + 13, 1);

               

                ResponseCode = msgid1.Substring(13).ToString().Trim();


                string msgid2 = words[1].ToString();
               // ResponseMessage = msgid2.Substring(msgid2.IndexOf("ResponseMessage=") + 16, 22);

                

                ResponseMessage = msgid2.Substring(16).ToString().Trim();


                string msgid5 = words[4].ToString();
                //MerchantRefNo = msgid5.Substring(msgid5.IndexOf("MerchantRefNo=") + 14, 11);

               

                MerchantRefNo = msgid5.Substring(14).ToString().Trim();

                //string msgid6 = words[23].ToString();
                //IsFlagged = msgid6.Substring(msgid6.IndexOf("IsFlagged=") + 10, 2);



                Session["Ticketrefno"] = Session["Order_Id"] = MerchantRefNo.ToString();

                if (ResponseMessage == "Transaction Successful" && ResponseCode == "0")
                {
                    //_objMaster = new clsMasters();
                    //_objMaster.ScreenInd = Masters.Ewalletbyrequestid;
                    //_objMaster.RequestID = Session["Order_Id"].ToString();
                    //_objDataSet = (DataSet)_objMaster.fnGetData();
                    //if (_objDataSet != null)
                    //{
                    //    if (_objDataSet.Tables.Count > 0)
                    //    {
                    //        if (_objDataSet.Tables[0].Rows.Count > 0)
                    //        {
                    //            Session["Ewallet"] = _objDataSet.Tables[0].Rows[0]["Type"].ToString();
                    //        }
                    //    }
                    //}

                    //if (Session["Ewallet"].ToString() == "null")
                    //{

                    if (MerchantRefNo.Contains("LJIF"))
                    {
                        Response.Redirect("~/frmIntFlightsAvailability.aspx", false);
                    }
                    else if (MerchantRefNo.Contains("LJC"))
                    {
                        Session["refno"] = Session["Order_Id"].ToString();
                        Response.Redirect("~/CarTicket.aspx", false);
                    }

                    else if (MerchantRefNo.Contains("LJH"))
                    {
                        Session["HotelRefNo"] = Session["Order_Id"].ToString();
                        Response.Redirect("~/HotelTicket.aspx", false);
                    }

                    else if (MerchantRefNo.Contains("LJDF"))
                    {

                      

                        _objMasters = new clsMasters();
                        _objMasters.ScreenInd = Masters.GetFlights1;
                        _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);
                        _objDataSet = new DataSet();
                        _objDataSet = (DataSet)_objMasters.fnGetData();

                        if (_objDataSet != null)
                        {
                            if (_objDataSet.Tables.Count > 0)
                            {
                                if (_objDataSet.Tables[0].Rows.Count > 0)
                                {
                                    if (_objDataSet.Tables[0].Rows[0]["Type"].ToString() == "Guest")
                                    {
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Domestic flights 1111" + "');</script>", false);

                                        Response.Redirect("~/frmFlightsAvailability.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("~/frmFlightsAvailability.aspx", false);
                                    }

                                }
                            }
                        }
                    }
                    else if (MerchantRefNo.Contains("LJB"))
                    {
                        Response.Redirect("~/redirectbus.aspx?Refno=" + MerchantRefNo.ToString(), false);
                    }
                    else if (MerchantRefNo.Contains("RVPG"))
                    {
                        // Response.Redirect("~/Agent/Bus/AddBalance.aspx?status=Yes", false);
                    }
                    else
                    {
                        // Response.Redirect("~/Rechargemethods.aspx", false);
                    }


                    //}
                    //else if (Session["Ewallet"].ToString() == "Ewallet")
                    //{
                    //    Session["Status12"] = "Y";
                    //    //Response.Redirect("~/User/EWallet.aspx", false);
                    //}
                }
                //else if (ResponseMessage == "Transaction Successful" && ResponseCode == "0")
                //{
                //    Session["IsFlagged"] = "Yes";
                //    Response.Redirect("~/Default.aspx", false);
                //}
                else
                {
                    Session["Transaction"] = "Failure";
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }
        private string Base64Decode(string sBase64String)
        {
            byte[] sBase64String_bytes =
            Convert.FromBase64String(sBase64String);
            return UnicodeEncoding.Default.GetString(sBase64String_bytes);
            //return UnicodeEncoding.ASCII.GetString(sBase64String_bytes);
        }

        public string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }

        protected void getip()
        {

            ipaddr = Page.Request.UserHostAddress;

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
        protected void mobilerecharge()
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
                    lblRequestID.Text = "KAA" + GenerateRandomNumber(11);

                    string URL = "http://www.bulksel.com/api_reach_bulksel.php?user=kass9378&pass=bus80111&mobileno=918008419101&newid=" + Session["Order_Id"] + "&message=BS " +
     Provider + " " + MobileNumber + " " + balance;


                    HttpWebRequest oReq = null;
                    HttpWebResponse oRes = null;
                    StreamReader oStream = null;
                    oReq = (HttpWebRequest)WebRequest.Create(URL);
                    oReq.Method = "GET";
                    oReq.Timeout = 10000;
                    oRes = (HttpWebResponse)oReq.GetResponse();
                    oStream = new StreamReader(oRes.GetResponseStream(), Encoding.GetEncoding(1252));


                    string strMessage = oStream.ReadToEnd().ToString();

                    Session["strMessage"] = strMessage.ToString();
                    string[] s = strMessage.Split('d');
                    if (s[0].ToString() == "Request Accepte")
                    {
                        #region Insert Data into Database

                        _objMaster = new clsMasters();

                        _objMaster.ScreenInd = Masters.getrecharge1;
                        _objMaster.Parameter = "update";
                        _objMaster.RequestID = Session["Order_Id"].ToString();
                        _objMaster.TransactionID = Convert.ToString(s[1].ToString());
                        Session["TransactionID"] = Convert.ToString(s[1].ToString());
                        _objMaster.IP = ipaddr;

                        _objMaster.Status = "SUCCESS";
                        // _objMaster.fnUpdateRecord();
                        if (_objMaster.fnUpdateRecord() == true)
                        {

                            Mpe1.Show();

                            //if (_objMaster.fnInsertRecord() == true)
                            //{
                            lblMessage.Text = "Recharge has Been Success";

                            try
                            {
                                string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                       "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                       "<td valign='top' width='100%'>" +
                       "<table width='100%'><tr><td valign='top'" +
                      " &nbsp;<img src='http://paytopups.com/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                      "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                      "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " </span></td></tr>" +
                      "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                      "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
                       "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                       "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                       "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                     "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                     "<td align='left' valign='top'> <p>Kassp Technologies f101, Rainbow residency, plot- 1000 and 1001,Pragathi Nagar, Kukatpally </p> Hyderabad - 90</td></tr>" +
                      "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                      "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                      "</table></body></html>" +
                      "<br />Again, we thank you for registering with <b>www.paytopups.com</b> and please " +
                       "do not hesitate to write to us at <a href='mailto:support@paytopups.com'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.paytopups.com'>paytopups.com</a> " + "<br /><br />";

                                MailSender.SendEmail(Email, "support@paytopups.com", "support@paytopups.com", "Paytopups-Recharge", body);

                            }
                            catch (Exception ex)
                            {
                                //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                //Response.Redirect("Error.aspx", false);

                            }

                            try
                            {
                                //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                //"&message= Thank You for usingpaytopups.com to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at support@paytopups.com" +
                                //"&sid=Paytopups&mtype=N";
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
                                // LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                                //Response.Redirect("Error.aspx", false);
                            }
                            //}
                            Response.Redirect("Success.aspx", false);
                        #endregion
                        }
                    }
                    else
                    {
                        Response.Redirect("RechargeFailure.aspx", false);
                        // LogError("redirect.aspx", "API", DateTime.Now, Session["strMessage"].ToString());
                        _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.Mobilenew;
                        _objMaster.Mobile_Num = Convert.ToString(MobileNumber); //txtMobile.Text.Trim();
                        _objMaster.Provider_Name = Convert.ToString(Provider);
                        _objMaster.E_Mail = Convert.ToString(Email);
                        _objMaster.Amount = Convert.ToDouble(balance);
                        _objMaster.Payment = Convert.ToString("Deposited");
                        _objMaster.RequestID = lblRequestID.Text.Trim();
                        _objMaster.TransactionID = Convert.ToString(Session["strMessage"]);

                        _objMaster.IP = ipaddr;
                        _objMaster.Status = "Failure";//strMessage.Substring(strMessage.IndexOf("<status>") + 8, 7);
                        _objMaster.CreatedBy = "NA";
                        _objMaster.ModifiedBy = "NA";
                        _objMaster.ModifiedDate = "NA";
                        _objMaster.fnInsertRecord();
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("RechargeFailure.aspx", false);
                    // LogError("redirect.aspx", "API", DateTime.Now, Session["strMessage"].ToString());
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    _objMaster.Mobile_Num = Convert.ToString(ViewState["Mobile"]); //txtMobile.Text.Trim();
                    _objMaster.Provider_Name = Convert.ToString(ViewState["provider"]);
                    _objMaster.E_Mail = Convert.ToString(ViewState["balance"]);
                    _objMaster.Amount = Convert.ToDouble(ViewState["Email"]);
                    _objMaster.Payment = Convert.ToString("Deposited");
                    _objMaster.RequestID = lblRequestID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(Session["strMessage"]);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "Failure";//strMessage.Substring(strMessage.IndexOf("<status>") + 8, 7);
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Mpe1.Show();
                lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";
            }
                    #endregion
        }
    }
}
