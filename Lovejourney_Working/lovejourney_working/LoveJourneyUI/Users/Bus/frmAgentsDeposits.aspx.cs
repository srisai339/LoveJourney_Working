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
public partial class Users_Bus_frmAgentsDeposits : System.Web.UI.Page
{
    ClsBAL objBal; double total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {

                //if (Session["Role"].ToString() == "Admin")
                //{
                CheckPermission("Deposits", Session["Role"].ToString());
                ViewState["SortDirection"] = " ASC";
                Getallagents();
                BindDeposits();
                //}
                //else
                //{
                //    tdmsg.Visible = true; tdmsg.Style.Add("background-color:#E77471;", ""); tblMain.Visible = false;
                //    lblMainMsg.InnerHtml = "  No access permission to this page. Please contact the Administrator for further details. ";
                //}
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            tblMain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                tblMain.Visible = false;

                ClsBAL objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                DataSet objDataSet = (DataSet)objBAL.GetPerByUser();
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
                            tblMain.Visible = true;
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
    protected void Getallagents()
    {
        DataSet ds = GetAgents();
        ddlagentname.DataSource = ds;
        ddlagentname.DataTextField = "Username";
        ddlagentname.DataValueField = "UserId";
        ddlagentname.DataBind();
        ddlagentname.Items.Insert(0, "Please Select");
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
        //if (ddlagentname.SelectedItem.Text == "Please Select")
        //{
        //    ddlagentname.SelectedItem.Text = "";
        //}
        if (ddldeposittype.SelectedItem.Text == "Please Select")
        {
            ddldeposittype.SelectedItem.Text = "";
        }

        ClsBAL obj = new ClsBAL();
        obj.FromDate = Convert.ToDateTime(txtdate.Text);
        obj.ToDate = Convert.ToDateTime(txtrefno.Text);
        obj.name = txtAgents.Text.Trim(); //ddlagentname.SelectedItem.Text;
        obj.type = ddldeposittype.SelectedItem.Text;
        DataSet ds = obj.getDepositsByAdminForAgents();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDeposits.DataSource = ds;
                   // ViewState["Users"] = ds.Tables[0];
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
        //if (ddlagentname.SelectedItem.Text == "")
        //{
        //    ddlagentname.SelectedItem.Text = "Please Select";
        //}
        if (ddldeposittype.SelectedItem.Text == "")
        {
            ddldeposittype.SelectedItem.Text = "Please Select";
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
            string Type=DataBinder.Eval(e.Row.DataItem,"Credit_Debit").ToString();
            if (Type == "Credit")
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            else if(Type=="Debit")
                total = total - Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
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
                if (txtdate.Text == "")
                {
                    txtdate.Text = "1/1/1900";
                }
                if (txtrefno.Text == "")
                {
                    txtrefno.Text = "1/1/1900";
                }

                if (ddldeposittype.SelectedItem.Text == "Please Select")
                {
                    ddldeposittype.SelectedItem.Text = "";
                }

                ClsBAL obj = new ClsBAL();
                obj.FromDate = Convert.ToDateTime(txtdate.Text);
                obj.ToDate = Convert.ToDateTime(txtrefno.Text);
                obj.name = txtAgents.Text.Trim(); //ddlagentname.SelectedItem.Text;
                obj.type = ddldeposittype.SelectedItem.Text;
                DataSet ds = obj.getDepositsByAdminForAgents();

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

    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvDeposits.Rows)
        {
            Label lblDepositedRequestId = (Label)row.FindControl("lblDepositRequestId");
            Label lblAgentId = (Label)row.FindControl("lblAgentId");
            Label lblAmount = (Label)row.FindControl("lblAmount");
            Label lblDepositType = (Label)row.FindControl("lblDepositType");
            Label lblTransactionNumber = (Label)row.FindControl("lblTransactionNumber");
            Label lblDetails = (Label)row.FindControl("lblDetails");
            Label lblDepositBank = (Label)row.FindControl("lblDepositBank");
            Label lblChequeDrawnBank = (Label)row.FindControl("lblChequeDrawnBank");
            Label lblChequeIssueDate = (Label)row.FindControl("lblChequeIssueDate");
            Label lblChequeNo = (Label)row.FindControl("lblChequeNo");
            Label lblStatus = (Label)row.FindControl("lblStatus");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            ClsBAL obj = new ClsBAL();
            DateTime? dtime = null;
            if (lblStatus.Text == "Requested")
            {
                if (lblChequeIssueDate.Text != "")
                {
                    dtime = Convert.ToDateTime(lblChequeIssueDate.Text);
                }
                lblMsg.InnerText = obj.UpdateDepositRequest(Convert.ToInt32(lblAgentId.Text), Convert.ToDouble(lblAmount.Text),
                               lblTransactionNumber.Text, lblDepositType.Text, lblDepositBank.Text, lblChequeDrawnBank.Text, dtime,
                             lblChequeNo.Text, Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(lblDepositedRequestId.Text), lblDetails.Text, ddlStatus.SelectedValue.ToString());
                if (lblMsg.InnerText.ToString() == "Amount has been deposited.")
                {
                    lblMsg.InnerText = lblMsg.InnerText.ToString();
                }

            }

        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAgentNames(string prefixText)
    {
        try
        {


            DataSet ds = new DataSet();

            ClsBAL objBal = new ClsBAL();
            ds = objBal.GetAgents();

            string filteringquery = "Username LIKE'" + prefixText + "%'";
            //Select always return array,thats why we store it into array of Datarow
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            //create new table
            DataTable dtNew = new DataTable();
            //create a clone of datatable dt and store it into new datatable
            dtNew = ds.Tables[0].Clone();
            //fetching all filtered rows add add into new datatable
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }
            //return dtAirportCodes;

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["Username"].ToString().Trim());
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtAgents.Text = "";
        txtdate.Text = "";
        txtrefno.Text = "";
        gvDeposits.Visible = false;

      //  divDeposits.Visible = false;
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvDeposits);
           // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=AgentDeposits.xls");
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