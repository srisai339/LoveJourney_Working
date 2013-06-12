using System;
using System.Data;
using HotelAPILayer;
using BAL;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Net;

public partial class Agent_Hotel_HotelTicket : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    ClsBAL objBAL;
    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Hotel - Ticket";
        if (!IsPostBack)
        {
            if (Session["HotelRefNo"] != null)
            {
                string strRefNo = Session["HotelRefNo"].ToString();

                HotelBAL obj = new HotelBAL();
                obj.ReferenceNo = strRefNo;
                DataSet ds = obj.GetHotelProvisional();

                if (ds != null)
                {
                    string hotelId = ""; string webService = ""; string ratePlanCode = ""; string roomTypeCode = "";
                    string cityName = ""; string allocavailResult = "";
                    string allocidResult = ""; string fromDate = ""; string toDate = ""; string roomType = "";
                    string wsKey = ""; string roomBasis = ""; string title = "";
                    string firstName = ""; string middleName = ""; string lastName = ""; int noOfRooms = 0;
                    int[] noOfAdultsInARoom = null; int[] noOfChildsInARoom = null;
                    int[] firstChildAge = null; int[] secondChildAge = null;
                    string roomStayCandidate = "";

                    DataRow dr = ds.Tables[0].Rows[0];

                    hotelId = dr["HotelId"].ToString();
                    webService = dr["WebService"].ToString();
                    ratePlanCode = dr["RatePlanType"].ToString();
                    roomTypeCode = dr["RoomTypeCode"].ToString();
                    cityName = dr["HotelCity"].ToString();
                    allocavailResult = dr["FromAllocation"].ToString();
                    allocidResult = dr["AllocationId"].ToString();

                    roomType = dr["RoomType"].ToString();
                    firstName = dr["FirstName"].ToString();
                    middleName = dr["MiddleName"].ToString();
                    lastName = dr["LastName"].ToString();
                    wsKey = dr["WsKey"].ToString();
                    roomBasis = dr["RoomBasis"].ToString();
                    title = dr["Title"].ToString();
                    noOfRooms = Convert.ToInt32(dr["NoOfRooms"].ToString());
                    roomStayCandidate = dr["RoomStayCandidate"].ToString();

                    string[] strValues = roomStayCandidate.Split(':');

                    fromDate = ConvertDate(strValues[1].ToString());
                    fromDate = fromDate.Replace('-', '/');
                    toDate = ConvertDate(strValues[2].ToString());
                    toDate = toDate.Replace('-', '/');


                    noOfRooms = Convert.ToInt32(strValues[3].ToString());

                    noOfAdultsInARoom = new int[noOfRooms];
                    noOfChildsInARoom = new int[noOfRooms];
                    firstChildAge = new int[noOfRooms];
                    secondChildAge = new int[noOfRooms];
                    int j = 0;
                    for (int i = 0; i < noOfRooms; i++)
                    {
                        if (i == 0)
                        {
                            j = 0;
                        }
                        else
                        {
                            j = 4 * i;
                        }

                        noOfAdultsInARoom[i] = Convert.ToInt32(strValues[4 + j].ToString());
                        noOfChildsInARoom[i] = Convert.ToInt32(strValues[5 + j].ToString());
                        firstChildAge[i] = Convert.ToInt32(strValues[6 + j].ToString());
                        secondChildAge[i] = Convert.ToInt32(strValues[7 + j].ToString());
                    }


                    {
                        DataSet dsHotelBooking = objArzooHotelAPILayer.HotelBooking
                            (hotelId, webService, ratePlanCode, roomTypeCode, cityName, allocavailResult,
                            allocidResult, fromDate, toDate, roomType, wsKey, roomBasis, title, firstName, middleName, lastName, noOfRooms,
                            noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge);

                        int provisionalId = Convert.ToInt32(dr["Id"].ToString());

                        if (!dsHotelBooking.Tables.Contains("HotelBooking"))
                        { lblMsg.Text = "Failed to book the ticket."; return; }

                        if (dsHotelBooking.Tables["HotelBooking"].Rows.Count == 0)
                        { lblMsg.Text = "Failed to book the ticket."; return; }

                        DataRow drr = dsHotelBooking.Tables["HotelBooking"].Rows[0];
                        wsKey = drr["wsKey"].ToString();

                        string extGuestTotal = drr["extGuestTotal"].ToString();
                        string roomTotal = drr["roomTotal"].ToString();
                        string serviceTaxTotal = drr["servicetaxTotal"].ToString();
                        string bookingStatus = drr["bookingstatus"].ToString();
                        string bookingRemarks = drr["bookingremarks"].ToString();
                        string bookingRefNo = drr["bookingref"].ToString();
                        string bookingTrn = drr["bookingTrn"].ToString();
                        string discount = drr["discount"].ToString();
                        string contactNumbers = drr["contactNumbers"].ToString();
                        string faxNumbers = drr["faxNumbers"].ToString();

                        if (drr["bookingstatus"].ToString() == "C")
                        {
                            string stt = "";
                            stt = InsertHotelBooking(provisionalId, wsKey, extGuestTotal, roomTotal, serviceTaxTotal, bookingStatus, bookingRemarks,
                                bookingRefNo, bookingTrn, discount, contactNumbers, faxNumbers, Convert.ToInt32(Session["UserID"].ToString()));
                            if (stt == "Success")
                            {
                                pnlTicket.Visible = true;
                                pnlOptions.Visible = true;

                                HotelBAL objTicket = new HotelBAL();
                                objTicket.ReferenceNo = strRefNo;
                                DataSet dsTicket = objTicket.GetHotelProvisional();

                                if (dsTicket != null)
                                {
                                    DataRow drTicketRow = dsTicket.Tables[0].Rows[0];
                                    lblHotelRefNo.Text = drTicketRow["ReferenceNo"].ToString();
                                    lblarzoorefno.Text = drTicketRow["BookingRefNo"].ToString();
                                    lblStatus.Text = drTicketRow["Status"].ToString();
                                    lblHotelName.Text = drTicketRow["HotelName"].ToString();

                                    lblAddress.Text = drTicketRow["HotelAddress"].ToString();

                                    lblHotelCity.Text = drTicketRow["HotelCity"].ToString();
                                    lblCheckIn.Text = drTicketRow["CheckInDate"].ToString();
                                    lblCheckOut.Text = drTicketRow["CheckOutDate"].ToString();
                                    lblRoomType.Text = drTicketRow["RoomType"].ToString();

                                    lblStar.Text = drTicketRow["HotelStar"].ToString()+" Star";

                                    lblNoOfRooms.Text = drTicketRow["NoOfRooms"].ToString();
                                    lblPaxGreaterThan12.Text = drTicketRow["NoOfAdults"].ToString();
                                    lblPaxLessThan12.Text = drTicketRow["NoOfChildren"].ToString();

                                    lblBookedDate.Text = drTicketRow["BookedDate"].ToString();
                                    lblHotelContactDetails.Text = drTicketRow["ContactNumbers"].ToString() + " , Fax Nos: " + drTicketRow["FaxNumbers"].ToString();


                                    lblTotalPrice.Text = drTicketRow["HotelTotalFare"].ToString() + "~" + drTicketRow["HotelTotlaFareDetails"].ToString();/////////////

                                    lblTitle.Text = drTicketRow["Title"].ToString();
                                    lblFirstName.Text = drTicketRow["FirstName"].ToString();
                                    lblMiddleName.Text = drTicketRow["MiddleName"].ToString();
                                    lblLastName.Text = drTicketRow["LastName"].ToString();
                                    lblMobileNo.Text = drTicketRow["MobileNumber"].ToString();
                                    lblEmailId.Text = drTicketRow["EmailId"].ToString();
                                    lblAdd.Text = drTicketRow["CustAddressLine"].ToString();
                                    lblState.Text = drTicketRow["CustState"].ToString();
                                    lblPinCode.Text = drTicketRow["CustZipCode"].ToString();

                                    lblCity.Text = drTicketRow["CustCity"].ToString();

                                    SMS();
                                    Mail(lblEmailId.Text.ToString());
                                }
                            }
                            else { lblMsg.Text = "Please Try Again."; }
                        }
                        else if (drr["bookingstatus"].ToString() == "E")
                        {
                            lblMsg.Text = "Failed to book the ticket.";
                        }
                    }

                    Session["HotelRefNo"] = null;
                }
            }
        }
    }
    protected void SMS()
    {
        try
        {



            string strUrl = "http://www.smsstriker.com/API/sms.php?username=lovejourney&password=lovejourney&from=LVJRNY&to=" + lblMobileNo.Text + "&msg=" + "Dear " + lblFirstName.Text + ", " + "You have succesfuly booked the room in " + lblHotelName.Text + " at " + lblHotelCity.Text + ". CheckIn :" + lblCheckIn.Text +
                " CheckOut : " + lblCheckOut.Text + " LJ RefNo:" + lblHotelRefNo.Text + ". Thanks for choosing www.lovejourney.in" + "%20&type=1";


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
    public string InsertHotelBooking(int provisionalId, string wsKey, string extGuestTotal, string roomTotal, string serviceTaxTotal, string bookingStatus,
        string bookingRemarks, string bookingRefNo, string bookingTrn, string discount, string contactNumbers, string faxNumbers, int? createdBy)
    {
        try
        {
            string strReturn = "";
            HotelBAL objHBooking = new HotelBAL();
            objHBooking.ProvisionalId = provisionalId;
            objHBooking.WsKey = wsKey;
            objHBooking.ExtGuestTotal = extGuestTotal;
            objHBooking.RoomTotal = roomTotal;
            objHBooking.ServiceTaxTotal = serviceTaxTotal;
            objHBooking.BookingStatus = bookingStatus;
            objHBooking.BookingRemarks = bookingRemarks;
            objHBooking.BookingRefNo = bookingRefNo;
            objHBooking.BookingTrn = bookingTrn;
            objHBooking.Discount = discount;
            objHBooking.ContactNumbers = contactNumbers;
            objHBooking.FaxNumbers = faxNumbers;
            objHBooking.CreatedBy = createdBy;

            bool b = objHBooking.AddHotelBooking();
            if (b) { strReturn = "Success"; }
            else { strReturn = ""; }
            return strReturn;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    private string getHTML(Panel Pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        Pnl.RenderControl(htmlwriter);
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
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”server” 
            -------------------------------------------  */
    }
    void Mail(string mailId)
    {
        try
        {
            {
                string body = getHTML(pnlTicket);
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
    protected void btnExportTOWord_Click(object sender, EventArgs e)
    {
        try
        {
            pnlTicket.Visible = true;
            // BindLabelData();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Ticket.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlTicket.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing


        }
    }
    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {

            if (lblEmailId.Text != null)
            {
                // downlink.Visible = false;
                string body = getHTML(pnlTicket);
                bool res = MailSender.SendEmail(lblEmailId.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", body);
                // downlink.Visible = true;
                if (res)
                {

                    lblMsg.Text = "Mail has been sent successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    lblMsg.Text = "Failed to send Mail ";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}