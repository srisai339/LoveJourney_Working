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

public partial class Users_Recharge_frmVisitors : System.Web.UI.Page
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

                                //txtDF.Text = System.DateTime.Now.ToString();
                                //txtDT.Text = System.DateTime.Now.ToString();
                                ddlservice.SelectedValue = "1";
                                MobileRecharge();
                                tblpendingRepports.Visible = true;
                            }
                            else
                            {
                                tdmsg.Visible = true;
                                tdmsg.Style.Add("background-color:#E77471;", "");
                                lblMainMsg.Text = "   No Permission to View pending Reports. Please Contact Administrator for further details...";
                                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                tblpendingRepports.Visible = false;
                            }
                        }
                        else
                        {
                            tdmsg.Visible = true;
                            tdmsg.Style.Add("background-color:#E77471;", "");
                            lblMainMsg.Text = "   No Permission to View pending Reports. Please Contact Administrator for further details...";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tblpendingRepports.Visible = false;
                        }

                    }
                    else
                    {
                        tdmsg.Visible = true;
                        tdmsg.Style.Add("background-color:#E77471;", "");
                        lblMainMsg.Text = "   No Permission to View pending Reports. Please Contact Administrator for further details...";
                        lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                        tblpendingRepports.Visible = false;
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
                    MobileRecharge();
                    tblpendingRepports.Visible = true;
                }
            }
        }

        else
        {
            Response.Redirect("~/Default.aspx", false);
        }
        
        
    }
    protected void CheckPermission()
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Penidng Reports";
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
        paging.Visible = false;
        gvMobile.DataSource = null;
        gvMobile.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;
        lblD2HMsg.Text = "";

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
             
                _objMasters.ScreenInd = Masters.VisitorsReport;
                _objMasters.From12 = Convert.ToDateTime(dt.ToString());
                _objMasters.To12 = Convert.ToDateTime(dt1.ToString());
               // _objMasters.UserID = Convert.ToInt32(Session["RechargeUserID"]);


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

    public void D2HRecharge()
    {
        paging.Visible = false;
       // gvD2HRecharge.DataSource = null;
      //  gvD2HRecharge.DataBind();
        lblD2HMsg.Text = string.Empty;


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
                gvD2HRecharge.Visible = false;
                return;
            }
            else
            {
              
                _objMasters.ScreenInd = Masters.VisitorsReportd2h;
                _objMasters.From12 = Convert.ToDateTime(dt.ToString());
                _objMasters.To12 = Convert.ToDateTime(dt1.ToString());
               // _objMasters.UserID = Convert.ToInt32(Session["RechargeUserID"]);
                _objMasters.Parameter = "D2H";
              
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["D2HData"] = _objDataSet.Tables[0];


                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    paging.Visible = true;
                    gvD2HRecharge.Visible = true;
                    gvD2HRecharge.DataSource = _objDataSet.Tables[0];
                    gvD2HRecharge.DataBind();
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
        paging.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblDataCardmsg.Text = string.Empty;
        lblD2HMsg.Text = ""; lblMobileMsg.Text = "";

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
              
                _objMasters.ScreenInd = Masters.VisitorsReportDatacard;
                _objMasters.From12 = Convert.ToDateTime(dt.ToString());
                _objMasters.To12 = Convert.ToDateTime(dt1.ToString());
                _objMasters.Parameter = "DataCard";
               // _objMasters.UserID = Convert.ToInt32(Session["RechargeUserID"]);
               
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

            if (ddlservice.SelectedValue == "1")
            {
                gvMobile.Visible = true;
                gvDataCardRecharge.Visible = false;
                gvD2HRecharge.Visible = false;
                MobileRecharge();
            }
            else if (ddlservice.SelectedValue == "2")
            {
                gvD2HRecharge.Visible = true;
                gvMobile.Visible = false;
                gvDataCardRecharge.Visible = false;
                D2HRecharge();
            }

            else if (ddlservice.SelectedValue == "3")
            {
                gvDataCardRecharge.Visible = true;
                gvMobile.Visible = false;
                gvD2HRecharge.Visible = false;
                DataCardRecharge();
            }
            else if (ddlservice.SelectedValue == "4")
            {
                gvMobile.Visible = true;
                gvDataCardRecharge.Visible = false;
                gvD2HRecharge.Visible = false;
                MobileRecharge();
             
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
               
                //gvMobile.DataSource = ViewState["MobileData"];
                //gvMobile.DataBind();

              
                //gvD2HRecharge.DataSource = ViewState["D2HData"];
                //gvD2HRecharge.DataBind();

              
                //gvDataCardRecharge.DataSource = ViewState["DataCardData"];
                //gvDataCardRecharge.DataBind();
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