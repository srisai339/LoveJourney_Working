using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;
using System.IO;

public partial class Users_OfficePickUp : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - Bus - OfficePickUp";
            CheckPermission();
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["View"].ToString() == "1")
                {
                    GetOfficePickups();
                    BindSourcesDests();
                    MVOficePickup.ActiveViewIndex = 0;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to view Office Pickups.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    MVOficePickup.Visible = true;
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to view Office Pickups.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                MVOficePickup.Visible = true;
            }

        }
    }
    public void GetOfficePickups()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.deliveryType = "Office Pickup";
            ObjDataset = (DataSet)objBAL.GetHomeOfficePickups();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ViewState["OfficePickups"] = ObjDataset.Tables[0];

                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = true;
                    }
                    else
                    {
                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = false;
                    }
                    Gvofficepckup.DataSource = ObjDataset.Tables[0];
                    Gvofficepckup.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }

    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Home Delivery Ticket";
            ObjDataset = (DataSet)objBAL.GetPerByUser();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = ObjDataset.Tables[0];
                    // ViewState["AddUser"] = ObjDataset.Tables[0].Rows[0]["Add"].ToString();
                    ViewState["View"] = ObjDataset.Tables[0].Rows[0]["View"].ToString();
                    // ViewState["DeleteUser"] = ObjDataset.Tables[0].Rows[0]["Delete"].ToString();
                    // ViewState["EditUser"] = ObjDataset.Tables[0].Rows[0]["Edit"].ToString();
                    // ViewState["PermissionUser"] = ObjDataset.Tables[0].Rows[0]["Permission"].ToString();

                }
                else
                {
                    ViewState["UserPermissions"] = null;
                }
            }
            else
            {
                ViewState["UserPermissions"] = null;
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
                        ddllocation.DataSource = ObjDataset.Tables[0];
                        ddllocation.DataTextField = "SourceName";
                        ddllocation.DataBind();
                        ddllocation.Items.Insert(0, "ALL");

                    }

                }
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
            Gvofficepckup.AllowPaging = true;
            if (ViewState["OfficePickups"] != null)
            {


                if (ddlPageSize.SelectedValue == "0")
                {
                    Gvofficepckup.PageSize = 40;
                    Gvofficepckup.PageIndex = 0;
                    Gvofficepckup.DataSource = ViewState["OfficePickups"];
                    Gvofficepckup.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    Gvofficepckup.PageSize = 10;
                    Gvofficepckup.PageIndex = 0;
                    Gvofficepckup.DataSource = ViewState["OfficePickups"];
                    Gvofficepckup.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    Gvofficepckup.PageSize = 20;
                    Gvofficepckup.PageIndex = 0;
                    Gvofficepckup.DataSource = ViewState["OfficePickups"];
                    Gvofficepckup.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    Gvofficepckup.PageSize = 30;
                    Gvofficepckup.PageIndex = 0;
                    Gvofficepckup.DataSource = ViewState["OfficePickupsOfficePickups"];
                    Gvofficepckup.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["OfficePickups"] != null)
            {
                tdmsg.Visible = false;
                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "Status";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["OfficePickups"], arr);
                GridViewExportUtil.ExportToExcel("OfficePickups.xls", dtExport, true);
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

        //Export the grid data to excel sheet
        //Export("Users.xls", this.GvUsers);
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.deliveryType = "Office Pickup";
            if (txtFrom.Text == "")
            {
                objBAL.from = null;
            }
            else
            {
                objBAL.from = Convert.ToDateTime(txtFrom.Text);
            }
            if (txtto.Text == "")
            {
                objBAL.to = null;
            }
            else
            {
                objBAL.to = Convert.ToDateTime(txtto.Text);
            }
            if (ddlDatefilter.SelectedItem.Text == "ALL")
            {
                objBAL.dateFilter = null;
            }
            else
            {
                objBAL.dateFilter = ddlDatefilter.SelectedItem.Text;
            }
            if (ddllocation.SelectedItem.Text == "ALL")
            {
                objBAL.sourceName = null;
            }
            else
            {
                objBAL.sourceName = ddllocation.SelectedItem.Text;
            }
            if (ddlOfficeDeliveryStatus.SelectedItem.Text == "ALL")
            {
                objBAL.status = null;
            }
            else
            {

                objBAL.status = ddlOfficeDeliveryStatus.SelectedItem.Text;

            }

            ObjDataset = (DataSet)objBAL.GetHomeOfficePickupsBySearch();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = true;
                    }
                    else
                    {
                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = false;
                    }
                    Gvofficepckup.DataSource = ObjDataset.Tables[0];
                    Gvofficepckup.DataBind();
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
    protected void Gvofficepckup_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["OfficePickups"] as DataTable;
            if (Gvofficepckup.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    Gvofficepckup.DataSource = dataview;
                    Gvofficepckup.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Gvofficepckup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            Gvofficepckup.PageIndex = e.NewPageIndex;
            if (ViewState["OfficePickups"] != null)
            {
                Gvofficepckup.DataSource = ViewState["OfficePickups"];
                Gvofficepckup.DataBind();
            }
            else
            {
                GetOfficePickups();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string seatswithname = string.Empty; ;
            //    Label lblNoOFSeats = (Label)e.Row.FindControl("lblNoOfSeats");
              //  Label lblBookedBy = (Label)e.Row.FindControl("lblBookedBy");
             //   Label lblAmount = (Label)e.Row.FindControl("lblAmount");
              //  Label lblDeliverycharges = (Label)e.Row.FindControl("lblDeliverycharges");
               // Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                //string[] seats = lblNoOFSeats.Text.Split(',');
                //foreach (string seat in seats)
                //{
                //    seatswithname += seat + " - " + lblBookedBy.Text + "<br/>";
                //}
                //lblNoOFSeats.Text = seatswithname;
              //  double Fare = Convert.ToDouble(lblAmount.Text);
              ////  double deliverycharges = Convert.ToDouble(lblDeliverycharges.Text);
              //  double totalFare = Fare + deliverycharges;
             //   lblTotal.Text = Convert.ToString(totalFare);
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
    protected void Gvofficepckup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                if (ViewState["OfficePickups"] != null)
                {
                    DataTable dt = (DataTable)ViewState["OfficePickups"];
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "BookingId='" + Convert.ToInt32(e.CommandArgument) + "'";
                    if (dv.Count > 0)
                    {
                        string travelName = dv[0]["TravelOPName"].ToString();
                        string api = dv[0]["APIName"].ToString();
                        gvView.DataSource = dv;
                        gvView.DataBind();
                        gvDetails.DataSource = dv;
                        gvDetails.DataBind();
                        GetCancellationPolicy(travelName);
                        MVOficePickup.ActiveViewIndex = 1;
                    }
                }
                else
                {
                    //GetOfficePickups();
                    // Gvofficepckup_RowCommand(sender, e);
                }
            }
            if (e.CommandName == "PayInfoUpdate")
            {
                txtdeliveredBy.Text = txtMnyCollectedBY.Text = "";
                lblID.Text = Convert.ToString(e.CommandArgument);
                MPEUpdate.Show();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Gvofficepckup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblCSEPerson = (Label)e.Row.FindControl("lblCSEPerson");
                if (lblCSEPerson.Text == "")
                {
                    lblCSEPerson.Text = "Customer";
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void lbtnback_Click(object sender, EventArgs e)
    {
        MVOficePickup.ActiveViewIndex = 0;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MPEUpdate.Hide();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.bookingId = Convert.ToInt32(lblID.Text);
            objBAL.status = ddlDeliveryStatus.SelectedItem.Text;
            objBAL.deliveredBy = txtdeliveredBy.Text;
            objBAL.amountrecievedBy = txtMnyCollectedBY.Text;
            if (objBAL.UpdateHMDeliveryStatus())
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#6CC417;", "");
                lblMainMsg.Text = "Pay Info Updated Successfully...";
                lblMainMsg.ForeColor = System.Drawing.Color.Green;
                GetOfficePickups();
                MVOficePickup.ActiveViewIndex = 0;
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   OOPs Falied to update...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;

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
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            string[] arr = new string[1];
            arr[0] = "UserName";

            DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["OfficePickups"], arr);
            GridViewExportUtil.ExportToExcel("OfficePickups.xls", dtExport, true);
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
}