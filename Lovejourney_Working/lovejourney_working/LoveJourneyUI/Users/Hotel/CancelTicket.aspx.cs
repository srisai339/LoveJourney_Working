using System;
using System.Data;
using HotelAPILayer;
using BAL;
using System.Web.UI.WebControls;


public partial class Agent_Hotel_CancelTicket : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer; ClsBAL objBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        lblMsg.Text = "";
        this.Page.Title = "LoveJourney - Hotel - CancelTicket";

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("Cancel Hotel Ticket", Session["Role"].ToString());
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

    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("MM/dd/yyyy");//07/28/2007
        return date;
    }

    public string ConvertDate1(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.AddDays(-1).ToString("MM/dd/yyyy");//07/28/2007
        return date;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string bookingRef = "";
            string emailId = "";
            string lastName = "";
            string webService = "";
            string startDate = "";
            string endDate = "";

            HotelBAL obj = new HotelBAL();
            obj.ReferenceNo = txtBookingRefNo.Text.ToString().Trim().ToString();
            DataSet ds = obj.GetHotelProvisional();

            if (ds == null)
            { lblMsg.Text = "Invalid reference number."; return; }
            if (ds.Tables.Count == 0)
            { lblMsg.Text = "Invalid reference number."; return; }
            if (ds.Tables[0].Rows.Count == 0)
            { lblMsg.Text = "Invalid reference number."; return; }

            DataRow dr = ds.Tables[0].Rows[0];

            emailId = dr["EmailId"].ToString();
            lastName = dr["LastName"].ToString();
            bookingRef = dr["BookingRefNo"].ToString();
            webService = dr["WebService"].ToString();
            startDate = ConvertDate(dr["CheckIn"].ToString());
            endDate = ConvertDate1(dr["CheckOut"].ToString());
            string status = dr["Status"].ToString();
            double hotelTotalFare = Convert.ToDouble(dr["HotelTotalFare"].ToString());

            if (status == "Cancelled") { lblMsg.Text = "Already this ticket has been cancelled."; return; }
            //if (emailId != txtEmailId.Text.Trim().ToString()) { lblMsg.Text = "Invalid email id."; return; }

            DataSet dsHotelCancellation = objArzooHotelAPILayer.HotelCancellation(emailId, lastName, bookingRef, webService, startDate, endDate);

            if (!dsHotelCancellation.Tables.Contains("HotelCancellation"))
            { lblMsg.Text = "Failed to cancel the ticket."; return; }

            DataTable dtCancellation = dsHotelCancellation.Tables["HotelCancellation"];
            if (dtCancellation.Rows.Count > 0)
            {
                DataRow item = dtCancellation.Rows[0];
                string cancellationId = item["cancellationId"].ToString();
                string refundTotalAmount = item["refundTotalAmount"].ToString();
                string cancellationAmount = item["cancellationAmount"].ToString();
                string success = item["success"].ToString();
                string error = item["error"].ToString();
                if (success != "" && cancellationId != "")
                {
                    lblMsg.Text = "Status: " + "Ticket has been cancelled successfully.";
                    string provisionalId = dr["ProvisionalId"].ToString();
                    string bookingId = dr["BookingId"].ToString();

                    double cancellationCharges = hotelTotalFare - Convert.ToDouble(refundTotalAmount);

                    InsertCancellaion(provisionalId, bookingId, Convert.ToDouble(refundTotalAmount),
                        cancellationCharges, Convert.ToInt32(Session["UserID"].ToString()), cancellationId);
                }
                else if (error != "") { lblMsg.Text = error.ToString(); }
                else { lblMsg.Text = "Failed to cancel the ticket."; }
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    public string InsertCancellaion(string provisionalId, string bookingId, double refundAmount, double cancellationCharges, int createdBy, string hotelCancellationId)
    {
        try
        {
            string strReturn = "";
            HotelBAL obj = new HotelBAL();
            obj.ProvisionalId = Convert.ToInt32(provisionalId);
            obj.BookingId = Convert.ToInt32(bookingId);
            obj.RefundAmount = refundAmount;
            obj.CancellationCharges = cancellationCharges;
            obj.CreatedBy = createdBy;
            obj.HotelCancellationId = hotelCancellationId;

            bool b = obj.AddHotelCancellation();
            if (b) { strReturn = "Success"; } else { strReturn = ""; }
            return strReturn;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
}