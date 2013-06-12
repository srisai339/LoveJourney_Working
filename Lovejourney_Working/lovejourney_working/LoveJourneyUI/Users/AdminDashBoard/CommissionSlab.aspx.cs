using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilghtsAPILayer;
using System.Data;
using BAL;


public partial class Users_AdminDashBoard_CommisiionSlab : System.Web.UI.Page
{
    ClsBAL objBAL = new ClsBAL();
    FlightsAPILayer objFlights = new FlightsAPILayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
            CommissionLoad();
            btnsubmit.Text = "Submit";
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bool b = false;
            if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights" || ddlserviceName.SelectedValue == "Bus")
            {
                b = objBAL.Commissionslab(ddlrole.SelectedValue, ddlserviceName.SelectedValue, Convert.ToDecimal(txtcommission.Text), Convert.ToString(Session["UserID"]), ddloperators.SelectedItem.Text.ToString());
            }
            else
            {
                b = objBAL.Commissionslab(ddlrole.SelectedValue, ddlserviceName.SelectedValue, Convert.ToDecimal(txtcommission.Text), Convert.ToString(Session["UserID"]), string.Empty);
            }

            if (b == true)
            {
                lblmsg.Text = "Record inserted successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                txtcommission.Text = "";
                ddlrole.ClearSelection();
                ddlserviceName.ClearSelection();
                ddloperators.ClearSelection();
                trOperators.Visible = false;              
                CommissionLoad();
                btnsubmit.Text = "Submit";
            }
            else
            {
                lblmsg.Text = "Please try again";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void CommissionLoad()
    {
        try
        {
            //string strname = "Getdata";
            DataSet ds = objBAL.GetCommissionSlab("","","");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvFlightsReports.DataSource = ds;
                    GvFlightsReports.DataBind();
                }
                else
                {
                    GvFlightsReports.DataSource = ds;
                    GvFlightsReports.DataBind();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void GvFlightsReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvFlightsReports.PageIndex = e.NewPageIndex;
            CommissionLoad();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void GvFlightsReports_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            lblCCode.Text = GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["CommID"].ToString().Trim();
            txtcommission.Text = GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["Commission"].ToString();

            ddlrole.ClearSelection();
            ddlrole.Items.FindByText(GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["Role"].ToString().Trim()).Selected = true;
            ddlserviceName.ClearSelection();
            ddlserviceName.Items.FindByValue(GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["ServiceName"].ToString().Trim()).Selected = true;
            if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights" || ddlserviceName.SelectedValue == "Bus")
            {
                ddloperators.ClearSelection();
                ddlserviceName_SelectedIndexChanged(sender, e);
                ddloperators.Items.FindByText(GvFlightsReports.DataKeys[GvFlightsReports.SelectedIndex].Values["OperatorName"].ToString().Trim()).Selected = true;
            }
            btnsubmit.Text = "Update";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void ddlserviceName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet dsAirlineNames = new DataSet();
            if (ddlserviceName.SelectedValue == "DomesticFlights" || ddlserviceName.SelectedValue == "InterNationalFlights")
            {

                if (ddlserviceName.SelectedValue == "DomesticFlights")
                {
                    dsAirlineNames = objBAL.GetAirlineNames("DOM");
                }
                else if (ddlserviceName.SelectedValue == "InterNationalFlights")
                {
                    dsAirlineNames = objBAL.GetAirlineNames("INT"); 
                }
                if (dsAirlineNames != null)
                {
                    if (dsAirlineNames.Tables[0].Rows.Count > 0)
                    {
                        ddloperators.DataSource = dsAirlineNames.Tables[0];
                        ddloperators.DataTextField = "AirlineName";
                        ddloperators.DataValueField = "Airline_Id";
                        ddloperators.DataBind();
                        
                        trOperators.Visible = true;
                      
                    }
                }
            }
            else if (ddlserviceName.SelectedValue == "Bus")
            {
                dsAirlineNames = objBAL.GetBusOperators();
                if (dsAirlineNames != null)
                {
                    if (dsAirlineNames.Tables[0].Rows.Count > 0)
                    {
                        ListItem ltcBitla = new ListItem();
                        ltcBitla.Text = "Bitla";
                        ltcBitla.Value = "Bitla";
                        ddloperators.Items.Add(ltcBitla);

                        ListItem ltcSVR = new ListItem();
                        ltcSVR.Text = "SVR";
                        ltcSVR.Value = "SVR";
                        ddloperators.Items.Add(ltcSVR);

                        ListItem ltcTicketGoose = new ListItem();
                        ltcTicketGoose.Text = "TicketGoose";
                        ltcTicketGoose.Value = "TicketGoose";
                        ddloperators.Items.Add(ltcTicketGoose);

                        //ddloperators.DataSource = dsAirlineNames.Tables[0];
                        //ddloperators.DataTextField = "BusOperatorName";
                        //ddloperators.DataValueField = "BusOperatorId";
                        //ddloperators.DataBind();

                        trOperators.Visible = true;

                    }
                }
            }
            else
            {
                trOperators.Visible = false;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}