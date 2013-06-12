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
using System.Globalization;
using System.Web.UI.HtmlControls;



public partial class Users_AdminDashBoard_AllReports : System.Web.UI.Page
{
    ClsBAL objbal = new ClsBAL();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Distributor")
                {
                    Response.Redirect("~/AllAgentReports.aspx");
                }
            }
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;

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
    }
    string Sname;
    int AgentId;
    DateTime FromDate;
    DateTime ToDate;
    string Agent;
    bool b = true;
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
          
            if (ddlagent.Text != "")
            {
                ListItem value = ddlagent1.Items.FindByText(ddlagent.Text.ToString());
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
            if (ddlserviceName.SelectedValue == "DomesticFlights")
            {

                Sname = "Dom";
                GvFlightsReports.Visible = true;
                gvMobile.Visible = false;
                gvBookings.Visible = false;
                GridView1.Visible = false;
                gdAllservicesreports.Visible = false;
                GvFlightsReports.PageSize =Convert.ToInt32(ddlpagesize.SelectedValue);
               
                btnExport.Visible = true;
                //ds=objbal.

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
                    GvFlightsReports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                   
                    btnExport.Visible = true;
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
                        GridView1.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                        btnExport.Visible = true;
                        gvCabBookings.Visible = false;

                        
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
                            gvBookings.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                            btnExport.Visible = true;
                            gvCabBookings.Visible = false;

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
                                gvMobile.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                                btnExport.Visible = true;
                                gvCabBookings.Visible = false;


                            }
            else if(ddlserviceName.SelectedValue == "ALL")
                            {
                                Sname = "Allservicereports";
                                gvMobile.Visible = false;
                                GvFlightsReports.Visible = false;
                                gvBookings.Visible = false;
                                GridView1.Visible = false;
                                gdAllservicesreports.Visible = true;
                                gdAllservicesreports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                                btnExport.Visible = true;
                                gvCabBookings.Visible = false;


                            }

                            else if (ddlserviceName.SelectedValue == "Cab")
                            {
                                Sname = "Cab";
                                gvMobile.Visible = false;
                                GvFlightsReports.Visible = false;
                                gvBookings.Visible = false;
                                GridView1.Visible = false;
                                gdAllservicesreports.Visible = false;
                                gdAllservicesreports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);
                                btnExport.Visible = true;
                                gvCabBookings.Visible = true;

                            }

            if (txtfrom.Text != "" && txtto.Text != "")
            {
                DateTime dt = DateTime.Parse(txtfrom.Text, CultureInfo.GetCultureInfo("en-gb"));
                DateTime dt1 = DateTime.Parse(txtto.Text, CultureInfo.GetCultureInfo("en-gb"));
                //dt = Convert.ToDateTime(dt.ToShortDateString()); 
                FromDate = Convert.ToDateTime(dt.ToShortDateString());
                ToDate = Convert.ToDateTime(dt1.ToShortDateString());
            }
            else
            {

                FromDate = Convert.ToDateTime("12/12/2000");
                ToDate = Convert.ToDateTime("12/12/2020");

            }
       
                ds = objbal.AllReports(Sname, AgentId, FromDate, ToDate, Agent,txtRefNo.Text);
           
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
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

                    else if (ddlserviceName.SelectedValue == "Cab")
                    {
                        gvCabBookings.DataSource = ds;
                        Session["CabReports"] = ds.Tables[0];
                        gvCabBookings.DataBind();

                    }
                }
                else
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
            markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

            refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
            ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
            // MBFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
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

            //Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
            //lblMBFare.Text = Convert.ToDouble(lblMBFare.Text).ToString("####0.00");

            Label lblTPartnerCommission = (Label)e.Row.FindControl("lblTPartnerCommission");
            lblTPartnerCommission.Text = Convert.ToDouble(lblTPartnerCommission.Text).ToString("####0.00");

            //Label lblTCharge = (Label)e.Row.FindControl("lblTCharge");
            //lblTCharge.Text = Convert.ToDouble(lblTCharge.Text).ToString("####0.00");

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
            //  Label lblMBFare = (Label)e.Row.FindControl("lblMBFare");
            // lblMBFare.Text = MBFare.ToString("####0.00");

            Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
            lblClosingBalance1.Text = closebal.ToString("####0.00");
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
    protected void gdAllservicesreports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ActualFare"));
            commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
            LjFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));

           // refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
          //  ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));

            closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));

            Label lblserviceActualFare = (Label)e.Row.FindControl("lblserviceActualFare");
            lblserviceActualFare.Text = Convert.ToDouble(lblserviceActualFare.Text).ToString("####0.00");



            Label lblserviceCommisionFare = (Label)e.Row.FindControl("lblserviceCommisionFare");
            lblserviceCommisionFare.Text = Convert.ToDouble(lblserviceCommisionFare.Text).ToString("####0.00");



            //Label lblRefundAmount = (Label)e.Row.FindControl("lblRefundAmount");
            //lblRefundAmount.Text = Convert.ToDouble(lblRefundAmount.Text).ToString("####0.00");

            //Label lblCancellationCharges = (Label)e.Row.FindControl("lblCancellationCharges");
            //lblCancellationCharges.Text = Convert.ToDouble(lblCancellationCharges.Text).ToString("####0.00");

            Label lblserviceClosingBalance = (Label)e.Row.FindControl("lblserviceClosingBalance");
            lblserviceClosingBalance.Text = Convert.ToDouble(lblserviceClosingBalance.Text).ToString("####0.00");
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblPayableAmt1 = (Label)e.Row.FindControl("lblserviceljfare");
            lblPayableAmt1.Text = LjFare.ToString("####0.00");

            Label lblcomm = (Label)e.Row.FindControl("lblservicecomm");
            lblcomm.Text = commission.ToString("####0.00");

            Label lblactulafare = (Label)e.Row.FindControl("lblserviceActfare");
            lblactulafare.Text = actualfare.ToString("####0.00");



            //Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmount1");
            //lblRefundAmount1.Text = refund.ToString("####0.00");
            //Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationCharges1");
            //lblCancellationCharges1.Text = ccharge.ToString("####0.00");


            //Label lblClosingBalance1 = (Label)e.Row.FindControl("lblserviceFclosingbalance");
            //lblClosingBalance1.Text = closebal.ToString("####0.00");
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
    protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
    {
       
       if (ddlserviceName.SelectedValue == "DomesticFlights")
        {

           


            try
            {
                GvFlightsReports.AllowPaging = true;
                if (Session["AllReports"] != null)
            {
                if (ddlpagesize.SelectedValue == "100")
                {
                    GvFlightsReports.PageSize = 100;
                    GvFlightsReports.PageIndex = 0;
                    GvFlightsReports.DataSource = Session["AllReports"];
                    GvFlightsReports.DataBind();
                }
                else if (ddlpagesize.SelectedValue == "150")
                {
                    GvFlightsReports.PageSize = 150;
                    GvFlightsReports.PageIndex = 0;
                    GvFlightsReports.DataSource = Session["AllReports"];
                    GvFlightsReports.DataBind();
                }
                else if (ddlpagesize.SelectedValue == "200")
                {
                    GvFlightsReports.PageSize = 200;
                    GvFlightsReports.PageIndex = 0;
                    GvFlightsReports.DataSource = Session["AllReports"];
                    GvFlightsReports.DataBind();
                }
                else if (ddlpagesize.SelectedValue == "250")
                {
                    GvFlightsReports.PageSize = 250;
                    GvFlightsReports.PageIndex = 0;
                    GvFlightsReports.DataSource = Session["AllReports"];
                    GvFlightsReports.DataBind();
                }
                else if (ddlpagesize.SelectedValue == "300")
                {
                    GvFlightsReports.PageSize = 300;
                    GvFlightsReports.PageIndex = 0;
                    GvFlightsReports.DataSource = Session["AllReports"];
                    GvFlightsReports.DataBind();
                }
            }
            }
            catch (Exception ex)
            {
                //lblMsg.InnerHtml = ex.Message;
                throw ex;
            }
            //ds=objbal.

        }
        else
            if (ddlserviceName.SelectedValue == "InterNationalFlights")
            {
                try
                {
                    GvFlightsReports.AllowPaging = true;
                    if (Session["AllReports"] != null)
                    {
                        if (ddlpagesize.SelectedValue == "100")
                        {
                            GvFlightsReports.PageSize = 100;
                            GvFlightsReports.PageIndex = 0;
                            GvFlightsReports.DataSource = Session["AllReports"];
                            GvFlightsReports.DataBind();
                        }
                        else if (ddlpagesize.SelectedValue == "150")
                        {
                            GvFlightsReports.PageSize = 150;
                            GvFlightsReports.PageIndex = 0;
                            GvFlightsReports.DataSource = Session["AllReports"];
                            GvFlightsReports.DataBind();
                        }
                        else if (ddlpagesize.SelectedValue == "200")
                        {
                            GvFlightsReports.PageSize = 200;
                            GvFlightsReports.PageIndex = 0;
                            GvFlightsReports.DataSource = Session["AllReports"];
                            GvFlightsReports.DataBind();
                        }
                        else if (ddlpagesize.SelectedValue == "250")
                        {
                            GvFlightsReports.PageSize = 250;
                            GvFlightsReports.PageIndex = 0;
                            GvFlightsReports.DataSource = Session["AllReports"];
                            GvFlightsReports.DataBind();
                        }
                        else if (ddlpagesize.SelectedValue == "300")
                        {
                            GvFlightsReports.PageSize = 300;
                            GvFlightsReports.PageIndex = 0;
                            GvFlightsReports.DataSource = Session["AllReports"];
                            GvFlightsReports.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //lblMsg.InnerHtml = ex.Message;
                    throw ex;
                }
                //ds=objbal.
            }
            else
                if (ddlserviceName.SelectedValue == "Hotels")
                {


                    try
                    {
                        GridView1.AllowPaging = true;
                        if (Session["HotelsReports"] != null)
                        {
                            if (ddlpagesize.SelectedValue == "100")
                            {
                                GridView1.PageSize = 100;
                                GridView1.PageIndex = 0;
                                GridView1.DataSource = Session["HotelsReports"];
                                GridView1.DataBind();
                            }
                            else if (ddlpagesize.SelectedValue == "150")
                            {
                                GridView1.PageSize = 150;
                                GridView1.PageIndex = 0;
                                GridView1.DataSource = Session["HotelsReports"];
                                GridView1.DataBind();
                            }
                            else if (ddlpagesize.SelectedValue == "200")
                            {
                                GridView1.PageSize = 200;
                                GridView1.PageIndex = 0;
                                GridView1.DataSource = Session["HotelsReports"];
                                GridView1.DataBind();
                            }
                            else if (ddlpagesize.SelectedValue == "250")
                            {
                                GridView1.PageSize = 250;
                                GridView1.PageIndex = 0;
                                GridView1.DataSource = Session["HotelsReports"];
                                GridView1.DataBind();
                            }
                            else if (ddlpagesize.SelectedValue == "300")
                            {
                                GridView1.PageSize = 300;
                                GridView1.PageIndex = 0;
                                GridView1.DataSource = Session["HotelsReports"];
                                GridView1.DataBind();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //lblMsg.InnerHtml = ex.Message;
                        throw ex;
                    }

                }

                else
                    if (ddlserviceName.SelectedValue == "Bus")
                    {


                        try
                        {
                            gvBookings.AllowPaging = true;
                            if (Session["BusReports"] != null)
                            {
                                if (ddlpagesize.SelectedValue == "100")
                                {
                                    gvBookings.PageSize = 100;
                                    gvBookings.PageIndex = 0;
                                    gvBookings.DataSource = Session["BusReports"];
                                    gvBookings.DataBind();
                                }
                                else if (ddlpagesize.SelectedValue == "150")
                                {
                                    gvBookings.PageSize = 150;
                                    gvBookings.PageIndex = 0;
                                    gvBookings.DataSource = Session["BusReports"];
                                    gvBookings.DataBind();
                                }
                                else if (ddlpagesize.SelectedValue == "200")
                                {
                                    gvBookings.PageSize = 200;
                                    gvBookings.PageIndex = 0;
                                    gvBookings.DataSource = Session["BusReports"];
                                    gvBookings.DataBind();
                                }
                                else if (ddlpagesize.SelectedValue == "250")
                                {
                                    gvBookings.PageSize = 250;
                                    gvBookings.PageIndex = 0;
                                    gvBookings.DataSource = Session["BusReports"];
                                    gvBookings.DataBind();
                                }
                                else if (ddlpagesize.SelectedValue == "300")
                                {
                                    gvBookings.PageSize = 300;
                                    gvBookings.PageIndex = 0;
                                    gvBookings.DataSource = Session["BusReports"];
                                    gvBookings.DataBind();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //lblMsg.InnerHtml = ex.Message;
                            throw ex;
                        }

                       
                    }
                    else
                        if (ddlserviceName.SelectedValue == "Recharge")
                        {



                            try
                            {
                                gvMobile.AllowPaging = true;
                                if (Session["RechargeReports"] != null)
                                {
                                    if (ddlpagesize.SelectedValue == "100")
                                    {
                                        gvMobile.PageSize = 100;
                                        gvMobile.PageIndex = 0;
                                        gvMobile.DataSource = Session["RechargeReports"];
                                        gvMobile.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "150")
                                    {
                                        gvMobile.PageSize = 150;
                                        gvMobile.PageIndex = 0;
                                        gvMobile.DataSource = Session["RechargeReports"];
                                        gvMobile.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "200")
                                    {
                                        gvMobile.PageSize = 200;
                                        gvMobile.PageIndex = 0;
                                        gvMobile.DataSource = Session["RechargeReports"];
                                        gvMobile.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "250")
                                    {
                                        gvMobile.PageSize = 250;
                                        gvMobile.PageIndex = 0;
                                        gvMobile.DataSource = Session["RechargeReports"];
                                        gvMobile.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "300")
                                    {
                                        gvMobile.PageSize = 300;
                                        gvMobile.PageIndex = 0;
                                        gvMobile.DataSource = Session["RechargeReports"];
                                        gvMobile.DataBind();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //lblMsg.InnerHtml = ex.Message;
                                throw ex;
                            }




                        }
                        else if (ddlserviceName.SelectedValue == "ALL")
                        {

                            try
                            {
                                gvMobile.AllowPaging = true;
                                if (Session["AllServicesReports"] != null)
                                {
                                    if (ddlpagesize.SelectedValue == "100")
                                    {
                                        gdAllservicesreports.PageSize = 100;
                                        gdAllservicesreports.PageIndex = 0;
                                        gdAllservicesreports.DataSource = Session["AllServicesReports"];
                                        gdAllservicesreports.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "150")
                                    {
                                        gdAllservicesreports.PageSize = 150;
                                        gdAllservicesreports.PageIndex = 0;
                                        gdAllservicesreports.DataSource = Session["AllServicesReports"];
                                        gdAllservicesreports.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "200")
                                    {
                                        gdAllservicesreports.PageSize = 200;
                                        gdAllservicesreports.PageIndex = 0;
                                        gdAllservicesreports.DataSource = Session["AllServicesReports"];
                                        gdAllservicesreports.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "250")
                                    {
                                        gdAllservicesreports.PageSize = 250;
                                        gdAllservicesreports.PageIndex = 0;
                                        gdAllservicesreports.DataSource = Session["AllServicesReports"];
                                        gdAllservicesreports.DataBind();
                                    }
                                    else if (ddlpagesize.SelectedValue == "300")
                                    {
                                        gdAllservicesreports.PageSize = 300;
                                        gdAllservicesreports.PageIndex = 0;
                                        gdAllservicesreports.DataSource = Session["AllServicesReports"];
                                        gdAllservicesreports.DataBind();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //lblMsg.InnerHtml = ex.Message;
                                throw ex;
                            }
                        }


        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtfrom.Text = "";
        txtto.Text = "";
        ddlagent.Text = "";
        ddlserviceName.ClearSelection();
        GridView1.Visible = false;
        gdAllservicesreports.Visible = false;
        GvFlightsReports.Visible = false;
        gvMobile.Visible = false;
        gvBookings.Visible = false;

    }
    double AmountPayable;
    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalFare"));
            commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));

            AmountPayable += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AmountPayable"));

            refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
            ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
            closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblcomm = (Label)e.Row.FindControl("lblCommisionFareTotal");
            lblcomm.Text = commission.ToString("####0.00");
            Label lblAmountPayable1 = (Label)e.Row.FindControl("lblAmountPayable1");
            lblAmountPayable1.Text = AmountPayable.ToString("####0.00");

            Label lblactulafare = (Label)e.Row.FindControl("lblActualFareTotal");
            lblactulafare.Text = actualfare.ToString("####0.00");        


            Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmountTotal");
            lblRefundAmount1.Text = refund.ToString("####0.00");
            Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationChargesTotal");
            lblCancellationCharges1.Text = ccharge.ToString("####0.00");
            Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
           lblClosingBalance1.Text = closebal.ToString("####0.00");
        }
    }
    
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    ChangeControlsToValue(GvFlightsReports);
        //    GvFlightsReports.Columns[13].Visible = false;
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
        //    Response.ContentType = "application/excel";
        //    StringWriter sWriter = new StringWriter();
        //    HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
        //    HtmlForm hForm = new HtmlForm();
        //    GvFlightsReports.Parent.Controls.Add(hForm);
        //    hForm.Attributes["runat"] = "server";
        //    hForm.Controls.Add(GvFlightsReports);
        //    hForm.RenderControl(hTextWriter);
        //    StringBuilder sBuilder = new StringBuilder();
        //    sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
        //    sBuilder.Append(sWriter + "</body></html>");
        //    Response.Write(sBuilder.ToString());
        //    Response.End();
        //    GvFlightsReports.Columns[13].Visible = true;
        //}
        //catch (Exception ex)
        //{
        //    //lblMsg.InnerHtml = ex.Message;
        //    throw ex;
        //}


        if (ddlserviceName.SelectedValue == "DomesticFlights")
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
            //ds=objbal.

        }
        else
            if (ddlserviceName.SelectedValue == "InterNationalFlights")
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
            else
                if (ddlserviceName.SelectedValue == "Hotels")
                {
                   

                    try
                    {
                        ChangeControlsToValue(GridView1);
                        GridView1.Columns[13].Visible = false;
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
                        Response.ContentType = "application/excel";
                        StringWriter sWriter = new StringWriter();
                        HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                        HtmlForm hForm = new HtmlForm();
                        GridView1.Parent.Controls.Add(hForm);
                        hForm.Attributes["runat"] = "server";
                        hForm.Controls.Add(GridView1);
                        hForm.RenderControl(hTextWriter);
                        StringBuilder sBuilder = new StringBuilder();
                        sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
                        sBuilder.Append(sWriter + "</body></html>");
                        Response.Write(sBuilder.ToString());
                        Response.End();
                        GridView1.Columns[13].Visible = true;
                    }
                    catch (Exception ex)
                    {
                        //lblMsg.InnerHtml = ex.Message;
                        throw ex;
                    }

                }

                else
                    if (ddlserviceName.SelectedValue == "Bus")
                    {
                       

                        try
                        {
                            ChangeControlsToValue(gvBookings);
                            gvBookings.Columns[13].Visible = false;
                            Response.ClearContent();
                            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
                            Response.ContentType = "application/excel";
                            StringWriter sWriter = new StringWriter();
                            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                            HtmlForm hForm = new HtmlForm();
                            gvBookings.Parent.Controls.Add(hForm);
                            hForm.Attributes["runat"] = "server";
                            hForm.Controls.Add(gvBookings);
                            hForm.RenderControl(hTextWriter);
                            StringBuilder sBuilder = new StringBuilder();
                            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
                            sBuilder.Append(sWriter + "</body></html>");
                            Response.Write(sBuilder.ToString());
                            Response.End();
                            gvBookings.Columns[13].Visible = true;
                        }
                        catch (Exception ex)
                        {
                            //lblMsg.InnerHtml = ex.Message;
                            throw ex;
                        }



                       
                    }
                    else
                        if (ddlserviceName.SelectedValue == "Recharge")
                        {
                            


                            try
                            {
                                ChangeControlsToValue(gvMobile);
                                //gvMobile.Columns[13].Visible = false;
                                Response.ClearContent();
                                Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
                                Response.ContentType = "application/excel";
                                StringWriter sWriter = new StringWriter();
                                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                                HtmlForm hForm = new HtmlForm();
                                gvMobile.Parent.Controls.Add(hForm);
                                hForm.Attributes["runat"] = "server";
                                hForm.Controls.Add(gvMobile);
                                hForm.RenderControl(hTextWriter);
                                StringBuilder sBuilder = new StringBuilder();
                                sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
                                sBuilder.Append(sWriter + "</body></html>");
                                Response.Write(sBuilder.ToString());
                                Response.End();
                                gvMobile.Columns[13].Visible = true;
                            }
                            catch (Exception ex)
                            {
                                //lblMsg.InnerHtml = ex.Message;
                                throw ex;
                            }








                        }
                        else if (ddlserviceName.SelectedValue == "ALL")
                        {
                           
                            try
                            {
                                ChangeControlsToValue(gdAllservicesreports);
                               // gdAllservicesreports.Columns[13].Visible = false;
                                Response.ClearContent();
                                Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
                                Response.ContentType = "application/excel";
                                StringWriter sWriter = new StringWriter();
                                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                                HtmlForm hForm = new HtmlForm();
                                gdAllservicesreports.Parent.Controls.Add(hForm);
                                hForm.Attributes["runat"] = "server";
                                hForm.Controls.Add(gdAllservicesreports);
                                hForm.RenderControl(hTextWriter);
                                StringBuilder sBuilder = new StringBuilder();
                                sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
                                sBuilder.Append(sWriter + "</body></html>");
                                Response.Write(sBuilder.ToString());
                                Response.End();
                                gdAllservicesreports.Columns[13].Visible = true;
                            }
                            catch (Exception ex)
                            {
                                //lblMsg.InnerHtml = ex.Message;
                                throw ex;
                            }


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
}