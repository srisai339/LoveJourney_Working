using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_ViewFeedbacks : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        if (!IsPostBack)
        {
            this.Page.Title = "LoveJourney - Feedbacks";
            if (Session["UserID"] != null)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    BindFeedbacks();
                    pnlfeedbacks.Visible= true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlfeedbacks.Visible = false;
                    CheckPermission("FeedBacks", Session["Role"].ToString());
                    BindFeedbacks();
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlfeedbacks.Visible = false;
            }
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlfeedbacks.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                pnlfeedbacks.Visible = false;

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
                            pnlfeedbacks.Visible = true;                          
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
    protected void BindFeedbacks()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetFeedbacks();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Feedbacks"] = ObjDataset.Tables[0];
                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = true;
                    }
                    else
                    {
                        ddlPageSize.Enabled = lbtnXport2Xcel.Enabled = false;
                    }
                    GvFeedbacks.DataSource = ObjDataset.Tables[0];
                    GvFeedbacks.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GvFeedbacks_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;
            lblMainMsg.Text = "";
            if (ViewState["Feedbacks"] != null)
            {
                DataTable dataTable = ViewState["Feedbacks"] as DataTable;
                if (GvFeedbacks.Rows.Count >= 0)
                {
                    if (dataTable != null)
                    {
                        DataView dataview = new DataView(dataTable);
                        string SD = GetSortDirection(e.SortExpression);
                        dataview.Sort = e.SortExpression + " " + SD;

                        GvFeedbacks.DataSource = dataview;
                        GvFeedbacks.DataBind();
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

    protected void GvFeedbacks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            GvFeedbacks.PageIndex = e.NewPageIndex;
            if (ViewState["Feedbacks"] != null)
            {
                GvFeedbacks.DataSource = ViewState["Feedbacks"];
                GvFeedbacks.DataBind();
            }
            else
            {
                BindFeedbacks();
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
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (ViewState["Feedbacks"] != null)
            {
                string[] arr = new string[1];
                arr[0] = "CreatedBy";
                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["Feedbacks"], arr);
                GridViewExportUtil.ExportToExcel("Feedbacks.xls", dtExport, true);
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
            GvFeedbacks.AllowPaging = true;
            if (ViewState["Feedbacks"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    GvFeedbacks.PageSize = 40;
                    GvFeedbacks.PageIndex = 0;
                    GvFeedbacks.DataSource = ViewState["Feedbacks"];
                    GvFeedbacks.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    GvFeedbacks.PageSize = 40;
                    GvFeedbacks.PageIndex = 0;
                    GvFeedbacks.DataSource = ViewState["Feedbacks"];
                    GvFeedbacks.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    GvFeedbacks.PageSize = 80;
                    GvFeedbacks.PageIndex = 0;
                    GvFeedbacks.DataSource = ViewState["Feedbacks"];
                    GvFeedbacks.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    GvFeedbacks.PageSize = 120;
                    GvFeedbacks.PageIndex = 0;
                    GvFeedbacks.DataSource = ViewState["Feedbacks"];
                    GvFeedbacks.DataBind();
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
                BindFeedbacks();
            }
            else
            {
                if (ViewState["Feedbacks"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("FeedbackId");
                    dtt.Columns.Add("Name");
                    dtt.Columns.Add("EmailId");
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("PartialComments");
                    dtt.Columns.Add("Comments");
                    dtt.Columns.Add("CreatedDate");
                    dtt.Columns.Add("CreatedBy");

                    DataTable DtCommission = (DataTable)ViewState["Feedbacks"];
                    DataRow[] dr = DtCommission.Select("Name like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "EmailId like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "PartialComments like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["FeedbackId"] = row["FeedbackId"].ToString();
                            ddd["Name"] = row["Name"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["PartialComments"] = row["PartialComments"].ToString();
                            ddd["Comments"] = row["Comments"].ToString();
                            ddd["CreatedDate"] = row["CreatedDate"].ToString();
                            ddd["CreatedBy"] = row["CreatedBy"].ToString();
                            dtt.Rows.Add(ddd);
                        }
                    }
                    if (dtt.Rows.Count > 0)
                    {
                        lbtnXport2Xcel.Enabled = true;
                    }
                    else
                    {
                        lbtnXport2Xcel.Enabled = false;
                    }
                    GvFeedbacks.DataSource = dtt;
                    GvFeedbacks.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GvFeedbacks_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                //if (ViewState["Feedbacks"] != null)
                //{
                //    DataTable dt = (DataTable)ViewState["Feedbacks"];
                //    DataView dV = new DataView(dt);
                //    dV.RowFilter = "FeedbackId='" + e.CommandArgument.ToString() + "'";
                //    if (dV.Count > 0)
                //    {
                //        if (dV.Count == 1)
                //        {
                //            GridView1.DataSource = dV;
                //            GridView1.DataBind();
                //            mpecomments.Show();
                //        }
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GvFeedbacks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvView = (GridView)e.Row.FindControl("GridView1");
                Label lblID = (Label)e.Row.FindControl("lblFeedbackID");
                if (ViewState["Feedbacks"] != null)
                {
                    DataTable dt = (DataTable)ViewState["Feedbacks"];
                    DataView dV = new DataView(dt);
                    dV.RowFilter = "FeedbackId='" + lblID.Text.ToString() + "'";
                    if (dV.Count > 0)
                    {
                        if (dV.Count == 1)
                        {
                            gvView.DataSource = dV;
                            gvView.DataBind();
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
}