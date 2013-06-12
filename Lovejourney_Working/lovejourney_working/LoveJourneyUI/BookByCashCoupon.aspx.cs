using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using BusAPILayer;

public partial class BookByCashCoupon : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL ObjBAL;
    DataSet _objDataSet;
    DataSet _objDataSetBook;
    IBitlaAPILayer objBitlaAPILayer;
    IKesineniAPILayer objKesineniAPILayer;
    IAbhiBusAPILayer objAbhiBusAPILayer;
    IKalladaAPILayer objKalladaAPILayer;
    ITicketGooseAPILayer objTicketGooseAPILayer;

    KalladaAPILayer kalladaDetails;
    static string Checked = "null";
    static string ipaddr;
    bool bookres = false;
    bool bookresreturn = false;
    bool res = false;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        objBitlaAPILayer = BitlaFactoryManager.GetBitlaAPILayerObject();
        objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
        objBitlaAPILayer.URL = BitlaConstants.URL;
        objKesineniAPILayer = KesineniFactoryManager.GetKesineniAPILayerObject();
        objKesineniAPILayer.LoginId = KesineniConstants.LoginId;
        objKesineniAPILayer.Password = KesineniConstants.Password;
        objAbhiBusAPILayer = AbhiBusFactoryManager.GetAbhiBusAPILayerObject();
        objKalladaAPILayer = KalladaFactoryManager.GetKalladaAPILayerObject();
        objTicketGooseAPILayer = TicketGooseFactoryManager.GetTicketGooseAPILayerObject();
        objTicketGooseAPILayer.UserId = TicketGooseConstants.USERID;
        objTicketGooseAPILayer.Password = TicketGooseConstants.PASSWORD;
        try
        {
            if (!IsPostBack)
            {
                BookTicket();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected String GenerateCashCoupon()
    {
        lblMsg.Text = "";
        int minPassSize = 8;
        int maxPassSize = 8;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        string code = "LJCC" + stringBuilder.ToString();
        ObjBAL = new ClsBAL();

        if (ObjBAL.CheckCashCouponAvailability(code) == false)
        {
            GenerateCashCoupon();
        }
        return code;
    }

    protected bool UpdateCashCoupon(string manabusrefNo, string emailID)
    {
        try
        {
            bool ress = false;
            ObjBAL = new ClsBAL();
            ObjBAL.manabusRefNo = manabusrefNo;
            _objDataSet = (DataSet)ObjBAL.GetUpdatedCouponDetails();

            if (_objDataSet != null)
            {

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    double amount = Convert.ToDouble(_objDataSet.Tables[0].Rows[0]["AmountAfterPG"].ToString());
                    if (amount > 0)
                    {
                        string couponcode = GenerateCashCoupon();

                        goto next;
                    next:
                        bool REs1 = AddCashCoupon(Convert.ToString(amount), couponcode, emailID);
                        if (REs1)
                        {
                            string body = "Dear Valued Customer, " + ",<br/><br/>" + "Thank you for using LoveJourney.in as your travel partner for booking your Bus Ticket. You can enter the cash coupon ID in the cash coupon box on the personal details page the next time you want to transact on LoveJourney.in and your amount will be adjusted against the fare.<br/><br/>"
                            + "Below are the cash coupon details of the cancelled ticket<br/><br/>Cash Coupon ID :" + couponcode + "<br/> Coupon Value: " + amount + "<br/>Expiry Date :" + DateTime.Now.AddMonths(6).ToString()
                            + "<br/><br/>Please save the cash coupon ID. This cash coupon can be used during your next transaction on LoveJourney.in. For more details about cash coupon, please visit the frequently asked questions page http://LoveJourney.in/FAQ." +
                            "<br/><br/>Best regards,<br/>Support Staff.<br/>LoveJourney.in";
                            Mailsender.SendEmail(emailID, "", "", "LoveJourney Cash Coupon Code", body);
                            lblMsg.Text = "Cash Coupon Code has been sent to your Email Id Please check";
                            ress = true;
                        }
                        else
                        {
                            goto next;

                        }
                    }
                    else if (amount == 0)
                    {
                        ress = true;
                    }
                }

            }
            return ress;
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected bool AddCashCoupon(string Amount, string couponCode, string emailid)
    {
        try
        {
            ObjBAL = new ClsBAL();

            ObjBAL.couponNo = Convert.ToString(couponCode);
            ObjBAL.emailId = Convert.ToString(emailid);
            ObjBAL.Amount = Convert.ToString(Amount);
            ObjBAL.createdBy = null;

            if (ObjBAL.AddCashCoupon(ref lblMsg))
            {
                return true;
            }
            else if (lblMsg.Text == "Already Cash Coupon with this Number Exists")
            {
                return false;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {

            throw ex;

        }

    }

    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            ObjBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                ObjBAL.api = travelname.Substring(0, 5);
            }
            else { ObjBAL.api = travelname; }
            _objDataSet = (DataSet)ObjBAL.GetCancelPercentageByAPI();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
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

    protected void BookTicket()
    {
        try
        {
            int sourceStationId = 0; int destinationStationId = 0; string journeyDate = "";
            long serviceId = 0; int serviceTransId = 0; int noOfSeats = 0; string address = ""; string contactNo = ""; string emailID = "";
            long blockedTicketId = 0; string apiname = ""; string boradingpointid = ""; int k = 0;
            string status = ""; string api = "";
            DataSet dsbookresult = null;
            if (Session["manabusrefno"] != null)
            {
                ObjBAL = new ClsBAL();
                ObjBAL.manabusRefNo = Session["manabusrefno"].ToString();
                _objDataSetBook = (DataSet)ObjBAL.GetTcktDetByMRefNo();
                if (_objDataSetBook != null)
                {
                    if (_objDataSetBook.Tables.Count > 0)
                    {
                        if (_objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            if (_objDataSetBook.Tables[0].Rows.Count < 3)
                            {
                                #region Book Ticket
                                foreach (DataRow dr in _objDataSetBook.Tables[0].Rows)
                                {
                                    string manabusrefNo = dr["OnewayMBRefNo"].ToString();
                                    apiname = dr["APIName"].ToString();
                                    sourceStationId = Convert.ToInt32(dr["SourceId"].ToString());
                                    destinationStationId = Convert.ToInt32(dr["DestinationId"].ToString());
                                    DateTime doj = Convert.ToDateTime(dr["DateOfJourney"]);
                                    boradingpointid = dr["BoardingPointID"].ToString();

                                    if (apiname == "Abhibus" || apiname == "Kallada")
                                    {
                                        journeyDate = doj.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        journeyDate = doj.ToString("yyyy/MM/dd");
                                    }

                                    if (dr["ServiceID"].ToString() == "")
                                    {
                                        serviceId = 0;
                                    }
                                    else
                                    {
                                        serviceId = Convert.ToInt64(dr["ServiceID"].ToString());
                                    }
                                    string bookinId = "";

                                    address = dr["Address"].ToString();
                                    contactNo = dr["ContactNo"].ToString();
                                    emailID = dr["EmailId"].ToString();
                                    if (dr["ServiceTranDateID"].ToString() == "")
                                    {
                                        serviceTransId = 0;
                                    }
                                    else
                                    {
                                        serviceTransId = Convert.ToInt32(dr["ServiceTranDateID"].ToString());
                                    }
                                    noOfSeats = Convert.ToInt32(dr["NoOfSeats"].ToString());
                                    if (apiname != "TicketGoose")
                                    {
                                        if (dr["BlockedId"].ToString() == "")
                                        {
                                            blockedTicketId = 0;
                                        }
                                        else
                                        {
                                            blockedTicketId = Convert.ToInt64(dr["BlockedId"].ToString());
                                        }
                                    }
                                    else { blockedTicketId = 0; bookinId = Convert.ToString(dr["BlockedId"].ToString()); }
                                    string seatNos = dr["SeatNos"].ToString();
                                    string gendertype = dr["Gender"].ToString();
                                    string psgrname = dr["FullName"].ToString();
                                    string idType = dr["IDType"].ToString();
                                    string idNo = dr["IDNumber"].ToString();
                                    string idIssuedBy = dr["IDIssuedBy"].ToString();
                                    string[] selectedSeatsArray = seatNos.Split(',');
                                    book_ticket bookTicket = new book_ticket();
                                    object[] obj = new object[2];

                                    book_ticketSeat_detailsSeat_detail[] sD = new book_ticketSeat_detailsSeat_detail[noOfSeats];

                                    string strPassengers = dr["PassengerDetails"].ToString();
                                    string[] strPassengersArray = strPassengers.Split(',');

                                    for (int i = 0; i < noOfSeats; i++)
                                    {
                                        book_ticketSeat_detailsSeat_detail sdd = new book_ticketSeat_detailsSeat_detail();
                                        sdd.seat_number = selectedSeatsArray[i].ToString();

                                        string strPassenger = strPassengersArray[i].ToString();
                                        string[] strPassengerArray = strPassenger.Split('-');

                                        sdd.title = strPassengerArray[1].ToString();
                                       
                                        if (strPassengerArray[1].ToString() == "Mr")
                                        {
                                            sdd.sex = "M";
                                        }
                                        else { sdd.sex = "F"; }

                                        if (i == 0) { sdd.is_primary = "true"; }
                                        else { sdd.is_primary = "false"; }
                                        sdd.address = address;

                                        string id = "";//1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card
                                        if (idType.ToString().ToLower().Contains("pan"))
                                        {
                                            id = "1";
                                        }
                                        else if (idType.ToString().ToLower().Contains("dri"))
                                        {
                                            id = "2";
                                        }
                                        else if (idType.ToString().ToLower().Contains("pass"))
                                        {
                                            id = "3";
                                        }
                                        else if (idType.ToString().ToLower().Contains("voter"))
                                        {
                                            id = "4";
                                        }
                                        else if (idType.ToString().ToLower().Contains("adhar"))
                                        {
                                            id = "5";
                                        }
                                        else if (idType.ToString().ToLower().Contains("ration"))
                                        {
                                            id = "4";
                                        }

                                        sdd.id_card_type = id;

                                        sdd.id_card_number = idNo;
                                        sdd.id_card_issued_by = idIssuedBy;
                                        sD[i] = sdd;
                                    }

                                    book_ticketSeat_details ss = new book_ticketSeat_details();
                                    ss.seat_detail = sD;
                                    book_ticketContact_detail cc = new book_ticketContact_detail();
                                    cc.mobile_number = contactNo;
                                    cc.email = emailID;
                                    cc.emergency_name = contactNo;
                                    obj[0] = ss;
                                    bookTicket.Items = obj;

                                    dsbookresult = CommonBookticket(sourceStationId, destinationStationId, journeyDate, serviceId, serviceTransId,
                                        blockedTicketId, boradingpointid, bookTicket, noOfSeats, seatNos, gendertype, psgrname, address,
                                        dr["FullName"].ToString(), contactNo, emailID, Session["manabusrefno"].ToString(), manabusrefNo,
                                        apiname, out api, out status, bookinId);
                                    if (status == "Success")
                                    {
                                        InsertBookedTicketDetails(dsbookresult, manabusrefNo, api);
                                    }
                                    else
                                    {
                                        lblReturnMsg.Text = "Failed to book. Please contact administartor of LoveJourney.";
                                        lblReturnMsg.Visible = true;
                                    }
                                }
                                #endregion

                                #region GetTicketDetails
                                if (status == "Success")
                                {
                                    #region Update Cash Coupon
                                    UpdateCashCoupon(Session["manabusrefno"].ToString(), emailID);
                                    #endregion
                                    GetTicketDetails();
                                }
                                #endregion
                            }
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

    protected DataSet CommonBookticket(int sourceId, int destinationId, string DOJ, long servicereservationId, int serviceTransId, 
        long blockedTicketId, string boardingpointId, book_ticket bookTicket, int noofSeats, string selectedSeats, string genderType, 
        string psgrName, string address, string fullName, string phoneNo, string emailId, string refNo, string manabusref, string Api,
        out string api, out string status, string bookinId)
    {
        try
        {
            api = ""; status = "Fail"; DataSet dsBookingResult = null; bool res = false;
            if (Api.ToString() == "Kesineni")
            {
                #region Kesineni

                dsBookingResult = objKesineniAPILayer.BookTicketsConfirmationOnwardJourney(sourceId, destinationId, DOJ,
                servicereservationId, serviceTransId, noofSeats, blockedTicketId, GenerateCashCoupon(), GenerateCashCoupon());
                if (dsBookingResult != null)
                {
                    if (dsBookingResult.Tables.Count > 0)
                    {
                        if (dsBookingResult.Tables[0].Rows.Count > 0)
                        {
                            res = true;
                            status = "Success";
                            api = "Kesineni";
                        }
                    }
                }
                #endregion
            }
            else if (Api.ToString() == "Bitla")
            {
                #region Bitla

                objBitlaAPILayer.ReservationId = Convert.ToString(servicereservationId);
                objBitlaAPILayer.OriginId = Convert.ToString(sourceId);
                objBitlaAPILayer.DestinationId = Convert.ToString(destinationId);
                objBitlaAPILayer.BoardingAt = boardingpointId;
                objBitlaAPILayer.NoOfSeats = Convert.ToString(noofSeats);
                objBitlaAPILayer.RefNumber = refNo;
                objBitlaAPILayer.TicketDetails = bookTicket;
                dsBookingResult = objBitlaAPILayer.BookTicket();
                if (dsBookingResult != null)
                {
                    if (dsBookingResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsBookingResult.Tables[0].Columns.Count > 3)
                        {
                            res = true;
                            status = "Success";
                            api = "Bitla";
                        }
                    }
                }
                #endregion
            }
            else if (Api.ToString() == "Abhibus")
            {
                #region Abhibus

                DataTable dtabhibus = objAbhiBusAPILayer.SeatBooking(DOJ, Convert.ToString(sourceId),
                    Convert.ToString(destinationId), Convert.ToString(servicereservationId), selectedSeats, genderType, psgrName,
                       boardingpointId, address.ToString(), fullName.ToString(),
                       phoneNo.ToString(), emailId.ToString(), refNo);
                dsBookingResult = new DataSet();
                dsBookingResult.Tables.Add(dtabhibus);
                if (dsBookingResult != null)
                {
                    if (dsBookingResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsBookingResult.Tables[0].Columns.Count > 2 && dsBookingResult.Tables[0].Rows[0]["TicketNumber"].ToString() != "")
                        {
                            res = true;
                            status = "Success";
                            api = "Abhibus";
                        }
                    }
                }
                #endregion
            }
            else if (Api.ToString() == "Kallada")
            {
                DataTable dtKallada = objKalladaAPILayer.SeatBooking(DOJ, Convert.ToString(sourceId), Convert.ToString(destinationId),
                       Convert.ToString(servicereservationId), selectedSeats, genderType, psgrName,
                       boardingpointId, address.ToString(), fullName.ToString(),
                       phoneNo.ToString(), emailId.ToString(), refNo);
                dsBookingResult = new DataSet();
                dsBookingResult.Tables.Add(dtKallada);
                if (dsBookingResult != null)
                {
                    if (dsBookingResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsBookingResult.Tables[0].Columns.Count > 2 && dsBookingResult.Tables[0].Rows[0]["TicketNumber"].ToString() != "")
                        {
                            res = true;
                            status = "Success";
                            api = "Kallada";
                        }
                    }
                }
            }
            else if (Api.ToString() == "TicketGoose")
            {
                DataTable dt = objTicketGooseAPILayer.BookTicket(bookinId);
                dsBookingResult = new DataSet();
                dsBookingResult.Tables.Add(dt);
                if (dsBookingResult != null)
                {
                    if (dsBookingResult.Tables[0].Rows.Count > 0)
                    {
                        if (dsBookingResult.Tables[0].Columns.Count > 2 && dsBookingResult.Tables[0].Rows[0]["Status"].ToString() != "")
                        {
                            if (dsBookingResult.Tables[0].Rows[0]["Status"].ToString() == "Success")
                            {
                                res = true;
                                status = "Success";
                                api = "TicketGoose";
                            }
                        }
                    }
                }
            }
            return dsBookingResult;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected bool InsertBookedTicketDetails(DataSet dsbookres, string manabusrefno, string api)
    {
        try
        {
            string pnrNumber = ""; string pnrticketId = ""; string message = ""; bool resinsert = false;
            if (api == "Kesineni")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["PNRNumber"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["PNRTicketIDs"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Message"].ToString();
            }
            else if (api == "Bitla")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["ticket_number"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["travel_operator_pnr"].ToString();
                message = dsbookres.Tables[0].Rows[0]["ticket_status"].ToString();
            }
            else if (api == "Abhibus")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["TicketNumber"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["serviceNumber"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Message"].ToString();
            }
            else if (api == "Kallada")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["TicketNumber"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["serviceNumber"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Message"].ToString();
            }
            else if (api == "TicketGoose")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["bookingId"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["extraSeatInfo"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Status"].ToString();
            }
            ObjBAL = new ClsBAL();
            ObjBAL.PNRNumber = pnrNumber;
            ObjBAL.PNRTicketIDs = pnrticketId;
            ObjBAL.message = message;
            ObjBAL.manabusRefNo = manabusrefno;//Session["manabusrefno"].ToString();
            ObjBAL.api = api;
            if (ObjBAL.AddBooking_TicketDetails())
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

    protected void GetTicketDetails()
    {
        try
        {
            if (Session["manabusrefno"] != null)
            {
                ObjBAL = new ClsBAL();
                ObjBAL.manabusRefNo = Session["manabusrefno"].ToString();
                _objDataSetBook = (DataSet)ObjBAL.GetTicketIdByManabusRefNo();
                if (_objDataSetBook != null)
                {
                    if (_objDataSetBook.Tables.Count > 0)
                    {
                        if (_objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            string travelName = _objDataSetBook.Tables[0].Rows[0]["TravelOPName"].ToString();
                            string api = _objDataSetBook.Tables[0].Rows[0]["APIName"].ToString();
                            lblNewcashcouponcode.Text = _objDataSetBook.Tables[0].Rows[0]["CouponNo"].ToString();
                            lblnewCouponAmount.Text = _objDataSetBook.Tables[0].Rows[0]["CashCouponAmount"].ToString();
                            gvView.DataSource = _objDataSetBook.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(travelName);
                            if (api == "Kesineni")
                            {
                                imgKesineni.Visible = true;
                            }
                            Mail();
                            #region SMS
                            Label lblManabusRefNo = (Label)gvView.Rows[0].FindControl("lblManabusRefNo");
                            Label lblDOJ = (Label)gvView.Rows[0].FindControl("lblDOJ");
                            Label lblTravelName = (Label)gvView.Rows[0].FindControl("lblTravelName");
                            Label lblSourceName = (Label)gvView.Rows[0].FindControl("lblSourceName");
                            Label lblDestinationName = (Label)gvView.Rows[0].FindControl("lblDestinationName");
                            Label lblBusType = (Label)gvView.Rows[0].FindControl("lblBusType");
                            Label lblBoardingPoint = (Label)gvView.Rows[0].FindControl("lblBoardingPoint");
                            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailid");
                            Label lblContactNo = (Label)gvView.Rows[0].FindControl("lblContactNo");
                            Label lblBookedBy = (Label)gvView.Rows[0].FindControl("lblBookedBy");
                            string msg = "Hi " + lblBookedBy.Text + "Your Journey Details are" + System.Environment.NewLine + "Route : " + lblSourceName.Text + " to " + lblDestinationName.Text + System.Environment.NewLine + "Reference N0: " + lblManabusRefNo.Text + System.Environment.NewLine +
                                "Travel Name: " + lblTravelName.Text;
                            string msg1 = " DOJ: " + lblDOJ.Text + System.Environment.NewLine + System.Environment.NewLine + "Thanks & Regards," + System.Environment.NewLine + "LoveJourney team";

          //                  string strUrl = "http://sms.cheapgoogleads.com/WebServiceSMS.aspx?User=superbus&passwd=hyderabad&mobilenumber=" + lblContactNo.Text.ToString() +
          //"&message= " + msg.ToString();

          //                  string strUrl2 = "http://sms.cheapgoogleads.com/WebServiceSMS.aspx?User=superbus&passwd=hyderabad&mobilenumber=" + lblContactNo.Text.ToString() +
          //"&message= " + msg1.ToString();
          //                  SendSMS(strUrl);
          //                  SendSMS(strUrl2);
                            #endregion
                        }
                        else
                        {
                            pnlmail.Visible = false;
                        }
                    }
                }
            }

        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (_objDataSetBook != null)
            {
                _objDataSetBook = null;
            }
        }
    }

    protected void SendSMS(string MSG)
    {
        try
        {
            //HttpWebRequest oReq1 = null;
            //HttpWebResponse oRes1 = null;
            //StreamReader oStream1 = null;
            //oReq1 = (HttpWebRequest)WebRequest.Create(MSG);
            //oReq1.Method = "GET";
            //oReq1.Timeout = 10000;
            //oRes1 = (HttpWebResponse)oReq1.GetResponse();
            //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            //string strMessage1 = oStream1.ReadToEnd().ToString();
        }
        catch (Exception ex)
        {
            throw ex;
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
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */
    }

    protected void Mail()
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (lblEmailID != null)
            {
                string body = getHTML(pnlmail);
                bool res = Mailsender.SendEmail(lblEmailID.Text, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMsg.Text = "Ticket Details has been sent to your mail. Please check. ";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
                            string[] details = item.Replace('-', ' ').Split(' ');
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
}