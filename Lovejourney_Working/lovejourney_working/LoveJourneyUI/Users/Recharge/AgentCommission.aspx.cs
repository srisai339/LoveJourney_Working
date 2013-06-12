using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Drawing;
using APRWorld;
using BAL;

public partial class Users_Recharge_AgentCommission : System.Web.UI.Page
{

    #region Global Variables
    ClsBAL objBal;
    DataSet _objDataSet;
    DataSet _objDataSet1;
    clsMasters _objMasters;
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

                                //   Agents();

                                fnLoadPage1();
                                btnUpdate.Visible = false;
                                btnDelete.Visible = false;
                                btnCancel.Visible = false;
                                btnAdd.Visible = true;
                                tdagentcommission.Visible = true;
                            }
                            else
                            {
                                tdmsg.Visible = true;
                                tdmsg.Style.Add("background-color:#E77471;", "");
                                lblMainMsg.Text = "   No Permission to add agents commission. Please Contact Administrator for further details...";
                                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                tdagentcommission.Visible = false;
                            }
                        }
                        else
                        {
                            tdmsg.Visible = true;
                            tdmsg.Style.Add("background-color:#E77471;", "");
                            lblMainMsg.Text = "   No Permission to add agents commission. Please Contact Administrator for further details...";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tdagentcommission.Visible = false;
                        }

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No Permission to add agents commission. Please Contact Administrator for further details...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        tdagentcommission.Visible = false;
                    }

                }
                else
                {
                    // Agents();

                    fnLoadPage1();
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    tdagentcommission.Visible = true;
                }
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
            objBAL.screenName = "Networks Commission";
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
    protected void Agents()
    {
        DataSet ds = GetAgents();
        ddlName.DataSource = ds;
        ddlName.DataTextField = "Username"; 
        ddlName.DataValueField = "UserId";
        ddlName.DataBind();
        ddlName.Items.Insert(0, "Please Select");
    }
    DataSet GetAgents()
    {
        try
        {
            objBal = new ClsBAL();
            return objBal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void BindDisAgents()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.GetDistributorsList;
        _objMasters.DistributorID = Convert.ToInt32(Session["RechargeUserID"].ToString());
        _objMasters.Parameter = "getagentsbydistributorsId";
        _objDataSet = (DataSet)_objMasters.fnGetData();
        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlName.DataSource = _objDataSet.Tables[0];
                    ddlName.DataValueField = "UserID";
                    ddlName.DataTextField = "FirstName";
                    ddlName.DataBind();
                    ddlName.Items.Insert(0, "Please Select");
                }
                else
                {
                    ddlName.Items.Clear();
                    ddlName.Items.Insert(0, "Please Select");
                }
            }
        }
    }
    private void fnLoadPage()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getoperators;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ddlProvider.DataSource = _objDataSet.Tables[0];
                        ddlProvider.DataValueField = "OperatorsID";
                        ddlProvider.DataTextField = "OperatorsName";
                        ddlProvider.DataBind();
                        ddlProvider.Items.Insert(0, "Please Select");

                    }
                    else
                    {
                        lblmessage.Text = "No data found";
                    }
                }
                else
                {
                    lblmessage.Text = "No data found";
                }
            }
            else
            {
                lblmessage.Text = "No data found";
            }
        }
        catch (Exception ex)
        {


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
    public void fnLoadPage1()
    {
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.AgentCommission;


            if (Session["Role"].ToString() == "Admin")
            {
                _objMasters.Type = "AD";
                _objMasters.DistributorID = Convert.ToInt32(Session["UserID"].ToString());
            }
            else if (Session["Role"].ToString() == "DB")
            {
                _objMasters.Type = "AG";
                _objMasters.DistributorID = Convert.ToInt32(Session["UserID"].ToString());
            }

          
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                gvOperators.DataSource = _objDataSet.Tables[0];
                gvOperators.DataBind();
                ViewState["OperatorName"] = _objDataSet.Tables[0];
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                btnAdd.Visible = true;
            }

        }
        catch (Exception ex)
        {
          //  LogError("Masters_frmOperatorNameaspx.aspx", "fnLoadPage", DateTime.Now, ex.Message.ToString());
          //  Response.Redirect("../Error.aspx", false);
            //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
            //Logger.Log(ex, Session["APRUserName"].ToString());
            lblmessage.Text = ex.Message;
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
        
            _objMasters.OperatorType = ddloperators.SelectedValue;
            _objMasters.NetworkName = ddlProvider.SelectedItem.Text;
            _objMasters.AgentCommission = Convert.ToDecimal(txtRechargeAmount.Text);
            _objMasters.Type = ddlName.SelectedValue;
           // _objMasters.DistributorID =Convert.ToInt32(ddlName.SelectedValue);

            _objMasters.ScreenInd = Masters.GetCommisionByNetwork;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    DataView dv = _objDataSet.Tables[0].DefaultView;

                    dv.RowFilter = "Type='" + ddlName.SelectedValue + "'and OperatorType='" + ddloperators.SelectedValue + "' and OperatorsName='" + ddlProvider.SelectedItem.Text+"'";
                    if (dv.Count > 0)
                    {
                        lblmessage.ForeColor = Color.Red;
                        lblmessage.Text = "Already you have given commission for this network,Please try another one.";
                        lblmessage.Visible = true;
                    }
                    else
                    {
                        _objMasters.ScreenInd = Masters.AgentCommission;

                        _objMasters.OperatorType = ddloperators.SelectedValue;
                        _objMasters.NetworkName = ddlProvider.SelectedValue;
                        _objMasters.AgentCommission = Convert.ToDecimal(txtRechargeAmount.Text);
                        _objMasters.Type = ddlName.SelectedValue;
                        if (_objMasters.fnInsertRecord() == true)
                        {
                            lblmessage.ForeColor = Color.Green;
                            lblmessage.Text = "Record saved successfully.";
                            ddlProvider.SelectedIndex = 0;
                            txtRechargeAmount.Text = string.Empty;

                            ddloperators.SelectedIndex = 0;
                            fnLoadPage1();
                        }
                        else
                        {
                            lblmessage.Text = "Insertion Failed";
                        }
                    }
                }
                else
                {
                    _objMasters.ScreenInd = Masters.AgentCommission;

                    _objMasters.OperatorType = ddloperators.SelectedValue;
                    _objMasters.NetworkName = ddlProvider.SelectedValue;
                    _objMasters.AgentCommission = Convert.ToDecimal(txtRechargeAmount.Text);
                    _objMasters.Type = ddlName.SelectedValue;
                    if (_objMasters.fnInsertRecord() == true)
                    {
                        lblmessage.ForeColor = Color.Green;
                        lblmessage.Text = "Record saved successfully.";
                        ddlProvider.SelectedIndex = 0;
                        txtRechargeAmount.Text = string.Empty;

                        ddloperators.SelectedIndex = 0;
                        fnLoadPage1();
                    }
                    else
                    {
                        lblmessage.Text = "Insertion Failed";
                    }
                }

            }
            else
            {
                _objMasters.ScreenInd = Masters.AgentCommission;

                _objMasters.OperatorType = ddloperators.SelectedValue;
                _objMasters.NetworkName = ddlProvider.SelectedValue;
                _objMasters.AgentCommission = Convert.ToDecimal(txtRechargeAmount.Text);
                _objMasters.Type = ddlName.SelectedValue;
                if (_objMasters.fnInsertRecord() == true)
                {
                    lblmessage.ForeColor = Color.Green;
                    lblmessage.Text = "Record saved successfully.";
                    ddlProvider.SelectedIndex = 0;
                    txtRechargeAmount.Text = string.Empty;

                    ddloperators.SelectedIndex = 0;
                    fnLoadPage1();
                }
                else
                {
                    lblmessage.Text = "Insertion Failed";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.AgentCommission;
            _objMasters.RefID = Convert.ToInt32(lblID.Text);

            _objMasters.OperatorType = ddloperators.SelectedValue;
            _objMasters.NetworkName = ddlProvider.SelectedValue;
            _objMasters.AgentCommission = Convert.ToDecimal(txtRechargeAmount.Text);


            if (_objMasters.fnUpdateRecord() == true)
            {
                lblmessage.ForeColor = Color.Green;
                lblmessage.Text = "Record Updated successfully.";
                ddlProvider.SelectedIndex = 0;
                txtRechargeAmount.Text = string.Empty;
              
                ddloperators.SelectedIndex = 0;
                fnLoadPage1();
            }
            else
            {
                lblmessage.Text = "Insertion Failed";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();

            _objMasters.ScreenInd = Masters.AgentCommission;
            _objMasters.RefID = Convert.ToInt32(lblID.Text.Trim());

            if (_objMasters.fnDeleteRecord() == true)
            {

                lblmessage.ForeColor = Color.Green;
                lblmessage.ForeColor = Color.Green;
                lblmessage.Text = "Record deleted successfully.";
                txtRechargeAmount.Text = string.Empty;
                fnLoadPage1();
                ddlProvider.SelectedIndex = 0;
                txtRechargeAmount.Text = string.Empty;

                ddloperators.SelectedIndex = 0;
            }
            else
            {
                lblmessage.ForeColor = Color.Red;
                lblmessage.ForeColor = Color.Red;
                lblmessage.Text = "Record deletion failed.";
            }
        }
        catch (Exception ex)
        {
            //LogError("Masters_frmOperatorNameaspx", "btnDelete_Click", DateTime.Now, ex.Message.ToString());
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
        lblmessage.Text = "";
        lblmessage.Text = "";
        txtRechargeAmount.Text = "";

        ddloperators.SelectedIndex = 0;
        ddlProvider.SelectedItem.Text = "Please Select";
        fnLoadPage();
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
    protected void gvOperators_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblID.Text = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["Id"].ToString();
        ddloperators.SelectedValue = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["OperatorType"].ToString();

        ddloperators_SelectedIndexChanged(sender, e);

        ddlProvider.SelectedValue = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["OperatorsID"].ToString().Trim();
        txtRechargeAmount.Text = gvOperators.DataKeys[gvOperators.SelectedIndex].Values["AgentCommission"].ToString();


        lblmessage.Text = "";
        btnUpdate.Visible = true;
        btnDelete.Visible = true;
        btnCancel.Visible = true;
        btnAdd.Visible = false;
    }
    protected void ddloperators_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetNetworkName;
            _objMasters.OperatorType = ddloperators.SelectedItem.Text;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlProvider.DataSource = _objDataSet.Tables[0];
                    ddlProvider.DataValueField = "OperatorsID";
                    ddlProvider.DataTextField = "OperatorsName";
                    ddlProvider.DataBind();
                    ddlProvider.Items.Insert(0, "Please Select");
                }
                else
                {
                    ddlProvider.Items.Insert(0, "Please Select");
                    ddlProvider.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
        }
       
    }

    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (Session["Role"].ToString() == "Admin")
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetAdminCommission;
            _objMasters.Type = "AD";


            _objMasters.NetworkName = ddlProvider.SelectedItem.Text;
         
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    lblpercentage.Text = _objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString() + "%";
                }
                else
                {
                    lblpercentage.Text = "0.00" + "%";
                }
            }
            else
            {
                lblpercentage.Text = "0.00" + "%";
            }

        }
        else if (Session["Role"].ToString() == "DB")
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getdisCommission;
            _objMasters.Type = "DB";

            _objMasters.NetworkName = ddlProvider.SelectedValue;
            _objMasters.DistributorID = Convert.ToInt32(Session["RechargeUserID"].ToString());
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    lblpercentage.Text = _objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString() + "%";
                }
                else
                {
                    lblpercentage.Text = "0.00" + "%";
                }
            }
            else
            {
                lblpercentage.Text = "0.00" + "%";
            }
        }
    }
    //protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if(ddlType.SelectedValue == "DB")
    //    {
    //        BindDistributors();
    //    }
    //    else if(ddlType.SelectedValue == "AG")
    //    {
    //       BindAgents();
    //    }
    //}
    protected void BindDistributors()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.GetDistributorsList;
        _objMasters.Parameter = "getdistributorslist";
        _objDataSet = (DataSet)_objMasters.fnGetData();
        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlName.DataSource = _objDataSet.Tables[0];
                    ddlName.DataTextField = "FirstName";
                    ddlName.DataValueField = "UserID";
                    ddlName.DataBind();

                    ddlName.Items.Insert(0, "Please Select");
                }

                else
                {
                    ddlName.Items.Insert(0, "Please Select");
                }
            }
            else
            {

            }
        }

    }

    private void BindAgents()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetAgentApprovedList;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlName.DataSource = _objDataSet.Tables[0];
                    ddlName.DataValueField = "UserID";
                    ddlName.DataTextField = "FirstName";
                    ddlName.DataBind();
                    ddlName.Items.Insert(0, "Please Select");
                    // ddlAgentName.SelectedIndex = 0;

                }
            }
        }
        catch (Exception ex)
        {


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
}