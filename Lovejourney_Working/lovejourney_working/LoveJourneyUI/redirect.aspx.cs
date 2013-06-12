using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusAPILayer;
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
using BAL;


public partial class redirect : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL ObjManbusBAL;
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
        if (!IsPostBack)
        {
            pnlmail.Visible = false;
        }

        populate(sender, e);
    }

    public string verifychecksum(string MerchantId, string OrderId, string Amount, string AuthDesc, string WorkingKey, string checksum)
    {
        string str, retval, adlerResult;
        long adler;
        str = MerchantId + "|" + OrderId + "|" + Amount + "|" + AuthDesc + "|" + WorkingKey;
        adler = 1;
        adlerResult = adler32(adler, str);

        if (string.Compare(adlerResult, checksum, true) == 0)
        {
            retval = "true";
        }
        else
        {
            retval = "false";
        }
        return retval;
    }

    private string adler32(long adler, string strPattern)
    {
        long BASE;
        long s1, s2;
        char[] testchar;
        long intTest = 0;

        BASE = 65521;
        s1 = andop(adler, 65535);
        s2 = andop(cdec(rightshift(cbin(adler), 16)), 65535);

        for (int n = 0; n < strPattern.Length; n++)
        {

            testchar = (strPattern.Substring(n, 1)).ToCharArray();
            intTest = (long)testchar[0];
            s1 = (s1 + intTest) % BASE;
            s2 = (s2 + s1) % BASE;
        }
        return (cdec(leftshift(cbin(s2), 16)) + s1).ToString();
    }

    private long power(long num)
    {
        long result = 1;
        for (int i = 1; i <= num; i++)
        {
            result = result * 2;
        }
        return result;
    }

    private long andop(long op1, long op2)
    {
        string op, op3, op4;
        op = "";

        op3 = cbin(op1);
        op4 = cbin(op2);

        for (int i = 0; i < 32; i++)
        {
            op = op + "" + ((long.Parse(op3.Substring(i, 1))) & (long.Parse(op4.Substring(i, 1))));
        }
        return cdec(op);
    }

    private string cbin(long num)
    {
        string bin = "";
        do
        {
            bin = (((num % 2)) + bin).ToString();
            double dbl1 = num / 2;
            num = (long)System.Math.Floor(dbl1);
        } while (!(num == 0));

        long tempCount = 32 - bin.Length;

        for (int i = 1; i <= tempCount; i++)
        {
            bin = "0" + bin;
        }
        return bin;
    }

    private string leftshift(string str, long num)
    {
        long tempCount = 32 - str.Length;

        for (int i = 1; i <= tempCount; i++)
        {

            str = "0" + str;
        }

        for (int i = 1; i <= num; i++)
        {
            str = str + "0";
            str = str.Substring(1, str.Length - 1);
        }
        return str;
    }

    private string rightshift(string str, long num)
    {

        for (int i = 1; i <= num; i++)
        {
            str = "0" + str;
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

    private long cdec(string strNum)
    {
        long dec = 0;
        for (int n = 0; n < strNum.Length; n++)
        {
            dec = dec + (long)(long.Parse(strNum.Substring(n, 1)) * power(strNum.Length - (n + 1)));
        }
        return dec;
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

    protected void getip()
    {

        ipaddr = Page.Request.UserHostAddress;

    }

    void populate(Object sender, EventArgs e)
    {
        string WorkingKey, Order_Id, Merchant_Id, Amount, AuthDesc, Checksum, newChecksum, status;

        //Assign following values to send it to verifychecksum function.
        //put in the 32 bit working key in the quotes provided here

        WorkingKey = "f3jbvmtdnx1xvphbe4";
        Merchant_Id = "M_syedtrav_15190";
        Order_Id = Request.Form["Order_Id"];
        Session["manabusrefno"] = Order_Id;
        Amount = Request.Form["Amount"];
        AuthDesc = Request.Form["AuthDesc"];



        ////////////////////////  ERROR...This variable(status) is not declared anywhere 

        status = Request.Form["Status"];

        ////////////////////// This comment is given by Majestic People, Coimbatore
        ////////////////////// The following variable "checksum" is declared as "Checksum" at the top

        Checksum = Request.Form["Checksum"];

        //Response.Write("Merchant_Id:" + Merchant_Id + "<br>");
        //Response.Write(Order_Id + "<br>");
        //Response.Write(Amount + "<br>");
        //Response.Write(AuthDesc + "<br>");
        //Response.Write(status + "<br>");
        //Response.Write(Checksum + "<br>");


        //Checksum = verifychecksum(Merchant_Id , Order_Id, Amount , AuthDesc ,WorkingKey, Checksum);
        Checksum = verifychecksum(Merchant_Id, Order_Id, Amount, AuthDesc, WorkingKey, Checksum);
        //Response.Write(Checksum + "<br>");

        if ((Checksum == "true") && (AuthDesc == "Y"))
        {
            BookTicket();
            pnlmail.Visible = true;
            //Response.Redirect("Payment.aspx?Result=Success", false);

        }
        else if ((Checksum == "true") && (AuthDesc == "N"))
        {
            // Message.Text = "<br>Thank you for Using Rechargebig. However,the transaction has been declined.";
            /*
                Here you need to put in the routines for a failed
                transaction such as sending an email to customer
                setting database status etc etc
            */
            //Response.Redirect("Payment.aspx?Result=Failure", false);
            Message.Text = "<br>Sorry for in convevience...payment Failed....";
            pnlmail.Visible = false;
        }
        else if ((Checksum == "true") && (AuthDesc == "B"))
        {
            Message.Text = "<br>Thank you for shopping with us.We will keep you posted regarding the status of your order through e-mail";
            pnlmail.Visible = false;
            /*
                Here you need to put in the routines/e-mail for a  "Batch Processing" order
                This is only if payment for this transaction has been made by an American Express Card
                since American Express authorisation status is available only after 5-6 hours by mail from ccavenue and at the "View Pending Orders"
         */
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

    protected String GenerateCashCoupon()
    {
        lblMsg.Text = "";
        int minPassSize = 9;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        //lblMessage.Text = stringBuilder.ToString();
        string code = "LJCC" + stringBuilder.ToString();
        ObjManbusBAL = new ClsBAL();

        if (ObjManbusBAL.CheckCashCouponAvailability(code) == false)
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
            ObjManbusBAL = new ClsBAL();
            ObjManbusBAL.manabusRefNo = manabusrefNo;
            _objDataSet = (DataSet)ObjManbusBAL.GetUpdatedCouponDetails();

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
                            string body = "HI " + ",<br/><br/>" + "Thanks for booking ticket. Your new cash coupon code is " + couponcode + " of amount <b>" + amount + "</b><br/>Note: This Coupon will expire with in 6 months." + "<br/><br/>Thanks & Regards,<br/>LoveJourney Team.";
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
        finally
        {

            if (_objDataSet != null)
            {
                _objDataSet = null;
            }
        }

    }

    protected bool AddCashCoupon(string Amount, string couponCode, string emailid)
    {
        try
        {
            ObjManbusBAL = new ClsBAL();

            ObjManbusBAL.couponNo = Convert.ToString(couponCode);
            ObjManbusBAL.emailId = Convert.ToString(emailid);
            ObjManbusBAL.Amount = Convert.ToString(Amount);
            ObjManbusBAL.createdBy = null;

            if (ObjManbusBAL.AddCashCoupon(ref lblMsg))
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

    protected void GetCancellationPolicy(string API)
    {
        try
        {
            ObjManbusBAL = new ClsBAL();
            //if (API.Length >= 5)
            //{
            //    ObjManbusBAL.api = API.Substring(0, 5);
            //}
            //else { ObjManbusBAL.api = API; }
            ObjManbusBAL.api = API;
            _objDataSet = (DataSet)ObjManbusBAL.GetCancelPercentageByAPI();
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
        finally
        {

            if (_objDataSet != null)
            {
                _objDataSet = null;
            }
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
                ObjManbusBAL = new ClsBAL();
                ObjManbusBAL.manabusRefNo = Session["manabusrefno"].ToString();
                _objDataSetBook = (DataSet)ObjManbusBAL.GetTcktDetByMRefNo();
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
                                        sdd.name = strPassengerArray[2].ToString();
                                        sdd.age = strPassengerArray[3].ToString();

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
                                    obj[1] = cc;
                                    bookTicket.Items = obj;

                                    dsbookresult = CommonBookticket(sourceStationId, destinationStationId, journeyDate, serviceId, serviceTransId, blockedTicketId, boradingpointid,
                                           bookTicket, noOfSeats, seatNos, gendertype, psgrname, address, dr["FullName"].ToString(), contactNo,
                                          emailID, Session["manabusrefno"].ToString(), manabusrefNo, apiname, out api, out status, bookinId);
                                    if (status == "Success")
                                    {
                                        InsertBookedTicketDetails(dsbookresult, manabusrefNo, api);
                                    }
                                    else
                                    {
                                        lblReturnMsg.Text = "Failed to book.Please contact administartor of Manabus..";
                                        lblReturnMsg.Visible = true;
                                    }
                                }
                                #endregion
                                if (status == "Success")
                                {
                                    #region Update Cash Coupon
                                    UpdateCashCoupon(Session["manabusrefno"].ToString(), emailID);
                                    #endregion

                                    #region GetTicketDetails
                                    GetTicketDetails();
                                    #endregion
                                }
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
        finally
        {
            if (_objDataSetBook != null)
            {
                _objDataSetBook = null;
            }

        }

    }

    protected DataSet CommonBookticket(int sourceId, int destinationId, string DOJ, long servicereservationId, int serviceTransId, long blockedTicketId,
        string boardingpointId, book_ticket bookTicket, int noofSeats, string selectedSeats, string genderType, string psgrName, string address,
        string fullName, string phoneNo, string emailId, string refNo, string manabusref, string Api, out string api, out string status, string bookinId)
    {
        try
        {
            api = ""; status = "Fail"; DataSet dsBookingResult = null; bool res = false;
            if (Api.ToString() == "Kesineni")
            {
                #region Kesineni


                dsBookingResult = objKesineniAPILayer.BookTicketsConfirmationOnwardJourney(sourceId, destinationId, DOJ,
                servicereservationId, serviceTransId, noofSeats, blockedTicketId, "0987654321", "1234567890");
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

                DataTable dtabhibus = objAbhiBusAPILayer.SeatBooking(DOJ, Convert.ToString(sourceId), Convert.ToString(destinationId), Convert.ToString(servicereservationId), selectedSeats, genderType, psgrName,
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
                DataTable dtKallada = objKalladaAPILayer.SeatBooking(DOJ, Convert.ToString(sourceId), Convert.ToString(destinationId), Convert.ToString(servicereservationId), selectedSeats, genderType, psgrName,
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
                pnrticketId = dsbookres.Tables[0].Rows[0]["bookingId"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Status"].ToString();
            }
            ObjManbusBAL = new ClsBAL();
            ObjManbusBAL.PNRNumber = pnrNumber;
            ObjManbusBAL.PNRTicketIDs = pnrticketId;
            ObjManbusBAL.message = message;
            ObjManbusBAL.manabusRefNo = manabusrefno;//Session["manabusrefno"].ToString();
            ObjManbusBAL.api = api;

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

    protected void GetTicketDetails()
    {
        try
        {
            if (Session["manabusrefno"] != null)
            {
                ObjManbusBAL = new ClsBAL();
                ObjManbusBAL.manabusRefNo = Session["manabusrefno"].ToString();
                _objDataSetBook = (DataSet)ObjManbusBAL.GetTicketIdByManabusRefNo();
                if (_objDataSetBook != null)
                {
                    if (_objDataSetBook.Tables.Count > 0)
                    {
                        if (_objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            string travelName = _objDataSetBook.Tables[0].Rows[0]["TravelOPName"].ToString();
                            string api = _objDataSetBook.Tables[0].Rows[0]["APIName"].ToString();
                            gvView.DataSource = _objDataSetBook.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(travelName);
                            if (api == "Kesineni")
                            {
                               // imgKesineni.Visible = true;
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
                            //Label lblNoOfSeats = (Label)gvView.Rows[0].FindControl("lblNoOfSeats");
                            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailid");
                            Label lblContactNo = (Label)gvView.Rows[0].FindControl("lblContactNo");
                            Label lblBookedBy = (Label)gvView.Rows[0].FindControl("lblBookedBy");
                            string msg = "Hi " + lblBookedBy.Text + "Your Journey Details are" + System.Environment.NewLine + "Route : " + lblSourceName.Text + " to " + lblDestinationName.Text + System.Environment.NewLine + "Reference N0: " + lblManabusRefNo.Text + System.Environment.NewLine +
                                "Travel Name: " + lblTravelName.Text;
                            string msg1 = " DOJ: " + lblDOJ.Text + System.Environment.NewLine  + System.Environment.NewLine + "Thanks & Regards," + System.Environment.NewLine + "Manabus team";

          //                  string strUrl = "http://sms.cheapgoogleads.com/WebServiceSMS.aspx?User=superbus&passwd=hyderabad&mobilenumber=" + lblContactNo.Text.ToString() +
          //"&message= " + msg.ToString();

          //                  string strUrl2 = "http://sms.cheapgoogleads.com/WebServiceSMS.aspx?User=superbus&passwd=hyderabad&mobilenumber=" + lblContactNo.Text.ToString() +
          //"&message= " + msg1.ToString();
          //                  SendSMS(strUrl);
          //                  SendSMS(strUrl2);
                            #endregion
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

    #region Mail
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

                    lblMsg.Text = "Ticket Details has been sent to your mail. Please check.";
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
    #endregion

    #region SMS

    protected void SendSMS(string MSG)
    {
        try
        {
            HttpWebRequest oReq1 = null;
            HttpWebResponse oRes1 = null;
            StreamReader oStream1 = null;
            oReq1 = (HttpWebRequest)WebRequest.Create(MSG);
            oReq1.Method = "GET";
            oReq1.Timeout = 10000;
            oRes1 = (HttpWebResponse)oReq1.GetResponse();
            oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            string strMessage1 = oStream1.ReadToEnd().ToString();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    #endregion

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
}