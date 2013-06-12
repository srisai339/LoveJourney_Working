using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
using System.Text;

public partial class Users_Flight_PromoCodes : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    static int i = 0;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        this.Page.Title = "LoveJourney - PromoCode";
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "CSE")
                {
                    pnlpromocode.Visible = pnlADD.Visible = false;
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "    No permission to this page. Please contact Administrator for further details.";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    CheckPermission("PromoCode", Session["Role"].ToString());

                    BindPromocodes();
                }
                else
                {
                    pnlpromocode.Visible = pnlADD.Visible = true;
                    BindPromocodes();
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlpromocode.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                pnlpromocode.Visible = false;

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
                            pnlpromocode.Visible = true;
                            pnlADD.Visible = true;
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
    protected void BindPromocodes()
    {

        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetPromoCodes();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        lbtnXport2Xcel.Enabled = true;
                        ViewState["PromoCodes"] = ObjDataset.Tables[0];
                    }
                    gvPromoCodes.DataSource = ObjDataset.Tables[0];
                    gvPromoCodes.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected bool AddPromoCode()
    {
        try
        {
            objBAL = new ClsBAL();
           // lblCode.Text = "PC" + GeneratePromocode();
            objBAL.name = ddlserviceName.SelectedValue;
            objBAL.promoCode = Convert.ToString(txtpromocode.Text);
            objBAL.Amount = txtAmount.Text.ToString();
            objBAL.monthsToExpire = Convert.ToInt32(txtMonthstoexpire.Text);
            //objBAL.MinAmount = txtminamt.Text.Trim();
            //objBAL.MaxAmount = txtmaxamt.Text.Trim();
            objBAL.createdBy = Convert.ToInt32(Session["UserID"].ToString());
            if (objBAL.AddPromoCode(ref lblMsg))
            {
                return true;
            }
            else if (lblMsg.Text == "Already Promo code with this Number Exists")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }



    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            goto next;
        next:
            if (i > 1)
            {
                i = 0;
                lblMsg.Text = "Already Promo code with this Number Exists..Try Agian";
            }
            else
            {
                bool REs1 = AddPromoCode();
                if (REs1)
                {


                    //lblCode.Visible = true;
                    BindPromocodes();
                    //string body = "Dear Valued Customer, " + ",<br/><br/>" + "Thank you for using lovejourney.in as your travel partner for booking your Bus Ticket. You can enter the cash coupon ID in the cash coupon box on the personal details page the next time you want to transact on lovejourney.in and your amount will be adjusted against the fare.<br/><br/>"
                    //      + "Below are the cash coupon details of the cancelled ticket<br/><br/>Cash Coupon ID :" + lblCode.Text + "<br/> Coupon Value: " + txtAmount.Text + "<br/>Expiry Date :" + DateTime.Now.AddMonths(6).ToString()
                    //      + "<br/><br/>Please save the cash coupon ID. This cash coupon can be used during your next transaction on lovejourney.in. For more details about cash coupon, please visit the frequently asked questions page http://lovejourney.in/FAQ." +
                    //      "<br/><br/>Best regards,<br/>Support Staff.<br/>lovejourney.in";
                    //Mailsender.SendEmail(txtEmailID.Text, "", "", "Manabus Cash Coupon Code", body);

                    txtAmount.Text = txtMonthstoexpire.Text = "";
                    string script = "alert('Promo code is " + txtpromocode.Text + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                                  "ServerControlScript", script, true);
                    txtpromocode.Text = "";
                    ddlserviceName.ClearSelection();
                }
                else
                {
                    i++;
                    goto next;
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
            txtAmount.Text = txtMonthstoexpire.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            gvPromoCodes.AllowPaging = true;
            if (ViewState["PromoCodes"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    gvPromoCodes.PageSize = 40;
                    gvPromoCodes.PageIndex = 0;
                    gvPromoCodes.DataSource = ViewState["PromoCodes"];
                    gvPromoCodes.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    gvPromoCodes.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvPromoCodes.PageIndex = 0;
                    gvPromoCodes.DataSource = ViewState["PromoCodes"];
                    gvPromoCodes.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    gvPromoCodes.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvPromoCodes.PageIndex = 0;
                    gvPromoCodes.DataSource = ViewState["PromoCodes"];
                    gvPromoCodes.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    gvPromoCodes.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvPromoCodes.PageIndex = 0;
                    gvPromoCodes.DataSource = ViewState["PromoCodes"];
                    gvPromoCodes.DataBind();
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
            if (ViewState["PromoCodes"] != null)
            {
                txtAmount.Text = txtMonthstoexpire.Text = lblMsg.Text = "";
                tdmsg.Visible = false;

                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "CreatedBy";

                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["PromoCodes"], arr);
                GridViewExportUtil.ExportToExcel("PromoCodes.xls", dtExport, true);
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
    protected void gvPromoCodes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "status")
            {
                LinkButton lbtn = (LinkButton)e.CommandSource;
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                LinkButton lbtnstatus = (LinkButton)row.FindControl("lbtnstatus");
                Label lblstatus = (Label)row.FindControl("lblStatus");
                if (lbtnstatus.Text == "Activate")
                {
                    objBAL = new ClsBAL();
                    objBAL.ID = Convert.ToInt32(e.CommandArgument);
                    objBAL.status = "1";
                    objBAL.modifiedBy = Convert.ToInt32(Session["UserID"].ToString());
                    if (objBAL.UpdatePromoCodeStatus())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Updated Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindPromocodes();
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS Some Problem in updation.Try Later...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }
                }
                else if (lbtnstatus.Text == "Deactivate")
                {
                    objBAL = new ClsBAL();
                    objBAL.ID = Convert.ToInt32(e.CommandArgument);
                    objBAL.status = "0";
                    objBAL.modifiedBy = Convert.ToInt32(Session["UserID"].ToString());
                    if (objBAL.UpdatePromoCodeStatus())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Updated Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindPromocodes();
                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "OOPS Some Problem in updation.Try Later...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    protected void gvPromoCodes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = (Label)e.Row.FindControl("lblStatus");
                LinkButton lbtnstatus = (LinkButton)e.Row.FindControl("lbtnstatus");
                if (lblstatus.Text == "0")//(Convert.ToDateTime(lblExpDate.Text).Date < DateTime.Now.Date)
                {
                    lblstatus.Text = "Expired";
                    lbtnstatus.Text = "Activate";

                }
                else if (lblstatus.Text == "1")
                {
                    lblstatus.Text = "Active";
                    lbtnstatus.Text = "Deactivate";
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvPromoCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvPromoCodes.PageIndex = e.NewPageIndex;
            if (ViewState["PromoCodes"] != null)
            {
                gvPromoCodes.DataSource = ViewState["PromoCodes"];
                gvPromoCodes.DataBind();
            }
            else
            {
                BindPromocodes();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvPromoCodes_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            txtAmount.Text = txtMonthstoexpire.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            if (ViewState["PromoCodes"] != null)
            {
                lblMainMsg.Text = "";
                DataTable dataTable = ViewState["PromoCodes"] as DataTable;
                if (gvPromoCodes.Rows.Count >= 0)
                {
                    if (dataTable != null)
                    {
                        DataView dataview = new DataView(dataTable);
                        string SD = GetSortDirection(e.SortExpression);
                        dataview.Sort = e.SortExpression + " " + SD;

                        gvPromoCodes.DataSource = dataview;
                        gvPromoCodes.DataBind();

                    }
                }
            }
            else
            {
                BindPromocodes();
                gvPromoCodes_Sorting(sender, e);
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
            txtAmount.Text = txtMonthstoexpire.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (ViewState["PromoCodes"] != null)
            {
                DataTable dtt = new DataTable();
                dtt.Columns.Add("PromoCodeId");
                dtt.Columns.Add("PromoCode");
                dtt.Columns.Add("OperaterName");
                dtt.Columns.Add("Amount");
                dtt.Columns.Add("MonthsToExpire");
                dtt.Columns.Add("ExpirationDate");
                dtt.Columns.Add("CreatedDate");
                dtt.Columns.Add("UserName");
                dtt.Columns.Add("Status");

                DataTable DtCommission = (DataTable)ViewState["PromoCodes"];
                DataRow[] dr = DtCommission.Select("PromoCode like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "UserName like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "OperaterName like '" + "%" + txtSearch.Text + "%" + "'");
                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        DataRow ddd = dtt.NewRow();
                        ddd["PromoCodeId"] = row["PromoCodeId"].ToString();
                        ddd["PromoCode"] = row["PromoCode"].ToString();
                        ddd["OperaterName"] = row["OperaterName"].ToString();
                        ddd["Amount"] = row["Amount"].ToString();
                        ddd["MonthsToExpire"] = row["MonthsToExpire"].ToString();
                        ddd["ExpirationDate"] = row["ExpirationDate"].ToString();
                        ddd["CreatedDate"] = row["CreatedDate"].ToString();
                        ddd["UserName"] = row["UserName"].ToString();
                        ddd["Status"] = row["Status"].ToString();

                        dtt.Rows.Add(ddd);
                    }
                    lbtnXport2Xcel.Enabled = true;
                }
                else
                {
                    lbtnXport2Xcel.Enabled = false;
                }
                gvPromoCodes.DataSource = dtt;
                gvPromoCodes.DataBind();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}