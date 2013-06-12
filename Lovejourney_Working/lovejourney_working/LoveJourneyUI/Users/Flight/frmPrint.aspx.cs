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
public partial class Users_Flight_frmPrint : System.Web.UI.Page
{
    DataSet objDataSet;
    ClsBAL objBAL;

    FlightsAPILayer objFlights = new FlightsAPILayer();
    FlightBAL objFlightsBAL = new FlightBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["Role"] != null)
            //{
            //CheckPermission("FlightsPrint", Session["Role"].ToString());
            //}
            //    else
            //    {
            //        Response.Redirect("~/Default.aspx", false);
            //    }
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
                lblmsg1.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblmsg1.ForeColor = System.Drawing.Color.Maroon;
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
            if (dsFlights.Tables[0].Rows.Count > 0)
            {
                string customerDetails = dsFlights.Tables[0].Rows[0]["CustomerDetails"].ToString();
                string[] strArryCustDet = customerDetails.Split('|');
                lblName.Text = strArryCustDet[0] + strArryCustDet[1] + "  " + strArryCustDet[2];
                lblTel.Text = dsFlights.Tables[0].Rows[0]["Telephone"].ToString();
                lblEmailAddress.Text = dsFlights.Tables[0].Rows[0]["EmailAddress"].ToString();
                lblPNR.Text = dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString();
                lblOrigin.Text = dsFlights.Tables[0].Rows[0]["DepartureAirportName"].ToString();
                lblDestination.Text = dsFlights.Tables[0].Rows[0]["ArrivalAirportName"].ToString();
                lblAirlineName.Text = dsFlights.Tables[0].Rows[0]["OperatingAirlineName"].ToString();
                
                //img.ImageUrl = dsFlights.Tables[0].Rows[0]["imageFileName"].ToString();
                lblFlightNumber.Text = dsFlights.Tables[0].Rows[0]["FlightNumber"].ToString();
               lblBookingTime.Text = dsFlights.Tables[0].Rows[0]["CreatedDate"].ToString();
                string DepartureDatetime = dsFlights.Tables[0].Rows[0]["DepartureDateTime"].ToString();
                string[] strArryDeptDatetime = DepartureDatetime.Split('T');

                DateTime dt = Convert.ToDateTime(strArryDeptDatetime[0].ToString());
                string date = dt.ToString("dd/MM/yyyy");
                lblDepartureDate.Text = date.ToString();

              //  lblDepartureDate.Text = strArryDeptDatetime[0].ToString();
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
                
                lblServiceTax.Text = (Convert.ToDouble(dsFlights.Tables[0].Rows[0]["STax"])).ToString(); //+ Convert.ToDouble(dsFlights.Tables[0].Rows[0]["Tcharge"])).ToString();
                lblTotal.Text = (Convert.ToDouble(lblBasicFare.Text) + (Convert.ToDouble(lblTaxes.Text) + Convert.ToDouble(lblServiceTax.Text))).ToString(); //- Convert.ToDouble(dsFlights.Tables[0].Rows[0]["TDiscount"].ToString())).ToString();
                pnlViewticket.Visible = true;
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
                        DateTime dt3 = Convert.ToDateTime(strArryDeptDatetimeRet[0].ToString());
                        string date3 = dt3.ToString("dd/MM/yyyy");
                        lblDepartureDatereturn.Text = date3.ToString();
                        lblDepartureTimereturn.Text = strArryDeptDatetimeRet[1].ToString();
                        string ArrivalDatetimeRet = dsFlights.Tables[0].Rows[1]["ArrivalDateTime"].ToString();
                        string[] strArrivalDatetimeRet = ArrivalDatetimeRet.Split('T');
                        DateTime dt4 = Convert.ToDateTime(strArrivalDatetimeRet[0].ToString());
                        string date4 = dt4.ToString("dd/MM/yyyy");
                        lblArrivalDatereturn.Text = date4.ToString();
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

            }
            else
            {
                pnlViewticket.Visible = false;
                lblMsg.Text = "Invalid Request";
                lblMsg.ForeColor = System.Drawing.Color.Red;
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
                pnlViewticket.Visible = true;
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
}