using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BAL;
public partial class Users_CashCoupon : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;
    DataTable ObjDatatable;
    DataView ObjDataview;
    int i = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.lbtnXport2Xcel);
        this.Page.Title = "LoveJourney - CashCoupon";

        if (!IsPostBack)
        {
            CheckPermission();
            if (ViewState["UserPermissions"] != null)
            {
                if (ViewState["View"].ToString() == "1")
                {
                    BindCashCoupons();
                    pnlAddCoupon.Visible =pnlCashCoupon.Visible= true;

                }
                else
                {
                    pnlAddCoupon.Visible = pnlCashCoupon.Visible = false;
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "   No Permission to Add Coupon. Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;

                }
            }
            //else
            //{
            //    pnlAddCoupon.Visible = pnlCashCoupon.Visible = false;
            //    tdmsg.Visible = true;
            //    tdmsg.Style.Add("background-color:#E77471;", "");
            //    lblMainMsg.Text = "   No Permission to Add Coupon. Please Contact Administrator for further details...";
            //    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;

            //}
        }
    }

    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Coupon";
            ObjDataset = (DataSet)objBAL.GetPerByUser();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = ObjDataset.Tables[0];
                    ViewState["Add"] = ObjDataset.Tables[0].Rows[0]["Add"].ToString();
                    ViewState["View"] = ObjDataset.Tables[0].Rows[0]["View"].ToString();
                    ViewState["Delete"] = ObjDataset.Tables[0].Rows[0]["Delete"].ToString();
                    ViewState["Edit"] = ObjDataset.Tables[0].Rows[0]["Edit"].ToString();
                    ViewState["Permission"] = ObjDataset.Tables[0].Rows[0]["Permission"].ToString();
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

    protected void BindCashCoupons()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetCashCoupons();
            if (ObjDataset != null)
            {
                gvcashcoupons.DataSource = ObjDataset.Tables[0];
                gvcashcoupons.DataBind();
                if (ObjDataset.Tables.Count > 0)
                {
                    ViewState["CashCoupons"] = ObjDataset.Tables[0];
                    lbtnXport2Xcel.Enabled = ddlPageSize.Enabled = true;
                }
                else
                {
                    lbtnXport2Xcel.Enabled = ddlPageSize.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected String GeneratePassword()
    {
        lblMsg.Text = "";
        int minPassSize = 9;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        //lblMessage.Text = stringBuilder.ToString();
        return "CC"+stringBuilder.ToString();
    }

    protected bool AddCashCoupontest()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.couponNo = Convert.ToString(GeneratePassword());
            objBAL.emailId = Convert.ToString(txtEmailID.Text);
            objBAL.Amount = Convert.ToString(txtAmount.Text);
            objBAL.createdBy = Convert.ToInt32(Session["UserID"]);

            if (objBAL.AddCashCoupon(ref lblMsg))
            {
                return true;
            }
            else if (lblMsg.Text == "Already Cash Coupon with this Number Exists")
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

    protected bool AddCashCoupon()
    {
        try
        {
            objBAL = new ClsBAL();
            lblCode.Text = "CC" + GeneratePassword();
            objBAL.name = ddlserviceName.SelectedValue;
            objBAL.couponNo = Convert.ToString(txtcahcoupon.Text);
            objBAL.emailId = Convert.ToString(txtEmailID.Text);
            objBAL.Amount = Convert.ToString(txtAmount.Text);
           // objBAL.MinAmount = txtminamt.Text.Trim();
          //  objBAL.MaxAmount = txtmaxamt.Text.Trim();
            objBAL.createdBy = Convert.ToInt32(Session["UserID"]);

            if (objBAL.AddCashCoupon(ref lblMsg))
            {
                return true;
            }
            else if (lblMsg.Text == "Already Cash Coupon with this Number Exists")
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


            //lblMsg.Text = "Cash Coupon Code :" + GeneratePassword();
            //bool Res = AddCashCoupontest();
            //if (Res)
            //{
            //    txtAmount.Text = txtEmailID.Text = "";
            //}
            //else
            //{
            //    goto next;
            //}



            //if (ViewState["UserPermissions"] != null)
            //{
            //    if (ViewState["Add"].ToString() == "1")
            //    {

                    goto next;
                next:
                    bool REs1 = AddCashCoupon();
                    if (REs1)
                    {

                        
                        //lblCode.Visible = true;
                        BindCashCoupons();
                        string body = "Dear Valued Customer, " + ",<br/><br/>" + "Thank you for using lovejourney.in as your travel partner for booking your Bus Ticket. You can enter the cash coupon ID in the cash coupon box on the personal details page the next time you want to transact on lovejourney.in and your amount will be adjusted against the fare.<br/><br/>"
                           + "Below are the cash coupon details of the cancelled ticket<br/><br/>Cash Coupon ID :" + lblCode.Text + "<br/> Coupon Value: " + txtAmount.Text + "<br/>Expiry Date :" + DateTime.Now.AddMonths(6).ToString()
                           + "<br/><br/>Please save the cash coupon ID. This cash coupon can be used during your next transaction on lovejourney.in. For more details about cash coupon, please visit the frequently asked questions page http://lovejourney.in/FAQ." +
                           "<br/><br/>Best regards,<br/>Support Staff.<br/>lovejourney.in";
                        Mailsender.SendEmail(txtEmailID.Text, "", "", "Manabus Cash Coupon Code", body);
                        string script = "alert('cash coupon code is " + lblCode.Text + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                                      "ServerControlScript", script, true);
                        txtAmount.Text = txtEmailID.Text = "";
                    }
                    else
                    {
                        goto next;
                    }

                //}
                //else
                //{
                //    tdmsg.Visible = true;
                //    tdmsg.Style.Add("background-color:#E77471;", "");
                //    lblMainMsg.Text = "  No Permission to Add Coupon.Please Contact Administrator for further details...";
                //    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;

                //}
            //}


        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void gvcashcoupons_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblExpDate = (Label)e.Row.FindControl("lblExpiryDate");
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

    protected void gvcashcoupons_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            txtAmount.Text = txtEmailID.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            DataTable dataTable = ViewState["CashCoupons"] as DataTable;
            if (gvcashcoupons.Rows.Count >= 0)
            {
                if (dataTable != null)
                {
                    DataView dataview = new DataView(dataTable);
                    string SD = GetSortDirection(e.SortExpression);
                    dataview.Sort = e.SortExpression + " " + SD;

                    gvcashcoupons.DataSource = dataview;
                    gvcashcoupons.DataBind();

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

    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["CashCoupons"] != null)
            {
                txtAmount.Text = txtEmailID.Text = lblMsg.Text = "";
                tdmsg.Visible = false;

                lblMainMsg.Text = "";
                string[] arr = new string[1];
                arr[0] = "CreatedBy";

                DataTable dtExport = GridViewExportUtil.GetNewExportTable((DataTable)ViewState["CashCoupons"], arr);
                GridViewExportUtil.ExportToExcel("Cashcoupons.xls", dtExport, true);
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
            txtAmount.Text = txtEmailID.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            gvcashcoupons.AllowPaging = true;
            if (ViewState["CashCoupons"] != null)
            {


                if (ddlPageSize.SelectedValue == "0")
                {
                    gvcashcoupons.PageSize = 40;
                    gvcashcoupons.PageIndex = 0;
                    gvcashcoupons.DataSource = ViewState["CashCoupons"];
                    gvcashcoupons.DataBind();
                    //BindUsers();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    gvcashcoupons.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvcashcoupons.PageIndex = 0;
                    gvcashcoupons.DataSource = ViewState["CashCoupons"];
                    gvcashcoupons.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    gvcashcoupons.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvcashcoupons.PageIndex = 0;
                    gvcashcoupons.DataSource = ViewState["CashCoupons"];
                    gvcashcoupons.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    gvcashcoupons.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvcashcoupons.PageIndex = 0;
                    gvcashcoupons.DataSource = ViewState["CashCoupons"];
                    gvcashcoupons.DataBind();
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
            txtAmount.Text = txtEmailID.Text = lblMsg.Text = "";
            tdmsg.Visible = false;

            lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                BindCashCoupons();
            }
            else
            {


                if (ViewState["CashCoupons"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("CouponId");
                    dtt.Columns.Add("CouponNo");
                    dtt.Columns.Add("EmailId");
                    dtt.Columns.Add("Amount");
                    dtt.Columns.Add("DateOfCreation");
                    dtt.Columns.Add("ExpiryDate");
                    dtt.Columns.Add("CreatedBy");
                    dtt.Columns.Add("Status");

                    DataTable DtCommission = (DataTable)ViewState["CashCoupons"];
                    DataRow[] dr = DtCommission.Select("CouponNo like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "EmailId like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["CouponId"] = row["CouponId"].ToString();
                            ddd["CouponNo"] = row["CouponNo"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                            ddd["Amount"] = row["Amount"].ToString();
                            ddd["DateOfCreation"] = row["DateOfCreation"].ToString();
                            ddd["ExpiryDate"] = row["ExpiryDate"].ToString();
                            ddd["CreatedBy"] = row["CreatedBy"].ToString();
                            ddd["Status"] = row["Status"].ToString();
                            dtt.Rows.Add(ddd);
                        }
                    }
                    gvcashcoupons.DataSource = dtt;
                    gvcashcoupons.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void gvcashcoupons_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvcashcoupons.PageIndex = e.NewPageIndex;
            if (ViewState["CashCoupons"] != null)
            {
                gvcashcoupons.DataSource = ViewState["CashCoupons"];
                gvcashcoupons.DataBind();
            }
            else
            {
                BindCashCoupons();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvcashcoupons_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    if (objBAL.UpdateCashCouponStatus())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Updated Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindCashCoupons();
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
                    if (objBAL.UpdateCashCouponStatus())
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#6CC417;", "");
                        lblMainMsg.Text = "Updated Successfully....";
                        lblMainMsg.ForeColor = System.Drawing.Color.Green;
                        BindCashCoupons();
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
}