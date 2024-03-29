﻿using System;
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
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class Users_Recharge_DailyReports : System.Web.UI.Page
{

    #region Global Variables
    DataSet _objDataSet;
    clsMasters _objMasters;
    private bool includeGridLines;
    decimal TotalAmount = 0;
    decimal TotalCommission = 0;
    DateTime dt;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
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
                                    
                                   // txtDF.Text = System.DateTime.Now.ToString();
                                    DateTime dateTime = Convert.ToDateTime(System.DateTime.Now.ToString());
                                    string date = dateTime.ToString("dd/MM/yyyy");
                                    txtDF.Text = date.ToString();


                                    MobileRecharge();
                                    tddailyreports.Visible = true;
                                }
                                else
                                {
                                    tdmsg.Visible = true;
                                    tdmsg.Style.Add("background-color:#E77471;", "");
                                    lblMainMsg.Text = "   No Permission to View daily Reports. Please Contact Administrator for further details...";
                                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                    tddailyreports.Visible = false;
                                }
                            }
                            else
                            {
                                tdmsg.Visible = true;
                                tdmsg.Style.Add("background-color:#E77471;", "");
                                lblMainMsg.Text = "   No Permission to View daily Reports. Please Contact Administrator for further details...";
                                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                                tddailyreports.Visible = false;
                            }

                        }
                        else
                        {
                            tdmsg.Visible = true;
                            tdmsg.Style.Add("background-color:#E77471;", "");
                            lblMainMsg.Text = "   No Permission to View daily Reports. Please Contact Administrator for further details...";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tddailyreports.Visible = false;
                        }
                    }
                    else
                    {
                        DateTime dateTime = Convert.ToDateTime(System.DateTime.Now.ToString());
                        string date = dateTime.ToString("dd/MM/yyyy");
                        txtDF.Text = date.ToString();
                        // txtDF.Text = System.DateTime.Now.ToString();
                        MobileRecharge();
                        tddailyreports.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message.ToString();
            }
        }
    }
    protected void CheckPermission()
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Daily Reports";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (ddlservice.SelectedValue == "1")
        //{
            MobileRecharge();
        //}
        //else if (ddlservice.SelectedValue == "2")
        //{
        //    D2HRecharge();
        //}

        //else if (ddlservice.SelectedValue == "3")
        //{
        //    DataCardRecharge();
        //}
    }
    protected void MobileRecharge()
    {
        paging.Visible = false;
        lblMobileMsg.Visible = true;
        gvMobile.Visible = true;
        gvD2HRecharge.Visible = false;
        gvDataCard.Visible = false;
        lblD2HMsg.Visible = false;
        gvMobile.DataSource = null;
        gvMobile.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.DailyReports;
           // _objMasters.Parameter = "Mobile";

            dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
            dt = Convert.ToDateTime(dt.ToShortDateString());
            _objMasters.From12 = Convert.ToDateTime(dt);
            _objDataSet = (DataSet)_objMasters.fnGetData();
            ViewState["MobileData"] = _objDataSet.Tables[0];

            //dt = DateTime.Parse(txtDF.Text, CultureInfo.GetCultureInfo("en-gb"));
            //dt = Convert.ToDateTime(dt.ToShortDateString());
            //txtDF.Text = dt.ToString();


            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                paging.Visible = true;
                gvMobile.DataSource = _objDataSet.Tables[0];
                gvMobile.DataBind();
                gvMobile.Visible = true;
            }
            else
            {
                paging.Visible = false;
                lblMobileMsg.Text = "No Numbers are Recharged on " + txtDF.Text;
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lblD2HMsg.Text = "";
            // lblMobileMsg.Text = "";
            lblDataCardmsg.Text = "";
        }


    }


    protected void D2HRecharge()
    {
        paging.Visible = false;
        lblD2HMsg.Visible = true;
        gvMobile.Visible = false;
        gvDataCard.Visible = false;
        lblMobileMsg.Visible = false;
        gvD2HRecharge.DataSource = null;
        gvD2HRecharge.DataBind();
        lblD2HMsg.Text = string.Empty;
        Label3DEH.Text = string.Empty;
        Label4D2hComm.Text = string.Empty;
        lblTotalProfit.Visible = false;
        try
        {
           
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.DailyReports;
                _objMasters.Parameter = "D2H";
                _objMasters.From12 = Convert.ToDateTime(txtDF.Text.Trim().ToString());
             
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
                lblD2HMsg.Text = "No  recharge has done on " + txtDF.Text ;
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            // lblD2HMsg.Text = "";
            lblMobileMsg.Text = "";
            lblDataCardmsg.Text = "";
        }
    }

    protected void DataCardRecharge()
    {

        paging.Visible = false;
        lblDataCard.Visible = true;
        gvMobile.Visible = false;
        gvD2HRecharge.Visible = false;
        gvDataCard.DataSource = null;
        gvDataCard.DataBind();
        lblMobileMsg.Text = string.Empty;
        lblTotalAmount.Text = string.Empty;
        lblTotalProfit.Text = string.Empty;
        lblTotalProfit.Visible = false;
        try
        {
           
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.DailyReports;
                _objMasters.Parameter = "DataCard";
                _objMasters.From12 = Convert.ToDateTime(txtDF.Text.Trim().ToString());             
                _objDataSet = (DataSet)_objMasters.fnGetData();
                ViewState["DataCardData"] = _objDataSet.Tables[0];
          

            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                paging.Visible = true;
                gvDataCard.DataSource = _objDataSet.Tables[0];
                gvDataCard.DataBind();
                gvDataCard.Visible = true;
            }
            else
            {
                paging.Visible = false;
                lblDataCardmsg.Text = "No numbers are recharged on " + txtDF.Text;
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lblD2HMsg.Text = "";
            lblMobileMsg.Text = "";
            //  lblDataCardmsg.Text = "";
        }
    }
    protected void ddlpagesize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            paging.Visible = true;
            if (ddlpagesize.SelectedIndex == 0)
            {
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();
                gvDataCard.DataSource = ViewState["DataCardData"];
                gvDataCard.DataBind();
            }

            if (ddlpagesize.SelectedValue == "1")
            {

                gvMobile.PageSize = 300;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 300;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCard.PageSize = 300;
                gvDataCard.DataSource = ViewState["DataCardData"];
                gvDataCard.DataBind();


            }
            else if (ddlpagesize.SelectedValue == "2")
            {

                gvMobile.PageSize = 600;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 600;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCard.PageSize = 600;
                gvDataCard.DataSource = ViewState["DataCardData"];
                gvDataCard.DataBind();

            }

            else if (ddlpagesize.SelectedValue == "3")
            {
                gvMobile.PageSize = 900;
                gvMobile.DataSource = ViewState["MobileData"];
                gvMobile.DataBind();

                gvD2HRecharge.PageSize = 900;
                gvD2HRecharge.DataSource = ViewState["D2HData"];
                gvD2HRecharge.DataBind();

                gvDataCard.PageSize = 900;
                gvDataCard.DataSource = ViewState["DataCardData"];
                gvDataCard.DataBind();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvMobile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            gvMobile.PageIndex = e.NewPageIndex;
            gvMobile.DataSource = ViewState["MobileData"];
            gvMobile.DataBind();
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
                    lblTotalAmount.Text = "Total Amount forSuccessful Recharges" + " " + Convert.ToString(TotalAmount);
                    TotalCommission = Convert.ToDecimal(e.Row.Cells[5].Text);
                    lblTotalProfit.Text = "Total Commission forSuccessful Recharges" + " " + Convert.ToString(TotalCommission);


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
                    TotalCommission =TotalCommission+ Convert.ToDecimal(e.Row.Cells[5].Text);
                    lblTotalProfit.Text = "Total Commission forSuccessful Recharges" + " " + Convert.ToString(TotalCommission);
                }
            }
        }
    }
    protected void gvMobile_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable dataTable = (DataTable)ViewState["MobileData"];
            if (gvMobile.Rows.Count >= 0)
            {
                DataView dataview = new DataView(dataTable);

                dataview.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvMobile.DataSource = dataview;
                gvMobile.DataBind();
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
    protected void gvD2HRecharge_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvD2HRecharge_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable dataTable = (DataTable)ViewState["D2HData"];
            if (gvMobile.Rows.Count >= 0)
            {
                DataView dataview = new DataView(dataTable);

                dataview.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvMobile.DataSource = dataview;
                gvMobile.DataBind();
            }
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

            gvD2HRecharge.PageIndex = e.NewPageIndex;
            gvD2HRecharge.DataSource = ViewState["D2HData"];
            gvD2HRecharge.DataBind();
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

            gvDataCard.PageIndex = e.NewPageIndex;
            gvDataCard.DataSource = ViewState["DataCardData"];
            gvDataCard.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void gvDataCard_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvDataCard_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {

            DataTable dataTable = (DataTable)ViewState["DataCardData"];
            if (gvMobile.Rows.Count >= 0)
            {
                DataView dataview = new DataView(dataTable);

                dataview.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvMobile.DataSource = dataview;
                gvMobile.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        
        try
        {
            //ChangeControlsToValue(gvMobile);
           // gvMobile.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=DailyReports.xls");
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
            //GvFlightsReports.Columns[13].Visible = true;
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