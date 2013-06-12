using System;
using System.Data;
using HotelAPILayer;
using BAL;

public partial class CancelHTicket : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
        lblMsg.Text = "";
        if (!IsPostBack)
        {

        }
    }
    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
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
            obj.ReferenceNo = txtBookingRefNo.Text.ToString();
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
            endDate = ConvertDate(dr["CheckOut"].ToString());
            string status = dr["Status"].ToString();

            if (status == "Cancelled") { lblMsg.Text = "Already this ticket has been cancelled."; return; }
            if (emailId != txtEmailId.Text.Trim().ToString()) { lblMsg.Text = "Invalid email id."; return; }

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
                if (success != "")
                {
                    lblMsg.Text = "Status: " + success;
                    string provisionalId = dr["ProvisionalId"].ToString();
                    InsertCancellaion(provisionalId);
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
    public string InsertCancellaion(string provisionalId)
    {
        try
        {
            string strReturn = "";
            HotelBAL obj = new HotelBAL();
            obj.ProvisionalId = Convert.ToInt32(provisionalId);
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