using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;

public partial class Users_AgentReports : System.Web.UI.Page
{
    DataSet ds=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.InnerHtml = ""; lblMainMsg.InnerHtml = "";
        this.Page.Title = "LoveJourney - Bus - AgentBookings";
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("Agent Bookings", Session["Role"].ToString());
                BindBookedTickets(); BindSourcesDests();
                ViewState["SortDirection"] = " ASC";
                ViewState["Data"] = null;

                ds = GetAgents();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlOperator.DataSource = ds;
                        ddlOperator.DataTextField = "Username";
                        ddlOperator.DataValueField = "ID";
                        ddlOperator.DataBind();

                        ddlOperator.Items.Insert(0, "-Please Select-");
                    }
                    btnSearch_Click(sender,e);

                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    DataSet GetAgents()
    {
        try
        {
         ClsBAL   objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
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
    void BindBookedTickets()
    {
        try
        {
            if (Session["UserID"] != null)
            {
                ClsBAL obj = new ClsBAL();
                DataSet ds = obj.GetAgentBookedTicketsForAdmin(null);
                gvBookings.DataSource = ds;
                gvBookings.DataBind();
                ViewState["Data"] = ds.Tables[0];
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message; throw;
        }
    }
    protected void gvBookings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBookings.PageIndex = e.NewPageIndex;
            if (ViewState["Data"] != null)
            {
                DataTable ds = (DataTable)ViewState["Data"];
                gvBookings.DataSource = ds;
                gvBookings.DataBind();
            }
            else { BindBookedTickets(); }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message; throw;
        }
    }
    protected void gvBookings_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                string strExpression = e.SortExpression;
                string strDirection = ViewState["SortDirection"].ToString();
                if (ViewState["Data"] != null)
                {
                    DataTable ds = (DataTable)ViewState["Data"];
                    DataTable dt = ds;
                    DataView dv = new DataView(dt);
                    dv.Sort = strExpression + strDirection;
                    gvBookings.DataSource = dv;
                    gvBookings.DataBind();
                    if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }
                }
                else { BindBookedTickets(); }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message; throw;
        }
    }
    protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                ClsBAL objManabusBAL = new ClsBAL();
                objManabusBAL.bookingId = Convert.ToInt32(e.CommandArgument);
                DataSet ObjDataset = (DataSet)objManabusBAL.GetCusEnquiryByID();
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows.Count == 1)
                        {
                            string travelName = ObjDataset.Tables[0].Rows[0]["TravelOPName"].ToString();
                            Label lbl = new Label();
                            lbl.Text = travelName.ToString();
                            string api = ObjDataset.Tables[0].Rows[0]["APIName"].ToString();
                            gvDetails.DataSource = ObjDataset.Tables[0];
                            foreach (DataRow item in ObjDataset.Tables[0].Rows)
                            {
                                item["Comment"] = Convert.ToDecimal(item["Comment"].ToString()).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                                item["TotalWithMarkPrice"] =
                                    Convert.ToDecimal(
                                    Convert.ToDecimal(item["Comment"].ToString())
                                    +
                                    Convert.ToDecimal(item["TotalFare"].ToString())
                                    ).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                                    ;
                            }
                            gvDetails.DataBind();
                            gvView.DataSource = ObjDataset.Tables[0];

                            gvView.DataBind();
                            GetCancellationPolicy(lbl.Text.ToString());
                            if (api == "Kesineni")
                            {
                               
                            }
                            else { }
                            divTicketDetails.Visible = true;
                            divBookedReport.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message; throw;
        }
    }
    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                objManabusBAL.api = travelname.Substring(0, 5);
            }
            else { objManabusBAL.api = travelname; }

            DataSet ObjDataset = (DataSet)objManabusBAL.GetCancelPercentageByAPI();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    gvCancellationDetails.DataSource = ObjDataset.Tables[0];
                    gvCancellationDetails.DataBind();
                }
                else { gvCancellationDetails.DataSource = null; gvCancellationDetails.DataBind(); }
            }
            else { gvCancellationDetails.DataSource = null; gvCancellationDetails.DataBind(); }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    double actualFareTotal = 0;
    double commisionFare = 0;
    double mbFare = 0;
    double cancellationCharges = 0;
    double refundAmount = 0;
    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                actualFareTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ActualFare"));
                commisionFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
                mbFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
                cancellationCharges += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                refundAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));

                Label lblCBStatus = (Label)e.Row.FindControl("lblCBStatus");
                if (lblCBStatus.Text == "Cancelled") { lblCBStatus.ForeColor = System.Drawing.Color.Red; }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbllblActualFareTotal = (Label)e.Row.FindControl("lblActualFareTotal");
                lbllblActualFareTotal.Text = actualFareTotal.ToString("####0.00");

                Label lblCommisionFareTotal = (Label)e.Row.FindControl("lblCommisionFareTotal");
                lblCommisionFareTotal.Text = commisionFare.ToString();

                Label lblMBFareTotal = (Label)e.Row.FindControl("lblMBFareTotal");
                lblMBFareTotal.Text = mbFare.ToString();

                Label lblCancellationChargesTotal = (Label)e.Row.FindControl("lblCancellationChargesTotal");
                lblCancellationChargesTotal.Text = cancellationCharges.ToString();

                Label lblRefundAmountTotal = (Label)e.Row.FindControl("lblRefundAmountTotal");
                lblRefundAmountTotal.Text = refundAmount.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message; throw;
        }
    }
    protected void radioButtonCancel_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblManabusRefNo = (Label)gvView.Rows[0].FindControl("lblManabusRefNo");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            Label lblTicketStatus = (Label)gvView.Rows[0].FindControl("lblTicketStatus");
            if (lblEmailID != null && lblManabusRefNo != null && lblTicketStatus != null)
            {
                if (lblTicketStatus.Text == "Booked")
                {
                    Response.Redirect("~/Agent/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
                }
                else if (lblTicketStatus.Text == "Cancelled")
                {
                    lblMsg.InnerHtml = "Already Cancelled this Ticket";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblManabusRefNo = (Label)gvView.Rows[0].FindControl("lblManabusRefNo");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            Label lblTicketStatus = (Label)gvView.Rows[0].FindControl("lblTicketStatus");
            if (lblEmailID != null && lblManabusRefNo != null && lblTicketStatus != null)
            {
                if (lblTicketStatus.Text == "Booked")
                {
                    Response.Redirect("~/Agent/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
                }
                else if (lblTicketStatus.Text == "Cancelled")
                {
                    lblMsg.InnerHtml = "Already Cancelled this Ticket";
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void radioButtonMail_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            Radio1.Checked = false; Radio2.Checked = false;
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (lblEmailID != null)
            {
                txtEmailTo.Text = lblEmailID.Text.Trim().ToString();
                MPEMail.Show();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (lblEmailID != null)
            {
                txtEmailTo.Text = lblEmailID.Text.Trim().ToString();
                MPEMail.Show();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void lbtnMaild_Command(object sender, CommandEventArgs e)
    {

    }
    protected void lbtnback_Click(object sender, EventArgs e)
    {
        divTicketDetails.Visible = false;
        divBookedReport.Visible = true;
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
                            // string[] details = item.Replace('-', ' ').Split(' ');
                            string[] details = item.Split('-');
                            if (details.Length > 0)
                            {
                                finalseats += "<tr><td width='100px' align='Center'>";
                                finalseats += details[0] + "</td>";
                                //string[] details123 = details[2].Split(' ');
                                //if (details123.Length > 1)
                                //{
                                //    finalseats += "<td width='100px' align='Center' ><p> " + details[1]+" " + details[2].Split(' ')[0] + " " + details[2].Split(' ')[1] + "</p>";
                                //}
                                //else
                                //{
                                finalseats += "<td width='100px' align='Center' ><p> " + details[1] + " " + details[2] + "</p>";
                                //}                               
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
                Label lblStatus = (Label)e.Row.FindControl("lblTicketStatus");
                if (lblStatus.Text == "Cancelled")
                {
                    lbtnCancel.Visible = false; //radioButtonCancel.Visible = false;
                    Panel pnlCancellationDetails = (Panel)e.Row.FindControl("pnlCancellationDetails");
                    pnlCancellationDetails.Visible = true;
                    Label lblCancelledBY = (Label)pnlCancellationDetails.FindControl("lblCancelledBY");
                    if (lblCancelledBY.Text == "")
                    {
                        lblCancelledBY.Text = "Online";
                    }
                }
                else { lbtnCancel.Visible = false; //radioButtonCancel.Visible = true;
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {
        try
        {
            string body = getHTML(pnlmail);
            bool res = Mailsender.SendEmail(txtEmailTo.Text, "", "", "Ticket Details", body);
            if (res)
            {
                lblMsg.InnerHtml = "Mail has been sent successfully";
            }
            else
            {
                lblMsg.InnerHtml = "Failed to send Mail";
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
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
    protected void btnCancelEmail_Click(object sender, EventArgs e)
    {
        try
        {
            MPEMail.Hide();
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    protected void BindSourcesDests()
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            DataSet ObjDataset = (DataSet)objManabusBAL.GetSourcesDests();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ddlSources.DataSource = ObjDataset.Tables[0];
                        ddlSources.DataTextField = "SourceName";
                        ddlSources.DataBind();
                        ddlSources.Items.Insert(0, "ALL");
                    }
                    if (ObjDataset.Tables[1].Rows.Count > 0)
                    {
                        ddlDestinations.DataSource = ObjDataset.Tables[1];
                        ddlDestinations.DataTextField = "DestinationName";
                        ddlDestinations.DataBind();
                        ddlDestinations.Items.Insert(0, "ALL");
                    }
                    //if (ObjDataset.Tables[2].Rows.Count > 0)
                    //{
                    //    ddlOperator.DataSource = ObjDataset.Tables[2];
                    //    ddlOperator.DataTextField = "TravelOPName";
                    //    ddlOperator.DataBind();
                    //    ddlOperator.Items.Insert(0, "ALL");
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    int AgentId;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (ddlPageSize.SelectedIndex != 0)
            { gvBookings.AllowPaging = true; gvBookings.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text.ToString()); }
            else
            { gvBookings.AllowPaging = false; }

            if (Session["UserID"] != null)
            {
                ClsBAL objManabusBAL = new ClsBAL();
                if (txtfromdate.Text == "") { objManabusBAL.dateOFJourney = null; }
                else { objManabusBAL.dateOFJourney = Convert.ToDateTime(txtfromdate.Text); }
                if (txttodate.Text == "") { objManabusBAL.dateOFBooking = null; }
                else { objManabusBAL.dateOFBooking = Convert.ToDateTime(txttodate.Text); }
                if (ddlSources.SelectedItem.Text != "ALL") { objManabusBAL.sourceName = ddlSources.SelectedItem.Text; }
                if (ddlDestinations.SelectedItem.Text != "ALL") { objManabusBAL.destinationName = ddlDestinations.SelectedItem.Text; }
                if (txtName.Text != "") { objManabusBAL.fullName = txtName.Text.Trim(); }
                if (txtEmailID.Text != "") { objManabusBAL.emailId = txtEmailID.Text; }
                if (txtManabusRefNo.Text != "") { objManabusBAL.manabusRefNo = txtManabusRefNo.Text; }
               // if (ddlOperator.SelectedItem.Text != "-Please Select-") { objManabusBAL.travelName = ddlOperator.SelectedItem.Text; }
                if (txtContact.Text != "") { objManabusBAL.mobileNo = txtContact.Text; }
                if (ddlStatus.SelectedItem.Text != "ALL") { objManabusBAL.status = ddlStatus.SelectedItem.Text; }
                if (txtName.Text != "")
                {
                    ListItem value = ddlOperator.Items.FindByText(txtName.Text.ToString());
                    if (value != null)
                    {
                        ddlOperator.SelectedItem.Value = value.Value;
                        AgentId = Convert.ToInt32(ddlOperator.SelectedValue);
                    }
                    else
                    {
                         AgentId = -1;
                    }

                }
                DataSet ObjDataset = (DataSet)objManabusBAL.SearchAgentBookedTicketsForAdmin(AgentId);
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows.Count > 0)
                        {
                            //ddlPageSize.Enabled = true;
                            //lbtnXport2Xcel.Enabled = true;
                            //ImageButton3.Visible = true;
                        }
                        else
                        {
                            //lbtnXport2Xcel.Enabled = false;
                        }
                        gvBookings.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                        gvBookings.DataSource = ObjDataset.Tables[0];
                        gvBookings.DataBind();
                        ViewState["Data"] = ObjDataset.Tables[0];
                    }
                    else
                    {
                        gvBookings.DataSource = ObjDataset;
                        gvBookings.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlSources.SelectedIndex = ddlDestinations.SelectedIndex = ddlOperator.SelectedIndex = ddlStatus.SelectedIndex = 0;
        ddlPageSize.SelectedIndex = 1;
        txtDOJ.Text = txtDateOfIssue.Text = txtName.Text = txtEmailID.Text = txtManabusRefNo.Text = txtContact.Text = ""; txttodate.Text = ""; txtfromdate.Text = "";
        BindBookedTickets();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvBookings);
            gvBookings.Columns[17].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvBookings.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvBookings);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
            gvBookings.Columns[17].Visible = true;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    private void ChangeControlsToValue(Control gridView)
    {
        Literal literal = new Literal();
        for (int i = 0; i < gridView.Controls.Count; i++)
        {
            if (gridView.Controls[i].GetType() == typeof(Button))
            {
                literal.Text = (gridView.Controls[i] as Button).Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(DropDownList))
            {
                literal.Text = (gridView.Controls[i] as DropDownList).SelectedItem.Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(CheckBox))
            {
                literal.Text = (gridView.Controls[i] as CheckBox).Checked ? "True" : "False";
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            if (gridView.Controls[i].HasControls())
            {
                ChangeControlsToValue(gridView.Controls[i]);
            }
        }
    }
    protected void btnExportTOWord_Click(object sender, EventArgs e)
    {
        try
        {
            pnlmail.Visible = true;
            // BindLabelData();
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Ticket.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlmail.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing


        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAgentNames(string prefixText)
    {
        try
        {


            DataSet ds = new DataSet();

            ClsBAL objBal = new ClsBAL();
            ds = objBal.GetAgents();

            string filteringquery = "Username LIKE'" + prefixText + "%'";
            //Select always return array,thats why we store it into array of Datarow
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            //create new table
            DataTable dtNew = new DataTable();
            //create a clone of datatable dt and store it into new datatable
            dtNew = ds.Tables[0].Clone();
            //fetching all filtered rows add add into new datatable
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }
            //return dtAirportCodes;

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["Username"].ToString().Trim());
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
}