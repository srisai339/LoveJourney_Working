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
public partial class Users_Recharge_AddTarrif : System.Web.UI.Page
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
             
            fnLoadPage();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.InsertTarrif;
       // _objDataSet = (DataSet)_objMasters.fnGetData();
        _objMasters.OperatorsID =Convert.ToInt32(ddlProvider.SelectedValue);
        _objMasters.Denomination =Convert.ToInt32( txtDenomination.Text);
        _objMasters.TalkTime = Convert.ToDecimal(txtTalkTime.Text);
        _objMasters.Validity = txtValidity.Text;
        _objMasters.Description = txtDescription.Text;

        if (_objMasters.fnInsertRecord() == true)
        {
            lblmessage.ForeColor = Color.Green;
            lblmessage.Text = "Record saved successfully.";

            ddlProvider_SelectedIndexChanged(sender, e);


            ddlProvider.SelectedIndex = 0;
            txtDenomination.Text = string.Empty;
            txtTalkTime.Text = string.Empty;
            txtValidity.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
        else
        {
            lblmessage.Text = "Insertion Failed";
        }
    }
        catch(Exception ex)
        {
            throw ex;
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

    protected void lnkback_Click(object sender, EventArgs e)
    {
        traddpopularrecharge.Visible = true;
        trpopularrecharges.Visible = false;
    }
    protected void lnkshow_Click(object sender, EventArgs e)
    {
        traddpopularrecharge.Visible = false;
        trpopularrecharges.Visible = true;
        fnLoadtariffsPage();
      
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

                    }
                    else
                    {
                        lblmsg.Text = "No data found";
                        lblmsg.Visible = true;
                        lblmsg.ForeColor = Color.Red;
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
    }
    private void fnLoadtariffsPage()
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
    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblmessage.Text = "";
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
                        gvMobile.Visible = true;
                        gvMobile.DataSource = _objDataSet.Tables[0];
                        gvMobile.DataBind();

                    }
                    else
                    {
                        //lblmsg.Text = "No data found";
                        //lblmsg.Visible = true;
                        //lblmsg.ForeColor = Color.Red;
                        gvMobile.Visible = false;

                    }
                }
                else
                {
                   // lblmsg.Text = "No data found";
                    gvMobile.Visible = false;
                }
            }
            else
            {
               // lblmsg.Text = "No data found";
                gvMobile.Visible = false;
            }
        }
        catch (Exception ex)
        {


        }
    }
}
