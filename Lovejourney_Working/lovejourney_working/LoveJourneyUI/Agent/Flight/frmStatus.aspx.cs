using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using FilghtsAPILayer;


public partial class Agent_Flight_frmStatus : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();
    string transId = string.Empty;
    FlightBAL objFlightBal = new FlightBAL();
    DataSet objDataSet;
    ClsBAL objBAL;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("FlightsStatus", Session["Role"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
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

    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            string AirlinePNR = string.Empty; // ConfirmationId
            string GDFPNRNumber = string.Empty; //PNRNumber
            string eticketNo = string.Empty;
            string flightUid = string.Empty;
            string passuid = string.Empty;

            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();

            if (transId != "")
            {
                String xmlRequestData = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>" + FlightsConstants.PARTNERID + "</partnerRefId></EticketRequest>";
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

                    objFlightBal.TransId = transId;
                    objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;

                    bool res = objFlightBal.UpdateDomesticFlightBookingStatus(objFlightBal);
                    if (res)
                    {
                        string status = GetStatusString(dsFlightBookStatus.Tables["requestedPNR"].Rows[0]["status"].ToString());
                        lblStatus.Text = "Your Ticket Status is : " + status;
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
                    else if (status == "PendingCan")
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

    private string GetStatusString(string sentStatus)
    {
        string status = string.Empty;
        try
        {
            switch (sentStatus)
            {
                case "SUCCESS": status = "Payment received, Ticket booking is under process";
                    break;
                case "SUCCESSCan": status = "Payment received, Due to some problems We cannot book the ticket.So cancelled. Payment will be reverted";
                    break;
                case "SuccessTkd": status = "Payment received, Ticket booked successfully";
                    break;
                case "SuccessTkdCan": status = "After successful confirmation of the ticket, if it is cancelled.";
                    break;

            }

        }
        catch (Exception ex)
        {

        }
        return status;
    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnGet.Visible = true;
            btnGetInt.Visible = false;
            txtBookingReferenceNo.Text = "";
            lblStatus.Text = "";
        }
        else
        {
            btnGet.Visible = false;
            btnGetInt.Visible = true;
            txtBookingReferenceNo.Text = "";
            lblStatus.Text = "";
        }
    }
    //protected void btnGetInt_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();

    //        string result = string.Empty;
    //        string EticketDetailsId = string.Empty;
    //        string givenName = string.Empty;
    //        string surName = string.Empty;
    //        string nameReference = string.Empty;
    //        string psgrType = string.Empty;
    //        string originDestinationOptionId = string.Empty;
    //        string onwardId = string.Empty;
    //        string FlightSegmentsId = string.Empty;
    //        string FlightSegmentId = string.Empty;
    //        string eticketdto_Id = string.Empty;
    //        string AirlinePNR = string.Empty; // ConfirmationId
    //        string GDFPNRNumber = string.Empty; //PNRNumber
    //        string eticketNo = string.Empty;
    //        string flightUid = string.Empty;
    //        string passuid = string.Empty;

    //        DataSet dsGetTransId = new DataSet();
    //        dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
    //        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


    //        String xmlRequest = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
    //        ds = objFlightBal.GetDatasetFromAPI(xmlRequest, "http://live.arzoo.com:9302/BookingStatus");

    //        if (ds.Tables["EticketDetails"].Columns.Contains("EticketDetails_Id"))
    //        {
    //            EticketDetailsId = ds.Tables["EticketDetails"].Rows[0]["EticketDetails_Id"].ToString();

    //            DataTable dtOriginDestinationOption = (DataTable)ds.Tables["OriginDestinationOption"];
    //            if (dtOriginDestinationOption.Rows.Count > 0)
    //            {
    //                DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("eticketDetails_Id=" + EticketDetailsId);
    //                originDestinationOptionId = rowOriginDestinationOption[0]["originDestinationOption_Id"].ToString();
    //            }
    //            DataTable dtOnward = (DataTable)ds.Tables["onward"];
    //            if (dtOnward.Rows.Count > 0)
    //            {
    //                DataRow[] rowOnward = dtOnward.Select("originDestinationOption_Id=" + originDestinationOptionId);
    //                onwardId = rowOnward[0]["Onward_Id"].ToString();
    //            }
    //            DataTable dtFlightSegments = (DataTable)ds.Tables["FlightSegments"];
    //            if (dtFlightSegments.Rows.Count > 0)
    //            {
    //                DataRow[] rowFlightSegments = dtFlightSegments.Select("Onward_Id=" + onwardId);
    //                FlightSegmentsId = rowFlightSegments[0]["FlightSegments_Id"].ToString();
    //            }

    //            DataTable dtFlightSegment = (DataTable)ds.Tables["FlightSegment"];
    //            if (dtFlightSegment.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < dtFlightSegment.Rows.Count; i++)
    //                {
    //                    DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsId);
    //                    FlightSegmentId = rowFlightSegment[i]["FlightSegment_Id"].ToString();
    //                    AirlinePNR = (AirlinePNR == "") ? rowFlightSegment[i]["confirmationid"].ToString() : AirlinePNR + "|" + rowFlightSegment[i]["confirmationid"].ToString();
    //                    GDFPNRNumber = (GDFPNRNumber == "") ? rowFlightSegment[i]["pnrnumber"].ToString() : GDFPNRNumber + "|" + rowFlightSegment[i]["pnrnumber"].ToString();


    //                    DataTable dtEticketDto = (DataTable)ds.Tables["Eticketdto"];
    //                    if (dtEticketDto.Rows.Count > 0)
    //                    {
    //                        DataRow[] rowEticketdto = dtEticketDto.Select("FlightSegment_Id=" + FlightSegmentId);
    //                        eticketdto_Id = rowEticketdto[0]["eticketdto_id"].ToString();
    //                        eticketNo = (eticketNo == "") ? rowEticketdto[i]["eticketno"].ToString() : eticketNo + "|" + rowEticketdto[i]["eticketno"].ToString();
    //                        flightUid = (flightUid == "") ? rowEticketdto[i]["flightuid"].ToString() : flightUid + "|" + rowEticketdto[i]["flightuid"].ToString();
    //                        passuid = (passuid == "") ? rowEticketdto[i]["passuid"].ToString() : passuid + "|" + rowEticketdto[i]["passuid"].ToString();

    //                    }
    //                }
    //            }

    //            string status1 = ds.Tables[0].Rows[0]["status"].ToString();

    //            objFlightBal.Status = status1;
    //            objFlightBal.TransId = transId;
    //            objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;
    //            objFlightBal.AirlinePNR = AirlinePNR;
    //            objFlightBal.GDFPNRNo = GDFPNRNumber;
    //            objFlightBal.passuid = passuid;
    //            objFlightBal.Flightuid = flightUid;
    //            objFlightBal.eticketNo = eticketNo;
    //            bool res = objFlightBal.UpdateInternationalFlightBookingStatus(objFlightBal);
    //            if (res)
    //            {
    //                string status = GetStatusString(ds.Tables[0].Rows[0]["status"].ToString());
    //                lblStatus.Text = "Your Ticket Status is : " + status;
    //                lblStatus.ForeColor = System.Drawing.Color.Green;
    //            }
    //        }

    //        else
    //        {
    //            lblStatus.Text = "Your ticket is under booking process";
    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
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
            string AirlinePNR = string.Empty; // ConfirmationId
            string GDFPNRNumber = string.Empty; //PNRNumber
            string eticketNo = string.Empty;
            string flightUid = string.Empty;
            string passuid = string.Empty;

            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();

            if (transId != "")
            {
                String xmlRequest = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
                ds = objFlightBal.GetDatasetFromAPI(xmlRequest, "http://live.arzoo.com:9302/BookingStatus");

                if (ds.Tables["EticketDetails"].Columns.Contains("EticketDetails_Id"))
                {
                    EticketDetailsId = ds.Tables["EticketDetails"].Rows[0]["EticketDetails_Id"].ToString();

                    DataTable dtOriginDestinationOption = (DataTable)ds.Tables["OriginDestinationOption"];
                    if (dtOriginDestinationOption.Rows.Count > 0)
                    {
                        DataRow[] rowOriginDestinationOption = dtOriginDestinationOption.Select("eticketDetails_Id=" + EticketDetailsId);
                        originDestinationOptionId = rowOriginDestinationOption[0]["originDestinationOption_Id"].ToString();
                    }
                    DataTable dtOnward = (DataTable)ds.Tables["onward"];
                    if (dtOnward.Rows.Count > 0)
                    {
                        DataRow[] rowOnward = dtOnward.Select("originDestinationOption_Id=" + originDestinationOptionId);
                        onwardId = rowOnward[0]["Onward_Id"].ToString();
                    }
                    DataTable dtFlightSegments = (DataTable)ds.Tables["FlightSegments"];
                    if (dtFlightSegments.Rows.Count > 0)
                    {
                        DataRow[] rowFlightSegments = dtFlightSegments.Select("Onward_Id=" + onwardId);
                        FlightSegmentsId = rowFlightSegments[0]["FlightSegments_Id"].ToString();
                    }

                    DataTable dtFlightSegment = (DataTable)ds.Tables["FlightSegment"];
                    if (dtFlightSegment.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtFlightSegment.Rows.Count; i++)
                        {
                            DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsId);
                            FlightSegmentId = rowFlightSegment[i]["FlightSegment_Id"].ToString();
                            AirlinePNR = (AirlinePNR == "") ? rowFlightSegment[i]["confirmationid"].ToString() : AirlinePNR + "|" + rowFlightSegment[i]["confirmationid"].ToString();
                            GDFPNRNumber = (GDFPNRNumber == "") ? rowFlightSegment[i]["pnrnumber"].ToString() : GDFPNRNumber + "|" + rowFlightSegment[i]["pnrnumber"].ToString();


                            DataTable dtEticketDto = (DataTable)ds.Tables["Eticketdto"];
                            if (dtEticketDto.Rows.Count > 0)
                            {
                                DataRow[] rowEticketdto = dtEticketDto.Select("FlightSegment_Id=" + FlightSegmentId);
                                eticketdto_Id = rowEticketdto[0]["eticketdto_id"].ToString();
                                eticketNo = (eticketNo == "") ? rowEticketdto[i]["eticketno"].ToString() : eticketNo + "|" + rowEticketdto[i]["eticketno"].ToString();
                                flightUid = (flightUid == "") ? rowEticketdto[i]["flightuid"].ToString() : flightUid + "|" + rowEticketdto[i]["flightuid"].ToString();
                                passuid = (passuid == "") ? rowEticketdto[i]["passuid"].ToString() : passuid + "|" + rowEticketdto[i]["passuid"].ToString();

                            }
                        }
                    }

                    string status1 = ds.Tables[0].Rows[0]["status"].ToString();

                    objFlightBal.Status = status1;
                    objFlightBal.TransId = transId;
                    objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;
                    objFlightBal.AirlinePNR = AirlinePNR;
                    objFlightBal.GDFPNRNo = GDFPNRNumber;
                    objFlightBal.passuid = passuid;
                    objFlightBal.Flightuid = flightUid;
                    objFlightBal.eticketNo = eticketNo;
                    bool res = objFlightBal.UpdateInternationalFlightBookingStatus(objFlightBal);
                    if (res)
                    {
                        string status = GetStatusString(ds.Tables[0].Rows[0]["status"].ToString());
                        lblStatus.Text = "Your Ticket Status is : " + status;
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    lblStatus.Text = "Your ticket is under booking process";
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
    protected void btnget1_Click(object sender, EventArgs e)
    {

    }
}