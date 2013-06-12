using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;



public partial class IFRports : System.Web.UI.Page
{
    FlightBAL objFlightBal = new FlightBAL();
    DataSet dsFlight;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void rdlflights_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {

                objFlightBal.Status = "Domestic";


            }
            else if (rdlflights.SelectedItem.Text == "InterNational Flights")
            {
                objFlightBal.Status = "IF";
            }
            dsFlight = objFlightBal.GetFlights(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
                    GvFlightsReports.DataSource = dsFlight;
                    GvFlightsReports.DataBind();
                }
                else
                {
                    GvFlightsReports.DataSource = dsFlight;
                    GvFlightsReports.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}