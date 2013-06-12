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
public partial class Users_Bus_FundTransferReport : System.Web.UI.Page
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
                if (Session["Role"].ToString() == "Admin")
                {
                    ViewState["SortDirection"] = " ASC";
                    Getallagents();
                    BindDepositRequests();
                }
                else
                {
                    tdmsg.Visible = true; tdmsg.Style.Add("background-color:#E77471;", ""); tblMain.Visible = false;
                    lblMainMsg.InnerHtml = "  No access permission to this page. Please contact the Administrator for further details. ";
                    CheckPermission("Deposits Requests", Session["Role"].ToString());
                    ViewState["SortDirection"] = " ASC";
                    Getallagents();
                    BindDepositRequests();
                }
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
        //DataSet ds = GetAgents();
        //ddlagentname.DataSource = ds;
        //ddlagentname.DataTextField = "Username";
        //ddlagentname.DataValueField = "UserId";
        //ddlagentname.DataBind();
        //ddlagentname.Items.Insert(0, "Please Select");
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
    void BindDepositRequests()
    {
        if (txtdate.Text == "")
        {
            txtdate.Text = "1/1/1900";
        }
        if (txtrefno.Text == "")
        {
            txtrefno.Text = "1/1/1900";
        }
        //if(ddlagentname.SelectedItem.Text == "Please Select")
        //{
        //    ddlagentname.SelectedItem.Text = "";
        //}
        if (ddldeposittype.SelectedItem.Text == "Please Select")
        {
            ddldeposittype.SelectedItem.Text = "";
        }

        ClsBAL obj = new ClsBAL();
        obj.FromDate =Convert.ToDateTime(txtdate.Text);
        obj.ToDate = Convert.ToDateTime(txtrefno.Text);
        obj.name = ddlagentname.Text;
        obj.type = ddldeposittype.SelectedItem.Text;
        DataSet ds = obj.getDepositrequestsforseach();
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
                    btnUpdateStatus.Visible = true;
                }
                else
                {
                    btnUpdateStatus.Visible = false;
                    trpaging.Visible = false;
                    lblerrormsg.Text = "No Data Found";
                    lblerrormsg.ForeColor = System.Drawing.Color.Red;
                    lblerrormsg.Visible = true;
                    gvDeposits.Visible = false;
                }
            }
            else
            {
                btnUpdateStatus.Visible = false;
                trpaging.Visible = false;
                lblerrormsg.Text = "No Data Found";
                lblerrormsg.ForeColor = System.Drawing.Color.Red;
                lblerrormsg.Visible = true;
                gvDeposits.Visible = false;
            }
        }
        else
        {
            btnUpdateStatus.Visible = false;
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
        BindDepositRequests();
    }
    protected void gvDeposits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DepositAmount"));
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                if (lblStatus.Text == "Deposited")
                {
                    lblStatus.Visible = true;
                    ddlStatus.Visible = false;
                }
                else
                {

                    lblStatus.Visible = false;
                    ddlStatus.Visible = true;
                }


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("lblTotal");
                lblamount.Text = total.ToString();
            }
        }
    }
    protected void gvDeposits_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gvDeposits.PageIndex = e.NewPageIndex;
            BindDepositRequests();
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
                objBal = new ClsBAL();
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
                DataSet ds = objBal.getDepositrequestsforseach();
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
            Label lblDepositedRequestId  =  (Label)row.FindControl("lblDepositRequestId");
            Label lblAgentId = (Label)row.FindControl("lblAgentId");
            Label lblAgentname = (Label)row.FindControl("lblAgentname");
            Label lblemailId = (Label)row.FindControl("lblemailId");

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

                if (ddlStatus.SelectedValue == "Deposited")
                {
                    if (lblChequeIssueDate.Text != "")
                    {
                        dtime = Convert.ToDateTime(lblChequeIssueDate.Text);
                    }
                    lblMsg.InnerText = obj.UpdateDepositRequest(Convert.ToInt32(lblAgentId.Text), Convert.ToDouble(lblAmount.Text),
                                   lblTransactionNumber.Text, lblDepositType.Text, lblDepositBank.Text, lblChequeDrawnBank.Text, dtime,
                                 lblChequeNo.Text, Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(lblDepositedRequestId.Text), lblDetails.Text, ddlStatus.SelectedValue.ToString());

                    //System.Data.DataSet ds = objBal.GetAgentById(Convert.ToInt32(lblAgentId.Text));

                    //DeductAgentBalance(Convert.ToInt32(lblAgentId.Text), Convert.ToDouble(0.00),
                    //                   Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"].ToString()), lblDepositType.Text, Convert.ToDouble(lblAmount.Text.ToString()),
                    //                   Convert.ToDouble(0.00), Convert.ToInt32(0.00));


                    objBal = new ClsBAL();
                    DataSet ds = objBal.GetAgentDeposits(Convert.ToInt32(lblAgentId.Text));
                    string Userid = ds.Tables[0].Rows[0]["UserId"].ToString();

                    DeductAgentBalance(Convert.ToInt32(lblAgentId.Text), Convert.ToDouble(0.00),
                             Convert.ToInt32(Userid), lblDepositType.Text, Convert.ToDouble(lblAmount.Text),
                             Convert.ToDouble(0.00), Convert.ToInt32(0.00));


                    if (lblMsg.InnerText.ToString() == "Amount has been deposited.")
                    {
                        lblMsg.InnerText = lblMsg.InnerText.ToString();
                        BindDepositRequests();


                        #region
                        string Body = "Hello <b>" + lblAgentname.Text + "</b>," +
                            "<br /><br />Let us welcome you  with lovejourney.in " +
                            "Following are your Added Balance details. <br/> <br/>" +
                            "Email ID :<b><b>" + lblemailId.Text.Trim() + "</b><br />" +
                            "Added Amount:<b><b>" + lblAmount.Text + "</b><br />" +

                            "<br /><br />We thank you for registering with  lovejourney.in and please " +
                            "do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail </a><b> " +
                            "should you have any questions. <br /><br />Best Regards, <br />Administrator<br /> <a href='http://lovejourney.in'> lovejourney.in</a>" +
                            "<br /><br />";
                        MailSender.SendEmail(lblemailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-Deposit", Body);
                        #endregion


                    }
                }
                //lblStatus.Visible = false;
                //ddlStatus.Visible = true;
            }
            //else
            //{
            //    lblStatus.Visible = true;
            //    ddlStatus.Visible = false;
            //}
        }
    }

    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare, double commisionFare, int commisionPercentage)
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            return objBAL.DeductAgentBalance(agentId, deductAmount, createdBy, mbRefNo,
                actualFare, commisionFare, commisionPercentage);
        }
        catch (Exception ex)
        {
            throw ex;
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
        txtdate.Text = "";
        txtrefno.Text = "";
        ddlagentname.Text = "";
        ddldeposittype.ClearSelection();
        gvDeposits.Visible = false;
        
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvDeposits);
           // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
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