using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using System.Drawing;
public partial class Users_frmOperatorNameaspx : System.Web.UI.Page
{
    #region Global Variables
    DataSet _objDataSet;
    clsMasters _objMasters;
    private bool includeGridLines;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "CSE")
                {
                    CheckPermission();
                    if (ViewState["UserPermissions"] != null)
                    {
                        if (ViewState["Book"] != null)
                        {
                            if (ViewState["Book"].ToString() == "1")
                            {
                                fnLoadPage();
                                tdoperator.Visible = true;
                            }

                            else
                            {
                                tdmsg.Visible = true;
                                tdmsg.Style.Add("background-color:#E77471;", "");
                                lblMainMsg.Text = "   No Permission to Add Operators name. Please Contact Administrator for further details...";
                                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                tdoperator.Visible = false;
                            }
                        }
                        else
                        {
                            tdmsg.Visible = true;
                            tdmsg.Style.Add("background-color:#E77471;", "");
                            lblMainMsg.Text = "   No Permission to Add Operators name. Please Contact Administrator for further details...";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tdoperator.Visible = false;
                        }

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No Permission to Add Operators name. Please Contact Administrator for further details...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        tdoperator.Visible = false;
                    }

                }
                else
                {
                    tdoperator.Visible = true;
                    fnLoadPage();
                }
                lblMsg1.Text = "";
                lblMsg2.Text = "";

            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    protected void CheckPermission()
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Operator";
            _objDataSet = (DataSet)objBAL.GetPerByUser();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = _objDataSet.Tables[0];
                    ViewState["Book"] = _objDataSet.Tables[0].Rows[0]["Book"].ToString();
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

    public void fnLoadPage()
    {
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Operators;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            ViewState["OperatorName"] = _objDataSet.Tables[0];

            gvOperators.DataSource = _objDataSet.Tables[0];
            gvOperators.DataBind();

            trCCode.Visible = false;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;


        }
        catch (Exception ex)
        {
          //  LogError("Masters_frmOperatorNameaspx.aspx", "fnLoadPage", DateTime.Now, ex.Message.ToString());
            Response.Redirect("../Error.aspx", false);
            //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
            //Logger.Log(ex, Session["APRUserName"].ToString());
        }
        finally
        {
            _objMasters = null;
            if (_objDataSet != null)
            {
                _objDataSet.Dispose();
            }
        }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();

            _objMasters.ScreenInd = Masters.Operators;
            _objMasters.NetworkName = txtOperatorsName.Text.Trim();
            _objMasters.OperatorKeyword = txtOperatorsKeyword.Text.Trim();
            _objMasters.OperatorType = ddltype.SelectedItem.Text;
          //  _objMasters.TypeOftransactionId = Convert.ToInt32(ddltypeoftransaction.SelectedValue);

            if (_objMasters.fnInsertRecord() == true)
            {
                fnLoadPage();
                lblMsg1.ForeColor = Color.Green;
                lblMsg2.ForeColor = Color.Green;
                lblMsg1.Text = "Confirmation: ";
                lblMsg2.Text = "Record inserted successfully.";
                txtOperatorsName.Text = string.Empty;
                txtOperatorsKeyword.Text = string.Empty;
            }
            else
            {
                lblMsg1.ForeColor = Color.Red;
                lblMsg2.ForeColor = Color.Red;
                lblMsg1.Text = "<font color='red'> Error Notification: </font>";
                lblMsg2.Text = "Record insertion failed.";
            }
        }
        catch (Exception ex)
        {
           // LogError("Masters_frmOperatorNameaspx.aspx", "btnAdd_Click", DateTime.Now, ex.Message.ToString());
            Response.Redirect("../Error.aspx", false);
            //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
            //Logger.Log(ex, Session["APRUserName"].ToString());
        }
        finally
        {
            _objMasters = null;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();

            _objMasters.ScreenInd = Masters.Operators;
            _objMasters.NetworkName = txtOperatorsName.Text.Trim();
            _objMasters.OperatorKeyword = txtOperatorsKeyword.Text.Trim();
            _objMasters.OperatorType = ddltype.SelectedItem.Text;
            _objMasters.RefID = Convert.ToInt32(lblCCode.Text);

            if (_objMasters.fnUpdateRecord() == true)
            {
                fnLoadPage();
                lblMsg1.ForeColor = Color.Green;
                lblMsg2.ForeColor = Color.Green;
                lblMsg1.Text = "Confirmation: ";
                lblMsg2.Text = "Record updated successfully.";
                txtOperatorsName.Text = string.Empty;
                txtOperatorsKeyword.Text = string.Empty;
            }
            else
            {
                lblMsg1.ForeColor = Color.Red;
                lblMsg2.ForeColor = Color.Red;
                lblMsg1.Text = "<font color='red'> Error Notification: </font>";
                lblMsg2.Text = "Record updation failed.";
            }
        }
        catch (Exception ex)
        {
          //  LogError("Masters_frmOperatorNameaspx.aspx", "btnUpdate_Click", DateTime.Now, ex.Message.ToString());
            Response.Redirect("../Error.aspx", false);
            //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
            //Logger.Log(ex, Session["APRUserName"].ToString());
        }
        finally
        {
            _objMasters = null;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();

            _objMasters.ScreenInd = Masters.Operators;
            _objMasters.RefID = Convert.ToInt32(lblCCode.Text.Trim());

            if (_objMasters.fnDeleteRecord() == true)
            {
                fnLoadPage();
                lblMsg1.ForeColor = Color.Green;
                lblMsg2.ForeColor = Color.Green;
                lblMsg1.Text = "Confirmation: ";
                lblMsg2.Text = "Record deleted successfully.";
                txtOperatorsName.Text = string.Empty;
                txtOperatorsKeyword.Text = string.Empty;
            }
            else
            {
                lblMsg1.ForeColor = Color.Red;
                lblMsg2.ForeColor = Color.Red;
                lblMsg1.Text = "<font color='red'> Error Notification: </font>";
                lblMsg2.Text = "Record deletion failed.";
            }
        }
        catch (Exception ex)
        {
          //  LogError("Masters_frmOperatorNameaspx", "btnDelete_Click", DateTime.Now, ex.Message.ToString());
            Response.Redirect("../Error.aspx", false);
            //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
            //Logger.Log(ex, Session["APRUserName"].ToString());
        }
        finally
        {
            _objMasters = null;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnCancel.Visible = false;
        btnAdd.Visible = true;
        lblMsg1.Text = "";
        lblMsg2.Text = "";
        txtOperatorsName.Text = "";
        txtOperatorsKeyword.Text = "";
        ddltype.SelectedValue = "0";
        fnLoadPage();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("OperatorDetails.xls", this.gvOperators, includeGridLines);
    }
    protected void gvOperators_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCCode.Text = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["NetworkId"].ToString().Trim();
        txtOperatorsName.Text = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["NetworkName"].ToString();
        txtOperatorsKeyword.Text = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["OperatorKeyword"].ToString();
        trCCode.Visible = true;
        btnUpdate.Visible = true;
        btnDelete.Visible = true;
        btnCancel.Visible = true;
        btnAdd.Visible = false;
    }
    protected void gvOperators_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            gvOperators.PageIndex = e.NewPageIndex;
            gvOperators.DataSource = ViewState["OperatorName"];
            gvOperators.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvOperators_Sorting(object sender, GridViewSortEventArgs e)
    {

        try
        {

            DataTable dataTable = (DataTable)ViewState["OperatorName"];
            if (gvOperators.Rows.Count >= 0)
            {
                DataView dataview = new DataView(dataTable);

                dataview.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                //gvBookBus.Sorting = "Fare ASC";
                gvOperators.DataSource = dataview;
                gvOperators.DataBind();
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
}