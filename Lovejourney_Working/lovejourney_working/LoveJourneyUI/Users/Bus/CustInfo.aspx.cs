using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using BAL;
using System.IO;
using System.Web.UI;
using LJ.CLB.DTO;


public partial class CustInfo : System.Web.UI.Page
{
    String[] BookingDetails = new String[20];
    SSAPIClient client = new SSAPIClient();
    bool res;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.Page.Title = "Passenger Info";

        if (!IsPostBack)
        {
            BookingDetails = (String[])Session["RedBusBookingDetails"];

            #region OneWayOrRoundTrip

            if (Session["RedBusBookingDetails"] != null)
            {
                BookingDetails = (String[])Session["RedBusBookingDetails"];
                pnlOnwardTicketDetails.Visible = true;

                lblRouteValue.Text = BookingDetails[0];
                lblJourneyDate.Text = BookingDetails[1];
                lblBusOperator.Text = BookingDetails[15].ToString();
                lblBusType.Text = BookingDetails[14].ToString();
                lblSeatNos.Text = BookingDetails[2];
                lblBoardingPoint.Text = BookingDetails[4].Split('~')[0];
                lblBoardingPoint.ToolTip = BookingDetails[4].Split('~')[1];
                lblFare.Text = BookingDetails[3];
                lblTotalAmountPayable.Text = BookingDetails[3];

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

                if (!BookingDetails[5].ToLower().Contains("single"))//RoundTrip
                {
                    pnlreturnticketdetails.Visible = true;
                    string[] ss = new string[1];
                    ss[0] = " to";
                    lblReturnJourney.Visible = true;

                    lblRoutereturn.Text = BookingDetails[0].Split(ss, StringSplitOptions.None)[1].ToString() + " to " + BookingDetails[0].Split(ss, StringSplitOptions.None)[0].ToString();
                    lblJourneydatereturn.Text = BookingDetails[6];
                    lblbusoperatorreturn.Text = BookingDetails[17].ToString();
                    lblbustypereturn.Text = BookingDetails[16].ToString();
                    lblseatNosReturn.Text = BookingDetails[7];
                    lblBoardingpointreturn.Text = BookingDetails[9];
                    lbltotalFarereturn.Text = BookingDetails[8];

                    lblTotalAmountPayable.Text = Convert.ToString(Convert.ToDouble(BookingDetails[8]) + Convert.ToDouble(lblFare.Text.ToString()));

                    DataTable dtseatsRet = new DataTable();
                    dtseatsRet.Columns.Add("SeatNos");
                    char[] separatorRet = { ',' };
                    string[] seatnosRet = lblseatNosReturn.Text.Split(separatorRet, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in seatnosRet)
                    {
                        DataRow dr = dtseatsRet.NewRow();
                        dr["SeatNos"] = item;
                        dtseatsRet.Rows.Add(dr);
                    }
                    if (dtseatsRet != null)
                    {
                        rptrPsgrDetailsReturn.DataSource = dtseatsRet;
                        rptrPsgrDetailsReturn.DataBind();
                    }
                }
                else//OneWay
                {
                    pnlreturnticketdetails.Visible = false;
                }
            }

            #endregion
        }
    }
    DateTime dt;
    protected void btnProceedToPayment_Click(object sender, EventArgs e)
    {
        try
        {
            int? createdBy = null;
            if (Session["UserID"] != null) { createdBy = Convert.ToInt32(Session["UserID"].ToString()); }

            if (Session["RedBusBookingDetails"] != null)
            {
                BookingDetails = (String[])Session["RedBusBookingDetails"];
                string gridviewdata = client.getBoardingPoint(BookingDetails[4].Split('~')[1]);
                DataTable dtOnwardBoardingInfo = convertJsonStringToDataSet(gridviewdata).Tables[0];

                string strOnwardBoardingInfo = dtOnwardBoardingInfo.Rows[0]["address"].ToString() + "," +
                     dtOnwardBoardingInfo.Rows[0]["landmark"].ToString();

                String referenceNumber = "";
                String referenceNumberReturn = "";
                referenceNumber = GenerateManabusRefNo();
                string provider = BookingDetails[19].ToString();

                if (BookingDetails[5].ToLower().Contains("single"))
                {
                    Session["Ticketrefno"] = referenceNumber;
                }

                #region OneWayOrRoundTrip

                //SingleTrip
                if (BookingDetails[5].ToLower().Contains("single"))
                {
                    
                    #region onwardTrip
                    String nameList = ""; String genderList = ""; String titleList = ""; String ageList = "";
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
                            nameList += txtPassengerNamerptr.Text;
                            titleList += ddlrptr.SelectedItem.Value.ToString();
                            ageList += txtAgerptr.Text;
                            genderList += ddlrptr.SelectedItem.Text.ToString();
                        }
                        else
                        {
                            ++countlist;
                            nameList += "," + txtPassengerNamerptr.Text;
                            titleList += "," + ddlrptr.SelectedItem.Value.ToString();
                            ageList += "," + txtAgerptr.Text;
                            genderList += "," + ddlrptr.SelectedItem.Text.ToString();
                        }
                    }
                    
                    String passengerDetailsonward = "";
                    BlockSeats blockseats = new BlockSeats();
                    blockseats.SourceId = int.Parse(BookingDetails[10]);
                    blockseats.DestinationId = int.Parse(BookingDetails[11]);
                    blockseats.TripId = BookingDetails[12];
                    blockseats.JourneyDate = BookingDetails[1];
                    blockseats.BoardingId = BookingDetails[4].Split('~')[1];
                    blockseats.NoOfSeats = countlist;
                    blockseats.SeatNo = BookingDetails[2];
                    blockseats.Title = titleList;
                    blockseats.Name = nameList;
                    blockseats.Age = ageList;
                    blockseats.Sex = genderList;
                    blockseats.Address = txtAddress.Text;
                    blockseats.BookingRefNo = referenceNumber;
                    blockseats.IdCardType = ddlIDType.SelectedItem.Text;
                    blockseats.IdCardNo = txtIDNumber.Text;
                    blockseats.IdCardIssuedBy = txtIdIssuedBY.Text;
                    blockseats.MobileNo = txtPhoneNo.Text;
                    blockseats.EmergencyMobileNo = txtPhoneNo.Text;
                    blockseats.EmailId = txtEmailId.Text;
                    blockseats.EmergencyMobileNo = txtEmailId.Text;
                    blockseats.ProviderName = BookingDetails[19].ToString();
                    
                    string var = BuildRequest(int.Parse(BookingDetails[3]), BookingDetails[2], BookingDetails[12],
                                               BookingDetails[4].Split('~')[1], BookingDetails[11].ToString(), BookingDetails[10].ToString()
                                               , nameList, genderList, titleList, ageList, BookingDetails[19].ToString());
                    lblMsg.Text = client.blockTicket(blockseats);
                    if (lblMsg.Text.ToString().Split(' ').Length == 1 && lblMsg.Text.ToString().ToLower() != "tentative booking failed")
                    {
                        string[] strDate = BookingDetails[1].Trim().ToString().Split('-');
                         dt = Convert.ToDateTime(strDate[2] + "-" + strDate[1] + "-" + strDate[0]);

                     

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
                    }
                    string[] str = new string[1];
                    str[0] = " to";
                    String[] cities = BookingDetails[0].ToString().Split(str, StringSplitOptions.None);



                res= InsertTentativeBooking(referenceNumber, Session["Ticketrefno"].ToString(), lblMsg.Text.ToString(), lblMsg.Text.ToString(), "", "", null, "SeatSeller"
                        , BookingDetails[15].ToString(), BookingDetails[14].ToString(), dt
                        , Convert.ToInt32(BookingDetails[10].ToString()), cities[0].ToString()
                        , Convert.ToInt32(BookingDetails[11].ToString()), cities[1].ToString()
                        , lblSeatNos.Text.ToString(), rptPassengersonward.Items.Count, Convert.ToDecimal(lblFare.Text.Trim().ToString()), null
                        , strOnwardBoardingInfo, BookingDetails[4].Split('~')[0].ToString(), nameList, 20, "M", txtPhoneNo.Text.ToString()
                        , txtEmailId.Text.ToString(), txtAddress.Text.ToString()
                        , "", null, 0, 0, rbtnlstpaytype.Text.ToString(), "Cash", "Oneway", createdBy, "Online", "", passengerDetailsonward
                        , ddlIDType.SelectedItem.Text.ToString(), txtIDNumber.Text.ToString(), "", provider);
                if (res == true)
                {                   
                  lblMsg.Text=client.bookTicket(blockseats);
                  if (lblMsg.Text.ToString().Split(' ').Length == 1)
                  {
                      InsertBookedTicketDetails(referenceNumber, lblMsg.Text.ToString());
                      //string CashcouponID = item["CashCouponId"].ToString();

                      pnlmail.Visible = true;

                      GetTicketDetails();



                      lblMsg.Text = "";
                  }
                  else
                  {
                      return; //Booking Failed.
                  }
                }
                    //BlockSeats blockSeats = new BlockSeats();
                    //blockSeats.Address = txtAddress.Text.ToString();
                    //blockSeats.Age = "25";
                    //blockSeats.BoardingId = lblBoardingPoint.ToolTip.ToString();
                    //blockSeats.BookingRefNo = referenceNumber.ToString();
                    //blockSeats.EmailId = txtEmailId.Text;
                    //blockSeats.EmergencyMobileNo = txtPhoneNo.Text;
                    //blockSeats.IdCardIssuedBy = txtIdIssuedBY.Text;
                    //blockSeats.IdCardNo = txtIDNumber.Text;
                    //blockSeats.IdCardType = ddlIDType.SelectedItem.Text;
                    //blockSeats.JourneyDate = lblJourneyDate.Text;
                    //blockSeats.MobileNo = txtPhoneNo.Text;
                    //blockSeats.Name = "Name";
                    //blockSeats.NoOfSeats = rptPassengersonward.Items.Count;
                    //blockSeats.ProviderName = BookingDetails[19].ToString();
                    //blockSeats.SeatNo = lblSeatNos.Text;
                    //blockSeats.Sex = "Male";
                    //blockSeats.SourceId = Convert.ToInt32(BookingDetails[10].ToString());//
                    //blockSeats.Title = "M";
                    //blockSeats.TripId = Convert.ToString(BookingDetails[12].ToString());//
                    //blockSeats.DestinationId = Convert.ToInt32(BookingDetails[11].ToString());//

                    //BusService bus = new BusService();
                    //string blockResponse = bus.BlockTicket(blockSeats);
                    //lblMsg.Text = blockResponse; lblMsg.Visible = true;
                    //if (blockSeats.ProviderName == "TICKETGOOSE")
                    //{
                    //    DataSet ds = convertJsonStringToDataSet(lblMsg.Text);
                    //    if (ds != null)
                    //    {
                    //        if (ds.Tables[0].Rows.Count > 0)
                    //        {
                    //            if (ds.Tables["status"].Rows[0]["code"].ToString().Trim().ToLower() == "200")
                    //            {
                    //                if (ds.Tables[0].Columns.Contains("bookingId"))
                    //                {
                    //                    blockSeats.BookingId = ds.Tables[0].Rows[0]["bookingId"].ToString();
                    //                    lblMsg.Text = lblMsg.Text + "<br/><br/><br/><br/>" + bus.BookTicket(blockSeats);
                    //                }
                    //            }
                    //            else { lblMsg.Text = ds.Tables["status"].Rows[0]["message"].ToString(); }
                    //        }
                    //    }
                    //}
                    //else if (blockSeats.ProviderName == "BITLA")
                    //{
                    //    XmlDocument doc = new XmlDocument();
                    //    doc.LoadXml(lblMsg.Text);
                    //    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    //    DataSet ds = new DataSet();
                    //    ds.ReadXml(xmlReader);
                    //    if (ds != null)
                    //    {
                    //        if (ds.Tables[0].Rows[0][0].ToString().ToLower() == "200")
                    //        {
                    //            lblMsg.Text = lblMsg.Text + "<br/><br/><br/><br/>" + bus.BookTicket(blockSeats);
                    //        }
                    //        else { lblMsg.Text = ds.Tables[0].Rows[0][1].ToString().ToLower(); }
                    //    }
                    //}
                  //  Server.Transfer("~/Users/Bus/redirect.aspx");
                    #endregion
                    
                }
                #endregion
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
    protected void GetCancellationPolicy(string API)
    {
        try
        {
          ClsBAL  ObjManbusBAL = new ClsBAL();
            if (API.Length >= 5)
            {
                ObjManbusBAL.api = API.Substring(0, 5);
            }
            else { ObjManbusBAL.api = API; }
         DataSet   _objDataSet = (DataSet)ObjManbusBAL.GetCancelPercentageByAPI();
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
    protected void GetTicketDetails()
    {
        try
        {
            if (Session["Ticketrefno"] != null)
            {
              ClsBAL  ObjManbusBAL = new ClsBAL();
                ObjManbusBAL.manabusRefNo = Session["Ticketrefno"].ToString();
             DataSet   _objDataSetBook = (DataSet)ObjManbusBAL.GetTicketIdByTicketrefNo();
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
                                imgKesineni.Visible = true;
                            }

                            Mail(_objDataSetBook.Tables[0].Rows[0]["EmailId"].ToString());

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

            ClsBAL objBAL = new ClsBAL();
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
string emailid, string address, string status, DateTime? responsedatetime, int? cashCouponId, int? promoCodeId, string deliveryType, string paymentType, string tripType,
int? createdBy, string saleType, string servicenumber, string passengerInfo, string Idtype, string IdNumber, string PrimaryPassengerseat,string Provider)
    {
        try
        {
            ClsBAL  objTicketBAL = new ClsBAL();
            objTicketBAL.OnewayMBRefNo = onewayrefNo;
            objTicketBAL.PGMBRefNo = pGRefNo;
            objTicketBAL.blockedId = blockedId;
            objTicketBAL.ticketId = ticketId;
            objTicketBAL.serviceId = serviceId;
            objTicketBAL.serviceTranDateId = serviceTransDateId;
            objTicketBAL.coachTypeId = coachTypeId;
            objTicketBAL.api = Api;
            objTicketBAL.travelName = travelName;
            objTicketBAL.busType = busType;
            objTicketBAL.dateOFJourney = doJ;
            objTicketBAL.sourceId = sourceId;
            objTicketBAL.sourceName = sourceName;
            objTicketBAL.destionationId = destinationId;
            objTicketBAL.destinationName = destinationName;
            objTicketBAL.bookedSeats = bookedSeats;
            objTicketBAL.noOfSeats = noofSeats;
            objTicketBAL.boardingPointId = bordingpointId;
            objTicketBAL.totalbasicFare = Convert.ToDecimal(basicFare);
            objTicketBAL.boardingpointinfo = boardingpointInfo;
            objTicketBAL.boardingPoint = boradingPoint;
            objTicketBAL.fullName = fullname;
            objTicketBAL.age = Convert.ToInt32(age);
            objTicketBAL.gender = gender;
            objTicketBAL.mobileNo = mobileNo;
            objTicketBAL.emailId = emailid;
            objTicketBAL.address = address;
            objTicketBAL.status = status;
            objTicketBAL.responsedatetime = responsedatetime;
            objTicketBAL.cashcouponId = cashCouponId;
            objTicketBAL.promoCodeId = promoCodeId;
            objTicketBAL.deliveryType = deliveryType;
            objTicketBAL.type = tripType;
            objTicketBAL.paymentType = paymentType;
            objTicketBAL.saleType = saleType;
            objTicketBAL.createdBy = createdBy;
            objTicketBAL.serviceNumber = servicenumber;
            objTicketBAL.IDType = Idtype;
            objTicketBAL.IDNumber = IdNumber;
            objTicketBAL.IDIssuedBy = txtIdIssuedBY.Text.ToString();
            objTicketBAL.PrimaryPassengerSeat = PrimaryPassengerseat;
            objTicketBAL.passengerDetails = passengerInfo;
            objTicketBAL.ProviderName = Provider;
            if (objTicketBAL.AddTentativeBooking())
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

    
    private String BuildRequest(int fare, String seatnos, string availableTrip_Id, string bordingpoint_id, string destinationcity, string sourcecity
   , String nameList, String genderList, String titleList, String ageList, string Providername)
    {
        fare = fare / seatnos.Split(',').Length;
        String[] names = nameList.ToString().Split(',');
        String[] genders = genderList.ToString().Split(',');
        String[] titles = titleList.ToString().Split(',');
        String[] ages = ageList.ToString().Split(',');

        StringBuilder inventoryItemsString = new StringBuilder();
        inventoryItemsString.Append("[");

        if (seatnos.Contains(","))
        {
            for (int i = 0; i < seatnos.Split(',').Length; i++)
            {
                inventoryItemsString.Append("{");
                inventoryItemsString.Append("\"fare\":\"" + fare);
                inventoryItemsString.Append("\",\"ladiesSeat\":\"false\",");
                if (i == 0)
                {
                    inventoryItemsString.Append("\"passenger\":{\"address\":\"" + txtAddress.Text.ToString() + "\",");//

                    inventoryItemsString.Append("\"age\":\"" + ages[i].ToString() + "\",");

                    inventoryItemsString.Append("\"email\":\"" + txtEmailId.Text + "\",");//

                    inventoryItemsString.Append("\"gender\":\"" + genders[i] + "\",\"idNumber\":\"" + txtIDNumber.Text.ToString() + "\",\"idType\":\"" + ddlIDType.SelectedItem.Text.ToString() + "\",");

                    inventoryItemsString.Append("\"mobile\":\"" + txtPhoneNo.Text + "\",");//

                    inventoryItemsString.Append("\"name\":\"" + names[i] + "\",");

                    inventoryItemsString.Append("\"primary\":\"true\",");

                    inventoryItemsString.Append("\"title\":\"" + titles[i] );

                  //  inventoryItemsString.Append("\"ProviderName\":\"" + Providername);
                }
                else
                {
                    inventoryItemsString.Append("\"passenger\":{");

                    inventoryItemsString.Append("\"age\":\"" + ages[i] + "\",");

                    inventoryItemsString.Append("\"email\":\"" + txtEmailId.Text + "\",");//

                    inventoryItemsString.Append("\"gender\":\"" + genders[i] + "\",");

                    inventoryItemsString.Append("\"mobile\":\"" + txtPhoneNo.Text + "\",");//

                    inventoryItemsString.Append("\"name\":\"" + names[i] + "\",");

                    inventoryItemsString.Append("\"primary\":\"false\",");

                    inventoryItemsString.Append("\"title\":\"" + titles[i]);
                }
                inventoryItemsString.Append("\"},");
                int j = i + 1;
                inventoryItemsString.Append("\"seatName\":\"" + seatnos.Split(',')[i] + "\"},");
            }
        }
        else
        {
            inventoryItemsString.Append("{");

            inventoryItemsString.Append("\"fare\":\"" + fare);

            inventoryItemsString.Append("\",\"ladiesSeat\":\"false\",");

            inventoryItemsString.Append("\"passenger\":{\"address\":\"" + txtAddress.Text.ToString() + "\",");//

            inventoryItemsString.Append("\"age\":\"" + ages[0] + "\",");

            inventoryItemsString.Append("\"email\":\"" + txtEmailId.Text + "\",");//

            inventoryItemsString.Append("\"gender\":\"" + genders[0] + "\",\"idNumber\":\"" + txtIDNumber.Text.ToString() + "\",\"idType\":\"" + ddlIDType.SelectedItem.Text.ToString() + "\",");

            inventoryItemsString.Append("\"mobile\":\"" + txtPhoneNo.Text + "\",");//

            inventoryItemsString.Append("\"name\":\"" + names[0] + "\",");

            inventoryItemsString.Append("\"primary\":\"true\",");

            inventoryItemsString.Append("\"title\":\"" + titles[0]);

            inventoryItemsString.Append("\"},");

            inventoryItemsString.Append("\"seatName\":\"" + seatnos + "\"},");
        }
        inventoryItemsString.Remove(inventoryItemsString.Length - 1, 1);
        inventoryItemsString.Append("],");

        string makeBlockRequest = "{\"availableTripId\":\"" + availableTrip_Id + "\",\"boardingPointId\":\"" + bordingpoint_id + "\",\"destination\":\"" + destinationcity + "\",\"inventoryItems\":" + inventoryItemsString + "\"source\":\"" + sourcecity + "\"}";
        return makeBlockRequest;
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

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }

    protected void chkPromoCode_CheckedChanged(object sender, EventArgs e) { }

    protected void btnPromoCode_Click(object sender, EventArgs e) { }

    protected void chkCashpay_CheckedChanged(object sender, EventArgs e) { }

    protected void rbtnlstpaytype_SelectedIndexChanged(object sender, EventArgs e) { }

    protected void chkDealCode_CheckedChanged(object sender, EventArgs e) { }
    protected void btnDealCode_Click(object sender, EventArgs e) { }
    protected void chkCashCoupon_CheckedChanged(object sender, EventArgs e) { }
    protected void btncashcoupon_Click(object sender, EventArgs e) { }

    protected void rptPassengersonward_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
    protected void rptrPsgrDetailsReturn_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
    protected void rptrPsgrDetailsReturn0_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
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
    
}