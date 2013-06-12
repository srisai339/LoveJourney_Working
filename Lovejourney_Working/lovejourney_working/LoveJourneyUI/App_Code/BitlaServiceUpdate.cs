using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using LJ.CLB.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Net;
using System.IO;
using System.Web;
using System.Globalization;
using BAL;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BitlaServiceUpdate" in code, svc and config file together.
public class BitlaServiceUpdate : IBitlaServiceUpdate
{
    String requestBody;
    string[] IDS;
    string reservation_Id = string.Empty;
    string strid = string.Empty;
    string number = string.Empty;
    string name = string.Empty;
    string operator_service_name = string.Empty;
    string origin = string.Empty;
    string destination = string.Empty;
    string origin_id = string.Empty;
    string destination_id = string.Empty;
    string reservation_id = string.Empty;
    string operator_route_id = string.Empty;
    string travel_id = string.Empty;
    string travels = string.Empty;
    string bus_type = string.Empty;
    string bus_type_id = string.Empty;
    string dep_time = string.Empty;
    string arr_time = string.Empty;
    string duration = string.Empty;
    string available_seats = string.Empty;
    string total_seats = string.Empty;
    string seat_type_detail = string.Empty;
    string fare_str = string.Empty;
    string is_cancellable = string.Empty;
    string commission = string.Empty;
    string status = string.Empty;

    private String getJSONReponse(String requestBody)
    {
        return invokeGetRequest(requestBody, @"application/xml");
    }
    public DataSet getServiceDetails(String reservationId, String URL, String ConsumerKey)
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
        return convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsLayout));
        //DataSet dss= convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsLayout));
        // dss.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/Routes/" + datenew["Date"] + ".xml"));


    }

    public DataSet convertJsonStringToDataSet(string jsonString)
    {
        try
        {
            DataSet ds = new DataSet();
            XmlDocument xd = new XmlDocument();
            jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
            xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
            ds.ReadXml(new XmlNodeReader(xd));
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    protected string invokeGetRequest(string requestUrl, string contentType)
    {
        string completeUrl = requestUrl;
        string responseString;
        try
        {
            HttpWebRequest request1 = WebRequest.Create(completeUrl) as HttpWebRequest;
            request1.ContentType = contentType;
            request1.Method = @"GET";
            HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse();
            using (BufferedStream buffer = new BufferedStream(httpWebResponse.GetResponseStream()))
            {
                using (StreamReader reader = new StreamReader(buffer))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            //StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            //string responseString = reader.ReadToEnd();
            return responseString;
        }
        catch (WebException ex)
        {
            //reading the custom messages sent by the server
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            return "Failed with exception message:" + ex.Message;
        }
    }
    public void service()
    {
        ClsBAL obj = new ClsBAL();
        bool b = obj.BitlaCallback("", "success");
        //set up a filestream
        FileStream fs = new FileStream(@"E:\ScheduledService.txt", FileMode.OpenOrCreate, FileAccess.Write);

        //set up a streamwriter for adding text
        StreamWriter sw = new StreamWriter(fs);

        //find the end of the underlying filestream
        sw.BaseStream.Seek(0, SeekOrigin.End);

        //add the text
        sw.WriteLine("Success");
        //add the text to the underlying filestream

        sw.Flush();
        //close the writer
        sw.Close();
        //DataTable dtcallback = new DataTable();
        //DataSet DsSub = new DataSet();
        //DataSet dsrefcalback = new DataSet();
        //DataSet ds = new DataSet();
        //DataTable dtds = new DataTable();
        //DsSub.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"));
        //dsrefcalback.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/XMLfiles/" + "RefCallback.xml"));

        //IEnumerable<DataRow> SubData = from i in DsSub.Tables[0].AsEnumerable()
        //                               where i.Field<string>("status") == Convert.ToString(0) && i.Field<string>("readMode") == Convert.ToString(0)
        //                               select i;


        //if (SubData.Count() > 0)
        //{
        //    foreach (DataRow dr in SubData)
        //    {
        //        string resrId = Convert.ToString(dr["sync_reservation_ids"]);
        //        if (reservation_Id.ToString() == "")
        //        {
        //            reservation_Id = resrId;
        //        }
        //        else
        //        {
        //            reservation_Id = reservation_Id + "," + resrId;
        //        }
        //    }
        //    //var lengthCount = reservation_Id.Distinct().ToList();
        //    string[] str = reservation_Id.Split(',');
        //    string[] res_id = str.Distinct().ToArray();
        //    // var splitted = reservation_Id.AsEnumerable().SelectMany(item => item.ToString()).Distinct();

        //    //foreach (DataRow dr in SubData)
        //    //{

        //    if (res_id.Count() > 0)
        //    {


        //        DateTime strdt = System.DateTime.Now;
        //        string us = strdt.ToString(new CultureInfo("en-US"));
        //        string[] date = us.Split(' ');
        //        //string resrId = Convert.ToString(dr["sync_reservation_ids"]);

        //        //if (resrId.Contains(','))
        //        //{
        //        //    IDS = resrId.Split(',');

        //        //}
        //        //else
        //        //{
        //        //    IDS = resrId.Split(' ');
        //        //}

        //        foreach (var id in res_id)
        //        {
        //            Service1 bus = new Service1();
        //            //BitlaAPILayer bus = new BitlaAPILayer();
        //            DataSet ds1 = bus.getServiceDetails(id, "", "");
        //            //to find in which date file we need to update
        //            IEnumerable<DataRow> SubDataDate = from j in dsrefcalback.Tables[0].AsEnumerable()
        //                                               where j.Field<string>("reservation_id") == Convert.ToString(id)
        //                                               select j;
        //            foreach (DataRow datenew in SubDataDate)
        //            {
        //                if (File.Exists(HttpContext.Current.Server.MapPath("~\\Routes\\" + datenew["Date"] + ".xml")))
        //                {
        //                    ds.ReadXml(HttpContext.Current.Server.MapPath("~/Routes/" + datenew["Date"] + ".xml"));
        //                    HttpContext.Current.Cache["Date"] = datenew["Date"];
        //                }
        //                else
        //                {
        //                    ds = null;
        //                }
        //            }
        //            if (ds1 != null)
        //            {

        //                foreach (DataRow dtrow in ds1.Tables[0].Rows)
        //                {
        //                    if (ds != null)
        //                    {
        //                        IEnumerable<DataRow> SubData1 = from j in ds.Tables[0].AsEnumerable()
        //                                                        where j.Field<string>("reservation_id") == Convert.ToString(id)
        //                                                        select j;
        //                        foreach (DataRow dr1 in SubData1)
        //                        {

        //                            XmlTextReader reader = new XmlTextReader(HttpContext.Current.Server.MapPath("~/Routes/" + Convert.ToString(HttpContext.Current.Cache["Date"]) + ".xml"));
        //                            XmlDocument doc = new XmlDocument();
        //                            doc.Load(reader);
        //                            reader.Close();

        //                            XmlNode oldCd;
        //                            XmlElement root = doc.DocumentElement;
        //                            oldCd = root.SelectSingleNode("/routes/route[reservation_id='" + id + "']");

        //                            foreach (XmlNode node in oldCd)
        //                            {
        //                                if (node.Name == "id")
        //                                {
        //                                    strid = node.InnerXml;
        //                                }
        //                                if (node.Name == "number")
        //                                {
        //                                    number = node.InnerXml;
        //                                }
        //                                if (node.Name == "name")
        //                                {
        //                                    name = node.InnerXml;
        //                                }
        //                                if (node.Name == "operator_service_name")
        //                                {
        //                                    operator_service_name = node.InnerXml;
        //                                }
        //                                if (node.Name == "origin")
        //                                {
        //                                    origin = node.InnerXml;
        //                                }
        //                                if (node.Name == "destination")
        //                                {
        //                                    destination = node.InnerXml;
        //                                }
        //                                if (node.Name == "origin_id")
        //                                {
        //                                    origin_id = node.InnerXml;
        //                                }
        //                                if (node.Name == "destination_id")
        //                                {
        //                                    destination_id = node.InnerXml;
        //                                }
        //                                if (node.Name == "reservation_id")
        //                                {
        //                                    reservation_id = node.InnerXml;
        //                                }
        //                                if (node.Name == "operator_route_id")
        //                                {
        //                                    operator_route_id = node.InnerXml;

        //                                }
        //                                if (node.Name == "travel_id")
        //                                {
        //                                    travel_id = node.InnerXml;

        //                                }
        //                                if (node.Name == "travels")
        //                                {
        //                                    travels = node.InnerXml;

        //                                }
        //                                if (node.Name == "bus_type")
        //                                {
        //                                    bus_type = node.InnerXml;

        //                                }
        //                                if (node.Name == "bus_type_id")
        //                                {
        //                                    bus_type_id = node.InnerXml;

        //                                }
        //                                if (node.Name == "dep_time")
        //                                {
        //                                    dep_time = node.InnerXml;

        //                                }
        //                                if (node.Name == "arr_time")
        //                                {
        //                                    arr_time = node.InnerXml;

        //                                }
        //                                if (node.Name == "duration")
        //                                {
        //                                    duration = node.InnerXml;

        //                                }
        //                                if (node.Name == "available_seats")
        //                                {
        //                                    available_seats = node.InnerXml;

        //                                }
        //                                if (node.Name == "total_seats")
        //                                {
        //                                    total_seats = node.InnerXml;

        //                                }
        //                                if (node.Name == "seat_type_detail")
        //                                {
        //                                    seat_type_detail = node.InnerXml;

        //                                }

        //                                if (node.Name == "fare_str")
        //                                {
        //                                    fare_str = node.InnerXml;

        //                                }
        //                                if (node.Name == "is_cancellable")
        //                                {
        //                                    is_cancellable = node.InnerXml;

        //                                }
        //                                if (node.Name == "commission")
        //                                {
        //                                    commission = node.InnerXml;

        //                                }
        //                                if (node.Name == "status")
        //                                {
        //                                    status = node.InnerXml;

        //                                }

        //                            }


        //                            XmlElement newCd = doc.CreateElement("route");
        //                            newCd.InnerXml = "<id>" + strid + "</id>" +
        //                                "<number>" + number + "</number>" +
        //                                "<name>" + name + "</name>" +
        //                                "<operator_service_name>" + operator_service_name + "</operator_service_name>" +
        //                               "<origin>" + origin + "</origin>" +
        //                               "<destination>" + destination + "</destination>" +
        //                               "<origin_id>" + origin_id + "</origin_id>"
        //                               + "<destination_id>" + destination_id + "</destination_id>" +
        //                              "<reservation_id>" + reservation_id + "</reservation_id>"
        //                              + "<operator_route_id>" + operator_route_id + "</operator_route_id>" +
        //                             "<travel_id>" + travel_id + "</travel_id>" +
        //                             "<travels>" + travels + "</travels>" +
        //                            "<bus_type>" + bus_type + "</bus_type>" +
        //                            "<bus_type_id>" + bus_type_id + "</bus_type_id>" +
        //                            "<dep_time>" + ds1.Tables["boardingTimes"].Rows[0]["time"].ToString() + "</dep_time>" +
        //                            "<arr_time>" + ds1.Tables["droppingTimes"].Rows[0]["time"].ToString() + "</arr_time>" +
        //                            "<duration>" + duration + "</duration>" +
        //                           "<available_seats>" + Convert.ToString(dtrow["availableSeatsCount"]) + "</available_seats>" +
        //                           "<total_seats>" + total_seats + "</total_seats>" +
        //                          "<seat_type_detail>" + seat_type_detail + "</seat_type_detail>" +
        //                          "<fare_str>" + fare_str + "</fare_str>" +
        //                        "<is_cancellable>" + is_cancellable + "</is_cancellable>" +
        //                        "<commission>" + commission + "</commission>" +
        //                       "<status>" + status + "</status>";


        //                            root.ReplaceChild(newCd, oldCd);
        //                            doc.Save(HttpContext.Current.Server.MapPath("~/Routes/" + Convert.ToString(HttpContext.Current.Cache["Date"]) + ".xml"));


        //                        }
        //                    }
        //                }
        //            }
        //            //if (ds != null)
        //            //{
        //            //    StreamWriter XmlData = new StreamWriter(Server.MapPath("~/Routes/" + Convert.ToString(ViewState["Date"]) + ".xml"), false);

        //            //    ds.WriteXml(XmlData);
        //            //    XmlData.Close();

        //            //}
        //        }
        //        //dr["status"] = "1";
        //        //StreamWriter XmlDatacallback = new StreamWriter(Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"), false);
        //        //DsSub.WriteXml(XmlDatacallback);
        //        //XmlDatacallback.Close();

        //    }

        //}
    }
}
