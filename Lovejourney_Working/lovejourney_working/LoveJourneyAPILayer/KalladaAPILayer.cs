using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CookComputing;
using CookComputing.XmlRpc;
using System.Collections;
using System.Collections.Generic;
using BAL;

namespace BusAPILayer
{
    public class KalladaAPILayer : IKalladaAPILayer
    {
        public DataTable GetSources()
        {
            try
            {
                object[] response = null;
                IKalladaGetSources gs = XmlRpcProxyGen.Create<IKalladaGetSources>();
                response = gs.GetSources();
                DataTable dt = new DataTable();
                dt.Columns.Add("SourceId");
                dt.Columns.Add("Source");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "source")
                        {
                            dr["Source"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "source_num")
                        {
                            dr["SourceId"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetDestinations(string sourceId)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("sourceid", sourceId);
                IKalladaGetDestinations gd = XmlRpcProxyGen.Create<IKalladaGetDestinations>();
                response = gd.GetDestinations(data);
                DataTable dt = new DataTable();
                dt.Columns.Add("DestinationId");
                dt.Columns.Add("Destination");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "destination")
                        {
                            dr["Destination"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "destination_num")
                        {
                            dr["DestinationId"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetServices(string journeyDate, string sourceId, string destinationId)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("jdate", journeyDate);
                data.Add("sourceid", sourceId);
                data.Add("destinationid", destinationId);
                data.Add("psgr_count", "10");

                IKalladaGetServices gs = XmlRpcProxyGen.Create<IKalladaGetServices>();
                response = gs.GetServices(data);
                DataTable dt = new DataTable();
                dt.Columns.Add("traveler_id");
                dt.Columns.Add("traveler_agent");
                dt.Columns.Add("service_desc");
                dt.Columns.Add("service_name");
                dt.Columns.Add("service_number");
                dt.Columns.Add("bus_type");
                dt.Columns.Add("service_type");
                dt.Columns.Add("departure_time");
                dt.Columns.Add("arrival_time");
                dt.Columns.Add("seat_fare_with_taxes");
                dt.Columns.Add("Sberth_fare_with_taxes");
                dt.Columns.Add("DBberth_fare_with_taxes");
                dt.Columns.Add("total_seats");
                dt.Columns.Add("remaining_seats");
                dt.Columns.Add("boardingpoints");
                dt.Columns.Add("droppingpoints");
                dt.Columns.Add("boardingpointsWithIds");
                dt.Columns.Add("droppingpointsWithIds");
                dt.Columns.Add("service_id");
                dt.Columns.Add("seat_type");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "traveler_id")
                        {
                            dr["traveler_id"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "traveler_agent")
                        {
                            dr["traveler_agent"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_desc")
                        {
                            dr["service_desc"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_name")
                        {
                            dr["service_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_number")
                        {
                            dr["service_number"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "bus_type")
                        {
                            dr["bus_type"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_type")
                        {
                            dr["service_type"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "departure_time")
                        {
                            dr["departure_time"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "arrival_time")
                        {
                            dr["arrival_time"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "seat_fare_with_taxes")
                        {
                            dr["seat_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "Sberth_fare_with_taxes")
                        {
                            dr["Sberth_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "DBberth_fare_with_taxes")
                        {
                            dr["DBberth_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "total_seats")
                        {
                            dr["total_seats"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "remaining_seats")
                        {
                            dr["remaining_seats"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_id")
                        {
                            dr["service_id"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "seat_type")
                        {
                            dr["seat_type"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "boardingpoints")
                        {
                            string[] boardingPoints = (string[])item[item1];
                            string sss = "";
                            string sssWithIds = "";
                            foreach (string str in boardingPoints)
                            {
                                if (str != "")
                                {
                                    string[] star = new string[1];
                                    star[0] = " - ";
                                    string[] ss = str.Split(star, StringSplitOptions.None);
                                    string[] star1 = new string[1];
                                    star1[0] = "^^";
                                    string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                    if (sss == "")
                                    {
                                        sss = " " + s[0].ToString() + " - " + ss[2].ToString() + " ";
                                        sssWithIds = " " + s[0].ToString() + " - " + ss[2].ToString() + " " + " - " + ss[0].ToString();
                                    }
                                    else
                                    {
                                        sss = sss + " %&% " + s[0].ToString() + " - " + ss[2].ToString();
                                        sssWithIds = sssWithIds + " %&% " + s[0].ToString() + " - " + ss[2].ToString() + " - " + ss[0].ToString();
                                    }
                                }
                            }
                            dr["boardingpoints"] = sss;
                            dr["boardingpointsWithIds"] = sssWithIds;
                        }
                        else if (item1.ToString() == "droppingpoints")
                        {
                            object[] droppingPoints = (object[])item[item1];
                            string sss = "";
                            string sssWithIds = "";
                            foreach (string str in droppingPoints)
                            {
                                if (str != "")
                                {
                                    string[] star = new string[1];
                                    star[0] = " - ";
                                    string[] ss = str.Split(star, StringSplitOptions.None);
                                    string[] star1 = new string[1];
                                    star1[0] = "^^";
                                    string[] s = ss[1].ToString().Split(star1, StringSplitOptions.None);

                                    if (sss == "")
                                    {
                                        sss = " " + s[0].ToString() + " - " + ss[2].ToString() + " ";
                                        sssWithIds = " " + s[0].ToString() + " - " + ss[2].ToString() + " " + " - " + ss[0].ToString();
                                    }
                                    else
                                    {
                                        sss = sss + " %&% " + s[0].ToString() + " - " + ss[2].ToString();
                                        sssWithIds = sssWithIds + " %&% " + s[0].ToString() + " - " + ss[2].ToString() + " - " + ss[0].ToString();
                                    }
                                }
                            }
                            dr["droppingpoints"] = sss;
                            dr["droppingpointsWithIds"] = sssWithIds;
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetSeatLayout(string journeyDate, string sourceId, string destinationId, string serviceId, string seatSleeper)
        {
            try
            {
                object[] response1 = null;
                XmlRpcStruct data1 = new XmlRpcStruct();
                data1.Add("jdate", journeyDate);
                data1.Add("sourceid", sourceId);
                data1.Add("destinationid", destinationId);
                data1.Add("serviceid", serviceId);
                data1.Add("seat_sleeper", seatSleeper);
                IKalladaGetSeatLayout gs1 = XmlRpcProxyGen.Create<IKalladaGetSeatLayout>();
                response1 = gs1.GetSeatLayout(data1);
                DataTable dt = new DataTable();
                dt.Columns.Add("layoutid");
                dt.Columns.Add("bustype_key");
                dt.Columns.Add("serv_tax_mode");
                dt.Columns.Add("service_number");
                dt.Columns.Add("serv_tax");
                dt.Columns.Add("education_cess");
                dt.Columns.Add("serv_layout_type");
                dt.Columns.Add("allot_seat_num");
                dt.Columns.Add("alloted_seat_row_cols");
                dt.Columns.Add("blocked_seat_nos");
                dt.Columns.Add("booked_row_cols");
                dt.Columns.Add("gendertype");
                dt.Columns.Add("tot_availableseat_rowcols");
                dt.Columns.Add("bookedseats");
                dt.Columns.Add("tot_availableseat_num");
                dt.Columns.Add("seat_fare_with_taxes");
                dt.Columns.Add("Sberth_fare_with_taxes");
                dt.Columns.Add("DBberth_fare_with_taxes");
                dt.Columns.Add("decks");
                dt.Columns.Add("tot_rows");
                dt.Columns.Add("tot_cols_left");
                dt.Columns.Add("tot_cols_right");
                dt.Columns.Add("upper_tot_rows");
                dt.Columns.Add("upper_tot_cols_left");
                dt.Columns.Add("upper_tot_cols_right");
                dt.Columns.Add("total_seat_cols");
                dt.Columns.Add("layout_seat_status");
                dt.Columns.Add("seat_nos");
                dt.Columns.Add("boardingpoints");
                dt.Columns.Add("droppingpoints");
                foreach (XmlRpcStruct item in response1)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "layoutid")
                        {
                            dr["layoutid"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "bustype_key")
                        {
                            dr["bustype_key"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "serv_tax_mode")
                        {
                            dr["serv_tax_mode"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_number")
                        {
                            dr["service_number"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "serv_tax")
                        {
                            dr["serv_tax"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "education_cess")
                        {
                            dr["education_cess"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "serv_layout_type")
                        {
                            dr["serv_layout_type"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "allot_seat_num")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["allot_seat_num"] = s;
                        }
                        else if (item1.ToString() == "alloted_seat_row_cols")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["alloted_seat_row_cols"] = s;
                        }
                        else if (item1.ToString() == "blocked_seat_nos")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["blocked_seat_nos"] = s;
                        }
                        else if (item1.ToString() == "booked_row_cols")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["booked_row_cols"] = s;
                        }
                        else if (item1.ToString() == "gendertype")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["gendertype"] = s;
                        }
                        else if (item1.ToString() == "tot_availableseat_rowcols")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["tot_availableseat_rowcols"] = s;
                        }
                        else if (item1.ToString() == "bookedseats")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["bookedseats"] = s;
                        }
                        else if (item1.ToString() == "tot_availableseat_num")
                        {
                            object[] sArr = (object[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["tot_availableseat_num"] = s;
                        }
                        else if (item1.ToString() == "seat_fare_with_taxes")
                        {
                            dr["seat_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "boardingpoints")
                        {
                            object[] boardingPoints = (object[])item[item1];
                            string s = "";
                            foreach (string str in boardingPoints)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["boardingpoints"] = s;
                        }
                        else if (item1.ToString() == "droppingpoints")
                        {
                            object[] droppingPoints = (object[])item[item1];
                            string s = "";
                            foreach (string str in droppingPoints)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["droppingpoints"] = s;
                        }
                        else if (item1.ToString() == "Sberth_fare_with_taxes")
                        {
                            dr["Sberth_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "DBberth_fare_with_taxes")
                        {
                            dr["DBberth_fare_with_taxes"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "decks")
                        {
                            dr["decks"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "tot_rows")
                        {
                            dr["tot_rows"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "tot_cols_left")
                        {
                            dr["tot_cols_left"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "tot_cols_right")
                        {
                            dr["tot_cols_right"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "upper_tot_rows")
                        {
                            dr["upper_tot_rows"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "upper_tot_cols_left")
                        {
                            dr["upper_tot_cols_left"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "upper_tot_cols_right")
                        {
                            dr["upper_tot_cols_right"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "total_seat_cols")
                        {
                            dr["total_seat_cols"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "layout_seat_status")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["layout_seat_status"] = s;
                        }
                        else if (item1.ToString() == "seat_nos")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["seat_nos"] = s;
                        }
                    }
                    dt.Rows.Add(dr);
                }

                //if (dt.Rows.Count > 0)
                //{
                //    DataTable dtSeatLayout = new DataTable();
                //    dtSeatLayout.Columns.Add("API");
                //    dtSeatLayout.Columns.Add("Row");
                //    dtSeatLayout.Columns.Add("Column");
                //    dtSeatLayout.Columns.Add("Seat");
                //    dtSeatLayout.Columns.Add("SeatStatus");
                //    dtSeatLayout.Columns.Add("Fare");
                //    dtSeatLayout.Columns.Add("Message");
                //    dtSeatLayout.Columns.Add("Type");

                //    string seatLayoutString = dt.Rows[0]["layout_seat_status"].ToString();
                //    string[] seatLayoutStringArray = seatLayoutString.Split(';');
                //    foreach (string seat in seatLayoutStringArray)
                //    {
                //        string[] star = new string[1];
                //        star[0] = " #*# ";
                //        string[] st = seat.Split(star, StringSplitOptions.None);
                //        string[] stRowColumn = st[1].ToString().Split('-');
                //        DataRow dr = dtSeatLayout.NewRow();
                //        dr["API"] = "Kal";
                //        dr["Row"] = stRowColumn[1].ToString();
                //        dr["Column"] = stRowColumn[0].ToString();
                //        dr["Seat"] = st[0].ToString();
                //        dr["Type"] = "";
                //        string seatStatus = "";
                //        if (st[4].ToString() == "A") { seatStatus = "true"; } else { seatStatus = "false"; }
                //        dr["SeatStatus"] = seatStatus;
                //        dr["Fare"] = dt.Rows[0]["seat_fare_with_taxes"].ToString();
                //        dr["Message"] = "";
                //        dtSeatLayout.Rows.Add(dr);
                //    }
                //}

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable SeatBlocking(string journeyDate, string sourceId, string destinationId, string serviceId, string selectedSeats)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("jdate", journeyDate);
                data.Add("sourceid", sourceId);
                data.Add("destinationid", destinationId);
                data.Add("serviceid", serviceId);
                data.Add("selected_seats", selectedSeats);
                IKalladaSeatBlocking gs = XmlRpcProxyGen.Create<IKalladaSeatBlocking>();
                response = gs.SeatBlocking(data);

                DataTable dt = new DataTable();
                dt.Columns.Add("sel_seats");
                dt.Columns.Add("total_servicetax_fare");
                dt.Columns.Add("total_education_fare");
                dt.Columns.Add("sel_seat_row_cols");
                dt.Columns.Add("total_fare");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "sel_seats")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["sel_seats"] = s;
                        }
                        else if (item1.ToString() == "total_servicetax_fare")
                        {
                            dr["total_servicetax_fare"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "total_education_fare")
                        {
                            dr["total_education_fare"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "sel_seat_row_cols")
                        {
                            string[] sArr = (string[])item[item1];
                            string s = "";
                            foreach (string str in sArr)
                            {
                                if (s == "") { s = str; }
                                else { s = s + ";" + str; }
                            }
                            dr["sel_seat_row_cols"] = s;
                        }
                        else if (item1.ToString() == "total_fare")
                        {
                            dr["total_fare"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable SeatBooking(string journeyDate, string sourceId, string destinationId, string serviceId, string selectedSeats, string passengerGenderType
           , string passengerName, string boardingPointId, string custAddress, string custName, string custPhoneNo, string custEmailId, string referenceNo)
        {
            string requestForMailForward = ""; string responseForMailForward = "";
            try
            {
                string req = "<?xml version='1.0'?><methodCall><methodName>index.seatbooking</methodName><params><param><value><struct><member><name>jdate</name><value><string>" + journeyDate + "</string></value></member><member><name>sourceid</name><value><string>" + sourceId + "</string></value></member><member><name>destinationid</name><value><string>" + destinationId + "</string></value></member><member><name>serviceid</name><value><string>" + serviceId + "</string></value></member><member><name>selected_seats</name><value><string>" + selectedSeats + "</string></value></member><member><name>psgr_gender_type</name><value><string>" + passengerGenderType + "</string></value></member><member><name>psgr_name</name><value><string>" + passengerName + "</string></value></member><member><name>boardingpoint_id</name><value><string>" + boardingPointId + "</string></value></member><member><name>customer_address</name><value><string> " + custAddress + " </string></value></member><member><name>customer_name</name><value><string>" + custName + "</string></value></member><member><name>customer_phoneno</name><value><string>" + custPhoneNo + "</string></value></member><member><name>customer_email</name><value><string>" + custEmailId + "</string></value></member><member><name>booking_ref_num</name><value><string>" + referenceNo + "</string></value></member></struct></value></param></params></methodCall>";
                byte[] requestData = Encoding.ASCII.GetBytes(req);
                requestForMailForward = req;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(KalladaConstants.URL);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.ContentLength = requestData.Length;

                using (Stream requestStream = request.GetRequestStream())
                { requestStream.Write(requestData, 0, requestData.Length); }

                string result = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("Status");
                dt.Columns.Add("Message");
                dt.Columns.Add("TicketNumber");
                dt.Columns.Add("TotalFare");
                dt.Columns.Add("ServiceNumber");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            result = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result); responseForMailForward = result;
                        XmlNode main = doc.DocumentElement;
                        Hashtable htMain = ParseNode(main);
                        ICollection ic = htMain.Values;
                        foreach (DictionaryEntry item in htMain)
                        {
                            Hashtable htMain1 = (Hashtable)item.Value;
                            foreach (DictionaryEntry item1 in htMain1)
                            {
                                Hashtable htMain2 = (Hashtable)item1.Value;
                                foreach (DictionaryEntry item2 in htMain2)
                                {
                                    Hashtable htMain3 = (Hashtable)item2.Value;
                                    foreach (DictionaryEntry item3 in htMain3)
                                    {
                                        Hashtable htMain4 = (Hashtable)item3.Value;
                                        foreach (DictionaryEntry item4 in htMain4)
                                        {
                                            Hashtable htMain5 = (Hashtable)item4.Value;
                                            foreach (DictionaryEntry item5 in htMain5)
                                            {
                                                Hashtable htMain6 = (Hashtable)item5.Value;
                                                foreach (DictionaryEntry item6 in htMain6)
                                                {
                                                    Hashtable htMain7 = (Hashtable)item6.Value;
                                                    foreach (DictionaryEntry item7 in htMain7)
                                                    {
                                                        System.Collections.Generic.List<Hashtable> objHash = (System.Collections.Generic.List<Hashtable>)item7.Value;
                                                        string status = ""; string message = ""; string ticket_num = ""; string total_fare = ""; string service_number = "";
                                                        foreach (Hashtable objHash1 in objHash)
                                                        {
                                                            string keyString = ""; string valueString = "";
                                                            ICollection ica = (ICollection)objHash1.Values;
                                                            foreach (var iVar in ica)
                                                            {
                                                                string sType = iVar.GetType().Name.ToString();
                                                                if (sType == "String")
                                                                {
                                                                    keyString = iVar.ToString();
                                                                }
                                                                else if (sType == "Hashtable")
                                                                {
                                                                    Hashtable hastTable = (Hashtable)iVar;
                                                                    ICollection ica2 = (ICollection)hastTable.Values;
                                                                    foreach (var iVar2 in ica2)
                                                                    {
                                                                        valueString = iVar2.ToString();
                                                                        if (keyString == "status") { status = valueString; }
                                                                        else if (keyString == "message") { message = valueString; }
                                                                        else if (keyString == "ticket_num") { ticket_num = valueString; }
                                                                        else if (keyString == "total_fare") { total_fare = valueString; }
                                                                        else if (keyString == "service_number") { service_number = valueString; }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        DataRow dr = dt.NewRow();
                                                        dr["Status"] = status;
                                                        dr["Message"] = message;
                                                        dr["TicketNumber"] = ticket_num;
                                                        dr["TotalFare"] = total_fare;
                                                        dr["ServiceNumber"] = service_number;
                                                        dt.Rows.Add(dr);
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

               
                return dt;
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }
        public DataTable GetTicketInfo(string bookingReferenceNumber)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("booking_ref_num", bookingReferenceNumber);
                IKalladaGetTicketInfo gd = XmlRpcProxyGen.Create<IKalladaGetTicketInfo>();
                response = gd.GetTicketInfo(data);
                DataTable dt = new DataTable();
                dt.Columns.Add("message");
                dt.Columns.Add("gendertype");
                dt.Columns.Add("seat_numbers");
                dt.Columns.Add("destination_name");
                dt.Columns.Add("servicename");
                dt.Columns.Add("ticket_fare");
                dt.Columns.Add("status");
                dt.Columns.Add("boarding_point_name");
                dt.Columns.Add("service_num");
                dt.Columns.Add("source_name");
                dt.Columns.Add("landmark");
                dt.Columns.Add("passenger_email");
                dt.Columns.Add("start_time");
                dt.Columns.Add("passenger_name");
                dt.Columns.Add("ticket_number");
                dt.Columns.Add("bus_type_name");
                dt.Columns.Add("traveler_name");
                dt.Columns.Add("journey_date");
                dt.Columns.Add("passenger_mobil");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "message")
                        {
                            dr["message"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "gendertype")
                        {
                            dr["gendertype"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "seat_numbers")
                        {
                            dr["seat_numbers"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "destination_name")
                        {
                            dr["destination_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "servicename")
                        {
                            dr["servicename"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "ticket_fare")
                        {
                            dr["ticket_fare"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "status")
                        {
                            dr["status"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "boarding_point_name")
                        {
                            dr["boarding_point_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "service_num")
                        {
                            dr["service_num"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "source_name")
                        {
                            dr["source_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "landmark")
                        {
                            dr["landmark"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "passenger_email")
                        {
                            dr["passenger_email"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "start_time")
                        {
                            dr["start_time"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "passenger_name")
                        {
                            dr["passenger_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "ticket_number")
                        {
                            dr["ticket_number"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "bus_type_name")
                        {
                            dr["bus_type_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "traveler_name")
                        {
                            dr["traveler_name"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "journey_date")
                        {
                            dr["journey_date"] = item[item1].ToString();
                        }
                        else if (item1.ToString() == "passenger_mobil")
                        {
                            dr["passenger_mobil"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable CancellationConfirmation(string ticketNo)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("ticketno", ticketNo);
                IKalladaCancellationConfirmation gd = XmlRpcProxyGen.Create<IKalladaCancellationConfirmation>();
                response = gd.CancellationConfirmation(data);
                DataTable dt = new DataTable();
                dt.Columns.Add("ticket_number"); dt.Columns.Add("message"); dt.Columns.Add("status");
                dt.Columns.Add("total_ticket_fare"); dt.Columns.Add("total_refund_amount"); dt.Columns.Add("cancellation_parcentage");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "ticket_number")
                        {
                            dr["ticket_number"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "message")
                        {
                            dr["message"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "status")
                        {
                            dr["status"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "total_ticket_fare")
                        {
                            dr["total_ticket_fare"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "total_refund_amount")
                        {
                            dr["total_refund_amount"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "cancellation_parcentage")
                        {
                            dr["cancellation_parcentage"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable TicketCancellation(string ticketNo)
        {
            try
            {
                object[] response = null;
                XmlRpcStruct data = new XmlRpcStruct();
                data.Add("ticketno", ticketNo);
                IKalladaTicketCancellation gd = XmlRpcProxyGen.Create<IKalladaTicketCancellation>();
                response = gd.TicketCancellation(data);
                DataTable dt = new DataTable();
                dt.Columns.Add("ticket_number"); dt.Columns.Add("message"); dt.Columns.Add("status");
                dt.Columns.Add("total_ticket_fare"); dt.Columns.Add("total_refund_amount"); dt.Columns.Add("cancellation_parcentage");
                foreach (XmlRpcStruct item in response)
                {
                    DataRow dr = dt.NewRow();
                    foreach (var item1 in item.Keys)
                    {
                        if (item1.ToString() == "ticket_number")
                        {
                            dr["ticket_number"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "message")
                        {
                            dr["message"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "status")
                        {
                            dr["status"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "total_ticket_fare")
                        {
                            dr["total_ticket_fare"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "total_refund_amount")
                        {
                            dr["total_refund_amount"] = item[item1].ToString();
                        }
                        if (item1.ToString() == "cancellation_parcentage")
                        {
                            dr["cancellation_parcentage"] = item[item1].ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Hashtable ParseNode(XmlNode node)
        {
            Hashtable ht = new Hashtable();
            foreach (XmlNode n in node.ChildNodes)
            {
                string name = n.Name;
                object value = null;
                if (n.HasChildNodes)
                {
                    if (n.ChildNodes.Count > 1) value = (object)ParseNode(n);
                    else
                    {
                        if (n.ChildNodes[0].NodeType == XmlNodeType.Text)
                            value = (object)n.ChildNodes[0].Value;
                        else value = (object)ParseNode(n);
                    }
                }
                else value = (object)n.Value;
                if (ht.ContainsKey(name))
                {
                    if (ht[name] is List<Hashtable>)
                    {
                        List<Hashtable> list = (List<Hashtable>)ht[name];
                        list.Add((Hashtable)value);
                        ht[name] = list;
                    }
                    else if (ht[name] is Hashtable)
                    {
                        List<Hashtable> list = new List<Hashtable>();
                        Hashtable htTmp = (Hashtable)ht[name];
                        list.Add(htTmp);
                        list.Add((Hashtable)value);
                        ht[name] = list;
                    }
                }
                else ht.Add(name, value);
            }
            return ht;
        }
    }
}
