using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class Users_CustomerEnquiry : System.Web.UI.Page
{

    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    DataSet ds = new DataSet();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        this.Page.Title = "LoveJourney - Bus - Bookings";

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("Bookings", Session["Role"].ToString());
                BindSourcesDests();
                btnExport.Visible = false;
                ds = GetAgents();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlagent1.DataSource = ds;
                        ddlagent1.DataTextField = "Username";
                        ddlagent1.DataValueField = "ID";
                        ddlagent1.DataBind();

                        ddlagent1.Items.Insert(0, "-Please Select-");
                    }

                }
                btnSearch_Click(sender, e);
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
          ClsBAL  objbal = new ClsBAL();
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
            MVCusEnquiry.Visible = true;
            MVCusEnquiry.ActiveViewIndex = 0;
            tdmsg.Visible = false;
            tdmsg.Style.Add("background-color:#E77471;", "");
            lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                MVCusEnquiry.Visible = false;

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
                            MVCusEnquiry.Visible = true;
                            MVCusEnquiry.ActiveViewIndex = 0;
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


    protected void BindSourcesDests()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetSourcesDests();
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

            throw ex;
        }


    }

    protected void BindCustomerEnquries()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetBookingDetails();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    ViewState["CusEnquiries"] = ObjDataset.Tables[0];
                    GvCusEnquiry.DataSource = ObjDataset.Tables[0];
                    GvCusEnquiry.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void GvCusEnquiry_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["CusEnquiries"] as DataTable;
            MVCusEnquiry.Visible = true;
            MVCusEnquiry.ActiveViewIndex = 0;
            if (GvCusEnquiry.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;
                    MVCusEnquiry.Visible = true;
                    MVCusEnquiry.ActiveViewIndex = 0;
                    GvCusEnquiry.DataSource = dataview;
                    GvCusEnquiry.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    private string GetSortDirection(string column)
    {
        string sortDirection = "ASC";
        string sortExpression = ViewState["SortExpression"] as string;

        if (sortExpression != null)
        {
            if (sortExpression == column)
            {
                string lastDirection = ViewState["SortDirection"] as string;
                if ((lastDirection != null) && (lastDirection == "ASC")) sortDirection = "DESC";
            }
        }

        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;

        return sortDirection;
    }

    protected void GvCusEnquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvCusEnquiry.PageIndex = e.NewPageIndex;
            if (ViewState["CusEnquiries"] != null)
            {
                GvCusEnquiry.DataSource = ViewState["CusEnquiries"];
                GvCusEnquiry.DataBind();
                MVCusEnquiry.ActiveViewIndex = 0;
            }
            else
            {
                BindCustomerEnquries();
                MVCusEnquiry.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    int AgentId;
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlagent.Text != "")
            {
                ListItem value = ddlagent1.Items.FindByText(ddlagent.Text.ToString());
                if (value != null)
                {
                    ddlagent1.SelectedItem.Value = value.Value;
                    AgentId = Convert.ToInt32(ddlagent1.SelectedValue);
                }
                else
                {
                    AgentId = -1;
                }

            }

            objBAL = new ClsBAL();
            if (txtfromdate.Text == "") { objBAL.dateOFJourney = null; }
            else { objBAL.dateOFJourney = Convert.ToDateTime(txtfromdate.Text); }
            if (txttodate.Text == "") { objBAL.dateOFBooking = null; }
            else { objBAL.dateOFBooking = Convert.ToDateTime(txttodate.Text); }
            if (ddlSources.SelectedItem.Text != "ALL") { objBAL.sourceName = ddlSources.SelectedItem.Text; }
            if (ddlDestinations.SelectedItem.Text != "ALL") { objBAL.destinationName = ddlDestinations.SelectedItem.Text; }
            if (ddlagent.Text != "") { objBAL.fullName = ddlagent.Text; }
            if (txtEmailID.Text != "") { objBAL.emailId = txtEmailID.Text; }
            if (txtManabusRefNo.Text != "") { objBAL.manabusRefNo = txtManabusRefNo.Text; }
           // if (ddlagent1.SelectedItem.Text != "-Please Select-") { objBAL.travelName = ddlagent1.SelectedItem.Text; }
            if (txtContact.Text != "") { objBAL.mobileNo = txtContact.Text; }
            if (ddlStatus.SelectedItem.Text != "ALL") { objBAL.status = ddlStatus.SelectedItem.Text; }
            if (txtrefeenceno.Text != "") { objBAL.manabusRefNo = txtrefeenceno.Text.Trim(); } else { objBAL.manabusRefNo = null; }

            ObjDataset = (DataSet)objBAL.GetCusEnquiryBySearch();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ddlPageSize.Enabled = true;
                        lbtnXport2Xcel.Enabled = true;
                       // ImageButton3.Visible = true;
                        btnExport.Visible = true;
                    }
                    else
                    {
                        lbtnXport2Xcel.Enabled = false;
                    }
                    ViewState["CusEnq"] = ObjDataset.Tables[0];
                    ViewState["CusEnquiries"] = ObjDataset.Tables[0];
                    GvCusEnquiry.DataSource = ObjDataset.Tables[0];
                    GvCusEnquiry.DataBind();

                }
            }


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void lbtnXport2Xcel_Click1(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["CusEnquiries"] != null)
            {
                tdmsg.Visible = false;
                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "PNRNumber";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["CusEnquiries"], arr);
                GridViewExportUtil.ExportToExcel("CustomerEnquiries.xls", dtExport, true);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvCusEnquiry.AllowPaging = true;
            if (ViewState["CusEnquiries"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvCusEnquiry.PageSize = 20;
                    GvCusEnquiry.PageIndex = 0;
                    GvCusEnquiry.DataSource = ViewState["CusEnquiries"];
                    GvCusEnquiry.DataBind();
                   // BindCustomerEnquries();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvCusEnquiry.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusEnquiry.PageIndex = 0;
                    GvCusEnquiry.DataSource = ViewState["CusEnquiries"];
                    GvCusEnquiry.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvCusEnquiry.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusEnquiry.PageIndex = 0;
                    GvCusEnquiry.DataSource = ViewState["CusEnquiries"];
                    GvCusEnquiry.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvCusEnquiry.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusEnquiry.PageIndex = 0;
                    GvCusEnquiry.DataSource = ViewState["CusEnquiries"];
                    GvCusEnquiry.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            BindCustomerEnquries();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    double actualfare;
    protected void GvCusEnquiry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalFare"));
                Label lblCSEPerson = (Label)e.Row.FindControl("lblCSEPerson");
                if (lblCSEPerson.Text == "")
                {
                   // lblCSEPerson.Text = "Customer";
                }
                Label lblBStatus = (Label)e.Row.FindControl("lblBStatus");
                if (lblBStatus != null)
                {
                    if (lblBStatus.Text == "Booked")
                    {
                        lblBStatus.Text = "Confirmed";
                        lblBStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (lblBStatus.Text == "Cancelled")
                    {

                        lblBStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalFare1 = (Label)e.Row.FindControl("lblTotalFare1");
                lblTotalFare1.Text = actualfare.ToString("####0.00");
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

            throw ex;
        }
    }
    protected void GetCancellationPolicy(string travelname)
    {
        try
        {

            ClsBAL ObjManbusBAL = new ClsBAL();
            ObjManbusBAL.api =Convert.ToString(travelname);
            DataSet ds = (DataSet)ObjManbusBAL.GetCancelPercentageByAPI();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCancellationDetails.DataSource = ds.Tables[0];
                    gvCancellationDetails.DataBind();
                }
                else { gvCancellationDetails.DataSource = null; gvCancellationDetails.DataBind(); }
            }
            else { gvCancellationDetails.DataSource = null; gvCancellationDetails.DataBind(); }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

            if (ds != null)
            {
                ds = null;
            }

        }

    }
    protected void GvCusEnquiry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                objBAL = new ClsBAL();
                objBAL.bookingId = Convert.ToInt32(e.CommandArgument);
                ObjDataset = (DataSet)objBAL.GetCusEnquiryByID();
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
                           // gvDetails.DataSource = ObjDataset.Tables[0];
                            //gvDetails.DataBind();
                            gvView.DataSource = ObjDataset.Tables[0];
                            gvView.DataBind();
                            GetCancellationPolicy(api);
                           
                            MVCusEnquiry.ActiveViewIndex = 1;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            MVCusEnquiry.ActiveViewIndex = 1;
            if (ObjDataset != null)
            {
                ObjDataset = null;
            }

        }
    }

    protected void lbtnback_Click(object sender, EventArgs e)
    {
        try
        {
            MVCusEnquiry.ActiveViewIndex = 0;
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
                txtEmailTo.Text = lblEmailID.Text.Trim().ToString();
                MPEMail.Show();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnCancelEmail_Click(object sender, EventArgs e)
    {
        try
        {
            MPEMail.Hide();
        }
        catch (Exception ex)
        {

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
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#6CC417;", "");
                lblMainMsg.Text = "Mail has been sent successfully";
                lblMainMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "Failed to send Mail ";
                lblMainMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {

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
                    Response.Redirect("~/Users/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
                }
                else if (lblTicketStatus.Text == "Cancelled")
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already Cancelled this Ticket";
                    lblMainMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
        catch (Exception ex)
        {

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

            throw ex;
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
                    Response.Redirect("~/Users/CancelTicket.aspx?RefNo=" + lblManabusRefNo.Text + "&EmID=" + lblEmailID.Text, false);
                }
                else if (lblTicketStatus.Text == "Cancelled")
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already Cancelled this Ticket";
                    lblMainMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(GvCusEnquiry);
            GvCusEnquiry.Columns[12].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            GvCusEnquiry.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(GvCusEnquiry);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
            GvCusEnquiry.Columns[12].Visible = true;
        }
        catch (Exception ex)
        {
           // lblMsg.InnerHtml = ex.Message;
            throw;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtfromdate.Text = "";
        txttodate.Text = "";
        ddlagent.Text = "";
        txtrefeenceno.Text = "";
    }
}