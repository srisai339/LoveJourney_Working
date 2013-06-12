using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;
using FilghtsAPILayer;
using System.Data;
using System.Text;
using BusAPILayer;

public partial class AdminDashBoard_AdminDashBoardPrint : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();
    FlightBAL objFlightsBAL = new FlightBAL();
    ClsBAL objBAL;
    DataSet ObjDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;

            btnSignIn.Visible = true;
            btnSignInInt.Visible = false;
        }

    }
    #region Domestic Flights

    protected void lbtnback_Click(object sender, EventArgs e)
    {

    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnSignIn.Visible = true;
            btnSignInInt.Visible = false;
        }
        else
        {
            btnSignIn.Visible = false;
            btnSignInInt.Visible = true;
        }
    }
    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedValue == "Buses")
            {
            }
            else if (ddlType.SelectedValue == "DomesticFlights")
            {

                if (lblEmailAddress.Text != null)
                {
                    string body = getHTML(pnlViewticket);
                    bool res = Mailsender.SendEmail(lblEmailAddress.Text, "", "", "Ticket Details", body);
                    if (res)
                    {

                        lblMainMSg.Text = "Mail has been sent successfully";
                        lblMainMSg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {

                        lblMainMSg.Text = "Failed to send Mail ";
                        lblMainMSg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else if (ddlType.SelectedValue == "Hotels")
            {
                try
                {
                    {
                        string body = getHTML(pnlTicket);
                        bool res = Mailsender.SendEmail(lblEmailId.Text, "", "", "Ticket Details", body);
                        if (res)
                        {
                            lblMsg.Text = "Mail has been sent successfully.";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMsg.Text = "Failed to send Mail.";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private string getHTML(Panel Pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        Pnl.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
        /* -----------------------------------
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */

    }
    protected void btnSignInInt_Click(object sender, EventArgs e)
    {
        try
        {
            FlightBAL objFlightsBAL = new FlightBAL();
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetInternationalFlightDetails(txtRefNo.Text.Trim());
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
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                lblDepartureDate.Text = strArryDeptDatetime[0].ToString();
                lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                lblArrivalDate.Text = strArryDeptDatetime[0].ToString();
                lblArrivalTime.Text = strArryDeptDatetime[1].ToString();
                lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
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
                lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                lblTotal.Text = Convert.ToDouble(lblBasicFare.Text) + (Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text) - Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                pnlViewticket.Visible = true;


            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedValue == "Buses")
            {
                try
                {
                    objBAL = new ClsBAL();
                    objBAL.manabusRefNo = txtMBRefNo.Text;
                    ObjDataset = (DataSet)objBAL.GetTicketIdByOnewayManabusRefNo();
                    if (ObjDataset != null)
                    {
                        if (ObjDataset.Tables.Count > 0)
                        {
                            if (ObjDataset.Tables[0].Rows.Count > 0)
                            {
                                string travelName = ObjDataset.Tables[0].Rows[0]["TravelOPName"].ToString();
                                string api = ObjDataset.Tables[0].Rows[0]["APIName"].ToString();
                                gvView.DataSource = ObjDataset.Tables[0];
                                GetCancellationPolicy(travelName);
                                if (api == "Kesineni")
                                {
                                    imgKesineni.Visible = true;
                                }
                                else { imgKesineni.Visible = false; }
                                gvView.DataBind();
                                Panel1.Visible = false;
                                pnlViewticket.Visible = true;
                            }
                            else
                            {
                                lblMsg.Text = "Invalid Ref No";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                Panel1.Visible = true;
                                pnlViewticket.Visible = false;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Invalid Ref No";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            Panel1.Visible = true;
                            pnlViewticket.Visible = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Ref No";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        Panel1.Visible = true;
                        pnlViewticket.Visible = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (ObjDataset != null)
                    {
                        ObjDataset = null;
                    }
                }
            }
            else if (ddlType.SelectedValue == "DomesticFlights")
            {
                DataSet dsFlights = new DataSet();
                dsFlights = objFlightsBAL.GetDomesticFlightDetails(txtRefNo.Text.Trim());
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
                    img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                    string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                    lblDepartureDate.Text = strArryDeptDatetime[0].ToString();
                    lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                    string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                    lblArrivalDate.Text = strArryDeptDatetime[0].ToString();
                    lblArrivalTime.Text = strArryDeptDatetime[1].ToString();
                    lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
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
                    lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                    lblTotal.Text = (Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text) - Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                    pnlViewticket.Visible = true;


                }
            }

        }
        catch (Exception ex)
        {

            throw;
        }

    }
    #endregion
    //protected void btnprint_Click(object sender, EventArgs e)
    //{
    //    if (ddlType.SelectedValue != "--PleaseSelect--")
    //    {
    //        if (ddlType.SelectedValue == "DomesticFlights")
    //        {
    //            pnldomesticflights.Visible = true;
    //            pnlbuses.Visible = false;
    //            pnlhotels.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Hotels")
    //        {
    //            pnlbuses.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlhotels.Visible = true;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Buses")
    //        {
    //            pnlhotels.Visible = false;
    //            pnlbuses.Visible = true;
    //            pnldomesticflights.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "Recharge")
    //        {
    //            pnlhotels.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlbuses.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //        else if (ddlType.SelectedValue == "IFFlights")
    //        {
    //            pnlhotels.Visible = false;
    //            pnldomesticflights.Visible = false;
    //            pnlbuses.Visible = false;
    //            lblMsg.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        lblMainMSg.Text = "Please select Flight Type";
    //    }
    //}
    #region buses
    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            objBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                objBAL.api = travelname.Substring(0, 5);
            }
            else { objBAL.api = travelname; }
            ObjDataset = (DataSet)objBAL.GetCancelPercentageByAPI();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    gvCancellationDetails.DataSource = ObjDataset.Tables[0];
                    gvCancellationDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (ObjDataset != null)
            {
                ObjDataset = null;
            }
        }
    }
    protected void gvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region Seats
                string finalseats = string.Empty;
                Label lblSeats = (Label)e.Row.FindControl("lblPassengerDetails");
                if (lblSeats != null && lblSeats.Text != "")
                {
                    string[] seats = lblSeats.Text.Split(',');
                    if (seats.Length > 0)
                    {
                        finalseats += "<table width='300px' border='1px Solid Black'  cellpadding='0' cellspacing='0'>";
                        finalseats += "<th width='100px' align='Center'>Seat</th><th align='Center' width='100px'>Name</th><th align='Center' width='100px'>Age</th>";
                        foreach (string item in seats)
                        {
                            string[] details = item.Split('-');
                            if (details.Length > 0)
                            {
                                finalseats += "<tr><td width='100px' align='Center'>";
                                finalseats += details[0] + "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[1] + " " + details[2] + "</p>";
                                finalseats += "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[3] + "</p>";
                                finalseats += "</td></tr>";
                            }
                        }
                        finalseats += "</table>";
                        lblSeats.Text = finalseats;
                    }
                }
                #endregion

                #region Cancellation Details
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus.Text == "Cancelled")
                {
                    Panel pnlCancellationDetails = (Panel)e.Row.FindControl("pnlCancellationDetails");
                    pnlCancellationDetails.Visible = true;
                    Label lblCancelledBY = (Label)pnlCancellationDetails.FindControl("lblCancelledBY");
                    if (lblCancelledBY.Text == "")
                    {
                        lblCancelledBY.Text = "Online";
                    }
                }
                #endregion
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region hotels
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            HotelBAL objTicket = new HotelBAL();
            objTicket.ReferenceNo = txtRefNo1.Text.ToString();
            DataSet dsTicket = objTicket.GetHotelProvisional();
            if (dsTicket == null) { lblMsg.Text = "Invalid Ref No."; return; }
            if (dsTicket.Tables.Count == 0) { lblMsg.Text = "Invalid Ref No."; return; }
            if (dsTicket.Tables[0].Rows.Count == 0) { lblMsg.Text = "Invalid Ref No."; return; }
            DataRow drTicketRow = dsTicket.Tables[0].Rows[0];
            lblHotelRefNo.Text = drTicketRow["ReferenceNo"].ToString();
            lblStatus.Text = drTicketRow["Status"].ToString();
            lblHotelName.Text = drTicketRow["HotelName"].ToString();

            lblAddress.Text = drTicketRow["HotelAddress"].ToString();

            lblHotelCity.Text = drTicketRow["HotelCity"].ToString();
            lblCheckIn.Text = drTicketRow["CheckInDate"].ToString();
            lblCheckOut.Text = drTicketRow["CheckOutDate"].ToString();
            lblRoomType.Text = drTicketRow["RoomType"].ToString();

            lblStar.Text = drTicketRow["HotelStar"].ToString();

            lblNoOfRooms.Text = drTicketRow["NoOfRooms"].ToString();
            lblPaxGreaterThan12.Text = drTicketRow["NoOfAdults"].ToString();
            lblPaxLessThan12.Text = drTicketRow["NoOfChildren"].ToString();

            lblTotalPrice.Text = drTicketRow["HotelTotalFare"].ToString();

            lblTitle.Text = drTicketRow["Title"].ToString();
            lblFirstName.Text = drTicketRow["FirstName"].ToString();
            lblMiddleName.Text = drTicketRow["MiddleName"].ToString();
            lblLastName.Text = drTicketRow["LastName"].ToString();
            lblMobileNo.Text = drTicketRow["MobileNumber"].ToString();
            lblEmailId.Text = drTicketRow["EmailId"].ToString();
            lblAdd.Text = drTicketRow["CustAddressLine"].ToString();
            lblState.Text = drTicketRow["CustState"].ToString();
            lblPinCode.Text = drTicketRow["CustZipCode"].ToString();

            lblCity.Text = drTicketRow["CustCity"].ToString();
            pnlViewTicket1.Visible = true; pnl.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    void Mail(string mailId)
    {
        try
        {
            objBAL = new ClsBAL();
            System.Data.DataSet ds = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
            {
                string body = getHTML(pnlTicket);
                bool res = Mailsender.SendEmail(mailId, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMsg.Text = "Ticket Details has been sent to your mail. Please check.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnMail_Click(object sender, EventArgs e)
    {
        try
        {
            {
                string body = getHTML(pnlTicket);
                bool res = Mailsender.SendEmail(lblEmailId.Text, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMsg.Text = "Mail has been sent successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.Text = "Failed to send Mail.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoard.aspx");
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue != "--PleaseSelect--")
        {
            if (ddlType.SelectedValue == "DomesticFlights")
            {
                pnldomesticflights.Visible = true;
                pnlbuses.Visible = false;
                pnlhotels.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Hotels")
            {
                pnlbuses.Visible = false;
                pnldomesticflights.Visible = false;
                pnlhotels.Visible = true;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Buses")
            {
                pnlhotels.Visible = false;
                pnlbuses.Visible = true;
                pnldomesticflights.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "Recharge")
            {
                pnlhotels.Visible = false;
                pnldomesticflights.Visible = false;
                pnlbuses.Visible = false;
                lblMsg.Text = "";
            }
            else if (ddlType.SelectedValue == "IFFlights")
            {
                pnlhotels.Visible = false;
                pnldomesticflights.Visible = false;
                pnlbuses.Visible = false;
                lblMsg.Text = "";
            }
        }
        else
        {
            lblMainMSg.Text = "Please select Flight Type";
        }

    }
}