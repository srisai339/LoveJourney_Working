using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using HotelAPILayer;


public partial class Agent_Hotel_PrintTicket : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    ClsBAL objBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        this.Page.Title = "LoveJourney - Hotel - PrintTicket"; lblMsg.Text = "";
        if (!IsPostBack)
        {
            if(Session["Role"] != null)
            {
            CheckPermission("Print Hotel Ticket", Session["Role"].ToString());
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
            pnlMain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlMain.Visible = false;

                ClsBAL objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                DataSet objDataSet = (DataSet)objBAL.GetPerByUser();
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
                            pnlMain.Visible = true;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            HotelBAL objTicket = new HotelBAL();
            objTicket.ReferenceNo = txtRefNo.Text.ToString().Trim().ToString();
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

            lblStar.Text = drTicketRow["HotelStar"].ToString()+" Star";

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
            pnlViewTicket.Visible = true; pnl.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
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
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”server” 
            -------------------------------------------  */
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
        pnl.Visible = true; pnlViewTicket.Visible = false;
        txtRefNo.Text = "";
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
}