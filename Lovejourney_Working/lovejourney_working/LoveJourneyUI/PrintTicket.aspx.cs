using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusAPILayer;
using BAL;
using System.Text;
using System.IO;

public partial class PrintTicket : System.Web.UI.Page
{
    ClsBAL objManabusBAL;
    DataSet ObjDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - PrintTicket";
        }
    }

    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            objManabusBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                objManabusBAL.api = travelname.Substring(0, 5);
            }
            else { objManabusBAL.api = travelname; }
            ObjDataset = (DataSet)objManabusBAL.GetCancelPercentageByAPI();
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

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        pnlFlightTicket.Visible = false;
        pnlViewticket.Visible = false;
        pnlhotelTicket.Visible = false;
        Panel1.Visible = false;
        Panel10.Visible = false;


        if (ddlType.SelectedItem.Text == "Bus")
        {
            pnlFlightTicket.Visible = false;
            pnlViewticket.Visible = false;
            pnlhotelTicket.Visible = false;
            Panel1.Visible = true;

            try
            {
                #region Bitla
                ////objBitlaAPILayer.TicketNumber = txtMBRefNo.Text.ToString();
                ////DataSet dsBitla = objBitlaAPILayer.GetTicketDetails();
                ////GridView1.DataSource = dsBitla;
                ////GridView1.DataBind();
                //#endregion

                //#region Kesneni
                //DataSet dsKesineni = objKesineniAPILayer.CancelTickets("843254",
                //    "RajuKatare", "RajuKatare", "05/25/2012", "2,1");
                //GridView1.DataSource = dsKesineni;
                //GridView1.DataBind();
                //#endregion

                //#region AbhiBus
                //DataTable dsAbhiBus = objAbhiBusAPILayer.GetTicketInfo("RajuKatare");
                //GridView1.DataSource = dsAbhiBus;
                //GridView1.DataBind();
                #endregion
                objManabusBAL = new ClsBAL();
                objManabusBAL.manabusRefNo = txtMBRefNo.Text;
                ObjDataset = (DataSet)objManabusBAL.GetTicketIdByOnewayManabusRefNo();
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
                            gvView.DataBind();
                            Panel1.Visible = false;
                            pnlViewticket.Visible = true;
                        }
                        else
                        {
                            lblMsg.Text = "Invalid Ref NO";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            Panel1.Visible = true;
                            pnlViewticket.Visible = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Ref NO";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        Panel1.Visible = true;
                        pnlViewticket.Visible = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Invalid Ref NO";
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
        else if (ddlType.SelectedItem.Text == "Flight")
        {



            pnlFlightTicket.Visible = true;
            pnlViewticket.Visible = false;
            pnlhotelTicket.Visible = false;
            Panel1.Visible = false;
            Panel10.Visible = false;



            try
            {
                DataSet dsFlights = new DataSet();
                FlightBAL objFlightsBAL = new FlightBAL();
                dsFlights = objFlightsBAL.GetDomesticFlightDetails(txtMBRefNo.Text.Trim());
                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    string customerDetails = dsFlights.Tables[0].Rows[0]["Customer_Details"].ToString();
                    string[] strArryCustDet = customerDetails.Split('|');
                    lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                    lblTel.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();
                    lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                    Session["EmailId"] = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                    lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                    lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                    lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["airlineName"].ToString();
                    img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                    lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                    string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetime = DepartureDatetime.Split('T');


                    DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                    string date = dt.ToString("dd/MM/yyyy");
                    lblDepartureDate.Text = date.ToString();
                    // lblDepartureDate.Text = strArryDeptDatetime[0].ToString();

                    lblDepartureTime.Text = strArryDeptDatetime[1].ToString();



                    string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetime = ArrivalDatetime.Split('T');

                    DateTime dt1 = Convert.ToDateTime(strArrivalDatetime[0].ToString());
                    string date1 = dt1.ToString("dd/MM/yyyy");
                    lblArrivalDate.Text = date1.ToString();
                    // lblArrivalDate.Text = strArryDeptDatetime[0].ToString();

                    lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                    lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();
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
                    string Tcharge = dsFlights.Tables[0].Rows[0]["Tcharge"].ToString();

                    lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(Tcharge) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TMarkUp"])).ToString();
                    lblTotal.Text = (Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text) + Convert.ToDouble(lblBasicFare.Text)).ToString();

                    //  + Convert.ToDouble(Tcharge)).ToString();
                    //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                    // pnlViewticket.Visible = true;
                    printroundtrip.Visible = false;

                    lblMsg.Text = "";
                    if (dsFlights.Tables[0].Rows.Count == 2)
                    {
                        //return 

                        if (dsFlights.Tables[0].Rows.Count > 0)
                        {
                            lblMainMSg.Text = "";
                            printroundtrip.Visible = true;
                            lblAirlineNamereturn.Text = dsFlights.Tables[0].Rows[1]["airlineName"].ToString();
                            //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                            lblFlightNumberreturn.Text = dsFlights.Tables[0].Rows[1]["FlightNumber"].ToString();
                            lblOriginRet.Text = dsFlights.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
                            lblDestinationRet.Text = dsFlights.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();

                            string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                            string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                            DateTime dt3 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                            string date3 = dt3.ToString("dd/MM/yyyy");
                            lblDepartureDatereturn.Text = date3.ToString();
                            //  lblDepartureDatereturn.Text = dt3.ToLongDateString();
                            lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                            string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                            string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                            DateTime dt4 = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                            string date4 = dt4.ToString("dd/MM/yyyy");
                            lblArrivalDatereturn.Text = date4.ToString();
                            lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                            // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();
                            string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                            string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                            string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TchargeRet"])).ToString();
                            string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts)).ToString(); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"].ToString())).ToString();
                            //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString())).ToString();
                            lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                            lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                            lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                            lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");
                        }

                    }
                }
                else
                {
                    lblMsg.Text = "Invalid Reference No";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    pnlViewticket.Visible = false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }
        else if (ddlType.SelectedItem.Text == "Hotel")
        {
            pnlFlightTicket.Visible = false;
            pnlViewticket.Visible = false;
            pnlhotelTicket.Visible = true;
            Panel1.Visible = false;
            Panel10.Visible = false;

            try
            {
                HotelBAL objTicket = new HotelBAL();
                objTicket.ReferenceNo = txtMBRefNo.Text.ToString().Trim().ToString();
                DataSet dsTicket = objTicket.GetHotelProvisional();
                if (dsTicket == null) { lblMsg.Text = "Invalid Ref No."; return; }
                if (dsTicket.Tables.Count == 0) { lblMsg.Text = "Invalid Ref No."; return; }
                if (dsTicket.Tables[0].Rows.Count == 0) { lblMsg.Text = "Invalid Ref No."; return; }
                DataRow drTicketRow = dsTicket.Tables[0].Rows[0];
                lblHotelRefNo.Text = drTicketRow["ReferenceNo"].ToString();
                lblStatus.Text = drTicketRow["Status"].ToString();
                lblHotelName.Text = drTicketRow["HotelName"].ToString();
                lblarzoorefno.Text = drTicketRow["BookingRefNo"].ToString();

                lblAddress.Text = drTicketRow["HotelAddress"].ToString();

                lblHotelCity.Text = drTicketRow["HotelCity"].ToString();
                lblCheckIn.Text = drTicketRow["CheckInDate"].ToString();
                lblCheckOut.Text = drTicketRow["CheckOutDate"].ToString();
                lblRoomType.Text = drTicketRow["RoomType"].ToString();

                lblStar.Text = drTicketRow["HotelStar"].ToString() + " Star";

                lblNoOfRooms.Text = drTicketRow["NoOfRooms"].ToString();
                lblPaxGreaterThan12.Text = drTicketRow["NoOfAdults"].ToString();
                lblPaxLessThan12.Text = drTicketRow["NoOfChildren"].ToString();

                lblBookedDate.Text = drTicketRow["BookedDate"].ToString();
                lblHotelContactDetails.Text = drTicketRow["ContactNumbers"].ToString() + " , Fax Nos: " + drTicketRow["FaxNumbers"].ToString();

                lblTotalPrice.Text = drTicketRow["HotelTotalFare"].ToString() + "~" + drTicketRow["HotelTotlaFareDetails"].ToString();/////////////

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

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;

                throw;
            }
        }

        else if (ddlType.SelectedItem.Text == "Cabs")
        {
            pnlFlightTicket.Visible = false;
            pnlViewticket.Visible = false;
            pnlhotelTicket.Visible = false;
            Panel1.Visible = false;
            Panel10.Visible = false;
            pnlCabTicket.Visible = true;
            Panel2.Visible = true;


            try
            {
                FlightBAL objFlightsBAL = new FlightBAL();
                DataSet dsFlights = new DataSet();
                dsFlights = objFlightsBAL.GetCarDetaisl(txtMBRefNo.Text, "");
                if (dsFlights.Tables[0].Rows.Count > 0)
                {

                    //lblCarName.Text = dsFlights.Tables[0].Rows[1]["CarName"].ToString();
                    lblCarRefNo.Text = dsFlights.Tables[0].Rows[0]["ReferanceId"].ToString();
                    lblCabstatus.Text = dsFlights.Tables[0].Rows[0]["Status"].ToString();
                    //if (dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString() == "1")
                    //{
                    //    lblStatus.Text ="Booked";
                    //}

                    lblCabAddress.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
                    lblCity1.Text = dsFlights.Tables[0].Rows[0]["City_Car"].ToString();
                    lblJourneyDate.Text = dsFlights.Tables[0].Rows[0]["TravelDate"].ToString();
                    lblCabName.Text = dsFlights.Tables[0].Rows[0]["CarName"].ToString();
                    lblCabMobile.Text = dsFlights.Tables[0].Rows[0]["MobileNo"].ToString();
                    lblCabEmail.Text = dsFlights.Tables[0].Rows[0]["EmailId"].ToString();
                    lblCabAddress1.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
                    lblCabCity.Text = dsFlights.Tables[0].Rows[0]["City"].ToString();
                    lblCabPincode.Text = dsFlights.Tables[0].Rows[0]["ZipCode"].ToString();
                    lblCabState.Text = dsFlights.Tables[0].Rows[0]["State"].ToString();
                    lblPickupTime.Text = dsFlights.Tables[0].Rows[0]["PickupTime"].ToString();
                    lblCarName.Text = dsFlights.Tables[0].Rows[0]["CarName"].ToString();

                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;

                throw;
            }
        }
    }
        
    

    protected void lbtnback_Click(object sender, EventArgs e)
    {
        try
        {
            txtMBRefNo.Text = "";
            Panel1.Visible = true;
            pnlViewticket.Visible = false;
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

    protected void lbtnmail_Click1(object sender, EventArgs e)
    {

        try
        {
           // GridView gvView = (GridView)Panel3.FindControl("gvView");
            //Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (Session["EmailId"]!=null)
            {
                string body = getHTML(Panel3);
                bool res = Mailsender.SendEmail(Session["EmailId"].ToString(),"", "", "Ticket Details", body);
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
        catch (Exception ex)
        {

            throw ex;
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



    
protected void  lnkCabMail_Click(object sender, EventArgs e)
{
    string body = getHTML(pnlCabTicket);
    bool res = MailSender.SendEmail(lblCabEmail.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", body);
    // downlink.Visible = true;
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