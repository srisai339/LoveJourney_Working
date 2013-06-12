using System;
using System.Data;
using System.Web.UI.WebControls;
using BAL;
using System.Drawing;


public partial class Users_BusOperators : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                if (Session["UserID"].ToString() == "1")
                {
                    BindOperators(); 
                    pnlbusOperators.Visible = true;
                }
                else
                {
                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "  No Permission to this Screen.Please Contact Administrator for further details...";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlbusOperators.Visible = false;
                }
            }
            else
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to this Screen.Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlbusOperators.Visible = false;
            } 
            
            
        
        
        
        }
        lblErrorMsg.Text = lblViewMsg.Text = lblMsg.Text = "";
    }
    void BindOperators()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetBusOperators();
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                gvOperators.DataSource = ds.Tables[0];
            }
            else
            {
                gvOperators.DataSource = null;
            }
            Session["Operators"] = ds.Tables[0];
            gvOperators.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        try
        {
            if (TabContainer1.ActiveTab.HeaderText == "View")
            {
                BindOperators(); lblViewMsg.Text = ""; txtName.Text = "";
                btnSubmit.Text = "Submit"; btnCancelEdit.Visible = false;
                tabPanelAdd.HeaderText = "Add";
            }
            else if (TabContainer1.ActiveTab.HeaderText == "Add")
            {
                txtName.Text = ""; lblMsg.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            if (btnSubmit.Text == "Submit")
            {
                bool val = obj.AddBusOperator(txtName.Text.ToString(), ddlAPi.SelectedItem.Text);
                if (val) { lblMsg.Text = "Inserted successfully."; lblMsg.ForeColor = Color.Green; BindOperators(); }
                else { lblMsg.Text = "Failed to Insert. Name is already existed."; lblMsg.ForeColor = Color.Red; }
            }
            else if (btnSubmit.Text == "Update")
            {
                int id = Convert.ToInt32(btnSubmit.CommandArgument.ToString());

                bool valOfUpdated = obj.UpdateBusOperator(txtName.Text.ToString(), id);
                if (valOfUpdated)
                {
                    lblViewMsg.Text = "Updated Successfully.";
                    lblViewMsg.ForeColor = Color.Green;
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit"; btnCancelEdit.Visible = false;
                    tabPanelAdd.HeaderText = "Add";
                    BindOperators();
                }
                else
                {
                    lblMsg.Text = "Failed to update.";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancelEdit_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancelEdit.Visible = false; btnSubmit.Text = "Submit";
            TabContainer1.ActiveTab.HeaderText = "Add";
            TabContainer1.ActiveTabIndex = 0;
            BindOperators();
            txtName.Text = lblViewMsg.Text = lblMsg.Text = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvOperators_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvOperators.PageIndex = e.NewPageIndex;
            BindOperators();
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void gvOperators_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditName")
            {
                //TabContainer1.ActiveTabIndex = 1;
                //ClsManaBusBAL obj = new ClsManaBusBAL();

                //int busOperatorId = Convert.ToInt32(e.CommandArgument.ToString());

                //DataSet objDataSet = obj.GetOverTimeById();

                //TabContainer1.ActiveTab.HeaderText = "Edit";

                //btnSubmit.Text = "Update"; btnCancelEdit.Text = "Cancel"; btnCancelEdit.Visible = true;

                //txtName.Text = objDataSet.Tables[0].Rows[0]["BusOperatorName"].ToString();

                //btnSubmit.CommandArgument = e.CommandArgument.ToString();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected DataView SortDataTable(DataTable dt, string sortExpression, string sortDirection)
    {
        try
        {
            if (dt != null)
            {
                DataView dv = new DataView(dt);
                if (sortExpression != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}",
                    sortExpression, sortDirection);
                }
                return dv;
            }
            else
            {
                return new DataView();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private string SortDirection
    {
        get
        {
            return ViewState["SortDirection"] as string ?? "ASC";
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }
    private string GetSortDirection()
    {
        switch (SortDirection)
        {
            case "ASC":
                SortDirection = "DESC";
                break;
            case "DESC":
                SortDirection = "ASC";
                break;
        }
        return SortDirection;
    }
    protected void gvOperators_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["Operators"];
            DataView dv = SortDataTable(dt, e.SortExpression, GetSortDirection());
            gvOperators.DataSource = dv;
            gvOperators.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
}