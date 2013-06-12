using System;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class Users_CancellationPolicy : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    DataSet ObjDataset;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "LoveJourney - Bus - CancellationPolicy";

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                CheckPermission("Cancellation Policy", Session["Role"].ToString());
                GetCancelPercentages();
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

    protected void GetCancelPercentages()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetCancelPercentage();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    gvCancelPolicy.DataSource = ObjDataset.Tables[0];
                    gvCancelPolicy.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }


    }
    protected void GetBusOpeartors()
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetBusOperators();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    ddlOperator.DataSource = ObjDataset.Tables[0];
                    ddlOperator.DataValueField = "BusOperatorId";
                    ddlOperator.DataTextField = "BusOperatorName";
                    ddlOperator.DataBind();
                    ddlOperator.Items.Insert(0, "Select");
                }
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
            objBAL = new ClsBAL();
            objBAL.api = ddlApi.SelectedItem.Text;
            objBAL.ID = Convert.ToInt32(ddlOperator.SelectedItem.Value);
            objBAL.beforeTime = txtBeforeTime.Text;
            objBAL.percentage = txtCancelPercenatge.Text;
            if (objBAL.AddCancelPolicy())
            {
                lblMsg.Text = "saved Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtCancelPercenatge.Text = txtBeforeTime.Text = "";
                ddlApi.SelectedIndex = 0;
                ddlOperator.SelectedIndex = 0;
                GetCancelPercentages();
            }
            else
            {
                lblMsg.Text = "Failed to Save.....";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvCancelPolicy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "CancelEdit")
            {
                GridViewRow gRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                Label lblAPI = (Label)gRow.FindControl("lblAPI");
                Label lblPercentage = (Label)gRow.FindControl("lblPercentage");
                Label lblCancelPolicyID = (Label)gRow.FindControl("lblCancelPolicyID");
                Label lblBeforeTime = (Label)gRow.FindControl("lblBeforeTime");
                Label lblBusOperatorId = (Label)gRow.FindControl("lblBusOperatorId");
                if (lblAPI.Text == "Kesineni")
                {
                    ddlApi.SelectedIndex = 3;
                }
                else if (lblAPI.Text == "Abhibus")
                {
                    ddlApi.SelectedIndex = 1;
                }
                else if (lblAPI.Text == "Bitla")
                {
                    ddlApi.SelectedIndex = 2;
                }
                ddlApi_SelectedIndexChanged(sender, e);
                ddlOperator.SelectedValue = lblBusOperatorId.Text;
                lblId.Text = lblCancelPolicyID.Text;
                txtCancelPercenatge.Text = lblPercentage.Text;
                txtBeforeTime.Text = lblBeforeTime.Text;
                btnupdate.Visible = btnCancel.Visible = true;
                btnsave.Visible = false;
            }
            if (e.CommandName == "DeleteCancelDetails")
            {
                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(e.CommandArgument);

                if (objBAL.DeleteCancelPolicy())
                {
                    lblMsg.Text = "Deleted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GetCancelPercentages();
                }
                else
                {
                    lblMsg.Text = "Failed to Delete.....";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(lblId.Text);
            objBAL.api = ddlApi.SelectedItem.Text;
            objBAL.sourceId = Convert.ToInt32(ddlOperator.SelectedItem.Value);
            objBAL.percentage = txtCancelPercenatge.Text;
            objBAL.beforeTime = txtBeforeTime.Text;
            if (objBAL.UpdateCancelPolicy())
            {
                lblMsg.Text = "Updated Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                txtCancelPercenatge.Text = txtBeforeTime.Text = "";
                ddlApi.SelectedIndex = 0;
                btnupdate.Visible = btnCancel.Visible = false;
                btnsave.Visible = true;
                GetCancelPercentages();
            }
            else
            {
                lblMsg.Text = "Failed to Update.....";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnupdate.Visible = btnCancel.Visible = false;
        btnsave.Visible = true;
        txtCancelPercenatge.Text = "";
        ddlApi.SelectedIndex = 0;
        ddlOperator.SelectedIndex = 0;
        txtBeforeTime.Text = "";
    }
    protected void ddlApi_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
    protected void gvCancelPolicy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            ObjDataset = (DataSet)objBAL.GetCancelPercentage();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    gvCancelPolicy.PageIndex = e.NewPageIndex;
                    gvCancelPolicy.DataSource = ObjDataset.Tables[0];
                    gvCancelPolicy.DataBind();

                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}