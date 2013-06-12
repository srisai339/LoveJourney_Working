using System;
using System.Data;
using HotelAPILayer.ArzooHotelAvailSearch;
using HotelAPILayer.ArzooHotelDetails;
using HotelAPILayer.ArzooHotelPolicy;
using HotelAPILayer.ArzooHotelProvisional;
using HotelAPILayer.ArzooHotelBooking;
using HotelAPILayer.ArzooHotelCancellation;
using System.Xml;

namespace HotelAPILayer
{
    public class ArzooHotelAPILayer : IArzooHotelAPILayer
    {
        HotelAvailSearchPortTypeClient objHotelAvailSearchPortTypeClient;
        HotelDetailsPortTypeClient objHotelDetailsPortTypeClient;
        HotelPolicyPortTypeClient objHotelPolicyPortTypeClient;
        HotelProvisionalPortTypeClient objHotelProvisionalPortTypeClient;
        HotelBookingPortTypeClient objHotelBookingPortTypeClient;
        HotelCancellationPortTypeClient objHotelCancellationPortTypeClient;

        #region Properties
        public string UserName { set; get; }
        public string UserType { set; get; }
        public string UserId { set; get; }
        public string Password { set; get; }
        public string PartnerId { set; get; }
        #endregion

        #region Methods
        public DataSet GetHotelAvailSearch(string startDate, string endDate, int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom,
            int[] firstChildAge, int[] secondChildAge, string cityName, string hotelName, string area, string rating)
        {
            try
            {
                #region xmlRequest
                String xmlRequest = "";
                xmlRequest = "<arzHotelAvailReq>" +

                                    "<clientInfo>" +
                                            "<username>" + UserName + "</username>" +
                                            "<userType>" + UserType + "</userType>" +
                                            "<userID>" + UserId + "</userID>" +
                                            "<password>" + Password + "</password>" +
                                            "<partnerID>" + PartnerId + "</partnerID>" +
                                    "</clientInfo>" +

                                    "<requestSegment>" +
                                          "<currency>INR</currency>" +
                                          "<searchType>search</searchType>" +
                                          "<residentOfIndia>true</residentOfIndia>" +

                                          "<stayDateRange>" +
                                                  "<start>" + startDate + "</start>" + //22/09/2012
                                                  "<end>" + endDate + "</end>" + //23/09/2012
                                          "</stayDateRange>" +
                              "<roomStayCandidate>";

                for (int i = 1; i <= noOfRooms; i++)
                {
                    if (Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) != "0")
                    {
                        xmlRequest = xmlRequest +
                                         "<guestDetails>" +
                                                 "<adults>" + Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) + "</adults>" +
                                                 "<child>";//
                        for (int j = 0; j <= Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()); j++)
                        {
                            if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 2)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                                if (j == 1)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(secondChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 1)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 0)
                            {
                                //xmlRequest = xmlRequest + "<age></age>"; //xmlRequest + "<age>-1</age>";
                            }
                        }
                        xmlRequest = xmlRequest + "</child>" +//
                                         "</guestDetails>";
                    }
                }

                xmlRequest = xmlRequest +
                              "</roomStayCandidate>" +
                             "<hotelSearchCriteria>" +
                                      "<hotelCityName>" + cityName + "</hotelCityName>" +
                                      "<hotelName>" + hotelName + "</hotelName>" +
                                      "<area>" + area + "</area>" +
                                      "<attraction></attraction>" +
                                      "<rating>" + Convert.ToString(rating) + "</rating>" +
                                      "<sortingPreference>1" +
                                      "</sortingPreference>" +
                                      "<hotelPackage>Y</hotelPackage>" +
                              "</hotelSearchCriteria>" +

                      "</requestSegment>" +

               "</arzHotelAvailReq>";
                #endregion

                objHotelAvailSearchPortTypeClient = new HotelAvailSearchPortTypeClient();
                String strResponse = objHotelAvailSearchPortTypeClient.getHotelAvailSearch(xmlRequest, "");
                DataSet dsHotelAvailSearch = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                if (dsHotelAvailSearch.Tables.Contains("hoteldetail") && dsHotelAvailSearch.Tables.Contains("contactinfo") && dsHotelAvailSearch.Tables.Contains("images") && dsHotelAvailSearch.Tables.Contains("image")
                    && dsHotelAvailSearch.Tables.Contains("bookinginfo") && dsHotelAvailSearch.Tables.Contains("services") && dsHotelAvailSearch.Tables.Contains("ratedetail") && dsHotelAvailSearch.Tables.Contains("rate")
                    && dsHotelAvailSearch.Tables.Contains("ratebands"))
                {
                    #region dsReturnWithHotelsAndHotelRooms
                    DataTable dtHotels = new DataTable();
                    dtHotels.TableName = "Hotels";

                    dtHotels.Columns.Add("hotelid"); dtHotels.Columns.Add("hotelname"); dtHotels.Columns.Add("hoteldesc");
                    dtHotels.Columns.Add("hotelchain"); dtHotels.Columns.Add("starrating"); dtHotels.Columns.Add("noofrooms");
                    dtHotels.Columns.Add("minRate"); dtHotels.Columns.Add("rph"); dtHotels.Columns.Add("webService");
                    dtHotels.Columns.Add("facilities"); dtHotels.Columns.Add("hotel_Id"); dtHotels.Columns.Add("hoteldetail_Id");

                    dtHotels.Columns.Add("address"); dtHotels.Columns.Add("pincode");
                    dtHotels.Columns.Add("citywiselocation"); dtHotels.Columns.Add("locationinfo"); dtHotels.Columns.Add("phone");
                    dtHotels.Columns.Add("fax"); dtHotels.Columns.Add("email"); dtHotels.Columns.Add("website");

                    dtHotels.Columns.Add("imagedesc"); dtHotels.Columns.Add("imagepath"); dtHotels.Columns.Add("images_Id");

                    dtHotels.Columns.Add("checkintime"); dtHotels.Columns.Add("checkouttime");

                    dtHotels.Columns.Add("creditcards"); dtHotels.Columns.Add("hotelservices"); dtHotels.Columns.Add("roomservices");


                    DataTable dtHotelRooms = new DataTable();
                    dtHotelRooms.TableName = "HotelRooms";
                    dtHotelRooms.Columns.Add("ratetype");
                    dtHotelRooms.Columns.Add("hotelPackage");
                    dtHotelRooms.Columns.Add("roomtype");
                    dtHotelRooms.Columns.Add("roombasis");
                    dtHotelRooms.Columns.Add("roomTypeCode");
                    dtHotelRooms.Columns.Add("ratePlanCode");

                    dtHotelRooms.Columns.Add("hotelid");

                    dtHotelRooms.Columns.Add("rate_Id");
                    dtHotelRooms.Columns.Add("ratedetail_Id");
                    dtHotelRooms.Columns.Add("hotel_Id");
                    dtHotelRooms.Columns.Add("hoteldetail_Id");

                    dtHotelRooms.Columns.Add("validdays");
                    dtHotelRooms.Columns.Add("wsKey");
                    dtHotelRooms.Columns.Add("extGuestTotal");
                    dtHotelRooms.Columns.Add("roomTotal");
                    dtHotelRooms.Columns.Add("servicetaxTotal");
                    dtHotelRooms.Columns.Add("discount");
                    dtHotelRooms.Columns.Add("commission");


                    DataTable dtHotelDetail = dsHotelAvailSearch.Tables["hoteldetail"];
                    DataTable dtContactInfo = dsHotelAvailSearch.Tables["contactinfo"];
                    DataTable dtImages = dsHotelAvailSearch.Tables["images"];
                    DataTable dtImage = dsHotelAvailSearch.Tables["image"];

                    DataTable dtBookingInfo = dsHotelAvailSearch.Tables["bookinginfo"];
                    DataTable dtServices = dsHotelAvailSearch.Tables["services"];
                    DataTable dtRateDetail = dsHotelAvailSearch.Tables["ratedetail"];
                    DataTable dtRate = dsHotelAvailSearch.Tables["rate"];
                    DataTable dtRateBands = dsHotelAvailSearch.Tables["ratebands"];


                    foreach (DataRow dr in dtHotelDetail.Rows)
                    {
                        DataRow drHotel = dtHotels.NewRow();

                        drHotel["hotelid"] = dr["hotelid"].ToString();
                        drHotel["hotelname"] = dr["hotelname"].ToString();
                        drHotel["hoteldesc"] = dr["hoteldesc"].ToString();
                        drHotel["hotelchain"] = dr["hotelchain"].ToString();
                        drHotel["starrating"] = dr["starrating"].ToString();
                        drHotel["noofrooms"] = dr["noofrooms"].ToString();
                        drHotel["minRate"] = dr["minRate"].ToString();
                        drHotel["rph"] = dr["rph"].ToString();
                        drHotel["webService"] = dr["webService"].ToString();
                        drHotel["facilities"] = dr["facilities"].ToString();
                        drHotel["hotel_Id"] = dr["hotel_Id"].ToString();
                        drHotel["hoteldetail_Id"] = dr["hoteldetail_Id"].ToString();

                        string hotel_Id = dr["hotel_Id"].ToString();
                        string hoteldetail_Id = dr["hoteldetail_Id"].ToString();
                        string hotelid = dr["hotelid"].ToString();

                        DataRow[] drContactInfo = dtContactInfo.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drContactInfo)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["address"] = item["address"].ToString();
                                drHotel["pincode"] = item["pincode"].ToString();
                                drHotel["citywiselocation"] = item["citywiselocation"].ToString();
                                drHotel["locationinfo"] = item["locationinfo"].ToString();
                                drHotel["phone"] = item["phone"].ToString();
                                drHotel["fax"] = item["fax"].ToString();
                                drHotel["email"] = item["email"].ToString();
                                drHotel["website"] = item["website"].ToString();
                            }
                        }

                        DataRow[] drImages = dtImages.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        string images_Id = "";
                        foreach (DataRow item in drImages)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                images_Id = item["images_Id"].ToString();
                            }
                        }

                        DataRow[] drImage = dtImage.Select("images_Id = '" + images_Id + "'");
                        foreach (DataRow item in drImage)
                        {
                            if (images_Id == item["images_Id"].ToString())
                            {
                                drHotel["imagedesc"] = item["imagedesc"].ToString();
                                if (item["imagepath"].ToString() != "")
                                {
                                    if (item["imagepath"].ToString().Contains("_TN"))
                                    {
                                        drHotel["imagepath"] = item["imagepath"].ToString().Replace("_TN", "");
                                    }
                                    else { drHotel["imagepath"] = item["imagepath"].ToString(); }
                                }
                                drHotel["images_Id"] = item["images_Id"].ToString();
                            }
                        }

                        DataRow[] drBookingInfo = dtBookingInfo.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drBookingInfo)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["checkintime"] = item["checkintime"].ToString();
                                drHotel["checkouttime"] = item["checkouttime"].ToString();
                            }
                        }

                        DataRow[] drServices = dtServices.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drServices)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["creditcards"] = item["creditcards"].ToString();
                                drHotel["hotelservices"] = item["hotelservices"].ToString();
                                drHotel["roomservices"] = item["roomservices"].ToString();
                            }
                        }

                        string ratedetail_Id = "";
                        DataRow[] drRateDetail = dtRateDetail.Select("hotel_Id = '" + hotel_Id + "'");
                        foreach (DataRow item in drRateDetail)
                        {
                            if (hotel_Id == item["hotel_Id"].ToString())
                            {
                                ratedetail_Id = item["ratedetail_Id"].ToString();
                            }
                        }

                        DataRow[] drRates = dtRate.Select("ratedetail_Id = '" + ratedetail_Id + "'");
                        string rate_Id = "";
                        foreach (DataRow item in drRates)
                        {
                            rate_Id = item["rate_Id"].ToString();
                            if (ratedetail_Id == item["ratedetail_Id"].ToString())
                            {
                                DataRow drHotelRoom = dtHotelRooms.NewRow();
                                drHotelRoom["ratetype"] = item["ratetype"].ToString();
                                drHotelRoom["hotelPackage"] = item["hotelPackage"].ToString();
                                drHotelRoom["roomtype"] = item["roomtype"].ToString();
                                drHotelRoom["roombasis"] = item["roombasis"].ToString();
                                drHotelRoom["roomTypeCode"] = item["roomTypeCode"].ToString();
                                drHotelRoom["ratePlanCode"] = item["ratePlanCode"].ToString();
                                drHotelRoom["rate_Id"] = rate_Id;
                                drHotelRoom["ratedetail_Id"] = ratedetail_Id;
                                drHotelRoom["hotel_Id"] = hotel_Id;
                                drHotelRoom["hoteldetail_Id"] = hoteldetail_Id;
                                drHotelRoom["hotelid"] = hotelid;

                                DataRow[] drRateBand = dtRateBands.Select("rate_Id = '" + rate_Id + "'");
                                foreach (DataRow item1 in drRateBand)
                                {
                                    if (rate_Id == item1["rate_Id"].ToString())
                                    {
                                        drHotelRoom["validdays"] = item1["validdays"].ToString();
                                        drHotelRoom["wsKey"] = item1["wsKey"].ToString();
                                        drHotelRoom["extGuestTotal"] = item1["extGuestTotal"].ToString();
                                        drHotelRoom["roomTotal"] = item1["roomTotal"].ToString();
                                        drHotelRoom["servicetaxTotal"] = item1["servicetaxTotal"].ToString();
                                        drHotelRoom["discount"] = item1["discount"].ToString();
                                        drHotelRoom["commission"] = item1["commission"].ToString();
                                    }
                                }

                                dtHotelRooms.Rows.Add(drHotelRoom);
                            }
                        }

                        dtHotels.Rows.Add(drHotel);
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtHotels);
                    dsReturn.Tables.Add(dtHotelRooms);
                    #endregion
                }

                else if (dsHotelAvailSearch.Tables.Contains("error"))
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataTable dt = dsHotelAvailSearch.Tables["error"];
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = dtError.NewRow();
                        dr["message"] = item["message"].ToString();
                        dtError.Rows.Add(dr);
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "No Hotels Found. Please try again";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelAvailSearchPortTypeClient = null;
            }
        }

        public DataSet GetHotelDetails(string hotelId, string webService, string cityName)
        {
            try
            {
                #region xmlRequest
                String xmlRequest = "<arzHotelDescReq>" +
                                      "<clientInfo>" +
                                      "<partnerID>" + PartnerId + "</partnerID>" +
                                      "<userID>" + UserId + "</userID>" +
                                      "<username>" + UserName + "</username>" +
                                      "<password>" + Password + "</password>" +
                                      "<userType>" + UserType + "</userType>" +
                                      "</clientInfo>" +
                                      "<searchquery>" +
                                      "<hotelinfo>" +
                                      "<hotelid>" + hotelId + "</hotelid>" +
                                      "<webService>" + webService + "</webService>" +
                                      "<city>" + cityName + "</city>" +
                                      "</hotelinfo>" +
                                      "</searchquery>" +
                                   "</arzHotelDescReq>";
                #endregion

                objHotelDetailsPortTypeClient = new HotelDetailsPortTypeClient();
                String strResponse = objHotelDetailsPortTypeClient.getHotelDetails(xmlRequest, "");
                DataSet dsHotelDetails = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                if (dsHotelDetails.Tables.Contains("hoteldetail") && dsHotelDetails.Tables.Contains("contactinfo")
                    && dsHotelDetails.Tables.Contains("images") && dsHotelDetails.Tables.Contains("image")
                    && dsHotelDetails.Tables.Contains("bookinginfo") && dsHotelDetails.Tables.Contains("services")
                    && dsHotelDetails.Tables.Contains("hotelinfo") && dsHotelDetails.Tables.Contains("hotel"))
                {
                    #region dsReturnWithHotelDetailsAndHotelImages
                    DataTable dtHotelDetails = new DataTable();
                    dtHotelDetails.TableName = "HotelDetails";

                    dtHotelDetails.Columns.Add("hotelid"); dtHotelDetails.Columns.Add("hotelname"); dtHotelDetails.Columns.Add("hoteldesc");
                    dtHotelDetails.Columns.Add("hotelchain"); dtHotelDetails.Columns.Add("starrating");
                    dtHotelDetails.Columns.Add("city"); dtHotelDetails.Columns.Add("country");
                    dtHotelDetails.Columns.Add("noofrooms"); dtHotelDetails.Columns.Add("facilities");
                    dtHotelDetails.Columns.Add("hotel_Id"); dtHotelDetails.Columns.Add("hoteldetail_Id");

                    dtHotelDetails.Columns.Add("address"); dtHotelDetails.Columns.Add("pincode");
                    dtHotelDetails.Columns.Add("citywiselocation"); dtHotelDetails.Columns.Add("locationinfo"); dtHotelDetails.Columns.Add("phone");
                    dtHotelDetails.Columns.Add("fax"); dtHotelDetails.Columns.Add("email"); dtHotelDetails.Columns.Add("website");

                    dtHotelDetails.Columns.Add("checkintime"); dtHotelDetails.Columns.Add("checkouttime");

                    dtHotelDetails.Columns.Add("creditcards"); dtHotelDetails.Columns.Add("hotelservices"); dtHotelDetails.Columns.Add("roomservices");

                    DataTable dtHotelImages = new DataTable();
                    dtHotelImages.TableName = "HotelImages";
                    dtHotelImages.Columns.Add("imagedesc"); dtHotelImages.Columns.Add("imagepath"); dtHotelImages.Columns.Add("images_Id");


                    DataTable dtHotelDetail = dsHotelDetails.Tables["hoteldetail"];
                    DataTable dtContactInfo = dsHotelDetails.Tables["contactinfo"];
                    DataTable dtImages = dsHotelDetails.Tables["images"];
                    DataTable dtImage = dsHotelDetails.Tables["image"];

                    DataTable dtBookingInfo = dsHotelDetails.Tables["bookinginfo"];
                    DataTable dtServices = dsHotelDetails.Tables["services"];
                    DataTable dtHotelInfo = dsHotelDetails.Tables["hotelinfo"];
                    DataTable dtHotel = dsHotelDetails.Tables["hotel"];

                    foreach (DataRow dr in dtHotelDetail.Rows)
                    {
                        DataRow drHotel = dtHotelDetails.NewRow();

                        drHotel["hotelid"] = hotelId;
                        drHotel["hotelname"] = dr["hotelname"].ToString();
                        drHotel["hoteldesc"] = dr["hoteldesc"].ToString();
                        drHotel["hotelchain"] = dr["hotelchain"].ToString();
                        drHotel["starrating"] = dr["starrating"].ToString();
                        drHotel["noofrooms"] = dr["noofrooms"].ToString();

                        if (dtHotelDetail.Columns.Contains("City"))
                        {
                            drHotel["city"] = dr["city"].ToString();
                        }
                        else
                        {
                            drHotel["city"] = "";
                        }

                        drHotel["country"] = dr["country"].ToString();
                        drHotel["facilities"] = dr["facilities"].ToString();
                        drHotel["hotel_Id"] = dr["hotel_Id"].ToString();
                        drHotel["hoteldetail_Id"] = dr["hoteldetail_Id"].ToString();

                        string hotel_Id = dr["hotel_Id"].ToString();
                        string hoteldetail_Id = dr["hoteldetail_Id"].ToString();
                        string hotelid = hotelId;

                        DataRow[] drContactInfo = dtContactInfo.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drContactInfo)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["address"] = item["address"].ToString();
                                if (dtContactInfo.Columns.Contains("pincode"))
                                {
                                    drHotel["pincode"] = item["pincode"].ToString();
                                }
                                else
                                {
                                    drHotel["pincode"] = "";
                                }
                                drHotel["citywiselocation"] = item["citywiselocation"].ToString();
                                drHotel["locationinfo"] = item["locationinfo"].ToString();
                                drHotel["phone"] = item["phone"].ToString();
                                drHotel["fax"] = item["fax"].ToString();
                                drHotel["email"] = item["email"].ToString();
                                drHotel["website"] = item["website"].ToString();
                            }
                        }

                        DataRow[] drImages = dtImages.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        string images_Id = "";
                        foreach (DataRow item in drImages)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                images_Id = item["images_Id"].ToString();
                            }
                        }

                        DataRow[] drBookingInfo = dtBookingInfo.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drBookingInfo)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["checkintime"] = item["checkintime"].ToString();
                                drHotel["checkouttime"] = item["checkouttime"].ToString();
                            }
                        }

                        DataRow[] drServices = dtServices.Select("hoteldetail_Id = '" + hoteldetail_Id + "'");
                        foreach (DataRow item in drServices)
                        {
                            if (hoteldetail_Id == item["hoteldetail_Id"].ToString())
                            {
                                drHotel["creditcards"] = item["creditcards"].ToString();
                                drHotel["hotelservices"] = item["hotelservices"].ToString();
                                drHotel["roomservices"] = item["roomservices"].ToString();
                            }
                        }

                        DataRow[] drImage = dtImage.Select("images_Id = '" + images_Id + "'");
                        foreach (DataRow item in drImage)
                        {
                            if (images_Id == item["images_Id"].ToString())
                            {
                                DataRow drImg = dtHotelImages.NewRow();
                                drImg["imagedesc"] = item["imagedesc"].ToString();
                                drImg["imagepath"] = item["imagepath"].ToString();
                                drImg["images_Id"] = item["images_Id"].ToString();
                                dtHotelImages.Rows.Add(drImg);
                            }
                        }

                        dtHotelDetails.Rows.Add(drHotel);
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtHotelDetails);
                    dsReturn.Tables.Add(dtHotelImages);
                    #endregion
                }
                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "No HotelDetails Found. Please try again";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelDetailsPortTypeClient = null;
            }
        }

        public DataSet GetHotelPolicy(string hotelId, string webService, string ratePlanType, string roomTypeCode, string checkInDate, string checkOutDate)
        {
            try
            {
                #region xmlRequest
                String xmlRequest = "<arzHotelPolicyReq>" +
                                   "<clientInfo>" +
                                   "<username>" + UserName + "</username>" +
                                   "<userType>" + UserType + "</userType>" +
                                   "<userID>" + UserId + "</userID>" +
                                   "<password>" +
                                   Password +
                                   "</password>" +
                                   "<partnerID>" + PartnerId + "</partnerID>" +
                                   "</clientInfo>" +
                                   "<searchquery>" +
                                   "<currency>INR</currency>" +
                                   "<residentOfIndia>true</residentOfIndia>" +
                                   "<hotelinfo>" +
                                   "<hotelid>" + hotelId + "</hotelid>" +
                                   "<webService>" + webService + "</webService>" +
                                   "<ratePlanType>" +
                                   ratePlanType + "</ratePlanType>" +
                                   "<roomTypeCode>" +
                                   roomTypeCode + "</roomTypeCode>" +
                                   "<checkInDate>" +
                                   checkInDate + "</checkInDate>" +
                                   "<checkOutDate>" +
                                   checkOutDate + "</checkOutDate>" +
                                   "</hotelinfo>" +
                                   "</searchquery>" +
                                   "</arzHotelPolicyReq>";
                #endregion

                objHotelPolicyPortTypeClient = new HotelPolicyPortTypeClient();
                string strResponse = objHotelPolicyPortTypeClient.getHotelPolicy(xmlRequest, "");
                DataSet dsHotelPolicy = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                if (dsHotelPolicy.Tables.Contains("policy"))
                {
                    #region dsReturnWithPolicy
                    DataTable dtPolicy = dsHotelPolicy.Tables["policy"];

                    DataTable dtPolicyReturn = new DataTable();
                    dtPolicyReturn.TableName = "HotelPolicy";
                    dtPolicyReturn.Columns.Add("policyText");
                    dtPolicyReturn.Columns.Add("policyType");

                    if (dtPolicy != null)
                    {
                        foreach (DataRow item in dtPolicy.Rows)
                        {
                            DataRow dr = dtPolicyReturn.NewRow();
                            dr["policyText"] = item["policy_Text"].ToString();
                            if (item["hotelPolicyRules_Id"].ToString() != "")
                            {
                                dr["policyType"] = "HotelPolicy";
                            }
                            else { dr["policyType"] = "CancellationPolicy"; }

                            dtPolicyReturn.Rows.Add(dr);
                        }
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtPolicyReturn);
                    #endregion
                }
                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "No HotelPolicy Found. Please try again";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelPolicyPortTypeClient = null;
            }
        }

        public DataSet HotelProvisional(string hotelId, string roomType, string webService, string fromDate, string toDate, string roomTypeCode, string ratePlanCode
            , string validDays, string wsKey, string extGuestTotal, string roomTotal, string serviceTaxTotal, string discount, string commission, string title
            , string firstName, string middleName, string lastName, string phNoCountryCode, string phNoAreaCode, string phoneNumber
            , string phNoExtension, string emailId, string custAddressLine, string custCity, string custZipCode, string custState, string custCountry
            , int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom, int[] firstChildAge, int[] secondChildAge)
        {
            try
            {
                #region xmlRequest
                String xmlRequest = "<arzHotelProvReq>" +

                                    "<clientInfo>" +
                                    "<username>" + UserName + "</username>" +
                                    "<password>" + Password + "</password>" +
                                    "<partnerID>" + PartnerId + "</partnerID>" +
                                    "<sessionid>" + "" + "</sessionid>" +
                                    "<userID>" + UserId + "</userID>" +
                                    "<userType>" + UserType + "</userType>" +
                                    "</clientInfo>" +

                                    "<allocquery>" +

                                    "<currency>INR</currency>" +

                                    "<hotelinfo>" +
                                    "<hotelid>" + hotelId + "</hotelid>" +
                                    "<roomtype>" + roomType + "</roomtype>" +
                                    "<webService>" + webService + "</webService>" +
                                    "<fromdate>" + fromDate + "</fromdate>" +//30/12/2010
                                    "<todate>" + toDate + "</todate>" +//31/12/2010
                                    "<roomTypeCode>" + roomTypeCode + "</roomTypeCode>" +
                                    "<ratePlanCode>" + ratePlanCode + "</ratePlanCode>" +
                                    "</hotelinfo>" +

                                    "<roomStayCandidate>";

                for (int i = 1; i <= noOfRooms; i++)
                {
                    if (Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) != "0")
                    {
                        xmlRequest = xmlRequest +
                                         "<guestDetails>" +
                                                 "<adults>" + Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) + "</adults>" +
                                                 "<child>";//
                        for (int j = 0; j <= Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()); j++)
                        {
                            if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 2)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                                if (j == 1)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(secondChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 1)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 0)
                            {
                                //xmlRequest = xmlRequest + "<age></age>"; //xmlRequest + "<age>-1</age>";
                            }
                        }
                        xmlRequest = xmlRequest + "</child>" +//
                                         "</guestDetails>";
                    }
                }

                xmlRequest = xmlRequest + "</roomStayCandidate>" +

               "<ratebands>" +
               "<validdays>" + validDays + "</validdays>" +
               "<wsKey>" + wsKey + "</wsKey>" +
               "<extGuestTotal>" + extGuestTotal + "</extGuestTotal>" +
               "<roomTotal>" + roomTotal + "</roomTotal>" +
               "<servicetaxTotal>" + serviceTaxTotal + "</servicetaxTotal>" +
               "<discount>" + discount + "</discount>" +
               "<commission>" + commission + "</commission>" +
               "</ratebands>" +

               "<guestInformation>" +
               "<title>" + title + "</title>" +//Mr
               "<firstName>" + firstName + "</firstName>" +
               "<middleName>" + middleName + "</middleName>" +
               "<lastName>" + lastName + "</lastName>" +

               "<phoneNumber>" +
               "<countryCode>" + phNoCountryCode + "</countryCode>" +
               "<areaCode>" + phNoAreaCode + "</areaCode>" +
               "<number>" + phoneNumber + "</number>" +
               "<extension>" + phNoExtension + "</extension>" +
               "</phoneNumber>" +

               "<email>" + emailId + "</email>" +

               "<address>" +
               "<addressLine>" + custAddressLine + "</addressLine>" +
               "<city>" + custCity + "</city>" +
               "<zipCode>" + custZipCode + "</zipCode>" +
               "<state>" + custState + "</state>" +
               "<country>" + custCountry + "</country>" +
               "</address>" +

               "<residentOfIndia>true</residentOfIndia>" +

               "</guestInformation>" +

               "</allocquery>" +
               "</arzHotelProvReq>";
                #endregion

                objHotelProvisionalPortTypeClient = new HotelProvisionalPortTypeClient();
                string strResponse = objHotelProvisionalPortTypeClient.getHotelProvisional(xmlRequest, "");
                DataSet dsHotelProvisional = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                if (dsHotelProvisional.Tables.Contains("allocresult"))
                {
                    #region dsReturnWithHotelProvisional
                    DataTable dtAllocResult = dsHotelProvisional.Tables["allocresult"];

                    DataTable dtAllocResultReturn = new DataTable();
                    dtAllocResultReturn.TableName = "HotelProvisional";
                    dtAllocResultReturn.Columns.Add("wsKey");
                    dtAllocResultReturn.Columns.Add("allocavail");
                    dtAllocResultReturn.Columns.Add("allocid");
                    dtAllocResultReturn.Columns.Add("error");

                    if (dtAllocResult != null)
                    {
                        foreach (DataRow item in dtAllocResult.Rows)
                        {
                            DataRow dr = dtAllocResultReturn.NewRow();

                            string wsKeyReturn = ""; string allocavailReturn = ""; string allocidReturn = ""; string errorReturn = "";
                            if (dtAllocResult.Columns.Contains("wsKey"))
                            {
                                wsKeyReturn = item["wsKey"].ToString();
                            }
                            if (dtAllocResult.Columns.Contains("error"))
                            {
                                errorReturn = item["error"].ToString();
                            }

                            allocidReturn = item["allocid"].ToString();
                            allocavailReturn = item["allocavail"].ToString();

                            dr["wsKey"] = wsKeyReturn;
                            dr["allocavail"] = allocavailReturn;
                            dr["allocid"] = allocidReturn;
                            dr["error"] = errorReturn;

                            dtAllocResultReturn.Rows.Add(dr);
                        }
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtAllocResultReturn);
                    #endregion
                }
                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "Please try again";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelProvisionalPortTypeClient = null;
            }
        }

        public DataSet HotelBooking(string hotelId, string webService, string ratePlanType, string roomTypeCode, string hotelCity
            , string fromAllocation, string allocId, string fromDate, string toDate, string roomType, string wsKey, string roomBasis, string title
            , string firstName, string middleName, string lastName
            , int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom, int[] firstChildAge, int[] secondChildAge)
        {
            try
            {
                #region xmlRequest
                String xmlRequest = "<arzHotelBookingReq>" +

                                    "<bookingrequest>" +

                                    "<clientInfo>" +
                                    "<partnerID>" + PartnerId + "</partnerID>" +
                                    "<username>" + UserName + "</username>" +
                                    "<password>" + Password + "</password>" +
                                    "<userID>" + UserId + "</userID>" +
                                    "<userType>" + UserType + "</userType>" +
                                    "</clientInfo>" +

                                    "<hotelinfo>" +
                                    "<hotelid>" + hotelId + "</hotelid>" +
                                    "<webService>" + webService + "</webService>" +
                                    "<ratePlanType>" + ratePlanType + "</ratePlanType>" +
                                    "<roomTypeCode>" + roomTypeCode + "</roomTypeCode>" +
                                    "<city>" + hotelCity + "</city>" +
                                    "</hotelinfo>" +

                                    "<bookinginfo>" +

                                    "<fromallocation>" + fromAllocation + "</fromallocation>" +
                                    "<allocid>" + allocId + "</allocid>" +
                                    "<fromdate>" + fromDate + "</fromdate>" +//30/12/2010
                                    "<todate>" + toDate + "</todate>" +//31/12/2010
                                    "<roomtype>" + roomType + "</roomtype>" +//Superior Room
                                    "<wsKey>" + wsKey + "</wsKey>" +
                                    "<roombasis>" + roomBasis + "</roombasis>" +//Breakfast, Pick up from therailway station
                                    "<currency>INR</currency>" +

                                    "<roomStayCandidate>";

                for (int i = 1; i <= noOfRooms; i++)
                {
                    if (Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) != "0")
                    {
                        xmlRequest = xmlRequest +
                                         "<guestDetails>" +
                                                 "<adults>" + Convert.ToString(noOfAdultsInARoom[i - 1].ToString()) + "</adults>" +
                                                 "<child>";
                        for (int j = 0; j <= Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()); j++)
                        {
                            if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 2)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                                if (j == 1)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(secondChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 1)
                            {
                                if (j == 0)
                                {
                                    xmlRequest = xmlRequest + "<age>" + Convert.ToString(firstChildAge[i - 1].ToString()) + "</age>";
                                }
                            }
                            else if (Convert.ToInt32(noOfChildsInARoom[i - 1].ToString()) == 0)
                            {
                                //xmlRequest = xmlRequest + "<age></age>"; //xmlRequest + "<age>-1</age>";
                            }
                        }
                        xmlRequest = xmlRequest + "</child>" +
                                         "</guestDetails>";
                    }
                }

                xmlRequest = xmlRequest +
                                    "</roomStayCandidate>" +

                                    "</bookinginfo>" +

                                    "<guestInformation>" +
                                    "<title>" + title + "</title>" +
                                    "<firstName>" + firstName + "</firstName>" +
                                    "<middleName>" + middleName + "</middleName>" +
                                    "<lastName>" + lastName + "</lastName>" +
                                    "<residentOfIndia>True</residentOfIndia>" +
                                    "</guestInformation>" +

                                    "</bookingrequest>" +

                                    "</arzHotelBookingReq>";
                #endregion

                objHotelBookingPortTypeClient = new HotelBookingPortTypeClient();
                string strResponse = objHotelBookingPortTypeClient.getHotelBooking(xmlRequest, "");
                DataSet dsHotelBooking = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                DataTable dtBookingRequest = dsHotelBooking.Tables["bookingrequest"];
                DataTable dtClientInfo = dsHotelBooking.Tables["clientInfo"];
                DataTable dtHotelInfo = dsHotelBooking.Tables["hotelinfo"];
                DataTable dtAddress = dsHotelBooking.Tables["address"];
                DataTable dtAddressLine = dsHotelBooking.Tables["addressLine"];
                DataTable dtContactNumbers = dsHotelBooking.Tables["contactNumbers"];
                DataTable dtContactNumber = dsHotelBooking.Tables["contactNumber"];
                DataTable dtTpaExtensions = dsHotelBooking.Tables["tPA__Extensions"];
                DataTable dtBookingInfo = dsHotelBooking.Tables["bookinginfo"];
                DataTable dtBookingResponse = dsHotelBooking.Tables["bookingresponse"];

                if (dsHotelBooking.Tables.Contains("bookingresponse"))
                {
                    #region dsReturnWithBooking
                    if (dtBookingResponse != null && dtTpaExtensions != null && dtContactNumber != null)
                    {
                        DataTable dtBookingReturn = new DataTable();
                        dtBookingReturn.TableName = "HotelBooking";
                        dtBookingReturn.Columns.Add("wsKey"); dtBookingReturn.Columns.Add("extGuestTotal"); dtBookingReturn.Columns.Add("roomTotal");
                        dtBookingReturn.Columns.Add("servicetaxTotal"); dtBookingReturn.Columns.Add("bookingstatus"); dtBookingReturn.Columns.Add("bookingremarks");
                        dtBookingReturn.Columns.Add("bookingref"); dtBookingReturn.Columns.Add("bookingTrn"); dtBookingReturn.Columns.Add("discount");

                        dtBookingReturn.Columns.Add("contactNumbers"); dtBookingReturn.Columns.Add("faxNumbers");

                        foreach (DataRow item in dtBookingResponse.Rows)
                        {
                            DataRow dr = dtBookingReturn.NewRow();
                            dr["wsKey"] = item["wsKey"].ToString();
                            dr["extGuestTotal"] = item["extGuestTotal"].ToString();
                            dr["roomTotal"] = item["roomTotal"].ToString();
                            dr["servicetaxTotal"] = item["servicetaxTotal"].ToString();

                            dr["bookingstatus"] = item["bookingstatus"].ToString();
                            dr["bookingremarks"] = item["bookingremarks"].ToString();
                            dr["bookingref"] = item["bookingref"].ToString();
                            dr["bookingTrn"] = item["bookingTrn"].ToString();

                            dr["discount"] = item["discount"].ToString();

                            string phoneNumbers = "";
                            foreach (DataRow item1 in dtContactNumber.Rows)
                            {
                                if (phoneNumbers == "")
                                {
                                    phoneNumbers = item1["phoneNumber"].ToString();
                                }
                                else { phoneNumbers = phoneNumbers + " , " + item1["phoneNumber"].ToString(); }
                            }
                            dr["contactNumbers"] = phoneNumbers;

                            string faxNumbers = "";
                            foreach (DataRow item2 in dtTpaExtensions.Rows)
                            {
                                if (faxNumbers == "")
                                {
                                    faxNumbers = item2["faxNumber"].ToString();
                                }
                                else { faxNumbers = faxNumbers + " , " + item2["faxNumber"].ToString(); }
                            }
                            dr["faxNumbers"] = faxNumbers;

                            dtBookingReturn.Rows.Add(dr);
                        }
                        dsReturn = new DataSet();
                        dsReturn.Tables.Add(dtBookingReturn);
                    }
                    #endregion
                }
                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "Failed to Book ticket. Please try again.";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelBookingPortTypeClient = null;
            }
        }

        public DataSet HotelCancellation(string emailId, string lastName, string bookingRef, string webService, string cancellationDate, string cancellationDate2)
        {
            try
            {
                #region xmlRequest
                String sCancel = "";
                if (cancellationDate == cancellationDate2)
                {
                    sCancel = "<cancellationDate>" + cancellationDate + "</cancellationDate>";//07/28/2007
                }
                else
                {
                    sCancel = "<cancellationDate>" + cancellationDate + "</cancellationDate>" + "<cancellationDate>" + cancellationDate2 + "</cancellationDate>";
                }
                String xmlRequest = "<arzHotelCancellationReq>" +

                                   "<clientInfo>" +
                                   "<username>" + UserName + "</username>" +
                                   "<password>" + Password + "</password>" +
                                   "<partnerID>" + PartnerId + "</partnerID>" +
                                   "<userID>" + UserId + "</userID>" +
                                   "<userType>" + UserType + "</userType>" +
                                   "</clientInfo>" +

                                   "<cancellationinfo>" +

                                   "<email>" + emailId + "</email>" +
                                   "<currency>INR</currency>" +
                                   "<lastName>" + lastName + "</lastName>" +
                                   "<bookingref>" + bookingRef + "</bookingref>" +
                                   "<webService>" + webService + "</webService>" +
                                   "<cancellationDates>" + sCancel + "</cancellationDates>" +

                                   "</cancellationinfo>" +

                                   "</arzHotelCancellationReq>";
                #endregion

                objHotelCancellationPortTypeClient = new HotelCancellationPortTypeClient();
                string strResponse = objHotelCancellationPortTypeClient.getHotelCancellation(xmlRequest, "");
                DataSet dsHotelCancellation = ConvertXMLStringToDataSet(strResponse);

                DataSet dsReturn = null;

                DataTable dtCancellationInfo = dsHotelCancellation.Tables["cancellationinfo"];
                DataTable dtCancellationDates = dsHotelCancellation.Tables["cancellationDates"];

                if (dtCancellationInfo != null)
                {
                    #region dsReturnWithCancellation
                    DataTable dtCancellationReturn = new DataTable();
                    dtCancellationReturn.TableName = "HotelCancellation";

                    dtCancellationReturn.Columns.Add("email");
                    dtCancellationReturn.Columns.Add("lastName");
                    dtCancellationReturn.Columns.Add("cancellationId");
                    dtCancellationReturn.Columns.Add("webService");
                    dtCancellationReturn.Columns.Add("currency");
                    dtCancellationReturn.Columns.Add("refundTotalAmount");
                    dtCancellationReturn.Columns.Add("cancellationAmount");

                    dtCancellationReturn.Columns.Add("success");
                    dtCancellationReturn.Columns.Add("error");

                    foreach (DataRow item in dtCancellationInfo.Rows)
                    {
                        DataRow dr = dtCancellationReturn.NewRow();

                        dr["email"] = item["email"].ToString();
                        dr["lastName"] = item["lastName"].ToString();
                        dr["webService"] = item["webService"].ToString();
                        dr["currency"] = item["currency"].ToString();



                        string success = ""; string error = "";
                        string cancellationId = "";
                        string refundTotalAmount = "";
                        string cancellationAmount = "";
                        if (dtCancellationInfo.Columns.Contains("success"))
                        {
                            success = item["success"].ToString();
                        }
                        if (dtCancellationInfo.Columns.Contains("error"))
                        {
                            error = item["error"].ToString();
                        }
                        if (dtCancellationInfo.Columns.Contains("cancellationId"))
                        {
                            cancellationId = item["cancellationId"].ToString();
                        }
                        if (dtCancellationInfo.Columns.Contains("refundTotalAmount"))
                        {
                            refundTotalAmount = item["refundTotalAmount"].ToString();
                        }
                        if (dtCancellationInfo.Columns.Contains("cancellationAmount"))
                        {
                            cancellationAmount = item["cancellationAmount"].ToString();
                        }

                        dr["cancellationId"] = cancellationId;
                        dr["refundTotalAmount"] = refundTotalAmount;
                        dr["cancellationAmount"] = cancellationAmount;
                        dr["success"] = success;
                        dr["error"] = error;

                        dtCancellationReturn.Rows.Add(dr);
                    }
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtCancellationReturn);
                    #endregion
                }
                else
                {
                    #region dsReturnWithError
                    DataTable dtError = new DataTable();
                    dtError.TableName = "Error";
                    dtError.Columns.Add("Message");
                    DataRow dr = dtError.NewRow();
                    dr["message"] = "Failed to Book ticket. Please try again.";
                    dtError.Rows.Add(dr);
                    dsReturn = new DataSet();
                    dsReturn.Tables.Add(dtError);
                    #endregion
                }

                return dsReturn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objHotelCancellationPortTypeClient = null;
            }
        }

        DataSet ConvertXMLStringToDataSet(string xmlString)
        {
            try
            {
                DataSet ds = null;
                string sss = xmlString.Substring(0, 1);
                if (sss == "<")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlString);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                else
                {
                    ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Message");
                    DataRow dr = dt.NewRow();
                    dr["Message"] = xmlString;
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}