using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Globalization;
using System.Xml;

public partial class Readxml : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataTable dtcallback = new DataTable();
            DataSet DsSub = new DataSet();
            DataSet dsrefcalback = new DataSet();
            DataSet ds = new DataSet();
            DataTable dtds = new DataTable();
            DsSub.ReadXml(Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"));
            dsrefcalback.ReadXml(Server.MapPath("~/App_Data/XMLfiles/" + "RefCallback.xml"));

            IEnumerable<DataRow> SubData = from i in DsSub.Tables[0].AsEnumerable()
                                           where i.Field<string>("status") == Convert.ToString(0) && i.Field<string>("readMode") == Convert.ToString(0)
                                           select i;


            if (SubData.Count() > 0)
            {
                foreach (DataRow dr in SubData)
                {
                    string resrId = Convert.ToString(dr["sync_reservation_ids"]);
                    if (reservation_Id.ToString() == "")
                    {
                        reservation_Id = resrId;
                    }
                    else
                    {
                        reservation_Id = reservation_Id + "," + resrId;
                    }
                }
                //var lengthCount = reservation_Id.Distinct().ToList();
                string[] str = reservation_Id.Split(',');
                string[] res_id = str.Distinct().ToArray();
                // var splitted = reservation_Id.AsEnumerable().SelectMany(item => item.ToString()).Distinct();

                //foreach (DataRow dr in SubData)
                //{

                if (res_id.Count() > 0)
                {
                    BusService bus = new BusService();
                    DateTime strdt = System.DateTime.Now;
                    string us = strdt.ToString(new CultureInfo("en-US"));
                    string[] date = us.Split(' ');
                    //string resrId = Convert.ToString(dr["sync_reservation_ids"]);

                    //if (resrId.Contains(','))
                    //{
                    //    IDS = resrId.Split(',');

                    //}
                    //else
                    //{
                    //    IDS = resrId.Split(' ');
                    //}

                    foreach (var id in res_id)
                    {
                        DataSet ds1 = bus.getServiceDetails(Convert.ToString(id), date[0]);
                        //to find in which date file we need to update
                        IEnumerable<DataRow> SubDataDate = from j in dsrefcalback.Tables[0].AsEnumerable()
                                                           where j.Field<string>("reservation_id") == Convert.ToString(id)
                                                           select j;
                        foreach (DataRow datenew in SubDataDate)
                        {
                            if (File.Exists(HttpContext.Current.Server.MapPath("~\\Routes\\" + datenew["Date"] + ".xml")))
                            {
                                ds.ReadXml(Server.MapPath("~/Routes/" + datenew["Date"] + ".xml"));
                                ViewState["Date"] = datenew["Date"];
                            }
                            else
                            {
                                ds = null;
                            }
                        }
                        if (ds1 != null)
                        {

                            foreach (DataRow dtrow in ds1.Tables[0].Rows)
                            {
                                if (ds != null)
                                {
                                    IEnumerable<DataRow> SubData1 = from j in ds.Tables[0].AsEnumerable()
                                                                    where j.Field<string>("reservation_id") == Convert.ToString(id)
                                                                    select j;
                                    foreach (DataRow dr1 in SubData1)
                                    {

                                        XmlTextReader reader = new XmlTextReader(Server.MapPath("~/Routes/" + Convert.ToString(ViewState["Date"]) + ".xml"));
                                        XmlDocument doc = new XmlDocument();
                                        doc.Load(reader);
                                        reader.Close();

                                        XmlNode oldCd;
                                        XmlElement root = doc.DocumentElement;
                                        oldCd = root.SelectSingleNode("/routes/route[reservation_id='" + id + "']");
                                        
                                        foreach(XmlNode node in oldCd)
                                        {
                                            if (node.Name == "id")
                                            {
                                                strid = node.InnerXml;
                                            }
                                            if (node.Name == "number")
                                            {
                                                number = node.InnerXml;
                                            }
                                            if (node.Name == "name")
                                            {
                                                name = node.InnerXml;
                                            }
                                            if (node.Name == "operator_service_name")
                                            {
                                                operator_service_name = node.InnerXml;
                                            }
                                            if (node.Name == "origin")
                                            {
                                                origin = node.InnerXml;
                                            }
                                            if (node.Name == "destination")
                                            {
                                                destination = node.InnerXml;
                                            }
                                            if (node.Name == "origin_id")
                                            {
                                                origin_id = node.InnerXml;
                                            }
                                            if (node.Name == "destination_id")
                                            {
                                                destination_id = node.InnerXml;
                                            }
                                            if (node.Name == "reservation_id")
                                            {
                                                reservation_id = node.InnerXml;
                                            }
                                            if (node.Name == "operator_route_id")
                                            {
                                                operator_route_id = node.InnerXml;

                                            }
                                            if (node.Name == "travel_id")
                                            {
                                                travel_id = node.InnerXml;

                                            }
                                            if (node.Name == "travels")
                                            {
                                                travels = node.InnerXml;

                                            }
                                            if (node.Name == "bus_type")
                                            {
                                                bus_type = node.InnerXml;

                                            }
                                            if (node.Name == "bus_type_id")
                                            {
                                                bus_type_id = node.InnerXml;

                                            }
                                            if (node.Name == "dep_time")
                                            {
                                                dep_time = node.InnerXml;

                                            }
                                            if (node.Name == "arr_time")
                                            {
                                                arr_time = node.InnerXml;

                                            }
                                            if (node.Name == "duration")
                                            {
                                                duration = node.InnerXml;

                                            }
                                            if (node.Name == "available_seats")
                                            {
                                                available_seats = node.InnerXml;

                                            }
                                            if (node.Name == "total_seats")
                                            {
                                                total_seats = node.InnerXml;

                                            }
                                            if (node.Name == "seat_type_detail")
                                            {
                                                seat_type_detail = node.InnerXml;

                                            }

                                            if (node.Name == "fare_str")
                                            {
                                                fare_str = node.InnerXml;

                                            }
                                            if (node.Name == "is_cancellable")
                                            {
                                                is_cancellable = node.InnerXml;

                                            }
                                            if (node.Name == "commission")
                                            {
                                                commission = node.InnerXml;

                                            }
                                            if (node.Name == "status")
                                            {
                                                status = node.InnerXml;

                                            }
                                          
                                        }
                                      

                                        XmlElement newCd = doc.CreateElement("route");
                                        newCd.InnerXml = "<id>" + strid + "</id>" +
                                            "<number>" + number + "</number>" +
                                            "<name>" + name + "</name>" +
                                            "<operator_service_name>" + operator_service_name + "</operator_service_name>" +
                                           "<origin>" + origin + "</origin>" +
                                           "<destination>" + destination + "</destination>" +
                                           "<origin_id>" + origin_id + "</origin_id>"
                                           + "<destination_id>" + destination_id + "</destination_id>" +
                                          "<reservation_id>" + reservation_id + "</reservation_id>"
                                          + "<operator_route_id>" + operator_route_id + "</operator_route_id>" +
                                         "<travel_id>" + travel_id + "</travel_id>" +
                                         "<travels>" + travels + "</travels>" +
                                        "<bus_type>" + bus_type + "</bus_type>" +
                                        "<bus_type_id>" + bus_type_id + "</bus_type_id>" +
                                        "<dep_time>" + ds1.Tables["boardingTimes"].Rows[0]["time"].ToString() + "</dep_time>" +
                                        "<arr_time>" + ds1.Tables["droppingTimes"].Rows[0]["time"].ToString() + "</arr_time>" +
                                        "<duration>" + duration+ "</duration>" +
                                       "<available_seats>" + Convert.ToString(dtrow["availableSeatsCount"]) + "</available_seats>" +
                                       "<total_seats>" + total_seats + "</total_seats>" +
                                      "<seat_type_detail>" + seat_type_detail + "</seat_type_detail>" +
                                      "<fare_str>" + fare_str + "</fare_str>" +
                                    "<is_cancellable>" + is_cancellable + "</is_cancellable>" +
                                    "<commission>" + commission + "</commission>" +
                                   "<status>" + status + "</status>";


                                        root.ReplaceChild(newCd, oldCd);
                                        doc.Save(Server.MapPath("~/Routes/" + Convert.ToString(ViewState["Date"]) + ".xml"));

                                        //if (Convert.ToString(dtrow["availableSeats"]) != "")
                                        //{
                                        //    dr1["available_seats"] = Convert.ToString(dtrow["availableSeats"]);
                                        //}
                                        //if (ds1.Tables["boardingTimes"].Columns.Contains("time"))
                                        //{
                                        //    dr1["dep_time"] = ds1.Tables["boardingTimes"].Rows[0]["time"].ToString();
                                        //}
                                        //if (Convert.ToString(dtrow["availableSeatsCount"]) != "")
                                        //{
                                        //    dr1["available_seats"] = Convert.ToString(dtrow["availableSeatsCount"]);
                                        //}
                                        //if (ds1.Tables["droppingTimes"].Columns.Contains("time"))
                                        //{
                                        //    dr1["arr_time"] = ds1.Tables["droppingTimes"].Rows[0]["time"].ToString();
                                        //}

                                    }
                                }
                            }
                        }
                        //if (ds != null)
                        //{
                        //    StreamWriter XmlData = new StreamWriter(Server.MapPath("~/Routes/" + Convert.ToString(ViewState["Date"]) + ".xml"), false);

                        //    ds.WriteXml(XmlData);
                        //    XmlData.Close();

                        //}
                    }
                    //dr["status"] = "1";
                    //StreamWriter XmlDatacallback = new StreamWriter(Server.MapPath("~/App_Data/XMLfiles/" + "Callback.xml"), false);
                    //DsSub.WriteXml(XmlDatacallback);
                    //XmlDatacallback.Close();

                }

            }

        }
    }
}