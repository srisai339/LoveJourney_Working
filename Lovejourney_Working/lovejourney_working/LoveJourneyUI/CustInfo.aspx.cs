using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using BAL;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LJ.CLB.DTO;
using LJ.CLB.Buses;


public partial class CustInfo : System.Web.UI.Page
{
    String[] BookingDetails = new String[20];
    SSAPIClient client = new SSAPIClient();
    bool res;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            string page = Request.Url.ToString().ToLower();

            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                if (page.Contains("custinfo.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;
                    //  HtmlGenericControl div = (HtmlGenericControl)this.Master.FindControl("divid");
                }
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                if (page.Contains("custinfo.aspx"))
                {
                    string url = "BusMasterpage.master";
                    this.MasterPageFile = url;


                    #region Markupfarefor Individual agents
                    Class1 objBal = new Class1();
                    DataSet objDataSet = new DataSet();
                    objBal.ScreenInd = Master123.gettopmarkup;
                    objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                    objBal.Type = "Bus";
                    objDataSet = (DataSet)objBal.fnGetData();
                    string markUpAmount = "0";
                    ViewState["MarkUp"] = markUpAmount;
                    if (objDataSet != null)
                    {
                        if (objDataSet.Tables.Count > 0)
                        {
                            markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                            ViewState["MarkUp"] = markUpAmount;
                        }
                    }
                   
                    #endregion

                }
            }
            else if (Session["Role"].ToString() == "CSE")
            {
                if (page.Contains("custinfo.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;

                }
            }
            else if (Session["Role"].ToString() == "User")
            {
                if (page.Contains("custinfo.aspx"))
                {
                    string url = "UserMasterPage.master";
                    this.MasterPageFile = url;

                }
            }


        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //LJ.CLB.Buses.AbhibusAPI obj = new LJ.CLB.Buses.AbhibusAPI();
        //string str = obj.getticketinfo("http://kaveribus.com/api/lovejourney/server.php", "LVOEJOURNEYAPI", "LJB8311");
        //return;

       


        this.Page.Title = "Passenger Info";

        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "CSE")
            {
                CheckPermission("custinfo.aspx", Session["Role"].ToString());
                return;
            }
            if (Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                btnProceedToPayment.Visible = false;

            }
            if (Session["Role"].ToString() == "Agent" || Session["Role"].ToString() == "Admin")
            {
                Promocode.Visible = false;
                cashcoupon.Visible = false;

            }
            else
            {
                Promocode.Visible = true;
                cashcoupon.Visible = true;
            }

        }



        if (!IsPostBack)
        {
            if (Request.QueryString["Refno"] != null)
            {
                if (Convert.ToString(Request.QueryString["Refno"]) == Convert.ToString(Session["Order_Id"]))
                {
                    if (Session["blockseats"] != null)
                    {
                        BlockSeats block = (BlockSeats)Session["blockseats"];
                        lblMsg.Text = client.bookTicket(block);
                        if (lblMsg.Text.ToString().Split(' ').Length == 1)
                        {

                            pnlmail.Visible = true;
                            GetTicketDetails();
                            lblMsg.Text = "";
                        }
                    }
                }
            }
            else
            {
                BookingDetails = (String[])Session["RedBusBookingDetails"];

                #region OneWayOrRoundTrip

                if (Session["RedBusBookingDetails"] != null)
                {
                    BookingDetails = (String[])Session["RedBusBookingDetails"];
                    pnlOnwardTicketDetails.Visible = true;


                    //AbhibusAPI abhi = new AbhibusAPI();
                    //abhi.checkGender(Convert.ToInt32(BookingDetails[10]), Convert.ToInt32(BookingDetails[11]),
                    //    BookingDetails[1], BookingDetails[12], BookingDetails[2], "Mr", "http://www.svrtravels.com/api/lovejourney/server.php", "LOVE@SVR");

                    if (ViewState["MarkUp"]!= null)
                    {
                        double amount = Convert.ToDouble(BookingDetails[3].ToString()) + Convert.ToDouble(ViewState["MarkUp"].ToString());
                        lblFare.Text = amount.ToString();
                        lblTotalAmountPayable.Text = amount.ToString();
                    }
                    else
                    {
                        lblFare.Text = BookingDetails[3];
                        lblTotalAmountPayable.Text = BookingDetails[3];
                    }

                  
                    lblRouteValue.Text = BookingDetails[0];
                    lblJourneyDate.Text = BookingDetails[1];
                    lblBusOperator.Text = BookingDetails[15].ToString();
                    lblBusType.Text = BookingDetails[14].ToString();
                    lblSeatNos.Text = BookingDetails[2];
                    lblBoardingPoint.Text = BookingDetails[4].Split('~')[0];
                    lblBoardingPoint.ToolTip = BookingDetails[4].Split('~')[1];
                   
                    
                    DataTable dtseats = new DataTable();
                    dtseats.Columns.Add("SeatNos");
                    char[] separator = { ',' };
                    string[] seatnos = lblSeatNos.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in seatnos)
                    {
                        DataRow dr = dtseats.NewRow();
                        dr["SeatNos"] = item;
                        dtseats.Rows.Add(dr);
                    }
                    if (dtseats != null)
                    {
                        ddlPrimaryPassenger.DataSource = dtseats;
                        ddlPrimaryPassenger.DataTextField = "SeatNos";
                        ddlPrimaryPassenger.DataBind();
                        rptPassengersonward.DataSource = dtseats;
                        rptPassengersonward.DataBind();
                    }

                    if (!BookingDetails[5].ToLower().Contains("single"))//RoundTrip
                    {
                        pnlreturnticketdetails.Visible = true;
                        string[] ss = new string[1];
                        ss[0] = " to";
                        lblReturnJourney.Visible = true;

                        lblRoutereturn.Text = BookingDetails[0].Split(ss, StringSplitOptions.None)[1].ToString() + " to " + BookingDetails[0].Split(ss, StringSplitOptions.None)[0].ToString();
                        lblJourneydatereturn.Text = BookingDetails[6];
                        lblbusoperatorreturn.Text = BookingDetails[17].ToString();
                        lblbustypereturn.Text = BookingDetails[16].ToString();
                        lblseatNosReturn.Text = BookingDetails[7];
                        lblBoardingpointreturn.Text = BookingDetails[9];
                        lbltotalFarereturn.Text = BookingDetails[8];

                        lblTotalAmountPayable.Text = Convert.ToString(Convert.ToDouble(BookingDetails[8]) + Convert.ToDouble(lblFare.Text.ToString()));

                        DataTable dtseatsRet = new DataTable();
                        dtseatsRet.Columns.Add("SeatNos");
                        char[] separatorRet = { ',' };
                        string[] seatnosRet = lblseatNosReturn.Text.Split(separatorRet, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in seatnosRet)
                        {
                            DataRow dr = dtseatsRet.NewRow();
                            dr["SeatNos"] = item;
                            dtseatsRet.Rows.Add(dr);
                        }
                        if (dtseatsRet != null)
                        {
                            rptrPsgrDetailsReturn.DataSource = dtseatsRet;
                            rptrPsgrDetailsReturn.DataBind();
                        }
                    }
                    else//OneWay
                    {
                        pnlreturnticketdetails.Visible = false;
                    }
                }

                #endregion
            }
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            tblMain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                tblMain.Visible = false;

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
                            tblMain.Visible = true;
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
    DateTime dt;
    protected void btnProceedToPayment_Click(object sender, EventArgs e)
    {
       
        try
        {
            if (cbxAgree.Checked == false)
            {
                lblMsg.Text = "please check the Terms & conditions.";
                return;
            }
            int? createdBy = null;
            if (Session["UserID"] != null) { createdBy = Convert.ToInt32(Session["UserID"].ToString()); }
            else { createdBy = 0; }




            if (Session["RedBusBookingDetails"] != null)
            {
                BookingDetails = (String[])Session["RedBusBookingDetails"];
                // string gridviewdata = client.getBoardingPoint(BookingDetails[4].Split('~')[1]);
                // DataTable dtOnwardBoardingInfo = convertJsonStringToDataSet(gridviewdata).Tables[0];
                string boardinginf = BookingDetails[4].ToString();
                string strOnwardBoardingInfo = string.Empty;
                if (BookingDetails[19].ToString().Trim() == "TICKETGOOSE")
                {
                    strOnwardBoardingInfo = Convert.ToString(BookingDetails[4].Split('~')[0]);
                }
                else
                {
                    strOnwardBoardingInfo = Convert.ToString(BookingDetails[4]);
                }

                // string strOnwardBoardingInfo = dtOnwardBoardingInfo.Rows[0]["address"].ToString() + "," +
                // dtOnwardBoardingInfo.Rows[0]["landmark"].ToString();

                String referenceNumber = "";
                String referenceNumberReturn = "";
                referenceNumber = GenerateManabusRefNo();
                string provider = BookingDetails[19].ToString();

                if (BookingDetails[5].ToLower().Contains("single"))
                {
                    Session["Ticketrefno"] = referenceNumber;
                }

                Session["Order_Id"] = referenceNumber;
                Session["Amount"] = lblTotalAmountPayable.Text;
                string phoneno;
                //SingleTrip
                if (BookingDetails[5].ToLower().Contains("single"))
                {

                    #region onwardTrip
                    String nameList = ""; String genderList = ""; String titleList = ""; String ageList = "";
                    int countlist = 0;
                    foreach (RepeaterItem item in rptPassengersonward.Items)
                    {
                        DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                        TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                        TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");
                        phoneno = txtPhoneNo.Text;
                        if (countlist == 0)
                        {
                            ++countlist;
                            nameList += txtPassengerNamerptr.Text;
                            titleList += ddlrptr.SelectedItem.Value.ToString();
                            ageList += txtAgerptr.Text;
                            genderList += ddlrptr.SelectedItem.Text.ToString();
                        }
                        else
                        {
                            ++countlist;
                            nameList += "," + txtPassengerNamerptr.Text;
                            titleList += "," + ddlrptr.SelectedItem.Value.ToString();
                            ageList += "," + txtAgerptr.Text;
                            genderList += "," + ddlrptr.SelectedItem.Text.ToString();
                        }
                    }

                    String passengerDetailsonward = "";
                    string bookingid = "";
                    string boarding = lblBoardingPoint.ToolTip.ToString();
                    BlockSeats blockseats = new BlockSeats();
                    blockseats.SourceId = int.Parse(BookingDetails[10]);
                    blockseats.DestinationId = int.Parse(BookingDetails[11]);
                    blockseats.TripId = BookingDetails[12];
                    blockseats.JourneyDate = BookingDetails[1];
                    blockseats.BoardingId = BookingDetails[4].Split('~')[1];
                    blockseats.NoOfSeats = countlist;
                    blockseats.SeatNo = BookingDetails[2];
                    blockseats.Title = titleList;
                    blockseats.Name = nameList;
                    blockseats.Age = ageList;
                    blockseats.Sex = genderList;
                    blockseats.Address = txtAddress.Text;
                    blockseats.BookingRefNo = referenceNumber;
                    blockseats.IdCardType = ddlIDType.SelectedItem.Text;
                    blockseats.IdCardNo = txtIDNumber.Text;
                    blockseats.IdCardIssuedBy = txtIdIssuedBY.Text;
                    blockseats.MobileNo = txtPhoneNo.Text;
                    blockseats.EmergencyMobileNo = txtPhoneNo.Text;
                    blockseats.EmailId = txtEmailId.Text;
                    blockseats.ProviderName = BookingDetails[19].ToString();
                    blockseats.BookingId = bookingid;
                    string blockresult = client.blockTicket(blockseats);
                    DataSet ds = convertJsonStringToDataSet(blockresult);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Columns.Contains("Status"))
                            {
                                if (ds.Tables[0].Rows[0]["Status"].ToString().ToUpper() == "SUCCESS")
                                {
                                    if (ds.Tables[0].Columns.Contains("BookingID"))
                                    {
                                        blockseats.BookingId = ds.Tables[0].Rows[0]["BookingID"].ToString();
                                        lblMsg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = ds.Tables[0].Rows[0]["message"].ToString();
                                    return;
                                }
                            }
                        }
                    }
                    if (Session["UserID"] != null)
                    {
                        if (Session["Role"].ToString() == "Agent")
                        {
                            ClsBAL objBAL = new ClsBAL();
                            DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"]));
                            DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "Bus", provider); // Change it
                            if (dsCommSlab != null)
                            {
                                if (dsCommSlab.Tables[0].Rows.Count > 0)
                                {
                                    string commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it

                                    string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                                    //string commisionPercentage = dsBalance.Tables[0].Rows[0]["CommisionPercentage"].ToString();
                                    string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
                                    string actualFare;
                                    string deductAmount;
                                    string commisionFare;
                                    if (ViewState["MarkUp"] != null)
                                    {
                                        double Am = Convert.ToDouble(lblTotalAmountPayable.Text.ToString()) - Convert.ToDouble(ViewState["MarkUp"].ToString());
                                        actualFare = Am.ToString();
                                        deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));
                                        commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                                    }
                                    else
                                    {
                                         actualFare = lblTotalAmountPayable.Text.ToString();
                                         deductAmount = Convert.ToString(Convert.ToDouble(lblTotalAmountPayable.Text.ToString()) - ((Convert.ToDouble(lblTotalAmountPayable.Text.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));
                                         commisionFare = Convert.ToString(Convert.ToDouble(lblTotalAmountPayable.Text.ToString()) - Convert.ToDouble(deductAmount));
                                    }


                                   
                                    Session["AgentId_Agent"] = agentId;
                                    Session["ActualFare_Agent"] = actualFare;
                                    Session["CommisionFare_Agent"] = commisionFare;
                                    Session["CommisionPercentage_Agent"] = commisionPercentage;
                                    Session["DeductAmount_Agent"] = deductAmount;
                                    Session["Markup"] = ViewState["MarkUp"];
                                    if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                                    {
                                        bool b = objBAL.UpdateAgentBalance(Convert.ToInt32(agentId), Convert.ToDouble(deductAmount), Convert.ToDouble(commisionFare));
                                        //UpdateagentBalance,@RefundAmount

                                    }
                                    else
                                    {
                                        lblMsg.Text = "You dont have enough balance to book a ticket.";
                                        return;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Please Contact administrater ";
                                    return;
                                }
                            }
                        }
                    }


                    Session["blockseats"] = blockseats;

                    if (lblMsg.Text.ToString().ToUpper() == "SUCCESS" && lblMsg.Text.ToString().ToLower() != "tentative booking failed")
                    {
                        string[] strDate = BookingDetails[1].Trim().ToString().Split('-');
                        dt = Convert.ToDateTime(strDate[2] + "-" + strDate[1] + "-" + strDate[0]);
                        int countpassengers = 0;
                        foreach (RepeaterItem item in rptPassengersonward.Items)
                        {
                            DropDownList ddlrptr = (DropDownList)item.FindControl("ddlGender");
                            Label lblSeatNorptr = (Label)item.FindControl("lblSeatNo");
                            TextBox txtPassengerNamerptr = (TextBox)item.FindControl("txtPassengerName");
                            TextBox txtAgerptr = (TextBox)item.FindControl("txtAge");
                            if (countpassengers == 0)
                            {
                                ++countpassengers;
                                passengerDetailsonward += lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text;
                            }
                            else
                            {
                                ++countpassengers;
                                passengerDetailsonward += "," + lblSeatNorptr.Text + "-" + ddlrptr.SelectedItem.Value + "-" + txtPassengerNamerptr.Text + "-" + txtAgerptr.Text;
                            }
                        }
                    }
                    string[] str = new string[1];
                    str[0] = " to";
                    //BookingDetails[4].Split('-')[7].Split('~')[1]
                    String[] cities = BookingDetails[0].ToString().Split(str, StringSplitOptions.None);
                    res = InsertTentativeBooking(referenceNumber, Convert.ToString(Session["Ticketrefno"]), blockseats.BookingId, lblMsg.Text.ToString(), "", "", null, provider
                            , BookingDetails[15].ToString(), BookingDetails[14].ToString(), dt
                            , Convert.ToInt32(BookingDetails[10].ToString()), cities[0].ToString()
                            , Convert.ToInt32(BookingDetails[11].ToString()), cities[1].ToString()
                        , lblSeatNos.Text.ToString(), rptPassengersonward.Items.Count,Convert.ToDecimal(ViewState["MarkUp"].ToString()),  Convert.ToDecimal(lblFare.Text.Trim().ToString()), null
                            , strOnwardBoardingInfo, BookingDetails[4].Split('-')[0].ToString() + "-" + BookingDetails[4].Split('-')[BookingDetails[4].Split('-').Length - 1].ToString().Split('~')[0].ToString(), nameList, 20, "M", txtPhoneNo.Text.ToString()
                            , txtEmailId.Text.ToString(), txtAddress.Text.ToString()
                            , "", null, 0, 0, "Online", "Cash", "Oneway", createdBy, "Online", "", passengerDetailsonward
                            , ddlIDType.SelectedItem.Text.ToString(), txtIDNumber.Text.ToString(), "", provider, Convert.ToDouble(Session["CommisionFare_Agent"]), blockseats.TripId, blockseats.Title, Convert.ToString(blockseats.BoardingId));
                    if (res == true)
                    {
                        if (Session["UserID"] != null)
                        {
                            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
                            {

                                lblMsg.Text = client.bookTicket(blockseats);
                                DataSet dsbook = convertJsonStringToDataSet(lblMsg.Text);
                                if (dsbook != null)
                                {
                                    if (dsbook.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsbook.Tables[0].Columns.Contains("APIPNR"))
                                        {
                                            lblMsg.Text = dsbook.Tables[0].Rows[0]["APIPNR"].ToString();
                                        }
                                    }
                                }
                                if (Convert.ToString(dsbook.Tables[0].Rows[0]["APIPNR"]) == "SUCCESS" || Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]).ToUpper() == "SUCCESS")
                                {
                                    if (lblMsg.Text.ToString().Split(' ').Length == 1)
                                    {
                                        InsertBookedTicketDetails(referenceNumber, lblMsg.Text.ToString());
                                        Response.Redirect("redirectbus.aspx", false);

                                    }
                                }
                                else
                                {
                                    return; //Booking Failed.
                                }
                            }
                            else if (Session["Role"].ToString() == "Agent")
                            {

                                lblMsg.Text = client.bookTicket(blockseats);
                                DataSet dsbook = convertJsonStringToDataSet(lblMsg.Text);
                                if (dsbook != null)
                                {
                                    if (dsbook.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsbook.Tables[0].Columns.Contains("APIPNR"))
                                        {
                                            lblMsg.Text = dsbook.Tables[0].Rows[0]["APIPNR"].ToString();
                                        }
                                    }
                                }
                                if (Convert.ToString(dsbook.Tables[0].Rows[0]["APIPNR"]) == "SUCCESS" || Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]).ToUpper() == "SUCCESS")
                                {
                                    if (lblMsg.Text.ToString().Split(' ').Length == 1)
                                    {
                                        InsertBookedTicketDetails(referenceNumber, lblMsg.Text.ToString());
                                        Response.Redirect("redirectbus.aspx", false);

                                    }
                                }
                                else
                                {
                                    return; //Booking Failed.
                                }


                            }
                            else if (Convert.ToDouble(lblTotalAmountPayable.Text) == Convert.ToDouble(0))
                            {
                                lblMsg.Text = client.bookTicket(blockseats);
                                DataSet dsbook = convertJsonStringToDataSet(lblMsg.Text);
                                if (dsbook != null)
                                {
                                    if (dsbook.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsbook.Tables[0].Columns.Contains("APIPNR"))
                                        {
                                            lblMsg.Text = dsbook.Tables[0].Rows[0]["APIPNR"].ToString();
                                        }
                                    }
                                }
                                if (Convert.ToString(dsbook.Tables[0].Rows[0]["APIPNR"]) == "SUCCESS" || Convert.ToString(dsbook.Tables[0].Rows[0]["Status"]).ToUpper() == "SUCCESS")
                                {
                                    if (lblMsg.Text.ToString().Split(' ').Length == 1)
                                    {
                                        InsertBookedTicketDetails(referenceNumber, lblMsg.Text.ToString());
                                        Response.Redirect("redirectbus.aspx", false);

                                    }
                                }
                                else
                                {
                                    return; //Booking Failed.
                                }
                            }
                            else if (Session["Role"].ToString() == "User")
                            {
                                Server.Transfer("Pay.aspx?val=bus");
                            }
                        }
                        else
                        {
                            // Response.Redirect("redirectbus.aspx?Refno=" + Session["Ticketrefno"].ToString(), false);
                            Response.Redirect("Pay.aspx?val=bus", false);
                        }
                    }

                    #endregion

                }

            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
    protected void GetCancellationPolicy(string API)
    {
        try
        {
            ClsBAL ObjManbusBAL = new ClsBAL();
            if (API.Length >= 5)
            {
                ObjManbusBAL.api = API.Substring(0, 5);
            }
            else { ObjManbusBAL.api = API; }
            DataSet _objDataSet = (DataSet)ObjManbusBAL.GetCancelPercentageByAPI();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    gvCancellationDetails.DataSource = _objDataSet.Tables[0];
                    gvCancellationDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void GetTicketDetails()
    {
        try
        {
            if (Session["Ticketrefno"] != null)
            {
                ClsBAL ObjManbusBAL = new ClsBAL();
                ObjManbusBAL.manabusRefNo = Session["Ticketrefno"].ToString();
                DataSet _objDataSetBook = (DataSet)ObjManbusBAL.GetTicketIdByTicketrefNo();
                if (_objDataSetBook != null)
                {
                    if (_objDataSetBook.Tables.Count > 0)
                    {
                        if (_objDataSetBook.Tables[0].Rows.Count > 0)
                        {
                            string travelName = _objDataSetBook.Tables[0].Rows[0]["TravelOPName"].ToString();
                            string api = _objDataSetBook.Tables[0].Rows[0]["APIName"].ToString();
                            gvView.DataSource = _objDataSetBook.Tables[0];
                            gvView.DataBind();

                            GetCancellationPolicy(travelName);



                            Mail(_objDataSetBook.Tables[0].Rows[0]["EmailId"].ToString());

                            ViewState["MailId"] = _objDataSetBook.Tables[0].Rows[0]["EmailId"].ToString();
                            ViewState["BookingId"] = _objDataSetBook.Tables[0].Rows[0]["BookingId"].ToString();
                            ViewState["TentativeId"] = _objDataSetBook.Tables[0].Rows[0]["TentativeId"].ToString();

                        }
                    }
                }
            }

        }
        catch (System.Exception ex)
        {
            throw ex;
        }

    }
    protected bool InsertBookedTicketDetails(string TicketrefNo, string tinNo)
    {
        try
        {
            string message = ""; bool resinsert = false;

            ClsBAL ObjManbusBAL = new ClsBAL();
            ObjManbusBAL.PNRNumber = tinNo;
            ObjManbusBAL.PNRTicketIDs = tinNo;
            ObjManbusBAL.message = message;
            ObjManbusBAL.manabusRefNo = TicketrefNo;
            ObjManbusBAL.api = "SeatSeller";

            if (ObjManbusBAL.AddBooking_TicketDetails())
            {
                resinsert = true;
            }

            return resinsert;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    protected string GenerateManabusRefNo()
    {

        try
        {
            int minPassSize = 4; int maxPassSize = 4;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = "0123456789".ToCharArray();
            int newPassLength = new Random().Next(minPassSize, maxPassSize);
            char character;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < newPassLength; i++)
            {
                character = charArray[rnd.Next(0, (charArray.Length - 1))];
                stringBuilder.Append(character);
            }
            ClsBAL objBAL = new ClsBAL();
            string strUniqueId = objBAL.GetUniqueId();
            string refno = "LJB" + stringBuilder.ToString() + strUniqueId.ToString();

           
            return refno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool InsertTentativeBooking(string onewayrefNo, string pGRefNo, string blockedId, string ticketId, string serviceId, string serviceTransDateId,
int? coachTypeId, string Api, string travelName, string busType, DateTime doJ, int sourceId, string sourceName, int destinationId, string destinationName,
string bookedSeats, int noofSeats,decimal markup, decimal basicFare, int? bordingpointId, string boardingpointInfo, string boradingPoint, string fullname, int age, string gender, string mobileNo,
string emailid, string address, string status, DateTime? responsedatetime, int? cashCouponId, int? promoCodeId, string deliveryType, string paymentType, string tripType,
int? createdBy, string saleType, string servicenumber, string passengerInfo, string Idtype, string IdNumber, string PrimaryPassengerseat, string Provider, Double commissionfare, string TripID, string Title, string Bording_ID)
    {
        try
        {
            ClsBAL objTicketBAL = new ClsBAL();
            objTicketBAL.OnewayMBRefNo = onewayrefNo;
            objTicketBAL.PGMBRefNo = pGRefNo;
            objTicketBAL.blockedId = blockedId;
            objTicketBAL.ticketId = ticketId;
            objTicketBAL.serviceId = serviceId;
            objTicketBAL.serviceTranDateId = serviceTransDateId;
            objTicketBAL.coachTypeId = coachTypeId;
            objTicketBAL.api = Api;
            objTicketBAL.travelName = travelName;
            objTicketBAL.busType = busType;
            objTicketBAL.dateOFJourney = doJ;
            objTicketBAL.sourceId = sourceId;
            objTicketBAL.sourceName = sourceName;
            objTicketBAL.destionationId = destinationId;
            objTicketBAL.destinationName = destinationName;
            objTicketBAL.bookedSeats = bookedSeats;
            objTicketBAL.noOfSeats = noofSeats;
            objTicketBAL.boardingPointId = bordingpointId;
            objTicketBAL.markup = Convert.ToDecimal(markup);
            objTicketBAL.totalbasicFare = Convert.ToDecimal(basicFare);
            objTicketBAL.boardingpointinfo = boardingpointInfo;
            objTicketBAL.boardingPoint = boradingPoint;
            objTicketBAL.fullName = fullname;
            objTicketBAL.age = Convert.ToInt32(age);
            objTicketBAL.gender = gender;
            objTicketBAL.mobileNo = mobileNo;
            objTicketBAL.emailId = emailid;
            objTicketBAL.address = address;
            objTicketBAL.status = status;
            objTicketBAL.responsedatetime = responsedatetime;
            objTicketBAL.cashcouponId = cashCouponId;
            objTicketBAL.promoCodeId = promoCodeId;
            objTicketBAL.deliveryType = deliveryType;
            objTicketBAL.type = tripType;
            objTicketBAL.paymentType = paymentType;
            objTicketBAL.saleType = saleType;
            objTicketBAL.createdBy = createdBy;
            objTicketBAL.serviceNumber = servicenumber;
            objTicketBAL.IDType = Idtype;
            objTicketBAL.IDNumber = IdNumber;
            objTicketBAL.IDIssuedBy = txtIdIssuedBY.Text.ToString();
            objTicketBAL.PrimaryPassengerSeat = PrimaryPassengerseat;
            objTicketBAL.passengerDetails = passengerInfo;
            objTicketBAL.ProviderName = Provider;
            objTicketBAL.Commission = commissionfare;
            objTicketBAL.TripID = TripID;
            objTicketBAL.Title = Title;
            objTicketBAL.Boarding_Id = Bording_ID;
            if (objTicketBAL.AddTentativeBooking())
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private String BuildRequest(string TripId, int SourceId, int DestinationId, string JourneyDate,
       string BoardingId, int NoOfSeats, string SeatNo, string Title, string Name,
       string Age, string Sex, string Address, string BookingRefNo,
       string IdCardType, string IdCardNo, string IdCardIssuedBy, string MobileNo, string EmergencyMobileNo,
       string EmailId, string ProviderName, string BookingId, string ResultSet)
    {

        // fare = fare / seatnos.Split(',').Length;
        String[] names = Name.ToString().Split(',');
        String[] genders = Sex.ToString().Split(',');
        String[] titles = Title.ToString().Split(',');
        String[] ages = Age.ToString().Split(',');


        #region old requet

        //StringBuilder inventoryItemsString = new StringBuilder();
        //inventoryItemsString.Append("[");

        //if (SeatNo.Contains(","))
        //{
        //    for (int i = 0; i < SeatNo.Split(',').Length; i++)
        //    {
        //        inventoryItemsString.Append("{");
        //        inventoryItemsString.Append("\"fare\":\"" + fare);
        //        inventoryItemsString.Append("\",\"ladiesSeat\":\"false\",");
        //        if (i == 0)
        //        {
        //            inventoryItemsString.Append("\"passenger\":{\"address\":\"" + txtAddress.Text.ToString() + "\",");//

        //            inventoryItemsString.Append("\"age\":\"" + ages[i].ToString() + "\",");

        //            inventoryItemsString.Append("\"email\":\"" + txtEmailId.Text + "\",");//

        //            inventoryItemsString.Append("\"gender\":\"" + genders[i] + "\",\"idNumber\":\"" + txtIDNumber.Text.ToString() + "\",\"idType\":\"" + ddlIDType.SelectedItem.Text.ToString() + "\",");

        //            inventoryItemsString.Append("\"mobile\":\"" + txtPhoneNo.Text + "\",");//

        //            inventoryItemsString.Append("\"name\":\"" + names[i] + "\",");

        //            inventoryItemsString.Append("\"primary\":\"true\",");

        //            inventoryItemsString.Append("\"title\":\"" + titles[i]);

        //            //  inventoryItemsString.Append("\"ProviderName\":\"" + Providername);
        //        }

        //    }
        //}
        //else
        //{
        //    inventoryItemsString.Append("{");

        //    inventoryItemsString.Append("\"fare\":\"" + fare);

        //    inventoryItemsString.Append("\",\"ladiesSeat\":\"false\",");

        //    inventoryItemsString.Append("\"passenger\":{\"address\":\"" + txtAddress.Text.ToString() + "\",");//

        //    inventoryItemsString.Append("\"age\":\"" + ages[0] + "\",");

        //    inventoryItemsString.Append("\"email\":\"" + txtEmailId.Text + "\",");//

        //    inventoryItemsString.Append("\"gender\":\"" + genders[0] + "\",\"idNumber\":\"" + txtIDNumber.Text.ToString() + "\",\"idType\":\"" + ddlIDType.SelectedItem.Text.ToString() + "\",");

        //    inventoryItemsString.Append("\"mobile\":\"" + txtPhoneNo.Text + "\",");//

        //    inventoryItemsString.Append("\"name\":\"" + names[0] + "\",");

        //    inventoryItemsString.Append("\"primary\":\"true\",");

        //    inventoryItemsString.Append("\"title\":\"" + titles[0]);

        //    inventoryItemsString.Append("\"},");

        //    inventoryItemsString.Append("\"seatName\":\"" + seatnos + "\"},");
        //}
        //inventoryItemsString.Remove(inventoryItemsString.Length - 1, 1);
        //inventoryItemsString.Append("],");
        #endregion
        string makeBlockRequest = "{\'TripId\':\'" + TripId + "\',\'SourceId\':\'" + SourceId + "\',\'DestinationId\':\'" + DestinationId + "\',\'JourneyDate\':\'" + JourneyDate + "\',\'BoardingId\':\'" + BoardingId + "\',\'NoOfSeats\':\'" + NoOfSeats + "\',\'SeatNo\':\'" + SeatNo + "\',\'Title\':\'" + Title + "\',\'Name\':\'" + Name + "\',\'Age\':\'" + Age + "\',\'Sex\':\'" + Sex + "\',\'Address\':\'" + Address + "\',\'BookingRefNo\':\'" + BookingRefNo + "\',\'IdCardType\':\'" + IdCardType + "\',\'IdCardNo\':\'" + IdCardNo + "\',\'IdCardIssuedBy\':\'" + IdCardIssuedBy + "\',\'MobileNo\':\'" + MobileNo + "\',\'EmergencyMobileNo\':\'" + MobileNo + "\',\'EmailId\':\'" + EmailId + "\',\'ProviderName\':\'" + ProviderName + "\',\'BookingId\':\'" + BookingId + "\',\'ResultSet\':\'" + ResultSet + "\'}";
        return makeBlockRequest;
    }
    private DataSet convertJsonStringToDataSet(string jsonString)
    {
        try
        {
            XmlDocument xd = new XmlDocument();
            jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
            xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
            DataSet ds = new DataSet();
            ds.ReadXml(new XmlNodeReader(xd));
            return ds;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("selectbus.aspx", false);
    }

    protected void chkPromoCode_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPromoCode.Checked == true)
        {
            txtPromoCode.Visible = true;
            btnPromoCode.Visible = true;
        }
        else
        {
            txtPromoCode.Visible = false;
            btnPromoCode.Visible = false;
        }
    }

    protected void btnPromoCode_Click(object sender, EventArgs e)
    {

        try
        {
            if (chkPromoCode.Checked == true && txtPromoCode.Text != "")
            {
                ClsBAL objBAL = new ClsBAL();
                objBAL.promoCode = txtPromoCode.Text;
                DataSet ds = objBAL.CheckPromoCode();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToDouble(lblTotalAmountPayable.Text) >= Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]))
                        {
                            lblTotalAmountPayable.Text = (Convert.ToDouble(lblTotalAmountPayable.Text) - Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"])).ToString();

                        }
                        else
                        {
                            lblTotalAmountPayable.Text = "0";
                            //double fare = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]) - Convert.ToDouble(lblTotalAmountPayable.Text);
                            //lblTotalAmountPayable.Text = "0";
                            //objBAL.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["PromoCodeId"]);
                            //objBAL.Amount = fare.ToString();
                            //objBAL.createdBy = Convert.ToInt32(Session["UserID"]);
                            //bool b = objBAL.UpdatePromoCode();
                            //if (b == true)
                            //{
                            //    lblMsg.Text = "Yours cash coupon amount greater than ticket amount,for the remaining balance use same cash coupon no.";
                            //}
                        }
                        lblMsg.Text = "please enter promocode";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        txtPromoCode.Text = "";
                        txtPromoCode.Visible = false;
                        btnPromoCode.Visible = false;
                        chkPromoCode.Checked = false;
                    }
                    else
                    {
                        lblMsg.Text = "please enter valid promocode";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            else
            {
                lblMsg.Text = "please enter promocode";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    protected String GenerateRandomCode()
    {
        int minPassSize = 9;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        ClsBAL objBAL = new ClsBAL();
        string strUniqueId = objBAL.GetUniqueId();
        return "Ca" + stringBuilder.ToString() + strUniqueId;
    }
    protected void chkCashpay_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rbtnlstpaytype_SelectedIndexChanged(object sender, EventArgs e) { }

    protected void chkDealCode_CheckedChanged(object sender, EventArgs e) { }
    protected void btnDealCode_Click(object sender, EventArgs e) { }
    protected void chkCashCoupon_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCashCoupon.Checked == true)
        {
            txtcashcoupon.Visible = true;
            btncashcoupon.Visible = true;
        }
        else
        {

            txtcashcoupon.Visible = false;
            btncashcoupon.Visible = false;
        }
    }
    protected void btncashcoupon_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtcashcoupon.Text != "" && chkCashCoupon.Checked == true)
            {
                ClsBAL objBal = new ClsBAL();
                objBal.couponNo = txtcashcoupon.Text;
                DataSet ds = objBal.CheckCashCoupon();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["EmailId"].ToString() == txtEmailId.Text.ToString())
                        {
                            if (Convert.ToDouble(lblTotalAmountPayable.Text) >= Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]))
                            {
                                lblTotalAmountPayable.Text = (Convert.ToDouble(lblTotalAmountPayable.Text) - Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"])).ToString();
                                ClsBAL objBAL = new ClsBAL();
                                objBAL.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["CouponId"]);
                                objBAL.status = "0";
                                objBAL.modifiedBy = 0;
                                bool b = objBAL.UpdateCashCouponStatus();
                                if (b == true)
                                {
                                    lblMsg.Text = "Yours cash coupon amount has update.";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                            else
                            {
                                double fare = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]) - Convert.ToDouble(lblTotalAmountPayable.Text);
                                lblTotalAmountPayable.Text = "0";
                                ClsBAL objBAL = new ClsBAL();
                                objBAL.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["CouponId"]);
                                objBAL.Amount = fare.ToString();
                                objBAL.createdBy = Convert.ToInt32(Session["UserID"]);
                                bool b = objBAL.UpdateCashCoupon();
                                if (b == true)
                                {
                                    lblMsg.Text = "Yours cash coupon amount greater than ticket amount,for the remaining balance use same cash coupon no.";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                            txtcashcoupon.Text = "";
                            txtcashcoupon.Visible = false;
                            btncashcoupon.Visible = false;
                            chkCashCoupon.Checked = false;
                        }
                        else
                        {
                            lblMsg.Text = "Please enter valid cash coupon person email id.";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            txtEmailId.Text = "";
                            txtcashcoupon.Text = "";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Please enter valid cash coupon no.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            else
            {
                lblMsg.Text = "Please enter cash coupon no.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    protected void rptPassengersonward_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
    protected void rptrPsgrDetailsReturn_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
    protected void rptrPsgrDetailsReturn0_ItemDataBound(object sender, RepeaterItemEventArgs e) { }
    protected void gvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
    protected void Mail(string mailId)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (mailId != "")
            {
                string body = GetHtml(pnlmail);
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
    private string GetHtml(Panel pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        pnl.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }


}