using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using LJ.CLB.DTO;
using Newtonsoft.Json;
using System.Linq;


namespace LJ.CLB.Buses
{
    public class EasybusAPI : BusesBaseClass
    {
        #region Declarations

        String requestBody;

        #endregion


        #region public Methods

        public String getSources(String URL, String ConsumerKey)
        {
            requestBody = URL + "?Method=GetStations&Key=" + ConsumerKey;
            DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
            DataTable dtCities = new DataTable();
            dtCities = ds.Tables[0];
            dtCities.Columns["stationId"].ColumnName = "id";
            dtCities.Columns["stationName"].ColumnName = "name";
            return JsonConvert.SerializeObject(dtCities);
            //return ds.GetXml();
            //return JsonConvert.SerializeObject(ds);
        }

        public String getDestinations(String URL, String ConsumerKey)
        {

            requestBody = URL + "?Method=GetDestinations&SorceStationid=38&Key=" + ConsumerKey;
            DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
            DataTable dtCities = new DataTable();
            dtCities = ds.Tables[0];
            dtCities.Columns["stationId"].ColumnName = "id";
            dtCities.Columns["stationName"].ColumnName = "name";
            return JsonConvert.SerializeObject(dtCities);
        }


        public AvailableTrips getAvailableServices(int sourceId, int destinationId, String dateOfJourney,
             String URL, String ConsumerKey, string providername)
        {
            //Convert mm-dd-yyyy format to API compatible format dd-mm-yyyy
            dateOfJourney = dateOfJourney.Split('-')[1] + "/" + dateOfJourney.Split('-')[0] + "/" + dateOfJourney.Split('-')[2];
            try
            {
                requestBody = URL + "/server.aspx?Method=GetAvailableServices&TripType=" + 1 + "&SorceStationid=" + sourceId + "&DestinationStationid=" + destinationId + "&DateofJourney=" + dateOfJourney + "&DateOfReturn=" + dateOfJourney + "&Key=" + ConsumerKey;

                DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
                DataTable dtBuses = new DataTable();
                dtBuses = ds.Tables[0];

                AvailableTrips objAvailableTrips = new AvailableTrips();

                if (dtBuses != null)
                {

                    //foreach (DataRow dtRow in dtBuses.Rows)

                    //{
                    if (dtBuses.TableName!="Respones"|| dtBuses.TableName=="Services")
                    {
                        for (int i = 0; i < dtBuses.Rows.Count; i++)
                        {
                            LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();
                            objTripDetails.providerName = providername;
                            objTripDetails.boardingTimes = null;//String.Empty;
                            objTripDetails.cancellationPolicy = String.Empty;
                            objTripDetails.droppingTimes = null;//String.Empty;
                            objTripDetails.sourceId = int.Parse(sourceId.ToString());
                            objTripDetails.destinationId = int.Parse(destinationId.ToString());
                            objTripDetails.partialCancellationAllowed = "false";

                            int Totalseats = Convert.ToInt32(dtBuses.Rows[i]["CAPACITY"].ToString());
                            int BookedSeats = Convert.ToInt32(dtBuses.Rows[i]["BOOKEDSEATS"].ToString());
                            int AvailableSeats = Totalseats - BookedSeats;
                            objTripDetails.id = dtBuses.Rows[i]["SERVICE_ID"].ToString();
                            objTripDetails.travels = dtBuses.Rows[i]["NOTES"].ToString();
                            objTripDetails.departureTime = dtBuses.Rows[i]["START_TIME"].ToString();
                            objTripDetails.arrivalTime = dtBuses.Rows[i]["HALT_TIME"].ToString();
                            objTripDetails.fares = dtBuses.Rows[i]["Fare"].ToString();
                            objTripDetails.availableSeats = AvailableSeats.ToString();
                            objTripDetails.busType = dtBuses.Rows[i]["BUS_TYPE"].ToString();
                            objTripDetails.SeatLayoutId = dtBuses.Rows[i]["LAYOUT_ID"].ToString();
                            objTripDetails.duration = Duration(objTripDetails.departureTime, objTripDetails.arrivalTime);
                            objAvailableTrips.Add(objTripDetails);
                        }
                    }
                    // }
                }
                return objAvailableTrips;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public SeatsInfo getLayoutDetails(int sourceId, int destinationId, String dateOfJourney, String serviceId, String markUpFare, String SeatLayoutId,
              String seatType, String URL, String ConsumerKey)
        {
            SeatsInfo objSeatsLayout = null;

            try
            {
                //Convert mm-dd-yyyy format to API compatible format dd-mm-yyyy
                dateOfJourney = dateOfJourney.Split('-')[1] + "/" + dateOfJourney.Split('-')[0] + "/" + dateOfJourney.Split('-')[2];

                // requestBody = URL + "/server.aspx?Method=GetLayoutDetails&ServiceId=" + serviceId + "&DateofJourney=" + dateOfJourney + "&SorceStationid="+sourceId + "&DestinationStationid=" + destinationId + "&DateofJourney=" + dateOfJourney + "&DateOfReturn=" + dateOfJourney + "&Key=" + ConsumerKey;
                string str = URL + "/Server.aspx?Method=GetLayoutDetails&ServiceId=" + serviceId + "&DateofJourney=" + dateOfJourney + "&LayoutId=" + SeatLayoutId + "&BreathFare=" + markUpFare + "&SeatFare=" + markUpFare + "&Key=" + ConsumerKey;
                requestBody = str;

                DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
                DataTable dtBuses = new DataTable();
                dtBuses = ds.Tables[0];

                objSeatsLayout = new SeatsInfo();
                objSeatsLayout.Seats = new List<SeatLayout>();
                if (dtBuses != null)
                {

                    for (int i = 0; i < dtBuses.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtBuses.Columns.Count; j++)
                        {
                            SeatLayout objSeat = new SeatLayout();

                            string seat;
                            //string[] arr = new string[1];
                            seat = dtBuses.Rows[i][j].ToString();
                            if (seat != null && seat != "" && seat != "$")
                            {
                                string[] seatstr = seat.ToString().Split('_');

                                if (seatstr[0].StartsWith("U") || seatstr[0].StartsWith("L"))
                                {

                                    if (Convert.ToString(seatstr[0]).Trim() != "")
                                    {
                                        objSeat.number = seatstr[0].ToString();
                                    }

                                    if (Convert.ToString(seatstr[1]).Trim() != "")
                                    {
                                        if (Convert.ToString(seatstr[1]).Trim() == "1")
                                        {
                                            objSeat.isAvailableSeat = "true";
                                        }
                                        else if (Convert.ToString(seatstr[1]).Trim() == "0")
                                        {
                                            objSeat.isAvailableSeat = "false";
                                            if (Convert.ToString(seatstr[3]).Trim() != "")
                                            {
                                                if (Convert.ToString(seatstr[3]).Trim() == "S")
                                                {
                                                    objSeat.length = 2;
                                                    objSeat.width = 1;
                                                    objSeat.zIndex = 0;
                                                }
                                                else if (Convert.ToString(seatstr[3]).Trim() == "B")
                                                {
                                                    objSeat.length = 2;
                                                    objSeat.width = 1;
                                                    objSeat.zIndex = 0;
                                                }
                                            }
                                        }
                                        if (Convert.ToString(seatstr[2]).Trim() != "")
                                        {
                                            if (Convert.ToString(seatstr[2]).Trim() == "S")
                                            {
                                                objSeat.length = 2;
                                                objSeat.width = 1;
                                                objSeat.zIndex = 0;
                                            }
                                            else if (Convert.ToString(seatstr[2]).Trim() == "B")
                                            {
                                                objSeat.length = 2;
                                                objSeat.width = 1;
                                                objSeat.zIndex = 0;
                                            }
                                        }

                                        if (Convert.ToString(seatstr[3]).Trim() != "")
                                        {
                                            objSeat.fare = seatstr[3].ToString();
                                        }
                                    }
                                }
                                else
                                {

                                    if (Convert.ToString(seatstr[0]).Trim() != "")
                                    {
                                        objSeat.number = seatstr[0].ToString();
                                    }
                                    if (Convert.ToString(seatstr[1]).Trim() != "")
                                    {
                                        if (Convert.ToString(seatstr[1]).Trim() == "1")
                                        {
                                            objSeat.isAvailableSeat = "true";
                                        }
                                        else if (Convert.ToString(seatstr[1]).Trim() == "0")
                                        {
                                            objSeat.isAvailableSeat = "false";
                                            if (Convert.ToString(seatstr[3]).Trim() != "")
                                            {
                                                if (Convert.ToString(seatstr[3]).Trim() == "S")
                                                {
                                                    objSeat.length = 1;
                                                    objSeat.width = 1;
                                                    objSeat.zIndex = 0;
                                                }
                                                else if (Convert.ToString(seatstr[3]).Trim() == "B")
                                                {
                                                    objSeat.length = 2;
                                                    objSeat.width = 1;
                                                    objSeat.zIndex = 0;
                                                }
                                            }


                                        }
                                    }
                                    if (Convert.ToString(seatstr[2]).Trim() != "")
                                    {
                                        if (Convert.ToString(seatstr[2]).Trim() == "S")
                                        {
                                            objSeat.length = 1;
                                            objSeat.width = 1;
                                            objSeat.zIndex = 0;
                                        }
                                        else if (Convert.ToString(seatstr[2]).Trim() == "B")
                                        {
                                            objSeat.length = 2;
                                            objSeat.width = 1;
                                            objSeat.zIndex = 0;
                                        }
                                    }

                                    if (Convert.ToString(seatstr[3]).Trim() != "")
                                    {
                                        objSeat.fare = seatstr[3].ToString();
                                    }
                                }

                                objSeat.row = i + 1;
                                objSeat.column = j + 1;
                                objSeat.id = serviceId;
                                objSeat.isLadiesSeat = "false";
                                objSeatsLayout.Seats.Add(objSeat);
                            }

                        }
                    }

                    #region boarding and dropping points

                    BoardingDroppingPoints bpList = new BoardingDroppingPoints();
                    string strb = URL + "/Server.aspx?Method=GetBoardingPoints&ServiceId=" + serviceId + "&SorceStationid=" + sourceId + "&Key=" + ConsumerKey;
                    DataSet dsb = convertXMLtoDataset(getJSONReponse(strb));
                    DataTable dtBoarding = new DataTable();
                    dtBoarding = dsb.Tables[0];
                    if (dtBoarding != null && dtBoarding.TableName == "BoardingPoints")
                    {

                        for (int i = 0; i < dtBoarding.Rows.Count; i++)
                        {

                            string strBoarding;
                            string strBoardingAddress;
                            strBoarding = dtBoarding.Rows[i]["BoardindPointID"].ToString();
                            strBoardingAddress = dtBoarding.Rows[i]["BoardindPointName"].ToString();
                            if (strBoardingAddress != null && strBoardingAddress != "")
                            {
                                string[] BoardingId = strBoarding.ToString().Split('-');
                                string[] BoardingAddress = strBoardingAddress.ToString().Split('-');
                                BoardingDroppingDetails point = new BoardingDroppingDetails();
                                if (Convert.ToString(BoardingId[0]).Trim() != "")
                                {
                                    point.pointId = BoardingId[0].ToString();
                                }
                                if (Convert.ToString(BoardingAddress[0]).Trim() != "")
                                {
                                    point.location = BoardingId[1].ToString() + "," + BoardingAddress[0].ToString();
                                }
                                if (Convert.ToString(BoardingAddress[1]).Trim() != "")
                                {
                                    point.time = BoardingAddress[1].ToString();
                                }

                                bpList.Add(point);

                            }
                        }
                        if (bpList.Count > 0)
                            objSeatsLayout.boardingTimes = bpList;
                    }
                    else
                    {
                        BoardingDroppingDetails point = new BoardingDroppingDetails();
                        point.pointId = "0";
                        point.location = "No Boarding Points";
                        point.time = "00.00";
                        bpList.Add(point);
                        if (bpList.Count > 0)
                            objSeatsLayout.boardingTimes = bpList;
                    }
                    #endregion
                }


            }
            catch (Exception)
            {

                throw;
            }

            return objSeatsLayout;

        }



        /// <summary>
        /// Method for getting the seat selection and blocking based on date, source, destination, and seat numbers
        /// </summary>
        /// <returns></returns>
        public BlockSeatsResponse getBlockTicket(int sourceId, int destinationId, String dateOfJourney, String serviceId,
             String selectedSeats, String URL, String ConsumerKey)
        {
            BlockSeatsResponse objBlockSeatsResponse = new BlockSeatsResponse();

            try
            {

                objBlockSeatsResponse.Status = "SUCCESS";

            }
            catch (Exception ex)
            {
                // to do
            }
            return objBlockSeatsResponse;
        }


        /// <summary>
        /// Method for booking a seat by passing the required information like date, source, destination etc.......
        /// </summary>
        /// <returns></returns>
        public BookSeatsResponse bookSeats(int sourceId, int destinationId, String dateOfJourney, String serviceId, String selectedSeats, String gender,
                String passengerName, String boardingPointId, String custAddress, String custName, String custPhoneNo,
                String custEmailId, String referenceNo, String URL, String ConsumerKey)
        {
            BookSeatsResponse objBookSeatsResponse = new BookSeatsResponse();
            try
            {
                String Gender = null;
                String Emails = null;
                String Phones = null;
                string g;
                string email;
                string phone;
                string[] gen = gender.ToString().Split(',');
                int k = gen.Count();
                if (k != 1)
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (Convert.ToString(gen[i]).Trim() == "MALE")
                        {
                            g = "M";
                            email = custEmailId;
                            phone = custPhoneNo;
                        }
                        else
                        {
                            g = "F";
                            email = custEmailId;
                            phone = custPhoneNo;
                        }
                        Gender = Gender + "," + g;
                        Emails = Emails + "," + email;
                        Phones = Phones + "," + phone;

                    }
                }
                else
                {
                    if (gender == "MALE")
                    {
                        Gender = "M";
                        Emails = custEmailId;
                        Phones = custPhoneNo;
                    }
                    else
                    {
                        Gender = "F";
                        Emails = custEmailId;
                        Phones = custPhoneNo;
                    }
                }
                if (Gender.StartsWith(","))
                {
                    Gender = Gender.Substring(1);
                }
                if (Emails.StartsWith(","))
                {
                    Emails = Emails.Substring(1);
                }
                if (Phones.StartsWith(","))
                {
                    Phones = Phones.Substring(1);
                }

                //Convert mm-dd-yyyy format to API compatible format dd-mm-yyyy
                dateOfJourney = dateOfJourney.Split('-')[1] + "/" + dateOfJourney.Split('-')[0] + "/" + dateOfJourney.Split('-')[2];
                // requestBody = URL + "/server.aspx?Method=BookTicket&SorceStationid=" + sourceId + "&DestinationStationid=" + destinationId + "&DateofJourney=" + dateOfJourney + "&ServiceId=" + serviceId + "&Seats=" + selectedSeats + "&PassName=" + passengerName + "&Email=" + custEmailId + "&ContactNo=" + custPhoneNo + "&Gender=" + gender + "&Address=" + custAddress + "&SeatFare=550" + "&BoardingId="+boardingPointId + "&Key=" + ConsumerKey;
                requestBody = URL + "/server.aspx?Method=BookTicket&SorceStationid=" + sourceId + "&DestinationStationid=" + destinationId + "&DateofJourney=" + dateOfJourney + "&ServiceId=" + serviceId + "&Seats=" + selectedSeats + "&PassName=" + passengerName + "&Email=" + Emails + "&ContactNo=" + Phones + "&Gender=" + Gender + "&Address=" + custAddress + "&SeatFare=550" + "&BoardingId=" + boardingPointId + "&Key=" + ConsumerKey;

                DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
                DataTable dtBookTicket = new DataTable();
                dtBookTicket = ds.Tables[0];
                if (dtBookTicket != null)
                {
                    objBookSeatsResponse.Status = "Success";
                    objBookSeatsResponse.APIPNR = dtBookTicket.Rows[0]["PNRNumber"].ToString();
                    objBookSeatsResponse.OperatorPNR = dtBookTicket.Rows[0]["PNRNumber"].ToString();
                    objBookSeatsResponse.Message = dtBookTicket.Rows[0]["Message"].ToString();
                }

                objBookSeatsResponse.OperaterNo = "AfterResponse";
            }
            catch (Exception ex)
            {
                // to do
            }
            return objBookSeatsResponse;
            //return null;
        }


        public DataTable cancelTicket(String URL, String ConsumerKey, String ticketNo, String seatnumbers, String dateofjourney)
        {
            try
            {
                //Convert mm-dd-yyyy format to API compatible format dd-mm-yyyy
                // dateofjourney = dateofjourney.Split('-')[1] + "/" + dateofjourney.Split('-')[0] + "/" + dateofjourney.Split('-')[2];

                requestBody = URL + "/Server.aspx?Method=CancelTicket&Seats=" + seatnumbers + "&TicketNumber=" + ticketNo + "&DateofJourney=" + dateofjourney + "&Key=" + ConsumerKey;
                DataSet ds = convertXMLtoDataset(getJSONReponse(requestBody));
                DataTable dtcancelTicket = new DataTable();
                dtcancelTicket = ds.Tables[0];
                if (dtcancelTicket != null)
                {
                    if (dtcancelTicket.Rows.Count > 0)
                    {
                        if (dtcancelTicket.Rows[0]["Message"].ToString().ToUpper().Trim().ToString() == "Your Ticket has been cancelled")
                        {
                            return dtcancelTicket;
                        }
                    }
                }
                return dtcancelTicket;


            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Private Methods

        private String getJSONReponse(String requestBody)
        {
            return invokeGetRequest(requestBody, @"application/xml");
        }

        private XmlNodeList getXmlNodeList(String requestBody, String URL, String ConsumerKey)
        {
            try
            {
                String response = invokePostRequest(URL + "?SecurityKey=" + ConsumerKey, requestBody, @"application/json");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response);
                return xmlDoc.GetElementsByTagName("struct");
            }
            catch (Exception ex)
            {
                //log exception
                //to do
                return null;
            }
        }
        #endregion
    }
}
