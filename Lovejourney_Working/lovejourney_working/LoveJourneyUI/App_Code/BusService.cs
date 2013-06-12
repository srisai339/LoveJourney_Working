using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Services;
using Newtonsoft.Json;
using BAL;
using LJ.WebAPI.Models;
using System.Globalization;

/// <summary>
/// Summary description for BusService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class BusService : System.Web.Services.WebService
{
    SSAPIClient objService = new SSAPIClient();
    private string baseUrl = ConfigurationManager.AppSettings["I2SBus_BaseURL"];
    private string ConsumerKey = ConfigurationManager.AppSettings["I2SBus_ConsumerKey"];
    private string ConsumerSecret = ConfigurationManager.AppSettings["I2SBus_ConsumerSecret"];
    public BusService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string GetSources()
    {
        try
        {
            DataSet ds = new DataSet();
            // return objService.getAllSources();
            clsMasters obj = new clsMasters();
            DataTable DtLocSub = new DataTable();
            DataSet DsSub = new DataSet();
            DsSub.ReadXml(Server.MapPath("~/App_Data/" + "Buses.xml"));
            IEnumerable<DataRow> SubData = from i in DsSub.Tables[0].AsEnumerable()
                                           where i.Field<string>("Deal") == "0"
                                           select i;


            if (SubData.Count() > 0)
            {
                DtLocSub = SubData.CopyToDataTable();
                ds.Tables.Add(DtLocSub);
                // DataSet ds = obj.GetCities(ConsumerKey, ConsumerSecret,0);

            }
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            throw ex;
        }



    }
    [WebMethod]
    public string GetSourcesTours()
    {
        try
        {
            // return objService.getAllSources();
            clsMasters obj = new clsMasters();
            DataSet ds = obj.GetCitiesTours(ConsumerKey, ConsumerSecret, 1);
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            throw ex;
        }



    }

    [WebMethod(EnableSession = true)]
    public string GetAvailableTrips(int sourceId, int destinationId, String dateofjourney, int resultSetIndex)
    {


        dateofjourney = dateofjourney.Split('-')[0] + "-" + dateofjourney.Split('-')[1] + "-" + dateofjourney.Split('-')[2];

        String response = objService.getAvailableTrips(sourceId.ToString(), destinationId.ToString(), dateofjourney, resultSetIndex).ToString();
        // string res = objService.getAvailableTripsTest();
        return response;


    }
    [WebMethod]
    public DataSet getServiceDetails(string reservation_id, string dateofjourney)
    {

        dateofjourney = dateofjourney.Split('/')[2] + "-" + dateofjourney.Split('/')[1] + "-" + dateofjourney.Split('/')[0];
        BusesViewModel bitla = new BusesViewModel();
        DataSet ds = bitla.GetcallBack(reservation_id, baseUrl, ConsumerKey, ConsumerSecret, dateofjourney);
        return ds;
    }
    [WebMethod(EnableSession = true)]
    public String GetTripDetails(String tripId, string sourceId, string destinationId, string markUpFare, string SeatLayoutId, string journeyDate, string providerName)
    {
        return objService.getTripDetails(tripId, sourceId, destinationId, markUpFare, SeatLayoutId, journeyDate, providerName);
    }


    [WebMethod(EnableSession = true)]
    public String SetValues(String tripDetails, String doj, String seats, String fare, String boardingDetails,
                    String tripID, String destinationID, String sourceID, String busType, String busOperator, String providerName)
    {
        String[] BookingDetails = new String[20];
        BookingDetails[0] = tripDetails;
        BookingDetails[1] = doj;
        BookingDetails[2] = seats;
        BookingDetails[3] = fare;
        BookingDetails[4] = boardingDetails;
        BookingDetails[5] = "Single";
        BookingDetails[6] = "";
        BookingDetails[7] = "";
        BookingDetails[8] = "";
        BookingDetails[9] = "";
        BookingDetails[10] = sourceID;
        BookingDetails[11] = destinationID;
        BookingDetails[12] = tripID;
        BookingDetails[13] = "";
        BookingDetails[14] = busType;
        BookingDetails[15] = busOperator;
        BookingDetails[16] = "";
        BookingDetails[17] = "";
        BookingDetails[18] = "";
        BookingDetails[19] = providerName;
        HttpContext.Current.Session["RedBusBookingDetails"] = BookingDetails;
        return "Success";
    }
    private string GetSpecialPrice(string actualPrice, string MarkUp_Down, string Percentage_Flat, string Value, string userType)
    {

        string[] strFares = actualPrice.Split('/');
        string returnString = actualPrice;

        //string userType = dr["UserType"].ToString();//B2B,B2C,BOTH
        string currentUser = "";//Admin,User,Agent
        bool go = false;
        if (HttpContext.Current.Session["Role"] != null)
        {
            currentUser = HttpContext.Current.Session["Role"].ToString().ToUpper();
        }

        if (userType == "B2C" && (currentUser == "" || currentUser == "USER")) { go = true; }
        if (userType == "B2B" && currentUser == "AGENT") { go = true; }
        if (userType == "BOTH") { go = true; }
        if (currentUser == "ADMIN") { go = false; }

        if (go)
        {
            foreach (string item in strFares)
            {
                if (!returnString.Contains("/"))
                {
                    if (MarkUp_Down == "Mark Up" && Percentage_Flat == "Flat")
                    {
                        returnString = Convert.ToString(Convert.ToDouble(actualPrice) + Convert.ToDouble(Value));
                    }
                    else if (MarkUp_Down == "Mark Up" && Percentage_Flat == "Percentage")
                    {
                        double percentageFare = (Convert.ToDouble(actualPrice) * Convert.ToDouble(Value)) / 100;
                        returnString = Convert.ToString(Convert.ToDouble(actualPrice) + percentageFare);
                    }
                    else if (MarkUp_Down == "Mark Down" && Percentage_Flat == "Flat")
                    {
                        returnString = Convert.ToString(Convert.ToDouble(actualPrice) - Convert.ToDouble(Value));
                    }
                    else if (MarkUp_Down == "Mark Down" && Percentage_Flat == "Percentage")
                    {
                        double percentageFare = (Convert.ToDouble(actualPrice) * Convert.ToDouble(Value)) / 100;
                        returnString = Convert.ToString(Convert.ToDouble(actualPrice) - percentageFare);
                    }
                }
            }
        }
        return returnString;
    }
    [WebMethod(EnableSession = true)]
    public string GetAgentSpecialPrice(string actualPrice)
    {

        string[] strFares = actualPrice.Split('/');
        string returnString = actualPrice;
        string value = "";
        //string userType = dr["UserType"].ToString();//B2B,B2C,BOTH
        string currentUser = "";//Admin,User,Agent
        string fare = "";
        if (HttpContext.Current.Session["fare"] != null)
        {
            if (HttpContext.Current.Session["Role"].ToString().ToUpper() == "AGENT")
            {
                value = Convert.ToString(HttpContext.Current.Session["fare"]);
            }
        }

        bool go = false;
        if (HttpContext.Current.Session["Role"] != null)
        {
            currentUser = HttpContext.Current.Session["Role"].ToString().ToUpper();
        }
        if (currentUser == "AGENT")
        {
            go = true;
        }
        if (go)
        {
            foreach (string item in strFares)
            {
                if (!returnString.Contains("/"))
                {
                    double percentageFare = (Convert.ToDouble(actualPrice) * Convert.ToDouble(value)) / 100;
                    fare = Convert.ToString(percentageFare);
                }
                else
                {
                    double percentageFare = (Convert.ToDouble(item) * Convert.ToDouble(value)) / 100;
                    if (fare.ToString() == "")
                    {
                        fare = Convert.ToString(percentageFare);
                    }
                    else
                    {
                        fare = fare + "/" + Convert.ToString(percentageFare);
                    }
                }
            }
        }
        else
        {
            fare = null;
        }
        return JsonConvert.SerializeObject(fare);
    }
    [WebMethod(EnableSession = true)]
    public string getagent()
    {
        if (HttpContext.Current.Session["UserID"] != null)
        {
            ClsBAL objBAL = new ClsBAL();
            DataSet dsCommSlab = objBAL.GetCommissionSlab("Agent", "Bus", "");
            if (dsCommSlab != null)
            {
                if (dsCommSlab.Tables[0].Rows.Count > 0)
                {
                    HttpContext.Current.Session["fare"] = Convert.ToString(dsCommSlab.Tables[0].Rows[0]["Commission"]);

                }

            }
        }
        else
        {
            HttpContext.Current.Session["fare"] = null;
        }
        return JsonConvert.SerializeObject(HttpContext.Current.Session["fare"]);

    }
    string image;
    private String GetSeatLayout(DataTable dtMain)
    {
        StringBuilder sbSeatLayout = new StringBuilder();
        StringBuilder sbSeatLayoutSleeper = new StringBuilder();

        try
        {
            if (dtMain.Rows.Count > 0)
            {

                Class1 obj = new Class1();
                obj.ScreenInd = Master123.GetMarkup;
                DataSet ds = obj.fnGetData();

                DataRow drSpecialPrice = ds.Tables[0].Rows[0];


                #region Code to convert "Row" & "Column" columns to integer datatype

                //create a copy of main table
                DataTable dt = dtMain.Clone();
                //set column datatypes for int values
                dt.Columns["row"].DataType = Type.GetType("System.Int16");
                dt.Columns["column"].DataType = Type.GetType("System.Int16");
                dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");

                DataRow[] drArray1 = dtMain.Select(String.Empty, "row, column ASC, zIndex DESC");
                if (drArray1.Length > 0)
                {
                    foreach (DataRow dr in drArray1)
                        dt.ImportRow(dr);
                }

                dt.AcceptChanges();

                #endregion

                var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();

                var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();

                //Used in exceptional cases where a bus has both seats and sleeper coaches
                //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();

                String strSeatType = String.Empty;
                String strSeatCssSuffix = String.Empty;

                if (zIndexCount.Count > 1)
                    sbSeatLayout.Append("<table  align=\"center\"  width=\"99%\"><tr><td colspan=\"2\"  >");

                else
                    sbSeatLayout.Append("<table  align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 0px; margin: 0px; \"><tr><td  style=\"float:left;\"><span style=\"float:left;\" class=\"steering\"></span></td><td>");//colspan=\"2\"
                foreach (Int16 index in zIndexCount)
                {
                    if (zIndexCount.Count > 1)
                    {
                        //div tag is added to show border with same size for upper and lower decks
                        sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 3px; margin: 3px;width:425px; \">");
                        //add steering image only once
                        //if (zIndexCount.IndexOf(index) > 0)
                        //    sbSeatLayout.Append("<span class=\"steering\" style=\"margin-top: 2px; float: left; \"/>");

                        if (index == 0)
                            sbSeatLayout.Append("<span class=\"lowerLabel\" style=\"margin-top: 1px; float: left; width:29; height:29; \"></span>");//class=\"lowerLabel\Lower\&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Lower"
                        else
                            sbSeatLayout.Append("<span class=\"upperLabel\" style=\"margin-top: 1px; float: left; width:29; height:29; \"></span>");//class=\"upperLabel\Upper"
                        sbSeatLayout.Append("<table>");

                    }
                    else
                        sbSeatLayout.Append("<div><span  style=\"margin-top: 2px; float: left; \"/><table>"); //class=\"steering\"


                    Int16 GangwayRow = 0;
                    foreach (Int16 row in RowCount)
                    {
                        #region Gangway

                        if (GangwayRow != row)
                        {
                            //check if bus has different seat layouts. If so, do not float seats right
                            if (maxLength == 2 && maxWidth == 2)
                                sbSeatLayout.Append("<tr><td>");
                            else
                                sbSeatLayout.Append("<tr><td style=\"float: right\">");

                            sbSeatLayout.Append("<ul class=\"seat_map\">");

                            sbSeatLayout.Append("<li>&nbsp;</li>");
                            sbSeatLayout.Append("</ul>");
                            sbSeatLayout.Append("</<td></tr>");
                            GangwayRow++;
                        }
                        GangwayRow++;

                        #endregion

                        #region Create datarow array

                        //Get the actual row count to drArrayMain 
                        DataRow[] drArrayMain = dt.Select("Row = " + row + " AND zIndex = " + index, "Column ASC");

                        //Create another array which is based on ColumnCount
                        //This array will be used in below code
                        DataRow[] drArray = new DataRow[ColumnCount.Count];

                        ColumnCount.Sort();

                        if (drArrayMain.Length != ColumnCount.Count)
                        {
                            for (int i = 0; i < ColumnCount.Count; i++)
                            {
                                try
                                {
                                    //check if main array contains a row with given column name
                                    //If so, assign it to other row else create a new row
                                    drArray[i] = drArrayMain.Single(p => int.Parse(p["Column"].ToString()) == int.Parse(ColumnCount[i].ToString()));
                                }
                                catch
                                {
                                    drArray[i] = dt.NewRow();
                                }
                            }
                        }
                        else
                        {
                            drArray = drArrayMain;
                        }

                        #endregion

                        //check if bus has different seat layouts. If so, do not float seats right
                        if (maxLength == 2 && maxWidth == 2)
                            sbSeatLayout.Append("<tr><td>");
                        else
                            sbSeatLayout.Append("<tr><td style=\"float: right\">");

                        sbSeatLayout.Append("<ul class=\"seat_map\">");

                        #region loop drArray and add seats

                        foreach (DataRow dr in drArray)
                        {
                            //Get special price
                            if (!dr["fare"].ToString().Trim().Equals(String.Empty))
                                dr["fare"] = GetSpecialPrice(dr["fare"].ToString(), drSpecialPrice["MarkUp_Down"].ToString()
                                    , drSpecialPrice["Percentage_Flat"].ToString(), drSpecialPrice["Value"].ToString(), drSpecialPrice["UserType"].ToString().ToUpper());


                            #region Set seat type seat/sleeper_v/sleeper_h

                            // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                            if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                            {
                                if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                {
                                    strSeatType = "Seat";
                                    strSeatCssSuffix = "seat";

                                    image = "images1/desc.png";
                                }
                                else if (int.Parse(dr["width"].ToString()) == 2)
                                {
                                    strSeatType = "Sleeper_v";
                                    strSeatCssSuffix = "sleeper_v";
                                    image = "images1/desc2.png";
                                }
                                else if (int.Parse(dr["length"].ToString()) == 2)
                                {
                                    strSeatType = "Sleeper_h";
                                    strSeatCssSuffix = "sleeper_h";
                                }
                            }
                            Session["RedbusSeattype"] = strSeatType;



                            #endregion

                            //Check if datarow has empty seats, if so add empty spaces
                            if (dr["available"] != null && dr["available"].ToString() != String.Empty)
                            {
                                //set appropriate class based on seat availability
                                if (dr["available"].ToString().ToUpper() == "FALSE")
                                {
                                    // if (dr["ladiesSeat"].ToString().ToUpper() == "TRUE")
                                    //  sbSeatLayout.Append("<li id=\"li" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");

                                    // else
                                    sbSeatLayout.Append("<li id=\"li" + dr["name"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");

                                    // sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["name"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                    // sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                    // sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["name"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                }
                                else
                                {
                                    if (dr["ladiesSeat"].ToString().ToUpper() == "TRUE")
                                    {
                                        sbSeatLayout.Append("<li id=\"li" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                        string seatname = "";
                                        if (Session["RedBusSeats"] == null)
                                        {
                                            seatname = dr["name"].ToString();
                                            Session["RedBusSeats"] = seatname;
                                        }
                                        else
                                        {
                                            Session["RedBusSeats"] = Session["RedBusSeats"].ToString() + "," + dr["name"].ToString();
                                        }

                                    }
                                    else
                                    {
                                        sbSeatLayout.Append("<li id=\"li" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");
                                    }

                                    sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["name"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                    sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                    sbSeatLayout.Append("onmouseover=title='" + strSeatType + ":" + dr["name"].ToString() + ":" + dr["fare"].ToString() + "' \"fnShowPanel1(event,'seat_info','" + dr["name"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                    //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                }

                                //Seat number is properly displayed in Chrome and Firefox except IE. 
                                //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                sbSeatLayout.Append("<a id='seat" + dr["name"].ToString() + "'>" + "" + "</a></li>");

                                sbSeatLayout.Append("<input id=\"isSelected" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["name"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                            }
                            else
                            {
                                //check if drArray has no seats. If so, add li element to create walking bay
                                if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                    sbSeatLayout.Append("<li>&nbsp;</li>");
                            }
                        }

                        #endregion

                        sbSeatLayout.Append("</ul>");
                        sbSeatLayout.Append("</<td></tr>");

                    }
                    sbSeatLayout.Append("</table></div>");
                }

                sbSeatLayout.Append("</<td></tr></table>");
            }
        }
        catch (Exception ex)
        {
            // only for development purpose
        }
        return sbSeatLayout.ToString();
    }
    [WebMethod(EnableSession = true)]
    public string AvailResponse()
    {
        try
        {
            if (HttpContext.Current.Session["AvailResponse"] != null)
            {
                return JsonConvert.SerializeObject(HttpContext.Current.Session["AvailResponse"]);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

}