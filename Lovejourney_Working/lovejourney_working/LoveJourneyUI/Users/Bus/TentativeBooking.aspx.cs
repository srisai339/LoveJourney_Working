using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_TentativeBooking : System.Web.UI.Page
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
            this.Page.Title = "LoveJourney - Bus - TentativeBooking";
            CheckPermission();
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["ViewUser"] != null )
                {
                    if (ViewState["ViewUser"].ToString() == "1")
                    {
                        BindTentatiives();
                        BindSourcesDests();
                        pnlCusEnquiryReports.Visible = true;

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No Permission to view Tentaive Bookings.Please Contact Administrator for further details...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        pnlCusEnquiryReports.Visible = false;
                    }
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to view Tentaive Bookings.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlCusEnquiryReports.Visible = false;
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to view Tentaive Bookings.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlCusEnquiryReports.Visible = false;
            }
           
        }
    }
    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Tentative Booking";
            ObjDataset = (DataSet)objBAL.GetPerByUser();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = ObjDataset.Tables[0];
                    ViewState["AddUser"] = ObjDataset.Tables[0].Rows[0]["Add"].ToString();
                    ViewState["ViewUser"] = ObjDataset.Tables[0].Rows[0]["View"].ToString();
                    ViewState["DeleteUser"] = ObjDataset.Tables[0].Rows[0]["Delete"].ToString();
                    ViewState["EditUser"] = ObjDataset.Tables[0].Rows[0]["Edit"].ToString();
                    ViewState["PermissionUser"] = ObjDataset.Tables[0].Rows[0]["Permission"].ToString();

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
    protected void BindTentatiives()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetTentativeBooking();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    ViewState["TentativeBookings"] = ObjDataset.Tables[0];
                    GvtentativeBooking.DataSource = ObjDataset.Tables[0];
                    GvtentativeBooking.DataBind();
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
                        ddloperator.DataSource = ObjDataset.Tables[2];
                        ddloperator.DataTextField = "TravelOPName";
                        ddloperator.DataBind();
                        ddloperator.Items.Insert(0, "ALL");
                    }
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            if (txtDOJ.Text == "") { objBAL.dateOFJourney = null; }
            else { objBAL.dateOFJourney = Convert.ToDateTime(txtDOJ.Text); }
            if (ddlSources.SelectedItem.Text != "ALL") { objBAL.sourceName = ddlSources.SelectedItem.Text; }
            if (ddlDestinations.SelectedItem.Text != "ALL") { objBAL.destinationName = ddlDestinations.SelectedItem.Text; }
            if (ddlStatus.SelectedItem.Text != "ALL") { objBAL.status = ddlStatus.SelectedItem.Text; }
            if (txtName.Text != "") { objBAL.fullName = txtName.Text; }
            if (txtEmailID.Text != "") { objBAL.emailId = txtEmailID.Text; }
            if (ddloperator.SelectedItem.Text != "ALL") { objBAL.travelName = ddloperator.SelectedItem.Text; }
            if (txtContact.Text != "") { objBAL.mobileNo = txtContact.Text; }
            ObjDataset = (DataSet)objBAL.GetTentativeBookingsBySearch();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        lbtnXport2Xcel.Enabled = true;

                    }
                    else
                    {
                        lbtnXport2Xcel.Enabled = false;
                    }
                    ViewState["TentativeBookings"] = ObjDataset.Tables[0];
                    GvtentativeBooking.DataSource = ObjDataset.Tables[0];
                    GvtentativeBooking.DataBind();
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
            if (ViewState["TentativeBookings"] != null)
            {
                tdmsg.Visible = false;
                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "ID";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["TentativeBookings"], arr);
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
            GvtentativeBooking.AllowPaging = true;
            if (ViewState["TentativeBookings"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvtentativeBooking.PageSize = 40;
                    GvtentativeBooking.PageIndex = 0;
                    GvtentativeBooking.DataSource = ViewState["TentativeBookings"];
                    GvtentativeBooking.DataBind();

                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvtentativeBooking.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvtentativeBooking.PageIndex = 0;
                    GvtentativeBooking.DataSource = ViewState["TentativeBookings"];
                    GvtentativeBooking.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvtentativeBooking.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvtentativeBooking.PageIndex = 0;
                    GvtentativeBooking.DataSource = ViewState["TentativeBookings"];
                    GvtentativeBooking.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvtentativeBooking.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvtentativeBooking.PageIndex = 0;
                    GvtentativeBooking.DataSource = ViewState["TentativeBookings"];
                    GvtentativeBooking.DataBind();
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
            BindTentatiives();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void GvtentativeBooking_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["TentativeBookings"] as DataTable;
            if (GvtentativeBooking.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    GvtentativeBooking.DataSource = dataview;
                    GvtentativeBooking.DataBind();

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
    protected void GvtentativeBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvtentativeBooking.PageIndex = e.NewPageIndex;
            if (ViewState["TentativeBookings"] != null)
            {
                GvtentativeBooking.DataSource = ViewState["TentativeBookings"];
                GvtentativeBooking.DataBind();
            }
            else
            {
                BindTentatiives();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}