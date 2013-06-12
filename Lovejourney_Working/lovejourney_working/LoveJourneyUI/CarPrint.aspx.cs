using System;
using System.Data;
using HotelAPILayer;
using BAL;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Net;

public partial class CarPrint : System.Web.UI.Page
{
    ClsBAL objBal;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {

                this.MasterPageFile = "UserMasterPage.master";
            }
            else if (Session["Role"].ToString() == "Agent")
            {

                this.MasterPageFile = "AgentMasterPage.master";
            }

        }
        else
        {
            this.MasterPageFile = "MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindTicketDetails();
        pnl.Visible = false;
        pnlViewTicket.Visible = true;

    }
    private void BindTicketDetails()
    {
        FlightBAL objFlightsBAL = new FlightBAL();
        DataSet dsFlights = new DataSet();
        dsFlights = objFlightsBAL.GetCarDetaisl(txtRefNo.Text,"");
        if (dsFlights.Tables[0].Rows.Count > 0)
        {

            //lblCarName.Text = dsFlights.Tables[0].Rows[1]["CarName"].ToString();
            lblCarRefNo.Text = dsFlights.Tables[0].Rows[0]["ReferanceId"].ToString();
            lblStatus.Text = dsFlights.Tables[0].Rows[0]["Status"].ToString();
            //if (dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString() == "1")
            //{
            //    lblStatus.Text ="Booked";
            //}

            lblAddress.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
            lblCity1.Text = dsFlights.Tables[0].Rows[0]["City_Car"].ToString();
            lblJourneyDate.Text = dsFlights.Tables[0].Rows[0]["TravelDate"].ToString();
            lblFirstName.Text = dsFlights.Tables[0].Rows[0]["Name"].ToString();
            lblMobileNo.Text = dsFlights.Tables[0].Rows[0]["MobileNo"].ToString();
            lblEmailId.Text = dsFlights.Tables[0].Rows[0]["EmailId"].ToString();
            lblAdd.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
            lblCity.Text = dsFlights.Tables[0].Rows[0]["City"].ToString();
            lblPinCode.Text = dsFlights.Tables[0].Rows[0]["ZipCode"].ToString();
            lblState.Text = dsFlights.Tables[0].Rows[0]["State"].ToString();
            lblPickupTime.Text = dsFlights.Tables[0].Rows[0]["PickupTime"].ToString();
            lblCarName.Text = dsFlights.Tables[0].Rows[0]["CarName"].ToString();

        }
    }
    protected void lbtnMail_Click(object sender, EventArgs e)
    {
        string body = getHTML(pnlTicket);
        bool res = MailSender.SendEmail(lblEmailId.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", body);
        // downlink.Visible = true;
        if (res)
        {

            lblMainMsg.Text = "Mail has been sent successfully";
            lblMainMsg.ForeColor = System.Drawing.Color.Green;

        }
        else
        {

            lblMainMsg.Text = "Failed to send Mail ";
            lblMainMsg.ForeColor = System.Drawing.Color.Red;
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

}