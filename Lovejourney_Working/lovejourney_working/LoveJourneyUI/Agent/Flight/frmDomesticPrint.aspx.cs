using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
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

public partial class Agent_Flight_frmDomesticPrint : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();
    FlightBAL objFlightsBAL = new FlightBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMainMSg.Text = string.Empty;
    }
    protected void lbtnback_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        pnlViewticket.Visible = false;
    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlViewticket.Visible = false;
        
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnSignIn.Visible = true;
            btnSignInInt.Visible = false;
            pnlViewticket.Visible = false;
        }
        else
        {
            btnSignIn.Visible = false;
            btnSignInInt.Visible = true;
            pnlViewticket.Visible = false;
        }
    }
    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
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
            if (dsFlights != null)
            {

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    lblMainMSg.Text = "";
                    string customerDetails = dsFlights.Tables[0].Rows[0]["CustomerDetails"].ToString();
                    string[] strArryCustDet = customerDetails.Split('|');
                    lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                    lblTel.Text = dsFlights.Tables[0].Rows[0]["Telephone"].ToString();
                    lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();
                    lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportName"].ToString();
                    lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
                    lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
                    lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                    //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                    string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                    DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());

                    string date = dt.ToString("dd/MM/yyyy");
                    lblDepartureDate.Text = date.ToString();
                   // lblDepartureDate.Text = dt.ToLongDateString();
                    lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                    string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                    DateTime dt1 = Convert.ToDateTime(strArrivalDatetime[0].ToString());

                    string date1 = dt1.ToString("dd/MM/yyyy");
                   lblArrivalDate.Text = date1.ToString();
                   // lblArrivalDate.Text = dt1.ToLongDateString();

                    lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                    //  lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
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
                        if (strArryCustDet1[3].ToString() == "adt")
                        {
                            dr["Type"] = "Adult";
                            Session["strtype"] = "Adult";
                        }
                        else
                            if (strArryCustDet1[3].ToString() == "chd")
                            {
                                dr["Type"] = "Child";
                                Session["strtype"] = "," + "Child";
                            }
                            else
                                if (strArryCustDet1[3].ToString() == "inf")
                                {
                                    dr["Type"] = "Infant";
                                    Session["strtype"] = "," + "Infant";
                                }
                        if (strArryCustDet1[3].ToString() != "inf")
                        {
                            dr["Age"] = strArryCustDet1[4];
                        }
                        else
                        {
                            dr["Age"] = strArryCustDet1[4] + "M";
                        }
                        dtPsgrDet.Rows.Add(dr);
                    }

                    gdvPassengerDetails.DataSource = dtPsgrDet;
                    gdvPassengerDetails.DataBind();
                    lblPassengerType.Text = Session["strtype"].ToString();
                    lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                    lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                    lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                    lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"])).ToString(); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Scharge"])).ToString();
                    Double total = (Convert.ToDouble(lblBasicFare.Text) + Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text)); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString());
                    lblTotal.Text = total.ToString();
                    pnlViewticket.Visible = true;

                }
                else
                {
                    lblMainMSg.Text = "Please enter correct Reference No.";
                    lblMainMSg.ForeColor = System.Drawing.Color.Red;
                }
                printroundtrip.Visible = false;
                if (dsFlights.Tables[0].Rows.Count == 2)
                {
                    //return 

                    if (dsFlights.Tables[0].Rows.Count > 0)
                    {
                        lblMainMSg.Text = "";
                        printroundtrip.Visible = true;
                        lblAirlineNamereturn.Text = dsFlights.Tables[0].Rows[1]["OperatingAirlineName"].ToString();
                        //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                        lblFlightNumberreturn.Text = dsFlights.Tables[0].Rows[1]["FlightNumber"].ToString();

                        lblOriginRet.Text = dsFlights.Tables[0].Rows[1]["DepartureAirportCode"].ToString();
                        lblDestinationRet.Text = dsFlights.Tables[0].Rows[1]["ArrivalAirportCode"].ToString();

                        string DepartureDatetimeRet = dsFlights.Tables[0].Rows[1]["DepartureDateTime"].ToString();
                        string[] strArryDeptDatetimeRet = DepartureDatetimeRet.Split('T');
                        DateTime dt1 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                        lblDepartureDatereturn.Text = dt1.ToLongDateString();
                        lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                        string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                        string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                        DateTime dt = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                        lblArrivalDatereturn.Text = dt.ToLongDateString();
                        lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                        // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();

                        //string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                        //string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                        //string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["SchargeRet"])).ToString();
                        //string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts) - Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString())).ToString();
                        //lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                        //lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                        //lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                        //lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");

                    }

                }
                else
                {
                    lblMainMSg.Text = "Please enter correct Reference No.";
                    lblMainMSg.ForeColor = System.Drawing.Color.Red;
                }
            }
          
            // pnlViewticket.Visible = true;
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
            DataSet dsFlights = new DataSet();
            dsFlights = objFlightsBAL.GetDomesticFlightDetails(txtRefNo.Text.Trim());
          

                if (dsFlights.Tables[0].Rows.Count > 0)
                {
                    lblMainMSg.Text = "";
                    string customerDetails = dsFlights.Tables[0].Rows[0]["Customer_Details"].ToString();
                    string[] strArryCustDet = customerDetails.Split('|');
                    lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                    lblTel.Text = dsFlights.Tables[0].Rows[0]["telephone"].ToString();
                    lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["emailAddress"].ToString();
                    lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                    lblAirlinePNR.Text = dsFlights.Tables[0].Rows[0]["AirlinePNR"].ToString();
                    lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportCode"].ToString();
                    lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportCode"].ToString();
                    lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["airlineName"].ToString();
                    img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                    lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
                    lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                    string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                    string[] strArryDeptDatetime = DepartureDatetime.Split('T');
                 

                    DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                    string date = dt.ToString("dd/MM/yyyy");
                    lblDepartureDate.Text = date.ToString();
                   // lblDepartureDate.Text = dt.ToLongDateString();

                    lblDepartureTime.Text = strArryDeptDatetime[1].ToString();
                    string ArrivalDatetime = dsFlights.Tables[0].Rows[0]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetime = ArrivalDatetime.Split('T');
                    DateTime dt1 = Convert.ToDateTime(strArrivalDatetime[0].ToString());
                    string date1 = dt1.ToString("dd/MM/yyyy");
                    lblArrivalDate.Text = date1.ToString();
                   // lblArrivalDate.Text = dt1.ToLongDateString();

                    lblArrivalTime.Text = strArrivalDatetime[1].ToString();
                    // lblPNRNo.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
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
                      //  dr["Age"] = strArryCustDet1[4];
                        if (strArryCustDet1[3].ToString() != "inf" && strArryCustDet1[3].ToString() != "Infant")
                        {
                            dr["Age"] = strArryCustDet1[4];
                        }
                        else
                        {
                            dr["Age"] = strArryCustDet1[4] + "M";
                        }
                        dtPsgrDet.Rows.Add(dr);
                    }

                    gdvPassengerDetails.DataSource = dtPsgrDet;
                    gdvPassengerDetails.DataBind();
                    lblPassengerType.Text = strArryCustDet[3];
                    lblPassengerCnt.Text = strCusDetArr.Length.ToString();
                    lblBasicFare.Text = dsFlights.Tables[0].Rows[0]["ActualBasefare"].ToString();
                    lblTaxes.Text = dsFlights.Tables[0].Rows[0]["Tax"].ToString();
                    lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"])).ToString();
                    lblTotal.Text = (Convert.ToDouble(lblBasicFare.Text) + Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text)).ToString(); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                    pnlViewticket.Visible = true;
                }
                else
                {
                    lblMainMSg.Text = "Please enter correct Reference No.";
                    lblMainMSg.ForeColor = System.Drawing.Color.Red;
                }
                printroundtrip.Visible = false;
                //return en
            
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
                    DateTime dt = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());

                    string date1 = dt.ToString("dd/MM/yyyy");
                    lblDepartureDatereturn.Text = date1.ToString();

                    lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                    string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                    string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                    DateTime dt1 = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());

                    string date2 = dt1.ToString("dd/MM/yyyy");
                    lblArrivalDatereturn.Text = date2.ToString();

                    lblArrivalTimereturn.Text = strArrivalDatetimeRet[1].ToString();
                    // lblPNRNoreturn.Text = dsFlights.Tables[0].Rows[1]["ReferenceNo"].ToString();
                    string Afareret = dsFlights.Tables[0].Rows[0]["ActualBasefareRet"].ToString();
                    string Tret = dsFlights.Tables[0].Rows[0]["TaxRet"].ToString();
                    string Sts = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STaxRet"]) + Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TchargeRet"])).ToString();
                    string totret = (Convert.ToDouble(Afareret) + Convert.ToDouble(Tret) + Convert.ToDouble(Sts)).ToString(); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscountRet"].ToString())).ToString();
                    lblBasicFare.Text = (Convert.ToDecimal(lblBasicFare.Text) + Convert.ToDecimal(Afareret)).ToString();
                    lblTaxes.Text = (Convert.ToDecimal(lblTaxes.Text) + Convert.ToDecimal(Tret)).ToString();
                    lblServiceTax.Text = (Convert.ToDecimal(lblServiceTax.Text) + Convert.ToDecimal(Sts)).ToString();
                    lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) + Convert.ToDecimal(totret)).ToString("####0.00");
                }

            }
            else
            {
                //lblMainMSg.Text = "Please enter correct Reference No.";
                lblMainMSg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {

            throw;
        }

    }
}