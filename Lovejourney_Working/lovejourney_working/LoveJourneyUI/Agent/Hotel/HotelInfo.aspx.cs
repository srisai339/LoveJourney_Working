using System;
using System.Data;
using HotelAPILayer;
using BAL;

public partial class Agent_Hotel_HotelInfo : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Hotel - HotelInfo";
        if (!IsPostBack)
        {
            if (Session["SelectedHotelParams"] != null && Session["SearchParams"] != null)
            {
                DataTable dtSelectedHotelDetails = (DataTable)Session["SelectedHotelParams"];
                string[] strValues = Session["SearchParams"].ToString().Split(':');

                DataRow dr = dtSelectedHotelDetails.Rows[0];

                lblHotelName.Text = dr["hotelName"].ToString();
                lblAddress.Text = dr["hotelAddress"].ToString();
                lblCheckIn.Text = strValues[1].ToString();
                lblCheckOut.Text = strValues[2].ToString();


                ////rajini

                //TimeSpan timespan = Convert.ToDateTime(strValues[2].ToString()).Subtract(Convert.ToDateTime(strValues[1].ToString()));
                //int NOofdays = timespan.Days ;

                //lblTotalPrice.Text = (Convert.ToDouble(dr["totalINR"].ToString()) * Convert.ToDouble(NOofdays)).ToString();

                ////Rajini end


                lblRoomType.Text = dr["roomType"].ToString();
                lblStar.Text = dr["hotelStar"].ToString() + " Star";
                lblTotalPrice.Text = dr["totalINRAgent"].ToString();// +" |||| " + dr["totalINR"].ToString();
                lblNoOfRooms.Text = strValues[3].ToString();
                lblCityOfHotel.Text = "<b>Hotel City</b> :" + strValues[0].ToString();
                int noOfAdults = 0;
                int noOfChilds = 0;

                int noOfRooms = Convert.ToInt32(strValues[3].ToString());
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

                    noOfAdults += Convert.ToInt32(strValues[4 + j].ToString());
                    noOfChilds += Convert.ToInt32(strValues[5 + j].ToString());
                }

                lblPaxGreaterThan12.Text = noOfAdults.ToString();
                lblPaxLessThan12.Text = noOfChilds.ToString();

                string hotelId = ""; string webService = ""; string ratePlanType = "";
                string roomTypeCode = ""; string checkInDate = ""; string checkOutDate = "";

                hotelId = dr["hotelId"].ToString();
                webService = dr["webService"].ToString();
                ratePlanType = dr["ratePlanCode"].ToString();
                roomTypeCode = dr["roomTypeCode"].ToString();
                checkInDate = ConvertDate(lblCheckIn.Text.ToString());
                checkOutDate = ConvertDate(lblCheckOut.Text.ToString());

                DataSet dsPolicy = objArzooHotelAPILayer.GetHotelPolicy(hotelId, webService, ratePlanType, roomTypeCode, checkInDate, checkOutDate);

                if (dsPolicy.Tables.Contains("HotelPolicy"))
                {
                    gvPolicy.DataSource = dsPolicy.Tables["HotelPolicy"];
                    gvPolicy.DataBind();
                }
            }
            else { Response.Redirect("Default.aspx", false); }
        }
    }
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
            if (Session["SelectedHotelParams"] != null && Session["SearchParams"] != null)
            {
                DataTable dtSelectedHotelDetails = (DataTable)Session["SelectedHotelParams"];
                string[] strValues = Session["SearchParams"].ToString().Split(':');

                DataRow dr = dtSelectedHotelDetails.Rows[0];

                string hotelId = dr["hotelId"].ToString();
                string hotelName = dr["hotelName"].ToString();

                string hotelAddress = dr["hotelAddress"].ToString();
                string hotelStar = dr["hotelStar"].ToString();
                //Rajini

                string hotelTotalFare = dr["totalINR"].ToString();

                string hotelTotalFareAgent = dr["totalINRAgent"].ToString();
                string markUp = dr["markUp"].ToString();

                // string hotelTotalFare = lblTotalPrice.Text;

                //Rajini
                string roomType = dr["roomType"].ToString();
                string webService = dr["webService"].ToString();

                string fromDate = ConvertDate(strValues[1].ToString());
                string toDate = ConvertDate(strValues[2].ToString());
                string cityName = strValues[0].ToString();

                string roomTypeCode = dr["roomTypeCode"].ToString();
                string ratePlanCode = dr["ratePlanCode"].ToString();
                string validDays = dr["validDays"].ToString();
                string wsKey = dr["wsKey"].ToString();

                string extGuestTotal = dr["extGuestTotal"].ToString();
                string roomTotal = dr["roomTotal"].ToString();
                string serviceTaxTotal = dr["serviceTaxTotal"].ToString();
                string discount = dr["discount"].ToString();
                string commission = dr["commission"].ToString();

                string title = ddlUserTitle.SelectedItem.Text.ToString();
                string firstName = txtUserFirstName.Text.ToString();
                string middleName = txtUserMiddleName.Text.ToString();
                string lastName = txtUserLastName.Text.ToString();
                string phNoCountryCode = "91";
                string phNoAreaCode = "91";
                string phoneNumber = txtUserPhoneNumber.Text.ToString();
                string phNoExtension = "91";
                string emailId = txtUserEmailId.Text.ToString();

                string custAddressLine = txtUserAddress.Text.ToString();
                string custCity = txtUserCity.Text.ToString();
                string custZipCode = txtUserPinCode.Text.ToString();
                string custState = ddlState.SelectedItem.Text.ToString();

                string custCountry = "India";

                string roomBasis = dr["roomBasis"].ToString();

                int noOfRooms = Convert.ToInt32(strValues[3].ToString());

                int[] noOfAdultsInARoom = new int[noOfRooms];
                int[] noOfChildsInARoom = new int[noOfRooms];
                int[] firstChildAge = new int[noOfRooms];
                int[] secondChildAge = new int[noOfRooms];
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

                int noOfAdults = 0;
                int noOfChilds = 0;
                int jj = 0;
                for (int i = 0; i < noOfRooms; i++)
                {
                    if (i == 0)
                    {
                        jj = 0;
                    }
                    else
                    {
                        jj = 4 * i;
                    }

                    noOfAdults += Convert.ToInt32(strValues[4 + j].ToString());
                    noOfChilds += Convert.ToInt32(strValues[5 + j].ToString());
                }

                DataSet dsHotelProvisional = objArzooHotelAPILayer.HotelProvisional(hotelId, roomType, webService, fromDate, toDate, roomTypeCode, ratePlanCode
                    , validDays, wsKey, extGuestTotal, roomTotal, serviceTaxTotal, discount, commission, title, firstName, middleName, lastName, phNoCountryCode
                    , phNoAreaCode, phoneNumber, phNoExtension, emailId, custAddressLine, custCity, custZipCode, custState, custCountry
                    , noOfRooms, noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge);

                if (dsHotelProvisional.Tables.Contains("HotelProvisional"))
                {
                    DataTable dt = dsHotelProvisional.Tables["HotelProvisional"];
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        string wsKeyResult = ""; string allocavailResult = ""; string allocidResult = ""; string errorResult = "";
                        wsKeyResult = dt.Rows[0]["wsKey"].ToString();
                        allocavailResult = dt.Rows[0]["allocavail"].ToString();
                        allocidResult = dt.Rows[0]["allocid"].ToString();
                        errorResult = dt.Rows[0]["error"].ToString();
                        if (errorResult == "")
                        {
                            string st = ""; string hotelRefNo = Common.GenerateHotelRefNo();
                            st = InsertProvisional(hotelRefNo, cityName, Convert.ToDateTime(strValues[1].ToString()), Convert.ToDateTime(strValues[2].ToString())
                                , noOfRooms, noOfAdults, noOfChilds, Session["SearchParams"].ToString(), hotelId, webService, ratePlanCode,
                                roomTypeCode, allocavailResult, allocidResult
                                , roomType, wsKey, roomBasis, title, firstName, middleName, lastName, phoneNumber, emailId, custAddressLine
                                , custCity, custZipCode, custState, custCountry, "0", Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()),
                                hotelName, hotelAddress, hotelStar
                                , hotelTotalFare.Split('~')[0].ToString(), hotelTotalFare.Split('~')[1].ToString()
                                , hotelTotalFareAgent.Split('~')[0].ToString(), hotelTotalFareAgent.Split('~')[1].ToString()
                                , markUp);

                            if (st == "Success")
                            {
                                Session["HotelRefNo"] = hotelRefNo;
                                Response.Redirect("HotelTicket.aspx", false);
                            }
                            else { lblMsg.Text = "Please Try Again."; }
                        }
                        else
                        {
                            // lblMsg.Text = errorResult;
                            lblMsg.Text = "Please Contact Administrator";
                        }
                    }
                    else { lblMsg.Text = "Please try again."; }
                }
                else if (dsHotelProvisional.Tables.Contains("Error"))
                {
                    lblMsg.Text = "Please try again.";
                }
            }
            else { Response.Redirect("Default.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    public string InsertProvisional(string referenceNo, string hotelCity, DateTime checkIn, DateTime checkOut, int noOfRooms, int? noOfAdults
        , int? noOfChildren, string roomStayCandidate, string hotelId, string webService, string ratePlanType, string roomTypeCode, string fromAllocation
        , string allocationId, string roomType, string wsKey, string roomBasis, string title, string firstName, string middleName, string lastName
        , string mobileNumber, string emailId, string custAddressLine, string custCity, string custZipCode, string custState, string custCountry, string comment
        , int? createdBy, int? modifiedBy, string hotelName, string hotelAddress, string hotelStar, string hotelTotalFare, string hotelTotalFareDetails
        , string hotelTotalFareAgent, string hotelTotalFareDetailsAgent, string markUpFareAgent)
    {
        try
        {
            string strReturn = "";
            HotelBAL obj = new HotelBAL();

            obj.ReferenceNo = referenceNo;
            obj.HotelCity = hotelCity;
            obj.CheckIn = checkIn;
            obj.CheckOut = checkOut;
            obj.NoOfRooms = noOfRooms;
            obj.NoOfAdults = noOfAdults;
            obj.NoOfChildren = noOfChildren;
            obj.RoomStayCandidate = roomStayCandidate;
            obj.HotelId = hotelId;
            obj.WebService = webService;
            obj.RatePlanType = ratePlanType;
            obj.RoomTypeCode = roomTypeCode;
            obj.FromAllocation = fromAllocation;
            obj.AllocationId = allocationId;
            obj.RoomType = roomType;
            obj.WsKey = wsKey;
            obj.RoomBasis = roomBasis;
            obj.Title = title;
            obj.FirstName = firstName;
            obj.MiddleName = middleName;
            obj.LastName = lastName;
            obj.MobileNumber = mobileNumber;
            obj.EmailId = emailId;
            obj.CustAddressLine = custAddressLine;
            obj.CustCity = custCity;
            obj.CustZipCode = custZipCode;
            obj.CustState = custState;
            obj.CustCountry = custCountry;
            obj.Comment = comment;
            obj.CreatedBy = createdBy;
            obj.ModifiedBy = modifiedBy;
            obj.HotelName = hotelName;
            obj.HotelAddress = hotelAddress;
            obj.HotelStar = hotelStar;
            obj.HotelTotalFare = hotelTotalFare;
            obj.HotelTotlaFareDetails = hotelTotalFareDetails;

            bool b = obj.AddHotelProvisionalAgent(hotelTotalFareAgent, hotelTotalFareDetailsAgent, markUpFareAgent);
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Agent/Hotel/Hotels.aspx", false);
    }
}