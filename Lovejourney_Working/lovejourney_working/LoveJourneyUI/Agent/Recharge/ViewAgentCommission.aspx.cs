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
//using APRWorld;
using BAL;

public partial class Agent_Recharge_ViewAgentCommission : System.Web.UI.Page
{
    #region Global Variables
    DataSet _objDataSet;
    DataSet _objDataSet1;
    clsMasters _objMasters;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["RechargeUserType"].ToString() == "DB")
            //{
            //    fnDistributorCommission();
            //}
            //else
            if (Session["UserID"] != null)
            {
                if (Session["Role"].ToString() == "Agent")
                {
                    fnLoadPage1();
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    public void fnLoadPage1()
    {
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.AgentCommission;

            if (Session["Role"].ToString() == "Agent")
            {
                _objMasters.Type = "AG";
            }

            _objMasters.DistributorID = Convert.ToInt32(Session["UserID"].ToString());
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                gvOperators.DataSource = _objDataSet.Tables[0];
                gvOperators.DataBind();
                ViewState["OperatorName"] = _objDataSet.Tables[0];
                lblmessage.Visible = false;

            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "No Data Found.";
                lblmessage.ForeColor = Color.Red;
            }

        }
        catch (Exception ex)
        {
          //  LogError("Masters_frmOperatorNameaspx.aspx", "fnLoadPage", DateTime.Now, ex.Message.ToString());
           // Response.Redirect("../Error.aspx", false);
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



    //public void fnDistributorCommission()
    //{
    //    try
    //    {

    //        _objMasters = new clsMasters();
    //        _objMasters.ScreenInd = Masters.AgentIndividualCommission;

    //        _objMasters.DistributorID = Convert.ToInt32(Session["RechargeUserID"].ToString());
    //        _objDataSet = (DataSet)_objMasters.fnGetData();

    //        if (_objDataSet.Tables[0].Rows.Count > 0)
    //        {
    //            gvOperators.DataSource = _objDataSet.Tables[0];
    //            gvOperators.DataBind();
    //            ViewState["OperatorName"] = _objDataSet.Tables[0];
    //            lblmessage.Visible = false;
    //        }
    //        else
    //        {
    //            lblmessage.Visible = true;
    //            lblmessage.Text = "No Data Found.";
    //            lblmessage.ForeColor = Color.Red;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        //LogError("Masters_frmOperatorNameaspx.aspx", "fnLoadPage", DateTime.Now, ex.Message.ToString());
    //        Response.Redirect("../Error.aspx", false);
    //        //Logger.Log(Logger.LogType.Log_In_DB, ex,true);
    //        //Logger.Log(ex, Session["APRUserName"].ToString());
    //    }
    //    finally
    //    {
    //        _objMasters = null;
    //        if (_objDataSet != null)
    //        {
    //            _objDataSet.Dispose();
    //        }
    //    }

    //}

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
}