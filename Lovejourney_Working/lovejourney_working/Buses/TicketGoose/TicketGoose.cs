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
using System.Linq;
using System.Xml;
using LJ.CLB.DTO;
using Newtonsoft.Json;
using BAL;
using I2S.API.Buses.TicketGoose;
using System.Collections;

#endregion

namespace LJ.CLB.Buses
{
    /// <summary>
    /// TicketGoose Class has the methods that calls TicketGoose API service
    /// </summary>
    public class TicketGooseAPI : BusesBaseClass
    {
        #region Declarations

        String requestBody;
        XmlNodeList xmlNodes;
        DataTable dtResponse;
        TGTravelServiceClient client;


        #endregion

        #region Public Methods

        /// <summary>
        /// Method for getting stationslist
        /// </summary>
        /// <returns></returns>
        public String getSources(String URL, String ConsumerKey, String ConsumerSecret)
        {
            client = new TGTravelServiceClient("TGSWS", URL);
            Station response = client.getStationList(ConsumerKey, ConsumerSecret);
            DataTable dtCities = new DataTable();
            //Check if response status is success
            if (response.status.code == "200")
            {
                dtCities = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(response.stationList));
                dtCities.Columns["stationId"].ColumnName = "id";
                dtCities.Columns["stationName"].ColumnName = "name";
                return JsonConvert.SerializeObject(dtCities);
            }
            else
                return String.Empty;
        }

        /// <summary>
        /// Method for getting from and to stationslist
        /// </summary>
        /// <returns></returns>
        public String getSourcesAndDestinations(String URL, String ConsumerKey, String ConsumerSecret)
        {
            client = new TGTravelServiceClient("TGSWS", URL);
            FromToStation response = client.getFromToStationIdList(ConsumerKey, ConsumerSecret);
            return JsonConvert.SerializeObject(response);
            //return JsonConvert.SerializeObject(response);
        }


        /// <summary>
        /// Method for getting triplist named v2
        /// </summary>
        /// 
        List<TripWithArrivalDTO> AvailableFlights;
        public AvailableTrips getTripListV2(int sourceId, int destinationId, String dateOfJourney, String URL, String ConsumerKey, String ConsumerSecret, int ProviderID)
        {
            try
            {
                
                //return "";
                //Convert dd-mm-yyyy format to API compatible format dd/mm/yyyy
                dateOfJourney = dateOfJourney.Replace('-', '/');
                client = new TGTravelServiceClient("TGSWS", URL);
                TripWithArrival response = client.getTripListV2(ConsumerKey, ConsumerSecret, sourceId.ToString(), destinationId.ToString(), dateOfJourney);
                AvailableTrips objAvailableTrips = null;
                if (response != null && response.tripList != null && response.tripList.Length > 0)
                {
                    objAvailableTrips = new AvailableTrips();
                    #region Loop each trip and add trip details to availabletrips

                    //ignore operator list

                    List<object> oo = new List<object>();
                    clsMasters obj = new clsMasters();
                    DataSet ds = obj.GetIgnoreList(ProviderID);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            AvailableFlights = response.tripList.ToList();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {

                                AvailableFlights = AvailableFlights.Where(e => e.provider != row[3].ToString()).ToList();

                            }
                        }
                        else
                        {
                            AvailableFlights = response.tripList.ToList();
                        }
                    }




                    //end ignore operator list
                    // List<TripWithArrivalDTO> AvailableFlights = response.tripList.Where(e => e.provider.Except(studentQuery).ToList();

                    foreach (TripWithArrivalDTO item in AvailableFlights)
                    {
                        //if (item.provider == "SVR Tours &  Travels")
                        //{
                        //}

                        LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();
                        objTripDetails.providerName = "TICKETGOOSE";
                        //remove seconds and make it to 12hr format
                        if (item.arrivalTime != null)
                        {
                            if (int.Parse(item.arrivalTime.Split(':')[0]) < 12) objTripDetails.arrivalTime = item.arrivalTime.Split(':')[0] + ':' + item.arrivalTime.Split(':')[1] + " AM";
                            else objTripDetails.arrivalTime = (int.Parse(item.arrivalTime.Split(':')[0]) - 12).ToString() + ':' + item.arrivalTime.Split(':')[1] + " PM";
                        }
                        else
                            objTripDetails.arrivalTime = "-";

                        objTripDetails.availableSeats = item.availableSeats;

                        //objTripDetails.boardingTimes = JsonConvert.SerializeObject(item.pickUpPointList);
                        objTripDetails.busType = item.type;
                        //cancellationPolicy  is not valid for ticketgoose
                        objTripDetails.cancellationPolicy = String.Empty;

                        //remove seconds and make it to 12hr format
                        if (item.departureTime != null)
                        {
                            if (int.Parse(item.departureTime.Split(':')[0]) < 12) objTripDetails.departureTime = item.departureTime.Split(':')[0] + ':' + item.departureTime.Split(':')[1] + " AM";
                            else objTripDetails.departureTime = (int.Parse(item.departureTime.Split(':')[0]) - 12).ToString() + ':' + item.departureTime.Split(':')[1] + " PM";
                        }

                        //objTripDetails.droppingTimes = String.Empty;

                        if (item.departureTime != null && item.arrivalTime != null)
                            //objTripDetails.duration = Duration(objTripDetails.departureTime, objTripDetails.arrivalTime);
                            objTripDetails.duration = Duration(objTripDetails.departureTime, objTripDetails.arrivalTime);
                        if (objTripDetails.duration == null)
                        {
                            objTripDetails.duration = "-";
                        }
                        objTripDetails.fares = item.fare;
                        objTripDetails.id = item.scheduleId;
                        //partialCancellationAllowed is not valid for ticketkgoose
                        objTripDetails.partialCancellationAllowed = String.Empty;
                        objTripDetails.travels = item.provider;
                        objTripDetails.sourceId = sourceId;
                        objTripDetails.destinationId = destinationId;
                        objAvailableTrips.Add(objTripDetails);

                    }
                    #endregion
                }



                return objAvailableTrips;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Method for getting all the tripdetails of V2
        /// </summary>
        /// <returns></returns>
        public SeatsInfo getTripDetailsV2(int sourceId, int destinationId, String dateOfJourney, String scheduleId, String URL,
                        String ConsumerKey, String ConsumerSecret)
        {
            SeatsInfo objSeatsLayout = null;
            try
            {
                //Convert dd-mm-yyyy format to API compatible format dd/mm/yyyy
                dateOfJourney = dateOfJourney.Replace('-', '/');
                client = new TGTravelServiceClient("TGSWS", URL);
                TripDetails response = client.getTripDetailsV2(ConsumerKey, ConsumerSecret, sourceId.ToString(), destinationId.ToString(), dateOfJourney, scheduleId);

                BoardingDroppingPoints bpList = new BoardingDroppingPoints();

                if (response != null && response.tripDetails != null)
                {
                    objSeatsLayout = new SeatsInfo();
                    objSeatsLayout.Seats = new List<SeatLayout>();
                    #region Loop each seat and add seat details to objSeatsLayout
                    //.OrderByDescending(element => element.level)
                    foreach (BusLayoutDTO busLayout in response.tripDetails.busLayoutList)
                    {
                        foreach (SeatDetailsDTO item in busLayout.seatDetailsList)
                        {
                            SeatLayout objSeat = new SeatLayout();
                            //set default values                            
                            objSeat.length = 1;
                            objSeat.width = 1;
                            objSeat.zIndex = busLayout.level - 1;
                            objSeat.row = item.columnNbr;
                            objSeat.column = item.rowNbr;
                            objSeat.id = scheduleId;
                            objSeat.number = item.seatNbr;

                            switch (item.cellType.ToUpper())
                            {
                                case "AISLE":
                                    break;
                                case "SEAT":
                                    objSeat.isAvailableSeat = "false";
                                    break;
                                case "BERTH":
                                    objSeat.isAvailableSeat = "false";
                                    objSeat.length = 2;
                                    objSeat.width = 1;
                                    break;
                                default:
                                    break;
                            }

                            //only available seats are fetched in response.tripDetails.seatDetailList
                            SeatDetailDTO seatInfo = response.tripDetails.seatDetailList.SingleOrDefault(seat => seat.seatNbr == item.seatNbr);

                            if (item.seatNbr != null && seatInfo != null)
                            {
                                objSeat.fare = seatInfo.fare;
                                if (seatInfo.seatStatus.Equals("A") || seatInfo.seatStatus.Equals("F") || seatInfo.seatStatus.Equals("M"))
                                {
                                    objSeat.isAvailableSeat = "true";
                                    if (seatInfo.seatStatus.Equals("F"))
                                        objSeat.isLadiesSeat = "true";
                                }
                            }

                            objSeatsLayout.Seats.Add(objSeat);
                        }
                    }
                    #endregion

                    #region Loop all boarding and dropping points
                    foreach (BoardingPointDTO point in response.tripDetails.boardingPointList)
                    {
                        bpList.Add(new BoardingDroppingDetails(point.boardingPointId, point.boardingPointName, point.time));
                    }
                    #endregion

                    if (bpList.Count > 0)
                        objSeatsLayout.boardingTimes = bpList;
                }
            }
            catch (Exception)
            {
                // to do
            }
            return objSeatsLayout;
        }

        /// <summary>
        /// Method for getting process request info
        /// </summary>
        /// <returns></returns>
        public String processRequest(int sourceId, int destinationId, int boardingPointId, String dateOfJourney, String scheduleId, String name,
                        String contactNo, String emailId, String noOfSeats, String comments, String URL, String ConsumerKey, String ConsumerSecret)
        {
            client = new TGTravelServiceClient("TGSWS", URL);
            Status response = client.processRequest(ConsumerKey, ConsumerSecret, sourceId.ToString(), destinationId.ToString(), dateOfJourney,
                                        scheduleId, name, contactNo, emailId, noOfSeats, comments);
            dtResponse = new DataTable();
            if (response != null)
            {
                //to do 
                //build dtresponse datatable
            }
            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeObject(response);
        }

        /// <summary>
        /// Method for blocking seats 
        /// </summary>
        /// <returns></returns>
        public BlockSeatsResponse blockSeatsForBooking(String scheduleId, String travelDate, String fromStationId, String toStationId, String boardingPointId,
                                String emailId, String mobileNbr, String address, String URL, String ConsumerKey, String ConsumerSecret,
                                int noOfSeats, String seatNo, String title, String name, String age, String sex)
        {

            BlockSeatsResponse objBlockSeatsResponse = new BlockSeatsResponse();
            try
            {
                travelDate = travelDate.Replace('-', '/');
                String[] seatNoArray = seatNo.Split(',');
                String[] titleArray = title.Split(',');
                String[] nameArray = name.Split(',');
                String[] ageArray = age.Split(',');
                String[] sexArray = sex.Split(',');

                client = new TGTravelServiceClient("TGSWS", URL);
                PassengerDetailDTO[] PassengerDetailDT = new PassengerDetailDTO[noOfSeats];

                for (int i = 0; i < noOfSeats; i++)
                {
                    PassengerDetailDTO PassengerDetailDTO1 = new PassengerDetailDTO();
                    PassengerDetailDTO1.age = ageArray[i].ToString();
                    PassengerDetailDTO1.name = nameArray[i].ToString();
                    PassengerDetailDTO1.seatNbr = seatNoArray[i].ToString();
                    PassengerDetailDTO1.sex = sexArray[i].ToString();
                    PassengerDetailDT[i] = PassengerDetailDTO1;
                }

                BlockedSeatsForBookingDetails response = client.blockSeatsForBooking(ConsumerKey, ConsumerSecret, scheduleId
                    , travelDate, fromStationId, toStationId, boardingPointId, emailId, mobileNbr, address, PassengerDetailDT);

                DataSet ds = convertJsonStringToDataSet(JsonConvert.SerializeObject(response));

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables["status"].Rows[0]["code"].ToString().Trim().ToLower() == "200")
                        {
                            if (ds.Tables[0].Columns.Contains("bookingId"))
                            {
                                objBlockSeatsResponse.BookingID = ds.Tables[0].Rows[0]["bookingId"].ToString();
                                objBlockSeatsResponse.Status = "SUCCESS";
                            }
                        }
                        else
                        {
                            objBlockSeatsResponse.Status = "FAIL";
                            objBlockSeatsResponse.Message = ds.Tables["status"].Rows[0]["message"].ToString();
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
        /// Method for booking a ticket using userid,password,bookingid
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        public BookSeatsResponse BookTicket(String bookingId, String URL, String ConsumerKey, String ConsumerSecret)
        {
            BookSeatsResponse objBookSeatsResponse = new BookSeatsResponse();
            try
            {
                client = new TGTravelServiceClient("TGSWS", URL);
                BookingDetails response = client.bookTicket(ConsumerKey, ConsumerSecret, bookingId);

                string strTicketGooseBookingResponse = JsonConvert.SerializeObject(response);

                DataSet ds = convertJsonStringToDataSet(strTicketGooseBookingResponse);

                if (ds != null && ds.Tables["status"] != null)
                {
                    if (ds.Tables["status"].Rows[0]["code"].ToString().Trim() == "200"
                        && ds.Tables["status"].Rows[0]["message"].ToString().Trim().ToLower() == "success")
                    {
                        objBookSeatsResponse.Status = "SUCCESS";
                        foreach (DataRow item in ds.Tables["extraSeatInfoList"].Rows)
                        {
                            objBookSeatsResponse.OperatorPNR = item["extraSeatInfo"].ToString();
                                //(objBookSeatsResponse.OperatorPNR == "") ?
                                    //                            item["extraSeatInfo"].ToString() :
                                   //                             objBookSeatsResponse.OperatorPNR + "," + item["extraSeatInfo"].ToString();
                            objBookSeatsResponse.OperaterNo = item["extraSeatInfo"].ToString();
                            objBookSeatsResponse.extraseatinfo = item["extraSeatInfo"].ToString();
                        }
                    }
                    else
                    {
                        objBookSeatsResponse.Status = "FAIL"; objBookSeatsResponse.Message = ds.Tables["status"].Rows[0]["message"].ToString().Trim();
                    }
                }
                else
                    objBookSeatsResponse.Status = "FAIL";

                objBookSeatsResponse.APIPNR = (objBookSeatsResponse.Status == "SUCCESS") ? bookingId : "";
            }
            catch (Exception ex)
            {
                // to do
            }
            return objBookSeatsResponse;
        }

        /// <summary>
        /// Method for cancelling ticket
        /// </summary>
        /// <returns></returns>
        public String cancelTicket(String bookingId, String seatNumbers, String URL, String ConsumerKey, String ConsumerSecret)
        {
            client = new TGTravelServiceClient("TGSWS", URL);
            CancellationChargeDetails response = client.cancelTicket(ConsumerKey, ConsumerSecret, bookingId, seatNumbers.Split(','));
            return JsonConvert.SerializeObject(response);
        }

        /// <summary>
        /// Method for ticket cancellation confirmation
        /// </summary>
        /// <returns></returns>
        public String confirmTicketCancellation(String bookingId, String seatNumbers, String URL, String ConsumerKey, String ConsumerSecret)
        {
            client = new TGTravelServiceClient("TGSWS", URL);
            string[] seats = seatNumbers.Split(',');
            CancellationDetails response = client.confirmTicketCancellation(ConsumerKey, ConsumerSecret, bookingId, seats);
            return JsonConvert.SerializeObject(response);
            //return JsonConvert.SerializeObject(response);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Common method to call api and get xml nodes list
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        private XmlNodeList getXmlNodeList(String requestBody)
        {
            String response = invokeGetRequest(requestBody, @"application/json");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response);
            return xmlDoc.ChildNodes;
        }

        #endregion
    }
}
