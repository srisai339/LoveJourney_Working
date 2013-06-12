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
public partial class Users_Flight_GuestReports : System.Web.UI.Page
{
    FlightBAL objFlightBal = new FlightBAL();
    DataSet dsFlight;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ds = GetAgents();
            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        ddlagent1.DataSource = ds;
            //        ddlagent1.DataTextField = "Username";
            //        ddlagent1.DataValueField = "ID";
            //        ddlagent1.DataBind();

            //        ddlagent1.Items.Insert(0, "-Please Select-");
            //    }

            //}

        }
    }
    DataSet GetAgents()
    {
        try
        {
            ClsBAL objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void rdlflights_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            source3.Visible = true;
            Button1_Click(sender, e);
            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {
                IF.Visible = false;
                Domestic.Visible = true;

                objFlightBal.TableName = "FlightGuestDomestic";
                ViewState["Flight"] = "Domestic";

            }
            else if (rdlflights.SelectedItem.Text == "International Flights")
            {
                IF.Visible = true;
                Domestic.Visible = false;
                objFlightBal.TableName = "FlightGuestInternational";
                ViewState["Flight"] = "IF";
            }

            if (txtfromdate.Text != "")
            {
                objFlightBal.DateOfJourney = Convert.ToDateTime(txtfromdate.Text);
            }
            else
            {
                objFlightBal.DateOfJourney = null;
            }
            if (txttodate.Text != "")
            {
                objFlightBal.DateOfIssue = Convert.ToDateTime(txttodate.Text);
            }
            else
            {
                objFlightBal.DateOfIssue = null;
            }
            objFlightBal.RefNo = txtrefno.Text.Trim();
            dsFlight = objFlightBal.GetGuestReports(objFlightBal);
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
                Label lblDepartureDateTime = (Label)e.Row.FindControl("lblDepartureDateTime");
                if (lblDepartureDateTime.Text.Contains('T'))
                {
                    string[] s = lblDepartureDateTime.Text.Split('T');
                    DateTime dt = Convert.ToDateTime(s[0].ToString());
                    lblDepartureDateTime.Text = dt.ToString("dd-MM-yyyy");
                }
                Label lblArrivalAirportName = (Label)e.Row.FindControl("lblArrivalAirportName");

                actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TPartnerCommission"));
                scharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Scharge"));
                discount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDiscount"));
                Charge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TCharge"));
                markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

                //refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                //ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                //closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));

                Label lblCustomerDetails = (Label)e.Row.FindControl("lblCustomerDetails");
                if (lblCustomerDetails.Text != "")
                {
                    string[] strCusDet = lblCustomerDetails.Text.Split('|');
                    lblCustomerDetails.Text = strCusDet[0] + " " + strCusDet[1] + " " + strCusDet[2];
                }
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


                //Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmount1");
                //lblRefundAmount1.Text = refund.ToString("####0.00");
                //Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationCharges1");
                //lblCancellationCharges1.Text = ccharge.ToString("####0.00");
                //Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
                //lblClosingBalance1.Text = closebal.ToString("####0.00");
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    int AgentId;
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtname.Text != "")
            //{
            //    ListItem value = ddlagent1.Items.FindByText(txtname.Text.ToString());
            //    if (value != null)
            //    {
            //        ddlagent1.SelectedItem.Value = value.Value;
            //        AgentId = Convert.ToInt32(ddlagent1.SelectedValue);
            //    }
            //    else
            //    {
            //        AgentId = -1;
            //    }

            //}
            if (ViewState["Flight"].ToString() == "Domestic")
            {
                objFlightBal.TableName = "FlightGuestDomestic";
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
                objFlightBal.TableName = "FlightGuestInternational";
                objFlightBal.Source = txtFrom.Text.Trim();
                objFlightBal.Destinations = txtTo.Text.Trim();
            }


            if (txtfromdate.Text != "")
            {
                objFlightBal.DateOfJourney = Convert.ToDateTime(txtfromdate.Text);
            }
            else
            {
                objFlightBal.DateOfJourney = null;
            }
            if (txttodate.Text != "")
            {
                objFlightBal.DateOfIssue = Convert.ToDateTime(txttodate.Text);
            }
            else
            {
                objFlightBal.DateOfIssue = null;
            }
        
            objFlightBal.RefNo = txtrefno.Text.Trim();
            dsFlight = objFlightBal.GetGuestReports(objFlightBal);
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
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
            lblmsg.ForeColor = System.Drawing.Color.Red;
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
      //  txtname.Text = "";
        txtrefno.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = "";
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
            if (Session["GvReports"] != null)
            {
                GvFlightsReports.DataSource = Session["GvReports"];
                GvFlightsReports.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
  
}