using System;
using System.Data;
using HotelAPILayer;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BAL;

public partial class Agent_Hotel_HotelSearch : System.Web.UI.Page
{
    ClsBAL objManabusBAL;
    //  DataSet ObjDataset;
    IArzooHotelAPILayer objArzooHotelAPILayer;
    clsMasters _objMasters;
    DataSet _objDataSet;
    static string val = "false";
    protected void Page_Load(object sender, EventArgs e)
    {


        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        this.Page.Title = "LoveJourney - Hotel - Search";
        {
            if (Session["UserID"] != null && Session["Role"] != null)
            {
                if (Session["UserID"].ToString() != "INVALID USER"
                    && Session["Role"].ToString() == "Agent")
                {
                    if (Session["UserName"] != null)
                    {
                        lblUsername.Text = "Welcome <b>" + Session["UserName"].ToString() + " </b>";
                        lblBalance.Text = "" + Session["Balance"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        if (!IsPostBack)
        {
            if (Session["HotelsAgentStatus"] == null) { Response.Redirect("~/Default.aspx", false); return; }
            if (Session["HotelsAgentStatus"].ToString() != "0")
            {

                getservices();
                if (val != "true")
                {
                    tdmsg.Visible = false;
                    tblmain.Visible = true;
                    #region HotelAvailSearch
                    string startDate = "29/09/2012";
                    string endDate = "30/09/2012";

                    int noOfRooms = 2;

                    int[] noOfAdultsInARoom = new int[noOfRooms];
                    noOfAdultsInARoom[0] = 2; noOfAdultsInARoom[1] = 0;

                    int[] noOfChildsInARoom = new int[noOfRooms];
                    noOfChildsInARoom[0] = 0; noOfChildsInARoom[1] = 2;

                    int[] firstChildAge = new int[noOfRooms];
                    firstChildAge[0] = 10; firstChildAge[1] = 4;

                    int[] secondChildAge = new int[noOfRooms];
                    secondChildAge[0] = 12; secondChildAge[1] = 6;

                    string cityName = "Hyderabad";
                    string hotelName = "";
                    string area = "";
                    string rating = "";

                    //DataSet dsHotelAvailSearch = objArzooHotelAPILayer.GetHotelAvailSearch(startDate, endDate, noOfRooms, noOfAdultsInARoom, noOfChildsInARoom,
                    //firstChildAge, secondChildAge, cityName, hotelName, area, rating);
                    #endregion

                    #region HotelDetails
                    string hotelId = "00003814"; //00003814,00008228,00002109,00006345,00005117,00008510,00003553,00004138
                    string webService = "arzooB";
                    //DataSet dsHotelDetails = objArzooHotelAPILayer.GetHotelDetails(hotelId, webService, cityName);
                    #endregion

                    #region HotelPolicy
                    string roomTypeCode = "0000013116";
                    string ratePlanType = "0000046915";
                    //DataSet dsHotelPolicy = objArzooHotelAPILayer.GetHotelPolicy(hotelId, webService, ratePlanType, roomTypeCode, startDate, endDate);
                    #endregion

                    #region HotelProvisional
                    string roomType = "Superior Double Room";
                    string roomBasis = "Breakfast, Complimentary tea / coffee maker in the room, Complimentary in-room internet, Complimentary use of Health Club, Gymnasium and Swimming pool";
                    string validDays = "11111111";
                    string wsKey = "Y20QQhVcx8o6eaST9cxEwEzqngWA9ZIGxDrDapJ4gq5r9ZWgWVwYbMQ6w2qSeIKumiyWPmQB9TPi/IsooseEjL0DGWrmSBV5D59NmCHWe6lPuT6OzXspSHCdUHHYpL1/n4KACQv3zPaXdy9UWBezV89+icUuhLgw/Krs4KYW64bEOsNqkniCrmj+/qF6X9ZwpzpzGizlSlr7cB0CvrXs09JAHo6LORdOWX4TN4803wDiFT3cZZUXkv53qVDwWkgJLnygygrzVhz9ZxeBT///KMLb1Ndh1GWueRfRkx9Pa7g0GnVMWcfDl9Kwj4E6zbFcwtvU12HUZa55F9GTH09ruIP7HOtOxFSg01yzXjfUO0D3FiYZuv+U87vpUHIZTppH/pIzqd16OKMKFbufX9740esPZgaWJ5fNxDrDapJ4gq6Z1y3BqtQnN/Rrjn3GwXyWlWhM0grn0WKsiQfpa3a2UMrNQyd/IIjYv+S6D3pWOfTDIqBVqMSB48X/9aX/yzZW3b6p6V6YDgLEOsNqkniCrmgs0lekXI2Ot9pnaZjxvgBH5BF+2jFuxeokonr4/8S0SUMlDEl48Dk9WlMsE495QfflIYqwnPKw3ElAxjIdqEPhQY4rE0SKTg==";

                    string extGuestTotal = "0";
                    string roomTotal = "3512";
                    string serviceTaxTotal = "447";
                    string discount = "0.0";
                    string commission = "0";

                    string title = "Mr";
                    string firstName = "Raju";
                    string middleName = "Katare";
                    string lastName = "KatareRaju";
                    string phNoCountryCode = "91";
                    string phNoAreaCode = "91";
                    string phoneNumber = "9985623799";
                    string phNoExtension = "98";
                    string emailId = "prasad@lovejourney.in";
                    string custAddressLine = "KPHB,Hyderabad";
                    string custCity = "Hyderabad";
                    string custZipCode = "500001";
                    string custState = "AndhraPradesh";
                    string custCountry = "India";

                    //DataSet dsHotelProvisional = objArzooHotelAPILayer.HotelProvisional(hotelId, roomType, webService, startDate, endDate, roomTypeCode, ratePlanType
                    //    , validDays, wsKey, extGuestTotal, roomTotal, serviceTaxTotal, discount, commission, title, firstName, middleName, lastName, phNoCountryCode
                    //    , phNoAreaCode, phoneNumber, phNoExtension, emailId, custAddressLine, custCity, custZipCode, custState, custCountry
                    //    , noOfRooms, noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge);
                    #endregion

                    #region HotelBooking
                    string fromAllocation = "Y";
                    string allocId = "35";
                    //DataSet dsHotelBooking = objArzooHotelAPILayer.HotelBooking(hotelId, webService, ratePlanType, roomTypeCode, cityName, fromAllocation, allocId, startDate, endDate, roomType,
                    //    wsKey, roomBasis, title, firstName, middleName, lastName, noOfRooms, noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge);
                    #endregion

                    #region HotelCancellation
                    string bookingRef = "ARZ0000245960";
                    //DataSet dsHotelCancellation = objArzooHotelAPILayer.HotelCancellation(emailId, lastName, bookingRef, webService, startDate, endDate);
                    #endregion
                }
                else
                {
                    tdmsg.Visible = true;
                    lblMainMsg.Text = "This Service is temporarily unavaliable";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    tblmain.Visible = false;
                }
            }
            else
            {
                tdmsg.Visible = true;
                lblMainMsg.Text = "This Service is temporarily unavaliable";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                tblmain.Visible = false;
            }


        }

    }


    protected void getservices()
    {
        try
        {
            val = "false";
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Getservices;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < _objDataSet.Tables[0].Rows.Count; i++)
                        {
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "Hotels" && _objDataSet.Tables[0].Rows[i]["Status"].ToString() == "1")
                            {
                                val = "true";
                            }
                        }

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    //[WebMethod]
    //public static HotelDetails[] GetHotels(String args)
    //{
    //    try
    //    {
    //        string[] strValues = args.Split('&');

    //        List<HotelDetails> details = new List<HotelDetails>();

    //        IArzooHotelAPILayer objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
    //        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
    //        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
    //        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
    //        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
    //        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;

    //        string startDate = strValues[1].ToString();
    //        string endDate = strValues[2].ToString();

    //        int noOfRooms = Convert.ToInt32(strValues[3].ToString());

    //        int[] noOfAdultsInARoom = new int[noOfRooms];
    //        int[] noOfChildsInARoom = new int[noOfRooms];
    //        int[] firstChildAge = new int[noOfRooms];
    //        int[] secondChildAge = new int[noOfRooms];
    //        int j = 0;
    //        for (int i = 0; i < noOfRooms; i++)
    //        {
    //            if (i == 0)
    //            {
    //                j = 0;
    //            }
    //            else
    //            {
    //                j = 4 * i;
    //            }

    //            noOfAdultsInARoom[i] = Convert.ToInt32(strValues[4 + j].ToString());
    //            noOfChildsInARoom[i] = Convert.ToInt32(strValues[5 + j].ToString());
    //            firstChildAge[i] = Convert.ToInt32(strValues[6 + j].ToString());
    //            secondChildAge[i] = Convert.ToInt32(strValues[7 + j].ToString());
    //        }

    //        string cityName = strValues[0].ToString();
    //        string hotelName = "";
    //        string area = "";
    //        string rating = "";

    //        DataSet dsHotelAvailSearch = objArzooHotelAPILayer.GetHotelAvailSearch(ConvertDate1(startDate), ConvertDate1(endDate), noOfRooms,
    //            noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge, cityName, hotelName, area, rating);

    //        if (!dsHotelAvailSearch.Tables.Contains("Error"))
    //        {
    //            foreach (DataRow item in dsHotelAvailSearch.Tables["Hotels"].Rows)
    //            {
    //                HotelDetails hotel = new HotelDetails();
    //                hotel.HotelId = item["hotelid"].ToString();
    //                hotel.HotelName = item["hotelname"].ToString();
    //                hotel.HotelDescription = item["hoteldesc"].ToString();

    //                hotel.HotelChain = item["hotelchain"].ToString();
    //                hotel.StarRating = item["starrating"].ToString();
    //                hotel.NoOfRooms = item["noofrooms"].ToString();

    //                hotel.MinRate = item["minRate"].ToString();
    //                hotel.Rph = item["rph"].ToString();
    //                hotel.WebService = item["webService"].ToString();

    //                hotel.Facilities = item["facilities"].ToString();
    //                hotel.hotel_Id = item["hotel_Id"].ToString();
    //                hotel.hoteldetail_Id = item["hoteldetail_Id"].ToString();

    //                hotel.Address = item["address"].ToString();
    //                hotel.PinCode = item["pincode"].ToString();
    //                hotel.CityWiseLocation = item["citywiselocation"].ToString();

    //                hotel.LocationInfo = item["locationinfo"].ToString();
    //                hotel.Phone = item["phone"].ToString();
    //                hotel.Fax = item["fax"].ToString();
    //                hotel.Email = item["email"].ToString();
    //                hotel.Website = item["website"].ToString();

    //                hotel.ImageDesc = item["imagedesc"].ToString();
    //                hotel.ImagePath = item["imagepath"].ToString();
    //                hotel.images_Id = item["images_Id"].ToString();
    //                hotel.CheckInTime = item["checkintime"].ToString();

    //                hotel.CheckOutTime = item["checkouttime"].ToString();
    //                hotel.CreditCards = item["creditcards"].ToString();
    //                hotel.HotelServices = item["hotelservices"].ToString();
    //                hotel.RoomServices = item["roomservices"].ToString();

    //                details.Add(hotel);
    //            }
    //        }
    //        System.Web.HttpContext.Current.Session["Hotels"] = details.ToArray();
    //        if (details.ToArray().Length > 20)
    //        {
    //            return details.GetRange(0, 20).ToArray();
    //        }
    //        else { return details.ToArray(); }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["SearchParams"] = hdnValues.Value;
            Response.Redirect("Hotels.aspx", false);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    public static string ConvertDate1(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "LogOut")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void lbtnlogout_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
                Session.Abandon();
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkButtonFeedBack_Click(object sender, EventArgs e)
    {
        mp3.Show();

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.name = txtName.Text;
            objManabusBAL.emailId = txtEmail.Text;
            objManabusBAL.mobileNo = txtPhone.Text;
            objManabusBAL.comments = txtComments.Text;
            if (objManabusBAL.AddFeedback())
            {

                lblmsg.Text = "Feedback submitted successfully to admin. Thanks for your feedback.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                txtName.Text = txtEmail.Text = txtPhone.Text = txtComments.Text = "";
            }
            else
            {
                lblmsg.Text = "Failed to send feedback. Please find try again.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        catch (Exception ex)
        {
            throw ex;
        }
    }
}