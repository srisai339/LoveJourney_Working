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
public partial class Users_Flight_frmCancelReports : System.Web.UI.Page
{
    FlightBAL objFlightBal = new FlightBAL();
    DataSet dsFlight;
    DataSet objDataSet;
    ClsBAL objBAL;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            CheckPermission("FlightsCancelReports", Session["Role"].ToString());
        }
    }

    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            panelBookingStatus.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                panelBookingStatus.Visible = false;

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
                            panelBookingStatus.Visible = true;
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

            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {
                IF.Visible = false;
                Domestic.Visible = true;

                objFlightBal.FlightName = "Domestic";
                ViewState["Flight"] = "Domestic";

            }
            else if (rdlflights.SelectedItem.Text == "InterNational Flights")
            {
                IF.Visible = true;
                Domestic.Visible = false;
                objFlightBal.FlightName = "IF";
                ViewState["Flight"] = "IF";
            }
            dsFlight = objFlightBal.GetFlights(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
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
    double actualfare;
    double commission;
    double scharge;
    double discount;
    double Charge;
    double markup;
    double refund;
    double ccharge;
    double closebal;
    protected void GvFlightsReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ActualBasefare"));
                commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TPartnerCommission"));
                scharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Scharge"));
                discount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDiscount"));
                Charge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TCharge"));
                markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

                refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                //closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));
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
            if (ViewState["Flight"].ToString() == "Domestic")
            {
                objFlightBal.FlightName = "Domestic";
                if (ddlsource.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Source = ddlsource.SelectedValue;
                }
                if (ddldestinations.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Destinations = ddldestinations.SelectedValue;
                }
            }
            else if (ViewState["Flight"].ToString() == "IF")
            {
                objFlightBal.FlightName = "IF";
                objFlightBal.Source = txtFrom.Text.Trim();
                objFlightBal.Destinations = txtTo.Text.Trim();
            }


            if (txtdate.Text != "")
            {
                objFlightBal.DateOfJourney = Convert.ToDateTime(txtdate.Text);
            }
            else
            {
                objFlightBal.DateOfJourney = null;
            }
            //if (txtdateofissue.Text != "")
            //{
            //    objFlightBal.DateOfIssue = Convert.ToDateTime(txtdateofissue.Text);
            //}
            //else
            //{
            objFlightBal.DateOfIssue = null;
            // }
            objFlightBal.Name = txtname.Text.Trim();
            objFlightBal.EmailId = txtemailId.Text.Trim();
            objFlightBal.RefNo = txtrefno.Text.Trim();
            // objFlightBal.Operator = ddloperator.SelectedValue;
            objFlightBal.ContactNo = txtcontactno.Text.Trim();
            objFlightBal.Status = ddlstatus.SelectedValue;
            // objFlightBal.PageSize = ddlpagesize.SelectedValue;
            objFlightBal.TableName = "Search";
            dsFlight = objFlightBal.FlightSearch(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
                    if (ddlpagesize.SelectedValue != "ALL")
                    {
                        GvFlightsReports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                    }
                    else
                    {
                        GvFlightsReports.PageSize = 10;
                    }
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
}