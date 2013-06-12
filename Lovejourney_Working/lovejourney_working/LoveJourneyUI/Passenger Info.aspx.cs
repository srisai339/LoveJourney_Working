using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.IO;
using System.Text;

public partial class Passenger_Info : System.Web.UI.Page
{
    ClsCommands objPsgDtl = new ClsCommands();
    DataSet _objDataSet;
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
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetCarDetails();
            // GetMail();
            // CityName.Text = Session["CityName"].ToString();
            TravelDate.Text = Session["TravelDate"].ToString();
            lblText.Text = "Cars in" +     Session["CityName"].ToString()   +   "On" + Session["TravelDate"].ToString();
        }
    }

    private void GetCarDetails()
    {
        try
        {
            objPsgDtl.ScreenInd = blossom.CarDetails;
            objPsgDtl.CarDetailsId = Convert.ToInt32(Session["CardetailsId"].ToString());
            _objDataSet = (DataSet)objPsgDtl.fnGetData();
            CarName.Text = _objDataSet.Tables[0].Rows[0]["CarName"].ToString();
            BasicPrice.Text = _objDataSet.Tables[0].Rows[0]["BasicPrice"].ToString();
            BookingType.Text = _objDataSet.Tables[0].Rows[0]["BookingType"].ToString();
            Status.Text = _objDataSet.Tables[0].Rows[0]["Status"].ToString();
            CityName.Text = _objDataSet.Tables[0].Rows[0]["CityName"].ToString();
        }
        catch (Exception)
        {

            throw;
        }
    }
    string str;
    ClsBAL objBal;
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            string refno = GenerateCabRef();
            if (Session["TravelDate"].ToString() != null && Session["CardetailsId"].ToString() != null)
            {
                objPsgDtl.ScreenInd = blossom.InsertPassengerDetails;
                objPsgDtl.TravelDate = Session["TravelDate"].ToString();
                objPsgDtl.CarDetailsId = Convert.ToInt32(Session["CardetailsId"].ToString());
                objPsgDtl.Name = txtName.Text.ToString();
                objPsgDtl.Address = txtAddress.Text.ToString();
                objPsgDtl.City = txtCity.Text.ToString();
                objPsgDtl.State = DDLState.SelectedValue.ToString();
                objPsgDtl.ZipCode = txtZipCode.Text.ToString();
                objPsgDtl.Country = txtCountry.Text.ToString();
                objPsgDtl.EmailId = txtEMailId.Text.ToString();
                objPsgDtl.MobileNo = txtMobileNo.Text.ToString();
                objPsgDtl.LandMark = txtLandMark.Text.ToString();
                objPsgDtl.city_car = Session["CityName"].ToString();
                objPsgDtl.Status = "Blocked";
                objPsgDtl.CarName = CarName.Text.ToString();
                Session["Amount"] = BasicPrice.Text;
                //objPsgDtl.Status = txtStatus.Text.ToString();
                // objPsgDtl.BasicPrice =Convert.ToDouble(txtBasicPrice.Text);
                // objPsgDtl.BookingType = txtBookingType.Text.ToString();
                objPsgDtl.PickUpTime = DDLPickUpTime.SelectedValue.ToString();
                objPsgDtl.Basicfare = BasicPrice.Text;
                if (Session["UserId"] != null)
                {
                    if (Session["Role"].ToString() == "Agent")
                    {
                       
                        Class1 objBal = new Class1();
                        DataSet objDataSet = new DataSet();
                        objBal.ScreenInd = Master123.gettopmarkup;
                        objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                        objBal.Type = "Cabs";
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

                        double actualfare = Convert.ToDouble(Session["Amount"]);
                        double totalfare = actualfare + Convert.ToDouble(markUpAmount);
                        objPsgDtl.TotalFare = totalfare.ToString();

                    }
                    else
                    {
                        objPsgDtl.TotalFare = BasicPrice.Text;
                    }
                }
                else
                {
                    objPsgDtl.TotalFare = BasicPrice.Text;
                }

                if (Session["UserId"] != null)
                {
                    objPsgDtl.AgentId = Session["UserId"].ToString();
                    objPsgDtl.AgentName = Session["UserName"].ToString();
                    objPsgDtl.Role = Session["Role"].ToString();
                }
                else
                {
                    objPsgDtl.Role = "Guest";
                }
                
                Session["refno"] = refno;
                objPsgDtl.ReferanceId = refno;
                objPsgDtl.CreatedBy = 1;
                 if (objPsgDtl.fnInsertRecord() == true)
                {
                    GetMail();
                    lblMsg.Text = "Record Inserted Successfully";
                    str = "SUCCESS";

                 

                }
                 if (Session["UserId"]!=null)
                 {
                     if (Session["Role"].ToString() == "User")
                     {
                         if (str == "SUCCESS")
                         {

                             Response.Redirect("~/Pay.aspx?val=car", false);
                         }
                     }
                 }

                if(Session["UserId"]==null)
                {
                    if (str == "SUCCESS")
                    {

                        Response.Redirect("~/Pay.aspx?val=car", false);
                    }
                    else
                    {
                        lblText.Text = "Booking is failed.Please try later";
                    }
                }
                else if (Session["UserId"] != null && Session["Role"].ToString()=="Admin")
                {
                    if (Session["Role"].ToString() == "Admin")
                    {
                        Response.Redirect("~/CarTicket.aspx", false);
                    }
                }
                else
                {
                    if (Session["Role"] != null)
                    {
                        if (Session["Role"].ToString() == "Agent")
                        {
                            ClsBAL objBal = new ClsBAL();
                            DataSet dsBalance = objBal.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                            DataSet dsCommSlab = objBal.GetCommissionSlab(Session["Role"].ToString(), "Car", ""); // Change it
                            string commisionPercentage = string.Empty;

                            if (dsCommSlab != null)
                            {
                                if (dsCommSlab.Tables[0].Rows.Count > 0)
                                {
                                    commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();// Change it
                                }
                                else
                                {
                                    commisionPercentage = "0";
                                }
                            }
                            else
                            {
                                commisionPercentage = "0";
                            }


                            string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                            string agentId = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
                            string TotalFare = BasicPrice.Text;
                            string actualFare = TotalFare;
                            string deductAmount = Convert.ToString(Convert.ToDouble(actualFare.ToString()) -
                                ((Convert.ToDouble(actualFare.ToString()) * Convert.ToDouble(commisionPercentage)) / 100));

                            string commisionFare = Convert.ToString(Convert.ToDouble(actualFare.ToString()) - Convert.ToDouble(deductAmount));

                            Session["AgentId_Agent"] = agentId;
                            Session["ActualFare_Agent"] = actualFare;
                            Session["CommisionFare_Agent"] = commisionFare;
                            Session["CommisionPercentage_Agent"] = commisionPercentage;
                            Session["DeductAmount_Agent"] = deductAmount;

                            if (Convert.ToDouble(balance) >= Convert.ToDouble(deductAmount))
                            {
                                string[] commPer = Session["CommisionPercentage_Agent"].ToString().Split('.');
                                DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(Session["DeductAmount_Agent"].ToString()),
                                                        Convert.ToInt32(Session["UserID"].ToString()), refno, Convert.ToDouble(Session["ActualFare_Agent"].ToString()),
                                                        Convert.ToDouble(Session["CommisionFare_Agent"].ToString()), Convert.ToDouble(Session["CommisionPercentage_Agent"]));

                                objBal = new ClsBAL();
                                DataSet dsBalanceA = objBal.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                                string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                                Label lbl = (Label)this.Master.FindControl("lblBalance");
                                lbl.Text = balanceAgent;
                                Session["Balance"] = balanceAgent;
                                Response.Redirect("~/CarTicket.aspx", false);


                            }
                            else
                            {



                                lblMsg.Text = "Your balance is too low to book the ticket.So,please contact administrator";

                                return;
                            }
                        }
                    }
                }

               
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare,
          double commisionFare, double commisionPercentage)
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            return objBAL.DeductAgentBalance(agentId, deductAmount, createdBy, mbRefNo,
                actualFare, commisionFare, commisionPercentage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string GenerateCabRef()
    {
        DateTime now = DateTime.Now;
        int m = now.Month + 64;
        string a = ((char)m).ToString();


        //int d = now.Day + 64;
        //string b = ((char)d).ToString();


        var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        var stringChars = new char[4];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        string refno = "LJCR" + DateTime.Now.ToString("yy") + a.ToString() + finalString.ToString();
        Session["refno"] = refno;
        return refno;
    }

    private void GetMail()
    {
        try
        {

            if (txtEMailId.Text != null)
            {
                // downlink.Visible = false;
                string Body = "<html><head><style type='text/css'> </style></head><body>" +
                         "<table cellpadding='0' cellspacing='0' border='0' width='100%'>" +
                         "<tr><td>" +
                      "<table width='900' border='0' cellspacing='0' cellpadding='0'>" +
                      "<tr><td align='left' width='300' height='96' valign='top'>" +
                      "<img src='http://lovejourney.in/Newimages/New_Logo.png' width='300' height='88' border='0' title='Love Journey' />&nbsp;&nbsp; </td>" +
                      "<td align='right'><table width='200' border='0' cellspacing='0' cellpadding='0'>" +
                      "<tr><td width='40' align='left'><img src='http://www.lovejourney.in/images/call.jpg' width='30' height='30' /> </td>" +
                      "<td align='left'><b>(080) 32 56 17 27</b></td></tr>" +
                      "<tr><td width='40' align='left'><img src='http://www.lovejourney.in/images/messenge.jpg' width='30' height='30' /></td>" +
                      "<td align='left'><a href='#'>info@lovejourney.in</a></td></tr></table>" +
                      "</td></tr></table>" +
                     " </td></tr>" +

                     "<tr><td width='900px'>" +
                     "<p>Note : To initiate your journey, please present your itinerary receipt or E-Ticket. " +
                     "Waiting list is not a confirmed ticket. Wait listed passengers are requested to check for their ticket confirmation with our helpline.</p>" +
                     "</td></tr>" +

                     "<tr><td><table cellpadding='0' cellspacing='0' border='1' width='90%'><tr>" +
                          "<td colspan='2'> LoveJourney Reference Number : " + Session["refno"].ToString() + "</td></tr>" +
                      "<tr><td  width='45%'>Travel Date : " + Session["TravelDate"].ToString() + "</td>" +
                         " <td> City :" + txtCity.Text.ToString() + "</td></tr>" +
                       "<tr><td  width='45%'> Coach : " + CarName.Text.ToString() + "</td>" +
                       "<td>pickupTime  : " + DDLPickUpTime.SelectedValue.ToString() + "</td></tr>" +
                    "<tr><td colspan='2'>Pickup Address :" + txtAddress.Text.ToString() + "</td></tr>" +
                         "<tr><td colspan='2'><asp:Label ID='Label5' runat='server' Text='Passenger Details : '></asp:Label></td></tr>" +
                         "<tr><td width='45%'> Name :" + txtName.Text.ToString() + " </td>" +
                             "<td>Contact No    : " + txtMobileNo.Text.ToString() + "</td></tr>" +
                          "<tr><td width='45%'>Status : " + Status.Text.ToString() + "</td>" +
                               "<td>Id Number :" + Session["refno"].ToString() + "</td></tr>" +
                         "<tr><td width='45%'> Booked By: " + txtName.Text.ToString() + "</td> " +
                              "<td>Amount  : " + BasicPrice.Text.ToString() + "</td></tr>" +
                    //"<tr><td colspan='2'>Contact Details  : "+Contact Details+"</td></tr>"+
                    // "</table></td></tr>"+

                            "<tr><td colspan='2'>Cancellation Policy :</td></tr>" +
                             "<tr><td colspan='2'>No cancellation Policy Updated</td></tr>" +
                             "<tr><td colspan='2'><p>Terms & Conditions : </p>" +
                                 "<p>1. Lovejourney.in is ONLY a online ticket booking of buses, flights,hotels and recharge . It does not operate travel services of its own. In order to provide a comprehensive choice of travel operators, departure times and prices to customers, it has tied up with many travel operators." +
                                    "lovejourney.in advices customers to choose travel operators they are aware of and whose service they are comfortable with.</p>" +
                                    "</td></tr></table>";

































                //"<tr><td>Passenger Details</td></tr><br />" +
                //"Name:" + txtName.Text.ToString() + "</tr><br />" + 
                //"Address:" + txtAddress.Text.ToString() + "</tr><br />" +
                //"City:" + txtCity.Text.ToString() + "</tr><br />" +
                //"State:" + DDLState.SelectedValue.ToString() + "</tr><br />" +
                //"ZipCode:" + txtZipCode.Text.ToString() + "</tr><br />" + 
                //"Country:" + txtCountry.Text.ToString() + "</tr><br />" + 
                //"EMailsId:" + txtEMailId.Text.ToString() + "</tr><br />" + 
                //"MobileNo:" + txtMobileNo.Text.ToString() + "</tr><br />" + 
                //"LandMark1:" + txtLandMark.Text.ToString() + "</tr><br />" + 
                //"Refreance No:" + Session["refno"].ToString() + "</tr><br />" + 
                //"Travel Date:" + Session["TravelDate"].ToString() + "</tr>" + 
                //"</div>"+
                //"</table> </body></html>";





                bool res = MailSender.SendEmail(txtEMailId.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", Body);
                // downlink.Visible = true;
                if (res)
                {

                    lblMsg.Text = "Mail has been sent successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    lblMsg.Text = "Failed to send Mail ";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
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


    private void details()
    {


    }
    protected void bnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CarResult.aspx", false);
    }
}