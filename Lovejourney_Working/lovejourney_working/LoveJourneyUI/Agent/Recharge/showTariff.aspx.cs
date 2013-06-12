using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using BAL;
using System.Drawing;

public partial class Agent_Recharge_showTariff : System.Web.UI.Page
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
            fnLoadPage();
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {


        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetTarrif;
            _objMasters.OperatorsID = Convert.ToInt32(ddlProvider.SelectedValue);
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        lblmsg.Text = "";
                        gvMobile.DataSource = _objDataSet.Tables[0];
                        gvMobile.DataBind();
                        gvMobile.Visible = true;

                    }
                    else
                    {
                        lblmsg.Text = "No data found";
                        lblmsg.Visible = true;
                        lblmsg.ForeColor = Color.Red;
                        gvMobile.Visible = false;
                    }
                }
                else
                {
                    lblmsg.Text = "No data found";
                    gvMobile.Visible = false;
                }
            }
            else
            {
                gvMobile.Visible = false;
                lblmsg.Text = "No data found";
            }
        }
        catch (Exception ex)
        {


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
                        lblmsg.Text = "No data found";
                    }
                }
                else
                {
                    lblmsg.Text = "No data found";
                }
            }
            else
            {
                lblmsg.Text = "No data found";
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