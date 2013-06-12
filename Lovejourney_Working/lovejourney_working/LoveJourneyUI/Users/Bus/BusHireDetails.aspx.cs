using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_BusHireDetails : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objManabusBAL;
    DataSet ObjDataset;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        if (!IsPostBack)
        {
            this.Page.Title = "Manabus - Bus Hires";
            if (Session["UserID"] != null)
            {

                if (Session["UserID"].ToString() == "1")
                {
                    pnlBusHires.Visible = true;
                    GetBusHireDetails();
                    ddlPageSize.Visible = lbtnXport2Xcel.Visible = txtSearch.Visible = btnSearch.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to View Bus Hires.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlBusHires.Visible = false;

                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to View Bus Hires.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlBusHires.Visible = false;

            }
        }

    }

    protected void GetBusHireDetails()
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            objManabusBAL = new ClsBAL();
            ObjDataset = objManabusBAL.GetBusHireDetails();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["BusHires"] = ObjDataset.Tables[0];
                    lbtnXport2Xcel.Enabled = ddlPageSize.Enabled = true;
                }
                else
                {
                    lbtnXport2Xcel.Enabled = ddlPageSize.Enabled = false;
                }
                GvBusHires.DataSource = ObjDataset.Tables[0];
                GvBusHires.DataBind();
            }
        }
        catch (Exception ex)
        {
            objManabusBAL.Logerror(this.Page.ToString(), "GetBusHireDetails", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            if (ObjDataset != null) { ObjDataset = null; }

        }
    }

    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (ViewState["BusHires"] != null)
            {
                string[] arr = new string[3];
                arr[0] = "CreatedBy"; arr[1] = "CreatedDate";
                arr[2] = "Status";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["BusHires"], arr);
                GridViewExportUtil.ExportToExcel("BusHires.xls", dtExport, true);
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

        //Export the grid data to excel sheet
        //Export("Users.xls", this.GvUsers);
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvBusHires.AllowPaging = true;
            if (ViewState["BusHires"] != null)
            {


                if (ddlPageSize.SelectedValue == "0")
                {
                    GvBusHires.PageSize = 40;
                    GvBusHires.PageIndex = 0;
                    GvBusHires.DataSource = ViewState["BusHires"];
                    GvBusHires.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvBusHires.PageSize = 40;
                    GvBusHires.PageIndex = 0;
                    GvBusHires.DataSource = ViewState["BusHires"];
                    GvBusHires.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvBusHires.PageSize = 80;
                    GvBusHires.PageIndex = 0;
                    GvBusHires.DataSource = ViewState["BusHires"];
                    GvBusHires.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvBusHires.PageSize = 120;
                    GvBusHires.PageIndex = 0;
                    GvBusHires.DataSource = ViewState["BusHires"];
                    GvBusHires.DataBind();
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
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                GetBusHireDetails();
            }
            else
            {
                if (ViewState["BusHires"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("Id");
                    dtt.Columns.Add("Name");
                    dtt.Columns.Add("EmailId");
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("Source");
                    dtt.Columns.Add("Destination");
                    dtt.Columns.Add("NoOfSeats");

                    DataTable DtCommission = (DataTable)ViewState["BusHires"];
                    DataRow[] dr = DtCommission.Select("Name like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "EmailId like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Source like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Destination like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["Id"] = row["Id"].ToString();
                            ddd["Name"] = row["Name"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["Source"] = row["Source"].ToString();
                            ddd["Destination"] = row["Destination"].ToString();
                            ddd["NoOfSeats"] = row["NoOfSeats"].ToString();
                            dtt.Rows.Add(ddd);
                        }
                    }
                    //if (dtt.Rows.Count > 0)
                    //{
                    GvBusHires.DataSource = dtt;
                    GvBusHires.DataBind();
                    //}
                }


            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void GvBusHires_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (ViewState["BusHires"] != null)
            {
                DataTable dataTable = ViewState["BusHires"] as DataTable;
                if (GvBusHires.Rows.Count >= 0)
                {
                    if (dataTable != null)
                    {
                        DataView dataview = new DataView(dataTable);
                        string SD = GetSortDirection(e.SortExpression);
                        dataview.Sort = e.SortExpression + " " + SD;

                        GvBusHires.DataSource = dataview;
                        GvBusHires.DataBind();

                    }
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

    protected void GvBusHires_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvBusHires.PageIndex = e.NewPageIndex;
            if (ViewState["BusHires"] != null)
            {
                GvBusHires.DataSource = ViewState["BusHires"];
                GvBusHires.DataBind();
            }
            else
            {
                GetBusHireDetails();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}