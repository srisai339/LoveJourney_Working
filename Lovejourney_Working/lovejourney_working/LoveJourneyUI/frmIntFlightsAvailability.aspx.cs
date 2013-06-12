using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FilghtsAPILayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;

public partial class frmIntFlightsAvailability : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();

    DataSet dsIntFlights = null;

    int adultCntInt = 0;
     int childCntInt = 0;
     int infantCntInt = 0;
    static string transId = "";
    DataTable dtNewFlightSegmentOnward ;
    DataTable dtNewFlightSegmentReturn ;
    DataSet objDataSet;
    ClsBAL objBAL;

    clsMasters _objMasters;
    DataSet _objDataSet;
    static string val;

    string ResponseMessage = string.Empty;
    string DateCreated = string.Empty;
    string PaymentID = string.Empty;
    string MerchantRefNo = string.Empty;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User"|| Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                this.MasterPageFile = "UserMasterPage.master";
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                this.MasterPageFile = "AgentMasterPage.master";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            getdatafromXMl();
            if (Session["UserID"] == null)
            {
                Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                pnl.Visible = false;
                lblMsg.Text = string.Empty;

                tblicons.Visible = true;
            }
            //hack
            //  Session["Order_Id"] = "LJIF5811720";
            // find(sender, e);
            //end hack
            if (Session["UserID"] == null)
            {
                User_menu.Visible = true;
                lnkSNFshow.Visible = false;
                lnkSNFshowroundtrip.Visible = false;
            }
            else if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor")
            {
                tblicons.Visible = false;

                User_menu.Visible = false;
                lnkSNFshow.Visible = false;
                lnkSNFshowroundtrip.Visible = false;

            }
            else if (Session["Role"].ToString() == "Agent")
            {
                tblicons.Visible = false;
                User_menu.Visible = false;
                lnkSNFshow.Visible = true;
                lnkSNFshowroundtrip.Visible = true;
            }
                
            if (!IsPostBack)
            {
                tdround.Visible = false;
                getservices();
                if (val != "true")
                {

                    pnlSearch.Visible = true;
                    if (Session["DR"] != null)
                    {
                        try
                        {
                            string sQS;
                            string pwd = "ebskey";
                            string DR = Session["DR"].ToString();
                            string str = Session["DR"].ToString();
                            Session["str"] = str.ToString();
                            // LogError("BusSearch", "str", DateTime.Now, str.ToString());
                            string[] words = str.Split('&');
                            string msgid2, msgid5;
                            msgid2 = "";
                            msgid5 = "";
                            try
                            {
                                msgid2 = words[1].ToString();
                                ResponseMessage = msgid2.Substring(16).ToString().Trim();
                            }
                            catch (Exception ex)
                            {
                                // LogError("BusSearch", "msgid2", DateTime.Now, msgid2.ToString());
                            }
                            try
                            {
                                msgid5 = words[4].ToString();
                                MerchantRefNo = msgid5.Substring(14).ToString().Trim();
                            }
                            catch (Exception ex)
                            {
                                // LogError("BusSearch", "msgid5", DateTime.Now, msgid5.ToString());
                            }

                            if (ResponseMessage == "Transaction Successful")
                            {

                                find(sender, e);
                                Session["DR"] = null;
                                // save(sender, e);
                                // method();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    pnlflights.Visible = true;
                        rbnIntOneWay.Checked = true;
                }
                else
                {
                    lblMainMsg.Text = "This Service is temporarily unavaliable";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    tdmsg.Visible = true;
                    pnlflights.Visible = false;

                }


            }

        }
        catch (Exception ex)
        { }
    }
    protected void getservices()
    {
        try
        {
            val = "false"; 
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Getservices;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < _objDataSet.Tables[0].Rows.Count; i++)
                        {
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "International Flights" && _objDataSet.Tables[0].Rows[i]["Status"].ToString() == "1")
                            {
                                val = "true";
                            }
                        }

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    private void find(object sender, EventArgs e)
    {
        try
        {
            FlightBAL objFlightsBal = new FlightBAL();
            string ReferenceNo = Convert.ToString(Session["Order_Id"]);
            DataSet dt = objFlightsBal.FGetInternationalFlightDetails(ReferenceNo);
            if (dt != null)
            {

                if (dt.Tables[0].Rows.Count > 0)
                {
                    if (dt.Tables[0].Rows[0]["TripMode"].ToString() == "Round")
                    {
                        saveround(sender, e);
                    }
                    if (dt.Tables[0].Rows[0]["TripMode"].ToString() == "One")
                    {
                        save(sender, e);
                    }
                }
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }


    protected void rbnIntOneWay_CheckedChanged(object sender, EventArgs e)
    {
        imgReturn.Visible = txtIntReturnDate.Visible = true;
        txtIntReturnDate.Enabled = false;
        txtIntReturnDate.Attributes.Remove("class");
       // RequiredReturnInt.Visible = false;
        txtIntReturnDate.Text = ""; lblMsg.Text = "";
        trroundTrip1.Visible = false;
        oneway.Visible = true;
        rradiooneway.Checked = true;
        rradioround.Checked = false;

        Returnway.Visible = false;
        //  Returnwayfare.Visible = false;

        printroundtrip.Visible = false;

        tdround.Visible = false;
    }
    protected void rbnIntRoundTrip_CheckedChanged(object sender, EventArgs e)
    {
        imgReturn.Visible = txtIntReturnDate.Visible = true;
        txtIntReturnDate.Enabled = true;
        txtIntReturnDate.Attributes.Add("class", "datepicker1");
       // RequiredReturnInt.Visible = true; 
        lblMsg.Text = "";

        trroundTrip1.Visible = true;
        oneway.Visible = false;
        rradiooneway.Checked = false;
        rradioround.Checked = true;

        Returnway.Visible = true;
        //  Returnwayfare.Visible = true;
        printroundtrip.Visible = true;

        tdround.Visible = true;

    }

    protected void ibtnSearchInt_Click(object sender, ImageClickEventArgs e)
    {       
        if (Session["UserId"] == null)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
            pnl.Visible = true;
        }

        try
        {
            try
            {
                if (Convert.ToInt32(ddlAdultsInt.SelectedValue) + Convert.ToInt32(ddlChildsInt.SelectedValue) + Convert.ToInt32(ddlInfantsInt.SelectedValue) <= 6)
                {
                    if (Convert.ToInt32(ddlInfantsInt.SelectedValue) <= Convert.ToInt32(ddlAdultsInt.SelectedValue))
                    {
                        string mode = (rbnIntOneWay.Checked) ? "ONE" : "ROUND";
                        //  dsIntFlights = new DataSet();

                        txtIntDeptDate.Text = hdnfromdate.Value;
                        txtIntReturnDate.Text = hdnTodate.Value;
                        if (txtIntReturnDate.Text.ToString() == "DD-MM-YYYY")
                        {
                            txtIntReturnDate.Text = "";
                        }
                        else
                        {
                            txtIntReturnDate.Text = hdnTodate.Value;
                        }

                        dsIntFlights = GetIntFlightsAvailability();
                        Session["dsIntFlights"] = dsIntFlights;
                        if (dsIntFlights.Tables.Count > 0)
                        {
                            if (dsIntFlights.Tables[1].Rows.Count > 0)
                            {
                                DataTable dtresponse = dsIntFlights.Tables[1];

                                if (mode == "ONE")
                                {

                                    if (dtresponse.Columns.Count != 4)
                                    {
                                        //if (dtresponse.Rows[0][1] == "")
                                        //{
                                        if (dsIntFlights.Tables[12].Rows.Count > 0)
                                        {


                                            #region FareDet

                                            DataTable dtFareDet = dsIntFlights.Tables[4];
                                            DataTable dtFareFlights = new DataTable();
                                            dtFareFlights = dsIntFlights.Tables[12].Clone();
                                            dtFareFlights.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                            dtFareFlights = GetFareDetTable(dsIntFlights.Tables[12], dtFareDet, dsIntFlights);

                                            DataView dvFare = dtFareFlights.DefaultView;
                                            dvFare.Sort = "Fare Asc";


                                            #endregion

                                            gdvIntFlights.DataSource = Session["dtIntFlights"] = Session["dtIntFlightsFare"] = dvFare.ToTable();
                                            gdvIntFlights.DataBind();
                                            pnlSearch.Visible = false;
                                            gdvRoundtrip.Visible = false;
                                            trFilterSearch.Visible = true;
                                            //lnkModifySearch.Visible = true;
                                            ModifySearch.Visible = false;
                                            lnkModifySearch_Click(sender, e);
                                            dvModifySearch.Visible = false;
                                            DataTable dtAirlineNames = dsIntFlights.Tables[12];
                                            BindAirportCodes(dtAirlineNames);

                                    

                                            decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                            decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);



                                            minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                            maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                            multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                            multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);


                                            getRouteNames();
                                        }
                                        else
                                        {
                                            gdvRoundtrip.Visible = false;
                                            trFilterSearch.Visible = false;
                                            pnlSearch.Visible = true;
                                            //lnkModifySearch.Visible = false;
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
                                        //if (dtresponse.Rows[0][1] == "")
                                        //{
                                        if (dsIntFlights.Tables[12].Rows.Count > 0)
                                        {
                                            gdvRoundtrip.Visible = true;
                                            RoundTripMethod();
                                            pnlSearch.Visible = false;
                                            trFilterSearch.Visible = true;
                                            // lnkModifySearch.Visible = true;

                                            ModifySearch.Visible = false;
                                            lnkModifySearch_Click(sender, e);
                                            dvModifySearch.Visible = false;

                                            BindAirportCodes(dsIntFlights.Tables["FlightSegment"]);

                                            DataTable dtFareDet = dsIntFlights.Tables["FareDetails"];
                                            decimal minValue = Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TMarkup"]); //+ Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                            decimal maxValue = Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TMarkup"]); //+ Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);


                                            minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                            maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                            multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                            multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);
                                            getRouteNames();
                                            //lnkModifySearch.Visible = true;
                                        }
                                        else
                                        {
                                            gdvRoundtrip.Visible = false;
                                            trFilterSearch.Visible = false;
                                            pnlSearch.Visible = true;
                                            //lnkModifySearch.Visible = false;
                                        }

                                    }
                                    else
                                    {
                                        mp3.Show();
                                        lblerror.Text = dtresponse.Rows[0][3].ToString();

                                    }
                                }
                            }

                        }
                        else
                        {
                            //lblMsg.Text = "No Records Found";
                            mp3.Show();
                            lblerror.Text = "No Services Found";
                        }
                    }
                    else
                    {
                        //  lblMsg.Text = "Infant Count should be less than or equal to Adult Count";
                        mp3.Show();
                        lblerror.Text = "Infant Count should be less than or equal to Adult Count";
                    }
                }
                else
                {
                    //Label3.Text = "Maximum Number of passengers allowed is 6";
                    mp3.Show();
                    lblerror.Text = "Maximum Number of passengers allowed is 6";
                }

            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }
    }


    private DataTable GetFareDetTable(DataTable dtFlightsSegment, DataTable dtFareDet, DataSet dsFilghts)
    {
        string FlightSegmentsID = string.Empty;
        string originDestination_Id = string.Empty;
        string fareDetailsId = string.Empty;
        string totalStr = string.Empty;
        DataTable dtNewFare = new DataTable();
        dtNewFare = dtFlightsSegment.Clone();
        dtNewFare.Columns.Add("Fare", System.Type.GetType("System.Decimal")); 
        foreach (DataRow dr in dtFlightsSegment.Rows)
        {
            dtNewFare.ImportRow(dr);
        }
        dtNewFare.AcceptChanges();

        for (int i = 0; i < dtFlightsSegment.Rows.Count; i++)
        {
            FlightSegmentsID = dtFlightsSegment.Rows[i]["FlightSegments_ID"].ToString();



            DataTable dtFareDetails1 = dsIntFlights.Tables[4];
            DataRow[] dtFareDetails = dtFareDetails1.Select("FareDetails_Id=" + FlightSegmentsID);
            foreach (DataRow rows in dtFareDetails)
            {

                decimal totalFare = Convert.ToDecimal(rows[0].ToString()) + Convert.ToDecimal(rows[1].ToString()) + Convert.ToDecimal(rows[2].ToString()) + Convert.ToDecimal(rows[3].ToString()) + Convert.ToDecimal(rows[6].ToString()); //+ Convert.ToDecimal(rows[4].ToString()) - Convert.ToDecimal(rows[5].ToString());

                dtNewFare.Rows[i]["Fare"] = Convert.ToDouble(totalFare).ToString("####0.00");
            }

        }
        return dtNewFare;
    }

    protected void getRouteNames()
    {
        try
        {
            string[] strfrom = new string[2];

            if (Session["From"] != null)
            {
                strfrom = Session["From"].ToString().Split(',');
            }
            else
            {
                Session["From"] = (rbnIntOneWay.Checked || rradiooneway.Checked) ? txtFrom.Text : txtfromsearch.Text;
                strfrom = Session["From"].ToString().Split(',');
            }
            string[] strto = new string[2];
            if (Session["TO"] != null)
            {
                strto = Session["TO"].ToString().Split(',');
            }
            else
            {
                Session["TO"] = (rbnIntRoundTrip.Checked || rradioround.Checked) ? txtTo.Text : txtleavingtosearch.Text;
                strto = Session["TO"].ToString().Split(',');
            }
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
           // DateTime Date = Convert.ToDateTime(txtIntDeptDate.Text);
            lblRouteFromTo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtIntDeptDate.Text;
            if (rbnIntRoundTrip.Checked == true || rradioround.Checked == true)
            {

               // DateTime Date1 = Convert.ToDateTime(txtIntReturnDate.Text);
                lblRouteFromTo.Text = lblRouteFromTo.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + txtIntReturnDate.Text;
            }
        }
        catch (NullReferenceException)
        {

        }
    }


    protected void getRouteNamesSrch()
    {
        try
        {
            string[] strfrom = new string[2];

            if (Session["From"] != null)
            {
                strfrom = Session["From"].ToString().Split(',');
            }
            else
            {
                Session["From"] = (rbnIntOneWay.Checked || rradiooneway.Checked) ? txtFrom.Text : txtfromsearch.Text;
                strfrom = Session["From"].ToString().Split(',');
            }
            string[] strto = new string[2];
            if (Session["TO"] != null)
            {
                strto = Session["TO"].ToString().Split(',');
            }
            else
            {
                Session["TO"] = (rbnIntRoundTrip.Checked || rradioround.Checked) ? txtTo.Text : txtleavingtosearch.Text;
                strto = Session["TO"].ToString().Split(',');
            }
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
           // DateTime Date = Convert.ToDateTime(txtdatesearch.Text);
            lblRouteFromTo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtdatesearch.Text;
            if (rbnIntRoundTrip.Checked == true || rradioround.Checked == true)
            {

              //  DateTime Date1 = Convert.ToDateTime(txtleavingtosearch.Text);
                lblRouteFromTo.Text = lblRouteFromTo.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + txtleavingtosearch.Text;
            }
        }
        catch (NullReferenceException)
        {

        }
    }


    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            try
            {

                if (Convert.ToInt32(ddladultsintsearch.SelectedValue) + Convert.ToInt32(ddlchildintsearch.SelectedValue) + Convert.ToInt32(ddlinfantsintsearch.SelectedValue) <= 6)
                {
                    if (Convert.ToInt32(ddlinfantsintsearch.SelectedValue) <= Convert.ToInt32(ddladultsintsearch.SelectedValue))
                    {
                        ViewState["Modify"] = "Modify";

                        string mode = (rradiooneway.Checked) ? "ONE" : "ROUND";
                        dsIntFlights = GetIntFlightsAvailabilitySearch();
                        Session["dsIntFlights"] = dsIntFlights;

                        if (dsIntFlights.Tables[12].Rows.Count > 0)
                        {
                            gdvIntFlights.Visible = trFilterSearch.Visible = true; trfiltersearch1.Visible = true;
                            pnlSearch.Visible = false;
                            if (mode == "ONE")
                            {
                                oneway.Visible = true;
                                #region FareDet

                                DataTable dtFareDet = dsIntFlights.Tables[4];
                                DataTable dtFareFlights = new DataTable();
                                dtFareFlights = dsIntFlights.Tables[12].Clone();
                                dtFareFlights.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                dtFareFlights = GetFareDetTable(dsIntFlights.Tables[12], dtFareDet, dsIntFlights);


                                #endregion

                                DataView dvFare = dtFareFlights.DefaultView;
                                dvFare.Sort = "Fare Asc";
                                gdvIntFlights.DataSource = Session["dtIntFlights"] = Session["dtIntFlightsFare"] = dtFareFlights;
                                gdvIntFlights.DataBind();
                                trFilterSearch.Visible = true;

                                DataTable dtAirlineNames = dsIntFlights.Tables[12];
                                BindAirportCodes(dtAirlineNames);



                                decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);



                                minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);
                                getRouteNamesSrch();

                            }
                            else
                            {
                                gdvRoundtrip.Visible = true; trfiltersearch1.Visible = true;
                                RoundTripMethod();
                                pnlSearch.Visible = false;
                                trFilterSearch.Visible = true;
                                // lnkModifySearch.Visible = true;

                                BindAirportCodes(dsIntFlights.Tables["FlightSegment"]);

                                DataTable dtFareDet = dsIntFlights.Tables["FareDetails"];
                                decimal minValue = Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TMarkup"]); //+ Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                decimal maxValue = Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TMarkup"]);//+ Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);


                                minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);
                                getRouteNamesSrch();
                            }
                        }
                        else
                        {
                            pnlSearch.Visible = true;
                            mp3.Show();
                            lblerror.Text = "No Services Found";
                        }
                        //gdvIntFlights.DataSource = Session["dtIntFlights"] = dsIntFlights.Tables[12];
                        //gdvIntFlights.DataBind();

                        //if (ViewState["Modify"] == null)
                        //{
                        //    lnkModifySearch.Visible = true;
                        //}
                        //else
                        //{
                        //    lnkModifySearch.Visible = false;
                        //}
                    }
                    else
                    {
                        mp3.Show();
                        lblerror.Text = "Infant Count should be less than or equal to Adult Count";
                        // lblMsg.Text = "Infant Count should be less than or equal to Adult Count";
                    }
                }
                else
                {
                    mp3.Show();
                    lblerror.Text = "Maximum Number of passengers allowed is 6";
                    //lblMsg.Text = "Maximum Number of passengers allowed is 9";
                }

            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }
    }



    private void RoundTripMethod()
    {
        try
        {
            dsIntFlights = (DataSet)Session["dsIntFlights"];
            string availResponseId = dsIntFlights.Tables["AvailResponse"].Rows[0]["AvailResponse_Id"].ToString();
            string originDestinationOptionsId = string.Empty;
            DataTable dtOriginDestinationOPtions = dsIntFlights.Tables["OriginDestinationOptions"];
            if (dtOriginDestinationOPtions.Rows.Count > 0)
            {
                DataRow[] row = dtOriginDestinationOPtions.Select("AvailResponse_Id=" + availResponseId);
                originDestinationOptionsId = row[0]["OriginDestinationOptions_Id"].ToString();
            }
            DataTable dtOriginDestinationOption = dsIntFlights.Tables["OriginDestinationOption"];


            DataTable dtsort = new DataTable();
            dtsort = dtOriginDestinationOption.Clone();

            foreach (DataRow dr in dtOriginDestinationOption.Rows)
            {
                dtsort.ImportRow(dr);
            }

            dtsort.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

            DataTable dt1 = dtsort.Clone();
            dt1.AcceptChanges();
            foreach (DataRow dr in dtsort.Rows)
            {
                dt1.ImportRow(dr);
            }



            DataTable dtFareDetails = dsIntFlights.Tables["FareDetails"];

            for (int i = 0; i < dtOriginDestinationOption.Rows.Count; i++)
            {

                DataRow[] drfare = dtFareDetails.Select("OriginDestinationOption_ID = " + dtOriginDestinationOption.Rows[i]["OriginDestinationOption_ID"]);


                Decimal TotalFare = Convert.ToDecimal(drfare[0]["actualBaseFare"]) + Convert.ToDecimal(drfare[0]["tax"]) +
                    Convert.ToDecimal(drfare[0]["stax"]) + Convert.ToDecimal(drfare[0]["Tcharge"])
                    + Convert.ToDecimal(drfare[0]["TMarkup"]);
                dt1.Rows[i]["Fare"] = TotalFare.ToString();
            }

            DataView dvfare = dt1.DefaultView;
            dvfare.Sort = "Fare ASC";

            gdvRoundtrip.DataSource = dtOriginDestinationOption;
            gdvRoundtrip.DataBind();
            gdvRoundtrip.Visible = true;
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }

    private DataSet GetIntFlightsAvailabilitySearch()
    {
        DataSet ds = new DataSet();
        try
        {
            Session["From"] = txtfromsearch.Text;
            Session["TO"] = txtleavingtosearch.Text;
            Session["datefrom"] = txtIntDeptDate.Text;
            ////converting from dd/mm/yyyy top yyyy/mm/dd
            //string s = txtdatesearch.Text;
            //string[] rslt = s.Split('-');
            //string date = rslt[2] + "-" + rslt[1] + "-" + rslt[0];
            ////converting from dd/mm/yyyy top yyyy/mm/dd
            //    Session["dateto"] = txtretundatesearch.Text;
            //    string date1 = "";
            //    if (txtretundatesearch.Text == "")
            //    {
            //        string s1 = txtdatesearch.Text;
            //        string[] rslt1 = s1.Split('-');
            //        date1 = rslt1[2] + "-" + rslt1[1] + "-" + rslt1[0];
            //    }




            //Converting dd-mm-yyyy to yyyy-mm-dd
            string s = txtdatesearch.Text.Trim();
            string[] r = s.Split('-');
            string date = r[2] + "-" + r[1] + "-" + r[0];
            string fromdate = date;
            string todate = "";
            if (txtretundatesearch.Text != "")
            {
                string s1 = txtretundatesearch.Text.Trim();
                string[] result1 = s1.Split('-');
                string date1 = result1[2] + "-" + result1[1] + "-" + result1[0];
                todate = date1;
            }




            Session["Adult"] = ddladultsintsearch.SelectedItem.Text;
            Session["Infant"] = ddlinfantsintsearch.SelectedItem.Text;
            Session["Child"] = ddlchildintsearch.SelectedItem.Text;
            infantCntInt = Convert.ToInt32(ddlinfantsintsearch.SelectedValue);
            childCntInt = Convert.ToInt32(ddlchildintsearch.SelectedValue);
            adultCntInt = Convert.ToInt32(ddladultsintsearch.SelectedValue);

            Session["adultCntInt"] = adultCntInt.ToString();
            Session["infantCntInt"] = infantCntInt.ToString();
            Session["childCntInt"] = childCntInt.ToString();

            string result = null;
            string mode = (rradiooneway.Checked) ? "ONE" : "ROUND";
            string returnDate = (rradiooneway.Checked) ? date : todate;
            string from = txtfromsearch.Text.Substring(txtfromsearch.Text.IndexOf("(") + 1, 3);
            string to = txtleavingtosearch.Text.Substring(txtleavingtosearch.Text.IndexOf("(") + 1, 3);

            // string xmlRequest = "xmlRequest=<AvailRequest><Trip>ONE</Trip><Origin>BLR</Origin><Destination>JFK</Destination><DepartDate>2012-10-19</DepartDate><ReturnDate>2012-10-25</ReturnDate><AdultPax>1</AdultPax><ChildPax>0</ChildPax><InfantPax>0</InfantPax><Currency>INR</Currency><PreferredClass>E</PreferredClass><Eticket>true</Eticket><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><PreferredAirline></PreferredAirline></AvailRequest>";
            string xmlRequest = "xmlRequest=<AvailRequest><Trip>" + mode + "</Trip><Origin>" + from + "</Origin>";
            xmlRequest = xmlRequest + "<Destination>" + to + "</Destination><DepartDate>" + fromdate + "</DepartDate><ReturnDate>" + returnDate + "</ReturnDate>";
            xmlRequest = xmlRequest + "<AdultPax>" + ddladultsintsearch.SelectedValue + "</AdultPax><ChildPax>" + ddlchildintsearch.SelectedValue + "</ChildPax><InfantPax>" + ddlinfantsintsearch.SelectedValue + "</InfantPax><Currency>INR</Currency><PreferredClass>" + ddlIntCabinTypesearch.SelectedValue + "</PreferredClass>";
            xmlRequest = xmlRequest + "<Eticket>true</Eticket><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><PreferredAirline></PreferredAirline></AvailRequest>";

            byte[] requestData = Encoding.ASCII.GetBytes(xmlRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Avalability");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = requestData.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
            }



            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                        result = reader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);

                    ds.ReadXml(xmlReader);
                }
            }

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message.ToString());
        }



        return ds;
    }
    private DataSet GetIntFlightsAvailability()
    {
        DataSet ds = new DataSet();
        try
        {
            try
            {

                infantCntInt = Convert.ToInt32(ddlInfantsInt.SelectedValue);
                childCntInt = Convert.ToInt32(ddlChildsInt.SelectedValue);
                adultCntInt = Convert.ToInt32(ddlAdultsInt.SelectedValue);

                Session["adultCntInt"] = adultCntInt.ToString();
                Session["infantCntInt"] = infantCntInt.ToString();
                Session["childCntInt"] = childCntInt.ToString();


                //Converting dd-mm-yyyy to yyyy-mm-dd
                string s = txtIntDeptDate.Text.Trim();
                string[] r = s.Split('-');
                string date = r[2] + "-" + r[1] + "-" + r[0];
                string fromdate = date;
                string todate = "";
                if (txtIntReturnDate.Text != "")
                {
                    string s1 = txtIntReturnDate.Text.Trim();
                    string[] result1 = s1.Split('-');
                    string date1 = result1[2] + "-" + result1[1] + "-" + result1[0];
                    todate = date1;
                }

                string result = null;
                string mode = (rbnIntOneWay.Checked) ? "ONE" : "ROUND";
                string returnDate = (rbnIntOneWay.Checked) ? fromdate : todate;
                string from = txtFrom.Text.Substring(txtFrom.Text.IndexOf("(") + 1, 3);
                string to = txtTo.Text.Substring(txtTo.Text.IndexOf("(") + 1, 3);
                Session["From"] = txtFrom.Text;
                Session["TO"] = txtTo.Text;
                Session["datefrom"] = txtIntDeptDate.Text;
                Session["dateto"] = todate;
                Session["Adult"] = ddlAdultsInt.SelectedItem.Text;
                Session["Infant"] = ddlInfantsInt.SelectedItem.Text;
                Session["Child"] = ddlChildsInt.SelectedItem.Text;

                // string xmlRequest = "xmlRequest=<AvailRequest><Trip>ONE</Trip><Origin>BLR</Origin><Destination>JFK</Destination><DepartDate>2012-10-19</DepartDate><ReturnDate>2012-10-25</ReturnDate><AdultPax>1</AdultPax><ChildPax>0</ChildPax><InfantPax>0</InfantPax><Currency>INR</Currency><PreferredClass>E</PreferredClass><Eticket>true</Eticket><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><PreferredAirline></PreferredAirline></AvailRequest>";
                string xmlRequest = "xmlRequest=<AvailRequest><Trip>" + mode + "</Trip><Origin>" + from + "</Origin>";
                xmlRequest = xmlRequest + "<Destination>" + to + "</Destination><DepartDate>" + fromdate + "</DepartDate><ReturnDate>" + returnDate + "</ReturnDate>";
                xmlRequest = xmlRequest + "<AdultPax>" + ddlAdultsInt.SelectedValue + "</AdultPax><ChildPax>" + ddlChildsInt.SelectedValue + "</ChildPax><InfantPax>" + ddlInfantsInt.SelectedValue + "</InfantPax><Currency>INR</Currency><PreferredClass>" + ddlIntCabinType.SelectedValue + "</PreferredClass>";
                xmlRequest = xmlRequest + "<Eticket>true</Eticket><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><PreferredAirline></PreferredAirline></AvailRequest>";

                byte[] requestData = Encoding.ASCII.GetBytes(xmlRequest);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Avalability");
                // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://59.162.33.102:9301/Avalability");


                request.Timeout = 1000000;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = requestData.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(requestData, 0, requestData.Length);
                }



                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            result = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);

                        ds.ReadXml(xmlReader);
                    }
                }
            }
            catch (NullReferenceException)
            {
                // Console.WriteLine(ex.Message.ToString());
                Response.Redirect("~/Default.aspx", false);

            }

        }
        catch (Exception ex)
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }

        return ds;
    }
    #region Variables
    string result = null;
    string str = string.Empty;
    string FlightSegmentsID = string.Empty;
    string DepartureAirportCode = string.Empty;
    string ArrivalDateTime = string.Empty;
    string DepartureAirportName = string.Empty;
    string DepartureDateTime = string.Empty;
    string FlightNumber = string.Empty;
    string MarketingAirlineCode = string.Empty;
    string OperatingAirlineCode = string.Empty;
    string OperatingAirlineName = string.Empty;
    string OperatingAirlineFlightNumber = string.Empty;
    string NumStops = string.Empty;
    string LinkSellAgrmnt = string.Empty;
    string Conx = string.Empty;
    string AirpChg = string.Empty;
    string InsideAvailOption = string.Empty;
    string GenTrafRestriction = string.Empty;
    string DaysOperates = string.Empty;
    string JrnyTm = string.Empty;
    string EndDt = string.Empty;
    string StartTerminal = string.Empty;
    string EndTerminal = string.Empty;
    string FltTm = string.Empty;
    string LSAInd = string.Empty;
    string Mile = string.Empty;
    string Availability = string.Empty;
    string BIC = string.Empty;
    string bookingclass = string.Empty;
    string classType = string.Empty;
    string farebasiscode = string.Empty;
    string Rule = string.Empty;
    string PsgrType = string.Empty;
    string BaseFare = string.Empty;
    string Tax = string.Empty;
    string BagInfo = string.Empty;
    string AirEquipType = string.Empty;
    string ArrivalAirportCode = string.Empty;
    string ArrivalAirportName = string.Empty;
    string return1 = string.Empty;
    string id1 = string.Empty;
    string key = string.Empty;
    string ActualBaseFare = string.Empty;
    string FareTax = string.Empty;
    string STax = string.Empty;
    string TCharge = string.Empty;
    string SCharge = string.Empty;
    string TDiscount = string.Empty;
    string TMarkup = string.Empty;
    string TPartnerCommission = string.Empty;
    string TSdiscount = string.Empty;
    string FarePsgrType = string.Empty;
    string FareBaseFare = string.Empty;
    string FareTax1 = string.Empty;
    string Country = string.Empty;
    string Amt = string.Empty;
    string ocTax = string.Empty;
    string onwardId = string.Empty;
    string OriginDestinationOption_Id = string.Empty;
    string FareDetails_id = string.Empty;
    string FareBreakUp_Id = string.Empty;
    string FareAry_id = string.Empty;
    string FareId = string.Empty;
    string bookingclassFareId = string.Empty;
    string psgrBreakUp_Id = string.Empty;
    string psgrAy_id = string.Empty;
    string country = string.Empty;
    string taxAmt = string.Empty;
    string taxData = string.Empty;
    string taxDataAry_id = string.Empty;



    string CFareId = string.Empty;
    string CPsgrType = string.Empty;
    string CBaseFare = string.Empty;
    string CFareTax = string.Empty;
    string IFareId = string.Empty;
    string IPsgrType = string.Empty;
    string IBaseFare = string.Empty;
    string IFareTax = string.Empty;

    string CFarePsgrType = string.Empty;
    string CFareBaseFare = string.Empty;
    string CFareTax1 = string.Empty;
    string CBagInfo = string.Empty;
    string IFarePsgrType = string.Empty;
    string IFareBaseFare = string.Empty;
    string IFareTax1 = string.Empty;
    string IBagInfo = string.Empty;
    string taxdatapsgr = string.Empty;
    bool res1;
    string Address = string.Empty;
    string faretype = string.Empty;



    string FlightSegmentsIDRet = string.Empty;
    string DepartureAirportCodeRet = string.Empty;
    string ArrivalDateTimeRet = string.Empty;
    string DepartureAirportNameRet = string.Empty;
    string DepartureDateTimeRet = string.Empty;
    string FlightNumberRet = string.Empty;
    string MarketingAirlineCodeRet = string.Empty;
    string OperatingAirlineCodeRet = string.Empty;
    string OperatingAirlineNameRet = string.Empty;
    string OperatingAirlineFlightNumberRet = string.Empty;
    string NumStopsRet = string.Empty;
    string LinkSellAgrmntRet = string.Empty;
    string ConxRet = string.Empty;
    string AirpChgRet = string.Empty;
    string InsideAvailOptionRet = string.Empty;
    string GenTrafRestrictionRet = string.Empty;
    string DaysOperatesRet = string.Empty;
    string JrnyTmRet = string.Empty;
    string EndDtRet = string.Empty;
    string StartTerminalRet = string.Empty;
    string EndTerminalRet = string.Empty;
    string FltTmRet = string.Empty;
    string LSAIndRet = string.Empty;
    string MileRet = string.Empty;
    string AvailabilityRet = string.Empty;
    string BICRet = string.Empty;
    string bookingclassRet = string.Empty;
    string classTypeRet = string.Empty;
    string farebasiscodeRet = string.Empty;
    string RuleRet = string.Empty;
    string PsgrTypeRet = string.Empty;
    string BaseFareRet = string.Empty;
    string TaxRet = string.Empty;
    string BagInfoRet = string.Empty;
    string AirEquipTypeRet = string.Empty;
    string ArrivalAirportCodeRet = string.Empty;
    string ArrivalAirportNameRet = string.Empty;

    string idRet = string.Empty;
    string keyRet = string.Empty;
    string ActualBaseFareRet = string.Empty;
    string FareTaxRet = string.Empty;
    string STaxRet = string.Empty;
    string TChargeRet = string.Empty;
    string SChargeRet = string.Empty;
    string TDiscountRet = string.Empty;
    string TMarkupRet = string.Empty;
    string TPartnerCommissionRet = string.Empty;
    string TSdiscountRet = string.Empty;
    string FarePsgrTypeRet = string.Empty;
    string FareBaseFareRet = string.Empty;
    string FareTax1Ret = string.Empty;
    string CountryRet = string.Empty;
    string AmtRet = string.Empty;
    string ocTaxRet = string.Empty;
    string onwardIdRet = string.Empty;
    string OriginDestinationOption_IdRet = string.Empty;
    string FareDetails_idRet = string.Empty;
    string FareBreakUp_IdRet = string.Empty;
    string FareAry_idRet = string.Empty;
    string FareIdRet = string.Empty;
    string bookingclassFareIdRet = string.Empty;
    string psgrBreakUp_IdRet = string.Empty;
    string psgrAy_idRet = string.Empty;
    string countryRet = string.Empty;
    string taxAmtRet = string.Empty;
    string taxDataRet = string.Empty;
    string taxDataAry_idRet = string.Empty;
    string returnIdRet = string.Empty;

    // string taxdatapsgr = string.Empty;
    string taxdatapsgrRet = string.Empty;
    string returnId = string.Empty;
    #endregion
    private void GetIntBookingRequest()
    {
        try
        {
            if (Session["dsIntFlights"] != null)
            {
                dsIntFlights = (DataSet)Session["dsIntFlights"];
                DataTable dtFlightSegment = dsIntFlights.Tables[12];
                if (dtFlightSegment.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegment = dtFlightSegment.Select("FlightSegment_ID=" + Convert.ToInt32(lblIntFlightSegmentId.Text));
                    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                    Session["FlightSegmentsID"] = FlightSegmentsID.ToString();

                }
                DataTable dtFlightSegments = dsIntFlights.Tables[11];
                if (dtFlightSegments.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID=" + FlightSegmentsID);
                    onwardId = rowFilghtSegments[0]["Onward_Id"].ToString();
                }
                DataTable dtOnward = dsIntFlights.Tables[10];
                if (dtOnward.Rows.Count > 0)
                {
                    DataRow[] rowOnward = dtOnward.Select("Onward_Id=" + onwardId);
                    OriginDestinationOption_Id = rowOnward[0]["OriginDestinationOption_Id"].ToString();
                }
                DataTable dtOriginDestinationOption = dsIntFlights.Tables[3];
                if (dtOriginDestinationOption.Rows.Count > 0)
                {
                    DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("OriginDestinationOption_Id=" + OriginDestinationOption_Id);
                    return1 = rowOriginDestinationOption[0]["Return"].ToString();
                    id1 = rowOriginDestinationOption[0]["id"].ToString();
                    key = rowOriginDestinationOption[0]["key"].ToString();
                }
                DataTable dtFareDetails = dsIntFlights.Tables[4];
                if (dtFareDetails.Rows.Count > 0)
                {
                    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + OriginDestinationOption_Id);
                    ActualBaseFare = rowFareDetails[0]["ActualBaseFare"].ToString();
                    Tax = rowFareDetails[0]["Tax"].ToString();
                    STax = rowFareDetails[0]["STax"].ToString();
                    TCharge = rowFareDetails[0]["TCharge"].ToString();
                    SCharge = rowFareDetails[0]["SCharge"].ToString();
                    TDiscount = rowFareDetails[0]["TDiscount"].ToString();
                    TMarkup = rowFareDetails[0]["TMarkup"].ToString();
                    TPartnerCommission = rowFareDetails[0]["TPartnerCommission"].ToString();
                    TSdiscount = rowFareDetails[0]["TSdiscount"].ToString();
                    ocTax = rowFareDetails[0]["ocTax"].ToString();
                    FareDetails_id = rowFareDetails[0]["FareDetails_id"].ToString();
                }
                DataTable dtFareBreakUp = dsIntFlights.Tables[5];
                if (dtFareBreakUp.Rows.Count > 0)
                {
                    DataRow[] rowFareBreakUp = dtFareBreakUp.Select("FareDetails_Id=" + FareDetails_id);
                    FareBreakUp_Id = rowFareBreakUp[0]["FareBreakUp_Id"].ToString();

                }
                DataTable dtFareAry = dsIntFlights.Tables[6];
                if (dtFareAry.Rows.Count > 0)
                {
                    DataRow[] rowFareAry = dtFareAry.Select("FareBreakUp_Id=" + FareBreakUp_Id);
                    FareAry_id = rowFareAry[0]["FareAry_id"].ToString();
                    Session["FareAry_id"] = FareAry_id.ToString();
                }
                DataTable dtFare = dsIntFlights.Tables[7];

                if (dtFare.Rows.Count > 0)
                {
                    DataRow[] rowFare = dtFare.Select("FareAry_id=" + FareAry_id);

                    PsgrType = rowFare[0]["PsgrType"].ToString();
                    BaseFare = rowFare[0]["BaseFare"].ToString();
                    FareTax = rowFare[0]["Tax"].ToString();
                    FareId = rowFare[0]["Fare_Id"].ToString();
                    Session["FareId"] = FareId.ToString();

                    foreach (DataRow dr in rowFare)
                    {
                        if (faretype == "")
                        {
                            faretype = dr["PsgrType"].ToString() + "," + dr["BaseFare"].ToString() + "," + dr["Tax"].ToString();
                        }
                        else
                        {

                            faretype = faretype + ";" + dr["PsgrType"].ToString() + "," + dr["BaseFare"].ToString() + "," + dr["Tax"].ToString() + ";";
                        }
                    }



                }

                DataTable dtBookingClass = dsIntFlights.Tables[13];
                if (dtBookingClass.Rows.Count > 0)
                {
                    DataRow[] rowBookingClass = dtBookingClass.Select("FlightSegment_Id=" + lblIntFlightSegmentId.Text);
                    Availability = rowBookingClass[0]["Availability"].ToString();
                    BIC = rowBookingClass[0]["BIC"].ToString();
                }
                DataTable dtBookingClassFare = dsIntFlights.Tables[14];
                if (dtBookingClassFare.Rows.Count > 0)
                {
                    DataRow[] rowBookingClassFare = dtBookingClassFare.Select("FlightSegment_Id=" + lblIntFlightSegmentId.Text);
                    bookingclass = rowBookingClassFare[0]["bookingclass"].ToString();
                    classType = rowBookingClassFare[0]["classType"].ToString();
                    farebasiscode = rowBookingClassFare[0]["farebasiscode"].ToString();
                    Rule = rowBookingClassFare[0]["Rule"].ToString();
                    if (dtBookingClassFare.Columns.Contains("bookingclassFare_Id"))
                    {
                        bookingclassFareId = rowBookingClassFare[0]["bookingclassFare_Id"].ToString();
                    }

                }
                if (dtBookingClassFare.Columns.Contains("bookingclassFare_Id"))
                {
                    DataTable dtPsgrBreakUp = dsIntFlights.Tables[15];
                    if (dtPsgrBreakUp.Rows.Count > 0)
                    {
                        DataRow[] rowPsgrBreakUp = dtPsgrBreakUp.Select("bookingclassFare_Id=" + bookingclassFareId);
                        psgrBreakUp_Id = rowPsgrBreakUp[0]["psgrBreakUp_Id"].ToString();

                    }
                    DataTable dtPsgrAry = dsIntFlights.Tables[16];
                    if (dtPsgrAry.Rows.Count > 0)
                    {
                        DataRow[] rowPsgrAry = dtPsgrAry.Select("psgrBreakUp_Id=" + psgrBreakUp_Id);
                        psgrAy_id = rowPsgrAry[0]["psgrAry_Id"].ToString();
                        Session["psgrAy_id"] = psgrAy_id.ToString();
                    }
                    DataTable dtPsgr = dsIntFlights.Tables[17];
                    if (dtPsgr.Rows.Count > 0)
                    {
                        DataRow[] rowPsgr = dtPsgr.Select("psgrAry_Id=" + psgrAy_id);
                        FarePsgrType = rowPsgr[0]["psgrType"].ToString();
                        FareBaseFare = rowPsgr[0]["BaseFare"].ToString();
                        FareTax1 = rowPsgr[0]["Tax"].ToString();
                        BagInfo = rowPsgr[0]["BagInfo"].ToString();


                    }

                }
                //ravi db save

                FlightBAL objFlightBal = new FlightBAL();
                String RefNo = Common.GetFlightsReferenceNo("LJIF");
                Session["Order_Id"] = RefNo.ToString();
                objFlightBal.ReferenceNo = RefNo.ToString();
                objFlightBal.TransId = "0";
                objFlightBal.Status = "Pending";
                objFlightBal.AdultPax = Convert.ToInt32(Session["Adult"]);
                objFlightBal.InfantPax = Convert.ToInt32(Session["Infant"]);
                objFlightBal.ChildPax = Convert.ToInt32(Session["Child"]);
                objFlightBal.Origin_Destination_Id = id1;
                objFlightBal.Origin_Destination_Key = key;
                objFlightBal.ActualBasefare = Convert.ToDecimal(ActualBaseFare);
                objFlightBal.Tax = Convert.ToDecimal(Tax);
                objFlightBal.STax = Convert.ToDecimal(STax);
                objFlightBal.TCharge = Convert.ToDecimal(TCharge);
                objFlightBal.Scharge = Convert.ToDecimal(SCharge);
                objFlightBal.TDiscount = Convert.ToDecimal(TDiscount);
                objFlightBal.TMarkUp = Convert.ToDecimal(TMarkup);
                objFlightBal.TPartnerCommission = Convert.ToDecimal(TPartnerCommission);
                objFlightBal.TSDiscount = Convert.ToDecimal(TSdiscount);
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                objFlightBal.TripMode = "One";
                objFlightBal.ocTax = ocTax;
                objFlightBal.Return = return1;
                objFlightBal.id = id1;
                objFlightBal.key = key;

                DataTable dtflightBookingId = objFlightBal.AddDInternationalFlightBooking(objFlightBal);
                Session["BookingID"] = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                //fegments


                string customerInfo = string.Empty;
                Table tbladults = (Table)this.UpdatePanel2.FindControl("tblAdultsInt");
                for (int l = 1; l <= Convert.ToInt32(Session["adultCntInt"]); l++)
                {

                    TextBox txtFn = (TextBox)tbladults.FindControl("txtFnInt" + l);
                    TextBox txtLn = (TextBox)tbladults.FindControl("txtLnInt" + l);
                    DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitleInt" + l);

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "adt" + "|" + "-";
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "adt" + "|" + "-";
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }

                Table tblChild = (Table)this.UpdatePanel2.FindControl("tblChildInt");
                for (int j = 1; j <= Convert.ToInt32(Session["childCntInt"]); j++)
                {
                    TextBox txtFn = (TextBox)tblChild.FindControl("txtCFnInt" + j);

                    TextBox txtLn = (TextBox)tblChild.FindControl("txtCLnInt" + j);

                    DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitleInt" + j);


                    TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDateInt" + j);

                    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "chd" + "|" + age + "|" + txtBirthDate.Text;
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "chd" + "|" + age + "|" + txtBirthDate.Text;
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }

                Table tblInfants = (Table)this.UpdatePanel2.FindControl("tblInfantsInt");
                for (int k = 1; k <= Convert.ToInt32(Session["infantCntInt"]); k++)
                {
                    TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFnInt" + k);

                    TextBox txtLn = (TextBox)tblInfants.FindControl("txtILnInt" + k);

                    DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitleInt" + k);

                    TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDateInt" + k);
                    string age = string.Empty;
                    if (txtBirthDate != null)
                        age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();
                    else
                        age = "0";


                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "inf" + "|" + age + "|" + txtBirthDate.Text;
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "inf" + "|" + age + "|" + txtBirthDate.Text;
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
                }



                if (dtFlightSegment.Rows.Count > 0)
                {
                    DataRow[] rowFilghtSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsID);
                    for (int j = 0; j < rowFilghtSegment.Length; j++)
                    {
                        AirEquipType = rowFilghtSegment[j]["AirEquipType"].ToString();
                        ArrivalAirportCode = rowFilghtSegment[j]["ArrivalAirportCode"].ToString();
                        ArrivalAirportName = rowFilghtSegment[j]["ArrivalAirportName"].ToString();
                        ArrivalDateTime = rowFilghtSegment[j]["ArrivalDateTime"].ToString();
                        DepartureAirportCode = rowFilghtSegment[j]["DepartureAirportCode"].ToString();
                        DepartureAirportName = rowFilghtSegment[j]["DepartureAirportName"].ToString();
                        DepartureDateTime = rowFilghtSegment[j]["DepartureDateTime"].ToString();
                        FlightNumber = rowFilghtSegment[j]["FlightNumber"].ToString();
                        MarketingAirlineCode = rowFilghtSegment[j]["MarketingAirlineCode"].ToString();
                        OperatingAirlineCode = rowFilghtSegment[j]["OperatingAirlineCode"].ToString();
                        OperatingAirlineName = rowFilghtSegment[j]["OperatingAirlineName"].ToString();
                        OperatingAirlineFlightNumber = rowFilghtSegment[j]["OperatingAirlineFlightNumber"].ToString();
                        NumStops = rowFilghtSegment[j]["NumStops"].ToString();
                        LinkSellAgrmnt = rowFilghtSegment[j]["LinkSellAgrmnt"].ToString();
                        Conx = rowFilghtSegment[j]["Conx"].ToString();
                        AirpChg = rowFilghtSegment[j]["AirpChg"].ToString();
                        InsideAvailOption = rowFilghtSegment[j]["InsideAvailOption"].ToString();
                        GenTrafRestriction = rowFilghtSegment[j]["GenTrafRestriction"].ToString();
                        DaysOperates = rowFilghtSegment[j]["DaysOperates"].ToString();
                        JrnyTm = rowFilghtSegment[j]["JrnyTm"].ToString();
                        EndDt = rowFilghtSegment[j]["EndDt"].ToString();
                        StartTerminal = rowFilghtSegment[j]["StartTerminal"].ToString();
                        EndTerminal = rowFilghtSegment[j]["EndTerminal"].ToString();
                        FltTm = rowFilghtSegment[j]["FltTm"].ToString();
                        LSAInd = rowFilghtSegment[j]["LSAInd"].ToString();
                        Mile = rowFilghtSegment[j]["Mile"].ToString();

                        DataTable dtBookingClass1 = dsIntFlights.Tables[13];
                        if (dtBookingClass1.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClass = dtBookingClass1.Select("FlightSegment_Id=" + rowFilghtSegment[j]["FlightSegment_Id"].ToString());
                            Availability = rowBookingClass[0]["Availability"].ToString();
                            BIC = rowBookingClass[0]["BIC"].ToString();
                        }

                        DataTable dtBookingClassFare1 = dsIntFlights.Tables[14];
                        if (dtBookingClassFare1.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClassFare = dtBookingClassFare1.Select("FlightSegment_Id=" + rowFilghtSegment[j]["FlightSegment_Id"].ToString());
                            bookingclass = rowBookingClassFare[0]["bookingclass"].ToString();
                            classType = rowBookingClassFare[0]["classType"].ToString();
                            farebasiscode = rowBookingClassFare[0]["farebasiscode"].ToString();
                            Rule = rowBookingClassFare[0]["Rule"].ToString();


                        }

                        //   bookingclass = rowFilghtSegment[j]["LSAInd"].ToString();
                        //   classType = rowFilghtSegment[j]["Mile"].ToString();

                        objFlightBal.FlightBookingID = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();//Convert.ToString(Session["BookingID"]);
                        objFlightBal.AirEquipType = AirEquipType;
                        objFlightBal.ArrivalAirportCode = ArrivalAirportCode;
                        objFlightBal.ArrivalAirportName = ArrivalAirportName;
                        objFlightBal.ArrivalDateTime = ArrivalDateTime;
                        objFlightBal.DepartureAirportCode = DepartureAirportCode;
                        objFlightBal.DepartureAirportName = DepartureAirportName;
                        objFlightBal.DepartureDateTime = DepartureDateTime;
                        objFlightBal.FlightNumber = FlightNumber;
                        objFlightBal.MarketingAirlineCode = MarketingAirlineCode;
                        objFlightBal.OperatingAirlineCode = OperatingAirlineCode;
                        objFlightBal.OperatingAirlineName = OperatingAirlineName;
                        objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumber;
                        objFlightBal.NumStops = NumStops;
                        objFlightBal.LinkSellAgrmnt = LinkSellAgrmnt;
                        objFlightBal.Conx = Conx;
                        objFlightBal.AirpChg = AirpChg;
                        objFlightBal.InsideAvailOption = InsideAvailOption;
                        objFlightBal.GenTrafRestriction = GenTrafRestriction;
                        objFlightBal.DaysOperates = DaysOperates;
                        objFlightBal.JrnyTm = JrnyTm;
                        objFlightBal.EndDt = EndDt;
                        objFlightBal.StartTerminal = StartTerminal;
                        objFlightBal.EndTerminal = EndTerminal;
                        objFlightBal.FltTm = FltTm;
                        objFlightBal.LSAInd = LSAInd;
                        objFlightBal.Mile = Mile;
                        objFlightBal.Availability = Availability;
                        objFlightBal.BIC = BIC;
                        objFlightBal.emailAddress = txtEmailIDInt.Text.Trim();
                        Session["EmailID"] = txtEmailIDInt.Text.Trim();
                        objFlightBal.telephone = txtMobileNumberInt.Text;
                        Session["MobileNo"] = txtMobileNumberInt.Text;
                        objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        objFlightBal.Customer_Details = customerInfo;
                        objFlightBal.Address = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                        Session["customerInfo"] = customerInfo;
                        Session["Address"] = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                        objFlightBal.bookingClass = bookingclass;
                        objFlightBal.ClassType = classType;
                        objFlightBal.farebasisCode = farebasiscode;
                        objFlightBal.Fare_Rule = Rule;
                        objFlightBal.PsgrType = FarePsgrType;
                        objFlightBal.BaseFare = FareBaseFare;
                        objFlightBal.psgrTax = FareTax1;
                        objFlightBal.BagInfo = BagInfo;
                        objFlightBal.FarePsgrType = faretype;

                        res1 = objFlightBal.AddInternationalFlightSegment(objFlightBal);

                    }
                }

                if (res1 == true)
                {
                    // PaymentGateway();
                    Session["result"] = "true";
                }
                //db save end
            }
            else
            {
                Response.Redirect("~/Default.aspx",false);
            }
        }

        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }

    string XmlPricingRequest;
    string[] rows;
    string[] Irows;
    private DataSet method()
    {
        try
        {
            DataSet ds = new DataSet();
            FlightBAL objFlightsBal = new FlightBAL();
           
                string ReferenceNo = Convert.ToString(Session["Order_Id"]);
                DataSet dtid = objFlightsBal.FGetInternationalFlightDetails(ReferenceNo);

                return1 = dtid.Tables[0].Rows[0]["Return1"].ToString();
                id1 = dtid.Tables[0].Rows[0]["id"].ToString();
                key = dtid.Tables[0].Rows[0]["Key1"].ToString();
                string[] actualBaseFare = dtid.Tables[0].Rows[0]["ActualBasefare"].ToString().Split('.');
                ActualBaseFare = actualBaseFare[0].ToString();
                string[] tx = dtid.Tables[0].Rows[0]["Tax"].ToString().Split('.');
                Tax = tx[0].ToString();
                string[] stx = dtid.Tables[0].Rows[0]["STax"].ToString().Split('.');
                STax = stx[0].ToString();
                string[] schrge = dtid.Tables[0].Rows[0]["Scharge"].ToString().Split('.');
                SCharge = schrge[0].ToString();
                string[] tdis = dtid.Tables[0].Rows[0]["TDiscount"].ToString().Split('.');
                TDiscount = tdis[0].ToString();
                string[] tpartcomm = dtid.Tables[0].Rows[0]["TPartnerCommission"].ToString().Split('.');
                TPartnerCommission = tpartcomm[0].ToString();
                string[] tsdisc = dtid.Tables[0].Rows[0]["TSDiscount"].ToString().Split('.');
                TSdiscount = tsdisc[0].ToString();
                ocTax = dtid.Tables[0].Rows[0]["Octax"].ToString();
                string[] tmrkup = dtid.Tables[0].Rows[0]["TMarkUp"].ToString().Split('.');
                TMarkup = tmrkup[0].ToString();
                string[] tchge = dtid.Tables[0].Rows[0]["TCharge"].ToString().Split('.');
                TCharge = tchge[0].ToString();

                string ReferenceNo1 = dtid.Tables[0].Rows[0]["Int_Booking_Id"].ToString();
                DataSet dsdbsave = objFlightsBal.GetInternationalFlightDetails1(ReferenceNo1);


                if (dsdbsave.Tables.Count > 0)
                {
                    if (dsdbsave.Tables[0].Rows.Count > 0)
                    {
                        //foreach (DataRow row in dsdbsave.Tables[0].Rows)
                        //{
                        if (dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Contains(";"))
                        {
                            rows = dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Split(';');
                            int count = rows.Count();
                            for (int i = 0; i < count; i++)
                            {
                                if (rows.Contains("|"))
                                {
                                    string[] str2 = rows[i].ToString().Split('|');

                                    Irows = str2.ToString().Split(',');
                                }
                                else
                                {
                                    Irows = rows[i].ToString().Split(',');
                                }
                                // Irows = rows.ToString().Split(',');
                                if (str == "")
                                {
                                    str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                                    // taxdatapsgr = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                    taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                }
                                else
                                {
                                    if (Irows[0].ToString() == "")
                                    {
                                    }
                                    else
                                    {
                                        str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                                        //  taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                        taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                    }
                                }
                            }
                        }
                        else
                        {
                            Irows = dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Split(',');

                            // Irows = rows.ToString().Split(',');
                            if (str == "")
                            {
                                str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                                //taxdatapsgr = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            }
                            else
                            {
                                if (Irows[0].ToString() == "")
                                {
                                }
                                else
                                {
                                    str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                                    // taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                    taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                }
                            }


                        }


                        //}

                        #region Pricing

                        XmlPricingRequest = "<PriceRequest><noadults>" + dtid.Tables[0].Rows[0]["AdultPax"].ToString() + "</noadults><nochild>" + dtid.Tables[0].Rows[0]["ChildPax"].ToString() + "</nochild><noinfant>" + dtid.Tables[0].Rows[0]["InfantPax"].ToString() + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry>" + str + "</FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails>";
                        XmlPricingRequest = XmlPricingRequest + "<onward><FlightSegments>";

                        foreach (DataRow row in dsdbsave.Tables[0].Rows)
                        {
                            AirEquipType = row["AirEquipType"].ToString();
                            ArrivalAirportCode = row["ArrivalAirportCode"].ToString();
                            ArrivalAirportName = row["ArrivalAirportName"].ToString();
                            ArrivalDateTime = row["ArrivalDateTime"].ToString();
                            DepartureAirportCode = row["DepartureAirportCode"].ToString();
                            DepartureAirportName = row["DepartureAirportName"].ToString();
                            DepartureDateTime = row["DepartureDateTime"].ToString();
                            FlightNumber = row["FlightNumber"].ToString();
                            MarketingAirlineCode = row["MarketingAirlineCode"].ToString();
                            OperatingAirlineCode = row["OperatingAirlineCode"].ToString();
                            OperatingAirlineName = row["OperatingAirlineName"].ToString();
                            OperatingAirlineFlightNumber = row["OperatingAirlineFlightNumber"].ToString();
                            NumStops = row["NumStops"].ToString();
                            LinkSellAgrmnt = row["LinkSellAgrmnt"].ToString();
                            Conx = row["Conx"].ToString();
                            AirpChg = row["AirpChg"].ToString();
                            InsideAvailOption = row["InsideAvailOption"].ToString();
                            GenTrafRestriction = row["GenTrafRestriction"].ToString();
                            DaysOperates = row["DaysOperates"].ToString();
                            JrnyTm = row["JrnyTm"].ToString();
                            EndDt = row["EndDt"].ToString();
                            StartTerminal = row["StartTerminal"].ToString();
                            EndTerminal = row["EndTerminal"].ToString();
                            FltTm = row["FltTm"].ToString();
                            LSAInd = row["LSAInd"].ToString();
                            Mile = row["Mile"].ToString();


                            Availability = row["Availability"].ToString();
                            BIC = row["BIC"].ToString();
                            bookingclass = row["bookingclass"].ToString();
                            classType = row["classType"].ToString();
                            farebasiscode = row["farebasiscode"].ToString();
                            Rule = row["Fare_Rule"].ToString();

                            FarePsgrType = row["PsgrType"].ToString();
                            FareBaseFare = row["BaseFare"].ToString();
                            FareTax1 = row["psgrTax"].ToString();
                            BagInfo = row["BagInfo"].ToString();



                            XmlPricingRequest = XmlPricingRequest + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
                            XmlPricingRequest = XmlPricingRequest + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
                            // XmlPricingRequest = XmlPricingRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";
                            XmlPricingRequest = XmlPricingRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgr + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";

                        }

                    }
                }

                #region old flightsegment



                //if (dtFlightSegment.Rows.Count > 0)
                //{
                //    DataRow[] rowFilghtSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsID);
                //    for (int j = 0; j < rowFilghtSegment.Length; j++)
                //    {
                //        AirEquipType = rowFilghtSegment[j]["AirEquipType"].ToString();
                //        ArrivalAirportCode = rowFilghtSegment[j]["ArrivalAirportCode"].ToString();
                //        ArrivalAirportName = rowFilghtSegment[j]["ArrivalAirportName"].ToString();
                //        ArrivalDateTime = rowFilghtSegment[j]["ArrivalDateTime"].ToString();
                //        DepartureAirportCode = rowFilghtSegment[j]["DepartureAirportCode"].ToString();
                //        DepartureAirportName = rowFilghtSegment[j]["DepartureAirportName"].ToString();
                //        DepartureDateTime = rowFilghtSegment[j]["DepartureDateTime"].ToString();
                //        FlightNumber = rowFilghtSegment[j]["FlightNumber"].ToString();
                //        MarketingAirlineCode = rowFilghtSegment[j]["MarketingAirlineCode"].ToString();
                //        OperatingAirlineCode = rowFilghtSegment[j]["OperatingAirlineCode"].ToString();
                //        OperatingAirlineName = rowFilghtSegment[j]["OperatingAirlineName"].ToString();
                //        OperatingAirlineFlightNumber = rowFilghtSegment[j]["OperatingAirlineFlightNumber"].ToString();
                //        NumStops = rowFilghtSegment[j]["NumStops"].ToString();
                //        LinkSellAgrmnt = rowFilghtSegment[j]["LinkSellAgrmnt"].ToString();
                //        Conx = rowFilghtSegment[j]["Conx"].ToString();
                //        AirpChg = rowFilghtSegment[j]["AirpChg"].ToString();
                //        InsideAvailOption = rowFilghtSegment[j]["InsideAvailOption"].ToString();
                //        GenTrafRestriction = rowFilghtSegment[j]["GenTrafRestriction"].ToString();
                //        DaysOperates = rowFilghtSegment[j]["DaysOperates"].ToString();
                //        JrnyTm = rowFilghtSegment[j]["JrnyTm"].ToString();
                //        EndDt = rowFilghtSegment[j]["EndDt"].ToString();
                //        StartTerminal = rowFilghtSegment[j]["StartTerminal"].ToString();
                //        EndTerminal = rowFilghtSegment[j]["EndTerminal"].ToString();
                //        FltTm = rowFilghtSegment[j]["FltTm"].ToString();
                //        LSAInd = rowFilghtSegment[j]["LSAInd"].ToString();
                //        Mile = rowFilghtSegment[j]["Mile"].ToString();


                //        XmlPricingRequest = XmlPricingRequest + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
                //        XmlPricingRequest = XmlPricingRequest + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
                //        // XmlPricingRequest = XmlPricingRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";
                //        XmlPricingRequest = XmlPricingRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgr + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";
                //    }
                //}
                #endregion

                XmlPricingRequest = XmlPricingRequest + "</FlightSegments></onward><Return>" + return1 + "</Return><id>" + id1 + "</id><key>" + key + "</key>";
                XmlPricingRequest = XmlPricingRequest + "</OriginDestinationOption></PriceRequest>";

                DataSet dsPricingResponse = objFlightsBal.GetDatasetFromAPI(XmlPricingRequest, "http://live.arzoo.com:9302/Pricing");



                        #endregion



                //  string ref1 = Common.GetFlightsReferenceNo("LJIF");

                string ref1 = Session["Order_Id"].ToString();

                string xmlRequest = "<Bookingrequest><noadults>" + dtid.Tables[0].Rows[0]["AdultPax"].ToString() + "</noadults><nochild>" + dtid.Tables[0].Rows[0]["ChildPax"].ToString() + "</nochild><noinfant>" + dtid.Tables[0].Rows[0]["InfantPax"].ToString() + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><creditcardno></creditcardno><PartnerreferenceID>" + ref1 + "</PartnerreferenceID>";
                xmlRequest = xmlRequest + "<personName>";

                ///details changing
                //   string strname = Convert.ToString(Session["customerInfo"]);
                string strname = dsdbsave.Tables[0].Rows[0]["CustomerDetails"].ToString();
                string[] strrows = strname.ToString().Split(';');
                int id = strrows.Count();
                for (int m = 0; m < id; m++)
                {
                    if (strrows[m].Contains("adt"))
                    {
                        string[] stradt = strrows[m].ToString().Split('|');
                        xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + stradt[1].ToString() + "</givenName><surName>" + stradt[2].ToString() + "</surName><nameReference>" + stradt[0].ToString() + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                    }
                    if (strrows[m].Contains("chd"))
                    {
                        string[] strchd = strrows[m].ToString().Split('|');
                        xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + strchd[1].ToString() + "</givenName><surName>" + strchd[2].ToString() + "</surName><nameReference>" + strchd[0].ToString() + "</nameReference><dob>" + strchd[5].ToString() + "</dob><age>" + strchd[4].ToString() + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                    }
                    if (strrows[m].Contains("inf"))
                    {
                        string[] strinf = strrows[m].ToString().Split('|');
                        xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + strinf[1].ToString() + "</givenName><surName>" + strinf[2].ToString() + "</surName><nameReference>" + strinf[0].ToString() + "</nameReference><dob>" + strinf[5].ToString() + "</dob><age>" + strinf[4].ToString() + "</age><psgrtype>inf</psgrtype></CustomerInfo>";

                    }
                }


                #region commentdata



                // Dynamic generation of names of adults, infants , Child
                //Table tbladults = (Table)this.UpdatePanel2.FindControl("tblAdultsInt");
                //for (int i = 1; i <= adultCntInt; i++)
                //{

                //    TextBox txtFn = (TextBox)tbladults.FindControl("txtFnInt" + i);
                //    TextBox txtLn = (TextBox)tbladults.FindControl("txtLnInt" + i);
                //    DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitleInt" + i);


                //    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                //}

                //Table tblChild = (Table)this.UpdatePanel2.FindControl("tblChildInt");
                //for (int i = 1; i <= childCntInt; i++)
                //{
                //    TextBox txtFn = (TextBox)tblChild.FindControl("txtCFnInt" + i);

                //    TextBox txtLn = (TextBox)tblChild.FindControl("txtCLnInt" + i);

                //    DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitleInt" + i);


                //    TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDateInt" + i);

                //    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                //    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                //}

                //Table tblInfants = (Table)this.UpdatePanel2.FindControl("tblInfantsInt");
                //for (int i = 1; i <= infantCntInt; i++)
                //{
                //    TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFnInt" + i);

                //    TextBox txtLn = (TextBox)tblInfants.FindControl("txtILnInt" + i);

                //    DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitleInt" + i);

                //    TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDateInt" + i);
                //    string age = string.Empty;
                //    if (txtBirthDate != null)
                //        age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();
                //    else
                //        age = "0";
                //    //if (Convert.ToInt32(age) == 12)
                //    //{
                //    //    Literal lit = new Literal();
                //    //    lit.Text = txtFn.Text + " Age should be below 1 yr.";
                //    //    this.Controls.Add(lit);
                //    //    break;
                //    //}

                //    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
                //}

                #endregion


                xmlRequest = xmlRequest + "</personName><telePhone><phoneNumber>" + dsdbsave.Tables[0].Rows[0]["Telephone"].ToString() + "</phoneNumber></telePhone><email><emailAddress>" + dsdbsave.Tables[0].Rows[0]["EmailAddress"].ToString() + "</emailAddress></email>";
                //xmlRequest = xmlRequest + "<OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>" + PsgrType + "</PsgrType><BaseFare>" + BaseFare + "</BaseFare><Tax>" + FareTax + "</Tax><TaxDataAry>";
                //xmlRequest = xmlRequest + taxData + "</TaxDataAry></Fare></FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails><onward><FlightSegments>";
                xmlRequest = xmlRequest + "<OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry>";
                xmlRequest = xmlRequest + str + "</FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails><onward><FlightSegments>";


                foreach (DataRow row in dsdbsave.Tables[0].Rows)
                {
                    AirEquipType = row["AirEquipType"].ToString();
                    ArrivalAirportCode = row["ArrivalAirportCode"].ToString();
                    ArrivalAirportName = row["ArrivalAirportName"].ToString();
                    ArrivalDateTime = row["ArrivalDateTime"].ToString();
                    DepartureAirportCode = row["DepartureAirportCode"].ToString();
                    DepartureAirportName = row["DepartureAirportName"].ToString();
                    DepartureDateTime = row["DepartureDateTime"].ToString();
                    FlightNumber = row["FlightNumber"].ToString();
                    MarketingAirlineCode = row["MarketingAirlineCode"].ToString();
                    OperatingAirlineCode = row["OperatingAirlineCode"].ToString();
                    OperatingAirlineName = row["OperatingAirlineName"].ToString();
                    OperatingAirlineFlightNumber = row["OperatingAirlineFlightNumber"].ToString();
                    NumStops = row["NumStops"].ToString();
                    LinkSellAgrmnt = row["LinkSellAgrmnt"].ToString();
                    Conx = row["Conx"].ToString();
                    AirpChg = row["AirpChg"].ToString();
                    InsideAvailOption = row["InsideAvailOption"].ToString();
                    GenTrafRestriction = row["GenTrafRestriction"].ToString();
                    DaysOperates = row["DaysOperates"].ToString();
                    JrnyTm = row["JrnyTm"].ToString();
                    EndDt = row["EndDt"].ToString();
                    StartTerminal = row["StartTerminal"].ToString();
                    EndTerminal = row["EndTerminal"].ToString();
                    FltTm = row["FltTm"].ToString();
                    LSAInd = row["LSAInd"].ToString();
                    Mile = row["Mile"].ToString();

                    Availability = row["Availability"].ToString();
                    BIC = row["BIC"].ToString();
                    bookingclass = row["bookingclass"].ToString();
                    classType = row["classType"].ToString();
                    farebasiscode = row["farebasiscode"].ToString();
                    Rule = row["Fare_Rule"].ToString();

                    FarePsgrType = row["PsgrType"].ToString();
                    FareBaseFare = row["BaseFare"].ToString();
                    FareTax1 = row["psgrTax"].ToString();
                    BagInfo = row["BagInfo"].ToString();

                    xmlRequest = xmlRequest + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
                    xmlRequest = xmlRequest + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
                    xmlRequest = xmlRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";

                }

                #region old


                //if (dtFlightSegment.Rows.Count > 0)
                //{
                //    DataRow[] rowFilghtSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsID);
                //    for (int j = 0; j < rowFilghtSegment.Length; j++)
                //    {
                //        AirEquipType = rowFilghtSegment[j]["AirEquipType"].ToString();
                //        ArrivalAirportCode = rowFilghtSegment[j]["ArrivalAirportCode"].ToString();
                //        ArrivalAirportName = rowFilghtSegment[j]["ArrivalAirportName"].ToString();
                //        ArrivalDateTime = rowFilghtSegment[j]["ArrivalDateTime"].ToString();
                //        DepartureAirportCode = rowFilghtSegment[j]["DepartureAirportCode"].ToString();
                //        DepartureAirportName = rowFilghtSegment[j]["DepartureAirportName"].ToString();
                //        DepartureDateTime = rowFilghtSegment[j]["DepartureDateTime"].ToString();
                //        FlightNumber = rowFilghtSegment[j]["FlightNumber"].ToString();
                //        MarketingAirlineCode = rowFilghtSegment[j]["MarketingAirlineCode"].ToString();
                //        OperatingAirlineCode = rowFilghtSegment[j]["OperatingAirlineCode"].ToString();
                //        OperatingAirlineName = rowFilghtSegment[j]["OperatingAirlineName"].ToString();
                //        OperatingAirlineFlightNumber = rowFilghtSegment[j]["OperatingAirlineFlightNumber"].ToString();
                //        NumStops = rowFilghtSegment[j]["NumStops"].ToString();
                //        LinkSellAgrmnt = rowFilghtSegment[j]["LinkSellAgrmnt"].ToString();
                //        Conx = rowFilghtSegment[j]["Conx"].ToString();
                //        AirpChg = rowFilghtSegment[j]["AirpChg"].ToString();
                //        InsideAvailOption = rowFilghtSegment[j]["InsideAvailOption"].ToString();
                //        GenTrafRestriction = rowFilghtSegment[j]["GenTrafRestriction"].ToString();
                //        DaysOperates = rowFilghtSegment[j]["DaysOperates"].ToString();
                //        JrnyTm = rowFilghtSegment[j]["JrnyTm"].ToString();
                //        EndDt = rowFilghtSegment[j]["EndDt"].ToString();
                //        StartTerminal = rowFilghtSegment[j]["StartTerminal"].ToString();
                //        EndTerminal = rowFilghtSegment[j]["EndTerminal"].ToString();
                //        FltTm = rowFilghtSegment[j]["FltTm"].ToString();
                //        LSAInd = rowFilghtSegment[j]["LSAInd"].ToString();
                //        Mile = rowFilghtSegment[j]["Mile"].ToString();


                //        xmlRequest = xmlRequest + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
                //        xmlRequest = xmlRequest + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
                //        xmlRequest = xmlRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";
                //    }
                //}
                #endregion
                xmlRequest = xmlRequest + "</FlightSegments></onward><Return>" + return1 + "</Return><id>" + id1 + "</id><key>" + key + "</key>";
                xmlRequest = xmlRequest + "</OriginDestinationOption></Bookingrequest>";

                #region Unwanted Code
                //xmlRequest = "<Bookingrequest><noadults>1</noadults><nochild>0</nochild><noinfant>0</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid>";
                //xmlRequest = xmlRequest + "<Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><creditcardno></creditcardno><PartnerreferenceID>" + ref1 + "</PartnerreferenceID><personName><CustomerInfo><givenName>Bindu</givenName> <surName>B</surName>";
                //xmlRequest = xmlRequest + "<nameReference>Mrs.</nameReference>";
                //xmlRequest = xmlRequest + "<psgrtype>adt</psgrtype>";
                //xmlRequest = xmlRequest + "</CustomerInfo>";
                //xmlRequest = xmlRequest + "</personName>";
                //xmlRequest = xmlRequest + "<telePhone>";
                //xmlRequest = xmlRequest + "<phoneNumber>9701213996</phoneNumber>";
                //xmlRequest = xmlRequest + "</telePhone>";
                //xmlRequest = xmlRequest + "<email>";
                //xmlRequest = xmlRequest + "<emailAddress>bindu.v@i2space.com</emailAddress>";
                //xmlRequest = xmlRequest + "</email>";
                //xmlRequest = xmlRequest + "<OriginDestinationOption>";
                //xmlRequest = xmlRequest + "<FareDetails>";
                //xmlRequest = xmlRequest + "<ActualBaseFare>21250</ActualBaseFare>";
                //xmlRequest = xmlRequest + "<Tax>19675</Tax>";
                //xmlRequest = xmlRequest + "<STax>264</STax>";
                //xmlRequest = xmlRequest + "<TCharge>0</TCharge>";
                //xmlRequest = xmlRequest + "<SCharge>0</SCharge>";
                //xmlRequest = xmlRequest + "<TDiscount>0</TDiscount>";
                //xmlRequest = xmlRequest + "<TMarkup>0</TMarkup>";
                //xmlRequest = xmlRequest + "<TPartnerCommission>0</TPartnerCommission>";
                //xmlRequest = xmlRequest + "<TSdiscount>0</TSdiscount>";
                //xmlRequest = xmlRequest + "<FareBreakup>";
                //xmlRequest = xmlRequest + "<FareAry>";
                //xmlRequest = xmlRequest + "<Fare>";
                //xmlRequest = xmlRequest + "<PsgrType>ADT</PsgrType>";
                //xmlRequest = xmlRequest + "<BaseFare>21250</BaseFare>";
                //xmlRequest = xmlRequest + "<Tax>19675</Tax>";
                //xmlRequest = xmlRequest + "<TaxDataAry>";
                //xmlRequest = xmlRequest + "<TaxData>";
                //xmlRequest = xmlRequest + "<Country>YQ</Country>";
                //xmlRequest = xmlRequest + "<Amt>0</Amt>";
                //xmlRequest = xmlRequest + "</TaxData>";
                //xmlRequest = xmlRequest + "<TaxData>";
                //xmlRequest = xmlRequest + "<Country>WO</Country>";
                //xmlRequest = xmlRequest + "<Amt>7108</Amt>";
                //xmlRequest = xmlRequest + "</TaxData>";
                //xmlRequest = xmlRequest + "<TaxData>";
                //xmlRequest = xmlRequest + "<Country>Other</Country>";
                //xmlRequest = xmlRequest + "<Amt>12567</Amt>";
                //xmlRequest = xmlRequest + "</TaxData>";
                //xmlRequest = xmlRequest + "</TaxDataAry>";
                //xmlRequest = xmlRequest + "</Fare>";
                //xmlRequest = xmlRequest + "</FareAry>";
                //xmlRequest = xmlRequest + "</FareBreakup>";
                //xmlRequest = xmlRequest + "<ocTax>0</ocTax>";
                //xmlRequest = xmlRequest + "</FareDetails>";
                //xmlRequest = xmlRequest + "<onward>";
                //xmlRequest = xmlRequest + "<FlightSegments>";
                //xmlRequest = xmlRequest + "<FlightSegment>";
                //xmlRequest = xmlRequest + "<AirEquipType>744</AirEquipType>";
                //xmlRequest = xmlRequest + "<ArrivalAirportCode>LHR</ArrivalAirportCode>";
                //xmlRequest = xmlRequest + "<ArrivalAirportName>London</ArrivalAirportName>";
                //xmlRequest = xmlRequest + "<ArrivalDateTime>2012-11-19T13:25:00</ArrivalDateTime>";
                //xmlRequest = xmlRequest + "<DepartureAirportCode>BLR</DepartureAirportCode>";
                //xmlRequest = xmlRequest + "<DepartureAirportName>BANGALORE</DepartureAirportName>";
                //xmlRequest = xmlRequest + "<DepartureDateTime>2012-11-19T07:50:00</DepartureDateTime>";
                //xmlRequest = xmlRequest + "<FlightNumber>6656</FlightNumber>";
                //xmlRequest = xmlRequest + "<MarketingAirlineCode>AA</MarketingAirlineCode>";
                //xmlRequest = xmlRequest + "<OperatingAirlineCode>BA</OperatingAirlineCode>";
                //xmlRequest = xmlRequest + "<OperatingAirlineName>American Airlines </OperatingAirlineName>";
                //xmlRequest = xmlRequest + "<OperatingAirlineFlightNumber>6656</OperatingAirlineFlightNumber>";
                //xmlRequest = xmlRequest + "<NumStops>0</NumStops>";
                //xmlRequest = xmlRequest + "<LinkSellAgrmnt />";
                //xmlRequest = xmlRequest + "<Conx>N</Conx>";
                //xmlRequest = xmlRequest + "<AirpChg>N</AirpChg>";
                //xmlRequest = xmlRequest + "<InsideAvailOption>C</InsideAvailOption>";
                //xmlRequest = xmlRequest + "<GenTrafRestriction>?</GenTrafRestriction>";
                //xmlRequest = xmlRequest + "<DaysOperates>NA</DaysOperates>";
                //xmlRequest = xmlRequest + "<JrnyTm>665</JrnyTm>";
                //xmlRequest = xmlRequest + "<EndDt />";
                //xmlRequest = xmlRequest + "<StartTerminal />";
                //xmlRequest = xmlRequest + "<EndTerminal />";
                //xmlRequest = xmlRequest + "<FltTm>665</FltTm>";
                //xmlRequest = xmlRequest + "<LSAInd>R</LSAInd>";
                //xmlRequest = xmlRequest + "<Mile>0</Mile>";
                //xmlRequest = xmlRequest + "<BookingClass>";
                //xmlRequest = xmlRequest + "<Availability>1</Availability>";
                //xmlRequest = xmlRequest + "<BIC>S</BIC>";
                //xmlRequest = xmlRequest + "</BookingClass>";
                //xmlRequest = xmlRequest + "<BookingClassFare>";
                //xmlRequest = xmlRequest + "<bookingclass>S</bookingclass>";
                //xmlRequest = xmlRequest + "<classType>Economy</classType>";
                //xmlRequest = xmlRequest + "<farebasiscode>ZeHo17My7PSA3CBU2WO9J34bX8FEuX61F9zkShsUkYU=</farebasiscode>";
                //xmlRequest = xmlRequest + "<Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule>";
                //xmlRequest = xmlRequest + "<PsgrBreakup>";
                //xmlRequest = xmlRequest + "<PsgrAry>";
                //xmlRequest = xmlRequest + "<Psgr>";
                //xmlRequest = xmlRequest + "<PsgrType>ADT</PsgrType>";
                //xmlRequest = xmlRequest + "<BaseFare>21250</BaseFare>";
                //xmlRequest = xmlRequest + "<Tax>19675</Tax>";
                //xmlRequest = xmlRequest + "<BagInfo />";
                //xmlRequest = xmlRequest + "</Psgr>";
                //xmlRequest = xmlRequest + "</PsgrAry>";
                //xmlRequest = xmlRequest + "</PsgrBreakup>";
                //xmlRequest = xmlRequest + "</BookingClassFare>";
                //xmlRequest = xmlRequest + "</FlightSegment>";
                //xmlRequest = xmlRequest + "<FlightSegment>";
                //xmlRequest = xmlRequest + "<AirEquipType>777</AirEquipType>";
                //xmlRequest = xmlRequest + "<ArrivalAirportCode>JFK</ArrivalAirportCode>";
                //xmlRequest = xmlRequest + "<ArrivalAirportName>NEW YORK</ArrivalAirportName>";
                //xmlRequest = xmlRequest + "<ArrivalDateTime>2012-11-19T18:10:00</ArrivalDateTime>";
                //xmlRequest = xmlRequest + "<DepartureAirportCode>LHR</DepartureAirportCode>";
                //xmlRequest = xmlRequest + "<DepartureAirportName>London</DepartureAirportName>";
                //xmlRequest = xmlRequest + "<DepartureDateTime>2012-11-19T15:15:00</DepartureDateTime>";
                //xmlRequest = xmlRequest + "<FlightNumber>6134</FlightNumber>";
                //xmlRequest = xmlRequest + "<MarketingAirlineCode>AA</MarketingAirlineCode>";
                //xmlRequest = xmlRequest + "<OperatingAirlineCode>BA</OperatingAirlineCode>";
                //xmlRequest = xmlRequest + "<OperatingAirlineName>American Airlines </OperatingAirlineName>";
                //xmlRequest = xmlRequest + "<OperatingAirlineFlightNumber>6134</OperatingAirlineFlightNumber>";
                //xmlRequest = xmlRequest + "<NumStops>0</NumStops>";
                //xmlRequest = xmlRequest + "<LinkSellAgrmnt />";
                //xmlRequest = xmlRequest + "<Conx>N</Conx>";
                //xmlRequest = xmlRequest + "<AirpChg>N</AirpChg>";
                //xmlRequest = xmlRequest + "<InsideAvailOption>C</InsideAvailOption>";
                //xmlRequest = xmlRequest + "<GenTrafRestriction>?</GenTrafRestriction>";
                //xmlRequest = xmlRequest + "<DaysOperates>NA</DaysOperates>";
                //xmlRequest = xmlRequest + "<JrnyTm>985</JrnyTm>";
                //xmlRequest = xmlRequest + "<EndDt />";
                //xmlRequest = xmlRequest + "<StartTerminal />";
                //xmlRequest = xmlRequest + "<EndTerminal />";
                //xmlRequest = xmlRequest + "<FltTm>985</FltTm>";
                //xmlRequest = xmlRequest + "<LSAInd>R</LSAInd>";
                //xmlRequest = xmlRequest + "<Mile>0</Mile>";
                //xmlRequest = xmlRequest + "<BookingClass>";
                //xmlRequest = xmlRequest + "<Availability>7</Availability>";
                //xmlRequest = xmlRequest + "<BIC>S</BIC>";
                //xmlRequest = xmlRequest + "</BookingClass>";
                //xmlRequest = xmlRequest + "<BookingClassFare>";
                //xmlRequest = xmlRequest + "<bookingclass>S</bookingclass>";
                //xmlRequest = xmlRequest + "<classType>Economy</classType>";
                //xmlRequest = xmlRequest + "<farebasiscode>ZeHo17My7PSA3CBU2WO9J34bX8FEuX61F9zkShsUkYU=</farebasiscode>";
                //xmlRequest = xmlRequest + "<Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule>";
                //xmlRequest = xmlRequest + "<PsgrBreakup>";
                //xmlRequest = xmlRequest + "<PsgrAry>";
                //xmlRequest = xmlRequest + "<Psgr>";
                //xmlRequest = xmlRequest + "<PsgrType>ADT</PsgrType>";
                //xmlRequest = xmlRequest + "<BaseFare>21250</BaseFare>";
                //xmlRequest = xmlRequest + "<Tax>19675</Tax>";
                //xmlRequest = xmlRequest + "<BagInfo />";
                //xmlRequest = xmlRequest + "</Psgr>";
                //xmlRequest = xmlRequest + "</PsgrAry>";
                //xmlRequest = xmlRequest + "</PsgrBreakup>";
                //xmlRequest = xmlRequest + "</BookingClassFare>";
                //xmlRequest = xmlRequest + "</FlightSegment>";
                //xmlRequest = xmlRequest + "</FlightSegments>";
                //xmlRequest = xmlRequest + "</onward>";
                //xmlRequest = xmlRequest + "<Return />";
                //xmlRequest = xmlRequest + "<id>arzoo13</id>";
                //xmlRequest = xmlRequest + "<key>";
                //xmlRequest = xmlRequest + "zWbxBFyA059f68R2DgKcVEb0gG2ZuxB2eOVHvZcIhsrrFUGZlB/H443Le2GIKliKcDol4S0eYt5n";
                //xmlRequest = xmlRequest + "4urlPHf4zwkxESOCSurS2zJT2fsu8E6Ny3thiCpYihRRnjyQGrh7hXWLu9m7LCssMPJ4Xz20E7cC";
                //xmlRequest = xmlRequest + "U/hS9xGE+mdK+SICvYvDvXFXubDdIyuoEEf9FbAN4z7uuUBbuJWfy8uNPG/9b2fi6uU8d/jPtkPz";
                //xmlRequest = xmlRequest + "+QotFGxf68R2DgKcVAxln+JT2sq20MHk4j4XRiE+dv3J10pg7QerGRHTwDoP0MHk4j4XRiFoKIn0";
                //xmlRequest = xmlRequest + "f2tgo/6/bBnC356utwJT+FL3EYQxhMrs9+Ll73qUfflxOSlgjct7YYgqWIooknPUNPq0fsMbz0mC";
                //xmlRequest = xmlRequest + "CnYdPxS/giio89vDvXFXubDdI5p3QtIQ6TM+X+vEdg4CnFSHVzKRaecmxRqaN5ZXELxy0MHk4j4X";
                //xmlRequest = xmlRequest + "RiFoKIn0f2tgo08iYOkW5WfDVAdtvjUETBAUbFQMZCvw/rcCU/hS9xGEV/KirOjbVWVf68R2DgKc";
                //xmlRequest = xmlRequest + "VIdXMpFp5ybFFnoP/rNoJySNy3thiCpYinP52+a6dCWv4z7uuUBbuJUr4zgoGssePSsZx2FQz4Qz";
                //xmlRequest = xmlRequest + "Mi4GIKZ/bQN5v2nhdWyUxWkXlLIRnKfWBOVnFhmDx7P+RkIizk8EmY3Le2GIKliKvHScqTjHzQGF";
                //xmlRequest = xmlRequest + "dYu72bssK9yA/LGYY4DttwJT+FL3EYR8llOd/AvvBcO9cVe5sN0jaHWZ74lyniM+CXHuBVUeI0eC";
                //xmlRequest = xmlRequest + "jTlyW+v3IvPKAXmAs/XjPu65QFu4lRIiMi13yfqv0MHk4j4XRiFoKIn0f2tgo3rxF/w/vseO0MHk";
                //xmlRequest = xmlRequest + "4j4XRiFoKIn0f2tgo08iYOkW5WfDtBFngPW6tS4UbFQMZCvw/rcCU/hS9xGEPmH+rCYA9GVn4url";
                //xmlRequest = xmlRequest + "PHf4z/KpTLVv6TwZmq/OLBKU+urDvXFXubDdI76GeeoT8f7/mZIC7bwXLBPEyJNwmQ0Hhl/rxHYO";
                //xmlRequest = xmlRequest + "ApxUwsS2F117BWpVx8rwsmCp/7cCU/hS9xGEO2M3JTnaOUPjPu65QFu4lcYxXFxB1Lxm2zJT2fsu";
                //xmlRequest = xmlRequest + "8E6Ny3thiCpYiskg7jRgjK6SgNO9QJL9N+kUA6rZxn6L2roVT2rwaaIHT9JeYXDjtB74LCthwRi6";
                //xmlRequest = xmlRequest + "QuM+7rlAW7iVci/YXLUgYhtn4urlPHf4z0sauaT5dh0YX+vEdg4CnFRm6meIMgjYjdDB5OI+F0Yh";
                //xmlRequest = xmlRequest + "aCiJ9H9rYKMzmFBNkf0Z9F/rxHYOApxU8q6B7/fP8qZn4urlPHf4z6xCf1SAy2vSGs5/DTSC7BXj";
                //xmlRequest = xmlRequest + "Pu65QFu4lXSi4I4fhBoPMaaYjNFAcsm3AlP4UvcRhPpnSvkiAr2Lw71xV7mw3SMrqBBH/RWwDeM+";
                //xmlRequest = xmlRequest + "7rlAW7iVdKLgjh+EGg9kUDg3MAXg5eM+7rlAW7iV3nbymUm4szIU66LMw4VmWYV1i7vZuywr4wJX";
                //xmlRequest = xmlRequest + "2WV2PV5f68R2DgKcVAxln+JT2sq20MHk4j4XRiEuvf9jqO9829DB5OI+F0YhE8ZmQzVYvJbgy4cv";
                //xmlRequest = xmlRequest + "1MfIol/rxHYOApxUuPBYmR6Sgw5f68R2DgKcVCB0cQSVLEagT+e92o4/qz5f68R2DgKcVMcBF2dl";
                //xmlRequest = xmlRequest + "btCnrziqklPvBLLl8OEMpKE9Rrqlvng58vzQsS7VmIqni8k6cEhUG/jNng==";
                //xmlRequest = xmlRequest + "</key>";
                //xmlRequest = xmlRequest + "</OriginDestinationOption>";
                //xmlRequest = xmlRequest + "</Bookingrequest>";

                #endregion
                StringBuilder stt = new StringBuilder();

                stt.Append("xmlRequest");
                stt.Append("=");
                stt.Append(Server.UrlEncode(xmlRequest));
                // stt.Append((xmlRequest).Replace("+", "%2B"));

                byte[] requestData = Encoding.UTF8.GetBytes(stt.ToString());


                //byte[] requestData = System.Text.Encoding.UTF8.GetBytes(xmlRequest.Replace("+","%2B"));

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Booking");

                //request.Accept = @"text/plain,application/xml";
                //request.ContentType = @"application/xml";
                //request.Method = @"POST";
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/json";
                // request.Accept = "en-us,en;q=0.5";


                //request.ContentType = "multipart/form-data";
                request.ContentLength = requestData.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(requestData, 0, requestData.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            result = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(result);
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);

                        ds.ReadXml(xmlReader);
                    }
                }
                Session["Response"] = ds;

                return ds;
            }
        
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
            return null;
        }

        //result = "<Bookingresponse><OriginDestinationOption><FareDetails><ActualBaseFare>85035</ActualBaseFare><Tax>4079</Tax><STax>1055</STax><TCharge>0</TCharge><SCharge>0</SCharge><TDiscount>0</TDiscount><TMarkup>150</TMarkup><TPartnerCommission>0</TPartnerCommission><TSdiscount>0</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>ADT</PsgrType><BaseFare>85035</BaseFare><Tax>4079</Tax></Fare></FareAry></FareBreakup></FareDetails><onward><FlightSegments><FlightSegment><AirEquipType>77W</AirEquipType><ArrivalAirportCode>LHR</ArrivalAirportCode><ArrivalAirportName>LONDON&lt;BR&gt; (HEATHROW)</ArrivalAirportName><ArrivalDateTime>2010-02-26T06:35:00</ArrivalDateTime><DepartureAirportCode>BOM</DepartureAirportCode><DepartureAirportName>MUMBAI&lt;BR&gt; (CHHATRAPATI SHIVAJI INTERNATIONAL)</DepartureAirportName><DepartureDateTime>2010-02-26T02:05:00</DepartureDateTime><FlightNumber>4131</FlightNumber><MarketingAirlineCode>BD</MarketingAirlineCode><OperatingAirlineCode>BD</OperatingAirlineCode><OperatingAirlineName>British Midland</OperatingAirlineName><OperatingAirlineFlightNumber>4131</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt></LinkSellAgrmnt><Conx>N</Conx><AirpChg>N</AirpChg><InsideAvailOption>C</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>NA</DaysOperates><JrnyTm></JrnyTm><EndDt></EndDt><StartTerminal></StartTerminal><EndTerminal></EndTerminal><FltTm>0</FltTm><LSAInd>R</LSAInd><Mile>0</Mile><BookingClass><Availability>9</Availability><BIC>Y</BIC></BookingClass><BookingClassFare><bookingclass>Y</bookingclass><classType>Economy</classType><farebasiscode>rb8QAsvpFIPpZo9gBUBg+6BMOP0MtJ7L</farebasiscode><Rule></Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>ADT</PsgrType><BaseFare>85035</BaseFare><Tax>4079</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment><FlightSegment><AirEquipType>346</AirEquipType><ArrivalAirportCode>JFK</ArrivalAirportCode><ArrivalAirportName>NEW YORK&lt;BR&gt; (JOHN F KENNEDY INTL)</ArrivalAirportName><ArrivalDateTime>2010-02-26T12:20:00</ArrivalDateTime><DepartureAirportCode>LHR</DepartureAirportCode><DepartureAirportName>LONDON&lt;BR&gt; (HEATHROW)</DepartureAirportName><DepartureDateTime>2010-02-26T09:20:00</DepartureDateTime><FlightNumber>8223</FlightNumber><MarketingAirlineCode>CO</MarketingAirlineCode><OperatingAirlineCode>CO</OperatingAirlineCode><OperatingAirlineName>Continental Airlines </OperatingAirlineName><OperatingAirlineFlightNumber>8223</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt></LinkSellAgrmnt><Conx>N</Conx><AirpChg>N</AirpChg><InsideAvailOption>C</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>NA</DaysOperates><JrnyTm></JrnyTm><EndDt></EndDt><StartTerminal></StartTerminal><EndTerminal></EndTerminal><FltTm>0</FltTm><LSAInd>R</LSAInd><Mile>0</Mile><BookingClass><Availability>4</Availability><BIC>L</BIC></BookingClass><BookingClassFare><bookingclass>L</bookingclass><classType>Economy</classType><farebasiscode>rb8QAsvpFIPpZo9gBUBg+6BMOP0MtJ7L</farebasiscode><Rule></Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>ADT</PsgrType><BaseFare>85035</BaseFare><Tax>4079</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment></FlightSegments></onward><Return/><id>arzoo100</id><key>ayCbutV8CZjQweTiPhdGIT52/cnXSmDtWDF6uoVa0Yx+dIrODcZqUYV1i7vZuywrXxtmsFOjbi9n4urlPHf4zxGFVKSEVPuglBZfw/aOkGOFdYu72bssKyww8nhfPbQTtwJT+FL3EYT6Z0r5IgK9i8O9cVe5sN0jK6gQR/0VsA3jPu65QFu4leESvkw2tYVo0MHk4j4XRiFoKIn0f2tgo+sVQZmUH8fjjct7YYgqWIoUUZ48kBq4e/0pg3DmQVVVo2Q3a0AUQSXLUP1Wu6PBd4V1i7vZuywrSdRter3iPenjPu65QFu4lbsv+JV45WPGtyljvg7883Sh2gnY0OmCJCn868u75ToLhXWLu9m7LCuMmusGneSEdRuxNaSOsudhnGqNtXQ916PjPu65QFu4lU2r9RVG+D9a0MHk4j4XRiFoKIn0f2tgozK2rkfhSWEWx6xZaH0ssx82RPW27flqmu5f2a5HBe02z/lJy0jWbT0M1G6o3Y+hzWfi6uU8d/jPAJdXKqYIvc5G93zQPY0iVQD8L1fsyfdm6xVBmZQfx+ONy3thiCpYihlAiI3xsTJF4z7uuUBbuJUEGsOfbTr3UF/rxHYOApxUsDfYCka6IQumFoD34DG1PbcCU/hS9xGEMwKsr63khSb3Qspj6nxBZe9bfmEZ7GUgEriX6+12U2wkVz4JY1XabcCU/hS9xGEcUGtscRHmuLDvXFXubDdIz12g5QheQXO4z7uuUBbuJVmadCAqLb2y2fi6uU8d/jPS1i6Qoti3wtoJoL9ZE4l6rEu1ZiKp4vJfk8fwf1jcc9f68R2DgKcVK1lGTAnSPxSl9HJUgz+eC+FdYu72bssKzNAqSxshbWRYUz9VFYzmixqeExNPowVA78GaMTl9BYe0fUDu2DE3rHDvXFXubDdI3dYiTg2zkNgU+gGkoFGtlfAPC2FpjoIsV/rxHYOApxURZOpRI/EzoEVg7MnTiMjPoV1i7vZuywrp7AOSJb8tei2GAYztr4tGO6Udvv6goYtX+vEdg4CnFThuwJPu5BuYitpzzDzl21bJ/v5/y98kwILsR2pjhA21YV1i7vZuywrGJgEwhHzH+9n4urlPHf4zwMsIQITsGsy0MHk4j4XRiFoKIn0f2tgowznwUkbWS71w71xV7mw3SOi9DZLo5De59CaB/YiXgfO40U/DdrAcfnP5jcg4z9RPIZB8/lb/sd5w71xV7mw3SNZoQyFRfkMl+M+7rlAW7iVOm7uM/9yhhNn4urlPHf4z7kR+x0lYQ5LX+vEdg4CnFRKt+2PZYo+CjOuGPE4fK4oZ+Lq5Tx3+M9KeFGbag7+buM+7rlAW7iVdKLgjh+EGg8Mv3JUr8Yz2NNESEN0N1nFqHicn8G1rgW8dJypOMfNAYV1i7vZuywrLDDyeF89tBO3AlP4UvcRhPpnSvkiAr2L00RIQ3Q3WcWoeJyfwbWuBfSvd+pfPzkTw71xV7mw3SNdcG/zHitfN1rAgZFeAikBjct7YYgqWIpXyYBKr/eg5uM+7rlAW7iVygQsiztYTQ9f68R2DgKcVBCq+RQJHE/z</key></OriginDestinationOption><telePhone><phoneNumber>9879961339</phoneNumber></telePhone><email><emailAddress>bhavik.m@arzoo.com</emailAddress></email><noadults>1</noadults><nochild>0</nochild><noinfant>0</noinfant><Clientid>Given By Arzoo.com</Clientid><Clienttype>ArzooINTLWS1.0</Clienttype><creditcardno>1234567890123456</creditcardno><error></error><personName><CustomerInfo><givenName>Sagar</givenName><surName>Arora</surName><nameReference>Mr.</nameReference><psgrtype>adt</psgrtype></CustomerInfo></personName><status>SUCCESS</status><transid>A396009</transid></Bookingresponse>";

        //   XmlDocument doc = new XmlDocument();
        //   doc.LoadXml(result);
        //   XmlNodeReader xmlReader = new XmlNodeReader(doc);

        //   ds.ReadXml(xmlReader);
    }
    // bool val=true;
    #region Payment Gateway Code
    private void PaymentGateway()
    {
        try
        {

            Response.Redirect("~/pay.aspx?val=true", false);
        }
        catch (Exception ex)
        {

        }

    }
    #endregion


    protected void btnIntBookNow_Click(object sender, EventArgs e)
    {

        gdvIntFlights.Visible = trFilterSearch.Visible = false;
        pnlIntPassengerDet.Visible = true;
        pnlSearch.Visible = false;
        ModifySearch.Visible = false;


    }
    private void CreateControlsInt(int adultCntInt, int ChildCntInt, int infCntInt)
    {      

        #region Validations

        try
        {           
            #region DomesticFlights
            for (int i = 1; i <= adultCntInt; i++)
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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.Width = 55;
                ddlTitle.ID = "ddlTitleInt" + i;
                ddlTitle.Items.Add("Mr.");
                ddlTitle.Items.Add("Ms.");
                ddlTitle.Items.Add("Mrs.");
                ddlTitle.Attributes.Add("onchange", "javascript:AddTitle(this);");
                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";

                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();

                txtFn.MaxLength = 20;
                txtFn.CssClass = "lj_inp";
                // txtFn.Width = 110;
                txtFn.ID = "txtFnInt" + i;
                txtFn.Attributes.Add("onkeyup", "javascript:AddLetters(this);");
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell td6 = new TableCell();
                RequiredFieldValidator rfv2 = new RequiredFieldValidator();

                rfv2.ID = "rfv2" + i;
                rfv2.ControlToValidate = "txtFnInt" + i;
                rfv2.ErrorMessage = "Enter First Name";
                rfv2.Display = ValidatorDisplay.None;


                rfv2.ValidationGroup = "SubmitBook";
                td6.Controls.Add(rfv2);
                tr.Controls.Add(td6);


                TableCell td12 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fte1 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fte1.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                fte1.TargetControlID = "txtFnInt" + i;
                td12.Controls.Add(fte1);
                tr.Controls.Add(td12);




                TableCell td7 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceFirstName1 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceFirstName1.ID = "vceFirstName1" + i;
                vceFirstName1.TargetControlID = "rfv2" + i;

                td7.Controls.Add(vceFirstName1);
                tr.Controls.Add(td7);


                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.MaxLength = 20;
                txtLn.CssClass = "lj_inp";
                //txtLn.Width = 110;
                txtLn.ID = "txtLnInt" + i;
                txtLn.Attributes.Add("onkeyup", "javascript:AddLettersLn(this);");
                txtLn.Attributes.Add("onchange", "javascript:CheckMinChars(this);");
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);


                TableCell td5 = new TableCell();
                RequiredFieldValidator rfv1 = new RequiredFieldValidator();
                rfv1.ID = "rfv1" + i;
                rfv1.ControlToValidate = "txtLnInt" + i;
                rfv1.ErrorMessage = "Enter Last Name";
                rfv1.Display = ValidatorDisplay.None;
                rfv1.ValidationGroup = "SubmitBook";
                td5.Controls.Add(rfv1);
                tr.Controls.Add(td5);

                TableCell td8 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceLastName1 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceLastName1.ID = "vceLastName1" + i;
                vceLastName1.TargetControlID = "rfv1" + i;

                td8.Controls.Add(vceLastName1);
                tr.Controls.Add(td8);

                //TableCell td9 = new TableCell();
                //RegularExpressionValidator revLastName = new RegularExpressionValidator();
                //revLastName.ID = "revLastName" + i;
                //revLastName.ControlToValidate = "txtLn" + i;
                //revLastName.ValidationExpression = "^.{2,128}$" + i;
                //revLastName.ErrorMessage="Name Should be Minimum 2 Characters";
                //revLastName.Display=ValidatorDisplay.None;
                //revLastName.ValidationGroup="SubmitBook";
                //td9.Controls.Add(revLastName);
                //tr.Controls.Add(td9);

                //TableCell td9 = new TableCell();
                //RangeValidator rvLastName = new RangeValidator();
                //rvLastName.ID = "rvLastName" + i;
                //rvLastName.ControlToValidate = "txtLn" + i;
                //rvLastName.MinimumValue = "2";
                ////rvLastName.MaximumValue = "20";
                //rvLastName.ErrorMessage = "Name Shold be Minimum 2 Characters";
                //rvLastName.Display = ValidatorDisplay.None;
                //rvLastName.ValidationGroup = "SubmitBook";
                //td9.Controls.Add(rvLastName);
                //tr.Controls.Add(td9);




                //TableCell td10 = new TableCell();
                //AjaxControlToolkit.ValidatorCalloutExtender vceLastName11 = new AjaxControlToolkit.ValidatorCalloutExtender();
                //vceLastName11.ID = "vceLastName11" + i;
                //vceLastName11.TargetControlID = "rvLastName" + i;
                //td10.Controls.Add(vceLastName11);
                //tr.Controls.Add(td10);


                TableCell td13 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fte2 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fte2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                fte2.TargetControlID = "txtLnInt" + i;
                td12.Controls.Add(fte2);
                tr.Controls.Add(td13);

                tblAdultsInt.Controls.Add(tr);
            }

            for (int i = 1; i <= ChildCntInt; i++)
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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.ID = "ddlCTitleInt" + i;
                ddlTitle.Items.Add("Mstr.");
                ddlTitle.Items.Add("Miss.");
                ddlTitle.Width = 55;

                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.MaxLength = 20;
                txtFn.CssClass = "lj_inp";
                //txtFn.Width = 110;
                txtFn.ID = "txtCFnInt" + i;
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.MaxLength = 20;
                txtLn.CssClass = "lj_inp";
                //txtLn.Width = 110;
                txtLn.ID = "txtCLnInt" + i;

                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);

                TableCell tdBD = new TableCell();
                tdBD.Text = "DOB :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdBD);


                TableCell td5 = new TableCell();
                TextBox txtBirthDate = new TextBox();
                txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate(this);");
                txtBirthDate.Attributes.Add("onkeyup", "javascript:Adddob(this);");
                txtBirthDate.CssClass = "lj_inp";
                txtBirthDate.Width = 110;
                txtBirthDate.ID = "txtCBirthDateInt" + i;
                txtBirthDate.AutoPostBack = true;
                txtBirthDate.Attributes.Add("OnTextChanged", "javascript:GetYears(" + txtBirthDate.Text + "," + DateTime.Now + ")");
                td5.Controls.Add(txtBirthDate);


                TableCell td32 = new TableCell();
                RequiredFieldValidator rfv32 = new RequiredFieldValidator();
                rfv32.ID = "rfv32" + i;
                rfv32.ControlToValidate = "txtCBirthDateInt" + i;
                rfv32.ErrorMessage = "Enter Date Of Birth";
                rfv32.Display = ValidatorDisplay.None;
                rfv32.ValidationGroup = "SubmitBook";
                td32.Controls.Add(rfv32);
                tr.Controls.Add(td32);


                TableCell td33 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName33 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName33.ID = "vceCFirstName33" + i;
                vceCFirstName33.TargetControlID = "rfv32" + i;

                td32.Controls.Add(vceCFirstName33);
                tr.Controls.Add(td33);

                Label lblBirthDate = new Label();
                lblBirthDate.ID = "lblCBirthDateInt" + i;
                lblBirthDate.Text = "eg : 20-Oct-2012";


                td5.Controls.Add(lblBirthDate);
                tr.Controls.Add(td5);


                TableCell td6 = new TableCell();
                AjaxControlToolkit.CalendarExtender calExtChild = new AjaxControlToolkit.CalendarExtender();
                calExtChild.ID = "calExtChild" + i;
                calExtChild.TargetControlID = "txtCBirthDateInt" + i;
                calExtChild.Format = "dd-MMM-yyyy";
                td6.Controls.Add(calExtChild);
                tr.Controls.Add(td6);




                TableCell td7 = new TableCell();
                RequiredFieldValidator rfv7 = new RequiredFieldValidator();
                rfv7.ID = "rfv7" + i;
                rfv7.ControlToValidate = "txtCLnInt" + i;
                rfv7.ErrorMessage = "Enter Last Name";
                rfv7.Display = ValidatorDisplay.None;
                rfv7.ValidationGroup = "SubmitBook";
                td7.Controls.Add(rfv7);
                tr.Controls.Add(td7);

                TableCell td15 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender ftec2 = new AjaxControlToolkit.FilteredTextBoxExtender();
                ftec2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                ftec2.TargetControlID = "txtCLnInt" + i;
                td15.Controls.Add(ftec2);
                tr.Controls.Add(td15);




                TableCell td16 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName2 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName2.ID = "vceCFirstName2" + i;
                vceCFirstName2.TargetControlID = "rfv7" + i;

                td7.Controls.Add(vceCFirstName2);
                tr.Controls.Add(td7);




                TableCell td8 = new TableCell();
                RequiredFieldValidator rfv8 = new RequiredFieldValidator();
                rfv8.ID = "rfv8" + i;
                rfv8.ControlToValidate = "txtCFnInt" + i;
                rfv8.ErrorMessage = "Enter First Name";
                rfv8.Display = ValidatorDisplay.None;
                rfv8.ValidationGroup = "SubmitBook";
                td8.Controls.Add(rfv8);
                tr.Controls.Add(td8);

                TableCell td13 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender ftec1 = new AjaxControlToolkit.FilteredTextBoxExtender();
                ftec1.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                ftec1.TargetControlID = "txtCFnInt" + i;
                td13.Controls.Add(ftec1);
                tr.Controls.Add(td13);




                TableCell td14 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName1 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName1.ID = "vceCFirstName1" + i;
                vceCFirstName1.TargetControlID = "rfv8" + i;

                td7.Controls.Add(vceCFirstName1);
                tr.Controls.Add(td7);





                tblChildInt.Controls.Add(tr);

            }

            for (int i = 1; i <= infCntInt; i++)
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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.ID = "ddlITitleInt" + i;
                ddlTitle.Items.Add("Mstr.");
                ddlTitle.Items.Add("Miss.");
                ddlTitle.Width = 55;
                td2.Controls.Add(ddlTitle);
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.MaxLength = 20;
                txtFn.CssClass = "lj_inp";
                // txtFn.Width = 110;
                txtFn.ID = "txtIFnInt" + i;
                td3.Controls.Add(txtFn);
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell tdLN = new TableCell();
                tdLN.Text = "LastName :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdLN);


                TableCell td4 = new TableCell();
                TextBox txtLn = new TextBox();
                txtLn.MaxLength = 20;
                txtLn.CssClass = "lj_inp";
                //txtLn.Width = 110;
                txtLn.ID = "txtILn" + i;
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);

                TableCell tdBD = new TableCell();
                tdBD.Text = "DOB :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdBD);

                TableCell td5 = new TableCell();
                TextBox txtBirthDate = new TextBox();
                txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate(this);");
                txtBirthDate.Attributes.Add("onkeyup", "javascript:Adddob(this);");
                txtBirthDate.CssClass = "lj_inp";
                txtBirthDate.Width = 110;
                txtBirthDate.ID = "txtIBirthDate" + i;

                td5.Controls.Add(txtBirthDate);


                TableCell td30 = new TableCell();
                RequiredFieldValidator rfv30 = new RequiredFieldValidator();
                rfv30.ID = "rfv30" + i;
                rfv30.ControlToValidate = "txtIBirthDate" + i;
                rfv30.ErrorMessage = "Enter Date Of Birth";
                rfv30.Display = ValidatorDisplay.None;
                rfv30.ValidationGroup = "SubmitBook";
                td30.Controls.Add(rfv30);
                tr.Controls.Add(td30);


                TableCell td31 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName31 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName31.ID = "vceCFirstName31" + i;
                vceCFirstName31.TargetControlID = "rfv30" + i;

                td31.Controls.Add(vceCFirstName31);
                tr.Controls.Add(td31);


                Label lblBirthDate = new Label();
                lblBirthDate.ID = "lblIBirthDate" + i;
                lblBirthDate.Text = " eg : 20-Oct-2012";
                td5.Controls.Add(lblBirthDate);


                tr.Controls.Add(td5);
                // txtBirthDate.Attributes.Add("onkeypress", "javascript:return false");


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
                rfv9.Display = ValidatorDisplay.None;
                rfv9.ValidationGroup = "SubmitBook";
                td7.Controls.Add(rfv9);
                tr.Controls.Add(td7);

                TableCell td9 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fteIc1 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fteIc1.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                fteIc1.TargetControlID = "txtILn" + i;
                td9.Controls.Add(fteIc1);
                tr.Controls.Add(td9);




                TableCell td10 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceIFirstName1 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceIFirstName1.ID = "vceIFirstName1" + i;
                vceIFirstName1.TargetControlID = "rfv9" + i;

                td7.Controls.Add(vceIFirstName1);
                tr.Controls.Add(td10);






                TableCell td8 = new TableCell();
                RequiredFieldValidator rfv10 = new RequiredFieldValidator();
                rfv10.ID = "rfv10" + i;
                rfv10.ControlToValidate = "txtIFnInt" + i;
                rfv10.ErrorMessage = "Enter First Name";
                rfv10.Display = ValidatorDisplay.None;
                rfv10.ValidationGroup = "SubmitBook";
                td8.Controls.Add(rfv10);
                tr.Controls.Add(td8);


                TableCell td11 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fteIc2 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fteIc2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                fteIc2.TargetControlID = "txtIFnInt" + i;
                td9.Controls.Add(fteIc2);
                tr.Controls.Add(td11);




                TableCell td12 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceIFirstName2 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceIFirstName2.ID = "vceIFirstName2" + i;
                vceIFirstName1.TargetControlID = "rfv10" + i;

                td7.Controls.Add(vceIFirstName1);
                tr.Controls.Add(td10);

                tblInfantsInt.Controls.Add(tr);

            }
            #endregion

        }
        catch
        {
        }

        #endregion
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        if (!IsPostBack)
        {


        }
        else
        {


            CreateControlsInt(Convert.ToInt32(Session["adultCntInt"]), Convert.ToInt32(Session["childCntInt"]), Convert.ToInt32(Session["infantCntInt"]));

        }
    }

    private void BindAirportCodes(DataTable dtFlightsSegment)
    {
        try
        {

            DataTable dtAirlineNames = new DataTable();
            dtAirlineNames.Columns.Add("OperatingAirlineName");
            if (dtFlightsSegment.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFlightsSegment.Rows)
                {
                    dtAirlineNames.ImportRow(dr);
                }

            }
            chkAirlines.Items.Clear();
            DataTable dtDistinctAirlines = dtAirlineNames.DefaultView.ToTable(true);
            for (int i = 0; i < dtDistinctAirlines.Rows.Count; i++)
            {
                chkAirlines.Items.Add(dtDistinctAirlines.Rows[i][0].ToString());
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    protected void lnkDomesticFlights_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Agent/Flight/frmFlightsAvailability.aspx", false);

    }
    protected void lnkInternationalFlights_Click(object sender, EventArgs e)
    {


    }


    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {

            if (lblEmailAddress.Text != "")
            {
                downlink.Visible = false;
                string body = getHTML(pnlViewticket);
                bool res = MailSender.SendEmail(lblEmailAddress.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", body);
                downlink.Visible = true;
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
    string strtype = string.Empty;
    protected void GetDetailsForPrint(string RefNo)
    {
        try
        {
            FlightBAL objFlightsBAL = new FlightBAL();
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetInternationalFlightDetails(RefNo);

            if (dsFlights.Tables[0].Rows.Count > 0)
            {
                string customerDetails = dsFlights.Tables[0].Rows[0]["CustomerDetails"].ToString();
                string[] strArryCustDet = customerDetails.Split('|');
                lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                lblTel.Text = dsFlights.Tables[0].Rows[0]["Telephone"].ToString();
                lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();

                lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();

                lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
                //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                lblDepartureDate.Text = dt.ToLongDateString();
                lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                DateTime dt1 = Convert.ToDateTime(strArrivalDatetime[0].ToString());
                lblArrivalDate.Text = dt1.ToLongDateString();
                lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                //  lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblPsngrMobileNo.Text = dsFlights.Tables[0].Rows[0]["Telephone"].ToString();

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
                    if (strArryCustDet1[3].ToString() == "adt")
                    {
                        dr["Type"] = "Adult";
                        strtype = "Adult";
                    }
                    else
                        if (strArryCustDet1[3].ToString() == "chd")
                        {
                            dr["Type"] = "Child";
                            strtype = strtype + "," + "Child";
                        }
                        else
                            if (strArryCustDet1[3].ToString() == "inf")
                            {
                                dr["Type"] = "Infant";
                                strtype = strtype + "," + "Infant";
                            }
                    if (strArryCustDet1[3].ToString() != "inf")
                    {
                        dr["Age"] = strArryCustDet1[4];
                    }
                    else
                    {
                        dr["Age"] = strArryCustDet1[4] + "M";
                    }
                    dtPsgrDet.Rows.Add(dr);
                }

                gdvPassengerDetails.DataSource = dtPsgrDet;
                gdvPassengerDetails.DataBind();
                lblPassengerType.Text = strtype.ToString();
                lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                Label4.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]).ToString()); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                Double total = Convert.ToDouble(lblBasicFare.Text) + Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(Label4.Text) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"]); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString());
                lblTotal.Text = total.ToString("####0.00");
                pnlViewticket.Visible = true;

            }

            if (dsFlights.Tables[0].Rows.Count == 2)
            {
                //return 

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    printroundtrip.Visible = true;
                    lblAirlineNamereturn.Text = dsFlights.Tables[0].Rows[1]["OperatingAirlineName"].ToString();
                    //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumberreturn.Text = dsFlights.Tables[0].Rows[1]["FlightNumber"].ToString();

                    lblOriginRet.Text = dsFlights.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
                    lblDestinationRet.Text = dsFlights.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();
                    lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["EmailAddress"].ToString();
                    string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                    DateTime dt1 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                    lblDepartureDatereturn.Text = dt1.ToLongDateString();
                    lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                    DateTime dt = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                    lblArrivalDatereturn.Text = dt.ToLongDateString();
                    lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                    // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();

                    //string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                    //string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                    //string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["SchargeRet"])).ToString();
                    //string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts) - Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString())).ToString();
                    //lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                    //lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                    //lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                    //lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");

                }

            }

            //return en


            pnlViewticket.Visible = true;



        }


        catch (Exception ex)
        {

            throw;
        }

    }
    protected void getdatafromXMl()
    {
        try
        {
            DataTable DtLocSub = new DataTable();
            DataSet DsSub = new DataSet();
            DsSub.ReadXml(Server.MapPath("~/App_Data/" + "Airports.xml"));
            IEnumerable<DataRow> SubData = from i in DsSub.Tables[0].AsEnumerable()
                                           where i.Field<string>("Type") == "I" || i.Field<string>("Type") == "C"
                                           select i;


            if (SubData.Count() > 0)
            {
                DtLocSub = SubData.CopyToDataTable();

                DataSet ds = new DataSet();
                ds.Tables.Add(DtLocSub);
                Session["AirportsCode"] = ds;

                // DataSet ds = (DataSet)Session["AirportsCode"];

            }

            //if (SubData.Count() > 0)
            //{
            //Session["AirportsCode"] = SubData;

            //DtLocSub = DsSub.Tables[0];
            //    HttpContext.Current.Session["AirportsCode"] = DtLocSub;
            //  }

        }
        catch (Exception)
        {
            //  throw;
        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAirportCodes(string prefixText)
    {
        try
        {


            DataSet ds = new DataSet();

            FlightBAL objFlightBal = new FlightBAL();
           // ds = objFlightBal.GetAirportCodes();
            ds = (DataSet)HttpContext.Current.Session["AirportsCode"];
            HttpContext.Current.Session["AirportsCode"] = ds;
          //  string filteringquery = "CityName LIKE'" + prefixText + "%'";

           string filteringquery = "CityName LIKE'" + "%" + prefixText + "%" + "'" + "or " + "AirportCode like '" + "%" + prefixText + "%" + "'";

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
                airports.Add(dtNew.Rows[i]["CityName"].ToString().Trim() + "," + dtNew.Rows[i]["Country"].ToString().Trim() + "," + dtNew.Rows[i]["AirportDesc"].ToString().Trim() + " - (" + dtNew.Rows[i]["AirportCode"].ToString().Trim() + ")");
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
    bool b = true;
    protected void gdvconnectingflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsIntFlights = (DataSet)Session["dsIntFlights"];

                GridView gv = sender as GridView;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblFlightNumber = (Label)e.Row.FindControl("lblOperatingAirlineFlightNumber");
                    Label lblduration = (Label)e.Row.FindControl("lblduration");
                    LinkButton lblnoofstops = (LinkButton)e.Row.FindControl("lnkNoofstops");
                    Label lblviaflight = (Label)e.Row.FindControl("lblviaflight");
                    Label lblStartFlight = (Label)e.Row.FindControl("lblStartFlight");
                    Label lblstartDepart = (Label)e.Row.FindControl("lblstartDepart");
                    Label lblstopArrival = (Label)e.Row.FindControl("lblstopArrival");
                    Label lblStartFlight1 = (Label)e.Row.FindControl("lblStartFlight1");
                    Label lblstartDepart1 = (Label)e.Row.FindControl("lblstartDepart1");
                    Label lblstopArrival1 = (Label)e.Row.FindControl("lblstopArrival1");
                    Panel pnlstops = (Panel)e.Row.FindControl("pnlstops");

                    //Splitting the departuredatetime with T
                    Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblDeparts");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());
                    string format = "ddd , MMM  d, yyyy";
                    lbldepartdate.Text = dt.ToString(format);


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblArrives");
                    DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);

                    DateTime dt1 = Convert.ToDateTime(Arrtime[0].ToString());
                    lblarrivaldate.Text = dt1.ToString(format);

                    //Getting the Cityname basedon airport code for departure
                    Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    DataSet dsairports = (DataSet)Session["AirportsCode"];
                    DataTable dtair = dsairports.Tables[0];
                    DataRow[] daar = dtair.Select("AirportCode = '" + lblDepartureAirportCode.Text.Trim() + "'");
                    lblDepartureAirportCode.Text = daar[0]["CityName"].ToString();


                    //Getting the Cityname basedon airport code for arrival
                    Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    DataRow[] drcity = dtair.Select("AirportCode = '" + lblArrivalAirportCode.Text.Trim() + "'");
                    lblArrivalAirportCode.Text = drcity[0]["CityName"].ToString();

                    if (lblnoofstops.Text == "1")
                    {

                        //string s = lblviaflight.Text.Replace("<brbr>", " ");
                        //string[] s1 = s.Split(' ');

                        //string s2 = s1[0].Replace("<br>", " ");
                        //string[] s3 = s2.Split(' ');

                        //string s4 = s1[1].Replace("<br>", " ");
                        //string[] s5 = s4.Split(' ');
                        //if (s3[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[3].Split('T');
                        //    s3[3] = s6[1].ToString();
                        //}
                        //if (s3[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[5].Split('T');
                        //    s3[5] = s6[1].ToString();
                        //}
                        //if (s5[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[5].Split('T');
                        //    s5[5] = s6[1].ToString();
                        //}
                        //if (s5[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[3].Split('T');
                        //    s5[3] = s6[1].ToString();
                        //}
                        //lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                        //lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                        //lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                        //lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                        //lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                        //lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                        pnlstops.Visible = false;

                        lblnoofstops.Text = lblnoofstops.Text + "Stop(s)";
                    }
                    else
                    {
                        lblnoofstops.Text = "Direct";

                        lblstartDepart.Text = lblDepartureAirportCode.Text + "<br> " + lblDepartTime.Text;
                        lblstopArrival.Text = lblArrivalAirportCode.Text + "<br> " + lblArrivalTime.Text; ;
                        lblstartDepart1.Text = "";
                        lblstopArrival1.Text = "";
                        lblStartFlight.Text = lblFlightNumber.Text;
                        lblStartFlight1.Text = "";
                        pnlstops.Visible = false;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;

                    Label lblflttime = (Label)e.Row.FindControl("lblflttime");

                    double hours = Convert.ToDouble(lblflttime.Text);
                    TimeSpan t = TimeSpan.FromMinutes(hours);
                    string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                    lblduration.Text = answer;


                    Image imagepath = (Image)e.Row.FindControl("img");
                    Label lblOperatingAirlineName = (Label)e.Row.FindControl("lblOperatingAirlineName");
                    clsMasters objmasters = new clsMasters();
                    objmasters.ScreenInd = Masters.getimages;
                    DataSet ds = (DataSet)objmasters.fnGetData();
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            int i;
                            DataTable data = ds.Tables[0];
                            for (i = 0; i < data.Rows.Count; i++)
                            {
                                if (lblOperatingAirlineName.Text.Trim().ToString() == data.Rows[i]["AirlineName"].ToString().Trim().ToString())
                                {
                                    imagepath.ImageUrl = data.Rows[i]["ImagePath"].ToString();

                                }
                            }

                        }
                    }



                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }
    }
    string originDestination_Id = string.Empty;
    string fareDetailsId = string.Empty;
    protected void gdvIntFlights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
           
            if (Session["dsIntFlights"] != null)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    dsIntFlights = (DataSet)Session["dsIntFlights"];
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label FlightSegments_ID = (Label)e.Row.FindControl("lblFlightSegments_ID");

                    Label lblConx = (Label)e.Row.FindControl("lblConx");

                    if (lblConx.Text != "Y")
                    {
                        Label airlinename = (Label)e.Row.FindControl("lblAirlineNameMrk");
                        DataTable dtFlightsSegment = dsIntFlights.Tables["FlightSegment"];
                        if (dtFlightsSegment.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                            DataTable dtinnergrid = dtFlightsSegment.Clone();
                            foreach (DataRow item in rowFilghtSegment)
                            {
                                dtinnergrid.ImportRow(item);
                            }
                            GridView gdvconnectingflights = (GridView)e.Row.FindControl("gdvconnectingflights");
                            gdvconnectingflights.DataSource = dtinnergrid;
                            gdvconnectingflights.DataBind();
                            //FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                        }
                        DataTable dtFareDetails1 = dsIntFlights.Tables["FareDetails"];
                        DataRow[] dtFareDetails = dtFareDetails1.Select("FareDetails_Id=" + FlightSegments_ID.Text);
                              
                        
                         Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                            Label lblTax = (Label)e.Row.FindControl("lblTax");
                            Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                            Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                            Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                            Label lblFare = (Label)e.Row.FindControl("lblFare");
                            Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");
                            foreach (DataRow rows in dtFareDetails)
                            {
                                string ActualBaseFare = rows[0].ToString();
                                string Tax = rows[1].ToString();
                                string STax = rows[2].ToString();
                                string TCharge = rows[3].ToString();
                                string SCharge = rows[4].ToString();
                                string TDiscount = rows[5].ToString();
                                string TMarkup = rows[6].ToString();


                                lblBaseFare.Text = ActualBaseFare.ToString();
                                lblTax.Text = Tax.ToString();
                                lblSTax.Text = STax.ToString();
                                lblSCharge.Text = SCharge.ToString();
                                lblTDiscount.Text = TDiscount.ToString();
                                lblTCharge.Text = (Convert.ToDouble(TCharge.ToString()) + Convert.ToDouble(TMarkup.ToString())).ToString();


                                decimal totalFare = Convert.ToDecimal(ActualBaseFare) + Convert.ToDecimal(Tax) + Convert.ToDecimal(STax) + Convert.ToDecimal(TCharge) + Convert.ToDecimal(TMarkup);// + Convert.ToDecimal(SCharge) + Convert.ToDecimal(TDiscount);
                                // Label lblFare = (Label)e.Row.FindControl("lblFare");
                                // lblFare.Text = totalFare.ToString("####0.0");
                                lblFare.Text = lblTotal.Text = totalFare.ToString("####0.0");

                                #region Calculating SNF and HNF internatoional flights

                                if (Session["UserID"] != null)
                                {
                                    if (Session["Role"].ToString() == "Agent")
                                    {
                                        ClsBAL objBAL1 = new ClsBAL();
                                        DataSet dsCommSlab = objBAL1.GetCommissionSlab(Session["Role"].ToString(), "InterNationalFlights", airlinename.Text);
                                        string commisionPercentage = string.Empty;
                                        if (dsCommSlab != null)
                                        {
                                            if (dsCommSlab.Tables[0].Rows.Count > 0)
                                            {
                                                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                                            }
                                            else
                                            {
                                                commisionPercentage = "0";
                                            }
                                        }
                                        else
                                        {
                                            commisionPercentage = "0";
                                        }

                                        Label lblHNFFare = (Label)e.Row.FindControl("lblHNFFare");
                                        Label lblOnewayAgentcomm=(Label)e.Row.FindControl("lblOnewayAgentcomm");
                                        double CommissionFare = (Convert.ToDouble(totalFare) * Convert.ToDouble(commisionPercentage)) / Convert.ToDouble(100);
                                        lblOnewayAgentcomm.Text="Com:" +CommissionFare.ToString("####0");
                                        double DeductAmount = Convert.ToDouble(totalFare) - CommissionFare;
                                        lblHNFFare.Text = DeductAmount.ToString();
                                        #region Adding mark up price of agent
                                        Class1 objBal = new Class1();
                                        objBal.ScreenInd = Master123.gettopmarkup;
                                        objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                                        objBal.Type = "International Flights";
                                        objDataSet = (DataSet)objBal.fnGetData();
                                        string markUpAmount = "0";
                                        ViewState["MarkUp"] = markUpAmount;
                                        if (objDataSet != null)
                                        {
                                            if (objDataSet.Tables.Count > 0)
                                            {
                                                if (objDataSet.Tables[0].Rows.Count > 0)
                                                {
                                                    markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                                                    ViewState["MarkUp"] = markUpAmount;
                                                   
                                                        lblTCharge.Text = (Convert.ToDouble(lblTCharge.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                                                   
                                                   
                                                    double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text);
                                                    lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                                                }
                                            }
                                        }


                                        #endregion
                                    }
                                }
                                #endregion

                            }

                            Label lbljrnytime = (Label)e.Row.FindControl("lbljrnytime");

                            double hours = Convert.ToDouble(lbljrnytime.Text);
                        TimeSpan t = TimeSpan.FromMinutes(hours);
                        string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                        lbljrnytime.Text = answer;

                        //DataTable dtFlightSegments = dsIntFlights.Tables["FlightSegments"];
                        //if (dtFlightSegments.Rows.Count > 0)
                        //{
                        //    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                        //    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                        //}
                        //DataTable dtFareDetails = dsIntFlights.Tables[5];
                        //if (dtFareDetails.Rows.Count > 0)
                        //{
                        //    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                        //    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                        //}
                        //DataTable dtChargeableFares = dsIntFlights.Tables[6];
                        //if (dtChargeableFares.Rows.Count > 0)
                        //{
                        //    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                        //    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                        //    Label lblTax = (Label)e.Row.FindControl("lblTax");
                        //    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                        //    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                        //    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                        //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                        //    Label lblFare = (Label)e.Row.FindControl("lblFare");
                        //    Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");



                        //    lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                        //    lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                        //    lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                        //    lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                        //    lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");
                        //    lblTCharge.Text = (Convert.ToDouble(rowChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");
                        //    //DataTable dtNonChargeableFares = dsIntFlights.Tables[7];
                        //    //if (dtNonChargeableFares.Rows.Count > 0)
                        //    //{
                        //     //   DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);  //CHITTI

                              
                        //   // }
                        //    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text); //+ Convert.ToDouble(lblTDiscount.Text) + Convert.ToDouble(lblSCharge.Text)
                        //    lblFare.Text = lblTotal.Text = total.ToString("####0.00");
                       // }
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }

                     #region old
                //    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                //    Label lblTax = (Label)e.Row.FindControl("lblTax");
                //    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                //    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                //    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                //    Label lblConx = (Label)e.Row.FindControl("lblConx");
                //    Label lblDeparts = (Label)e.Row.FindControl("lblDeparts");
                //    Label lblArrives = (Label)e.Row.FindControl("lblArrives");
                //    Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                //    Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                //    Label lblDestinations = (Label)e.Row.FindControl("lblDestinations");
                //    Label lblDuration = (Label)e.Row.FindControl("lblDuration");
                //    Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                //    Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");
                //    Label lblFare = (Label)e.Row.FindControl("lblFare");
                //    Label airlinename = (Label)e.Row.FindControl("lblOperatingAirlineName");

                //    TextBox txtfromsearch = new TextBox();
                //    txtfromsearch.Text = Session["From"].ToString();
                //    TextBox txttosearch = new TextBox();
                //    txttosearch.Text = Session["TO"].ToString();

                //    string from = txtfromsearch.Text.Substring(txtfromsearch.Text.IndexOf("(") + 1, 3);
                //    string to = txttosearch.Text.Substring(txttosearch.Text.IndexOf("(") + 1, 3);


                //    lblDeparts.Text = lblDeparts.Text.Substring(lblDeparts.Text.IndexOf("T") + 1, 5);


                //    if (e.Row.RowIndex + 2 <= dsIntFlights.Tables["FlightSegment"].Rows.Count - 2)
                //    {
                //        if (dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["Conx"].ToString() == "Y" && dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["Conx"].ToString() == "Y")
                //        {
                //            lblConnectingFlights.Visible = true;
                //            lblDestinations.Text = from + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString() + " - " + to;
                //            lblArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 2]["ArrivalDateTime"].ToString();
                //            lblArrives.Text = lblArrives.Text.Substring(lblArrives.Text.IndexOf("T") + 1, 5);

                //            double hours = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 2]["JrnyTm"].ToString());
                //            TimeSpan t = TimeSpan.FromMinutes(hours);
                //            string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                //            lblDuration.Text = answer;
                //        }
                //        else if (dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["Conx"].ToString() == "Y")
                //        {
                //            lblConnectingFlights.Visible = true;
                //            lblDestinations.Text = from + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + to;
                //            lblArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();
                //            lblArrives.Text = lblArrives.Text.Substring(lblArrives.Text.IndexOf("T") + 1, 5);

                //            double hours = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["JrnyTm"].ToString());
                //            TimeSpan t = TimeSpan.FromMinutes(hours);
                //            string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                //            lblDuration.Text = answer;
                //        }
                //        else
                //        {
                //            lblDestinations.Text = from + " - " + to;

                //            lblArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalDateTime"].ToString();
                //            lblArrives.Text = lblArrives.Text.Substring(lblArrives.Text.IndexOf("T"), 5);

                //            double hours = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["JrnyTm"].ToString());
                //            TimeSpan t = TimeSpan.FromMinutes(hours);
                //            string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                //            lblDuration.Text = answer;
                //        }
                //    }
                //    else if (e.Row.RowIndex + 1 <= dsIntFlights.Tables["FlightSegment"].Rows.Count - 1)
                //    {
                //        if (dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["Conx"].ToString() == "Y")
                //        {
                //            lblConnectingFlights.Visible = true;
                //            lblDestinations.Text = from + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + to;
                //            lblArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();
                //            lblArrives.Text = lblArrives.Text.Substring(lblArrives.Text.IndexOf("T") + 1, 5);

                //            double hours = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["JrnyTm"].ToString());
                //            TimeSpan t = TimeSpan.FromMinutes(hours);
                //            string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                //            lblDuration.Text = answer;
                //        }
                //        else
                //        {
                //            lblDestinations.Text = from + " - " + to;

                //            lblArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalDateTime"].ToString();
                //            lblArrives.Text = lblArrives.Text.Substring(lblArrives.Text.IndexOf("T"), 5);

                //            double hours = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["JrnyTm"].ToString());
                //            TimeSpan t = TimeSpan.FromMinutes(hours);
                //            string answer = string.Format("{0}h : {1}m ", Convert.ToInt32(t.TotalHours), t.Minutes);
                //            lblDuration.Text = answer;
                //        }
                //    }


                //    if (dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["Conx"].ToString() == "N")
                //    {
                //        e.Row.Visible = false;
                //    }





                //    //string StartTime = lblDeparts.Text;
                //    //string EndTime = lblArrives.Text;
                //    //DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                //    //DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                //    //string format = "MMM ddd d HH:mm yyyy";
                //    //lbldepartdate.Text = Date.ToLongDateString();
                //    //lblarrivaldate.Text = Date1.ToLongDateString();

                //    //DateTime startTime = DateTime.Parse(StartTime);
                //    //DateTime endTime = DateTime.Parse(EndTime);

                //    //TimeSpan ts = endTime.Subtract(startTime);

                //    //lblDuration.Text = ts.ToString();
                //    //lblDuration.Text = lblDuration.Text.Substring(0, lblDuration.Text.Length - 3);



                //    if (dsIntFlights.Tables.Count > 0)
                //    {

                //        DataTable dtBookingClassFare = dsIntFlights.Tables[14];
                //        Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                //        lblFareRules.Text = dtBookingClassFare.Rows[e.Row.RowIndex]["Rule"].ToString();

                //        //changes ravi
                //        Label lblFlightSegment_ID = (Label)e.Row.FindControl("lblFlightSegment_ID");
                //        DataTable dtFareDetails1 = dsIntFlights.Tables[4];
                //        DataRow[] dtFareDetails = dtFareDetails1.Select("FareDetails_Id=" + lblFlightSegment_ID.Text);
                //        foreach (DataRow rows in dtFareDetails)
                //        {
                //            string ActualBaseFare = rows[0].ToString();
                //            string Tax = rows[1].ToString();
                //            string STax = rows[2].ToString();
                //            string TCharge = rows[3].ToString();
                //            string SCharge = rows[4].ToString();
                //            string TDiscount = rows[5].ToString();
                //            string TMarkup = rows[6].ToString();


                //            lblBaseFare.Text = ActualBaseFare.ToString();
                //            lblTax.Text = Tax.ToString();
                //            lblSTax.Text = STax.ToString();
                //            lblSCharge.Text = SCharge.ToString();
                //            lblTDiscount.Text = TDiscount.ToString();
                //            lblTCharge.Text = (Convert.ToDouble(TCharge.ToString()) + Convert.ToDouble(TMarkup.ToString())).ToString();


                //            decimal totalFare = Convert.ToDecimal(ActualBaseFare) + Convert.ToDecimal(Tax) + Convert.ToDecimal(STax) + Convert.ToDecimal(TCharge) + Convert.ToDecimal(TMarkup);// + Convert.ToDecimal(SCharge) + Convert.ToDecimal(TDiscount);
                //            // Label lblFare = (Label)e.Row.FindControl("lblFare");
                //            // lblFare.Text = totalFare.ToString("####0.0");
                //            lblFare.Text = lblTotal.Text = totalFare.ToString("####0.0");
                //            #region Calculating SNF and HNF
                //            if (Session["UserID"] != null)
                //            {
                //                if (Session["Role"].ToString() == "Agent")
                //                {
                //                    ClsBAL objBAL1 = new ClsBAL();
                //                    DataSet dsCommSlab = objBAL1.GetCommissionSlab(Session["Role"].ToString(), "InterNationalFlights", airlinename.Text);
                //                    string commisionPercentage = string.Empty;
                //                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                //                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                //                    else
                //                        commisionPercentage = "0";

                //                    Label lblHNFFare = (Label)e.Row.FindControl("lblHNFFare");
                //                    double CommissionFare = (Convert.ToDouble(totalFare) * Convert.ToDouble(commisionPercentage)) / Convert.ToDouble(100);
                //                    double DeductAmount = Convert.ToDouble(totalFare) - CommissionFare;
                //                    lblHNFFare.Text = DeductAmount.ToString();
                //                    #region Adding mark up price of agent
                //                    Class1 objBal = new Class1();
                //                    objBal.ScreenInd = Master123.gettopmarkup;
                //                    objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                //                    objBal.Type = "International Flights";
                //                    objDataSet = (DataSet)objBal.fnGetData();
                //                    string markUpAmount = "0";
                //                    ViewState["MarkUp"] = markUpAmount;
                //                    if (objDataSet != null)
                //                    {
                //                        if (objDataSet.Tables.Count > 0)
                //                        {

                //                            markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                //                            ViewState["MarkUp"] = markUpAmount;
                //                            if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                //                            {
                //                                lblTCharge.Text = (Convert.ToDouble(lblTCharge.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                //                            }
                //                            else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                //                            {
                //                                lblTCharge.Text = (Convert.ToDouble(lblTCharge.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                //                            }
                //                            double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text);
                //                            lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                //                        }
                //                    }


                //                    #endregion
                //                }
                //            }
                //            #endregion
                //        }

                    DataTable dtactivedetails = dsIntFlights.Tables[0];
                    Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                    Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                    Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                    Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                    lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                    lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                    lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                    lblTripone.Text = dtactivedetails.Rows[0]["Trip"].ToString();

                //        Session["dsIntFlights"] = dsIntFlights;
                    //    }
#endregion

                }

            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    protected void gdvIntFlights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (Session["dsIntFlights"] != null)
            {
                dsIntFlights = (DataSet)Session["dsIntFlights"];
                if (e.CommandName == "BookTicket")
                {
                    if (Session["UserId"] == null)
                    {
                        Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                        pnl.Visible = true;
                    }
                    ModifySearch.Visible = false;
                    //lnkModifySearch.Visible = false;
                    lblIntFlightSegmentId.Text = e.CommandArgument.ToString();
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                    Session["TotalFare"] = ((Label)row.Cells[0].FindControl("lblFare")).Text.ToString();

                    Control ctl = e.CommandSource as Control;
                    GridViewRow row1 = ctl.NamingContainer as GridViewRow;

                    GridView gdvconnecting = (GridView)row1.FindControl("gdvconnectingflights");

                    foreach (GridViewRow item in gdvconnecting.Rows)
                    {
                        Label lblarrivaldate = (Label)item.FindControl("lblarrivaldate");
                        Label lbldepartdate = (Label)item.FindControl("lbldepartdate");
                        Label lblOperatingAirlineName = (Label)item.FindControl("lblOperatingAirlineName");
                        Label lblOperatingAirlineFlightNumber = (Label)item.FindControl("lblOperatingAirlineFlightNumber");
                        Label lblDestinations = (Label)item.FindControl("lblDestinations");
                        Label lblarrtime = (Label)item.FindControl("lblArrives");
                        Label lbldeptime = (Label)item.FindControl("lblDeparts");


                        Label lblTax = (Label)row1.FindControl("lblTax");
                        Label lblSTax = (Label)row1.FindControl("lblSTax");
                        Label lblSCharge = (Label)row1.FindControl("lblSCharge");
                        Label lblTDiscount = (Label)row1.FindControl("lblTDiscount");
                        Label lblTotal = (Label)row1.FindControl("lblTotal");
                        Label lblBaseFare = (Label)row1.FindControl("lblBaseFare");
                        Label lblTCharge = (Label)row1.FindControl("lblTCharge");

                        lblairline.Text = lblOperatingAirlineName.Text;
                        lblflightno.Text = lblOperatingAirlineFlightNumber.Text;

                        DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                        DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                        string format = "MMM ddd d HH:mm yyyy";


                        //lbldepartdate.Text = Date.ToString("dd/MM/yyyy");
                        //lblarrivaldate.Text = Date1.ToString("dd/MM/yyyy");

                        string departdate = Date.ToString("dd/MM/yyyy");
                        string arrivaldate = Date1.ToString("dd/MM/yyyy");

                        lbldepart.Text = departdate;
                        lblarrives.Text = arrivaldate;
                        lblarrivetime.Text = lblarrtime.Text;
                        lbldeparttime.Text = lbldeptime.Text;

                        string[] strfrom = new string[2];

                        if (Session["From"] != null)
                        {
                            strfrom = Session["From"].ToString().Split(',');
                        }
                        else
                        {
                            Session["From"] = (rbnIntOneWay.Checked || rradiooneway.Checked) ? txtFrom.Text : txtfromsearch.Text;
                            strfrom = Session["From"].ToString().Split(',');
                        }
                        string[] strto = new string[2];
                        if (Session["TO"] != null)
                        {
                            strto = Session["TO"].ToString().Split(',');
                        }
                        else
                        {
                            Session["TO"] = (rbnIntRoundTrip.Checked || rradioround.Checked) ? txtTo.Text : txtleavingtosearch.Text;
                            strto = Session["TO"].ToString().Split(',');
                        }
                        lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();

                        lblairporttax.Text = lblTax.Text;
                        //   lblServiceTax.Text = lblSTax.Text;
                        lblServiceTaxreturn.Text = lblSTax.Text;
                        lblServiceCharge.Text = lblSCharge.Text;
                        lblTotalDiscount.Text = lblTDiscount.Text;
                        lblTotalAmt.Text = lblTotal.Text;
                        lblActualFare.Text = lblBaseFare.Text;
                        lblTChargeFareBreak.Text = lblTCharge.Text;

                        Session["BaseFare"] = lblBaseFare.Text;
                        Session["STax"] = lblSTax.Text;
                        Session["SCharge"] = lblSCharge.Text;
                        Session["TDiscount"] = lblTDiscount.Text;
                        Session["Total"] = lblTotal.Text;
                        Session["Tax"] = lblTax.Text;


                        Label lbladultone = (Label)row1.FindControl("lbladultone");
                        Label lblchildone = (Label)row1.FindControl("lblchildone");
                        Label lblinfantone = (Label)row1.FindControl("lblinfantone");
                        Label lblTripone = (Label)row1.FindControl("lblTripone");
                        lbladultreturn.Text = lbladultone.Text;
                        lblchildreturn.Text = lblchildone.Text;
                        lblinfantreturn.Text = lblinfantone.Text;
                        lblTrip.Text = lblTripone.Text;


                        btnIntBookRoundTrip.Visible = false;
                        btnIntBook.Visible = true;
                    }
                }

                if (e.CommandName == "View Details")
                {
                    DataSet dsIntFlights1 = (DataSet)Session["dsIntFlights"];
                    DataTable dtFlightSegment = dsIntFlights1.Tables["FlightSegment"];
                    string flightSegmentId = e.CommandArgument.ToString();
                    DataRow[] dr = dtFlightSegment.Select("FlightSegment_Id='" + flightSegmentId + "'");
                    Control ctl = e.CommandSource as Control;
                    GridViewRow row1 = ctl.NamingContainer as GridViewRow;

                    DataRow[] drFlight = dtFlightSegment.Select("FlightSegment_Id='" + flightSegmentId + "'");
                    lblOperatingAirlineNameDet.Text = drFlight[0]["OperatingAirlineName"].ToString();
                    lblMarketingAirlineno.Text = drFlight[0]["MarketingAirlineCode"].ToString();
                    lblOperatingAirlineFlightNumberDet.Text = drFlight[0]["OperatingAirlineFlightNumber"].ToString();
                    lblDepartureAirportNameDet.Text = drFlight[0]["DepartureAirportName"].ToString();
                    lblDepartureDateTimeDet.Text = drFlight[0]["DepartureDateTime"].ToString();
                    lblArrivalAirportNameDet.Text = drFlight[0]["ArrivalAirportName"].ToString();
                    lblArrivalDateTimeDet.Text = drFlight[0]["ArrivalDateTime"].ToString();
                    lblDurationDet.Text = drFlight[0]["FltTm"].ToString();

                    TimeSpan t = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet.Text));
                    string[] hrs = t.TotalHours.ToString().Split('.');
                    string answer = string.Format("{0}h : {1}m ", hrs[0].ToString(), t.Minutes);
                    lblDurationDet.Text = answer;


                    string[] strDep = lblDepartureDateTimeDet.Text.Split('T');
                    string[] strArr = lblArrivalDateTimeDet.Text.Split('T');

                    DateTime Date = Convert.ToDateTime(lblDepartureDateTimeDet.Text);
                    DateTime Date1 = Convert.ToDateTime(lblArrivalDateTimeDet.Text);

                    lblDepartureDateTimeDet.Text = Date.ToString("dd/MM/yyyy") + " " + strDep[1].ToString().Substring(0, strDep[1].ToString().Length - 3);
                    lblArrivalDateTimeDet.Text = Date1.ToString("dd/MM/yyyy") + " " + strArr[1].ToString().Substring(0, strArr[1].ToString().Length - 3);

                    DataRow[] drFlight1 = dtFlightSegment.Select("FlightSegment_Id='" + (Convert.ToInt32(flightSegmentId) + 1).ToString() + "'");
                    if (drFlight[0]["Conx"].ToString() == "Y")
                    {

                        trConnecting1.Visible = true;
                        lblOperatingAirlineNameDet1.Text = drFlight1[0]["OperatingAirlineName"].ToString();
                        lblMarketingAirlineno1.Text = drFlight1[0]["MarketingAirlineCode"].ToString();
                        lblOperatingAirlineFlightNumberDet1.Text = drFlight1[0]["OperatingAirlineFlightNumber"].ToString();
                        lblDepartureAirportNameDet1.Text = drFlight1[0]["DepartureAirportName"].ToString();
                        lblDepartureDateTimeDet1.Text = drFlight1[0]["DepartureDateTime"].ToString();
                        lblArrivalAirportNameDet1.Text = drFlight1[0]["ArrivalAirportName"].ToString();
                        lblArrivalDateTimeDet1.Text = drFlight1[0]["ArrivalDateTime"].ToString();
                        lblDurationDet1.Text = drFlight1[0]["FltTm"].ToString();


                        TimeSpan t1 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet1.Text));
                        string[] hrs1 = t1.TotalHours.ToString().Split('.');
                        string answer1 = string.Format("{0}h : {1}m ", hrs1[0].ToString(), t1.Minutes);
                        lblDurationDet1.Text = answer1;


                        string[] strDep1 = lblDepartureDateTimeDet1.Text.Split('T');
                        string[] strArr1 = lblArrivalDateTimeDet1.Text.Split('T');

                        DateTime Date11 = Convert.ToDateTime(lblDepartureDateTimeDet1.Text);
                        DateTime Date12 = Convert.ToDateTime(lblArrivalDateTimeDet1.Text);

                        lblDepartureDateTimeDet1.Text = Date11.ToString("dd/MM/yyyy") + " " + strDep1[1].ToString().Substring(0, strDep1[1].ToString().Length - 3);
                        lblArrivalDateTimeDet1.Text = Date12.ToString("dd/MM/yyyy") + " " + strArr1[1].ToString().Substring(0, strArr1[1].ToString().Length - 3);
                    }
                    else
                    {
                        trConnecting1.Visible = false;
                    }

                    DataRow[] drFlight2 = dtFlightSegment.Select("FlightSegment_Id='" + (Convert.ToInt32(flightSegmentId) + 2).ToString() + "'");
                    if (drFlight1[0]["Conx"].ToString() == "Y")
                    {
                        trConnecting2.Visible = true;
                        lblOperatingAirlineNameDet2.Text = drFlight2[0]["OperatingAirlineName"].ToString();
                        lblMarketingAirlineno2.Text = drFlight2[0]["MarketingAirlineCode"].ToString();
                        lblOperatingAirlineFlightNumberDet2.Text = drFlight2[0]["OperatingAirlineFlightNumber"].ToString();
                        lblDepartureAirportNameDet2.Text = drFlight2[0]["DepartureAirportName"].ToString();
                        lblDepartureDateTimeDet2.Text = drFlight2[0]["DepartureDateTime"].ToString();
                        lblArrivalAirportNameDet2.Text = drFlight2[0]["ArrivalAirportName"].ToString();
                        lblArrivalDateTimeDet2.Text = drFlight2[0]["ArrivalDateTime"].ToString();
                        lblDurationDet2.Text = drFlight2[0]["FltTm"].ToString();


                        TimeSpan t2 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet2.Text));
                        string[] hrs2 = t2.TotalHours.ToString().Split('.');
                        string answer2 = string.Format("{0}h : {1}m ", hrs2[0].ToString(), t2.Minutes);
                        lblDurationDet2.Text = answer2;


                        string[] strDep2 = lblDepartureDateTimeDet2.Text.Split('T');
                        string[] strArr2 = lblArrivalDateTimeDet2.Text.Split('T');

                        DateTime Date111 = Convert.ToDateTime(lblDepartureDateTimeDet2.Text);
                        DateTime Date121 = Convert.ToDateTime(lblArrivalDateTimeDet2.Text);

                        lblDepartureDateTimeDet2.Text = Date111.ToString("dd/MM/yyyy") + " " + strDep2[1].ToString().Substring(0, strDep2[1].ToString().Length - 3);
                        lblArrivalDateTimeDet2.Text = Date121.ToString("dd/MM/yyyy") + " " + strArr2[1].ToString().Substring(0, strArr2[1].ToString().Length - 3);
                    }
                    else
                    {
                        trConnecting2.Visible = false;
                    }

                    lnkDummy_Click(sender, e);
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    protected void lnkDummy_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAirlineDet.Show();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnIntBook_Click(object sender, EventArgs e)
    {
        try
        {
            // if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); return; }
            ClsBAL objBAL = new ClsBAL();
            GetIntBookingRequest();

            Session["Amount"] = lblTotalAmt.Text;

            if (Session["result"] != null)
            {
                if (Session["result"].ToString() == "true")
                {
                    if (Session["UserID"] != null)
                    {
                        if (Session["Role"] != null)
                        {
                            #region Checking the roles and booking the tickets
                              

                             if (Session["Role"].ToString() == "User")
                            {
                                objBAL = new ClsBAL();
                                DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                                Session["AgentId_Agent"] = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                                Response.Redirect("~/pay.aspx?val=true", false);
                            }
                            else if (Session["Role"].ToString() == "Admin")
                            {

                                save(sender, e);
                            }
                            else if (Session["Role"].ToString() == "Agent")
                            {
                                DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                                DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", lblairline.Text.ToString()); // Change it
                                string commisionPercentage = string.Empty;
                                if (dsCommSlab.Tables[0].Rows.Count > 0)
                                    commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                                else
                                    commisionPercentage = "0";
                                string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                                string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                                string actualFare = lblTotalAmt.Text;
                                string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
                                    ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));

                                string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                                Session["AgentId_Agent"] = agentId;
                                Session["ActualFare_Agent"] = actualFare;
                                Session["CommisionFare_Agent"] = commisionFare;
                                Session["CommisionPercentage_Agent"] = commisionPercentage;
                                Session["DeductAmount_Agent"] = deductAmount;

                                if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                                {
                                    save(sender, e);
                                }
                                else
                                {
                                    mp3.Show();

                                    lblerror.Text = "Your balance is too low to book the ticket.So,please contact administrator";

                                    return;
                                }
                            }
                            else if (Session["Role"].ToString() == "Distributor")
                            {
                                DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                                DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", lblairline.Text.ToString()); // Change it
                                string commisionPercentage = string.Empty;
                                if (dsCommSlab.Tables[0].Rows.Count > 0)
                                    commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                                else
                                    commisionPercentage = "0";
                                string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                                string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                                string actualFare = lblTotalAmt.Text;
                                string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
                                    ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));

                                string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                                Session["AgentId_Agent"] = agentId;
                                Session["ActualFare_Agent"] = actualFare;
                                Session["CommisionFare_Agent"] = commisionFare;
                                Session["CommisionPercentage_Agent"] = commisionPercentage;
                                Session["DeductAmount_Agent"] = deductAmount;

                                if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                                {
                                    save(sender, e);
                                }
                                else
                                {
                                    mp3.Show();

                                    lblerror.Text = "Your balance is too low to book the ticket.So, please contact administrator";

                                    return;
                                }
                            }
                           
                            #endregion
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx", false);
                        }
                    }
                    else
                    {
                        if (Session["Role"] == null)
                            {
                                Response.Redirect("~/pay.aspx?val=true", false);
                            }
                    }
                   
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    protected void save(object sender, EventArgs e)
    {
        try
        {
            DataSet dsBookingResponse = new DataSet();

            // dsBookingResponse = (DataSet)Session["Response"];


            dsBookingResponse = method();
            Session["Response"] = null;
            FlightBAL objFlightBal = new FlightBAL();
            if (dsBookingResponse.Tables.Count > 0)
            {
                if (dsBookingResponse.Tables["BookingResponse"].Rows.Count > 0)
                {
                    if (Session["UserID"] != null && Session["Role"] != null)
                    {                

                    #region Dedcuting the amount from the agent and DB's balance after booking


                        if (Session["Role"].ToString() == "Agent" || Session["Role"].ToString() == "Distributor")
                        {
                            string[] commPer = Session["CommisionPercentage_Agent"].ToString().Split('.');
                            DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                                                    Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
                                                    Convert.ToDouble(Session["CommisionFare_Agent"].ToString()), Convert.ToDouble(Session["CommisionPercentage_Agent"]));

                            objBAL = new ClsBAL();
                            DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                            string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                            Label lbl = (Label)this.Master.FindControl("lblBalance");
                            lbl.Text = balanceAgent;
                            Session["Balance"] = balanceAgent;


                        }
                        else if (Session["Role"].ToString() == "User")
                        {
                            DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                                Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                        else if (Session["Role"].ToString() == "Admin")
                        {
                            DeductAgentBalance(0, Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                               Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                    #endregion
                    }
                    else if (Session["Role"] == null)
                    {
                        DeductAgentBalance(0, Convert.ToDouble("0.00"), 0, Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                                  Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                    }

                    objFlightBal.ReferenceNo = Convert.ToString(Session["Order_Id"]);// Common.GetFlightsReferenceNo("LJIF");
                    objFlightBal.TransId = dsBookingResponse.Tables["BookingResponse"].Rows[0]["transid"].ToString();
                    objFlightBal.Status = dsBookingResponse.Tables["BookingResponse"].Rows[0]["status"].ToString();
                    //  objFlightBal.AdultPax = Convert.ToInt32(dsBookingResponse.Tables["BookingResponse"].Rows[0]["noadults"].ToString());
                    //objFlightBal.InfantPax = Convert.ToInt32(dsBookingResponse.Tables["BookingResponse"].Rows[0]["noinfant"].ToString());
                    //objFlightBal.ChildPax = Convert.ToInt32(dsBookingResponse.Tables["BookingResponse"].Rows[0]["nochild"].ToString());
                    //objFlightBal.Origin_Destination_Id = dsBookingResponse.Tables["OriginDestinationOption"].Rows[0]["id"].ToString();
                    //objFlightBal.Origin_Destination_Key = dsBookingResponse.Tables["OriginDestinationOption"].Rows[0]["key"].ToString();
                    //objFlightBal.ActualBasefare = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["ActualBasefare"].ToString());
                    // objFlightBal.Tax = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["Tax"].ToString());
                    // objFlightBal.STax = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["STax"].ToString());
                    //  objFlightBal.TCharge = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["TCharge"].ToString());
                    // objFlightBal.Scharge = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["Scharge"].ToString());
                    //objFlightBal.TDiscount = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["TDiscount"].ToString());
                    // objFlightBal.TMarkUp = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["TMarkUp"].ToString());
                    // objFlightBal.TPartnerCommission = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["TPartnerCommission"].ToString());
                    //  objFlightBal.TSDiscount = Convert.ToDecimal(dsBookingResponse.Tables["FareDetails"].Rows[0]["TSDiscount"].ToString());
                    //  objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    //  objFlightBal.TripMode = "One";

                    objFlightBal.UpdateDInternationalFlightBooking(objFlightBal);
                    // string flightBookingId = Session["BookingID"].ToString(); //dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                    //Do the Insert of Flgiht Segment

                    //  objFlightBal.FlightBookingID = flightBookingId.ToString();
                    if (dsBookingResponse.Tables["FlightSegment"].Rows.Count > 0)
                    {
                        for (int j = 0; j < dsBookingResponse.Tables["FlightSegment"].Rows.Count; j++)
                        {

                            //objFlightBal.Customer_Details = customerInfo;
                            
                            objFlightBal.FlightBookingID = Convert.ToString(Session["BookingID"]);
                            objFlightBal.bookingClass = dsBookingResponse.Tables["BookingClassFare"].Rows[j]["bookingClass"].ToString();
                            objFlightBal.ClassType = dsBookingResponse.Tables["BookingClassFare"].Rows[j]["ClassType"].ToString();
                            objFlightBal.farebasisCode = dsBookingResponse.Tables["BookingClassFare"].Rows[j]["farebasisCode"].ToString();
                            objFlightBal.Fare_Rule = dsBookingResponse.Tables["BookingClassFare"].Rows[j]["Rule"].ToString();
                            objFlightBal.PsgrType = dsBookingResponse.Tables["psgr"].Rows[j]["PsgrType"].ToString();
                            objFlightBal.BaseFare = dsBookingResponse.Tables["psgr"].Rows[j]["BaseFare"].ToString();
                            objFlightBal.psgrTax = dsBookingResponse.Tables["psgr"].Rows[j]["Tax"].ToString();
                            objFlightBal.BagInfo = dsBookingResponse.Tables["psgr"].Rows[j]["BagInfo"].ToString();

                            bool res1 = objFlightBal.UpdateInternationalFlightSegment(objFlightBal);

                            if (res1)
                            {
                                GetDetailsForPrint(Convert.ToString(Session["Order_Id"]));
                                lbtnmail.Visible = false;
                                pnlSearch.Visible = false;
                                pnlIntPassengerDet.Visible = false;
                                lblMsg.Visible = true;
                                lblMsg.Text = "Ticket has been booked successfully. Reference Number is : " + objFlightBal.ReferenceNo.ToString();
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                pnlViewticket.Visible = true;
                            }

                        }
                        lbtnmail_Click1(sender, e);

                    }

                }
            }


        }

        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare,
         double commisionFare, double commisionPercentage)
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
    protected void btnBookStatusInt_Click(object sender, EventArgs e)
    {
        string result = string.Empty;
        DataSet ds = new DataSet();
        transId = "A396009";
        String xmlRequest = "xmlRequest=<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid></EticketRequest>";

        byte[] requestData = Encoding.ASCII.GetBytes(xmlRequest);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Booking");

        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = requestData.Length;

        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(requestData, 0, requestData.Length);
        }



        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                    result = reader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNodeReader xmlReader = new XmlNodeReader(doc);

                ds.ReadXml(xmlReader);
            }
        }



    }

    

    protected void btnCancelTicketInt_Click(object sender, EventArgs e)
    {
        transId = "A013729";
        String xmlRequestData = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100200</partnerRefId></EticketRequest>";
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
        String xmlCancelRequest = "<CancelationDetails><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><status>" + status + "</status><remarks>Hi transaction</remarks><eticketdto>";
        xmlCancelRequest = xmlCancelRequest + "<Eticket><givenName>" + givenName + "</givenName><surName>" + surName + "</surName><nameReference>" + nameReference + "</nameReference><eticketno>" + eticketNo + "</eticketno><flightuid>" + flightUid + "</flightuid><passuid>" + passUid + "</passuid></Eticket>";
        xmlCancelRequest = xmlCancelRequest + "</eticketdto></CancelationDetails>";
        DataSet dsCancelResponse = objFlights.CancelTicket(xmlCancelRequest);
    }
    protected void btnCancelTicketStatusInt_Click(object sender, EventArgs e)
    {
        transId = "A410697";
        String xmlCancelReqStatus = "<EticketCanStatusReq><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>" + transId + "</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
        DataSet dsCancelResponse = objFlights.GetCancelTicketStatus(xmlCancelReqStatus);
    }
    protected void gdvIntFlights_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["dtIntFlights"] != null)
            {
                DataSet ds = (DataSet)Session["dtIntFlights"];
                gdvIntFlights.PageIndex = e.NewPageIndex;
                gdvIntFlights.DataSource = ds;
                gdvIntFlights.DataBind();
            }
            else { Response.Redirect("Default.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void lnkModifySearch_Click(object sender, EventArgs e)
    {
        // gdvIntFlights.Visible = false;
        //pnlSearch.Visible = true;
        BindModifySearch();

        string mode = (rbnIntOneWay.Checked) ? "ONE" : "ROUND";
        if (mode.ToString() == "ONE")
        {
            txtretundatesearch.Enabled = false;
        }
        else
        {
            imgReturn.Visible = txtretundatesearch.Visible = true;
            txtretundatesearch.Enabled = true;
            txtretundatesearch.Attributes.Add("class", "datepicker1");
            //rfvtxtretundatesearch.Visible = false; 
           // txtretundatesearch.Text = ""; 
            lblMsg.Text = "";
        }


    }


    private void BindModifySearch()
    {
        try
        {
            ddladultsintsearch.SelectedValue = ddlAdultsInt.SelectedValue;
            ddlinfantsintsearch.SelectedValue = ddlInfantsInt.SelectedValue;
            ddlchildintsearch.SelectedValue = ddlChildsInt.SelectedValue;
            txtfromsearch.Text = Convert.ToString(Session["From"]);
            txtleavingtosearch.Text = Convert.ToString(Session["TO"]);
            txtdatesearch.Text = Convert.ToString(Session["datefrom"]);
            txtretundatesearch.Text = Convert.ToString(Session["dateto"]);
            ddlIntCabinTypesearch.SelectedValue = ddlIntCabinType.SelectedValue;
          

        }
        catch (Exception ex)
        {
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
        try
        {
            //  You can cache the DataTable for improving performance
            DataTable dt = ((DataTable)Session["dtIntFlights"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression +" " + direction;

            gdvIntFlights.DataSource = dv;
            dsIntFlights = (DataSet)Session["dsIntFlights"];
            gdvIntFlights.DataBind();

        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }

    private void SortGridView1(string sortExpression, string direction)
    {
        try
        {
            try
            {
                //  You can cache the DataTable for improving performance
                DataSet ds = ((DataSet)Session["dsIntFlights"]);
                DataTable dtFlightsegment = ds.Tables["FlightSegment"];          

                DataTable dtOnward = ds.Tables["Onward"];
                DataTable dtsort = new DataTable();
                dtsort = dtOnward.Clone();

                 DataTable dtflightsegments = ds.Tables["FlightSegments"];

                dtsort.Columns.Add("FlightSegments_ID", System.Type.GetType("System.Decimal"));

                foreach (DataRow dr in dtOnward.Rows)
                {
                    dtsort.ImportRow(dr);
                }
                dtsort.AcceptChanges();

                for (int i = 0; i < dtOnward.Rows.Count; i++)
                {
                    DataRow[] dronward = dtflightsegments.Select("onward_Id = " + dtOnward.Rows[i]["onward_Id"]);
                    dtsort.Rows[i]["FlightSegments_ID"] = dronward[0]["FlightSegments_Id"].ToString();
                }

                dtsort.Columns.Add("DepartureDateTime", typeof(DateTime));
                dtsort.Columns.Add("ArrivalDateTime", typeof(DateTime));
                dtsort.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                DataTable dt1 = dtsort.Clone();
                dt1.AcceptChanges();

                foreach (DataRow dr in dtsort.Rows)
                {
                    dt1.ImportRow(dr);
                }
                DataTable dtFareDetails = ds.Tables["FareDetails"];

                for (int i = 0; i < dtsort.Rows.Count; i++)
                {
                    DataRow[] drdepart = dtFlightsegment.Select("FlightSegments_ID = " + dtsort.Rows[i]["FlightSegments_ID"]);
                    DataRow[] drfare = dtFareDetails.Select("OriginDestinationOption_ID = " + dtsort.Rows[i]["OriginDestinationOption_ID"]);
                  
                    dt1.Rows[i]["DepartureDateTime"] = drdepart[0]["DepartureDateTime"].ToString();
                    dt1.Rows[i]["ArrivalDateTime"] = drdepart[0]["ArrivalDateTime"].ToString();

                    Decimal TotalFare = Convert.ToDecimal(drfare[0]["actualBaseFare"]) + Convert.ToDecimal(drfare[0]["tax"]) +
                        Convert.ToDecimal(drfare[0]["stax"]) + Convert.ToDecimal(drfare[0]["Tcharge"])
                        + Convert.ToDecimal(drfare[0]["TMarkup"]);
                    dt1.Rows[i]["Fare"] = TotalFare.ToString();
                }

               
            
                //Decimal TotalFare = Convert.ToDecimal(drFareDetails[0]["actualBaseFare"]) + Convert.ToDecimal(drFareDetails[0]["tax"]) + Convert.ToDecimal(drFareDetails[0]["stax"]) + Convert.ToDecimal(drFareDetails[0]["Tcharge"]) + Convert.ToDecimal(drFareDetails[0]["TMarkup"]);//+ Convert.ToDecimal(drFareDetails[0]["scharge"]) + Convert.ToDecimal(drFareDetails[0]["Tdiscount"])

                //lblTotal.Text = lblTotalPrice.Text = TotalFare.ToString();




                DataView dv = new DataView(dt1);
                 dv.Sort = sortExpression + " " + direction;

                gdvRoundtrip.DataSource = dv;
                dsIntFlights = (DataSet)Session["dsIntFlights"];
                gdvRoundtrip.DataBind();




               // DataTable dtsort = new DataTable();
                
               // dtsort = dtFlightsegment.Clone();
               // dtsort.Columns.Add("OriginDestinationOption_Id", System.Type.GetType("System.Decimal"));
               // foreach (DataRow dr in dtFlightsegment.Rows)
               // {
               //     dtsort.ImportRow(dr);
               // }
               // dtsort.AcceptChanges();


               // for (int i = 0; i < dtFlightsegment.Rows.Count; i++)
               // {
               //     DataRow[] dr = dtFlightsegment.Select("FlightSegments_ID = " + dtFlightsegment.Rows[i]["FlightSegments_ID"].ToString());
               //     DataRow[] dronward = dtflightsegments.Select("FlightSegments_ID = " + dr[0]["FlightSegments_ID"]);
               //    DataRow[] drorigindestinationoptionId;
               //     if (Convert.ToString(dronward[0]["onward_Id"]) != "")
               //     {
               //         drorigindestinationoptionId = dtonward.Select("onward_Id = " + dronward[0]["onward_Id"]);
               //     }
               //     else
               //     {
               //         drorigindestinationoptionId = dtreturn.Select("return_Id  = " + dronward[0]["return_Id"]);
               //     }

               //     foreach(DataRow rows in drorigindestinationoptionId)
               //     {
               //          dtsort.Rows[i]["OriginDestinationOption_Id"] = rows[0].ToString();
               //     }
               // }


               // DataView dv = new DataView(dtsort);

          
               //// Session["Sortdata"] = dv.ToTable();

              

               //// RoundTripMethod();


              
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }

    protected void gdvIntFlights_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gdvconnectingonwardflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsIntFlights = (DataSet)Session["dsIntFlights"];

                GridView gv = sender as GridView;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {               

                    Label lblFlightNumber = (Label)e.Row.FindControl("lblFlightNumber");
                    Label lblduration = (Label)e.Row.FindControl("lblduration");
                    LinkButton lblnoofstops = (LinkButton)e.Row.FindControl("lnkNoofstops");
                    Label lblviaflight = (Label)e.Row.FindControl("lblviaflight");
                    Label lblStartFlight = (Label)e.Row.FindControl("lblStartFlight");
                    Label lblstartDepart = (Label)e.Row.FindControl("lblstartDepart");
                    Label lblstopArrival = (Label)e.Row.FindControl("lblstopArrival");
                    Label lblStartFlight1 = (Label)e.Row.FindControl("lblStartFlight1");
                    Label lblstartDepart1 = (Label)e.Row.FindControl("lblstartDepart1");
                    Label lblstopArrival1 = (Label)e.Row.FindControl("lblstopArrival1");
                    Panel pnlstops = (Panel)e.Row.FindControl("pnlstops");

                    //Splitting the departuredatetime with T
                    Label lbldepartdate = (Label)e.Row.FindControl("lblOnwardDeparts");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblOnwardDepartstime");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());
                    string format = "ddd , MMM  d, yyyy";
                    lbldepartdate.Text = dt.ToString(format);


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblOnwardArrives");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblOnwardArrivestime");
                    DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);

                    DateTime dt1 = Convert.ToDateTime(Arrtime[0].ToString());
                    lblarrivaldate.Text = dt1.ToString(format);

                    //Getting the Cityname basedon airport code for departure
                    Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    DataSet dsairports = (DataSet)Session["AirportsCode"];
                    DataTable dtair = dsairports.Tables[0];
                    DataRow[] daar = dtair.Select("AirportCode = '" + lblDepartureAirportCode.Text.Trim() + "'");
                    lblDepartureAirportCode.Text = daar[0]["CityName"].ToString();


                    //Getting the Cityname basedon airport code for arrival
                    Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    DataRow[] drcity = dtair.Select("AirportCode = '" + lblArrivalAirportCode.Text.Trim() + "'");
                    lblArrivalAirportCode.Text = drcity[0]["CityName"].ToString();

                    if (lblnoofstops.Text == "1")
                    {

                        //string s = lblviaflight.Text.Replace("<brbr>", " ");
                        //string[] s1 = s.Split(' ');

                        //string s2 = s1[0].Replace("<br>", " ");
                        //string[] s3 = s2.Split(' ');

                        //string s4 = s1[1].Replace("<br>", " ");
                        //string[] s5 = s4.Split(' ');
                        //if (s3[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[3].Split('T');
                        //    s3[3] = s6[1].ToString();
                        //}
                        //if (s3[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[5].Split('T');
                        //    s3[5] = s6[1].ToString();
                        //}
                        //if (s5[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[5].Split('T');
                        //    s5[5] = s6[1].ToString();
                        //}
                        //if (s5[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[3].Split('T');
                        //    s5[3] = s6[1].ToString();
                        //}
                        //lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                        //lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                        //lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                        //lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                        //lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                        //lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                        pnlstops.Visible = false;

                        lblnoofstops.Text = lblnoofstops.Text + "Stop(s)";
                    }
                    else
                    {
                        lblnoofstops.Text = "Direct";

                        lblstartDepart.Text = "" + "<br> " + "";
                        lblstopArrival.Text = "" + "<br> " + ""; ;
                        lblstartDepart1.Text = "";
                        lblstopArrival1.Text = "";
                        lblStartFlight.Text = "";
                        lblStartFlight1.Text = "";
                        pnlstops.Visible = false;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;

                    Image imagepath = (Image)e.Row.FindControl("imgonward");
                    Label lblOperatingAirlineName = (Label)e.Row.FindControl("lblOperatingAirlineName");
                    clsMasters objmasters = new clsMasters();
                    objmasters.ScreenInd = Masters.getimages;
                    DataSet ds = (DataSet)objmasters.fnGetData();
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            int i;
                            DataTable data = ds.Tables[0];
                            for (i = 0; i < data.Rows.Count; i++)
                            {
                                if (lblOperatingAirlineName.Text.Trim().ToString() == data.Rows[i]["AirlineName"].ToString().Trim().ToString())
                                {
                                    imagepath.ImageUrl = data.Rows[i]["ImagePath"].ToString();

                                }
                            }

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }
    }
    protected void gdvreturnconnectingflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
               // dsIntFlights = (DataSet)Session["dsDomFlights"];

                GridView gv = sender as GridView;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblFlightNumber = (Label)e.Row.FindControl("lblFlightNumber");
                    Label lblduration = (Label)e.Row.FindControl("lblReturnDuration");
                    LinkButton lblnoofstops = (LinkButton)e.Row.FindControl("lnkNoofstops");
                    Label lblviaflight = (Label)e.Row.FindControl("lblviaflight");
                    Label lblStartFlight = (Label)e.Row.FindControl("lblStartFlight");
                    Label lblstartDepart = (Label)e.Row.FindControl("lblstartDepart");
                    Label lblstopArrival = (Label)e.Row.FindControl("lblstopArrival");
                    Label lblStartFlight1 = (Label)e.Row.FindControl("lblStartFlight1");
                    Label lblstartDepart1 = (Label)e.Row.FindControl("lblstartDepart1");
                    Label lblstopArrival1 = (Label)e.Row.FindControl("lblstopArrival1");
                    Panel pnlstops = (Panel)e.Row.FindControl("pnlstops");

                    //Splitting the departuredatetime with T
                    Label lbldepartdate = (Label)e.Row.FindControl("lblReturnDeparts");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblReturnDepartstime");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());
                    string format = "ddd , MMM  d, yyyy";
                    lbldepartdate.Text = dt.ToString(format);


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblReturnArrives");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblReturnArrivestime");
                    DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);

                    DateTime dt1 = Convert.ToDateTime(Arrtime[0].ToString());
                    lblarrivaldate.Text = dt1.ToString(format);

                    //Getting the Cityname basedon airport code for departure
                    Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    DataSet dsairports = (DataSet)Session["AirportsCode"];
                    DataTable dtair = dsairports.Tables[0];
                    DataRow[] daar = dtair.Select("AirportCode = '" + lblDepartureAirportCode.Text.Trim() + "'");
                    lblDepartureAirportCode.Text = daar[0]["CityName"].ToString();


                    //Getting the Cityname basedon airport code for arrival
                    Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    DataRow[] drcity = dtair.Select("AirportCode = '" + lblArrivalAirportCode.Text.Trim() + "'");
                    lblArrivalAirportCode.Text = drcity[0]["CityName"].ToString();

                    if (lblnoofstops.Text == "1")
                    {

                        //string s = lblviaflight.Text.Replace("<brbr>", " ");
                        //string[] s1 = s.Split(' ');

                        //string s2 = s1[0].Replace("<br>", " ");
                        //string[] s3 = s2.Split(' ');

                        //string s4 = s1[1].Replace("<br>", " ");
                        //string[] s5 = s4.Split(' ');
                        //if (s3[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[3].Split('T');
                        //    s3[3] = s6[1].ToString();
                        //}
                        //if (s3[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s3[5].Split('T');
                        //    s3[5] = s6[1].ToString();
                        //}
                        //if (s5[5].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[5].Split('T');
                        //    s5[5] = s6[1].ToString();
                        //}
                        //if (s5[3].ToString() != "NA")
                        //{
                        //    string[] s6 = s5[3].Split('T');
                        //    s5[3] = s6[1].ToString();
                        //}
                        //lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                        //lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                        //lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                        //lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                        //lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                        //lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                        pnlstops.Visible = false;

                        lblnoofstops.Text = lblnoofstops.Text + "Stop(s)";
                    }
                    else
                    {
                        lblnoofstops.Text = "Direct";

                        lblstartDepart.Text = "" + "<br> " + "";
                        lblstopArrival.Text = "" + "<br> " + ""; ;
                        lblstartDepart1.Text = "";
                        lblstopArrival1.Text = "";
                        lblStartFlight.Text = "";
                        lblStartFlight1.Text = "";
                        pnlstops.Visible = false;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;

                    Image imagepath = (Image)e.Row.FindControl("imgreturn");
                    Label lblOperatingAirlineName = (Label)e.Row.FindControl("lblOperatingAirlineName");
                    clsMasters objmasters = new clsMasters();
                    objmasters.ScreenInd = Masters.getimages;
                    DataSet ds = (DataSet)objmasters.fnGetData();
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            int i;
                            DataTable data = ds.Tables[0];
                            for (i = 0; i < data.Rows.Count; i++)
                            {
                                if (lblOperatingAirlineName.Text.Trim().ToString() == data.Rows[i]["AirlineName"].ToString().Trim().ToString())
                                {
                                    imagepath.ImageUrl = data.Rows[i]["ImagePath"].ToString();

                                }
                            }

                        }
                    }

                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            mp3.Show();
            lblerror.Text = ex.Message;
        }
    }
    protected void gdvRoundtrip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dtNewFlightSegmentOnward = new DataTable();
        dtNewFlightSegmentReturn = new DataTable();
        try
        {
            dsIntFlights = (DataSet)Session["dsIntFlights"];

            DataTable dtFlightSegments = dsIntFlights.Tables["FlightSegments"];
            DataTable dtFlightSegment = dsIntFlights.Tables["FlightSegment"];

            if (Session["Sortdata"] != null)
            {
                dtFlightSegment =(DataTable)Session["Sortdata"];
            }

            if (dtNewFlightSegmentOnward.Rows.Count == 0 || dtNewFlightSegmentOnward.Columns.Count == 0)
            {
                dtNewFlightSegmentOnward = dtFlightSegment.Clone();
                dtNewFlightSegmentReturn = dtFlightSegment.Clone();
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOnwardAirline = (Label)e.Row.FindControl("lblOnwardAirline");
                Label lblOnwardConnectingFlights = (Label)e.Row.FindControl("lblOnwardConnectingFlights");
                Label lblOnwardDestinations = (Label)e.Row.FindControl("lblOnwardDestinations");
                Label lblOnwardDeparts = (Label)e.Row.FindControl("lblOnwardDeparts");
                Label lblOnwardArrives = (Label)e.Row.FindControl("lblOnwardArrives");
                Label lblOnwardDuration = (Label)e.Row.FindControl("lblOnwardDuration");
                Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
                Label lblOnwardConnectingAirline = (Label)e.Row.FindControl("lblOnwardConnectingAirline");
                Label lblOnwardConnectingDestinations = (Label)e.Row.FindControl("lblOnwardConnectingDestinations");
                Label lblOnwardConnectingDeparts = (Label)e.Row.FindControl("lblOnwardConnectingDeparts");
                Label lblOnwardConnectingArrives = (Label)e.Row.FindControl("lblOnwardConnectingArrives");
                Label lblOnwardConnectingDuration = (Label)e.Row.FindControl("lblOnwardConnectingDuration");

                Label lblReturnConnectingAirline = (Label)e.Row.FindControl("lblReturnConnectingAirline");
                Label lblReturnConnectingDestinations = (Label)e.Row.FindControl("lblReturnConnectingDestinations");
                Label lblReturnConnectingDeparts = (Label)e.Row.FindControl("lblReturnConnectingDeparts");
                Label lblReturnConnectingArrives = (Label)e.Row.FindControl("lblReturnConnectingArrives");
                Label lblReturnConnectingDuration = (Label)e.Row.FindControl("lblReturnConnectingDuration");

                Label lblReturnAirline = (Label)e.Row.FindControl("lblReturnAirline");
                Label lblReturnConnectingFlights = (Label)e.Row.FindControl("lblReturnConnectingFlights");
                Label lblReturnDestinations = (Label)e.Row.FindControl("lblReturnDestinations");
                Label lblReturnDeparts = (Label)e.Row.FindControl("lblReturnDeparts");
                Label lblReturnArrives = (Label)e.Row.FindControl("lblReturnArrives");
                Label lblReturnDuration = (Label)e.Row.FindControl("lblReturnDuration");
                Label lblOriginDestiantionOptionid = (Label)e.Row.FindControl("lblOriginDestiantionOptionid");

                Label lblflighno = (Label)e.Row.FindControl("lblflighno");
                Label lblflighnoreturn = (Label)e.Row.FindControl("lblflighnoreturn");

                Label lblTotal = (Label)e.Row.FindControl("lblTotal");

                #region Variables
                string availResponseId = string.Empty;
                string originDestinationOptionsId = string.Empty;
                string originDestinationOptionId = string.Empty;
                string onwardId = string.Empty;
                string returnId = string.Empty;
                string FlightSegmentsId = string.Empty;
                string FlightSegmentID = string.Empty;
                string DepartureAirportCode = string.Empty;
                string ArrivalDateTime = string.Empty;
                string DepartureAirportName = string.Empty;
                string DepartureDateTime = string.Empty;
                string FlightNumber = string.Empty;
                string MarketingAirlineCode = string.Empty;
                string OperatingAirlineCode = string.Empty;
                string OperatingAirlineName = string.Empty;
                string OperatingAirlineFlightNumber = string.Empty;
                string NumStops = string.Empty;
                string LinkSellAgrmnt = string.Empty;
                string Conx = string.Empty;
                string AirpChg = string.Empty;
                string InsideAvailOption = string.Empty;
                string GenTrafRestriction = string.Empty;
                string DaysOperates = string.Empty;
                string JrnyTm = string.Empty;
                string EndDt = string.Empty;
                string StartTerminal = string.Empty;
                string EndTerminal = string.Empty;
                string FltTm = string.Empty;
                string LSAInd = string.Empty;
                string Mile = string.Empty;
                string Availability = string.Empty;
                string BIC = string.Empty;
                string bookingclass = string.Empty;
                string classType = string.Empty;
                string farebasiscode = string.Empty;
                string Rule = string.Empty;
                string PsgrType = string.Empty;
                string BaseFare = string.Empty;
                string Tax = string.Empty;
                string BagInfo = string.Empty;
                string AirEquipType = string.Empty;
                string ArrivalAirportCode = string.Empty;
                string ArrivalAirportName = string.Empty;
                string return1 = string.Empty;
                string id = string.Empty;
                string key = string.Empty;
                string ActualBaseFare = string.Empty;
                string FareTax = string.Empty;
                string STax = string.Empty;
                string TCharge = string.Empty;
                string SCharge = string.Empty;
                string TDiscount = string.Empty;
                string TMarkup = string.Empty;
                string TPartnerCommission = string.Empty;
                string TSdiscount = string.Empty;
                string FarePsgrType = string.Empty;
                string FareBaseFare = string.Empty;
                string FareTax1 = string.Empty;
                string Country = string.Empty;
                string Amt = string.Empty;
                string ocTax = string.Empty;
                string OriginDestinationOption_Id = string.Empty;
                string FareDetails_id = string.Empty;
                string FareBreakUp_Id = string.Empty;
                string FareAry_id = string.Empty;
                string FareId = string.Empty;
                string bookingclassFareId = string.Empty;
                string psgrBreakUp_Id = string.Empty;
                string psgrAy_id = string.Empty;
                string country = string.Empty;
                string taxAmt = string.Empty;
                string taxData = string.Empty;
                string taxDataAry_id = string.Empty;
                #endregion

                TextBox txtfromsearch = new TextBox();
                txtfromsearch.Text = Session["From"].ToString();
                TextBox txttosearch = new TextBox();
                txttosearch.Text = Session["TO"].ToString();

                string from = txtfromsearch.Text.Substring(txtfromsearch.Text.IndexOf("(") + 1, 3);
                string to = txttosearch.Text.Substring(txttosearch.Text.IndexOf("(") + 1, 3);

                DataTable dtOnward = dsIntFlights.Tables["Onward"];
                DataRow[] drOnward = dtOnward.Select("OriginDestinationOption_Id=" + lblOriginDestiantionOptionid.Text.ToString());
                DataTable dtReturn = dsIntFlights.Tables["Return"];
                DataRow[] drReturn = dtReturn.Select("OriginDestinationOption_Id=" + lblOriginDestiantionOptionid.Text.ToString());

                for (int j = 0; j < drOnward.Length; j++)
                {
                    DataRow[] rowFlightSegments = dtFlightSegments.Select("onward_Id=" + drOnward[j]["Onward_Id"].ToString());
                    DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id = " + rowFlightSegments[j]["FlightSegments_Id"].ToString());
                    foreach (DataRow dr in rowFlightSegment)
                    {
                        dtNewFlightSegmentOnward.ImportRow(dr);
                    }

                    //if (dtNewFlightSegmentOnward.Rows[0]["Conx"].ToString() != "Y")
                    //{
                    //    Label lbldeparttime1 = (Label)e.Row.FindControl("lbldeparttime1");

                    //}

                    GridView gdvonwardconnectingflights = (GridView)e.Row.FindControl("gdvonwardconnectingflights");
                    gdvonwardconnectingflights.DataSource = dtNewFlightSegmentOnward;
                    gdvonwardconnectingflights.DataBind();
                }
                for (int x = 0; x < drReturn.Length; x++)
                {
                    DataRow[] rowFlightSegments = dtFlightSegments.Select("Return_Id=" + drReturn[x]["Return_Id"].ToString());
                    DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id = " + rowFlightSegments[x]["FlightSegments_Id"].ToString());
                    foreach (DataRow dr in rowFlightSegment)
                    {
                        dtNewFlightSegmentReturn.ImportRow(dr);
                    }
                    GridView gdvreturnconnectingflights = (GridView)e.Row.FindControl("gdvreturnconnectingflights");
                    gdvreturnconnectingflights.DataSource = dtNewFlightSegmentReturn;
                    gdvreturnconnectingflights.DataBind();
                }

                DataTable dtFareDetails = dsIntFlights.Tables["FareDetails"];
                DataRow[] drFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + lblOriginDestiantionOptionid.Text.ToString());
                Decimal TotalFare = Convert.ToDecimal(drFareDetails[0]["actualBaseFare"]) + Convert.ToDecimal(drFareDetails[0]["tax"]) + Convert.ToDecimal(drFareDetails[0]["stax"]) + Convert.ToDecimal(drFareDetails[0]["Tcharge"]) + Convert.ToDecimal(drFareDetails[0]["TMarkup"]);//+ Convert.ToDecimal(drFareDetails[0]["scharge"]) + Convert.ToDecimal(drFareDetails[0]["Tdiscount"])

                lblTotal.Text = lblTotalPrice.Text = TotalFare.ToString();

               

                ////lblOnwardAirline.Text = dtNewFlightSegmentOnward.Rows[e.Row.RowIndex]["MarketingAirlineCode"].ToString();
                ////lblOnwardAirline.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineName"].ToString();
                ////lblOnwardDestinations.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[0]["ArrivalAirportCode"].ToString();




                ////lblOnwardDeparts.Text = dtNewFlightSegmentOnward.Rows[e.Row.RowIndex]["DepartureDateTime"].ToString();
                ////lblOnwardDeparts.Text = lblOnwardDeparts.Text.Substring(lblOnwardDeparts.Text.IndexOf("T") + 1, 5);
                ////lblOnwardArrives.Text = dtNewFlightSegmentOnward.Rows[e.Row.RowIndex]["ArrivalDateTime"].ToString();
                ////lblOnwardArrives.Text = lblOnwardArrives.Text.Substring(lblOnwardArrives.Text.IndexOf("T") + 1, 5);
                //lblflighno.Text = dtNewFlightSegmentOnward.Rows[0]["FlightNumber"].ToString();



                ////lblOnwardDuration.Text = lblOnwardDuration.Text.Substring(0, lblOnwardDuration.Text.Length - 3);
                ////ravi 


                Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                Label lblTax = (Label)e.Row.FindControl("lblTax");
                Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblFare = (Label)e.Row.FindControl("lblFare");
                Label lblBaseFarereturn = (Label)e.Row.FindControl("lblBaseFarereturn");
                Label lblTaxreturn = (Label)e.Row.FindControl("lblTaxreturn");
                Label lblSTaxreturn = (Label)e.Row.FindControl("lblSTaxreturn");
                Label lblSChargereturn = (Label)e.Row.FindControl("lblSChargereturn");
                Label lblTDiscountreturn = (Label)e.Row.FindControl("lblTDiscountreturn");
                Label lblTotalreturn = (Label)e.Row.FindControl("lblTotalreturn");
                Label lblFarereturn = (Label)e.Row.FindControl("lblFarereturn");
                Label lblTcharge = (Label)e.Row.FindControl("lblTcharge");

                //Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                //Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                //Label lblarrivaldatereturn = (Label)e.Row.FindControl("lblarrivaldatereturn");
                //Label lbldepartdatereturn = (Label)e.Row.FindControl("lbldepartdatereturn");
                ////lbldepartdate.Text = dtNewFlightSegmentOnward.Rows[e.Row.RowIndex]["DepartureDateTime"].ToString();
                ////lblarrivaldate.Text = dtNewFlightSegmentOnward.Rows[e.Row.RowIndex]["ArrivalDateTime"].ToString();


                lblBaseFare.Text = Convert.ToDouble(drFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                lblTax.Text = Convert.ToDouble(drFareDetails[0]["Tax"]).ToString("####0.00");
                lblSTax.Text = Convert.ToDouble(drFareDetails[0]["STax"]).ToString("####0.00");
                lblSCharge.Text = Convert.ToDouble(drFareDetails[0]["SCharge"]).ToString("####0.00");
                lblTDiscount.Text = Convert.ToDouble(drFareDetails[0]["TDiscount"]).ToString("####0.00");
                lblTcharge.Text = (Convert.ToDouble(drFareDetails[0]["TCharge"]) + Convert.ToDouble(drFareDetails[0]["TMarkup"])).ToString("####0.00");
                ////ravi end

                //#region  set departure time

                //if (e.Row.RowIndex + 2 <= dsIntFlights.Tables["FlightSegment"].Rows.Count - 2)
                //{
                //    if (dtNewFlightSegmentOnward.Rows[0]["Conx"].ToString() == "Y" && dtNewFlightSegmentOnward.Rows[1]["Conx"].ToString() == "Y" && dtNewFlightSegmentOnward.Rows[2]["Conx"].ToString() == "N")
                //    {
                //        lblOnwardDeparts.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblOnwardDeparts.Text = lblOnwardDeparts.Text.Substring(lblOnwardDeparts.Text.IndexOf("T") + 1, 5);

                //        lblOnwardConnectingFlights.Visible = true;
                //        //lblOnwardDestinations.Text = from + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString() + " - " + to;
                //        //   lblOnwardArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 2]["ArrivalDateTime"].ToString();
                //        lblOnwardArrives.Text = dtNewFlightSegmentOnward.Rows[2]["ArrivalDateTime"].ToString(); ;
                //        lblOnwardArrives.Text = lblOnwardArrives.Text.Substring(lblOnwardArrives.Text.IndexOf("T") + 1, 5);

                //        double hours1 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 2]["JrnyTm"].ToString());
                //        TimeSpan t1 = TimeSpan.FromMinutes(hours1);
                //        string answer1 = string.Format("{0}h : {1}m ", Convert.ToInt32(t1.TotalHours), t1.Minutes);
                //        lblOnwardDuration.Text = answer1;


                //        lblOnwardAirline.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineName"].ToString();
                //        lblOnwardDestinations.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[1]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[2]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[2]["ArrivalAirportCode"].ToString();

                //        lbldepartdate.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldate.Text = dtNewFlightSegmentOnward.Rows[2]["ArrivalDateTime"].ToString();

                //        ViewState["DepartDate"] = lbldepartdate.Text;
                //        ViewState["ArrivalDate"] = lblarrivaldate.Text;


                //    }
                //    else if (dtNewFlightSegmentOnward.Rows[0]["Conx"].ToString() == "Y" && dtNewFlightSegmentOnward.Rows[1]["Conx"].ToString() == "N")
                //    {
                //        lblOnwardDeparts.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblOnwardDeparts.Text = lblOnwardDeparts.Text.Substring(lblOnwardDeparts.Text.IndexOf("T") + 1, 5);
                //        lblOnwardConnectingFlights.Visible = true;
                //        //lblOnwardDestinations.Text = from + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + to;
                //        // lblOnwardArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();

                //        lblOnwardArrives.Text = dtNewFlightSegmentOnward.Rows[1]["ArrivalDateTime"].ToString();
                //        lblOnwardArrives.Text = lblOnwardArrives.Text.Substring(lblOnwardArrives.Text.IndexOf("T") + 1, 5);

                //        double hours2 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 1]["JrnyTm"].ToString());
                //        TimeSpan t2 = TimeSpan.FromMinutes(hours2);
                //        string answer2 = string.Format("{0}h : {1}m ", Convert.ToInt32(t2.TotalHours), t2.Minutes);
                //        lblOnwardDuration.Text = answer2;

                //        lblOnwardAirline.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineName"].ToString();
                //        lblOnwardDestinations.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[1]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[1]["ArrivalAirportCode"].ToString();



                //        lbldepartdate.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldate.Text = dtNewFlightSegmentOnward.Rows[1]["ArrivalDateTime"].ToString();

                //        ViewState["DepartDate"] = lbldepartdate.Text;
                //        ViewState["ArrivalDate"] = lblarrivaldate.Text;

                //    }

                //    else
                //    {

                //        lblOnwardDeparts.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblOnwardDeparts.Text = lblOnwardDeparts.Text.Substring(lblOnwardDeparts.Text.IndexOf("T") + 1, 5);


                //        lbldepartdate.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldate.Text = dtNewFlightSegmentOnward.Rows[0]["ArrivalDateTime"].ToString();

                //        ViewState["DepartDate"] = lbldepartdate.Text;
                //        ViewState["ArrivalDate"] = lblarrivaldate.Text;
                //        //lblOnwardDestinations.Text = from + " - " + to;


                //        lblOnwardArrives.Text = dsIntFlights.Tables["FlightSegment"].Rows[0]["ArrivalDateTime"].ToString();
                //        lblOnwardArrives.Text = lblOnwardArrives.Text.Substring(lblOnwardArrives.Text.IndexOf("T"), 5);

                //        double hours3 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["JrnyTm"].ToString());
                //        TimeSpan t3 = TimeSpan.FromMinutes(hours3);
                //        string answer3 = string.Format("{0}h : {1}m ", Convert.ToInt32(t3.TotalHours), t3.Minutes);
                //        lblOnwardDuration.Text = answer3;


                //        lblOnwardAirline.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineName"].ToString();
                //        lblOnwardDestinations.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentOnward.Rows[1]["ArrivalAirportCode"].ToString();

                //    }
                //}

                //#endregion
                //#region Calculating SNF and HNF
                //if (Session["UserID"] != null)
                //{
                //    if (Session["Role"].ToString() == "Agent")
                //    {
                //        ClsBAL objBAL1 = new ClsBAL();
                //        DataSet dsCommSlab = objBAL1.GetCommissionSlab(Session["Role"].ToString(), "InterNationalFlights", lblOnwardAirline.Text);
                //        string commisionPercentage = string.Empty;
                //        if (dsCommSlab.Tables[0].Rows.Count > 0)
                //            commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                //        else
                //            commisionPercentage = "0";

                //        Label lblHNFFare = (Label)e.Row.FindControl("lblHNFFareRoundtrip");
                //        double CommissionFare = (Convert.ToDouble(lblTotal.Text) * Convert.ToDouble(commisionPercentage)) / Convert.ToDouble(100);
                //        double DeductAmount = Convert.ToDouble(lblTotal.Text) - CommissionFare;
                //        lblHNFFare.Text = DeductAmount.ToString();

                //        #region Adding mark up price of agent
                //        Class1 objBal = new Class1();
                //        objBal.ScreenInd = Master123.gettopmarkup;
                //        objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                //        objBal.Type = "International Flights";
                //        objDataSet = (DataSet)objBal.fnGetData();
                //        string markUpAmount = "0";
                //        ViewState["MarkUp"] = markUpAmount;
                //        if (objDataSet != null)
                //        {
                //            if (objDataSet.Tables.Count > 0)
                //            {

                //                markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                //                ViewState["MarkUp"] = markUpAmount;
                //                if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                //                {
                //                    lblTcharge.Text = (Convert.ToDouble(lblTcharge.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                //                }
                //                else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                //                {
                //                    lblTcharge.Text = (Convert.ToDouble(lblTcharge.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                //                }
                //                double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTcharge.Text);
                //                lblFare.Text = lblTotal.Text = total1.ToString();

                //            }
                //        }


                //        #endregion
                //    }
                //}
                //#endregion
                ////if (dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["Conx"].ToString() == "N")
                ////{
                ////    e.Row.Visible = false;
                ////}




                //DataRow[] drReturnFlightSegments = dtFlightSegments.Select("Return_Id = " + lblOriginDestiantionOptionid.Text.ToString());   ///changed by ravi
                //string RetFlightSegmentsId = drReturnFlightSegments[0]["FlightSegments_Id"].ToString();
                //DataRow[] drFlightSegmentReturn = dtNewFlightSegmentReturn.Select("FlightSegments_Id = " + RetFlightSegmentsId);
               // lblflighnoreturn.Text = drFlightSegmentReturn[drFlightSegmentReturn.Length - 1]["FlightNumber"].ToString();
                lblBaseFarereturn.Text = Convert.ToDouble(drFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                lblTaxreturn.Text = Convert.ToDouble(drFareDetails[0]["Tax"]).ToString("####0.00");
                lblSTaxreturn.Text = Convert.ToDouble(drFareDetails[0]["STax"]).ToString("####0.00");
                lblSChargereturn.Text = Convert.ToDouble(drFareDetails[0]["SCharge"]).ToString("####0.00");
                lblTDiscountreturn.Text = Convert.ToDouble(drFareDetails[0]["TDiscount"]).ToString("####0.00");

                ////ravi end


                //if (e.Row.RowIndex + 3 <= dsIntFlights.Tables["FlightSegment"].Rows.Count - 1)
                //{
                //    if (dtNewFlightSegmentReturn.Rows[0]["Conx"].ToString() == "Y" && dtNewFlightSegmentReturn.Rows[1]["Conx"].ToString() == "Y" && dtNewFlightSegmentReturn.Rows[2]["Conx"].ToString() == "N")
                //    {
                //        lblReturnDeparts.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblReturnDeparts.Text = lblReturnDeparts.Text.Substring(lblReturnDeparts.Text.IndexOf("T") + 1, 5);

                //        //lblReturnDestinations.Text = to + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + from;
                //        lblReturnArrives.Text = dtNewFlightSegmentReturn.Rows[2]["ArrivalDateTime"].ToString();
                //        lblReturnArrives.Text = lblReturnArrives.Text.Substring(lblReturnArrives.Text.IndexOf("T") + 1, 5);

                //        double hours4 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 3]["JrnyTm"].ToString());
                //        TimeSpan t4 = TimeSpan.FromMinutes(hours4);
                //        string answer4 = string.Format("{0}h : {1}m ", Convert.ToInt32(t4.TotalHours), t4.Minutes);
                //        lblReturnDuration.Text = answer4;

                //        lblReturnAirline.Text = dtNewFlightSegmentReturn.Rows[0]["OperatingAirlineName"].ToString();
                //        lblReturnDestinations.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[1]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[2]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[2]["ArrivalAirportCode"].ToString();

                //        lbldepartdatereturn.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldatereturn.Text = dtNewFlightSegmentReturn.Rows[2]["ArrivalDateTime"].ToString();

                //        ViewState["DepartDateReturn"] = lbldepartdatereturn.Text;
                //        ViewState["ArrivalDateReturn"] = lblarrivaldatereturn.Text;


                //    }
                //    else if (dtNewFlightSegmentReturn.Rows[0]["Conx"].ToString() == "Y" && dtNewFlightSegmentReturn.Rows[1]["Conx"].ToString() == "N")
                //    {
                //        lblReturnDeparts.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblReturnDeparts.Text = lblReturnDeparts.Text.Substring(lblReturnDeparts.Text.IndexOf("T") + 1, 5);

                //        //lblReturnDestinations.Text = to + " - " + dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString() + " - " + from;
                //        lblReturnArrives.Text = dtNewFlightSegmentReturn.Rows[1]["ArrivalDateTime"].ToString();
                //        lblReturnArrives.Text = lblReturnArrives.Text.Substring(lblReturnArrives.Text.IndexOf("T") + 1, 5);

                //        double hours4 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 3]["JrnyTm"].ToString());
                //        TimeSpan t4 = TimeSpan.FromMinutes(hours4);
                //        string answer4 = string.Format("{0}h : {1}m ", Convert.ToInt32(t4.TotalHours), t4.Minutes);
                //        lblReturnDuration.Text = answer4;


                //        lblReturnAirline.Text = dtNewFlightSegmentReturn.Rows[0]["OperatingAirlineName"].ToString();
                //        lblReturnDestinations.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[1]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[1]["ArrivalAirportCode"].ToString();

                //        lbldepartdatereturn.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldatereturn.Text = dtNewFlightSegmentReturn.Rows[1]["ArrivalDateTime"].ToString();


                //        ViewState["DepartDateReturn"] = lbldepartdatereturn.Text;
                //        ViewState["ArrivalDateReturn"] = lblarrivaldatereturn.Text;

                //    }
                //    else
                //    {
                //        lblReturnDeparts.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblReturnDeparts.Text = lblReturnDeparts.Text.Substring(lblReturnDeparts.Text.IndexOf("T") + 1, 5);

                //        lblReturnDestinations.Text = from + " - " + to;

                //        lblReturnArrives.Text = dtNewFlightSegmentReturn.Rows[0]["ArrivalDateTime"].ToString();
                //        lblReturnArrives.Text = lblReturnArrives.Text.Substring(lblReturnArrives.Text.IndexOf("T"), 5);

                //        double hours5 = Convert.ToDouble(dsIntFlights.Tables["FlightSegment"].Rows[e.Row.RowIndex + 2]["JrnyTm"].ToString());
                //        TimeSpan t5 = TimeSpan.FromMinutes(hours5);
                //        string answer5 = string.Format("{0}h : {1}m ", Convert.ToInt32(t5.TotalHours), t5.Minutes);
                //        lblReturnDuration.Text = answer5;

                //        lblReturnAirline.Text = dtNewFlightSegmentReturn.Rows[0]["OperatingAirlineName"].ToString();
                //        lblReturnDestinations.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureAirportCode"].ToString() + "-" + dtNewFlightSegmentReturn.Rows[0]["ArrivalAirportCode"].ToString();

                //        lbldepartdatereturn.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                //        lblarrivaldatereturn.Text = dtNewFlightSegmentReturn.Rows[0]["ArrivalDateTime"].ToString();


                //        ViewState["DepartDateReturn"] = lbldepartdatereturn.Text;
                //        ViewState["ArrivalDateReturn"] = lblarrivaldatereturn.Text;

                //    }
                //}

                DataTable dtactivedetails = dsIntFlights.Tables[0];
                Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                lbladultreturn.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                lblchildreturn.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                lblinfantreturn.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                lblTrip.Text = dtactivedetails.Rows[0]["Trip"].ToString();


            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }

    protected void gdvRoundtrip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BookTicket")
        {
            if (Session["UserId"] == null)
            {
                Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                pnl.Visible = true;
            }
            ModifySearch.Visible = false;
            // lnkModifySearch.Visible = false;
            trFilterSearch.Visible = false;
            lblOriginDestinationRoundTrip.Text = e.CommandArgument.ToString();
            pnlIntPassengerDet.Visible = true;
            //  lnkModifySearch.Visible = false;
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            Session["TotalFare"] = ((Label)row.Cells[0].FindControl("lblTotalPrice")).Text.ToString();
            gdvRoundtrip.Visible = false;
            btnIntBookRoundTrip.Visible = true;
            btnIntBook.Visible = false;


            //ravi
            Control ctl = e.CommandSource as Control;
            GridViewRow gdvFlightsrow = ctl.NamingContainer as GridViewRow;

            GridView gdvonwardconnectingflights = (GridView)gdvFlightsrow.FindControl("gdvonwardconnectingflights");

            GridView gdvreturnconnectingflights = (GridView)gdvFlightsrow.FindControl("gdvreturnconnectingflights");


          
            Label lblOnwardAirline = (Label)gdvFlightsrow.FindControl("lblOnwardAirline");
            Label lblReturnAirline = (Label)gdvFlightsrow.FindControl("lblReturnAirline");
            //   Label lblOperatingAirlineFlightNumber = (Label)gdvFlightsrow.FindControl("lblFlightNumber");
            Label lblOnwardDestinations = (Label)gdvFlightsrow.FindControl("lblOnwardDestinations");
            Label lblReturnDestinations = (Label)gdvFlightsrow.FindControl("lblReturnDestinations");


            Label lblTax1 = (Label)gdvFlightsrow.FindControl("lblTax");
            Label lblSTax1 = (Label)gdvFlightsrow.FindControl("lblSTax");
            Label lblSCharge1 = (Label)gdvFlightsrow.FindControl("lblSCharge");
            Label lblTDiscount1 = (Label)gdvFlightsrow.FindControl("lblTDiscount");
            Label lblTotal1 = (Label)gdvFlightsrow.FindControl("lblTotalPrice");
            Label lblBaseFare1 = (Label)gdvFlightsrow.FindControl("lblBaseFare");
            Label lblTcharge1 = (Label)gdvFlightsrow.FindControl("lblTcharge");

            Label lblflighno = (Label)gdvFlightsrow.FindControl("lblflighno");
            Label lblflighnoreturn = (Label)gdvFlightsrow.FindControl("lblflighnoreturn");

            //lblflightnoreturn
            //lblflightno
            lblflightno.Text = lblflighno.Text;
            lblflightnoreturn.Text = lblflighnoreturn.Text;

            //lbldepartdate.Text = ViewState["DepartDate"].ToString();
            //lblarrivaldate.Text = ViewState["DepartDateReturn"].ToString();


            foreach (GridViewRow item in gdvonwardconnectingflights.Rows)
            {
                Label lblarrtime = (Label)item.FindControl("lblOnwardArrives");
                Label lbldeptime = (Label)item.FindControl("lblOnwardDepartstime");

                Label lbldepartdate = (Label)item.FindControl("lblOnwardDeparts");
                Label lblarrivaldate = (Label)item.FindControl("lblOnwardArrives");

                DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                string format = "MMM ddd d HH:mm yyyy";

                string departdate = Date.ToString("dd/MM/yyyy");
                string arrivaldate = Date1.ToString("dd/MM/yyyy");

                lbldepart.Text = departdate;
                lblarrives.Text = arrivaldate;
                lblarrivetime.Text = lblarrtime.Text;
                lbldeparttime.Text = lbldeptime.Text;
            }
            //lbldepartdate.Text = Date.ToString("dd/MM/yyyy");
            //lblarrivaldate.Text = Date1.ToString("dd/MM/yyyy");

            //lbldepartdatereturn.Text = ViewState["DepartDateReturn"].ToString();
            //lblarrivaldatereturn.Text = ViewState["ArrivalDateReturn"].ToString();

            foreach (GridViewRow item1 in gdvreturnconnectingflights.Rows)
            {
                Label lblarrtimereturn = (Label)item1.FindControl("lblReturnArrivestime");
                Label lbldeptimereturn = (Label)item1.FindControl("lblReturnDepartstime");
                Label lblarrivaldatereturn = (Label)item1.FindControl("lblReturnArrives");
                Label lbldepartdatereturn = (Label)item1.FindControl("lblReturnDeparts");

                DateTime Date2 = Convert.ToDateTime(lbldepartdatereturn.Text);
                DateTime Date3 = Convert.ToDateTime(lblarrivaldatereturn.Text);



                string departdatereturn = Date2.ToString("dd/MM/yyyy");
                string arrivaldatereturn = Date3.ToString("dd/MM/yyyy");


              

                lbldepartreturn.Text = departdatereturn;
                lblarrivesreturn.Text = arrivaldatereturn;

                lbldeparttimereturn.Text = lbldeptimereturn.Text;
                lblarrivetimereturn.Text = lblarrtimereturn.Text;
            }

            //lblairline.Text = lblOnwardAirline.Text;
           // lblairlinereturn.Text = lblReturnAirline.Text;
          

            string[] strfrom = new string[2];

            if (Session["From"] != null)
            {
                strfrom = Session["From"].ToString().Split(',');
            }
            else
            {
                Session["From"] = (rbnIntOneWay.Checked || rradiooneway.Checked) ? txtFrom.Text : txtfromsearch.Text;
                strfrom = Session["From"].ToString().Split(',');
            }
            string[] strto = new string[2];
            if (Session["TO"] != null)
            {
                strto = Session["TO"].ToString().Split(',');
            }
            else
            {
                Session["TO"] = (rbnIntRoundTrip.Checked || rradioround.Checked) ? txtTo.Text : txtleavingtosearch.Text;
                strto = Session["TO"].ToString().Split(',');
            }
            lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
            lblRouteReturn.Text = strto[0].ToString() + "-" + strfrom[0].ToString();
            //  DateTime Dateret;
            //if (rbnIntRoundTrip.Checked == true || rradioround.Checked == true)
            //{
            //    string date = (rbnIntRoundTrip.Checked || rradioround.Checked) ? txtIntReturnDate.Text : txtretundatesearch.Text;
            //    Dateret = Convert.ToDateTime(date);
            //    lblRouteFromTo.Text = lblRouteFromTo.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + Dateret.ToLongDateString();
            //}

            lblairporttax.Text = lblTax1.Text;
            lblServiceTaxreturn.Text = lblSTax1.Text;
            lblServiceCharge.Text = lblSCharge1.Text;
            lblTotalDiscount.Text = lblTDiscount1.Text;
            lblTotalAmt.Text = lblTotal1.Text;
            lblActualFare.Text = lblBaseFare1.Text;
            lblTChargeFareBreak.Text = lblTcharge1.Text;


            Label lbladultone = (Label)gdvFlightsrow.FindControl("lbladultone");
            Label lblchildone = (Label)gdvFlightsrow.FindControl("lblchildone");
            Label lblinfantone = (Label)gdvFlightsrow.FindControl("lblinfantone");
            Label lblTripone = (Label)gdvFlightsrow.FindControl("lblTripone");
            // lbladult.Text = lbladultone.Text;
            // lblchild.Text = lblchildone.Text;
            // lblinfant.Text = lblinfantone.Text;
            lblTrip.Text = lblTripone.Text;
        }

        if (e.CommandName == "View Details")
        {
            dtNewFlightSegmentOnward = new DataTable();
            dtNewFlightSegmentReturn = new DataTable();
            DataSet dsIntFlights1 = (DataSet)Session["dsIntFlights"];
            DataTable dtFlightSegments = dsIntFlights1.Tables["FlightSegments"];
            DataTable dtFlightSegment = dsIntFlights1.Tables["FlightSegment"];
            string originDestinationoptionId = e.CommandArgument.ToString();

            dtNewFlightSegmentOnward = dtFlightSegment.Clone();
            dtNewFlightSegmentReturn = dtFlightSegment.Clone();

            DataTable dtOnward = dsIntFlights1.Tables["Onward"];
            DataRow[] drOnward = dtOnward.Select("OriginDestinationOption_Id=" + originDestinationoptionId);
            DataTable dtReturn = dsIntFlights1.Tables["Return"];
            DataRow[] drReturn = dtReturn.Select("OriginDestinationOption_Id=" + originDestinationoptionId);

            for (int j = 0; j < drOnward.Length; j++)
            {
                DataRow[] rowFlightSegments = dtFlightSegments.Select("onward_Id=" + drOnward[j]["Onward_Id"].ToString());
                DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id = " + rowFlightSegments[j]["FlightSegments_Id"].ToString());
                foreach (DataRow dr in rowFlightSegment)
                {
                    dtNewFlightSegmentOnward.ImportRow(dr);
                }
            }
            for (int x = 0; x < drReturn.Length; x++)
            {
                DataRow[] rowFlightSegments = dtFlightSegments.Select("Return_Id=" + drReturn[x]["Return_Id"].ToString());
                DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id = " + rowFlightSegments[x]["FlightSegments_Id"].ToString());
                foreach (DataRow dr in rowFlightSegment)
                {
                    dtNewFlightSegmentReturn.ImportRow(dr);
                }
            }

            DataTable dtFareDetails = dsIntFlights1.Tables["FareDetails"];
            DataRow[] drFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestinationoptionId);
            Decimal TotalFare = Convert.ToDecimal(drFareDetails[0]["actualBaseFare"]) + Convert.ToDecimal(drFareDetails[0]["tax"]) + Convert.ToDecimal(drFareDetails[0]["stax"]) + Convert.ToDecimal(drFareDetails[0]["Tcharge"]); //+ Convert.ToDecimal(drFareDetails[0]["Tdiscount"]) + Convert.ToDecimal(drFareDetails[0]["scharge"]);




            lblOperatingAirlineNameDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineName"].ToString();
            lblMarketingAirlinenoonward.Text = dtNewFlightSegmentOnward.Rows[0]["MarketingAirlineCode"].ToString();
            lblOperatingAirlineFlightNumberDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["OperatingAirlineFlightNumber"].ToString();
            lblDepartureAirportNameDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureAirportName"].ToString();
            lblDepartureDateTimeDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["DepartureDateTime"].ToString();
            lblArrivalAirportNameDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["ArrivalAirportName"].ToString();
            lblArrivalDateTimeDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["ArrivalDateTime"].ToString();
            lblDurationDetonward.Text = dtNewFlightSegmentOnward.Rows[0]["FltTm"].ToString();

            TimeSpan t = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDetonward.Text));
            string[] hrs = t.TotalHours.ToString().Split('.');
            string answer = string.Format("{0}h : {1}m ", hrs[0].ToString(), t.Minutes);
            lblDurationDetonward.Text = answer;


            string[] strDep = lblDepartureDateTimeDetonward.Text.Split('T');
            string[] strArr = lblArrivalDateTimeDetonward.Text.Split('T');

            DateTime Date = Convert.ToDateTime(lblDepartureDateTimeDetonward.Text);
            DateTime Date1 = Convert.ToDateTime(lblArrivalDateTimeDetonward.Text);

            lblDepartureDateTimeDetonward.Text = Date.ToString("dd/MM/yyyy") + " " + strDep[1].ToString().Substring(0, strDep[1].ToString().Length - 3);
            lblArrivalDateTimeDetonward.Text = Date1.ToString("dd/MM/yyyy") + " " + strArr[1].ToString().Substring(0, strArr[1].ToString().Length - 3);

            if (dtNewFlightSegmentOnward.Rows[0]["Conx"].ToString() == "Y")
            {
                trConnecting1onward.Visible = true;
                lblOperatingAirlineNameDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["OperatingAirlineName"].ToString();
                lblMarketingAirlineno1onward.Text = dtNewFlightSegmentOnward.Rows[1]["MarketingAirlineCode"].ToString();
                lblOperatingAirlineFlightNumberDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["OperatingAirlineFlightNumber"].ToString();
                lblDepartureAirportNameDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["DepartureAirportName"].ToString();
                lblDepartureDateTimeDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["DepartureDateTime"].ToString();
                lblArrivalAirportNameDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["ArrivalAirportName"].ToString();
                lblArrivalDateTimeDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["ArrivalDateTime"].ToString();
                lblDurationDet1onward.Text = dtNewFlightSegmentOnward.Rows[1]["FltTm"].ToString();

                TimeSpan t1 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet1onward.Text));
                string[] hrs1 = t1.TotalHours.ToString().Split('.');
                string answer1 = string.Format("{0}h : {1}m ", hrs1[0].ToString(), t1.Minutes);
                lblDurationDet1onward.Text = answer1;


                string[] strDep1 = lblDepartureDateTimeDet1onward.Text.Split('T');
                string[] strArr1 = lblArrivalDateTimeDet1onward.Text.Split('T');

                DateTime Date11 = Convert.ToDateTime(lblDepartureDateTimeDet1onward.Text);
                DateTime Date12 = Convert.ToDateTime(lblArrivalDateTimeDet1onward.Text);

                lblDepartureDateTimeDet1onward.Text = Date11.ToString("dd/MM/yyyy") + " " + strDep1[1].ToString().Substring(0, strDep1[1].ToString().Length - 3);
                lblArrivalDateTimeDet1onward.Text = Date12.ToString("dd/MM/yyyy") + " " + strArr1[1].ToString().Substring(0, strArr1[1].ToString().Length - 3);
            }

            if (dtNewFlightSegmentOnward.Rows.Count > 1)
            {

                if (dtNewFlightSegmentOnward.Rows[1]["Conx"].ToString() == "Y")
                {
                    trConnecting2onward.Visible = true;
                    lblOperatingAirlineNameDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["OperatingAirlineName"].ToString();
                    lblMarketingAirlineno2onward.Text = dtNewFlightSegmentOnward.Rows[2]["MarketingAirlineCode"].ToString();
                    lblOperatingAirlineFlightNumberDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["OperatingAirlineFlightNumber"].ToString();
                    lblDepartureAirportNameDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["DepartureAirportName"].ToString();
                    lblDepartureDateTimeDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["DepartureDateTime"].ToString();
                    lblArrivalAirportNameDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["ArrivalAirportName"].ToString();
                    lblArrivalDateTimeDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["ArrivalDateTime"].ToString();
                    lblDurationDet2onward.Text = dtNewFlightSegmentOnward.Rows[2]["FltTm"].ToString();


                    TimeSpan t2 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet2onward.Text));
                    string[] hrs2 = t2.TotalHours.ToString().Split('.');
                    string answer2 = string.Format("{0}h : {1}m ", hrs2[0].ToString(), t2.Minutes);
                    lblDurationDet2onward.Text = answer2;


                    string[] strDep2 = lblDepartureDateTimeDet2onward.Text.Split('T');
                    string[] strArr2 = lblArrivalDateTimeDet2onward.Text.Split('T');

                    DateTime Date111 = Convert.ToDateTime(lblDepartureDateTimeDet2onward.Text);
                    DateTime Date121 = Convert.ToDateTime(lblArrivalDateTimeDet2onward.Text);

                    lblDepartureDateTimeDet2onward.Text = Date111.ToString("dd/MM/yyyy") + " " + strDep2[1].ToString().Substring(0, strDep2[1].ToString().Length - 3);
                    lblArrivalDateTimeDet2onward.Text = Date121.ToString("dd/MM/yyyy") + " " + strArr2[1].ToString().Substring(0, strArr2[1].ToString().Length - 3);
                }

            }

                //Return
                lblOperatingAirlineNameDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["OperatingAirlineName"].ToString();
                lblMarketingAirlinenoreturn.Text = dtNewFlightSegmentReturn.Rows[0]["MarketingAirlineCode"].ToString();
                lblOperatingAirlineFlightNumberDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["OperatingAirlineFlightNumber"].ToString();
                lblDepartureAirportNameDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureAirportName"].ToString();
                lblDepartureDateTimeDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["DepartureDateTime"].ToString();
                lblArrivalAirportNameDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["ArrivalAirportName"].ToString();
                lblArrivalDateTimeDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["ArrivalDateTime"].ToString();
                lblDurationDetreturn.Text = dtNewFlightSegmentReturn.Rows[0]["FltTm"].ToString();

                TimeSpan t4 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDetreturn.Text));
                string[] hrs4 = t4.TotalHours.ToString().Split('.');
                string answer4 = string.Format("{0}h : {1}m ", hrs4[0].ToString(), t4.Minutes);
                lblDurationDetreturn.Text = answer4;


                string[] strDep4 = lblDepartureDateTimeDetreturn.Text.Split('T');
                string[] strArr4 = lblArrivalDateTimeDetreturn.Text.Split('T');

                DateTime Date4 = Convert.ToDateTime(lblDepartureDateTimeDetreturn.Text);
                DateTime Date14 = Convert.ToDateTime(lblArrivalDateTimeDetreturn.Text);

                lblDepartureDateTimeDetreturn.Text = Date4.ToString("dd/MM/yyyy") + " " + strDep4[1].ToString().Substring(0, strDep4[1].ToString().Length - 3);
                lblArrivalDateTimeDetreturn.Text = Date14.ToString("dd/MM/yyyy") + " " + strArr4[1].ToString().Substring(0, strArr4[1].ToString().Length - 3);

                if (dtNewFlightSegmentReturn.Rows[0]["Conx"].ToString() == "Y")
                {
                    trConnecting1return.Visible = true;
                    lblOperatingAirlineNameDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["OperatingAirlineName"].ToString();
                    lblMarketingAirlineno1return.Text = dtNewFlightSegmentReturn.Rows[1]["MarketingAirlineCode"].ToString();
                    lblOperatingAirlineFlightNumberDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["OperatingAirlineFlightNumber"].ToString();
                    lblDepartureAirportNameDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["DepartureAirportName"].ToString();
                    lblDepartureDateTimeDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["DepartureDateTime"].ToString();
                    lblArrivalAirportNameDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["ArrivalAirportName"].ToString();
                    lblArrivalDateTimeDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["ArrivalDateTime"].ToString();
                    lblDurationDet1return.Text = dtNewFlightSegmentReturn.Rows[1]["FltTm"].ToString();




                    TimeSpan t5 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet1return.Text));
                    string[] hrs5 = t5.TotalHours.ToString().Split('.');
                    string answer5 = string.Format("{0}h : {1}m ", hrs5[0].ToString(), t5.Minutes);
                    lblDurationDet1return.Text = answer5;


                    string[] strDep5 = lblDepartureDateTimeDet1return.Text.Split('T');
                    string[] strArr5 = lblArrivalDateTimeDet1return.Text.Split('T');

                    DateTime Date5 = Convert.ToDateTime(lblDepartureDateTimeDet1return.Text);
                    DateTime Date15 = Convert.ToDateTime(lblArrivalDateTimeDet1return.Text);

                    lblDepartureDateTimeDet1return.Text = Date5.ToString("dd/MM/yyyy") + " " + strDep5[1].ToString().Substring(0, strDep5[1].ToString().Length - 3);
                    lblArrivalDateTimeDet1return.Text = Date15.ToString("dd/MM/yyyy") + " " + strArr5[1].ToString().Substring(0, strArr5[1].ToString().Length - 3);
                }

                if (dtNewFlightSegmentReturn.Rows[1]["Conx"].ToString() == "Y")
                {
                    trConnecting2return.Visible = true;
                    lblOperatingAirlineNameDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["OperatingAirlineName"].ToString();
                    lblMarketingAirlineno2return.Text = dtNewFlightSegmentReturn.Rows[2]["MarketingAirlineCode"].ToString();
                    lblOperatingAirlineFlightNumberDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["OperatingAirlineFlightNumber"].ToString();
                    lblDepartureAirportNameDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["DepartureAirportName"].ToString();
                    lblDepartureDateTimeDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["DepartureDateTime"].ToString();
                    lblArrivalAirportNameDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["ArrivalAirportName"].ToString();
                    lblArrivalDateTimeDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["ArrivalDateTime"].ToString();
                    lblDurationDet2return.Text = dtNewFlightSegmentReturn.Rows[2]["FltTm"].ToString();


                    TimeSpan t6 = TimeSpan.FromMinutes(Convert.ToDouble(lblDurationDet2return.Text));
                    string[] hrs6 = t6.TotalHours.ToString().Split('.');
                    string answer6 = string.Format("{0}h : {1}m ", hrs6[0].ToString(), t6.Minutes);
                    lblDurationDet2return.Text = answer6;


                    string[] strDep6 = lblDepartureDateTimeDet2return.Text.Split('T');
                    string[] strArr6 = lblArrivalDateTimeDet2return.Text.Split('T');

                    DateTime Date6 = Convert.ToDateTime(lblDepartureDateTimeDet2return.Text);
                    DateTime Date16 = Convert.ToDateTime(lblArrivalDateTimeDet2return.Text);

                    lblDepartureDateTimeDet2return.Text = Date6.ToString("dd/MM/yyyy") + " " + strDep6[1].ToString().Substring(0, strDep6[1].ToString().Length - 3);
                    lblArrivalDateTimeDet2return.Text = Date16.ToString("dd/MM/yyyy") + " " + strArr6[1].ToString().Substring(0, strArr6[1].ToString().Length - 3);
                }

                lnkDummyRound_Click(sender, e);            
        }
    }

    protected void lnkDummyRound_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAirlineDetOnward.Show();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnIntBookRoundTrip_Click(object sender, EventArgs e)
    {
        try
        {
            GetRoundtripIntBookingRequest();

            Session["Amount"] = lblTotalAmt.Text;

            if (Session["result"].ToString() == "true")
            {
                #region Checking the roles and booking the tickets
                  if (Session["Role"] == null)
                {
                    Response.Redirect("~/pay.aspx?val=true", false);
                }
              else  if (Session["Role"].ToString() == "User")
                {
                    objBAL = new ClsBAL();
                    DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                    Session["AgentId_Agent"] = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                    Response.Redirect("~/pay.aspx?val=true", false);
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    saveround(sender, e);
                }
                else if (Session["Role"].ToString() == "Agent")
                {
                    DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                    DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", lblairline.Text.ToString()); // Change it
                    string commisionPercentage = string.Empty;
                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                    else
                        commisionPercentage = "0";
                    string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                    string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                    string actualFare = lblTotalAmt.Text;
                    string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
                        ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));

                    string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                    Session["AgentId_Agent"] = agentId;
                    Session["ActualFare_Agent"] = actualFare;
                    Session["CommisionFare_Agent"] = commisionFare;
                    Session["CommisionPercentage_Agent"] = commisionPercentage;
                    Session["DeductAmount_Agent"] = deductAmount;

                    if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                    {
                        saveround(sender, e);
                    }
                    else
                    {
                        mp3.Show();

                        lblerror.Text = "Your balance is too low to book the ticket.So,please contact administrator";

                        return;
                    }
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                    DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", lblairline.Text.ToString()); // Change it
                    string commisionPercentage = string.Empty;
                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                    else
                        commisionPercentage = "0";
                    string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                    string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                    string actualFare = lblTotalAmt.Text;
                    string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
                        ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));

                    string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                    Session["AgentId_Agent"] = agentId;
                    Session["ActualFare_Agent"] = actualFare;
                    Session["CommisionFare_Agent"] = commisionFare;
                    Session["CommisionPercentage_Agent"] = commisionPercentage;
                    Session["DeductAmount_Agent"] = deductAmount;

                    if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                    {
                        saveround(sender, e);
                    }
                    else
                    {
                        mp3.Show();

                        lblerror.Text = "Your balance is too low to book the ticket.So, please contact administrator";

                        return;
                    }
                }
               
                #endregion
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }

    private void GetRoundtripIntBookingRequest()
    {
        dsIntFlights = (DataSet)Session["dsIntFlights"];
        DataSet dsResponse = new DataSet();
        string result = string.Empty;
        try
        {

            #region Pricing

            DataTable dtPricingreqOriginDestinationOption = dsIntFlights.Tables["OriginDestinationOption"];
            if (dtPricingreqOriginDestinationOption.Rows.Count > 0)
            {
                DataRow[] rowOriginDestinationOption = dtPricingreqOriginDestinationOption.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
                id1 = rowOriginDestinationOption[0]["id"].ToString();
                key = rowOriginDestinationOption[0]["key"].ToString();

            }

            //Get Details From roundtrip response
            DataTable dtPricingreqFareDetails = dsIntFlights.Tables["FareDetails"];
            if (dtPricingreqFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtPricingreqFareDetails.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
                ActualBaseFare = rowFareDetails[0]["ActualBaseFare"].ToString();
                Tax = rowFareDetails[0]["Tax"].ToString();
                STax = rowFareDetails[0]["STax"].ToString();
                TCharge = rowFareDetails[0]["TCharge"].ToString();
                SCharge = rowFareDetails[0]["SCharge"].ToString();
                TDiscount = rowFareDetails[0]["TDiscount"].ToString();
                TMarkup = rowFareDetails[0]["TMarkup"].ToString();
                TPartnerCommission = rowFareDetails[0]["TPartnerCommission"].ToString();
                TSdiscount = rowFareDetails[0]["TSdiscount"].ToString();
                ocTax = rowFareDetails[0]["ocTax"].ToString();
                FareDetails_id = rowFareDetails[0]["FareDetails_id"].ToString();
            }
            DataTable dtPricingreqFareBreakUp = dsIntFlights.Tables["FareBreakUp"];
            if (dtPricingreqFareBreakUp.Rows.Count > 0)
            {
                DataRow[] rowFareBreakUp = dtPricingreqFareBreakUp.Select("FareDetails_Id=" + FareDetails_id);
                FareBreakUp_Id = rowFareBreakUp[0]["FareBreakUp_Id"].ToString();

            }
            DataTable dtPricingreqFareAry = dsIntFlights.Tables["FareAry"];
            if (dtPricingreqFareAry.Rows.Count > 0)
            {
                DataRow[] rowFareAry = dtPricingreqFareAry.Select("FareBreakUp_Id=" + FareBreakUp_Id);
                FareAry_id = rowFareAry[0]["FareAry_id"].ToString();
            }
            DataTable dtPricingreqFare = dsIntFlights.Tables["Fare"];
            if (dtPricingreqFare.Rows.Count > 0)
            {
                DataRow[] rowFare = dtPricingreqFare.Select("FareAry_id=" + FareAry_id);
                PsgrType = rowFare[0]["PsgrType"].ToString();
                BaseFare = rowFare[0]["BaseFare"].ToString();
                FareTax = rowFare[0]["Tax"].ToString();
                FareId = rowFare[0]["Fare_Id"].ToString();
                foreach (DataRow dr in rowFare)
                {
                    if (faretype == "")
                    {
                        faretype = dr["PsgrType"].ToString() + "," + dr["BaseFare"].ToString() + "," + dr["Tax"].ToString();
                    }
                    else
                    {

                        faretype = faretype + ";" + dr["PsgrType"].ToString() + "," + dr["BaseFare"].ToString() + "," + dr["Tax"].ToString() + ";";
                    }
                }
            }


            //db save
            FlightBAL objFlightBal = new FlightBAL();
            String RefNo = Common.GetFlightsReferenceNo("LJIF");
            Session["Order_Id"] = RefNo.ToString();
            objFlightBal.ReferenceNo = RefNo.ToString();
            objFlightBal.TransId = "0";
            objFlightBal.Status = "Pending";
            objFlightBal.AdultPax = Convert.ToInt32(Session["Adult"]);
            objFlightBal.InfantPax = Convert.ToInt32(Session["Infant"]);
            objFlightBal.ChildPax = Convert.ToInt32(Session["Child"]);
            objFlightBal.Origin_Destination_Id = id1;
            objFlightBal.Origin_Destination_Key = key;
            objFlightBal.ActualBasefare = Convert.ToDecimal(ActualBaseFare);
            objFlightBal.Tax = Convert.ToDecimal(Tax);
            objFlightBal.STax = Convert.ToDecimal(STax);
            objFlightBal.TCharge = Convert.ToDecimal(TCharge);
            objFlightBal.Scharge = Convert.ToDecimal(SCharge);
            objFlightBal.TDiscount = Convert.ToDecimal(TDiscount);
            objFlightBal.TMarkUp = Convert.ToDecimal(TMarkup);
            objFlightBal.TPartnerCommission = Convert.ToDecimal(TPartnerCommission);
            objFlightBal.TSDiscount = Convert.ToDecimal(TSdiscount);
            objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
            objFlightBal.TripMode = "Round";
            objFlightBal.ocTax = ocTax;
            //   objFlightBal.Return = return1;
            objFlightBal.id = id1;
            objFlightBal.key = key;

            DataTable dtflightBookingId = objFlightBal.AddDInternationalFlightBooking(objFlightBal);
            Session["BookingID"] = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

            //fegments


            string customerInfo = string.Empty;
            Table tbladults = (Table)this.UpdatePanel2.FindControl("tblAdultsInt");
            for (int l = 1; l <= Convert.ToInt32(Session["adultCntInt"]); l++)
            {

                TextBox txtFn = (TextBox)tbladults.FindControl("txtFnInt" + l);
                TextBox txtLn = (TextBox)tbladults.FindControl("txtLnInt" + l);
                DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitleInt" + l);

                if (customerInfo == string.Empty)
                {
                    customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "adt" + "|" + "-";
                }
                else
                {
                    customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "adt" + "|" + "-";
                }
                //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
            }

            Table tblChild = (Table)this.UpdatePanel2.FindControl("tblChildInt");
            for (int j = 1; j <= childCntInt; j++)
            {
                TextBox txtFn = (TextBox)tblChild.FindControl("txtCFnInt" + j);

                TextBox txtLn = (TextBox)tblChild.FindControl("txtCLnInt" + j);

                DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitleInt" + j);


                TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDateInt" + j);

                string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                if (customerInfo == string.Empty)
                {
                    customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "chd" + "|" + age + "|" + txtBirthDate.Text;
                }
                else
                {
                    customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "chd" + "|" + age + "|" + txtBirthDate.Text;
                }
                //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
            }

            Table tblInfants = (Table)this.UpdatePanel2.FindControl("tblInfantsInt");
            for (int k = 1; k <= infantCntInt; k++)
            {
                TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFnInt" + k);

                TextBox txtLn = (TextBox)tblInfants.FindControl("txtILnInt" + k);

                DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitleInt" + k);

                TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDateInt" + k);
                string age = string.Empty;
                if (txtBirthDate != null)
                    age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();
                else
                    age = "0";


                if (customerInfo == string.Empty)
                {
                    customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "inf" + "|" + age + "|" + txtBirthDate.Text;
                }
                else
                {
                    customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "inf" + "|" + age + "|" + txtBirthDate.Text;
                }
                //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
            }

            DataTable dtpricingreqBookingClass = dsIntFlights.Tables["BookingClass"];
            DataTable dtpricingreqBookingClassFare = dsIntFlights.Tables["BookingClassFare"];
            DataTable dtpricingreqOnward = dsIntFlights.Tables["Onward"];
            DataTable dtpricingreqPsgrBreakUp = dsIntFlights.Tables["PsgrBreakUp"];
            DataTable dtpricingreqPsgrAry = dsIntFlights.Tables["PsgrAry"];
            DataTable dtpricingreqPsgr = dsIntFlights.Tables["Psgr"];
            DataTable dtpricingreqTaxDataAry = dsIntFlights.Tables["TaxDataAry"];
            DataTable dtpricingreqTaxData = dsIntFlights.Tables["TaxData"];
            if (dtpricingreqOnward.Rows.Count > 0)
            {
                DataRow[] rowOnward = dtpricingreqOnward.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
                onwardId = rowOnward[0]["onward_id"].ToString();
            }
            DataTable dtpricingreqFlightSegments = dsIntFlights.Tables["FlightSegments"];
            if (dtpricingreqFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFlightSegments = dtpricingreqFlightSegments.Select("onward_id=" + onwardId);
                FlightSegmentsID = rowFlightSegments[0]["FlightSegments_Id"].ToString();
            }



            DataTable dtFlightSegment = dsIntFlights.Tables[12];
            if (dtFlightSegment.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsID);
                for (int j = 0; j < rowFilghtSegment.Length; j++)
                {
                    AirEquipType = rowFilghtSegment[j]["AirEquipType"].ToString();
                    ArrivalAirportCode = rowFilghtSegment[j]["ArrivalAirportCode"].ToString();
                    ArrivalAirportName = rowFilghtSegment[j]["ArrivalAirportName"].ToString();
                    ArrivalDateTime = rowFilghtSegment[j]["ArrivalDateTime"].ToString();
                    DepartureAirportCode = rowFilghtSegment[j]["DepartureAirportCode"].ToString();
                    DepartureAirportName = rowFilghtSegment[j]["DepartureAirportName"].ToString();
                    DepartureDateTime = rowFilghtSegment[j]["DepartureDateTime"].ToString();
                    FlightNumber = rowFilghtSegment[j]["FlightNumber"].ToString();
                    MarketingAirlineCode = rowFilghtSegment[j]["MarketingAirlineCode"].ToString();
                    OperatingAirlineCode = rowFilghtSegment[j]["OperatingAirlineCode"].ToString();
                    OperatingAirlineName = rowFilghtSegment[j]["OperatingAirlineName"].ToString();
                    OperatingAirlineFlightNumber = rowFilghtSegment[j]["OperatingAirlineFlightNumber"].ToString();
                    NumStops = rowFilghtSegment[j]["NumStops"].ToString();
                    LinkSellAgrmnt = rowFilghtSegment[j]["LinkSellAgrmnt"].ToString();
                    Conx = rowFilghtSegment[j]["Conx"].ToString();
                    AirpChg = rowFilghtSegment[j]["AirpChg"].ToString();
                    InsideAvailOption = rowFilghtSegment[j]["InsideAvailOption"].ToString();
                    GenTrafRestriction = rowFilghtSegment[j]["GenTrafRestriction"].ToString();
                    DaysOperates = rowFilghtSegment[j]["DaysOperates"].ToString();
                    JrnyTm = rowFilghtSegment[j]["JrnyTm"].ToString();
                    EndDt = rowFilghtSegment[j]["EndDt"].ToString();
                    StartTerminal = rowFilghtSegment[j]["StartTerminal"].ToString();
                    EndTerminal = rowFilghtSegment[j]["EndTerminal"].ToString();
                    FltTm = rowFilghtSegment[j]["FltTm"].ToString();
                    LSAInd = rowFilghtSegment[j]["LSAInd"].ToString();
                    Mile = rowFilghtSegment[j]["Mile"].ToString();
                    //   bookingclass = rowFilghtSegment[j]["LSAInd"].ToString();
                    //   classType = rowFilghtSegment[j]["Mile"].ToString();

                    if (dtpricingreqBookingClass != null)
                    {

                        if (dtpricingreqBookingClass.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClass = dtpricingreqBookingClass.Select("FlightSegment_Id=" + rowFilghtSegment[j]["FlightSegment_Id"].ToString());
                            Availability = rowBookingClass[0]["Availability"].ToString();
                            BIC = rowBookingClass[0]["BIC"].ToString();
                        }
                    }
                    if (dtpricingreqBookingClassFare != null)
                    {
                        if (dtpricingreqBookingClassFare.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClassFare = dtpricingreqBookingClassFare.Select("FlightSegment_Id=" + rowFilghtSegment[j]["FlightSegment_Id"].ToString());
                            bookingclass = rowBookingClassFare[0]["bookingclass"].ToString();
                            classType = rowBookingClassFare[0]["classType"].ToString();
                            farebasiscode = rowBookingClassFare[0]["farebasiscode"].ToString();
                            Rule = rowBookingClassFare[0]["Rule"].ToString();
                           // bookingclassFareId = rowBookingClassFare[0]["bookingclassFare_Id"].ToString();

                        }
                    }

                    if (dtpricingreqPsgrBreakUp != null)
                    {

                        if (dtpricingreqPsgrBreakUp.Rows.Count > 0)
                        {
                            DataRow[] rowPsgrBreakUp = dtpricingreqPsgrBreakUp.Select("bookingclassFare_Id=" + bookingclassFareId);
                            psgrBreakUp_Id = rowPsgrBreakUp[0]["psgrBreakUp_Id"].ToString();

                        }
                    }

                    if (dtpricingreqPsgrAry != null)
                    {
                        if (dtpricingreqPsgrAry.Rows.Count > 0)
                        {
                            DataRow[] rowPsgrAry = dtpricingreqPsgrAry.Select("psgrBreakUp_Id=" + psgrBreakUp_Id);
                            psgrAy_id = rowPsgrAry[0]["psgrAry_Id"].ToString();

                        }
                    }
                    if (dtpricingreqPsgr != null)
                    {
                        if (dtpricingreqPsgr.Rows.Count > 0)
                        {
                            DataRow[] rowPsgr = dtpricingreqPsgr.Select("psgrAry_Id=" + psgrAy_id);
                            FarePsgrType = rowPsgr[0]["psgrType"].ToString();
                            FareBaseFare = rowPsgr[0]["BaseFare"].ToString();
                            FareTax1 = rowPsgr[0]["Tax"].ToString();
                            BagInfo = rowPsgr[0]["BagInfo"].ToString();

                        }
                    }
                    objFlightBal.FlightBookingID = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();//Convert.ToString(Session["BookingID"]);
                    objFlightBal.AirEquipType = AirEquipType;
                    objFlightBal.ArrivalAirportCode = ArrivalAirportCode;
                    objFlightBal.ArrivalAirportName = ArrivalAirportName;
                    objFlightBal.ArrivalDateTime = ArrivalDateTime;
                    objFlightBal.DepartureAirportCode = DepartureAirportCode;
                    objFlightBal.DepartureAirportName = DepartureAirportName;
                    objFlightBal.DepartureDateTime = DepartureDateTime;
                    objFlightBal.FlightNumber = FlightNumber;
                    objFlightBal.MarketingAirlineCode = MarketingAirlineCode;
                    objFlightBal.OperatingAirlineCode = OperatingAirlineCode;
                    objFlightBal.OperatingAirlineName = OperatingAirlineName;
                    objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumber;
                    objFlightBal.NumStops = NumStops;
                    objFlightBal.LinkSellAgrmnt = LinkSellAgrmnt;
                    objFlightBal.Conx = Conx;
                    objFlightBal.AirpChg = AirpChg;
                    objFlightBal.InsideAvailOption = InsideAvailOption;
                    objFlightBal.GenTrafRestriction = GenTrafRestriction;
                    objFlightBal.DaysOperates = DaysOperates;
                    objFlightBal.JrnyTm = JrnyTm;
                    objFlightBal.EndDt = EndDt;
                    objFlightBal.StartTerminal = StartTerminal;
                    objFlightBal.EndTerminal = EndTerminal;
                    objFlightBal.FltTm = FltTm;
                    objFlightBal.LSAInd = LSAInd;
                    objFlightBal.Mile = Mile;
                    objFlightBal.Availability = Availability;
                    objFlightBal.BIC = BIC;
                    objFlightBal.emailAddress = txtEmailIDInt.Text.Trim();
                    Session["EmailID"] = txtEmailIDInt.Text.Trim();
                    objFlightBal.telephone = txtMobileNumberInt.Text;
                    Session["MobileNo"] = txtMobileNumberInt.Text;
                    objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    objFlightBal.Customer_Details = customerInfo;
                    objFlightBal.Address = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                    Session["customerInfo"] = customerInfo;
                    Session["Address"] = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                    objFlightBal.bookingClass = bookingclass;
                    objFlightBal.ClassType = classType;
                    objFlightBal.farebasisCode = farebasiscode;
                    objFlightBal.Fare_Rule = Rule;
                    objFlightBal.PsgrType = FarePsgrType;
                    objFlightBal.BaseFare = FareBaseFare;
                    objFlightBal.psgrTax = FareTax1;
                    objFlightBal.BagInfo = BagInfo;
                    objFlightBal.FarePsgrType = faretype;

                    res1 = objFlightBal.AddInternationalFlightSegment(objFlightBal);

                }
            }

            DataTable dtpricingreqReturn = dsIntFlights.Tables["Return"];
            if (dtpricingreqReturn.Rows.Count > 0)
            {
                DataRow[] rowReturn = dtpricingreqReturn.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
                returnId = rowReturn[0]["return_id"].ToString();
            }
            DataTable dtpricingreqFlightSegmentsRet = dsIntFlights.Tables["FlightSegments"];
            if (dtpricingreqFlightSegmentsRet.Rows.Count > 0)
            {
                DataRow[] rowFlightSegmentsRet = dtpricingreqFlightSegmentsRet.Select("return_id=" + returnId);
                FlightSegmentsIDRet = rowFlightSegmentsRet[0]["FlightSegments_Id"].ToString();
            }
            DataTable dtpricingreqFlightSegmentRet = dsIntFlights.Tables["FlightSegment"];
            DataTable dtpricingreqBookingClassRet = dsIntFlights.Tables["BookingClass"];
            DataTable dtpricingreqBookingClassFareRet = dsIntFlights.Tables["BookingClassFare"];
            DataTable dtpricingreqPsgrBreakUpRet = dsIntFlights.Tables["PsgrBreakUp"];
            DataTable dtpricingreqPsgrAryRet = dsIntFlights.Tables["PsgrAry"];
            DataTable dtpricingreqPsgrRet = dsIntFlights.Tables["Psgr"];
            DataTable dtpricingreqTaxDataAryRet = dsIntFlights.Tables["TaxDataAry"];
            DataTable dtpricingreqTaxDataRet = dsIntFlights.Tables["TaxData"];


            if (dtpricingreqFlightSegmentRet.Rows.Count > 0)
            {
                DataRow[] rowFlightSegmentRet = dtpricingreqFlightSegmentRet.Select("FlightSegments_Id=" + FlightSegmentsIDRet);
                for (int i = 0; i < rowFlightSegmentRet.Length; i++)
                {

                    AirEquipTypeRet = rowFlightSegmentRet[i]["AirEquipType"].ToString();
                    ArrivalAirportCodeRet = rowFlightSegmentRet[i]["ArrivalAirportCode"].ToString();
                    ArrivalAirportNameRet = rowFlightSegmentRet[i]["ArrivalAirportName"].ToString();
                    ArrivalDateTimeRet = rowFlightSegmentRet[i]["ArrivalDateTime"].ToString();
                    DepartureAirportCodeRet = rowFlightSegmentRet[i]["DepartureAirportCode"].ToString();
                    DepartureAirportNameRet = rowFlightSegmentRet[i]["DepartureAirportName"].ToString();
                    DepartureDateTimeRet = rowFlightSegmentRet[i]["DepartureDateTime"].ToString();
                    FlightNumberRet = rowFlightSegmentRet[i]["FlightNumber"].ToString();
                    MarketingAirlineCodeRet = rowFlightSegmentRet[i]["MarketingAirlineCode"].ToString();
                    OperatingAirlineCodeRet = rowFlightSegmentRet[i]["OperatingAirlineCode"].ToString();
                    OperatingAirlineNameRet = rowFlightSegmentRet[i]["OperatingAirlineName"].ToString();
                    OperatingAirlineFlightNumberRet = rowFlightSegmentRet[i]["OperatingAirlineFlightNumber"].ToString();
                    NumStopsRet = rowFlightSegmentRet[i]["NumStops"].ToString();
                    LinkSellAgrmntRet = rowFlightSegmentRet[i]["LinkSellAgrmnt"].ToString();
                    ConxRet = rowFlightSegmentRet[i]["Conx"].ToString();
                    AirpChgRet = rowFlightSegmentRet[i]["AirpChg"].ToString();
                    InsideAvailOptionRet = rowFlightSegmentRet[i]["InsideAvailOption"].ToString();
                    GenTrafRestrictionRet = rowFlightSegmentRet[i]["GenTrafRestriction"].ToString();
                    DaysOperatesRet = rowFlightSegmentRet[i]["DaysOperates"].ToString();
                    JrnyTmRet = rowFlightSegmentRet[i]["JrnyTm"].ToString();
                    EndDtRet = rowFlightSegmentRet[i]["EndDt"].ToString();
                    StartTerminalRet = rowFlightSegmentRet[i]["StartTerminal"].ToString();
                    EndTerminalRet = rowFlightSegmentRet[i]["EndTerminal"].ToString();
                    FltTmRet = rowFlightSegmentRet[i]["FltTm"].ToString();
                    LSAIndRet = rowFlightSegmentRet[i]["LSAInd"].ToString();
                    MileRet = rowFlightSegmentRet[i]["Mile"].ToString();

                    if (dtpricingreqBookingClassRet != null)
                    {
                        if (dtpricingreqBookingClassRet.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClassRet = dtpricingreqBookingClassRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
                            AvailabilityRet = rowBookingClassRet[0]["Availability"].ToString();
                            BICRet = rowBookingClassRet[0]["BIC"].ToString();
                        }
                    }
                    if (dtpricingreqBookingClassFareRet != null)
                    {
                        if (dtpricingreqBookingClassFareRet.Rows.Count > 0)
                        {
                            DataRow[] rowBookingClassFareRet = dtpricingreqBookingClassFareRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
                            bookingclassRet = rowBookingClassFareRet[0]["bookingclass"].ToString();
                            classTypeRet = rowBookingClassFareRet[0]["classType"].ToString();
                            farebasiscodeRet = rowBookingClassFareRet[0]["farebasiscode"].ToString();
                            RuleRet = rowBookingClassFareRet[0]["Rule"].ToString();
                           // bookingclassFareIdRet = rowBookingClassFareRet[0]["bookingclassFare_Id"].ToString();

                        }
                    }
                    if (dtpricingreqPsgrBreakUpRet != null)
                    {

                        if (dtpricingreqPsgrBreakUpRet.Rows.Count > 0)
                        {
                            DataRow[] rowPsgrBreakUpRet = dtpricingreqPsgrBreakUpRet.Select("bookingclassFare_Id=" + bookingclassFareIdRet);
                            psgrBreakUp_IdRet = rowPsgrBreakUpRet[0]["psgrBreakUp_Id"].ToString();

                        }
                    }
                    if (dtpricingreqPsgrAryRet != null)
                    {

                        if (dtpricingreqPsgrAryRet.Rows.Count > 0)
                        {
                            DataRow[] rowPsgrAryRet = dtpricingreqPsgrAryRet.Select("psgrBreakUp_Id=" + psgrBreakUp_IdRet);
                            psgrAy_idRet = rowPsgrAryRet[0]["psgrAry_Id"].ToString();

                        }
                    }

                    if (dtpricingreqPsgrRet != null)
                    {
                        if (dtpricingreqPsgrRet.Rows.Count > 0)
                        {
                            DataRow[] rowPsgrRet = dtpricingreqPsgrRet.Select("psgrAry_Id=" + psgrAy_idRet);
                            FarePsgrTypeRet = rowPsgrRet[0]["psgrType"].ToString();
                            FareBaseFareRet = rowPsgrRet[0]["BaseFare"].ToString();
                            FareTax1Ret = rowPsgrRet[0]["Tax"].ToString();
                            BagInfoRet = rowPsgrRet[0]["BagInfo"].ToString();

                        }
                    }
                    objFlightBal.FlightBookingID = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();//Convert.ToString(Session["BookingID"]);
                    objFlightBal.AirEquipType = AirEquipTypeRet;
                    objFlightBal.ArrivalAirportCode = ArrivalAirportCodeRet;
                    objFlightBal.ArrivalAirportName = ArrivalAirportNameRet;
                    objFlightBal.ArrivalDateTime = ArrivalDateTimeRet;
                    objFlightBal.DepartureAirportCode = DepartureAirportCodeRet;
                    objFlightBal.DepartureAirportName = DepartureAirportNameRet;
                    objFlightBal.DepartureDateTime = DepartureDateTimeRet;
                    objFlightBal.FlightNumber = FlightNumberRet;
                    objFlightBal.MarketingAirlineCode = MarketingAirlineCodeRet;
                    objFlightBal.OperatingAirlineCode = OperatingAirlineCodeRet;
                    objFlightBal.OperatingAirlineName = OperatingAirlineNameRet;
                    objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumberRet;
                    objFlightBal.NumStops = NumStopsRet;
                    objFlightBal.LinkSellAgrmnt = LinkSellAgrmntRet;
                    objFlightBal.Conx = ConxRet;
                    objFlightBal.AirpChg = AirpChgRet;
                    objFlightBal.InsideAvailOption = InsideAvailOptionRet;
                    objFlightBal.GenTrafRestriction = GenTrafRestrictionRet;
                    objFlightBal.DaysOperates = DaysOperatesRet;
                    objFlightBal.JrnyTm = JrnyTmRet;
                    objFlightBal.EndDt = EndDtRet;
                    objFlightBal.StartTerminal = StartTerminalRet;
                    objFlightBal.EndTerminal = EndTerminalRet;
                    objFlightBal.FltTm = FltTmRet;
                    objFlightBal.LSAInd = LSAIndRet;
                    objFlightBal.Mile = MileRet;
                    objFlightBal.Availability = AvailabilityRet;
                    objFlightBal.BIC = BICRet;
                    objFlightBal.emailAddress = txtEmailIDInt.Text.Trim();
                    Session["EmailID"] = txtEmailIDInt.Text.Trim();
                    objFlightBal.telephone = txtMobileNumberInt.Text;
                    Session["MobileNo"] = txtMobileNumberInt.Text;
                    objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    objFlightBal.Customer_Details = customerInfo;
                    objFlightBal.Address = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                    Session["customerInfo"] = customerInfo;
                    Session["Address"] = txtCityInt.Text + "," + txtStateInt.Text + "," + ddlCountryInt.SelectedValue + "," + txtPostalCodeInt.Text + ",";
                    objFlightBal.bookingClass = bookingclassRet;
                    objFlightBal.ClassType = classTypeRet;
                    objFlightBal.farebasisCode = farebasiscodeRet;
                    objFlightBal.Fare_Rule = RuleRet;
                    objFlightBal.PsgrType = FarePsgrTypeRet;
                    objFlightBal.BaseFare = FareBaseFareRet;
                    objFlightBal.psgrTax = FareTax1Ret;
                    objFlightBal.BagInfo = BagInfoRet;
                    objFlightBal.FarePsgrType = faretype;

                    res1 = objFlightBal.AddInternationalFlightSegment(objFlightBal);
                }
            }



            if (res1 == true)
            {
               // PaymentGateway();
                Session["result"] = "true";
            }


            //end db save



        }
        catch (Exception ex)
        {

            throw;
        }

    }
    string xmlpricingrequestforInt;
    private DataSet methodround()
    {
        try
        {
            #region Variables
            string str = string.Empty;
            string FlightSegmentsID = string.Empty;
            string DepartureAirportCode = string.Empty;
            string ArrivalDateTime = string.Empty;
            string DepartureAirportName = string.Empty;
            string DepartureDateTime = string.Empty;
            string FlightNumber = string.Empty;
            string MarketingAirlineCode = string.Empty;
            string OperatingAirlineCode = string.Empty;
            string OperatingAirlineName = string.Empty;
            string OperatingAirlineFlightNumber = string.Empty;
            string NumStops = string.Empty;
            string LinkSellAgrmnt = string.Empty;
            string Conx = string.Empty;
            string AirpChg = string.Empty;
            string InsideAvailOption = string.Empty;
            string GenTrafRestriction = string.Empty;
            string DaysOperates = string.Empty;
            string JrnyTm = string.Empty;
            string EndDt = string.Empty;
            string StartTerminal = string.Empty;
            string EndTerminal = string.Empty;
            string FltTm = string.Empty;
            string LSAInd = string.Empty;
            string Mile = string.Empty;
            string Availability = string.Empty;
            string BIC = string.Empty;
            string bookingclass = string.Empty;
            string classType = string.Empty;
            string farebasiscode = string.Empty;
            string Rule = string.Empty;
            string PsgrType = string.Empty;
            string BaseFare = string.Empty;
            string Tax = string.Empty;
            string BagInfo = string.Empty;
            string AirEquipType = string.Empty;
            string ArrivalAirportCode = string.Empty;
            string ArrivalAirportName = string.Empty;
            string return1 = string.Empty;
            string id = string.Empty;
            string key = string.Empty;
            string ActualBaseFare = string.Empty;
            string FareTax = string.Empty;
            string STax = string.Empty;
            string TCharge = string.Empty;
            string SCharge = string.Empty;
            string TDiscount = string.Empty;
            string TMarkup = string.Empty;
            string TPartnerCommission = string.Empty;
            string TSdiscount = string.Empty;
            string FarePsgrType = string.Empty;
            string FareBaseFare = string.Empty;
            string FareTax1 = string.Empty;
            string Country = string.Empty;
            string Amt = string.Empty;
            string ocTax = string.Empty;
            string onwardId = string.Empty;
            string OriginDestinationOption_Id = string.Empty;
            string FareDetails_id = string.Empty;
            string FareBreakUp_Id = string.Empty;
            string FareAry_id = string.Empty;
            string FareId = string.Empty;
            string bookingclassFareId = string.Empty;
            string psgrBreakUp_Id = string.Empty;
            string psgrAy_id = string.Empty;
            string country = string.Empty;
            string taxAmt = string.Empty;
            string taxData = string.Empty;
            string taxDataAry_id = string.Empty;
            string returnId = string.Empty;

            string FlightSegmentsIDRet = string.Empty;
            string DepartureAirportCodeRet = string.Empty;
            string ArrivalDateTimeRet = string.Empty;
            string DepartureAirportNameRet = string.Empty;
            string DepartureDateTimeRet = string.Empty;
            string FlightNumberRet = string.Empty;
            string MarketingAirlineCodeRet = string.Empty;
            string OperatingAirlineCodeRet = string.Empty;
            string OperatingAirlineNameRet = string.Empty;
            string OperatingAirlineFlightNumberRet = string.Empty;
            string NumStopsRet = string.Empty;
            string LinkSellAgrmntRet = string.Empty;
            string ConxRet = string.Empty;
            string AirpChgRet = string.Empty;
            string InsideAvailOptionRet = string.Empty;
            string GenTrafRestrictionRet = string.Empty;
            string DaysOperatesRet = string.Empty;
            string JrnyTmRet = string.Empty;
            string EndDtRet = string.Empty;
            string StartTerminalRet = string.Empty;
            string EndTerminalRet = string.Empty;
            string FltTmRet = string.Empty;
            string LSAIndRet = string.Empty;
            string MileRet = string.Empty;
            string AvailabilityRet = string.Empty;
            string BICRet = string.Empty;
            string bookingclassRet = string.Empty;
            string classTypeRet = string.Empty;
            string farebasiscodeRet = string.Empty;
            string RuleRet = string.Empty;
            string PsgrTypeRet = string.Empty;
            string BaseFareRet = string.Empty;
            string TaxRet = string.Empty;
            string BagInfoRet = string.Empty;
            string AirEquipTypeRet = string.Empty;
            string ArrivalAirportCodeRet = string.Empty;
            string ArrivalAirportNameRet = string.Empty;

            string idRet = string.Empty;
            string keyRet = string.Empty;
            string ActualBaseFareRet = string.Empty;
            string FareTaxRet = string.Empty;
            string STaxRet = string.Empty;
            string TChargeRet = string.Empty;
            string SChargeRet = string.Empty;
            string TDiscountRet = string.Empty;
            string TMarkupRet = string.Empty;
            string TPartnerCommissionRet = string.Empty;
            string TSdiscountRet = string.Empty;
            string FarePsgrTypeRet = string.Empty;
            string FareBaseFareRet = string.Empty;
            string FareTax1Ret = string.Empty;
            string CountryRet = string.Empty;
            string AmtRet = string.Empty;
            string ocTaxRet = string.Empty;
            string onwardIdRet = string.Empty;
            string OriginDestinationOption_IdRet = string.Empty;
            string FareDetails_idRet = string.Empty;
            string FareBreakUp_IdRet = string.Empty;
            string FareAry_idRet = string.Empty;
            string FareIdRet = string.Empty;
            string bookingclassFareIdRet = string.Empty;
            string psgrBreakUp_IdRet = string.Empty;
            string psgrAy_idRet = string.Empty;
            string countryRet = string.Empty;
            string taxAmtRet = string.Empty;
            string taxDataRet = string.Empty;
            string taxDataAry_idRet = string.Empty;
            string returnIdRet = string.Empty;

            string taxdatapsgr = string.Empty;
            string taxdatapsgrRet = string.Empty;
            #endregion

            #region old

            //DataTable dtPricingreqFare = dsIntFlights.Tables["Fare"];
            //if (dtPricingreqFare.Rows.Count > 0)
            //{
            //    DataRow[] rowFare = dtPricingreqFare.Select("FareAry_id=" + FareAry_id);
            //    foreach (DataRow row in rowFare)
            //    {
            //        if (row.Table.Rows.Count == 0)
            //        {
            //            str = "<Fare><PsgrType>" + row["PsgrType"].ToString() + "</PsgrType><BaseFare>" + row["BaseFare"].ToString() + "</BaseFare><Tax>" + row["Tax"].ToString() + "</Tax></Fare>";
            //        }
            //        else
            //        {
            //            str = str + "<Fare><PsgrType>" + row["PsgrType"].ToString() + "</PsgrType><BaseFare>" + row["BaseFare"].ToString() + "</BaseFare><Tax>" + row["Tax"].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
            //        }
            //    }
            //}


            //FlightBAL objFlightsBal = new FlightBAL();
            //string xmlpricingrequestforInt = "<PriceRequest><noadults>" + ddlAdultsInt.SelectedValue + "</noadults><nochild>" + ddlChildsInt.SelectedValue + "</nochild><noinfant>" + ddlInfantsInt.SelectedValue + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype>";
            //xmlpricingrequestforInt = xmlpricingrequestforInt + "<OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry>" + str + "</FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails>";//<Fare><PsgrType>" + PsgrType + "</PsgrType><BaseFare>" + BaseFare + "</BaseFare><Tax>" + FareTax + "</Tax></Fare>
            //xmlpricingrequestforInt = xmlpricingrequestforInt + "<onward><FlightSegments>";


            //DataTable dtpricingreqOnward = dsIntFlights.Tables["Onward"];
            //if (dtpricingreqOnward.Rows.Count > 0)
            //{
            //    DataRow[] rowOnward = dtpricingreqOnward.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
            //    onwardId = rowOnward[0]["onward_id"].ToString();
            //}
            //DataTable dtpricingreqFlightSegments = dsIntFlights.Tables["FlightSegments"];
            //if (dtpricingreqFlightSegments.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegments = dtpricingreqFlightSegments.Select("onward_id=" + onwardId);
            //    FlightSegmentsID = rowFlightSegments[0]["FlightSegments_Id"].ToString();
            //}
            //DataTable dtpricingreqFlightSegment = dsIntFlights.Tables["FlightSegment"];
            //DataTable dtpricingreqBookingClass = dsIntFlights.Tables["BookingClass"];
            //DataTable dtpricingreqBookingClassFare = dsIntFlights.Tables["BookingClassFare"];
            //DataTable dtpricingreqPsgrBreakUp = dsIntFlights.Tables["PsgrBreakUp"];
            //DataTable dtpricingreqPsgrAry = dsIntFlights.Tables["PsgrAry"];
            //DataTable dtpricingreqPsgr = dsIntFlights.Tables["Psgr"];
            //DataTable dtpricingreqTaxDataAry = dsIntFlights.Tables["TaxDataAry"];
            //DataTable dtpricingreqTaxData = dsIntFlights.Tables["TaxData"];


            //if (dtpricingreqFlightSegment.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegment = dtpricingreqFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsID);
            //    for (int i = 0; i < rowFlightSegment.Length; i++)
            //    {

            //        AirEquipType = rowFlightSegment[i]["AirEquipType"].ToString();
            //        ArrivalAirportCode = rowFlightSegment[i]["ArrivalAirportCode"].ToString();
            //        ArrivalAirportName = rowFlightSegment[i]["ArrivalAirportName"].ToString();
            //        ArrivalDateTime = rowFlightSegment[i]["ArrivalDateTime"].ToString();
            //        DepartureAirportCode = rowFlightSegment[i]["DepartureAirportCode"].ToString();
            //        DepartureAirportName = rowFlightSegment[i]["DepartureAirportName"].ToString();
            //        DepartureDateTime = rowFlightSegment[i]["DepartureDateTime"].ToString();
            //        FlightNumber = rowFlightSegment[i]["FlightNumber"].ToString();
            //        MarketingAirlineCode = rowFlightSegment[i]["MarketingAirlineCode"].ToString();
            //        OperatingAirlineCode = rowFlightSegment[i]["OperatingAirlineCode"].ToString();
            //        OperatingAirlineName = rowFlightSegment[i]["OperatingAirlineName"].ToString();
            //        OperatingAirlineFlightNumber = rowFlightSegment[i]["OperatingAirlineFlightNumber"].ToString();
            //        NumStops = rowFlightSegment[i]["NumStops"].ToString();
            //        LinkSellAgrmnt = rowFlightSegment[i]["LinkSellAgrmnt"].ToString();
            //        Conx = rowFlightSegment[i]["Conx"].ToString();
            //        AirpChg = rowFlightSegment[i]["AirpChg"].ToString();
            //        InsideAvailOption = rowFlightSegment[i]["InsideAvailOption"].ToString();
            //        GenTrafRestriction = rowFlightSegment[i]["GenTrafRestriction"].ToString();
            //        DaysOperates = rowFlightSegment[i]["DaysOperates"].ToString();
            //        JrnyTm = rowFlightSegment[i]["JrnyTm"].ToString();
            //        EndDt = rowFlightSegment[i]["EndDt"].ToString();
            //        StartTerminal = rowFlightSegment[i]["StartTerminal"].ToString();
            //        EndTerminal = rowFlightSegment[i]["EndTerminal"].ToString();
            //        FltTm = rowFlightSegment[i]["FltTm"].ToString();
            //        LSAInd = rowFlightSegment[i]["LSAInd"].ToString();
            //        Mile = rowFlightSegment[i]["Mile"].ToString();


            //        if (dtpricingreqBookingClass.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClass = dtpricingreqBookingClass.Select("FlightSegment_Id=" + rowFlightSegment[i]["FlightSegment_Id"].ToString());
            //            Availability = rowBookingClass[0]["Availability"].ToString();
            //            BIC = rowBookingClass[0]["BIC"].ToString();
            //        }

            //        if (dtpricingreqBookingClassFare.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClassFare = dtpricingreqBookingClassFare.Select("FlightSegment_Id=" + rowFlightSegment[i]["FlightSegment_Id"].ToString());
            //            bookingclass = rowBookingClassFare[0]["bookingclass"].ToString();
            //            classType = rowBookingClassFare[0]["classType"].ToString();
            //            farebasiscode = rowBookingClassFare[0]["farebasiscode"].ToString();
            //            Rule = rowBookingClassFare[0]["Rule"].ToString();
            //            bookingclassFareId = rowBookingClassFare[0]["bookingclassFare_Id"].ToString();

            //        }

            //        if (dtpricingreqPsgrBreakUp.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrBreakUp = dtpricingreqPsgrBreakUp.Select("bookingclassFare_Id=" + bookingclassFareId);
            //            psgrBreakUp_Id = rowPsgrBreakUp[0]["psgrBreakUp_Id"].ToString();

            //        }


            //        if (dtpricingreqPsgrAry.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrAry = dtpricingreqPsgrAry.Select("psgrBreakUp_Id=" + psgrBreakUp_Id);
            //            psgrAy_id = rowPsgrAry[0]["psgrAry_Id"].ToString();

            //        }

            //        if (dtpricingreqPsgr.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgr = dtpricingreqPsgr.Select("psgrAry_Id=" + psgrAy_id);
            //            FarePsgrType = rowPsgr[0]["psgrType"].ToString();
            //            FareBaseFare = rowPsgr[0]["BaseFare"].ToString();
            //            FareTax1 = rowPsgr[0]["Tax"].ToString();
            //            BagInfo = rowPsgr[0]["BagInfo"].ToString();

            //        }

            //        if (dtpricingreqTaxDataAry.Rows.Count > 0)
            //        {
            //            DataRow[] rowTaxDataAry = dtpricingreqTaxDataAry.Select("Fare_id=" + FareId);
            //            taxDataAry_id = rowTaxDataAry[0]["TaxdataAry_Id"].ToString();
            //        }

            //        if (dtpricingreqTaxData.Rows.Count > 0)
            //        {
            //            DataRow[] rowTaxData = dtpricingreqTaxData.Select("TaxdataAry_Id=" + taxDataAry_id);
            //            for (int j = 0; j < rowTaxData.Length; j++)
            //            {
            //                if (rowTaxData.Length == 0)
            //                {
            //                    taxData = "<TaxData><Country>" + rowTaxData[j]["Country"].ToString() + "</Country><Amt>" + rowTaxData[j]["Amt"].ToString() + "</Amt></TaxData>";
            //                }
            //                else
            //                {
            //                    taxData = taxData + "<TaxData><Country>" + rowTaxData[j]["Country"].ToString() + "</Country><Amt>" + rowTaxData[j]["Amt"].ToString() + "</Amt></TaxData>";
            //                }
            //            }

            //        }

            //        if (dtpricingreqPsgr.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgr = dtpricingreqPsgr.Select("psgrAry_Id=" + psgrAy_id);
            //            foreach (DataRow rows in rowPsgr)
            //            {
            //                if (rows.Table.Rows.Count == 0)
            //                {
            //                    taxdatapsgr = "<Psgr><PsgrType>" + rows["psgrType"].ToString() + "</PsgrType><BaseFare>" + rows["BaseFare"].ToString() + "</BaseFare><Tax>" + rows["Tax"].ToString() + "</Tax><BagInfo>" + rows["BagInfo"].ToString() + "</BagInfo></Psgr>";
            //                }
            //                else
            //                {
            //                    taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + rows["psgrType"].ToString() + "</PsgrType><BaseFare>" + rows["BaseFare"].ToString() + "</BaseFare><Tax>" + rows["Tax"].ToString() + "</Tax><BagInfo>" + rows["BagInfo"].ToString() + "</BagInfo></Psgr>";
            //                }
            //            }
            //        }

            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgr + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";//<Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr>

            //    }
            //}
            #endregion
            DataSet ds = new DataSet();
            FlightBAL objFlightsBal = new FlightBAL();
            string ReferenceNo = Convert.ToString(Session["Order_Id"]);
            DataSet dtid = objFlightsBal.FGetInternationalFlightDetails(ReferenceNo);


            #region oneway

            // return1 = dtid.Tables[0].Rows[0]["Return1"].ToString();
            id1 = dtid.Tables[0].Rows[0]["id"].ToString();
            key = dtid.Tables[0].Rows[0]["Key1"].ToString();
            string[] actualBaseFare = dtid.Tables[0].Rows[0]["ActualBasefare"].ToString().Split('.');
            ActualBaseFare = actualBaseFare[0].ToString();
            string[] tx = dtid.Tables[0].Rows[0]["Tax"].ToString().Split('.');
            Tax = tx[0].ToString();
            string[] stx = dtid.Tables[0].Rows[0]["STax"].ToString().Split('.');
            STax = stx[0].ToString();
            string[] schrge = dtid.Tables[0].Rows[0]["Scharge"].ToString().Split('.');
            SCharge = schrge[0].ToString();
            string[] tdis = dtid.Tables[0].Rows[0]["TDiscount"].ToString().Split('.');
            TDiscount = tdis[0].ToString();
            string[] tpartcomm = dtid.Tables[0].Rows[0]["TPartnerCommission"].ToString().Split('.');
            TPartnerCommission = tpartcomm[0].ToString();
            string[] tsdisc = dtid.Tables[0].Rows[0]["TSDiscount"].ToString().Split('.');
            TSdiscount = tsdisc[0].ToString();
            ocTax = dtid.Tables[0].Rows[0]["Octax"].ToString();
            string[] tmrkup = dtid.Tables[0].Rows[0]["TMarkUp"].ToString().Split('.');
            TMarkup = tmrkup[0].ToString();
            string[] tchge = dtid.Tables[0].Rows[0]["TCharge"].ToString().Split('.');
            TCharge = tchge[0].ToString();
            string ReferenceNo1 = dtid.Tables[0].Rows[0]["Int_Booking_Id"].ToString();
            DataSet dsdbsave = objFlightsBal.GetInternationalFlightDetails1(ReferenceNo1);


            if (dsdbsave.Tables.Count > 0)
            {
                if (dsdbsave.Tables[0].Rows.Count > 0)
                {
                    //foreach (DataRow row in dsdbsave.Tables[0].Rows)
                    //{
                    if (dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Contains(";"))
                    {
                        rows = dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Split(';');
                        int count = rows.Count();
                        for (int i = 0; i < count; i++)
                        {
                            if (rows[i].Contains("|"))
                            {
                                string[] str2 = rows[i].ToString().Split('|');

                                Irows = str2.ToString().Split(',');
                            }
                            else
                            {
                                Irows = rows[i].ToString().Split(',');

                            }
                            // Irows = rows.ToString().Split(',');
                            if (str == "")
                            {
                                str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                                //taxdatapsgr = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            }
                            else
                            {

                                if (Irows[0].ToString() == "")
                                {
                                }
                                else
                                {
                                    str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                                    // taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                    taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                }
                            }
                        }
                    }
                    else
                    {
                        Irows = dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Split(',');

                        // Irows = rows.ToString().Split(',');
                        if (str == "")
                        {
                            str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                            //taxdatapsgr = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                        }
                        else
                        {
                            str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                            // taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            taxdatapsgr = taxdatapsgr + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                        }


                    }
                    //}                    
                    //  string XmlPricingRequest = "<PriceRequest><noadults>" + ddlAdultsInt.SelectedValue + "</noadults><nochild>" + ddlChildsInt.SelectedValue + "</nochild><noinfant>" + ddlInfantsInt.SelectedValue + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>" + PsgrType + "</PsgrType><BaseFare>" + BaseFare + "</BaseFare><Tax>" + FareTax + "</Tax></Fare></FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails>";

                    xmlpricingrequestforInt = "<PriceRequest><noadults>" + dtid.Tables[0].Rows[0]["AdultPax"].ToString() + "</noadults><nochild>" + dtid.Tables[0].Rows[0]["ChildPax"].ToString() + "</nochild><noinfant>" + dtid.Tables[0].Rows[0]["InfantPax"].ToString() + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry>" + str + "</FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<onward><FlightSegments>";

                    //foreach (DataRow row in dsdbsave.Tables[0].Rows)
                    //{
                    AirEquipType = dsdbsave.Tables[0].Rows[0]["AirEquipType"].ToString();
                    ArrivalAirportCode = dsdbsave.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                    ArrivalAirportName = dsdbsave.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
                    ArrivalDateTime = dsdbsave.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    DepartureAirportCode = dsdbsave.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                    DepartureAirportName = dsdbsave.Tables[0].Rows[0]["DepartureAirportName"].ToString();
                    DepartureDateTime = dsdbsave.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    FlightNumber = dsdbsave.Tables[0].Rows[0]["FlightNumber"].ToString();
                    MarketingAirlineCode = dsdbsave.Tables[0].Rows[0]["MarketingAirlineCode"].ToString();
                    OperatingAirlineCode = dsdbsave.Tables[0].Rows[0]["OperatingAirlineCode"].ToString();
                    OperatingAirlineName = dsdbsave.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
                    OperatingAirlineFlightNumber = dsdbsave.Tables[0].Rows[0]["OperatingAirlineFlightNumber"].ToString();
                    NumStops = dsdbsave.Tables[0].Rows[0]["NumStops"].ToString();
                    LinkSellAgrmnt = dsdbsave.Tables[0].Rows[0]["LinkSellAgrmnt"].ToString();
                    Conx = dsdbsave.Tables[0].Rows[0]["Conx"].ToString();
                    AirpChg = dsdbsave.Tables[0].Rows[0]["AirpChg"].ToString();
                    InsideAvailOption = dsdbsave.Tables[0].Rows[0]["InsideAvailOption"].ToString();
                    GenTrafRestriction = dsdbsave.Tables[0].Rows[0]["GenTrafRestriction"].ToString();
                    DaysOperates = dsdbsave.Tables[0].Rows[0]["DaysOperates"].ToString();
                    JrnyTm = dsdbsave.Tables[0].Rows[0]["JrnyTm"].ToString();
                    EndDt = dsdbsave.Tables[0].Rows[0]["EndDt"].ToString();
                    StartTerminal = dsdbsave.Tables[0].Rows[0]["StartTerminal"].ToString();
                    EndTerminal = dsdbsave.Tables[0].Rows[0]["EndTerminal"].ToString();
                    FltTm = dsdbsave.Tables[0].Rows[0]["FltTm"].ToString();
                    LSAInd = dsdbsave.Tables[0].Rows[0]["LSAInd"].ToString();
                    Mile = dsdbsave.Tables[0].Rows[0]["Mile"].ToString();


                    Availability = dsdbsave.Tables[0].Rows[0]["Availability"].ToString();
                    BIC = dsdbsave.Tables[0].Rows[0]["BIC"].ToString();
                    bookingclass = dsdbsave.Tables[0].Rows[0]["bookingclass"].ToString();
                    classType = dsdbsave.Tables[0].Rows[0]["classType"].ToString();
                    farebasiscode = dsdbsave.Tables[0].Rows[0]["farebasiscode"].ToString();
                    Rule = dsdbsave.Tables[0].Rows[0]["Fare_Rule"].ToString();

                    FarePsgrType = dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString();
                    FareBaseFare = dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString();
                    FareTax1 = dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString();
                    BagInfo = dsdbsave.Tables[0].Rows[0]["BagInfo"].ToString();



                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
                    // xmlpricingrequestforInt = xmlpricingrequestforInt + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>" + FarePsgrType + "</PsgrType><BaseFare>" + FareBaseFare + "</BaseFare><Tax>" + FareTax1 + "</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgr + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";

                    // }

                }
            }

            #endregion



            xmlpricingrequestforInt = xmlpricingrequestforInt + "</FlightSegments></onward><Return><FlightSegments>";
            #region old return

            //DataTable dtpricingreqReturn = dsIntFlights.Tables["Return"];
            //if (dtpricingreqReturn.Rows.Count > 0)
            //{
            //    DataRow[] rowReturn = dtpricingreqReturn.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
            //    returnId = rowReturn[0]["return_id"].ToString();
            //}
            //DataTable dtpricingreqFlightSegmentsRet = dsIntFlights.Tables["FlightSegments"];
            //if (dtpricingreqFlightSegmentsRet.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegmentsRet = dtpricingreqFlightSegmentsRet.Select("return_id=" + returnId);
            //    FlightSegmentsIDRet = rowFlightSegmentsRet[0]["FlightSegments_Id"].ToString();
            //}
            //DataTable dtpricingreqFlightSegmentRet = dsIntFlights.Tables["FlightSegment"];
            //DataTable dtpricingreqBookingClassRet = dsIntFlights.Tables["BookingClass"];
            //DataTable dtpricingreqBookingClassFareRet = dsIntFlights.Tables["BookingClassFare"];
            //DataTable dtpricingreqPsgrBreakUpRet = dsIntFlights.Tables["PsgrBreakUp"];
            //DataTable dtpricingreqPsgrAryRet = dsIntFlights.Tables["PsgrAry"];
            //DataTable dtpricingreqPsgrRet = dsIntFlights.Tables["Psgr"];
            //DataTable dtpricingreqTaxDataAryRet = dsIntFlights.Tables["TaxDataAry"];
            //DataTable dtpricingreqTaxDataRet = dsIntFlights.Tables["TaxData"];


            //if (dtpricingreqFlightSegmentRet.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegmentRet = dtpricingreqFlightSegmentRet.Select("FlightSegments_Id=" + FlightSegmentsIDRet);
            //    for (int i = 0; i < rowFlightSegmentRet.Length; i++)
            //    {

            //        AirEquipTypeRet = rowFlightSegmentRet[i]["AirEquipType"].ToString();
            //        ArrivalAirportCodeRet = rowFlightSegmentRet[i]["ArrivalAirportCode"].ToString();
            //        ArrivalAirportNameRet = rowFlightSegmentRet[i]["ArrivalAirportName"].ToString();
            //        ArrivalDateTimeRet = rowFlightSegmentRet[i]["ArrivalDateTime"].ToString();
            //        DepartureAirportCodeRet = rowFlightSegmentRet[i]["DepartureAirportCode"].ToString();
            //        DepartureAirportNameRet = rowFlightSegmentRet[i]["DepartureAirportName"].ToString();
            //        DepartureDateTimeRet = rowFlightSegmentRet[i]["DepartureDateTime"].ToString();
            //        FlightNumberRet = rowFlightSegmentRet[i]["FlightNumber"].ToString();
            //        MarketingAirlineCodeRet = rowFlightSegmentRet[i]["MarketingAirlineCode"].ToString();
            //        OperatingAirlineCodeRet = rowFlightSegmentRet[i]["OperatingAirlineCode"].ToString();
            //        OperatingAirlineNameRet = rowFlightSegmentRet[i]["OperatingAirlineName"].ToString();
            //        OperatingAirlineFlightNumberRet = rowFlightSegmentRet[i]["OperatingAirlineFlightNumber"].ToString();
            //        NumStopsRet = rowFlightSegmentRet[i]["NumStops"].ToString();
            //        LinkSellAgrmntRet = rowFlightSegmentRet[i]["LinkSellAgrmnt"].ToString();
            //        ConxRet = rowFlightSegmentRet[i]["Conx"].ToString();
            //        AirpChgRet = rowFlightSegmentRet[i]["AirpChg"].ToString();
            //        InsideAvailOptionRet = rowFlightSegmentRet[i]["InsideAvailOption"].ToString();
            //        GenTrafRestrictionRet = rowFlightSegmentRet[i]["GenTrafRestriction"].ToString();
            //        DaysOperatesRet = rowFlightSegmentRet[i]["DaysOperates"].ToString();
            //        JrnyTmRet = rowFlightSegmentRet[i]["JrnyTm"].ToString();
            //        EndDtRet = rowFlightSegmentRet[i]["EndDt"].ToString();
            //        StartTerminalRet = rowFlightSegmentRet[i]["StartTerminal"].ToString();
            //        EndTerminalRet = rowFlightSegmentRet[i]["EndTerminal"].ToString();
            //        FltTmRet = rowFlightSegmentRet[i]["FltTm"].ToString();
            //        LSAIndRet = rowFlightSegmentRet[i]["LSAInd"].ToString();
            //        MileRet = rowFlightSegmentRet[i]["Mile"].ToString();


            //        if (dtpricingreqBookingClassRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClassRet = dtpricingreqBookingClassRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
            //            AvailabilityRet = rowBookingClassRet[0]["Availability"].ToString();
            //            BICRet = rowBookingClassRet[0]["BIC"].ToString();
            //        }

            //        if (dtpricingreqBookingClassFareRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClassFareRet = dtpricingreqBookingClassFareRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
            //            bookingclassRet = rowBookingClassFareRet[0]["bookingclass"].ToString();
            //            classTypeRet = rowBookingClassFareRet[0]["classType"].ToString();
            //            farebasiscodeRet = rowBookingClassFareRet[0]["farebasiscode"].ToString();
            //            RuleRet = rowBookingClassFareRet[0]["Rule"].ToString();
            //            bookingclassFareIdRet = rowBookingClassFareRet[0]["bookingclassFare_Id"].ToString();

            //        }

            //        if (dtpricingreqPsgrBreakUpRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrBreakUpRet = dtpricingreqPsgrBreakUpRet.Select("bookingclassFare_Id=" + bookingclassFareIdRet);
            //            psgrBreakUp_IdRet = rowPsgrBreakUpRet[0]["psgrBreakUp_Id"].ToString();

            //        }


            //        if (dtpricingreqPsgrAryRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrAryRet = dtpricingreqPsgrAryRet.Select("psgrBreakUp_Id=" + psgrBreakUp_IdRet);
            //            psgrAy_idRet = rowPsgrAryRet[0]["psgrAry_Id"].ToString();

            //        }

            //        if (dtpricingreqPsgrRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrRet = dtpricingreqPsgrRet.Select("psgrAry_Id=" + psgrAy_idRet);
            //            FarePsgrTypeRet = rowPsgrRet[0]["psgrType"].ToString();
            //            FareBaseFareRet = rowPsgrRet[0]["BaseFare"].ToString();
            //            FareTax1Ret = rowPsgrRet[0]["Tax"].ToString();
            //            BagInfoRet = rowPsgrRet[0]["BagInfo"].ToString();

            //        }

            //        if (dtpricingreqPsgrRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgr = dtpricingreqPsgrRet.Select("psgrAry_Id=" + psgrAy_idRet);
            //            foreach (DataRow rows in rowPsgr)
            //            {
            //                if (rows.Table.Rows.Count == 0)
            //                {
            //                    taxdatapsgrRet = "<Psgr><PsgrType>" + rows["psgrType"].ToString() + "</PsgrType><BaseFare>" + rows["BaseFare"].ToString() + "</BaseFare><Tax>" + rows["Tax"].ToString() + "</Tax><BagInfo>" + rows["BagInfo"].ToString() + "</BagInfo></Psgr>";
            //                }
            //                else
            //                {
            //                    taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + rows["psgrType"].ToString() + "</PsgrType><BaseFare>" + rows["BaseFare"].ToString() + "</BaseFare><Tax>" + rows["Tax"].ToString() + "</Tax><BagInfo>" + rows["BagInfo"].ToString() + "</BagInfo></Psgr>";
            //                }
            //            }
            //        }


            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportNameRet + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportNameRet + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber>";
            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<MarketingAirlineCode>" + MarketingAirlineCodeRet + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineNameRet + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><NumStops>" + NumStopsRet + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmntRet + "</LinkSellAgrmnt><Conx>" + ConxRet + "</Conx><AirpChg>" + AirpChgRet + "</AirpChg><InsideAvailOption>" + InsideAvailOptionRet + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestrictionRet + "</GenTrafRestriction><DaysOperates>" + DaysOperatesRet + "</DaysOperates><JrnyTm>" + JrnyTmRet + "</JrnyTm><EndDt>" + EndDtRet + "</EndDt><StartTerminal>" + StartTerminalRet + "</StartTerminal><EndTerminal>" + EndTerminalRet + "</EndTerminal>";
            //        xmlpricingrequestforInt = xmlpricingrequestforInt + "<FltTm>" + FltTmRet + "</FltTm><LSAInd>" + LSAIndRet + "</LSAInd><Mile>" + MileRet + "</Mile><BookingClass><Availability>" + AvailabilityRet + "</Availability><BIC>" + BICRet + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclassRet + "</bookingclass><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><Rule>" + RuleRet.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgrRet + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";//<Psgr><PsgrType>" + FarePsgrTypeRet + "</PsgrType><BaseFare>" + FareBaseFareRet + "</BaseFare><Tax>" + FareTax1Ret + "</Tax><BagInfo></BagInfo></Psgr>

            //    }
            //}
            #endregion


            #region return
            //idRet = dtid.Tables[0].Rows[1]["id"].ToString();
            //keyRet = dtid.Tables[0].Rows[1]["Key1"].ToString();
            //ActualBaseFareRet = dtid.Tables[0].Rows[1]["ActualBasefare"].ToString();
            //TaxRet = dtid.Tables[0].Rows[1]["Tax"].ToString();
            //STaxRet = dtid.Tables[0].Rows[1]["STax"].ToString();
            //SChargeRet = dtid.Tables[0].Rows[1]["Scharge"].ToString();
            //TDiscountRet = dtid.Tables[0].Rows[1]["TDiscount"].ToString();
            //TPartnerCommissionRet = dtid.Tables[0].Rows[1]["TPartnerCommission"].ToString();
            //TSdiscountRet = dtid.Tables[0].Rows[1]["TSDiscount"].ToString();
            //ocTaxRet = dtid.Tables[0].Rows[1]["Octax"].ToString();
            //TMarkupRet = dtid.Tables[0].Rows[1]["TMarkUp"].ToString();
            //TChargeRet = dtid.Tables[0].Rows[1]["TCharge"].ToString();

            //string ReferenceNo2 = dtid.Tables[0].Rows[1]["Int_Booking_Id"].ToString();
            //DataSet dsdbsaveRet = objFlightsBal.GetInternationalFlightDetails1(ReferenceNo2);


            if (dsdbsave.Tables.Count > 0)
            {
                if (dsdbsave.Tables[0].Rows.Count > 0)
                {
                    //foreach (DataRow row in dsdbsave.Tables[0].Rows)
                    //{
                    str = "";
                    if (dsdbsave.Tables[0].Rows[1]["FarePsgrType"].ToString().Contains(";"))
                    {
                        rows = dsdbsave.Tables[0].Rows[1]["FarePsgrType"].ToString().Split(';');
                        int count = rows.Count();
                        for (int i = 0; i < count; i++)
                        {
                            if (rows.Contains("|"))
                            {
                                string[] str2 = rows[i].ToString().Split('|');

                                Irows = str2.ToString().Split(',');
                            }
                            else
                            {
                                Irows = rows[i].ToString().Split(',');
                            }
                            // Irows = rows.ToString().Split(',');

                            if (str == "")
                            {
                                str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                                // taxdatapsgrRet = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[1]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[1]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[1]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            }
                            else
                            {
                                if (Irows[0].ToString() == "")
                                {
                                }
                                else
                                {

                                    str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                                    //  taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[1]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[1]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[1]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                    taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                                }
                            }
                        }
                    }
                    else
                    {
                        Irows = dsdbsave.Tables[0].Rows[0]["FarePsgrType"].ToString().Split(',');

                        // Irows = rows.ToString().Split(',');
                        if (str == "")
                        {
                            str = "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";
                            // taxdatapsgrRet = "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[1]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[1]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[1]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                        }
                        else
                        {
                            str = str + "<Fare><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax></Fare>";//<TaxDataAry>" + str + "</TaxDataAry>
                            // taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + dsdbsave.Tables[0].Rows[1]["PsgrType"].ToString() + "</PsgrType><BaseFare>" + dsdbsave.Tables[0].Rows[1]["BaseFare"].ToString() + "</BaseFare><Tax>" + dsdbsave.Tables[0].Rows[1]["psgrTax"].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                            taxdatapsgrRet = taxdatapsgrRet + "<Psgr><PsgrType>" + Irows[0].ToString() + "</PsgrType><BaseFare>" + Irows[1].ToString() + "</BaseFare><Tax>" + Irows[2].ToString() + "</Tax><BagInfo></BagInfo></Psgr>";
                        }


                    }

                    // foreach (DataRow row in dsdbsave.Tables[0].Rows)
                    //{
                    AirEquipTypeRet = dsdbsave.Tables[0].Rows[1]["AirEquipType"].ToString();
                    ArrivalAirportCodeRet = dsdbsave.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();
                    ArrivalAirportNameRet = dsdbsave.Tables[0].Rows[1]["ArrivalAirportName"].ToString();
                    ArrivalDateTimeRet = dsdbsave.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    DepartureAirportCodeRet = dsdbsave.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
                    DepartureAirportNameRet = dsdbsave.Tables[0].Rows[1]["DepartureAirportName"].ToString();
                    DepartureDateTimeRet = dsdbsave.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                    FlightNumberRet = dsdbsave.Tables[0].Rows[1]["FlightNumber"].ToString();
                    MarketingAirlineCodeRet = dsdbsave.Tables[0].Rows[1]["MarketingAirlineCode"].ToString();
                    OperatingAirlineCodeRet = dsdbsave.Tables[0].Rows[1]["OperatingAirlineCode"].ToString();
                    OperatingAirlineNameRet = dsdbsave.Tables[0].Rows[1]["OperatingAirlineName"].ToString();
                    OperatingAirlineFlightNumberRet = dsdbsave.Tables[0].Rows[1]["OperatingAirlineFlightNumber"].ToString();
                    NumStopsRet = dsdbsave.Tables[0].Rows[1]["NumStops"].ToString();
                    LinkSellAgrmntRet = dsdbsave.Tables[0].Rows[1]["LinkSellAgrmnt"].ToString();
                    ConxRet = dsdbsave.Tables[0].Rows[1]["Conx"].ToString();
                    AirpChgRet = dsdbsave.Tables[0].Rows[1]["AirpChg"].ToString();
                    InsideAvailOptionRet = dsdbsave.Tables[0].Rows[1]["InsideAvailOption"].ToString();
                    GenTrafRestrictionRet = dsdbsave.Tables[0].Rows[1]["GenTrafRestriction"].ToString();
                    DaysOperatesRet = dsdbsave.Tables[0].Rows[1]["DaysOperates"].ToString();
                    JrnyTmRet = dsdbsave.Tables[0].Rows[1]["JrnyTm"].ToString();
                    EndDtRet = dsdbsave.Tables[0].Rows[1]["EndDt"].ToString();
                    StartTerminalRet = dsdbsave.Tables[0].Rows[1]["StartTerminal"].ToString();
                    EndTerminalRet = dsdbsave.Tables[0].Rows[1]["EndTerminal"].ToString();
                    FltTmRet = dsdbsave.Tables[0].Rows[1]["FltTm"].ToString();
                    LSAIndRet = dsdbsave.Tables[0].Rows[1]["LSAInd"].ToString();
                    MileRet = dsdbsave.Tables[0].Rows[1]["Mile"].ToString();


                    AvailabilityRet = dsdbsave.Tables[0].Rows[1]["Availability"].ToString();
                    BICRet = dsdbsave.Tables[0].Rows[1]["BIC"].ToString();
                    bookingclassRet = dsdbsave.Tables[0].Rows[1]["bookingclass"].ToString();
                    classTypeRet = dsdbsave.Tables[0].Rows[1]["classType"].ToString();
                    farebasiscodeRet = dsdbsave.Tables[0].Rows[1]["farebasiscode"].ToString();
                    RuleRet = dsdbsave.Tables[0].Rows[1]["Fare_Rule"].ToString();

                    FarePsgrTypeRet = dsdbsave.Tables[0].Rows[1]["PsgrType"].ToString();
                    FareBaseFareRet = dsdbsave.Tables[0].Rows[1]["BaseFare"].ToString();
                    FareTax1Ret = dsdbsave.Tables[0].Rows[1]["psgrTax"].ToString();
                    BagInfoRet = dsdbsave.Tables[0].Rows[1]["BagInfo"].ToString();



                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportNameRet + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportNameRet + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<MarketingAirlineCode>" + MarketingAirlineCodeRet + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineNameRet + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><NumStops>" + NumStopsRet + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmntRet + "</LinkSellAgrmnt><Conx>" + ConxRet + "</Conx><AirpChg>" + AirpChgRet + "</AirpChg><InsideAvailOption>" + InsideAvailOptionRet + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestrictionRet + "</GenTrafRestriction><DaysOperates>" + DaysOperatesRet + "</DaysOperates><JrnyTm>" + JrnyTmRet + "</JrnyTm><EndDt>" + EndDtRet + "</EndDt><StartTerminal>" + StartTerminalRet + "</StartTerminal><EndTerminal>" + EndTerminalRet + "</EndTerminal>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "<FltTm>" + FltTmRet + "</FltTm><LSAInd>" + LSAIndRet + "</LSAInd><Mile>" + MileRet + "</Mile><BookingClass><Availability>" + AvailabilityRet + "</Availability><BIC>" + BICRet + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclassRet + "</bookingclass><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><Rule>" + RuleRet.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgrRet + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";//<Psgr><PsgrType>" + FarePsgrTypeRet + "</PsgrType><BaseFare>" + FareBaseFareRet + "</BaseFare><Tax>" + FareTax1Ret + "</Tax><BagInfo></BagInfo></Psgr>



            #endregion


                    xmlpricingrequestforInt = xmlpricingrequestforInt + "</FlightSegments></Return><id>" + id1 + "</id><key>" + key + "</key>";
                    xmlpricingrequestforInt = xmlpricingrequestforInt + "</OriginDestinationOption></PriceRequest>";


                    DataSet dsPricingResponse = objFlightsBal.GetDatasetFromAPI(xmlpricingrequestforInt, "http://59.162.33.102:9301/Pricing");
                    if (dsPricingResponse != null)
                    {
                        if (dsPricingResponse.Tables.Count > 0)
                        {
                            if (!dsPricingResponse.Tables[0].Columns.Contains("error"))
                            {
                                DataTable dtpricingresFareDetails = dsPricingResponse.Tables["FareDetails"];
                                if (dtpricingresFareDetails.Rows.Count > 0)
                                {
                                    DataRow[] rowFareDetails = dtpricingresFareDetails.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
                                    ActualBaseFare = rowFareDetails[0]["ActualBaseFare"].ToString();
                                    Tax = rowFareDetails[0]["Tax"].ToString();
                                    STax = rowFareDetails[0]["STax"].ToString();
                                    TCharge = rowFareDetails[0]["TCharge"].ToString();
                                    SCharge = rowFareDetails[0]["SCharge"].ToString();
                                    TDiscount = rowFareDetails[0]["TDiscount"].ToString();
                                    TMarkup = rowFareDetails[0]["TMarkup"].ToString();
                                    TPartnerCommission = rowFareDetails[0]["TPartnerCommission"].ToString();
                                    TSdiscount = rowFareDetails[0]["TSdiscount"].ToString();
                                    ocTax = rowFareDetails[0]["ocTax"].ToString();
                                    FareDetails_id = rowFareDetails[0]["FareDetails_id"].ToString();
                                }
                            }
                        }
                    }

                }

            }
            #endregion
            string xmlRequest;
            
            #region new bookrequest onward

            string ref1 = Session["Order_Id"].ToString();

            xmlRequest = "<Bookingrequest><noadults>" + dtid.Tables[0].Rows[0]["AdultPax"].ToString() + "</noadults><nochild>" + dtid.Tables[0].Rows[0]["ChildPax"].ToString() + "</nochild><noinfant>" + dtid.Tables[0].Rows[0]["InfantPax"].ToString() + "</noinfant><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><creditcardno></creditcardno><PartnerreferenceID>" + ref1 + "</PartnerreferenceID>";
            xmlRequest = xmlRequest + "<personName>";

            ///details changing
            //   string strname = Convert.ToString(Session["customerInfo"]);
            string strname = dsdbsave.Tables[0].Rows[0]["CustomerDetails"].ToString();
            string[] strrows = strname.ToString().Split(';');
            int id2 = strrows.Count();
            for (int m = 0; m < id2; m++)
            {
                if (strrows[m].Contains("adt"))
                {
                    string[] stradt = strrows[m].ToString().Split('|');
                    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + stradt[1].ToString() + "</givenName><surName>" + stradt[2].ToString() + "</surName><nameReference>" + stradt[0].ToString() + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }
                if (strrows[m].Contains("chd"))
                {
                    string[] strchd = strrows[m].ToString().Split('|');
                    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + strchd[1].ToString() + "</givenName><surName>" + strchd[2].ToString() + "</surName><nameReference>" + strchd[0].ToString() + "</nameReference><dob>" + strchd[5].ToString() + "</dob><age>" + strchd[4].ToString() + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }
                if (strrows[m].Contains("inf"))
                {
                    string[] strinf = strrows[m].ToString().Split('|');
                    xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + strinf[1].ToString() + "</givenName><surName>" + strinf[2].ToString() + "</surName><nameReference>" + strinf[0].ToString() + "</nameReference><dob>" + strinf[5].ToString() + "</dob><age>" + strinf[4].ToString() + "</age><psgrtype>inf</psgrtype></CustomerInfo>";

                }
            }
            xmlRequest = xmlRequest + "</personName><telePhone><phoneNumber>" + dsdbsave.Tables[0].Rows[0]["Telephone"].ToString() + "</phoneNumber></telePhone><email><emailAddress>" + dsdbsave.Tables[0].Rows[0]["EmailAddress"].ToString() + "</emailAddress></email>";
            //xmlRequest = xmlRequest + "<OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>" + PsgrType + "</PsgrType><BaseFare>" + BaseFare + "</BaseFare><Tax>" + FareTax + "</Tax><TaxDataAry>";
            //xmlRequest = xmlRequest + taxData + "</TaxDataAry></Fare></FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails><onward><FlightSegments>";
            xmlRequest = xmlRequest + "<OriginDestinationOption><FareDetails><ActualBaseFare>" + ActualBaseFare + "</ActualBaseFare><Tax>" + Tax + "</Tax><STax>" + STax + "</STax><TCharge>" + TCharge + "</TCharge><SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TMarkup>" + TMarkup + "</TMarkup><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission><TSdiscount>" + TSdiscount + "</TSdiscount><FareBreakup><FareAry>";
            xmlRequest = xmlRequest + str + "</FareAry></FareBreakup><ocTax>" + ocTax + "</ocTax></FareDetails><onward><FlightSegments>";


            //foreach (DataRow row in dsdbsave.Tables[0].Rows)
            //{
            AirEquipType = dsdbsave.Tables[0].Rows[0]["AirEquipType"].ToString();
            ArrivalAirportCode = dsdbsave.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
            ArrivalAirportName = dsdbsave.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
            ArrivalDateTime = dsdbsave.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
            DepartureAirportCode = dsdbsave.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
            DepartureAirportName = dsdbsave.Tables[0].Rows[0]["DepartureAirportName"].ToString();
            DepartureDateTime = dsdbsave.Tables[0].Rows[0]["DepartureDateTime"].ToString();
            FlightNumber = dsdbsave.Tables[0].Rows[0]["FlightNumber"].ToString();
            MarketingAirlineCode = dsdbsave.Tables[0].Rows[0]["MarketingAirlineCode"].ToString();
            OperatingAirlineCode = dsdbsave.Tables[0].Rows[0]["OperatingAirlineCode"].ToString();
            OperatingAirlineName = dsdbsave.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
            OperatingAirlineFlightNumber = dsdbsave.Tables[0].Rows[0]["OperatingAirlineFlightNumber"].ToString();
            NumStops = dsdbsave.Tables[0].Rows[0]["NumStops"].ToString();
            LinkSellAgrmnt = dsdbsave.Tables[0].Rows[0]["LinkSellAgrmnt"].ToString();
            Conx = dsdbsave.Tables[0].Rows[0]["Conx"].ToString();
            AirpChg = dsdbsave.Tables[0].Rows[0]["AirpChg"].ToString();
            InsideAvailOption = dsdbsave.Tables[0].Rows[0]["InsideAvailOption"].ToString();
            GenTrafRestriction = dsdbsave.Tables[0].Rows[0]["GenTrafRestriction"].ToString();
            DaysOperates = dsdbsave.Tables[0].Rows[0]["DaysOperates"].ToString();
            JrnyTm = dsdbsave.Tables[0].Rows[0]["JrnyTm"].ToString();
            EndDt = dsdbsave.Tables[0].Rows[0]["EndDt"].ToString();
            StartTerminal = dsdbsave.Tables[0].Rows[0]["StartTerminal"].ToString();
            EndTerminal = dsdbsave.Tables[0].Rows[0]["EndTerminal"].ToString();
            FltTm = dsdbsave.Tables[0].Rows[0]["FltTm"].ToString();
            LSAInd = dsdbsave.Tables[0].Rows[0]["LSAInd"].ToString();
            Mile = dsdbsave.Tables[0].Rows[0]["Mile"].ToString();

            Availability = dsdbsave.Tables[0].Rows[0]["Availability"].ToString();
            BIC = dsdbsave.Tables[0].Rows[0]["BIC"].ToString();
            bookingclass = dsdbsave.Tables[0].Rows[0]["bookingclass"].ToString();
            classType = dsdbsave.Tables[0].Rows[0]["classType"].ToString();
            farebasiscode = dsdbsave.Tables[0].Rows[0]["farebasiscode"].ToString();
            Rule = dsdbsave.Tables[0].Rows[0]["Fare_Rule"].ToString();

            FarePsgrType = dsdbsave.Tables[0].Rows[0]["PsgrType"].ToString();
            FareBaseFare = dsdbsave.Tables[0].Rows[0]["BaseFare"].ToString();
            FareTax1 = dsdbsave.Tables[0].Rows[0]["psgrTax"].ToString();
            BagInfo = dsdbsave.Tables[0].Rows[0]["BagInfo"].ToString();

            xmlRequest = xmlRequest + "<FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportName + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportName + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber>";
            xmlRequest = xmlRequest + "<MarketingAirlineCode>" + MarketingAirlineCode + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineName + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><NumStops>" + NumStops + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmnt + "</LinkSellAgrmnt><Conx>" + Conx + "</Conx><AirpChg>" + AirpChg + "</AirpChg><InsideAvailOption>" + InsideAvailOption + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestriction + "</GenTrafRestriction><DaysOperates>" + DaysOperates + "</DaysOperates><JrnyTm>" + JrnyTm + "</JrnyTm><EndDt>" + EndDt + "</EndDt><StartTerminal>" + StartTerminal + "</StartTerminal><EndTerminal>" + EndTerminal + "</EndTerminal>";
            xmlRequest = xmlRequest + "<FltTm>" + FltTm + "</FltTm><LSAInd>" + LSAInd + "</LSAInd><Mile>" + Mile + "</Mile><BookingClass><Availability>" + Availability + "</Availability><BIC>" + BIC + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclass + "</bookingclass><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><Rule>" + Rule.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgrRet + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";

            // }

            #endregion


            xmlRequest = xmlRequest + "</FlightSegments></onward><Return><FlightSegments>";
            #region old return

            //DataTable dtReturn = dsIntFlights.Tables["Return"];
            //if (dtReturn.Rows.Count > 0)
            //{
            //    DataRow[] rowReturn = dtReturn.Select("OriginDestinationOption_Id=" + lblOriginDestinationRoundTrip.Text);
            //    returnId = rowReturn[0]["return_id"].ToString();
            //}
            //DataTable dtFlightSegmentsRet = dsIntFlights.Tables["FlightSegments"];
            //if (dtFlightSegmentsRet.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegmentsRet = dtFlightSegmentsRet.Select("return_id=" + returnId);
            //    FlightSegmentsIDRet = rowFlightSegmentsRet[0]["FlightSegments_Id"].ToString();
            //}
            //DataTable dtFlightSegmentRet = dsIntFlights.Tables["FlightSegment"];
            //DataTable dtBookingClassRet = dsIntFlights.Tables["BookingClass"];
            //DataTable dtBookingClassFareRet = dsIntFlights.Tables["BookingClassFare"];
            //DataTable dtPsgrBreakUpRet = dsIntFlights.Tables["PsgrBreakUp"];
            //DataTable dtPsgrAryRet = dsIntFlights.Tables["PsgrAry"];
            //DataTable dtPsgrRet = dsIntFlights.Tables["Psgr"];
            //DataTable dtTaxDataAryRet = dsIntFlights.Tables["TaxDataAry"];
            //DataTable dtTaxDataRet = dsIntFlights.Tables["TaxData"];


            //if (dtFlightSegmentRet.Rows.Count > 0)
            //{
            //    DataRow[] rowFlightSegmentRet = dtFlightSegmentRet.Select("FlightSegments_Id=" + FlightSegmentsIDRet);
            //    for (int i = 0; i < rowFlightSegmentRet.Length; i++)
            //    {

            //        AirEquipTypeRet = rowFlightSegmentRet[i]["AirEquipType"].ToString();
            //        ArrivalAirportCodeRet = rowFlightSegmentRet[i]["ArrivalAirportCode"].ToString();
            //        ArrivalAirportNameRet = rowFlightSegmentRet[i]["ArrivalAirportName"].ToString();
            //        ArrivalDateTimeRet = rowFlightSegmentRet[i]["ArrivalDateTime"].ToString();
            //        DepartureAirportCodeRet = rowFlightSegmentRet[i]["DepartureAirportCode"].ToString();
            //        DepartureAirportNameRet = rowFlightSegmentRet[i]["DepartureAirportName"].ToString();
            //        DepartureDateTimeRet = rowFlightSegmentRet[i]["DepartureDateTime"].ToString();
            //        FlightNumberRet = rowFlightSegmentRet[i]["FlightNumber"].ToString();
            //        MarketingAirlineCodeRet = rowFlightSegmentRet[i]["MarketingAirlineCode"].ToString();
            //        OperatingAirlineCodeRet = rowFlightSegmentRet[i]["OperatingAirlineCode"].ToString();
            //        OperatingAirlineNameRet = rowFlightSegmentRet[i]["OperatingAirlineName"].ToString();
            //        OperatingAirlineFlightNumberRet = rowFlightSegmentRet[i]["OperatingAirlineFlightNumber"].ToString();
            //        NumStopsRet = rowFlightSegmentRet[i]["NumStops"].ToString();
            //        LinkSellAgrmntRet = rowFlightSegmentRet[i]["LinkSellAgrmnt"].ToString();
            //        ConxRet = rowFlightSegmentRet[i]["Conx"].ToString();
            //        AirpChgRet = rowFlightSegmentRet[i]["AirpChg"].ToString();
            //        InsideAvailOptionRet = rowFlightSegmentRet[i]["InsideAvailOption"].ToString();
            //        GenTrafRestrictionRet = rowFlightSegmentRet[i]["GenTrafRestriction"].ToString();
            //        DaysOperatesRet = rowFlightSegmentRet[i]["DaysOperates"].ToString();
            //        JrnyTmRet = rowFlightSegmentRet[i]["JrnyTm"].ToString();
            //        EndDtRet = rowFlightSegmentRet[i]["EndDt"].ToString();
            //        StartTerminalRet = rowFlightSegmentRet[i]["StartTerminal"].ToString();
            //        EndTerminalRet = rowFlightSegmentRet[i]["EndTerminal"].ToString();
            //        FltTmRet = rowFlightSegmentRet[i]["FltTm"].ToString();
            //        LSAIndRet = rowFlightSegmentRet[i]["LSAInd"].ToString();
            //        MileRet = rowFlightSegmentRet[i]["Mile"].ToString();


            //        if (dtBookingClassRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClassRet = dtBookingClassRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
            //            AvailabilityRet = rowBookingClassRet[0]["Availability"].ToString();
            //            BICRet = rowBookingClassRet[0]["BIC"].ToString();
            //        }

            //        if (dtBookingClassFareRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowBookingClassFareRet = dtBookingClassFareRet.Select("FlightSegment_Id=" + rowFlightSegmentRet[i]["FlightSegment_Id"].ToString());
            //            bookingclassRet = rowBookingClassFareRet[0]["bookingclass"].ToString();
            //            classTypeRet = rowBookingClassFareRet[0]["classType"].ToString();
            //            farebasiscodeRet = rowBookingClassFareRet[0]["farebasiscode"].ToString();
            //            RuleRet = rowBookingClassFareRet[0]["Rule"].ToString();
            //            bookingclassFareIdRet = rowBookingClassFareRet[0]["bookingclassFare_Id"].ToString();

            //        }

            //        if (dtPsgrBreakUpRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrBreakUpRet = dtPsgrBreakUpRet.Select("bookingclassFare_Id=" + bookingclassFareIdRet);
            //            psgrBreakUp_IdRet = rowPsgrBreakUpRet[0]["psgrBreakUp_Id"].ToString();

            //        }


            //        if (dtPsgrAryRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrAryRet = dtPsgrAryRet.Select("psgrBreakUp_Id=" + psgrBreakUp_IdRet);
            //            psgrAy_idRet = rowPsgrAryRet[0]["psgrAry_Id"].ToString();

            //        }

            //        if (dtPsgrRet.Rows.Count > 0)
            //        {
            //            DataRow[] rowPsgrRet = dtPsgrRet.Select("psgrAry_Id=" + psgrAy_idRet);
            //            FarePsgrTypeRet = rowPsgrRet[0]["psgrType"].ToString();
            //            FareBaseFareRet = rowPsgrRet[0]["BaseFare"].ToString();
            //            FareTax1Ret = rowPsgrRet[0]["Tax"].ToString();
            //            BagInfoRet = rowPsgrRet[0]["BagInfo"].ToString();

            //        }

            //        //if (dtTaxDataAryRet.Rows.Count > 0)
            //        //{
            //        //    DataRow[] rowTaxDataAryRet = dtTaxDataAryRet.Select("Fare_id=" + FareIdRet);
            //        //    taxDataAry_id = rowTaxDataAryRet[0]["TaxdataAry_Id"].ToString();
            //        //}

            //        //if (dtTaxDataRet.Rows.Count > 0)
            //        //{
            //        //    DataRow[] rowTaxDataRet = dtTaxDataRet.Select("TaxdataAry_Id=" + taxDataAry_idRet);
            //        //    for (int j = 0; j < rowTaxDataRet.Length; j++)
            //        //    {
            //        //        if (rowTaxDataRet.Length == 0)
            //        //        {
            //        //            taxDataRet = "<TaxData><Country>" + rowTaxDataRet[j]["Country"].ToString() + "</Country><Amt>" + rowTaxDataRet[j]["Amt"].ToString() + "</Amt></TaxData>";
            //        //        }
            //        //        else
            //        //        {
            //        //            taxDataRet = taxDataRet + "<TaxData><Country>" + rowTaxDataRet[j]["Country"].ToString() + "</Country><Amt>" + rowTaxDataRet[j]["Amt"].ToString() + "</Amt></TaxData>";
            //        //        }
            //        //    }


            //        //}

            //        xmlRequest = xmlRequest + "<FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportNameRet + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportNameRet + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber>";
            //        xmlRequest = xmlRequest + "<MarketingAirlineCode>" + MarketingAirlineCodeRet + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineNameRet + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><NumStops>" + NumStopsRet + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmntRet + "</LinkSellAgrmnt><Conx>" + ConxRet + "</Conx><AirpChg>" + AirpChgRet + "</AirpChg><InsideAvailOption>" + InsideAvailOptionRet + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestrictionRet + "</GenTrafRestriction><DaysOperates>" + DaysOperatesRet + "</DaysOperates><JrnyTm>" + JrnyTmRet + "</JrnyTm><EndDt>" + EndDtRet + "</EndDt><StartTerminal>" + StartTerminalRet + "</StartTerminal><EndTerminal>" + EndTerminalRet + "</EndTerminal>";
            //        xmlRequest = xmlRequest + "<FltTm>" + FltTmRet + "</FltTm><LSAInd>" + LSAIndRet + "</LSAInd><Mile>" + MileRet + "</Mile><BookingClass><Availability>" + AvailabilityRet + "</Availability><BIC>" + BICRet + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclassRet + "</bookingclass><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><Rule>" + RuleRet.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgrRet + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";//<Psgr><PsgrType>" + FarePsgrTypeRet + "</PsgrType><BaseFare>" + FareBaseFareRet + "</BaseFare><Tax>" + FareTax1Ret + "</Tax><BagInfo></BagInfo></Psgr>

            //    }
            //}
            #endregion
            #region bookrequest return

            xmlRequest = xmlRequest + "<FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalAirportName>" + ArrivalAirportNameRet + "</ArrivalAirportName><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureAirportName>" + DepartureAirportNameRet + "</DepartureAirportName><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber>";
            xmlRequest = xmlRequest + "<MarketingAirlineCode>" + MarketingAirlineCodeRet + "</MarketingAirlineCode><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineName>" + OperatingAirlineNameRet + "</OperatingAirlineName><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><NumStops>" + NumStopsRet + "</NumStops><LinkSellAgrmnt>" + LinkSellAgrmntRet + "</LinkSellAgrmnt><Conx>" + ConxRet + "</Conx><AirpChg>" + AirpChgRet + "</AirpChg><InsideAvailOption>" + InsideAvailOptionRet + "</InsideAvailOption><GenTrafRestriction>" + GenTrafRestrictionRet + "</GenTrafRestriction><DaysOperates>" + DaysOperatesRet + "</DaysOperates><JrnyTm>" + JrnyTmRet + "</JrnyTm><EndDt>" + EndDtRet + "</EndDt><StartTerminal>" + StartTerminalRet + "</StartTerminal><EndTerminal>" + EndTerminalRet + "</EndTerminal>";
            xmlRequest = xmlRequest + "<FltTm>" + FltTmRet + "</FltTm><LSAInd>" + LSAIndRet + "</LSAInd><Mile>" + MileRet + "</Mile><BookingClass><Availability>" + AvailabilityRet + "</Availability><BIC>" + BICRet + "</BIC></BookingClass><BookingClassFare><bookingclass>" + bookingclassRet + "</bookingclass><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><Rule>" + RuleRet.Replace("<", "&lt;").Replace(">", "&gt;") + "</Rule><PsgrBreakup><PsgrAry>" + taxdatapsgrRet + "</PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment>";//<Psgr><PsgrType>" + FarePsgrTypeRet + "</PsgrType><BaseFare>" + FareBaseFareRet + "</BaseFare><Tax>" + FareTax1Ret + "</Tax><BagInfo></BagInfo></Psgr>

            xmlRequest = xmlRequest + "</FlightSegments></Return><id>" + id1 + "</id><key>" + key + "</key>";
            xmlRequest = xmlRequest + "</OriginDestinationOption></Bookingrequest>";

            #endregion


            DataSet dsResponse = new DataSet();

            StringBuilder stt = new StringBuilder();

            stt.Append("xmlRequest");
            stt.Append("=");
            stt.Append(Server.UrlEncode(xmlRequest));

            byte[] requestData = Encoding.UTF8.GetBytes(stt.ToString());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Booking");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";

            request.ContentLength = requestData.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                        result = reader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);

                    dsResponse.ReadXml(xmlReader);
                }
            }
            return dsResponse;


        }
        catch (Exception ex)
        {

            throw;

        }

    }
    private void saveround(object sender, EventArgs e)
    {
        try
        {
            DataSet dsBookingResponse = new DataSet();
            dsBookingResponse = methodround();

            #region Save Response
            FlightBAL objFlightBal = new FlightBAL();
            if (dsBookingResponse.Tables.Count > 0)
            {
                if (dsBookingResponse.Tables["BookingResponse"].Rows.Count > 0)
                {
                    #region Dedcuting the amount from the agent and DB's balance after booking

                    if (Session["UserID"] != null)
                    {
                        if (Session["Role"] != null)
                        {
                            if (Session["Role"].ToString() == "Agent" || Session["Role"].ToString() == "Distributor")
                            {
                                string[] commPer = Session["CommisionPercentage_Agent"].ToString().Split('.');
                                DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                                                        Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
                                                        Convert.ToDouble(Session["CommisionFare_Agent"].ToString()), Convert.ToDouble(Session["CommisionPercentage_Agent"]));

                                objBAL = new ClsBAL();
                                DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                                string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                                Label lbl = (Label)this.Master.FindControl("lblBalance");
                                lbl.Text = balanceAgent;
                                Session["Balance"] = balanceAgent;
                            }
                            else if (Session["Role"].ToString() == "User")
                            {
                                DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                                    Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                            }
                            else if (Session["Role"].ToString() == "Admin")
                            {
                                DeductAgentBalance(0, Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                                   Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                            }
                        }
                       
                    }
                    else if (Session["Role"] == null)
                    {
                        DeductAgentBalance(0, Convert.ToDouble("0.00"), 0, Session["Order_Id"].ToString(), Convert.ToDouble(Session["Amount"].ToString()),
                                                  Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                    }
                    #endregion
                    objFlightBal.ReferenceNo = Convert.ToString(Session["Order_Id"]);// Common.GetFlightsReferenceNo("LJIF");
                    objFlightBal.TransId = dsBookingResponse.Tables["BookingResponse"].Rows[0]["transid"].ToString();
                    objFlightBal.Status = dsBookingResponse.Tables["BookingResponse"].Rows[0]["status"].ToString();
                    objFlightBal.UpdateDInternationalFlightBooking(objFlightBal);

                    GetDetailsForPrint(Convert.ToString(Session["Order_Id"]));
                    lbtnmail.Visible = false;
                    lbtnmail_Click1(sender, e);
                    pnlSearch.Visible = false;
                    pnlViewticket.Visible = true;
                    pnlIntPassengerDet.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Ticket has been booked successfully. Reference Number is : " + Convert.ToString(Session["Order_Id"]);
                    lblMsg.ForeColor = System.Drawing.Color.Green;


                }
            }

            #endregion
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
            //throw ex;
        }
    }
    DataTable dtdt;
    DataView dv = new DataView();
    bool bl = true;
    int i = 0;
    int strone;
    //  DataTable dataoption;
    protected void Valuechanged(object sender, EventArgs e)
    {
        try
        {
            //if (Chkstop1.Checked == false && Chkstop2.Checked == false)
            //{
            if (rbnIntOneWay.Checked == true)
            {
                #region oneway

                if (Session["dsIntFlights"] != null)
                {

                    if (Session["dtmodifyInt"] == null)
                    {
                        DataSet dd = (DataSet)Session["dsIntFlights"];
                        DataTable dt = dd.Tables[4];
                        // dt.Clone();
                        dt.Columns.Add("TotalFare");
                        foreach (DataRow dtnew in dt.Rows)
                        {
                            decimal str = Convert.ToDecimal(dtnew["ActualBaseFare"]) + Convert.ToDecimal(dtnew["Tax"]) + Convert.ToDecimal(dtnew["Stax"]) + Convert.ToDecimal(dtnew["TCharge"]) + Convert.ToDecimal(dtnew["TMarkup"]);// + Convert.ToDecimal(dtnew["SCharge"]) + Convert.ToDecimal(dtnew["TDiscount"]);
                            dtnew["TotalFare"] = str.ToString();
                        }
                        Session["dtmodifyInt"] = dt;
                        dv = dt.DefaultView;
                        bl = false;
                    }
                    else
                    {
                        DataTable dtmodify = (DataTable)Session["dtmodifyInt"];

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
                        DataTable dtSource = (DataTable)Session["dtIntFlightsFare"];
                        DataView dv1 = dtSource.DefaultView;//dsIntFlights.Tables[12].DefaultView;
                        DataTable dt2 = new DataTable();
                        dt2.TableName = "MM";
                        dt2.Columns.Add("AirEquipType");
                        dt2.Columns.Add("ArrivalAirportName");
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
                        dt2.Columns.Add("JrnyTm");
                        dt2.Columns.Add("EndDt");
                        dt2.Columns.Add("StartTerminal");
                        dt2.Columns.Add("EndTerminal");
                        dt2.Columns.Add("FltTm");
                        dt2.Columns.Add("LsaInd");
                        dt2.Columns.Add("Mile");
                        dt2.Columns.Add("FlightSegment_Id");
                        dt2.Columns.Add("FlightSegments_Id");
                        dt2.Columns.Add("Fare");

                        foreach (DataRow dr in dtdv.Rows)
                        {
                            dv1.RowFilter = "FlightSegments_Id='" + dr["FareDetails_Id"] + "'";
                            dv1.Table.Clone();

                            foreach (DataRowView datav in dv1)
                            {
                                // dtdt.TableName = "MM";

                                dt2.ImportRow(datav.Row);// = dv1.row;
                            }

                        }
                        dv1.Table.AcceptChanges();
                        int v = dv1.Count;
                        gdvIntFlights.DataSource = dt2;
                        ViewState["dt2"] = dt2;
                        DataTable dttt = (DataTable)dv.ToTable();
                        ViewState["dv"] = dttt;
                        gdvIntFlights.DataBind();
                        ViewState["dv"] = null;
                    }
                    else
                    {

                        // Label5.Text = tbUse.Text;
                    }
                }
                #endregion
            }
            else
            {
                DataTable dataoption = new DataTable("dataoption");
                dataoption.Columns.Add("ActualBaseFare");
                dataoption.Columns.Add("Tax");
                dataoption.Columns.Add("Stax");
                dataoption.Columns.Add("SCharge");
                dataoption.Columns.Add("TDiscount");
                dataoption.Columns.Add("TMarkup");
                dataoption.Columns.Add("TPartnerCommission");
                dataoption.Columns.Add("OriginDestinationOption_Id");
                dataoption.Columns.Add("onward_Id");
                dataoption.Columns.Add("FlightSegmets_Id");

                dsIntFlights = (DataSet)Session["dsIntFlights"];
                string availResponseId = dsIntFlights.Tables["AvailResponse"].Rows[0]["AvailResponse_Id"].ToString();
                string originDestinationOptionsId = string.Empty;
                DataTable dtOriginDestinationOPtions = dsIntFlights.Tables["OriginDestinationOptions"];
                if (dtOriginDestinationOPtions.Rows.Count > 0)
                {
                    DataRow[] row = dtOriginDestinationOPtions.Select("AvailResponse_Id=" + availResponseId);
                    originDestinationOptionsId = row[0]["OriginDestinationOptions_Id"].ToString();
                }
                DataTable dtfaredetails = dsIntFlights.Tables["FareDetails"];
                DataView dvfaredetails = dtfaredetails.DefaultView;
                DataTable dtflightsegment = dsIntFlights.Tables["FlightSegment"];
                DataView dvflightsegment = dtflightsegment.DefaultView;
                DataTable dtOriginDestinationOption = dsIntFlights.Tables["OriginDestinationOption"];
                DataTable dtonwardid = dsIntFlights.Tables["onward"];
                DataTable dtFlightSegmetsIds = dsIntFlights.Tables["FlightSegments"];
                DataView dvflightssegments = dtFlightSegmetsIds.DefaultView;
                DataView dv = dtonwardid.DefaultView;
                DataTable dtreturn = dsIntFlights.Tables["Return"];
                DataView dvreturn = dtreturn.DefaultView;
                dataoption.Columns.Add("TotalFare");
                //onward
                foreach (DataRow row in dtOriginDestinationOption.Rows)
                {

                    dvfaredetails.RowFilter = "OriginDestinationOption_Id='" + row["OriginDestinationOption_Id"] + "'";


                    foreach (DataRowView dv2 in dvfaredetails)
                    {

                        dataoption.ImportRow(dv2.Row);

                    }
                }
                foreach (DataRow dtnew in dataoption.Rows)
                {
                    decimal str = Convert.ToDecimal(dtnew["ActualBaseFare"]) + Convert.ToDecimal(dtnew["Tax"]) + Convert.ToDecimal(dtnew["Stax"]) + Convert.ToDecimal(dtnew["SCharge"]) + Convert.ToDecimal(dtnew["TDiscount"]);
                    dtnew["TotalFare"] = str.ToString();
                }

                DataView dvtotal = dataoption.DefaultView;
                dvtotal.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                dvtotal.Table.AcceptChanges();
                DataView dvdtOriginDestinationOption = dtOriginDestinationOption.DefaultView;

                DataTable dtdestinations = new DataTable("destiantion");
                dtdestinations.Columns.Add("OriginDestinationOption_Id");
                dtdestinations.Columns.Add("id");
                dtdestinations.Columns.Add("key");
                dtdestinations.Columns.Add("OriginDestinationOptions_Id");
                dtdestinations.Columns.Add("OperatingAirlineName");
                dtdestinations.Columns.Add("NumStops");

                foreach (DataRowView rowm in dvtotal)
                {
                    dvdtOriginDestinationOption.RowFilter = "OriginDestinationOption_Id ='" + rowm["OriginDestinationOption_Id"] + "'";
                    foreach (DataRowView rows in dvdtOriginDestinationOption)
                    {
                        dtdestinations.ImportRow(rows.Row);
                    }
                }
                foreach (DataRow drv in dtdestinations.Rows)
                {


                    dvflightsegment.RowFilter = "FlightSegments_Id='" + drv["OriginDestinationOption_Id"] + "'";
                    foreach (DataRowView data in dvflightsegment)
                    {
                        drv["OperatingAirlineName"] = data["OperatingAirlineName"];
                        drv["NumStops"] = data["NumStops"];
                    }
                }

                if (dtdestinations.Rows.Count > 0)
                {
                    trroundTrip1.Visible = true;
                    trroundTrip.Visible = true;
                    //  gdvRoundtrip.DataSource = dtdestinations;
                    ViewState["dtdestinations"] = dtdestinations;
                    //  gdvRoundtrip.DataBind();
                }
                else
                {

                    // gdvRoundtrip.DataSource = dtdestinations;
                    ViewState["dtdestinations"] = dtdestinations;
                    //gdvRoundtrip.DataBind();
                }
                //dv.RowFilter = "OriginDestinationOption_Id='" + row["OriginDestinationOption_Id"] + "'";
                //foreach (DataRowView v in dv)
                //{
                //    dvflightssegments.RowFilter = "onward_Id='" + v["onward_Id"] + "'";

                //    foreach (DataRowView dfs in dvflightssegments)
                //    {
                //        //FlightSegments_Id
                //        dvflightsegment.RowFilter = "FlightSegments_Id='" + dfs["FlightSegments_Id"] + "'";
                //        foreach (DataRowView dvseg in dvflightsegment)
                //        {
                //            dvfaredetails.RowFilter = "OriginDestinationOption_Id='" + dvseg["FlightSegment_Id"] + "'";

                //            foreach (DataRowView dv2 in dvfaredetails)
                //            {                                    

                //                    dataoption.ImportRow(dv2.Row);

                //                    dataoption.Rows[i]["onward_Id"] = v["onward_Id"];
                //                    dataoption.Rows[i]["FlightSegmets_Id"] = dfs["FlightSegments_Id"];
                //                    i = i + 1;                                       
                //            }
                //        }

                //    }

                //}
            }
            //i = 0;


            ////return
            //DataTable datareturn = new DataTable("dataoption");
            //datareturn.Columns.Add("ActualBaseFare");
            //datareturn.Columns.Add("Tax");
            //datareturn.Columns.Add("Stax");
            //datareturn.Columns.Add("SCharge");
            //datareturn.Columns.Add("TDiscount");
            //datareturn.Columns.Add("TMarkup");
            //datareturn.Columns.Add("TPartnerCommission");
            //datareturn.Columns.Add("OriginDestinationOption_Id");
            //datareturn.Columns.Add("Return_Id");
            //datareturn.Columns.Add("FlightSegmets_Id");
            //foreach (DataRow row in dtOriginDestinationOption.Rows)
            //{
            //    dvreturn.RowFilter = "OriginDestinationOption_Id='" + row["OriginDestinationOption_Id"] + "'";
            //    foreach (DataRowView v in dvreturn)
            //    {
            //        dvflightssegments.RowFilter = "Return_Id='" + v["Return_Id"] + "'";

            //        foreach (DataRowView dfs in dvflightssegments)
            //        {
            //            //FlightSegments_Id
            //            dvflightsegment.RowFilter = "FlightSegments_Id='" + dfs["FlightSegments_Id"] + "'";
            //            foreach (DataRowView dvseg in dvflightsegment)
            //            {
            //                dvfaredetails.RowFilter = "OriginDestinationOption_Id='" + dvseg["FlightSegment_Id"] + "'";

            //                foreach (DataRowView dv2 in dvfaredetails)
            //                {

            //                    datareturn.ImportRow(dv2.Row);

            //                    datareturn.Rows[i]["Return_Id"] = v["Return_Id"];
            //                    datareturn.Rows[i]["FlightSegmets_Id"] = dfs["FlightSegments_Id"];
            //                    i = i + 1;
            //                }
            //            }

            //        }

            //    }
            //}
            //datareturn.Columns.Add("TotalFare");
            //foreach (DataRow dtnew in datareturn.Rows)
            //{
            //    int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) - Convert.ToInt32(dtnew["TDiscount"]);
            //    dtnew["TotalFare"] = str.ToString();
            //}
            //DataView dvdtreturn = datareturn.DefaultView;
            //DataView dvdtonward = dataoption.DefaultView;
            //dataoption.Columns.Add("TotalRoundtrip");
            //foreach (DataRow d in dataoption.Rows)
            //{
            //    dvdtreturn.RowFilter = "Return_Id='" + d["onward_Id"] + "'";
            //    dvdtonward.RowFilter = "onward_Id='" + d["onward_Id"] + "'";
            //    foreach (DataRowView dr in dvdtonward)
            //    {
            //         strone = Convert.ToInt32(d["TotalFare"]) + Convert.ToInt32(dr[10]);
            //    }
            //    d["TotalRoundtrip"] = strone.ToString();
            //}





            // }
            //}
            //else
            //{

            //}
            lbl.Text = HiddenField1.Value;
            lbl11.Text = HiddenField2.Value;
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    protected void sliderTwo_TextChanged(object sender, EventArgs e)
    {

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
            dt2.Columns.Add("JrnyTm");
            dt2.Columns.Add("EndDt");
            dt2.Columns.Add("StartTerminal");
            dt2.Columns.Add("EndTerminal");
            dt2.Columns.Add("FltTm");
            dt2.Columns.Add("LsaInd");
            dt2.Columns.Add("Mile");
            dt2.Columns.Add("FlightSegment_Id");
            dt2.Columns.Add("FlightSegments_Id");
            dt2.Columns.Add("Fare");

            if (ViewState["dt2"] != null)
            {
                DataTable dtstop = (DataTable)ViewState["dt2"];
                dvstop = dtstop.DefaultView;
            }

            string rowfilter = string.Empty;
            for (int i = 0; i < chkAirlines.Items.Count; i++)
            {
                if (chkAirlines.Items[i].Selected)
                {
                    if (rowfilter == string.Empty)
                    {
                        rowfilter = "OperatingAirlineName='" + chkAirlines.Items[i].Text.Trim() + "'";
                    }
                    else
                    {
                        rowfilter = rowfilter + " or OperatingAirlineName='" + chkAirlines.Items[i].Text.Trim() + "'";
                    }
                }
            }
            dvstop.RowFilter = rowfilter;

            if (dvstop.Count > 0)
            {
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }

            }



            if (dt2.Rows.Count > 0)
            {
                gdvIntFlights.DataSource = dt2;
                Session["dtIntFlights"] = dt2;
                gdvIntFlights.DataBind();

            }
            else
            {
                gdvIntFlights.DataSource = dt2;
                gdvIntFlights.DataBind();
            }
        }
        catch (Exception ex)
        {

           // throw ex;
        }
    }
    
    protected void JetAirwaysReturn(object sender, EventArgs e)
    {
        try
        {
            Valuechanged(sender, e);
            DataTable dt2 = new DataTable();
            dt2.TableName = "MM";
            dt2.Columns.Add("OriginDestinationOption_Id");
            dt2.Columns.Add("id");
            dt2.Columns.Add("key");
            dt2.Columns.Add("OriginDestinationOptions_Id");
            dt2.Columns.Add("OperatingAirlineName");
            dt2.Columns.Add("NumStops");
            if (ViewState["dtdestinations"] != null)
            {
                DataTable dtstop = (DataTable)ViewState["dtdestinations"];
                dvstop = dtstop.DefaultView;
            }


            string rowfilter = string.Empty;
            for (int i = 0; i < chkAirlines.Items.Count; i++)
            {
                if (chkAirlines.Items[i].Selected)
                {
                    if (rowfilter == string.Empty)
                    {
                        rowfilter = "OperatingAirlineName='" + chkAirlines.Items[i].Text.Trim().Trim() + "'";
                    }
                    else
                    {
                        rowfilter = rowfilter + " or OperatingAirlineName='" + chkAirlines.Items[i].Text.Trim().Trim() + "'";
                    }
                }
            }
            dvstop.RowFilter = rowfilter;



            if (dvstop.Count > 0)
            {
                foreach (DataRowView rows in dvstop)
                {
                    dt2.ImportRow(rows.Row);
                }

            }


            if (dt2.Rows.Count > 0)
            {
                gdvRoundtrip.DataSource = dt2;
                gdvRoundtrip.DataBind();
            }
            else
            {

                gdvRoundtrip.DataSource = dv;
                gdvRoundtrip.DataBind();
                return;

            }




        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void filter(object sender, EventArgs e)
    {
        try
        {
            if (rbnIntOneWay.Checked == true || rradiooneway.Checked == true)
            {
                JetAirways(sender, e);
            }
            else if (rbnIntRoundTrip.Checked == true || rradioround.Checked == true)
            {
                JetAirwaysReturn(sender, e);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void rradiooneway_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            txtretundatesearch.Enabled = false;
            txtretundatesearch.Attributes.Remove("class");
            txtretundatesearch.Text = ""; lblMsg.Text = "";
            trroundTrip1.Visible = false;
            oneway.Visible = false;
            rbnIntRoundTrip.Checked = false;
            rbnIntOneWay.Checked = true;
            printroundtrip.Visible = false;
            btnIntBook.Visible = false;
            trFilterSearch.Visible = true;
            trfiltersearch1.Visible = false;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void rradioround_CheckedChanged(object sender, EventArgs e)
    {
        trFilterSearch.Visible = false;
        txtretundatesearch.Enabled = true;
        txtretundatesearch.Attributes.Add("class", "datepicker1");
        rbnIntRoundTrip.Checked = true;
        rbnIntOneWay.Checked = false;

        trroundTrip1.Visible = true;
        oneway.Visible = false;
        printroundtrip.Visible = true;
        btnBack.Visible = false;
        trFilterSearch.Visible = true;
        trfiltersearch1.Visible = false;
    }
    protected void Nextdatemodify(object sender, EventArgs e)
    {
        try
        {
            if (rradioround.Checked == true)
            {
                DateTime Cdt = Convert.ToDateTime(txtdatesearch.Text);
                Cdt = Cdt.AddDays(1);
                txtretundatesearch.Text = Cdt.ToString("yyyy-MM-dd");
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    protected void dates(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void TextValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (args.Value.Length >= 2);

    }
    protected void btnExportTOWord_Click(object sender, EventArgs e)
    {
        try
        {
            pnlViewticket.Visible = true;
            // BindLabelData();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Ticket.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlViewticket.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing


        }
    }


    protected void btnResetFilters_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["dsIntFlights"] != null)
            {
                dsIntFlights = (DataSet)Session["dsIntFlights"];
                DataTable dtFlightsSegment = dsIntFlights.Tables[12];


                DataTable dtFareDet = dsIntFlights.Tables[4];
                decimal minValue = Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TMarkup"]); //+ Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]);

                decimal maxValue = Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TMarkup"]);//+ Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);
                

                multiHandleSliderExtenderTwo.BehaviorID = "multiHandleSliderExtenderTwo";
                multiHandleSliderExtenderTwo.TargetControlID = "sliderTwo";
                multiHandleSliderExtenderTwo.EnableHandleAnimation = true;
                multiHandleSliderExtenderTwo.EnableKeyboard = false;
                multiHandleSliderExtenderTwo.EnableMouseWheel = false;
                multiHandleSliderExtenderTwo.EnableRailClick = false;
                multiHandleSliderExtenderTwo.ShowHandleDragStyle = true;

                multiHandleSliderExtenderTwo.ShowInnerRail = true;
                multiHandleSliderExtenderTwo.OnClientDragEnd = "ValueChangedHandler";



                minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);

                BindAirportCodes(dtFlightsSegment);
                Valuechanged(sender, e);

                multiHandleSliderExtenderTwo.ClientState = minValue + "," + maxValue;
                if (rradiooneway.Checked == true)
                {
                    JetAirways(sender, e);
                }
                else
                {
                    JetAirwaysReturn(sender, e);
                }
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

        //InternationalFlightsPanel.Visible = true;
        ModifySearch.Visible = false;
        pnlIntPassengerDet.Visible = false;
        trFilterSearch.Visible = true;
        gdvIntFlights.Visible = true;
        gdvRoundtrip.Visible = true;
    }

    protected void lnkDepart_Click(object sender, EventArgs e)
    {
        SortGridView("DepartureDateTime", lnkDepart.ToolTip);
        if (lnkDepart.ToolTip == "ASC")
        {
            lnkDepart.ToolTip = "DESC";
        }
        else
        {
            lnkDepart.ToolTip = "ASC";
        }
    }
    protected void lnkarrives_Click(object sender, EventArgs e)
    {
        SortGridView("ArrivalDateTime", lnkarrives.ToolTip);
        if (lnkarrives.ToolTip == "ASC")
        {
            lnkarrives.ToolTip = "DESC";
        }
        else
        {
            lnkarrives.ToolTip = "ASC";
        }
    }
    protected void lnkfare_Click(object sender, EventArgs e)
    {
        SortGridView("Fare", lnkfare.ToolTip);
        if (lnkfare.ToolTip == "ASC")
        {
            lnkfare.ToolTip = "DESC";
        }
        else
        {
            lnkfare.ToolTip = "ASC";
        }
    }
    protected void lnkdepartonward_Click(object sender, EventArgs e)
    {
        SortGridView1("DepartureDateTime", lnkdepartonward.ToolTip);
        if (lnkdepartonward.ToolTip == "ASC")
        {
            lnkdepartonward.ToolTip = "DESC";
        }
        else
        {
            lnkdepartonward.ToolTip = "ASC";
        }
    }
    protected void lnkarriveonward_Click(object sender, EventArgs e)
    {
        SortGridView1("ArrivalDateTime", lnkarriveonward.ToolTip);
        if (lnkarriveonward.ToolTip == "ASC")
        {
            lnkarriveonward.ToolTip = "DESC";
        }
        else
        {
            lnkarriveonward.ToolTip = "ASC";
        }
    }
    protected void lnkfareroudwayn_Click(object sender, EventArgs e)
    {
        SortGridView1("Fare", lnkfareroudwayn.ToolTip);
        if (lnkfareroudwayn.ToolTip == "ASC")
        {
            lnkfareroudwayn.ToolTip = "DESC";
        }
        else
        {
            lnkfareroudwayn.ToolTip = "ASC";
        }
    }
}