using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;


public partial class Users_Roles : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objbal = new ClsBAL();
    DataSet ObjDataset;
    DataView ObjDataview;
    DataTable ObjDatatable;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        this.Page.Title = "LoveJourney - Roles";

        if (!IsPostBack)
        {

            if (Session["UserID"] != null)
            {
                if (Session["UserID"].ToString() == "1")
                {
                    pnlRoles.Visible = true;
                    BindRoles();
                    lblSelectpage.Visible = ddlPageSize.Visible = lbtnXport2Xcel.Visible = txtSearch.Visible = btnSearch.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to View Roles.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlRoles.Visible = false;

                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to View Roles.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlRoles.Visible = false;

            }
        }
    }

    protected void BindRoles()
    {
        try
        {
            ObjDataset = objbal.GetRoles();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["Roles"] = ObjDataset.Tables[0];
                    GVRoles.DataSource = ObjDataset.Tables[0];
                    GVRoles.DataBind();
                    lbtnXport2Xcel.Visible = true;
                }
                else
                {
                    lbtnXport2Xcel.Visible = false;
                    ViewState["Roles"] = ObjDataset.Tables[0];
                    ObjDataset.Tables[0].Rows.Add(ObjDataset.Tables[0].NewRow());
                    GVRoles.DataSource = ObjDataset.Tables[0];
                    GVRoles.DataBind();

                    int TotalColumns = GVRoles.Rows[0].Cells.Count;
                    GVRoles.Rows[0].Cells.Clear();
                    GVRoles.Rows[0].Cells.Add(new TableCell());
                    GVRoles.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    GVRoles.Rows[0].Cells[0].Text = "No Roles Added Yet.... ";
                }

            }
            else
            {
                lbtnXport2Xcel.Visible = false;
                ViewState["Roles"] = ObjDataset.Tables[0];
                ObjDataset.Tables[0].Rows.Add(ObjDataset.Tables[0].NewRow());
                GVRoles.DataSource = ObjDataset.Tables[0];
                GVRoles.DataBind();

                int TotalColumns = GVRoles.Rows[0].Cells.Count;
                GVRoles.Rows[0].Cells.Clear();
                GVRoles.Rows[0].Cells.Add(new TableCell());
                GVRoles.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                GVRoles.Rows[0].Cells[0].Text = "No Roles Added Yet.... ";
            }
        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "BindRoles", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), Convert.ToDateTime(DateTime.Now));
            throw ex;
        }
        finally
        {
            if (ObjDataset != null) { ObjDataset = null; }
            if (ObjDataview != null) { ObjDataview = null; }
            if (ObjDataset != null) { ObjDataset = null; }
        }

    }

    protected void btnRoleAdd(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            TextBox txtRolesf = (TextBox)GVRoles.FooterRow.FindControl("txtRolef");
            if (ViewState["Roles"] != null)
            {
                ObjDatatable = (DataTable)ViewState["Roles"];

                ObjDataview = new DataView(ObjDatatable);
                ObjDataview.RowFilter = "Role='" + Convert.ToString(txtRolesf.Text) + "'";
                if (ObjDataview.Count > 0)
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already Role with this name has been created ...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
                }
                else
                {
                    objbal.role = Convert.ToString(txtRolesf.Text.ToString());
                    objbal.createdBy = Convert.ToInt32(1);//Session["UserID"]);
                    if (objbal.AddRole())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Role Created Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindRoles();
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS...Role Creation Failed....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }

                }

            }
        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "btnRoleAdd", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }

    }

    protected void GVRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            GVRoles.PageIndex = e.NewPageIndex;
            if (ViewState["Roles"] != null)
            {
                GVRoles.DataSource = ViewState["Roles"];
                GVRoles.DataBind();
            }
            else
            {
                BindRoles();
            }
        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "GVRoles_PageIndexChanging", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GVRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            GVRoles.EditIndex = -1;
            if (ViewState["Roles"] != null)
            {
                GVRoles.DataSource = ViewState["Roles"];
                GVRoles.DataBind();
            }
            else
            {
                BindRoles();
            }
        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "GVRoles_RowCancelingEdit", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GVRoles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            GVRoles.EditIndex = e.NewEditIndex;
            if (ViewState["Roles"] != null)
            {
                GVRoles.DataSource = ViewState["Roles"];
                GVRoles.DataBind();
            }
            else
            {
                BindRoles();
            }

        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "GVRoles_RowEditing", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GVRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            TextBox txtRoleE = (TextBox)GVRoles.Rows[e.RowIndex].FindControl("txtRole");
            Label lblID = (Label)GVRoles.Rows[e.RowIndex].FindControl("lblID");
            if (ViewState["Roles"] != null)
            {
                ObjDatatable = (DataTable)ViewState["Roles"];

                ObjDataview = new DataView(ObjDatatable);
                ObjDataview.RowFilter = "Role='" + Convert.ToString(txtRoleE.Text) + "'";
                if (ObjDataview.Count > 0)
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already Role with this name has been created ...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
                }
                else
                {
                    objbal.ID = Convert.ToInt32(lblID.Text);
                    objbal.role = Convert.ToString(txtRoleE.Text.ToString());
                    objbal.modifiedBy = Convert.ToInt32(1);//Session["UserID"]);
                    if (objbal.UpdateRole())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Role Updated Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        GVRoles.EditIndex = -1;
                        BindRoles();

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS...Role Updation Failed....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }

                }

            }

        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "GVRoles_RowUpdating", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {



        }
    }

    protected void GVRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            Label lblID = (Label)GVRoles.Rows[e.RowIndex].FindControl("lblID");
            objbal.ID = Convert.ToInt32(lblID.Text);
            objbal.modifiedBy = Convert.ToInt32(1);
            if (objbal.DeleteRole())
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#6CC417;", "");
                lblMainMsg.Text = "Role Deleted Successfully....";
                lblMainMsg.ForeColor = System.Drawing.Color.Green;
                BindRoles();
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "OOPS...Role Deletion Failed....";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            }

        }
        catch (Exception ex)
        {
            objbal.Logerror(this.Page.ToString(), "GVRoles_RowDeleting", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GVRoles_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["Roles"] as DataTable;
            if (GVRoles.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    GVRoles.DataSource = dataview;
                    GVRoles.DataBind();

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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Its Confirms that an HtmlForm control is rendered for the specified .net server control at run time. */
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GVRoles.AllowPaging = true;
            if (ViewState["Roles"] != null)
            {


                if (ddlPageSize.SelectedValue == "0")
                {
                    GVRoles.PageSize = 10;
                    GVRoles.PageIndex = 0;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GVRoles.PageSize = 10;
                    GVRoles.PageIndex = 0;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GVRoles.PageSize = 20;
                    GVRoles.PageIndex = 0;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GVRoles.PageSize = 30;
                    GVRoles.PageIndex = 0;
                    GVRoles.DataSource = ViewState["Roles"];
                    GVRoles.DataBind();
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
        string[] arr = new string[5];
        arr[0] = "CreatedBy"; arr[1] = "CreatedDate"; arr[2] = "ModifiedBy";
        arr[3] = "Status"; arr[4] = "ModifiedDate";
        DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["Roles"], arr);
        GridViewExportUtil.ExportToExcel("Users.xls", dtExport, true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";

            if (ViewState["Roles"] != null)
            {
                DataTable dtt = new DataTable();
                dtt.Columns.Add("ID");
                dtt.Columns.Add("Role");



                DataTable DtCommission = (DataTable)ViewState["Roles"];
                DataRow[] dr = DtCommission.Select("Role like '" + "%" + txtSearch.Text + "%" + "'");
                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        DataRow ddd = dtt.NewRow();
                        ddd["ID"] = row["ID"].ToString();
                        ddd["Role"] = row["Role"].ToString();
                        dtt.Rows.Add(ddd);
                    }
                }
                //if (dtt.Rows.Count > 0)
                //{
                GVRoles.DataSource = dtt;
                GVRoles.DataBind();
                //}
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void lbtnPrint_Click(object sender, EventArgs e)
    {

    }
}