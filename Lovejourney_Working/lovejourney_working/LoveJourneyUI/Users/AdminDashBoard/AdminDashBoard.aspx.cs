using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;
using BusAPILayer;
using System.Globalization;
using HotelAPILayer;
using FilghtsAPILayer;
using System.Xml;
using System.Net;
using System.Text;
using System.Data.OleDb;
using System.IO;
public partial class Agent_Masters_AdminDashBoard : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    #region BusGlobalVariables
    ClsBAL objBAL;
    KesineniDetails kesineniDetails;
    AbhiBusDetails abhiBusDetails;
    BitlaDetails bitlaDetails;
    KABCommon objCommon;
    #endregion

    #region HotelGlobalVariables
    IArzooHotelAPILayer objArzooHotelAPILayer;
    #endregion

    #region DomesticFlightsGlobalVariable
   // ClsBAL objBAL = new ClsBAL();
    FlightsAPILayer objFlights = new FlightsAPILayer();
    static DataSet dsFilghts = null;
    static DataSet dsIntFlights = null;
    static int adultcnt = 0;
    static int childCnt = 0;
    static int infantCnt = 0;
    static int adultCntInt = 0;
    static int childCntInt = 0;
    static int infantCntInt = 0;
    static string transId = "";
   // DataSet objDataSet;
    
    #endregion

    #region AdminDashBoard
    protected void Page_Load(object sender, EventArgs e)
     {




         objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
         objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
         objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
         objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
         objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
         objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        //if (!IsPostBack)
        //{
        //  BindRemainders();
        //   BindNotices();
        //}
        try
        {
            kesineniDetails = new KesineniDetails();
            kesineniDetails.LoginId = KesineniConstants.LoginId;
            kesineniDetails.PassWord = KesineniConstants.Password;

            abhiBusDetails = new AbhiBusDetails();
            abhiBusDetails.Url = AbhiBusConstants.URL;

            bitlaDetails = new BitlaDetails();
            bitlaDetails.ApiKey = BitlaConstants.API_KEY;
            bitlaDetails.Url = BitlaConstants.URL;

            objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);
            this.Page.Title = "LoveJourney - Bus - Search";

            if (!IsPostBack)
            {

                Panel pnl = (Panel)this.Master.FindControl("pnl");
                pnl.Visible = false;

                pnlAdminDomesticFlights.Visible = false;
                BindRemainders();
                // BindNotices();
                 adminPanelBuses.Visible = false;
               // CheckPermission("Book Ticket", Session["Role"].ToString());
                 pnlAdminHotels.Visible = false;
                 #region DomesticFlights
                // CheckPermission("Domestic Availability", Session["Role"].ToString());
                 //  GetIntFlightsAvailability();
                 gdvFlights.Visible = true;
                 round.Visible = false;
#endregion

                 #region BusesSearch

                 objDataSet = null;
                if (objDataSet == null)
                {
                    objBAL = new ClsBAL();
                    objDataSet = objBAL.GetSourcess();
                }
                if (objDataSet != null)
                {
                    if (objDataSet.Tables.Count > 0)
                    {
                        if (objDataSet.Tables[0].Rows.Count > 0)
                        {
                            ddlSources.DataSource = objDataSet.Tables[0];
                            ddlSources.DataTextField = "SourceName";
                            ddlSources.DataValueField = "ID";
                            ddlSources.DataBind();
                            ddlSources.Items.Insert(0, "----------");
                            ddlDestinations.Items.Clear();
                            ddlDestinations.Items.Insert(0, "----------");
                        }
                    }
                }
                ddlSources.SelectedValue = ddlSources.Items.FindByText("Hyderabad").Value;
                ddlSources_SelectedIndexChanged(sender, e);
                ddlDestinations.SelectedValue = ddlDestinations.Items.FindByText("Bangalore").Value;

                Session["DOJ"] = txtFromDate.Text.ToString();
                Session["From"] = ddlSources.SelectedItem.Text.ToString();
                Session["To"] = ddlDestinations.SelectedItem.Text.ToString();
                 #endregion

            }
        }
        catch (Exception)
        {
            throw;
        }
       

    }
    protected void btnAdminQuery_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AdminQueries.aspx?Flag=NewMsgs");
    }
    protected void btnGroupQuery_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminQueries.aspx?Flag=NewMsgs");
    }
    private void BindRemainders()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetAdminRemainder;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvRemainders.DataSource = objDataSet.Tables[0];
                    gvRemainders.DataBind();

                    
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    //private void BindNotices()
    //{
    //    try
    //    {
    //        objBal = new Class1();
    //        objDataSet = new DataSet();

    //        objBal.ScreenInd = Master123.GetAdminNotice;
    //        objDataSet = (DataSet)objBal.fnGetData();
    //        if (objDataSet.Tables[0] != null)
    //        {
    //            if (objDataSet.Tables[0].Rows.Count > 0)
    //            {


    //                //gvRemainders.Visible = false;
    //                gvNotices.DataSource = objDataSet.Tables[0];
    //                gvNotices.DataBind();

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //private void BindNotices()
    //{
    //    try
    //    {
    //        objBal = new Class1();
    //        objDataSet = new DataSet();

    //        objBal.ScreenInd = Master123.GetNotices;
    //        objDataSet = (DataSet)objBal.fnGetData();
    //        if (objDataSet.Tables[0] != null)
    //        {
    //            if (objDataSet.Tables[0].Rows.Count > 0)
    //            {


    //                //gvRemainders.Visible = false;
    //                gvNotices.DataSource = objDataSet.Tables[0];
    //                gvNotices.DataBind();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }


    //}

    protected void lbtnNoticeMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminNotices.aspx");
    }
    protected void lbtnRemainder_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminRemainders.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoardPrint.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoardCancel.aspx");
    }
    protected void btnCheckFlightStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminBookingStatus.aspx");
    }
    protected void btnCheckCancelStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminCancelStatus.aspx");
    }
    protected void btnHotelsGo_Click(object sender, EventArgs e)
    {
        //pnlAdminHotels.Visible = true;
        //pnlAdminDashBoard.Visible = false;


        Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false);
    }

    protected void btnInternationalGo_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Users/Flight/frmInternationalAvailablity.aspx", false);

    }

    protected void lbtnMarkup_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminMarkUp.aspx");
    }
    protected void btnAccountManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminMarkUp.aspx");
    }
    protected void btnDomesticFlightsGo_Click(object sender, EventArgs e)
    {
        //pnlAdminDomesticFlights.Visible = true;
        //pnlAdminDashBoard.Visible = false;

        Response.Redirect("~/Users/Flight/frmDomesticAvailability.aspx", false);

    }
    #endregion


    #region Buses
    protected void btnBusesGo_Click(object sender, EventArgs e)
    {
        //adminPanelBuses.Visible = true;
        //pnlAdminDashBoard.Visible = false;

        Response.Redirect("~/Users/Bus/Bus_Search.aspx", false);

    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlBook.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlBook.Visible = false;

                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                objDataSet = (DataSet)objBAL.GetPerByUser();
                if (objDataSet != null)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserPermissions"] = objDataSet.Tables[0];
                        ViewState["Book"] = objDataSet.Tables[0].Rows[0]["Book"].ToString();
                    }
                    else { ViewState["UserPermissions"] = null; }
                }
                else { ViewState["UserPermissions"] = null; }

                if (ViewState["UserPermissions"] != null)
                {
                    if (ViewState["Book"] != null)
                    {
                        if (ViewState["Book"].ToString() == "1")
                        {
                            pnlBook.Visible = true;
                            tdmsg.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlSources_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDestinations.Items.Clear();
            ddlDestinations.Items.Insert(0, "----------");
            if (ddlSources.SelectedIndex != 0 && ddlSources.SelectedItem.Value != "----------")
            {
                string str = ddlSources.SelectedItem.Value.ToString();
                objBAL = new ClsBAL();
                objDataSet = objBAL.GetDestinations(str);
                if (objDataSet != null)
                {
                    if (objDataSet.Tables.Count > 0)
                    {
                        if (objDataSet.Tables[0].Rows.Count > 0)
                        {
                            Session["sesDTDestinations"] = objDataSet.Tables[0];
                            ddlDestinations.Items.Clear();
                            ddlDestinations.DataSource = objDataSet.Tables[0];
                            ddlDestinations.DataTextField = "DestinationName";
                            ddlDestinations.DataValueField = "ID";
                            ddlDestinations.DataBind();
                            ddlDestinations.Items.Insert(0, "----------");
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
         try
        {
            lblMsg.Text = ""; string ssreturn = "";
            if (Convert.ToDateTime(txtFromDate.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Travel Date should not be less than Current Date." + "');</script>", false);
                lblMsg.Text = "Travel Date should not be less than Current Date.";
                return;
            }
            if (rbtnRoundTrip.Checked)
            {
                if (Convert.ToDateTime(txtReturnDate.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Return Journey Date should not be less than Current Date." + "');</script>", false);
                    lblMsg.Text = "Return Journey Date should not be less than Current Date.";
                    return;
                }
                if (Convert.ToDateTime(txtReturnDate.Text.ToString()) > Convert.ToDateTime(txtReturnDate.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Return Journey Date should  be greater than Onward Journey Date." + "');</script>", false);
                    lblMsg.Text = "Return Journey Date should  be greater than Onward Journey Date.";
                    return;
                }
                CultureInfo culturereturn = new CultureInfo("pt-BR");
                string datereturn = Convert.ToDateTime(txtReturnDate.Text, culturereturn).ToString();
                DateTime dtreturn = Convert.ToDateTime(txtReturnDate.Text, culturereturn);
                ssreturn = dtreturn.ToString("dd-MMMM-yyyy");
            }
            CultureInfo culture = new CultureInfo("pt-BR");
            string date = Convert.ToDateTime(txtFromDate.Text, culture).ToString();
            DateTime dt = Convert.ToDateTime(txtFromDate.Text, culture);
            string ss = dt.ToString("dd-MMMM-yyyy");

            BaseClass basecls = new BaseClass();
            basecls.preLoadParams[0] = ddlSources.SelectedItem.Value.ToString();
            basecls.preLoadParams[1] = ddlDestinations.SelectedItem.Value.ToString();
            basecls.preLoadParams[2] = ss;
            basecls.preLoadParams[3] = ssreturn;
            basecls.preLoadParams[4] = ddlSources.SelectedItem.Text.ToString();
            basecls.preLoadParams[5] = ddlDestinations.SelectedItem.Text.ToString();
            basecls.preLoadParams[6] = rbtnOneWay.Checked ? "OneWay" : "RoundTrip";

            HttpContext.Current.Session["Parameters"] = basecls;

            if (basecls.preLoadParams[6].ToString() == "RoundTrip")
            {
                if (Convert.ToDateTime(txtFromDate.Text.ToString()) >= Convert.ToDateTime(txtReturnDate.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "ReturnDate should be greater than TravelingDate." + "');</script>", false);
                    lblMsg.Text = "ReturnDate should be greater than TravelingDate.";
                    return;
                }
            }
            Response.Redirect("~/Users/Bus/Show_Trips.aspx", false);
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void rbtnOneWay_CheckedChanged(object sender, EventArgs e)
    {
        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = false;
        txtReturnDate.Attributes.Remove("class");
        RequiredReturn.Visible = false; txtReturnDate.Text = ""; lblMsg.Text = "";
    }
    protected void rbtnRoundTrip_CheckedChanged(object sender, EventArgs e)
    {
        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = true;
        RequiredReturn.Visible = true; lblMsg.Text = "";
        txtReturnDate.Attributes.Add("class", "datepicker");
    }
    void BitlaDestinations()
    {
        try
        {
            BitlaAPILayer o = new BitlaAPILayer();
            o.ApiKey = BitlaConstants.API_KEY;
            o.URL = BitlaConstants.URL;
            DataSet dB = o.GetDestinationPairs();

            DataTable dtOrigin = dB.Tables["origin"];
            DataTable dtDestination = dB.Tables["destination"];

            objBAL = new ClsBAL();
            foreach (DataRow dataRow1 in dtOrigin.Rows)
            {
                DataRow[] drArray2 = dtDestination.Select("destination_pair_Id = '" + dataRow1["destination_pair_Id"].ToString() + "'");
                foreach (DataRow dataRow2 in drArray2)
                {
                    objBAL.AddBitlaDestinations(dataRow2["id"].ToString(), dataRow2["name"].ToString(),
                        dataRow1["id"].ToString());
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void BitlaCities()
    {
        try
        {
            BitlaAPILayer o = new BitlaAPILayer();
            o.ApiKey = BitlaConstants.API_KEY;
            o.URL = BitlaConstants.URL;
            DataSet dB = o.GetCities();
            objBAL = new ClsBAL();
            foreach (DataRow item in dB.Tables[0].Rows)
            {
                objBAL.AddBitlaCities(item["id"].ToString(), item["name"].ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void Sources(DataTable dtSources)
    {
        try
        {
            objBAL = new ClsBAL();
            DataView dv = new DataView(dtSources);
            DataRow[] dr = dtSources.Select("SourceName IN ('AHMEDABAD','BANGALORE','CHENNAI','COIMBATORE','DELHI','GOA','HYDERABAD','MUMBAI','PUNE')");
            foreach (DataRow item1 in dr)
            {
                objBAL.ticketId = item1["AllIds"].ToString();
                objBAL.name = item1["SourceName"].ToString();
                objBAL.AddSources();
            }
            if (dr.Length != 0)
            {
                objBAL.ticketId = "----------";
                objBAL.name = "----------";
                objBAL.AddSources();
            }
            foreach (DataRow item2 in dtSources.Rows)
            {
                objBAL.ticketId = item2["AllIds"].ToString();
                objBAL.name = item2["SourceName"].ToString();
                objBAL.AddSources();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void DestinationsBySource(string sourceId, DataTable dtDestinations)
    {
        try
        {
            objBAL = new ClsBAL();
            DataView dv = new DataView(dtDestinations);
            DataRow[] dr = dtDestinations.Select("DestinationName IN ('AHMEDABAD','BANGALORE','CHENNAI','COIMBATORE','DELHI','GOA','HYDERABAD','MUMBAI','PUNE')");
            foreach (DataRow item1 in dr)
            {
                objBAL.AddDestinations(item1["AllIds"].ToString(), item1["DestinationName"].ToString(), sourceId);
            }
            foreach (DataRow item in dtDestinations.Rows)
            {
                objBAL.AddDestinations(item["AllIds"].ToString(), item["DestinationName"].ToString(), sourceId);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    #region Hotels
    protected void btnSearch1_Click1(object sender, EventArgs e)
    {
        try
        {
            Session["SearchParams"] = hdnValues.Value;
            Response.Redirect("~/Users/Hotel/Hotels.aspx", false);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }

    }

    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    public static string ConvertDate1(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
   

    #endregion
    #region DomesticFlights
    //protected void CheckPermission(string pageName, string role)
    //{
    //    try
    //    {
    //        panelBookingStatus.Visible = true;
    //        tdmsg.Visible = false;
    //        if (role == "CSE")
    //        {
    //            tdmsg.Visible = true;
    //            tdmsg.Style.Add("background-color:#E77471;", "");
    //            lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
    //            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
    //            panelBookingStatus.Visible = false;

    //            objBAL = new ClsBAL();
    //            objBAL.ID = Convert.ToInt32(Session["UserID"]);
    //            objBAL.screenName = pageName;
    //            objDataSet = (DataSet)objBAL.GetPerByUser();
    //            if (objDataSet != null)
    //            {
    //                if (objDataSet.Tables[0].Rows.Count > 0)
    //                {
    //                    ViewState["UserPermissions"] = objDataSet.Tables[0];
    //                    ViewState["Book"] = objDataSet.Tables[0].Rows[0]["Book"].ToString();
    //                }
    //                else { ViewState["UserPermissions"] = null; }
    //            }
    //            else { ViewState["UserPermissions"] = null; }

    //            if (ViewState["UserPermissions"] != null)
    //            {
    //                if (ViewState["Book"] != null)
    //                {
    //                    if (ViewState["Book"].ToString() == "1")
    //                    {
    //                        panelBookingStatus.Visible = true;
    //                        tdmsg.Visible = false;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    private void GetFlights()
    {
        try
        {
            infantCnt = Convert.ToInt32(ddlInfant.SelectedValue);
            childCnt = Convert.ToInt32(ddlChild.SelectedValue);
            adultcnt = Convert.ToInt32(ddlAdult.SelectedValue);
            string mode = (rbtnOneWay.Checked) ? "ONE" : "ROUND";
            string returnDate = (rbtnOneWay.Checked) ? txtFromDate.Text : txtReturnDate.Text;
            String xmlRequestData = "<Request><Origin>" + ddlSources.SelectedValue + "</Origin><Destination>" + ddlDestinations.SelectedValue + "</Destination><DepartDate>" + txtFromDate.Text + "</DepartDate>" +
       "<ReturnDate>" + returnDate + "</ReturnDate>" +
       "<AdultPax>" + ddlAdult.SelectedValue + "</AdultPax>" +
       "<ChildPax>" + ddlChild.SelectedValue + "</ChildPax>" +
       "<InfantPax>" + ddlInfant.SelectedValue + "</InfantPax>" +
       "<Currency>INR</Currency>" +
       "<Clientid>77743504</Clientid>" +
       "<Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword>" +
       "<Clienttype>ArzooFWS1.1</Clienttype>" +
           "<Preferredclass>" + ddlCabin_type.SelectedValue + "</Preferredclass>" +
       "<mode>" + mode + "</mode>" +
           "<PreferredAirline>AI,G8,IC,6E,9W,S2,IT,9H,I7,SG</PreferredAirline>" +
       "</Request>";
            //dsFilghts = new DataSet();
            //dsFilghts.ReadXml("C:\\Users\\ravikanth\\Desktop\\XML_Response1.xml");
            dsFilghts = objFlights.GetAvailability(xmlRequestData);
            Session["dsIntFlights"] = dsFilghts;
            lnkModifySearch.Visible = true;
            gdvFlights.Visible = true;
            trFilterSearch.Visible = true;
            tblSearch.Visible = false;
            DataTable dtresponse = dsFilghts.Tables[0];
            if (mode == "ONE")
            {
                if (dtresponse.Columns.Count != 4)
                {
                    if (dtresponse.Rows[0][1] == "")
                    {
                        DataTable dtFlightsSegment = dsFilghts.Tables[9];


                        gdvFlights.DataSource = Session["dtFights"] = dtFlightsSegment;
                        gdvFlights.DataBind();
                    }
                    else
                    {
                        mp3.Show();
                        lblerror.Text = dtresponse.Rows[0][1].ToString();
                    }

                }
                else
                {
                    mp3.Show();
                    lblerror.Text = dtresponse.Rows[0][3].ToString();

                }

            }
            else
            {
                if (dtresponse.Columns.Count != 4)
                {
                    if (dtresponse.Rows[0][1] == "")
                    {
                        lblOnwardDepartureAirportCode.Text = lblReturnArrivalAirportCode.Text = ddlSources.SelectedValue;
                        lblOnwardArrivalAirportCode.Text = lblReturnDepartureAirportCode.Text = ddlDestinations.SelectedValue;
                        lblOnwardTO.Visible = lblReturnTO.Visible = true;
                        RoundtripMethod();
                    }
                    else
                    {
                        mp3.Show();
                        lblerror.Text = dtresponse.Rows[0][1].ToString();
                    }
                }
                else
                {
                    mp3.Show();
                    lblerror.Text = dtresponse.Rows[0][3].ToString();

                }


            }

        }
        catch (Exception ex)
        {

        }
    }

    private void RoundtripMethod()
    {
        trroundTrip.Visible = true;
        string responseDepartId = string.Empty;
        string responseReturnId = string.Empty;
        string OriginDestinationOptionsId = string.Empty;
        // For Onward Flights
        string ArzooResponseId = dsFilghts.Tables[0].Rows[0]["arzoo__response_Id"].ToString();

        #region Departure
        DataTable dtResponse_Depart = dsFilghts.Tables["Response__Depart"];
        if (dtResponse_Depart.Rows.Count > 0)
        {
            DataRow[] row = dtResponse_Depart.Select("arzoo__response_Id=" + ArzooResponseId);
            responseDepartId = row[0]["Response__Depart_Id"].ToString();
        }


        DataTable dtOriginDestinationOptions = dsFilghts.Tables["OriginDestinationOptions"];
        if (dtOriginDestinationOptions.Rows.Count > 0)
        {
            DataRow[] row = dtOriginDestinationOptions.Select("Response__Depart_Id=" + responseDepartId);
            OriginDestinationOptionsId = row[0]["OriginDestinationOptions_Id"].ToString();

        }
        DataTable dtOriginDestinationOption = dsFilghts.Tables["OriginDestinationOption"];
        DataTable dtFlightSegments = dsFilghts.Tables["FlightSegments"];
        DataTable dtNewFlightSegments = dtFlightSegments.Clone();
        if (dtOriginDestinationOption.Rows.Count > 0)
        {
            DataRow[] row = dtOriginDestinationOption.Select("OriginDestinationOptions_Id=" + OriginDestinationOptionsId);
            for (int i = 0; i < row.Length; i++)
            {
                DataRow[] rowFlightSegments = dtFlightSegments.Select("OriginDestinationOption_Id=" + row[i]["OriginDestinationOption_Id"].ToString());
                foreach (DataRow dr in rowFlightSegments)
                {
                    dtNewFlightSegments.ImportRow(dr);
                }
            }
        }
        DataTable dtFlightSegment = dsFilghts.Tables["FlightSegment"];
        DataTable dtNewFlightSegment = dtFlightSegment.Clone();
        if (dtNewFlightSegments.Rows.Count > 0)
        {
            for (int i = 0; i < dtNewFlightSegments.Rows.Count; i++)
            {
                DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + dtNewFlightSegments.Rows[i]["FlightSegments_Id"].ToString());
                foreach (DataRow dr in rowFlightSegment)
                {
                    dtNewFlightSegment.ImportRow(dr);
                }
            }
        }

        gdvOnward.DataSource = Session["DtOnWardFlights"] = dtNewFlightSegment;
        gdvOnward.DataBind();

        #endregion

        #region Return

        DataTable dtResponse_Return = dsFilghts.Tables["Response__Return"];
        if (dtResponse_Return.Rows.Count > 0)
        {
            DataRow[] row = dtResponse_Return.Select("arzoo__response_Id=" + ArzooResponseId);
            responseReturnId = row[0]["Response__Return_Id"].ToString();
        }

        string OriginDestinationOptionsIdRet = string.Empty;
        DataTable dtOriginDestinationOptionsRet = dsFilghts.Tables["OriginDestinationOptions"];
        if (dtOriginDestinationOptionsRet.Rows.Count > 0)
        {
            DataRow[] row = dtOriginDestinationOptionsRet.Select("Response__Return_Id=" + responseReturnId);
            OriginDestinationOptionsIdRet = row[0]["OriginDestinationOptions_Id"].ToString();

        }
        DataTable dtOriginDestinationOptionRet = dsFilghts.Tables["OriginDestinationOption"];
        DataTable dtFlightSegmentsRet = dsFilghts.Tables["FlightSegments"];
        DataTable dtNewFlightSegmentsRet = dtFlightSegmentsRet.Clone();
        if (dtOriginDestinationOptionRet.Rows.Count > 0)
        {
            DataRow[] row = dtOriginDestinationOptionRet.Select("OriginDestinationOptions_Id=" + OriginDestinationOptionsIdRet);
            for (int i = 0; i < row.Length; i++)
            {
                DataRow[] rowFlightSegments = dtFlightSegmentsRet.Select("OriginDestinationOption_Id=" + row[i]["OriginDestinationOption_Id"].ToString());
                foreach (DataRow dr in rowFlightSegments)
                {
                    dtNewFlightSegmentsRet.ImportRow(dr);
                }
            }
        }
        DataTable dtFlightSegmentRet = dsFilghts.Tables["FlightSegment"];
        DataTable dtNewFlightSegmentRet = dtFlightSegment.Clone();
        if (dtNewFlightSegmentsRet.Rows.Count > 0)
        {
            for (int i = 0; i < dtNewFlightSegmentsRet.Rows.Count; i++)
            {
                DataRow[] rowFlightSegmentRet = dtFlightSegmentRet.Select("FlightSegments_Id=" + dtNewFlightSegmentsRet.Rows[i]["FlightSegments_Id"].ToString());
                foreach (DataRow dr in rowFlightSegmentRet)
                {
                    dtNewFlightSegmentRet.ImportRow(dr);
                }
            }
        }

        gdvReturn.DataSource = Session["DtReturnFlights"] = dtNewFlightSegmentRet;
        gdvReturn.DataBind();
        #endregion

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void DrbtnOneWay_CheckedChanged(object sender, EventArgs e)
    {

        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = false;
        txtReturnDate.Attributes.Remove("class");
        RequiredReturn.Visible = false; txtReturnDate.Text = ""; lblMsg.Text = "";
        txtretundatesearch.Enabled = false;
        txtretundatesearch.Attributes.Remove("class");
        Oneway.Visible = true;

        round.Visible = false;
        Returnway.Visible = false;
        Returnwayfare.Visible = false;
        rbonesearch.Checked = true;
        rbreturnsearch.Checked = false;
        printroundtrip.Visible = false;

    }
    protected void DrbtnRoundTrip_CheckedChanged(object sender, EventArgs e)
    {
        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = true;
        txtReturnDate.Attributes.Add("class", "datepicker");
        RequiredReturn.Visible = true; lblMsg.Text = "";
        txtretundatesearch.Enabled = true;
        txtretundatesearch.Attributes.Add("class", "datepicker");

        Oneway.Visible = false;
        trroundTrip.Visible = true;
        round.Visible = true;
        Returnway.Visible = true;
        Returnwayfare.Visible = true;
        rbonesearch.Checked = false;
        rbreturnsearch.Checked = true;
        modifyfilter.Visible = false;
        printroundtrip.Visible = true;
    }
    protected void rbonesearch_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtretundatesearch.Enabled = false;
            txtretundatesearch.Attributes.Remove("class");
            Oneway.Visible = true;
            trroundTrip.Visible = false;
            round.Visible = true;
            Returnway.Visible = false;
            Returnwayfare.Visible = false;
            gdvFlights.Visible = true;
            modifyfilter.Visible = false;
            printroundtrip.Visible = false;


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void rbreturnsearch_CheckedChanged(object sender, EventArgs e)
    {

        txtretundatesearch.Enabled = true;
        txtretundatesearch.Attributes.Add("class", "datepicker");
        Oneway.Visible = false;
        trroundTrip.Visible = true;
        round.Visible = true;
        Returnway.Visible = true;
        Returnwayfare.Visible = true;
        //gdvFlights.Visible = false;
        printroundtrip.Visible = true;


    }



    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            GetFlights();
            lnkModifySearch.Visible = true;
            modifyfilter.Visible = true;
            string[] strfrom = new string[2];
            strfrom = Session["From"].ToString().Split(',');
            string[] strto = new string[2];
            strto = Session["To"].ToString().Split(',');
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
            Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();
        }
        catch (Exception ex)
        {

        }
    }


    protected void gdvFlights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string FlightSegmentsID = string.Empty;
        string originDestination_Id = string.Empty;
        string fareDetailsId = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
            Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
            Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
            Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
            Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");

            DataTable dtFlightsSegment = dsFilghts.Tables[9];
            if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
            {
                if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                {
                    lblConnectingAirportCode.Visible = true;
                    lblHyphen.Visible = true;
                    lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                    lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                    lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                    lblConnectingFlights.Visible = true;
                }
                else
                {
                    lblConnectingAirportCode.Visible = false;
                    lblHyphen.Visible = false;
                    lblConnectingFlights.Visible = false;
                }
            }
            if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
            {
                e.Row.Visible = false;
            }

            Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
            DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
            string time = dtDepart.ToShortTimeString();
            lblDepartTime.Text = time.ToString();

            Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
            DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
            string Arrtime = dtArrive.ToShortTimeString();
            lblArrivalTime.Text = Arrtime.ToString();

            LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
            int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

            DataTable dtBookingFareRules = dsFilghts.Tables[11];
            if (dtBookingFareRules.Rows.Count > 0)
            {
                DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                lblFareRules.Text = row[0]["Rule"].ToString();
            }


            if (dtFlightsSegment.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + FlightSegmentId);
                FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
            }

            DataTable dtFlightSegments = dsFilghts.Tables[8];
            if (dtFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
            }
            DataTable dtFareDetails = dsFilghts.Tables[5];
            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }
            DataTable dtChargeableFares = dsFilghts.Tables[6];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                Label lblTax = (Label)e.Row.FindControl("lblTax");
                Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblFare = (Label)e.Row.FindControl("lblFare");


                lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");

                double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblSCharge.Text) - Convert.ToDouble(lblTDiscount.Text);
                lblTotal.Text = lblFare.Text = total.ToString("####0.00");



            }

            DataTable dtactivedetails = dsFilghts.Tables[1];
            Label lbladultone = (Label)e.Row.FindControl("lbladultone");
            Label lblchildone = (Label)e.Row.FindControl("lblchildone");
            Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
            Label lblTripone = (Label)e.Row.FindControl("lblTripone");
            lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
            lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
            lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
            lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();

        }


    }
    protected void gdvFlights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BoolTicket")
        {

            lblFlightSegmentId1.Text = e.CommandArgument.ToString();

            Control ctl = e.CommandSource as Control;
            GridViewRow row1 = ctl.NamingContainer as GridViewRow;
            Label lblarrivaldate = (Label)row1.FindControl("lblarrivaldate");
            Label lbldepartdate = (Label)row1.FindControl("lbldepartdate");
            Label lblOperatingAirlineName = (Label)row1.FindControl("lblAirlineName");
            Label lblOperatingAirlineFlightNumber = (Label)row1.FindControl("lblFlightNumber");
            Label lblDestinations = (Label)row1.FindControl("lblDestinations");
            Label lblarrtime = (Label)row1.FindControl("lblArrivalTime");
            Label lbldeptime = (Label)row1.FindControl("lblDepartTime");
            Label lblTax = (Label)row1.FindControl("lblTax");
            Label lblSTax = (Label)row1.FindControl("lblSTax");
            Label lblSCharge = (Label)row1.FindControl("lblSCharge");
            Label lblTDiscount = (Label)row1.FindControl("lblTDiscount");
            Label lblTotal = (Label)row1.FindControl("lblTotal");
            Label lblBaseFare = (Label)row1.FindControl("lblBaseFare");

            lblairline.Text = lblOperatingAirlineName.Text;
            lblflightno.Text = lblOperatingAirlineFlightNumber.Text;
            lbldepart.Text = lbldepartdate.Text;
            lblarrives.Text = lblarrivaldate.Text;
            lblarrivetime.Text = lblarrtime.Text;
            lbldeparttime.Text = lbldeptime.Text;

            string[] strfrom = new string[2];
            strfrom = Session["From"].ToString().Split(',');
            string[] strto = new string[2];
            strto = Session["To"].ToString().Split(',');
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
            lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();

            lblairporttax.Text = lblTax.Text;
            lblServiceTaxthree.Text = lblSTax.Text;
            lblServiceCharge.Text = lblSCharge.Text;
            lblTotalDiscount.Text = lblTDiscount.Text;
            lblTotalAmt.Text = lblTotal.Text;
            lblActualFare.Text = lblBaseFare.Text;


            Label lbladultone = (Label)row1.FindControl("lbladultone");
            Label lblchildone = (Label)row1.FindControl("lblchildone");
            Label lblinfantone = (Label)row1.FindControl("lblinfantone");
            Label lblTripone = (Label)row1.FindControl("lblTripone");
            lbladult.Text = lbladultone.Text;
            lblchild.Text = lblchildone.Text;
            lblinfant.Text = lblinfantone.Text;
            lblTrip.Text = lblTripone.Text;
        }
    }
    protected void rbnAirline_CheckedChanged(object sender, EventArgs e)
    {
        tblAirlineDet.Visible = true;
        RadioButton rbnAirline = (RadioButton)sender;
        GridViewRow gdvFlightsrow = (GridViewRow)rbnAirline.NamingContainer;
        Image imggrid = (Image)gdvFlightsrow.FindControl("img");
        Label lblAirlineName = (Label)gdvFlightsrow.FindControl("lblAirlineName");
        Label lblFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
        Label lblDepartTime = (Label)gdvFlightsrow.FindControl("lblDepartTime");
        Label lblArrivalTime = (Label)gdvFlightsrow.FindControl("lblArrivalTime");
        Label lblFare = (Label)gdvFlightsrow.FindControl("lblFare");
        Label lblTotal = (Label)gdvFlightsrow.FindControl("lblTotal");
        LinkButton lnkFareRule = (LinkButton)gdvFlightsrow.FindControl("lnkFareRule");

        Label lblBaseFare = (Label)gdvFlightsrow.FindControl("lblBaseFare");
        Label lblTax = (Label)gdvFlightsrow.FindControl("lblTax");
        Label lblSTax = (Label)gdvFlightsrow.FindControl("lblSTax");
        Label lblSCharge = (Label)gdvFlightsrow.FindControl("lblSCharge");
        Label lblTDiscount = (Label)gdvFlightsrow.FindControl("lblTDiscount");


        img.ImageUrl = imggrid.ImageUrl;
        lblAirlineName1.Text = lblAirlineName.Text;
        lblFlightNumber1.Text = lblFlightNumber.Text;
        lblDepartTime1.Text = lblDepartTime.Text;
        lblArrivalTime1.Text = lblArrivalTime.Text;
        lblOrigin1.Text = ddlSources.SelectedValue.ToString();
        lblDestination1.Text = ddlDestinations.SelectedValue.ToString();
        lblTravelDate.Text = txtFromDate.Text;
        lblTotalFare1.Text = lblTotal1.Text = lblTotal.Text;



        lblBaseFare1.Text = lblBaseFare.Text;
        lblTax1.Text = lblTax.Text;
        lblSTax1.Text = lblSTax.Text;
        lblSCharge1.Text = lblSCharge.Text;
        lblTDiscount1.Text = lblTDiscount.Text;
        lblFlightSegmentId1.Text = lnkFareRule.CommandArgument.ToString();

    }
    protected void rbnAirlineonward_CheckedChanged(object sender, EventArgs e)
    {

        tblOnwardFlightDet.Visible = true;

        RadioButton rbnAirline = (RadioButton)sender;
        GridViewRow gdvFlightsrow = (GridViewRow)rbnAirline.NamingContainer;
        Image imggrid = (Image)gdvFlightsrow.FindControl("img");
        Label lblAirlineName = (Label)gdvFlightsrow.FindControl("lblAirlineName");
        Label lblFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
        Label lblDepartTime = (Label)gdvFlightsrow.FindControl("lblDepartTime");
        Label lblArrivalTime = (Label)gdvFlightsrow.FindControl("lblArrivalTime");
        Label lblFare = (Label)gdvFlightsrow.FindControl("lblFare");
        Label lblTotal = (Label)gdvFlightsrow.FindControl("lblTotal");
        LinkButton lnkFareRule = (LinkButton)gdvFlightsrow.FindControl("lnkFareRule");

        Label lblBaseFare = (Label)gdvFlightsrow.FindControl("lblBaseFare");
        Label lblTax = (Label)gdvFlightsrow.FindControl("lblTax");
        Label lblSTax = (Label)gdvFlightsrow.FindControl("lblSTax");
        Label lblSCharge = (Label)gdvFlightsrow.FindControl("lblSCharge");
        Label lblTDiscount = (Label)gdvFlightsrow.FindControl("lblTDiscount");


        imgOnwardFlight.ImageUrl = imggrid.ImageUrl;
        lblOnwardAirline.Text = lblAirlineName.Text;
        lblOnwardFlightNum.Text = lblFlightNumber.Text;
        lblOnwardDeparts.Text = lblDepartTime.Text;
        lblOnwardArrives.Text = lblArrivalTime.Text;
        lblOnwardOrigin.Text = ddlSources.SelectedValue.ToString();
        lblonwardDestination.Text = ddlDestinations.SelectedValue.ToString();
        lblOnwardTravelDate.Text = txtFromDate.Text;
        lblOnwardTotalFare.Text = lblOnwardTotal.Text = lblTotal.Text;
        lblTotalFare.Visible = true;

        if (lblReturnTotal.Text != "" && lblOnwardTotal.Text != "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblOnwardTotal.Text) + Convert.ToDouble(lblReturnTotal.Text)).ToString();
        }
        else if (lblReturnTotal.Text == "" && lblOnwardTotal.Text != "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblOnwardTotal.Text)).ToString();
        }
        else if (lblReturnTotal.Text != "" && lblOnwardTotal.Text == "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblReturnTotal.Text)).ToString();
        }


        lblOnwardBaseFare.Text = lblBaseFare.Text;
        lblOnwardAirportTax.Text = lblTax.Text;
        lblOnwardServiceTax.Text = lblSTax.Text;
        lblOnwardScharge.Text = lblSCharge.Text;
        lblOnwardDiscount.Text = lblTDiscount.Text;
        lblonwardFlightSegmentId.Text = lnkFareRule.CommandArgument.ToString();
        btnRoundTripBook.Visible = true;



        //ravi

        Label lblarrivaldate = (Label)gdvFlightsrow.FindControl("lblarrivaldate");
        Label lbldepartdate = (Label)gdvFlightsrow.FindControl("lbldepartdate");
        Label lblOperatingAirlineName = (Label)gdvFlightsrow.FindControl("lblAirlineName");
        Label lblOperatingAirlineFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
        Label lblDestinations = (Label)gdvFlightsrow.FindControl("lblDestinations");
        Label lblarrtime = (Label)gdvFlightsrow.FindControl("lblArrivalTime");
        Label lbldeptime = (Label)gdvFlightsrow.FindControl("lblDepartTime");
        Label lblTax1 = (Label)gdvFlightsrow.FindControl("lblTax");
        Label lblSTax1 = (Label)gdvFlightsrow.FindControl("lblSTax");
        Label lblSCharge1 = (Label)gdvFlightsrow.FindControl("lblSCharge");
        Label lblTDiscount1 = (Label)gdvFlightsrow.FindControl("lblTDiscount");
        Label lblTotal1 = (Label)gdvFlightsrow.FindControl("lblTotal");
        Label lblBaseFare1 = (Label)gdvFlightsrow.FindControl("lblBaseFare");

        lblairline.Text = lblOperatingAirlineName.Text;
        lblflightno.Text = lblOperatingAirlineFlightNumber.Text;
        lbldepart.Text = lbldepartdate.Text;
        lblarrives.Text = lblarrivaldate.Text;
        lblarrivetime.Text = lblarrtime.Text;
        lbldeparttime.Text = lbldeptime.Text;

        string[] strfrom = new string[2];
        strfrom = Session["From"].ToString().Split(',');
        string[] strto = new string[2];
        strto = Session["To"].ToString().Split(',');
        lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
        lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();

        lblairporttax.Text = lblTax1.Text;
        lblServiceTaxthree.Text = lblSTax1.Text;
        lblServiceCharge.Text = lblSCharge1.Text;
        lblTotalDiscount.Text = lblTDiscount1.Text;
        lblTotalAmt.Text = lblTotal1.Text;
        lblActualFare.Text = lblBaseFare1.Text;


        Label lbladultone = (Label)gdvFlightsrow.FindControl("lbladultone");
        Label lblchildone = (Label)gdvFlightsrow.FindControl("lblchildone");
        Label lblinfantone = (Label)gdvFlightsrow.FindControl("lblinfantone");
        Label lblTripone = (Label)gdvFlightsrow.FindControl("lblTripone");
        lbladult.Text = lbladultone.Text;
        lblchild.Text = lblchildone.Text;
        lblinfant.Text = lblinfantone.Text;
        lblTrip.Text = lblTripone.Text;



        foreach (GridViewRow oldrow in gdvOnward.Rows)
        {
            ((RadioButton)oldrow.FindControl("rbnAirline")).Checked = false;
        }

        //Set the new selected row
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        ((RadioButton)row.FindControl("rbnAirline")).Checked = true;





    }
    protected void rbnAirlineReturn_CheckedChanged(object sender, EventArgs e)
    {
        tblReturnFlightDet.Visible = true;
        RadioButton rbnAirline = (RadioButton)sender;
        GridViewRow gdvFlightsrow = (GridViewRow)rbnAirline.NamingContainer;
        Image imggrid = (Image)gdvFlightsrow.FindControl("img");
        Label lblAirlineName = (Label)gdvFlightsrow.FindControl("lblAirlineName");
        Label lblFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
        Label lblDepartTime = (Label)gdvFlightsrow.FindControl("lblDepartTime");
        Label lblArrivalTime = (Label)gdvFlightsrow.FindControl("lblArrivalTime");
        Label lblFare = (Label)gdvFlightsrow.FindControl("lblFare");
        Label lblTotal = (Label)gdvFlightsrow.FindControl("lblTotal");
        LinkButton lnkFareRule = (LinkButton)gdvFlightsrow.FindControl("lnkFareRule");

        Label lblBaseFare = (Label)gdvFlightsrow.FindControl("lblBaseFare");
        Label lblTax = (Label)gdvFlightsrow.FindControl("lblTax");
        Label lblSTax = (Label)gdvFlightsrow.FindControl("lblSTax");
        Label lblSCharge = (Label)gdvFlightsrow.FindControl("lblSCharge");
        Label lblTDiscount = (Label)gdvFlightsrow.FindControl("lblTDiscount");


        imgReturn.ImageUrl = imggrid.ImageUrl;
        lblReturnAirline.Text = lblAirlineName.Text;
        lblReturnFlightNum.Text = lblFlightNumber.Text;
        lblReturnDeparts.Text = lblDepartTime.Text;
        lblReturnArrives.Text = lblArrivalTime.Text;
        lblReturnDestination.Text = ddlSources.SelectedValue.ToString();
        lblReturnOrigin.Text = ddlDestinations.SelectedValue.ToString();
        lblReturnTravelDate.Text = txtFromDate.Text;
        lblReturnTotalFare.Text = lblReturnTotal.Text = lblTotal.Text;

        if (lblReturnTotal.Text != "" && lblOnwardTotal.Text != "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblOnwardTotal.Text) + Convert.ToDouble(lblReturnTotal.Text)).ToString();
        }
        else if (lblReturnTotal.Text == "" && lblOnwardTotal.Text != "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblOnwardTotal.Text)).ToString();
        }
        else if (lblReturnTotal.Text != "" && lblOnwardTotal.Text == "")
        {
            lblTotalOnwardReturn.Text = (Convert.ToDouble(lblReturnTotal.Text)).ToString();
        }



        lblReturnBaseFare.Text = lblBaseFare.Text;
        lblReturnAirportTax.Text = lblTax.Text;
        lblReturnServiceTax.Text = lblSTax.Text;
        lblReturnSCharge.Text = lblSCharge.Text;
        lblReturnDiscount.Text = lblTDiscount.Text;
        lblReturnFlightSegment.Text = lnkFareRule.CommandArgument.ToString();
        btnRoundTripBook.Visible = true;



        //ravi

        Label lblarrivaldate = (Label)gdvFlightsrow.FindControl("lblarrivaldate");
        Label lbldepartdate = (Label)gdvFlightsrow.FindControl("lbldepartdate");
        Label lblOperatingAirlineName = (Label)gdvFlightsrow.FindControl("lblAirlineName");
        Label lblOperatingAirlineFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
        Label lblDestinations = (Label)gdvFlightsrow.FindControl("lblDestinations");
        Label lblarrtime = (Label)gdvFlightsrow.FindControl("lblArrivalTime");
        Label lbldeptime = (Label)gdvFlightsrow.FindControl("lblDepartTime");
        Label lblTax1 = (Label)gdvFlightsrow.FindControl("lblTax");
        Label lblSTax1 = (Label)gdvFlightsrow.FindControl("lblSTax");
        Label lblSCharge1 = (Label)gdvFlightsrow.FindControl("lblSCharge");
        Label lblTDiscount1 = (Label)gdvFlightsrow.FindControl("lblTDiscount");
        Label lblTotal1 = (Label)gdvFlightsrow.FindControl("lblTotal");
        Label lblBaseFare1 = (Label)gdvFlightsrow.FindControl("lblBaseFare");

        lblairlinereturn.Text = lblOperatingAirlineName.Text;
        lblflightnoreturn.Text = lblOperatingAirlineFlightNumber.Text;
        lbldepartreturn.Text = lbldepartdate.Text;
        lblarrivesreturn.Text = lblarrivaldate.Text;
        lblarrivetimereturn.Text = lblarrtime.Text;
        lbldeparttimereturn.Text = lbldeptime.Text;

        string[] strfrom = new string[2];
        strfrom = Session["From"].ToString().Split(',');
        string[] strto = new string[2];
        strto = Session["To"].ToString().Split(',');
        lblRouteReturn.Text = strto[0].ToString() + "-" + strfrom[0].ToString();
        lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();

        lblairporttaxreturn.Text = lblTax1.Text;
        lblServiceTaxreturn.Text = lblSTax1.Text;
        lblServiceChargereturn.Text = lblSCharge1.Text;
        lblTotalDiscountreturn.Text = lblTDiscount1.Text;
        lblTotalAmtreturn.Text = lblTotal1.Text;
        lblActualFarereturn.Text = lblBaseFare1.Text;


        Label lbladultone = (Label)gdvFlightsrow.FindControl("lbladultone");
        Label lblchildone = (Label)gdvFlightsrow.FindControl("lblchildone");
        Label lblinfantone = (Label)gdvFlightsrow.FindControl("lblinfantone");
        Label lblTripone = (Label)gdvFlightsrow.FindControl("lblTripone");
        lbladultreturn.Text = lbladultone.Text;
        lblchildreturn.Text = lblchildone.Text;
        lblinfantreturn.Text = lblinfantone.Text;
        lblTripreturn.Text = lblTripone.Text;



        foreach (GridViewRow oldrow in gdvReturn.Rows)
        {
            ((RadioButton)oldrow.FindControl("rbnAirline")).Checked = false;
        }

        //Set the new selected row
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        ((RadioButton)row.FindControl("rbnAirline")).Checked = true;
    }
    protected void btnBookNow_Click(object sender, EventArgs e)
    {
        btnBook.Visible = true;
        btnRoundTripSubmit.Visible = false;

        pnlPassengerDet.Visible = true;
        pnlSearch.Visible = false;


    }
    private void GetSearchFlights()
    {
        try
        {
            Session["From"] = ddlSourcesSearch.SelectedItem.Text;
            Session["TO"] = ddlDestinationsSearch.SelectedItem.Text;
            infantCnt = Convert.ToInt32(ddlinfantsintsearch.SelectedValue);
            childCnt = Convert.ToInt32(ddlchildintsearch.SelectedValue);
            adultcnt = Convert.ToInt32(ddladultsintsearch.SelectedValue);
            string mode = (rbtnOneWay.Checked) ? "ONE" : "ROUND";
            string returnDate = (rbtnOneWay.Checked) ? txtdatesearch.Text : txtretundatesearch.Text;
            String xmlRequestData = "<Request><Origin>" + ddlSourcesSearch.SelectedValue + "</Origin><Destination>" + ddlDestinationsSearch.SelectedValue + "</Destination><DepartDate>" + txtdatesearch.Text + "</DepartDate>" +
       "<ReturnDate>" + returnDate + "</ReturnDate>" +
       "<AdultPax>" + ddladultsintsearch.SelectedValue + "</AdultPax>" +
       "<ChildPax>" + ddlchildintsearch.SelectedValue + "</ChildPax>" +
       "<InfantPax>" + ddlinfantsintsearch.SelectedValue + "</InfantPax>" +
       "<Currency>INR</Currency>" +
       "<Clientid>77743504</Clientid>" +
       "<Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword>" +
       "<Clienttype>ArzooFWS1.1</Clienttype>" +
           "<Preferredclass>" + ddlIntCabinTypesearch.SelectedValue + "</Preferredclass>" +
       "<mode>" + mode + "</mode>" +
           "<PreferredAirline>AI,G8,IC,6E,9W,S2,IT,9H,I7,SG</PreferredAirline>" +
       "</Request>";
            dsFilghts = objFlights.GetAvailability(xmlRequestData);
            Session["dsIntFlights"] = dsFilghts;

            //DataTable dtFlightsSegment = dsFilghts.Tables[9];

            //gdvFlights.DataSource = Session["dtFights"] = dtFlightsSegment;
            //gdvFlights.DataBind();

            lnkModifySearch.Visible = true;
            gdvFlights.Visible = trFilterSearch.Visible = true;
            tblSearch.Visible = false;

            if (mode == "ONE")
            {
                DataTable dtFlightsSegment = dsFilghts.Tables[9];


                gdvFlights.DataSource = Session["dtFights"] = dtFlightsSegment;
                gdvFlights.DataBind();
            }
            else
            {
                lblOnwardDepartureAirportCode.Text = lblReturnArrivalAirportCode.Text = ddlSources.SelectedValue;
                lblOnwardArrivalAirportCode.Text = lblReturnDepartureAirportCode.Text = ddlDestinations.SelectedValue;
                lblOnwardTO.Visible = lblReturnTO.Visible = true;
                RoundtripMethod();


            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnIntBookNow_Click(object sender, EventArgs e)
    {

        // gdvIntFlights.Visible = false;
        // pnlIntPassengerDet.Visible = true;
        pnlSearch.Visible = false;


    }

    private void CreateControls(int adultCnt, int ChildCnt, int infCnt)
    {
        try
        {

            #region DomesticFlights
            for (int i = 1; i <= adultCnt; i++)
            {
                TableRow tr = new TableRow();
                TableCell td1 = new TableCell();
                td1.Text = "Adult" + i;
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(td1);

                TableCell tdSp = new TableCell();
                tdSp.Text = "";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdSp);

                TableCell tdtitle = new TableCell();
                tdtitle.Text = "Title :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdtitle);

                TableCell td2 = new TableCell();
                DropDownList ddlTitle = new DropDownList();
                ddlTitle.ID = "ddlTitle" + i;
                ddlTitle.Items.Add("Mr.");
                ddlTitle.Items.Add("Ms.");
                ddlTitle.Items.Add("Mrs.");
                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.ID = "txtFn" + i;
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell td6 = new TableCell();
                RequiredFieldValidator rfv2 = new RequiredFieldValidator();
                rfv2.ID = "rfv2" + i;
                rfv2.ControlToValidate = "txtFn" + i;
                rfv2.ErrorMessage = "Enter First Name";
                td6.Controls.Add(rfv2);
                tr.Controls.Add(td6);


                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.ID = "txtLn" + i;
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);


                TableCell td5 = new TableCell();
                RequiredFieldValidator rfv1 = new RequiredFieldValidator();
                rfv1.ID = "rfv1" + i;
                rfv1.ControlToValidate = "txtLn" + i;
                rfv1.ErrorMessage = "Enter Last Name";
                td5.Controls.Add(rfv1);
                tr.Controls.Add(td5);




                tblAdults.Controls.Add(tr);
            }

            for (int i = 1; i <= ChildCnt; i++)
            {
                TableRow tr = new TableRow();
                TableCell td1 = new TableCell();
                td1.Text = "Child" + i;
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(td1);

                TableCell tdSp = new TableCell();
                tdSp.Text = "";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdSp);

                TableCell tdtitle = new TableCell();
                tdtitle.Text = "Title :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdtitle);

                TableCell td2 = new TableCell();
                DropDownList ddlTitle = new DropDownList();
                ddlTitle.ID = "ddlCTitle" + i;
                ddlTitle.Items.Add("Mstr.");
                ddlTitle.Items.Add("Miss.");

                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.ID = "txtCFn" + i;
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.ID = "txtCLn" + i;
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);

                TableCell tdBD = new TableCell();
                tdBD.Text = "BirthDate :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdBD);


                TableCell td5 = new TableCell();
                TextBox txtBirthDate = new TextBox();
                txtBirthDate.ID = "txtCBirthDate" + i;
                td5.Controls.Add(txtBirthDate);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td5);
                txtBirthDate.Attributes.Add("onkeypress", "javascript:return false");

                TableCell td6 = new TableCell();
                AjaxControlToolkit.CalendarExtender calExtChild = new AjaxControlToolkit.CalendarExtender();
                calExtChild.ID = "calExtChild" + i;
                calExtChild.TargetControlID = "txtCBirthDate" + i;
                calExtChild.Format = "dd-MMM-yyyy";
                td6.Controls.Add(calExtChild);
                tr.Controls.Add(td6);

                TableCell td7 = new TableCell();
                RequiredFieldValidator rfv7 = new RequiredFieldValidator();
                rfv7.ID = "rfv7" + i;
                rfv7.ControlToValidate = "txtCLn" + i;
                rfv7.ErrorMessage = "Enter Last Name";
                td7.Controls.Add(rfv7);
                tr.Controls.Add(td7);


                TableCell td8 = new TableCell();
                RequiredFieldValidator rfv8 = new RequiredFieldValidator();
                rfv8.ID = "rfv8" + i;
                rfv8.ControlToValidate = "txtCFn" + i;
                rfv8.ErrorMessage = "Enter First Name";
                td8.Controls.Add(rfv8);
                tr.Controls.Add(td8);


                tblChild.Controls.Add(tr);

            }

            for (int i = 1; i <= infCnt; i++)
            {
                TableRow tr = new TableRow();
                TableCell td1 = new TableCell();
                td1.Text = "Infant" + i;
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(td1);

                TableCell tdSp = new TableCell();
                tdSp.Text = "";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdSp);

                TableCell tdtitle = new TableCell();
                tdtitle.Text = "Title :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdtitle);

                TableCell td2 = new TableCell();
                DropDownList ddlTitle = new DropDownList();
                ddlTitle.ID = "ddlITitle" + i;
                ddlTitle.Items.Add("Mstr.");
                ddlTitle.Items.Add("Miss.");

                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.ID = "txtIFn" + i;
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.ID = "txtILn" + i;
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);

                TableCell tdBD = new TableCell();
                tdBD.Text = "BirthDate :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdBD);

                TableCell td5 = new TableCell();
                TextBox txtBirthDate = new TextBox();
                txtBirthDate.ID = "txtIBirthDate" + i;
                td5.Controls.Add(txtBirthDate);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td5);
                txtBirthDate.Attributes.Add("onkeypress", "javascript:return false");


                TableCell td6 = new TableCell();
                AjaxControlToolkit.CalendarExtender calExtInf = new AjaxControlToolkit.CalendarExtender();
                calExtInf.ID = "calExtInf" + i;
                calExtInf.TargetControlID = "txtIBirthDate" + i;
                calExtInf.Format = "dd-MMM-yyyy";
                td6.Controls.Add(calExtInf);
                tr.Controls.Add(td6);


                TableCell td7 = new TableCell();
                RequiredFieldValidator rfv9 = new RequiredFieldValidator();
                rfv9.ID = "rfv9" + i;
                rfv9.ControlToValidate = "txtILn" + i;
                rfv9.ErrorMessage = "Enter Last Name";
                td7.Controls.Add(rfv9);
                tr.Controls.Add(td7);


                TableCell td8 = new TableCell();
                RequiredFieldValidator rfv10 = new RequiredFieldValidator();
                rfv10.ID = "rfv10" + i;
                rfv10.ControlToValidate = "txtIFn" + i;
                rfv10.ErrorMessage = "Enter First Name";
                td8.Controls.Add(rfv10);
                tr.Controls.Add(td8);


                tblInfants.Controls.Add(tr);

            }
            #endregion




        }
        catch
        {

        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        if (!IsPostBack)
        {


        }
        else
        {

            CreateControls(adultcnt, childCnt, infantCnt);
            // CreateControlsInt(adultCntInt, childCntInt, infantCntInt);

        }
    }

    protected void btnBook_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); return; }

            #region Variables
            string FlightSegmentsID = string.Empty;
            string originDestination_Id = string.Empty;
            string fareDetailsId = string.Empty;
            string TotalFare = string.Empty;
            /*FlightsSegment*/
            string AirEquipType = string.Empty;
            string ArrivalAirportCode = string.Empty;
            string ArrivalDateTime = string.Empty;
            string DepartureAirportCode = string.Empty;
            string DepartureDateTime = string.Empty;
            string FlightNumber = string.Empty;
            string OperatingAirlineCode = string.Empty;
            string OperatingAirlineFlightNumber = string.Empty;
            string RPH = string.Empty;
            string StopQuantity = string.Empty;
            string airLineName = string.Empty;
            string airportTax = string.Empty;
            string imageFileName = string.Empty;
            string BookingClassAvailability = string.Empty;
            string BookingClassResBookDesigCode = string.Empty;
            string adultFare = string.Empty;
            string bookingclass = string.Empty;
            string childFare = string.Empty;
            string classType = string.Empty;
            string farebasiscode = string.Empty;
            string infantfare = string.Empty;
            string Rule = string.Empty;
            string adultCommission = string.Empty;
            string childCommission = string.Empty;
            string commissionOnTCharge = string.Empty;
            string Discount = string.Empty;
            string airportTaxChild = string.Empty;
            string airportTaxInfant = string.Empty;
            string adultTaxBreakup = string.Empty;
            string childTaxBreakup = string.Empty;
            string infantTaxBreakup = string.Empty;
            string octax = string.Empty;
            string id = string.Empty;
            string key = string.Empty;
            string TCharge = string.Empty;
            string TMarkup = string.Empty;
            string TSdiscount = string.Empty;
            string TPartnerCommission = string.Empty;
            string actualBaseFare = string.Empty;
            string tax = string.Empty;
            string Stax = string.Empty;
            string SCharge = string.Empty;
            string TDiscount = string.Empty;



            #endregion



            DataTable dtFlightsSegment = dsFilghts.Tables[9];
            if (dtFlightsSegment.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + Convert.ToInt32(lblFlightSegmentId1.Text));
                FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                AirEquipType = rowFilghtSegment[0]["AirEquipType"].ToString();
                ArrivalAirportCode = rowFilghtSegment[0]["ArrivalAirportCode"].ToString();
                ArrivalDateTime = rowFilghtSegment[0]["ArrivalDateTime"].ToString();
                DepartureAirportCode = rowFilghtSegment[0]["DepartureAirportCode"].ToString();
                DepartureDateTime = rowFilghtSegment[0]["DepartureDateTime"].ToString();
                FlightNumber = rowFilghtSegment[0]["FlightNumber"].ToString();
                OperatingAirlineCode = rowFilghtSegment[0]["OperatingAirlineCode"].ToString();
                OperatingAirlineFlightNumber = rowFilghtSegment[0]["OperatingAirlineFlightNumber"].ToString();
                RPH = rowFilghtSegment[0]["RPH"].ToString();
                StopQuantity = rowFilghtSegment[0]["StopQuantity"].ToString();
                airLineName = rowFilghtSegment[0]["airLineName"].ToString();
                airportTax = rowFilghtSegment[0]["airportTax"].ToString();
                imageFileName = rowFilghtSegment[0]["imageFileName"].ToString();
                Discount = rowFilghtSegment[0]["Discount"].ToString();
                airportTaxChild = rowFilghtSegment[0]["airportTaxChild"].ToString();
                airportTaxInfant = rowFilghtSegment[0]["airportTaxInfant"].ToString();
                adultTaxBreakup = rowFilghtSegment[0]["adultTaxBreakup"].ToString();
                childTaxBreakup = rowFilghtSegment[0]["childTaxBreakup"].ToString();
                infantTaxBreakup = rowFilghtSegment[0]["infantTaxBreakup"].ToString();
                octax = rowFilghtSegment[0]["octax"].ToString();
            }

            DataTable dtFlightSegments = dsFilghts.Tables[8];
            if (dtFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
            }
            DataTable dtFareDetails = dsFilghts.Tables[5];
            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }

            DataTable dtChargeableFares = dsFilghts.Tables[6];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                TPartnerCommission = rowChargeableFareDetails[0]["TPartnerCommission"].ToString();
                actualBaseFare = rowChargeableFareDetails[0]["ActualBaseFare"].ToString();
                tax = rowChargeableFareDetails[0]["Tax"].ToString();
                Stax = rowChargeableFareDetails[0]["Stax"].ToString();
                SCharge = rowChargeableFareDetails[0]["SCharge"].ToString();
                TDiscount = rowChargeableFareDetails[0]["TDiscount"].ToString();
                TotalFare = (Convert.ToDecimal(actualBaseFare) + Convert.ToDecimal(tax) + Convert.ToDecimal(Stax) + Convert.ToDecimal(SCharge) - Convert.ToDecimal(TDiscount)).ToString();


            }
            DataTable dtNonChargeableFares = dsFilghts.Tables[7];
            if (dtNonChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                TCharge = rowNonChargeableFareDetails[0]["TCharge"].ToString();
                TMarkup = rowNonChargeableFareDetails[0]["TMarkup"].ToString();
                TSdiscount = rowNonChargeableFareDetails[0]["TSdiscount"].ToString();
            }

            DataTable dtBookingClass = dsFilghts.Tables[10];
            if (dtBookingClass.Rows.Count > 0)
            {
                DataRow[] rowBookingClass = dtBookingClass.Select("FlightSegment_ID=" + Convert.ToInt32(lblFlightSegmentId1.Text));
                BookingClassAvailability = rowBookingClass[0]["Availability"].ToString();
                BookingClassResBookDesigCode = rowBookingClass[0]["ResBookDesigCode"].ToString();
            }

            DataTable dtBookingFareRules = dsFilghts.Tables[11];
            if (dtBookingFareRules.Rows.Count > 0)
            {
                DataRow[] rowBookingFareRules = dtBookingFareRules.Select("FlightSegment_ID=" + Convert.ToInt32(lblFlightSegmentId1.Text));
                adultFare = rowBookingFareRules[0]["adultFare"].ToString();
                bookingclass = rowBookingFareRules[0]["bookingclass"].ToString();
                farebasiscode = rowBookingFareRules[0]["farebasiscode"].ToString();
                Rule = rowBookingFareRules[0]["Rule"].ToString().Replace("<br>", "");
                adultCommission = rowBookingFareRules[0]["adultCommission"].ToString();
                childCommission = rowBookingFareRules[0]["childCommission"].ToString();
                infantfare = (infantCnt > 0) ? rowBookingFareRules[0]["infantfare"].ToString() : "1";
                classType = rowBookingFareRules[0]["classType"].ToString();
                childFare = (childCnt > 0) ? rowBookingFareRules[0]["childFare"].ToString() : "1";
                commissionOnTCharge = rowBookingFareRules[0]["commissionOnTCharge"].ToString();

            }

            DataTable dtOriginDestinationOption = dsFilghts.Tables[4];
            if (dtOriginDestinationOption.Rows.Count > 0)
            {
                DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("OriginDestinationOption_Id=" + originDestination_Id);
                id = rowOriginDestinationOption[0]["id"].ToString();
                key = rowOriginDestinationOption[0]["key"].ToString();
            }



            #region Pricing

            String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/> <telePhone>" + txtPhoneNum.Text + "</telePhone><email>" + txtEmailID.Text + "</email> <creditcardno></creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";
            DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);



            if (!dsFlightPricing.Tables[0].Columns.Contains("error"))
            {

                DataTable dtFlightSegment = dsFlightPricing.Tables["FlightSegment"];
                string PricingFlightSegmentsId = dsFlightPricing.Tables["FlightSegment"].Rows[0]["FlightSegments_Id"].ToString();
                DataTable dtchangeFlightSegments = dsFlightPricing.Tables[6];
                if (dtchangeFlightSegments.Rows.Count > 0)
                {
                    DataRow[] rowchangeFilghtSegments = dtchangeFlightSegments.Select("FlightSegments_Id=" + PricingFlightSegmentsId);
                    originDestination_Id = rowchangeFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                }

                DataTable dtchangeFareDetails = dsFlightPricing.Tables[3];
                if (dtchangeFareDetails.Rows.Count > 0)
                {
                    DataRow[] rowchangeFareDetails = dtchangeFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    fareDetailsId = rowchangeFareDetails[0]["FareDetails_Id"].ToString();
                }

                DataTable dtchangeprice = dsFlightPricing.Tables[4];
                if (dtchangeprice.Rows.Count > 0)
                {
                    DataRow[] rowchangeprices = dtchangeprice.Select("FareDetails_Id=" + fareDetailsId);
                    TPartnerCommission = rowchangeprices[0]["TPartnerCommission"].ToString();
                    actualBaseFare = rowchangeprices[0]["ActualBaseFare"].ToString();
                    tax = rowchangeprices[0]["Tax"].ToString();
                    Stax = rowchangeprices[0]["Stax"].ToString();
                    SCharge = rowchangeprices[0]["SCharge"].ToString();
                    TDiscount = rowchangeprices[0]["TDiscount"].ToString();
                    TotalFare = (Convert.ToDecimal(actualBaseFare) + Convert.ToDecimal(tax) + Convert.ToDecimal(Stax) + Convert.ToDecimal(SCharge) - Convert.ToDecimal(TDiscount)).ToString();
                }
            }


            #endregion

            string refNo = Common.GetFlightsReferenceNo("LJDF");


            String xmlRequestData = "<Bookingrequest><onwardFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare> <Tax>" + tax + "</Tax><STax>" + Stax + "</STax> <SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TSdiscount + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/><personName>";


            // Dynamic generation of names of adults, infants , Child

            Table tbladults = (Table)this.UpdatePanel1.FindControl("tblAdults");
            for (int i = 1; i <= adultcnt; i++)
            {

                TextBox txtFn = (TextBox)tbladults.FindControl("txtFn" + i);
                TextBox txtLn = (TextBox)tbladults.FindControl("txtLn" + i);
                DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitle" + i);


                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
            }

            Table tblChild = (Table)this.UpdatePanel1.FindControl("tblChild");
            for (int i = 1; i <= childCnt; i++)
            {
                TextBox txtFn = (TextBox)tblChild.FindControl("txtCFn" + i);

                TextBox txtLn = (TextBox)tblChild.FindControl("txtCLn" + i);

                DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitle" + i);


                TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDate" + i);
                DateTime strdate = Convert.ToDateTime(txtBirthDate.Text);


                string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
            }

            Table tblInfants = (Table)this.UpdatePanel1.FindControl("tblInfants");
            for (int i = 1; i <= infantCnt; i++)
            {
                TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFn" + i);

                TextBox txtLn = (TextBox)tblInfants.FindControl("txtILn" + i);

                DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitle" + i);

                TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDate" + i);//this.

                string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
            }

            xmlRequestData = xmlRequestData + "</personName><telePhone><phoneNumber>" + txtPhoneNum.Text + "</phoneNumber></telePhone><email><emailAddress>" + txtEmailID.Text + "</emailAddress></email><creditcardno>4111111111111111</creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword> <partnerRefId>" + refNo + "</partnerRefId> <Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + ddlAdult.SelectedItem.Value + "</AdultPax><ChildPax>" + ddlChild.SelectedItem.Value + "</ChildPax><InfantPax>" + ddlInfant.SelectedItem.Value + "</InfantPax></Bookingrequest>";
            DataSet dsBookingResponse = new DataSet();


            //DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            //string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
            //string commisionPercentage = dsBalance.Tables[0].Rows[0]["CommisionPercentage"].ToString();
            //string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

            //string actualFare = TotalFare;
            //string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
            //    ((Convert.ToDouble(actualFare.ToString()) * Convert.ToInt32(commisionPercentage)) / 100));
            //string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

            //Session["AgentId_Agent"] = agentId;
            //Session["ActualFare_Agent"] = actualFare;
            //Session["CommisionFare_Agent"] = commisionFare;
            //Session["CommisionPercentage_Agent"] = commisionPercentage;
            //Session["DeductAmount_Agent"] = deductAmount;

            //if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
            //{

            dsBookingResponse = objFlights.GetBookingDetails(xmlRequestData);
            //}
            //else { return; }

            string error = string.Empty;


            // If there is any Error -- We wont get the transid instead we get error
            if (dsBookingResponse.Tables[0].Columns.Contains("transid"))
            {
                transId = dsBookingResponse.Tables[0].Rows[0]["transid"].ToString();

                //DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                //                        Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
                //                        Convert.ToDouble(Session["CommisionFare_Agent"].ToString()), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));

                //objBAL = new ClsBAL();
                //DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                //string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                //Label lbl = (Label)this.Master.FindControl("lblBalance");
                //lbl.Text = balance;
                //Session["Balance"] = balanceAgent;



                #region SaveResponse
                FlightBAL objFlightBal = new FlightBAL();

                objFlightBal.ReferenceNo = refNo;
                objFlightBal.TransId = transId;
                objFlightBal.Status = dsBookingResponse.Tables["Bookingresponse"].Rows[0]["status"].ToString();
                objFlightBal.AdultPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["AdultPax"].ToString());
                objFlightBal.InfantPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["InfantPax"].ToString());
                objFlightBal.ChildPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["ChildPax"].ToString());
                objFlightBal.Origin_Destination_Id = dsBookingResponse.Tables["originDestinationOption"].Rows[0]["id"].ToString();
                objFlightBal.Origin_Destination_Key = dsBookingResponse.Tables["originDestinationOption"].Rows[0]["key"].ToString();
                objFlightBal.ActualBasefare = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["ActualBasefare"].ToString());
                objFlightBal.Tax = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["Tax"].ToString());
                objFlightBal.STax = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["STax"].ToString());
                objFlightBal.Scharge = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["Scharge"].ToString());
                objFlightBal.TDiscount = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["TDiscount"].ToString());
                objFlightBal.TPartnerCommission = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["TPartnerCommission"].ToString());
                objFlightBal.TCharge = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TCharge"].ToString());
                objFlightBal.TMarkUp = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TMarkUp"].ToString());
                objFlightBal.TSDiscount = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TSDiscount"].ToString());
                string givenName = string.Empty;
                string surName = string.Empty;
                string namereference = string.Empty;
                string psgrType = string.Empty;
                string Age = string.Empty;
                string customerInfo = string.Empty;
                for (int i = 0; i < dsBookingResponse.Tables["CustomerInfo"].Rows.Count; i++)
                {

                    givenName = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["givenName"].ToString();
                    surName = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["surName"].ToString();
                    namereference = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["nameReference"].ToString();


                    string[] str = namereference.ToString().Split(',');
                    if (str[0].ToString() == "C")
                    {
                        psgrType = "Child";
                        Age = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["age"].ToString();
                    }
                    else
                        if (str[0].ToString() == "I")
                        {
                            psgrType = "Infant";
                            Age = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["age"].ToString();
                        }
                        else
                        {
                            psgrType = "Adt";
                        }


                    //   psgrType = "";// dsBookingResponse.Tables["CustomerInfo"].Rows[i]["psgrtype"].ToString();

                    if (psgrType.ToString() != "Adt")
                    {
                        if (customerInfo == string.Empty)
                        {
                            customerInfo = str[1].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                        else
                        {
                            customerInfo = customerInfo + ";" + str[1].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                    }
                    else
                    {
                        if (customerInfo == string.Empty)
                        {
                            customerInfo = str[0].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                        else
                        {
                            customerInfo = customerInfo + ";" + str[0].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                    }

                }
                objFlightBal.Customer_Details = customerInfo;
                objFlightBal.telephone = dsBookingResponse.Tables["telePhone"].Rows[0]["PhoneNumber"].ToString();
                objFlightBal.emailAddress = lblEmailAddress.Text = dsBookingResponse.Tables["email"].Rows[0]["emailAddress"].ToString();
                objFlightBal.TripMode = "One";
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);

                // bool res = objFlightBal.AddDomesticFlightBooking(objFlightBal);

                DataTable dtflightBookingId = objFlightBal.AddDomesticFlightBooking(objFlightBal);
                string flightBookingId = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                objFlightBal.FlightBookingID = flightBookingId.ToString();
                if (dsBookingResponse.Tables["FlightSegment"].Rows.Count > 0)
                {
                    for (int j = 0; j < dsBookingResponse.Tables["FlightSegment"].Rows.Count; j++)
                    {


                        objFlightBal.AirEquipType = dsBookingResponse.Tables["FlightSegment"].Rows[0]["AirEquipType"].ToString();
                        objFlightBal.ArrivalAirportCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ArrivalAirportCode"].ToString();
                        objFlightBal.ArrivalDateTime = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ArrivalDateTime"].ToString();
                        objFlightBal.DepartureAirportCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["DepartureAirportCode"].ToString();
                        objFlightBal.DepartureDateTime = dsBookingResponse.Tables["FlightSegment"].Rows[0]["DepartureDateTime"].ToString();
                        objFlightBal.FlightNumber = dsBookingResponse.Tables["FlightSegment"].Rows[0]["FlightNumber"].ToString();
                        objFlightBal.OperatingAirlineCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["OperatingAirlineCode"].ToString();
                        objFlightBal.OperatingAirlineFlightNumber = dsBookingResponse.Tables["FlightSegment"].Rows[0]["OperatingAirlineFlightNumber"].ToString();
                        objFlightBal.RPH = dsBookingResponse.Tables["FlightSegment"].Rows[0]["RPH"].ToString();
                        objFlightBal.StopQuantity = dsBookingResponse.Tables["FlightSegment"].Rows[0]["StopQuantity"].ToString();
                        objFlightBal.airlineName = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airlineName"].ToString();
                        objFlightBal.airportTax = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTax"].ToString();
                        objFlightBal.imageFileName = dsBookingResponse.Tables["FlightSegment"].Rows[0]["imageFileName"].ToString();
                        objFlightBal.Discount = dsBookingResponse.Tables["FlightSegment"].Rows[0]["Discount"].ToString();
                        objFlightBal.airportTaxChild = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTaxChild"].ToString();
                        objFlightBal.airportTaxInfant = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTaxInfant"].ToString();
                        objFlightBal.adultTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["adultTaxBreakUp"].ToString();
                        objFlightBal.ChildTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ChildTaxBreakUp"].ToString();
                        objFlightBal.InfantTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["InfantTaxBreakUp"].ToString();
                        objFlightBal.ocTax = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ocTax"].ToString();
                        objFlightBal.Availability = dsBookingResponse.Tables["BookingClass"].Rows[0]["Availability"].ToString();
                        objFlightBal.ResBookingCode = dsBookingResponse.Tables["BookingClass"].Rows[0]["ResBookDesigCode"].ToString();
                        objFlightBal.adultFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["adultFare"].ToString();
                        objFlightBal.bookingClass = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["bookingClass"].ToString();
                        objFlightBal.ChildFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["ChildFare"].ToString();
                        objFlightBal.ClassType = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["ClassType"].ToString();
                        objFlightBal.farebasisCode = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["farebasisCode"].ToString();
                        objFlightBal.infantFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["infantFare"].ToString();
                        objFlightBal.Fare_Rule = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["Rule"].ToString();
                        objFlightBal.adultCommission = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["adultCommission"].ToString();
                        objFlightBal.childCommission = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["childCommission"].ToString();
                        objFlightBal.CommissionOnTCharge = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["CommissionOnTCharge"].ToString();
                        objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);


                        bool res = objFlightBal.AddDomesticFlightBookingsegments(objFlightBal);


                        if (res)
                        {

                            GetDetailsForPrint(objFlightBal.ReferenceNo.ToString());
                            lbtnmail.Visible = false;
                            lbtnmail_Click1(sender, e);
                            pnlPassengerDet.Visible = false;
                            lblStatus.Visible = true;
                            lblStatus.Text = "Ticket has been booked successfully. Reference Number is : " + objFlightBal.ReferenceNo.ToString();
                            lblStatus.ForeColor = System.Drawing.Color.Green;

                        }

                #endregion

                        else
                        {
                            error = dsBookingResponse.Tables[0].Rows[0]["error"].ToString();
                            lblStatus.Text = error;

                        }
                    }
                }
            }
            else
            {
                mp3.Show();
                lblerror.Text = dsBookingResponse.Tables[0].Rows[0]["error"].ToString();
            }

        }
        catch (Exception ex)
        {

        }

    }


    //private string GetReferenceNo()
    //{
    //    Random random = new Random();
    //    return "DF" + random.Next();

    //}
    protected void gdvFlights_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    private void SortGridView(string sortExpression, string direction)
    {
        //  You can cache the DataTable for improving performance
        DataTable dt = ((DataTable)Session["dtFights"]);
        //GetData().Tables[0];
        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + direction;

        gdvFlights.DataSource = dv;
        dsFilghts = (DataSet)Session["dsIntFlights"];
        gdvFlights.DataBind();


    }

    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare,
          double commisionFare, int commisionPercentage)
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            return objBAL.DeductAgentBalance(agentId, deductAmount, createdBy, mbRefNo,
                actualFare, commisionFare, commisionPercentage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnBookStatus_Click(object sender, EventArgs e)
    {
        transId = "A013729";
        String xmlRequestData = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100200</partnerRefId></EticketRequest>";
        DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);
        lblMsg.Visible = true;
        lblMsg.Text = dsFlightBookStatus.Tables[0].Rows[0]["Status"].ToString();
    }
    protected void btnCancelTicket_Click(object sender, EventArgs e)
    {
        transId = "A013729";
        String xmlRequestData = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100200</partnerRefId></EticketRequest>";
        DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);

        #region Variables

        string status = string.Empty;
        string remarks = string.Empty;
        string requestedPNR_Id = string.Empty;
        string originDestinationOptionsId = string.Empty;
        string OriDestPNRRequest_id = string.Empty;
        string eticketdto_id = string.Empty;
        string givenName = string.Empty;
        string surName = string.Empty;
        string nameReference = string.Empty;
        string eticketNo = string.Empty;
        string flightUid = string.Empty;
        string passUid = string.Empty;

        #endregion

        DataTable dtRequestedPNR = (DataTable)dsFlightBookStatus.Tables[0];
        transId = dtRequestedPNR.Rows[0]["transid"].ToString();
        status = dtRequestedPNR.Rows[0]["status"].ToString();
        requestedPNR_Id = dtRequestedPNR.Rows[0]["requestedPNR_Id"].ToString();

        DataTable dtOriginDestinationOptions = (DataTable)dsFlightBookStatus.Tables[1];
        if (dtOriginDestinationOptions.Rows.Count > 0)
        {
            DataRow[] rowOriginDestinationOptions = dtOriginDestinationOptions.Select("requestedPNR_Id=" + requestedPNR_Id);
            originDestinationOptionsId = rowOriginDestinationOptions[0]["OriginDestinationoptions_Id"].ToString();
        }

        DataTable dtOriDetPNRRequest = dsFlightBookStatus.Tables[2];
        if (dtOriDetPNRRequest.Rows.Count > 0)
        {
            DataRow[] drOriDetPNRRequest = dtOriDetPNRRequest.Select("OriginDestinationoptions_Id=" + originDestinationOptionsId);
            OriDestPNRRequest_id = drOriDetPNRRequest[0]["OriDestPNRRequest_id"].ToString();

        }

        DataTable dtEticketdo = dsFlightBookStatus.Tables[3];
        if (dtEticketdo.Rows.Count > 0)
        {
            DataRow[] drEticketdo = dtEticketdo.Select("OriDestPNRRequest_id=" + OriDestPNRRequest_id);
            eticketdto_id = drEticketdo[0]["eticketdto_id"].ToString();
        }

        DataTable dtEticket = dsFlightBookStatus.Tables[4];
        if (dtEticket.Rows.Count > 0)
        {
            DataRow[] drEticket = dtEticket.Select("eticketdto_id=" + eticketdto_id);
            givenName = drEticket[0]["givenName"].ToString();
            surName = drEticket[0]["surName"].ToString();
            nameReference = drEticket[0]["nameReference"].ToString();
            eticketNo = drEticket[0]["eticketNo"].ToString();
            flightUid = drEticket[0]["flightUid"].ToString();
            passUid = drEticket[0]["passuid"].ToString();

        }
        String xmlCancelRequest = "<CancelationDetails><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><status>" + status + "</status><remarks>Hi transaction</remarks><eticketdto>";
        xmlCancelRequest = xmlCancelRequest + "<Eticket><givenName>" + givenName + "</givenName><surName>" + surName + "</surName><nameReference>" + nameReference + "</nameReference><eticketno>" + eticketNo + "</eticketno><flightuid>" + flightUid + "</flightuid><passuid>" + passUid + "</passuid></Eticket>";
        xmlCancelRequest = xmlCancelRequest + "</eticketdto></CancelationDetails>";
        DataSet dsCancelResponse = objFlights.CancelTicket(xmlCancelRequest);
    }
    protected void btnCancelTicketStatus_Click(object sender, EventArgs e)
    {
        transId = "A410697";
        String xmlCancelReqStatus = "<EticketCanStatusReq><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>" + transId + "</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
        DataSet dsCancelResponse = objFlights.GetCancelTicketStatus(xmlCancelReqStatus);
    }
    protected void lnkDomesticFlights_Click(object sender, EventArgs e)
    {
        //tbl_domesticFlights.Visible = true;
        //tbl_InternationalFlights.Visible = false;
    }
    protected void lnkInternationalFlights_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Agent/Flight/frmInternationalAvailablity.aspx", false);
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAirportCodes(string prefixText)
    {
        try
        {

            //string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=F:\\LoveJourney\\LoveJourneyCode\\LoveJourneyUI\\DOCS\\International_AirportCodes.xlsx;Extended Properties=Excel 12.0;HDR=YES;IMEX=1";
            string connstr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=~\\DOCS\\International_AirportCodes.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES""");
            OleDbConnection conn = new OleDbConnection(connstr);
            string strSQL = "SELECT * FROM [Sheet1$]";


            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            string filteringquery = "CityName_ LIKE'" + prefixText + "%'";
            //Select always return array,thats why we store it into array of Datarow
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            //create new table
            DataTable dtNew = new DataTable();
            //create a clone of datatable dt and store it into new datatable
            dtNew = ds.Tables[0].Clone();
            //fetching all filtered rows add add into new datatable
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }
            //return dtAirportCodes;

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["CityName_"].ToString() + " - (" + dtNew.Rows[i]["AirportCode_"].ToString() + ")");
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }


    protected void lnkModifySearch_Click(object sender, EventArgs e)
    {

        ModifySearch.Visible = true;
        ClearSearchFields();
    }
    private void ClearSearchFields()
    {
        ddlSourcesSearch.SelectedIndex = -1;
        ddlDestinationsSearch.SelectedIndex = -1;
        txtdatesearch.Text = string.Empty;
        txtretundatesearch.Text = string.Empty;
        ddlIntCabinTypesearch.SelectedIndex = -1;
        ddladultsintsearch.SelectedIndex = -1;
        ddlchildintsearch.SelectedIndex = -1;
        ddlinfantsintsearch.SelectedIndex = -1;
        lnkModifySearch.Visible = false;
    }
    protected void gdvFlights_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["dtFights"] != null)
            {
                DataSet ds = (DataSet)Session["dtFights"];
                gdvFlights.PageIndex = e.NewPageIndex;
                gdvFlights.DataSource = ds;
                gdvFlights.DataBind();
            }
            else { Response.Redirect("Default.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {

            if (lblEmailAddress.Text != null)
            {
                string body = getHTML(pnlViewticket);
                bool res = Mailsender.SendEmail(lblEmailAddress.Text, "", "", "Ticket Details", body);
                if (res)
                {

                    lblStatus.Text = "Mail has been sent successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    lblStatus.Text = "Failed to send Mail ";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private string getHTML(Panel Pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        Pnl.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
        /* -----------------------------------
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */

    }
    protected void GetDetailsForPrint(string RefNo)
    {
        try
        {
            FlightBAL objFlightsBAL = new FlightBAL();
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetDomesticFlightDetails(RefNo.Trim());
            if (dsFlights.Tables[0].Rows.Count == 1)
            {

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    string customerDetails = dsFlights.Tables[0].Rows[0]["Customer_Details"].ToString();
                    string[] strArryCustDet = customerDetails.Split('|');
                    lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                    lblTel.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();
                    lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                    lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                    lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                    lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["airlineName"].ToString();
                    img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                    string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                    lblDepartureDate.Text = strArryDeptDatetime[0].ToString();
                    lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                    string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                    lblArrivalDate.Text = strArryDeptDatetime[0].ToString();
                    lblArrivalTime.Text = strArryDeptDatetime[1].ToString();
                    lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblPsngrMobileNo.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();

                    string[] strCusDetArr = customerDetails.Split(';');
                    string indCustDet = string.Empty;
                    DataTable dtPsgrDet = new DataTable();
                    dtPsgrDet.Columns.Add("Name", typeof(string));
                    dtPsgrDet.Columns.Add("Type", typeof(string));
                    dtPsgrDet.Columns.Add("Age", typeof(string));

                    for (int i = 0; i < strCusDetArr.Length; i++)
                    {
                        indCustDet = strCusDetArr[i];
                        string[] strArryCustDet1 = indCustDet.Split('|');
                        DataRow dr = dtPsgrDet.NewRow();
                        dr["Name"] = strArryCustDet1[0] + strArryCustDet1[1] + "  " + strArryCustDet1[2];
                        dr["Type"] = strArryCustDet1[3];
                        dr["Age"] = strArryCustDet1[4];
                        dtPsgrDet.Rows.Add(dr);
                    }

                    gdvPassengerDetails.DataSource = dtPsgrDet;
                    gdvPassengerDetails.DataBind();
                    lblPassengerType.Text = strArryCustDet[3];
                    lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                    lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                    lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                    lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                    lblTotal.Text = (Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text) - Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                    pnlViewticket.Visible = true;
                }


                //return en





            }
            else if (dsFlights.Tables[0].Rows.Count == 2)
            {
                //return 

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    lblAirlineNamereturn.Text = dsFlights.Tables[0].Rows[1]["airlineName"].ToString();
                    //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumberreturn.Text = dsFlights.Tables[0].Rows[1]["FlightNumber"].ToString();
                    string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                    lblDepartureDatereturn.Text = strArryDeptDatetimeRet[0].ToString();
                    lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                    lblArrivalDatereturn.Text = strArryDeptDatetimeRet[0].ToString();
                    lblArrivalTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();

                }

            }
            pnlViewticket.Visible = true;

        }
        catch (Exception ex)
        {

            throw;
        }

    }

    protected void gdvOnward_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string FlightSegmentsID = string.Empty;
            string originDestination_Id = string.Empty;
            string fareDetailsId = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dsFilghts = (DataSet)Session["dsIntFlights"];

                Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
                Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");

                DataTable dtFlightsSegment = (DataTable)Session["DtOnwardFlights"];

                if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                {
                    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    {
                        lblConnectingAirportCode.Visible = true;
                        lblHyphen.Visible = true;
                        lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                        lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                        lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                        lblConnectingFlights.Visible = true;
                    }
                    else
                    {
                        lblConnectingAirportCode.Visible = false;
                        lblHyphen.Visible = false;
                        lblConnectingFlights.Visible = false;
                    }
                }
                if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
                {
                    e.Row.Visible = false;
                }

                Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                string time = dtDepart.ToShortTimeString();
                lblDepartTime.Text = time.ToString();

                Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
                DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                string Arrtime = dtArrive.ToShortTimeString();
                lblArrivalTime.Text = Arrtime.ToString();

                LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
                int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

                DataTable dtBookingFareRules = dsFilghts.Tables[11];
                if (dtBookingFareRules.Rows.Count > 0)
                {
                    DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                    Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                    lblFareRules.Text = row[0]["Rule"].ToString();
                }


                if (dtFlightsSegment.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + FlightSegmentId);
                    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                }

                DataTable dtFlightSegments = dsFilghts.Tables[8];
                if (dtFlightSegments.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                }
                DataTable dtFareDetails = dsFilghts.Tables[5];
                if (dtFareDetails.Rows.Count > 0)
                {
                    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                }
                DataTable dtChargeableFares = dsFilghts.Tables[6];
                if (dtChargeableFares.Rows.Count > 0)
                {
                    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                    Label lblTax = (Label)e.Row.FindControl("lblTax");
                    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    Label lblFare = (Label)e.Row.FindControl("lblFare");


                    lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                    lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                    lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                    lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                    lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");

                    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblSCharge.Text) - Convert.ToDouble(lblTDiscount.Text);
                    lblTotal.Text = lblFare.Text = total.ToString("####0.00");



                }
                DataTable dtactivedetails = dsFilghts.Tables[1];
                Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gdvReturn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string FlightSegmentsID = string.Empty;
            string originDestination_Id = string.Empty;
            string fareDetailsId = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dsFilghts = (DataSet)Session["dsIntFlights"];
                Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
                Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");

                DataTable dtFlightsSegment = (DataTable)Session["DtReturnFlights"];
                if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                {
                    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    {
                        lblConnectingAirportCode.Visible = true;
                        lblHyphen.Visible = true;
                        lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                        lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                        lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                        lblConnectingFlights.Visible = true;
                    }
                    else
                    {
                        lblConnectingAirportCode.Visible = false;
                        lblHyphen.Visible = false;
                        lblConnectingFlights.Visible = false;
                    }
                }
                if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
                {
                    e.Row.Visible = false;
                }

                Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                string time = dtDepart.ToShortTimeString();
                lblDepartTime.Text = time.ToString();

                Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
                DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                string Arrtime = dtArrive.ToShortTimeString();
                lblArrivalTime.Text = Arrtime.ToString();

                LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
                int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

                DataTable dtBookingFareRules = dsFilghts.Tables[11];
                if (dtBookingFareRules.Rows.Count > 0)
                {
                    DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                    Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                    lblFareRules.Text = row[0]["Rule"].ToString();
                }


                if (dtFlightsSegment.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + FlightSegmentId);
                    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                }

                DataTable dtFlightSegments = dsFilghts.Tables[8];
                if (dtFlightSegments.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                }
                DataTable dtFareDetails = dsFilghts.Tables[5];
                if (dtFareDetails.Rows.Count > 0)
                {
                    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                }
                DataTable dtChargeableFares = dsFilghts.Tables[6];
                if (dtChargeableFares.Rows.Count > 0)
                {
                    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                    Label lblTax = (Label)e.Row.FindControl("lblTax");
                    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    Label lblFare = (Label)e.Row.FindControl("lblFare");


                    lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                    lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                    lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                    lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                    lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");

                    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblSCharge.Text) - Convert.ToDouble(lblTDiscount.Text);
                    lblTotal.Text = lblFare.Text = total.ToString("####0.00");



                }
                DataTable dtactivedetails = dsFilghts.Tables[1];
                Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (rbonesearch.Checked == true)
            {
                Oneway.Visible = true;
                gdvFlights.Visible = true;
            }
            else if (rbreturnsearch.Checked == true)
            {
                trroundTrip.Visible = true;
                round.Visible = true;
                Returnway.Visible = true;
                Returnwayfare.Visible = true;
            }
            GetSearchFlights();
            lnkModifySearch.Visible = false;
            modifyfilter.Visible = true;
            string[] strfrom = new string[2];
            strfrom = Session["From"].ToString().Split(',');
            string[] strto = new string[2];
            strto = Session["To"].ToString().Split(',');
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
            Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();
        }
        catch (Exception ex)
        {

        }
    }
    bool b = true;
    bool br = true;
    protected void btnRoundTripBook_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow rows in gdvReturn.Rows)
            {
                RadioButton rd = (RadioButton)rows.FindControl("rbnAirline");
                if (rd.Checked == true)
                {
                    b = true;
                    break;
                }
                else
                {
                    b = false;
                }
            }
            foreach (GridViewRow rows in gdvOnward.Rows)
            {
                RadioButton rd = (RadioButton)rows.FindControl("rbnAirline");
                if (rd.Checked == true)
                {
                    br = true;
                    break;
                }
                else
                {
                    br = false;
                }
            }
            if (b == true && br == true)
            {
                btnBook.Visible = false;
                btnRoundTripSubmit.Visible = true;
                pnlPassengerDet.Visible = true;
                pnlSearch.Visible = false;

                //gdvOnward_RowCommand(sender, e);
            }
            else
            {
                Literal lit = new Literal();
                lit.Text = "Please select oneway and return";
                this.Page.Controls.Add(lit);

            }





        }
        catch (Exception ex)
        {
        }
    }

    protected void btnRoundTripSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); return; }

            #region Variables
            string FlightSegmentsID = string.Empty;
            string originDestination_Id = string.Empty;
            string fareDetailsId = string.Empty;
            string TotalFare = string.Empty;
            string AirEquipType = string.Empty;
            string ArrivalAirportCode = string.Empty;
            string ArrivalDateTime = string.Empty;
            string DepartureAirportCode = string.Empty;
            string DepartureDateTime = string.Empty;
            string FlightNumber = string.Empty;
            string OperatingAirlineCode = string.Empty;
            string OperatingAirlineFlightNumber = string.Empty;
            string RPH = string.Empty;
            string StopQuantity = string.Empty;
            string airLineName = string.Empty;
            string airportTax = string.Empty;
            string imageFileName = string.Empty;
            string BookingClassAvailability = string.Empty;
            string BookingClassResBookDesigCode = string.Empty;
            string adultFare = string.Empty;
            string bookingclass = string.Empty;
            string childFare = string.Empty;
            string classType = string.Empty;
            string farebasiscode = string.Empty;
            string infantfare = string.Empty;
            string Rule = string.Empty;
            string adultCommission = string.Empty;
            string childCommission = string.Empty;
            string commissionOnTCharge = string.Empty;
            string Discount = string.Empty;
            string airportTaxChild = string.Empty;
            string airportTaxInfant = string.Empty;
            string adultTaxBreakup = string.Empty;
            string childTaxBreakup = string.Empty;
            string infantTaxBreakup = string.Empty;
            string octax = string.Empty;
            string id = string.Empty;
            string key = string.Empty;
            string TCharge = string.Empty;
            string TMarkup = string.Empty;
            string TSdiscount = string.Empty;
            string TPartnerCommission = string.Empty;
            string actualBaseFare = string.Empty;
            string tax = string.Empty;
            string Stax = string.Empty;
            string SCharge = string.Empty;
            string TDiscount = string.Empty;

            string responseDepartId = string.Empty;
            string responseReturnId = string.Empty;
            string OriginDestinationOptionsId = string.Empty;

            string FlightSegmentsIDRet = string.Empty;
            string originDestination_IdRet = string.Empty;
            string fareDetailsIdRet = string.Empty;
            string TotalFareRet = string.Empty;
            string AirEquipTypeRet = string.Empty;
            string ArrivalAirportCodeRet = string.Empty;
            string ArrivalDateTimeRet = string.Empty;
            string DepartureAirportCodeRet = string.Empty;
            string DepartureDateTimeRet = string.Empty;
            string FlightNumberRet = string.Empty;
            string OperatingAirlineCodeRet = string.Empty;
            string OperatingAirlineFlightNumberRet = string.Empty;
            string RPHRet = string.Empty;
            string StopQuantityRet = string.Empty;
            string airLineNameRet = string.Empty;
            string airportTaxRet = string.Empty;
            string imageFileNameRet = string.Empty;
            string BookingClassAvailabilityRet = string.Empty;
            string BookingClassResBookDesigCodeRet = string.Empty;
            string adultFareRet = string.Empty;
            string bookingclassRet = string.Empty;
            string childFareRet = string.Empty;
            string classTypeRet = string.Empty;
            string farebasiscodeRet = string.Empty;
            string infantfareRet = string.Empty;
            string RuleRet = string.Empty;
            string adultCommissionRet = string.Empty;
            string childCommissionRet = string.Empty;
            string commissionOnTChargeRet = string.Empty;
            string DiscountRet = string.Empty;
            string airportTaxChildRet = string.Empty;
            string airportTaxInfantRet = string.Empty;
            string adultTaxBreakupRet = string.Empty;
            string childTaxBreakupRet = string.Empty;
            string infantTaxBreakupRet = string.Empty;
            string octaxRet = string.Empty;
            string idRet = string.Empty;
            string keyRet = string.Empty;
            string TChargeRet = string.Empty;
            string TMarkupRet = string.Empty;
            string TSdiscountRet = string.Empty;
            string TPartnerCommissionRet = string.Empty;
            string actualBaseFareRet = string.Empty;
            string taxRet = string.Empty;
            string StaxRet = string.Empty;
            string SChargeRet = string.Empty;
            string TDiscountRet = string.Empty;

            string responseDepartIdRet = string.Empty;
            string responseReturnIdRet = string.Empty;
            string OriginDestinationOptionsIdRet = string.Empty;

            #endregion


            DataTable dtFlightSegment = dsFilghts.Tables["FlightSegment"];

            if (dtFlightSegment.Rows.Count > 0)
            {
                DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegment_Id=" + lblonwardFlightSegmentId.Text);
                AirEquipType = rowFlightSegment[0]["AirEquipType"].ToString();
                ArrivalAirportCode = rowFlightSegment[0]["ArrivalAirportCode"].ToString();
                ArrivalDateTime = rowFlightSegment[0]["ArrivalDateTime"].ToString();
                DepartureAirportCode = rowFlightSegment[0]["DepartureAirportCode"].ToString();
                DepartureDateTime = rowFlightSegment[0]["DepartureDateTime"].ToString();
                FlightNumber = rowFlightSegment[0]["FlightNumber"].ToString();
                OperatingAirlineCode = rowFlightSegment[0]["OperatingAirlineCode"].ToString();
                OperatingAirlineFlightNumber = rowFlightSegment[0]["OperatingAirlineFlightNumber"].ToString();
                RPH = rowFlightSegment[0]["RPH"].ToString();
                StopQuantity = rowFlightSegment[0]["StopQuantity"].ToString();
                airLineName = rowFlightSegment[0]["airLineName"].ToString();
                airportTax = rowFlightSegment[0]["airportTax"].ToString();
                imageFileName = rowFlightSegment[0]["imageFileName"].ToString();
                Discount = rowFlightSegment[0]["Discount"].ToString();
                airportTaxChild = rowFlightSegment[0]["airportTaxChild"].ToString();
                airportTaxInfant = rowFlightSegment[0]["airportTaxInfant"].ToString();
                adultTaxBreakup = rowFlightSegment[0]["adultTaxBreakup"].ToString();
                childTaxBreakup = rowFlightSegment[0]["childTaxBreakup"].ToString();
                infantTaxBreakup = rowFlightSegment[0]["infantTaxBreakup"].ToString();
                octax = rowFlightSegment[0]["octax"].ToString();
                FlightSegmentsID = rowFlightSegment[0]["FlightSegments_Id"].ToString();
            }

            DataTable dtFlightSegments = dsFilghts.Tables["FlightSegments"];

            if (dtFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFlightSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                originDestination_Id = rowFlightSegments[0]["originDestinationoption_Id"].ToString();
            }
            DataTable dtoriginDestinationoption = dsFilghts.Tables["originDestinationoption"];

            if (dtoriginDestinationoption.Rows.Count > 0)
            {
                DataRow[] roworiginDestinationoption = dtoriginDestinationoption.Select("originDestinationoption_Id=" + originDestination_Id);
                id = roworiginDestinationoption[0]["id"].ToString();
                key = roworiginDestinationoption[0]["key"].ToString();
            }

            DataTable dtFareDetails = dsFilghts.Tables["FareDetails"];

            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("originDestinationoption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }

            DataTable dtChargeableFares = dsFilghts.Tables["ChargeableFares"];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFares = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                actualBaseFare = rowChargeableFares[0]["ActualBaseFare"].ToString();
                tax = rowChargeableFares[0]["tax"].ToString();
                Stax = rowChargeableFares[0]["Stax"].ToString();
                SCharge = rowChargeableFares[0]["SCharge"].ToString();
                TDiscount = rowChargeableFares[0]["TDiscount"].ToString();
                TPartnerCommission = rowChargeableFares[0]["TPartnerCommission"].ToString();

            }

            DataTable dtNonChargeableFares = dsFilghts.Tables["NonChargeableFares"];
            if (dtNonChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowNonChargeableFares = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                TCharge = rowNonChargeableFares[0]["TCharge"].ToString();
                TSdiscount = rowNonChargeableFares[0]["TSdiscount"].ToString();
                TMarkup = rowNonChargeableFares[0]["TMarkup"].ToString();
            }
            DataTable dtBookingClass = dsFilghts.Tables["BookingClass"];
            if (dtBookingClass.Rows.Count > 0)
            {
                DataRow[] rowBookingClass = dtBookingClass.Select("FlightSegment_Id=" + lblonwardFlightSegmentId.Text);
                BookingClassAvailability = rowBookingClass[0]["Availability"].ToString();
                BookingClassResBookDesigCode = rowBookingClass[0]["ResBookDesigCode"].ToString();

            }

            DataTable dtBookingClassfare = dsFilghts.Tables["BookingClassFare"];
            if (dtBookingClassfare.Rows.Count > 0)
            {
                DataRow[] rowBookingClassFare = dtBookingClassfare.Select("FlightSegment_Id=" + lblonwardFlightSegmentId.Text);
                adultFare = rowBookingClassFare[0]["adultFare"].ToString();
                if (dtBookingClassfare.Columns.Contains("childFare"))
                {
                    childFare = rowBookingClassFare[0]["childFare"].ToString();
                }
                if (dtBookingClassfare.Columns.Contains("infantfare"))
                {
                    infantfare = rowBookingClassFare[0]["infantfare"].ToString();
                }
                bookingclass = rowBookingClassFare[0]["bookingclass"].ToString();
                classType = rowBookingClassFare[0]["classType"].ToString();
                farebasiscode = rowBookingClassFare[0]["farebasiscode"].ToString();
                Rule = rowBookingClassFare[0]["Rule"].ToString().Replace("<", "&lt;").Replace(">", "&gt;");
                adultCommission = rowBookingClassFare[0]["adultCommission"].ToString();
                childCommission = rowBookingClassFare[0]["childCommission"].ToString();
                commissionOnTCharge = rowBookingClassFare[0]["commissionOnTCharge"].ToString();
            }

            #region ReturnOriginDestionOptionDetails
            DataTable dtFlightSegmentRet = dsFilghts.Tables["FlightSegment"];

            if (dtFlightSegmentRet.Rows.Count > 0)
            {
                DataRow[] rowFlightSegmentRet = dtFlightSegmentRet.Select("FlightSegment_Id=" + lblReturnFlightSegment.Text);
                AirEquipTypeRet = rowFlightSegmentRet[0]["AirEquipType"].ToString();
                ArrivalAirportCodeRet = rowFlightSegmentRet[0]["ArrivalAirportCode"].ToString();
                ArrivalDateTimeRet = rowFlightSegmentRet[0]["ArrivalDateTime"].ToString();
                DepartureAirportCodeRet = rowFlightSegmentRet[0]["DepartureAirportCode"].ToString();
                DepartureDateTimeRet = rowFlightSegmentRet[0]["DepartureDateTime"].ToString();
                FlightNumberRet = rowFlightSegmentRet[0]["FlightNumber"].ToString();
                OperatingAirlineCodeRet = rowFlightSegmentRet[0]["OperatingAirlineCode"].ToString();
                OperatingAirlineFlightNumberRet = rowFlightSegmentRet[0]["OperatingAirlineFlightNumber"].ToString();
                RPHRet = rowFlightSegmentRet[0]["RPH"].ToString();
                StopQuantityRet = rowFlightSegmentRet[0]["StopQuantity"].ToString();
                airLineNameRet = rowFlightSegmentRet[0]["airLineName"].ToString();
                airportTaxRet = rowFlightSegmentRet[0]["airportTax"].ToString();
                imageFileNameRet = rowFlightSegmentRet[0]["imageFileName"].ToString();
                DiscountRet = rowFlightSegmentRet[0]["Discount"].ToString();
                airportTaxChildRet = rowFlightSegmentRet[0]["airportTaxChild"].ToString();
                airportTaxInfantRet = rowFlightSegmentRet[0]["airportTaxInfant"].ToString();
                adultTaxBreakupRet = rowFlightSegmentRet[0]["adultTaxBreakup"].ToString();
                childTaxBreakupRet = rowFlightSegmentRet[0]["childTaxBreakup"].ToString();
                infantTaxBreakupRet = rowFlightSegmentRet[0]["infantTaxBreakup"].ToString();

                octaxRet = rowFlightSegmentRet[0]["octax"].ToString();
                FlightSegmentsIDRet = rowFlightSegmentRet[0]["FlightSegments_Id"].ToString();
            }

            DataTable dtFlightSegmentsRet = dsFilghts.Tables["FlightSegments"];

            if (dtFlightSegmentsRet.Rows.Count > 0)
            {
                DataRow[] rowFlightSegmentsRet = dtFlightSegmentsRet.Select("FlightSegments_Id=" + FlightSegmentsIDRet);
                originDestination_IdRet = rowFlightSegmentsRet[0]["originDestinationoption_Id"].ToString();
            }
            DataTable dtoriginDestinationoptionRet = dsFilghts.Tables["originDestinationoption"];

            if (dtoriginDestinationoptionRet.Rows.Count > 0)
            {
                DataRow[] roworiginDestinationoptionRet = dtoriginDestinationoptionRet.Select("originDestinationoption_Id=" + originDestination_IdRet);
                idRet = roworiginDestinationoptionRet[0]["id"].ToString();
                keyRet = roworiginDestinationoptionRet[0]["key"].ToString();
            }

            DataTable dtFareDetailsRet = dsFilghts.Tables["FareDetails"];

            if (dtFareDetailsRet.Rows.Count > 0)
            {
                DataRow[] rowFareDetailsRet = dtFareDetailsRet.Select("originDestinationoption_Id=" + originDestination_IdRet);
                fareDetailsIdRet = rowFareDetailsRet[0]["FareDetails_Id"].ToString();
            }

            DataTable dtChargeableFaresRet = dsFilghts.Tables["ChargeableFares"];
            if (dtChargeableFaresRet.Rows.Count > 0)
            {
                DataRow[] rowChargeableFaresRet = dtChargeableFaresRet.Select("FareDetails_Id=" + fareDetailsIdRet);
                actualBaseFareRet = rowChargeableFaresRet[0]["ActualBaseFare"].ToString();
                taxRet = rowChargeableFaresRet[0]["tax"].ToString();
                StaxRet = rowChargeableFaresRet[0]["Stax"].ToString();
                SChargeRet = rowChargeableFaresRet[0]["SCharge"].ToString();
                TDiscountRet = rowChargeableFaresRet[0]["TDiscount"].ToString();
                TPartnerCommissionRet = rowChargeableFaresRet[0]["TPartnerCommission"].ToString();

            }

            DataTable dtNonChargeableFaresRet = dsFilghts.Tables["NonChargeableFares"];
            if (dtNonChargeableFaresRet.Rows.Count > 0)
            {
                DataRow[] rowNonChargeableFaresRet = dtNonChargeableFaresRet.Select("FareDetails_Id=" + fareDetailsIdRet);
                TChargeRet = rowNonChargeableFaresRet[0]["TCharge"].ToString();
                TSdiscountRet = rowNonChargeableFaresRet[0]["TSdiscount"].ToString();
                TMarkupRet = rowNonChargeableFaresRet[0]["TMarkup"].ToString();
            }
            DataTable dtBookingClassRet = dsFilghts.Tables["BookingClass"];
            if (dtBookingClassRet.Rows.Count > 0)
            {
                DataRow[] rowBookingClassRet = dtBookingClassRet.Select("FlightSegment_Id=" + lblReturnFlightSegment.Text);
                BookingClassAvailabilityRet = rowBookingClassRet[0]["Availability"].ToString();
                BookingClassResBookDesigCodeRet = rowBookingClassRet[0]["ResBookDesigCode"].ToString();

            }

            DataTable dtBookingClassfareRet = dsFilghts.Tables["BookingClassFare"];
            if (dtBookingClassfareRet.Rows.Count > 0)
            {
                DataRow[] rowBookingClassFareRet = dtBookingClassfareRet.Select("FlightSegment_Id=" + lblReturnFlightSegment.Text);
                adultFareRet = rowBookingClassFareRet[0]["adultFare"].ToString();
                if (dtBookingClassfareRet.Columns.Contains("childFare"))
                {
                    childFareRet = rowBookingClassFareRet[0]["childFare"].ToString();
                }
                if (dtBookingClassfareRet.Columns.Contains("infantfare"))
                {
                    infantfareRet = rowBookingClassFareRet[0]["infantfare"].ToString();
                }
                bookingclassRet = rowBookingClassFareRet[0]["bookingclass"].ToString();
                classTypeRet = rowBookingClassFareRet[0]["classType"].ToString();
                farebasiscodeRet = rowBookingClassFareRet[0]["farebasiscode"].ToString();
                RuleRet = rowBookingClassFareRet[0]["Rule"].ToString().Replace("<", "&lt;").Replace(">", "&gt;");
                adultCommissionRet = rowBookingClassFareRet[0]["adultCommission"].ToString();
                childCommissionRet = rowBookingClassFareRet[0]["childCommission"].ToString();
                commissionOnTChargeRet = rowBookingClassFareRet[0]["commissionOnTCharge"].ToString();

            }

            #endregion
            #region Pricing

            //String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/> <telePhone>" + txtPhoneNum.Text + "</telePhone><email>" + txtEmailID.Text + "</email> <creditcardno></creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";
            //DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);
            #region Pricing

            String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights>";

            XMLPricing = XMLPricing + "<returnFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFareRet + "</ActualBaseFare><Tax>" + taxRet + "</Tax> <STax>" + StaxRet + "</STax><SCharge>" + SChargeRet + "</SCharge> <TDiscount>" + TDiscountRet + "</TDiscount><TPartnerCommission>" + TPartnerCommissionRet + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TChargeRet + "</TCharge> <TMarkup>" + TMarkupRet + "</TMarkup><TSdiscount>" + TDiscountRet + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><RPH>" + RPHRet + "</RPH> <StopQuantity>" + StopQuantityRet + "</StopQuantity><airLineName>" + airLineNameRet + "</airLineName><airportTax>" + airportTaxRet + "</airportTax><imageFileName>" + imageFileNameRet + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailabilityRet + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCodeRet + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFareRet + "</adultFare><bookingclass>" + bookingclassRet + "</bookingclass> <childFare>" + childFareRet + "</childFare><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><infantfare>" + infantfareRet + "</infantfare> <Rule>" + RuleRet + "</Rule><adultCommission>" + adultCommissionRet + "</adultCommission><childCommission>" + childCommissionRet + "</childCommission><commissionOnTCharge>" + commissionOnTChargeRet + "</commissionOnTCharge></BookingClassFare> <Discount>" + DiscountRet + "</Discount><airportTaxChild>" + airportTaxChildRet + "</airportTaxChild><airportTaxInfant>" + airportTaxInfantRet + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakupRet + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakupRet + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakupRet + "</infantTaxBreakup><octax>" + octaxRet + "</octax> </FlightSegment> </FlightSegments><id>" + idRet + "</id><key>" + keyRet + "</key> </OriginDestinationOption></returnFlights>";

            XMLPricing = XMLPricing + "<telePhone>" + txtPhoneNum.Text + "</telePhone><email>" + txtEmailID.Text + "</email> <creditcardno></creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";

            DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);

            if (!dsFlightPricing.Tables[0].Columns.Contains("error"))
            {
                string ReturnFlightId = dsFlightPricing.Tables["returnFlights"].Rows[0]["ReturnFlights_Id"].ToString();


                DataTable dtchangeFlightSegments = dsFlightPricing.Tables["originDestinationoption"];
                if (dtchangeFlightSegments.Rows.Count > 0)
                {
                    DataRow[] rowchangeFilghtSegments = dtchangeFlightSegments.Select("ReturnFlights_Id=" + ReturnFlightId);
                    originDestination_IdRet = rowchangeFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                }

                DataTable dtchangeFareDetails = dsFlightPricing.Tables[3];
                if (dtchangeFareDetails.Rows.Count > 0)
                {
                    DataRow[] rowchangeFareDetails = dtchangeFareDetails.Select("OriginDestinationOption_Id=" + originDestination_IdRet);
                    fareDetailsIdRet = rowchangeFareDetails[0]["FareDetails_Id"].ToString();
                }

                DataTable dtchangeprice = dsFlightPricing.Tables[4];
                if (dtchangeprice.Rows.Count > 0)
                {
                    DataRow[] rowchangeprices = dtchangeprice.Select("FareDetails_Id=" + fareDetailsIdRet);
                    TPartnerCommissionRet = rowchangeprices[0]["TPartnerCommission"].ToString();
                    actualBaseFareRet = rowchangeprices[0]["ActualBaseFare"].ToString();
                    taxRet = rowchangeprices[0]["Tax"].ToString();
                    StaxRet = rowchangeprices[0]["Stax"].ToString();
                    SChargeRet = rowchangeprices[0]["SCharge"].ToString();
                    TDiscountRet = rowchangeprices[0]["TDiscount"].ToString();
                    TotalFare = (Convert.ToDecimal(actualBaseFare) + Convert.ToDecimal(tax) + Convert.ToDecimal(Stax) + Convert.ToDecimal(SCharge) - Convert.ToDecimal(TDiscount)).ToString();
                }
            }


            #endregion

            #endregion

            string refNo = Common.GetFlightsReferenceNo("LJDF");


            String xmlRequestData = "<Bookingrequest><onwardFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare> <Tax>" + tax + "</Tax><STax>" + Stax + "</STax> <SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TSdiscount + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights>";

            xmlRequestData = xmlRequestData + "<returnFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFareRet + "</ActualBaseFare> <Tax>" + taxRet + "</Tax><STax>" + StaxRet + "</STax> <SCharge>" + SChargeRet + "</SCharge><TDiscount>" + TDiscountRet + "</TDiscount><TPartnerCommission>" + TPartnerCommissionRet + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TChargeRet + "</TCharge> <TMarkup>" + TMarkupRet + "</TMarkup><TSdiscount>" + TSdiscountRet + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><RPH>" + RPHRet + "</RPH> <StopQuantity>" + StopQuantityRet + "</StopQuantity><airLineName>" + airLineNameRet + "</airLineName><airportTax>" + airportTaxRet + "</airportTax><imageFileName>" + imageFileNameRet + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailabilityRet + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCodeRet + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFareRet + "</adultFare><bookingclass>" + bookingclassRet + "</bookingclass> <childFare>" + childFareRet + "</childFare><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><infantfare>" + infantfareRet + "</infantfare> <Rule>" + RuleRet + "</Rule><adultCommission>" + adultCommissionRet + "</adultCommission><childCommission>" + childCommissionRet + "</childCommission><commissionOnTCharge>" + commissionOnTChargeRet + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + DiscountRet + "</Discount><airportTaxChild>" + airportTaxChildRet + "</airportTaxChild><airportTaxInfant>" + airportTaxInfantRet + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakupRet + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakupRet + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakupRet + "</infantTaxBreakup><octax>" + octaxRet + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + idRet + "</id><key>" + keyRet + "</key> </OriginDestinationOption></returnFlights>";

            xmlRequestData = xmlRequestData + "<personName>";
            // Dynamic generation of names of adults, infants , Child
            Table tbladults = (Table)this.UpdatePanel1.FindControl("tblAdults");
            for (int i = 1; i <= adultcnt; i++)
            {

                TextBox txtFn = (TextBox)tbladults.FindControl("txtFn" + i);
                TextBox txtLn = (TextBox)tbladults.FindControl("txtLn" + i);
                DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitle" + i);


                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
            }

            Table tblChild = (Table)this.UpdatePanel1.FindControl("tblChild");
            for (int i = 1; i <= childCnt; i++)
            {
                TextBox txtFn = (TextBox)tblChild.FindControl("txtCFn" + i);

                TextBox txtLn = (TextBox)tblChild.FindControl("txtCLn" + i);

                DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitle" + i);


                TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDate" + i);

                string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
            }

            Table tblInfants = (Table)this.UpdatePanel1.FindControl("tblInfants");
            for (int i = 1; i <= infantCnt; i++)
            {
                TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFn" + i);

                TextBox txtLn = (TextBox)tblInfants.FindControl("txtILn" + i);

                DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitle" + i);

                TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDate" + i);

                string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
            }

            xmlRequestData = xmlRequestData + "</personName><telePhone><phoneNumber>" + txtPhoneNum.Text + "</phoneNumber></telePhone><email><emailAddress>" + txtEmailID.Text + "</emailAddress></email><creditcardno>4111111111111111</creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword> <partnerRefId>" + refNo + "</partnerRefId> <Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + ddlAdult.SelectedItem.Value + "</AdultPax><ChildPax>" + ddlChild.SelectedItem.Value + "</ChildPax><InfantPax>" + ddlInfant.SelectedItem.Value + "</InfantPax></Bookingrequest>";
            DataSet dsBookingResponse = new DataSet();


            //DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            //string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
            //string commisionPercentage = dsBalance.Tables[0].Rows[0]["CommisionPercentage"].ToString();
            //string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

            //string actualFare = lblTotalOnwardReturn.Text;
            //string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
            //    ((Convert.ToDouble(actualFare.ToString()) * Convert.ToInt32(commisionPercentage)) / 100));
            //string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

            //Session["AgentId_Agent"] = agentId;
            //Session["ActualFare_Agent"] = actualFare;
            //Session["CommisionFare_Agent"] = commisionFare;
            //Session["CommisionPercentage_Agent"] = commisionPercentage;
            //Session["DeductAmount_Agent"] = deductAmount;

            //if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
            //{

            dsBookingResponse = objFlights.GetBookingDetails(xmlRequestData);
            //}
            //else { return; }

            string error = string.Empty;


            // If there is any Error -- We wont get the transid instead we get error
            if (dsBookingResponse.Tables[0].Columns.Contains("transid"))
            {
                transId = dsBookingResponse.Tables[0].Rows[0]["transid"].ToString();

                //DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                //                        Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
                //                        Convert.ToDouble(Session["CommisionFare_Agent"].ToString()), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));

                //objBAL = new ClsBAL();
                //DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                //string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                //Label lbl = (Label)this.Master.FindControl("lblBalance");
                //lbl.Text = balance;
                //Session["Balance"] = balanceAgent;



                #region SaveResponse
                FlightBAL objFlightBal = new FlightBAL();

                objFlightBal.ReferenceNo = refNo;
                objFlightBal.TransId = transId;
                objFlightBal.Status = dsBookingResponse.Tables["Bookingresponse"].Rows[0]["status"].ToString();
                objFlightBal.AdultPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["AdultPax"].ToString());
                objFlightBal.InfantPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["InfantPax"].ToString());
                objFlightBal.ChildPax = Convert.ToInt32(dsBookingResponse.Tables["Bookingresponse"].Rows[0]["ChildPax"].ToString());
                objFlightBal.Origin_Destination_Id = dsBookingResponse.Tables["originDestinationOption"].Rows[0]["id"].ToString();
                objFlightBal.Origin_Destination_Key = dsBookingResponse.Tables["originDestinationOption"].Rows[0]["key"].ToString();
                objFlightBal.ActualBasefare = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["ActualBasefare"].ToString());
                objFlightBal.Tax = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["Tax"].ToString());
                objFlightBal.STax = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["STax"].ToString());
                objFlightBal.Scharge = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["Scharge"].ToString());
                objFlightBal.TDiscount = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["TDiscount"].ToString());
                objFlightBal.TPartnerCommission = Convert.ToDecimal(dsBookingResponse.Tables["ChargeableFares"].Rows[0]["TPartnerCommission"].ToString());
                objFlightBal.TCharge = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TCharge"].ToString());
                objFlightBal.TMarkUp = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TMarkUp"].ToString());
                objFlightBal.TSDiscount = Convert.ToDecimal(dsBookingResponse.Tables["NonChargeableFares"].Rows[0]["TSDiscount"].ToString());
                string givenName = string.Empty;
                string surName = string.Empty;
                string namereference = string.Empty;
                string psgrType = string.Empty;
                string Age = string.Empty;
                string customerInfo = string.Empty;


                for (int i = 0; i < dsBookingResponse.Tables["CustomerInfo"].Rows.Count; i++)
                {

                    givenName = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["givenName"].ToString();
                    surName = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["surName"].ToString();
                    namereference = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["nameReference"].ToString();
                    //  psgrType = "adt"; //dsBookingResponse.Tables["CustomerInfo"].Rows[i]["psgrtype"].ToString();


                    string[] str = namereference.ToString().Split(',');
                    if (str[0].ToString() == "C")
                    {
                        psgrType = "Child";
                        Age = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["age"].ToString();
                    }
                    else
                        if (str[0].ToString() == "I")
                        {
                            psgrType = "Infant";
                            Age = dsBookingResponse.Tables["CustomerInfo"].Rows[i]["age"].ToString();
                        }
                        else
                        {
                            psgrType = "Adt";
                        }


                    //   psgrType = "";// dsBookingResponse.Tables["CustomerInfo"].Rows[i]["psgrtype"].ToString();

                    if (psgrType.ToString() != "Adt")
                    {
                        if (customerInfo == string.Empty)
                        {
                            customerInfo = str[1].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                        else
                        {
                            customerInfo = customerInfo + ";" + str[1].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                    }
                    else
                    {
                        if (customerInfo == string.Empty)
                        {
                            customerInfo = str[0].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                        else
                        {
                            customerInfo = customerInfo + ";" + str[0].ToString() + "|" + givenName + "|" + surName + "|" + psgrType + "|" + Age;
                        }
                    }
                    //if (customerInfo == string.Empty)
                    //{
                    //    customerInfo = namereference + "|" + givenName + "|" + surName + "|" + psgrType;
                    //}
                    //else
                    //{
                    //    customerInfo = customerInfo + ";" + namereference + "|" + givenName + "|" + surName + "|" + psgrType;
                    //}

                }
                objFlightBal.Customer_Details = customerInfo;
                objFlightBal.telephone = dsBookingResponse.Tables["telePhone"].Rows[0]["PhoneNumber"].ToString();
                objFlightBal.emailAddress = lblEmailAddress.Text = dsBookingResponse.Tables["email"].Rows[0]["emailAddress"].ToString();
                objFlightBal.TripMode = "Round";


                DataTable dtflightBookingId = objFlightBal.AddDomesticFlightBooking(objFlightBal);
                string flightBookingId = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                objFlightBal.FlightBookingID = flightBookingId.ToString();
                if (dsBookingResponse.Tables["FlightSegment"].Rows.Count > 0)
                {
                    for (int j = 0; j < dsBookingResponse.Tables["FlightSegment"].Rows.Count; j++)
                    {
                        objFlightBal.AirEquipType = dsBookingResponse.Tables["FlightSegment"].Rows[0]["AirEquipType"].ToString();
                        objFlightBal.ArrivalAirportCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ArrivalAirportCode"].ToString();
                        objFlightBal.ArrivalDateTime = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ArrivalDateTime"].ToString();
                        objFlightBal.DepartureAirportCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["DepartureAirportCode"].ToString();
                        objFlightBal.DepartureDateTime = dsBookingResponse.Tables["FlightSegment"].Rows[0]["DepartureDateTime"].ToString();
                        objFlightBal.FlightNumber = dsBookingResponse.Tables["FlightSegment"].Rows[0]["FlightNumber"].ToString();
                        objFlightBal.OperatingAirlineCode = dsBookingResponse.Tables["FlightSegment"].Rows[0]["OperatingAirlineCode"].ToString();
                        objFlightBal.OperatingAirlineFlightNumber = dsBookingResponse.Tables["FlightSegment"].Rows[0]["OperatingAirlineFlightNumber"].ToString();
                        objFlightBal.RPH = dsBookingResponse.Tables["FlightSegment"].Rows[0]["RPH"].ToString();
                        objFlightBal.StopQuantity = dsBookingResponse.Tables["FlightSegment"].Rows[0]["StopQuantity"].ToString();
                        objFlightBal.airlineName = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airlineName"].ToString();
                        objFlightBal.airportTax = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTax"].ToString();
                        objFlightBal.imageFileName = dsBookingResponse.Tables["FlightSegment"].Rows[0]["imageFileName"].ToString();
                        objFlightBal.Discount = dsBookingResponse.Tables["FlightSegment"].Rows[0]["Discount"].ToString();
                        objFlightBal.airportTaxChild = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTaxChild"].ToString();
                        objFlightBal.airportTaxInfant = dsBookingResponse.Tables["FlightSegment"].Rows[0]["airportTaxInfant"].ToString();
                        objFlightBal.adultTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["adultTaxBreakUp"].ToString();
                        objFlightBal.ChildTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ChildTaxBreakUp"].ToString();
                        objFlightBal.InfantTaxBreakUp = dsBookingResponse.Tables["FlightSegment"].Rows[0]["InfantTaxBreakUp"].ToString();
                        objFlightBal.ocTax = dsBookingResponse.Tables["FlightSegment"].Rows[0]["ocTax"].ToString();
                        objFlightBal.Availability = dsBookingResponse.Tables["BookingClass"].Rows[0]["Availability"].ToString();
                        objFlightBal.ResBookingCode = dsBookingResponse.Tables["BookingClass"].Rows[0]["ResBookDesigCode"].ToString();
                        objFlightBal.adultFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["adultFare"].ToString();
                        objFlightBal.bookingClass = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["bookingClass"].ToString();
                        objFlightBal.ChildFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["ChildFare"].ToString();
                        objFlightBal.ClassType = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["ClassType"].ToString();
                        objFlightBal.farebasisCode = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["farebasisCode"].ToString();
                        objFlightBal.infantFare = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["infantFare"].ToString();
                        objFlightBal.Fare_Rule = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["Rule"].ToString();
                        objFlightBal.adultCommission = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["adultCommission"].ToString();
                        objFlightBal.childCommission = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["childCommission"].ToString();
                        objFlightBal.CommissionOnTCharge = dsBookingResponse.Tables["BookingClassFare"].Rows[0]["CommissionOnTCharge"].ToString();

                        objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        bool res = objFlightBal.AddDomesticFlightBookingsegments(objFlightBal);
                        if (res)
                        {

                            GetDetailsForPrint(objFlightBal.ReferenceNo.ToString());
                            lbtnmail.Visible = false;
                            lbtnmail_Click1(sender, e);
                            pnlPassengerDet.Visible = false;
                            lblStatus.Visible = true;
                            lblStatus.Text = "Ticket has been booked successfully. Reference Number is : " + objFlightBal.ReferenceNo.ToString();
                            lblStatus.ForeColor = System.Drawing.Color.Green;

                        }

                #endregion

                        else
                        {
                            error = dsBookingResponse.Tables[0].Rows[0]["error"].ToString();
                            lblStatus.Text = error;
                            lblStatus.ForeColor = System.Drawing.Color.Red;

                        }
                    }
                }
            }
            else
            {
                lblStatus.Text = dsBookingResponse.Tables[0].Rows[0]["Error"].ToString();
                lblStatus.Visible = true;
            }


        }
        catch (Exception ex)
        {

        }

    }


    DataView dvstop;
    DataSet dd;
    bool checkzero;
    bool checkone;
    bool checktwo;
    bool price = false;
    protected void JetAirways(object sender, EventArgs e)
    {
        try
        {
            Valuechanged(sender, e);
            DataTable dt2 = new DataTable();
            dt2.TableName = "MM";
            dt2.Columns.Add("AirEquipType");
            dt2.Columns.Add("ArrivalAirportName");
            dt2.Columns.Add("ArrivalAirportCode");
            dt2.Columns.Add("DepartureAirportCode");
            dt2.Columns.Add("ArrivalDateTime");
            dt2.Columns.Add("DepartureAirportName");
            dt2.Columns.Add("DepartureDateTime");
            dt2.Columns.Add("FlightNumer");
            dt2.Columns.Add("MarketingAirlineCode");
            dt2.Columns.Add("OperatingAirlineCode");
            dt2.Columns.Add("OperatingAirlineName");
            dt2.Columns.Add("OperatingAirlineFlightNumber");
            dt2.Columns.Add("NumStops");
            dt2.Columns.Add("LinksellAgrmnt");
            dt2.Columns.Add("Conx");
            dt2.Columns.Add("AirpChg");
            dt2.Columns.Add("InsideAvailOption");
            dt2.Columns.Add("GenTranfRestriction");
            dt2.Columns.Add("DaysOperates");
            dt2.Columns.Add("JmyTm");
            dt2.Columns.Add("EndDt");
            dt2.Columns.Add("StartTerminal");
            dt2.Columns.Add("EndTerminal");
            dt2.Columns.Add("FltTm");
            dt2.Columns.Add("LsaInd");
            dt2.Columns.Add("Mile");
            dt2.Columns.Add("FlightSegment_Id");
            dt2.Columns.Add("FlightSegments_Id");
            dt2.Columns.Add("RPH");
            dt2.Columns.Add("StopQuantity");
            dt2.Columns.Add("airportTax");
            dt2.Columns.Add("imageFileName");
            dt2.Columns.Add("ViaFlight");
            dt2.Columns.Add("airportTaxChild");
            dt2.Columns.Add("airportTaxInfant");
            dt2.Columns.Add("adultTaxBreakup");
            dt2.Columns.Add("childTaxBreakup");

            dt2.Columns.Add("infantTaxBreakup");
            dt2.Columns.Add("octax");
            dt2.Columns.Add("airLineName"); dt2.Columns.Add("FlightNumber");
            if (ViewState["dt2"] != null)
            {
                DataTable dtstop = (DataTable)ViewState["dt2"];
                dvstop = dtstop.DefaultView;
            }
            if (chkjetlite.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkjetlite.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }

                }
            }
            if (chkAirIndia.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkAirIndia.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
            }
            if (chkJetAirways.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkJetAirways.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
            }
            if (chkstop0.Checked == true)
            {
                dvstop.RowFilter = "NumStops=0";
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }
                if (dvstop.Count > 0)
                {
                    checkzero = true;
                }
                else
                {
                    checkzero = false;
                }
            }
            else
            {
                checkzero = false;
            }
            if (Chkstop1.Checked == true)
            {
                dvstop.RowFilter = "NumStops=1";
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }
                if (dvstop.Count > 0)
                {
                    checkone = true;
                }
                else
                {
                    if (checkzero == true)
                    { }
                    else
                    {
                        if (checktwo == true)
                        {
                        }
                        else
                        {
                            dvstop.Table.AcceptChanges();
                            dt2 = dvstop.ToTable();
                            checkone = false;
                        }
                    }
                }
            }
            else
            {
                checkone = false;
            }
            if (Chkstop2.Checked == true)
            {
                dvstop.RowFilter = "NumStops=2";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
                else
                {
                    if (checkzero == true || checkone == true)
                    {

                    }
                    else
                    {
                        dvstop.Table.AcceptChanges();
                        dt2 = dvstop.ToTable();
                    }
                }
            }
            else
            {
                if (ViewState["dt2"] != null)
                {
                    DataTable dtstop = (DataTable)ViewState["dt2"];
                    dvstop = dtstop.DefaultView;
                }
                if (chkjetlite.Checked == true)
                {
                    dvstop.RowFilter = "OperatingAirlineName='" + chkjetlite.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }

                    }
                }
                if (chkAirIndia.Checked == true)
                {
                    dvstop.RowFilter = "OperatingAirlineName='" + chkAirIndia.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }
                    }
                }
                if (chkJetAirways.Checked == true)
                {
                    dvstop.RowFilter = "OperatingAirlineName='" + chkJetAirways.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }
                    }
                }
                if (dt2.Rows.Count > 0)
                {

                }
                else
                {
                    if (rbtnOneWay.Checked == true)
                    {
                        gdvFlights.DataSource = dvstop;
                        gdvFlights.DataBind();
                        return;
                    }
                    else
                    {

                    }
                }


            }
            // dt2.AcceptChanges();

            if (dt2.Rows.Count > 0)
            {
                if (rbtnOneWay.Checked == true)
                {

                    gdvFlights.DataSource = dt2;
                    gdvFlights.DataBind();
                }
                else
                {
                }

            }
            else
            {
                if (rbtnOneWay.Checked == true)
                {
                    gdvFlights.DataSource = dt2;
                    gdvFlights.DataBind();
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    DataTable dtdt;
    DataView dv;
    bool bl = true;
    string fareDetailsId;



    protected void Valuechanged(object sender, EventArgs e)
    {
        try
        {
            dsFilghts = (DataSet)Session["dsIntFlights"];
            if (rbtnOneWay.Checked == true)
            {
                #region oneway

                if (Chkstop1.Checked == false || Chkstop1.Checked == false)
                {
                    if (Session["dsIntFlights"] != null)
                    {

                        if (Session["dtmodify"] == null)
                        {
                            DataSet dd = (DataSet)Session["dsIntFlights"];
                            DataTable dt = dd.Tables[6];
                            // dt.Clone();
                            dt.Columns.Add("TotalFare");
                            foreach (DataRow dtnew in dt.Rows)
                            {
                                int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) - Convert.ToInt32(dtnew["TDiscount"]);
                                dtnew["TotalFare"] = str.ToString();
                            }
                            Session["dtmodify"] = dt;
                            dv = dt.DefaultView;
                            bl = false;
                        }
                        else
                        {
                            DataTable dtmodify = (DataTable)Session["dtmodify"];
                            dv = dtmodify.DefaultView;
                            bl = true;
                        }




                        dv.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                        dv.Table.AcceptChanges();

                        int id = dv.Count;
                        // = new DataTable();
                        DataTable dtdv = dv.ToTable();
                        if (id != null)
                        {
                            dsIntFlights = (DataSet)Session["dsIntFlights"];
                            DataView dv1 = dsIntFlights.Tables[9].DefaultView;
                            DataTable dt2 = new DataTable();
                            dt2.TableName = "MM";
                            dt2.Columns.Add("AirEquipType");
                            dt2.Columns.Add("ArrivalAirportName");

                            dt2.Columns.Add("ArrivalDateTime");
                            dt2.Columns.Add("DepartureAirportName");
                            dt2.Columns.Add("ArrivalAirportCode");
                            dt2.Columns.Add("DepartureAirportCode");
                            dt2.Columns.Add("DepartureDateTime");
                            dt2.Columns.Add("FlightNumer");
                            dt2.Columns.Add("MarketingAirlineCode");
                            dt2.Columns.Add("OperatingAirlineCode");
                            dt2.Columns.Add("OperatingAirlineName");
                            dt2.Columns.Add("OperatingAirlineFlightNumber");
                            dt2.Columns.Add("NumStops");
                            dt2.Columns.Add("LinksellAgrmnt");
                            dt2.Columns.Add("Conx");
                            dt2.Columns.Add("AirpChg");
                            dt2.Columns.Add("InsideAvailOption");
                            dt2.Columns.Add("GenTranfRestriction");
                            dt2.Columns.Add("DaysOperates");
                            dt2.Columns.Add("JmyTm");
                            dt2.Columns.Add("EndDt");
                            dt2.Columns.Add("StartTerminal");
                            dt2.Columns.Add("EndTerminal");
                            dt2.Columns.Add("FltTm");
                            dt2.Columns.Add("LsaInd");
                            dt2.Columns.Add("Mile");
                            dt2.Columns.Add("FlightSegment_Id");
                            dt2.Columns.Add("FlightSegments_Id");
                            dt2.Columns.Add("RPH");
                            dt2.Columns.Add("StopQuantity");
                            dt2.Columns.Add("airportTax");
                            dt2.Columns.Add("imageFileName");
                            dt2.Columns.Add("ViaFlight");
                            dt2.Columns.Add("airportTaxChild");
                            dt2.Columns.Add("airportTaxInfant");
                            dt2.Columns.Add("adultTaxBreakup");
                            dt2.Columns.Add("childTaxBreakup");
                            dt2.Columns.Add("infantTaxBreakup");
                            dt2.Columns.Add("octax");

                            dt2.Columns.Add("airLineName"); dt2.Columns.Add("FlightNumber");
                            foreach (DataRow dr in dtdv.Rows)
                            {
                                dv1.RowFilter = "FlightSegment_Id='" + dr["FareDetails_Id"] + "'";
                                dv1.Table.Clone();

                                foreach (DataRowView datav in dv1)
                                {
                                    // dtdt.TableName = "MM";

                                    dt2.ImportRow(datav.Row);// = dv1.row;
                                }

                            }
                            dv1.Table.AcceptChanges();
                            int v = dv1.Count;
                            gdvFlights.DataSource = dt2;
                            ViewState["dt2"] = dt2;
                            DataTable dttt = (DataTable)dv.ToTable();
                            ViewState["dv"] = dttt;
                            gdvFlights.DataBind();
                            ViewState["dv"] = null;
                        }
                        else
                        {

                            // Label5.Text = tbUse.Text;
                        }
                    }
                }
                else
                {


                }
                #endregion
            }
            else
            {

                if (Session["dsIntFlights"] != null)
                {
                    if (Session["DtOnWardFlights"] != null && Session["DtReturnFlights"] != null)
                    {
                        Session["dsIntFlights"] = dsFilghts;
                        string responseDepartId = string.Empty;
                        string responseReturnId = string.Empty;
                        string OriginDestinationOptionsId = string.Empty;
                        // For Onward Flights
                        string ArzooResponseId = dsFilghts.Tables[0].Rows[0]["arzoo__response_Id"].ToString();


                        DataTable dtResponse_Depart = dsFilghts.Tables["Response__Depart"];
                        if (dtResponse_Depart.Rows.Count > 0)
                        {
                            DataRow[] row = dtResponse_Depart.Select("arzoo__response_Id=" + ArzooResponseId);
                            responseDepartId = row[0]["Response__Depart_Id"].ToString();
                        }


                        DataTable dtOriginDestinationOptions = dsFilghts.Tables["OriginDestinationOptions"];
                        if (dtOriginDestinationOptions.Rows.Count > 0)
                        {
                            DataRow[] row = dtOriginDestinationOptions.Select("Response__Depart_Id=" + responseDepartId);
                            OriginDestinationOptionsId = row[0]["OriginDestinationOptions_Id"].ToString();

                        }
                        DataTable dtOriginDestinationOption = dsFilghts.Tables["OriginDestinationOption"];
                        DataTable dtChargeableFares = dsFilghts.Tables[6];
                        DataTable dtNewFlightSegments = dtChargeableFares.Clone();
                        if (dtOriginDestinationOption.Rows.Count > 0)
                        {
                            DataRow[] row = dtOriginDestinationOption.Select("OriginDestinationOptions_Id=" + OriginDestinationOptionsId);
                            for (int i = 0; i < row.Length; i++)
                            {
                                DataRow[] rowFlightSegments = dtChargeableFares.Select("FareDetails_Id=" + row[i]["OriginDestinationOption_Id"].ToString());//OriginDestinationOption_Id
                                foreach (DataRow dr in rowFlightSegments)
                                {
                                    dtNewFlightSegments.ImportRow(dr);
                                }
                            }
                        }
                        dsFilghts = (DataSet)Session["dsIntFlights"];
                        // DataTable dtChargeableFares = dsFilghts.Tables[6];
                        //DataTable dtget = new DataTable("dtget");
                        ////  dtget.TableName = "dt";
                        //dtget.Columns.Add("ActualBaseFare");
                        //dtget.Columns.Add("Tax");

                        //dtget.Columns.Add("Stax");
                        //dtget.Columns.Add("SCharge");
                        //dtget.Columns.Add("TDiscount");
                        //dtget.Columns.Add("TPartnerCommission");
                        //dtget.Columns.Add("FareDetails_Id");

                        //if (dtChargeableFares.Rows.Count > 0)
                        //{
                        //    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                        //    foreach (DataRow dr in rowChargeableFareDetails)
                        //    {
                        //        dtget.ImportRow(dr);
                        //    }
                        //}
                        dtNewFlightSegments.Columns.Add("TotalFare");


                        //Bindu
                        //foreach (DataRow dr in dtChargeableFares.Rows)
                        //{
                        //    dtNewFlightSegments.ImportRow(dr);
                        //}

                        foreach (DataRow dtnew in dtNewFlightSegments.Rows)
                        {
                            int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) - Convert.ToInt32(dtnew["TDiscount"]);
                            dtnew["TotalFare"] = str.ToString();
                        }
                        Session["dtmodify"] = dtNewFlightSegments;
                        Session["dsIntFlights"] = dd;
                        dv = dtNewFlightSegments.DefaultView;
                        ///return fare details
                        DataTable dtResponse_Return = dsFilghts.Tables["Response__Return"];
                        if (dtResponse_Return.Rows.Count > 0)
                        {
                            DataRow[] row = dtResponse_Return.Select("arzoo__response_Id=" + ArzooResponseId);
                            responseReturnId = row[0]["Response__Return_Id"].ToString();
                        }

                        string OriginDestinationOptionsIdRet = string.Empty;
                        DataTable dtOriginDestinationOptionsRet = dsFilghts.Tables["OriginDestinationOptions"];
                        if (dtOriginDestinationOptionsRet.Rows.Count > 0)
                        {
                            DataRow[] row = dtOriginDestinationOptionsRet.Select("Response__Return_Id=" + responseReturnId);
                            OriginDestinationOptionsIdRet = row[0]["OriginDestinationOptions_Id"].ToString();

                        }
                        DataTable dtOriginDestinationOptionRet = dsFilghts.Tables["OriginDestinationOption"];
                        DataTable dtFlightSegmentsRet = dsFilghts.Tables["FlightSegments"];
                        DataTable dtNewFlightSegmentsRet = dtFlightSegmentsRet.Clone();
                        if (dtOriginDestinationOptionRet.Rows.Count > 0)
                        {
                            DataRow[] row = dtOriginDestinationOptionRet.Select("OriginDestinationOptions_Id=" + OriginDestinationOptionsIdRet);
                            for (int i = 0; i < row.Length; i++)
                            {
                                DataRow[] rowFlightSegments = dtFlightSegmentsRet.Select("OriginDestinationOption_Id=" + row[i]["OriginDestinationOption_Id"].ToString());
                                foreach (DataRow dr in rowFlightSegments)
                                {
                                    dtNewFlightSegmentsRet.ImportRow(dr);
                                }
                            }
                        }

                        DataTable dtNewFlightSegmentRet = dtChargeableFares.Clone();
                        if (dtNewFlightSegmentsRet.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtNewFlightSegmentsRet.Rows.Count; i++)
                            {
                                DataRow[] rowFlightSegmentRet = dtChargeableFares.Select("FareDetails_Id=" + dtNewFlightSegmentsRet.Rows[i]["FlightSegments_Id"].ToString());
                                foreach (DataRow dr in rowFlightSegmentRet)
                                {
                                    dtNewFlightSegmentRet.ImportRow(dr);
                                }
                            }
                        }
                        //DataTable dtreturn = new DataTable("dtreturn");
                        //dtreturn.Columns.Add("ActualBaseFare");
                        //dtreturn.Columns.Add("Tax");

                        //dtreturn.Columns.Add("Stax");
                        //dtreturn.Columns.Add("SCharge");
                        //dtreturn.Columns.Add("TDiscount");
                        //dtreturn.Columns.Add("TPartnerCommission");
                        //dtreturn.Columns.Add("FareDetails_Id");
                        //if (dtChargeableFares.Rows.Count > 0)
                        //{
                        //    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                        //    foreach (DataRow dr in rowChargeableFareDetails)
                        //    {
                        //        dtreturn.ImportRow(dr);
                        //    }
                        //}


                        dtNewFlightSegmentRet.Columns.Add("TotalFare");
                        foreach (DataRow dtnew in dtNewFlightSegmentRet.Rows)
                        {
                            int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) - Convert.ToInt32(dtnew["TDiscount"]);
                            dtnew["TotalFare"] = str.ToString();
                        }
                        Session["dtmodifyreturn"] = dtNewFlightSegmentsRet;
                        dvstop = dtNewFlightSegmentRet.DefaultView;
                        bl = false;
                        //}
                        //else
                        //{
                        //    DataTable dtmodify = (DataTable)Session["dtmodify"];
                        //    dv = null;
                        //    dv = dtmodify.DefaultView;
                        //    DataTable dtmodifyreturn = (DataTable)Session["dtmodifyreturn"];
                        //    dvstop = dtmodifyreturn.DefaultView;
                        //    bl = true;
                        //}
                        dv.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                        dv.Table.AcceptChanges();

                        int id = dv.Count;
                        Session["dsIntFlights"] = dsFilghts;
                        DataTable dtdv = dv.ToTable();
                        if (id != null)
                        {
                            DataTable dtonward = (DataTable)Session["DtOnWardFlights"];
                            DataView dv1 = dtonward.DefaultView;
                            DataTable dt2 = new DataTable("dt2");
                            // dt2.TableName = "MM";
                            dt2.Columns.Add("AirEquipType");
                            dt2.Columns.Add("ArrivalAirportName");

                            dt2.Columns.Add("ArrivalDateTime");
                            dt2.Columns.Add("DepartureAirportName");
                            dt2.Columns.Add("ArrivalAirportCode");
                            dt2.Columns.Add("DepartureAirportCode");
                            dt2.Columns.Add("DepartureDateTime");
                            dt2.Columns.Add("FlightNumer");
                            dt2.Columns.Add("MarketingAirlineCode");
                            dt2.Columns.Add("OperatingAirlineCode");
                            dt2.Columns.Add("OperatingAirlineName");
                            dt2.Columns.Add("OperatingAirlineFlightNumber");
                            dt2.Columns.Add("NumStops");
                            dt2.Columns.Add("LinksellAgrmnt");
                            dt2.Columns.Add("Conx");
                            dt2.Columns.Add("AirpChg");
                            dt2.Columns.Add("InsideAvailOption");
                            dt2.Columns.Add("GenTranfRestriction");
                            dt2.Columns.Add("DaysOperates");
                            dt2.Columns.Add("JmyTm");
                            dt2.Columns.Add("EndDt");
                            dt2.Columns.Add("StartTerminal");
                            dt2.Columns.Add("EndTerminal");
                            dt2.Columns.Add("FltTm");
                            dt2.Columns.Add("LsaInd");
                            dt2.Columns.Add("Mile");
                            dt2.Columns.Add("FlightSegment_Id");
                            dt2.Columns.Add("FlightSegments_Id");
                            dt2.Columns.Add("RPH");
                            dt2.Columns.Add("StopQuantity");
                            dt2.Columns.Add("airportTax");
                            dt2.Columns.Add("imageFileName");
                            dt2.Columns.Add("ViaFlight");
                            dt2.Columns.Add("airportTaxChild");
                            dt2.Columns.Add("airportTaxInfant");
                            dt2.Columns.Add("adultTaxBreakup");
                            dt2.Columns.Add("childTaxBreakup");
                            dt2.Columns.Add("infantTaxBreakup");
                            dt2.Columns.Add("octax");

                            dt2.Columns.Add("airLineName");
                            dt2.Columns.Add("FlightNumber");
                            foreach (DataRow dr in dtdv.Rows)
                            {
                                dv1.RowFilter = "FlightSegments_Id='" + dr["FareDetails_Id"] + "'";///s
                                dv1.Table.Clone();

                                foreach (DataRowView datav in dv1)
                                {
                                    // dtdt.TableName = "MM";

                                    dt2.ImportRow(datav.Row);// = dv1.row;
                                }

                            }
                            dv1.Table.AcceptChanges();
                            int v = dv1.Count;
                            dd = (DataSet)Session["dsIntFlights"];
                            Session["dsIntFlights"] = dd;
                            Session["dt4"] = dt2;
                            // gdvOnward.DataSource = dt2;
                            //gdvOnward.DataBind();


                            ///return

                            dvstop.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                            dvstop.Table.AcceptChanges();

                            int id1 = dvstop.Count;
                            // = new DataTable();
                            DataTable dtdv1 = dvstop.ToTable();
                            if (id != null)
                            {
                                DataTable dtback = (DataTable)Session["DtReturnFlights"];
                                DataView dv2 = dtback.DefaultView;
                                DataTable dt3 = new DataTable();
                                dt3.TableName = "returnMM";
                                dt3.Columns.Add("AirEquipType");
                                dt3.Columns.Add("ArrivalAirportName");

                                dt3.Columns.Add("ArrivalDateTime");
                                dt3.Columns.Add("DepartureAirportName");
                                dt3.Columns.Add("ArrivalAirportCode");
                                dt3.Columns.Add("DepartureAirportCode");
                                dt3.Columns.Add("DepartureDateTime");
                                dt3.Columns.Add("FlightNumer");
                                dt3.Columns.Add("MarketingAirlineCode");
                                dt3.Columns.Add("OperatingAirlineCode");
                                dt3.Columns.Add("OperatingAirlineName");
                                dt3.Columns.Add("OperatingAirlineFlightNumber");
                                dt3.Columns.Add("NumStops");
                                dt3.Columns.Add("LinksellAgrmnt");
                                dt3.Columns.Add("Conx");
                                dt3.Columns.Add("AirpChg");
                                dt3.Columns.Add("InsideAvailOption");
                                dt3.Columns.Add("GenTranfRestriction");
                                dt3.Columns.Add("DaysOperates");
                                dt3.Columns.Add("JmyTm");
                                dt3.Columns.Add("EndDt");
                                dt3.Columns.Add("StartTerminal");
                                dt3.Columns.Add("EndTerminal");
                                dt3.Columns.Add("FltTm");
                                dt3.Columns.Add("LsaInd");
                                dt3.Columns.Add("Mile");
                                dt3.Columns.Add("FlightSegment_Id");
                                dt3.Columns.Add("FlightSegments_Id");
                                dt3.Columns.Add("RPH");
                                dt3.Columns.Add("StopQuantity");
                                dt3.Columns.Add("airportTax");
                                dt3.Columns.Add("imageFileName");
                                dt3.Columns.Add("ViaFlight");
                                dt3.Columns.Add("airportTaxChild");
                                dt3.Columns.Add("airportTaxInfant");
                                dt3.Columns.Add("adultTaxBreakup");
                                dt3.Columns.Add("childTaxBreakup");
                                dt3.Columns.Add("infantTaxBreakup");
                                dt3.Columns.Add("octax");

                                dt3.Columns.Add("airLineName");
                                dt3.Columns.Add("FlightNumber");
                                foreach (DataRow dr in dtdv1.Rows)
                                {
                                    dv2.RowFilter = "FlightSegments_Id='" + dr["FareDetails_Id"] + "'";///s
                                    dv2.Table.Clone();

                                    foreach (DataRowView datav in dv2)
                                    {
                                        // dtdt.TableName = "MM";

                                        dt3.ImportRow(datav.Row);// = dv1.row;
                                    }

                                }
                                dv2.Table.AcceptChanges();
                                int v1 = dv2.Count;
                                Session["dsIntFlights"] = dd;
                                Session["dt3"] = dt3;
                                //  gdvReturn.DataSource = dt3;
                                //  gdvReturn.DataBind();



                            }
                        }


                    }
                }
            }

            lbl.Text = HiddenField1.Value;
            lbl11.Text = HiddenField2.Value;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void sliderTwo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void NextDate(object sender, EventArgs e)
    {
        try
        {
            if (rbtnRoundTrip.Checked == true)
            {
                DateTime Cdt = Convert.ToDateTime(txtFromDate.Text);
                Cdt = Cdt.AddDays(1);
                txtReturnDate.Text = Cdt.ToString("yyyy-MM-dd");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void JetAirwaysReturn(object sender, EventArgs e)
    {
        try
        {
            Valuechanged(sender, e);
            #region round

            DataTable dt2 = new DataTable();
            dt2.TableName = "MM";
            dt2.Columns.Add("AirEquipType");
            //   dt2.Columns.Add("ArrivalAirportName");
            dt2.Columns.Add("ArrivalAirportCode");
            dt2.Columns.Add("DepartureAirportCode");
            dt2.Columns.Add("ArrivalDateTime");
            dt2.Columns.Add("DepartureAirportName");
            dt2.Columns.Add("DepartureDateTime");
            dt2.Columns.Add("FlightNumer");
            dt2.Columns.Add("MarketingAirlineCode");
            dt2.Columns.Add("OperatingAirlineCode");
            dt2.Columns.Add("OperatingAirlineName");
            dt2.Columns.Add("OperatingAirlineFlightNumber");
            dt2.Columns.Add("NumStops");
            dt2.Columns.Add("LinksellAgrmnt");
            dt2.Columns.Add("Conx");
            dt2.Columns.Add("AirpChg");
            dt2.Columns.Add("InsideAvailOption");
            dt2.Columns.Add("GenTranfRestriction");
            dt2.Columns.Add("DaysOperates");
            dt2.Columns.Add("JmyTm");
            dt2.Columns.Add("EndDt");
            dt2.Columns.Add("StartTerminal");
            dt2.Columns.Add("EndTerminal");
            dt2.Columns.Add("FltTm");
            dt2.Columns.Add("LsaInd");
            dt2.Columns.Add("Mile");
            dt2.Columns.Add("FlightSegment_Id");
            dt2.Columns.Add("FlightSegments_Id");
            dt2.Columns.Add("RPH");
            dt2.Columns.Add("StopQuantity");
            dt2.Columns.Add("airportTax");
            dt2.Columns.Add("imageFileName");
            dt2.Columns.Add("ViaFlight");
            dt2.Columns.Add("airportTaxChild");
            dt2.Columns.Add("airportTaxInfant");
            dt2.Columns.Add("adultTaxBreakup");
            dt2.Columns.Add("childTaxBreakup");

            dt2.Columns.Add("infantTaxBreakup");
            dt2.Columns.Add("octax");
            dt2.Columns.Add("airLineName");
            dt2.Columns.Add("FlightNumber");
            if (Session["dt4"] != null)
            {
                DataTable dtstop = (DataTable)Session["dt4"];
                dvstop = dtstop.DefaultView;
            }
            DataTable dt3 = new DataTable();
            dt3.TableName = "returnMM";
            dt3.Columns.Add("AirEquipType");
            //   dt3.Columns.Add("ArrivalAirportName");

            dt3.Columns.Add("ArrivalDateTime");
            dt3.Columns.Add("DepartureAirportName");
            dt3.Columns.Add("ArrivalAirportCode");
            dt3.Columns.Add("DepartureAirportCode");
            dt3.Columns.Add("DepartureDateTime");
            dt3.Columns.Add("FlightNumer");
            dt3.Columns.Add("MarketingAirlineCode");
            dt3.Columns.Add("OperatingAirlineCode");
            dt3.Columns.Add("OperatingAirlineName");
            dt3.Columns.Add("OperatingAirlineFlightNumber");
            dt3.Columns.Add("NumStops");
            dt3.Columns.Add("LinksellAgrmnt");
            dt3.Columns.Add("Conx");
            dt3.Columns.Add("AirpChg");
            dt3.Columns.Add("InsideAvailOption");
            dt3.Columns.Add("GenTranfRestriction");
            dt3.Columns.Add("DaysOperates");
            dt3.Columns.Add("JmyTm");
            dt3.Columns.Add("EndDt");
            dt3.Columns.Add("StartTerminal");
            dt3.Columns.Add("EndTerminal");
            dt3.Columns.Add("FltTm");
            dt3.Columns.Add("LsaInd");
            dt3.Columns.Add("Mile");
            dt3.Columns.Add("FlightSegment_Id");
            dt3.Columns.Add("FlightSegments_Id");
            dt3.Columns.Add("RPH");
            dt3.Columns.Add("StopQuantity");
            dt3.Columns.Add("airportTax");
            dt3.Columns.Add("imageFileName");
            dt3.Columns.Add("ViaFlight");
            dt3.Columns.Add("airportTaxChild");
            dt3.Columns.Add("airportTaxInfant");
            dt3.Columns.Add("adultTaxBreakup");
            dt3.Columns.Add("childTaxBreakup");
            dt3.Columns.Add("infantTaxBreakup");
            dt3.Columns.Add("octax");

            dt3.Columns.Add("airLineName");
            dt3.Columns.Add("FlightNumber");
            if (Session["dt3"] != null)
            {
                DataTable dtstop = (DataTable)Session["dt3"];
                dv = dtstop.DefaultView;
            }
            if (chkjetlite.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkjetlite.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }

                }
                dv.RowFilter = "airLineName='" + chkjetlite.Text + "'";
                if (dv.Count > 0)
                {
                    foreach (DataRowView rows in dv)
                    {
                        dt3.ImportRow(rows.Row);
                    }

                }
            }
            if (chkAirIndia.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkAirIndia.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
                dv.RowFilter = "airLineName='" + chkAirIndia.Text + "'";
                if (dv.Count > 0)
                {
                    foreach (DataRowView rows in dv)
                    {
                        dt3.ImportRow(rows.Row);
                    }
                }
            }
            if (chkJetAirways.Checked == true)
            {
                dvstop.RowFilter = "airLineName='" + chkJetAirways.Text + "'";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
                dv.RowFilter = "airLineName='" + chkJetAirways.Text + "'";
                if (dv.Count > 0)
                {
                    foreach (DataRowView rows in dv)
                    {
                        dt3.ImportRow(rows.Row);
                    }
                }
            }
            if (chkstop0.Checked == true)
            {
                dvstop.RowFilter = "NumStops=0";
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }
                if (dvstop.Count > 0)
                {
                    checkzero = true;
                }
                else
                {
                    checkzero = false;
                }
                dv.RowFilter = "NumStops=0";
                foreach (DataRowView rows in dv)
                {
                    dt3.ImportRow(rows.Row);
                }
                if (dv.Count > 0)
                {
                    checkzero = true;
                }
                else
                {
                    checkzero = false;
                }
            }
            else
            {
                checkzero = false;
            }
            if (Chkstop1.Checked == true)
            {
                dvstop.RowFilter = "NumStops=1";
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }
                if (dvstop.Count > 0)
                {
                    checkone = true;
                }
                else
                {
                    if (checkzero == true)
                    { }
                    else
                    {
                        if (checktwo == true)
                        {
                        }
                        else
                        {
                            dvstop.Table.AcceptChanges();
                            dt2 = dvstop.ToTable();
                            checkone = false;
                        }
                    }
                }
            }
            else
            {
                checkone = false;
            }
            if (Chkstop2.Checked == true)
            {
                dvstop.RowFilter = "NumStops=2";
                if (dvstop.Count > 0)
                {
                    foreach (DataRowView rows in dvstop)
                    {
                        dt2.ImportRow(rows.Row);
                    }
                }
                else
                {
                    if (checkzero == true || checkone == true)
                    {

                    }
                    else
                    {
                        dvstop.Table.AcceptChanges();
                        dt2 = dvstop.ToTable();
                    }
                }
            }
            else
            {
                if (Session["dt4"] != null)
                {
                    DataTable dtstop = (DataTable)Session["dt4"];
                    dvstop = dtstop.DefaultView;
                }
                if (Session["dt3"] != null)
                {
                    DataTable dtstop = (DataTable)Session["dt3"];
                    dv = dtstop.DefaultView;
                }
                if (chkjetlite.Checked == true)
                {
                    dvstop.RowFilter = "airLineName='" + chkjetlite.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }

                    }
                    dv.RowFilter = "airLineName='" + chkjetlite.Text + "'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRowView rows in dv)
                        {
                            dt3.ImportRow(rows.Row);
                        }

                    }
                }
                if (chkAirIndia.Checked == true)
                {
                    dvstop.RowFilter = "airLineName='" + chkAirIndia.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }
                    }
                    dv.RowFilter = "airLineName='" + chkAirIndia.Text + "'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRowView rows in dv)
                        {
                            dt3.ImportRow(rows.Row);
                        }
                    }
                }
                if (chkJetAirways.Checked == true)
                {
                    dvstop.RowFilter = "airLineName='" + chkJetAirways.Text + "'";
                    if (dvstop.Count > 0)
                    {
                        foreach (DataRowView rows in dvstop)
                        {
                            dt2.ImportRow(rows.Row);
                        }
                    }
                    dv.RowFilter = "airLineName='" + chkJetAirways.Text + "'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRowView rows in dv)
                        {
                            dt3.ImportRow(rows.Row);
                        }
                    }
                }
                if (dt2.Rows.Count > 0)
                {
                    gdvReturn.DataSource = dt2;
                    gdvReturn.DataBind();
                }
                else
                {

                    gdvOnward.DataSource = dvstop;
                    gdvOnward.DataBind();
                    // return;

                }
                if (dt3.Rows.Count > 0)
                {

                    gdvReturn.DataSource = dt3;
                    gdvReturn.DataBind();


                }
                else
                {

                    gdvReturn.DataSource = dv;
                    gdvReturn.DataBind();

                }


            }
            #endregion
            dt2.AcceptChanges();

            if (Chkstop2.Checked == true)
            {
                if (dt3.Rows.Count > 0)
                {

                    gdvReturn.DataSource = dt3;
                    gdvReturn.DataBind();


                }
                else
                {

                    gdvReturn.DataSource = dv;
                    gdvReturn.DataBind();

                }
                if (dt2.Rows.Count > 0)
                {

                    gdvOnward.DataSource = dt2;
                    gdvOnward.DataBind();


                }
                else
                {

                    gdvOnward.DataSource = dvstop;
                    gdvOnward.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void filter(object sender, EventArgs e)
    {
        if (rbtnOneWay.Checked == true || rbtnOneWay.Checked == true)
        {
            JetAirways(sender, e);
        }
        else if (rbtnRoundTrip.Checked == true || rbtnRoundTrip.Checked == true)
        {
            JetAirwaysReturn(sender, e);
        }
    }
    #endregion


}