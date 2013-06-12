using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using FilghtsAPILayer;

public partial class AdminDashBoard_AdminBookingStatus : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();
    string transId = string.Empty;
    FlightBAL objFlightBal = new FlightBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
        }

    }
    protected void lbtnCancelstatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoard.aspx");
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


            String xmlRequestData = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100214</partnerRefId></EticketRequest>";
            DataSet dsFlightBookStatus = objFlights.GetBookingStatusDetails(xmlRequestData);

            if (dsFlightBookStatus.Tables.Contains("requestedPNR"))
            {
                objFlightBal.Status = dsFlightBookStatus.Tables["requestedPNR"].Rows[0]["status"].ToString();
                objFlightBal.TransId = transId;
                objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;

                bool res = objFlightBal.UpdateDomesticFlightBookingStatus(objFlightBal);
                if (res)
                {
                    lblStatus.Text = "Updated the status";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
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
        catch (Exception ex)
        {

        }
    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnGet.Visible = true;
            btnGetInt.Visible = false;
        }
        else
        {
            btnGet.Visible = false;
            btnGetInt.Visible = true;
        }
    }
    protected void btnGetInt_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();

            string result = string.Empty;
            string EticketDetailsId = string.Empty;
            string givenName = string.Empty;
            string surName = string.Empty;
            string nameReference = string.Empty;
            string psgrType = string.Empty;
            string originDestinationOptionId = string.Empty;
            string onwardId = string.Empty;
            string FlightSegmentsId = string.Empty;
            string FlightSegmentId = string.Empty;
            string eticketdto_Id = string.Empty;
            string eticketNo = string.Empty;
            string flightUid = string.Empty;
            string passUid = string.Empty;

            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


            String xmlRequest = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
            ds = objFlightBal.GetDatasetFromAPI(xmlRequest, "http://live.arzoo.com:9302/BookingStatus");

            if (ds.Tables["EticketDetails"].Columns.Contains("EticketDetails_Id"))
            {
                //EticketDetailsId = ds.Tables["EticketDetails"].Rows[0]["EticketDetails_Id"].ToString();

                //DataTable dtOriginDestinationOption = (DataTable)ds.Tables["OriginDestinationOption"];
                //if (dtOriginDestinationOption.Rows.Count > 0)
                //{
                //    DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("eticketDetails_Id=" + EticketDetailsId);
                //    originDestinationOptionId = rowOriginDestinationOption[0]["originDestinationOption_Id"].ToString();
                //}
                //DataTable dtOnward = (DataTable)ds.Tables["onward"];
                //if (dtOnward.Rows.Count > 0)
                //{
                //    DataRow[] rowOnward = dtOnward.Select("originDestinationOption_Id=" + originDestinationOptionId);
                //    onwardId = rowOnward[0]["Onward_Id"].ToString();
                //}
                //DataTable dtFlightSegments = (DataTable)ds.Tables["FlightSegments"];
                //if (dtFlightSegments.Rows.Count > 0)
                //{
                //    DataRow[] rowFlightSegments = dtFlightSegments.Select("Onward_Id=" + onwardId);
                //    FlightSegmentsId = rowFlightSegments[0]["FlightSegments_Id"].ToString();
                //}

                //DataTable dtFlightSegment = (DataTable)ds.Tables["FlightSegment"];
                //if (dtFlightSegment.Rows.Count > 0)
                //{
                //    DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsId);
                //    FlightSegmentId = rowFlightSegment[0]["FlightSegment_Id"].ToString();
                //}
                //DataTable dtEticketDto = (DataTable)ds.Tables["Eticketdto"];
                //if (dtEticketDto.Rows.Count > 0)
                //{
                //    DataRow[] rowEticketdto = dtEticketDto.Select("FlightSegment_Id=" + FlightSegmentId);
                //    eticketdto_Id = rowEticketdto[0]["eticketdto_id"].ToString();
                //}

                string status = ds.Tables[0].Rows[0]["status"].ToString();
                lblStatus.Text = "Your ticket is " + status;
                objFlightBal.Status = status;
                objFlightBal.TransId = transId;
                objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;
                bool res = objFlightBal.UpdateInternationalFlightBookingStatus(objFlightBal);

            }
            else
            {
                lblStatus.Text = "Your ticket is under booking process";
            }

        }
        catch (Exception ex)
        {

        }
    }
}