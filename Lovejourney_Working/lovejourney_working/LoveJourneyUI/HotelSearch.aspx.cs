﻿using System;
using System.Data;
using HotelAPILayer;
using System.Web.Services;
using System.Collections.Generic;
using BAL;

public partial class HotelSearch : System.Web.UI.Page
{
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
      //  pnlHeader.Visible = false;
        ///Menus visible true or false
        Guestfooter.Visible  = GuestHeader2.Visible = false;
        AdminHeader.Visible = AgentHeader.Visible = LoggedUserFooter.Visible = false;

        if (Session["UserID"] != null)
        {
            tblicons.Visible = false;
            Guestfooter.Visible  = GuestHeader2.Visible = false;

            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor")
            {
                User_menu.Visible = false;
                AdminHeader.Visible = true;
                lblUsername.Text ="Welcome"  +Session["UserName"].ToString();
                GuestHeader1.Visible = false;
                GuestHeader2.Visible = true;
               



                if (Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor") 
                {
                    city.Visible = carm.Visible = description.Visible = policy.Visible = false;
                    User_menu.Visible = false;
                    liuserinfo.Visible = false;
                    Cashcoupon.Visible = false;
                    lipromocode.Visible = false;
                    licse.Visible = false;
                    liReports1.Visible = false;
                    lisubmenuAgentReports.Visible = false;
                    liagents.Visible = false;
                    liuserreports.Visible = true;
                    lisubmenureports.Visible = false;
                    Tddmr.Visible = false;
                    lirecharge.Visible = false;
                    viewagents.Visible = false; agentdeposits.Visible = false; agentrequests.Visible = false; fundtransferreport.Visible = false; stopservices.Visible = false;
                    if (Session["Role"].ToString() == "Distributor")
                    {
                        viewagents.Visible = true; 
                        lirecharge.Visible = true;
                        liagents.Visible = true;
                        Tddmr.Visible = true;
                        lblBal.Text = "Your balance is : " + " " + Session["Balance"].ToString();
                        DistDeposits.Visible = DistDmr.Visible = DistProfile.Visible = DistLoginHistory.Visible = true;
                        lifeedback.Visible = false;
                    }

                }
                else
                {
                    viewagents.Visible = true; agentdeposits.Visible = true; agentrequests.Visible = true; fundtransferreport.Visible = true; stopservices.Visible = true; 
                    lirecharge.Visible = true;
                    liuserinfo.Visible = true;
                    Cashcoupon.Visible = true;
                    lipromocode.Visible = true;
                    licse.Visible = true;
                    liReports1.Visible = true;
                    lisubmenuAgentReports.Visible = true;
                    liagents.Visible = true;
                    liuserreports.Visible = false;
                    lisubmenureports.Visible = true;
                    Tddmr.Visible = true;
                }


            }
            else if (Session["Role"].ToString() == "Agent")
            {
                User_menu.Visible = false;
                AgentHeader.Visible = true;
                lblAgentUserName.Text = Session["UserName"].ToString();
                lblBalance.Text = Session["Balance"].ToString();
                GuestHeader1.Visible = false;
                movietiket.Visible = false;
            }

            LoggedUserFooter.Visible = true;
        }
        else
        {
            tblicons.Visible = true;

            User_menu.Visible = true;
            Guestfooter.Visible  = GuestHeader2.Visible = true;
            LoggedUserFooter.Visible = false; Guestfooter.Visible = true;
        }
        ///Menus visible true or false

        if (!IsPostBack)
        {
            getservices();
            if (val != "true")
            {
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
            }
            else
            {
                tdmsg.Visible = true;
                lblMainMsg.Text = "This Service is temporarily unavaliable";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                //pnlMain.Visible = false;
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
    [WebMethod]
    public static HotelDetails[] GetHotels(String args)
    {
        try
        {
            string[] strValues = args.Split('&');

            List<HotelDetails> details = new List<HotelDetails>();

            IArzooHotelAPILayer objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
            objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
            objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
            objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
            objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
            objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;

            string startDate = strValues[1].ToString();
            string endDate = strValues[2].ToString();

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

            string cityName = strValues[0].ToString();
            string hotelName = "";
            string area = "";
            string rating = "";

            DataSet dsHotelAvailSearch = objArzooHotelAPILayer.GetHotelAvailSearch(ConvertDate1(startDate), ConvertDate1(endDate), noOfRooms,
                noOfAdultsInARoom, noOfChildsInARoom, firstChildAge, secondChildAge, cityName, hotelName, area, rating);

            if (!dsHotelAvailSearch.Tables.Contains("Error"))
            {
                foreach (DataRow item in dsHotelAvailSearch.Tables["Hotels"].Rows)
                {
                    HotelDetails hotel = new HotelDetails();
                    hotel.HotelId = item["hotelid"].ToString();
                    hotel.HotelName = item["hotelname"].ToString();
                    hotel.HotelDescription = item["hoteldesc"].ToString();

                    hotel.HotelChain = item["hotelchain"].ToString();
                    hotel.StarRating = item["starrating"].ToString();
                    hotel.NoOfRooms = item["noofrooms"].ToString();

                    hotel.MinRate = item["minRate"].ToString();
                    hotel.Rph = item["rph"].ToString();
                    hotel.WebService = item["webService"].ToString();

                    hotel.Facilities = item["facilities"].ToString();
                    hotel.hotel_Id = item["hotel_Id"].ToString();
                    hotel.hoteldetail_Id = item["hoteldetail_Id"].ToString();

                    hotel.Address = item["address"].ToString();
                    hotel.PinCode = item["pincode"].ToString();
                    hotel.CityWiseLocation = item["citywiselocation"].ToString();

                    hotel.LocationInfo = item["locationinfo"].ToString();
                    hotel.Phone = item["phone"].ToString();
                    hotel.Fax = item["fax"].ToString();
                    hotel.Email = item["email"].ToString();
                    hotel.Website = item["website"].ToString();

                    hotel.ImageDesc = item["imagedesc"].ToString();
                    hotel.ImagePath = item["imagepath"].ToString();
                    hotel.images_Id = item["images_Id"].ToString();
                    hotel.CheckInTime = item["checkintime"].ToString();

                    hotel.CheckOutTime = item["checkouttime"].ToString();
                    hotel.CreditCards = item["creditcards"].ToString();
                    hotel.HotelServices = item["hotelservices"].ToString();
                    hotel.RoomServices = item["roomservices"].ToString();

                    details.Add(hotel);
                }
            }
            System.Web.HttpContext.Current.Session["Hotels"] = details.ToArray();
            if (details.ToArray().Length > 20)
            {
                return details.GetRange(0, 20).ToArray();
            }
            else { return details.ToArray(); }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
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
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
}

public class HotelDetails
{
    public string HotelId { get; set; }
    public string HotelName { get; set; }
    public string HotelDescription { get; set; }

    public string HotelChain { get; set; }
    public string StarRating { get; set; }
    public string NoOfRooms { get; set; }

    public string MinRate { get; set; }
    public string Rph { get; set; }
    public string WebService { get; set; }

    public string Facilities { get; set; }
    public string hotel_Id { get; set; }
    public string hoteldetail_Id { get; set; }

    public string Address { get; set; }
    public string PinCode { get; set; }
    public string CityWiseLocation { get; set; }

    public string LocationInfo { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }

    public string ImageDesc { get; set; }
    public string ImagePath { get; set; }
    public string images_Id { get; set; }
    public string CheckInTime { get; set; }

    public string CheckOutTime { get; set; }
    public string CreditCards { get; set; }
    public string HotelServices { get; set; }
    public string RoomServices { get; set; }
}