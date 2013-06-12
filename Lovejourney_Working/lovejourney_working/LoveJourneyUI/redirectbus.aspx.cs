using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using Newtonsoft.Json;
using System.Xml;
using System.Data;
using System.Text;
using System.IO;
using LJ.CLB.DTO;
using System.Net;

public partial class redirectbus : System.Web.UI.Page
{
    SSAPIClient client = new SSAPIClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["Refno"] != null)
            {
                if (Convert.ToString(Request.QueryString["Refno"]) == Convert.ToString(Session["Order_Id"]))
                {
                    //LJB3240,LJB66851787

                    Session["Ticketrefno"] = Convert.ToString(Request.QueryString["Refno"]);
                    clsMasters objTicket = new clsMasters();
                    objTicket.ScreenInd = Masters.getticket;
                    objTicket.BankReferenceNo = Convert.ToString(Session["Ticketrefno"]);
                    DataSet dsTicket = objTicket.fnGetData();
                    if (dsTicket != null)
                    {

                        if (dsTicket.Tables[0].Rows.Count > 0)
                        {
                            BlockSeats blockseats = new BlockSeats();
                            blockseats.SourceId = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["SourceId"]);
                            blockseats.DestinationId = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["DestinationId"]);
                            blockseats.TripId = Convert.ToString(dsTicket.Tables[0].Rows[0]["TripID"]);
                            blockseats.JourneyDate = Convert.ToDateTime(dsTicket.Tables[0].Rows[0]["DateOfJourney"]).ToShortDateString();
                            blockseats.BoardingId = Convert.ToString(dsTicket.Tables[0].Rows[0]["Boarding_Id"]);
                            blockseats.NoOfSeats = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["NoOfSeats"]);
                            blockseats.SeatNo = Convert.ToString(dsTicket.Tables[0].Rows[0]["SeatNos"]);
                            blockseats.Title = Convert.ToString(dsTicket.Tables[0].Rows[0]["Title"]);
                            blockseats.Name = Convert.ToString(dsTicket.Tables[0].Rows[0]["FullName"]);
                            blockseats.Age = Convert.ToString(dsTicket.Tables[0].Rows[0]["Age"]);
                            blockseats.Sex = Convert.ToString(dsTicket.Tables[0].Rows[0]["Gender"]);
                            blockseats.Address = Convert.ToString(dsTicket.Tables[0].Rows[0]["Address"]);
                            blockseats.BookingRefNo = Convert.ToString(dsTicket.Tables[0].Rows[0]["PGMBRefNo"]);
                            blockseats.IdCardType = Convert.ToString(dsTicket.Tables[0].Rows[0]["IDType"]);
                            blockseats.IdCardNo = Convert.ToString(dsTicket.Tables[0].Rows[0]["IDNumber"]);
                            blockseats.IdCardIssuedBy = Convert.ToString(dsTicket.Tables[0].Rows[0]["IDIssuedBy"]);
                            blockseats.MobileNo = Convert.ToString(dsTicket.Tables[0].Rows[0]["ContactNo"]);
                            blockseats.EmergencyMobileNo = Convert.ToString(dsTicket.Tables[0].Rows[0]["ContactNo"]);
                            blockseats.EmailId = Convert.ToString(dsTicket.Tables[0].Rows[0]["EmailId"]);
                            blockseats.ProviderName = Convert.ToString(dsTicket.Tables[0].Rows[0]["APIName"]);
                            blockseats.BookingId = Convert.ToString(dsTicket.Tables[0].Rows[0]["BlockedId"]);
                            
                            lblMsg.Text = client.bookTicket(blockseats);

                            DataSet dsbook = convertJsonStringToDataSet(lblMsg.Text);
                            if (dsbook != null)
                            {
                                if (dsbook.Tables[0].Rows.Count > 0)
                                {
                                    if (dsbook.Tables[0].Columns.Contains("APIPNR"))
                                    {

                                        if (Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]).ToUpper() == "SUCCESS")
                                        {
                                            if (blockseats.ProviderName.Trim().ToUpper() == "TICKETGOOSE")
                                            {
                                                lblMsg.Text = blockseats.BookingId.ToString();
                                            }
                                            else
                                            {
                                                lblMsg.Text = dsbook.Tables[0].Rows[0]["APIPNR"].ToString();
                                            }
                                            InsertBookedTicketDetails(Convert.ToString(Session["Order_Id"]), lblMsg.Text.ToString());
                                            pnlmail.Visible = true;
                                            GetTicketDetails();
                                            Session["Order_Id"] = null;
                                            Session["blockseats"] = null;
                                            Session["Ticketrefno"] = null;
                                            lblMsg.Text = "";
                                        }
                                        else
                                        {
                                            lblMsg.Text = "null response" + lblMsg.Text + Convert.ToString(dsbook.Tables[0].Rows[0]["APIPNR"]) + Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]) + Convert.ToString(dsbook.Tables[0].Rows[0]["Message"]);
                                            lblMsg.ForeColor = System.Drawing.Color.Red;

                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]);
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblMsg.Text = "no records found";
                            lblMsg.ForeColor = System.Drawing.Color.Red;

                        }

                    }
                    else
                    {
                        lblMsg.Text = "Booking failed";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }
            else
            {
                GetTicketDetails();
                Session["Order_Id"] = null;
                Session["blockseats"] = null;
                Session["Ticketrefno"] = null;
            }
        }

    }
    protected bool InsertBookedTicketDetails(string TicketrefNo, string tinNo)
    {
        try
        {
            string message = ""; bool resinsert = false;

            ClsBAL ObjManbusBAL = new ClsBAL();
            ObjManbusBAL.PNRNumber = tinNo;
            ObjManbusBAL.PNRTicketIDs = tinNo;
            ObjManbusBAL.message = message;
            ObjManbusBAL.manabusRefNo = TicketrefNo;
            ObjManbusBAL.api = "SeatSeller";

            if (ObjManbusBAL.AddBooking_TicketDetails())
            {
                resinsert = true;
            }

            return resinsert;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    private DataSet convertJsonStringToDataSet(string jsonString)
    {
        try
        {
            XmlDocument xd = new XmlDocument();
            jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
            xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
            DataSet ds = new DataSet();
            ds.ReadXml(new XmlNodeReader(xd));
            return ds;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    protected void gvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string finalseats = string.Empty;
                Label lblSeats = (Label)e.Row.FindControl("lblPassengerDetails");
                if (lblSeats != null && lblSeats.Text != "")
                {
                    string[] seats = lblSeats.Text.Split(',');
                    if (seats.Length > 0)
                    {
                        finalseats += "<table width='300px' border='1px Solid Black'  cellpadding='0' cellspacing='0'>";
                        finalseats += "<th width='100px' align='Center'>Seat</th><th align='Center' width='100px'>Name</th><th align='Center' width='100px'>Age</th>";
                        foreach (string item in seats)
                        {
                            string[] details = item.Split('-');
                            if (details.Length > 0)
                            {
                                finalseats += "<tr><td width='100px' align='Center'>";
                                finalseats += details[0] + "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[1] + " " + details[2] + "</p>";
                                finalseats += "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[3] + "</p>";
                                finalseats += "</td></tr>";
                            }
                        }
                        finalseats += "</table>";
                        lblSeats.Text = finalseats;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    protected void GetCancellationPolicy(string API)
    {
        try
        {
            ClsBAL ObjManbusBAL = new ClsBAL();
           ObjManbusBAL.api = API; 
            DataSet _objDataSet = (DataSet)ObjManbusBAL.GetCancelPercentageByAPI();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    gvCancellationDetails.DataSource = _objDataSet.Tables[0];
                    gvCancellationDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    string Route; string SeatNos; string LJRefNo; string PNR; string travelName; string api; string Boardingpoint; string BoardingInfo; string ContactNo;
    string Name = string.Empty;
    protected void GetTicketDetails()
    {
        try
        {
            if (Session["Ticketrefno"] != null)
            {
                ClsBAL ObjManbusBAL = new ClsBAL();
                ObjManbusBAL.manabusRefNo = Session["Ticketrefno"].ToString();
                DataSet _objDataSetBook = (DataSet)ObjManbusBAL.GetTicketIdByTicketrefNo();
                if (_objDataSetBook != null)
                {
                    if (_objDataSetBook.Tables.Count > 0)
                    {
                        if (_objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            travelName = _objDataSetBook.Tables[0].Rows[0]["TravelOPName"].ToString().Trim();
                            api = _objDataSetBook.Tables[0].Rows[0]["APIName"].ToString();
                            Name = _objDataSetBook.Tables[0].Rows[0]["FullName"].ToString();
                            SeatNos = _objDataSetBook.Tables[0].Rows[0]["SeatNos"].ToString();
                            Route = _objDataSetBook.Tables[0].Rows[0]["Route"].ToString();
                            LJRefNo = _objDataSetBook.Tables[0].Rows[0]["OnewayMBRefNo"].ToString();
                            PNR = _objDataSetBook.Tables[0].Rows[0]["PNRNumber"].ToString();
                            Boardingpoint = _objDataSetBook.Tables[0].Rows[0]["BoardingPointName"].ToString();
                            BoardingInfo = _objDataSetBook.Tables[0].Rows[0]["BoardingInfo"].ToString();
                            ContactNo = _objDataSetBook.Tables[0].Rows[0]["ContactNo"].ToString();

                            gvView.DataSource = _objDataSetBook.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(api);
                            Mail(_objDataSetBook.Tables[0].Rows[0]["EmailId"].ToString());

                            SMS();

                            ViewState["MailId"] = _objDataSetBook.Tables[0].Rows[0]["EmailId"].ToString();
                            ViewState["BookingId"] = _objDataSetBook.Tables[0].Rows[0]["BookingId"].ToString();
                            ViewState["TentativeId"] = _objDataSetBook.Tables[0].Rows[0]["TentativeId"].ToString();

                        }
                    }
                }
            }

        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    protected void SMS()
    {
        try
        {
            //string strUrl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=lovejourney&password=1449423933&sendername=LUJRNY&mobileno=91" + ContactNo + "&message=" + "Dear Customer, " + Route + " SeatNos :" + SeatNos + " LJ RefNo : " + LJRefNo + " PNR :" + PNR + " Travels :" +
            //    travelName + " Boarding Point : " + Boardingpoint + " www.lovejourney.in";
            //HttpWebRequest oReq1 = null;
            //HttpWebResponse oRes1 = null;
            //StreamReader oStream1 = null;
            //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
            //oReq1.Method = "GET";
            //oReq1.Timeout = 10000;
            //oRes1 = (HttpWebResponse)oReq1.GetResponse();
            //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            //string strMessage1 = oStream1.ReadToEnd().ToString();

            string strUrl = "http://www.smsstriker.com/API/sms.php?username=lovejourney&password=lovejourney&from=LVJRNY&to=" + ContactNo + "&msg=" + "Dear " + Name + ", Route" + Route + " SeatNos :" + SeatNos + " LJ RefNo : " + LJRefNo + " PNR :" + PNR + " Travels :" +
                 travelName + " Boarding Point : " + Boardingpoint + " Address :" + BoardingInfo + " www.lovejourney.in" + "%20&type=1";


            HttpWebRequest oReq1 = null;
            HttpWebResponse oRes1 = null;
            StreamReader oStream1 = null;
            oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
            oReq1.Method = "GET";
            oReq1.Timeout = 100000;
            oRes1 = (HttpWebResponse)oReq1.GetResponse();
            oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            string strMessage1 = oStream1.ReadToEnd().ToString();

        }
        catch (Exception)
        {

            //  throw;
        }
    }
    //private void sms()
    //{
    //    try
    //    {
    //        string msg = "Hi " + "ravi" + "Your Journey Details are" + System.Environment.NewLine + "Route : " + "hyderabad" + " to " + "bangalore" + System.Environment.NewLine + "Reference N0: " + "refno123456" + System.Environment.NewLine +
    //                                                "Travel Name: " + "kaveri" + " DOJ: " + "" + System.Environment.NewLine + System.Environment.NewLine + "Thanks and  Regards," + System.Environment.NewLine + "Love Journey team";


    //        String strUrl;


    //        string mobno = "9502109080";
    //        strUrl = "http://xxxxxxxx/xxxx?username=xxxxx&password=xxxxxx&to=91" + mobno + "&text=" + msg + "";


    //        HttpWebRequest oReq1 = null;
    //        HttpWebResponse oRes1 = null;
    //        StreamReader oStream1 = null;
    //        oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
    //        oReq1.Method = "GET";
    //        oReq1.Timeout = 10000;
    //        oRes1 = (HttpWebResponse)oReq1.GetResponse();
    //        oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
    //        string strMessage1 = oStream1.ReadToEnd().ToString();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    protected void Mail(string mailId)
    {
        try
        {
            
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (mailId != "")
            {
                string body = GetHtml(pnlmail);
                bool res = Mailsender.SendEmail(mailId, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMsg.Text = "Ticket Details has been sent to your mail. Please check.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private string GetHtml(Panel pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        pnl.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
        /* -----------------------------------
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */

    }
}