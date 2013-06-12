#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
 * Version          : 1.0
 */
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using LJ.CLB.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BAL;
using BusAPILayer;
#endregion

namespace LJ.CLB.Buses
{
    /// <summary>
    /// Bitla Class has the methods that calls Bitla API service
    /// </summary>
    public class BitlaAPI : BusesBaseClass
    {
        #region Declarations

        String requestBody;
        DataTable dtResponse;

        #endregion

        #region Public Methods
        /// <summary>
        /// Method for getting all the cities
        /// </summary>
        /// <returns></returns>
        public String getSources(String URL, String ConsumerKey)
        {
            requestBody = URL + "/cities.json?api_key=" + ConsumerKey;
            DataSet ds = convertJsonStringToDataSet(getJSONReponse(requestBody));
            return JsonConvert.SerializeObject(ds.Tables["city"]);
        }

        /// <summary>
        /// Method for getting all the Operators available
        /// </summary>
        /// <returns></returns>
        public String getOperators(String URL, String ConsumerKey)
        {
            requestBody = URL + "/operators.json?api_key=" + ConsumerKey;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting destination pairs
        /// </summary>
        /// <returns></returns>
        public string getDestinationPairs(String URL, String ConsumerKey)
        {
            requestBody = URL + "/destination_pairs.json?api_key=" + ConsumerKey;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting bus categories
        /// </summary>
        /// <returns></returns>
        public String getBusCategories(String URL, String ConsumerKey)
        {
            requestBody = URL + "/bus_categories.json?api_key=" + ConsumerKey;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting bus types
        /// </summary>
        /// <returns></returns>
        
        public String getBusTypes(String URL, String ConsumerKey)
        {
            requestBody = URL + "/bus_types.json?api_key=" + ConsumerKey;
            return getJSONReponse(requestBody);
        }

        public DataSet GetAllAvailableRoutes(String URL, String ConsumerKey,String dateofjourney)
        {
            try
            {
                //dateofjourney = dateofjourney.Split('-')[2] + "-" + dateofjourney.Split('-')[1] + "-" + dateofjourney.Split('-')[0];

                requestBody = URL + "all_available_routes/" + dateofjourney + ".json?api_key=" + ConsumerKey;
                DataSet ds = convertJsonStringToDataSet(getJSONReponse(requestBody));

                return ds;


            }
            catch (Exception)
            {

                throw;
            }

        }

        

        /// <summary>
        /// Method for getting available routes according to the date
        /// </summary>

        AvailableTrips objAvailableTrips = new AvailableTrips();
        List<LJ.CLB.DTO.TripDetails> trip = new List<LJ.CLB.DTO.TripDetails>();
        public AvailableTrips MRgetAvailableRoutes(int sourceId, int destinationId, String dateOfJourney, String URL, String ConsumerKey, int ProviderID, string MPName)
        {
            string JourneyDate = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];

            IBitlaAPILayer objBitlaAPILayer = null;
            objBitlaAPILayer = new BitlaAPILayer();
            objBitlaAPILayer.URL = URL;
            objBitlaAPILayer.ApiKey = ConsumerKey;
            objBitlaAPILayer.Date = JourneyDate;
            DataSet ds = null;
            ds = objBitlaAPILayer.GetAllAvailableRoutes();
            if (ds != null)
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["route"].Rows.Count > 0)
                {

                    #region Loop each trip and add trip details to availabletrips

                    foreach (DataRow item in ds.Tables["route"].Rows)
                    {
                        //add the routes that match with given source and destinations
                        if (int.Parse(item["origin_id"].ToString()) == sourceId && int.Parse(item["destination_id"].ToString()) == destinationId)
                        {
                            LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();
                            objTripDetails.providerName = "MORNINGSTAR";
                            objTripDetails.arrivalTime = CalculateArrivalTime(item["dep_time"].ToString(), item["duration"].ToString());
                            objTripDetails.availableSeats = item["available_seats"].ToString();
                            //boardingTimes are fetched in seat layout
                            objTripDetails.busType = item["bus_type"].ToString();
                            //cancellationPolicy  is not valid for bitla
                            objTripDetails.cancellationPolicy = String.Empty;
                            objTripDetails.departureTime = item["dep_time"].ToString();
                            //droppingTimes are fetched in seat layout
                            objTripDetails.duration = item["duration"].ToString() + " hrs";
                            objTripDetails.fares = item["fare_str"].ToString();
                            objTripDetails.id = item["reservation_id"].ToString();
                            objTripDetails.partialCancellationAllowed = item["is_cancellable"].ToString();
                            objTripDetails.travels = item["travels"].ToString();
                            objTripDetails.sourceId = int.Parse(item["origin_id"].ToString());
                            objTripDetails.destinationId = int.Parse(item["destination_id"].ToString());

                            objAvailableTrips.Add(objTripDetails);
                        }
                    }
                    #endregion
                }
            }

            //ignore operator list
            return objAvailableTrips;
        }
        public AvailableTrips getAvailableRoutes(int sourceId, int destinationId, String dateOfJourney, String URL, String ConsumerKey, int ProviderID)
        {
            try
            {
                dateOfJourney = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];
                if (File.Exists(Path.Combine(HttpRuntime.AppDomainAppPath, "Routes\\" + dateOfJourney + ".xml")))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Path.Combine(HttpRuntime.AppDomainAppPath, "Routes\\" + dateOfJourney + ".xml"));
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables["route"].Rows.Count > 0)
                    {
                        objAvailableTrips = new AvailableTrips();
                        DataView dv = ds.Tables["route"].DefaultView;
                        dv.RowFilter = "origin_id=" + sourceId + "and destination_id=" + destinationId;
                        foreach (DataRowView item in dv)
                        {
                            //add the routes that match with given source and destinations
                            if (int.Parse(item["origin_id"].ToString()) == sourceId && int.Parse(item["destination_id"].ToString()) == destinationId)
                            {
                                LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();
                                objTripDetails.providerName = "BITLA";
                                objTripDetails.arrivalTime = CalculateArrivalTime(item["dep_time"].ToString(), item["duration"].ToString());
                                objTripDetails.availableSeats = item["available_seats"].ToString();
                                //boardingTimes are fetched in seat layout
                                objTripDetails.busType = item["bus_type"].ToString();
                                //cancellationPolicy  is not valid for bitla
                                objTripDetails.cancellationPolicy = String.Empty;
                                objTripDetails.departureTime = item["dep_time"].ToString();
                                //droppingTimes are fetched in seat layout
                                objTripDetails.duration = item["duration"].ToString();
                                objTripDetails.fares = item["fare_str"].ToString();
                                objTripDetails.id = item["reservation_id"].ToString();
                                objTripDetails.partialCancellationAllowed = item["is_cancellable"].ToString();
                                objTripDetails.travels = item["travels"].ToString();
                                objTripDetails.sourceId = int.Parse(item["origin_id"].ToString());
                                objTripDetails.destinationId = int.Parse(item["destination_id"].ToString());
                                trip.Add(objTripDetails);
                            }
                        }
                        
                    }
                    //ignore operator list
                    clsMasters obj = new clsMasters();
                    DataSet dsignore = obj.GetIgnoreList(ProviderID);
                    if (dsignore != null)
                    {
                        if (dsignore.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in dsignore.Tables[0].Rows)
                            {
                                trip = trip.Where(e => e.travels != row[3].ToString()).ToList();
                            }

                        }

                    }
                    foreach (var bt in trip)
                    {
                        LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();
                        objTripDetails.providerName = "BITLA";
                        objTripDetails.arrivalTime = CalculateArrivalTime(bt.departureTime.ToString(), bt.duration.ToString());
                        objTripDetails.availableSeats = bt.availableSeats.ToString();
                        //boardingTimes are fetched in seat layout
                        objTripDetails.busType = bt.busType.ToString();
                        //cancellationPolicy  is not valid for bitla
                        objTripDetails.cancellationPolicy = String.Empty;
                        objTripDetails.departureTime = bt.departureTime.ToString();
                        //droppingTimes are fetched in seat layout
                        objTripDetails.duration = bt.duration.ToString() + " hrs";
                        objTripDetails.fares = bt.fares.ToString();
                        objTripDetails.id = bt.id.ToString();
                        objTripDetails.partialCancellationAllowed = bt.partialCancellationAllowed.ToString();
                        objTripDetails.travels = bt.travels.ToString();
                        objTripDetails.sourceId = int.Parse(bt.sourceId.ToString());
                        objTripDetails.destinationId = int.Parse(bt.destinationId.ToString());
                        objAvailableTrips.Add(objTripDetails);
                    }
                }
               
                
                return objAvailableTrips;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method for checking the whether the service is available or not based on the reservation id
        /// </summary>
        /// <returns></returns>
        public SeatsInfo getServiceDetails(String reservationId, String URL, String ConsumerKey)
        {
            SeatsInfo objSeatsLayout = null;
            try
            {
                requestBody = URL + "/service_details/" + reservationId + ".json?api_key=" + ConsumerKey;
                String strResponse = getJSONReponse(requestBody);
                DataSet ds = convertJsonStringToDataSet(strResponse);
                BoardingDroppingPoints bpList = new BoardingDroppingPoints();
                BoardingDroppingPoints dpList = new BoardingDroppingPoints();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["seat"].Rows.Count > 0)
                {
                    objSeatsLayout = new SeatsInfo();
                    objSeatsLayout.Seats = new List<SeatLayout>();
                    #region Loop each seat and add seat details to objSeatsLayout
                    foreach (DataRow item in ds.Tables["seat"].Rows)
                    {
                        SeatLayout objSeat = new SeatLayout();
                        objSeat.fare = item["fare"].ToString();
                        objSeat.id = reservationId;
                        objSeat.number = item["number"].ToString();

                        if (!Boolean.Parse(item["is_gangway"].ToString()))
                        {
                            objSeat.isAvailableSeat = item["available"].ToString();
                            objSeat.isLadiesSeat = item["is_reserved_for_ladies"].ToString();
                        }
                        else
                        {
                            objSeat.isAvailableSeat = null;
                            objSeat.isLadiesSeat = null;
                        }

                        objSeat.row = Int16.Parse(item["col_id"].ToString());
                        objSeat.column = Int16.Parse(item["row_id"].ToString());

                        #region set length, width and zindex

                        switch (item["type"].ToString())
                        {
                            case "UB":
                            case "SUB":
                                objSeat.length = 2;
                                objSeat.width = 1;
                                objSeat.zIndex = 1;
                                break;

                            //objSeat.length = 2;
                            //objSeat.width = 1;
                            //objSeat.zIndex = 1;
                            //break;
                            case "LB":
                            case "SLB":
                                objSeat.length = 2;
                                objSeat.width = 1;
                                objSeat.zIndex = 0;
                                break;

                            //objSeat.length = 2;
                            //objSeat.width = 1;
                            //objSeat.zIndex = 0;
                            //break;
                            case "SS":
                                objSeat.length = 1;
                                objSeat.width = 1;
                                objSeat.zIndex = 0;
                                break;
                            case "GY":
                                objSeat.length = 1;
                                objSeat.width = 1;
                                objSeat.zIndex = 0;
                                break;
                            default:
                                break;
                        }

                        #endregion

                        objSeatsLayout.Seats.Add(objSeat);
                    }
                    #endregion

                    #region Loop all boarding and dropping points
                    foreach (DataRow point in ds.Tables["stage"].Rows)
                    {
                        if (point["type"] != null)
                        {
                            if (point["type"].ToString().ToUpper().Contains("BOARDING"))
                            {
                                bpList.Add(new BoardingDroppingDetails((String)point["address"], (String)point["contact_numbers"], (String)point["contact_persons"],
                                    (String)point["id"], (String)point["landmark"], (String)point["name"], (String)point["name"], (String)point["time"]));
                            }
                            else
                            {
                                dpList.Add(new BoardingDroppingDetails((String)point["address"], (String)point["contact_numbers"], (String)point["contact_persons"],
                                    (String)point["id"], (String)point["landmark"], (String)point["name"], (String)point["name"], (String)point["time"]));
                            }
                            //id,name,type,time,address,city_id,city,state(empty),contact_numbers,contact_persons,pin_code,landmark,ref_stage_id,ref_stage_name,stages_id
                        }
                    }
                    #endregion

                    if (bpList.Count > 0)
                        objSeatsLayout.boardingTimes = bpList;
                    if (dpList.Count > 0)
                        objSeatsLayout.droppingTimes = dpList;

                    if (ds.Tables["service_details"] != null &&
                        ds.Tables["service_details"].Rows.Count > 0 &&
                        ds.Tables["service_details"].Rows[0]["available_Seats"] != null)
                        objSeatsLayout.availableSeatsCount = ds.Tables["service_details"].Rows[0]["available_Seats"].ToString();
                }
            }
            catch (Exception ex)
            {
                // to do
            }
            return objSeatsLayout;
        }

        /// <summary>
        /// Method for validating booked ticket
        /// </summary>
        /// <returns></returns>
        public BlockSeatsResponse validateTicket(int sourceId, int destinationId, String reservationId, String URL, String ConsumerKey
            , int noOfSeats, String boardingPointId, String seatNo, String title, String name, String age, String sex, String address
            , String bookingRefNo, String idCardType, String idCardNo, String idCardIssuedBy, String mobileNo, String emergencyMobileNo
            , String emailId)
        {
            BlockSeatsResponse objBlockSeatsResponse = new BlockSeatsResponse();

            try
            {
                String[] seatNoArray = seatNo.Split(',');
                String[] titleArray = title.Split(',');
                String[] nameArray = name.Split(',');
                String[] ageArray = age.Split(',');
                String[] sexArray = sex.Split(',');

                String requestUrl = URL + "/validate_book_ticket.json?api_key=" + ConsumerKey + "&reservation_id="
                    + reservationId + "&origin_id=" + sourceId + "&destination_id=" + destinationId + "&boarding_at=" + boardingPointId
                        + "&no_of_seats=" + noOfSeats + "&agent_ref_number=" + bookingRefNo;

                #region JsonRequestBody
                string seatDetails = "";

                for (int i = 0; i < noOfSeats; i++)
                {
                    if (seatDetails == "")
                    {
                        seatDetails = "{\"seat_number\":\"" + seatNoArray[i].ToString() + "\",\"title\":\"" + titleArray[i].ToString() + "\",\"name\":\"" + nameArray[i].ToString() + "\",\"age\":\""
                                        + ageArray[i].ToString() + "\",\"sex\":\"" + sexArray[i].ToString() + "\",\"is_primary\":\"" + "true" + "\",\"id_card_type\":\""
                                        + "1" + "\",\"id_card_number\":\"" + idCardNo + "\",\"id_card_issued_by\":\""
                                        + idCardIssuedBy + "\"} ";
                        //1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card////id_card_type
                    }
                    else
                    {
                        seatDetails = seatDetails + "," + "{\"seat_number\":\"" + seatNoArray[i].ToString() + "\",\"title\":\"" + titleArray[i].ToString() + "\",\"name\":\"" + nameArray[i].ToString() + "\",\"age\":\""
                                        + ageArray[i].ToString() + "\",\"sex\":\"" + sexArray[i].ToString() + "\",\"is_primary\":\"" + "true" + "\",\"id_card_type\":\""
                                        + "1" + "\",\"id_card_number\":\"" + idCardNo + "\",\"id_card_issued_by\":\""
                                        + idCardIssuedBy + "\"} ";
                    }
                }

                String req = "{\"book_ticket\":{\"seat_details\":{\"seat_detail\":[" + seatDetails + "]},";

                req = req + "\"contact_detail\":{\"mobile_number\":\"" + mobileNo + "\",\"emergency_name\":\"" + emergencyMobileNo
                          + "\",\"email\":\"" + emailId + "\"}}}";
                #endregion

                string response = invokePostRequest(requestUrl, req, "application/json");

                DataSet ds = convertJsonStringToDataSet(response);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["code"].ToString().Trim() == "200")
                        {
                            objBlockSeatsResponse.Status = "SUCCESS";
                            objBlockSeatsResponse.Message = ds.Tables[0].Rows[0]["message"].ToString().Trim();
                        }
                        else
                        {
                            objBlockSeatsResponse.Status = "FAIL";
                            objBlockSeatsResponse.Message = ds.Tables[0].Rows[0]["message"].ToString().Trim();
                        }
                    }
                }
                else { objBlockSeatsResponse.Status = "FAIL"; }

            }
            catch (Exception ex)
            {
                // to do
            }
            return objBlockSeatsResponse;
        }

        /// <summary>
        /// Method for booking ticket
        /// </summary>
        /// <returns></returns>
        public BookSeatsResponse bookTicket(int sourceId, int destinationId, String reservationId, String URL, String ConsumerKey
            , int noOfSeats, String boardingPointId, String seatNo, String title, String name, String age, String sex, String address
            , String bookingRefNo, String idCardType, String idCardNo, String idCardIssuedBy, String mobileNo, String emergencyMobileNo
            , String emailId)
        {
            BookSeatsResponse objBookSeatsResponse = new BookSeatsResponse();
            try
            {
                String[] seatNoArray = seatNo.Split(',');
                String[] titleArray = title.Split(',');
                String[] nameArray = name.Split(',');
                String[] ageArray = age.Split(',');
                String[] sexArray = sex.Split(',');

                String requestUrl = URL + "/book_ticket.json?api_key=" + ConsumerKey +
                    "&reservation_id=" + reservationId + "&origin_id=" + sourceId + "&destination_id=" + destinationId
                    + "&boarding_at=" + boardingPointId + "&no_of_seats=" + noOfSeats.ToString() + "&agent_ref_number=" + bookingRefNo;


                #region JsonRequestBody
                string seatDetails = "";

                for (int i = 0; i < noOfSeats; i++)
                {
                    if (seatDetails == "")
                    {
                        seatDetails = "{\"seat_number\":\"" + seatNoArray[i].ToString() + "\",\"title\":\"" + titleArray[i].ToString() + "\",\"name\":\"" + nameArray[i].ToString() + "\",\"age\":\""
                                        + ageArray[i].ToString() + "\",\"sex\":\"" + sexArray[i].ToString() + "\",\"is_primary\":\"" + "true" + "\",\"id_card_type\":\""
                                        + "1" + "\",\"id_card_number\":\"" + idCardNo + "\",\"id_card_issued_by\":\""
                                        + idCardIssuedBy + "\"} ";
                        //1 -> Pan Card, 2 -> D/L, 3 -> Passport, 4 -> Voter, 5 -> Aadhar Card////id_card_type
                    }
                    else
                    {
                        seatDetails = seatDetails + "," + "{\"seat_number\":\"" + seatNoArray[i].ToString() + "\",\"title\":\"" + titleArray[i].ToString() + "\",\"name\":\"" + nameArray[i].ToString() + "\",\"age\":\""
                                        + ageArray[i].ToString() + "\",\"sex\":\"" + sexArray[i].ToString() + "\",\"is_primary\":\"" + "true" + "\",\"id_card_type\":\""
                                        + "1" + "\",\"id_card_number\":\"" + idCardNo + "\",\"id_card_issued_by\":\""
                                        + idCardIssuedBy + "\"} ";
                    }
                }

                String req = "{\"book_ticket\":{\"seat_details\":{\"seat_detail\":[" + seatDetails + "]},";

                req = req + "\"contact_detail\":{\"mobile_number\":\"" + mobileNo + "\",\"emergency_name\":\"" + emergencyMobileNo
                          + "\",\"email\":\"" + emailId + "\"}}}";
                #endregion

                String str = invokePostRequest(requestUrl, req, "application/json");

                DataSet ds = convertJsonStringToDataSet(str);

                if (ds != null)
                {
                    if (ds.Tables["ticket_details"] != null)
                    {
                        if (ds.Tables["ticket_details"].Rows[0]["ticket_status"].ToString().Trim().ToLower() == "confirmed"
                            && ds.Tables["ticket_details"].Rows[0]["ticket_number"].ToString().Trim() != "")
                        {
                            objBookSeatsResponse.Status = "SUCCESS";
                            objBookSeatsResponse.APIPNR = ds.Tables["ticket_details"].Rows[0]["ticket_number"].ToString().Trim();
                            objBookSeatsResponse.OperatorPNR = ds.Tables["ticket_details"].Rows[0]["travel_operator_pnr"].ToString().Trim();
                        }
                        else
                        {
                            objBookSeatsResponse.Status = "FAIL";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //to do
            }
            return objBookSeatsResponse;
        }

        /// <summary>
        /// Method for cancelling ticket
        /// </summary>
        /// <returns></returns>
        public string cancelTicket(String ticketNumber, String seatNos, String URL, String ConsumerKey)
        {
            requestBody = URL + "/cancel_ticket.json?api_key=" + ConsumerKey + "&ticket_number=" + ticketNumber;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for cancelling the partial ticket
        /// </summary>
        /// <returns></returns>
        public string cancelPartialTicket(String ticketNumber, String URL, String ConsumerKey)
        {
            requestBody = URL + "/cancel_partial_ticket.json?api_key=" + ConsumerKey + "&ticket_number=" + ticketNumber;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting the cancellable ticket information
        /// </summary>
        /// <returns></returns>
        public String getCancellableTickets(String ticketNumber, String SeatsCount, String URL, String ConsumerKey)
        {
            requestBody = URL + "/is_ticket_cancellable.json?api_key=" + ConsumerKey + "&ticket_number=" + ticketNumber + "&seat_numbers=" + SeatsCount;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting the booked ticket details
        /// </summary>
        /// <returns></returns>
        public string getTicketDetails(String ticketNumber, String URL, String ConsumerKey)
        {
            requestBody = URL + "/ticket_details.json?api_key=" + ConsumerKey + "&ticket_number=" + ticketNumber;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method for getting the default stages
        /// </summary>
        /// <returns></returns>
        public String getDefaultStages(String URL, String ConsumerKey)
        {
            requestBody = URL + "/default_stages.json?api_key=" + ConsumerKey;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// method for checking the transaction log
        /// </summary>
        /// <returns></returns>
        public string getTransactionLog(String date, String URL, String ConsumerKey)
        {
            requestBody = URL + "/transaction_log.json?api_key=" + ConsumerKey + "&trans_date=" + date;
            return getJSONReponse(requestBody);
        }

        /// <summary>
        /// Method to store bitla routes
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="ConsumerKey"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public string storeBitlaTrips(String URL, String fromDate, String toDate, String ConsumerKey)
        {
            try
            {
                DateTime dtFrom = DateTime.ParseExact(fromDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime dtTo = DateTime.ParseExact(toDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                while (dtFrom <= dtTo)
                {
                    requestBody = URL + "/all_available_routes/" + dtFrom.ToString("yyyy-MM-dd") + ".json?api_key=" + ConsumerKey;
                    String response = invokeGetRequest(requestBody, @"application/json");
                    JObject jObject = JObject.Parse(response);
                    if (jObject["routes"] != null)
                    {
                        //Create a txt file with current date, get the data from API and store it to text file
                        String file = dtFrom.ToString("MM-dd-yyyy");
                        File.WriteAllText(HttpContext.Current.Server.MapPath("Resources\\Bitla\\AvailableRoutes " + file + ".txt"), response);
                    }
                    //mode to next date
                    dtFrom = dtFrom.AddDays(1.0);
                }
                return "Successfully saved the routes";
            }
            catch (Exception ex)
            {
                return "Failed to save routes. " + ex.Message;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Common method to call api and get xml nodes list
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        private String getJSONReponse(String requestBody)
        {
            return invokeGetRequest(requestBody, @"application/xml");
        }
      
        private String CalculateArrivalTime(String departureTime, String duration)
        {
            String[] strDepTimeArray = departureTime.Split(':');
            int hours = Convert.ToInt32(strDepTimeArray[0].ToString());
            int mins = (hours * 60) + Convert.ToInt32(strDepTimeArray[1].ToString().Substring(0, 2));
            String amorpm = Convert.ToString(strDepTimeArray[1].ToString().Substring(2, 2)).ToLower().ToString();

            String[] strDurationArray = duration.Split(':');
            int hours1 = Convert.ToInt32(strDurationArray[0].ToString());
            int mins1 = (hours1 * 60) + Convert.ToInt32(strDurationArray[1].ToString().Substring(0));

            String total = "";

            int arrtimemins = 0;

            if (amorpm.Contains("p"))
            {
                total = Convert.ToString(mins + mins1 + 720);
                arrtimemins = mins + mins1 + 720;
            }
            else { total = Convert.ToString(mins + mins1); arrtimemins = mins + mins1; }

            return Time(total);
            //return TimeInMins(Time(total));
        }

        #endregion
    }
}
