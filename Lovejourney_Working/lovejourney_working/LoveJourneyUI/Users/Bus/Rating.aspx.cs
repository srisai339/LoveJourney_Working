using System;
using System.Data;
using System.Web.UI.WebControls;
using BAL;

public partial class Users_Rating : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (!IsPostBack) 
            {
                if (Session["Role"] != null)
                {
                    CheckPermission("Rating", Session["Role"].ToString());

                    BindGrid();
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            this.Page.Title = "LoveJourney - Bus - Rating";

        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlMain.Visible = true;
            tdmsg.Style.Add("background-color:#E77471;", "");
            lblMainMsg.Text = " No Permission to this page. Please contact Administrator for further details.";
            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
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
    void BindGrid()
    {
        objBAL = new ClsBAL();
        DataSet ds = objBAL.GetRatings();
        gvRating.DataSource = ds;
        ViewState["Rating"] = ds.Tables[0];
        gvRating.DataBind();
    }
    protected void ddlApi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           // txtRating.Text = ""; 
            btnsave.Text = " Save ";
            if (ddlApi.SelectedValue != "0")
            {
                objBAL = new ClsBAL();
                objBAL.api = ddlApi.SelectedItem.Text;
                ObjDataset = (DataSet)objBAL.GetBusOperatorsByAPI();
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        ddlOperator.DataSource = ObjDataset.Tables[0];
                        ddlOperator.DataValueField = "BusOperatorId";
                        ddlOperator.DataTextField = "BusOperatorName";
                        ddlOperator.DataBind();
                        ddlOperator.Items.Insert(0, "Select");
                    }
                    else
                    {
                        ddlOperator.Items.Clear();
                        ddlOperator.Items.Insert(0, "Select");
                    }
                }
            }
            else
            {
                ddlOperator.Items.Clear();
                ddlOperator.Items.Insert(0, "Select");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            objBAL = new ClsBAL();
            bool b= objBAL.AddRating(Convert.ToInt32(ddlOperator.SelectedValue.ToString()), Convert.ToInt32(txtRating.Text.ToString()));
            if (b) { lblMsg.Text = "Saved Successfully."; BindGrid(); }
            else { lblMsg.Text = "Failed."; }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void gvRating_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Edit") 
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            objBAL = new ClsBAL();
            DataSet ds = objBAL.GetRatingByRatingId(Convert.ToInt32(id));
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txtRating.Text = ds.Tables[0].Rows[0]["Rating"].ToString();
                ddlApi.SelectedValue = ddlApi.Items.FindByText(ds.Tables[0].Rows[0]["APIName"].ToString()).Value;
                ddlApi_SelectedIndexChanged(sender, e);
                ddlOperator.SelectedValue = ddlOperator.Items.FindByText(ds.Tables[0].Rows[0]["BusOperatorName"].ToString()).Value;
            }
        }
    }
    protected void gvRating_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvRating.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void gvRating_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
           

            DataTable dataTable = (DataTable)ViewState["Rating"];
            if (gvRating.Rows.Count >= 0)
            {
                DataView dataview = new DataView(dataTable);

                dataview.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                //gvBookBus.Sorting = "Fare ASC";
                gvRating.DataSource = dataview;
                gvRating.DataBind();
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
    protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtRating.Text = ""; btnsave.Text = " Save ";
            if (ddlOperator.SelectedIndex != 0)
            {
                objBAL = new ClsBAL();
                DataSet ds = objBAL.GetRatingByOperatorId(Convert.ToInt32(ddlOperator.SelectedValue.ToString()));
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    txtRating.Text = ds.Tables[0].Rows[0]["Rating"].ToString();
                    btnsave.Text = " Update ";
                }
                else { txtRating.Text = ""; btnsave.Text = " Save "; }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    protected void gvRating_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label ID = (Label)gvRating.FindControl("lblid");

        objBAL = new ClsBAL();
        DataSet ds = objBAL.GetRatingByRatingId(Convert.ToInt32(ID));
        if (ds.Tables[0].Rows.Count >= 1)
        {
            txtRating.Text = ds.Tables[0].Rows[0]["Rating"].ToString();
            ddlApi.SelectedValue = ddlApi.Items.FindByText(ds.Tables[0].Rows[0]["APIName"].ToString()).Value;
            ddlApi_SelectedIndexChanged(sender, e);
            ddlOperator.SelectedValue = ddlOperator.Items.FindByText(ds.Tables[0].Rows[0]["BusOperatorName"].ToString()).Value;
        }
    }
    protected void gvRating_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            objBAL = new ClsBAL();
            DataSet ds = objBAL.GetRatingByRatingId(Convert.ToInt32(id));
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txtRating.Text = ds.Tables[0].Rows[0]["Rating"].ToString();
                ddlApi.SelectedValue = ddlApi.Items.FindByText(ds.Tables[0].Rows[0]["APIName"].ToString()).Value;
                ddlApi_SelectedIndexChanged(sender, e);
                ddlOperator.SelectedValue = ddlOperator.Items.FindByText(ds.Tables[0].Rows[0]["BusOperatorName"].ToString()).Value;
            }
        }
    }
    protected void gvRating_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvRating_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}