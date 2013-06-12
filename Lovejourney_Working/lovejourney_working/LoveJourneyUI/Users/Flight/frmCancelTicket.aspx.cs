using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FilghtsAPILayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;

public partial class Users_Flight_frmCancelTicket : System.Web.UI.Page
{
    string transId = string.Empty;
    FlightsAPILayer objFlights = new FlightsAPILayer();
    FlightBAL objFlightBal = new FlightBAL();
    DataSet objDataSet;
    ClsBAL objBAL;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
            CheckPermission("FlightsCancelTickets", Session["Role"].ToString());
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();


        dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


        String xmlRequestData = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><partnerRefId>100214</partnerRefId></EticketRequest>";
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
        if (dtRequestedPNR.Columns.Contains("requestedPNR_Id"))
        {
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
            int j;
            //for (j = 0; j <= dtEticket.Rows.Count; j++)
            //{
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

                #region SaveCancelResponse

                if (dsCancelResponse.Tables.Contains("onwardcanceldata"))
                {
                    objFlightBal.TransId = transId;
                    objFlightBal.Status = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["status"].ToString();
                    objFlightBal.remarks = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["remarks"].ToString();
                    objFlightBal.CancelId = dsCancelResponse.Tables["onwardcanceldata"].Rows[0]["Canid"].ToString();
                    objFlightBal.ReferenceNo = txtBookingReferenceNo.Text.Trim();
                    objFlightBal.Reason = txtReason.Text;

                    string givenName1 = string.Empty;
                    string surName1 = string.Empty;
                    string namereference = string.Empty;
                    string eticketNo1 = string.Empty;
                    string flightUid1 = string.Empty;
                    string passUid1 = string.Empty;

                    string customerInfo = string.Empty;


                    for (int i = 0; i < dsCancelResponse.Tables["Eticket"].Rows.Count; i++)
                    {

                        givenName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["givenName"].ToString();
                        surName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["surName"].ToString();
                        namereference = dsCancelResponse.Tables["Eticket"].Rows[i]["nameReference"].ToString();
                        eticketNo1 = dsCancelResponse.Tables["Eticket"].Rows[i]["eticketno"].ToString();
                        flightUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["flightuid"].ToString();
                        passUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["passuid"].ToString();
                        if (customerInfo == string.Empty)
                        {
                            customerInfo = namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                        }
                        else
                        {
                            customerInfo = customerInfo + ";" + namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                        }

                    }
                    objFlightBal.TicketDetails = customerInfo;
                    objFlightBal.CreatedBy = Convert.ToInt32(Session["Userid"].ToString());
                    objFlightBal.CancelDomesticFlightBooking(objFlightBal);
                #endregion
                }
                else
                {
                    lblStatus.Text = dsCancelResponse.Tables["CancelationDetails"].Rows[0]["error"].ToString();
                }

           // }
            

           
            }
            else
        {
            #region Commented
            ////Should be removed
                //String xmlCancelRequest = "<CancelationDetails><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>" + transId + "</transid><status>" + status + "</status><remarks>Hi transaction</remarks><eticketdto>";
                //xmlCancelRequest = xmlCancelRequest + "<Eticket><givenName>" + givenName + "</givenName><surName>" + surName + "</surName><nameReference>" + nameReference + "</nameReference><eticketno>" + eticketNo + "</eticketno><flightuid>" + flightUid + "</flightuid><passuid>" + passUid + "</passuid></Eticket>";
                //xmlCancelRequest = xmlCancelRequest + "</eticketdto></CancelationDetails>";
                //DataSet dsCancelResponse = objFlights.CancelTicket(xmlCancelRequest);
              

                //objFlightBal.TransId = transId;
                //objFlightBal.Status = dsCancelResponse.Tables[2].Rows[0]["status"].ToString();
                //objFlightBal.remarks = dsCancelResponse.Tables[2].Rows[0]["remarks"].ToString();

                //string givenName1 = string.Empty;
                //string surName1 = string.Empty;
                //string namereference = string.Empty;
                //string eticketNo1 = string.Empty;
                //string flightUid1 = string.Empty;
                //string passUid1 = string.Empty;

                //string customerInfo = string.Empty;

                //for (int i = 0; i < dsCancelResponse.Tables["Eticket"].Rows.Count; i++)
                //{

                //    givenName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["givenName"].ToString();
                //    surName1 = dsCancelResponse.Tables["Eticket"].Rows[i]["surName"].ToString();
                //    namereference = dsCancelResponse.Tables["Eticket"].Rows[i]["nameReference"].ToString();
                //    eticketNo1 = dsCancelResponse.Tables["Eticket"].Rows[i]["eticketno"].ToString();
                //    flightUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["flightuid"].ToString();
                //    passUid1 = dsCancelResponse.Tables["Eticket"].Rows[i]["passuid"].ToString();
                //    if (customerInfo == string.Empty)
                //    {
                //        customerInfo = namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                //    }
                //    else
                //    {
                //        customerInfo = customerInfo + ";" + namereference + "|" + givenName1 + "|" + surName1 + "|" + eticketNo1 + "|" + flightUid1 + "|" + passUid1;
                //    }

                //}
                //objFlightBal.TicketDetails = customerInfo;
                //objFlightBal.CancelDomesticFlightBooking(objFlightBal);
                #endregion

                lblStatus.Text = "Booking is Still Under Process";
            }
        
    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnCancel.Visible = true;
            btnCancelInt.Visible = false;
        }
        else
        {
            btnCancel.Visible = false;
            btnCancelInt.Visible = true;
        }
    }
    protected void btnCancelInt_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();
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

        dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();
        if (transId != "")
        {
            //String xmlRequest = "xmlRequest=<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
            String xmlRequest = "<EticketRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><transid>" + transId + "</transid></EticketRequest>";
            ds = objFlightBal.GetDatasetFromAPI(xmlRequest, "http://live.arzoo.com:9302/BookingStatus");




            //if (ds.Tables["EticketDetails"].Rows[0]["status"].ToString().ToUpper() == "SUCCESS")
            //{
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
                    DataRow[] rowFlightSegment = dtFlightSegment.Select("FlightSegments_Id=" + FlightSegmentsId);
                    FlightSegmentId = rowFlightSegment[0]["FlightSegment_Id"].ToString();
                }
                DataTable dtEticketDto = (DataTable)ds.Tables["Eticketdto"];
                if (dtEticketDto.Rows.Count > 0)
                {
                    DataRow[] rowEticketdto = dtEticketDto.Select("FlightSegment_Id=" + FlightSegmentId);
                    eticketdto_Id = rowEticketdto[0]["eticketdto_id"].ToString();
                }

                String xmlCancelReq = "<CanIntRequest><Clientid>" + FlightsConstants.USERID + "</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><Transid>" + ds.Tables["EticketDetails"].Rows[0]["transid"].ToString() + "</Transid><Remarks>Example1</Remarks><eticketdto>";

                DataTable dtEticket = (DataTable)ds.Tables["Eticket"];
                if (dtEticket.Rows.Count > 0)
                {
                    DataRow[] rowEticket = dtEticket.Select("eticketdto_id=" + eticketdto_Id);
                    for (int i = 0; i < rowEticket.Length; i++)
                    {

                        givenName = rowEticket[i]["givenName"].ToString();
                        surName = rowEticket[i]["surName"].ToString();
                        nameReference = rowEticket[i]["nameReference"].ToString();
                        eticketNo = rowEticket[i]["EticketNo"].ToString();
                        flightUid = rowEticket[i]["FlightUid"].ToString();
                        passUid = rowEticket[i]["passuid"].ToString();

                        xmlCancelReq = xmlCancelReq + "<Eticket><GivenName>" + givenName + "</GivenName><SurName>" + surName + "</SurName><NameReference>" + nameReference + "</NameReference><Eticketno>" + eticketNo + "</Eticketno><Flightuid>" + flightUid + "</Flightuid><Passuid>" + passUid + "</Passuid></Eticket>";
                    }
                }
                xmlCancelReq = xmlCancelReq + "</eticketdto></CanIntRequest>";

                DataSet dsCancelResponse = new DataSet();
                dsCancelResponse = objFlightBal.GetDatasetFromAPI(xmlCancelReq, "http://live.arzoo.com:9302/Cancellation");
                if (dsCancelResponse.Tables[0].Columns.Contains("error"))
                {
                    lblStatus.Text = dsCancelResponse.Tables[0].Rows[0]["error"].ToString();
                }
                else
                {
                    string status = dsCancelResponse.Tables[0].Rows[0]["status"].ToString();
                    lblStatus.Text = "Your ticket is " + status;
                    objFlightBal.Status = status;
                    objFlightBal.TransId = transId;
                    objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;
                    bool res = objFlightBal.UpdateInternationalFlightBookingStatus(objFlightBal);

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
}