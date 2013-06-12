using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilghtsAPILayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;
using BusAPILayer;
using HotelAPILayer;


public partial class AdminDashBoard_AdminDashBoardCancel : System.Web.UI.Page
{

    string transId = string.Empty;
    FlightsAPILayer objFlights = new FlightsAPILayer();
    FlightBAL objFlightBal = new FlightBAL();
    #region Global Variables
    ClsBAL objManabusBAL;
    DataSet ObjDataset;
    static bool CheckStatus = false;
    IBitlaAPILayer objBitlaAPILayer;
    IKesineniAPILayer objKesineniAPILayer;
    IAbhiBusAPILayer objAbhiBusAPILayer;
    IKalladaAPILayer objkalladaAPILayer;
    ITicketGooseAPILayer objTicketGooseAPILayer;

    static int i = 0;
    #endregion
    IArzooHotelAPILayer objArzooHotelAPILayer; ClsBAL objBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Hotel - CancelTicket";

        if (!IsPostBack)
        {
           
                Panel pnl = (Panel)this.Master.FindControl("pnl");
                pnl.Visible = false;
           
        }
         

    }
    #region flights
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();


        dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


        String xmlRequestData = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100214</partnerRefId></EticketRequest>";
        DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);

        #region Variables

        string status = string.Empty;
        string remarks = string.Empty;
        string requestedPNR_Id = string.Empty;
        string originDestinationOptionsId = string.Empty;
        string OriDestPNRRequest_id = string.Empty;
        string eticketdto_id = string.Empty;
        string givenName = string.Empty;
        string surName = string.Empty;
        string nameReference = string.Empty;
        string eticketNo = string.Empty;
        string flightUid = string.Empty;
        string passUid = string.Empty;

        #endregion

        DataTable dtRequestedPNR = (DataTable)dsFlightBookStatus.Tables[0];
        if (dtRequestedPNR.Columns.Contains("requestedPNR_Id"))
        {
            transId = dtRequestedPNR.Rows[0]["transid"].ToString();
            status = dtRequestedPNR.Rows[0]["status"].ToString();
            requestedPNR_Id = dtRequestedPNR.Rows[0]["requestedPNR_Id"].ToString();

            DataTable dtOriginDestinationOptions = (DataTable)dsFlightBookStatus.Tables[1];
            if (dtOriginDestinationOptions.Rows.Count > 0)
            {
                DataRow[] rowOriginDestinationOptions = dtOriginDestinationOptions.Select("requestedPNR_Id=" + requestedPNR_Id);
                originDestinationOptionsId = rowOriginDestinationOptions[0]["OriginDestinationoptions_Id"].ToString();
            }

            DataTable dtOriDetPNRRequest = dsFlightBookStatus.Tables[2];
            if (dtOriDetPNRRequest.Rows.Count > 0)
            {
                DataRow[] drOriDetPNRRequest = dtOriDetPNRRequest.Select("OriginDestinationoptions_Id=" + originDestinationOptionsId);
                OriDestPNRRequest_id = drOriDetPNRRequest[0]["OriDestPNRRequest_id"].ToString();

            }

            DataTable dtEticketdo = dsFlightBookStatus.Tables[3];
            if (dtEticketdo.Rows.Count > 0)
            {
                DataRow[] drEticketdo = dtEticketdo.Select("OriDestPNRRequest_id=" + OriDestPNRRequest_id);
                eticketdto_id = drEticketdo[0]["eticketdto_id"].ToString();
            }

            DataTable dtEticket = dsFlightBookStatus.Tables[4];
            if (dtEticket.Rows.Count > 0)
            {
                DataRow[] drEticket = dtEticket.Select("eticketdto_id=" + eticketdto_id);
                givenName = drEticket[0]["givenName"].ToString();
                surName = drEticket[0]["surName"].ToString();
                nameReference = drEticket[0]["nameReference"].ToString();
                eticketNo = drEticket[0]["eticketNo"].ToString();
                flightUid = drEticket[0]["flightUid"].ToString();
                passUid = drEticket[0]["passuid"].ToString();

            }
            String xmlCancelRequest = "<CancelationDetails><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><status>" + status + "</status><remarks>Hi transaction</remarks><eticketdto>";
            xmlCancelRequest = xmlCancelRequest + "<Eticket><givenName>" + givenName + "</givenName><surName>" + surName + "</surName><nameReference>" + nameReference + "</nameReference><eticketno>" + eticketNo + "</eticketno><flightuid>" + flightUid + "</flightuid><passuid>" + passUid + "</passuid></Eticket>";
            xmlCancelRequest = xmlCancelRequest + "</eticketdto></CancelationDetails>";
            DataSet dsCancelResponse = objFlights.CancelTicket(xmlCancelRequest);


            #region SaveCancelResponse

            objFlightBal.TransId = transId;
            objFlightBal.Status = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["status"].ToString();
            objFlightBal.remarks = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["remarks"].ToString();
            objFlightBal.CancelId = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["Canid"].ToString();
            objFlightBal.ReferenceNo = txtBookingReferenceNo.Text.Trim();
            objFlightBal.Reason = txtReason.Text;

            string givenName1 = string.Empty;
            string surName1 = string.Empty;
            string namereference = string.Empty;
            string eticketNo1 = string.Empty;
            string flightUid1 = string.Empty;
            string passUid1 = string.Empty;

            string customerInfo = string.Empty;


            for (int i = 0; i < dsCancelResponse.Tables["Eticket"].Rows.Count; i++)
            {

                givenName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["givenName"].ToString();
                surName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["surName"].ToString();
                namereference = dsCancelResponse.Tables["Eticket"].Rows[i]["nameReference"].ToString();
                eticketNo1 = dsCancelResponse.Tables["Eticket"].Rows[i]["eticketno"].ToString();
                flightUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["flightuid"].ToString();
                passUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["passuid"].ToString();
                if (customerInfo == string.Empty)
                {
                    customerInfo = namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                }
                else
                {
                    customerInfo = customerInfo + ";" + namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                }

            }
            objFlightBal.TicketDetails = customerInfo;
            objFlightBal.CreatedBy = Convert.ToInt32(Session["Userid"].ToString());
            objFlightBal.CancelDomesticFlightBooking(objFlightBal);
            #endregion

        }
        else
        {
            ////Should be removed
            //String xmlCancelRequest = "<CancelationDetails><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><status>" + status + "</status><remarks>Hi transaction</remarks><eticketdto>";
            //xmlCancelRequest = xmlCancelRequest + "<Eticket><givenName>" + givenName + "</givenName><surName>" + surName + "</surName><nameReference>" + nameReference + "</nameReference><eticketno>" + eticketNo + "</eticketno><flightuid>" + flightUid + "</flightuid><passuid>" + passUid + "</passuid></Eticket>";
            //xmlCancelRequest = xmlCancelRequest + "</eticketdto></CancelationDetails>";
            //DataSet dsCancelResponse = objFlights.CancelTicket(xmlCancelRequest);
            //#region SaveCancelResponse

            //objFlightBal.TransId = transId;
            //objFlightBal.Status = dsCancelResponse.Tables[2].Rows[0]["status"].ToString();
            //objFlightBal.remarks = dsCancelResponse.Tables[2].Rows[0]["remarks"].ToString();

            //string givenName1 = string.Empty;
            //string surName1 = string.Empty;
            //string namereference = string.Empty;
            //string eticketNo1 = string.Empty;
            //string flightUid1 = string.Empty;
            //string passUid1 = string.Empty;

            //string customerInfo = string.Empty;

            //for (int i = 0; i < dsCancelResponse.Tables["Eticket"].Rows.Count; i++)
            //{

            //    givenName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["givenName"].ToString();
            //    surName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["surName"].ToString();
            //    namereference = dsCancelResponse.Tables["Eticket"].Rows[i]["nameReference"].ToString();
            //    eticketNo1 = dsCancelResponse.Tables["Eticket"].Rows[i]["eticketno"].ToString();
            //    flightUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["flightuid"].ToString();
            //    passUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["passuid"].ToString();
            //    if (customerInfo == string.Empty)
            //    {
            //        customerInfo = namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
            //    }
            //    else
            //    {
            //        customerInfo = customerInfo + ";" + namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
            //    }

            //}
            //objFlightBal.TicketDetails = customerInfo;
            //objFlightBal.CancelDomesticFlightBooking(objFlightBal);
            //#endregion

            lblStatus1.Text = "Booking is Still Under Process";
        }
    }


    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnCancel.Visible = true;
            btnCancelInt.Visible = false;
        }
        else
        {
            btnCancel.Visible = false;
            btnCancelInt.Visible = true;
        }
    }
    protected void btnCancelInt_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();
        DataSet ds = new DataSet();

        string result = string.Empty;
        string EticketDetailsId = string.Empty;
        string givenName = string.Empty;
        string surName = string.Empty;
        string nameReference = string.Empty;
        string psgrType = string.Empty;
        string originDestinationOptionId = string.Empty;
        string onwardId = string.Empty;
        string FlightSegmentsId = string.Empty;
        string FlightSegmentId = string.Empty;
        string eticketdto_Id = string.Empty;
        string eticketNo = string.Empty;
        string flightUid = string.Empty;
        string passUid = string.Empty;

        dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();

        //String xmlRequest = "xmlRequest=<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
        String xmlRequest = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
        ds = objFlightBal.GetDatasetFromAPI(xmlRequest, "http://live.arzoo.com:9302/BookingStatus");




        //if (ds.Tables["EticketDetails"].Rows[0]["status"].ToString().ToUpper() == "SUCCESS")
        //{
        if (ds.Tables["EticketDetails"].Columns.Contains("EticketDetails_Id"))
        {
            EticketDetailsId = ds.Tables["EticketDetails"].Rows[0]["EticketDetails_Id"].ToString();

            DataTable dtOriginDestinationOption = (DataTable)ds.Tables["OriginDestinationOption"];
            if (dtOriginDestinationOption.Rows.Count > 0)
            {
                DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("eticketDetails_Id=" + EticketDetailsId);
                originDestinationOptionId = rowOriginDestinationOption[0]["originDestinationOption_Id"].ToString();
            }
            DataTable dtOnward = (DataTable)ds.Tables["onward"];
            if (dtOnward.Rows.Count > 0)
            {
                DataRow[] rowOnward = dtOnward.Select("originDestinationOption_Id=" + originDestinationOptionId);
                onwardId = rowOnward[0]["Onward_Id"].ToString();
            }
            DataTable dtFlightSegments = (DataTable)ds.Tables["FlightSegments"];
            if (dtFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFlightSegments = dtFlightSegments.Select("Onward_Id=" + onwardId);
                FlightSegmentsId = rowFlightSegments[0]["FlightSegments_Id"].ToString();
            }

            DataTable dtFlightSegment = (DataTable)ds.Tables["FlightSegment"];
            if (dtFlightSegment.Rows.Count > 0)
            {
                DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsId);
                FlightSegmentId = rowFlightSegment[0]["FlightSegment_Id"].ToString();
            }
            DataTable dtEticketDto = (DataTable)ds.Tables["Eticketdto"];
            if (dtEticketDto.Rows.Count > 0)
            {
                DataRow[] rowEticketdto = dtEticketDto.Select("FlightSegment_Id=" + FlightSegmentId);
                eticketdto_Id = rowEticketdto[0]["eticketdto_id"].ToString();
            }

            String xmlCancelReq = "<CanIntRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><Transid>" + ds.Tables["EticketDetails"].Rows[0]["transid"].ToString() + "</Transid><Remarks>Example1</Remarks><eticketdto>";

            DataTable dtEticket = (DataTable)ds.Tables["Eticket"];
            if (dtEticket.Rows.Count > 0)
            {
                DataRow[] rowEticket = dtEticket.Select("eticketdto_id=" + eticketdto_Id);
                for (int i = 0; i < rowEticket.Length; i++)
                {

                    givenName = rowEticket[i]["givenName"].ToString();
                    surName = rowEticket[i]["surName"].ToString();
                    nameReference = rowEticket[i]["nameReference"].ToString();
                    eticketNo = rowEticket[i]["EticketNo"].ToString();
                    flightUid = rowEticket[i]["FlightUid"].ToString();
                    passUid = rowEticket[i]["passuid"].ToString();

                    xmlCancelReq = xmlCancelReq + "<Eticket><GivenName>" + givenName + "</GivenName><SurName>" + surName + "</SurName><NameReference>" + nameReference + "</NameReference><Eticketno>" + eticketNo + "</Eticketno><Flightuid>" + flightUid + "</Flightuid><Passuid>" + passUid + "</Passuid></Eticket>";
                }
            }
            xmlCancelReq = xmlCancelReq + "</eticketdto></CanIntRequest>";

            DataSet dsCancelResponse = new DataSet();
            dsCancelResponse = objFlightBal.GetDatasetFromAPI(xmlCancelReq, "http://live.arzoo.com:9302/Cancellation");
            if (dsCancelResponse.Tables[0].Columns.Contains("error"))
            {
                lblStatus1.Text = dsCancelResponse.Tables[0].Rows[0]["error"].ToString();
            }
            else
            {
                string status = dsCancelResponse.Tables[0].Rows[0]["status"].ToString();
                lblStatus1.Text = "Your ticket is " + status;
                objFlightBal.Status = status;
                objFlightBal.TransId = transId;
                objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;
                bool res = objFlightBal.UpdateInternationalFlightBookingStatus(objFlightBal);

            }

        }
        else
        {
            lblStatus1.Text = "Your ticket is under booking process";
        }
    }
    #endregion

    #region Buses

    protected DataSet CheckTicketID()
    {
        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.emailId = txtEmailID.Text;
            objManabusBAL.manabusRefNo = txtMBRefNo.Text;
            ObjDataset = (DataSet)objManabusBAL.GetTicketIdByEmail();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {

                        CheckStatus = true;
                        return ObjDataset;
                    }
                    else
                    {
                        CheckStatus = false;
                        ObjDataset = null;
                        return ObjDataset;
                    }
                }
                else
                {
                    CheckStatus = false;
                    ObjDataset = null;
                    return ObjDataset;
                }
            }
            else
            {
                CheckStatus = false;
                ObjDataset = null;
                return ObjDataset;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected String GeneratePromocode()
    {

        int minPassSize = 9;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$&".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        return "Ca" + stringBuilder.ToString();
    }

    protected void AddCancellation(int bookingId, int tentativeId, string seatNos, string emailId, string refundAmt, string CancelCharges)
    {
        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.bookingId = Convert.ToInt32(bookingId);
            objManabusBAL.tentativeId = Convert.ToInt32(tentativeId);
            objManabusBAL.cancelSeats = seatNos;
            objManabusBAL.emailId = emailId;
            objManabusBAL.refundAmount = refundAmt;
            objManabusBAL.cancellationCharges = CancelCharges;
            lblCode.Text = "Can" + GeneratePromocode();
            objManabusBAL.couponNo = lblCode.Text.ToString();
            ObjDataset = (DataSet)objManabusBAL.AddCancellation();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows[0]["CouponNo"].ToString() == "Already  Exists")
                        {

                            AddCancellation(bookingId, tentativeId, seatNos, emailId, refundAmt, CancelCharges);

                        }
                        else if (ObjDataset.Tables[0].Rows[0]["CouponNo"].ToString() == "Success")
                        {
                            lblMsg.Text = "Ticket cancelled successfully.Cash Coupon Code has been sent to your Email Id Please check";
                            lblMsg.Visible = true;
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            txtEmailID.Text = txtMBRefNo.Text = "";
                            if (ViewState["APIName"] != null)
                            {
                                if (ViewState["APIName"].ToString() == "Bitla")
                                {
                                    gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                                    txtEmailID.Text = txtMBRefNo.Text = "";
                                }
                                else if (ViewState["APIName"].ToString() == "Kesineni")
                                {
                                    gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                                    txtEmailID.Text = txtMBRefNo.Text = "";
                                }
                            }

                            string body = "HI " + Session["NameMail"].ToString() + ",<br/><br/>" + "Ticket has been cancelled successfully. Your Cash coupon code is " + lblCode.Text.ToString() + "<br/>Note: This Coupon will expire with in 6 months." + "<br/><br/>Thanks & Regards,<br/>LoveJourney Team.";
                            Mailsender.SendEmail(Session["EmailIdMail"].ToString(), "", "", "LoveJourney Cash Coupon Code", body);
                            lblMsg1.Text = "Ticket cancelled successfully. Cash Coupon Code has been sent to your Email Id. Please check.";
                        }
                        else
                        {
                            lblMsg1.Text = "Failed to insert..Try Again";
                        }
                    }
                    else
                    {
                        lblMsg1.Text = "Failed to insert..Try Again";
                    }
                }
                else
                {
                    lblMsg1.Text = "Failed to insert..Try Again";
                }
            }
            else
            {
                lblMsg1.Text = "Failed to insert..Try Again";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void UpdateCancelltion(int CancellationId, string CancelledSeats, string refundAmount, string cancellationCharges)
    {
        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.ID = CancellationId;
            objManabusBAL.cancelSeats = CancelledSeats;
            objManabusBAL.refundAmount = refundAmount;
            objManabusBAL.cancellationCharges = cancellationCharges;
            if (objManabusBAL.UpdateCancellations())
            {
                lblMsg.Text = "Ticket cancelled successfully. Cash Coupon Code has been sent to your Email Id Please check";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtEmailID.Text = txtMBRefNo.Text = "";
                if (ViewState["APIName"] != null)
                {
                    if (ViewState["APIName"].ToString() == "Bitla")
                    {
                        gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                        txtEmailID.Text = txtMBRefNo.Text = "";
                    }
                    if (ViewState["APIName"].ToString() == "Kesineni")
                    {
                        gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                        txtEmailID.Text = txtMBRefNo.Text = "";
                    }
                }
            }
            else
            {
                lblMsg.Text = "Failed to insert..Try Again";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsticketdetails = CheckTicketID();
            if (CheckStatus)
            {
                if (dsticketdetails != null)
                {
                    int BookingId = Convert.ToInt32(dsticketdetails.Tables[0].Rows[0]["BookingId"].ToString());
                    int tentativeId = Convert.ToInt32(dsticketdetails.Tables[0].Rows[0]["TentativeId"].ToString());
                    string EmailId = dsticketdetails.Tables[0].Rows[0]["EmailId"].ToString();
                    string Name = dsticketdetails.Tables[0].Rows[0]["FullName"].ToString();
                    string seatnumbers = dsticketdetails.Tables[0].Rows[0]["SeatNos"].ToString();
                    string totalfareabhi = dsticketdetails.Tables[0].Rows[0]["TotalFare"].ToString();
                    string ticketNumberBitla = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();

                    Session["NameMail"] = Name;
                    Session["EmailIdMail"] = EmailId;

                    #region Kesineni
                    if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "Kesineni")
                    {
                        #region kesineni total Cancelltion

                        string pnrNumberKesineni = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString().Trim().ToString();
                        string firstNameKesineni = dsticketdetails.Tables[0].Rows[0]["FullName"].ToString();
                        string lastNameKesineni = dsticketdetails.Tables[0].Rows[0]["FullName"].ToString();
                        DateTime DOJ = Convert.ToDateTime(dsticketdetails.Tables[0].Rows[0]["DateOfJourney"].ToString());
                        string dateOfJourneyKesineni = DOJ.ToString("MM/dd/yyyy");
                        string seatNumberListKesineni = dsticketdetails.Tables[0].Rows[0]["SeatNos"].ToString();
                        DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
                            dateOfJourneyKesineni, seatNumberListKesineni);

                        if (dsKesineni != null)
                        {
                            if (dsKesineni.Tables[0].Columns.Count > 5)
                            {
                                gvCancelDetails.Visible = true;
                                gvAlreadyCancelDetails.Visible = false;
                                gvCancelDetails.DataSource = dsKesineni;
                                gvCancelDetails.DataBind();
                            }
                            else
                            {
                                gvCancelDetails.Visible = false;
                                gvAlreadyCancelDetails.Visible = true;
                                gvAlreadyCancelDetails.DataSource = dsKesineni;
                                gvAlreadyCancelDetails.DataBind();
                            }

                        }
                        #endregion
                        ViewState["APIName"] = "Kesineni";
                        rbtnlstCancelType.Visible = gvPartialCancellation.Visible = btnConfrmCancel.Visible = true;
                        gvPartialCancellation.DataSource = dsticketdetails.Tables[1];
                        gvPartialCancellation.DataBind();
                        ViewState["dsticketdetails"] = dsticketdetails.Tables[0];
                    }

                    #endregion

                    #region AbhiBus
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "Abhibus")
                    {
                        string ticketNumberAbhiBus = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();//"OHYD19615";
                        DataTable dtAbhiBus = objAbhiBusAPILayer.CancellationConfirmation(ticketNumberAbhiBus);
                        if (dtAbhiBus != null)
                        {
                            if (dtAbhiBus.Rows.Count > 0)
                            {
                                if (dtAbhiBus.Rows[0]["status"].ToString() == "Success")
                                {
                                    string totalRefundAmount = dtAbhiBus.Rows[0]["total_refund_amount"].ToString();
                                    string canpercentage = dtAbhiBus.Rows[0]["cancellation_parcentage"].ToString();
                                    string[] canindec = canpercentage.Split('%');
                                    double cancelcharges = Convert.ToDouble(totalfareabhi) * (Convert.ToDouble(canindec[0].ToString()) / 100);

                                    DataTable dtAbhiBus1 = objAbhiBusAPILayer.TicketCancellation(ticketNumberAbhiBus);
                                    if (dtAbhiBus1.Rows.Count > 0 && dtAbhiBus1.Columns.Count > 1)
                                    {
                                        AddCancellation(BookingId, tentativeId, seatnumbers, EmailId, Convert.ToString(Convert.ToDouble(totalfareabhi) - cancelcharges), Convert.ToString(cancelcharges));


                                    }


                                    //GridView1.DataSource = dtAbhiBus;
                                    //GridView1.DataBind();
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    #endregion

                    #region Bitla
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "Bitla")
                    {

                        objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                        objBitlaAPILayer.SeatNumbers = seatnumbers;
                        DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();
                        if (dsBitla != null)
                        {

                            if (dsBitla.Tables[0].Columns.Count > 3)
                            {
                                gvCancelDetails.Visible = true;
                                gvAlreadyCancelDetails.Visible = false;
                                gvCancelDetails.DataSource = dsBitla;
                                gvCancelDetails.DataBind();
                            }
                            else
                            {
                                gvCancelDetails.Visible = false;
                                gvAlreadyCancelDetails.Visible = true;
                                gvAlreadyCancelDetails.DataSource = dsBitla;
                                gvAlreadyCancelDetails.DataBind();
                            }


                        }


                        ViewState["APIName"] = "Bitla";
                        rbtnlstCancelType.Visible = gvPartialCancellation.Visible = btnConfrmCancel.Visible = true;
                        gvPartialCancellation.DataSource = dsticketdetails.Tables[1];
                        gvPartialCancellation.DataBind();
                        ViewState["dsticketdetails"] = dsticketdetails.Tables[0];

                        //CancelBitlaTickets(dsticketdetails);





                    }
                    #endregion

                    #region Kallada
                    if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "Kallada")
                    {

                        string ticketNumberkallada = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();//"OHYD19615";
                        DataTable dtkallada = objkalladaAPILayer.CancellationConfirmation(ticketNumberkallada);
                        if (dtkallada != null)
                        {
                            if (dtkallada.Rows.Count > 0)
                            {
                                if (dtkallada.Rows[0]["status"].ToString() == "Success")
                                {
                                    string totalRefundAmount = dtkallada.Rows[0]["total_refund_amount"].ToString();
                                    string canpercentage = dtkallada.Rows[0]["cancellation_parcentage"].ToString();
                                    string[] canindec = canpercentage.Split('%');
                                    double cancelcharges = Convert.ToDouble(totalfareabhi) * (Convert.ToDouble(canindec[0].ToString()) / 100);

                                    DataTable dtKallada1 = objkalladaAPILayer.TicketCancellation(ticketNumberkallada);
                                    if (dtKallada1.Rows.Count > 0 && dtKallada1.Columns.Count > 1)
                                    {
                                        AddCancellation(BookingId, tentativeId, seatnumbers, EmailId,
                                            Convert.ToString(Convert.ToDouble(totalfareabhi) - cancelcharges), Convert.ToString(cancelcharges));
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }


                    }
                    #endregion

                    #region TicketGoose
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "TicketGoose")
                    {
                        ViewState["APIName"] = "TicketGoose";
                        string ticketNumber = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();
                        string[] seatNos = dsticketdetails.Tables[0].Rows[0]["SeatNos"].ToString().Split(',');
                        DataTable dt = objTicketGooseAPILayer.CancelTicket(ticketNumber, seatNos);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["Status"].ToString() == "Success")
                                {
                                    DataTable dtt = objTicketGooseAPILayer.ConfirmTicketCancellation(ticketNumber, seatNos);
                                    if (dtt != null)
                                    {
                                        if (dtt.Rows.Count > 0)
                                        {
                                            if (dtt.Rows[0]["Status"].ToString() == "Success")
                                            {
                                                string refAmount = dtt.Rows[0]["refundAmount"].ToString();
                                                AddCancellation(BookingId, tentativeId, seatnumbers, EmailId,
                                               refAmount, Convert.ToString(Convert.ToDouble(totalfareabhi) - Convert.ToDouble(refAmount)));
                                            }
                                            else { lblMsg.Text = "Ticket cancelled failed. Try Again"; }

                                            txtEmailID.Text = txtMBRefNo.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    lblMsg.Text = "Invalid Ref No";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "Invalid Ref No";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
            foreach (GridViewRow row in gvPartialCancellation.Rows)
            {
                CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");

                chkbChild.Checked = chkbHeader.Checked;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected string GenerateManabusRefNo()
    {
        try
        {
            lblMsg.Text = "";
            int minPassSize = 4;
            int maxPassSize = 6;
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
            return "CC" + stringBuilder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected bool AddCashCoupon(string Amount, string couponCode)
    {
        try
        {
            objManabusBAL = new ClsBAL();

            objManabusBAL.couponNo = Convert.ToString(couponCode);
            objManabusBAL.emailId = Convert.ToString(txtEmailID.Text);
            objManabusBAL.Amount = Convert.ToString(Amount);
            objManabusBAL.createdBy = null;

            if (objManabusBAL.AddCashCoupon(ref lblMsg))
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

    protected void CancelBitlaTickets(string CancelType, string SeatNos)
    {
        try
        {
            if (ViewState["dsticketdetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dsticketdetails"];
                int BookingId = Convert.ToInt32(dt.Rows[0]["BookingId"].ToString());
                int tentativeId = Convert.ToInt32(dt.Rows[0]["TentativeId"].ToString());
                string EmailId = dt.Rows[0]["EmailId"].ToString();
                string Name = dt.Rows[0]["FullName"].ToString();
                string ticketNumberBitla = dt.Rows[0]["PNRNumber"].ToString();
                string seatNumbersBitla = dt.Rows[0]["SeatNos"].ToString();
                string cancelllationId = dt.Rows[0]["CancellationId"].ToString();
                string CancelledSaets = dt.Rows[0]["CancelledSeats"].ToString();

                if (CancelType == "Total Cancellation")
                {
                    objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    objBitlaAPILayer.SeatNumbers = SeatNos;
                    DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();

                    #region Cancellation
                    if (dsBitla != null)
                    {
                        if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                        {
                            string refundAmount = dsBitla.Tables[0].Rows[0]["refund_amount"].ToString();
                            string cancellationCharges = dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString();
                            if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                            {
                                objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                                DataSet dsBitla1 = objBitlaAPILayer.CancelTicket();

                                if (dsBitla1 != null)
                                {
                                    if (dsBitla1.Tables.Count > 0)
                                    {
                                        if (dsBitla1.Tables[0].Columns.Count > 1 && dsBitla1.Tables[0].Rows.Count > 0)
                                        {
                                            AddCancellation(BookingId, tentativeId, SeatNos, EmailId, refundAmount, cancellationCharges);

                                        }
                                        else
                                        {
                                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                                            lblMsg.ForeColor = System.Drawing.Color.Red;
                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }

                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }
                        }
                        else
                        {
                            lblMsg.Text = "Already cancelled ";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    #endregion

                }
                else if (CancelType == "Partial Cancellation")
                {
                    objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    objBitlaAPILayer.SeatNumbers = SeatNos;
                    DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();
                    #region PartialCancellation
                    if (dsBitla != null)
                    {
                        if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                        {
                            string refundAmount = dsBitla.Tables[0].Rows[0]["refund_amount"].ToString();
                            string cancellationCharges = dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString();
                            if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                            {
                                objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                                DataSet dsBitla1 = objBitlaAPILayer.CancelPartialTicket();
                                if (dsBitla1 != null)
                                {
                                    if (dsBitla1.Tables.Count > 0)
                                    {
                                        if (dsBitla1.Tables[0].Columns.Count > 1 && dsBitla1.Tables[0].Rows.Count > 0)
                                        {


                                            if (cancelllationId != "" && CancelledSaets != "")
                                            {
                                                UpdateCancelltion(Convert.ToInt32(cancelllationId), SeatNos, refundAmount, cancellationCharges);


                                            }
                                            else if (cancelllationId == "" && CancelledSaets == "")
                                            {
                                                AddCancellation(BookingId, tentativeId, SeatNos, EmailId, refundAmount, cancellationCharges);


                                            }

                                        }
                                        else
                                        {
                                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                                            lblMsg.ForeColor = System.Drawing.Color.Red;
                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }

                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Already cancelled ";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    #endregion
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }



    }

    protected void CancelKesineniTickets(string CancelType, string SeatNos)
    {
        try
        {
            if (ViewState["dsticketdetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dsticketdetails"];
                int BookingId = Convert.ToInt32(dt.Rows[0]["BookingId"].ToString());
                int tentativeId = Convert.ToInt32(dt.Rows[0]["TentativeId"].ToString());
                string EmailId = dt.Rows[0]["EmailId"].ToString();
                string cancelllationId = dt.Rows[0]["CancellationId"].ToString();
                string CancelledSaets = dt.Rows[0]["CancelledSeats"].ToString();
                string pnrNumberKesineni = dt.Rows[0]["PNRNumber"].ToString().Trim().ToString();
                string firstNameKesineni = dt.Rows[0]["FullName"].ToString();
                string lastNameKesineni = dt.Rows[0]["FullName"].ToString();
                DateTime DOJ = Convert.ToDateTime(dt.Rows[0]["DateOfJourney"].ToString());
                string dateOfJourneyKesineni = DOJ.ToString("MM/dd/yyyy");
                string seatNumberListKesineni = dt.Rows[0]["SeatNos"].ToString();

                if (CancelType == "Total Cancellation")
                {
                    DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
             dateOfJourneyKesineni, SeatNos);

                    #region total Cancellation
                    if (dsKesineni != null)
                    {
                        if (dsKesineni.Tables[0].Rows.Count > 0 && dsKesineni.Tables[0].Columns.Count > 2)
                        {
                            double grandTotalRefund = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["GrandTotalRefunded"].ToString());
                            double cancellationCharges = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["CancellationCharges"].ToString());

                            DataSet dsKesineni1 = objKesineniAPILayer.ConfirmCancelTickets(pnrNumberKesineni, firstNameKesineni,
                             lastNameKesineni, dateOfJourneyKesineni, SeatNos);

                            if (dsKesineni1 != null)
                            {
                                if (dsKesineni1.Tables.Count > 0)
                                {
                                    if (dsKesineni1.Tables[0].Columns.Count > 1 && dsKesineni1.Tables[0].Rows.Count > 0)
                                    {
                                        AddCancellation(BookingId, tentativeId, SeatNos, EmailId, Convert.ToString(grandTotalRefund), Convert.ToString(cancellationCharges));




                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }

                        }

                    }
                    #endregion

                }
                else if (CancelType == "Partial Cancellation")
                {
                    DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
              dateOfJourneyKesineni, SeatNos);
                    #region PartialCancellation
                    if (dsKesineni != null)
                    {
                        if (dsKesineni.Tables[0].Rows.Count > 0 && dsKesineni.Tables[0].Columns.Count > 2)
                        {
                            double grandTotalRefundp = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["GrandTotalRefunded"].ToString());
                            double cancellationChargesp = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["CancellationCharges"].ToString());

                            DataSet dsKesineni1 = objKesineniAPILayer.ConfirmCancelTickets(pnrNumberKesineni, firstNameKesineni,
                             lastNameKesineni, dateOfJourneyKesineni, SeatNos);
                            if (dsKesineni1 != null)
                            {
                                if (dsKesineni1.Tables.Count > 0)
                                {
                                    if (dsKesineni1.Tables[0].Columns.Count > 1 && dsKesineni1.Tables[0].Rows.Count > 0)
                                    {


                                        if (cancelllationId != "" && CancelledSaets != "")
                                        {
                                            UpdateCancelltion(Convert.ToInt32(cancelllationId), SeatNos, Convert.ToString(grandTotalRefundp), Convert.ToString(cancellationChargesp));




                                        }
                                        else if (cancelllationId == "" && CancelledSaets == "")
                                        {
                                            AddCancellation(BookingId, tentativeId, SeatNos, EmailId, Convert.ToString(grandTotalRefundp), Convert.ToString(cancellationChargesp));



                                        }

                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }

                    }
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }




    }

    protected void btnConfrmCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string Ids = string.Empty;
            lblMsg.Text = "";
            int i = 0;
            if (ViewState["APIName"] != null)
            {

                if (ViewState["APIName"].ToString() == "Bitla")
                {
                    #region Bitla
                    CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                    foreach (GridViewRow row in gvPartialCancellation.Rows)
                    {
                        CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");
                        if (chkbChild.Checked)
                        {
                            Label lblSeatNo = (Label)row.FindControl("lblSeatNo");
                            Label lblStatus = (Label)row.FindControl("lblStatus");
                            if (lblStatus.Text == "NotCancelled")
                            {
                                if (Ids.ToString() == "")
                                {
                                    Ids = Ids + lblSeatNo.Text.ToString();
                                }
                                else
                                {
                                    Ids = Ids + "," + lblSeatNo.Text.ToString();
                                }
                            }


                            i++;
                        }
                    }
                    if (rbtnlstCancelType.SelectedItem.Value == "0")
                    {

                        if (i > 0)
                        {

                            CancelBitlaTickets("Total Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    else if (rbtnlstCancelType.SelectedItem.Value == "1")
                    {
                        if (i > 0)
                        {

                            CancelBitlaTickets("Partial Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    #endregion
                }

                else if (ViewState["APIName"].ToString() == "Kesineni")
                {
                    #region Kesineni


                    CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                    foreach (GridViewRow row in gvPartialCancellation.Rows)
                    {
                        CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");
                        if (chkbChild.Checked)
                        {
                            Label lblSeatNo = (Label)row.FindControl("lblSeatNo");
                            Label lblStatus = (Label)row.FindControl("lblStatus");
                            if (lblStatus.Text == "NotCancelled")
                            {
                                if (Ids.ToString() == "")
                                {
                                    Ids = Ids + lblSeatNo.Text.ToString();
                                }
                                else
                                {
                                    Ids = Ids + "," + lblSeatNo.Text.ToString();
                                }
                            }


                            i++;
                        }
                    }
                    if (rbtnlstCancelType.SelectedItem.Value == "0")
                    {

                        if (i > 0)
                        {

                            CancelKesineniTickets("Total Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    else if (rbtnlstCancelType.SelectedItem.Value == "1")
                    {
                        if (i > 0)
                        {

                            CancelKesineniTickets("Partial Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    #endregion
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void rbtnlstCancelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtnlstCancelType.SelectedItem.Value == "0")
            {
                CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                chkbHeader.Checked = true;
                foreach (GridViewRow row in gvPartialCancellation.Rows)
                {
                    CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");

                    chkbChild.Checked = chkbHeader.Checked;
                    chkbChild.Enabled = false;
                    chkbHeader.Enabled = false;
                }
            }
            else if (rbtnlstCancelType.SelectedItem.Value == "1")
            {
                CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                chkbHeader.Checked = false;
                foreach (GridViewRow row in gvPartialCancellation.Rows)
                {
                    CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");

                    chkbChild.Checked = chkbHeader.Checked;
                    chkbChild.Enabled = true;
                    chkbHeader.Enabled = true;

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void gvPartialCancellation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                CheckBox chkChild = (CheckBox)e.Row.FindControl("chkChild");
                if (lblStatus.Text == "Cancelled")
                {
                    chkChild.Visible = false;
                }
                else if (lblStatus.Text == "NotCancelled")
                {
                    chkChild.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    #endregion

    #region Hotels
    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string bookingRef = "";
            string emailId = "";
            string lastName = "";
            string webService = "";
            string startDate = "";
            string endDate = "";

            HotelBAL obj = new HotelBAL();
            obj.ReferenceNo = txtBookingRefNo.Text.ToString();
            DataSet ds = obj.GetHotelProvisional();

            if (ds == null)
            { lblMsg.Text = "Invalid reference number."; return; }
            if (ds.Tables.Count == 0)
            { lblMsg.Text = "Invalid reference number."; return; }
            if (ds.Tables[0].Rows.Count == 0)
            { lblMsg.Text = "Invalid reference number."; return; }

            DataRow dr = ds.Tables[0].Rows[0];

            emailId = dr["EmailId"].ToString();
            lastName = dr["LastName"].ToString();
            bookingRef = dr["BookingRefNo"].ToString();
            webService = dr["WebService"].ToString();
            startDate = ConvertDate(dr["CheckIn"].ToString());
            endDate = ConvertDate(dr["CheckOut"].ToString());
            string status = dr["Status"].ToString();
            double hotelTotalFare = Convert.ToDouble(dr["HotelTotalFare"].ToString());

            if (status == "Cancelled") { lblMsg.Text = "Already this ticket has been cancelled."; return; }
            if (emailId != txtHotelEmailId.Text.Trim().ToString()) { lblMsg.Text = "Invalid email id."; return; }

            DataSet dsHotelCancellation = objArzooHotelAPILayer.HotelCancellation(emailId, lastName, bookingRef, webService, startDate, endDate);

            if (!dsHotelCancellation.Tables.Contains("HotelCancellation"))
            { lblMsg.Text = "Failed to cancel the ticket."; return; }

            DataTable dtCancellation = dsHotelCancellation.Tables["HotelCancellation"];
            if (dtCancellation.Rows.Count > 0)
            {
                DataRow item = dtCancellation.Rows[0];
                string cancellationId = item["cancellationId"].ToString();
                string refundTotalAmount = item["refundTotalAmount"].ToString();
                string cancellationAmount = item["cancellationAmount"].ToString();
                string success = item["success"].ToString();
                string error = item["error"].ToString();
                if (success != "" && cancellationId != "")
                {
                    lblMsg.Text = "Status: " + "Ticket has been cancelled successfully.";
                    string provisionalId = dr["ProvisionalId"].ToString();
                    string bookingId = dr["BookingId"].ToString();

                    double cancellationCharges = hotelTotalFare - Convert.ToDouble(refundTotalAmount);

                    InsertCancellaion(provisionalId, bookingId, Convert.ToDouble(refundTotalAmount),
                        cancellationCharges, Convert.ToInt32(Session["UserID"].ToString()), cancellationId);

                    objBAL = new ClsBAL();
                    objBAL.AdjustAgentBalance(txtBookingRefNo.Text.Trim().ToString(),
                        Convert.ToDouble(refundTotalAmount), Convert.ToDouble(cancellationAmount),
                        Convert.ToInt32(Session["UserID"].ToString()));

                    DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                    string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                    Label lbl = (Label)this.Master.FindControl("lblBalance");
                    lbl.Text = balance;
                    Session["Balance"] = balance;
                    txtHotelEmailId.Text = txtBookingRefNo.Text = "";
                }
                else if (error != "") { lblMsg.Text = error.ToString(); }
                else { lblMsg.Text = "Failed to cancel the ticket."; }
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    public string InsertCancellaion(string provisionalId, string bookingId, double refundAmount, double cancellationCharges, int createdBy, string hotelCancellationId)
    {
        try
        {
            string strReturn = "";
            HotelBAL obj = new HotelBAL();
            obj.ProvisionalId = Convert.ToInt32(provisionalId);
            obj.BookingId = Convert.ToInt32(bookingId);
            obj.RefundAmount = refundAmount;
            obj.CancellationCharges = cancellationCharges;
            obj.CreatedBy = createdBy;
            obj.HotelCancellationId = hotelCancellationId;

            bool b = obj.AddHotelCancellation();
            if (b) { strReturn = "Success"; } else { strReturn = ""; }
            return strReturn;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    #endregion
    //protected void btnprint_Click(object sender, EventArgs e)
    //{
    //    if (ddlType.SelectedValue != "--PleaseSelect--")
    //    {
    //        if (ddlType.SelectedValue == "DomesticFlights")
    //        {
    //            pnldomesticflights.Visible = true;
    //            pnlbuses1.Visible = false;
    //            pnlhotels.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Hotels")
    //        {
    //            pnlbuses1.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlhotels.Visible = true;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Buses")
    //        {
    //            pnlhotels.Visible = false;
    //            pnlbuses1.Visible = true;
    //            pnldomesticflights.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Recharge")
    //        {
    //            pnlhotels.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlbuses1.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "IFFlights")
    //        {
    //            pnlhotels.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlbuses1.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        lblMainMSg.Text = "Please select Flight Type";
    //    }
    //}
    protected void linkCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoard.aspx");
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue != "--PleaseSelect--")
        {
            if (ddlType.SelectedValue == "DomesticFlights")
            {
                pnldomesticflights.Visible = true;
                pnlbuses1.Visible = false;
                pnlhotels.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Hotels")
            {
                pnlbuses1.Visible = false;
                pnldomesticflights.Visible = false;
                pnlhotels.Visible = true;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Buses")
            {
                pnlhotels.Visible = false;
                pnlbuses1.Visible = true;
                pnldomesticflights.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Recharge")
            {
                pnlhotels.Visible = false;
                pnldomesticflights.Visible = false;
                pnlbuses1.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "IFFlights")
            {
                pnlhotels.Visible = false;
                pnldomesticflights.Visible = false;
                pnlbuses1.Visible = false;
                lblMsg.Text = "";
            }
        }
        else
        {
            lblMainMSg.Text = "Please select Flight Type";
        }
    }
}