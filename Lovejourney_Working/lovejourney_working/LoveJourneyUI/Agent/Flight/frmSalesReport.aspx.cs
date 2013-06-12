using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;


public partial class Agent_Flight_frmSalesReport : System.Web.UI.Page
{
    ClsBAL objBal; double total = 0; double CommFare = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["SortDirection"] = " ASC";
        
            BindDeposits();

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
                FlightBAL objBal = new FlightBAL();
                
                if (txtdate.Text == "")
                {
                    txtdate.Text = "1/1/1900";
                }
                if (txtrefno.Text == "")
                {
                    txtrefno.Text = "1/1/1900";
                }
                objBal.FromDate = Convert.ToDateTime(txtdate.Text);
                objBal.ToDate = Convert.ToDateTime(txtrefno.Text);
                DataSet ds = objBal.GetFlightSalesReport();
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

   
}