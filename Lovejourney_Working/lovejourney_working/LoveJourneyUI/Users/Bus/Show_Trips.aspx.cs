using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusAPILayer;
using BAL;
using System.Web;
using System.Text;
using System.Web.Services;
using System.Linq;

public partial class Users_Show_Trips : System.Web.UI.Page
{
    //KesineniDetails kesineniDetails;
    //AbhiBusDetails abhiBusDetails;
    //BitlaDetails bitlaDetails;
    //KABCommon objCommon;
    ClsBAL objManabusBAL;
    DataSet ObjDataset;
    //public static BaseClass baseCls = null;

    #region Static variables

    public static String strFilterBusesWithCheckBoxes = String.Empty;
    public static String strFilterBusesWithDropDowns = String.Empty;
    public static String strFilterBusesWithSliders = String.Empty;
    public static String sortDirection = " ASC";
    public static String travelOperatorSelected = "";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0) { Request.Browser.Adapters.Clear(); }
        //kesineniDetails = new KesineniDetails();
        //kesineniDetails.LoginId = KesineniConstants.LoginId;
        //kesineniDetails.PassWord = KesineniConstants.Password;

        //abhiBusDetails = new AbhiBusDetails();
        //abhiBusDetails.Url = AbhiBusConstants.URL;

        //bitlaDetails = new BitlaDetails();
        //bitlaDetails.ApiKey = BitlaConstants.API_KEY;
        //bitlaDetails.Url = BitlaConstants.URL;

        //objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

        lblUPDOWNDate.Text = lblUPDOWNDateReturn.Text = "";

        try
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
                    {
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    }
                    else if (Session["Role"].ToString() == "User")
                    {
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    }


                }
                BaseClass baseCls = new BaseClass();
                baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);
                travelOperatorSelected = "";

                lblRoute.Text = baseCls.preLoadParams[4].Trim() + "<span style='color:Black;'> <i>to</i> </span>" + baseCls.preLoadParams[5].Trim()
                    + "<span style='color:Black;'> <i>on</i> </span>" + baseCls.preLoadParams[2].Trim();

                Boolean tempParams = false;
                //Loop through baseCls.preLoadParams and check if all required values are set
                foreach (String item in baseCls.preLoadParams)
                {
                    //If return type is one way ReturnJourneyDate is optional
                    if (baseCls.preLoadParams[6].ToUpper().Equals("ONEWAY"))
                        if (baseCls.preLoadParams[3].Trim() == String.Empty)
                            continue;

                    if (item.Trim() == String.Empty)
                    {
                        tempParams = true;
                        break;
                    }
                }

                //If all required parameters are not set, reqirect user to default page.
                if (tempParams)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    HttpContext.Current.Session["btnType"] = "btnContinue";

                    #region Load Sources and destinations in dropdowns

                    if (ObjDataset == null)
                    {
                        objManabusBAL = new ClsBAL();
                        ObjDataset = objManabusBAL.GetCities();
                    }
                    if (ObjDataset != null)
                    {
                        if (ObjDataset.Tables.Count > 0)
                        {
                            if (ObjDataset.Tables[0].Rows.Count > 0)
                            {
                                ddlSources.DataSource = ObjDataset.Tables[0];
                                ddlSources.DataTextField = "SourceName";
                                ddlSources.DataValueField = "ID";
                                ddlSources.DataBind();
                                ddlSources.Items.Insert(0, "----------");
                                //Session["sesDTDestinations"] = ObjDataset.Tables[0];
                            }
                        }
                    }

                    #endregion

                    DateTime dt = Convert.ToDateTime(baseCls.preLoadParams[2].ToString());
                    string sss = dt.ToString("dd-MMMM-yyyy");
                    lblJD.Text = sss;

                    ListItem lt = ddlSources.Items.FindByText(baseCls.preLoadParams[4].ToString());
                    ddlSources.SelectedValue = lt.Value;

                    DataTable dtDestinations = ObjDataset.Tables[0];//(DataTable)Session["sesDTDestinations"];
                    StringBuilder sbTravels = new StringBuilder();
                    if (dtDestinations.Rows.Count > 0)
                    {
                        sbTravels.Append("<select id=\"ddldestinationsDiv\" name=\"ddldestinationsDiv\" class=\"Dropdownlist\" >");

                        sbTravels.Append("<option value=''>----------</option>");
                        foreach (DataRow item in dtDestinations.Rows)
                        {
                            if (baseCls.preLoadParams[5].ToString() != item["SourceName"].ToString())
                            {
                                sbTravels.Append("<option value=" + item["ID"].ToString() + ">" + item["SourceName"].ToString() + "</option>");
                            }
                            else
                            {
                                sbTravels.Append("<option selected='selected' value=" + item["ID"].ToString() + ">" + item["SourceName"].ToString() + "</option>");
                            }
                        }
                        sbTravels.Append("</select>");
                    }
                    destinationsDiv.InnerHtml = sbTravels.ToString();

                    if (baseCls.preLoadParams[6].ToString() == "OneWay")
                    {
                        lblOnwardJourneyHeader.Visible = false;
                    }
                    else { lblOnwardJourneyHeader.Visible = true; }
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.") { Response.Redirect("~/Default.aspx", false); }
        }
    }

    protected void showmenus()
    {
        if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
        {
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = true;
            liagents.Visible = true;
            lipromocode.Visible = true;
            lifeedback.Visible = true;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenusettings.Visible = true;
            lisubmenuReports.Visible = true;
            liReports1.Visible = true;
        }
        else if (Session["Role"].ToString() == "User")
        {
            lidashboard.Visible = false;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = false;
            liagents.Visible = false;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenusettings.Visible = false;
            lisubmenuReports.Visible = false;
            liReports1.Visible = false;
            FeedBack.Visible = true;
        }
    }

    #region WebMethods

    [WebMethod(EnableSession = true)]
    public static string GetCancellationPolicy(String travelsName, String busType)
    {
        try
        {
            StringBuilder sbCancellation = new StringBuilder();
            DataTable dtCancellation = null;
            ClsBAL objManabusBAL = new ClsBAL();
            objManabusBAL.api = travelsName.ToString();
            dtCancellation = objManabusBAL.GetCancelPercentageByAPI().Tables[0];
            if (dtCancellation.Rows.Count > 0)
            {
                sbCancellation.Append("<table width='450px' cellpadding='5'><tr><th colspan='2' align='center'>");
                sbCancellation.Append("Operator: " + travelsName + " || Type: " + busType);
                sbCancellation.Append("</th></tr><tr><td colspan='2'> </td></tr><tr><th>Cancellation Time</th><th>Percentage</th></tr>");
                foreach (DataRow dr in dtCancellation.Rows)
                {
                    sbCancellation.Append("<tr><td >");
                    sbCancellation.Append(dr["BeforeTime"]);
                    sbCancellation.Append("</td><td>");
                    sbCancellation.Append(dr["CancePercentage"]);
                    sbCancellation.Append("</td></tr>");
                }
                sbCancellation.Append("<tr><td ></td>");
                sbCancellation.Append("<td align='right'>   <img alt='i' src='../../Images/001_051.png' onclick='CloseDiv();' title='Click to close'/>   </td>");
                sbCancellation.Append("</tr></table>");
            }
            else
            {
                sbCancellation.Append("<table width='450px' cellpadding='5'><tr><th colspan='2' align='center'>");
                sbCancellation.Append("Operator: " + travelsName + " || Type: " + busType);
                sbCancellation.Append("</th></tr><tr><td colspan='2'> </td></tr><tr><th>Cancellation Time</th><th>Percentage</th></tr>");
                sbCancellation.Append("<tr><td colspan='2'> No Cancellation Policy Found. </td></tr><tr><td ></td>");
                sbCancellation.Append("<td align='right'>   <img alt='i' src='../../Images/001_051.png' onclick='CloseDiv();' title='Click to close'/>   </td></tr></table>");
            }
            return sbCancellation.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public static string GetPoints(String BDParams, String api, String boardingOrDropping, string stringPoints)
    {
        try
        {
            BaseClass baseCls = new BaseClass();
            baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);

            StringBuilder sbBoardingPoints = new StringBuilder();
            KesineniDetails kesineniDetails;
            AbhiBusDetails abhiBusDetails;
            BitlaDetails bitlaDetails;
            kesineniDetails = new KesineniDetails();
            kesineniDetails.LoginId = KesineniConstants.LoginId;
            kesineniDetails.PassWord = KesineniConstants.Password;

            abhiBusDetails = new AbhiBusDetails();
            abhiBusDetails.Url = AbhiBusConstants.URL;

            bitlaDetails = new BitlaDetails();
            bitlaDetails.ApiKey = BitlaConstants.API_KEY;
            bitlaDetails.Url = BitlaConstants.URL;

            DataTable dt = null;
            KABCommon commonCls = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

            if (boardingOrDropping == "Boarding")
            {
                if (api != "Abh")
                {
                    dt = commonCls.GetBoardingPoints(BDParams, api);
                }
                else
                {
                    DataTable dtBP = new DataTable();
                    dtBP.Columns.Add("Name");
                    dtBP.Columns.Add("Id");
                    dtBP.Columns.Add("Address");
                    dtBP.Columns.Add("ContactNumber");
                    dtBP.Columns.Add("Landmark");

                    string strBP = stringPoints;

                    if (strBP != "")
                    {
                        string[] str = new string[1];
                        str[0] = "%&%";
                        string[] ssstr = strBP.Split(str, StringSplitOptions.None);
                        foreach (string st in ssstr)
                        {
                            if (st != "")
                            {
                                string[] sp = new string[1];
                                sp[0] = "%&&%";

                                string[] strAA = st.Split(sp, StringSplitOptions.None);

                                string[] strArr = strAA[0].ToString().Split('-');

                                DataRow dr = dtBP.NewRow();
                                if (strArr.Length == 3)
                                {
                                    dr["Name"] = strArr[0].ToString() + " - " + strArr[1].ToString();
                                    dr["Id"] = strArr[2].ToString().Trim().ToString();
                                    dr["Address"] = "";
                                    dr["ContactNumber"] = strAA[1].ToString();
                                    dr["Landmark"] = "";
                                    dtBP.Rows.Add(dr);
                                }
                                else if (strArr.Length == 5)
                                {
                                    dr["Name"] = strArr[0].ToString() + "" + strArr[1].ToString() + "" + strArr[2].ToString() + " - " + strArr[3].ToString();
                                    dr["Id"] = strArr[4].ToString().Trim().ToString();
                                    dr["Address"] = "";
                                    dr["ContactNumber"] = strAA[1].ToString();
                                    dr["Landmark"] = "";
                                    dtBP.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    dt = dtBP;
                }
            }
            else if (boardingOrDropping == "Dropping")
            {
                if (api != "Abh")
                {
                    dt = commonCls.GetDropingPoints(BDParams, api);
                }
                else
                {
                    DataTable dtBP = new DataTable();
                    dtBP.Columns.Add("Name");
                    dtBP.Columns.Add("Id");
                    dtBP.Columns.Add("Address");
                    dtBP.Columns.Add("ContactNumber");
                    dtBP.Columns.Add("Landmark");

                    string strBP = stringPoints;

                    if (strBP != "")
                    {
                        string[] str = new string[1];
                        str[0] = "%&%";
                        string[] ssstr = strBP.Split(str, StringSplitOptions.None);
                        foreach (string st in ssstr)
                        {
                            if (st != "")
                            {
                                string[] strArr = st.Split('-');
                                DataRow dr = dtBP.NewRow();
                                if (strArr.Length == 3)
                                {
                                    dr["Name"] = strArr[0].ToString() + " - " + strArr[1].ToString();
                                    dr["Id"] = strArr[2].ToString().Trim().ToString();
                                    dr["Address"] = "";
                                    dr["ContactNumber"] = "";
                                    dr["Landmark"] = "";
                                    dtBP.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    dt = dtBP;
                }
            }
            if (dt.Rows.Count > 0)
            {
                sbBoardingPoints.Append("<table cellpadding='5'>");
                sbBoardingPoints.Append("<tr>");
                sbBoardingPoints.Append("<th>");
                sbBoardingPoints.Append(boardingOrDropping + " Points");
                sbBoardingPoints.Append("</th>");
                sbBoardingPoints.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    sbBoardingPoints.Append("<tr><td>");
                    sbBoardingPoints.Append(dr["Name"]);
                    sbBoardingPoints.Append("</tr></td>");
                }
                sbBoardingPoints.Append("</table>");
            }
            else
            {
                sbBoardingPoints.Append("<table cellpadding='5'>");
                sbBoardingPoints.Append("<tr>");
                sbBoardingPoints.Append("<th>");
                sbBoardingPoints.Append(boardingOrDropping + " Points");
                sbBoardingPoints.Append("</th>");
                sbBoardingPoints.Append("</tr>");
                sbBoardingPoints.Append("<tr><td>");
                //sbBoardingPoints.Append(" No " + boardingOrDropping + " Points Found");
                if (boardingOrDropping != "Dropping")
                {
                    sbBoardingPoints.Append("" + baseCls.preLoadParams[4].ToString() + "");
                }
                else { sbBoardingPoints.Append("" + baseCls.preLoadParams[5].ToString() + ""); }
                sbBoardingPoints.Append("</tr></td>");
                sbBoardingPoints.Append("</table>");
            }
            return sbBoardingPoints.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public static String[] GetSeatLayout(String args)
    {
        String[] returnval = new String[5];
        try
        {
            BaseClass baseCls = new BaseClass();
            baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);

            KesineniDetails kesineniDetails;
            AbhiBusDetails abhiBusDetails;
            BitlaDetails bitlaDetails;
            KABCommon objCommon;
            kesineniDetails = new KesineniDetails();
            kesineniDetails.LoginId = KesineniConstants.LoginId;
            kesineniDetails.PassWord = KesineniConstants.Password;
            abhiBusDetails = new AbhiBusDetails();
            abhiBusDetails.Url = AbhiBusConstants.URL;
            bitlaDetails = new BitlaDetails();
            bitlaDetails.ApiKey = BitlaConstants.API_KEY;
            bitlaDetails.Url = BitlaConstants.URL;
            objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

            string[] strArray = args.Split('~');

            string TripType = baseCls.preLoadParams[6].ToString();

            string type = strArray[7].ToString();//Onward,Return

            string journeyDetails = strArray[8].ToString() + "~" + strArray[9].ToString() + "~" + strArray[10].ToString() + "~" + strArray[11].ToString() + "~" + strArray[12].ToString();

            #region Boarding Points

            System.Text.StringBuilder sbBoardingPoints = new System.Text.StringBuilder();

            DataTable dtBoardingPoints = new DataTable();
            DataTable dtDroppiongPoints = null;
            DataTable dtBitlaSeatLayout = null;

            if (strArray[0].ToString() == "Abh")
            {
                DataTable dtBP = new DataTable();
                dtBP.Columns.Add("Name");
                dtBP.Columns.Add("Id");
                dtBP.Columns.Add("Address");
                dtBP.Columns.Add("ContactNumber");
                dtBP.Columns.Add("Landmark");

                string strBP = strArray[6].ToString();

                if (strBP != "")
                {
                    string[] str = new string[1];
                    str[0] = "%&%";
                    string[] ssstr = strBP.Split(str, StringSplitOptions.None);
                    foreach (string st in ssstr)
                    {
                        if (st != "")
                        {
                            string[] sp = new string[1];
                            sp[0] = "%&&%";

                            string[] strAA = st.Split(sp, StringSplitOptions.None);

                            string[] strArr = strAA[0].ToString().Split('-');

                            DataRow dr = dtBP.NewRow();
                            if (strArr.Length == 3)
                            {
                                dr["Name"] = strArr[0].ToString() + " - " + strArr[1].ToString();
                                dr["Id"] = strArr[2].ToString().Trim().ToString();
                                dr["Address"] = "";
                                dr["ContactNumber"] = strAA[1].ToString();
                                dr["Landmark"] = "";
                                dtBP.Rows.Add(dr);
                            }
                            else if (strArr.Length == 5)
                            {
                                dr["Name"] = strArr[0].ToString() + "" + strArr[1].ToString() + "" + strArr[2].ToString() + " - " + strArr[3].ToString();
                                dr["Id"] = strArr[4].ToString().Trim().ToString();
                                dr["Address"] = "";
                                dr["ContactNumber"] = strAA[1].ToString();
                                dr["Landmark"] = "";
                                dtBP.Rows.Add(dr);
                            }
                        }
                    }
                }
                dtBoardingPoints = dtBP;
            }
            else
            {
                if (strArray[0].ToString() == "Bit")
                {
                    dtBitlaSeatLayout = objCommon.GetBitlaSeatLayoutAndBoardingPoints(strArray[1].ToString(), out dtBoardingPoints);
                }
                else
                {
                    dtBoardingPoints = objCommon.GetBoardingPoints(strArray[1].ToString(), strArray[0].ToString());
                }
                if (strArray[0].ToString() == "Kes")
                {
                    dtDroppiongPoints = objCommon.GetDropingPoints(strArray[1].ToString(), strArray[0].ToString());
                    DataRow dr = dtDroppiongPoints.Rows[Convert.ToInt32(dtDroppiongPoints.Rows.Count - 1)];
                }
            }

            HttpContext.Current.Session["dtBPForAddressAndLandmark"] = dtBoardingPoints;
            HttpContext.Current.Session["dtDPForAddressAndLandmark"] = dtDroppiongPoints;

            HttpContext.Current.Session["lblB"] = strArray[4].ToString();
            HttpContext.Current.Session["ServiceNumber"] = strArray[5].ToString();


            sbBoardingPoints.Append("<a href='' id=\"lblBP\" class=\"fg-button fg-button-icon-right ui-widget ui-state-default ui-corner-all\" onclick=\"$('#ulbp').slideDown('fast'); return false; \">" + " <span class=\"ui-icon ui-icon-triangle-1-s\"></span>" + "Boarding Points</a>");
            sbBoardingPoints.Append("<label id=\"lblBoardingPoint\" style=\"display: none;\" class=\"add_cont\"></label>");
            sbBoardingPoints.Append("<input id=\"boardingpoint\" type=\"hidden\" value='' name=\"boardingpoint\">");
            sbBoardingPoints.Append("<ul class=\"boardingpoints\" style=\"display: none; position: absolute;\" id='ulbp'>");
            sbBoardingPoints.Append("<img src='images/closeseatlayout.png' onclick=\"$('#ulbp').slideUp('meduim');\" title='close' style=\"float: right;\"/>");

            foreach (DataRow dr in dtBoardingPoints.Rows)
            {
                dr["Address"] = dr["Address"].ToString().Replace("\n", "&nbsp;");
                sbBoardingPoints.Append("<li id=\"" + dr["Id"].ToString() + "\"><span onmouseover=\"showPanel(event, 'boardingpoint_info', '" + dr["ContactNumber"].ToString() + "~" + dr["Landmark"].ToString() + "~" + dr["Address"].ToString() + "');\" ");
                sbBoardingPoints.Append("onmouseout=\"closePanel('boardingpoint_info');\" onclick=\"closePanel('boardingpoint_info'); $('#boardingpoint').val($(this).parent()[0].id); $('#lblBP').html($(this).html()); $('#lblBoardingPoint').html($(this).html()); $('#ulbp').fadeOut('meduim');\">" + dr["Name"].ToString() + "</span> </li>"); //alert( $('#boardingpoint').val());
            }

            sbBoardingPoints.Append("</ul>");

            #endregion

            string strNoLayout = "";
            string strNoBp = "";
            StringBuilder sbSeatLayout = new StringBuilder();
            DataTable dtMain = null;
            if (strArray[0].ToString() == "Bit")
            {
                dtMain = dtBitlaSeatLayout;
                if (dtMain.Rows.Count == 0)
                {
                    strNoLayout = " <div style=\"\"><h1> Service is no longer available. </h1></div>";
                    strNoBp = " --- ";
                }
            }
            else
            {
                dtMain = objCommon.GetSeatLayout(strArray[0].ToString(), strArray[1].ToString()).Tables[0];
                if (dtMain.Rows.Count == 0)
                {
                    strNoLayout = " <div style=\"\"><h1> Service is no longer available. </h1></div>";
                    strNoBp = " --- ";
                }
            }

            returnval[0] = sbBoardingPoints.ToString();

            if (strNoLayout != "")
            {
                returnval[1] = strNoLayout;
            }
            else { returnval[1] = GetSeatLayout(dtMain, strArray[3].ToString(), strArray[2].ToString()); }

            returnval[2] = strArray[2].ToString() + " || " + strArray[3].ToString();

            returnval[3] = "btnContinue";
            returnval[4] = journeyDetails;
        }
        catch (Exception ex)
        {
            //
            Mailsender.SendErrorEmail("prasad@lovejourney.in", "prasad@lovejourney.in;",
                                          "", "SeatLayoutIssue // LoveJourney.in", args.ToString()
                                          + "////////////////////////////////////////////////////////////////////////////////////"
                                          + ex.Message + ex.Source + ex.InnerException + ex.StackTrace);
        }
        return returnval;
    }

    public static String GetSeatLayout(DataTable dtMain, String seatType, String travelOperator)
    {
        StringBuilder sbSeatLayout = new StringBuilder();
        StringBuilder sbSeatLayoutSleeper = new StringBuilder();

        DataTable dtUpper = dtMain.Clone();
        dtUpper.TableName = "Upper";

        DataTable dtLower = dtMain.Clone();
        dtLower.TableName = "Lower";

        DataSet dsSleeper = new DataSet();
        dtMain.TableName = "Main";

        DataSet dss = dtMain.DataSet;
        if (dss == null) { dsSleeper.Tables.Add(dtMain); }
        else { dtMain.DataSet.Tables.Clear(); dsSleeper.Tables.Add(dtMain); }

        //travelOperator.ToLower().Contains("svr") && travelOperator.ToLower().Contains("tours") && travelOperator.ToLower().Contains("travels") &&
        if (seatType.ToString().ToLower().Contains("sleeper") && !seatType.ToString().ToLower().Contains("semi"))
        {
            foreach (DataRow item in dtMain.Rows)
            {
                if (item["Seat"].ToString().ToUpper().Contains("U"))
                {
                    dtUpper.ImportRow(item);
                }
                if (item["Seat"].ToString().ToUpper().Contains("L"))
                {
                    dtLower.ImportRow(item);
                }
            }
            if (dtLower.Rows.Count >= 0 && dtUpper.Rows.Count >= 0)
            {
                dsSleeper.Tables.Clear();
                dsSleeper.Tables.Add(dtUpper);
                dsSleeper.Tables.Add(dtLower);
            }
        }
        try
        {
            if (dsSleeper.Tables.Count != 0)
            {
                for (int tbl = 0; tbl < dsSleeper.Tables.Count; tbl++)
                {
                    dtMain = dsSleeper.Tables[tbl];

                    if (dtMain.Rows.Count > 0)
                    {
                        #region Code to convert "Row" & "Column" columns to integer datatype

                        //create a copy of main table
                        DataTable dt = dtMain.Clone();
                        //set column datatypes for int values
                        dt.Columns["row"].DataType = Type.GetType("System.Int16");
                        dt.Columns["column"].DataType = Type.GetType("System.Int16");
                        //dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");

                        DataRow[] drArray1 = null;
                        //DataRow[] drArray1 = dtMain.Select(String.Empty, "row, column ASC");

                        if (dtMain.Rows[0][0].ToString() == "Bit" || dtMain.Rows[0][0].ToString() == "Tig")
                        {
                            drArray1 = dtMain.Select(String.Empty, "Row DESC, Column ASC");
                        }
                        else { drArray1 = dtMain.Select(String.Empty, "Row, Column ASC"); }

                        if (drArray1.Length > 0)
                        {
                            foreach (DataRow dr in drArray1)
                                dt.ImportRow(dr);
                        }

                        dt.AcceptChanges();

                        #endregion

                        var zIndexCount = "1".ToList();

                        //var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();

                        var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                        var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();

                        //Used in exceptional cases where a bus has both seats and sleeper coaches
                        //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                        //int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                        //int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();
                        int maxLength = 1;
                        int maxWidth = 1;

                        String strSeatType = String.Empty;
                        String strSeatCssSuffix = String.Empty;

                        if (zIndexCount.Count > 1)
                            sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                        else
                            sbSeatLayout.Append("<table align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 3px; margin: 3px; \"><tr><td colspan=\"2\">");

                        foreach (Int16 index in zIndexCount)
                        {
                            if (zIndexCount.Count > 1)
                            {
                                //div tag is added to show border with same size for upper and lower decks
                                sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 7px; margin: 3px; \">");
                                sbSeatLayout.Append("<table>");
                            }
                            else
                                sbSeatLayout.Append("<div><table>");
                            foreach (Int16 row in RowCount)
                            {
                                #region Create datarow array

                                //Get the actual row count to drArrayMain 
                                DataRow[] drArrayMain = dt.Select("Row = " + row, "Column ASC");//dt.Select("Row = " + row + " AND zIndex = " + index, "Column ASC");

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
                                            if (drArrayMain.Length > 0 && drArrayMain[0].ItemArray.Length > 0 && drArrayMain[0].ItemArray[0].ToString() == "Tig")
                                            {
                                                DataRow[] ddr = dt.Select("Row = " + row + " AND Column = " + Convert.ToInt16(i + 1) + " AND Seat <> ''");// 
                                                if (ddr.Length >= 1)
                                                {
                                                    drArray[i] = ddr[0];
                                                }
                                                else { drArray[i] = dt.NewRow(); }
                                            }
                                            else
                                            {
                                                drArray[i] = drArrayMain.Single(p => int.Parse(p["Column"].ToString()) == int.Parse(ColumnCount[i].ToString()));
                                            }
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

                                #region loop array and add seats

                                foreach (DataRow dr in drArray)
                                {
                                    #region Set seat type seat/sleeper_v/sleeper_h

                                    /******* HARD CODED SEATTYPE FOR TESTING *********/
                                    if (dr["Seat"].ToString() != String.Empty)
                                    {

                                        if (seatType.ToString().ToLower().Contains("sleeper") && !seatType.ToString().ToLower().Contains("semi"))
                                        {
                                            strSeatType = "Sleeper";
                                            strSeatCssSuffix = "sleeper";
                                        }
                                        else
                                        {
                                            strSeatType = "Seat";
                                            strSeatCssSuffix = "seat";
                                        }

                                    }

                                    #endregion

                                    //Check if datarow has empty seats, if so add empty spaces
                                    if (dr["Seat"] != null && dr["Seat"].ToString() != String.Empty)
                                    {
                                        //set appropriate class based on seat availability
                                        if (dr["SeatStatus"].ToString().ToUpper() == "FALSE")
                                        {
                                            if (dr["IsBookedByFemale"].ToString().ToUpper() == "TRUE")
                                                sbSeatLayout.Append("<li id=\"li" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" title=\" Booked - " + dr["Seat"].ToString() + " \"+ ");
                                            else
                                                sbSeatLayout.Append("<li id=\"li" + dr["Seat"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title=\" Booked - " + dr["Seat"].ToString() + " \"+  > ");
                                        }
                                        else
                                        {
                                            if (dr["IsBookedByFemale"].ToString().ToUpper() == "TRUE")
                                                sbSeatLayout.Append("<li id=\"li" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                            else
                                                sbSeatLayout.Append("<li id=\"li" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                            if (dr["IsReservedForFemale"].ToString().ToUpper() == "TRUE")
                                                sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["Seat"].ToString() + "', '" + dr["Fare"].ToString() + "," + strSeatType + ",1', 'available')\" ");
                                            else
                                                sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["Seat"].ToString() + "', '" + dr["Fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");

                                            sbSeatLayout.Append("onmouseout=\"closePanel('seat_info');\" ");
                                            sbSeatLayout.Append("onmouseover=\"showPanel(event,'seat_info','" + dr["Seat"].ToString() + "," + dr["Fare"].ToString() + "," + strSeatType + "');\">");

                                            //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                        }

                                        //Seat number is properly displayed in Chrome and Firefox except IE. 
                                        //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                        //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                        sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>" + "" + "</a></li>");

                                        sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                        //sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["Seat"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
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

            }
        }
        catch (Exception ex)
        {
            // only for development purpose
        }
        return sbSeatLayout.ToString();
    }

    [WebMethod(EnableSession = true)]
    public static String[] GetRoutes(String Sorting, String Filter)
    {
        String[] returnval = null;
        try
        {
            BaseClass baseCls = new BaseClass();
            baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);

            if (Filter.ToLower() == "reset" && Sorting.ToLower() == "reset")
            {
                travelOperatorSelected = "";
                DataTable dt = (DataTable)HttpContext.Current.Session["dtRoutes"];
                returnval = GetDataset(dt);
            }

            else if (Sorting.ToLower() == "modify")
            {
                travelOperatorSelected = "";
                String[] filterparams = Filter.Split('*');

                baseCls.preLoadParams[0] = filterparams[0].ToString();
                baseCls.preLoadParams[1] = filterparams[1].ToString();
                baseCls.preLoadParams[2] = filterparams[2].ToString();
                baseCls.preLoadParams[3] = baseCls.preLoadParams[3].ToString();
                baseCls.preLoadParams[4] = filterparams[3].ToString();
                baseCls.preLoadParams[5] = filterparams[4].ToString();
                baseCls.preLoadParams[6] = baseCls.preLoadParams[6].ToString();


                HttpContext.Current.Session["Parameters"] = baseCls;

                KesineniDetails kesineniDetails = new KesineniDetails(KesineniConstants.LoginId, KesineniConstants.Password);
                BitlaDetails bitlaDetails = new BitlaDetails(BitlaConstants.URL, BitlaConstants.API_KEY);
                AbhiBusDetails abhiBusDetails = new AbhiBusDetails();
                KABCommon objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

                DataTable dtroutes = null;


                dtroutes = objCommon.GetRoutes(
                           baseCls.preLoadParams[0].ToString()
                           , baseCls.preLoadParams[1].ToString()
                           , baseCls.preLoadParams[2].ToString());

                dtroutes = MarkUp(dtroutes);

                HttpContext.Current.Session["dtRoutes"] = dtroutes;
                returnval = GetDataset(dtroutes);
            }

            else if (Filter.ToUpper() != "NONE")
            {
                String[] filterparams = Filter.Split(',');

                string minPrice = filterparams[5].ToString();
                string maxPrice = filterparams[6].ToString();
                string minDepTime = filterparams[7].ToString();
                string maxDepTime = filterparams[8].ToString();

                FilterBusesWithSliders(minPrice, maxPrice, minDepTime, maxDepTime);

                returnval = FilterBuses(
                    Boolean.Parse(filterparams[0])
                    , Boolean.Parse(filterparams[1])
                    , Boolean.Parse(filterparams[2])
                    , Boolean.Parse(filterparams[3])
                    , filterparams[4].ToString(), Sorting);
            }

            else
            {
                KesineniDetails kesineniDetails = new KesineniDetails(KesineniConstants.LoginId, KesineniConstants.Password);
                BitlaDetails bitlaDetails = new BitlaDetails(BitlaConstants.URL, BitlaConstants.API_KEY);
                AbhiBusDetails abhiBusDetails = new AbhiBusDetails();
                KABCommon objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);

                DataTable dtroutes = null;
                travelOperatorSelected = "";
                baseCls = new BaseClass();
                baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);

                dtroutes = objCommon.GetRoutes(
                           baseCls.preLoadParams[0].ToString()
                           , baseCls.preLoadParams[1].ToString()
                           , baseCls.preLoadParams[2].ToString());

                dtroutes = MarkUp(dtroutes);

                HttpContext.Current.Session["dtRoutes"] = dtroutes;
                returnval = GetDataset(dtroutes);
            }
        }
        catch (Exception ex)
        {

        }
        return returnval;
    }

    static DataTable MarkUp(DataTable dt)
    {
        //string strUserId = HttpContext.Current.Session["UserID"].ToString();
        //string strRole = HttpContext.Current.Session["Role"].ToString();
        //dt.Columns.Add("ApiFare");

        //foreach (DataRow item in dt.Rows)
        //{
        //    string api = item["API"].ToString();
        //    string fare = item["Fare"].ToString();
        //    //item["Fare"] = 1000;
        //    if (api.ToUpper().ToString() == "ABH")
        //    {
        //        double apiFare = Convert.ToDouble(fare);
        //        int percentage = 10;
        //        double markUpFare = apiFare + ((apiFare * percentage) / 100);
        //        item["Fare"] = markUpFare;
        //        item["ApiFare"] = apiFare;
        //    }
        //}
        //dt.AcceptChanges();
        return dt;
    }

    [WebMethod(EnableSession = true)]
    public static String GetDestinations(String sourceId)
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            DataSet ObjDataset = objManabusBAL.GetDestinations(sourceId);
            StringBuilder sbDestinations = new StringBuilder();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    DataTable dtDestinations = ObjDataset.Tables[0];
                    HttpContext.Current.Session["sesDTDestinations"] = dtDestinations;
                    sbDestinations.Append("<select id=\"ddldestinationsDiv\" name=\"ddldestinationsDiv\" class=\"Dropdownlist\" >");
                    sbDestinations.Append("<option value=''>----------</option>");
                    if (dtDestinations.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtDestinations.Rows)
                        {
                            sbDestinations.Append("<option value=" + item["ID"].ToString() + ">" + item["DestinationName"].ToString() + "</option>");
                        }
                    }
                    sbDestinations.Append("</select>");
                }
            }
            return sbDestinations.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private static String[] GetDataset(DataTable dtroutes)
    {
        String[] returnval = new String[dtroutes.Rows.Count + 2];
        try
        {
            decimal max = 0; decimal min = 0; decimal dec = 0; decimal din = 0;

            #region Get bus rating

            ClsBAL objManabusBAL = new ClsBAL();
            DataTable dtRating = objManabusBAL.GetRatings().Tables[0];

            #endregion

            #region Get distinct travels


            DataTable dtTravels = ((DataTable)(HttpContext.Current.Session["dtRoutes"])).DefaultView.ToTable(true, "Travels");


            //(from DataRow dr in dtroutes.Rows select (string)dr["Name"]).Distinct().OrderBy(name => name); 

            DataRow[] drTravels = dtTravels.Select("", "Travels ASC");

            StringBuilder sbTravels = new StringBuilder();

            if (drTravels.Length > 0)
            {
                sbTravels.Append("<select id=\"ddlOperator\" name=\"ddlOperator\"   class=\"Dropdownlist\" onchange=\"LoadFilteredRoutes(event,''); return false;\" >");

                sbTravels.Append("<option value=''>All Operators</option>");
                foreach (DataRow item in drTravels)
                {
                    if (travelOperatorSelected != item["Travels"].ToString())
                    {
                        sbTravels.Append("<option value=" + item["Travels"].ToString() + ">" + item["Travels"].ToString() + "</option>");
                    }
                    else
                    {
                        sbTravels.Append("<option selected='selected' value=" + item["Travels"].ToString() + ">" + item["Travels"].ToString() + "</option>");
                    }
                }
                sbTravels.Append("</select>");
            }

            returnval[dtroutes.Rows.Count] = sbTravels.ToString();

            #endregion

            for (int i = 0; i < dtroutes.Rows.Count; i++)
            {
                DataRow[] dr = null;
                if (dtroutes.Rows[i]["Travels"].ToString().Length >= 5)
                {
                    dr = dtRating.Select("BusOperatorName LIKE '" + dtroutes.Rows[i]["Travels"].ToString().Substring(0, 5) + "%'");
                }
                else { dr = dtRating.Select("BusOperatorName LIKE '" + dtroutes.Rows[i]["Travels"].ToString() + "%'"); }

                String sRating = dr.Length > 0 ? "../../Images/star" + dr[0]["Rating"].ToString() + ".png" : "../../Images/star3.png";

                string sDuration = dtroutes.Rows[i]["Duration"].ToString();
                if (sDuration == "") { sDuration = " - "; }
                string sArrTime = dtroutes.Rows[i]["ArrTime"].ToString();
                if (sArrTime == "") { sArrTime = " - "; }

                string sBusType = dtroutes.Rows[i]["BusType"].ToString();
                if (sBusType.Length > 50) { sBusType = sBusType.Substring(0, 48); }


                returnval[i] = dtroutes.Rows[i]["API"].ToString() + "~" + dtroutes.Rows[i]["SNo"].ToString() + "~"
                                + dtroutes.Rows[i]["Travels"].ToString() + "~" + sBusType + "~"
                                + dtroutes.Rows[i]["DepTime"].ToString() + "~" + sArrTime + "~"
                                + sDuration + "~" + dtroutes.Rows[i]["Fare"].ToString() + "~"
                                + dtroutes.Rows[i]["ReservationId"].ToString() + "~"
                                + dtroutes.Rows[i]["ServiceId"].ToString() + "~" + dtroutes.Rows[i]["CoachTypeId"].ToString() + "~"
                                + dtroutes.Rows[i]["ServiceNumber"].ToString() + "~"
                                + dtroutes.Rows[i]["BoardingPointsWithIds"].ToString() + "~" + dtroutes.Rows[i]["DropingPointsWithIds"].ToString() + "~"
                                + dtroutes.Rows[i]["lblS"].ToString() + "~"
                                + dtroutes.Rows[i]["lblB"].ToString() + "~"
                                + sRating + "~" + dtroutes.Rows[i]["AvailableSeats"].ToString() + "~"
                                + dtroutes.Rows[i]["SourceId"].ToString() + "~"
                                + dtroutes.Rows[i]["SourceName"].ToString() + "~"
                                + dtroutes.Rows[i]["DestinationId"].ToString() + "~"
                                + dtroutes.Rows[i]["DestinationName"].ToString() + "~"
                                + dtroutes.Rows[i]["JourneyDate"].ToString()
                                ;
                if (i == 0) { max = min = Convert.ToDecimal(Convert.ToDecimal(dtroutes.Rows[i]["Fare"].ToString()).ToString("0", System.Globalization.CultureInfo.InvariantCulture)); }
                dec = din = Convert.ToDecimal(Convert.ToDecimal(dtroutes.Rows[i]["Fare"].ToString()).ToString("0", System.Globalization.CultureInfo.InvariantCulture));
                if (dec > max) { max = dec; }
                if (din < min) { min = din; }

            }
            if (dtroutes.Rows.Count != 0)
            {
                returnval[dtroutes.Rows.Count + 1] = min + "|" + max;
            }
            else { returnval[dtroutes.Rows.Count + 1] = "1" + "|" + "2500"; }
        }
        catch (Exception e)
        {

        }
        return returnval;
    }

    private static String[] FilterBuses(bool ac, bool nonAc, bool sleeper, bool semiSleeper, String traveloperator, String sortfield)
    {

        DataTable dt = (DataTable)HttpContext.Current.Session["dtRoutes"];
        DataTable dtroutes = null;
        dtroutes = dt.Clone();
        DataView dv = new DataView(dt);



        #region Dropdown

        strFilterBusesWithDropDowns = "(Travels LIKE '%" + traveloperator + "%')";
        travelOperatorSelected = traveloperator;

        #endregion

        #region CheckBoxes
        if (ac == false && nonAc == false && sleeper == false && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "";
        }
        else if (ac == true && nonAc == true && sleeper == true && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%A%' OR BusTypeShort LIKE '%N%' OR BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%X%')";
        }
        else if (ac == true && nonAc == false && sleeper == false && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%A%')";
        }
        else if (ac == false && nonAc == true && sleeper == false && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%N%')";
        }
        else if (ac == false && nonAc == false && sleeper == true && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%S%')";
        }
        else if (ac == false && nonAc == false && sleeper == false && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%X%')";
        }
        else if (ac == true && nonAc == true && sleeper == false && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%A%' OR BusTypeShort LIKE '%N%')";
        }
        else if (ac == false && nonAc == false && sleeper == true && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%X%')";
        }
        else if (ac == false && nonAc == true && sleeper == true && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%X%' OR BusTypeShort LIKE '%N%')";
        }
        else if (ac == false && nonAc == true && sleeper == true && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%N%')";
        }
        else if (ac == true && nonAc == false && sleeper == true && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%X%' OR BusTypeShort LIKE '%A%')";
        }
        else if (ac == true && nonAc == true && sleeper == false && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%N%' OR BusTypeShort LIKE '%X%' OR BusTypeShort LIKE '%A%')";
        }
        else if (ac == true && nonAc == true && sleeper == true && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%N%' OR BusTypeShort LIKE '%S%' OR BusTypeShort LIKE '%A%')";
        }
        else if (ac == false && nonAc == true && sleeper == false && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%N%' OR BusTypeShort LIKE '%X%')";
        }
        else if (ac == true && nonAc == false && sleeper == true && semiSleeper == false)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%A%' OR BusTypeShort LIKE '%S%')";
        }
        else if (ac == true && nonAc == false && sleeper == false && semiSleeper == true)
        {
            strFilterBusesWithCheckBoxes = "(BusTypeShort LIKE '%A%' OR BusTypeShort LIKE '%X%')";
        }
        #endregion

        string ssRowFilter = Expression();
        dv.RowFilter = ssRowFilter;
        if (sortfield.ToUpper() != "NONE" && sortfield.ToString() != "")
        {
            if (sortDirection == " ASC")
            {
                sortDirection = " DESC";
                dv.Sort = sortfield + sortDirection;
            }
            else
            {
                sortDirection = " ASC";
                dv.Sort = sortfield + sortDirection;
            }
        }
        dtroutes = dv.ToTable();


        return GetDataset(dtroutes);

    }

    private static void FilterBusesWithSliders(string minPrice, string maxPrice, string minDepTime, string maxDepTime)
    {

        #region Sliders

        {
            strFilterBusesWithSliders = "(Fare >= '" + minPrice + "' AND " + " Fare <= '" + maxPrice + "')";
        }

        {
            int minTime = Convert.ToInt32(minDepTime);
            int maxTime = Convert.ToInt32(maxDepTime);
            if (minTime == 0)
            { minTime = 1; }

            if (minTime != 1)
            { minTime = (Convert.ToInt32((Convert.ToInt32(minTime)) * 60) - 1); }
            maxTime = (Convert.ToInt32((Convert.ToInt32(maxTime) + 1) * 60) - 1);

            strFilterBusesWithSliders = strFilterBusesWithSliders + " AND " + "(DepTimeInMins >= '" + minTime
                   + "' AND " + " DepTimeInMins <= '" + maxTime + "')";
        }

        #endregion



    }

    private static string Expression()
    {
        try
        {
            string strCD = "";
            string strReturn = "";

            ///

            if (strFilterBusesWithCheckBoxes == "" && strFilterBusesWithDropDowns == "")
            {
                strCD = "";
            }
            else if (strFilterBusesWithCheckBoxes != "" && strFilterBusesWithDropDowns != "")
            {
                strCD = strFilterBusesWithCheckBoxes + " AND " + strFilterBusesWithDropDowns;
            }
            else if (strFilterBusesWithCheckBoxes == "" && strFilterBusesWithDropDowns != "")
            {
                strCD = strFilterBusesWithDropDowns;
            }
            else if (strFilterBusesWithCheckBoxes != "" && strFilterBusesWithDropDowns == "")
            {
                strCD = strFilterBusesWithCheckBoxes;
            }
            ///

            ///

            if (strCD == "" && strFilterBusesWithSliders == "")
            {
                strReturn = "";
            }
            else if (strCD != "" && strFilterBusesWithSliders != "")
            {
                strReturn = strCD + " AND " + strFilterBusesWithSliders;
            }
            else if (strCD == "" && strFilterBusesWithSliders != "")
            {
                strReturn = strFilterBusesWithSliders;
            }
            else if (strCD != "" && strFilterBusesWithSliders == "")
            {
                strReturn = strCD;
            }
            ///

            return strReturn;
        }
        catch (Exception)
        {
            throw;
        }
    }

    #endregion

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            BaseClass baseCls = new BaseClass();
            baseCls = (BaseClass)(HttpContext.Current.Session["Parameters"]);

            string strBoardingPointId = hdnBoardingPointIdJQ.Value;
            string strSeatList = hdnSeatListJQ.Value;
            string strFare = hdnFareJQ.Value;
            string strTravelInfo = hdnTravelInfoJQ.Value;
            string strBoardingPointName = hdnBoardingPointNameJQ.Value;
            string strBoardingPointAddress = "";

            string strJourneyDetails = hdnJourneyDetailsJQ.Value;

            string lblB = Session["lblB"].ToString();
            string serviceNumber = Session["ServiceNumber"].ToString();

            string strInfo = "";
            int noOfSeats = strSeatList.ToString().Split(',').Length;

            if (lblB.ToString().Split(';')[0].ToString() == "Kes")
            {
                if (noOfSeats > 4)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "You can select max 4 seats." + "');</script>", false);
                    return;
                }
            }
            else
            {
                if (noOfSeats > 6)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "You can select max 6 seats." + "');</script>", false);
                    return;
                }
            }


            string[] str = new string[1];
            str[0] = " || ";
            string[] strTravelInfoArray = strTravelInfo.Split(str, StringSplitOptions.None);

            DataTable dt = (DataTable)Session["dtBPForAddressAndLandmark"];
            if (strBoardingPointName != "")
            {
                DataRow[] dr = dt.Select("Name ='" + strBoardingPointName + "'");
                string str11 = "" + dr[0]["Landmark"].ToString();
                strBoardingPointAddress = str11;
                if (str11 == "") { strBoardingPointAddress = dr[0]["Address"].ToString(); }
                strBoardingPointAddress = strBoardingPointAddress + ", " + dr[0]["Address"].ToString() + ", " + dr[0]["ContactNumber"].ToString();
            }


            if (lblB.ToString().Split(';')[0].ToString() == "Kes")
            {
                DataTable dtDroppiongPoints = (DataTable)Session["dtDPForAddressAndLandmark"];
                DataRow dr = dtDroppiongPoints.Rows[Convert.ToInt32(dtDroppiongPoints.Rows.Count - 1)];

                string bpPointsKes = ""; bpPointsKes = strBoardingPointId;
                if (noOfSeats > 1)
                {
                    for (int i = 0; i < noOfSeats - 1; i++)
                    {
                        bpPointsKes = bpPointsKes + "," + strBoardingPointId;
                    }
                }
                strInfo = ";" + Convert.ToString(noOfSeats) + ";" + strSeatList + ";" +
                    bpPointsKes + ";" + strFare + ";" + dr["Id"].ToString();
            }
            else if (lblB.ToString().Split(';')[0].ToString() == "Bit")
            {
                strInfo = ";" + Convert.ToString(noOfSeats) + ";" + strBoardingPointId + ";"
                    + strSeatList;
            }
            else if (lblB.ToString().Split(';')[0].ToString() == "Abh")
            {
                strInfo = ";" + strSeatList + ";" + strBoardingPointId + ";" +
                    Convert.ToString(noOfSeats);
            }
            else if (lblB.ToString().Split(';')[0].ToString() == "Kal")
            {
                strInfo = ";" + strSeatList + ";" + strBoardingPointId + ";" +
                    Convert.ToString(noOfSeats);
            }
            else if (lblB.ToString().Split(';')[0].ToString() == "Tig")
            {
                strInfo = ";" + strBoardingPointId;
            }

            DataTable dtTicketInfo = new DataTable();
            dtTicketInfo.TableName = "TicketDetails";
            dtTicketInfo.Columns.Add("Route");
            dtTicketInfo.Columns.Add("JourneyDate");
            dtTicketInfo.Columns.Add("Travels");
            dtTicketInfo.Columns.Add("BusType");
            dtTicketInfo.Columns.Add("SeatNos");
            dtTicketInfo.Columns.Add("TotalFare");
            dtTicketInfo.Columns.Add("BoardingPoint");
            dtTicketInfo.Columns.Add("Title");
            dtTicketInfo.Columns.Add("FullName");
            dtTicketInfo.Columns.Add("Age");
            dtTicketInfo.Columns.Add("PhoneNo");
            dtTicketInfo.Columns.Add("EmailId");
            dtTicketInfo.Columns.Add("Address");
            dtTicketInfo.Columns.Add("OtherInfo");
            dtTicketInfo.Columns.Add("BoardingInfo");
            dtTicketInfo.Columns.Add("ServiceNumber");
            dtTicketInfo.Columns.Add("FullNameList");
            dtTicketInfo.Columns.Add("PhoneNoList");
            dtTicketInfo.Columns.Add("AgeList");
            dtTicketInfo.Columns.Add("GenderList");
            dtTicketInfo.Columns.Add("IdType");
            dtTicketInfo.Columns.Add("IdNo");
            dtTicketInfo.Columns.Add("IdIssuedBy");

            DataRow drTicketDetails = dtTicketInfo.NewRow();
            drTicketDetails["Route"] = baseCls.preLoadParams[4].ToString() + "  To  " + baseCls.preLoadParams[5].ToString() + "";
            drTicketDetails["JourneyDate"] = baseCls.preLoadParams[2].ToString();
            drTicketDetails["Travels"] = strTravelInfoArray[0].ToString();
            drTicketDetails["BusType"] = strTravelInfoArray[1].ToString();
            drTicketDetails["SeatNos"] = strSeatList;
            drTicketDetails["BoardingPoint"] = strBoardingPointName;
            drTicketDetails["Title"] = "";
            drTicketDetails["FullName"] = "";
            drTicketDetails["Age"] = "";
            drTicketDetails["PhoneNo"] = "";
            drTicketDetails["EmailId"] = "";
            drTicketDetails["Address"] = "";
            drTicketDetails["TotalFare"] = strFare;
            drTicketDetails["OtherInfo"] = lblB + strInfo;
            drTicketDetails["BoardingInfo"] = strBoardingPointAddress;
            drTicketDetails["ServiceNumber"] = serviceNumber;
            drTicketDetails["FullNameList"] = "";
            drTicketDetails["PhoneNoList"] = "";
            drTicketDetails["AgeList"] = "";
            drTicketDetails["GenderList"] = "";
            drTicketDetails["IdType"] = "";
            drTicketDetails["IdNo"] = "";
            drTicketDetails["IdIssuedBy"] = "";

            dtTicketInfo.Rows.Add(drTicketDetails);

            Session["dtTicketInfo"] = dtTicketInfo;

            Session["ddlSources"] = baseCls.preLoadParams[0].ToString();
            Session["ddlDestinations"] = baseCls.preLoadParams[1].ToString();
            Session["DOJ"] = baseCls.preLoadParams[2].ToString();
            Session["From"] = baseCls.preLoadParams[4].ToString();
            Session["To"] = baseCls.preLoadParams[5].ToString();

            Session["ddlSourcesReturn"] = baseCls.preLoadParams[1].ToString();
            Session["ddlDestinationsReturn"] = baseCls.preLoadParams[0].ToString();
            Session["DOJReturn"] = baseCls.preLoadParams[3].ToString();
            Session["FromReturn"] = baseCls.preLoadParams[5].ToString();
            Session["ToReturn"] = baseCls.preLoadParams[4].ToString();

            Session["OneWayOrRoundTrip"] = baseCls.preLoadParams[6].ToString();

            if (baseCls.preLoadParams[6].ToString() == "OneWay")
            {
                Session["dtTicketInfoReturn"] = null;
                Response.Redirect("~/Users/Bus/ProceedToBook.aspx", false);
            }
            else
            {
                Response.Redirect("~/Users/Bus/Show_Trips_ReturnJourney.aspx", false);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void lbtnlogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }
    protected void Menu3_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
    {
        if (e.Item.Text == "LogOut")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}