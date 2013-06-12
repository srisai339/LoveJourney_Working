using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_CustomerRequest : System.Web.UI.Page
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
            this.Page.Title = "LoveJourney - CustomerRequest";
            CheckPermission();
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["View"].ToString() == "1")
                {
                    BindCusRequests();
                    pnlCusRequestReports.Visible = true;

                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to view Customer Requests.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlCusRequestReports.Visible = false;
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to view Customer Requests.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlCusRequestReports.Visible = false;
            }
        }
    }

    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Customer Request";
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

    protected void BindCusRequests()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetCusRequests();
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
                    ViewState["CusRequests"] = ObjDataset.Tables[0];
                    GvCusRequests.DataSource = ObjDataset.Tables[0];
                    GvCusRequests.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GvCusRequests_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["CusRequests"] as DataTable;
            if (GvCusRequests.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    GvCusRequests.DataSource = dataview;
                    GvCusRequests.DataBind();

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

    protected void GvCusRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvCusRequests.PageIndex = e.NewPageIndex;
            if (ViewState["CusRequests"] != null)
            {
                GvCusRequests.DataSource = ViewState["Users"];
                GvCusRequests.DataBind();
            }
            else
            {
                BindCusRequests();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();

            if (txtTravelFrom.Text == "") { objBAL.from = null; }
            else { objBAL.from = Convert.ToDateTime(txtTravelFrom.Text); }
            if (txtTravelTo.Text == "") { objBAL.to = null; }
            else { objBAL.to = Convert.ToDateTime(txtTravelTo.Text); }
            if (txtRequestFrom.Text == "") { objBAL.requestfrom = null; }
            else { objBAL.requestfrom = Convert.ToDateTime(txtRequestFrom.Text); }
            if (txtRequestTo.Text == "") { objBAL.requestto = null; }
            else { objBAL.requestto = Convert.ToDateTime(txtRequestTo.Text); }

            ObjDataset = (DataSet)objBAL.GetCusRequestsBySearch();
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
                    GvCusRequests.DataSource = ObjDataset.Tables[0];
                    GvCusRequests.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GvCusRequests_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lbtnXport2Xcel_Click1(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["CusRequests"] != null)
            {
                tdmsg.Visible = false;
                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "Status";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["CusRequests"], arr);
                GridViewExportUtil.ExportToExcel("CustomerRequests.xls", dtExport, true);
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
            GvCusRequests.AllowPaging = true;
            if (ViewState["CusRequests"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvCusRequests.PageSize = 40;
                    GvCusRequests.PageIndex = 0;
                    GvCusRequests.DataSource = ViewState["CusRequests"];
                    GvCusRequests.DataBind();
                   // BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvCusRequests.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusRequests.PageIndex = 0;
                    GvCusRequests.DataSource = ViewState["CusRequests"];
                    GvCusRequests.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvCusRequests.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusRequests.PageIndex = 0;
                    GvCusRequests.DataSource = ViewState["CusRequests"];
                    GvCusRequests.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvCusRequests.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCusRequests.PageIndex = 0;
                    GvCusRequests.DataSource = ViewState["CusRequests"];
                    GvCusRequests.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}