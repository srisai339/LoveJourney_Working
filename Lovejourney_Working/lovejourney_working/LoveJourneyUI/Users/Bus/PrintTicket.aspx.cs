using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusAPILayer;
using BAL;
using System.Text;
using System.IO;
using System.Net;

public partial class Users_PrintTicket : System.Web.UI.Page
{
    IBitlaAPILayer objBitlaAPILayer;
    IKesineniAPILayer objKesineniAPILayer;
    IAbhiBusAPILayer objAbhiBusAPILayer;
    ClsBAL objBAL;
    DataSet ObjDataset;

   


    protected void Page_Load(object sender, EventArgs e)
    {
        objBitlaAPILayer = BitlaFactoryManager.GetBitlaAPILayerObject();
        objBitlaAPILayer.ApiKey = BitlaConstants.API_KEY;
        objBitlaAPILayer.URL = BitlaConstants.URL;

        objKesineniAPILayer = KesineniFactoryManager.GetKesineniAPILayerObject();
        objKesineniAPILayer.LoginId = KesineniConstants.LoginId;
        objKesineniAPILayer.Password = KesineniConstants.Password;

        objAbhiBusAPILayer = AbhiBusFactoryManager.GetAbhiBusAPILayerObject();
        this.Page.Title = "LoveJourney - Bus - PrintTicket";

        if (!IsPostBack)
        {
            if (Session["Role"].ToString()=="Admin")
            {
               CheckPermission("Print Ticket", Session["Role"].ToString());
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
    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            objBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                objBAL.api = travelname.Substring(0, 5);
            }
            else { objBAL.api = travelname; }
            ObjDataset = (DataSet)objBAL.GetCancelPercentageByAPI();
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
     string Route; string SeatNos; string LJRefNo; string PNR; string travelName; string api; string Boardingpoint; string BoardingInfo; string ContactNo;
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {

            objBAL = new ClsBAL();
            objBAL.manabusRefNo = txtMBRefNo.Text;
            ObjDataset = (DataSet)objBAL.GetTicketIdByOnewayManabusRefNo();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                         travelName = ObjDataset.Tables[0].Rows[0]["TravelOPName"].ToString();
                         api = ObjDataset.Tables[0].Rows[0]["APIName"].ToString();

                         Route = ObjDataset.Tables[0].Rows[0]["Route"].ToString();
                         LJRefNo = ObjDataset.Tables[0].Rows[0]["OnewayMBRefNo"].ToString();
                         PNR = ObjDataset.Tables[0].Rows[0]["PNRNumber"].ToString();
                         Boardingpoint = ObjDataset.Tables[0].Rows[0]["BoardingPointName"].ToString();
                         BoardingInfo = ObjDataset.Tables[0].Rows[0]["BoardingInfo"].ToString();
                         ContactNo = ObjDataset.Tables[0].Rows[0]["ContactNo"].ToString();
                         SeatNos = ObjDataset.Tables[0].Rows[0]["SeatNos"].ToString();
                           
                        gvView.DataSource = ObjDataset.Tables[0];
                        gvView.DataBind();
                        GetCancellationPolicy(travelName);
                        if (api == "Kesineni")
                        {
                           
                        }

                        Panel1.Visible = false;
                        pnlViewticket.Visible = true;
                    }
                    else
                    {
                        Label1.Text = "Invalid  Ref No";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Panel1.Visible = true;
                        pnlViewticket.Visible = false;
                    }
                }
                else
                {
                    Label1.Text = "Invalid  Ref No";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Panel1.Visible = true;
                    pnlViewticket.Visible = false;
                }
            }
            else
            {
                Label1.Text = "Invalid  Ref No";
                Label1.ForeColor = System.Drawing.Color.Red;
                Panel1.Visible = true;
                pnlViewticket.Visible = false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
       
      protected void SMS()
    {
        try
        {
            string strUrl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=lovejourney&password=1449423933&sendername=LUJRNY&mobileno=91" + "8897971907" + "&message=www.lovejourney.in";




            //string strUrl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=lovejourney&password=1449423933&sendername=LUJRNY&mobileno=91"+ "8897971907" +"&message=" + " Dear Customer, " + Route + " SeatNos :" + SeatNos + " LJ RefNo : " + LJRefNo + " PNR :" + PNR + " Travels :" +
            //    travelName + " Boarding Point : " + Boardingpoint + " Address :" + BoardingInfo + " www.lovejourney.in";
            HttpWebRequest oReq1 = null;
            HttpWebResponse oRes1 = null;
            StreamReader oStream1 = null;
            oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
            oReq1.Method = "GET";
            oReq1.Timeout = 10000;
            oRes1 = (HttpWebResponse)oReq1.GetResponse();
            oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            string strMessage1 = oStream1.ReadToEnd().ToString();

        }
        catch (Exception)
        {

            //  throw;
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
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (lblEmailID != null)
            {
                string body = getHTML(pnlmail);
                bool res = Mailsender.SendEmail(lblEmailID.Text, "", "", "Ticket Details", body);
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
                            string[] details = item.Replace('-', ' ').Split(' ');
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
}