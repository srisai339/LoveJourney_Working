#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
 * Version          : 1.0
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using LJ.CLB.DTO;
using Newtonsoft.Json;
using System.Linq;

namespace LJ.CLB.Buses
{
    /// <summary>
    /// Abhibus Class has the methods that calls Abhibus API service
    /// </summary>
    public class AbhibusAPI : BusesBaseClass
    {
        #region Declarations

        String requestBody;
        XmlNodeList xmlNodes;
        DataTable dtResponse;

        #endregion
        #region Public Methods

        /// <summary>
        /// Method for getting all the sources
        /// </summary>
        /// <returns>source list string</returns>
        public String getSources(String URL, String ConsumerKey)
        {
            try
            {
                requestBody = "<?xml version='1.0'?><methodCall><methodName>index.getSourceList</methodName>";
                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
                dtResponse = new DataTable();
                if (xmlNodes != null)
                {
                    dtResponse.Columns.Add("id");
                    dtResponse.Columns.Add("name");

                    foreach (XmlNode xNode in xmlNodes)
                    {
                        String cityId = xNode.SelectNodes("member/value/string")[0].InnerText;
                        String cityName = xNode.SelectNodes("member/value/string")[1].InnerText;
                        object[] o = { cityId, cityName };
                        dtResponse.Rows.Add(o);
                    }
                }
                return JsonConvert.SerializeObject(dtResponse);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Method for getting destinations based on source id
        /// </summary>
        /// <returns></returns>
        public String getDestinations(String URL, String ConsumerKey)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
            "<methodName>index.getDestinationList</methodName>" +
            "<params><param><value><struct>" +
            "<member><name>sourceid</name><value><string>" + 1030 + "</string></value></member>" +
            "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                dtResponse.Columns.Add("cityId");
                dtResponse.Columns.Add("cityName");
                foreach (XmlNode xNode in xmlNodes)
                {
                    String cityId = xNode.SelectNodes("member/value/string")[0].InnerText;
                    String cityName = xNode.SelectNodes("member/value/string")[1].InnerText;
                    object[] o = { cityId, cityName };
                    dtResponse.Rows.Add(o);

                }
            }
            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        /// <summary>
        /// Method for getting all the available buses based on source, destination and date of journey
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="dateOfJourney"></param>
        /// <param name="seatCount"></param>
        /// <param name="seatType">seat/sleeper</param>
        /// <param name="URL"></param>
        /// <param name="ConsumerKey"></param>
        /// <returns></returns>
        public AvailableTrips getBusAvailability(int sourceId, int destinationId, String dateOfJourney, Int16 seatCount,
             String seatType, String URL, String ConsumerKey, string providername)
        {
            //Convert dd-mm-yyyy format to API compatible format yyyy-mm-dd
            dateOfJourney = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];
            try
            {
                requestBody = "<?xml version='1.0'?><methodCall>" +
                "<methodName>select.bustojurney</methodName>" +
                "<params><param><value><struct>" +
                "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
                 "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
                  "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
                   "<member><name>psgr_count</name><value><string>" + seatCount + "</string></value></member>" +
                   "<member><name>seat_sleeper</name><value><string>" + seatType + "</string></value></member>" +
                "</struct></value></param></params></methodCall>";

                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

                AvailableTrips objAvailableTrips = new AvailableTrips();

                if (xmlNodes != null)
                {
                    foreach (XmlNode xNode in xmlNodes)
                    {
                        LJ.CLB.DTO.TripDetails objTripDetails = new DTO.TripDetails();

                        objTripDetails.providerName = providername;
                        objTripDetails.boardingTimes = null;//String.Empty;
                        objTripDetails.cancellationPolicy = String.Empty;
                        objTripDetails.droppingTimes = null;//String.Empty;
                        objTripDetails.sourceId = int.Parse(sourceId.ToString());
                        objTripDetails.destinationId = int.Parse(destinationId.ToString());
                        objTripDetails.partialCancellationAllowed = "false";

                        XmlNodeList nodeNameList = xNode.SelectNodes("member/name");
                        XmlNodeList nodeValueList = xNode.SelectNodes("member/value");

                        for (int i = 0; i < nodeNameList.Count; i++)
                        {
                            switch (nodeNameList.Item(i).InnerText.ToLower())
                            {
                                case "service_id":
                                    objTripDetails.id = nodeValueList.Item(i).InnerText;
                                    break;
                                case "traveler_agent":
                                    if (nodeValueList.Item(i).InnerText == "")
                                    {
                                        objTripDetails.travels = "Kallada Tours & Travels";
                                    }
                                    else
                                    {
                                        objTripDetails.travels = nodeValueList.Item(i).InnerText;
                                    }
                                    break;
                                case "departure_time":
                                    objTripDetails.departureTime = nodeValueList.Item(i).InnerText;
                                    break;
                                case "arrival_time":
                                    objTripDetails.arrivalTime = nodeValueList.Item(i).InnerText;
                                    break;
                                case "seat_fare_with_taxes":
                                case "seat_fare":
                                    objTripDetails.fares = nodeValueList.Item(i).InnerText;
                                    break;
                                case "totalavailableseats":
                                    objTripDetails.availableSeats = nodeValueList.Item(i).InnerText;
                                    break;
                                case "remaining_seats":
                                    objTripDetails.availableSeats = nodeValueList.Item(i).InnerText;
                                    break;
                                case "service_type":
                                    objTripDetails.busType = nodeValueList.Item(i).InnerText;
                                    break;
                                case "boardingpoints":
                                    #region Boarding Points
                                    string strBP = "";
                                    XmlDocument xmlDocBP = new XmlDocument();
                                    xmlDocBP.LoadXml(nodeValueList.Item(i).InnerXml);
                                    XmlNodeList nodesBP = xmlDocBP.GetElementsByTagName("array");
                                    foreach (XmlNode item in nodesBP)
                                    {
                                        foreach (XmlNode item1 in item.SelectNodes("data/value"))
                                        {
                                            strBP = (strBP == "") ? item1.InnerText : strBP + "%&&&%" + item1.InnerText;
                                        }
                                    }
                                    //objTripDetails.boardingTimes = strBP;
                                    objTripDetails.boardingTimes = Points(strBP, objTripDetails.travels);
                                    #endregion
                                    break;
                                case "droppingpoints":
                                    #region Dropping Points
                                    string strDP = "";//nodeValueList.Item(i).InnerXml;
                                    XmlDocument xmlDocDP = new XmlDocument();
                                    xmlDocDP.LoadXml(nodeValueList.Item(i).InnerXml);
                                    XmlNodeList nodesDP = xmlDocDP.GetElementsByTagName("array");
                                    foreach (XmlNode item in nodesDP)
                                    {
                                        foreach (XmlNode item1 in item.SelectNodes("data/value"))
                                        {
                                            strDP = (strDP == "") ? item1.InnerText : strDP + ";" + item1.InnerText;
                                        }
                                    }
                                    objTripDetails.droppingTimes = Points(strDP, objTripDetails.travels);

                                    #endregion
                                    break;
                                default:
                                    break;
                            }
                        }
                        objTripDetails.duration = Duration(objTripDetails.departureTime, objTripDetails.arrivalTime);
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
        /// Method for getting the seat layout based on source, destination, date of journey and serviceid
        /// </summary>
        /// <returns></returns>
        public SeatsInfo getBusSeatLayout(int sourceId, int destinationId, String dateOfJourney, String serviceId,
             String seatType, String URL, String ConsumerKey)
        {
            // SeatsInfo objSeatsLayout = new SeatsInfo();
            SeatsInfo objSeatsLayout = null;
            string tot_Seat_num = "";
            string tot_availableseat_num = ""; string gendertype = ""; string bookedseats = "";
            string lowerdeck_seat_nos = ""; string upperdeck_seat_nos = "";
            string layoutid = ""; string seat_fare = "";
            int length = 1; int width = 1; int zIdnex = 0;

            try
            {
                dateOfJourney = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];

                requestBody = "<?xml version='1.0'?><methodCall>" +
                "<methodName>index.busseating</methodName>" +
                "<params><param><value><struct>" +
                "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
                 "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
                  "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
                   "<member><name>serviceid</name><value><string>" + serviceId + "</string></value></member>" +
                   "<member><name>seat_sleeper</name><value><string>" + seatType + "</string></value></member>" +
                "</struct></value></param></params></methodCall>";

                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
                //objSeatsLayout.Seats = new List<SeatLayout>();

                string names = string.Empty;
                string values = string.Empty;

                if (xmlNodes != null)
                {
                    foreach (XmlNode xNode in xmlNodes)
                    {
                        XmlNodeList nodeNameList = xNode.SelectNodes("member/name");
                        XmlNodeList nodeValueList = xNode.SelectNodes("member/value");

                        for (int i = 0; i < nodeNameList.Count; i++)
                        {
                            names = names + "$%^^%$" + nodeNameList.Item(i).InnerText;
                            values = values + "$%^^%$" + nodeValueList.Item(i).InnerText;

                            if (nodeNameList.Item(i).InnerText == "layoutid")
                            {
                                layoutid = nodeValueList.Item(i).InnerText;
                            }
                            else if (nodeNameList.Item(i).InnerText == "seat_fare_with_taxes" || nodeNameList.Item(i).InnerText == "seat_fare")//seat_fare_with_taxes,seat_fare
                            {
                                seat_fare = nodeValueList.Item(i).InnerText;
                            }
                            //else if (nodeNameList.Item(i).InnerText == "tot_availableseat_num")//seat_nos,tot_availableseat_num
                            //{
                            //    tot_availableseat_num = "";//nodeValueList.Item(i).InnerText;
                            //    XmlDocument xmlDoc = new XmlDocument();
                            //    xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                            //    XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                            //    foreach (XmlNode item in t)
                            //    {
                            //        foreach (XmlNode item1 in item.SelectNodes("data/value"))
                            //        {
                            //            tot_availableseat_num = tot_availableseat_num == "" ? item1.InnerText : tot_availableseat_num + ";" + item1.InnerText;
                            //        }
                            //    }

                            //}
                            //else if (nodeNameList.Item(i).InnerText == "seat_nos")//seat_nos,tot_availableseat_num
                            //{
                            //    tot_Seat_num = "";//nodeValueList.Item(i).InnerText;
                            //    XmlDocument xmlDoc = new XmlDocument();
                            //    xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                            //    XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                            //    foreach (XmlNode item in t)
                            //    {
                            //        foreach (XmlNode item1 in item.SelectNodes("data/value"))
                            //        {
                            //            tot_Seat_num = tot_Seat_num == "" ? item1.InnerText : tot_Seat_num + ";" + item1.InnerText;
                            //        }
                            //    }
                            //    //bookedseats = tot_Seat_num - tot_availableseat_num;

                            //}
                            else if (nodeNameList.Item(i).InnerText == "bookedseats")
                            {
                                bookedseats = "";//nodeValueList.Item(i).InnerText;
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                                XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                                foreach (XmlNode item in t)
                                {
                                    foreach (XmlNode item1 in item.SelectNodes("data/value"))
                                    {
                                        bookedseats = bookedseats == "" ? item1.InnerText : bookedseats + ";" + item1.InnerText;
                                    }
                                }

                            }
                            //else if (nodeNameList.Item(i).InnerText == "gendertype")
                            //{
                            //    gendertype = "";//nodeValueList.Item(i).InnerText;
                            //    XmlDocument xmlDoc = new XmlDocument();
                            //    xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                            //    XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                            //    foreach (XmlNode item in t)
                            //    {
                            //        foreach (XmlNode item1 in item.SelectNodes("data/value"))
                            //        {
                            //            gendertype = gendertype == "" ? item1.InnerText : gendertype + ";" + item1.InnerText;
                            //        }
                            //    }
                            //}
                            else if (nodeNameList.Item(i).InnerText == "serv_layout_type")
                            {
                                if (nodeValueList.Item(i).InnerText == "S")
                                {
                                    length = 1;
                                    width = 1;
                                    zIdnex = 0;
                                }
                                if (nodeValueList.Item(i).InnerText == "B")
                                {
                                    length = 2;
                                    width = 1;
                                    zIdnex = 0;
                                }
                            }
                            else if (nodeNameList.Item(i).InnerText == "lowerdeck_seat_nos")
                            {
                                lowerdeck_seat_nos = "";//nodeValueList.Item(i).InnerXml;
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                                XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                                foreach (XmlNode item in t)
                                {
                                    foreach (XmlNode item1 in item.SelectNodes("data/value"))
                                    {
                                        lowerdeck_seat_nos = lowerdeck_seat_nos == "" ? item1.InnerText : lowerdeck_seat_nos + ";" + item1.InnerText;
                                    }
                                }
                            }
                            else if (nodeNameList.Item(i).InnerText == "upperdeck_seat_nos")
                            {
                                upperdeck_seat_nos = "";//nodeValueList.Item(i).InnerXml;
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.LoadXml(nodeValueList.Item(i).InnerXml);
                                XmlNodeList t = xmlDoc.GetElementsByTagName("array");
                                foreach (XmlNode item in t)
                                {
                                    foreach (XmlNode item1 in item.SelectNodes("data/value"))
                                    {
                                        upperdeck_seat_nos = upperdeck_seat_nos == "" ? item1.InnerText : upperdeck_seat_nos + ";" + item1.InnerText;
                                    }
                                }
                            }
                        }
                    }
                    //return SeatLayout(tot_availableseat_num, bookedseats, gendertype, lowerdeck_seat_nos, upperdeck_seat_nos, seat_fare, layoutid, length, width, zIdnex);
                    return SeatLayout(tot_availableseat_num, tot_Seat_num, bookedseats, gendertype, lowerdeck_seat_nos, upperdeck_seat_nos, seat_fare, layoutid, length, width, zIdnex);
                }

            }
            catch (Exception ex)
            {
                // to do
            }
            return objSeatsLayout;

        }
        string feseat = string.Empty;
        string tot = string.Empty;
        string strbseats = string.Empty;
        string[] strseatarr;

        SeatsInfo SeatLayout(String tot_availableseat_num, string tot_Seat_num, String bookedseats, String gendertype,
             String lowerdeck_seat_nos, String upperdeck_seat_nos,
             String seat_fare, String layoutid, int length, int width, int zIdnex)
        {
            try
            {
                SeatsInfo objSeatsLayout = new SeatsInfo();
                objSeatsLayout.Seats = new List<SeatLayout>();
                //string[] seatLayoutStringArray = tot_availableseat_num.Split(';');
                //string[] Bookedseats = tot_Seat_num.Split(';');
                string[] seatLayoutStringArray = lowerdeck_seat_nos.Split(';');
                string[] Bookedseats = upperdeck_seat_nos.Split(';');
                string[] BSeats = bookedseats.Split(';');

                foreach (string bseat in BSeats)
                {
                    if (bseat != "" && bseat != "#*#-")
                    {
                        string[] star = new string[1];
                        star[0] = "#*#";
                        string[] st = bseat.Split(star, StringSplitOptions.None);
                        if (Convert.ToString(strbseats) == "")
                        {
                            strbseats = st[0].ToString();
                        }
                        else
                        {
                            strbseats = strbseats + ";" + st[0].ToString();
                        }
                    }

                }


                string[] strseatarr = strbseats.ToString().Split(';');
                foreach (string femaleseat in strseatarr)
                {
                    foreach (string seat in seatLayoutStringArray)
                    {
                        if (seat != "" && seat != "#*#-")
                        {
                            //R3 #*# 1-2 #*# S #*# B #*# F
                            string[] star = new string[1];
                            star[0] = "#*#";
                            string[] st = seat.Split(star, StringSplitOptions.None);
                            if (Convert.ToString(st[0]).Trim() != "")
                            {
                                if (Convert.ToString(st[2]).Trim() != "B")
                                {

                                    if (st.Count() > 4)
                                    {
                                        if (Convert.ToString(st[4]).Trim() == "F")
                                        {
                                            if (Convert.ToString(st[0]).Trim() == Convert.ToString(femaleseat).Trim())
                                            {
                                                if (femaleseat.Contains('L'))
                                                {
                                                    if (femaleseat.ToString().Split('L')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('L')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat ="L"+ Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('L')[1]) - 1) ;
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "L" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('L')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "L" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('L')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "L" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('L')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('R'))
                                                {
                                                    if (femaleseat.ToString().Split('R')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('R')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                feseat = "R" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('R')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "R" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('R')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "R" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('R')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "R" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('R')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('A'))
                                                {
                                                    if (femaleseat.ToString().Split('A')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('A')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "A" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('A')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "A" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('A')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "A" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('A')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "A" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('A')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('B'))
                                                {
                                                    if (femaleseat.ToString().Split('B')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('B')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "B" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('B')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "B" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('B')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "B" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('B')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "B" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('B')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('C'))
                                                {
                                                    if (femaleseat.ToString().Split('C')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('C')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "C" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('C')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "C" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('C')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "C" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('C')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "C" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('C')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('D'))
                                                {
                                                    if (femaleseat.ToString().Split('D')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('D')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "D" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('D')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "D" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('D')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "D" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('D')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "D" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('D')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('E'))
                                                {
                                                    if (femaleseat.ToString().Split('E')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('E')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "E" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('E')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "E" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('E')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "E" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('E')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "E" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('E')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('F'))
                                                {
                                                    if (femaleseat.ToString().Split('F')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('F')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "F" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('F')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "F" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('F')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "F" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('F')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "F" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('F')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('G'))
                                                {
                                                    if (femaleseat.ToString().Split('G')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('G')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "G" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('G')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "G" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('G')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "G" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('G')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "G" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('G')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('H'))
                                                {
                                                    if (femaleseat.ToString().Split('H')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('H')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "H" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('H')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "H" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('H')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "H" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('H')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "H" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('H')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('I'))
                                                {
                                                    if (femaleseat.ToString().Split('I')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('I')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "I" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('I')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "I" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('I')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "I" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('I')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "I" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('I')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('J'))
                                                {
                                                    if (femaleseat.ToString().Split('J')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('J')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "J" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('J')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "J" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('J')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "J" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('J')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "J" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('J')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('K'))
                                                {
                                                    if (femaleseat.ToString().Split('K')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('K')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "K" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('K')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "K" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('K')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "K" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('K')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "K" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('K')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (femaleseat.Contains('V'))
                                                {
                                                    if (femaleseat.ToString().Split('V')[1] != "")
                                                    {
                                                        if (Convert.ToInt32(femaleseat.ToString().Split('V')[1]) % 2 == 0)
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //even
                                                                feseat = "V" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('V')[1]) - 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "V" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('V')[1]) - 1);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(feseat) == "")
                                                            {
                                                                //odd
                                                                feseat = "V" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('V')[1]) + 1);
                                                            }
                                                            else
                                                            {
                                                                feseat = feseat + ";" + "V" + Convert.ToString(Convert.ToInt32(femaleseat.ToString().Split('V')[1]) + 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(femaleseat) % 2 == 0)
                                                    {
                                                        if (Convert.ToString(feseat) == "")
                                                        {
                                                            //even
                                                            feseat = Convert.ToString(Convert.ToInt32(femaleseat) - 1);
                                                        }
                                                        else
                                                        {
                                                            feseat = feseat + ";" + Convert.ToString(Convert.ToInt32(femaleseat) - 1);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(feseat) == "")
                                                        {
                                                            //odd
                                                            feseat = Convert.ToString(Convert.ToInt32(femaleseat) + 1);
                                                        }
                                                        else
                                                        {
                                                            feseat = feseat + ";" + Convert.ToString(Convert.ToInt32(femaleseat) + 1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                foreach (string seat in seatLayoutStringArray)
                {
                    if (seat != "" && seat != "#*#-")
                    {
                        //R3 #*# 1-2 #*# S #*# B #*# F
                        string[] star = new string[1];
                        star[0] = "#*#";
                        string[] st = seat.Split(star, StringSplitOptions.None);
                        if (Convert.ToString(st[0]).Trim() != "")
                        {

                            string[] stRowColumn = st[1].ToString().Split('-');
                            string strseat2 = st[0].ToString().Trim();
                            SeatLayout objSeat = new SeatLayout();
                            objSeat.column = Convert.ToInt32(stRowColumn[1].ToString().Trim());
                            objSeat.fare = seat_fare;
                            objSeat.id = layoutid;
                            if (Convert.ToString(st[3]).Trim() == "A")
                            {
                                objSeat.isAvailableSeat = "true";
                            }
                            else
                            {
                                objSeat.isAvailableSeat = "false";

                            }
                            if (Convert.ToString(st[2]).Trim() == "B")
                            {
                                if (st.Count() > 4)
                                {
                                    if (Convert.ToString(st[4]).Trim() == "F")
                                    {
                                        objSeat.isLadiesSeat = "true";
                                    }
                                    else
                                    {
                                        objSeat.isLadiesSeat = null;
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToString(st[3]).Trim() == "A")
                                {
                                    string[] seatstr = feseat.ToString().Split(';');
                                    if (seatstr.Length >= 1)
                                    {
                                        foreach (string f in seatstr)
                                        {
                                            if (f.Contains('L'))
                                            {
                                                if (Convert.ToString(st[0]).Trim() == Convert.ToString(f))
                                                {
                                                    objSeat.isLadiesSeat = "true";
                                                    break;
                                                }
                                                else
                                                {
                                                    objSeat.isLadiesSeat = "false";
                                                }
                                            }
                                            else if (f.Contains('R'))
                                            {
                                                if (Convert.ToString(st[0]).Trim() == Convert.ToString(f))
                                                {
                                                    objSeat.isLadiesSeat = "true";
                                                    break;
                                                }
                                                else
                                                {
                                                    objSeat.isLadiesSeat = "false";
                                                }
                                            }
                                            else
                                                if (Convert.ToString(st[0]).Trim() == Convert.ToString(f))
                                                {
                                                    objSeat.isLadiesSeat = "true";
                                                    break;
                                                }
                                                else
                                                {
                                                    objSeat.isLadiesSeat = "false";
                                                }
                                        }

                                    }
                                }
                                else
                                {
                                    objSeat.isLadiesSeat = "false";
                                }
                                
                            }





                            //}
                            //else
                            //{
                            //    objSeat.isLadiesSeat = null;
                            //}
                            objSeat.length = length;
                            objSeat.number = Convert.ToString(st[0]).Trim();
                            objSeat.row = Convert.ToInt32(Convert.ToString(stRowColumn[0]).Trim());
                            objSeat.width = width;
                            objSeat.zIndex = zIdnex;
                            objSeatsLayout.Seats.Add(objSeat);
                        }

                    }
                }
                #region comment code
                // tot_Seat_num = tot_Seat_num + ";";
                // string[] Bookedseats = tot_Seat_num.Split(';');
                //SeatLayout objSeat1 = new SeatLayout();
                //foreach (string seat2 in seatLayoutStringArray)//available seats
                //{
                //    string[] star = new string[1];
                //    star[0] = "#*#";
                //    string[] st = seat2.Split(star, StringSplitOptions.None);
                //    string strseat2 = st[0].ToString().Trim();
                //    string[] stRowColumn = st[1].ToString().Split('-');
                //    foreach (string seat3 in Bookedseats)
                //    {
                //        string[] star1 = new string[1];
                //        star1[0] = "#*#";
                //        string[] st1 = seat3.Split(star, StringSplitOptions.None);
                //        string strseat3 = st1[0].ToString().Trim();
                //        tot = "";
                //        if (strseat2 == strseat3)
                //        {
                //            tot_Seat_num = tot_Seat_num.Replace(seat3 + ";", "");
                //            break;
                //        }
                //    }

                //}


                //tot_Seat_num = tot_Seat_num.Replace("L5 #*# 5-12", "");
                //string[] Bookedseats1 = tot_Seat_num.Split(';');
                //foreach (string seat5 in Bookedseats1)
                //{
                //    string[] star1 = new string[1];
                //    star1[0] = "#*#";
                //    string[] st1 = seat5.Split(star1, StringSplitOptions.None);
                //    string strseat3 = st1[0].ToString().Trim();
                //    string[] seatLayoutStringArray4 = bookedseats.Split(';');
                //    foreach (string seat4 in seatLayoutStringArray4)
                //    {
                //        if (seat4 != "" && seat4 != "#*#-")
                //        {
                //            string[] star4 = new string[1];
                //            star4[0] = "#*#";
                //            string[] st4 = seat4.Split(star4, StringSplitOptions.None);
                //            string strseat4 = st4[0].ToString();
                //            if (strseat3 == strseat4)
                //            {
                //                tot_Seat_num = tot_Seat_num.Replace(seat5 + ";", "");
                //            }
                //        }
                //    }
                //}
                //bookedseats = bookedseats + ";" + tot_Seat_num;
                #endregion


                string[] seatLayoutStringArray1 = upperdeck_seat_nos.Split(';');
                string[] seatLayoutStringArray2 = gendertype.Split(';');
                //int k = 0;
                foreach (string seat1 in seatLayoutStringArray1)
                {
                    if (seat1 != "" && seat1 != "#*#-")
                    {
                        string[] star = new string[1];
                        star[0] = "#*#";
                        string[] st = seat1.Split(star, StringSplitOptions.None);
                        if (Convert.ToString(st[0]).Trim() != "")
                        {
                            string[] stRowColumn = st[1].ToString().Split('-');

                            SeatLayout objSeat = new SeatLayout();
                            objSeat.column = Convert.ToInt32(stRowColumn[1].ToString().Trim());
                            objSeat.fare = seat_fare;
                            objSeat.id = layoutid;
                            if (Convert.ToString(st[3]).Trim() == "A")
                            {
                                objSeat.isAvailableSeat = "true";
                            }
                            else
                            {
                                objSeat.isAvailableSeat = "false";
                            }
                            if (st.Count() > 4)
                            {
                                if (Convert.ToString(st[4]).Trim() == "F")
                                {
                                    objSeat.isLadiesSeat = "true";
                                }
                                else
                                {
                                    objSeat.isLadiesSeat = null;
                                }

                            }
                            else
                            {
                                objSeat.isLadiesSeat = null;
                            }
                            objSeat.length = length;
                            objSeat.number = Convert.ToString(st[0]).Trim();
                            objSeat.row = Convert.ToInt32(Convert.ToString(stRowColumn[0]).Trim());
                            objSeat.width = width;
                            objSeat.zIndex = zIdnex;
                            objSeatsLayout.Seats.Add(objSeat);
                        }
                    }
                    //k += 1;

                }
                objSeatsLayout.boardingTimes = null;
                return objSeatsLayout;
            }
            catch (Exception ex)
            {
                return null;
            }
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
                dateOfJourney = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];

                requestBody = "<?xml version='1.0'?><methodCall>" +
                "<methodName>index.seatselection</methodName>" +
                "<params><param><value><struct>" +
                "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
                "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
                "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
                "<member><name>serviceid</name><value><string>" + serviceId + "</string></value></member>" +
                "<member><name>selected_seats</name><value><string>" + selectedSeats + "</string></value></member>" +
                "</struct></value></param></params></methodCall>";

                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
                string sel_seats = "", total_fare = "";
                if (xmlNodes != null)
                {
                    foreach (XmlNode xNode in xmlNodes)
                    {
                        XmlNodeList nodeNameList = xNode.SelectNodes("member/name");
                        XmlNodeList nodeValueList = xNode.SelectNodes("member/value");

                        for (int i = 0; i < nodeNameList.Count; i++)
                        {
                            if (nodeNameList.Item(i).InnerText == "sel_seats")
                            {
                                sel_seats = nodeValueList.Item(i).InnerText;
                            }
                            else if (nodeNameList.Item(i).InnerText == "sel_seat_row_cols")
                            {
                                string sel_seat_row_cols = nodeValueList.Item(i).InnerText;
                            }
                            else if (nodeNameList.Item(i).InnerText == "total_fare")
                            {
                                total_fare = nodeValueList.Item(i).InnerText;
                            }
                        }
                    }
                }

                if (sel_seats != "" && total_fare != "")
                {
                    objBlockSeatsResponse.Status = "SUCCESS";
                }
                else
                {
                    objBlockSeatsResponse.Status = "FAIL";
                }
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
                //dateOfJourney = "5/2/2013";
                //yyyy-MM-dd
                if (dateOfJourney.Contains('/'))
                {
                    if (dateOfJourney.Split('/')[0].Length == 1 && dateOfJourney.Split('/')[1].Length == 1)
                    {
                        dateOfJourney = dateOfJourney.Split('/')[2] + "-" + "0" + dateOfJourney.Split('/')[0] + "-" + "0" + dateOfJourney.Split('/')[1];
                    }
                    else if (dateOfJourney.Split('/')[0].Length == 1)
                    {
                        dateOfJourney = dateOfJourney.Split('/')[2] + "-" + "0" + dateOfJourney.Split('/')[0] + "-" + dateOfJourney.Split('/')[1];
                    }
                    else if (dateOfJourney.Split('/')[1].Length == 1)
                    {
                        dateOfJourney = dateOfJourney.Split('/')[2] + "-" + dateOfJourney.Split('/')[0] + "-" + "0" + dateOfJourney.Split('/')[1];
                    }
                    else
                    {
                        dateOfJourney = dateOfJourney.Split('/')[2] + "-" + dateOfJourney.Split('/')[0] + "-" + dateOfJourney.Split('/')[1];
                    }
                }
                else
                {
                    dateOfJourney = dateOfJourney.Split('-')[2] + "-" + dateOfJourney.Split('-')[1] + "-" + dateOfJourney.Split('-')[0];
                }
                requestBody = "<?xml version='1.0'?><methodCall>" +
                    "<methodName>index.seatbooking</methodName>" +
                    "<params><param><value><struct>" +
                    "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
                    "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
                    "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
                    "<member><name>serviceid</name><value><string>" + serviceId + "</string></value></member>" +
                    "<member><name>selected_seats</name><value><string>" + selectedSeats + "</string></value></member>" +
                    "<member><name>psgr_gender_type</name><value><string>" + gender + "</string></value></member>" +
                    "<member><name>psgr_name</name><value><string>" + passengerName + "</string></value></member>" +
                    "<member><name>boardingpoint_id</name><value><string>" + boardingPointId + "</string></value></member>" +
                    "<member><name>customer_address</name><value><string> " + custAddress + " </string></value></member>" +
                    "<member><name>customer_name</name><value><string>" + custName + "</string></value></member>" +
                    "<member><name>customer_phoneno</name><value><string>" + custPhoneNo + "</string></value></member>" +
                    "<member><name>customer_email</name><value><string>" + custEmailId + "</string></value></member>" +
                    "<member><name>booking_ref_num</name><value><string>" + referenceNo + "</string></value></member>" +
                    "</struct></value></param></params></methodCall>";

                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

                if (xmlNodes != null)
                {
                    foreach (XmlNode xNode in xmlNodes)
                    {
                        XmlNodeList nodeNameList = xNode.SelectNodes("member/name");
                        XmlNodeList nodeValueList = xNode.SelectNodes("member/value");

                        for (int i = 0; i < nodeNameList.Count; i++)
                        {
                            switch (nodeNameList.Item(i).InnerText.ToLower())
                            {
                                case "status":
                                    objBookSeatsResponse.Status = nodeValueList.Item(i).InnerText;
                                    break;
                                case "ticket_num":
                                    objBookSeatsResponse.APIPNR = nodeValueList.Item(i).InnerText;
                                    break;
                                case "service_number":
                                    objBookSeatsResponse.OperatorPNR = nodeValueList.Item(i).InnerText;
                                    break;
                                case "message":
                                    objBookSeatsResponse.Message = nodeValueList.Item(i).InnerText;
                                    break;
                                //case "total_fare":
                                //    //total_fare = nodeValueList.Item(i).InnerText;
                                //    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                objBookSeatsResponse.OperaterNo = "AfterResponse";
            }
            catch (Exception ex)
            {
                // to do
            }
            return objBookSeatsResponse;
        }

        /// <summary>
        /// Method for checking the gender while booking the seat
        /// </summary>
        /// <returns></returns>
        public String checkGender(int sourceId, int destinationId, String dateOfJourney, String serviceId, String selectedSeats,
             String gender, String URL, String ConsumerKey)
        {
            //dateOfJourney - yymmdd
            //sourceId - 1030
            //destinationId - 1107
            //serviceId - 1245 
            //selectedSeats - "14,15"
            //gender = "Male";

            requestBody = "<?xml version='1.0'?><methodCall>" +
            "<methodName>index.checkgender</methodName>" +
            "<params><param><value><struct>" +
            "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
             "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
              "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
               "<member><name>serviceid</name><value><string>" + serviceId + "</string></value></member>" +
               "<member><name>selected_seats</name><value><string>" + selectedSeats + "</string></value></member>" +
               "<member><name>psgr_gender_type</name><value><string>" + gender + "</string></value></member>" +
            "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                //to do 
                //build dtresponse datatable
            }

            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        /// <summary>
        /// Method for checking the fare based on source and destination
        /// </summary>
        /// <returns></returns>
        public String getFareDetails(int sourceId, int destinationId, String dateOfJourney, String serviceId, String selectedSeats,
             String gender, String URL, String ConsumerKey)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
            "<methodName>select.bustojurney</methodName>" +
            "<params><param><value><struct>" +
            "<member><name>jdate</name><value><string>" + dateOfJourney + "</string></value></member>" +
             "<member><name>sourceid</name><value><string>" + sourceId + "</string></value></member>" +
              "<member><name>destinationid</name><value><string>" + destinationId + "</string></value></member>" +
            "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                //to do 
                //build dtresponse datatable
            }

            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        /// <summary>
        /// Method for getting all the stations information
        /// </summary>
        /// <returns></returns>
        public String getStations(String URL, String ConsumerKey)
        {
            try
            {
                requestBody = "<?xml version='1.0'?><methodCall><methodName>index.getStationsList</methodName>";
                xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
                dtResponse = new DataTable();
                if (xmlNodes != null)
                {
                    dtResponse.Columns.Add("id");
                    dtResponse.Columns.Add("name");

                    foreach (XmlNode xNode in xmlNodes)
                    {
                        String cityId = xNode.SelectNodes("member/value/string")[0].InnerText;
                        String cityName = xNode.SelectNodes("member/value/string")[1].InnerText;
                        object[] o = { cityId, cityName };
                        dtResponse.Rows.Add(o);
                    }
                }
                return JsonConvert.SerializeObject(dtResponse);
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Method for cancellation confirmation with the ticket number/PNR number
        /// </summary>
        /// <returns></returns>
        public string cancellationConfirmation(String URL, String ConsumerKey, String ticketNo)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
           "<methodName>index.cancellationconfirmation</methodName>" +
           "<params><param><value><struct>" +
           "<member><name>ticketno</name><value><string>" + ticketNo + "</string></value></member>" +
           "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                //to do 
                //build dtresponse datatable
            }

            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        /// <summary>
        /// Method for Ticket cancellation with the ticket number/PNR number
        /// </summary>
        /// <returns></returns>
        public DataTable cancelTicket(String URL, String ConsumerKey, String ticketNo)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
          "<methodName>index.ticketcancellation</methodName>" +
          "<params><param><value><struct>" +
          "<member><name>ticketno</name><value><string>" + ticketNo + "</string></value></member>" +
          "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);
            string ticket_number = "", message = "", status = "", total_ticket_fare = "", total_refund_amount = "", cancellation_parcentage = "";
            if (xmlNodes != null)
            {
                foreach (XmlNode xNode in xmlNodes)
                {
                    XmlNodeList nodeNameList = xNode.SelectNodes("member/name");
                    XmlNodeList nodeValueList = xNode.SelectNodes("member/value");

                    for (int i = 0; i < nodeNameList.Count; i++)
                    {
                        if (nodeNameList.Item(i).InnerText == "status")
                        {
                            status = nodeValueList.Item(i).InnerText;
                        }
                        else if (nodeNameList.Item(i).InnerText == "ticket_number")
                        {
                            ticket_number = nodeValueList.Item(i).InnerText;
                        }
                        else if (nodeNameList.Item(i).InnerText == "total_ticket_fare")
                        {
                            total_ticket_fare = nodeValueList.Item(i).InnerText;
                        }
                        else if (nodeNameList.Item(i).InnerText == "total_refund_amount")
                        {
                            total_refund_amount = nodeValueList.Item(i).InnerText;
                        }
                        else if (nodeNameList.Item(i).InnerText == "message")
                        {
                            message = nodeValueList.Item(i).InnerText;
                        }
                        else if (nodeNameList.Item(i).InnerText == "cancellation_parcentage")
                        {
                            cancellation_parcentage = nodeValueList.Item(i).InnerText;
                        }
                    }
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("ticket_number"); dt.Columns.Add("message"); dt.Columns.Add("status");
            dt.Columns.Add("total_ticket_fare"); dt.Columns.Add("total_refund_amount"); dt.Columns.Add("cancellation_parcentage");

            DataRow dr = dt.NewRow();
            dr["ticket_number"] = ticket_number;
            dr["message"] = message;
            dr["status"] = status;
            dr["total_ticket_fare"] = total_ticket_fare;
            dr["total_refund_amount"] = total_refund_amount;
            dr["cancellation_parcentage"] = cancellation_parcentage;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// Method for getting the ticket information by booking reference number
        /// </summary>
        /// <returns></returns>
        public String getTicketinformation(String URL, String ConsumerKey)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
            "<methodName>index.cancellationconfirmation</methodName>" +
            "<params><param><value><struct>" +
            "<member><name>booking_ref_num</name><value><string>" + 1030 + "</string></value></member>" +
            "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                //to do 
                //build dtresponse datatable
            }

            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }
        public String getticketinfo(String URL, String ConsumerKey, string REFNO)
        {
            requestBody = "<?xml version='1.0'?><methodCall>" +
            "<methodName>index.seatbooking</methodName>" +
            "<params><param><value><struct>" +
            "<member><name>booking_ref_num</name><value><string>" + REFNO + "</string></value></member>" +
            "</struct></value></param></params></methodCall>";

            xmlNodes = getXmlNodeList(requestBody, URL, ConsumerKey);

            dtResponse = new DataTable();
            if (xmlNodes != null)
            {
                //to do 
                //build dtresponse datatable
            }

            return JsonConvert.SerializeObject(dtResponse);
            //return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        #endregion
        #region Private Methods

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

        private BoardingDroppingPoints Points(string points,string Travel)
        {
            BoardingDroppingPoints bdPoints = new BoardingDroppingPoints();

            try
            {
                if (points != "")
                {
                    string[] str = new string[1];
                    str[0] = "%&&&%";
                    string[] ssstr = points.Split(str, StringSplitOptions.None);
                    foreach (string st in ssstr)
                    {
                        if (st != "")
                        {
                            //6 - Ameerpet^^Kaveri Travels Near Hotel Imrose,Towards Begumpet (Ph No:9246462060) - 10:15PM
                            string[] strsplit = st.Split('^');
                            string[] strArr = strsplit[0].Split('-');
                            string[] strtime = strsplit[2].Split('-');
                            BoardingDroppingDetails details = new BoardingDroppingDetails();
                            details.pointId = strArr[0].ToString();
                            details.time = strtime[strtime.Length - 1].ToString().Trim().ToString();
                            //string[] strphone = strtime[0].Split('(');
                            details.address = strsplit[2].ToString().Trim().ToString();
                            //details.contactNumbers = strphone[1].ToString().Split(')')[0].Trim().ToString();
                            //for (int i = 1; i < strArr.Length - 1; i++)
                            if (Travel != "Kaveri Kamakshi Travels")
                            {
                                details.name = strArr[1].ToString();
                            }
                            else
                            {
                                details.name = strArr[2].ToString();
                            }
                            // details.name = details.name + strArr[i].ToString();
                            bdPoints.Add(details);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // to do
            }
            return bdPoints;
        }


        #endregion
    }
}
