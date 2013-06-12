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
using System.Xml;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using I2S.CLB.DTO;

#endregion

namespace I2S.CLB.Buses
{
    /// <summary>
    /// Redbus Class has the methods that calls Redbus API service
    /// </summary>
    public class RedbusAPI : BusesBaseClass
    {
        #region Declarations

        #endregion

        #region Public Methods

        SSAPIClient objService = new SSAPIClient();

        public String getSources(String URL, String ConsumerKey, String ConsumerSecret)
        {
            try
            {
                //fails to convert to datatable
                DataSet dsCities = new DataSet();
                dsCities = convertJsonStringToDataSet(objService.getAllSources(URL, ConsumerKey, ConsumerSecret));
                return JsonConvert.SerializeObject(dsCities.Tables["cities"]);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public String getDestinations(int sourceId, String URL, String ConsumerKey, String ConsumerSecret)
        {   
            return objService.getAllDestinations(sourceId.ToString(), URL, ConsumerKey, ConsumerSecret);
        }

        public AvailableTrips getAvailableTrips(int sourceId, int destinationId, String dateofjourney, String URL, String ConsumerKey, String ConsumerSecret)
        {
            dateofjourney = dateofjourney.Split('-')[2] + "-" + dateofjourney.Split('-')[1] + "-" + dateofjourney.Split('-')[0];
            try
            {
                String strResponse = objService.getAvailableTrips(sourceId.ToString(), destinationId.ToString(), dateofjourney, URL, ConsumerKey, ConsumerSecret);
                DataSet ds = convertJsonStringToDataSet(strResponse);

                //Check if response is valid else return error message
                if (ds == null)
                {
                    throw new Exception(strResponse);
                }
                AvailableTrips objAvailableTrips = null;
                
                if (ds != null && ds.Tables.Count > 0 && ds.Tables["availableTrips"].Rows.Count > 0)
                {
                    objAvailableTrips = new AvailableTrips();
                    #region Loop each trip and add trip details to availabletrips

                    foreach (DataRow item in ds.Tables["availableTrips"].Rows)
                    {
                        DTO.TripDetails objTripDetails = new DTO.TripDetails();
                        objTripDetails.boardingTimes = new BoardingDroppingPoints();
                        objTripDetails.droppingTimes = new BoardingDroppingPoints();

                        objTripDetails.providerName = "REDBUS";
                        objTripDetails.availableSeats = item["availableSeats"].ToString();
                        objTripDetails.busType = item["busType"].ToString();
                        objTripDetails.cancellationPolicy = item["cancellationPolicy"].ToString();
                        objTripDetails.departureTime = Time(item["departureTime"].ToString());

                        #region Boarding & Dropping Points

                        //boarding points
                        DataTable dtBP = ds.Tables["boardingTimes"].Clone();
                        DataRow[] drBPArray = ds.Tables["boardingTimes"].Select("availableTrips_Id = " + item["availableTrips_Id"].ToString());
                        foreach (DataRow drow in drBPArray)
                        {
                            String strBP = "";// objService.getBoardingPoint(drow["bpId"].ToString(), URL, ConsumerKey, ConsumerSecret);
                            BoardingDroppingDetails bp = new BoardingDroppingDetails(drow["bpId"].ToString(), drow["location"].ToString(), Time(drow["time"].ToString()));
                            if (strBP != String.Empty)
                            {
                                bp.address = (String)JObject.Parse(strBP)["address"];
                                bp.landmark = (String)JObject.Parse(strBP)["landmark"];
                                bp.name = (String)JObject.Parse(strBP)["name"];
                            }
                            objTripDetails.boardingTimes.Add(bp);
                        }
                        //dropping points                       
                        DataTable dtDP = ds.Tables["droppingTimes"].Clone();
                        DataRow[] drDPArray = ds.Tables["droppingTimes"].Select("availableTrips_Id = " + item["availableTrips_Id"].ToString());
                        foreach (DataRow drow in drDPArray)
                        {
                            String strDP = "";// objService.getBoardingPoint(drow["bpId"].ToString(), URL, ConsumerKey, ConsumerSecret);
                            BoardingDroppingDetails dp = new BoardingDroppingDetails(drow["bpId"].ToString(), drow["location"].ToString(), Time(drow["time"].ToString()));
                            if (strDP != String.Empty)
                            {
                                dp.address = (String)JObject.Parse(strDP)["address"];
                                dp.landmark = (String)JObject.Parse(strDP)["landmark"];
                                dp.name = (String)JObject.Parse(strDP)["name"];
                            }
                            objTripDetails.boardingTimes.Add(dp);
                        }

                        #endregion

                        //check if boarding and dropping times are same. If so, show '-'
                        if (item["arrivalTime"].ToString() != item["departureTime"].ToString())
                        {
                            objTripDetails.arrivalTime = Time(item["arrivalTime"].ToString());
                            objTripDetails.duration = Duration(objTripDetails.departureTime, objTripDetails.arrivalTime);
                        }
                        else
                            objTripDetails.arrivalTime = objTripDetails.duration = "-";
                        
                        if (ds.Tables["fares"] == null)
                            objTripDetails.fares = item["fares"].ToString();
                        else
                            objTripDetails.fares = ds.Tables["fares"].Rows[ds.Tables["availableTrips"].Rows.IndexOf(item)]["fares_text"].ToString();
                        objTripDetails.id = item["id"].ToString();
                        objTripDetails.partialCancellationAllowed = item["partialCancellationAllowed"].ToString();
                        objTripDetails.travels = item["travels"].ToString();

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
                throw ex;
            }           
        }

        public SeatsInfo getTripDetails(String tripId, String URL, String ConsumerKey, String ConsumerSecret)
        {
            SeatsInfo objSeatsLayout = null;
            try
            {
                String strResponse = objService.getTripDetails(tripId, URL, ConsumerKey, ConsumerSecret);
                DataSet ds = convertJsonStringToDataSet(strResponse);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables["seats"].Rows.Count > 0)
                {
                    objSeatsLayout = new SeatsInfo();
                    objSeatsLayout.Seats = new List<SeatLayout>();
                    #region Loop each seat and add seat details to objSeatsLayout

                    foreach (DataRow item in ds.Tables["seats"].Rows)
                    {
                        SeatLayout objSeat = new SeatLayout();
                        
                        objSeat.column = Int16.Parse(item["column"].ToString());
                        objSeat.fare = item["fare"].ToString();
                        objSeat.id = tripId;
                        objSeat.isAvailableSeat = item["available"].ToString();
                        objSeat.isLadiesSeat = item["ladiesSeat"].ToString();
                        objSeat.length = Int16.Parse(item["length"].ToString());
                        objSeat.number = item["name"].ToString();
                        objSeat.row = Int16.Parse(item["row"].ToString());
                        objSeat.width = Int16.Parse(item["width"].ToString());
                        objSeat.zIndex = Int16.Parse(item["zIndex"].ToString());

                        objSeatsLayout.Seats.Add(objSeat);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                // to do
            }
            return objSeatsLayout;
        }

        public BlockSeatsResponse blockTicket(String tripDetails, String doj, String seats, String fare, String boardingDetails,
                                    String tripID, String destinationID, String sourceID, String busType, String busOperator,
                                    String tripType, String dor, String seatsRet, String fareRet, String boardingDetailsRet,
                                    String tripIDRet, String destinationIDRet, String sourceIDRet, String busTypeRet, String busOperatorRet,
                                    String multiCityID, String URL, String ConsumerKey, String ConsumerSecret)
        {            
            // to do
            return new BlockSeatsResponse();
        }

        public BookSeatsResponse bookTicket(String blockKey, String URL, String ConsumerKey, String ConsumerSecret)
        {           
            //return objService.bookTicket(blockKey, URL, ConsumerKey, ConsumerSecret);
            return new BookSeatsResponse();
        }

        public String getTicketDetails(String tinNo, String URL, String ConsumerKey, String ConsumerSecret)
        {
            return objService.getTicket(tinNo, URL, ConsumerKey, ConsumerSecret);
        }

        public String getCancellationDetails(String tinNo, String URL, String ConsumerKey, String ConsumerSecret)
        {
            return objService.getCancellationData(tinNo, URL, ConsumerKey, ConsumerSecret);
        }

        public String cancelTicket(String cancellationRequest, String URL, String ConsumerKey, String ConsumerSecret)
        {
            return objService.cancelTicket(cancellationRequest, URL, ConsumerKey, ConsumerSecret);
        }

        #endregion
    }
}