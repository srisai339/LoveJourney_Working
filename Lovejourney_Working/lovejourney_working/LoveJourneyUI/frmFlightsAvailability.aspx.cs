using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using FilghtsAPILayer;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;
using BAL.DTO;

public partial class frmFlightsAvailability : System.Web.UI.Page
{
    ClsBAL objBAL = new ClsBAL();
    FlightsAPILayer objFlights = new FlightsAPILayer();
    DataSet dsFilghts = null;
    DataSet dsIntFlights = null;
    int adultcnt = 0;
    int childCnt = 0;
    int infantCnt = 0;
    int statusCnt = 0;


    clsMasters _objMasters;
    DataSet _objDataSet;
    static string val;


    static string transId = "";
    DataSet objDataSet;
    string ResponseMessage = string.Empty;
    string DateCreated = string.Empty;
    string PaymentID = string.Empty;
    string MerchantRefNo = string.Empty;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
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
           // FnLocationtoXml();
            getdatafromXMl();
           
            if (Session["UserID"] == null)
            {
                lblMsg.Text = string.Empty;
                Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                pnl.Visible = true;

                tblicons.Visible = true;
                
            }
            if (Session["UserID"] == null)
            {
                User_menu.Visible = true;
                lnkSNFFare.Visible = false;
                lnkSNFFareroundtrip.Visible = false;
            }
            else if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User")
            {
                tblicons.Visible = false;
                User_menu.Visible = false;
                lnkSNFFare.Visible = false;
                lnkSNFFareroundtrip.Visible = false;
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                tblicons.Visible = false;
                User_menu.Visible = false;
                lnkSNFFare.Visible = true;
                lnkSNFFareroundtrip.Visible = true;
            }
            if (!IsPostBack)
            {            
             

                if (Session["UserID"] == null)
                {
                    lblMsg.Text = string.Empty;
                    Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                    pnl.Visible = false;
                }

                rbtnOneWay.Checked = true;
                getservices();
                if (val != "true")
                {

                    gdvFlights.Visible = true;
                    round.Visible = false;
                    Page.Header.DataBind();
                    //tdimage.Visible = true;
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
                                ResponseMessage = msgid2.Substring(16).ToString().Trim().ToString();
                            }
                            catch (Exception ex)
                            {
                                // LogError("BusSearch", "msgid2", DateTime.Now, msgid2.ToString());
                            }
                            try
                            {
                                msgid5 = words[4].ToString();
                                MerchantRefNo = msgid5.Substring(14).ToString().Trim().ToString();
                            }
                            catch (Exception ex)
                            {
                                // LogError("BusSearch", "msgid5", DateTime.Now, msgid5.ToString());
                            }

                            if (ResponseMessage == "Transaction Successful")
                            {

                                find(sender, e);
                                Session["DR"] = null;
                                
                                
                            }

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
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
            DataSet dt = objFlightsBal.IGetInternationalFlightDetails(ReferenceNo);
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
    private void GetFlights()
    {
        try
        {
            try
            {

                //Session["From"] = ddlSources.Text.Substring(ddlSources.Text.IndexOf("(") + 1, 3);
                //Session["TO"] = ddlDestinations.Text.Substring(ddlDestinations.Text.IndexOf("(") + 1, 3);

                //Session["FromDate"] = txtFromDate.Text.Trim();
                ////Converting dd-mm-yyyy to yyyy-mm-dd
                //string s = txtFromDate.Text.Trim();
                //string[] result = s.Split('-');
                //string date = result[2] + "-" + result[1] + "-" + result[0];
                ////  txtFromDate.Text = date;           

                //Session["ToDate"] = txtReturnDate.Text.Trim();
                ////Converting dd-mm-yyyy to yyyy-mm-dd
                //string date1 = "";
                //if (txtReturnDate.Text != "")
                //{
                //    string s1 = txtReturnDate.Text.Trim();
                //    string[] result1 = s1.Split('-');
                //    date1 = result1[2] + "-" + result1[1] + "-" + result1[0];
                //    //  txtReturnDate.Text = date1;
                //}
                //infantCnt = Convert.ToInt32(ddlInfant.SelectedValue);
                //childCnt = Convert.ToInt32(ddlChild.SelectedValue);
                //adultcnt = Convert.ToInt32(ddlAdult.SelectedValue);

                //Session["adultcnt"] = adultcnt.ToString();
                //Session["infantCnt"] = infantCnt.ToString();
                //Session["childCnt"] = childCnt.ToString();


               // string mode = (rbtnOneWay.Checked) ? "ONE" : "ROUND";
                //string returnDate = (rbtnOneWay.Checked) ? date : date1;
                String xmlRequestData = "<Request><Origin>" + Session["From"].ToString() + "</Origin><Destination>" + Session["TO"].ToString() + "</Destination><DepartDate>" + ViewState["OnwardDate"] + "</DepartDate>" +
           "<ReturnDate>" + ViewState["ReturnDate"] + "</ReturnDate>" +
           "<AdultPax>" + Session["adultcnt"] + "</AdultPax>" +  
           "<ChildPax>" + Session["childCnt"] + "</ChildPax>" +
           "<InfantPax>" + Session["infantCnt"] + "</InfantPax>" +
           "<Currency>INR</Currency>" +
           "<Clientid>" + FlightsConstants.USERID + "</Clientid>" +
           "<Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword>" +
           "<Clienttype>" + FlightsConstants.USERTYPE + "</Clienttype>" +
               "<Preferredclass>" + Session["ClassType"] + "</Preferredclass>" +
           "<mode>" + Session["Mode"] + "</mode>" +
               "<PreferredAirline></PreferredAirline>" +
           "</Request>";


                //  FlightsAvailabilityManager dsavialibility = new FlightsAvailabilityManager();
                ////  dsavalibility.GetAvailableFlights(xmlRequestData);

                //  gdvFlights.DataSource = dsavalibility.GetAvailableFlights(xmlRequestData);
                //  gdvFlights.DataBind();

                dsFilghts = objFlights.GetAvailability(xmlRequestData);


                Session["dsDomFlights"] = dsFilghts;

                string mode = Session["Mode"].ToString();
                if (dsFilghts.Tables.Count > 0)
                {                  

                    DataTable dtresponse = dsFilghts.Tables[0];

                   
                    
                        // lnkModifySearch.Visible = true;
                        modifyfilter.Visible = true;

                        ModifySearch.Visible = false;  ///changed              
                        dvModifySearch.Visible = false;///changed

                        if (mode == "ONE")
                        {

                            if (dtresponse.Columns.Count != 4)
                            {
                                if (dtresponse.Rows[0][1].ToString() == "")
                                {
                                    DataTable dtFlightsSegment = dsFilghts.Tables[9];

                                    gdvFlights.Visible = true;
                                    trFilterSearch.Visible = true;
                                    tblSearch.Visible = false;
                                    FilterBlock.Visible = true;

                                    #region FareDet
                                    DataTable dtFareDet = dsFilghts.Tables[6];
                                    DataTable dtFareFlights = new DataTable();
                                    dtFareFlights = dtFlightsSegment.Clone();
                                    // dtFareFlights.Columns.Add("Fare", typeof(decimal));
                                    dtFareFlights.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                    dtFareFlights = GetFareDetTable(dtFlightsSegment, dtFareDet, dsFilghts);


                                    #endregion

                                    DataView dvFare = dtFareFlights.DefaultView;
                                    dvFare.Sort = "Fare Asc";

                                   

                                    gdvFlights.DataSource = Session["dtFights"] = Session["dtFightsFare"] = dvFare.ToTable();

                                 //   gdvFlights.DataSource = Session["dtFights"] = Session["dtFightsFare"] = dtFareFlights;

                                    gdvFlights.DataBind();
                                    BindAirportCodes(dtFlightsSegment);


                                    decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                    decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);


                                    minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                    maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                    multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                    multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);




                                    string[] strfrom = new string[2];

                                    if (Session["From"] != null)
                                    {
                                        strfrom = Session["From"].ToString().Split(',');
                                    }
                                    else
                                    {
                                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                                        strfrom = Session["From"].ToString().Split(',');
                                    }
                                    string[] strto = new string[2];
                                    if (Session["To"] != null)
                                    {
                                        strto = Session["To"].ToString().Split(',');
                                    }
                                    else
                                    {
                                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                                        strto = Session["To"].ToString().Split(',');
                                    }
                                    lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                                  //  DateTime Date = Convert.ToDateTime(txtFromDate.Text);

                                    Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtFromDate.Text;
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
                                    DataTable dtFlightsSegment = dsFilghts.Tables[9];
                                    // lnkModifySearch.Visible = true;
                                    gdvFlights.Visible = true;
                                    trFilterSearch.Visible = true;
                                    tblSearch.Visible = false;
                                    FilterBlock.Visible = true;
                                    lblOnwardDepartureAirportCode.Text = lblReturnArrivalAirportCode.Text = ddlSources.Text;
                                    lblOnwardArrivalAirportCode.Text = lblReturnDepartureAirportCode.Text = ddlDestinations.Text;
                                    lblOnwardTO.Visible = lblReturnTO.Visible = true;
                                    RoundtripMethod();

                                    DataTable dtFareDet = dsFilghts.Tables[6];
                                    DataTable dtNonFareDet = dsFilghts.Tables[7];

                                    DataTable dtNewFare = dtFareDet.Copy();
                                    dtNewFare.Columns.Add("TCharge", System.Type.GetType("System.Decimal"));
                                    dtNewFare.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                    for (int i = 0; i < dtFareDet.Rows.Count; i++)
                                    {

                                        dtNewFare.Rows[i]["Tcharge"] = dtNonFareDet.Rows[i]["TCharge"].ToString();
                                        dtNewFare.Rows[i]["Fare"] = Convert.ToDecimal(dtFareDet.Rows[i]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[i]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[i]["STax"]) + Convert.ToDecimal(dtNonFareDet.Rows[i]["TCharge"]) + Convert.ToDecimal(dtNonFareDet.Rows[i]["TMarkup"]);//+ Convert.ToDecimal(dtFareDet.Rows[i]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[i]["TDiscount"])


                                    }
                                    DataView dvFare = dtNewFare.DefaultView;
                                    dvFare.Sort = "Fare Asc";

                                    decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]); //Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]) + Convert.ToDecimal(dtNonFareDet.Rows[0]["TCharge"]);

                                    decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]) + Convert.ToDecimal(dtNonFareDet.Rows[dtNonFareDet.Rows.Count - 1]["TCharge"]); 


                                    minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                    maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                    multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                    multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);
                                    BindAirportCodes(dtFlightsSegment);

                                    string[] strfrom = new string[2];

                                    if (Session["From"] != null)
                                    {
                                        strfrom = Session["From"].ToString().Split(',');
                                    }
                                    else
                                    {
                                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                                        strfrom = Session["From"].ToString().Split(',');
                                    }
                                    string[] strto = new string[2];
                                    if (Session["To"] != null)
                                    {
                                        strto = Session["To"].ToString().Split(',');
                                    }
                                    else
                                    {
                                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                                        strto = Session["To"].ToString().Split(',');
                                    }
                                    lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();

                                    if (rbtnRoundTrip.Checked == true)
                                    {

                                      //  DateTime Date = Convert.ToDateTime(txtFromDate.Text);
                                        Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtFromDate.Text;
                                      //  DateTime Date1 = Convert.ToDateTime(txtReturnDate.Text);


                                        Label3.Text = Label3.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + txtReturnDate.Text;
                                    }
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
                   
                    // lnkModifySearch.Visible = true;
                }
                else
                {
                    mp3.Show();
                    lblerror.Text = "No Services Found";
                    return;
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

            DataTable dtFlightSegments = dsFilghts.Tables[8];
            if (dtFlightSegments.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID=" + FlightSegmentsID);
                originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
            }
            DataTable dtFareDetails = dsFilghts.Tables[5];
            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }
            DataTable dtChargeableFares = dsFilghts.Tables[6];
            DataTable dtNonChargeableFares = dsFilghts.Tables[7];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId); //CHITTI

                double total = Convert.ToDouble(Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]) + Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]) + Convert.ToDouble(rowChargeableFareDetails[0]["STax"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]));// + Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]) +                                        Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"])
                totalStr = total.ToString("####0.00");

            }
            dtNewFare.Rows[i]["Fare"] = totalStr;


        }
        return dtNewFare;
    }

    private void RoundtripMethod()
    {
        string totalStr1 = string.Empty;

        dsFilghts = (DataSet)Session["dsDomFlights"];
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
        //Adding fare column to the flight segments for sorting for onward
        DataTable dtnewflightsegment1 = dtNewFlightSegment.Clone();
        dtnewflightsegment1.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

        foreach (DataRow dr in dtNewFlightSegment.Rows)
        {
            dtnewflightsegment1.ImportRow(dr);
        }
        dtnewflightsegment1.AcceptChanges();

        for (int i = 0; i < dtNewFlightSegment.Rows.Count; i++)
        {
            FlightSegmentsID = dtNewFlightSegment.Rows[i]["FlightSegments_ID"].ToString();

            DataTable dtFlightSegments1 = dsFilghts.Tables[8];
            if (dtFlightSegments1.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegments = dtFlightSegments1.Select("FlightSegments_ID=" + FlightSegmentsID);
                originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
            }
            DataTable dtFareDetails = dsFilghts.Tables[5];
            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }
            DataTable dtChargeableFares = dsFilghts.Tables[6];
            DataTable dtNonChargeableFares = dsFilghts.Tables[7];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId); //CHITTI

                double total = Convert.ToDouble(Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]) + Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]) + Convert.ToDouble(rowChargeableFareDetails[0]["STax"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]));// + Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]) +                                        Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"])
                totalStr1 = total.ToString("####0.00");

            }
            dtnewflightsegment1.Rows[i]["Fare"] = totalStr1;

        }


        DataView dvfare = dtnewflightsegment1.DefaultView;
        dvfare.Sort = "Fare ASC";

        gdvOnward.DataSource = Session["DtOnWardFlights"] = dvfare.ToTable();//dtnewflightsegment1;
        gdvOnward.DataBind();
        BindAirportCodes(dtNewFlightSegment);

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

        //Adding fare column to the flight segments for sorting for return
        DataTable dtNewFlightSegmentRet1 = dtNewFlightSegmentRet.Clone();
        dtNewFlightSegmentRet1.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

        foreach (DataRow dr in dtNewFlightSegmentRet.Rows)
        {
            dtNewFlightSegmentRet1.ImportRow(dr);
        }
        dtNewFlightSegmentRet1.AcceptChanges();

        for (int i = 0; i < dtNewFlightSegmentRet.Rows.Count; i++)
        {
            FlightSegmentsID = dtNewFlightSegmentRet.Rows[i]["FlightSegments_ID"].ToString();

            DataTable dtFlightSegments1 = dsFilghts.Tables[8];
            if (dtFlightSegments1.Rows.Count > 0)
            {
                DataRow[] rowFilghtSegments = dtFlightSegments1.Select("FlightSegments_ID=" + FlightSegmentsID);
                originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
            }
            DataTable dtFareDetails = dsFilghts.Tables[5];
            if (dtFareDetails.Rows.Count > 0)
            {
                DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
            }
            DataTable dtChargeableFares = dsFilghts.Tables[6];
            DataTable dtNonChargeableFares = dsFilghts.Tables[7];
            if (dtChargeableFares.Rows.Count > 0)
            {
                DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId); //CHITTI

                double total = Convert.ToDouble(Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]) + Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]) + Convert.ToDouble(rowChargeableFareDetails[0]["STax"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]));// + Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]) +                                        Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"])
                totalStr1 = total.ToString("####0.00");

            }
            dtNewFlightSegmentRet1.Rows[i]["Fare"] = totalStr1;

        }

        DataView dvreturnfare = dtNewFlightSegmentRet1.DefaultView;
        dvreturnfare.Sort = "Fare ASC";

        gdvReturn.DataSource = Session["DtReturnFlights"] = dvreturnfare.ToTable(); //dtNewFlightSegmentRet1;
        gdvReturn.DataBind();
        #endregion

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void rbtnOneWay_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            lblMsg.Text = string.Empty;
            Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
            pnl.Visible = false;
        }
       // lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = false;
        txtReturnDate.Attributes.Remove("class");
       // RequiredReturn.Visible = false; 
        txtReturnDate.Text = ""; lblMsg.Text = "";
        txtretundatesearch.Enabled = false;
        txtretundatesearch.Attributes.Remove("class");
        Oneway.Visible = true;

        round.Visible = false;
        Returnway.Visible = false;
        Returnwayfare.Visible = false;
        rbonesearch.Checked = true;
        rbreturnsearch.Checked = false;

        tdround.Visible = false;

    }
    protected void rbtnRoundTrip_CheckedChanged(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            lblMsg.Text = string.Empty;
            Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
            pnl.Visible = false;
        }
       // lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = true;
        txtReturnDate.Attributes.Add("class", "datepicker1");
        //RequiredReturn.Visible = true;
        lblMsg.Text = "";
        txtretundatesearch.Enabled = true;
        txtretundatesearch.Attributes.Add("class", "datepicker1");

        Oneway.Visible = false;
        trroundTrip.Visible = true;
        round.Visible = true;
        Returnway.Visible = true;
        Returnwayfare.Visible = true;
        rbonesearch.Checked = false;
        rbreturnsearch.Checked = true;
        modifyfilter.Visible = true ;
        trfiltersearch1.Visible = false;


        tdround.Visible = true;
    }
    protected void rbonesearch_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            txtretundatesearch.Enabled = false;
            txtretundatesearch.Attributes.Remove("class");
            Oneway.Visible = false;
            trroundTrip.Visible = false;
            round.Visible = false;
            Returnway.Visible = false;
            Returnwayfare.Visible = false;
            gdvFlights.Visible = true;
            modifyfilter.Visible = true;
            FilterBlock.Visible = true;
            trfiltersearch1.Visible = false;

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void rbreturnsearch_CheckedChanged(object sender, EventArgs e)
    {

        //txtretundatesearch.Enabled = true;
        //txtretundatesearch.Attributes.Add("class", "datepicker");
        //Oneway.Visible = false;
        //trroundTrip.Visible = true;
        //round.Visible = true;
        //Returnway.Visible = true;
        //Returnwayfare.Visible = true;
        //FilterBlock.Visible = false;
        txtretundatesearch.Enabled = true;
        txtretundatesearch.Attributes.Add("class", "datepicker");
        Oneway.Visible = false;
        trroundTrip.Visible = true;
        round.Visible = false;
        Returnway.Visible = true;
        Returnwayfare.Visible = true;
        //gdvFlights.Visible = false;
        printroundtrip.Visible = true;

        Tr1.Visible = false;
        tblOnwardFlightDet.Visible = false;
        tblReturnFlightDet.Visible = false;
        FilterBlock.Visible = true;
        trfiltersearch1.Visible = false;
        return1.Visible = true;


    }

    protected void ibtnSearch_Click1(object sender, EventArgs e)
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
                if (Convert.ToInt32(ddlAdult.SelectedValue) + Convert.ToInt32(ddlChild.SelectedValue) + Convert.ToInt32(ddlInfant.SelectedValue) <= 9)
                {
                    if (Convert.ToInt32(ddlInfant.SelectedValue) <= Convert.ToInt32(ddlAdult.SelectedValue))
                    {
                        txtFromDate.Text = hdnfromdate.Value;
                        if (hdnTodate.Value == "DD-MM-YYYY")
                        {
                            txtReturnDate.Text = "";
                        }
                        else
                        {
                            txtReturnDate.Text = hdnTodate.Value;
                        }

                        trfiltersearch1.Visible = true;
                        lnkModifySearch_Click(sender, e);




                        Session["From"] = ddlSources.Text.Substring(ddlSources.Text.IndexOf("(") + 1, 3);
                        Session["TO"] = ddlDestinations.Text.Substring(ddlDestinations.Text.IndexOf("(") + 1, 3);

                        Session["FromDate"] = txtFromDate.Text.Trim();
                      //  DateTime dt = DateTime.Parse(txtFromDate.Text, CultureInfo.GetCultureInfo("en-gb"));

                        //Converting dd-mm-yyyy to yyyy-mm-dd
                      //  string fromdate = dt.ToString();

                        string s = txtFromDate.Text.Trim();
                        string[] result = s.Split('-');
                       string date = result[2] + "-" + result[1] + "-" + result[0];
                    
                      // string date = dt.ToString();
                        ViewState["OnwardDate"] = date;

                        Session["ToDate"] = txtReturnDate.Text.Trim();
                        //Converting dd-mm-yyyy to yyyy-mm-dd
                        string date1 = "";
                        if (txtReturnDate.Text != "")
                        {
                            string s1 = txtReturnDate.Text.Trim();
                            string[] result1 = s1.Split('-');
                            date1 = result1[2] + "-" + result1[1] + "-" + result1[0];                 
                        }
                        string returnDate = (rbtnOneWay.Checked) ? date : date1;
                        ViewState["ReturnDate"] = returnDate;

                        infantCnt = Convert.ToInt32(ddlInfant.SelectedValue);
                        childCnt = Convert.ToInt32(ddlChild.SelectedValue);
                        adultcnt = Convert.ToInt32(ddlAdult.SelectedValue);

                        Session["adultcnt"] = adultcnt.ToString();
                        Session["infantCnt"] = infantCnt.ToString();
                        Session["childCnt"] = childCnt.ToString();

                        Session["ClassType"] = ddlCabin_type.SelectedValue;
                        string mode = (rbtnOneWay.Checked) ? "ONE" : "ROUND";
                        Session["Mode"] = mode;
                        GetFlights();
                        if (mode == "ONE")
                        {
                            return1.Visible = false;

                        }
                        else
                        {
                            return1.Visible = true;
                        }
                        //ModifySearch.Visible = true;

                        //dvModifySearch.Visible = true;

                        //tdimage.Visible = false;
                        //string[] strfrom = new string[2];
                        //strfrom = Session["From"].ToString().Split(',');
                        //string[] strto = new string[2];
                        //strto = Session["To"].ToString().Split(',');
                        //lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                        //DateTime Date = Convert.ToDateTime(txtFromDate.Text);
                        //Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + Date.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblMsg.Text = "Infant Count should be less than or equal to Adult Count";
                    }

                }
                else
                {
                    lblMsg.Text = "Maximum Number of passengers allowed is 9";
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

    


    protected void gdvFlights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];

                string FlightSegmentsID = string.Empty;
                string originDestination_Id = string.Empty;
                string fareDetailsId = string.Empty;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label FlightSegments_ID = (Label)e.Row.FindControl("lblFlightSegments_ID");

                    Label adulttaxbreakup = (Label)e.Row.FindControl("lbladulttaxbreakup");
                    Label lbldepartsort = (Label)e.Row.FindControl("lbldepartsort");
                    if (adulttaxbreakup.Text != "0,0,0")
                    {
                        Label airlinename = (Label)e.Row.FindControl("lblAirlineNameMrk");
                        DataTable dtFlightsSegment = dsFilghts.Tables[9];
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

                          DataTable dtFlightSegments = dsFilghts.Tables[8];
                        if (dtFlightSegments.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
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
                            Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");



                            lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                            lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                            lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                            lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                            lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");

                            DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                            if (dtNonChargeableFares.Rows.Count > 0)
                            {
                                DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);  //CHITTI

                                lblTCharge.Text = (Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");
                            }
                            double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text); //+ Convert.ToDouble(lblTDiscount.Text) + Convert.ToDouble(lblSCharge.Text)
                            lblFare.Text = lblTotal.Text = total.ToString("####0.00");



                            #region Calculating SNF and HNF for domestic one way
                            if (Session["UserID"] != null)
                            {
                                if (Session["Role"].ToString() == "Agent")
                                {
                                    DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airlinename.Text.ToString());
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
                                    double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                                    double DeductAmount = total - CommissionFare;
                                    lblHNFFare.Text = Convert.ToDouble(DeductAmount).ToString();
                                    double newcomm = total - Convert.ToDouble(DeductAmount);
                                    int newcomm1 = Convert.ToInt32(newcomm);
                                    
                                    Label lblagentcomm1=(Label)e.Row.FindControl("lblagentcomm1");
                                    lblagentcomm1.Text = "com:" +newcomm1.ToString();
                                    #region Adding mark up price of agent
                                    Class1 objBal = new Class1();
                                    objBal.ScreenInd = Master123.gettopmarkup;
                                    objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                                    objBal.Type = "Domestic Flights";
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
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                    #region old
                    //Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
                    //Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    //Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    //Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                    //Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");
                    //Label lblduration = (Label)e.Row.FindControl("lblduration");
                    //Label airlinename = (Label)e.Row.FindControl("lblAirlineName");

                    //DataTable dtFlightsSegment = dsFilghts.Tables[9];
                    ////rajini
                    //if (Session["dtFights"] != null)
                    //{
                    //    dtFlightsSegment = (DataTable)Session["dtFights"];
                    //}
                    ////rajini end
                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {
                    //        lblConnectingAirportCode.Visible = true;
                    //        lblHyphen.Visible = true;
                    //        lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                    //        lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                    //        lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                    //        lblConnectingFlights.Visible = true;
                    //        string destinationsearch = ddlDestinationsSearch.Text.Substring(ddlDestinationsSearch.Text.IndexOf("(") + 1, 3);
                    //        string SourcesSearch = ddlSourcesSearch.Text.Substring(ddlSourcesSearch.Text.IndexOf("(") + 1, 3);

                    //        if (lblArrivalAirportCode.Text != destinationsearch)
                    //        {
                    //            e.Row.Visible = false;
                    //        }
                    //        if (lblDepartureAirportCode.Text != SourcesSearch)
                    //        {
                    //            e.Row.Visible = false;
                    //        }

                    //    }
                    //    else
                    //    {
                    //        lblConnectingAirportCode.Visible = false;
                    //        lblHyphen.Visible = false;
                    //        lblConnectingFlights.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblConnectingFlights.Visible = false;
                    //}
                    //if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //{
                    //    e.Row.Visible = false;
                    //}

                    //Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    //DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    //string[] time = lblDepartTime.Text.ToString().Split('T');
                    //lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);

                    //Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
                    //DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    //string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    //lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);


                    //var dateOne = dtDepart;
                    //var dateTwo = dtArrive;
                    //var diff = dateTwo.Subtract(dateOne);
                    //var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                    //lblduration.Text = res;

                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {

                    //        string departTime1 = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureDateTime"].ToString();
                    //        DateTime dpttime = Convert.ToDateTime(departTime1);
                    //        string[] departtime1 = departTime1.ToString().Split('T');

                    //        string arrTime1 = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();
                    //        DateTime arrtime = Convert.ToDateTime(arrTime1);
                    //        string[] Arrtime1 = arrTime1.ToString().Split('T');
                    //        lblArrivalTime.Text = Arrtime1[1].ToString().Substring(0, Arrtime1[1].ToString().Length - 3);

                    //        var dateOne1 = dpttime;
                    //        var dateTwo1 = arrtime;
                    //        var diff1 = dateTwo1.Subtract(dateOne1);
                    //        var res1 = String.Format("{0}hrs:{1}m", diff1.Hours, diff1.Minutes);
                    //        lblduration.Text = res1;
                    //    }
                    //}


                    //LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
                    //int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

                    //DataTable dtBookingFareRules = dsFilghts.Tables[11];
                    //if (dtBookingFareRules.Rows.Count > 0)
                    //{
                    //    DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                    //    Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                    //    lblFareRules.Text = row[0]["Rule"].ToString();
                    //}


                    //if (dtFlightsSegment.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID = '" + FlightSegmentId + "'");
                    //    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                    //}

                    //DataTable dtFlightSegments = dsFilghts.Tables[8];
                    //if (dtFlightSegments.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID = '" + FlightSegmentsID + "'");
                    //    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                    //}
                    //DataTable dtFareDetails = dsFilghts.Tables[5];
                    //if (dtFareDetails.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    //    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                    //}
                    //DataTable dtChargeableFares = dsFilghts.Tables[6];
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

                    //    DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                    //    if (dtNonChargeableFares.Rows.Count > 0)
                    //    {
                    //        DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);  //CHITTI

                    //        lblTCharge.Text = (Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");
                    //    }
                    //    //TcCharge is from Nonchargeable fares and all from Chargeable Fares
                    //    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text); //+ Convert.ToDouble(lblTDiscount.Text) + Convert.ToDouble(lblSCharge.Text)

                    //    lblFare.Text = lblTotal.Text = total.ToString("####0.00");

                    //    #region Calculating SNF and HNF
                    //    if (Session["UserID"] != null)
                    //    {
                    //        if (Session["Role"].ToString() == "Agent")
                    //        {
                    //            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airlinename.Text.ToString());
                    //            string commisionPercentage = string.Empty;
                    //            if (dsCommSlab.Tables[0].Rows.Count > 0)
                    //                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                    //            else
                    //                commisionPercentage = "0";

                    //            Label lblHNFFare = (Label)e.Row.FindControl("lblHNFFare");
                    //            double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                    //            double DeductAmount = total - CommissionFare;
                    //            lblHNFFare.Text = Convert.ToDouble(DeductAmount).ToString();

                    //            #region Adding mark up price of agent
                    //            Class1 objBal = new Class1();
                    //            objBal.ScreenInd = Master123.gettopmarkup;
                    //            objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                    //            objBal.Type = "Domestic Flights";
                    //            objDataSet = (DataSet)objBal.fnGetData();
                    //            string markUpAmount = "0";
                    //            ViewState["MarkUp"] = markUpAmount;
                    //            if (objDataSet != null)
                    //            {
                    //                if (objDataSet.Tables.Count > 0)
                    //                {

                    //                    markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                    //                    ViewState["MarkUp"] = markUpAmount;
                    //                    if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                    //                    {
                    //                        lblTCharge.Text = (Convert.ToDouble(lblTCharge.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                    //                    {
                    //                        lblTCharge.Text = (Convert.ToDouble(lblTCharge.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTCharge.Text);
                    //                    lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                    //                }
                    //            }


                    //            #endregion
                    //        }
                    //    }
                    //    #endregion
                    //}




                    DataTable dtactivedetails = dsFilghts.Tables[1];
                    Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                    Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                    Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                    Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                    lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                    lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                    lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                    lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();
                    #endregion
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

    protected void gdvconnectingflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];

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
                    Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());                             
                    string format = "ddd , MMM  d, yyyy";
                    lbldepartdate.Text = dt.ToString(format); 


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
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


                    Image img = (Image)e.Row.FindControl("img");
                    Label lblAirlineName = (Label)e.Row.FindControl("lblAirlineName");
                    if (lblAirlineName.Text == "Indigo")
                    {
                        img.ImageUrl = "~/images/indigo.png";
                    }


                    if (lblnoofstops.Text == "1")
                    {                    

                       // string s = lblviaflight.Text.Replace("<brbr>", " ");

                        string spacecontains;
                        spacecontains = lblviaflight.Text;

                        if (lblviaflight.Text.Contains(" "))
                        {
                            spacecontains = lblviaflight.Text.Replace(" ", "-");
                        }

                        string s = spacecontains.Replace("<brbr>", " ");






                        string[] s1 = s.Split(' ');

                        string s2 = s1[0].Replace("<br>", " ");
                        string[] s3 = s2.Split(' ');

                        string s4 = s1[1].Replace("<br>", " ");
                        string[] s5 = s4.Split(' ');
                        if (s3[3].ToString() != "NA")
                        {
                            string[] s6 = s3[3].Split('T');
                            s3[3] = s6[1].ToString();
                        }
                        if (s3[5].ToString() != "NA")
                        {
                            string[] s6 = s3[5].Split('T');
                            s3[5] = s6[1].ToString();
                        }
                        if (s5[5].ToString() != "NA")
                        {
                            string[] s6 = s5[5].Split('T');
                            s5[5] = s6[1].ToString();
                        }
                        if (s5[3].ToString() != "NA")
                        {
                            string[] s6 = s5[3].Split('T');
                            s5[3] = s6[1].ToString();
                        }
                        lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                        lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                        lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                        lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                        lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                        lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                        pnlstops.Visible = true;

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
                        pnlstops.Visible = true;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;

                   

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
    protected void gdvonwardconflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];

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
                    Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());
                    string format = "ddd,MMM d";
                    lbldepartdate.Text = dt.ToString(format);


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
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


                    Image img = (Image)e.Row.FindControl("img");
                    Label lblAirlineName = (Label)e.Row.FindControl("lblAirlineName");
                    if (lblAirlineName.Text == "Indigo")
                    {
                        img.ImageUrl = "~/images/indigo.png";
                    }


                    if (lblnoofstops.Text == "1")
                    {

                       // string s = lblviaflight.Text.Replace("<brbr>", " ");

                        string spacecontains;
                        spacecontains = lblviaflight.Text;

                        if (lblviaflight.Text.Contains(" "))
                        {
                            spacecontains = lblviaflight.Text.Replace(" ", "-");
                        }

                        string s = spacecontains.Replace("<brbr>", " ");



                        string[] s1 = s.Split(' ');

                        string s2 = s1[0].Replace("<br>", " ");
                        string[] s3 = s2.Split(' ');

                        string s4 = s1[1].Replace("<br>", " ");
                        string[] s5 = s4.Split(' ');
                        if (s3[3].ToString() != "NA")
                        {
                            string[] s6 = s3[3].Split('T');
                            s3[3] = s6[1].ToString();
                        }
                        if (s3[5].ToString() != "NA")
                        {
                            string[] s6 = s3[5].Split('T');
                            s3[5] = s6[1].ToString();
                        }
                        if (s5[5].ToString() != "NA")
                        {
                            string[] s6 = s5[5].Split('T');
                            s5[5] = s6[1].ToString();
                        }
                        if (s5[3].ToString() != "NA")
                        {
                            string[] s6 = s5[3].Split('T');
                            s5[3] = s6[1].ToString();
                        }
                        lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                        lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                        lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                        lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                        lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                        lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                        pnlstops.Visible = true;

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
                        pnlstops.Visible = true;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}h:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;

                    

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
    protected void gdvreturnconflights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];

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
                    Label lbldepartdate = (Label)e.Row.FindControl("lbldepartdate");
                    Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    string[] time = lblDepartTime.Text.ToString().Split('T');
                    lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);
                    DateTime dt = Convert.ToDateTime(time[0].ToString());
                    string format = "ddd,MMM d";
                    lbldepartdate.Text = dt.ToString(format);


                    //Splitting the Arrivaldatetime with T
                    Label lblarrivaldate = (Label)e.Row.FindControl("lblarrivaldate");
                    Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
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



                    Image img = (Image)e.Row.FindControl("img");
                    Label lblAirlineName = (Label)e.Row.FindControl("lblAirlineName");
                    if (lblAirlineName.Text == "Indigo")
                    {
                        img.ImageUrl = "~/images/indigo.png";
                    }

                    if (lblnoofstops.Text == "1")
                    {

                       // string s = lblviaflight.Text.Replace("<brbr>", " ");


                        string spacecontains;
                        spacecontains = lblviaflight.Text;

                        if (lblviaflight.Text != "Via Flight")
                        {

                            if (lblviaflight.Text.Contains(" "))
                            {
                                spacecontains = lblviaflight.Text.Replace(" ", "-");
                            }

                            string s = spacecontains.Replace("<brbr>", " ");



                            string[] s1 = s.Split(' ');

                            string s2 = s1[0].Replace("<br>", " ");
                            string[] s3 = s2.Split(' ');

                            string s4 = s1[1].Replace("<br>", " ");
                            string[] s5 = s4.Split(' ');
                            if (s3[3].ToString() != "NA")
                            {
                                string[] s6 = s3[3].Split('T');
                                s3[3] = s6[1].ToString();
                            }
                            if (s3[5].ToString() != "NA")
                            {
                                string[] s6 = s3[5].Split('T');
                                s3[5] = s6[1].ToString();
                            }
                            if (s5[5].ToString() != "NA")
                            {
                                string[] s6 = s5[5].Split('T');
                                s5[5] = s6[1].ToString();
                            }
                            if (s5[3].ToString() != "NA")
                            {
                                string[] s6 = s5[3].Split('T');
                                s5[3] = s6[1].ToString();
                            }
                            lblStartFlight.Text = s3[0].ToString() + "-" + s3[1].ToString();
                            lblStartFlight1.Text = s5[0].ToString() + " -" + s5[1].ToString();
                            lblstartDepart.Text = s3[2].ToString() + "<br> " + s3[3].ToString();
                            lblstopArrival.Text = s3[4].ToString() + "<br> " + s3[5].ToString();
                            lblstartDepart1.Text = s5[2].ToString() + " <br>" + s5[3].ToString();
                            lblstopArrival1.Text = s5[4].ToString() + " <br>" + s5[5].ToString();
                            pnlstops.Visible = true;

                            lblnoofstops.Text = lblnoofstops.Text + "Stop(s)";
                        }
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
                        pnlstops.Visible = true;
                    }


                    var dateOne = dtDepart;
                    var dateTwo = dtArrive;
                    var diff = dateTwo.Subtract(dateOne);
                    var res = String.Format("{0}h:{1}m", diff.Hours, diff.Minutes);
                    lblduration.Text = res;



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
    protected void gdvFlights_RowCommand(object sender, GridViewCommandEventArgs e)
    {      

        if (e.CommandName == "BoolTicket")
        {
            if (Session["UserId"] == null)
            {
                Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
                pnl.Visible = true;
            }
            try
            {

                pnlSearch.Visible = false;//changed
                lblFlightSegmentId1.Text = e.CommandArgument.ToString();

                Control ctl = e.CommandSource as Control;
                GridViewRow row1 = ctl.NamingContainer as GridViewRow;               

                GridView gdvconnectingflights = (GridView)row1.FindControl("gdvconnectingflights");
                GridViewRow row = (GridViewRow)gdvconnectingflights.NamingContainer;

               // GridViewRow gdvconflightsrows = (GridViewRow)gdvconnectingflights.NamingContainer;
              //  string arrivaldate = gdvconnectingflights.DataKeys[row.RowIndex].Values["lblarrivaldate"].ToString();


                foreach (GridViewRow row2 in gdvconnectingflights.Rows)
                {

                    Label lblarrivaldate = (Label)row2.FindControl("lblarrivaldate");

                    Label lbldepartdate = (Label)row2.FindControl("lbldepartdate");
                    Label lblOperatingAirlineName = (Label)row2.FindControl("lblAirlineName");
                    Label lblOperatingAirlineFlightNumber = (Label)row2.FindControl("lblFlightNumber");
                    Label lblDestinations = (Label)row2.FindControl("lblDestinations");
                    Label lblarrtime = (Label)row2.FindControl("lblArrivalTime");
                    Label lbldeptime = (Label)row2.FindControl("lblDepartTime");
                    Label lblTax = (Label)row1.FindControl("lblTax");
                    Label lblSTax = (Label)row1.FindControl("lblSTax");
                    Label lblSCharge = (Label)row1.FindControl("lblSCharge");
                    Label lblTDiscount = (Label)row1.FindControl("lblTDiscount");
                    Label lblTotal = (Label)row1.FindControl("lblTotal");
                    Label lblBaseFare = (Label)row1.FindControl("lblBaseFare");
                    Label lblTcharge = (Label)row1.FindControl("lblTCharge");

                    lblairline.Text = lblOperatingAirlineName.Text;
                    lblflightno.Text = lblOperatingAirlineFlightNumber.Text;

                    DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                    DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                    string format = "MMM ddd d HH:mm yyyy";

                    //lbldepartdate.Text = Date.ToString("dd/MM/yyyy");
                    //lblarrivaldate.Text = Date1.ToString("dd/MM/yyyy");
                    string depart = Date.ToString("dd/MM/yyyy");
                    string arrival = Date1.ToString("dd/MM/yyyy");

                    lbldepart.Text = depart;
                    lblarrives.Text = arrival;
                    lblarrivetime.Text = lblarrtime.Text;
                    lbldeparttime.Text = lbldeptime.Text;
                    string[] strfrom = new string[2];

                    if (Session["From"] != null)
                    {
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    else
                    {
                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    string[] strto = new string[2];
                    if (Session["To"] != null)
                    {
                        strto = Session["To"].ToString().Split(',');
                    }
                    else
                    {
                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                        strto = Session["To"].ToString().Split(',');
                    }
                    lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                    lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + lbldepart.Text;

                    lblairporttax.Text = lblTax.Text;
                    lblServiceTaxthree.Text = lblSTax.Text;
                    lblTChargeRet5.Text = lblTcharge.Text;
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
            catch (Exception ex)
            {
                mp3.Show();
                lblerror.Text = ex.Message;
            }
        }
        
        // For Details in a grid
        if (e.CommandName == "View Details")
        {
            try
            {
                try
                {
                    DataSet dsDomFlights = (DataSet)Session["dsDomFlights"];
                    DataTable dtFlightSegment = dsDomFlights.Tables[9];
                    lblFlightSegmentId1.Text = e.CommandArgument.ToString();
                    DataRow[] dr = dtFlightSegment.Select("FlightSegment_Id='" + lblFlightSegmentId1.Text + "'");
                    Control ctl = e.CommandSource as Control;
                    GridViewRow row1 = ctl.NamingContainer as GridViewRow;
                    Label lblarrivaldate = (Label)row1.FindControl("lblarrivaldate");
                    Label lbldepartdate = (Label)row1.FindControl("lbldepartdate");
                    Label lblOperatingAirlineName = (Label)row1.FindControl("lblAirlineName");
                    Label lblOperatingAirlineFlightNumber = (Label)row1.FindControl("lblFlightNumber");
                    Label lblDestinations = (Label)row1.FindControl("lblDestinations");
                    Label lblArrivalTime = (Label)row1.FindControl("lblArrivalTime");
                    Label lblDepartTime = (Label)row1.FindControl("lblDepartTime");
                    Label lblDepartureAirportCode = (Label)row1.FindControl("lblDepartureAirportCode");
                    Label lblArrivalAirportCode = (Label)row1.FindControl("lblArrivalAirportCode");
                    Label lblConnectingAirportCode = (Label)row1.FindControl("lblConnectingAirportCode");
                    Image img = (Image)row1.FindControl("img");
                    Label lblduration = (Label)row1.FindControl("lblduration");
                    Label lblstops = (Label)row1.FindControl("lblstops");
                    Label lblviaflight = (Label)row1.FindControl("lblviaflight");
                    #region No of stops
                    lnkNoofstops.Text = lblstops.Text;
                    if (lnkNoofstops.Text == "1")
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
                        //pnlstops.Visible = true;

                    }
                    else if (lnkNoofstops.Text == "0")
                    {
                    //    lblstartDepart.Text = "";
                    //    lblstopArrival.Text = "";
                    //    lblstartDepart1.Text = "";
                    //    lblstopArrival1.Text = "";
                    //    lblStartFlight.Text = "";
                    //    lblStartFlight1.Text = "";
                    //    pnlstops.Visible = false;
                    }
                    #endregion

                    #region Det

                    lblAirlineNameDet.Text = lblOperatingAirlineName.Text;
                    imgDet.ImageUrl = img.ImageUrl;
                    lblFlightNumberDet.Text = lblOperatingAirlineFlightNumber.Text;
                    string text = ddlSources.Text;
                    //foreach (ListItem li in ddlSources.Items)
                    //{
                    //    if (lblDepartureAirportCode.Text == li.Value)
                    //    {
                    //        lblDepartureAirportNameDet.Text = li.Text;
                    //    }

                    //}
                    //foreach (ListItem li in ddlDestinations.Items)
                    //{
                    //    if (lblArrivalAirportCode.Text == li.Value)
                    //    {
                    //        lblArrivalAirportNameDet.Text = li.Text;
                    //    }
                    //}

                    lblDepartureDateTimeDet.Text = lblDepartTime.Text;

                    lblArrivalDateTimeDet.Text = lblArrivalTime.Text;
                    lblduratindetails.Text = lblduration.Text;


                    #endregion

                    DataRow[] drFlightNext = dtFlightSegment.Select("FlightSegment_Id='" + (Convert.ToInt32(lblFlightSegmentId1.Text) + 1) + "'");
                    if (drFlightNext[0]["adultTaxBreakUp"].ToString() == "0,0,0")
                    {

                        DataRow[] drFlightPrev = dtFlightSegment.Select("FlightSegment_Id='" + lblFlightSegmentId1.Text + "'");
                        lblAirlineNameDet.Text = drFlightPrev[0]["AirlineName"].ToString();
                        imgDet.ImageUrl = drFlightPrev[0]["imageFileName"].ToString();
                        lblFlightNumberDet.Text = drFlightPrev[0]["FlightNumber"].ToString();
                        //foreach (ListItem li in ddlSources.Items)
                        //{
                        //    if (drFlightPrev[0]["DepartureAirportCode"].ToString() == li.Value)
                        //    {
                        //        lblDepartureAirportNameDet.Text = li.Text;
                        //    }


                        //}
                        //foreach (ListItem li in ddlDestinations.Items)
                        //{
                        //    if (drFlightPrev[0]["ArrivalAirportCode"].ToString() == li.Value)
                        //    {
                        //        lblArrivalAirportNameDet.Text = li.Text;
                        //    }


                        //}
                        lblDepartureDateTimeDet.Text = drFlightPrev[0]["DepartureDateTime"].ToString();

                        lblArrivalDateTimeDet.Text = drFlightPrev[0]["ArrivalDateTime"].ToString();

                        string[] strDep = lblDepartureDateTimeDet.Text.Split('T');
                        string[] strArr = lblArrivalDateTimeDet.Text.Split('T');

                        DateTime Date = Convert.ToDateTime(lblDepartureDateTimeDet.Text);
                        DateTime Date1 = Convert.ToDateTime(lblArrivalDateTimeDet.Text);

                        lblDepartureDateTimeDet.Text = Date.ToString("dd/MM/yyyy") + " " + strDep[1].ToString();
                        lblArrivalDateTimeDet.Text = Date1.ToString("dd/MM/yyyy") + " " + strArr[1].ToString();

                        trConnecting.Visible = true;

                        lblAirlineNameDet1.Text = drFlightNext[0]["AirlineName"].ToString();
                        imgDet1.ImageUrl = drFlightNext[0]["imageFileName"].ToString();
                        lblFlightNumberDet1.Text = drFlightNext[0]["FlightNumber"].ToString();
                        //foreach (ListItem li in ddlSources.Items)
                        //{
                        //    if (drFlightNext[0]["DepartureAirportCode"].ToString() == li.Value)
                        //    {
                        //        lblDepartureAirportNameDet1.Text = li.Text;
                        //    }


                        //}
                        //foreach (ListItem li in ddlDestinations.Items)
                        //{
                        //    if (drFlightNext[0]["ArrivalAirportCode"].ToString() == li.Value)
                        //    {
                        //        lblArrivalAirportNameDet1.Text = li.Text;
                        //    }


                        //}
                        lblDepartureDateTimeDet1.Text = drFlightNext[0]["DepartureDateTime"].ToString();

                        lblArrivalDateTimeDet1.Text = drFlightNext[0]["ArrivalDateTime"].ToString();

                        string[] strDep1 = lblDepartureDateTimeDet1.Text.Split('T');
                        string[] strArr1 = lblArrivalDateTimeDet1.Text.Split('T');

                        DateTime Date12 = Convert.ToDateTime(lblDepartureDateTimeDet1.Text);
                        DateTime Date11 = Convert.ToDateTime(lblArrivalDateTimeDet1.Text);

                        lblDepartureDateTimeDet1.Text = Date12.ToString("dd/MM/yyyy") + " " + strDep1[1].ToString();
                        lblArrivalDateTimeDet1.Text = Date11.ToString("dd/MM/yyyy") + " " + strArr1[1].ToString();

                        //calculating layover time
                        #region calculating layover time


                        DateTime dtDepart = Convert.ToDateTime(drFlightPrev[0]["DepartureDateTime"].ToString());
                        DateTime dtArrive = Convert.ToDateTime(drFlightPrev[0]["ArrivalDateTime"].ToString());

                        var dateOne = dtDepart;
                        var dateTwo = dtArrive;
                        var diff = dateTwo.Subtract(dateOne);
                        var res = String.Format("{0}hrs:{1}m", diff.Hours, diff.Minutes);
                        lblduration1.Text = res;
                        lblduration1.Visible = true;


                        DateTime dtDepart1 = Convert.ToDateTime(drFlightNext[0]["DepartureDateTime"].ToString());
                        DateTime dtArrive1 = Convert.ToDateTime(drFlightNext[0]["ArrivalDateTime"].ToString());

                        var dateOne1 = dtDepart1;
                        var dateTwo1 = dtArrive1;
                        var diff1 = dateTwo1.Subtract(dateOne1);
                        var res1 = String.Format("{0}hrs:{1}m", diff1.Hours, diff1.Minutes);
                        lblduration2.Text = res1;

                        var time = diff.Add(diff1);

                        var diff3 = dateTwo1.Subtract(dateOne);
                        var layovertime = diff3.Subtract(time);
                        var res3 = String.Format("{0}hrs:{1}m", layovertime.Hours, layovertime.Minutes);
                        lbllayovertime.Text = res3;


                        trlayovertime.Visible = true;
                        lblduratindetails.Visible = false;
                        #endregion

                        // end calculating layover time
                    }
                    else
                    {
                        trConnecting.Visible = false;
                    }
                    lnkDummy_Click(sender, e);
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
        Label lblTCharge = (Label)gdvFlightsrow.FindControl("lblTCharge");


        img.ImageUrl = imggrid.ImageUrl;
        lblAirlineName1.Text = lblAirlineName.Text;
        lblFlightNumber1.Text = lblFlightNumber.Text;
        lblDepartTime1.Text = lblDepartTime.Text;
        lblArrivalTime1.Text = lblArrivalTime.Text;
        lblOrigin1.Text = ddlSources.Text;
        lblDestination1.Text = ddlDestinations.Text.ToString();
        lblTravelDate.Text = txtFromDate.Text;
        lblTotalFare1.Text = lblTotal1.Text = lblTotal.Text;



        lblBaseFare1.Text = lblBaseFare.Text;
        lblTax1.Text = lblTax.Text;
        lblSTax1.Text = lblSTax.Text;
        lblSCharge1.Text = lblSCharge.Text;
        lblTDiscount1.Text = lblTDiscount.Text;
        lblTCharge1.Text = lblTCharge.Text;
        lblFlightSegmentId1.Text = lnkFareRule.CommandArgument.ToString();

    }
    protected void rbnAirlineonward_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            try
            {
                Tr1.Visible = true;
                tblOnwardFlightDet.Visible = true;

                RadioButton rbnAirline = (RadioButton)sender;
                GridViewRow gdvFlightsrow = (GridViewRow)rbnAirline.NamingContainer;
                GridView  gdvonwardconflights = (GridView)gdvFlightsrow.FindControl("gdvonwardconflights");




                Label lblFare = (Label)gdvFlightsrow.FindControl("lblFare");
                Label lblTotal = (Label)gdvFlightsrow.FindControl("lblTotal");
                LinkButton lnkFareRule = (LinkButton)gdvFlightsrow.FindControl("lnkFareRule");

                Label lblBaseFare = (Label)gdvFlightsrow.FindControl("lblBaseFare");
                Label lblTax = (Label)gdvFlightsrow.FindControl("lblTax");
                Label lblSTax = (Label)gdvFlightsrow.FindControl("lblSTax");
                Label lblSCharge = (Label)gdvFlightsrow.FindControl("lblSCharge");
                Label lblTDiscount = (Label)gdvFlightsrow.FindControl("lblTDiscount");
                Label lblTChargeRet1 = (Label)gdvFlightsrow.FindControl("lblTChargeRet3");

                foreach (GridViewRow gvrow in gdvonwardconflights.Rows)
                {
                    Image imggrid = (Image)gvrow.FindControl("img");
                    Label lblAirlineName = (Label)gvrow.FindControl("lblAirlineName");
                    Label lblFlightNumber = (Label)gvrow.FindControl("lblFlightNumber");
                    Label lblDepartTime = (Label)gvrow.FindControl("lblDepartTime");
                    Label lblArrivalTime = (Label)gvrow.FindControl("lblArrivalTime");


                    imgOnwardFlight.ImageUrl = imggrid.ImageUrl;
                    lblOnwardAirline.Text = lblAirlineName.Text;
                    lblOnwardFlightNum.Text = lblFlightNumber.Text;
                    lblOnwardDeparts.Text = lblDepartTime.Text;
                    lblOnwardArrives.Text = lblArrivalTime.Text;
                }

             


             
                lblOnwardOrigin.Text = ddlSources.Text.ToString();
                lblonwardDestination.Text = ddlDestinations.Text.ToString();
                lblOnwardTravelDate.Text = txtFromDate.Text = Convert.ToString(Session["FromDate"]);
                lblOnwardTotalFare.Text = lblOnwardTotal.Text = lblTotal.Text;


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
                lblonwardTChargeRet1.Text = lblTChargeRet1.Text;
                lblonwardTChargeRet1.Text = lblTChargeRet1.Text;


                lblonwardFlightSegmentId.Text = lnkFareRule.CommandArgument.ToString();
                btnRoundTripBook.Visible = false;



                //ravi

                foreach (GridViewRow gvrow1 in gdvonwardconflights.Rows)
                {
                    Label lblarrivaldate = (Label)gvrow1.FindControl("lblarrivaldate");
                    Label lbldepartdate = (Label)gvrow1.FindControl("lbldepartdate");
                    Label lblOperatingAirlineName = (Label)gvrow1.FindControl("lblAirlineName");
                    Label lblOperatingAirlineFlightNumber = (Label)gvrow1.FindControl("lblFlightNumber");
                    Label lblDestinations = (Label)gvrow1.FindControl("lblDestinations");
                    Label lblarrtime = (Label)gvrow1.FindControl("lblArrivalTime");
                    Label lbldeptime = (Label)gvrow1.FindControl("lblDepartTime");




                    Label lblTax1 = (Label)gdvFlightsrow.FindControl("lblTax");
                    Label lblSTax1 = (Label)gdvFlightsrow.FindControl("lblSTax");
                    Label lblSCharge1 = (Label)gdvFlightsrow.FindControl("lblSCharge");
                    Label lblTDiscount1 = (Label)gdvFlightsrow.FindControl("lblTDiscount");
                    Label lblTotal1 = (Label)gdvFlightsrow.FindControl("lblTotal");
                    Label lblBaseFare1 = (Label)gdvFlightsrow.FindControl("lblBaseFare");

                    lblairline.Text = lblOperatingAirlineName.Text;
                    lblflightno.Text = lblOperatingAirlineFlightNumber.Text;

                    DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                    DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                    string format = "MMM ddd d HH:mm yyyy";


                    //lbldepartdate.Text = Date.ToString("dd/MM/yyyy");
                    //lblarrivaldate.Text = Date1.ToString("dd/MM/yyyy");

                    string depart = Date.ToString("dd/MM/yyyy");
                    string arrival = Date1.ToString("dd/MM/yyyy");

                    lbldepart.Text = depart;
                    lblarrives.Text = arrival;
                    lblarrivetime.Text = lblarrtime.Text;
                    lbldeparttime.Text = lbldeptime.Text;

                    string[] strfrom = new string[2];

                    if (Session["From"] != null)
                    {
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    else
                    {
                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    string[] strto = new string[2];
                    if (Session["To"] != null)
                    {
                        strto = Session["To"].ToString().Split(',');
                    }
                    else
                    {
                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                        strto = Session["To"].ToString().Split(',');
                    }
                    lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                    lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + lbldepart.Text;

                    lblairporttax.Text = lblTax1.Text;
                    lblServiceTaxthree.Text = lblSTax1.Text;
                    lblTChargeRet5.Text = lblTChargeRet1.Text;
                    lblServiceCharge.Text = lblSCharge1.Text;
                    lblTotalDiscount.Text = lblTDiscount1.Text;
                    lblTotalAmt.Text = lblTotal1.Text;
                    lblActualFare.Text = lblBaseFare1.Text;
                }

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
    protected void rbnAirlineReturn_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            try
            {
                Tr1.Visible = true;
                tblReturnFlightDet.Visible = true;
                RadioButton rbnAirline = (RadioButton)sender;
                GridViewRow gdvFlightsrow = (GridViewRow)rbnAirline.NamingContainer;

                GridView gdvreturnconflights = (GridView)gdvFlightsrow.FindControl("gdvreturnconflights");
                Label lblFare = (Label)gdvFlightsrow.FindControl("lblFare");
                Label lblTotal = (Label)gdvFlightsrow.FindControl("lblTotal");
                LinkButton lnkFareRule = (LinkButton)gdvFlightsrow.FindControl("lnkFareRule");

                Label lblBaseFare = (Label)gdvFlightsrow.FindControl("lblBaseFare");
                Label lblTax = (Label)gdvFlightsrow.FindControl("lblTax");
                Label lblSTax = (Label)gdvFlightsrow.FindControl("lblSTax");
                Label lblSCharge = (Label)gdvFlightsrow.FindControl("lblSCharge");
                Label lblTDiscount = (Label)gdvFlightsrow.FindControl("lblTDiscount");
                Label lblTreturnCharge = (Label)gdvFlightsrow.FindControl("lblTChargeRet");
                foreach (GridViewRow item in gdvreturnconflights.Rows)
                {
                    Image imggrid = (Image)item.FindControl("img");
                    Label lblAirlineName = (Label)item.FindControl("lblAirlineName");
                    Label lblFlightNumber = (Label)item.FindControl("lblFlightNumber");
                    Label lblDepartTime = (Label)item.FindControl("lblDepartTime");
                    Label lblArrivalTime = (Label)item.FindControl("lblArrivalTime");

                    imgReturn.ImageUrl = imggrid.ImageUrl;
                    lblReturnAirline.Text = lblAirlineName.Text;
                    lblReturnFlightNum.Text = lblFlightNumber.Text;
                    lblReturnDeparts.Text = lblDepartTime.Text;
                    lblReturnArrives.Text = lblArrivalTime.Text;
                    lblReturnOrigin.Text = ddlDestinations.Text.ToString();
                    lblReturnDestination.Text = ddlSources.Text.ToString();
                    lblReturnTravelDate.Text = txtReturnDate.Text = Convert.ToString(Session["ToDate"]);
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
                    lblTChargeRet2.Text = lblTreturnCharge.Text;
                    lblReturnSCharge.Text = lblSCharge.Text;
                    lblReturnDiscount.Text = lblTDiscount.Text;
                    lblReturnFlightSegment.Text = lnkFareRule.CommandArgument.ToString();
                    btnRoundTripBook.Visible = true;



                    //ravi

                    Label lblarrivaldate = (Label)item.FindControl("lblarrivaldate");
                    Label lbldepartdate = (Label)item.FindControl("lbldepartdate");
                    Label lblOperatingAirlineName = (Label)item.FindControl("lblAirlineName");
                    Label lblOperatingAirlineFlightNumber = (Label)item.FindControl("lblFlightNumber");
                    Label lblDestinations = (Label)item.FindControl("lblDestinations");
                    Label lblarrtime = (Label)item.FindControl("lblArrivalTime");
                    Label lbldeptime = (Label)item.FindControl("lblDepartTime");
                    Label lblTax1 = (Label)gdvFlightsrow.FindControl("lblTax");
                    Label lblSTax1 = (Label)gdvFlightsrow.FindControl("lblSTax");
                    Label lblSCharge1 = (Label)gdvFlightsrow.FindControl("lblSCharge");
                    Label lblTDiscount1 = (Label)gdvFlightsrow.FindControl("lblTDiscount");
                    Label lblTotal1 = (Label)gdvFlightsrow.FindControl("lblTotal");
                    Label lblBaseFare1 = (Label)gdvFlightsrow.FindControl("lblBaseFare");

                    Label lblTCharge = (Label)gdvFlightsrow.FindControl("lblTChargeRet");

                    lblairlinereturn.Text = lblOperatingAirlineName.Text;
                    lblflightnoreturn.Text = lblOperatingAirlineFlightNumber.Text;


                    DateTime Date = Convert.ToDateTime(lbldepartdate.Text);
                    DateTime Date1 = Convert.ToDateTime(lblarrivaldate.Text);
                    string format = "MMM ddd d HH:mm yyyy";

                    string depart = Date.ToString("dd/MM/yyyy");
                    string arrival = Date1.ToString("dd/MM/yyyy");

                    lbldepartreturn.Text = depart;
                    lblarrivesreturn.Text = arrival;


                    lblarrivetimereturn.Text = lblarrtime.Text;
                    lbldeparttimereturn.Text = lbldeptime.Text;

                    string[] strfrom = new string[2];

                    if (Session["From"] != null)
                    {
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    else
                    {
                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    string[] strto = new string[2];
                    if (Session["To"] != null)
                    {
                        strto = Session["To"].ToString().Split(',');
                    }
                    else
                    {
                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                        strto = Session["To"].ToString().Split(',');
                    }
                    lblRouteReturn.Text = strto[0].ToString() + "-" + strfrom[0].ToString();
                    lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + lbldepart.Text;

                    lblairporttaxreturn.Text = lblTax1.Text;
                    lblTChargeRet6.Text = lblTCharge.Text;
                    lblServiceTaxreturn.Text = lblSTax1.Text;
                    lblServiceChargereturn.Text = lblSCharge1.Text;
                    lblTotalDiscountreturn.Text = lblTDiscount1.Text;
                    lblTotalAmtreturn.Text = lblTotal1.Text;
                    lblActualFarereturn.Text = lblBaseFare1.Text;
                }

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
            try
            {
                Session["From"] = ddlSourcesSearch.Text.Substring(ddlSources.Text.IndexOf("(") + 1, 3);
                Session["TO"] = ddlDestinationsSearch.Text.Substring(ddlDestinationsSearch.Text.IndexOf("(") + 1, 3);
                Session["FromDate"] = txtdatesearch.Text.Trim();
                //Converting dd-mm-yyyy to yyyy-mm-dd
                string s = txtdatesearch.Text.Trim();
                string[] result = s.Split('-');
                string date = result[2] + "-" + result[1] + "-" + result[0];

                Session["ToDate"] = txtretundatesearch.Text.Trim();

                string date1 = "";
                if (txtretundatesearch.Text != "")
                {
                    string s1 = txtretundatesearch.Text.Trim();
                    string[] result1 = s1.Split('-');
                    date1 = result1[2] + "-" + result1[1] + "-" + result1[0];
                    //  txtReturnDate.Text = date1;
                }


                infantCnt = Convert.ToInt32(ddlinfantsintsearch.SelectedValue);
                childCnt = Convert.ToInt32(ddlchildintsearch.SelectedValue);
                adultcnt = Convert.ToInt32(ddladultsintsearch.SelectedValue);

                Session["adultcnt"] = adultcnt.ToString();
                Session["infantCnt"] = infantCnt.ToString();
                Session["childCnt"] = childCnt.ToString();


                string mode = (rbonesearch.Checked) ? "ONE" : "ROUND";
                string returnDate = (rbonesearch.Checked) ? txtdatesearch.Text : txtretundatesearch.Text;
                String xmlRequestData = "<Request><Origin>" + Session["From"] + "</Origin><Destination>" + Session["TO"] + "</Destination><DepartDate>" + date + "</DepartDate>" +
           "<ReturnDate>" + date1 + "</ReturnDate>" +
           "<AdultPax>" + ddladultsintsearch.SelectedValue + "</AdultPax>" +
           "<ChildPax>" + ddlchildintsearch.SelectedValue + "</ChildPax>" +
           "<InfantPax>" + ddlinfantsintsearch.SelectedValue + "</InfantPax>" +
           "<Currency>INR</Currency>" +
         "<Clientid>" + FlightsConstants.USERID + "</Clientid>" +
           "<Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword>" +
           "<Clienttype>" + FlightsConstants.USERTYPE + "</Clienttype>" +
               "<Preferredclass>" + ddlIntCabinTypesearch.SelectedValue + "</Preferredclass>" +
           "<mode>" + mode + "</mode>" +
               "<PreferredAirline>AI,G8,IC,6E,9W,S2,IT,9H,I7,SG</PreferredAirline>" +
           "</Request>";

                dsFilghts = objFlights.GetAvailability(xmlRequestData);
                Session["dsDomFlights"] = dsFilghts;
                if (dsFilghts.Tables.Count > 0)
                {
                    lnkModifySearch.Visible = false;
                    modifyfilter.Visible = true;
                    DataTable dtresponse = dsFilghts.Tables[0];
                    DataTable dtFlightsSegment = dsFilghts.Tables[9];
                    if (mode == "ONE")
                    {
                        if (dtresponse.Columns.Count != 4)
                        {
                            if (dtresponse.Rows[0][1] == "")
                            {


                                //  lnkModifySearch.Visible = true;
                                gdvFlights.Visible = true;
                                trFilterSearch.Visible = true;
                                tblSearch.Visible = false;
                                Oneway.Visible = true;
                                FilterBlock.Visible = true;

                                #region FareDet
                                DataTable dtFareDet = dsFilghts.Tables[6];
                                DataTable dtFareFlights = new DataTable();
                                dtFareFlights = dtFlightsSegment.Clone();
                                dtFareFlights.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                dtFareFlights = GetFareDetTable(dtFlightsSegment, dtFareDet, dsFilghts);


                                #endregion

                                DataView dvFare = dtFareFlights.DefaultView;
                                dvFare.Sort = "Fare Asc";
                                gdvFlights.DataSource = Session["dtFights"] = Session["dtFightsFare"] = dvFare.ToTable();
                                gdvFlights.DataBind();

                                BindAirportCodes(dtFlightsSegment);


                                decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                                decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);



                                minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);



                                string[] strfrom = new string[2];

                                if (Session["From"] != null)
                                {
                                    strfrom = Session["From"].ToString().Split(',');
                                }
                                else
                                {
                                    Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                                    strfrom = Session["From"].ToString().Split(',');
                                }
                                string[] strto = new string[2];
                                if (Session["To"] != null)
                                {
                                    strto = Session["To"].ToString().Split(',');
                                }
                                else
                                {
                                    Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                                    strto = Session["To"].ToString().Split(',');
                                }
                                lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                               // DateTime Date = Convert.ToDateTime(txtFromDate.Text);

                                Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtFromDate.Text;

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
                                // lnkModifySearch.Visible = true;
                                gdvFlights.Visible = false;
                                trFilterSearch.Visible = true;
                                tblSearch.Visible = false;
                                FilterBlock.Visible = true;


                                lblOnwardDepartureAirportCode.Text = lblReturnArrivalAirportCode.Text = ddlSourcesSearch.Text;
                                lblOnwardArrivalAirportCode.Text = lblReturnDepartureAirportCode.Text = ddlDestinationsSearch.Text;
                                lblOnwardTO.Visible = lblReturnTO.Visible = true;
                                RoundtripMethod();

                                BindAirportCodes(dtFlightsSegment);
                                DataTable dtFareDet = dsFilghts.Tables[6];
                                DataTable dtFareDetNon = dsFilghts.Tables[7];

                                DataTable dtNewFare = dtFareDet.Copy();
                                dtNewFare.Columns.Add("TCharge", System.Type.GetType("System.Decimal"));
                                dtNewFare.Columns.Add("Fare", System.Type.GetType("System.Decimal"));

                                for (int i = 0; i < dtFareDet.Rows.Count; i++)
                                {

                                    dtNewFare.Rows[i]["Tcharge"] = dtFareDetNon.Rows[i]["TCharge"].ToString();
                                    dtNewFare.Rows[i]["Fare"] = Convert.ToDecimal(dtFareDet.Rows[i]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[i]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[i]["STax"]) + Convert.ToDecimal(dtFareDetNon.Rows[i]["TCharge"]) + Convert.ToDecimal(dtFareDetNon.Rows[i]["TMarkup"]);//+ Convert.ToDecimal(dtFareDet.Rows[i]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[i]["TDiscount"])


                                }
                                DataView dvFare = dtNewFare.DefaultView;
                                dvFare.Sort = "Fare Asc";

                                decimal minValue = Convert.ToDecimal(dvFare[0]["Fare"]); //Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]) + Convert.ToDecimal(dtNonFareDet.Rows[0]["TCharge"]);

                                decimal maxValue = Convert.ToDecimal(dvFare[dvFare.Count - 1]["Fare"]);//Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]) + Convert.ToDecimal(dtNonFareDet.Rows[dtNonFareDet.Rows.Count - 1]["TCharge"]); 

                                minPriceLbl.InnerText = HiddenField1.Value = minValue.ToString();
                                maxPriceLbl.InnerText = HiddenField2.Value = maxValue.ToString();
                                multiHandleSliderExtenderTwo.Minimum = Convert.ToInt32(minValue);
                                multiHandleSliderExtenderTwo.Maximum = Convert.ToInt32(maxValue);
                                BindAirportCodes(dtFlightsSegment);

                                string[] strfrom = new string[2];

                                if (Session["From"] != null)
                                {
                                    strfrom = Session["From"].ToString().Split(',');
                                }
                                else
                                {
                                    Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                                    strfrom = Session["From"].ToString().Split(',');
                                }
                                string[] strto = new string[2];
                                if (Session["To"] != null)
                                {
                                    strto = Session["To"].ToString().Split(',');
                                }
                                else
                                {
                                    Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                                    strto = Session["To"].ToString().Split(',');
                                }
                                lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();

                                if (rbtnRoundTrip.Checked == true)
                                {

                                   // DateTime Date = Convert.ToDateTime(txtFromDate.Text);
                                    Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + txtFromDate.Text;
                                   // DateTime Date1 = Convert.ToDateTime(txtReturnDate.Text);


                                    Label3.Text = Label3.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + txtReturnDate.Text;
                                }
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
                else
                {
                    mp3.Show();
                    lblerror.Text = "No Records Found";
                    return;
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

    private void BindAirportCodes(DataTable dtFlightsSegment)
    {
        try
        {
           
            chkAirlines.Items.Clear();
               
            DataTable dtAirlineNames = new DataTable();
            dtAirlineNames.Columns.Add("airLineName");
            if (dtFlightsSegment.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFlightsSegment.Rows)
                {
                    if (dr["adultTaxBreakup"].ToString() != "0,0,0")
                    {
                        dtAirlineNames.ImportRow(dr);
                    }
                }

            }

            DataTable dtDistinctAirlines = dtAirlineNames.DefaultView.ToTable(true);
            for (int i = 0; i < dtDistinctAirlines.Rows.Count; i++)
            {
                //string S= dtDistinctAirlines.Rows[i][0].ToString();
                //string S1 = S.PadLeft(50 + S.Length, ' ');

                chkAirlines.Items.Add("      " + dtDistinctAirlines.Rows[i][0].ToString());
            }

            #region NumOfStops

            ChkStops.Items.Clear();
            DataTable dtStops = new DataTable();
            dtStops.Columns.Add("StopQuantity");
            if (dtFlightsSegment.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFlightsSegment.Rows)
                {
                    dtStops.ImportRow(dr);
                }
            }

            DataTable dtDistinctStops = dtStops.DefaultView.ToTable(true);
            for (int i = 0; i < dtDistinctStops.Rows.Count; i++)
            {
                ChkStops.Items.Add("      " + dtDistinctStops.Rows[i][0].ToString() + " Stop(s)");
            }
            #endregion
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnIntBookNow_Click(object sender, EventArgs e)
    {

        // gdvIntFlights.Visible = false;
        // pnlIntPassengerDet.Visible = true;
        tblSearch.Visible = false;


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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.Width =55;
                ddlTitle.ID = "ddlTitle" + i;
                ddlTitle.Items.Add("Mr.");
                ddlTitle.Items.Add("Ms.");
                ddlTitle.Items.Add("Mrs.");
                td2.Controls.Add(ddlTitle);
                ddlTitle.Attributes.Add("onchange", "javascript:AddTitle(this);");
                //td2.Width = Unit.Percentage(25);
                tr.Controls.Add(td2);

                TableCell tdFN = new TableCell();
                tdFN.Text = "FirstName :";

               


              

                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdFN);

                TableCell td3 = new TableCell();
                TextBox txtFn = new TextBox();
                txtFn.Attributes.Add("onkeyup", "javascript:AddLetters(this);");
                txtFn.MaxLength = 20;
               // txtFn.Width = 110;
                txtFn.ID = "txtFn" + i;
                td3.Controls.Add(txtFn);
                txtFn.CssClass = "lj_inp";
                // td3.Width = Unit.Percentage(25);
                tr.Controls.Add(td3);

                TableCell td6 = new TableCell();
                RequiredFieldValidator rfv2 = new RequiredFieldValidator();

                rfv2.ID = "rfv2" + i;
                rfv2.ControlToValidate = "txtFn" + i;
                rfv2.ErrorMessage = "Enter First Name";
                rfv2.Display = ValidatorDisplay.None;


                rfv2.ValidationGroup = "SubmitBook";
                td6.Controls.Add(rfv2);
                tr.Controls.Add(td6);


                TableCell td12 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fte1 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fte1.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                fte1.TargetControlID = "txtFn" + i;
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
                //txtLn.Width = 110;
                txtLn.ID = "txtLn" + i;
                string txtlnClientId = txtLn.ClientID;
                //txtLn.Attributes.Add("onchange", "javascript:CheckMinChars(" + txtlnClientId + ");");
                txtLn.Attributes.Add("onkeyup", "javascript:AddLettersLn(this);");
                txtLn.Attributes.Add("onchange", "javascript:CheckMinChars(this);");
                txtLn.CssClass = "lj_inp";
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);


                TableCell td5 = new TableCell();
                RequiredFieldValidator rfv1 = new RequiredFieldValidator();
                rfv1.ID = "rfv1" + i;
                rfv1.ControlToValidate = "txtLn" + i;
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
                fte2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                fte2.TargetControlID = "txtLn" + i;
                td12.Controls.Add(fte2);
                tr.Controls.Add(td13);

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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.ID = "ddlCTitle" + i;
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
                txtLn.MaxLength = 20;
                txtLn.CssClass = "lj_inp";
                //txtLn.Width = 110;
                txtLn.ID = "txtCLn" + i;
                td4.Controls.Add(txtLn);
                // td4.Width = Unit.Percentage(25);
                tr.Controls.Add(td4);

                TableCell tdBD = new TableCell();
                tdBD.Text = "DOB :";
                // td1.Width = Unit.Percentage(25);
                tr.Controls.Add(tdBD);


                TableCell td5 = new TableCell();
                TextBox txtBirthDate = new TextBox();
                txtBirthDate.CssClass = "lj_inp";
                txtBirthDate.Width = 90;
                txtBirthDate.ID = "txtCBirthDate" + i;
                txtBirthDate.AutoPostBack = true;
               // txtBirthDate.Attributes.Add("OnTextChanged", "GetYears(txtBirthDate.Text)");
                txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate(this);");
                txtBirthDate.Attributes.Add("onkeyup", "javascript:Adddob(this);");
                td5.Controls.Add(txtBirthDate);

                TableCell td30 = new TableCell();
                RequiredFieldValidator rfv30 = new RequiredFieldValidator();
                rfv30.ID = "rfv30" + i;
                rfv30.ControlToValidate = "txtCBirthDate" + i;
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
                lblBirthDate.ID = "lblCBirthDate" + i;
                lblBirthDate.Text = "eg : 20-Oct-2012";
                
                td5.Controls.Add(lblBirthDate);
                tr.Controls.Add(td5);


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
                rfv7.Display = ValidatorDisplay.None;
                rfv7.ValidationGroup = "SubmitBook";
                td7.Controls.Add(rfv7);
                tr.Controls.Add(td7);

                TableCell td15 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender ftec2 = new AjaxControlToolkit.FilteredTextBoxExtender();
                ftec2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                ftec2.TargetControlID = "txtCLn" + i;
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
                rfv8.ControlToValidate = "txtCFn" + i;
                rfv8.ErrorMessage = "Enter First Name";
                rfv8.Display = ValidatorDisplay.None;
                rfv8.ValidationGroup = "SubmitBook";
                td8.Controls.Add(rfv8);
                tr.Controls.Add(td8);

                TableCell td13 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender ftec1 = new AjaxControlToolkit.FilteredTextBoxExtender();
                ftec1.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                ftec1.TargetControlID = "txtCFn" + i;
                td13.Controls.Add(ftec1);
                tr.Controls.Add(td13);




                TableCell td14 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName1 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName1.ID = "vceCFirstName1" + i;
                vceCFirstName1.TargetControlID = "rfv8" + i;

                td7.Controls.Add(vceCFirstName1);
                tr.Controls.Add(td7);





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
                ddlTitle.CssClass = "lj_inp";
                ddlTitle.ID = "ddlITitle" + i;
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
                txtBirthDate.CssClass = "lj_inp";
                txtBirthDate.Width = 87;
                txtBirthDate.ID = "txtIBirthDate" + i;

              // txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate('txtIBirthDate' +i+);");
                //string txtBirthDateClientId = txtBirthDate.ClientID;
              //  txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate('txtIBirthDate1');");
                txtBirthDate.Attributes.Add("onchange", "javascript:InfantDate(this);");
                txtBirthDate.Attributes.Add("onkeyup", "javascript:Adddob(this);");


                td5.Controls.Add(txtBirthDate);

                Label lblBirthDate = new Label();
                lblBirthDate.ID = "lblIBirthDate" + i;
                lblBirthDate.Text = " eg : 20-Oct-2012";
                td5.Controls.Add(lblBirthDate);


                tr.Controls.Add(td5);
                // txtBirthDate.Attributes.Add("onkeypress", "javascript:return false");

                TableCell td30 = new TableCell();
                RequiredFieldValidator rfv32 = new RequiredFieldValidator();
                rfv32.ID = "rfv32" + i;
                rfv32.ControlToValidate = "txtIBirthDate" + i;
                rfv32.ErrorMessage = "Enter  Date Of Birth";
                rfv32.Display = ValidatorDisplay.None;
                rfv32.ValidationGroup = "SubmitBook";
                td30.Controls.Add(rfv32);
                tr.Controls.Add(td30);


                TableCell td31 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceCFirstName33 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceCFirstName33.ID = "vceCFirstName33" + i;
                vceCFirstName33.TargetControlID = "rfv32" + i;

                td31.Controls.Add(vceCFirstName33);
                tr.Controls.Add(td31);








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
                rfv10.ControlToValidate = "txtIFn" + i;
                rfv10.ErrorMessage = "Enter First Name";
                rfv10.Display = ValidatorDisplay.None;
                rfv10.ValidationGroup = "SubmitBook";
                td8.Controls.Add(rfv10);
                tr.Controls.Add(td8);


                TableCell td11 = new TableCell();
                AjaxControlToolkit.FilteredTextBoxExtender fteIc2 = new AjaxControlToolkit.FilteredTextBoxExtender();
                fteIc2.ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
                fteIc2.TargetControlID = "txtIFn" + i;
                td9.Controls.Add(fteIc2);
                tr.Controls.Add(td11);




                TableCell td12 = new TableCell();
                AjaxControlToolkit.ValidatorCalloutExtender vceIFirstName2 = new AjaxControlToolkit.ValidatorCalloutExtender();
                vceIFirstName2.ID = "vceIFirstName2" + i;
                vceIFirstName1.TargetControlID = "rfv10" + i;

                td7.Controls.Add(vceIFirstName1);
                tr.Controls.Add(td10);






                tblInfants.Controls.Add(tr);

            }
            #endregion

        }
        catch
        {

        }
    }
    public int GetYears(DateTime birthDate)
    {
        // cache the current time
        DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
        // get the difference in years
        int years = now.Year - birthDate.Year;
        // subtract another year if we're before the
        // birth day in the current year
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            --years;

        return years;

    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        if (!IsPostBack)
        {


        }
        else
        {

            CreateControls(Convert.ToInt32(Session["adultcnt"]), Convert.ToInt32(Session["childCnt"]), Convert.ToInt32(Session["infantCnt"]));
            // CreateControlsInt(adultCntInt, childCntInt, infantCntInt);

        }
    }
    #region Variables
    string FlightSegmentsID = string.Empty;
    string originDestination_Id = string.Empty;
    //string fareDetailsId = string.Empty;
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
    protected void btnBook_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];
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
                DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                if (dtNonChargeableFares.Rows.Count > 0)
                {
                    DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                    TCharge = rowNonChargeableFareDetails[0]["TCharge"].ToString();
                    TMarkup = rowNonChargeableFareDetails[0]["TMarkup"].ToString();
                    TSdiscount = rowNonChargeableFareDetails[0]["TSdiscount"].ToString();
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
                    TotalFare = (Convert.ToDecimal(actualBaseFare) + Convert.ToDecimal(tax) + Convert.ToDecimal(Stax) + Convert.ToDecimal(TCharge) + Convert.ToDecimal(TMarkup)).ToString();//+ Convert.ToDecimal(SCharge) + Convert.ToDecimal(TDiscount)
                    Session["Amount"] = TotalFare;

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


                #region SaveRequestToDBBeforePG

                string refNo = Common.GetFlightsReferenceNo("LJDF");
                Session["Order_Id"] = refNo.ToString();
                FlightBAL objFlightBal = new FlightBAL();

                objFlightBal.ReferenceNo = refNo;
                objFlightBal.TransId = string.Empty;
                objFlightBal.Status = "Pending";
                objFlightBal.AdultPax = Convert.ToInt32(ddlAdult.SelectedValue);
                objFlightBal.InfantPax = Convert.ToInt32(ddlInfant.SelectedValue);
                objFlightBal.ChildPax = Convert.ToInt32(ddlChild.SelectedValue);
                objFlightBal.Origin_Destination_Id = id;
                objFlightBal.Origin_Destination_Key = key;
                objFlightBal.ActualBasefare = Convert.ToDecimal(actualBaseFare);
                objFlightBal.Tax = Convert.ToDecimal(tax);
                objFlightBal.STax = Convert.ToDecimal(Stax);
                objFlightBal.Scharge = Convert.ToDecimal(SCharge);
                objFlightBal.TDiscount = Convert.ToDecimal(TDiscount);
                objFlightBal.TPartnerCommission = Convert.ToDecimal(TPartnerCommission);
                objFlightBal.TCharge = Convert.ToDecimal(TCharge);
                objFlightBal.TMarkUp = Convert.ToDecimal(TMarkup);
                objFlightBal.TSDiscount = Convert.ToDecimal(TSdiscount);
                string givenName = string.Empty;
                string surName = string.Empty;
                string namereference = string.Empty;
                string psgrType = string.Empty;
                string Age = string.Empty;
                string customerInfo = string.Empty;
                Table tbladults1 = (Table)this.UpdatePanel1.FindControl("tblAdults");
                for (int l = 1; l <= Convert.ToInt32(Session["adultcnt"]); l++)
                {

                    TextBox txtFn = (TextBox)tbladults1.FindControl("txtFn" + l);
                    TextBox txtLn = (TextBox)tbladults1.FindControl("txtLn" + l);
                    DropDownList ddlTitle = (DropDownList)tbladults1.FindControl("ddlTitle" + l);

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Adt" + "|" + "-";
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Adt" + "|" + "-";
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }

                Table tblChild1 = (Table)this.UpdatePanel1.FindControl("tblChild");
                for (int j = 1; j <= Convert.ToInt32(Session["childCnt"]); j++)
                {
                    TextBox txtFn = (TextBox)tblChild1.FindControl("txtCFn" + j);

                    TextBox txtLn = (TextBox)tblChild1.FindControl("txtCLn" + j);

                    DropDownList ddlTitle = (DropDownList)tblChild1.FindControl("ddlCTitle" + j);


                    TextBox txtBirthDate = (TextBox)tblChild1.FindControl("txtCBirthDate" + j);

                    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Chd" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Chd" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }

                Table tblInfants1 = (Table)this.UpdatePanel1.FindControl("tblInfants");
                for (int k = 1; k <= Convert.ToInt32(Session["infantCnt"]); k++)
                {
                    TextBox txtFn = (TextBox)tblInfants1.FindControl("txtIFn" + k);

                    TextBox txtLn = (TextBox)tblInfants1.FindControl("txtILn" + k);

                    DropDownList ddlTitle = (DropDownList)tblInfants1.FindControl("ddlITitle" + k);

                    TextBox txtBirthDate = (TextBox)tblInfants1.FindControl("txtIBirthDate" + k);
                    string age = string.Empty;
                    if (txtBirthDate != null)
                        age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();
                    else
                        age = "0";


                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Inf" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Inf" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
                }

                objFlightBal.Address = txtCity.Text + "," + txtState.Text + "," + ddlcountry.SelectedValue + "," + txtPostalCode.Text + ",";
                objFlightBal.Customer_Details = customerInfo;
                //objFlightBal.Customer_Details = "Mr.|rajini|reguri|Adt|";
                objFlightBal.telephone =txtMobileNum.Text;
                objFlightBal.emailAddress = lblEmailAddress.Text = txtEmailID.Text;
                objFlightBal.TripMode = "One";
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                if (Session["Role"] == null)
                {
                    objFlightBal.Type = "Guest";
                }
                else
                {
                    objFlightBal.Type = Session["Role"].ToString();
                }
                objFlightBal.id = id;
                objFlightBal.key = key;


                DataTable dtflightBookingId = objFlightBal.AddDomesticFlightBooking(objFlightBal);
                string flightBookingId = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();
                Session["BookingID"] = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                objFlightBal.FlightBookingID = flightBookingId.ToString();
                objFlightBal.AirEquipType = AirEquipType;
                objFlightBal.ArrivalAirportCode = ArrivalAirportCode;
                objFlightBal.ArrivalDateTime = ArrivalDateTime;
                objFlightBal.DepartureAirportCode = DepartureAirportCode;
                objFlightBal.DepartureDateTime = DepartureDateTime;
                objFlightBal.FlightNumber = FlightNumber;
                objFlightBal.OperatingAirlineCode = OperatingAirlineCode;
                objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumber;
                objFlightBal.RPH = RPH;
                objFlightBal.StopQuantity = StopQuantity;
                objFlightBal.airlineName = airLineName;
                objFlightBal.airportTax = airportTax;
                objFlightBal.imageFileName = imageFileName;
                objFlightBal.Discount = Discount;
                objFlightBal.airportTaxChild = airportTaxChild;
                objFlightBal.airportTaxInfant = airportTaxInfant;
                objFlightBal.adultTaxBreakUp = adultTaxBreakup;
                objFlightBal.ChildTaxBreakUp = childTaxBreakup;
                objFlightBal.InfantTaxBreakUp = infantTaxBreakup;
                objFlightBal.ocTax = octax;
                objFlightBal.Availability = BookingClassAvailability;
                objFlightBal.ResBookingCode = BookingClassResBookDesigCode;
                objFlightBal.adultFare = adultFare;
                objFlightBal.bookingClass = bookingclass;
                objFlightBal.ChildFare = childFare;
                objFlightBal.ClassType = classType;
                objFlightBal.farebasisCode = farebasiscode;
                objFlightBal.infantFare = infantfare;
                objFlightBal.Fare_Rule = Rule;
                objFlightBal.adultCommission = adultCommission;
                objFlightBal.childCommission = childCommission;
                objFlightBal.CommissionOnTCharge = commissionOnTCharge;
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);


                bool res = objFlightBal.AddDomesticFlightBookingsegments(objFlightBal);


                if (res)
                {
                    try
                    {
                        if (Page.IsValid)
                        {
                            // Response.Redirect("~/pay.aspx?val=Dom", false); //Uncomment it 
                            #region Checking the roles and booking the tickets

                              if (Session["Role"] == null)
                            {
                                Response.Redirect("~/pay.aspx?val=Dom", false);
                            }
                          else  if (Session["Role"].ToString() == "User")
                            {
                                objBAL = new ClsBAL();
                                DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                                Session["AgentId_Agent"] = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
                                Response.Redirect("~/pay.aspx?val=Dom", false);
                            }
                            else if (Session["Role"].ToString() == "Admin")
                            {
                                save(sender, e);
                            }
                            else if (Session["Role"].ToString() == "Agent")
                            {
                                DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                                DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airLineName.ToString()); // Change it
                                string commisionPercentage = string.Empty;
                              
                                if (dsCommSlab != null)
                                {
                                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                                    {
                                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
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


                                string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                                string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                                string actualFare = TotalFare;
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
                                DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airLineName.ToString()); // Change it
                                string commisionPercentage = string.Empty;
                                if (dsCommSlab != null)
                                {
                                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                                    {
                                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
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

                                string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                                string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                                string actualFare = TotalFare;
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
                            lblMsg.Text = "Enter Valid Data";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        //  LogError("frmSearchBus.aspx", "paymentgateway", DateTime.Now, ex.Message.ToString());
                        // lblMsg1.Visible = true;
                        // lblMsg1.Text = "Error in the payment gateway";
                    }
                }

                #endregion
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
    string Customer_Details = string.Empty;
    string emailAddress = string.Empty;
    string telephone = string.Empty;
    string id1 = string.Empty;
    string refNo = string.Empty;
    private void save(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            FlightBAL objFlightsBal = new FlightBAL();
            string ReferenceNo = Convert.ToString(Session["Order_Id"]);
            DataSet dtid = objFlightsBal.IGetInternationalFlightDetails(ReferenceNo);

            id1 = dtid.Tables[0].Rows[0]["id"].ToString();
            key = dtid.Tables[0].Rows[0]["Key1"].ToString();
            string[] strfare = dtid.Tables[0].Rows[0]["ActualBasefare"].ToString().Split('.');
            actualBaseFare = strfare[0].ToString();
            string[] strtax = dtid.Tables[0].Rows[0]["Tax"].ToString().Split('.');
            tax = strtax[0].ToString();
            string[] strstax = dtid.Tables[0].Rows[0]["STax"].ToString().Split('.');
            Stax = strstax[0].ToString();
            string[] strscharge = dtid.Tables[0].Rows[0]["Scharge"].ToString().Split('.');
            SCharge = strscharge[0].ToString();
            string[] strtdis = dtid.Tables[0].Rows[0]["TDiscount"].ToString().Split('.');
            TDiscount = strtdis[0].ToString();
            string[] strtcomm = dtid.Tables[0].Rows[0]["TPartnerCommission"].ToString().Split('.');
            TPartnerCommission = strtcomm[0].ToString();
            string[] strtsdis = dtid.Tables[0].Rows[0]["TSDiscount"].ToString().Split('.');
            TSdiscount = strtsdis[0].ToString();

            string[] strmark = dtid.Tables[0].Rows[0]["TMarkUp"].ToString().Split('.');
            TMarkup = strmark[0].ToString();
            string[] strtcharge = dtid.Tables[0].Rows[0]["TCharge"].ToString().Split('.');
            TCharge = strtcharge[0].ToString();
            Customer_Details = dtid.Tables[0].Rows[0]["Customer_Details"].ToString();
            telephone = dtid.Tables[0].Rows[0]["telephone"].ToString();
            emailAddress = dtid.Tables[0].Rows[0]["emailAddress"].ToString();

            adultcnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["AdultPax"]);
            infantCnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["InfantPax"]);
            childCnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["ChildPax"]);
            refNo = dtid.Tables[0].Rows[0]["ReferenceNo"].ToString();


            string ReferenceNo1 = dtid.Tables[0].Rows[0]["Dom_Booking_Id"].ToString();
            DataSet dsdbsave = objFlightsBal.GetInternationalFlightDetailsI1(ReferenceNo1);


            AirEquipType = dsdbsave.Tables[0].Rows[0]["AirEquipType"].ToString();
            ArrivalAirportCode = dsdbsave.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
            // ArrivalAirportName = dsdbsave.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
            ArrivalDateTime = dsdbsave.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
            DepartureAirportCode = dsdbsave.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
            //  DepartureAirportName = dsdbsave.Tables[0].Rows[0]["DepartureAirportName"].ToString();
            DepartureDateTime = dsdbsave.Tables[0].Rows[0]["DepartureDateTime"].ToString();
            FlightNumber = dsdbsave.Tables[0].Rows[0]["FlightNumber"].ToString();
            // MarketingAirlineCode = dsdbsave.Tables[0].Rows[0]["MarketingAirlineCode"].ToString();
            OperatingAirlineCode = dsdbsave.Tables[0].Rows[0]["OperatingAirlineCode"].ToString();
            airLineName = dsdbsave.Tables[0].Rows[0]["airlineName"].ToString();
            OperatingAirlineFlightNumber = dsdbsave.Tables[0].Rows[0]["OperatingAirlineFlightNumber"].ToString();
            RPH = dsdbsave.Tables[0].Rows[0]["RPH"].ToString();
            StopQuantity = dsdbsave.Tables[0].Rows[0]["StopQuantity"].ToString();
            airportTax = dsdbsave.Tables[0].Rows[0]["airportTax"].ToString();
            imageFileName = dsdbsave.Tables[0].Rows[0]["imageFileName"].ToString();
            string[] strdis = dsdbsave.Tables[0].Rows[0]["Discount"].ToString().Split('.');
            Discount = strdis[0].ToString();
            airportTaxChild = dsdbsave.Tables[0].Rows[0]["airportTaxChild"].ToString();
            airportTaxInfant = dsdbsave.Tables[0].Rows[0]["airportTaxInfant"].ToString();
            airportTaxChild = dsdbsave.Tables[0].Rows[0]["airportTaxChild"].ToString();
            airportTaxInfant = dsdbsave.Tables[0].Rows[0]["airportTaxInfant"].ToString();
            childTaxBreakup = dsdbsave.Tables[0].Rows[0]["ChildTaxBreakUp"].ToString();
            infantTaxBreakup = dsdbsave.Tables[0].Rows[0]["InfantTaxBreakUp"].ToString();
            adultTaxBreakup = dsdbsave.Tables[0].Rows[0]["adultTaxBreakUp"].ToString();
            octax = dsdbsave.Tables[0].Rows[0]["ocTax"].ToString();
            BookingClassResBookDesigCode = dsdbsave.Tables[0].Rows[0]["ResBookingCode"].ToString();
            string[] stradultfare = dsdbsave.Tables[0].Rows[0]["adultFare"].ToString().Split('.');
            adultFare = stradultfare[0].ToString();


            BookingClassAvailability = dsdbsave.Tables[0].Rows[0]["Availability"].ToString();
            string[] strchildfare = dsdbsave.Tables[0].Rows[0]["ChildFare"].ToString().Split('.');
            childFare = strchildfare[0].ToString();
            bookingclass = dsdbsave.Tables[0].Rows[0]["bookingClass"].ToString();
            classType = dsdbsave.Tables[0].Rows[0]["ClassType"].ToString();
            farebasiscode = dsdbsave.Tables[0].Rows[0]["farebasisCode"].ToString();
            string[] strinffare = dsdbsave.Tables[0].Rows[0]["infantFare"].ToString().Split('.');
            infantfare = strinffare[0].ToString();

            Rule = dsdbsave.Tables[0].Rows[0]["Fare_Rule"].ToString();
            string[] stradultcomm = dsdbsave.Tables[0].Rows[0]["adultCommission"].ToString().Split('.');
            adultCommission = stradultcomm[0].ToString();
            string[] strchildcomm = dsdbsave.Tables[0].Rows[0]["childCommission"].ToString().Split('.');
            childCommission = strchildcomm[0].ToString();
            string[] strcommoncharge = dsdbsave.Tables[0].Rows[0]["CommissionOnTCharge"].ToString().Split('.');
            commissionOnTCharge = strcommoncharge[0].ToString();



            #region Pricing

            String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id1 + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/> <telePhone>" + telephone + "</telePhone><email>" + emailAddress + "</email> <creditcardno></creditcardno><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";
            DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);

            if (dsFlightPricing.Tables.Count > 0)
            {

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
                    DataTable dtchangepriceNon = dsFlightPricing.Tables[5];
                    if (dtchangeprice.Rows.Count > 0)
                    {
                        DataRow[] rowchangeprices = dtchangeprice.Select("FareDetails_Id=" + fareDetailsId);
                        DataRow[] rowchangepricesNon = dtchangepriceNon.Select("FareDetails_Id=" + fareDetailsId);
                        TPartnerCommission = rowchangeprices[0]["TPartnerCommission"].ToString();
                        actualBaseFare = rowchangeprices[0]["ActualBaseFare"].ToString();
                        tax = rowchangeprices[0]["Tax"].ToString();
                        Stax = rowchangeprices[0]["Stax"].ToString();
                        SCharge = rowchangeprices[0]["SCharge"].ToString();
                        TDiscount = rowchangeprices[0]["TDiscount"].ToString();
                        TCharge = rowchangepricesNon[0]["TCharge"].ToString();
                        TMarkup = rowchangepricesNon[0]["TMarkup"].ToString();
                        TotalFare = (Convert.ToDecimal(actualBaseFare) + Convert.ToDecimal(tax) + Convert.ToDecimal(Stax) + Convert.ToDecimal(TCharge) + Convert.ToDecimal(TMarkup)).ToString();//Convert.ToDecimal(SCharge) + Convert.ToDecimal(TDiscount) +
                    }
                }
            }


            #endregion




            String xmlRequestData = "<Bookingrequest><onwardFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare> <Tax>" + tax + "</Tax><STax>" + Stax + "</STax> <SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TSdiscount + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + id1 + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/><personName>";


            // Dynamic generation of names of adults, infants , Child

            string strname = dtid.Tables[0].Rows[0]["Customer_Details"].ToString();
            string[] strrows = strname.ToString().Split(';');
            int id = strrows.Count();
            for (int m = 0; m < id; m++)
            {
                if (strrows[m].ToUpper().Contains("ADT"))
                {
                    string[] stradt = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + stradt[1].ToString() + "</givenName><surName>" + stradt[2].ToString() + "</surName><nameReference>" + stradt[0].ToString() + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }
                if (strrows[m].ToUpper().Contains("CHD"))
                {
                    string[] strchd = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + strchd[1].ToString() + "</givenName><surName>" + strchd[2].ToString() + "</surName><nameReference>" + strchd[0].ToString() + "</nameReference><dob>" + strchd[5].ToString() + "</dob><age>" + strchd[4].ToString() + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }
                if (strrows[m].ToUpper().Contains("INF"))
                {
                    string[] strinf = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + strinf[1].ToString() + "</givenName><surName>" + strinf[2].ToString() + "</surName><nameReference>" + strinf[0].ToString() + "</nameReference><dob>" + strinf[5].ToString() + "</dob><age>" + strinf[4].ToString() + "</age><psgrtype>inf</psgrtype></CustomerInfo>";

                }
            }

            xmlRequestData = xmlRequestData + "</personName><telePhone><phoneNumber>" + telephone + "</phoneNumber></telePhone><email><emailAddress>" + emailAddress + "</emailAddress></email><creditcardno></creditcardno><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword> <partnerRefId>" + ReferenceNo + "</partnerRefId> <Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + ddlAdult.SelectedItem.Value + "</AdultPax><ChildPax>" + ddlChild.SelectedItem.Value + "</ChildPax><InfantPax>" + ddlInfant.SelectedItem.Value + "</InfantPax></Bookingrequest>";
            DataSet dsBookingResponse = new DataSet();





            dsBookingResponse = objFlights.GetBookingDetails(xmlRequestData);

            string error = string.Empty;


            // If there is any Error -- We wont get the transid instead we get error
            if (dsBookingResponse.Tables[0].Columns.Contains("transid"))
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
                                                    Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
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
                            DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                                Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                        else if (Session["Role"].ToString() == "Admin")
                        {
                            DeductAgentBalance(0, Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                               Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                    }
                }
                else if (Session["Role"] == null)
                {
                    DeductAgentBalance(0, Convert.ToDouble("0.00"), 0, refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                              Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                }
                #endregion

                objFlightsBal.TransId = dsBookingResponse.Tables[0].Rows[0]["transid"].ToString();
                objFlightsBal.Status = dsBookingResponse.Tables[0].Rows[0]["status"].ToString();
                objFlightsBal.ReferenceNo = Convert.ToString(Session["Order_Id"]);
                if (objFlightsBal.Status == "SUCCESS")
                {
                    objFlightsBal.UpdateDomesticFlightBooking(objFlightsBal);
                    GetBookingStatus(objFlightsBal.ReferenceNo);
                }
                else
                {
                    objFlightsBal.UpdateDomesticFlightBooking(objFlightsBal);
                }


                GetDetailsForPrint(Convert.ToString(Session["Order_Id"]));
                lbtnmail.Visible = false;
                lbtnmail_Click1(sender, e);
                pnlPassengerDet.Visible = false;
                pnlSearch.Visible = false;
                lblStatus.Visible = true;
                lblStatus.Text = "Ticket has been booked successfully. Reference Number is : " + Convert.ToString(Session["Order_Id"]);
                lblStatus.ForeColor = System.Drawing.Color.Green;
                //  Response.Redirect("Pay.aspx", false);             



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

    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare,
          double commisionFare, double  commisionPercentage)
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
        String xmlRequestData = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100200</partnerRefId></EticketRequest>";
        DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);
        lblMsg.Visible = true;
        lblMsg.Text = dsFlightBookStatus.Tables[0].Rows[0]["Status"].ToString();
    }
    protected void btnCancelTicket_Click(object sender, EventArgs e)
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
    protected void btnCancelTicketStatus_Click(object sender, EventArgs e)
    {
        transId = "A410697";
        String xmlCancelReqStatus = "<EticketCanStatusReq><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>" + transId + "</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
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

    private void BindModifySearch()
    {
        try
        {
            ddlSourcesSearch.Text = ddlSources.Text;
            ddlDestinationsSearch.Text = ddlDestinations.Text;
            txtdatesearch.Text = txtFromDate.Text;
            txtretundatesearch.Text = txtReturnDate.Text;
            ddladultsintsearch.SelectedValue = ddlAdult.SelectedValue;
            ddlchildintsearch.SelectedValue = ddlChild.SelectedValue;
            ddlinfantsintsearch.SelectedValue = ddlInfant.SelectedValue;
            rbonesearch.Checked = rbtnOneWay.Checked;
            rbreturnsearch.Checked = rbtnRoundTrip.Checked;
            ddlIntCabinTypesearch.SelectedValue = ddlCabin_type.SelectedValue;
            return1.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }

    private void BindSearch()
    {
        try
        {

            ddlSources.Text = ddlSourcesSearch.Text;
            ddlDestinations.Text = ddlDestinationsSearch.Text;
            txtFromDate.Text = txtdatesearch.Text;
            txtReturnDate.Text = txtretundatesearch.Text;
            ddlAdult.SelectedValue = ddladultsintsearch.SelectedValue;
            ddlChild.SelectedValue = ddlchildintsearch.SelectedValue;
            ddlInfant.SelectedValue = ddlinfantsintsearch.SelectedValue;
            rbtnOneWay.Checked = rbonesearch.Checked;
            rbtnRoundTrip.Checked = rbreturnsearch.Checked;
            ddlCabin_type.SelectedValue = ddlIntCabinTypesearch.SelectedValue;
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkModifySearch_Click(object sender, EventArgs e)
    {

        ModifySearch.Visible = true;
        ClearSearchFields();
        BindModifySearch();
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
    private void ClearSearchFields()
    {
        ddlSourcesSearch.Text = string.Empty;
        ddlDestinationsSearch.Text = string.Empty;
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
    protected void GetDetailsForPrint(string RefNo)
    {
        try
        {
            FlightBAL objFlightsBAL = new FlightBAL();
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetDomesticFlightDetails(RefNo.Trim());


            if (dsFlights.Tables[0].Rows.Count > 0)
            {
                printroundtrip.Visible = false;
                string customerDetails = dsFlights.Tables[0].Rows[0]["Customer_Details"].ToString();
                string[] strArryCustDet = customerDetails.Split('|');
                lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                lblTel.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();
                lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();

                lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();


                lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["airlineName"].ToString();
                img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                lblDepartureDate.Text = dt.ToString("dd/MM/yyyy");
                lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                lblArrivalDate.Text = strArrivalDatetime[0].ToString();
                lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                // lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
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
                
                lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]).ToString()); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                lblTotal.Text = (Convert.ToDouble(lblBasicFare.Text) + Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TCharge"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TMarkup"])).ToString("####0.00");//+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())
                pnlViewticket.Visible = true;
            }
            //return en





            if (dsFlights.Tables[0].Rows.Count == 2)
            {
                //return 

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    printroundtrip.Visible = true;
                    lblAirlineNamereturn.Text = dsFlights.Tables[0].Rows[1]["airlineName"].ToString();
                    //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumberreturn.Text = dsFlights.Tables[0].Rows[1]["FlightNumber"].ToString();
                    lblOriginRet.Text = dsFlights.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
                    lblDestinationRet.Text = dsFlights.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();

                    string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                    DateTime dt = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                    lblDepartureDatereturn.Text = dt.ToString("dd/MM/yyyy");
                    lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                    lblArrivalDatereturn.Text = strArrivalDatetimeRet[0].ToString();
                    lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                    // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();
                    string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                    string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                    string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]).ToString()); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["SchargeRet"])).ToString();
                    string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TCharge"].ToString()) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TMarkup"].ToString())).ToString("####0.00"); //Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString()) +
                    lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                    lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                    lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                    lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");
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
            try
            {
                string FlightSegmentsID = string.Empty;
                string originDestination_Id = string.Empty;
                string fareDetailsId = string.Empty;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label FlightSegments_ID = (Label)e.Row.FindControl("lblFlightSegments_ID");

                    Label adulttaxbreakup = (Label)e.Row.FindControl("lbladulttaxbreakup");
                    Label lbldepartsort = (Label)e.Row.FindControl("lbldepartsort");
                    if (adulttaxbreakup.Text != "0,0,0")
                    {
                      //  DataTable dtFlightsSegment = dsFilghts.Tables[9];

                        DataTable dtFlightsSegment = (DataTable)Session["DtOnwardFlights"];

                        if (dtFlightsSegment.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                            DataTable dtinnergrid = dtFlightsSegment.Clone();
                            foreach (DataRow item in rowFilghtSegment)
                            {
                                dtinnergrid.ImportRow(item);
                            }
                            GridView gdvonwardconflights = (GridView)e.Row.FindControl("gdvonwardconflights");
                            gdvonwardconflights.DataSource = dtinnergrid;
                            gdvonwardconflights.DataBind();
                            //FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                        }

                        DataTable dtFlightSegments = dsFilghts.Tables[8];
                        if (dtFlightSegments.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                            originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                        }
                        DataTable dtFareDetails = dsFilghts.Tables[5];
                        if (dtFareDetails.Rows.Count > 0)
                        {
                            DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                            fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                        }

                        DataTable dtChargeableFares = dsFilghts.Tables[6];
                        DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                        if (dtChargeableFares.Rows.Count > 0)
                        {
                            DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                            DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                            Label airlinename = (Label)e.Row.FindControl("lblAirlineNameonwardMrk");
                            Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                            Label lblTax = (Label)e.Row.FindControl("lblTax");
                            Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                            Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                            Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                            Label lblFare = (Label)e.Row.FindControl("lblFare");

                            Label lblTChargeRet3 = (Label)e.Row.FindControl("lblTChargeRet3");


                            lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                            lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                            lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                            lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                            lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");
                            lblTChargeRet3.Text = (Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");

                            double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]);//Convert.ToDouble(lblSCharge.Text) + Convert.ToDouble(lblTDiscount.Text) +
                            lblTotal.Text = lblFare.Text = total.ToString("####0.00");



                            #region Calculating the HNF and snf for onward flight in domestic



                            if (Session["UserID"] != null)
                            {
                                if (Session["Role"].ToString() == "Agent")
                                {
                                    DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights","");
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

                                    Label lblHNFFareonward = (Label)e.Row.FindControl("lblHNFFareonward");
                                    Label lblAgentcommonward = (Label)e.Row.FindControl("lblAgentcommonward");
                                    double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                                    double DeductAmount = total - CommissionFare;
                                    double newagentcommonward = total - DeductAmount;
                                    lblHNFFareonward.Text = DeductAmount.ToString("####0.00");
                                    lblAgentcommonward.Text = "Comm:" + newagentcommonward.ToString("####0");
                                  

                                    //#region Adding mark up price of agent
                                    //Class1 objBal = new Class1();
                                    //objBal.ScreenInd = Master123.gettopmarkup;
                                    //objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                                    //objBal.Type = "Domestic Flights";
                                    //objDataSet = (DataSet)objBal.fnGetData();
                                    //string markUpAmount = "0";
                                    //ViewState["MarkUp"] = markUpAmount;
                                    //if (objDataSet != null)
                                    //{
                                    //    if (objDataSet.Tables.Count > 0)
                                    //    {
                                    //        if (objDataSet.Tables[0].Rows.Count > 0)
                                    //        {

                                    //            markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                                    //            ViewState["MarkUp"] = markUpAmount;
                                    //            if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                                    //            {
                                    //                lblTChargeRet3.Text = (Convert.ToDouble(lblTChargeRet3.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                                    //            }
                                    //            else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                                    //            {
                                    //                lblTChargeRet3.Text = (Convert.ToDouble(lblTChargeRet3.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                                    //            }
                                    //            double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTChargeRet3.Text);
                                    //            lblFare.Text = lblTotal.Text = total1.ToString("####0.00");
                                    //        }
                                    //    }
                                    //}


                                    //#endregion
                                }
                            }
                            #endregion

                            #region Adding mark up price of agent
                            Class1 objBal = new Class1();
                            objBal.ScreenInd = Master123.gettopmarkup;
                            objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                            objBal.Type = "Domestic Flights";
                            objDataSet = (DataSet)objBal.fnGetData();
                            string markUpAmount = "0";
                            ViewState["MarkUp"] = markUpAmount;
                            if (objDataSet != null)
                            {
                                if (objDataSet.Tables.Count > 0)
                                {

                                    markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                                    ViewState["MarkUp"] = markUpAmount;
                                  
                                        lblTChargeRet3.Text = (Convert.ToDouble(lblTChargeRet3.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                                   
                                   
                                    double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTChargeRet3.Text);
                                    lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                                }
                            }


                            #endregion


                        }
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }

                    #region old
                    //dsFilghts = (DataSet)Session["dsDomFlights"];

                    //Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
                    //Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    //Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    //Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                    //Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");
                    //Label airlinename = (Label)e.Row.FindControl("lblAirlineName");

                    //DataTable dtFlightsSegment = (DataTable)Session["DtOnwardFlights"];

                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {
                    //        lblConnectingAirportCode.Visible = true;
                    //        lblHyphen.Visible = true;
                    //        lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                    //        lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                    //        lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                    //        lblConnectingFlights.Visible = true;

                    //        string destinatonsearch = ddlDestinationsSearch.Text.Substring(ddlDestinationsSearch.Text.IndexOf("(") + 1, 3);

                    //        if (lblArrivalAirportCode.Text != destinatonsearch)
                    //        {
                    //            e.Row.Visible = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblConnectingAirportCode.Visible = false;
                    //        lblHyphen.Visible = false;
                    //        lblConnectingFlights.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblConnectingFlights.Visible = false;
                    //}
                    //if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //{
                    //    e.Row.Visible = false;
                    //}

                    //Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    //DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    //string[] time = lblDepartTime.Text.ToString().Split('T');
                    //lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);

                    //Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
                    //DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    //string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    //lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);

                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {

                    //        string arrTime1 = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();
                    //        string[] Arrtime1 = arrTime1.ToString().Split('T');
                    //        lblArrivalTime.Text = Arrtime1[1].ToString().Substring(0, Arrtime1[1].ToString().Length - 3);
                    //    }
                    //}

                    //LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
                    //int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

                    //DataTable dtBookingFareRules = dsFilghts.Tables[11];
                    //if (dtBookingFareRules.Rows.Count > 0)
                    //{
                    //    DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                    //    Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                    //    lblFareRules.Text = row[0]["Rule"].ToString();
                    //}


                    //if (dtFlightsSegment.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + FlightSegmentId);
                    //    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                    //}

                    //DataTable dtFlightSegments = dsFilghts.Tables[8];
                    //if (dtFlightSegments.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                    //    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                    //}
                    //DataTable dtFareDetails = dsFilghts.Tables[5];
                    //if (dtFareDetails.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    //    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                    //}
                    //DataTable dtChargeableFares = dsFilghts.Tables[6];
                    //DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                    //if (dtChargeableFares.Rows.Count > 0)
                    //{
                    //    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                    //    DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);

                    //    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                    //    Label lblTax = (Label)e.Row.FindControl("lblTax");
                    //    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                    //    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                    //    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                    //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    //    Label lblFare = (Label)e.Row.FindControl("lblFare");

                    //    Label lblTChargeRet3 = (Label)e.Row.FindControl("lblTChargeRet3");


                    //    lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                    //    lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                    //    lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                    //    lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                    //    lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");
                    //    lblTChargeRet3.Text = (Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");

                    //    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]);//Convert.ToDouble(lblSCharge.Text) + Convert.ToDouble(lblTDiscount.Text) +
                    //    lblTotal.Text = lblFare.Text = total.ToString("####0.00");

                    //    #region Calculating the HNF
                    //    if (Session["UserID"] != null)
                    //    {
                    //        if (Session["Role"].ToString() == "Agent")
                    //        {
                    //            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airlinename.Text.ToString());
                    //            string commisionPercentage = string.Empty;
                    //            if (dsCommSlab.Tables[0].Rows.Count > 0)
                    //                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                    //            else
                    //                commisionPercentage = "0";

                    //            Label lblHNFFareonward = (Label)e.Row.FindControl("lblHNFFareonward");
                    //            double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                    //            double DeductAmount = total - CommissionFare;
                    //            lblHNFFareonward.Text = DeductAmount.ToString("####0.00");

                    //            #region Adding mark up price of agent
                    //            Class1 objBal = new Class1();
                    //            objBal.ScreenInd = Master123.gettopmarkup;
                    //            objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                    //            objBal.Type = "Domestic Flights";
                    //            objDataSet = (DataSet)objBal.fnGetData();
                    //            string markUpAmount = "0";
                    //            ViewState["MarkUp"] = markUpAmount;
                    //            if (objDataSet != null)
                    //            {
                    //                if (objDataSet.Tables.Count > 0)
                    //                {

                    //                    markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                    //                    ViewState["MarkUp"] = markUpAmount;
                    //                    if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                    //                    {
                    //                        lblTChargeRet3.Text = (Convert.ToDouble(lblTChargeRet3.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                    //                    {
                    //                        lblTChargeRet3.Text = (Convert.ToDouble(lblTChargeRet3.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTChargeRet3.Text);
                    //                    lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                    //                }
                    //            }


                    //            #endregion
                    //        }
                    //    }
                    //    #endregion

                    //}
                    DataTable dtactivedetails = dsFilghts.Tables[1];
                    Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                    Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                    Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                    Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                    lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                    lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                    lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                    lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();

                    #endregion

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
    protected void gdvReturn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                string FlightSegmentsID = string.Empty;
                string originDestination_Id = string.Empty;
                string fareDetailsId = string.Empty;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label FlightSegments_ID = (Label)e.Row.FindControl("lblFlightSegments_ID");

                    Label adulttaxbreakup = (Label)e.Row.FindControl("lbladulttaxbreakup");
                    Label lbldepartsort = (Label)e.Row.FindControl("lbldepartsort");
                    if (adulttaxbreakup.Text != "0,0,0")
                    {
                        Label airlinename = (Label)e.Row.FindControl("lblAirlineNamereturn");
                        DataTable dtFlightsSegment = (DataTable)Session["DtReturnFlights"];

                        if (dtFlightsSegment.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                            DataTable dtinnergrid = dtFlightsSegment.Clone();
                            foreach (DataRow item in rowFilghtSegment)
                            {
                                dtinnergrid.ImportRow(item);
                            }
                            GridView gdvreturnconflights = (GridView)e.Row.FindControl("gdvreturnconflights");
                            gdvreturnconflights.DataSource = dtinnergrid;
                            gdvreturnconflights.DataBind();
                            //FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                        }

                        DataTable dtFlightSegments = dsFilghts.Tables[8];
                        if (dtFlightSegments.Rows.Count > 0)
                        {
                            DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_ID = '" + FlightSegments_ID.Text + "'");
                            originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                        }
                        DataTable dtFareDetails = dsFilghts.Tables[5];
                        if (dtFareDetails.Rows.Count > 0)
                        {
                            DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                            fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                        }

                        DataTable dtChargeableFares = dsFilghts.Tables[6];
                        DataTable dtNonChargeableFares = dsFilghts.Tables[7];
                        if (dtChargeableFares.Rows.Count > 0)
                        {
                            DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                            DataRow[] rowNonChargeableFareDetails = dtNonChargeableFares.Select("FareDetails_Id=" + fareDetailsId);


                            Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                            Label lblTax = (Label)e.Row.FindControl("lblTax");
                            Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                            Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                            Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                            Label lblFare = (Label)e.Row.FindControl("lblFare");

                            Label lblTChargeRet = (Label)e.Row.FindControl("lblTChargeRet");


                            lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                            lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                            lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                            lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                            lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");
                            lblTChargeRet.Text = (Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"])).ToString("####0.00");

                            double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TCharge"]) + Convert.ToDouble(rowNonChargeableFareDetails[0]["TMarkup"]);//Convert.ToDouble(lblSCharge.Text) + Convert.ToDouble(lblTDiscount.Text) +
                            lblTotal.Text = lblFare.Text = total.ToString("####0.00");

                            #region Calculating the HNF for return flight in domestic
                            if (Session["UserID"] != null)
                            {
                                if (Session["Role"].ToString() == "Agent")
                                {
                                    DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", "");
                                    string commisionPercentage = string.Empty;
                                    if (dsCommSlab.Tables[0].Rows.Count > 0)
                                        commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                                    else
                                        commisionPercentage = "0";

                                    Label lblHNFFarereturn = (Label)e.Row.FindControl("lblHNFFarereturn");
                                    Label lblAgentcommreturn = (Label)e.Row.FindControl("lblAgentcommreturn");

                                    double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                                    double DeductAmount = total - CommissionFare;
                                   // lblHNFFarereturn.Text = DeductAmount.ToString("####0.00");
                                    lblAgentcommreturn.Text = "Comm:" + CommissionFare.ToString("####0");


                                }
                            }
                            #endregion

                            #region Adding mark up price of agent
                                        Class1 objBal = new Class1();
                                        objBal.ScreenInd = Master123.gettopmarkup;
                                        objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                                        objBal.Type = "Domestic Flights";
                                        objDataSet = (DataSet)objBal.fnGetData();
                                        string markUpAmount = "0";
                                        ViewState["MarkUp"] = markUpAmount;
                                        if (objDataSet != null)
                                        {
                                            if (objDataSet.Tables.Count > 0)
                                            {

                                                markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                                                ViewState["MarkUp"] = markUpAmount;
                                               
                                                lblTChargeRet.Text = (Convert.ToDouble(lblTChargeRet.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                                                
                                               
                                                double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTChargeRet.Text);
                                                lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                                            }
                                        }


                                        #endregion
                              



                            


                        }
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                    #region old
                    //dsFilghts = (DataSet)Session["dsDomFlights"];
                    //Label lblConnectingAirportCode = (Label)e.Row.FindControl("lblConnectingAirportCode");
                    //Label lblDepartureAirportCode = (Label)e.Row.FindControl("lblDepartureAirportCode");
                    //Label lblArrivalAirportCode = (Label)e.Row.FindControl("lblArrivalAirportCode");
                    //Label lblConnectingFlights = (Label)e.Row.FindControl("lblConnectingFlights");
                    //Label lblHyphen = (Label)e.Row.FindControl("lblHyphen");
                    //Label airlinename = (Label)e.Row.FindControl("lblAirlineName");
                    //DataTable dtFlightsSegment = (DataTable)Session["DtReturnFlights"];
                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {
                    //        lblConnectingAirportCode.Visible = true;
                    //        lblHyphen.Visible = true;
                    //        lblConnectingAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["ArrivalAirportCode"].ToString();
                    //        lblDepartureAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex]["DepartureAirportCode"].ToString();
                    //        lblArrivalAirportCode.Text = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalAirportCode"].ToString();
                    //        lblConnectingFlights.Visible = true;

                    //        string SourcesSearch = ddlSourcesSearch.Text.Substring(ddlSourcesSearch.Text.IndexOf("(") + 1, 3);

                    //        if (lblArrivalAirportCode.Text != SourcesSearch)
                    //        {
                    //            e.Row.Visible = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblConnectingAirportCode.Visible = false;
                    //        lblHyphen.Visible = false;
                    //        lblConnectingFlights.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lblConnectingFlights.Visible = false;
                    //}
                    //if (dtFlightsSegment.Rows[e.Row.RowIndex]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //{
                    //    e.Row.Visible = false;
                    //}

                    //Label lblDepartTime = (Label)e.Row.FindControl("lblDepartTime");
                    //DateTime dtDepart = Convert.ToDateTime(lblDepartTime.Text);
                    //string[] time = lblDepartTime.Text.ToString().Split('T');
                    //lblDepartTime.Text = time[1].ToString().Substring(0, time[1].ToString().Length - 3);


                    //Label lblArrivalTime = (Label)e.Row.FindControl("lblArrivalTime");
                    //DateTime dtArrive = Convert.ToDateTime(lblArrivalTime.Text);
                    //string[] Arrtime = lblArrivalTime.Text.ToString().Split('T');
                    //lblArrivalTime.Text = Arrtime[1].ToString().Substring(0, Arrtime[1].ToString().Length - 3);

                    //if (e.Row.RowIndex + 1 <= dtFlightsSegment.Rows.Count - 1)
                    //{
                    //    if (dtFlightsSegment.Rows[e.Row.RowIndex + 1]["adultTaxBreakUp"].ToString() == "0,0,0")
                    //    {

                    //        string arrTime1 = dtFlightsSegment.Rows[e.Row.RowIndex + 1]["ArrivalDateTime"].ToString();
                    //        string[] Arrtime1 = arrTime1.ToString().Split('T');
                    //        lblArrivalTime.Text = Arrtime1[1].ToString().Substring(0, Arrtime1[1].ToString().Length - 3);
                    //    }
                    //}

                    //LinkButton lnkFareRule = (LinkButton)e.Row.FindControl("lnkFareRule");
                    //int FlightSegmentId = Convert.ToInt32(lnkFareRule.CommandArgument);

                    //DataTable dtBookingFareRules = dsFilghts.Tables[11];
                    //if (dtBookingFareRules.Rows.Count > 0)
                    //{
                    //    DataRow[] row = dtBookingFareRules.Select("FlightSegment_ID=" + FlightSegmentId);

                    //    Label lblFareRules = (Label)e.Row.FindControl("lblFareRules");
                    //    lblFareRules.Text = row[0]["Rule"].ToString();
                    //}


                    //if (dtFlightsSegment.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegment = dtFlightsSegment.Select("FlightSegment_ID=" + FlightSegmentId);
                    //    FlightSegmentsID = rowFilghtSegment[0]["FlightSegments_Id"].ToString();
                    //}

                    //DataTable dtFlightSegments = dsFilghts.Tables[8];
                    //if (dtFlightSegments.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFilghtSegments = dtFlightSegments.Select("FlightSegments_Id=" + FlightSegmentsID);
                    //    originDestination_Id = rowFilghtSegments[0]["OriginDestinationOption_Id"].ToString();
                    //}
                    //DataTable dtFareDetails = dsFilghts.Tables[5];
                    //if (dtFareDetails.Rows.Count > 0)
                    //{
                    //    DataRow[] rowFareDetails = dtFareDetails.Select("OriginDestinationOption_Id=" + originDestination_Id);
                    //    fareDetailsId = rowFareDetails[0]["FareDetails_Id"].ToString();
                    //}
                    //DataTable dtChargeableFares = dsFilghts.Tables[6];
                    //DataTable dtChargeableFaresNon = dsFilghts.Tables[7];
                    //if (dtChargeableFares.Rows.Count > 0)
                    //{
                    //    DataRow[] rowChargeableFareDetails = dtChargeableFares.Select("FareDetails_Id=" + fareDetailsId);
                    //    DataRow[] rowChargeableFareDetailsNon = dtChargeableFaresNon.Select("FareDetails_Id=" + fareDetailsId);

                    //    Label lblBaseFare = (Label)e.Row.FindControl("lblBaseFare");
                    //    Label lblTax = (Label)e.Row.FindControl("lblTax");
                    //    Label lblSTax = (Label)e.Row.FindControl("lblSTax");
                    //    Label lblSCharge = (Label)e.Row.FindControl("lblSCharge");
                    //    Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                    //    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    //    Label lblFare = (Label)e.Row.FindControl("lblFare");
                    //    Label lblTChargeRet = (Label)e.Row.FindControl("lblTChargeRet");


                    //    lblBaseFare.Text = Convert.ToDouble(rowChargeableFareDetails[0]["ActualBaseFare"]).ToString("####0.00");
                    //    lblTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["Tax"]).ToString("####0.00");
                    //    lblSTax.Text = Convert.ToDouble(rowChargeableFareDetails[0]["STax"]).ToString("####0.00");
                    //    lblSCharge.Text = Convert.ToDouble(rowChargeableFareDetails[0]["SCharge"]).ToString("####0.00");
                    //    lblTDiscount.Text = Convert.ToDouble(rowChargeableFareDetails[0]["TDiscount"]).ToString("####0.00");

                    //    lblTChargeRet.Text = (Convert.ToDouble(rowChargeableFareDetailsNon[0]["TCharge"]) + Convert.ToDouble(rowChargeableFareDetailsNon[0]["TMarkup"])).ToString("####0.00");

                    //    double total = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(rowChargeableFareDetailsNon[0]["TCharge"]) + Convert.ToDouble(rowChargeableFareDetailsNon[0]["TMarkup"]);//+ Convert.ToDouble(lblSCharge.Text) + Convert.ToDouble(lblTDiscount.Text)
                    //    lblTotal.Text = lblFare.Text = total.ToString("####0.00");

                    //    #region Calculating the HNF
                    //    if (Session["UserID"] != null)
                    //    {
                    //        if (Session["Role"].ToString() == "Agent")
                    //        {
                    //            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airlinename.Text.ToString());
                    //            string commisionPercentage = string.Empty;
                    //            if (dsCommSlab.Tables[0].Rows.Count > 0)
                    //                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                    //            else
                    //                commisionPercentage = "0";

                    //            Label lblHNFFarereturn = (Label)e.Row.FindControl("lblHNFFarereturn");
                    //            double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                    //            double DeductAmount = total - CommissionFare;
                    //            lblHNFFarereturn.Text = DeductAmount.ToString("####0.00");

                    //            #region Adding mark up price of agent
                    //            Class1 objBal = new Class1();
                    //            objBal.ScreenInd = Master123.gettopmarkup;
                    //            objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                    //            objBal.Type = "Domestic Flights";
                    //            objDataSet = (DataSet)objBal.fnGetData();
                    //            string markUpAmount = "0";
                    //            ViewState["MarkUp"] = markUpAmount;
                    //            if (objDataSet != null)
                    //            {
                    //                if (objDataSet.Tables.Count > 0)
                    //                {

                    //                    markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                    //                    ViewState["MarkUp"] = markUpAmount;
                    //                    if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Add")
                    //                    {
                    //                        lblTChargeRet.Text = (Convert.ToDouble(lblTChargeRet.Text) + Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    else if (objDataSet.Tables[0].Rows[0]["AddSubtract"].ToString() == "Subtract")
                    //                    {
                    //                        lblTChargeRet.Text = (Convert.ToDouble(lblTChargeRet.Text) - Convert.ToDouble(ViewState["MarkUp"].ToString())).ToString();

                    //                    }
                    //                    double total1 = Convert.ToDouble(lblBaseFare.Text) + Convert.ToDouble(lblTax.Text) + Convert.ToDouble(lblSTax.Text) + Convert.ToDouble(lblTChargeRet.Text);
                    //                    lblFare.Text = lblTotal.Text = total1.ToString("####0.00");

                    //                }
                    //            }


                    //            #endregion
                    //        }
                    //    }
                    //    #endregion

                    //}
                    DataTable dtactivedetails = dsFilghts.Tables[1];
                    Label lbladultone = (Label)e.Row.FindControl("lbladultone");
                    Label lblchildone = (Label)e.Row.FindControl("lblchildone");
                    Label lblinfantone = (Label)e.Row.FindControl("lblinfantone");
                    Label lblTripone = (Label)e.Row.FindControl("lblTripone");
                    lbladultone.Text = dtactivedetails.Rows[0]["AdultPax"].ToString();
                    lblchildone.Text = dtactivedetails.Rows[0]["ChildPax"].ToString();
                    lblinfantone.Text = dtactivedetails.Rows[0]["InfantPax"].ToString();
                    lblTripone.Text = dtactivedetails.Rows[0]["Mode"].ToString();
                    #endregion
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

    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            try
            {
                if (Convert.ToInt32(ddladultsintsearch.SelectedValue) + Convert.ToInt32(ddlchildintsearch.SelectedValue) + Convert.ToInt32(ddlinfantsintsearch.SelectedValue) <= 9)
                {

                    if (Convert.ToInt32(ddlinfantsintsearch.SelectedValue) <= Convert.ToInt32(ddladultsintsearch.SelectedValue))
                    {
                        if (rbonesearch.Checked == true)
                        {
                            trfiltersearch1.Visible = true;
                            Oneway.Visible = true;
                            gdvFlights.Visible = true;
                        }
                        else if (rbreturnsearch.Checked == true)
                        {
                            trfiltersearch1.Visible = true;
                            trroundTrip.Visible = true;
                            round.Visible = true;
                            Returnway.Visible = true;
                            Returnwayfare.Visible = true;
                        }
                        BindSearch();




                        Session["From"] = ddlSourcesSearch.Text.Substring(ddlSources.Text.IndexOf("(") + 1, 3);
                        Session["TO"] = ddlDestinationsSearch.Text.Substring(ddlDestinationsSearch.Text.IndexOf("(") + 1, 3);
                        Session["FromDate"] = txtdatesearch.Text.Trim();
                        //Converting dd-mm-yyyy to yyyy-mm-dd
                        string s = txtdatesearch.Text.Trim();
                        string[] result = s.Split('-');
                        string date = result[2] + "-" + result[1] + "-" + result[0];
                        ViewState["OnwardDate"] = date;

                        Session["ToDate"] = txtretundatesearch.Text.Trim();

                        string date1 = "";
                        if (txtretundatesearch.Text != "")
                        {
                            string s1 = txtretundatesearch.Text.Trim();
                            string[] result1 = s1.Split('-');
                            date1 = result1[2] + "-" + result1[1] + "-" + result1[0];
                            //  txtReturnDate.Text = date1;
                        }

                        infantCnt = Convert.ToInt32(ddlinfantsintsearch.SelectedValue);
                        childCnt = Convert.ToInt32(ddlchildintsearch.SelectedValue);
                        adultcnt = Convert.ToInt32(ddladultsintsearch.SelectedValue);

                        Session["adultcnt"] = adultcnt.ToString();
                        Session["infantCnt"] = infantCnt.ToString();
                        Session["childCnt"] = childCnt.ToString();


                        string mode = (rbonesearch.Checked) ? "ONE" : "ROUND";
                        Session["Mode"] = mode;

                        string returnDate = (rbonesearch.Checked) ? date : date1;
                        ViewState["ReturnDate"] = returnDate;

                        GetFlights();

                     //   GetSearchFlights();

                        //string[] strfrom = new string[2];
                        //strfrom = Session["From"].ToString().Split(',');
                        //string[] strto = new string[2];
                        //strto = Session["To"].ToString().Split(',');
                        //lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();
                        //Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();
                        //Label3.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString();
                    }
                    else
                    {
                        // lblMsg.Text = "Infant Count should be less than or equal to Adult Count";
                        mp3.Show();
                        lblerror.Text = "Infant Count should be less than or equal to Adult Count";
                    }
                }
                else
                {
                    //lblMsg.Text = "Maximum Number of passengers allowed is 9";
                    mp3.Show();
                    lblerror.Text = "Maximum Number of passengers allowed is 9";
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
    bool b = true;
    bool br = true;
    protected void btnRoundTripBook_Click(object sender, EventArgs e)
    {
        try
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

                    string[] strfrom = new string[2];
                    if (Session["From"] != null)
                    {
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    else
                    {
                        Session["From"] = (rbtnOneWay.Checked || rbonesearch.Checked) ? ddlSources.Text : ddlSourcesSearch.Text;
                        strfrom = Session["From"].ToString().Split(',');
                    }
                    string[] strto = new string[2];
                    if (Session["To"] != null)
                    {
                        strto = Session["To"].ToString().Split(',');
                    }
                    else
                    {
                        Session["To"] = (rbtnRoundTrip.Checked || rbreturnsearch.Checked) ? ddlDestinations.Text : ddlDestinationsSearch.Text;
                        strto = Session["To"].ToString().Split(',');
                    }

                    lblRoute.Text = strfrom[0].ToString() + "-" + strto[0].ToString();

                    lblRoutetwo.Text = "Route From " + strfrom[0].ToString() + " To " + strto[0].ToString() + " on " + lbldepart.Text;
                    if (rbtnRoundTrip.Checked == true || rbreturnsearch.Checked == true)
                    {
                       // DateTime Dateret = Convert.ToDateTime(txtReturnDate.Text);
                        lblRoutetwo.Text = lblRoutetwo.Text + " - " + "Return From " + strto[0].ToString() + " To " + strfrom[0].ToString() + " on " + txtReturnDate.Text;
                    }
                    //gdvOnward_RowCommand(sender, e);
                }
                else
                {
                    Literal lit = new Literal();
                    lit.Text = "Please select oneway and return";
                    this.Page.Controls.Add(lit);

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
    private void saveround(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            FlightBAL objFlightsBal = new FlightBAL();
            string ReferenceNo = Convert.ToString(Session["Order_Id"]);
            DataSet dtid = objFlightsBal.IGetInternationalFlightDetails(ReferenceNo);

            id1 = dtid.Tables[0].Rows[0]["id"].ToString();
            key = dtid.Tables[0].Rows[0]["Key1"].ToString();
            string[] strfare = dtid.Tables[0].Rows[0]["ActualBasefare"].ToString().Split('.');
            actualBaseFare = strfare[0].ToString();
            string[] strtax = dtid.Tables[0].Rows[0]["Tax"].ToString().Split('.');
            tax = strtax[0].ToString();
            string[] strstax = dtid.Tables[0].Rows[0]["STax"].ToString().Split('.');
            Stax = strstax[0].ToString();
            string[] strscharge = dtid.Tables[0].Rows[0]["Scharge"].ToString().Split('.');
            SCharge = strscharge[0].ToString();
            string[] strtdis = dtid.Tables[0].Rows[0]["TDiscount"].ToString().Split('.');
            TDiscount = strtdis[0].ToString();
            string[] strtcomm = dtid.Tables[0].Rows[0]["TPartnerCommission"].ToString().Split('.');
            TPartnerCommission = strtcomm[0].ToString();
            string[] strtsdis = dtid.Tables[0].Rows[0]["TSDiscount"].ToString().Split('.');
            TSdiscount = strtsdis[0].ToString();

            string[] strmark = dtid.Tables[0].Rows[0]["TMarkUp"].ToString().Split('.');
            TMarkup = strmark[0].ToString();
            string[] strtcharge = dtid.Tables[0].Rows[0]["TCharge"].ToString().Split('.');
            TCharge = strtcharge[0].ToString();


            idRet = dtid.Tables[0].Rows[0]["idRet"].ToString();
            keyRet = dtid.Tables[0].Rows[0]["Key1Ret"].ToString();
            string[] strfareRet = dtid.Tables[0].Rows[0]["ActualBasefareRet"].ToString().Split('.');
            actualBaseFareRet = strfareRet[0].ToString();
            string[] strtaxRet = dtid.Tables[0].Rows[0]["TaxRet"].ToString().Split('.');
            taxRet = strtaxRet[0].ToString();
            string[] strstaxRet = dtid.Tables[0].Rows[0]["STaxRet"].ToString().Split('.');
            StaxRet = strstaxRet[0].ToString();
            string[] strschargeRet = dtid.Tables[0].Rows[0]["SchargeRet"].ToString().Split('.');
            SChargeRet = strschargeRet[0].ToString();
            string[] strtdisRet = dtid.Tables[0].Rows[0]["TDiscountRet"].ToString().Split('.');
            TDiscountRet = strtdisRet[0].ToString();
            string[] strtcommRet = dtid.Tables[0].Rows[0]["TPartnerCommissionRet"].ToString().Split('.');
            TPartnerCommissionRet = strtcommRet[0].ToString();
            string[] strtsdisRet = dtid.Tables[0].Rows[0]["TSDiscountRet"].ToString().Split('.');
            TSdiscountRet = strtsdisRet[0].ToString();

            string[] strmarkRet = dtid.Tables[0].Rows[0]["TMarkUpRet"].ToString().Split('.');
            TMarkupRet = strmarkRet[0].ToString();
            string[] strtchargeRet = dtid.Tables[0].Rows[0]["TChargeRet"].ToString().Split('.');
            TChargeRet = strtchargeRet[0].ToString();


            //   octax = dtid.Tables[0].Rows[0]["Octax"].ToString();
            Customer_Details = dtid.Tables[0].Rows[0]["Customer_Details"].ToString();
            telephone = dtid.Tables[0].Rows[0]["telephone"].ToString();
            emailAddress = dtid.Tables[0].Rows[0]["emailAddress"].ToString();

            adultcnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["AdultPax"]);
            infantCnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["InfantPax"]);
            childCnt = Convert.ToInt32(dtid.Tables[0].Rows[0]["ChildPax"]);
            refNo = dtid.Tables[0].Rows[0]["ReferenceNo"].ToString();


            string ReferenceNo1 = dtid.Tables[0].Rows[0]["Dom_Booking_Id"].ToString();
            DataSet dsdbsave = objFlightsBal.GetInternationalFlightDetailsI1(ReferenceNo1);
            //1st row

            AirEquipType = dsdbsave.Tables[0].Rows[0]["AirEquipType"].ToString();
            ArrivalAirportCode = dsdbsave.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
            // ArrivalAirportName = dsdbsave.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
            ArrivalDateTime = dsdbsave.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
            DepartureAirportCode = dsdbsave.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
            //  DepartureAirportName = dsdbsave.Tables[0].Rows[0]["DepartureAirportName"].ToString();
            DepartureDateTime = dsdbsave.Tables[0].Rows[0]["DepartureDateTime"].ToString();
            FlightNumber = dsdbsave.Tables[0].Rows[0]["FlightNumber"].ToString();
            // MarketingAirlineCode = dsdbsave.Tables[0].Rows[0]["MarketingAirlineCode"].ToString();
            OperatingAirlineCode = dsdbsave.Tables[0].Rows[0]["OperatingAirlineCode"].ToString();
            airLineName = dsdbsave.Tables[0].Rows[0]["airlineName"].ToString();
            OperatingAirlineFlightNumber = dsdbsave.Tables[0].Rows[0]["OperatingAirlineFlightNumber"].ToString();
            RPH = dsdbsave.Tables[0].Rows[0]["RPH"].ToString();
            StopQuantity = dsdbsave.Tables[0].Rows[0]["StopQuantity"].ToString();
            airportTax = dsdbsave.Tables[0].Rows[0]["airportTax"].ToString();
            imageFileName = dsdbsave.Tables[0].Rows[0]["imageFileName"].ToString();
            string[] strdis = dsdbsave.Tables[0].Rows[0]["Discount"].ToString().Split('.');
            Discount = strdis[0].ToString();
            airportTaxChild = dsdbsave.Tables[0].Rows[0]["airportTaxChild"].ToString();
            airportTaxInfant = dsdbsave.Tables[0].Rows[0]["airportTaxInfant"].ToString();
            airportTaxChild = dsdbsave.Tables[0].Rows[0]["airportTaxChild"].ToString();
            airportTaxInfant = dsdbsave.Tables[0].Rows[0]["airportTaxInfant"].ToString();
            childTaxBreakup = dsdbsave.Tables[0].Rows[0]["ChildTaxBreakUp"].ToString();
            infantTaxBreakup = dsdbsave.Tables[0].Rows[0]["InfantTaxBreakUp"].ToString();
            adultTaxBreakup = dsdbsave.Tables[0].Rows[0]["adultTaxBreakUp"].ToString();
            octax = dsdbsave.Tables[0].Rows[0]["ocTax"].ToString();
            BookingClassResBookDesigCode = dsdbsave.Tables[0].Rows[0]["ResBookingCode"].ToString();
            string[] stradultfare = dsdbsave.Tables[0].Rows[0]["adultFare"].ToString().Split('.');
            adultFare = stradultfare[0].ToString();


            BookingClassAvailability = dsdbsave.Tables[0].Rows[0]["Availability"].ToString();
            string[] strchildfare = dsdbsave.Tables[0].Rows[0]["ChildFare"].ToString().Split('.');
            childFare = strchildfare[0].ToString();
            bookingclass = dsdbsave.Tables[0].Rows[0]["bookingClass"].ToString();
            classType = dsdbsave.Tables[0].Rows[0]["ClassType"].ToString();
            farebasiscode = dsdbsave.Tables[0].Rows[0]["farebasisCode"].ToString();
            string[] strinffare = dsdbsave.Tables[0].Rows[0]["infantFare"].ToString().Split('.');
            infantfare = strinffare[0].ToString();

            Rule = dsdbsave.Tables[0].Rows[0]["Fare_Rule"].ToString();
            string[] stradultcomm = dsdbsave.Tables[0].Rows[0]["adultCommission"].ToString().Split('.');
            adultCommission = stradultcomm[0].ToString();
            string[] strchildcomm = dsdbsave.Tables[0].Rows[0]["childCommission"].ToString().Split('.');
            childCommission = strchildcomm[0].ToString();
            string[] strcommoncharge = dsdbsave.Tables[0].Rows[0]["CommissionOnTCharge"].ToString().Split('.');
            commissionOnTCharge = strcommoncharge[0].ToString();

            //2nd row

            AirEquipTypeRet = dsdbsave.Tables[0].Rows[1]["AirEquipType"].ToString();
            ArrivalAirportCodeRet = dsdbsave.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();
            // ArrivalAirportName = dsdbsave.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
            ArrivalDateTimeRet = dsdbsave.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
            DepartureAirportCodeRet = dsdbsave.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
            //  DepartureAirportName = dsdbsave.Tables[0].Rows[0]["DepartureAirportName"].ToString();
            DepartureDateTimeRet = dsdbsave.Tables[0].Rows[1]["DepartureDateTime"].ToString();
            FlightNumberRet = dsdbsave.Tables[0].Rows[1]["FlightNumber"].ToString();
            // MarketingAirlineCode = dsdbsave.Tables[0].Rows[0]["MarketingAirlineCode"].ToString();
            OperatingAirlineCodeRet = dsdbsave.Tables[0].Rows[1]["OperatingAirlineCode"].ToString();
            airLineNameRet = dsdbsave.Tables[0].Rows[1]["airlineName"].ToString();
            OperatingAirlineFlightNumberRet = dsdbsave.Tables[0].Rows[1]["OperatingAirlineFlightNumber"].ToString();
            RPHRet = dsdbsave.Tables[0].Rows[1]["RPH"].ToString();
            StopQuantityRet = dsdbsave.Tables[0].Rows[1]["StopQuantity"].ToString();
            airportTaxRet = dsdbsave.Tables[0].Rows[1]["airportTax"].ToString();
            imageFileNameRet = dsdbsave.Tables[0].Rows[1]["imageFileName"].ToString();
            string[] strdisRet = dsdbsave.Tables[0].Rows[1]["Discount"].ToString().Split('.');
            DiscountRet = strdisRet[0].ToString();
            airportTaxChildRet = dsdbsave.Tables[0].Rows[1]["airportTaxChild"].ToString();
            airportTaxInfantRet = dsdbsave.Tables[0].Rows[1]["airportTaxInfant"].ToString();
            airportTaxChildRet = dsdbsave.Tables[0].Rows[1]["airportTaxChild"].ToString();
            airportTaxInfantRet = dsdbsave.Tables[0].Rows[1]["airportTaxInfant"].ToString();
            childTaxBreakupRet = dsdbsave.Tables[0].Rows[1]["ChildTaxBreakUp"].ToString();
            infantTaxBreakupRet = dsdbsave.Tables[0].Rows[1]["InfantTaxBreakUp"].ToString();
            adultTaxBreakupRet = dsdbsave.Tables[0].Rows[0]["adultTaxBreakUp"].ToString();
            octaxRet = dsdbsave.Tables[0].Rows[1]["ocTax"].ToString();
            BookingClassResBookDesigCodeRet = dsdbsave.Tables[0].Rows[1]["ResBookingCode"].ToString();
            string[] stradultretfare = dsdbsave.Tables[0].Rows[1]["adultFare"].ToString().Split('.');
            adultFareRet = stradultretfare[0].ToString();


            BookingClassAvailabilityRet = dsdbsave.Tables[0].Rows[1]["Availability"].ToString();
            string[] strchildretfare = dsdbsave.Tables[0].Rows[1]["ChildFare"].ToString().Split('.');
            childFareRet = strchildretfare[0].ToString();
            bookingclassRet = dsdbsave.Tables[0].Rows[1]["bookingClass"].ToString();
            classTypeRet = dsdbsave.Tables[0].Rows[1]["ClassType"].ToString();
            farebasiscodeRet = dsdbsave.Tables[0].Rows[1]["farebasisCode"].ToString();
            string[] strinfantfareret = dsdbsave.Tables[0].Rows[1]["infantFare"].ToString().Split('.');
            infantfareRet = strinfantfareret[0].ToString();

            RuleRet = dsdbsave.Tables[0].Rows[1]["Fare_Rule"].ToString();
            string[] stracr = dsdbsave.Tables[0].Rows[1]["adultCommission"].ToString().Split('.');
            adultCommissionRet = stracr[0].ToString();
            string[] strccr = dsdbsave.Tables[0].Rows[1]["childCommission"].ToString().Split('.');
            childCommissionRet = strccr[0].ToString();
            string[] ctcr = dsdbsave.Tables[0].Rows[1]["CommissionOnTCharge"].ToString().Split('.');
            commissionOnTChargeRet = ctcr[0].ToString();


            //String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights><returnFlights/> <telePhone>" + txtPhoneNum.Text + "</telePhone><email>" + txtEmailID.Text + "</email> <creditcardno></creditcardno><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";
            //DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);
            #region Pricing

            String XMLPricing = "<pricingrequest><onwardFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare><Tax>" + tax + "</Tax> <STax>" + Stax + "</STax><SCharge>" + SCharge + "</SCharge> <TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TDiscount + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare> <Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments><id>" + id1 + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights>";

            XMLPricing = XMLPricing + "<returnFlights><OriginDestinationOption><FareDetails><ChargeableFares><ActualBaseFare>" + actualBaseFareRet + "</ActualBaseFare><Tax>" + taxRet + "</Tax> <STax>" + StaxRet + "</STax><SCharge>" + SChargeRet + "</SCharge> <TDiscount>" + TDiscountRet + "</TDiscount><TPartnerCommission>" + TPartnerCommissionRet + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TChargeRet + "</TCharge> <TMarkup>" + TMarkupRet + "</TMarkup><TSdiscount>" + TDiscountRet + "</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><RPH>" + RPHRet + "</RPH> <StopQuantity>" + StopQuantityRet + "</StopQuantity><airLineName>" + airLineNameRet + "</airLineName><airportTax>" + airportTaxRet + "</airportTax><imageFileName>" + imageFileNameRet + "</imageFileName> <BookingClass><Availability>" + BookingClassAvailabilityRet + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCodeRet + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFareRet + "</adultFare><bookingclass>" + bookingclassRet + "</bookingclass> <childFare>" + childFareRet + "</childFare><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><infantfare>" + infantfareRet + "</infantfare> <Rule>" + RuleRet + "</Rule><adultCommission>" + adultCommissionRet + "</adultCommission><childCommission>" + childCommissionRet + "</childCommission><commissionOnTCharge>" + commissionOnTChargeRet + "</commissionOnTCharge></BookingClassFare> <Discount>" + DiscountRet + "</Discount><airportTaxChild>" + airportTaxChildRet + "</airportTaxChild><airportTaxInfant>" + airportTaxInfantRet + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakupRet + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakupRet + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakupRet + "</infantTaxBreakup><octax>" + octaxRet + "</octax> </FlightSegment> </FlightSegments><id>" + idRet + "</id><key>" + keyRet + "</key> </OriginDestinationOption></returnFlights>";

            XMLPricing = XMLPricing + "<telePhone>" + telephone + "</telePhone><email>" + emailAddress + "</email> <creditcardno></creditcardno><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + adultcnt + "</AdultPax><ChildPax>" + childCnt + "</ChildPax><InfantPax>" + infantCnt + "</InfantPax></pricingrequest>";

            DataSet dsFlightPricing = objFlights.GetPricingDetails(XMLPricing);
            if (dsFlightPricing.Tables.Count > 0)
            {

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
                    DataTable dtNonchangeprice = dsFlightPricing.Tables[5];
                    if (dtchangeprice.Rows.Count > 0)
                    {
                        DataRow[] rowchangeprices = dtchangeprice.Select("FareDetails_Id=" + fareDetailsIdRet);
                        DataRow[] rowNonchangeprices = dtNonchangeprice.Select("FareDetails_Id=" + fareDetailsIdRet);
                        TPartnerCommissionRet = rowchangeprices[0]["TPartnerCommission"].ToString();
                        actualBaseFareRet = rowchangeprices[0]["ActualBaseFare"].ToString();
                        taxRet = rowchangeprices[0]["Tax"].ToString();
                        StaxRet = rowchangeprices[0]["Stax"].ToString();
                        SChargeRet = rowchangeprices[0]["SCharge"].ToString();
                        TDiscountRet = rowchangeprices[0]["TDiscount"].ToString();
                        TChargeRet = rowNonchangeprices[0]["TCharge"].ToString();
                        TotalFare = (Convert.ToDecimal(actualBaseFareRet) + Convert.ToDecimal(taxRet) + Convert.ToDecimal(StaxRet) + Convert.ToDecimal(TChargeRet) + Convert.ToDecimal(rowNonchangeprices[0]["TMarkup"])).ToString();//+ Convert.ToDecimal(SChargeRet) + Convert.ToDecimal(TDiscountRet)
                    }
                }
            }


            #endregion



            refNo = Convert.ToString(Session["Order_Id"]);


            String xmlRequestData = "<Bookingrequest><onwardFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFare + "</ActualBaseFare> <Tax>" + tax + "</Tax><STax>" + Stax + "</STax> <SCharge>" + SCharge + "</SCharge><TDiscount>" + TDiscount + "</TDiscount><TPartnerCommission>" + TPartnerCommission + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TCharge + "</TCharge> <TMarkup>" + TMarkup + "</TMarkup><TSdiscount>" + TSdiscount + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipType + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCode + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTime + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCode + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTime + "</DepartureDateTime><FlightNumber>" + FlightNumber + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCode + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumber + "</OperatingAirlineFlightNumber><RPH>" + RPH + "</RPH> <StopQuantity>" + StopQuantity + "</StopQuantity><airLineName>" + airLineName + "</airLineName><airportTax>" + airportTax + "</airportTax><imageFileName>" + imageFileName + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailability + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCode + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFare + "</adultFare><bookingclass>" + bookingclass + "</bookingclass> <childFare>" + childFare + "</childFare><classType>" + classType + "</classType><farebasiscode>" + farebasiscode + "</farebasiscode><infantfare>" + infantfare + "</infantfare> <Rule>" + Rule + "</Rule><adultCommission>" + adultCommission + "</adultCommission><childCommission>" + childCommission + "</childCommission><commissionOnTCharge>" + commissionOnTCharge + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + Discount + "</Discount><airportTaxChild>" + airportTaxChild + "</airportTaxChild><airportTaxInfant>" + airportTaxInfant + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakup + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakup + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakup + "</infantTaxBreakup><octax>" + octax + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + id1 + "</id><key>" + key + "</key> </OriginDestinationOption></onwardFlights>";

            xmlRequestData = xmlRequestData + "<returnFlights><OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>" + actualBaseFareRet + "</ActualBaseFare> <Tax>" + taxRet + "</Tax><STax>" + StaxRet + "</STax> <SCharge>" + SChargeRet + "</SCharge><TDiscount>" + TDiscountRet + "</TDiscount><TPartnerCommission>" + TPartnerCommissionRet + "</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>" + TChargeRet + "</TCharge> <TMarkup>" + TMarkupRet + "</TMarkup><TSdiscount>" + TSdiscountRet + "</TSdiscount> </NonchargeableFares></FareDetails>";
            xmlRequestData = xmlRequestData + "<FlightSegments> <FlightSegment><AirEquipType>" + AirEquipTypeRet + "</AirEquipType><ArrivalAirportCode>" + ArrivalAirportCodeRet + "</ArrivalAirportCode><ArrivalDateTime>" + ArrivalDateTimeRet + "</ArrivalDateTime><DepartureAirportCode>" + DepartureAirportCodeRet + "</DepartureAirportCode><DepartureDateTime>" + DepartureDateTimeRet + "</DepartureDateTime><FlightNumber>" + FlightNumberRet + "</FlightNumber><OperatingAirlineCode>" + OperatingAirlineCodeRet + "</OperatingAirlineCode><OperatingAirlineFlightNumber>" + OperatingAirlineFlightNumberRet + "</OperatingAirlineFlightNumber><RPH>" + RPHRet + "</RPH> <StopQuantity>" + StopQuantityRet + "</StopQuantity><airLineName>" + airLineNameRet + "</airLineName><airportTax>" + airportTaxRet + "</airportTax><imageFileName>" + imageFileNameRet + "</imageFileName>";
            xmlRequestData = xmlRequestData + "<BookingClass><Availability>" + BookingClassAvailabilityRet + "</Availability><ResBookDesigCode>" + BookingClassResBookDesigCodeRet + "</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>" + adultFareRet + "</adultFare><bookingclass>" + bookingclassRet + "</bookingclass> <childFare>" + childFareRet + "</childFare><classType>" + classTypeRet + "</classType><farebasiscode>" + farebasiscodeRet + "</farebasiscode><infantfare>" + infantfareRet + "</infantfare> <Rule>" + RuleRet + "</Rule><adultCommission>" + adultCommissionRet + "</adultCommission><childCommission>" + childCommissionRet + "</childCommission><commissionOnTCharge>" + commissionOnTChargeRet + "</commissionOnTCharge></BookingClassFare>";
            xmlRequestData = xmlRequestData + "<Discount>" + DiscountRet + "</Discount><airportTaxChild>" + airportTaxChildRet + "</airportTaxChild><airportTaxInfant>" + airportTaxInfantRet + "</airportTaxInfant><adultTaxBreakup>" + adultTaxBreakupRet + "</adultTaxBreakup><childTaxBreakup>" + childTaxBreakupRet + "</childTaxBreakup><infantTaxBreakup>" + infantTaxBreakupRet + "</infantTaxBreakup><octax>" + octaxRet + "</octax> </FlightSegment> </FlightSegments>";
            xmlRequestData = xmlRequestData + "<id>" + idRet + "</id><key>" + keyRet + "</key> </OriginDestinationOption></returnFlights>";

            xmlRequestData = xmlRequestData + "<personName>";
            // Dynamic generation of names of adults, infants , Child
            #region old

            //Table tbladults = (Table)this.UpdatePanel1.FindControl("tblAdults");
            //for (int i = 1; i <= adultcnt; i++)
            //{

            //    TextBox txtFn = (TextBox)tbladults.FindControl("txtFn" + i);
            //    TextBox txtLn = (TextBox)tbladults.FindControl("txtLn" + i);
            //    DropDownList ddlTitle = (DropDownList)tbladults.FindControl("ddlTitle" + i);


            //    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
            //}

            //Table tblChild = (Table)this.UpdatePanel1.FindControl("tblChild");
            //for (int i = 1; i <= childCnt; i++)
            //{
            //    TextBox txtFn = (TextBox)tblChild.FindControl("txtCFn" + i);

            //    TextBox txtLn = (TextBox)tblChild.FindControl("txtCLn" + i);

            //    DropDownList ddlTitle = (DropDownList)tblChild.FindControl("ddlCTitle" + i);


            //    TextBox txtBirthDate = (TextBox)tblChild.FindControl("txtCBirthDate" + i);

            //    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

            //    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
            //}

            //Table tblInfants = (Table)this.UpdatePanel1.FindControl("tblInfants");
            //for (int i = 1; i <= infantCnt; i++)
            //{
            //    TextBox txtFn = (TextBox)tblInfants.FindControl("txtIFn" + i);

            //    TextBox txtLn = (TextBox)tblInfants.FindControl("txtILn" + i);

            //    DropDownList ddlTitle = (DropDownList)tblInfants.FindControl("ddlITitle" + i);

            //    TextBox txtBirthDate = (TextBox)tblInfants.FindControl("txtIBirthDate" + i);

            //    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

            //    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
            //}
            #endregion
            string strname = dtid.Tables[0].Rows[0]["Customer_Details"].ToString();
            string[] strrows = strname.ToString().Split(';');
            int id = strrows.Count();
            for (int m = 0; m < id; m++)
            {
                if (strrows[m].ToUpper().Contains("ADT"))
                {
                    string[] stradt = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + stradt[1].ToString() + "</givenName><surName>" + stradt[2].ToString() + "</surName><nameReference>" + stradt[0].ToString() + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }
                if (strrows[m].ToUpper().Contains("CHD"))
                {
                    string[] strchd = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + strchd[1].ToString() + "</givenName><surName>" + strchd[2].ToString() + "</surName><nameReference>" + strchd[0].ToString() + "</nameReference><dob>" + strchd[5].ToString() + "</dob><age>" + strchd[4].ToString() + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }
                if (strrows[m].ToUpper().Contains("INF"))
                {
                    string[] strinf = strrows[m].ToString().Split('|');
                    xmlRequestData = xmlRequestData + "<CustomerInfo><givenName>" + strinf[1].ToString() + "</givenName><surName>" + strinf[2].ToString() + "</surName><nameReference>" + strinf[0].ToString() + "</nameReference><dob>" + strinf[5].ToString() + "</dob><age>" + strinf[4].ToString() + "</age><psgrtype>inf</psgrtype></CustomerInfo>";

                }
            }

            xmlRequestData = xmlRequestData + "</personName><telePhone><phoneNumber>" + telephone + "</phoneNumber></telePhone><email><emailAddress>" + emailAddress + "</emailAddress></email><creditcardno>4111111111111111</creditcardno><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword> <partnerRefId>" + refNo + "</partnerRefId> <Clienttype>ArzooFWS1.1</Clienttype><AdultPax>" + Session["adultcnt"].ToString() + "</AdultPax><ChildPax>" + Session["childCnt"].ToString() + "</ChildPax><InfantPax>" + Session["infantCnt"].ToString() + "</InfantPax></Bookingrequest>";
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



                //  #region SaveResponse
                #region Dedcuting the amount from the agent and DB's balance after booking

                if (Session["UserID"] != null)
                {
                    if (Session["Role"] != null)
                    {
                        if (Session["Role"].ToString() == "Agent" || Session["Role"].ToString() == "Distributor")
                        {
                            string[] commPer = Session["CommisionPercentage_Agent"].ToString().Split('.');
                            DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                                                    Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
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
                            DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                                Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                        else if (Session["Role"].ToString() == "Admin")
                        {
                            DeductAgentBalance(0, Convert.ToDouble("0.00"), Convert.ToInt32(Session["UserID"].ToString()), refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                               Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                        }
                    }
                }
                else if (Session["Role"] == null)
                {
                    DeductAgentBalance(0, Convert.ToDouble("0.00"), 0, refNo, Convert.ToDouble(Session["Amount"].ToString()),
                                              Convert.ToDouble("0.00"), Convert.ToDouble("0.00"));
                }
                #endregion
                FlightBAL objFlightBal = new FlightBAL();

                objFlightBal.ReferenceNo = refNo;
                objFlightBal.TransId = transId;
                objFlightBal.Status = dsBookingResponse.Tables["Bookingresponse"].Rows[0]["status"].ToString();
                if (objFlightBal.Status == "SUCCESS")
                {
                    objFlightsBal.UpdateDomesticFlightBooking(objFlightBal);
                    GetBookingStatus(objFlightBal.ReferenceNo);
                }
                else
                {
                    objFlightsBal.UpdateDomesticFlightBooking(objFlightBal);
                }

                GetDetailsForPrint(Convert.ToString(Session["Order_Id"]));
                lbtnmail.Visible = false;
                pnlSearch.Visible = false;
                lbtnmail_Click1(sender, e);
                pnlPassengerDet.Visible = false;
                lblStatus.Visible = true;
                lblStatus.Text = "Ticket has been booked successfully. Reference Number is : " + Convert.ToString(Session["Order_Id"]);
                lblStatus.ForeColor = System.Drawing.Color.Green;
                //  Response.Redirect("Pay.aspx", false);

                
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
    protected void btnRoundTripSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                // if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); return; }

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



                #endregion
                dsFilghts = (DataSet)Session["dsDomFlights"];

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

                // string flightBookingId = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();
                // Session["BookingID"] = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();
                string refNo = Common.GetFlightsReferenceNo("LJDF");
                Session["Order_Id"] = refNo.ToString();
                FlightBAL objFlightBal = new FlightBAL();

                objFlightBal.ReferenceNo = refNo;
                objFlightBal.TransId = string.Empty;
                objFlightBal.Status = "Pending";
                objFlightBal.AdultPax = Convert.ToInt32(ddlAdult.SelectedValue);
                objFlightBal.InfantPax = Convert.ToInt32(ddlInfant.SelectedValue);
                objFlightBal.ChildPax = Convert.ToInt32(ddlChild.SelectedValue);
                objFlightBal.Origin_Destination_Id = id;
                objFlightBal.Origin_Destination_Key = key;
                objFlightBal.ActualBasefare = Convert.ToDecimal(actualBaseFare);
                objFlightBal.Tax = Convert.ToDecimal(tax);
                objFlightBal.STax = Convert.ToDecimal(Stax);
                objFlightBal.Scharge = Convert.ToDecimal(SCharge);
                objFlightBal.TDiscount = Convert.ToDecimal(TDiscount);
                objFlightBal.TPartnerCommission = Convert.ToDecimal(TPartnerCommission);
                objFlightBal.TCharge = Convert.ToDecimal(TCharge);
                objFlightBal.TMarkUp = Convert.ToDecimal(TMarkup);
                objFlightBal.TSDiscount = Convert.ToDecimal(TSdiscount);
                objFlightBal.ActualBasefareRet = Convert.ToDecimal(actualBaseFareRet);
                objFlightBal.TaxRet = Convert.ToDecimal(taxRet);
                objFlightBal.STaxRet = Convert.ToDecimal(StaxRet);
                objFlightBal.SchargeRet = Convert.ToDecimal(SChargeRet);
                objFlightBal.TDiscountRet = Convert.ToDecimal(TDiscountRet);
                objFlightBal.TPartnerCommissionRet = Convert.ToDecimal(TPartnerCommissionRet);
                objFlightBal.TChargeRet = Convert.ToDecimal(TChargeRet);
                objFlightBal.TMarkUpRet = Convert.ToDecimal(TMarkupRet);
                objFlightBal.TSDiscountRet = Convert.ToDecimal(TSdiscountRet);
                string givenName = string.Empty;
                string surName = string.Empty;
                string namereference = string.Empty;
                string psgrType = string.Empty;
                string Age = string.Empty;
                string customerInfo = string.Empty;
                #region customer

                Table tbladults1 = (Table)this.UpdatePanel1.FindControl("tblAdults");
                for (int l = 1; l <= Convert.ToInt32(Session["adultcnt"]); l++)
                {

                    TextBox txtFn = (TextBox)tbladults1.FindControl("txtFn" + l);
                    TextBox txtLn = (TextBox)tbladults1.FindControl("txtLn" + l);
                    DropDownList ddlTitle = (DropDownList)tbladults1.FindControl("ddlTitle" + l);

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Adt" + "|" + "-";
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Adt" + "|" + "-";
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><psgrtype>adt</psgrtype></CustomerInfo>";
                }

                Table tblChild1 = (Table)this.UpdatePanel1.FindControl("tblChild");
                for (int j = 1; j <= Convert.ToInt32(Session["childCnt"]); j++)
                {
                    TextBox txtFn = (TextBox)tblChild1.FindControl("txtCFn" + j);

                    TextBox txtLn = (TextBox)tblChild1.FindControl("txtCLn" + j);

                    DropDownList ddlTitle = (DropDownList)tblChild1.FindControl("ddlCTitle" + j);


                    TextBox txtBirthDate = (TextBox)tblChild1.FindControl("txtCBirthDate" + j);

                    string age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();

                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Chd" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Chd" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>chd</psgrtype></CustomerInfo>";
                }

                Table tblInfants1 = (Table)this.UpdatePanel1.FindControl("tblInfants");
                for (int k = 1; k <= Convert.ToInt32(Session["infantCnt"]); k++)
                {
                    TextBox txtFn = (TextBox)tblInfants1.FindControl("txtIFn" + k);

                    TextBox txtLn = (TextBox)tblInfants1.FindControl("txtILn" + k);

                    DropDownList ddlTitle = (DropDownList)tblInfants1.FindControl("ddlITitle" + k);

                    TextBox txtBirthDate = (TextBox)tblInfants1.FindControl("txtIBirthDate" + k);
                    string age = string.Empty;
                    if (txtBirthDate != null)
                        age = (DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year).ToString();
                    else
                        age = "0";


                    if (customerInfo == string.Empty)
                    {
                        customerInfo = ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Inf" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    else
                    {
                        customerInfo = customerInfo + ";" + ddlTitle.SelectedItem.Text + "|" + txtFn.Text + "|" + txtLn.Text + "|" + "Inf" + "|" + age + "|" + txtBirthDate.Text.ToString();
                    }
                    //  xmlRequest = xmlRequest + "<CustomerInfo><givenName>" + txtFn.Text + "</givenName><surName>" + txtLn.Text + "</surName><nameReference>" + ddlTitle.SelectedItem.Value + "</nameReference><dob>" + txtBirthDate.Text + "</dob><age>" + age + "</age><psgrtype>inf</psgrtype></CustomerInfo>";
                }
                #endregion
                objFlightBal.Address = txtCity.Text + "," + txtState.Text + "," + ddlcountry.SelectedValue + "," + txtPostalCode.Text + ",";
                objFlightBal.Customer_Details = customerInfo;
                //objFlightBal.Customer_Details = "Mr.|rajini|reguri|Adt|";
                objFlightBal.telephone = txtMobileNum.Text;
                objFlightBal.emailAddress = lblEmailAddress.Text = txtEmailID.Text;
                objFlightBal.TripMode = "Round";
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
                if (Session["Role"] == null)
                {
                    objFlightBal.Type = "Guest";
                }
                else
                {
                    objFlightBal.Type = Session["Role"].ToString();
                }
                objFlightBal.id = id;
                objFlightBal.key = key;
                objFlightBal.idRet = idRet;
                objFlightBal.keyRet = keyRet;
                DataTable dtflightBookingId = objFlightBal.AddDomesticFlightBooking(objFlightBal);


                string flightBookingId = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();
                Session["BookingID"] = dtflightBookingId.Rows[0]["FlightBookingID"].ToString();

                objFlightBal.FlightBookingID = flightBookingId.ToString();
                objFlightBal.AirEquipType = AirEquipType;
                objFlightBal.ArrivalAirportCode = ArrivalAirportCode;
                objFlightBal.ArrivalDateTime = ArrivalDateTime;
                objFlightBal.DepartureAirportCode = DepartureAirportCode;
                objFlightBal.DepartureDateTime = DepartureDateTime;
                objFlightBal.FlightNumber = FlightNumber;
                objFlightBal.OperatingAirlineCode = OperatingAirlineCode;
                objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumber;
                objFlightBal.RPH = RPH;
                objFlightBal.StopQuantity = StopQuantity;
                objFlightBal.airlineName = airLineName;
                objFlightBal.airportTax = airportTax;
                objFlightBal.imageFileName = imageFileName;
                objFlightBal.Discount = Discount;
                objFlightBal.airportTaxChild = airportTaxChild;
                objFlightBal.airportTaxInfant = airportTaxInfant;
                objFlightBal.adultTaxBreakUp = adultTaxBreakup;
                objFlightBal.ChildTaxBreakUp = childTaxBreakup;
                objFlightBal.InfantTaxBreakUp = infantTaxBreakup;
                objFlightBal.ocTax = octax;
                objFlightBal.Availability = BookingClassAvailability;
                objFlightBal.ResBookingCode = BookingClassResBookDesigCode;
                objFlightBal.adultFare = adultFare;
                objFlightBal.bookingClass = bookingclass;
                objFlightBal.ChildFare = childFare;
                objFlightBal.ClassType = classType;
                objFlightBal.farebasisCode = farebasiscode;
                objFlightBal.infantFare = infantfare;
                objFlightBal.Fare_Rule = Rule;
                objFlightBal.adultCommission = adultCommission;
                objFlightBal.childCommission = childCommission;
                objFlightBal.CommissionOnTCharge = commissionOnTCharge;
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);


                bool res = objFlightBal.AddDomesticFlightBookingsegments(objFlightBal);

                objFlightBal.FlightBookingID = flightBookingId.ToString();
                objFlightBal.AirEquipType = AirEquipTypeRet;
                objFlightBal.ArrivalAirportCode = ArrivalAirportCodeRet;
                objFlightBal.ArrivalDateTime = ArrivalDateTimeRet;
                objFlightBal.DepartureAirportCode = DepartureAirportCodeRet;
                objFlightBal.DepartureDateTime = DepartureDateTimeRet;
                objFlightBal.FlightNumber = FlightNumberRet;
                objFlightBal.OperatingAirlineCode = OperatingAirlineCodeRet;
                objFlightBal.OperatingAirlineFlightNumber = OperatingAirlineFlightNumberRet;
                objFlightBal.RPH = RPHRet;
                objFlightBal.StopQuantity = StopQuantityRet;
                objFlightBal.airlineName = airLineNameRet;
                objFlightBal.airportTax = airportTaxRet;
                objFlightBal.imageFileName = imageFileNameRet;
                objFlightBal.Discount = DiscountRet;
                objFlightBal.airportTaxChild = airportTaxChildRet;
                objFlightBal.airportTaxInfant = airportTaxInfantRet;
                objFlightBal.adultTaxBreakUp = adultTaxBreakupRet;
                objFlightBal.ChildTaxBreakUp = childTaxBreakupRet;
                objFlightBal.InfantTaxBreakUp = infantTaxBreakupRet;
                objFlightBal.ocTax = octaxRet;
                objFlightBal.Availability = BookingClassAvailabilityRet;
                objFlightBal.ResBookingCode = BookingClassResBookDesigCodeRet;
                objFlightBal.adultFare = adultFareRet;
                objFlightBal.bookingClass = bookingclassRet;
                objFlightBal.ChildFare = childFareRet;
                objFlightBal.ClassType = classTypeRet;
                objFlightBal.farebasisCode = farebasiscodeRet;
                objFlightBal.infantFare = infantfareRet;
                objFlightBal.Fare_Rule = RuleRet;
                objFlightBal.adultCommission = adultCommissionRet;
                objFlightBal.childCommission = childCommissionRet;
                objFlightBal.CommissionOnTCharge = commissionOnTChargeRet;
                objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);


                res = objFlightBal.AddDomesticFlightBookingsegments(objFlightBal);

                if (res)
                {
                    try
                    {

                        //  Response.Redirect("~/pay.aspx?val=Dom", false);
                        #region Checking the roles and booking the tickets

                        TotalFare = (Convert.ToDouble(lblTotalAmtreturn) + Convert.ToDouble(lblTotalAmt)).ToString();
                        Session["Amount"] = TotalFare;
                          if (Session["Role"] == null)
                        {
                            Response.Redirect("~/pay.aspx?val=Dom", false);
                        }
                          else if (Session["Role"].ToString() == "User")
                        {
                            objBAL = new ClsBAL();
                            DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                            Session["AgentId_Agent"] = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();

                            Response.Redirect("~/pay.aspx?val=Dom", false);
                        }
                        else if (Session["Role"].ToString() == "Admin")
                        {
                            saveround(sender, e);
                        }
                        else if (Session["Role"].ToString() == "Agent")
                        {
                            DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airLineName.ToString()); // Change it
                            string commisionPercentage = string.Empty;
                            if (dsCommSlab.Tables[0].Rows.Count > 0)
                                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                            else
                                commisionPercentage = "0";
                            string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                            string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
                            TotalFare = (Convert.ToDouble(lblTotalAmtreturn.Text) + Convert.ToDouble(lblTotalAmt.Text)).ToString();
                            string actualFare = TotalFare;
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
                            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "DomesticFlights", airLineName.ToString()); // Change it
                            string commisionPercentage = string.Empty;
                            if (dsCommSlab.Tables[0].Rows.Count > 0)
                                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                            else
                                commisionPercentage = "0";
                            string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                            string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
                            TotalFare = (Convert.ToDouble(lblTotalAmtreturn.Text) + Convert.ToDouble(lblTotalAmt.Text)).ToString();
                            string actualFare = TotalFare;
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
                    catch (Exception ex)
                    {
                        //  LogError("frmSearchBus.aspx", "paymentgateway", DateTime.Now, ex.Message.ToString());
                        // lblMsg1.Visible = true;
                        // lblMsg1.Text = "Error in the payment gateway";
                    }
                }
                #endregion
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
            try
            {

                DataTable dtstop = new DataTable();


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
                dt2.Columns.Add("FlightSegment_ID");
                dt2.Columns.Add("FlightSegments_ID");
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
                dt2.Columns.Add("Fare");
              
                if (ViewState["dt2"] != null)
                {
                     dtstop = (DataTable)ViewState["dt2"];
                    dvstop = dtstop.DefaultView;
                }

                string rowfilter = string.Empty;
                for (int i = 0; i < chkAirlines.Items.Count; i++)
                {
                    if (chkAirlines.Items[i].Selected)
                    {
                        if (rowfilter == string.Empty)
                        {
                            rowfilter = "airLineName='" + chkAirlines.Items[i].Text.Trim() + "'";
                           
                        }
                        else
                        {
                           
                            rowfilter = rowfilter + " or airLineName='" + chkAirlines.Items[i].Text.Trim() + "'";
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

                string rowfilterStop = string.Empty;
                for (int i = 0; i < ChkStops.Items.Count; i++)
                {
                    if (ChkStops.Items[i].Selected)
                    {
                        string[] strStopName = ChkStops.Items[i].Text.Split(' ');
                        if (rowfilterStop == string.Empty)
                        {

                            rowfilterStop = "StopQuantity='" + strStopName[6].ToString().Trim() + "'";
                        }
                        else
                        {
                            rowfilterStop = rowfilterStop + " or StopQuantity='" + strStopName[6].ToString().Trim() + "'";
                        }
                    }
                }

                dt2.DefaultView.RowFilter = rowfilterStop;
                DataTable dt3 = dt2.Clone();
                DataTable dt4 = dt2.Clone();
                if (dt2.DefaultView.Count > 0)
                {
                    foreach (DataRowView rows in dt2.DefaultView)
                    {
                        dt4.ImportRow(rows.Row);                        
                    }
                    int i ;




                    for (i = 0; i < dt4.Rows.Count; i++)
                    {                     

                        DataRow[] dr1 = dt2.Select("FlightSegments_ID = '" + dt4.Rows[i]["FlightSegments_ID"] + "'");

                        string adulttaxbreakup = dr1[0].ToString();                 

                        if (dr1[0]["adulttaxbreakup"] != "0,0,0")
                        {
                            foreach (DataRow drow in dr1)
                            {
                                dt3.ImportRow(drow);
                            }
                       }
                      
                    }
                }

                BindAirportCodes(dtstop);

                if (dt3.Rows.Count > 0)
                {
                    if (rbtnOneWay.Checked == true)
                    {

                        gdvFlights.DataSource = Session["dtFights"] = dt3;
                        gdvFlights.DataBind();
                    }
                    else
                    {
                        gdvFlights.DataSource = Session["dtFights"] = dt3;
                        gdvFlights.DataBind();
                    }

                }
                else
                {
                    if (rbtnOneWay.Checked == true)
                    {
                        gdvFlights.DataSource = Session["dtFights"] = dt3;
                        gdvFlights.EmptyDataText = "No Records Found";
                        gdvFlights.EmptyDataRowStyle.ForeColor = System.Drawing.Color.Red;
                        gdvFlights.DataBind();
                    }
                    else
                    {
                        gdvFlights.DataSource = Session["dtFights"] = dt3;
                        gdvFlights.EmptyDataText = "No Records Found";
                        gdvFlights.EmptyDataRowStyle.ForeColor = System.Drawing.Color.Red;
                        gdvFlights.DataBind();
                    }
                }
                ViewState["dt2"] = null;
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
    DataTable dtdt;
    DataView dv;
    bool bl = true;
    string fareDetailsId;



    protected void Valuechanged(object sender, EventArgs e)
    {
        try
        {
            dsFilghts = (DataSet)Session["dsDomFlights"];
            if (rbtnOneWay.Checked == true)
            {
                #region oneway

                //if (Chkstop1.Checked == false || Chkstop1.Checked == false)
                //{
                if (Session["dsDomFlights"] != null)
                {

                    if (Session["dtmodify"] == null)
                    {
                        DataSet dd = (DataSet)Session["dsDomFlights"];
                        if (dd.Tables.Count > 0)
                        {
                            DataTable dt = dd.Tables[6];
                            DataTable dtNon = dd.Tables[7];
                            if (!dt.Columns.Contains("TotalFare"))
                            {
                                dt.Columns.Add("TotalFare");
                                
                            }
                       
                            for(int i = 0; i< dt.Rows.Count ; i++)
                            {
                                int str = Convert.ToInt32(dd.Tables[6].Rows[i]["ActualBaseFare"]) + Convert.ToInt32(dd.Tables[6].Rows[i]["Tax"]) + Convert.ToInt32(dd.Tables[6].Rows[i]["Stax"]) + Convert.ToInt32(dd.Tables[7].Rows[i]["TCharge"]) + Convert.ToInt32(dd.Tables[7].Rows[i]["TMarkup"]);//+ Convert.ToInt32(dd.Tables[6].Rows[i]["SCharge"]) + Convert.ToInt32(dd.Tables[6].Rows[i]["TDiscount"]) 
                              
                                dt.Rows[i]["TotalFare"] = str.ToString();
                            }
                            Session["dtmodify"] = dt;
                            dv = dt.DefaultView;
                            bl = false;
                        }
                        else
                        {
                            mp3.Show();
                            lblerror.Text = "No Data Found";
                        }
                    }
                    else
                    {
                        DataTable dtmodify = (DataTable)Session["dtmodify"];
                        dv = dtmodify.DefaultView;
                        bl = true;
                        Session["dtmodify"] = null;
                    }




                    dv.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                    dv.Table.AcceptChanges();

                    int id = dv.Count;
                    // = new DataTable();
                    DataTable dtdv = dv.ToTable();
                    if (id != null)
                    {
                        dsIntFlights = (DataSet)Session["dsDomFlights"];
                        DataTable dtSource  = (DataTable)Session["dtFightsFare"];
                        DataView dv1 = dtSource.DefaultView;// dsIntFlights.Tables[9].DefaultView;
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
                        dt2.Columns.Add("airLineName");
                        dt2.Columns.Add("FlightNumber");
                        dt2.Columns.Add("Fare");
                        string ODO_Id = string.Empty;
                        string FlightSegmentsId = string.Empty;
                        foreach (DataRow dr in dtdv.Rows)
                        {



                            DataTable dtFareDetails = dsFilghts.Tables["FareDetails"];
                            if (dtFareDetails.Rows.Count > 0)
                            {
                                DataRow[] rowFareDetails = dtFareDetails.Select("FareDetails_Id=" + dr["FareDetails_Id"].ToString());
                                ODO_Id = rowFareDetails[0]["OriginDestinationOption_Id"].ToString();
                            }
                            DataTable dtFlightSegments = dsFilghts.Tables["FlightSegments"];
                            if (dtFlightSegments.Rows.Count > 0)
                            {
                                DataRow[] rowFlightSegments = dtFlightSegments.Select("OriginDestinationOption_Id=" + ODO_Id);
                                FlightSegmentsId = rowFlightSegments[0]["FlightSegments_Id"].ToString();
                            }


                            dv1.RowFilter = "FlightSegments_Id='" + FlightSegmentsId + "'";
                            dv1.Table.Clone();

                            foreach (DataRowView datav in dv1)
                            {
                                // dtdt.TableName = "MM";

                                dt2.ImportRow(datav.Row);// = dv1.row;
                            }

                        }
                        dv1.Table.AcceptChanges();
                        int v = dv1.Count;
                        gdvFlights.DataSource = Session["dtFights"] = dt2;

                    

                        ViewState["dt2"] = dt2;
                        DataTable dttt = (DataTable)dv.ToTable();
                        ViewState["dv"] = dttt;
                        //gdvFlights.DataBind();
                        //ViewState["dv"] = null;
                    }
                    else
                    {

                        // Label5.Text = tbUse.Text;
                    }
                }
                //}
                //else
                //{


                //}
                #endregion
            }
            else
            {

                if (Session["dsDomFlights"] != null)
                {
                    if (Session["DtOnWardFlights"] != null && Session["DtReturnFlights"] != null)
                    {
                        Session["dsDomFlights"] = dsFilghts;
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

                        //DataTable dtfaredetails = dsFilghts.Tables["FareDEtails"];
                        //DataTable dtNewFaredetailsid = dtfaredetails.Clone();

                        if (dtOriginDestinationOption.Rows.Count > 0)
                        {
                            DataRow[] row = dtOriginDestinationOption.Select("OriginDestinationOptions_Id=" + OriginDestinationOptionsId);

                            //for (int j = 0; j < row.Length; j++)
                            //{
                            //    DataRow[] rowFlightSegments = dtfaredetails.Select("OriginDestinationOption_Id=" + row[j]["OriginDestinationOption_Id"].ToString());//OriginDestinationOption_Id
                            //    foreach (DataRow drfare in row)
                            //    {
                            //        dtNewFaredetailsid.ImportRow(drfare);
                            //    }
                            //}

                           // DataRow[] rowFare = dtfaredetails.Select("FareDetails=" + row[j]["OriginDestinationOption_Id"].ToString());//OriginDestinationOption_Id
                            for (int i = 0; i < row.Length; i++)
                            {
                                DataRow[] rowFlightSegments = dtChargeableFares.Select("FareDetails_Id=" + row[i]["OriginDestinationOption_Id"].ToString());//OriginDestinationOption_Id
                                foreach (DataRow dr in rowFlightSegments)
                                {
                                    dtNewFlightSegments.ImportRow(dr);
                                }
                            }
                        }
                        dsFilghts = (DataSet)Session["dsDomFlights"];
                      
                        dtNewFlightSegments.Columns.Add("TotalFare");


                        
                        for (int i = 0; i < dtNewFlightSegments.Rows.Count; i++)
                        {
                            int str = Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["ActualBaseFare"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["Tax"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["Stax"]) + Convert.ToInt32(dsFilghts.Tables[7].Rows[i]["TCharge"]) + Convert.ToInt32(dsFilghts.Tables[7].Rows[i]["TMarkup"]);//+ Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["SCharge"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["TDiscount"]) 

                            dtNewFlightSegments.Rows[i]["TotalFare"] = str.ToString();
                        }
                        //foreach (DataRow dtnew in dtNewFlightSegments.Rows)
                        //{
                        //    int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) + Convert.ToInt32(dtnew["TDiscount"]);
                        //    dtnew["TotalFare"] = str.ToString();
                        //}
                        Session["dtmodify"] = dtNewFlightSegments;
                        Session["dsDomFlights"] = dd;
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
                       


                        dtNewFlightSegmentRet.Columns.Add("TotalFare");
                        //foreach (DataRow dtnew in dtNewFlightSegmentRet.Rows)
                        //{
                        //    int str = Convert.ToInt32(dtnew["ActualBaseFare"]) + Convert.ToInt32(dtnew["Tax"]) + Convert.ToInt32(dtnew["Stax"]) + Convert.ToInt32(dtnew["SCharge"]) + Convert.ToInt32(dtnew["TDiscount"]);
                        //    dtnew["TotalFare"] = str.ToString();
                        //}

                        for (int i = 0; i < dtNewFlightSegmentRet.Rows.Count; i++)
                        {
                            int str = Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["ActualBaseFare"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["Tax"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["Stax"]) + Convert.ToInt32(dsFilghts.Tables[7].Rows[i]["TCharge"]) + Convert.ToInt32(dsFilghts.Tables[7].Rows[i]["TMarkup"]);// Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["SCharge"]) + Convert.ToInt32(dsFilghts.Tables[6].Rows[i]["TDiscount"]) +

                            dtNewFlightSegmentRet.Rows[i]["TotalFare"] = str.ToString();
                        }
                        Session["dtmodifyreturn"] = dtNewFlightSegmentRet;
                        dvstop = dtNewFlightSegmentRet.DefaultView;
                        bl = false;
                      
                        dv.RowFilter = "TotalFare >=" + HiddenField1.Value + " and TotalFare <=" + HiddenField2.Value;
                        dv.Table.AcceptChanges();

                        int id = dv.Count;
                        Session["dsDomFlights"] = dsFilghts;
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
                            dd = (DataSet)Session["dsDomFlights"];
                            Session["dsDomFlights"] = dd;
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
                                Session["dsDomFlights"] = dd;
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
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
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

            string rowfilter = string.Empty;
            for (int i = 0; i < chkAirlines.Items.Count; i++)
            {
                if (chkAirlines.Items[i].Selected)
                {
                    if (rowfilter == string.Empty)
                    {
                        rowfilter = "airLineName='" + chkAirlines.Items[i].Text.Trim() + "'";
                    }
                    else
                    {
                        rowfilter = rowfilter + " or airLineName='" + chkAirlines.Items[i].Text.Trim() + "'";
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

            dv.RowFilter = rowfilter;
            if (dv.Count > 0)
            {
                foreach (DataRowView rows in dv)
                {
                    dt3.ImportRow(rows.Row);
                }

            }

            string rowfilterStop = string.Empty;
            for (int i = 0; i < ChkStops.Items.Count; i++)
            {
                if (ChkStops.Items[i].Selected)
                {
                    string[] strStopName = ChkStops.Items[i].Text.Split(' ');
                    if (rowfilterStop == string.Empty)
                    {

                        rowfilterStop = "StopQuantity='" + strStopName[0].ToString().Trim() + "'";
                    }
                    else
                    {
                        rowfilterStop = rowfilterStop + " or StopQuantity='" + strStopName[0].ToString().Trim() + "'";
                    }
                }
            }

            dt3.DefaultView.RowFilter = rowfilterStop;
            dt2.DefaultView.RowFilter = rowfilterStop;
           // DataTable dt4 = dt3.Clone();
           // //if (dt4.DefaultView.Count > 0)
           // //{

           //     foreach (DataRowView rows in dt3.DefaultView)
           //     {
           //         dt4.ImportRow(rows.Row);
           //     }

           //// }
           // dt4.DefaultView.RowFilter = rowfilterStop;

            #endregion
            

            //if (Chkstop2.Checked == true)
            //{
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
        //}
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
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
        try
        {
            if (Session["dtFights"] != null)
            {
                //  You can cache the DataTable for improving performance
                DataTable dt = ((DataTable)Session["dtFights"]);
                //GetData().Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + " " + direction;

                gdvFlights.DataSource = dv;
                dsFilghts = (DataSet)Session["dsDomFlights"];
                gdvFlights.DataBind();
            }            
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
            
                DataTable dt = ((DataTable)Session["DtReturnFlights"]);
                //GetData().Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + " " + direction;

                gdvReturn.DataSource = dv;
                // dsFilghts = (DataSet)Session["DtOnWardFlights"];
                gdvReturn.DataBind();
            

        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }
    private void SortGridViewonward(string sortExpression, string direction)
    {
        try
        {

            DataTable dt = ((DataTable)Session["DtOnWardFlights"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + " " + direction;

            gdvOnward.DataSource = dv;
            // dsFilghts = (DataSet)Session["DtOnWardFlights"];
            gdvOnward.DataBind();


        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }
    protected void btnExportTOWord_Click(object sender, EventArgs e)
    {
        try
        {
            pnlViewticket.Visible = true;
            // BindLabelData();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BioData.doc");
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
            if (Session["dsDomFlights"] != null)
            {
                dsFilghts = (DataSet)Session["dsDomFlights"];
                DataTable dtFlightsSegment = dsFilghts.Tables[9];

                DataTable dtFareDet = dsFilghts.Tables[6];
                decimal minValue = Convert.ToDecimal(dtFareDet.Rows[0]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[0]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[0]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[0]["TDiscount"]);

                decimal maxValue = Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["ActualBaseFare"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["Tax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["STax"]) + Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["SCharge"]) - Convert.ToDecimal(dtFareDet.Rows[dtFareDet.Rows.Count - 1]["TDiscount"]);
                // sliderTwo.Text = "";

                // multiHandleSliderExtenderTwo.Controls.Clear();// =sliderTwo.Text;



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


                multiHandleSliderExtenderTwo.ClientState = minValue + "," + maxValue;
                Valuechanged(sender, e);
            }
            if (rbonesearch.Checked == true)
            {
                JetAirways(sender, e);
            }
            else
            {
                JetAirwaysReturn(sender, e);
            } 

        }
        catch (NullReferenceException)
        {
            Response.Redirect("~/Default.aspx", false);
        }
    }
    protected void GetBookingStatus(string ReferenceNo)
    {
        try
        {
            string AirlinePNR = string.Empty; // ConfirmationId
            string GDFPNRNumber = string.Empty; //PNRNumber
            string eticketNo = string.Empty;
            string flightUid = string.Empty;
            string passuid = string.Empty;

            FlightBAL objFlightBal = new FlightBAL();
            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetTransID(ReferenceNo);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();
            //remove
            //  transId = "A015663";
            if (transId != "")
            {
                String xmlRequestData = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100214</partnerRefId></EticketRequest>";
                DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);

                if (dsFlightBookStatus.Tables.Contains("requestedPNR"))
                {
                    DataTable dtOriDestPNRRequest = dsFlightBookStatus.Tables["OriDestPNRRequest"];
                    for (int i = 0; i < dtOriDestPNRRequest.Rows.Count; i++)
                    {
                        AirlinePNR = (AirlinePNR == string.Empty) ? dtOriDestPNRRequest.Rows[i]["confirmationid"].ToString() : AirlinePNR + "|" + dtOriDestPNRRequest.Rows[i]["confirmationid"].ToString();
                        GDFPNRNumber = (GDFPNRNumber == string.Empty) ? dtOriDestPNRRequest.Rows[i]["pnrnumber"].ToString() : AirlinePNR + "|" + dtOriDestPNRRequest.Rows[i]["pnrnumber"].ToString();
                    }

                    DataTable dtETicket = dsFlightBookStatus.Tables["ETicket"];
                    for (int i = 0; i < dtETicket.Rows.Count; i++)
                    {
                        eticketNo = (eticketNo == string.Empty) ? dtETicket.Rows[i]["eticketNo"].ToString() : eticketNo + "|" + dtETicket.Rows[i]["eticketNo"].ToString();
                        flightUid = (flightUid == string.Empty) ? dtETicket.Rows[i]["flightuid"].ToString() : flightUid + "|" + dtETicket.Rows[i]["flightuid"].ToString();
                        passuid = (passuid == string.Empty) ? dtETicket.Rows[i]["passuid"].ToString() : passuid + "|" + dtETicket.Rows[i]["passuid"].ToString();
                    }

                    objFlightBal.AirlinePNR = AirlinePNR;
                    objFlightBal.GDFPNRNo = GDFPNRNumber;
                    objFlightBal.eticketNo = eticketNo;
                    objFlightBal.Flightuid = flightUid;
                    objFlightBal.passuid = passuid;
                    objFlightBal.Status = dsFlightBookStatus.Tables["requestedPNR"].Rows[0]["status"].ToString();
                    //remove
                    //dsGetTransId = objFlightBal.GetTransID(ReferenceNo);
                    //transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();
                    //remove
                    objFlightBal.TransId = transId;
                    objFlightBal.ReferenceNo = ReferenceNo;

                    if (objFlightBal.Status == "SUCCESS")
                    {
                        statusCnt++;
                        if (statusCnt < 3)
                        {
                            GetBookingStatus(ReferenceNo);
                        }
                        else
                        {
                            bool res = objFlightBal.UpdateDomesticFlightBookingStatus(objFlightBal);
                            if (res)
                            {
                                lblStatus.Text = "Updated the status";
                                lblStatus.ForeColor = System.Drawing.Color.Green;
                            }
                        }

                    }
                    else
                    {
                        bool res = objFlightBal.UpdateDomesticFlightBookingStatus(objFlightBal);
                        if (res)
                        {
                            lblStatus.Text = "Updated the status";
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    string status = dsFlightBookStatus.Tables[0].Rows[0]["Status"].ToString();
                    if (status == "SUCCESS")
                    {
                        lblStatus.Text = "Your Ticket is still under booking process";
                    }
                }
            }
            else
            {

                lblStatus.Text = "Invalid Request";
            }

        }
        catch (Exception ex)
        {

        }
    }
   

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        pnlPassengerDet.Visible = false;
    }
    protected void txtConfirmEmail_TextChanged(object sender, EventArgs e)
    {
        if (txtEmailID.Text == null)
        {
            //lblEmail.Text = "Please Enter EmailId";
            lblerror.Text = "Enetr Email Id";

        }
        else
        {
            txtEmailID.Focus();
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
                                           where i.Field<string>("Type") == "D" || i.Field<string>("Type") == "C"
                                           select i;


            if (SubData.Count() > 0)
            {
                DtLocSub = SubData.CopyToDataTable();
              
                DataSet ds = new DataSet();
                 ds.Tables.Add(DtLocSub);
                 Session["AirportsCode"] = ds;            

            }

          

        }
        catch (Exception)
        {            
          //  throw;
        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAirportCodes1(string prefixText)
    {
        try
        {

            DataSet ds = new DataSet();

            FlightBAL objFlightBal = new FlightBAL();
            //ds = objFlightBal.GetDomAirportCodes();
            ds =(DataSet)HttpContext.Current.Session["AirportsCode"];

            HttpContext.Current.Session["AirportsCode"] = ds;

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
                airports.Add(dtNew.Rows[i]["CityName"].ToString().Trim() +  " - (" + dtNew.Rows[i]["AirportCode"].ToString().Trim() + ")");
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
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
    public void FnLocationtoXml()
    {
        string Constring = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection con = new SqlConnection(Constring);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_IFReports", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TableName", "DomAirportCodes");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DsLoc = new DataSet();
            da.Fill(DsLoc);

            string DirectoryPath = Server.MapPath("~/App_Data");
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            string filepath = "~/App_Data/" + "Airports.xml";
            string DirectoryPath1 = Server.MapPath(filepath);
            DirectoryInfo dir1 = new DirectoryInfo(DirectoryPath1);
            if (!dir1.Exists)
            {
                DataSet ds1 = new DataSet();
                ds1.EnforceConstraints = false;
                XmlDataDocument XmlDoc = new XmlDataDocument(ds1);
                // Write down the XML declaration
                 XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element
                 XmlElement rootNode = XmlDoc.CreateElement("Airports");
                XmlDoc.InsertBefore(xmlDeclaration, XmlDoc.DocumentElement);
                XmlDoc.AppendChild(rootNode);
                XmlDoc.Save(Server.MapPath(filepath));

            }


            StreamWriter XmlData = new StreamWriter(Server.MapPath("~/App_Data/" + "Airports.xml"), false);
            DsLoc.WriteXml(XmlData);
            XmlData.Close();
            //Label5.Visible = true;
            //Label8.Text = " AllCitiesList Uploaded to XML Successfully";

        }
        finally
        {
            con.Close();
        }

    }
    protected void lnkDepartreturn_Click(object sender, EventArgs e)
    {
        SortGridView1("DepartureDateTime", lnkDepartreturn.ToolTip);
        if (lnkDepartreturn.ToolTip == "ASC")
        {
            lnkDepartreturn.ToolTip = "DESC";
        }
        else
        {
            lnkDepartreturn.ToolTip = "ASC";
        }
    }
    protected void lnkarrivesreturn_Click(object sender, EventArgs e)
    {
        SortGridView1("ArrivalDateTime", lnkarrivesreturn.ToolTip);
        if (lnkarrivesreturn.ToolTip == "ASC")
        {
            lnkarrivesreturn.ToolTip = "DESC";
        }
        else
        {
            lnkarrivesreturn.ToolTip = "ASC";
        }
    }
    protected void lnkfarereturn_Click(object sender, EventArgs e)
    {
        SortGridView1("Fare", lnkfarereturn.ToolTip);
        if (lnkfarereturn.ToolTip == "ASC")
        {
            lnkfarereturn.ToolTip = "DESC";
        }
        else
        {
            lnkfarereturn.ToolTip = "ASC";
        }
    }

    protected void lnkDepartonward_Click(object sender, EventArgs e)
    {
        SortGridViewonward("DepartureDateTime", lnkDepartonward.ToolTip);
        if (lnkDepartonward.ToolTip == "ASC")
        {
            lnkDepartonward.ToolTip = "DESC";
        }
        else
        {
            lnkDepartonward.ToolTip = "ASC";
        }
    }
    protected void lnkarrivesonward_Click(object sender, EventArgs e)
    {
        SortGridViewonward("ArrivalDateTime", lnkarrivesonward.ToolTip);
        if (lnkarrivesonward.ToolTip == "ASC")
        {
            lnkarrivesonward.ToolTip = "DESC";
        }
        else
        {
            lnkarrivesonward.ToolTip = "ASC";
        }
    }
    protected void lnkfareonward_Click(object sender, EventArgs e)
    {
        SortGridViewonward("Fare", lnkfareonward.ToolTip);
        if (lnkfareonward.ToolTip == "ASC")
        {
            lnkfareonward.ToolTip = "DESC";
        }
        else
        {
            lnkfareonward.ToolTip = "ASC";
        }
    }
}
