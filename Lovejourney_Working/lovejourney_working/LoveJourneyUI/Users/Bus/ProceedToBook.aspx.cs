using System;
using System.Data;
using BusAPILayer;
using BAL;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;

public partial class Users_ProceedToBook : System.Web.UI.Page
{
    ClsBAL objBAL;
    DataSet objDataSet;
    DataSet objDataSetBook;
    IBitlaAPILayer objBitlaAPILayer;
    IKesineniAPILayer objKesineniAPILayer;
    IAbhiBusAPILayer objAbhiBusAPILayer;
    IKalladaAPILayer objKalladaAPILayer;
    KesineniDetails kesineniDetails;
    AbhiBusDetails abhiBusDetails;
    KalladaAPILayer kalladaDetails;
    BitlaDetails bitlaDetails;
    KABCommon objCommon;
    ITicketGooseAPILayer objTicketGooseAPILayer;
    bool res = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        objBitlaAPILayer = BitlaFactoryManager.GetBitlaAPILayerObject();
        objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
        objBitlaAPILayer.URL = BitlaConstants.URL;
        objKesineniAPILayer = KesineniFactoryManager.GetKesineniAPILayerObject();
        objKesineniAPILayer.LoginId = KesineniConstants.LoginId;
        objKesineniAPILayer.Password = KesineniConstants.Password;
        objAbhiBusAPILayer = AbhiBusFactoryManager.GetAbhiBusAPILayerObject();

        kesineniDetails = new KesineniDetails();
        kesineniDetails.LoginId = KesineniConstants.LoginId;
        kesineniDetails.PassWord = KesineniConstants.Password;

        abhiBusDetails = new AbhiBusDetails();
        abhiBusDetails.Url = AbhiBusConstants.URL;

        objKalladaAPILayer = KalladaFactoryManager.GetKalladaAPILayerObject();

        objTicketGooseAPILayer = TicketGooseFactoryManager.GetTicketGooseAPILayerObject();
        objTicketGooseAPILayer.UserId = TicketGooseConstants.USERID;
        objTicketGooseAPILayer.Password = TicketGooseConstants.PASSWORD;

        bitlaDetails = new BitlaDetails();
        bitlaDetails.ApiKey = BitlaConstants.API_KEY;
        bitlaDetails.Url = BitlaConstants.URL;

        objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

        if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - Bus - ProceedToBook";
            if (
                Session["ddlSources"] != null && Session["ddlDestinations"] != null && Session["DOJ"] != null
                   && Session["From"] != null && Session["To"] != null
                   && Session["OneWayOrRoundTrip"] != null && Session["ddlSourcesReturn"] != null
                   && Session["ddlDestinationsReturn"] != null && Session["DOJReturn"] != null
                   && Session["FromReturn"] != null && Session["ToReturn"] != null
                )
            {
                MVIEW.ActiveViewIndex = 0;
                ViewState["ddlSources"] = Session["ddlSources"].ToString();
                ViewState["ddlDestinations"] = Session["ddlDestinations"].ToString();
                ViewState["DOJ"] = Session["DOJ"].ToString();
                ViewState["From"] = Session["From"].ToString();
                ViewState["To"] = Session["To"].ToString();

                ViewState["ddlSourcesReturn"] = Session["ddlSourcesReturn"].ToString();
                ViewState["ddlDestinationsReturn"] = Session["ddlDestinationsReturn"].ToString();
                ViewState["DOJReturn"] = Session["DOJReturn"].ToString();
                ViewState["FromReturn"] = Session["FromReturn"].ToString();
                ViewState["ToReturn"] = Session["ToReturn"].ToString();

                ViewState["OneWayOrRoundTrip"] = Session["OneWayOrRoundTrip"].ToString();

                lblMsg.Text = "";
                DataTable dt = (DataTable)Session["dtTicketInfo"];
                pnlOnwardTicketDetails.Visible = true;
                pnlreturnticketdetails.Visible = false;
                lblRouteValue.Text = dt.Rows[0]["Route"].ToString();
                lblJourneyDate.Text = dt.Rows[0]["JourneyDate"].ToString();
                lblBusOperator.Text = dt.Rows[0]["Travels"].ToString();
                lblBusType.Text = dt.Rows[0]["BusType"].ToString();
                lblSeatNos.Text = dt.Rows[0]["SeatNos"].ToString();
                lblFare.Text = dt.Rows[0]["TotalFare"].ToString();
                lblTotalAmountPayable.Text = dt.Rows[0]["TotalFare"].ToString();
                lblBoardingPoint.Text = dt.Rows[0]["BoardingPoint"].ToString();
                ViewState["CashCouponcode"] = null;
                ViewState["Promocode"] = null;
                DataTable dt1 = null;
                DataTable dtseats = new DataTable();
                dtseats.Columns.Add("SeatNos");
                char[] separator = { ',' };
                string[] seatnos = lblSeatNos.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in seatnos)
                {
                    DataRow dr = dtseats.NewRow();
                    dr["SeatNos"] = item;
                    dtseats.Rows.Add(dr);
                }

                if (dtseats != null)
                {
                    ddlPrimaryPassenger.DataSource = dtseats;
                    ddlPrimaryPassenger.DataTextField = "SeatNos";
                    ddlPrimaryPassenger.DataBind();
                    rptPassengersonward.DataSource = dtseats;
                    rptPassengersonward.DataBind();
                }
                int NoOFSeats = seatnos.Length;
                if (NoOFSeats == 1)
                {
                    pnlPriamryPassenger.Visible = false;
                }
                if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                {
                    pnlOnwardTicketDetails.Visible = true;
                    pnlreturnticketdetails.Visible = true;
                    dt1 = (DataTable)Session["dtTicketInfoReturn"];
                    lblRoutereturn.Text = dt1.Rows[0]["Route"].ToString();
                    lblJourneydatereturn.Text = dt1.Rows[0]["JourneyDate"].ToString();

                    if (Convert.ToDateTime(lblJourneyDate.Text.ToString()) >= Convert.ToDateTime(lblJourneydatereturn.Text.ToString()))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "ReturnDate should be greater than TravelingDate." + "');</script>", false);
                        return;
                    }


                    lblbusoperatorreturn.Text = dt1.Rows[0]["Travels"].ToString();
                    lblbustypereturn.Text = dt1.Rows[0]["BusType"].ToString();
                    lblseatNosReturn.Text = dt1.Rows[0]["SeatNos"].ToString();
                    lbltotalFarereturn.Text = dt1.Rows[0]["TotalFare"].ToString();
                    double totalamntPayable = Convert.ToDouble(dt1.Rows[0]["TotalFare"].ToString()) + Convert.ToDouble(dt.Rows[0]["TotalFare"].ToString());
                    lblTotalAmountPayable.Text = Convert.ToString(totalamntPayable);
                    lblBoardingpointreturn.Text = dt1.Rows[0]["BoardingPoint"].ToString();
                    DataTable dtseatsreturn = new DataTable();
                    dtseatsreturn.Columns.Add("SeatNosreturn");

                    string[] seatnosreturn = lblseatNosReturn.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in seatnosreturn)
                    {
                        DataRow dr = dtseats.NewRow();
                        DataRow drreturn = dtseatsreturn.NewRow();
                        dr["SeatNos"] = item;
                        drreturn["SeatNosreturn"] = item;
                        dtseats.Rows.Add(dr);
                        dtseatsreturn.Rows.Add(drreturn);
                    }
                    if (dtseats != null && dtseatsreturn != null)
                    {
                        ddlPrimaryPassenger.DataSource = dtseats.DefaultView.ToTable(true, "SeatNos");
                        ddlPrimaryPassenger.DataTextField = "SeatNos";
                        ddlPrimaryPassenger.DataBind();
                        rptrPsgrDetailsReturn.DataSource = dtseatsreturn;
                        rptrPsgrDetailsReturn.DataBind();
                    }
                    NoOFSeats = seatnos.Length + seatnosreturn.Length;
                    if (NoOFSeats == 1)
                    {
                        pnlPriamryPassenger.Visible = false;
                    }
                }
            }
            else { Response.Redirect("~/Users/Bus/Bus_Search.aspx", false); }
        }
    }

    protected string GenerateManabusRefNo()
    {
        try
        {
            int minPassSize = 4; int maxPassSize = 4;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = "0123456789".ToCharArray();
            int newPassLength = new Random().Next(minPassSize, maxPassSize);
            char character;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < newPassLength; i++)
            {
                character = charArray[rnd.Next(0, (charArray.Length - 1))];
                stringBuilder.Append(character);
            }
            string refno = "LJB" + stringBuilder.ToString();

            objBAL = new ClsBAL();
            string strUniqueId = objBAL.GetUniqueId();
            return refno + strUniqueId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected bool InsertTentativeBooking(string onewayrefNo, string pGRefNo, string blockedId, string ticketId, string serviceId, string serviceTransDateId,
                int? coachTypeId, string Api, string travelName, string busType, DateTime doJ, int sourceId, string sourceName, int destinationId, string destinationName,
                string bookedSeats, int noofSeats, decimal basicFare, int? bordingpointId, string boardingpointInfo, string boradingPoint, string fullname, int age, string gender, string mobileNo,
                string emailid, string address, string status, DateTime? responsedatetime, int? cashCouponId, int? promoCodeId, string deliveryType, string deliveryAddress, string paymentType, string tripType,
                int? createdBy, string saleType, string servicenumber, string passengerInfo, string Idtype, string IdNumber, string PrimaryPassengerseat)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.OnewayMBRefNo = onewayrefNo;
            objBAL.PGMBRefNo = pGRefNo;
            objBAL.blockedId = blockedId;
            objBAL.ticketId = ticketId;
            objBAL.serviceId = serviceId;
            objBAL.serviceTranDateId = serviceTransDateId;
            objBAL.coachTypeId = coachTypeId;
            objBAL.api = Api;
            objBAL.travelName = travelName;
            objBAL.busType = busType;
            objBAL.dateOFJourney = doJ;
            objBAL.sourceId = sourceId;
            objBAL.sourceName = sourceName;
            objBAL.destionationId = destinationId;
            objBAL.destinationName = destinationName;
            objBAL.bookedSeats = bookedSeats;
            objBAL.noOfSeats = noofSeats;
            objBAL.boardingPointId = bordingpointId;
            objBAL.totalbasicFare = Convert.ToDecimal(basicFare);
            objBAL.boardingpointinfo = boardingpointInfo;
            objBAL.boardingPoint = boradingPoint;
            objBAL.fullName = fullname;
            objBAL.age = Convert.ToInt32(age);
            objBAL.gender = gender;
            objBAL.mobileNo = mobileNo;
            objBAL.emailId = emailid;
            objBAL.address = address;
            objBAL.status = status;
            objBAL.responsedatetime = responsedatetime;
            objBAL.cashcouponId = cashCouponId;
            objBAL.promoCodeId = promoCodeId;
            objBAL.deliveryType = deliveryType;
            objBAL.deliveryAddress = deliveryAddress;
            objBAL.type = tripType;
            objBAL.paymentType = paymentType;
            objBAL.saleType = saleType;
            objBAL.createdBy = createdBy;
            objBAL.serviceNumber = servicenumber;
            objBAL.IDType = Idtype;
            objBAL.IDNumber = IdNumber;
            objBAL.IDIssuedBy = txtIdIssuedBY.Text.ToString();
            objBAL.PrimaryPassengerSeat = PrimaryPassengerseat;
            objBAL.passengerDetails = passengerInfo;
            objBAL.comments = txtComment.Text.ToString();
            if (objBAL.AddTentativeBooking())
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnProceedToPayment_Click(object sender, EventArgs e)
    {
        try
        {
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Bus service is under maintenance." + "');</script>", false);
            //return;
            if (Session["Role"].ToString() == "User")
            {
                lblMsg.Text = "Ticket booking failed. Please contact the administrator."; return;
                // Response.Redirect("~/Pay.aspx", false);
            }
            else
            {
                if (cbxAgree.Checked == true)
                {

                    string namelist = "", phonelist = "", agelist = "", genderlist = "";
                    int countlist = 0;
                    foreach (RepeaterItem item in rptPassengersonward.Items)
                    {
                        DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                        TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                        TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");
                        string phoneno = txtPhoneNo.Text;
                        if (countlist == 0)
                        {
                            ++countlist;
                            namelist += txtPassengerNamerptr.Text;
                            phonelist += phoneno;
                            agelist += txtAgerptr.Text;
                            genderlist += ddlrptr.SelectedItem.Value.ToString();
                        }
                        else
                        {
                            ++countlist;
                            namelist += "," + txtPassengerNamerptr.Text;
                            phonelist += "," + phoneno;
                            agelist += "," + txtAgerptr.Text;
                            genderlist += "," + ddlrptr.SelectedItem.Value.ToString();
                        }
                    }
                    DataTable dtInfo = (DataTable)Session["dtTicketInfo"];
                    dtInfo.Rows[0]["Title"] = ddlGender.SelectedItem.Value.ToString();
                    TextBox txtname = (TextBox)rptPassengersonward.Items[0].FindControl("txtPassengerName");
                    dtInfo.Rows[0]["FullName"] = txtname.Text.ToString();
                    dtInfo.Rows[0]["Age"] = 20;
                    dtInfo.Rows[0]["PhoneNo"] = txtPhoneNo.Text.ToString();
                    dtInfo.Rows[0]["EmailId"] = txtEmailId.Text.ToString();
                    dtInfo.Rows[0]["Address"] = txtAddress.Text.ToString();
                    dtInfo.Rows[0]["FullNameList"] = namelist;
                    dtInfo.Rows[0]["PhoneNoList"] = phonelist;
                    dtInfo.Rows[0]["AgeList"] = agelist;
                    dtInfo.Rows[0]["GenderList"] = genderlist;
                    dtInfo.Rows[0]["IdType"] = ddlIDType.SelectedItem.Text;
                    dtInfo.Rows[0]["IdNo"] = txtIDNumber.Text;
                    dtInfo.Rows[0]["IdIssuedBy"] = txtIdIssuedBY.Text;
                    Session["dtTicketInfo"] = dtInfo;
                    namelist = phonelist = agelist = genderlist = "";

                    if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                    {
                        int countlistsreturn = 0;
                        foreach (RepeaterItem item in rptrPsgrDetailsReturn.Items)
                        {
                            DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                            TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                            TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");
                            string phoneno = txtPhoneNo.Text;
                            if (countlistsreturn == 0)
                            {
                                ++countlistsreturn;
                                namelist += txtPassengerNamerptr.Text;
                                phonelist += phoneno;
                                agelist += txtAgerptr.Text;
                                genderlist += ddlrptr.SelectedItem.Value.ToString();
                            }
                            else
                            {
                                ++countlistsreturn;
                                namelist += "," + txtPassengerNamerptr.Text;
                                phonelist += "," + phoneno;
                                agelist += "," + txtAgerptr.Text;
                                genderlist += "," + ddlrptr.SelectedItem.Value.ToString();
                            }


                        }
                        DataTable dtInfo1 = (DataTable)Session["dtTicketInfoReturn"];
                        dtInfo1.Rows[0]["Title"] = ddlGender.SelectedItem.Value.ToString();
                        TextBox txtnamereturn = (TextBox)rptrPsgrDetailsReturn.Items[0].FindControl("txtPassengerName");
                        dtInfo1.Rows[0]["FullName"] = txtnamereturn.Text;//txtFullName.Text.ToString();
                        dtInfo1.Rows[0]["Age"] = 20;
                        dtInfo1.Rows[0]["PhoneNo"] = txtPhoneNo.Text.ToString();
                        dtInfo1.Rows[0]["EmailId"] = txtEmailId.Text.ToString();
                        dtInfo1.Rows[0]["Address"] = txtAddress.Text.ToString();
                        //dtInfo1.Rows[0]["BoardingInfo"] = lblBoardingPoint.Text.ToString();
                        dtInfo1.Rows[0]["FullNameList"] = namelist;
                        dtInfo1.Rows[0]["PhoneNoList"] = phonelist;
                        dtInfo1.Rows[0]["AgeList"] = agelist;
                        dtInfo1.Rows[0]["GenderList"] = genderlist;
                        dtInfo1.Rows[0]["IdType"] = ddlIDType.SelectedItem.Text;
                        dtInfo1.Rows[0]["IdNo"] = txtIDNumber.Text;
                        dtInfo1.Rows[0]["IdIssuedBy"] = txtIdIssuedBY.Text;
                        Session["dtTicketInfoReturn"] = dtInfo1;
                    }

                    lblMsg.Text = "";
                    bool res = false;
                    string status = ""; string statusReason = ""; string api = ""; string referenceNumber = ""; string referenceNumberReturn = "";
                    string statusReturn = ""; string statusReasonReturn = "";
                    string apiReturn = ""; string CouponFare = ""; double totalOnFareRetFare = 0; int count = 0;

                    if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                    {
                        referenceNumber = GenerateManabusRefNo();
                        referenceNumberReturn = GenerateManabusRefNo();
                    }
                    else
                    {
                        referenceNumber = GenerateManabusRefNo();
                    }
                    DataTable dtTicketInfo = (DataTable)Session["dtTicketInfo"];

                    DataTable dtTicketInfoReturn = null;

                    if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                    {
                        dtTicketInfoReturn = (DataTable)Session["dtTicketInfoReturn"];
                        Session["returnFare"] = dtTicketInfoReturn.Rows[0]["TotalFare"].ToString();
                    }

                    DataSet ds = objCommon.TentativeBooking(dtTicketInfo, referenceNumber, out api, out status, out statusReason);
                    DataSet dsReturn = null;
                    if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                    {
                        dsReturn = objCommon.TentativeBooking(dtTicketInfoReturn, referenceNumberReturn, out apiReturn, out statusReturn, out statusReasonReturn);
                    }
                    if (status == "Success")
                    {
                        #region Payment Gateway Parameters
                        Session["Name_PG"] = txtFullName.Text.ToString();
                        Session["Phone_PG"] = txtPhoneNo.Text.ToString();
                        Session["EmailId_PG"] = txtEmailId.Text.ToString();
                        Session["Address_PG"] = txtAddress.Text.ToString();
                        #endregion

                        Session["dtTicketInfo"] = dtTicketInfo;
                        Session["dtTicketInfoReturn"] = null;

                        Session["dsTentativeInfo"] = ds;
                        Session["dsTentativeInfoReturn"] = null;
                        Session["OneWayOrRoundTrip"] = ViewState["OneWayOrRoundTrip"].ToString();

                        DataTable dtTicketInfo1 = (DataTable)Session["dtTicketInfo"];
                        string str = dtTicketInfo1.Rows[0]["OtherInfo"].ToString();
                        string[] strArray = str.Split(';');
                        Session["DOJ"] = Convert.ToDateTime(dtTicketInfo1.Rows[0]["JourneyDate"].ToString());
                        Session["seatnos"] = dtTicketInfo1.Rows[0]["SeatNos"].ToString();

                        Session["fare"] = lblTotalAmountPayable.Text.ToString();

                        if (ViewState["OneWayOrRoundTrip"].ToString() == "OneWay")
                        {
                            ViewState["TripType"] = "oneway";
                            Session["manabusrefno"] = referenceNumber;
                        }
                        else if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                        {
                            ViewState["TripType"] = "roundtrip";
                            Session["manabusrefno"] = referenceNumber + "X" + referenceNumberReturn;
                        }

                        #region Parameters
                        string OnewayMBRefNo = "", PGMBRefNo = "", blockedId = "", ticketId = "", serviceId = "", serviceTranDateId = "", api_G = "", travelName = "", busType = "", sourceName = "", destinationName = "", deliveryAddress = "Manabus Address", ServiceNumberonward = "", passengerDetailsonward = "", passengerDetailsReturn = "", IDType = "", IDNumber = "", PrimaryPassengerSeat = "", ServiceNumberReturn = "",
                            bookedSeats = "", boardingpointinfo = "", boardingPoint = "", fullName = "", gender = "", mobileNo = "", emailId = "", address = "",
                            status_G = "", paymentType = "", saleType = "", deliveryType = "", tripType = "";
                        int sourceId = 0, destionationId = 0, noOfSeats = 0, age = 0;
                        DateTime dateOFJourney;
                        DateTime? responsedatetime = null;
                        decimal totalbasicFare = 0;
                        int? cashcouponId = null, promoCodeId = null, CreatedBy = null, coachTypeId = null, boardingPointId = null;
                        if (rdbtnlstselct.SelectedItem.Value == "0")
                        {
                            deliveryAddress = txtAddress.Text + "," + txtLandmark.Text + "," + txtCity.Text + "," + txtPinCode.Text + "," + ddlHour.SelectedItem.Text + ":" + ddlMinutes.SelectedItem.Text + ":" + ddlAmPm.SelectedItem.Text + "," + txtComments.Text;
                            pnlhomedelivery.Visible = false;
                            txtAddress.Text = txtComments.Text = txtLandmark.Text = txtPinCode.Text = txtCity.Text = "";
                            ddlHour.Items.Clear();
                            ddlMinutes.Items.Clear();
                        }
                        OnewayMBRefNo = referenceNumber;
                        PGMBRefNo = Session["manabusrefno"].ToString();
                        sourceName = Session["From"].ToString();
                        destinationName = Session["To"].ToString();
                        travelName = dtTicketInfo1.Rows[0]["Travels"].ToString();
                        busType = dtTicketInfo1.Rows[0]["BusType"].ToString();
                        dateOFJourney = Convert.ToDateTime(dtTicketInfo1.Rows[0]["JourneyDate"].ToString());
                        bookedSeats = dtTicketInfo1.Rows[0]["SeatNos"].ToString();
                        totalbasicFare = Convert.ToDecimal(dtTicketInfo1.Rows[0]["TotalFare"].ToString());
                        boardingPoint = dtTicketInfo1.Rows[0]["BoardingPoint"].ToString();
                        boardingpointinfo = dtTicketInfo1.Rows[0]["BoardingInfo"].ToString();
                        fullName = dtTicketInfo1.Rows[0]["FullName"].ToString();
                        age = Convert.ToInt32(dtTicketInfo1.Rows[0]["Age"].ToString());
                        gender = dtTicketInfo1.Rows[0]["Title"].ToString();
                        mobileNo = dtTicketInfo1.Rows[0]["PhoneNo"].ToString();
                        emailId = dtTicketInfo1.Rows[0]["EmailId"].ToString();
                        address = dtTicketInfo1.Rows[0]["Address"].ToString();
                        if (ViewState["CashCouponID"] != null)
                        {
                            cashcouponId = Convert.ToInt32(ViewState["CashCouponID"].ToString());
                            paymentType = "CashCoupon";
                        }
                        else
                        {
                            cashcouponId = null;
                        }
                        if (ViewState["PromoCodeID"] != null)
                        {
                            promoCodeId = Convert.ToInt32(ViewState["PromoCodeID"].ToString());
                            paymentType = "CashCoupon";
                        }
                        else
                        {
                            promoCodeId = null;
                        }

                        paymentType = "Cash";
                        deliveryType = rdbtnlstselct.SelectedItem.Text;
                        tripType = ViewState["TripType"].ToString();
                        saleType = "Executive";
                        IDType = ddlIDType.SelectedItem.Text;
                        IDNumber = txtIDNumber.Text;
                        ServiceNumberonward = dtTicketInfo1.Rows[0]["ServiceNumber"].ToString();
                        PrimaryPassengerSeat = ddlPrimaryPassenger.SelectedItem.Text;
                        int countpassengers = 0;
                        foreach (RepeaterItem item in rptPassengersonward.Items)
                        {
                            DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                            Label lblSeatNorptr = (Label)item.FindControl("lblSeatNo");
                            TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                            TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");
                            if (countpassengers == 0)
                            {
                                ++countpassengers;
                                passengerDetailsonward += lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text;
                            }
                            else
                            {
                                ++countpassengers;
                                passengerDetailsonward += "," + lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text;
                            }
                        }
                        CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        if (api.ToString() == "Kes")
                        {
                            if (ds.Tables[0].Columns.Count > 1)
                            {
                                api_G = "Kesineni";

                                blockedId = ds.Tables[0].Rows[0]["BlockedTicketID"].ToString();
                                ticketId = ds.Tables[0].Rows[0]["TicketNumber"].ToString();
                                serviceId = ds.Tables[0].Rows[0]["ServiceID"].ToString();
                                serviceTranDateId = ds.Tables[0].Rows[0]["ServiceTransDateID"].ToString();
                                status_G = ds.Tables[0].Rows[0]["Status"].ToString();
                                responsedatetime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ResponseDatetime"].ToString());

                                sourceId = Convert.ToInt32(strArray[1].ToString());
                                destionationId = Convert.ToInt32(strArray[2].ToString());
                                // dateOFJourney = Convert.ToDateTime(strArray[3].ToString());
                                coachTypeId = Convert.ToInt32(strArray[5].ToString());
                                noOfSeats = Convert.ToInt32(strArray[7].ToString());
                                bookedSeats = strArray[8].ToString();
                                totalbasicFare = Convert.ToDecimal(strArray[10].ToString());
                            }
                        }
                        else if (api.ToString() == "Bit")
                        {
                            api_G = "Bitla";
                            serviceId = strArray[1].ToString();
                            sourceId = Convert.ToInt32(strArray[2].ToString());
                            destionationId = Convert.ToInt32(strArray[3].ToString());
                            noOfSeats = Convert.ToInt32(strArray[4].ToString());
                            boardingPointId = Convert.ToInt32(strArray[5].ToString());
                        }
                        else if (api.ToString() == "Abh")
                        {
                            api_G = "Abhibus";
                            serviceId = strArray[4].ToString();
                            // dateOFJourney = Convert.ToDateTime(strArray[1].ToString());
                            sourceId = Convert.ToInt32(strArray[2].ToString());
                            destionationId = Convert.ToInt32(strArray[3].ToString());
                            bookedSeats = strArray[5].ToString();
                            noOfSeats = Convert.ToInt32(strArray[7].ToString());
                            boardingPointId = Convert.ToInt32(strArray[6].ToString());
                        }
                        else if (api.ToString() == "Kal")
                        {
                            api_G = "Kallada";
                            serviceId = strArray[4].ToString();
                            // dateOFJourney = Convert.ToDateTime(strArray[1].ToString());
                            sourceId = Convert.ToInt32(strArray[2].ToString());
                            destionationId = Convert.ToInt32(strArray[3].ToString());
                            bookedSeats = strArray[5].ToString();
                            noOfSeats = Convert.ToInt32(strArray[7].ToString());
                            boardingPointId = Convert.ToInt32(strArray[6].ToString());
                        }
                        else if (api.ToString() == "Tig")
                        {
                            api_G = "TicketGoose";
                            blockedId = ds.Tables[0].Rows[0]["BookingId"].ToString();

                            sourceId = Convert.ToInt32(strArray[1].ToString());
                            destionationId = Convert.ToInt32(strArray[2].ToString());

                            bookedSeats = dtTicketInfo1.Rows[0]["SeatNos"].ToString();
                            noOfSeats = dtTicketInfo1.Rows[0]["SeatNos"].ToString().Split(',').Length;

                            //boardingPointId = Convert.ToInt32(strArray[5].ToString());
                        }
                        #endregion

                        #region Oneway

                        res = InsertTentativeBooking(OnewayMBRefNo, PGMBRefNo, blockedId, ticketId, serviceId, serviceTranDateId,
                                        coachTypeId, api_G, travelName, busType, dateOFJourney, sourceId, sourceName, destionationId, destinationName,
                                        bookedSeats, noOfSeats, totalbasicFare, boardingPointId, boardingpointinfo, boardingPoint, fullName, age, gender, mobileNo,
                                        emailId, address, status_G, responsedatetime, cashcouponId, promoCodeId, deliveryType, deliveryAddress, paymentType, tripType,
                                        CreatedBy, saleType, ServiceNumberonward, passengerDetailsonward, IDType, IDNumber, PrimaryPassengerSeat);

                        #endregion

                        if (res)
                        {
                            #region Twoway

                            if (ViewState["OneWayOrRoundTrip"].ToString() == "OneWay")
                            {
                                if (status == "Success")
                                {
                                    Session["dtTicketInfoReturn"] = null;
                                    Session["dsTentativeInfoReturn"] = null;
                                    lblMsg.Text = "Success";
                                    //BookTicket();
                                }
                                else if (status == "Fail")
                                {
                                    lblMsg.Text = statusReason;
                                    return;
                                }
                            }
                            else if (ViewState["OneWayOrRoundTrip"].ToString() == "RoundTrip")
                            {
                                res = false;
                                //dsReturn = objCommon.TentativeBooking(dtTicketInfoReturn, referenceNumberReturn, out apiReturn, out statusReturn, out statusReasonReturn);
                                if (statusReturn == "Success")
                                {
                                    Session["dtTicketInfo"] = dtTicketInfo;
                                    Session["dtTicketInfoReturn"] = dtTicketInfoReturn;

                                    Session["dsTentativeInfo"] = ds;
                                    Session["dsTentativeInfoReturn"] = dsReturn;
                                    Session["OneWayOrRoundTrip"] = ViewState["OneWayOrRoundTrip"].ToString();

                                    #region Roundtrip
                                    if (referenceNumber.ToString() != referenceNumberReturn.ToString())
                                    {
                                        DataTable dtTicketInforeturn = (DataTable)Session["dtTicketInfoReturn"];
                                        string strreturn = dtTicketInforeturn.Rows[0]["OtherInfo"].ToString();
                                        string[] strArrayreturn = strreturn.Split(';');

                                        Session["DOJ"] = Convert.ToDateTime(dtTicketInforeturn.Rows[0]["JourneyDate"].ToString());
                                        Session["seatnos"] = dtTicketInforeturn.Rows[0]["SeatNos"].ToString();
                                        Session["fare"] = lblTotalAmountPayable.Text;

                                        Session["manabusrefno"] = referenceNumber + "X" + referenceNumberReturn;


                                        #region Return Parameters
                                        if (rdbtnlstselct.SelectedItem.Value == "0")
                                        {
                                            deliveryAddress = txtAddress.Text + "," + txtLandmark.Text + "," + txtCity.Text + "," + txtPinCode.Text + "," + ddlHour.SelectedItem.Text + ":" + ddlMinutes.SelectedItem.Text + ":" + ddlAmPm.SelectedItem.Text + "," + txtComments.Text;
                                            pnlhomedelivery.Visible = false;
                                            txtAddress.Text = txtComments.Text = txtLandmark.Text = txtPinCode.Text = txtCity.Text = "";
                                            ddlHour.Items.Clear();
                                            ddlMinutes.Items.Clear();
                                        }
                                        OnewayMBRefNo = referenceNumberReturn;
                                        PGMBRefNo = Session["manabusrefno"].ToString();
                                        sourceName = Session["To"].ToString();
                                        destinationName = Session["From"].ToString();
                                        travelName = dtTicketInforeturn.Rows[0]["Travels"].ToString();
                                        busType = dtTicketInforeturn.Rows[0]["BusType"].ToString();
                                        dateOFJourney = Convert.ToDateTime(dtTicketInforeturn.Rows[0]["JourneyDate"].ToString());
                                        bookedSeats = dtTicketInforeturn.Rows[0]["SeatNos"].ToString();
                                        totalbasicFare = Convert.ToDecimal(dtTicketInforeturn.Rows[0]["TotalFare"].ToString());
                                        boardingPoint = dtTicketInforeturn.Rows[0]["BoardingPoint"].ToString();
                                        boardingpointinfo = dtTicketInforeturn.Rows[0]["BoardingInfo"].ToString();
                                        fullName = dtTicketInforeturn.Rows[0]["FullName"].ToString();
                                        age = Convert.ToInt32(dtTicketInforeturn.Rows[0]["Age"].ToString());
                                        gender = dtTicketInforeturn.Rows[0]["Title"].ToString();
                                        mobileNo = dtTicketInforeturn.Rows[0]["PhoneNo"].ToString();
                                        emailId = dtTicketInforeturn.Rows[0]["EmailId"].ToString();
                                        address = dtTicketInforeturn.Rows[0]["Address"].ToString();
                                        if (ViewState["CashCouponID"] != null)
                                        {
                                            cashcouponId = Convert.ToInt32(ViewState["CashCouponID"].ToString());
                                            paymentType = "CashCoupon";
                                        }
                                        else
                                        {
                                            cashcouponId = null;
                                        }
                                        if (ViewState["PromoCodeID"] != null)
                                        {
                                            promoCodeId = Convert.ToInt32(ViewState["PromoCodeID"].ToString());
                                            paymentType = "CashCoupon";
                                        }
                                        else
                                        {
                                            promoCodeId = null;
                                        }
                                        paymentType = "Cash";
                                        deliveryType = rdbtnlstselct.SelectedItem.Text;
                                        tripType = ViewState["TripType"].ToString();
                                        saleType = "Executive";
                                        ServiceNumberReturn = dtTicketInforeturn.Rows[0]["ServiceNumber"].ToString();
                                        int countpassengersreturn = 0;
                                        foreach (RepeaterItem item in rptrPsgrDetailsReturn.Items)
                                        {
                                            DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                                            Label lblSeatNorptr = (Label)item.FindControl("lblSeatNo");
                                            TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                                            TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");

                                            if (countpassengersreturn == 0)
                                            {
                                                ++countpassengersreturn;
                                                passengerDetailsReturn += lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text;
                                            }
                                            else
                                            {
                                                ++countpassengersreturn;
                                                passengerDetailsonward += "," + lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text + ",";
                                            }


                                        }
                                        CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                                        if (apiReturn.ToString() == "Kes")
                                        {
                                            if (ds.Tables[0].Columns.Count > 1)
                                            {
                                                api_G = "Kesineni";

                                                blockedId = dsReturn.Tables[0].Rows[0]["BlockedTicketID"].ToString();
                                                ticketId = dsReturn.Tables[0].Rows[0]["TicketNumber"].ToString();
                                                serviceId = dsReturn.Tables[0].Rows[0]["ServiceID"].ToString();
                                                serviceTranDateId = dsReturn.Tables[0].Rows[0]["ServiceTransDateID"].ToString();
                                                status_G = dsReturn.Tables[0].Rows[0]["Status"].ToString();
                                                responsedatetime = Convert.ToDateTime(dsReturn.Tables[0].Rows[0]["ResponseDatetime"].ToString());

                                                sourceId = Convert.ToInt32(strArrayreturn[1].ToString());
                                                destionationId = Convert.ToInt32(strArrayreturn[2].ToString());
                                                // dateOFJourney = Convert.ToDateTime(strArray[3].ToString());
                                                coachTypeId = Convert.ToInt32(strArrayreturn[5].ToString());
                                                noOfSeats = Convert.ToInt32(strArrayreturn[7].ToString());
                                                bookedSeats = strArrayreturn[8].ToString();
                                                totalbasicFare = Convert.ToDecimal(strArrayreturn[10].ToString());
                                            }
                                        }
                                        else if (apiReturn.ToString() == "Bit")
                                        {
                                            api_G = "Bitla";
                                            serviceId = strArrayreturn[1].ToString();
                                            sourceId = Convert.ToInt32(strArrayreturn[2].ToString());
                                            destionationId = Convert.ToInt32(strArrayreturn[3].ToString());
                                            noOfSeats = Convert.ToInt32(strArrayreturn[4].ToString());
                                            boardingPointId = Convert.ToInt32(strArrayreturn[5].ToString());
                                        }
                                        else if (apiReturn.ToString() == "Abh")
                                        {
                                            api_G = "Abhibus";
                                            serviceId = strArrayreturn[4].ToString();
                                            // dateOFJourney = Convert.ToDateTime(strArray[1].ToString());
                                            sourceId = Convert.ToInt32(strArrayreturn[2].ToString());
                                            destionationId = Convert.ToInt32(strArrayreturn[3].ToString());
                                            bookedSeats = strArrayreturn[5].ToString();
                                            noOfSeats = Convert.ToInt32(strArrayreturn[7].ToString());
                                            boardingPointId = Convert.ToInt32(strArrayreturn[6].ToString());
                                        }
                                        else if (api.ToString() == "Kal")
                                        {
                                            api_G = "Kallada";
                                            serviceId = strArray[4].ToString();
                                            // dateOFJourney = Convert.ToDateTime(strArray[1].ToString());
                                            sourceId = Convert.ToInt32(strArray[2].ToString());
                                            destionationId = Convert.ToInt32(strArray[3].ToString());
                                            bookedSeats = strArray[5].ToString();
                                            noOfSeats = Convert.ToInt32(strArray[7].ToString());
                                            boardingPointId = Convert.ToInt32(strArray[6].ToString());
                                        }
                                        else if (api.ToString() == "Tig")
                                        {
                                            api_G = "TicketGoose";
                                            blockedId = ds.Tables[0].Rows[0]["BookingId"].ToString();

                                            sourceId = Convert.ToInt32(strArray[1].ToString());
                                            destionationId = Convert.ToInt32(strArray[2].ToString());

                                            bookedSeats = dtTicketInfo1.Rows[0]["SeatNos"].ToString();
                                            noOfSeats = dtTicketInfo1.Rows[0]["SeatNos"].ToString().Split(',').Length;

                                            //boardingPointId = Convert.ToInt32(strArray[5].ToString());
                                        }

                                        #endregion

                                        res = InsertTentativeBooking(OnewayMBRefNo, PGMBRefNo, blockedId, ticketId, serviceId, serviceTranDateId,
                                                    coachTypeId, api_G, travelName, busType, dateOFJourney, sourceId, sourceName, destionationId, destinationName,
                                                    bookedSeats, noOfSeats, totalbasicFare, boardingPointId, boardingpointinfo, boardingPoint, fullName, age, gender, mobileNo,
                                                    emailId, address, status_G, responsedatetime, cashcouponId, promoCodeId, deliveryType, deliveryAddress, paymentType, tripType,
                                                    CreatedBy, saleType, ServiceNumberReturn, passengerDetailsReturn, IDType, IDNumber, PrimaryPassengerSeat);

                                        if (res)
                                        {
                                            Session["dtTicketInfoReturn"] = null;
                                            Session["dsTentativeInfoReturn"] = null;
                                            lblMsg.Text = "Success";
                                            BookTicket();
                                        }
                                        else
                                        {
                                            lblMsg.Text = "Please try again later. DBE";//DBE-Database Error;
                                        }

                                    }
                                    #endregion
                                    else { lblMsg.Text = "Please try again later."; }
                                }
                                else if (statusReturn == "Fail")
                                {
                                    lblMsg.Text = statusReturn;
                                    lblMsg.Visible = true;
                                    return;
                                }
                            }
                            else { lblMsg.Text = "Please try again later."; }
                            #endregion
                        }
                        else
                        {
                            lblMsg.Text = "Please try again later. DBE";//DBE-Database Error;
                        }
                    }
                    else
                    {
                        lblMsg.Text = statusReason;
                        lblMsg.Visible = true;
                        res = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Please agree to the terms and conditions.";
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        //if (Session["ddlSources"] != null && Session["ddlDestinations"] != null && Session["DOJ"] != null
        //           && Session["From"] != null && Session["To"] != null && Session["sesDTDestinations"] != null
        //           && Session["OneWayOrRoundTrip"] != null && Session["ddlSourcesReturn"] != null
        //           && Session["ddlDestinationsReturn"] != null && Session["DOJReturn"] != null
        //           && Session["FromReturn"] != null && Session["ToReturn"] != null)
        //{
        //    Session["ddlSources"] = ViewState["ddlSources"].ToString();
        //    Session["ddlDestinations"] = ViewState["ddlDestinations"].ToString();
        //    Session["DOJ"] = ViewState["DOJ"].ToString();
        //    Session["From"] = ViewState["From"].ToString();
        //    Session["To"] = ViewState["To"].ToString();

        //    Session["ddlSourcesReturn"] = ViewState["ddlSourcesReturn"].ToString();
        //    Session["ddlDestinationsReturn"] = ViewState["ddlDestinationsReturn"].ToString();
        //    Session["DOJReturn"] = ViewState["DOJReturn"].ToString();
        //    Session["FromReturn"] = ViewState["FromReturn"].ToString();
        //    Session["ToReturn"] = ViewState["ToReturn"].ToString();

        //    Session["sesDTDestinations"] = Session["sesDTDestinations"];

        //    Session["OneWayOrRoundTrip"] = ViewState["OneWayOrRoundTrip"].ToString();

            Response.Redirect("~/Users/Bus/Show_Trips.aspx", false);
        //}
        //else { Response.Redirect("~/Users/Bus/Bus_Search.aspx", false); }
    }

    #region CashCoupon and Promo code

    protected void chkCashCoupon_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkCashCoupon.Checked)
            {
                txtcashcoupon.Visible =
                btncashcoupon.Visible = true;
            }
            else
            {
                txtcashcoupon.Text = "";
                txtcashcoupon.Visible = btncashcoupon.Visible = false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void chkPromoCode_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPromoCode.Checked)
            {
                txtPromoCode.Visible = btnPromoCode.Visible = true;
            }
            else
            {
                txtPromoCode.Text = "";
                txtPromoCode.Visible = btnPromoCode.Visible = false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btncashcoupon_Click(object sender, EventArgs e)
    {
        try
        {
            int CouponId = 0; string CouponFare = ""; double FinalFare = 0;
            if (chkCashCoupon.Checked)
            {
                if (txtcashcoupon.Text != "")
                {
                    objBAL = new ClsBAL();
                    objBAL.couponNo = txtcashcoupon.Text;
                    objDataSet = (DataSet)objBAL.CheckCashCoupon();
                    if (objDataSet != null)
                    {
                        if (objDataSet.Tables.Count > 0)
                        {
                            if (objDataSet.Tables[0].Rows.Count > 0)
                            {
                                CouponFare = objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                                CouponId = Convert.ToInt32(objDataSet.Tables[0].Rows[0]["CouponId"].ToString());
                                if (Convert.ToDouble(lblTotalAmountPayable.Text) >= Convert.ToDouble(CouponFare))
                                {
                                    FinalFare = Convert.ToDouble(lblTotalAmountPayable.Text) - Convert.ToDouble(CouponFare);
                                    lblTotalAmountPayable.Text = Convert.ToString(FinalFare);
                                }
                                else if (Convert.ToDouble(CouponFare) > Convert.ToDouble(lblTotalAmountPayable.Text))
                                {
                                    FinalFare = Convert.ToDouble(CouponFare) - Convert.ToDouble(lblTotalAmountPayable.Text);
                                    lblTotalAmountPayable.Text = Convert.ToString(0);
                                }
                                ViewState["CashCouponID"] = CouponId;
                                ViewState["FinalFare"] = lblTotalAmountPayable.Text;
                                chkCashCoupon.Checked = false;
                                chkCashCoupon_CheckedChanged(sender, e);
                                chkCashCoupon.Enabled = false;
                            }
                            else
                            {
                                lblCashcouponErrormsg.Text = "Please enter valid coupon code";
                            }
                        }
                        else
                        {
                            lblCashcouponErrormsg.Text = "Please enter valid coupon code";
                        }
                    }
                    else
                    {
                        lblCashcouponErrormsg.Text = "Please enter valid coupon code";
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
            if (objDataSet != null)
            {
                objDataSet = null;
            }
        }
    }

    protected void btnPromoCode_Click(object sender, EventArgs e)
    {
        try
        {
            int CouponId = 0; string CouponFare = ""; double FinalFare = 0;
            if (chkPromoCode.Checked)
            {
                if (txtPromoCode.Text != "")
                {
                    objBAL = new ClsBAL();
                    objBAL.promoCode = txtPromoCode.Text;
                    objDataSet = (DataSet)objBAL.CheckPromoCode();
                    if (objDataSet != null)
                    {
                        if (objDataSet.Tables.Count > 0)
                        {
                            if (objDataSet.Tables[0].Rows.Count > 0)
                            {
                                CouponFare = objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                                CouponId = Convert.ToInt32(objDataSet.Tables[0].Rows[0]["PromoCodeId"].ToString());
                                if (Convert.ToDouble(lblTotalAmountPayable.Text) >= Convert.ToDouble(CouponFare))
                                {
                                    FinalFare = Convert.ToDouble(lblTotalAmountPayable.Text) - Convert.ToDouble(CouponFare);
                                    lblTotalAmountPayable.Text = Convert.ToString(FinalFare);
                                }
                                else if (Convert.ToDouble(CouponFare) > Convert.ToDouble(lblTotalAmountPayable.Text))
                                {
                                    FinalFare = Convert.ToDouble(CouponFare) - Convert.ToDouble(lblTotalAmountPayable.Text);
                                    lblTotalAmountPayable.Text = Convert.ToString(0);
                                }
                                ViewState["PromoCodeID"] = CouponId;
                                ViewState["FinalFare"] = lblTotalAmountPayable.Text;
                                chkPromoCode.Checked = false;
                                chkPromoCode_CheckedChanged(sender, e);
                                chkPromoCode.Enabled = false;
                            }
                            else
                            {
                                lblPromocodeErrorMsg.Text = "Please enter valid promo code";
                            }
                        }
                        else
                        {
                            lblPromocodeErrorMsg.Text = "Please enter valid promo code";
                        }
                    }
                    else
                    {
                        lblPromocodeErrorMsg.Text = "Please enter valid promo code";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    protected void rdbtnlstselct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlHour.Items.Clear();
            ddlMinutes.Items.Clear();
            if (rdbtnlstselct.SelectedItem.Text == "Home Delivery")
            {
                pnlhomedelivery.Visible = true;
                for (int i = 0; i <= 12; i++)
                {
                    ddlHour.Items.Insert(i, Convert.ToString(i));
                }
                for (int j = 0; j < 59; j++)
                {
                    ddlMinutes.Items.Insert(j, Convert.ToString(j));
                }
                ddlHour.SelectedIndex = 6;
                ddlMinutes.SelectedIndex = 30;
                ddlAmPm.SelectedIndex = 1;
            }
            else
            {
                pnlhomedelivery.Visible = false;
                ddlHour.Items.Clear();
                ddlMinutes.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Booking Ticket

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
        //lblMessage.Text = stringBuilder.ToString();
        string code = "MBCC" + stringBuilder.ToString();
        objBAL = new ClsBAL();

        if (objBAL.CheckCashCouponAvailability(code) == false)
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
            objBAL = new ClsBAL();
            objBAL.manabusRefNo = manabusrefNo;
            objDataSet = (DataSet)objBAL.GetUpdatedCouponDetails();

            if (objDataSet != null)
            {

                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    double amount = Convert.ToDouble(objDataSet.Tables[0].Rows[0]["AmountAfterPG"].ToString());
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
            objBAL = new ClsBAL();

            objBAL.couponNo = Convert.ToString(couponCode);
            objBAL.emailId = Convert.ToString(emailid);
            objBAL.Amount = Convert.ToString(Amount);
            objBAL.createdBy = null;

            if (objBAL.AddCashCoupon(ref lblMsg))
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
            objBAL = new ClsBAL();

            //if (travelname.Length >= 5)
            //{
            //    objBAL.api = travelname.Substring(0, 2);
            //}
            //else { objBAL.api = travelname; }
            objBAL.api = travelname;
            objDataSet = (DataSet)objBAL.GetCancelPercentageByAPI();
            if (objDataSet != null)
            {
                if (objDataSet.Tables.Count > 0)
                {
                    gvCancellationDetails.DataSource = objDataSet.Tables[0];
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
            if (objDataSet != null)
            {
                objDataSet = null;
            }
        }
    }

    protected void BookTicket()
    {
        try
        {
            return;
            int sourceStationId = 0; int destinationStationId = 0; string journeyDate = "";
            long serviceId = 0; int serviceTransId = 0; int noOfSeats = 0; string address = ""; string contactNo = ""; string emailID = "";
            long blockedTicketId = 0; string apiname = ""; string boradingpointid = ""; int k = 0;
            string status = ""; string api = "", CashcouponID = "";
            DataSet dsbookresult = null;
            if (Session["manabusrefno"] != null)
            {
                objBAL = new ClsBAL();
                objBAL.manabusRefNo = Session["manabusrefno"].ToString();
                objDataSetBook = (DataSet)objBAL.GetTcktDetByMRefNo();
                if (objDataSetBook != null)
                {
                    if (objDataSetBook.Tables.Count > 0)
                    {
                        if (objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            if (objDataSetBook.Tables[0].Rows.Count < 3)
                            {
                                #region Book Ticket
                                foreach (DataRow dr in objDataSetBook.Tables[0].Rows)
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
                                    CashcouponID = dr["CashCouponId"].ToString();
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
                                        if (Session["BookingFailedMessage"] != null)
                                        {
                                            lblMsg.Text = Session["BookingFailedMessage"].ToString();
                                        }
                                        else
                                        {
                                            lblMsg.Text = "Failed to book. Please contact administartor of LoveJourney..";
                                        }
                                        lblMsg.Visible = true;
                                    }
                                }
                                #endregion
                                if (status == "Success")
                                {
                                    #region Update Cash Coupon
                                    if (CashcouponID != "")
                                    {
                                        UpdateCashCoupon(Session["manabusrefno"].ToString(), emailID);
                                    }

                                    #endregion

                                    #region GetTicketDetails
                                    GetTicketDetails();
                                    #endregion}
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
            if (objDataSet != null)
            {
                objDataSet = null;
            }
        }

    }

    protected DataSet CommonBookticket(int sourceId, int destinationId, string DOJ, long servicereservationId, int serviceTransId, long blockedTicketId,
        string boardingpointId, book_ticket bookTicket, int noofSeats, string selectedSeats, string genderType, string psgrName,
        string address, string fullName, string phoneNo, string emailId, string refNo, string manabusref, string Api, out string api, out string status, string bookinId)
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
                        else
                        {
                            if (dsBookingResult.Tables[0].Columns.Contains("message"))
                            {
                                Session["BookingFailedMessage"] = dsBookingResult.Tables[0].Rows[0]["message"].ToString();
                            }
                        }
                    }
                }
                #endregion
            }
            else if (Api.ToString() == "Abhibus")
            {
                #region Abhibus
                DataTable dtabhibus = objAbhiBusAPILayer.SeatBooking(DOJ, Convert.ToString(sourceId), Convert.ToString(destinationId),
                    Convert.ToString(servicereservationId), selectedSeats, genderType, psgrName,
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
                #region Kallada
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
                #endregion
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
            if (api == "Bitla")
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
            else if (api == "TicketGoose")
            {
                pnrNumber = dsbookres.Tables[0].Rows[0]["bookingId"].ToString();
                pnrticketId = dsbookres.Tables[0].Rows[0]["bookingId"].ToString();
                message = dsbookres.Tables[0].Rows[0]["Status"].ToString();
            }
            objBAL = new ClsBAL();
            objBAL.PNRNumber = pnrNumber;
            objBAL.PNRTicketIDs = pnrticketId;
            objBAL.message = message;
            objBAL.manabusRefNo = manabusrefno;
            objBAL.api = api;
            if (objBAL.AddBooking_TicketDetails())
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
                objBAL = new ClsBAL();
                objBAL.manabusRefNo = Session["manabusrefno"].ToString();
                objDataSetBook = (DataSet)objBAL.GetTicketIdByManabusRefNo();
                if (objDataSetBook != null)
                {
                    if (objDataSetBook.Tables.Count > 0)
                    {
                        if (objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            string travelName = objDataSetBook.Tables[0].Rows[0]["TravelOPName"].ToString();
                            string api = objDataSetBook.Tables[0].Rows[0]["APIName"].ToString();
                            gvView.DataSource = objDataSetBook.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(travelName);
                            MVIEW.ActiveViewIndex = 1;
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
                            //SendSMS(strUrl);
                            //SendSMS(strUrl2);
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
            if (objDataSetBook != null)
            {
                objDataSetBook = null;
            }
        }
    }

    #endregion

    #region Print/Mail/Cancel/SMS
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
    protected void lbtnmail_Click1(object sender, EventArgs e)
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
                    lblmsg1.Text = "Mail has been sent successfully";
                    lblmsg1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblmsg1.Text = "Failed to send mail";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblManabusRefNo = (Label)gvView.Rows[0].FindControl("lblManabusRefNo");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            Label lblTicketStatus = (Label)gvView.Rows[0].FindControl("lblTicketStatus");
            if (lblEmailID != null && lblManabusRefNo != null && lblTicketStatus != null)
            {
                if (lblTicketStatus.Text == "Booked")
                {
                    Response.Redirect("~/Users/Bus/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
                }
                else if (lblTicketStatus.Text == "Cancelled")
                {
                    lblmsg1.Text = "Already Cancelled this Ticket";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
                    lblmsg1.Text = "Ticket Details has been sent to your mail.Please check.";
                    lblmsg1.ForeColor = System.Drawing.Color.Green;
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
    protected void btnExportTOWord_Click(object sender, EventArgs e)
    {
        try
        {
            pnlViewticket.Visible = true;
            // BindLabelData();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Ticket.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlViewticket.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing


        }
    }
}