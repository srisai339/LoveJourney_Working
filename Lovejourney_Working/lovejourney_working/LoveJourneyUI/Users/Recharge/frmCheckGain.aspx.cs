using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using System.Data;
using BAL;
using System.Drawing;
using System.Globalization;

public partial class Users_Recharge_frmCheckGain : System.Web.UI.Page
{
    #region Global Variables
    DataSet _objDataSet;
    clsMasters _objMasters;
    private bool includeGridLines;
    DateTime dt; DateTime dt1;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                if (Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor")
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
                    MobileRecharge();
                }
                else if (Session["Role"].ToString() == "Admin")
                {

                }
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    #region FUNCTIONS


    public void MobileRecharge()
    {
        paging.Visible = false;
        gvMobile.DataSource = null;
        gvMobile.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;


        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = true;

        lblD2HMsg.Visible = false;
        lblDataCardmsg.Visible = false;
        lblMobileMsg.Visible = true;


        try
        {
            _objMasters = new clsMasters();
            dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt = Convert.ToDateTime(dt.ToShortDateString());

            dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt1 = Convert.ToDateTime(dt1.ToShortDateString());

            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblMobileMsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
                
                _objMasters.ScreenInd = Masters.GetMRDBySearch;
                _objMasters.From = dt.ToString();
                _objMasters.To = dt1.ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
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
                    lblMobileMsg.Visible = true;
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

        lblD2HMsg.Visible = true;
        lblDataCardmsg.Visible = false;
        lblMobileMsg.Visible = false;

        paging.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblD2HMsg.Text = string.Empty;


        gvD2HRecharge.Visible = true;
        gvDataCardRecharge.Visible = false;
        gvMobile.Visible = false;


        try
        {
            _objMasters = new clsMasters();
            dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt = Convert.ToDateTime(dt.ToShortDateString());

            dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt1 = Convert.ToDateTime(dt1.ToShortDateString());

            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblD2HMsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
              
                _objMasters.ScreenInd = Masters.GetD2HBySearch;
                _objMasters.From = dt.ToString();
                _objMasters.To = dt1.ToString();
                _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                if (ddlservice.SelectedValue == "2")
                {
                    _objMasters.Parameter = "DTH";
                }
                else if (ddlservice.SelectedValue == "4")
                {
                    _objMasters.Parameter = "ALL";
                }

                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["D2HData"] = _objDataSet.Tables[0];


                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvD2HRecharge.DataSource = _objDataSet.Tables[0];
                    gvD2HRecharge.DataBind();
                    gvD2HRecharge.Visible = true;
                }
                else
                {
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

        lblD2HMsg.Visible = false;
        lblDataCardmsg.Visible = true;
        lblMobileMsg.Visible = false;


        paging.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblDataCardmsg.Text = string.Empty;

        gvD2HRecharge.Visible = false;
        gvDataCardRecharge.Visible = true;
        gvMobile.Visible = false;


        try
        {
            _objMasters = new clsMasters();
            dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt = Convert.ToDateTime(dt.ToShortDateString());

            dt1 = DateTime.Parse(txtDT.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt1 = Convert.ToDateTime(dt1.ToShortDateString());

            if (DateTime.Parse(dt.ToString()) > DateTime.Parse(dt1.ToString()))
            {
                lblDataCardmsg.Text = "From Date should be less than To Date";
                return;
            }
            else
            {
              
                _objMasters.ScreenInd = Masters.GetD2HBySearch;
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
        catch(Exception ex)

        {
            throw ex;
        }
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
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
            else if(ddlservice.SelectedValue == "4")
            {
                D2HRecharge();
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
            gvMobile.DataSource = ViewState["D2HData"];
            gvD2HRecharge.DataBind();
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
            gvMobile.DataSource = ViewState["DataCardData"];
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


}
