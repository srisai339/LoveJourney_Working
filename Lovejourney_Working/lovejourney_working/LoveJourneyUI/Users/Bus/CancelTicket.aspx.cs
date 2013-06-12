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
using System.Configuration;
using LJ.CLB.DTO;
using System.Data.SqlClient;

public partial class Users_CancelTicket : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    static bool CheckStatus = false;
    IBitlaAPILayer objBitlaAPILayer;
    IKesineniAPILayer objKesineniAPILayer;
    IAbhiBusAPILayer objAbhiBusAPILayer;
    IKalladaAPILayer objkalladaAPILayer;
    ITicketGooseAPILayer objTicketGooseAPILayer;
    String ConnectionString = ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
    static int i = 0;
    private string baseUrl = ConfigurationManager.AppSettings["I2SBus_BaseURL"];
    private string ConsumerKey = ConfigurationManager.AppSettings["I2SBus_ConsumerKey"];
    private string ConsumerSecret = ConfigurationManager.AppSettings["I2SBus_ConsumerSecret"];
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        objBitlaAPILayer = BitlaFactoryManager.GetBitlaAPILayerObject();
        objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
        objBitlaAPILayer.URL = BitlaConstants.URL;

        objKesineniAPILayer = KesineniFactoryManager.GetKesineniAPILayerObject();
        objKesineniAPILayer.LoginId = KesineniConstants.LoginId;
        objKesineniAPILayer.Password = KesineniConstants.Password;

        objAbhiBusAPILayer = AbhiBusFactoryManager.GetAbhiBusAPILayerObject();
        objkalladaAPILayer = KalladaFactoryManager.GetKalladaAPILayerObject();
        this.Page.Title = "LoveJourney - Bus - CancelTicket";

        objTicketGooseAPILayer = TicketGooseFactoryManager.GetTicketGooseAPILayerObject();
        objTicketGooseAPILayer.UserId = TicketGooseConstants.USERID;
        objTicketGooseAPILayer.Password = TicketGooseConstants.PASSWORD;

        if (!IsPostBack)
        {
            CheckPermission("Cancel Ticket", Session["Role"].ToString());
        }
    }
    protected void Mail(string mailId, string refNo)
    {
        try
        {
            objBAL = new ClsBAL();
            System.Data.DataSet ds = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            if (mailId != "")
            {
                string body = "Your (" + refNo + ") ticket has been cancelled.";
                bool res = Mailsender.SendEmail(mailId, "", "", "Ticket Cancelled Details", body);
                if (res)
                {
                    lblMsg.Text = "Ticket Details has been sent to your mail.Please check.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
                pnlMain.Visible = false;

                objBAL = new ClsBAL();
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

    protected DataSet CheckTicketID()
    {
        try
        {
            objBAL = new ClsBAL();
            // objManabusBAL.emailId = txtEmailID.Text;
            objBAL.manabusRefNo = txtMBRefNo.Text.Trim();
            objBAL.createdBy = Convert.ToInt32(Session["UserID"]);
            ObjDataset = (DataSet)objBAL.GetTicketIdByrefnoforcancel();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {

                        CheckStatus = true;
                        return ObjDataset;
                    }
                    else
                    {
                        CheckStatus = false;
                        ObjDataset = null;
                        return ObjDataset;
                    }
                }
                else
                {
                    CheckStatus = false;
                    ObjDataset = null;
                    return ObjDataset;
                }
            }
            else
            {
                CheckStatus = false;
                ObjDataset = null;
                return ObjDataset;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected String GeneratePromocode()
    {

        int minPassSize = 9;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$&".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        //lblMessage.Text = stringBuilder.ToString();
        return "Ca" + stringBuilder.ToString();
    }
    protected string GenerateManabusRefNo()
    {
        try
        {
            lblMsg.Text = "";
            int minPassSize = 5;
            int maxPassSize = 8;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int newPassLength = new Random().Next(minPassSize, maxPassSize);
            char character;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < newPassLength; i++)
            {
                character = charArray[rnd.Next(0, (charArray.Length - 1))];
                stringBuilder.Append(character);
            }
            return "CC" + stringBuilder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool AddCashCoupon(string Amount, string couponCode)
    {
        try
        {
            objBAL = new ClsBAL();

            objBAL.couponNo = Convert.ToString(couponCode);
            objBAL.emailId = Convert.ToString(txtEmailID.Text);
            objBAL.Amount = Convert.ToString(Amount);
            objBAL.createdBy = null;

            if (objBAL.AddCashCoupon(ref lblMsg))
            {
                return true;
            }
            else if (lblMsg.Text == "Already Cash Coupon with this Number Exists")
            {
                return false;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {

            throw ex;

        }

    }
    protected void AddCancellation(int bookingId, int tentativeId, string seatNos, string emailId, string refundAmt, string CancelCharges)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.bookingId = Convert.ToInt32(bookingId);
            objBAL.tentativeId = Convert.ToInt32(tentativeId);
            objBAL.cancelSeats = seatNos;
            objBAL.emailId = emailId;
            objBAL.refundAmount = refundAmt;
            objBAL.cancellationCharges = CancelCharges;
            lblCode.Text = "Can" + GeneratePromocode();
            objBAL.couponNo = lblCode.Text.ToString();
            objBAL.createdBy = Convert.ToInt32(Session["UserID"].ToString());
            ObjDataset = (DataSet)objBAL.AddCancellation();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows[0]["CouponNo"].ToString() == "Already  Exists")
                        {
                            AddCancellation(bookingId, tentativeId, seatNos, emailId, refundAmt, CancelCharges);
                        }
                        else if (ObjDataset.Tables[0].Rows[0]["CouponNo"].ToString() == "Success")
                        {
                            lblMsg.Text = "Ticket cancelled successfully.Cash Coupon Code has been sent to your Email Id Please check";
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            txtEmailID.Text = txtMBRefNo.Text = "";
                            if (ViewState["APIName"] != null)
                            {
                                if (ViewState["APIName"].ToString() == "Bitla")
                                {
                                    gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                                }
                                else if (ViewState["APIName"].ToString() == "Kesineni")
                                {
                                    gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                                    txtEmailID.Text = txtMBRefNo.Text = "";
                                }
                            }
                            string body = "HI " + Session["NameMail"].ToString() + ",<br/><br/>" + "Ticket has been cancelled successfully. Your Cash coupon code is " + lblCode.Text.ToString() + "<br/>Note: This Coupon will expire with in 6 months." + "<br/><br/>Thanks & Regards,<br/>LoveJourney Team.";
                            Mailsender.SendEmail(Session["EmailIdMail"].ToString(), "", "", "LoveJourney Cash Coupon Code", body);
                            lblMsg.Text = "Ticket cancelled successfully.Cash Coupon Code has been sent to your Email Id Please check";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to insert..Try Again";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Failed to insert..Try Again";
                    }
                }
                else
                {
                    lblMsg.Text = "Failed to insert..Try Again";
                }
            }
            else
            {
                lblMsg.Text = "Failed to insert..Try Again";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void UpdateCancelltion(int CancellationId, string CancelledSeats, string refundAmount, string cancellationCharges)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = CancellationId;
            objBAL.cancelSeats = CancelledSeats;
            objBAL.refundAmount = refundAmount;
            objBAL.cancellationCharges = cancellationCharges;
            objBAL.modifiedBy = Convert.ToInt32(Session["UserID"].ToString());
            if (objBAL.UpdateCancellations())
            {
                lblMsg.Text = "Ticket cancelled successfully. Cash Coupon Code has been sent to your email id. Please check";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtEmailID.Text = txtMBRefNo.Text = "";
                if (ViewState["APIName"] != null)
                {
                    if (ViewState["APIName"].ToString() == "Bitla")
                    {
                        gvPartialCancellation.Visible = rbtnlstCancelType.Visible = btnConfrmCancel.Visible = false;
                    }
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    private ClientAPIList GetAPIProvidersList(String ConsumerKey, String ConsumerSecret)
    {
        ClientAPIList objClientAPIList = new ClientAPIList();
        DataSet dsProviders = new DataSet();
        SqlConnection Connection = new SqlConnection(ConnectionString);
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "SP_WebAPI_GetProviders";
        command.Parameters.Add("@ConsumerKey", SqlDbType.VarChar).Value = ConsumerKey;
        command.Parameters.Add("@ConsumerSecret", SqlDbType.VarChar).Value = ConsumerSecret;
        command.Connection = Connection;
        Connection.Open();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(dsProviders);
        Connection.Close();

        //Check if atleast one provider is accessible
        if (dsProviders != null && dsProviders.Tables.Count > 0 && dsProviders.Tables[0].Rows.Count > 0)
        {
            //Loop each record, get the provider api details and add to objClientAPIList
            foreach (DataRow drProvider in dsProviders.Tables[0].Rows)
            {
                ClientAPIDetails objClientAPIDetails = new ClientAPIDetails();
                objClientAPIDetails.ClientID = int.Parse(drProvider["Client_ID"].ToString());
                objClientAPIDetails.ProviderID = int.Parse(drProvider["Provider_ID"].ToString());
                objClientAPIDetails.APIURL = drProvider["API_URL"].ToString();
                objClientAPIDetails.ConsumerKey = drProvider["API_ConsumerKey"].ToString();
                objClientAPIDetails.ConsumerSecret = drProvider["API_ConsumerSecret"].ToString();
                objClientAPIDetails.DomainIP = drProvider["Domain_IP"].ToString();
                objClientAPIDetails.ProviderName = drProvider["Provider_Name"].ToString();
                objClientAPIList.Add(objClientAPIDetails);
            }
            //Set cache to expire after 20 minutes,i.e., the object expires 
            //  and is removed from the cache 20 minutes after it is last accessed.
        }
        return objClientAPIList;

    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsticketdetails = CheckTicketID();
            if (CheckStatus)
            {
                if (dsticketdetails != null)
                {
                    int BookingId = Convert.ToInt32(dsticketdetails.Tables[0].Rows[0]["BookingId"].ToString());
                    int tentativeId = Convert.ToInt32(dsticketdetails.Tables[0].Rows[0]["TentativeId"].ToString());
                    string EmailId = dsticketdetails.Tables[0].Rows[0]["EmailId"].ToString();
                    string Name = dsticketdetails.Tables[0].Rows[0]["FullName"].ToString();
                    string seatnumbers = dsticketdetails.Tables[0].Rows[0]["SeatNos"].ToString();
                    string totalfareabhi = dsticketdetails.Tables[0].Rows[0]["TotalFare"].ToString();
                    string ticketNumberBitla = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();

                    Session["NameMail"] = Name;
                    Session["EmailIdMail"] = EmailId;

                    #region Kesineni
                    if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "Kesineni")
                    {
                        ViewState["APIName"] = "Kesineni";
                        rbtnlstCancelType.Visible = gvPartialCancellation.Visible = btnConfrmCancel.Visible = true;
                        gvPartialCancellation.DataSource = dsticketdetails.Tables[1];
                        gvPartialCancellation.DataBind();
                        ViewState["dsticketdetails"] = dsticketdetails.Tables[0];
                    }
                    #endregion

                    #region AbhiBus
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "SVR" || dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "KAVERI" || dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "RAJESH" || dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "SAIANJANA" || dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "KALLADA")
                    {
                        string ticketNumberAbhiBus = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();//"OHYD19615";
                        //cancelTicket
                        ClientAPIList objClientAPIList = new ClientAPIList();
                        objClientAPIList = GetAPIProvidersList(ConsumerKey, ConsumerSecret);
                        ClientAPIDetails objClientAPIDetails = objClientAPIList.SingleOrDefault(element => element.ProviderName == dsticketdetails.Tables[0].Rows[0]["APIName"].ToString()); //objClientAPIList.ElementAt(resultSet - 1)
                        LJ.CLB.Buses.AbhibusAPI obj = new LJ.CLB.Buses.AbhibusAPI();
                        DataTable dtAbhiBus = obj.cancelTicket(objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, ticketNumberAbhiBus);

                        if (dtAbhiBus != null)
                        {
                            if (dtAbhiBus.Rows.Count > 0)
                            {
                                if (dtAbhiBus.Rows[0]["status"].ToString().ToUpper().Trim().ToString() == "SUCCESS")
                                {
                                    string totalRefundAmount = dtAbhiBus.Rows[0]["total_refund_amount"].ToString();
                                    string canpercentage = dtAbhiBus.Rows[0]["cancellation_parcentage"].ToString();
                                    string[] canindec = canpercentage.Split('%');
                                    double cancelcharges = Convert.ToDouble(totalfareabhi) * (Convert.ToDouble(canindec[0].ToString()) / 100);
                                    AddCancellation(BookingId, tentativeId, seatnumbers, EmailId, Convert.ToString(Convert.ToDouble(totalfareabhi) - cancelcharges), Convert.ToString(cancelcharges));
                                    Mail(dtAbhiBus.Rows[0]["EmailId"].ToString(), dtAbhiBus.Rows[0]["PGMBRefNo"].ToString());
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                        }
                    }
                    #endregion

                    #region Bitla
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "BITLA")
                    {
                        ViewState["APIName"] = "Bitla";
                        rbtnlstCancelType.Visible = gvPartialCancellation.Visible = btnConfrmCancel.Visible = true;
                        gvPartialCancellation.DataSource = dsticketdetails.Tables[1];
                        gvPartialCancellation.DataBind();
                        ViewState["dsticketdetails"] = dsticketdetails.Tables[0];
                        btnConfrmCancel_Click(sender, e);
                    }
                    #endregion

                    #region Kallada
                    if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "kallada")
                    {

                        string ticketNumberkallada = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();//"OHYD19615";
                        DataTable dtkallada = objkalladaAPILayer.CancellationConfirmation(ticketNumberkallada);
                        if (dtkallada != null)
                        {
                            if (dtkallada.Rows.Count > 0)
                            {
                                if (dtkallada.Rows[0]["status"].ToString() == "Success")
                                {
                                    string totalRefundAmount = dtkallada.Rows[0]["total_refund_amount"].ToString();
                                    string canpercentage = dtkallada.Rows[0]["cancellation_parcentage"].ToString();
                                    string[] canindec = canpercentage.Split('%');
                                    double cancelcharges = Convert.ToDouble(totalfareabhi) * (Convert.ToDouble(canindec[0].ToString()) / 100);

                                    DataTable dtKallada1 = objkalladaAPILayer.TicketCancellation(ticketNumberkallada);
                                    if (dtKallada1.Rows.Count > 0 && dtKallada1.Columns.Count > 1)
                                    {
                                        AddCancellation(BookingId, tentativeId, seatnumbers, EmailId, Convert.ToString(Convert.ToDouble(totalfareabhi) - cancelcharges), Convert.ToString(cancelcharges));
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    #endregion

                    #region TicketGoose
                    else if (dsticketdetails.Tables[0].Rows[0]["APIName"].ToString() == "TICKETGOOSE")
                    {
                        ViewState["APIName"] = "TicketGoose";
                        string ticketNumber = dsticketdetails.Tables[0].Rows[0]["PNRNumber"].ToString();
                        string[] seatNos = dsticketdetails.Tables[0].Rows[0]["SeatNos"].ToString().Split(',');
                        DataTable dt = objTicketGooseAPILayer.CancelTicket(ticketNumber, seatNos);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["Status"].ToString() == "Success")
                                {
                                    DataTable dtt = objTicketGooseAPILayer.ConfirmTicketCancellation(ticketNumber, seatNos);
                                    if (dtt != null)
                                    {
                                        if (dtt.Rows.Count > 0)
                                        {
                                            if (dtt.Rows[0]["Status"].ToString() == "Success")
                                            {
                                                string refAmount = dtt.Rows[0]["refundAmount"].ToString();

                                                AddCancellation(BookingId, tentativeId, seatnumbers, EmailId,
                                               refAmount, Convert.ToString(Convert.ToDouble(totalfareabhi) - Convert.ToDouble(refAmount)));

                                                Mail(dt.Rows[0]["EmailId"].ToString(), dt.Rows[0]["PGMBRefNo"].ToString());

                                            }
                                            else { lblMsg.Text = "Ticket cancelled failed. Try Again"; }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    txtMBRefNo.Text = "";
                    lblCancelMessage.Visible = true;
                    lblCancelMessage.Text = "Invalid Love Journey RefNo";
                    lblCancelMessage.ForeColor = System.Drawing.Color.Maroon;
                }
            }
            else
            {
                txtMBRefNo.Text = "";
                lblCancelMessage.Visible = true;
                lblCancelMessage.Text = "Invalid Love Journey RefNo";
                lblCancelMessage.ForeColor = System.Drawing.Color.Maroon;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
            foreach (GridViewRow row in gvPartialCancellation.Rows)
            {
                CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");
                chkbChild.Checked = chkbHeader.Checked;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void CancelKesineniTickets(string CancelType, string SeatNos)
    {
        try
        {
            if (ViewState["dsticketdetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dsticketdetails"];
                int BookingId = Convert.ToInt32(dt.Rows[0]["BookingId"].ToString());
                int tentativeId = Convert.ToInt32(dt.Rows[0]["TentativeId"].ToString());
                string EmailId = dt.Rows[0]["EmailId"].ToString();
                string cancelllationId = dt.Rows[0]["CancellationId"].ToString();
                string CancelledSaets = dt.Rows[0]["CancelledSeats"].ToString();
                string pnrNumberKesineni = dt.Rows[0]["PNRNumber"].ToString().Trim().ToString();
                string firstNameKesineni = dt.Rows[0]["FullName"].ToString();
                string lastNameKesineni = dt.Rows[0]["FullName"].ToString();
                DateTime DOJ = Convert.ToDateTime(dt.Rows[0]["DateOfJourney"].ToString());
                string dateOfJourneyKesineni = DOJ.ToString("MM/dd/yyyy");
                string seatNumberListKesineni = dt.Rows[0]["SeatNos"].ToString();

                if (CancelType == "Total Cancellation")
                {
                    DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
             dateOfJourneyKesineni, SeatNos);

                    #region total Cancellation
                    if (dsKesineni != null)
                    {
                        if (dsKesineni.Tables[0].Rows.Count > 0 && dsKesineni.Tables[0].Columns.Count > 2)
                        {
                            double grandTotalRefund = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["GrandTotalRefunded"].ToString());
                            double cancellationCharges = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["CancellationCharges"].ToString());

                            DataSet dsKesineni1 = objKesineniAPILayer.ConfirmCancelTickets(pnrNumberKesineni, firstNameKesineni,
                             lastNameKesineni, dateOfJourneyKesineni, SeatNos);

                            if (dsKesineni1 != null)
                            {
                                if (dsKesineni1.Tables.Count > 0)
                                {
                                    if (dsKesineni1.Tables[0].Columns.Count > 1 && dsKesineni1.Tables[0].Rows.Count > 0)
                                    {
                                        AddCancellation(BookingId, tentativeId, SeatNos, EmailId, Convert.ToString(grandTotalRefund), Convert.ToString(cancellationCharges));



                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }

                        }

                    }
                    #endregion

                }
                else if (CancelType == "Partial Cancellation")
                {
                    DataSet dsKesineni = objKesineniAPILayer.CancelTickets(pnrNumberKesineni, firstNameKesineni, lastNameKesineni,
              dateOfJourneyKesineni, SeatNos);
                    #region PartialCancellation
                    if (dsKesineni != null)
                    {
                        if (dsKesineni.Tables[0].Rows.Count > 0 && dsKesineni.Tables[0].Columns.Count > 2)
                        {
                            double grandTotalRefundp = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["GrandTotalRefunded"].ToString());
                            double cancellationChargesp = Convert.ToDouble(dsKesineni.Tables[0].Rows[0]["CancellationCharges"].ToString());

                            DataSet dsKesineni1 = objKesineniAPILayer.ConfirmCancelTickets(pnrNumberKesineni, firstNameKesineni,
                             lastNameKesineni, dateOfJourneyKesineni, SeatNos);
                            if (dsKesineni1 != null)
                            {
                                if (dsKesineni1.Tables.Count > 0)
                                {
                                    if (dsKesineni1.Tables[0].Columns.Count > 1 && dsKesineni1.Tables[0].Rows.Count > 0)
                                    {


                                        if (cancelllationId != "" && CancelledSaets != "")
                                        {
                                            UpdateCancelltion(Convert.ToInt32(cancelllationId), SeatNos, Convert.ToString(grandTotalRefundp), Convert.ToString(cancellationChargesp));




                                        }
                                        else if (cancelllationId == "" && CancelledSaets == "")
                                        {
                                            AddCancellation(BookingId, tentativeId, SeatNos, EmailId, Convert.ToString(grandTotalRefundp), Convert.ToString(cancellationChargesp));


                                        }

                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }
                            else
                            {
                                lblMsg.Text = "Ticket cancelled failed.Try Again";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                            //GridView1.DataSource = dsBitla1; GridView1.DataBind();
                        }

                    }
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }




    }

    protected void CancelBitlaTickets(string CancelType, string SeatNos)
    {
        try
        {
            if (ViewState["dsticketdetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dsticketdetails"];
                int BookingId = Convert.ToInt32(dt.Rows[0]["BookingId"].ToString());
                int tentativeId = Convert.ToInt32(dt.Rows[0]["TentativeId"].ToString());
                string EmailId = dt.Rows[0]["EmailId"].ToString();
                string Name = dt.Rows[0]["FullName"].ToString();
                string ticketNumberBitla = dt.Rows[0]["PNRNumber"].ToString();
                string seatNumbersBitla = dt.Rows[0]["SeatNos"].ToString();
                string cancelllationId = dt.Rows[0]["CancellationId"].ToString();
                string CancelledSaets = dt.Rows[0]["CancelledSeats"].ToString();

                if (CancelType == "Total Cancellation")
                {
                    objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    objBitlaAPILayer.SeatNumbers = SeatNos;
                    DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();

                    #region Cancellation
                    if (dsBitla != null)
                    {
                        if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                        {
                            string refundAmount = dsBitla.Tables[0].Rows[0]["refund_amount"].ToString();
                            string cancellationCharges = dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString();
                            if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                            {

                                objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                                DataSet dsBitla1 = objBitlaAPILayer.CancelTicket();


                                if (dsBitla1 != null)
                                {
                                    if (dsBitla1.Tables.Count > 0)
                                    {
                                        if (dsBitla1.Tables[0].Columns.Count > 1 && dsBitla1.Tables[0].Rows.Count > 0)
                                        {
                                            AddCancellation(BookingId, tentativeId, SeatNos, EmailId, refundAmount, cancellationCharges);



                                        }
                                        else
                                        {
                                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    }

                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                }

                            }
                        }
                        else
                        {
                            lblMsg.Text = "Already cancelled ";

                        }
                    }
                    #endregion

                }
                else if (CancelType == "Partial Cancellation")
                {
                    objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                    objBitlaAPILayer.SeatNumbers = SeatNos;
                    DataSet dsBitla = objBitlaAPILayer.IsTicketCancellable();
                    #region PartialCancellation
                    if (dsBitla != null)
                    {
                        if (dsBitla.Tables[0].Rows.Count > 0 && dsBitla.Tables[0].Columns.Count > 2)
                        {
                            string refundAmount = dsBitla.Tables[0].Rows[0]["refund_amount"].ToString();
                            string cancellationCharges = dsBitla.Tables[0].Rows[0]["cancellation_charges"].ToString();
                            if (dsBitla.Tables[0].Rows[0]["is_cancellable"].ToString() == "true")
                            {
                                objBitlaAPILayer.TicketNumber = ticketNumberBitla;
                                DataSet dsBitla1 = objBitlaAPILayer.CancelPartialTicket();
                                if (dsBitla1 != null)
                                {
                                    if (dsBitla1.Tables.Count > 0)
                                    {
                                        if (dsBitla1.Tables[0].Columns.Count > 1 && dsBitla1.Tables[0].Rows.Count > 0)
                                        {


                                            if (cancelllationId != "" && CancelledSaets != "")
                                            {
                                                UpdateCancelltion(Convert.ToInt32(cancelllationId), SeatNos, refundAmount, cancellationCharges);



                                            }
                                            else if (cancelllationId == "" && CancelledSaets == "")
                                            {
                                                AddCancellation(BookingId, tentativeId, SeatNos, EmailId, refundAmount, cancellationCharges);




                                            }

                                        }
                                        else
                                        {
                                            lblMsg.Text = "Ticket cancelled failed.Try Again";
                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Ticket cancelled failed.Try Again";
                                    }

                                }
                                else
                                {
                                    lblMsg.Text = "Ticket cancelled failed.Try Again";
                                }
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Already cancelled ";
                        }
                    }
                    #endregion
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }



    }

    protected void btnConfrmCancel_Click(object sender, EventArgs e)
    {
        try
        {
            string Ids = string.Empty;
            lblMsg.Text = "";
            int i = 0;
            if (ViewState["APIName"] != null)
            {
                if (ViewState["APIName"].ToString() == "Bitla")
                {
                    #region Bitla
                    CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                    foreach (GridViewRow row in gvPartialCancellation.Rows)
                    {
                        CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");
                        if (chkbChild.Checked)
                        {
                            Label lblSeatNo = (Label)row.FindControl("lblSeatNo");
                            Label lblStatus = (Label)row.FindControl("lblStatus");
                            if (lblStatus.Text == "NotCancelled")
                            {
                                if (Ids.ToString() == "")
                                {
                                    Ids = Ids + lblSeatNo.Text.ToString();
                                }
                                else
                                {
                                    Ids = Ids + "," + lblSeatNo.Text.ToString();
                                }
                            }


                            i++;
                        }
                    }
                    if (rbtnlstCancelType.SelectedItem.Value == "0")
                    {

                        if (i > 0)
                        {

                            CancelBitlaTickets("Total Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    else if (rbtnlstCancelType.SelectedItem.Value == "1")
                    {
                        if (i > 0)
                        {

                            CancelBitlaTickets("Partial Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    #endregion
                }

                else if (ViewState["APIName"].ToString() == "Kesineni")
                {
                    #region Kesineni


                    CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                    foreach (GridViewRow row in gvPartialCancellation.Rows)
                    {
                        CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");
                        if (chkbChild.Checked)
                        {
                            Label lblSeatNo = (Label)row.FindControl("lblSeatNo");
                            Label lblStatus = (Label)row.FindControl("lblStatus");
                            if (lblStatus.Text == "NotCancelled")
                            {
                                if (Ids.ToString() == "")
                                {
                                    Ids = Ids + lblSeatNo.Text.ToString();
                                }
                                else
                                {
                                    Ids = Ids + "," + lblSeatNo.Text.ToString();
                                }
                            }


                            i++;
                        }
                    }
                    if (rbtnlstCancelType.SelectedItem.Value == "0")
                    {

                        if (i > 0)
                        {

                            CancelKesineniTickets("Total Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    else if (rbtnlstCancelType.SelectedItem.Value == "1")
                    {
                        if (i > 0)
                        {

                            CancelKesineniTickets("Partial Cancellation", Ids);
                        }
                        else
                        {
                            lblMsg.Text = "select atleast one seat to cancel";
                        }
                    }
                    #endregion
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void rbtnlstCancelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtnlstCancelType.SelectedItem.Value == "0")
            {
                CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                chkbHeader.Checked = true;
                foreach (GridViewRow row in gvPartialCancellation.Rows)
                {
                    CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");

                    chkbChild.Checked = chkbHeader.Checked;
                    chkbChild.Enabled = false;
                    chkbHeader.Enabled = false;
                }
            }
            else if (rbtnlstCancelType.SelectedItem.Value == "1")
            {
                CheckBox chkbHeader = (CheckBox)gvPartialCancellation.HeaderRow.FindControl("chkSelectAll");
                chkbHeader.Checked = false;
                foreach (GridViewRow row in gvPartialCancellation.Rows)
                {
                    CheckBox chkbChild = (CheckBox)row.FindControl("chkChild");

                    chkbChild.Checked = chkbHeader.Checked;
                    chkbChild.Enabled = true;
                    chkbHeader.Enabled = true;

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void gvPartialCancellation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                CheckBox chkChild = (CheckBox)e.Row.FindControl("chkChild");
                if (lblStatus.Text == "Cancelled")
                {
                    chkChild.Visible = false;
                }
                else if (lblStatus.Text == "NotCancelled")
                {
                    chkChild.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}