using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Globalization;

public partial class Agent_Bus_AllAgentReports : System.Web.UI.Page
{
    ClsBAL objbal = new ClsBAL();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Panel pnl = (Panel)this.Master.FindControl("Menu1");
            //pnl.Visible = false;
            ds = GetAgents();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlagent1.DataSource = ds;
                    ddlagent1.DataValueField = "AgentId";
                    ddlagent1.DataTextField = "AgentName";
                    ddlagent1.DataBind();

                    ddlagent1.Items.Insert(0, "-Please Select-");
                }

            }

        }
    }
    string Sname;
    int AgentId;
    DateTime FromDate;
    DateTime ToDate;
    string Agent;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlserviceName.SelectedValue == "DomesticFlights")
            {

                Sname = "Dom";
                GvFlightsReports.Visible = true;
                gvMobile.Visible = false;
                gvBookings.Visible = false;
                GridView1.Visible = false;
                gdAllservicesreports.Visible = false;
                //ds=objbal.               
                   // Agent = 0;

            }
            else
                if (ddlserviceName.SelectedValue == "InterNationalFlights")
                {
                    Sname = "IN";
                    GvFlightsReports.Visible = true;
                    gvMobile.Visible = false;
                    gvBookings.Visible = false;
                    GridView1.Visible = false;
                    gdAllservicesreports.Visible = false;
                   // Agent = Convert.ToString(Session["UserName"]);
                   // Agent = 0;
                }
                else
                    if (ddlserviceName.SelectedValue == "Hotels")
                    {
                        Sname = "Hotels";
                        gvMobile.Visible = false;
                        GvFlightsReports.Visible = false;
                        gvBookings.Visible = false;
                        GridView1.Visible = true;
                        gdAllservicesreports.Visible = false;
                       // AgentId = Convert.ToInt32(Session["UserName"]);
                       // AgentId = 0;
                    }

                    else
                        if (ddlserviceName.SelectedValue == "Bus")
                        {
                            Sname = "Bus";
                            gvMobile.Visible = false;
                            GvFlightsReports.Visible = false;
                            gvBookings.Visible = true;
                            GridView1.Visible = false;
                            gdAllservicesreports.Visible = false;
                           // AgentId = Convert.ToInt32(Session["UserID"]);
                          //  AgentId = 0;
                        }
                        else
                            if (ddlserviceName.SelectedValue == "Recharge")
                            {
                                Sname = "Recharge";
                                gvMobile.Visible = true;
                                GvFlightsReports.Visible = false;
                                gvBookings.Visible = false;
                                GridView1.Visible = false;
                                gdAllservicesreports.Visible = false;
                              //  AgentId = Convert.ToInt32(Session["UserID"]);
                              //  AgentId = 0;

                            }
                            else
                                if (ddlserviceName.SelectedValue == "ALL")
                                {
                                    Sname = "Allservicereports";
                                    gvMobile.Visible = false;
                                    GvFlightsReports.Visible = false;
                                    gvBookings.Visible = false;
                                    GridView1.Visible = false;
                                    gdAllservicesreports.Visible = true;
                                    //  AgentId = Convert.ToInt32(Session["UserID"]);
                                    //  AgentId = 0;

                                }
           // if (ddlagent.SelectedItem.Text != "-Please Select-")
          //  {
                //AgentId = Convert.ToInt32(ddlagent.SelectedValue);
                //if (ddlserviceName.SelectedValue == "Recharge" || ddlserviceName.SelectedValue == "Bus" || ddlserviceName.SelectedValue == "Hotels")
                //{
                //   // AgentId = Convert.ToInt32(ddlagent.SelectedValue);
                //   // AgentId = 0;
                //}
           // }
            //else
            //{
            //    AgentId = Convert.ToInt32(Session["UserID"]);
            //  //  Agent = 0;
            //}
            if (txtfrom.Text == "")
            {
              //  FromDate = Convert.ToDateTime("1/1/1990");
                FromDate = Convert.ToDateTime("12/12/2000");
               
            }
            else {
                DateTime dt = DateTime.Parse(txtfrom.Text, CultureInfo.GetCultureInfo("en-gb"));
                FromDate = Convert.ToDateTime(dt.ToShortDateString());
            }
            if (txtto.Text == "")
            {
              //  ToDate = Convert.ToDateTime("1/1/1990");
                ToDate = Convert.ToDateTime("12/12/2020");
            }
            else {
                DateTime dt1 = DateTime.Parse(txtto.Text, CultureInfo.GetCultureInfo("en-gb"));
                ToDate = Convert.ToDateTime(dt1.ToShortDateString());
            }
            AgentId = Convert.ToInt32(Session["UserID"]);
            ds = objbal.AllReports(Sname, AgentId, FromDate, ToDate, Agent,"");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights")
                    {
                        GvFlightsReports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        GvFlightsReports.DataSource = ds;
                        Session["AllReports"] = ds.Tables[0];
                        GvFlightsReports.DataBind();

                    }
                    else if (ddlserviceName.SelectedValue == "Recharge")
                    {
                        gvMobile.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        gvMobile.DataSource = ds;
                        Session["RechargeReports"] = ds.Tables[0];
                        gvMobile.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "Bus")
                    {
                        gvBookings.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        gvBookings.DataSource = ds;
                        Session["BusReports"] = ds.Tables[0];
                        gvBookings.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "Hotels")
                    {
                        GridView1.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        GridView1.DataSource = ds;
                        Session["HotelsReports"] = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "ALL")
                    {
                        gdAllservicesreports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        gdAllservicesreports.DataSource = ds;
                        Session["AllServicesReports"] = ds.Tables[0];
                        gdAllservicesreports.DataBind();
                    }
                }
                else
                {
                    if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights")
                    {
                        GvFlightsReports.DataSource = ds;
                        Session["AllReports"] = ds.Tables[0];
                        GvFlightsReports.DataBind();

                    }
                    else if (ddlserviceName.SelectedValue == "Recharge")
                    {
                        gvMobile.DataSource = ds;
                        Session["RechargeReports"] = ds.Tables[0];
                        gvMobile.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "Bus")
                    {
                        gvBookings.DataSource = ds;
                        Session["BusReports"] = ds.Tables[0];
                        gvBookings.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "Hotels")
                    {
                        GridView1.DataSource = ds;
                        Session["HotelsReports"] = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    else if (ddlserviceName.SelectedValue == "ALL")
                    {
                        gdAllservicesreports.DataSource = ds;
                        Session["AllServicesReports"] = ds.Tables[0];
                        gdAllservicesreports.DataBind();
                    }
                }
                //else
                //{
                //    GvFlightsReports.DataSource = ds;
                //    Session["AllReports"] = ds;
                //    GvFlightsReports.DataBind();
                //}
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    DataSet GetAgents()
    {
        try
        {
            objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void GvFlightsReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvFlightsReports.PageIndex = e.NewPageIndex;
            if (Session["AllReports"] != null)
            {
                GvFlightsReports.DataSource = Session["AllReports"];
                GvFlightsReports.DataBind();
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
    double LjFare;
    double markup;
    double refund;
    double ccharge;
    double closebal;
    double MBFare;
    protected void GvFlightsReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TPartnerCommission"));
            scharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Scharge"));
            discount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDiscount"));
            LjFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PayableAmt"));
          //  Charge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TCharge"));
            markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

            refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
            ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
          //  MBFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
            closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));


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

           // Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
           // lblMBFare.Text = Convert.ToDouble(lblMBFare.Text).ToString("####0.00");

            Label lblTPartnerCommission = (Label)e.Row.FindControl("lblTPartnerCommission");
            lblTPartnerCommission.Text = Convert.ToDouble(lblTPartnerCommission.Text).ToString("####0.00");

          //  Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");
          //  lblTCharge.Text = Convert.ToDouble(lblTCharge.Text).ToString("####0.00");

            Label lblTMarkUp = (Label)e.Row.FindControl("lblTMarkUp");
            lblTMarkUp.Text = Convert.ToDouble(lblTMarkUp.Text).ToString("####0.00");

            Label lblRefundAmount = (Label)e.Row.FindControl("lblRefundAmount");
            lblRefundAmount.Text = Convert.ToDouble(lblRefundAmount.Text).ToString("####0.00");

            Label lblCancellationCharges = (Label)e.Row.FindControl("lblCancellationCharges");
            lblCancellationCharges.Text = Convert.ToDouble(lblCancellationCharges.Text).ToString("####0.00");

            Label lblClosingBalance = (Label)e.Row.FindControl("lblClosingBalance");
            lblClosingBalance.Text = Convert.ToDouble(lblClosingBalance.Text).ToString("####0.00");
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblPayableAmt1 = (Label)e.Row.FindControl("lblPayableAmt1");
            lblPayableAmt1.Text = LjFare.ToString("####0.00");

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
           // Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
            //lblMBFare.Text = MBFare.ToString("####0.00");

            Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
            lblClosingBalance1.Text = closebal.ToString("####0.00");
        }





    }
    protected void gvMobile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvMobile.PageIndex = e.NewPageIndex;
            if (Session["RechargeReports"] != null)
            {
                gvMobile.DataSource = Session["RechargeReports"];
                gvMobile.DataBind();
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


        if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights")
        {
            DataTable dt = ((DataTable)Session["AllReports"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GvFlightsReports.DataSource = dv;
            GvFlightsReports.DataBind();

        }
        else if (ddlserviceName.SelectedValue == "Recharge")
        {
            DataTable dt = ((DataTable)Session["RechargeReports"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            gvMobile.DataSource = dv;
            gvMobile.DataBind();
        }
        else if (ddlserviceName.SelectedValue == "Bus")
        {
            DataTable dt = ((DataTable)Session["BusReports"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            gvBookings.DataSource = dv;
            gvBookings.DataBind();
        }
        else if (ddlserviceName.SelectedValue == "Hotels")
        {
            DataTable dt = ((DataTable)Session["HotelsReports"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        else if (ddlserviceName.SelectedValue == "ALL")
        {
            DataTable dt = ((DataTable)Session["AllServicesReports"]);
            //GetData().Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = sortExpression + direction;
            gdAllservicesreports.DataSource = dv;
            gdAllservicesreports.DataBind();
        }


    }
    protected void gdAllservicesreports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdAllservicesreports.PageIndex = e.NewPageIndex;
            if (Session["AllServicesReports"] != null)
            {
                gdAllservicesreports.DataSource = Session["AllServicesReports"];
                gdAllservicesreports.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
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
    protected void gdAllservicesreports_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gvMobile_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gvBookings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBookings.PageIndex = e.NewPageIndex;
            if (Session["BusReports"] != null)
            {
                gvBookings.DataSource = Session["BusReports"];
                gvBookings.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvBookings_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBookings.PageIndex = e.NewPageIndex;
            if (Session["HotelsReports"] != null)
            {
                GridView1.DataSource = Session["HotelsReports"];
                GridView1.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ActualFare"));
            commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));

            LjFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PayableAmt"));
            refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
            ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));

            closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));

            Label lblActualBasefare = (Label)e.Row.FindControl("lblActualFare");
            lblActualBasefare.Text = Convert.ToDouble(lblActualBasefare.Text).ToString("####0.00");



            Label lblTPartnerCommission = (Label)e.Row.FindControl("lblTPartnerCommission");
            lblTPartnerCommission.Text = Convert.ToDouble(lblTPartnerCommission.Text).ToString("####0.00");



            Label lblRefundAmount = (Label)e.Row.FindControl("lblRefundAmount");
            lblRefundAmount.Text = Convert.ToDouble(lblRefundAmount.Text).ToString("####0.00");

            Label lblCancellationCharges = (Label)e.Row.FindControl("lblCancellationCharges");
            lblCancellationCharges.Text = Convert.ToDouble(lblCancellationCharges.Text).ToString("####0.00");

            Label lblClosingBalance = (Label)e.Row.FindControl("lblClosingBalance");
            lblClosingBalance.Text = Convert.ToDouble(lblClosingBalance.Text).ToString("####0.00");
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblPayableAmt1 = (Label)e.Row.FindControl("lblPayableAmt1");
            lblPayableAmt1.Text = LjFare.ToString("####0.00");

            Label lblcomm = (Label)e.Row.FindControl("lblcomm");
            lblcomm.Text = commission.ToString("####0.00");

            Label lblactulafare = (Label)e.Row.FindControl("lblactulafare");
            lblactulafare.Text = actualfare.ToString("####0.00");



            Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmount1");
            lblRefundAmount1.Text = refund.ToString("####0.00");
            Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationCharges1");
            lblCancellationCharges1.Text = ccharge.ToString("####0.00");


            Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
            lblClosingBalance1.Text = closebal.ToString("####0.00");
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddlserviceName.ClearSelection();
        txtfrom.Text = "";
        txtto.Text = "";
        GvFlightsReports.Visible = false;
        gvMobile.Visible = false;
        gvBookings.Visible = false;
        GridView1.Visible = false;
        
    }
    double CancellationCharges = 0;
    double RefundAmount = 0;
    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalFare"));
            commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
            RefundAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
            CancellationCharges += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
            LjFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AmountPayable"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblAmountPayable1 = (Label)e.Row.FindControl("lblAmountPayable1");
            lblAmountPayable1.Text = LjFare.ToString("####0.00");

            Label lblCancellationChargesTotal = (Label)e.Row.FindControl("lblCancellationChargesTotal");
            lblCancellationChargesTotal.Text = CancellationCharges.ToString("####0.00");
            Label lblRefundAmountTotal = (Label)e.Row.FindControl("lblRefundAmountTotal");
            lblRefundAmountTotal.Text = RefundAmount.ToString("####0.00");
            Label lblCommisionFareTotal = (Label)e.Row.FindControl("lblCommisionFareTotal");
            lblCommisionFareTotal.Text = commission.ToString("####0.00");
            Label lblactulafare = (Label)e.Row.FindControl("lblActualFareTotal");
            lblactulafare.Text = actualfare.ToString("####0.00");        


           
        }
    }
    
    protected void gdAllservicesreports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

               // Label lblAmount1 = (Label)e.Row.FindControl("lblserviceActualFare");
                //lblAmount1.Text = Convert.ToDouble(lblAmount1.Text).ToString("####0.00");

                //Label lblserviceMBFare1 = (Label)e.Row.FindControl("lblserviceMBFare");
               // lblserviceMBFare1.Text = Convert.ToDouble(lblAmount1.Text).ToString("####0.00");


               // Label lblserviceCommisionFare1 = (Label)e.Row.FindControl("lblserviceCommisionFare");
                //lblserviceCommisionFare1.Text = Convert.ToDouble(lblAmount1.Text).ToString("####0.00");


              //Label lblserviceClosingBalance1 = (Label)e.Row.FindControl("lblserviceClosingBalance");
              // lblserviceClosingBalance1.Text = Convert.ToDouble(lblAmount1.Text).ToString("####0.00");





            }
           
        }
    }
   
}