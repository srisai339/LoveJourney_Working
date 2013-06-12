using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HotelAPILayer;
using BAL;
using System.Data;
using System.IO;
using System.Text;

public partial class Users_Hotel_UserReports : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer; ClsBAL objBAL;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        this.Page.Title = "LoveJourney - Hotel - AgentBookings";

        objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
        objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
        objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
        objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
        objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
        objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;

        lblMsg.InnerHtml = "";

        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    CheckPermission("Hotel Agent Bookings", Session["Role"].ToString());

                    BindBookedTickets();
                    ViewState["SortDirection"] = " ASC";
                    ViewState["Data"] = null;
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

                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }
    }
    DataSet GetAgents()
    {
        try
        {
            ClsBAL objbal = new ClsBAL();
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
    void BindBookedTickets()
    {
        try
        {
            if (Session["UserID"] != null)
            {
                if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
                ViewState["Data"] = null;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                if (ddlPageSize.SelectedIndex != 0)
                { gvBookings.AllowPaging = true; gvBookings.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text.ToString()); }
                else
                { gvBookings.AllowPaging = false; }

                HotelBAL obj = new HotelBAL();

                if (txtfromdate.Text == "") { obj.CheckIn = null; }
                else { obj.CheckIn = Convert.ToDateTime(txtfromdate.Text); }

                if (txttodate.Text == "") { obj.CheckOut = null; }
                else { obj.CheckOut = Convert.ToDateTime(txttodate.Text); }

                if (ddlCity.Value != "line") { obj.HotelCity = ddlCity.Value.ToString(); }

                if (txtEmailID.Text != "") { obj.EmailId = txtEmailID.Text; }

                if (txtreferenceno.Text != "") { obj.ReferenceNo = txtreferenceno.Text; }

                obj.UserId = Convert.ToInt32(Session["UserID"].ToString());

                if (txtName.Text != "") { obj.FirstName = txtName.Text; }

                if (txtContact.Text != "") { obj.MobileNumber = txtContact.Text; }

                if (ddlStatus.SelectedItem.Text != "ALL") { obj.Status = ddlStatus.SelectedItem.Text; }

                DataSet ObjDataset = (DataSet)obj.SearchAllAgentsBookedTicketsUser();
                gvBookings.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                gvBookings.DataSource = ObjDataset;
                gvBookings.DataBind();
                if (gvBookings.Rows.Count > 0) { btnExport.Visible = true; } else { btnExport.Visible = false; }
                ViewState["Data"] = ObjDataset.Tables[0];
            }
            else { Response.Redirect("~/Default.aspx"); }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            ddlCity.SelectedIndex = 0;
            ddlPageSize.SelectedIndex = 1; ddlStatus.SelectedIndex = 0;
            txtDOJ.Text = txtDateOfIssue.Text = txtName.Text = txtEmailID.Text = txtManabusRefNo.Text = txtContact.Text = ""; txttodate.Text = ""; txtfromdate.Text = "";
            txtreferenceno.Text = "";
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvBookings);
            //gvBookings.Columns[16].Visible = 
            gvBookings.AllowSorting = false;
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
            //gvBookings.Columns[16].Visible =
            gvBookings.AllowSorting = true;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
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
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                HotelBAL obj = new HotelBAL();
                obj.ReferenceNo = e.CommandArgument.ToString();
                DataSet dsTicket = obj.GetHotelProvisional();

                pnlViewTicket.Visible = true; pnlSearchResults.Visible = pnlSearch.Visible = false;

                if (dsTicket == null) { lblMsg.InnerHtml = "Invalid Ref No."; return; }
                if (dsTicket.Tables.Count == 0) { lblMsg.InnerHtml = "Invalid Ref No."; return; }
                if (dsTicket.Tables[0].Rows.Count == 0) { lblMsg.InnerHtml = "Invalid Ref No."; return; }
                DataRow drTicketRow = dsTicket.Tables[0].Rows[0];
                lblHotelRefNo.Text = drTicketRow["ReferenceNo"].ToString();
                lblarzoorefno.Text = drTicketRow["BookingRefNo"].ToString();
                lblStatus.Text = drTicketRow["Status"].ToString();
                lblHotelName.Text = drTicketRow["HotelName"].ToString();

                lblAddress.Text = drTicketRow["HotelAddress"].ToString();

                lblHotelCity.Text = drTicketRow["HotelCity"].ToString();
                lblCheckIn.Text = drTicketRow["CheckInDate"].ToString();
                lblCheckOut.Text = drTicketRow["CheckOutDate"].ToString();
                lblRoomType.Text = drTicketRow["RoomType"].ToString();

                lblStar.Text = drTicketRow["HotelStar"].ToString();

                lblNoOfRooms.Text = drTicketRow["NoOfRooms"].ToString();
                lblPaxGreaterThan12.Text = drTicketRow["NoOfAdults"].ToString();
                lblPaxLessThan12.Text = drTicketRow["NoOfChildren"].ToString();

                lblTotalPrice.Text = drTicketRow["HotelTotalFare"].ToString();

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
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
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
                actualFareTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ActualFare"));
                commisionFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
                mbFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MBFare"));
                cancellationCharges += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                refundAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                markUp += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Comment"));


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

                Label lblMarkUpTotal = (Label)e.Row.FindControl("lblMarkUpTotal");
                lblMarkUpTotal.Text = markUp.ToString();
            }
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
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        pnlViewTicket.Visible = false; pnlSearchResults.Visible = pnlSearch.Visible = true;
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
    protected void lbtnMail_Click(object sender, EventArgs e)
    {
        try
        {
            {
                string body = getHTML(pnlTicket);
                bool res = Mailsender.SendEmail(lblEmailId.Text, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMsg.InnerHtml = "Mail has been sent successfully.";
                }
                else
                {
                    lblMsg.InnerHtml = "Failed to send Mail.";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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