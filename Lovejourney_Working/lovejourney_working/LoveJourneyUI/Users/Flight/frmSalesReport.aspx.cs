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
using System.Globalization;
using System.Web.UI.HtmlControls;


public partial class Users_Flight_frmSalesReport : System.Web.UI.Page
{
     double total = 0; double CommFare = 0;
    DataSet objDataSet;
    ClsBAL objBAL;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
                CheckPermission("FlightsSalesReports", Session["Role"].ToString());
          
            ViewState["SortDirection"] = " ASC";

            BindDeposits();

        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            panelBookingStatus.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblmsg1.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblmsg1.ForeColor = System.Drawing.Color.Maroon;
                panelBookingStatus.Visible = false;

                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                objDataSet = (DataSet)objBAL.GetPerByUser();
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
                            panelBookingStatus.Visible = true;
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

    void BindDeposits()
    {
        if (txtdate.Text == "")
        {
            txtdate.Text = "1/1/1900";
        }
        if (txtrefno.Text == "")
        {
            txtrefno.Text = "1/1/1900";
        }


        FlightBAL obj = new FlightBAL();
        obj.FromDate = Convert.ToDateTime(txtdate.Text);
        obj.ToDate = Convert.ToDateTime(txtrefno.Text);
        obj.agentId = Convert.ToInt32(Session["UserId"]);
        DataSet ds = obj.GetFlightSalesReport();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDeposits.DataSource = ds;
                    gvDeposits.DataBind();
                    ViewState["gv"] = ds;
                    trpaging.Visible = true;
                    lblerrormsg.Visible = false;
                    gvDeposits.Visible = true;
                }
                else
                {
                    trpaging.Visible = false;
                    lblerrormsg.Text = "No Data Found";
                    lblerrormsg.ForeColor = System.Drawing.Color.Red;
                    lblerrormsg.Visible = true;
                    gvDeposits.Visible = false;
                }
            }
            else
            {
                trpaging.Visible = false;
                lblerrormsg.Text = "No Data Found";
                lblerrormsg.ForeColor = System.Drawing.Color.Red;
                lblerrormsg.Visible = true;
                gvDeposits.Visible = false;
            }
        }
        else
        {
            trpaging.Visible = false;
            lblerrormsg.Text = "No Data Found";
            lblerrormsg.ForeColor = System.Drawing.Color.Red;
            lblerrormsg.Visible = true;
            gvDeposits.Visible = false;
        }
        if (txtdate.Text == "1/1/1900")
        {
            txtdate.Text = "";
        }
        if (txtrefno.Text == "1/1/1900")
        {
            txtrefno.Text = "";
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        BindDeposits();
    }
    protected void gvDeposits_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AgentAmount"));
            CommFare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CommisionFare"));
            //Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            //DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            //if (lblStatus.Text == "Deposited")
            //{
            //    lblStatus.Visible = true;
            //    ddlStatus.Visible = false;
            //}
            //else
            //{

            //    lblStatus.Visible = false;
            //    ddlStatus.Visible = true;
            //}


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblamount = (Label)e.Row.FindControl("lblTotal");
            lblamount.Text = total.ToString();

            Label lblCommisionFareTotal = (Label)e.Row.FindControl("lblCommisionFareTotal");
            lblCommisionFareTotal.Text = CommFare.ToString();
        }
    }
    protected void gvDeposits_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gvDeposits.PageIndex = e.NewPageIndex;
            BindDeposits();
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void gvDeposits_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            try
            {
                string strExpression = e.SortExpression;
                string strDirection = ViewState["SortDirection"].ToString();
                objBAL = new ClsBAL();
                if (txtdate.Text == "")
                {
                    txtdate.Text = "1/1/1900";
                }
                if (txtrefno.Text == "")
                {
                    txtrefno.Text = "1/1/1900";
                }
                objBAL.FromDate = Convert.ToDateTime(txtdate.Text);
                objBAL.ToDate = Convert.ToDateTime(txtrefno.Text);
                DataSet ds = objBAL.getDepositrequestsforseach();
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = strExpression + strDirection;
                gvDeposits.DataSource = dv;
                gvDeposits.DataBind();
                if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }

                if (txtdate.Text == "1/1/1900")
                {
                    txtdate.Text = "";
                }
                if (txtrefno.Text == "1/1/1900")
                {
                    txtrefno.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblMsg.InnerHtml = ex.Message;
                throw;
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void ddlpaging_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblpaging.Visible = true;


            if (ddlpaging.SelectedIndex == 0)
            {
                gvDeposits.DataSource = ViewState["gv"];
                gvDeposits.DataBind();
            }
            else if (ddlpaging.SelectedValue == "1")
            {

                gvDeposits.PageSize = 40;
                gvDeposits.DataSource = ViewState["gv"];
                gvDeposits.DataBind();
            }

            else if (ddlpaging.SelectedValue == "2")
            {
                gvDeposits.PageSize = 80;
                gvDeposits.DataSource = ViewState["gv"];
                gvDeposits.DataBind();

            }
            else if (ddlpaging.SelectedValue == "3")
            {
                gvDeposits.PageSize = 120;
                gvDeposits.DataSource = ViewState["gv"];
                gvDeposits.DataBind();

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
            ChangeControlsToValue(gvDeposits);
           // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=SalesReport.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvDeposits.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvDeposits);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
            //gvDeposits.Columns[13].Visible = true;
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