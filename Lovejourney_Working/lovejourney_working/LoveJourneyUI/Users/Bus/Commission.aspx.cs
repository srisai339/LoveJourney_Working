using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_Commission : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    DataSet ObjDataset1;
    DataTable ObjDatatable;
    DataView ObjDataview;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - Commission";
            CheckPermission();
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["ViewCom"].ToString() == "1")
                {
                    BindApis();
                    MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to view Commissions.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    MVUsers.ActiveViewIndex = 0;
                    MVUsers.Visible = false;
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to view Commissions.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                MVUsers.ActiveViewIndex = 0; MVUsers.Visible = false;
            }

        }
    }

    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Commission";
            ObjDataset = (DataSet)objBAL.GetPerByUser();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = ObjDataset.Tables[0];
                    ViewState["AddCom"] = ObjDataset.Tables[0].Rows[0]["Add"].ToString();
                    ViewState["ViewCom"] = ObjDataset.Tables[0].Rows[0]["View"].ToString();
                    ViewState["DeleteCom"] = ObjDataset.Tables[0].Rows[0]["Delete"].ToString();
                    ViewState["EditCom"] = ObjDataset.Tables[0].Rows[0]["Edit"].ToString();


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

    protected void BindApis()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetCommissionApis();
            if (ObjDataset != null)
            {
                ViewState["CommissionApis"] = ObjDataset.Tables[0];
                GvCommissions.DataSource = ObjDataset.Tables[0];
                GvCommissions.DataBind();
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    lbtnXport2Xcel.Visible = true;
                }
                else
                {
                    lbtnXport2Xcel.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "BindApis", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
        finally
        {
            if (ObjDataset != null) { ObjDataset = null; }
            if (ObjDataset1 != null) { ObjDataset1 = null; }
            if (ObjDatatable != null) { ObjDatatable = null; }
            if (ObjDataview != null) { ObjDataview = null; }

        }

    }

    protected void GvCommissions_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["EditCom"].ToString() == "1")
                {
                    // GvCommissions.EditIndex = e.NewEditIndex;

                    Label lblApiE1 = (Label)GvCommissions.Rows[e.NewEditIndex].Cells[1].FindControl("lblApi");
                    Label lblIDE1 = (Label)GvCommissions.Rows[e.NewEditIndex].Cells[0].FindControl("lblID");
                    Label lblPercentageE1 = (Label)GvCommissions.Rows[e.NewEditIndex].Cells[2].FindControl("lblPercentage");

                    txtApi.Text = lblApiE1.Text;
                    txtPercentage.Text = lblPercentageE1.Text;
                    lblCommissionID.Text = lblIDE1.Text;
                    //GvCommissions.EditIndex = -1;
                    MVUsers.Visible = true;
                    MVUsers.ActiveViewIndex = 1;
                    btnSaveCD.Visible = false;
                    btnUpdateCD.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to edit Commissions details.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                }
            }



        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "GvCommissions_RowEditing", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void GvCommissions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["DeleteCom"].ToString() == "1")
                {
                    Label lblID1 = (Label)GvCommissions.Rows[e.RowIndex].FindControl("lblID");

                    objBAL = new ClsBAL();
                    objBAL.ID = Convert.ToInt32(lblID1.Text);
                    objBAL.modifiedBy = Convert.ToInt32(Session["UserID"]);
                    if (objBAL.DeleteCommission())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Commission details deleted Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindApis();
                        MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS...Failed to delete Commission details....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon; MVUsers.Visible = true;
                    }
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to view Commissions.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                }
            }


        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "GvCommissions_RowDeleting", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void btnSaveCD_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            if (ViewState["CommissionApis"] != null)
            {
                ObjDatatable = (DataTable)ViewState["CommissionApis"];

                ObjDataview = new DataView(ObjDatatable);
                ObjDataview.RowFilter = "Api='" + Convert.ToString(txtApi.Text) + "'";
                if (ObjDataview.Count > 0)
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already APi with this name has been created ...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    //GvCommissions.DataSource = ViewState["Roles"];
                    //GvCommissions.DataBind();
                }
                else
                {
                    objBAL = new ClsBAL();
                    objBAL.api = txtApi.Text;
                    objBAL.percentage = txtPercentage.Text;
                    objBAL.createdBy = Convert.ToInt32(Session["UserID"]);
                    if (objBAL.AddCommission())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Commission details saved Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindApis();
                        MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS...Failed to save Commission details....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnSaveCD_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void btnUpdateCD_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";

            if (ViewState["CommissionApis"] != null)
            {
                ObjDatatable = (DataTable)ViewState["CommissionApis"];

                ObjDataview = new DataView(ObjDatatable);
                ObjDataview.RowFilter = "Api='" + Convert.ToString(txtApi.Text) + "'";
                if (ObjDataview.Count > 0)
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "Already Api with this name has been created ...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;

                }
                else
                {

                    objBAL = new ClsBAL();
                    objBAL.ID = Convert.ToInt32(lblCommissionID.Text);
                    objBAL.api = txtApi.Text;
                    objBAL.percentage = txtPercentage.Text;
                    objBAL.modifiedBy = Convert.ToInt32(Session["UserID"]);
                    if (objBAL.UpdateCommission())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Commission details saved Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindApis();
                        MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS...Failed to save Commission details....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }
                }
            }






        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnUpdateCD_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "btnCancel_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    protected void lbtnNewCommission_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            txtApi.Text = "";
            txtPercentage.Text = "";
            txtSearch.Text = "";
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["AddCom"].ToString() == "1")
                {
                    MVUsers.ActiveViewIndex = 1;
                    btnUpdateCD.Visible = false;
                    btnSaveCD.Visible = true; MVUsers.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to add Commissions.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    MVUsers.ActiveViewIndex = 0; MVUsers.Visible = true;
                }
            }


        }
        catch (Exception ex)
        {
            objBAL.Logerror(this.Page.ToString(), "lbtnNewCommission_Click", ex.Message.ToString(), Convert.ToString(ex.InnerException), Convert.ToString(Request.UserHostAddress.ToString()), DateTime.Now);
            throw ex;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Its Confirms that an HtmlForm control is rendered for the specified .net server control at run time. */
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            GvCommissions.AllowPaging = true;
            if (ViewState["CommissionApis"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvCommissions.PageSize = 40;
                    GvCommissions.PageIndex = 0;
                    GvCommissions.DataSource = ViewState["CommissionApis"];
                    GvCommissions.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvCommissions.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCommissions.PageIndex = 0;
                    GvCommissions.DataSource = ViewState["CommissionApis"];
                    GvCommissions.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvCommissions.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCommissions.PageIndex = 0;
                    GvCommissions.DataSource = ViewState["CommissionApis"];
                    GvCommissions.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvCommissions.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    GvCommissions.PageIndex = 0;
                    GvCommissions.DataSource = ViewState["CommissionApis"];
                    GvCommissions.DataBind();
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
            if (ViewState["CommissionApis"] != null)
            {
                string[] arr = new string[5];
                arr[0] = "Status"; arr[1] = "CreatedBy"; arr[2] = "CreatedDate";
                arr[3] = "ModifiedBy"; arr[4] = "ModifiedDate";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["CommissionApis"], arr);
                GridViewExportUtil.ExportToExcel("Commission.xls", dtExport, true);
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void GvCommissions_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = ""; txtSearch.Text = ""; txtApi.Text = "";
            txtPercentage.Text = "";
            DataTable dataTable = ViewState["CommissionApis"] as DataTable;
            if (GvCommissions.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    GvCommissions.DataSource = dataview;
                    GvCommissions.DataBind();

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
        try
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
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void GvCommissions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvCommissions.PageIndex = e.NewPageIndex;
            if (ViewState["CommissionApis"] != null)
            {
                GvCommissions.DataSource = ViewState["CommissionApis"];
                GvCommissions.DataBind();
            }
            else
            {
                BindApis();
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
            if (ViewState["CommissionApis"] != null)
            {
                if (txtSearch.Text=="")
                {
                    GvCommissions.DataSource = ViewState["CommissionApis"];
                    GvCommissions.DataBind();

                }
                else
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("CommisssionId");
                    dtt.Columns.Add("Api");
                    dtt.Columns.Add("Percentage");

                    DataTable DtCommission = (DataTable)ViewState["CommissionApis"];
                    DataRow[] dr = DtCommission.Select("Api like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["CommisssionId"] = row["CommisssionId"].ToString();
                            ddd["Api"] = row["Api"].ToString();
                            ddd["Percentage"] = row["Percentage"].ToString();
                            dtt.Rows.Add(ddd);
                        }
                    }

                    GvCommissions.DataSource = dtt;
                    GvCommissions.DataBind();

                }
               
            }
        }
        catch (Exception EX)
        {

            throw EX;
        }
    }
}