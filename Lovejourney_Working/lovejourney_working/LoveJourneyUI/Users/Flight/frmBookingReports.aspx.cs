using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Globalization;
public partial class Users_Flight_frmBookingReports : System.Web.UI.Page
{

    FlightBAL objFlightBal = new FlightBAL();
    DataSet dsFlight;
    DataSet objDataSet;
    ClsBAL objBAL;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("FlightsBookReports", Session["Role"].ToString());
                btnExport.Visible = false;
                rdlflights.SelectedValue = "DomesticFlights";
                rdlflights_SelectedIndexChanged(sender, e);
                ds = GetAgents();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlagent1.DataSource = ds;
                        ddlagent1.DataTextField = "Username";
                        ddlagent1.DataValueField = "ID";
                        ddlagent1.DataBind();

                        ddlagent1.Items.Insert(0, "-Please Select-");
                    }

                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    DataSet GetAgents()
    {
        try
        {
          ClsBAL  objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlBookingreports.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlBookingreports.Visible = false;

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
                            pnlBookingreports.Visible = true;
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
    protected void rdlflights_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Button1_Click(sender, e);
            source3.Visible = true;
            dsFlight = new DataSet();
            objFlightBal.TableName = "Search";
            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {
                IF.Visible = false;
                Domestic.Visible = true;

                objFlightBal.FlightName = "Domesticadmin";
                ViewState["Flight"] = "Domesticadmin";

            }
            else if (rdlflights.SelectedItem.Text == "International Flights")
            {
                IF.Visible = true;
                Domestic.Visible = false;
                objFlightBal.FlightName = "IFadmin";
                ViewState["Flight"] = "IFadmin";
            }
            objFlightBal.CreatedBy = Convert.ToInt32(Session["UserId"]);
            dsFlight = objFlightBal.FlightSearch(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                    GvFlightsReports.Visible = true;
                    btnExport.Visible = true;
                }
                else
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    double actualfare;
    double commission;
    double scharge;
    double discount;
    double Charge;
    double markup;
    double refund;
    double ccharge;
    double closebal;
    double MBFare;
    int AgentId;
    protected void GvFlightsReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblDepartureDateTime = (Label)e.Row.FindControl("lblDepartureDateTime");
                if (lblDepartureDateTime.Text.Contains('T'))
                {
                    string[] s = lblDepartureDateTime.Text.Split('T');
                    DateTime dt = Convert.ToDateTime(s[0].ToString());
                    lblDepartureDateTime.Text = dt.ToString("dd-MM-yyyy");
                }
                actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TPartnerCommission"));
                scharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Scharge"));
                discount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDiscount"));
                Charge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TCharge"));
                markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

                refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                MBFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
                //closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));


                Label lblCustomerDetails = (Label)e.Row.FindControl("lblCustomerDetails");
                if (lblCustomerDetails.Text != "")
                {
                    string[] strCusDet = lblCustomerDetails.Text.Split('|');
                    lblCustomerDetails.Text = strCusDet[0] + " " + strCusDet[1] + " " + strCusDet[2];
                }

                Label lblActualBasefare = (Label)e.Row.FindControl("lblActualBasefare");
                lblActualBasefare.Text = Convert.ToDouble(lblActualBasefare.Text).ToString("####0.00");

                Label lblScharge = (Label)e.Row.FindControl("lblScharge");
                lblScharge.Text = Convert.ToDouble(lblScharge.Text).ToString("####0.00");

                Label lblTDiscount = (Label)e.Row.FindControl("lblTDiscount");
                lblTDiscount.Text = Convert.ToDouble(lblTDiscount.Text).ToString("####0.00");

                Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
                lblMBFare.Text = Convert.ToDouble(lblMBFare.Text).ToString("####0.00");

                Label lblTPartnerCommission = (Label)e.Row.FindControl("lblTPartnerCommission");
                lblTPartnerCommission.Text = Convert.ToDouble(lblTPartnerCommission.Text).ToString("####0.00");

                Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");
                lblTCharge.Text = Convert.ToDouble(lblTCharge.Text).ToString("####0.00");

                Label lblTMarkUp = (Label)e.Row.FindControl("lblTMarkUp");
                lblTMarkUp.Text = Convert.ToDouble(lblTMarkUp.Text).ToString("####0.00");

                Label lblRefundAmount = (Label)e.Row.FindControl("lblRefundAmount");
                lblRefundAmount.Text = Convert.ToDouble(lblRefundAmount.Text).ToString("####0.00");

                Label lblCancellationCharges = (Label)e.Row.FindControl("lblCancellationCharges");
                lblCancellationCharges.Text = Convert.ToDouble(lblCancellationCharges.Text).ToString("####0.00");

                //Label lblClosingBalance = (Label)e.Row.FindControl("lblClosingBalance");
                //lblClosingBalance.Text = Convert.ToDouble(lblClosingBalance.Text).ToString("####0.00");



            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label lblcharge = (Label)e.Row.FindControl("lblcharge");
                lblcharge.Text = Charge.ToString("####0.00");

                Label lblcomm = (Label)e.Row.FindControl("lblcomm");
                lblcomm.Text = commission.ToString("####0.00");
                Label lbldiscount = (Label)e.Row.FindControl("lbldiscount");
                lbldiscount.Text = discount.ToString("####0.00");
                Label lblScharge = (Label)e.Row.FindControl("lblScharge");
                lblScharge.Text = scharge.ToString("####0.00");
                Label lblactulafare = (Label)e.Row.FindControl("lblactulafare");
                lblactulafare.Text = actualfare.ToString("####0.00");
                Label lblmarkup = (Label)e.Row.FindControl("lblmarkup");
                lblmarkup.Text = markup.ToString("####0.00");


                Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmount1");
                lblRefundAmount1.Text = refund.ToString("####0.00");
                Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationCharges1");
                lblCancellationCharges1.Text = ccharge.ToString("####0.00");
                Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
                lblMBFare.Text = MBFare.ToString("####0.00");

                //  Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
                // lblClosingBalance1.Text = closebal.ToString("####0.00");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtname.Text != "")
            {
                ListItem value = ddlagent1.Items.FindByText(txtname.Text.ToString());
                if (value != null)
                {
                    ddlagent1.SelectedItem.Value = value.Value;
                    AgentId = Convert.ToInt32(ddlagent1.SelectedValue);
                }
                else
                {
                    AgentId = -1;
                }

            }
            dsFlight = new DataSet();
            if (ViewState["Flight"].ToString() == "Domesticadmin")
            {
                objFlightBal.FlightName = "DomesticAdmin";
                if (ddlsource.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Source = ddlsource.SelectedValue;
                }
                if (ddldestinations.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Destinations = ddldestinations.SelectedValue;
                }
            }
            else if (ViewState["Flight"].ToString() == "IFadmin")
            {
                objFlightBal.FlightName = "IFadmin";
                objFlightBal.Source = txtFrom.Text.Trim();
                objFlightBal.Destinations = txtTo.Text.Trim();
            }


            if (txtfromdate.Text != "")
            {
                DateTime dt = DateTime.Parse(txtfromdate.Text, CultureInfo.GetCultureInfo("en-gb"));

                objFlightBal.DateOfJourney = Convert.ToDateTime(dt.ToShortDateString());
            }
            else
            {
                objFlightBal.DateOfJourney = null;
            }

            if (txttodate.Text != "")
            {
                DateTime dt1 = DateTime.Parse(txttodate.Text, CultureInfo.GetCultureInfo("en-gb"));
                objFlightBal.DateOfIssue = Convert.ToDateTime(dt1.ToShortDateString());
            }
            else
            {
                objFlightBal.DateOfIssue = null;
            }
            objFlightBal.Name = txtname.Text.Trim();
            objFlightBal.EmailId = txtemailId.Text.Trim();
            objFlightBal.RefNo = txtrefno.Text.Trim();
            // objFlightBal.Operator = ddloperator.SelectedValue;
            objFlightBal.ContactNo = txtcontactno.Text.Trim();
            objFlightBal.Status = ddlstatus.SelectedValue;
            // objFlightBal.PageSize = ddlpagesize.SelectedValue;
            objFlightBal.TableName = "Search";
            objFlightBal.CreatedBy = AgentId;
            dsFlight = objFlightBal.FlightSearch(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
                  
                    GvFlightsReports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();

                }
                else
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                }
            }


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ddldestinations.ClearSelection();
        ddlpagesize.ClearSelection();
        ddlsource.ClearSelection();
        ddlstatus.ClearSelection();
        txtcontactno.Text = "";
        txtdate.Text = "";
        txtemailId.Text = "";
        txtname.Text = "";
        txtrefno.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = "";
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string[] GetAirportCodes(string prefixText)
    {
        try
        {

            //string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=F:\\LoveJourney\\LoveJourneyCode\\LoveJourneyUI\\DOCS\\International_AirportCodes.xlsx;Extended Properties=Excel 12.0;HDR=YES;IMEX=1";

            string connstr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\21082012 Onwards\\Test1\\DOCS\\International_AirportCodes.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES""");
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
                airports.Add(dtNew.Rows[i]["CityName_"].ToString() + "," + dtNew.Rows[i]["AirportDesc_"].ToString() + " - (" + dtNew.Rows[i]["AirportCode_"].ToString() + ")");
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

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
        DataTable dt = ((DataTable)Session["GvReports"]);
        //GetData().Tables[0];
        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + direction;

        GvFlightsReports.DataSource = dv;
        GvFlightsReports.DataBind();

    }
    protected void GvFlightsReports_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void GvFlightsReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvFlightsReports.PageIndex = e.NewPageIndex;
            GvFlightsReports.DataSource = Session["GvReports"];
            GvFlightsReports.DataBind();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void GvFlightsReports_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "print")
        {
            string refno;
            refno = e.CommandArgument.ToString();

            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {
                GetDetailsForPrint(refno);
            }
            else if (rdlflights.SelectedItem.Text == "International Flights")
            {
                getdetailsForInternationalPirnt(refno);
            }
        }

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
                string customerDetails = dsFlights.Tables[0].Rows[0]["Customer_Details"].ToString();
                string[] strArryCustDet = customerDetails.Split('|');
                lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                lblTel.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();
                lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["airlineName"].ToString();
                lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                // img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');

                DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                string date = dt.ToString("dd/MM/yyyy");
                lblDepartureDate.Text = date.ToString();
               // lblDepartureDate.Text = strArryDeptDatetime[0].ToString();


                lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                string[] strArrivalDatetime = ArrivalDatetime.Split('T');


                DateTime dt1 = Convert.ToDateTime(strArrivalDatetime[0].ToString());
                string date1 = dt1.ToString("dd/MM/yyyy");
                lblArrivalDate.Text = date1.ToString();

               // lblArrivalDate.Text = strArryDeptDatetime[0].ToString();

                lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();
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
                    dr["Age"] = "-";
                    dtPsgrDet.Rows.Add(dr);
                }

                gdvPassengerDetails.DataSource = dtPsgrDet;
                gdvPassengerDetails.DataBind();
                lblPassengerType.Text = strArryCustDet[3];
                lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TMarkUp"])).ToString();
                lblTotal.Text = (Convert.ToDouble(lblBasicFare.Text) + Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text)).ToString(); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();



            }
            trtable.Visible = false;
            trgv.Visible = false;
            pnlmail.Visible = true;
            trback.Visible = true;
            printroundtrip.Visible = false;
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
                    DateTime dt3 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                    string date3 = dt3.ToString("dd/MM/yyyy");
                    lblDepartureDatereturn.Text = date3.ToString();
                    //  lblDepartureDatereturn.Text = dt3.ToLongDateString();
                    lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                    DateTime dt4 = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                    string date4 = dt4.ToString("dd/MM/yyyy");
                    lblArrivalDatereturn.Text = date4.ToString();
                    lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                    // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();
                    string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                    string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                    string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TchargeRet"])).ToString();
                    string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts)).ToString(); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"].ToString())).ToString();
                    //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString())).ToString();
                    lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                    lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                    lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                    lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");
                }

            }
            //  trprint.Visible = true;

            //Session["ctrl"] = pnlmail;
            //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Agent/Flight/Reports.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            //Control ctrl = (Control)Session["ctrl"];
            //// btnback.Visible = false;
            //PrintHelper.PrintWebControl(ctrl);

        }
        catch (Exception ex)
        {

            throw;
        }

    }

    protected void getdetailsForInternationalPirnt(string RefNo)
    {
        try
        {
            FlightBAL objFlightsBAL = new FlightBAL();
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetInternationalFlightDetails(RefNo.Trim());
            if (dsFlights.Tables[0].Rows.Count > 0)
            {
                string customerDetails = dsFlights.Tables[0].Rows[0]["CustomerDetails"].ToString();
                string[] strArryCustDet = customerDetails.Split('|');
                lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                lblTel.Text = dsFlights.Tables[0].Rows[0]["Telephone"].ToString();
                lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
                //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');


                DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                string date = dt.ToString("dd/MM/yyyy");
                lblDepartureDate.Text = date.ToString();
               // lblDepartureDate.Text = strArryDeptDatetime[0].ToString();


                lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                string[] strArrivalDatetime = ArrivalDatetime.Split('T');

                DateTime dt1 = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                string date1 = dt1.ToString("dd/MM/yyyy");
                lblArrivalDate.Text = date1.ToString();
               // lblArrivalDate.Text = strArryDeptDatetime[0].ToString();


                lblArrivalTime.Text = strArryDeptDatetime[1].ToString();
                lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();
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
                    dr["Type"] = strArryCustDet1[3];
                    dr["Age"] = "-";
                    dtPsgrDet.Rows.Add(dr);
                }

                gdvPassengerDetails.DataSource = dtPsgrDet;
                gdvPassengerDetails.DataBind();
                lblPassengerType.Text = strArryCustDet[3];
                lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"])).ToString(); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                lblTotal.Text = (Convert.ToDouble(lblBasicFare.Text) + ((Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text)))).ToString(); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();

                trtable.Visible = false;
                trgv.Visible = false;
                pnlmail.Visible = true;
                trback.Visible = true;
                printroundtrip.Visible = false;
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

                        string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                        string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                        DateTime dt3 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                        string date3 = dt3.ToString("dd/MM/yyyy");
                        lblDepartureDatereturn.Text = date3.ToString();
                        lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                        string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                        string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                        DateTime dt4 = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                        string date4 = dt4.ToString("dd/MM/yyyy");
                        lblArrivalDatereturn.Text = date4.ToString();
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

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void lbtnback_Click(object sender, EventArgs e)
    {
        pnlmail.Visible = false;
        trtable.Visible = true;
        trgv.Visible = true;
        trback.Visible = false;
        rdlflights_SelectedIndexChanged(sender, e);
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
        /* -----------------------------------
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        try
        {

            //  GetDetailsForPrint(Refno);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Ticket.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlmail.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        try
        {
            ChangeControlsToValue(GvFlightsReports);
            GvFlightsReports.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            GvFlightsReports.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(GvFlightsReports);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
            GvFlightsReports.Columns[13].Visible = true;
        }
        catch (Exception ex)
        {
            //lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    private void ChangeControlsToValue(Control gridView)
    {
        Literal literal = new Literal();
        for (int i = 0; i < gridView.Controls.Count; i++)
        {
            if (gridView.Controls[i].GetType() == typeof(Button))
            {
                literal.Text = (gridView.Controls[i] as Button).Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(DropDownList))
            {
                literal.Text = (gridView.Controls[i] as DropDownList).SelectedItem.Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(CheckBox))
            {
                literal.Text = (gridView.Controls[i] as CheckBox).Checked ? "True" : "False";
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            if (gridView.Controls[i].HasControls())
            {
                ChangeControlsToValue(gridView.Controls[i]);
            }
        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAgentNames(string prefixText)
    {
        try
        {


            DataSet ds = new DataSet();

            ClsBAL objBal = new ClsBAL();
            ds = objBal.GetAgents();

            string filteringquery = "Username LIKE'" + prefixText + "%'";
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
                airports.Add(dtNew.Rows[i]["Username"].ToString().Trim());
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
    protected void GvFlightsReports_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}