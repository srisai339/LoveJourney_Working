using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Agent_Bookings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }


        this.Page.Title = "LoveJourney - Bus - Bookings"; lblMsg.InnerHtml = "";
        if (!IsPostBack)
        {
            BindBookedTickets(); BindSourcesDests();
            ViewState["SortDirection"] = " ASC";
            ViewState["Data"] = null;
        }
    }

    void BindBookedTickets()
    {
        try
        {
            if (Session["UserID"] != null)
            {
                ClsBAL obj = new ClsBAL();
                DataSet ds = obj.GetAgentBookedTickets(Convert.ToInt32(Session["UserID"].ToString()));
                gvBookings.DataSource = ds;
                gvBookings.DataBind();
                if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
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
                if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
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
                    if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
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
                            //foreach (DataRow item in ObjDataset.Tables[0].Rows)
                            //{
                            //    item["Comment"] = Convert.ToDecimal(item["Comment"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            //    item["TotalWithMarkPrice"] =
                            //        Convert.ToDecimal(
                            //        Convert.ToDecimal(item["Comment"].ToString())
                            //        +
                            //        Convert.ToDecimal(item["TotalFare"].ToString())
                            //        ).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                            //        ;
                            //}
                            gvDetails.DataBind();
                            gvView.DataSource = ObjDataset.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(api);
                            if (api == "Kesineni")
                            {
                               // imgKesineni.Visible = true;
                            }
                            else { 
                                //imgKesineni.Visible = false;
                            }
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

    protected void GetCancellationPolicy(string API)
    {
        try
        {
            ClsBAL objManabusBAL = new ClsBAL();
            //if (travelname.Length >= 5)
            //{
            //    objManabusBAL.api = travelname.Substring(0, 5);
            //}
            //else {
            objManabusBAL.api = API; 
           // }

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
    double markUp = 0;
    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                actualFareTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalFare"));
                commisionFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
                mbFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
                cancellationCharges += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                refundAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                //  markUp += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Comment"));


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

                //Label lblMarkUpTotal = (Label)e.Row.FindControl("lblMarkUpTotal");
                //  lblMarkUpTotal.Text = markUp.ToString();
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
                    Response.Redirect("~/Agent/Bus/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
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
                    Response.Redirect("~/Agent/Bus/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
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
                else
                {
                    lbtnCancel.Visible = false; //radioButtonCancel.Visible = true; 
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
                    if (ObjDataset.Tables[2].Rows.Count > 0)
                    {
                        //ddlOperator.DataSource = ObjDataset.Tables[2];
                        //ddlOperator.DataTextField = "TravelOPName";
                        //ddlOperator.DataBind();
                        //ddlOperator.Items.Insert(0, "ALL");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
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
                if (txtusername.Text != "") { objManabusBAL.fullName = txtusername.Text; }
                if (txtEmailID.Text != "") { objManabusBAL.emailId = txtEmailID.Text; }
                if (txtManabusRefNo.Text != "") { objManabusBAL.manabusRefNo = txtManabusRefNo.Text; }
                // if (ddlOperator.SelectedItem.Text != "ALL") { objManabusBAL.travelName = ddlOperator.SelectedItem.Text; }
                if (txtContact.Text != "") { objManabusBAL.mobileNo = txtContact.Text; }
                if (ddlStatus.SelectedItem.Text != "ALL") { objManabusBAL.status = ddlStatus.SelectedItem.Text; }

                DataSet ObjDataset = (DataSet)objManabusBAL.SearchAgentBookedTickets(Convert.ToInt32(Session["UserID"].ToString()));
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
                        if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
                        ViewState["Data"] = ObjDataset.Tables[0];
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
        ddlSources.SelectedIndex = ddlDestinations.SelectedIndex = ddlStatus.SelectedIndex = 0;
        ddlPageSize.SelectedIndex = 1;
        txtDOJ.Text = txtDateOfIssue.Text = txtName.Text = txtEmailID.Text = txtManabusRefNo.Text = txtContact.Text = "";
        txttodate.Text = "";
        txtfromdate.Text = "";
        txtusername.Text = "";
        BindBookedTickets();
        //gvBookings.Visible = false;
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvBookings);
            gvBookings.Columns[16].Visible = gvBookings.AllowSorting = false;
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
            gvBookings.Columns[16].Visible = gvBookings.AllowSorting = true;
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
}