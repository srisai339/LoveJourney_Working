using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class Users_Recharge_IndividualAgentReports : System.Web.UI.Page
{
    #region Global Variables
    DataSet _objDataSet;
    clsMasters _objMasters;
    private bool includeGridLines;
    decimal TotalAmount = 0;
    decimal TotalCommission = 0;
    DateTime dt; DateTime dt1;
   
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
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
                                DateTime dateTime = Convert.ToDateTime(System.DateTime.Now.ToString());
                                string date = dateTime.ToString("dd/MM/yyyy");
                                txtDF.Text = date.ToString();

                                DateTime dateTime1 = Convert.ToDateTime(System.DateTime.Now.ToString());
                                string date1 = dateTime.ToString("dd/MM/yyyy");
                                txtDT.Text = date1.ToString();


                               // txtDF.Text = System.DateTime.Now.ToString();
                               // txtDT.Text = System.DateTime.Now.ToString();
                                ddlservice.SelectedValue = "1";
                                MobileRechargeAdmin();
                                tdindividualAgentReports.Visible = true;
                            }
                            else
                            {
                                tdmsg.Visible = true;
                                tdmsg.Style.Add("background-color:#E77471;", "");
                                lblMainMsg.Text = "   No Permission to View Reports . Please Contact Administrator for further details...";
                                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                tdindividualAgentReports.Visible = false;
                            }
                        }
                        else
                        {
                            tdmsg.Visible = true;
                            tdmsg.Style.Add("background-color:#E77471;", "");
                            lblMainMsg.Text = "   No Permission to View Reports. Please Contact Administrator for further details...";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tdindividualAgentReports.Visible = false;
                        }

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No Permission to View Reports. Please Contact Administrator for further details...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        tdindividualAgentReports.Visible = false;
                    }
                }
                else
                {
                    DateTime dateTime = Convert.ToDateTime(System.DateTime.Now.ToString());
                    string date = dateTime.ToString("dd/MM/yyyy");
                    txtDF.Text = date.ToString();

                    DateTime dateTime1 = Convert.ToDateTime(System.DateTime.Now.ToString());
                    string date1 = dateTime.ToString("dd/MM/yyyy");
                    txtDT.Text = date1.ToString();

                    //txtDF.Text = System.DateTime.Now.ToString();
                    //txtDT.Text = System.DateTime.Now.ToString();
                    ddlservice.SelectedValue = "1";
                    MobileRechargeAdmin();
                    tdindividualAgentReports.Visible = true;
                }
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx",false);
        }
    }
    protected void CheckPermission()
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Individual Agent Reports";
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
    #region FUNCTIONS


    public void MobileRecharge()
    {
        lblMobileMsg.Text = ""; lblDataCardmsg.Text = ""; lblDataCardmsg.Text = "";
        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = true;
        paging.Visible = false;
        gvMobile.DataSource = null;
        gvMobile.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;
        lblD2HMsg.Visible = false;


        Label4dataCommi.Visible = false;
        Label4D2hComm.Visible = false;
        Label3DEH.Visible = false;

        lblTotalProfit.Visible = true;
        lblTotalAmount.Visible = true;

        try
        {
            if (DateTime.Parse(txtDF.Text.Trim().ToString()) > DateTime.Parse(txtDT.Text.Trim().ToString()))
            {
                lblMobileMsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.GetAgentOnly;
                _objMasters.From = txtDF.Text.Trim().ToString();
                _objMasters.To = txtDT.Text.Trim().ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                _objMasters.Parameter = "Mobile";
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["MobileData"] = _objDataSet.Tables[0];

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvMobile.DataSource = _objDataSet.Tables[0];
                    gvMobile.DataBind();
                }
                else
                {
                    paging.Visible = false;
                    lblMobileMsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void D2HRecharge()
    {
        lblMobileMsg.Text = ""; lblDataCardmsg.Text = ""; lblD2HMsg.Text = "";
        gvD2HRecharge.Visible = true;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = false;
        paging.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblD2HMsg.Text = string.Empty;

        Label4dataCommi.Visible = false;
        Label4D2hComm.Visible = true;
        Label3DEH.Visible = true;

        lblTotalProfit.Visible = false;
        lblTotalAmount.Visible = false;


        try
        {
            if (DateTime.Parse(txtDF.Text.Trim().ToString()) > DateTime.Parse(txtDT.Text.Trim().ToString()))
            {
                lblD2HMsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.GetAgentOnly;
                _objMasters.From = txtDF.Text.Trim().ToString();
                _objMasters.To = txtDT.Text.Trim().ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                _objMasters.Parameter = "DTH";
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["D2HData"] = _objDataSet.Tables[0];


                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvD2HRecharge.DataSource = _objDataSet.Tables[0];
                    gvD2HRecharge.DataBind();
                }
                else
                {
                    Label3DEH.Visible = false;
                    Label4D2hComm.Visible = false;
                    paging.Visible = false;
                    lblD2HMsg.Visible = true;
                    lblD2HMsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch
        {


        }
    }


    public void DataCardRecharge()
    {
        lblMobileMsg.Text = ""; lblDataCardmsg.Text = "";
        lblD2HMsg.Text = "";
        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = true;
        gvMobile.Visible = false;
        paging.Visible = false;
        gvDataCardRecharge.DataSource = null;
        gvDataCardRecharge.DataBind();
        lblDataCardmsg.Text = string.Empty;

        Label4dataCommi.Visible = true;
        Label4D2hComm.Visible = false;

        lblTotalProfit.Visible = false;

        try
        {
            if (DateTime.Parse(txtDF.Text.Trim().ToString()) > DateTime.Parse(txtDT.Text.Trim().ToString()))
            {
                lblDataCardmsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.GetAgentOnly;
                _objMasters.From = txtDF.Text.Trim().ToString();
                _objMasters.To = txtDT.Text.Trim().ToString();
                _objMasters.Parameter = "DataCard";
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["DataCardData"] = _objDataSet.Tables[0];

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvDataCardRecharge.DataSource = _objDataSet.Tables[0];
                    gvDataCardRecharge.DataBind();
                }
                else
                {
                    paging.Visible = false;
                    lblDataCardmsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region ADMINFUNCTIONS


    public void MobileRechargeAdmin()
    {
        lblMobileMsg.Text = ""; lblD2HMsg.Text = ""; lblDataCardmsg.Text = "";
        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = true;
        paging.Visible = false;
        gvMobile.DataSource = null;
        gvMobile.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;


        Label4dataCommi.Visible = false;
        Label4D2hComm.Visible = false;
        Label3DEH.Visible = false;

        lblTotalProfit.Visible = true;
        lblTotalAmount.Visible = false;

        _objMasters = new clsMasters();
        dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt = Convert.ToDateTime(dt.ToShortDateString());

        dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt1 = Convert.ToDateTime(dt1.ToShortDateString());

        try
        {
            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblMobileMsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
              
                _objMasters.ScreenInd = Masters.GetAdminReports;

              

                _objMasters.From = dt.ToString();
                _objMasters.To = dt1.ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                if (ddlservice.SelectedValue == "1")
                {
                    _objMasters.Parameter = "Mobile";
                }
                else if (ddlservice.SelectedValue == "4")
                {
                    _objMasters.Parameter = "ALL";
                }


                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["MobileData"] = _objDataSet.Tables[0];

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvMobile.DataSource = _objDataSet.Tables[0];
                    gvMobile.DataBind();
                }
                else
                {
                    paging.Visible = false;
                    lblMobileMsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void D2HRechargeAdmin()
    {
        lblMobileMsg.Text = ""; lblDataCardmsg.Text = ""; lblD2HMsg.Text = "";
        gvD2HRecharge.Visible = true;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = false;
        paging.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblD2HMsg.Text = string.Empty;

        Label4dataCommi.Visible = false;
        Label4D2hComm.Visible = true;

        lblTotalProfit.Visible = false;
        lblTotalAmount.Visible = false;

        _objMasters = new clsMasters();
        dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt = Convert.ToDateTime(dt.ToShortDateString());

        dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt1 = Convert.ToDateTime(dt1.ToShortDateString());


        try
        {
            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblD2HMsg.Text = "From Date should be less than To Date";
                Label3DEH.Visible = false;
                Label4D2hComm.Visible = false;
                return;
            }
            else
            {
            
                _objMasters.ScreenInd = Masters.GetAdminReports;
                _objMasters.From = dt.ToString();
                _objMasters.To = dt1.ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                _objMasters.Parameter = "DTH";
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["D2HData"] = _objDataSet.Tables[0];


                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvD2HRecharge.DataSource = _objDataSet.Tables[0];
                    gvD2HRecharge.DataBind();
                }
                else
                {

                    Label3DEH.Visible = false;
                    Label4D2hComm.Visible = false;
                    paging.Visible = false;
                    lblD2HMsg.Visible = true;
                    lblD2HMsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch
        {


        }
    }


    public void DataCardRechargeADMIN()
    {
        lblMobileMsg.Text = ""; lblDataCardmsg.Text = "";
        lblD2HMsg.Text = "";
        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = true;
        gvMobile.Visible = false;
        paging.Visible = false;
        gvDataCardRecharge.DataSource = null;
        gvDataCardRecharge.DataBind();
        lblDataCardmsg.Text = string.Empty;

        Label4dataCommi.Visible = true;
        Label4D2hComm.Visible = false;

        lblTotalProfit.Visible = false;


        _objMasters = new clsMasters();
        dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt = Convert.ToDateTime(dt.ToShortDateString());

        dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
        dt1 = Convert.ToDateTime(dt1.ToShortDateString());

        try
        {
            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblDataCardmsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.GetAdminReports;
                _objMasters.From = dt.ToString();
                _objMasters.To = dt1.ToString();
                _objMasters.Parameter = "DataCard";
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["DataCardData"] = _objDataSet.Tables[0];

                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvDataCardRecharge.DataSource = _objDataSet.Tables[0];
                    gvDataCardRecharge.DataBind();
                }
                else
                {
                    paging.Visible = false;
                    lblDataCardmsg.Text = "No Numbers are Recharged between " + txtDF.Text + " and  " + txtDT.Text;
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Role"].ToString() == "Agent")
            {

                if (ddlservice.SelectedValue == "1")
                {
                    MobileRecharge();
                }
                else if (ddlservice.SelectedValue == "2")
                {
                    D2HRecharge();
                }

                else if (ddlservice.SelectedValue == "3")
                {
                    DataCardRecharge();
                }

            }
            else if (Session["Role"].ToString() == "Admin")
            {

                if (ddlservice.SelectedValue == "1")
                {
                    MobileRechargeAdmin();
                }
                else if (ddlservice.SelectedValue == "2")
                {
                    D2HRechargeAdmin();
                }

                else if (ddlservice.SelectedValue == "3")
                {
                    DataCardRechargeADMIN();
                }
                else if (ddlservice.SelectedValue == "4")
                {
                    MobileRechargeAdmin();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (gvGain.Rows.Count > 0)
        {
            //GridViewExportUtil.Export("CheckGainDetails.xls", this.gvGain, includeGridLines);
        }
        //else
        //{
        //    lblerrMsg.Text = "Data not available in grid to export";
        //    return;
        //}
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _objMasters = new clsMasters();
            //  _objMasters.ScreenInd = Masters.Users_UT;
            //_objMasters.UserType = ddlUserType.SelectedItem.Value.ToString();
            //_objDataSet = (DataSet)_objMasters.fnGetData();
            //ddlUser.DataSource = _objDataSet.Tables[0];
            //ddlUser.DataValueField = "Code";
            //ddlUser.DataTextField = "Description";
            //ddlUser.DataBind();
            //ddlUser.Items.Insert(0, "Please Select");
            //ddlUser.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    #region PageIndexChanging

    protected void gvMobile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            // MobileRecharge();
            gvMobile.PageIndex = e.NewPageIndex;
            gvMobile.DataSource = ViewState["MobileData"];
            gvMobile.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvD2HRecharge_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            // D2HRecharge();
            gvD2HRecharge.PageIndex = e.NewPageIndex;
            gvD2HRecharge.DataSource = ViewState["D2HData"];
            gvD2HRecharge.DataBind();
            gvD2HRecharge.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvGain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void gvDataCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            gvDataCardRecharge.PageIndex = e.NewPageIndex;
            gvDataCardRecharge.DataSource = ViewState["DataCardData"];
            gvDataCardRecharge.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlpagesize.SelectedValue == "Please Select")
            {

            }

            if (ddlpagesize.SelectedValue == "1")
            {
                gvMobile.PageSize = 300;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 300;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCardRecharge.PageSize = 300;
                gvDataCardRecharge.DataSource = ViewState["DataCardData"];
                gvDataCardRecharge.DataBind();


            }
            else if (ddlpagesize.SelectedValue == "2")
            {

                gvMobile.PageSize = 600;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 600;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCardRecharge.PageSize = 600;
                gvDataCardRecharge.DataSource = ViewState["DataCardData"];
                gvDataCardRecharge.DataBind();

            }

            else if (ddlpagesize.SelectedValue == "3")
            {
                gvMobile.PageSize = 900;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 900;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCardRecharge.PageSize = 900;
                gvDataCardRecharge.DataSource = ViewState["DataCardData"];
                gvDataCardRecharge.DataBind();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvMobile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label4dataCommi.Visible = false;
            Label4D2hComm.Visible = false;
            lblTotalProfit.Visible = true;
            lblTotalAmount.Visible = true;

            if (e.Row.Cells[6].Text == "SUCCESS")
            {
                if (TotalAmount == 0)
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0.00";
                    }
                    if (e.Row.Cells[5].Text == "&nbsp;" || e.Row.Cells[5].Text == "")
                    {
                        e.Row.Cells[5].Text = "0.00";
                    }
                    TotalAmount = Convert.ToDecimal(e.Row.Cells[4].Text);
                    lblTotalAmount.Text = "Total Amount for Successful Recharges" + " " + Convert.ToString(TotalAmount);
                    TotalCommission = Convert.ToDecimal(e.Row.Cells[5].Text);
                    lblTotalProfit.Text = "Total Commission for  Successful Recharges" + " " + Convert.ToString(TotalCommission);


                }
                else
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0.00";
                    }
                    if (e.Row.Cells[5].Text == "&nbsp;" || e.Row.Cells[5].Text == "")
                    {
                        e.Row.Cells[5].Text = "0.00";
                    }
                    TotalAmount = TotalAmount + Convert.ToDecimal(e.Row.Cells[4].Text);
                    lblTotalAmount.Text = "Total Amount forSuccessful Recharges" + " " + Convert.ToString(TotalAmount);
                    TotalCommission = TotalCommission + Convert.ToDecimal(e.Row.Cells[5].Text);
                    lblTotalProfit.Text = "Total Commission forSuccessful Recharges" + " " + Convert.ToString(TotalCommission);
                }
            }
        }
    }
    protected void gvD2HRecharge_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label4dataCommi.Visible = false;
        Label4D2hComm.Visible = true;
        Label3DEH.Visible = true;
        lblTotalProfit.Visible = false;
        lblTotalAmount.Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "SUCCESS")
            {
                if (TotalAmount == 0)
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0.00";
                    }
                    if (e.Row.Cells[5].Text == "&nbsp;" || e.Row.Cells[5].Text == "")
                    {
                        e.Row.Cells[5].Text = "0.00";
                    }
                    TotalAmount = Convert.ToDecimal(e.Row.Cells[4].Text);
                    Label3DEH.Text = "Total Amount for Successful Recharges" + " " + Convert.ToString(TotalAmount);
                    TotalCommission = Convert.ToDecimal(e.Row.Cells[5].Text);
                    Label4D2hComm.Text = "Total Commission for Successful Recharges" + " " + Convert.ToString(TotalCommission);
                }
                else
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0.00";
                    }
                    if (e.Row.Cells[5].Text == "&nbsp;" || e.Row.Cells[5].Text == "")
                    {
                        e.Row.Cells[5].Text = "0.00";
                    }
                    TotalAmount = TotalAmount + Convert.ToDecimal(e.Row.Cells[4].Text);
                    Label3DEH.Text = "Total Amount for Successful Recharges" + " " + Convert.ToString(TotalAmount);
                    TotalCommission = TotalCommission + Convert.ToDecimal(e.Row.Cells[5].Text);
                    Label4D2hComm.Text = "Total Commission for Successful Recharges" + " " + Convert.ToString(TotalCommission);

                }
            }
        }
    }
    protected void gvDataCardRecharge_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label4dataCommi.Visible = true;
        Label4D2hComm.Visible = false;
        lblTotalProfit.Visible = false;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "SUCCESS")
            {
                if (TotalAmount == 0)
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0";
                    }
                    TotalAmount = Convert.ToDecimal(e.Row.Cells[4].Text);
                    Label4dataCommi.Text = "Total Commission for Successful Recharges" + " " + Convert.ToString(TotalAmount);
                }
                else
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        e.Row.Cells[4].Text = "0";
                    }
                    TotalAmount = TotalAmount + Convert.ToDecimal(e.Row.Cells[4].Text);
                    Label4dataCommi.Text = "Total Commission forSuccessful Recharges" + " " + Convert.ToString(TotalAmount);
                }
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        try
        {
            ChangeControlsToValue(gvMobile);
            //GvFlightsReports.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvMobile.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvMobile);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
          //  GvFlightsReports.Columns[13].Visible = true;
        }
        catch (Exception ex)
        {
            //lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    private void ChangeControlsToValue(Control gridView)
    {
        Literal literal = new Literal();
        for (int i = 0; i < gridView.Controls.Count; i++)
        {
            if (gridView.Controls[i].GetType() == typeof(Button))
            {
                literal.Text = (gridView.Controls[i] as Button).Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(DropDownList))
            {
                literal.Text = (gridView.Controls[i] as DropDownList).SelectedItem.Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(CheckBox))
            {
                literal.Text = (gridView.Controls[i] as CheckBox).Checked ? "True" : "False";
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            if (gridView.Controls[i].HasControls())
            {
                ChangeControlsToValue(gridView.Controls[i]);
            }
        }
    }
}