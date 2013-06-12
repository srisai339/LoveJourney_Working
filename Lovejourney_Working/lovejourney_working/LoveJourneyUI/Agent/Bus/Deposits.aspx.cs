using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Text;
using System.Xml;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Web.UI.HtmlControls;
using iTextSharp.text.html.simpleparser;



public partial class Agent_Deposits : System.Web.UI.Page
{
    ClsBAL objBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }


        this.Page.Title = "LoveJourney - Deposits";
        if (!IsPostBack)
        {
            ViewState["SortDirection"] = " ASC";
            BindDeposits();
            //Menu men = (Menu) this.Master.FindControl("Menu2");
            //foreach (MenuItem item in men.Items)
            //{
            //    if (item.Text == "Deposits")
            //    {
            //        item.Enabled = false;
            //    }
            //    else { item.Enabled = true; }
            //}

          //  Table men1 = this.FindControl("Content2").FindControl("Menu1") as Table;                                
            Panel men1 = (Panel)this.Master.FindControl("Menu1");
            men1.Visible = false;
           

            
        }
        lblMsg.InnerText = "";
    }
    void BindDeposits()
    {
        if (Session["UserID"] != null)
        {
            objBal = new ClsBAL();
            DataSet ds = objBal.GetAgentDepositsByUserId(Convert.ToInt32(Session["UserID"].ToString()));
            gvDeposits.DataSource = ds;
            gvDeposits.DataBind();
        }
        else { Response.Redirect("~/Default.aspx", false); }
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
            string strExpression = e.SortExpression;
            string strDirection = ViewState["SortDirection"].ToString();
            objBal = new ClsBAL();
            DataSet ds = objBal.GetAgentDepositsByUserId(Convert.ToInt32(Session["UserID"].ToString()));
            DataTable dt = ds.Tables[0];
            DataView dv = new DataView(dt);
            dv.Sort = strExpression + strDirection;
            gvDeposits.DataSource = dv;
            gvDeposits.DataBind();
            if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    double total = 0;
    protected void gvDeposits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Type = DataBinder.Eval(e.Row.DataItem, "Credit_Debit").ToString();
                if(Type=="Credit")
                    total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                else if(Type=="Debit")
                    total -= Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                Label lblAmount1 = (Label)e.Row.FindControl("lblAmount");
                lblAmount1.Text = Convert.ToDouble(lblAmount1.Text).ToString("####0.00");
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("lblTotal");
                lblamount.Text = total.ToString("####0.00");
            }
        }
    }
    protected void lbtnDeposits_Click(object sender, EventArgs e)
    {
        divDepositUpdateRequest.Visible = false; divDeposits.Visible = true; divDepositProcess.Visible = false;
        lbtnDeposits.Font.Bold = true; lbtnDepositUpdateRequest.Font.Bold = false; lbtnDepositProcess.Font.Bold = false;
        tdhead.Visible = false; tdheading.Visible = true;

    }
    protected void lbtnDepositUpdateRequest_Click(object sender, EventArgs e)
    {
        tdhead.Visible = false;
        divDepositUpdateRequest.Visible = true; divDeposits.Visible = false; divDepositProcess.Visible = false;
        lbtnDeposits.Font.Bold = false; lbtnDepositUpdateRequest.Font.Bold = true; lbtnDepositProcess.Font.Bold = false;
        tdhead.Visible = true; tdheading.Visible = false;

        txtDepositAmount.Text = txtMobileNumber.Text = txtTransactionId.Text = txtChequeNumber.Text = txtChequeIssueDate.Text = txtChequeDrawnBank.Text = "";
        ddlDepositedBank.SelectedIndex = 0;
        BindDepositRequests();

    }
    protected void lbtnDepositProcess_Click(object sender, EventArgs e)
    {
        divDepositUpdateRequest.Visible = false; divDeposits.Visible = false; divDepositProcess.Visible = true;
        lbtnDeposits.Font.Bold = false; lbtnDepositUpdateRequest.Font.Bold = false; lbtnDepositProcess.Font.Bold = true;
    }
    protected void btnDepositUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                ClsBAL obj = new ClsBAL();
                DateTime? dtime = null;
                if (txtChequeIssueDate.Text != "")
                {
                    dtime = Convert.ToDateTime(txtChequeIssueDate.Text.ToString());
                }
                lblMsg.InnerText = obj.InsertDepositUpdateRequest(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDouble(txtDepositAmount.Text.Trim().ToString()),
                    Convert.ToString(txtMobileNumber.Text.ToString()), txtTransactionId.Text.ToString(), rbtnDepositType.SelectedItem.Text.ToString(),
                    ddlDepositedBank.SelectedItem.Text.ToString(), txtChequeDrawnBank.Text.ToString(), dtime,
                    txtChequeNumber.Text.ToString(), Convert.ToInt32(Session["UserID"].ToString()),"Requested");
                if (lblMsg.InnerText.ToString() == "Your request has been submitted successfully. Our Team will get back to you.")
                {
                    txtDepositAmount.Text = txtMobileNumber.Text = txtTransactionId.Text = txtChequeNumber.Text = txtChequeIssueDate.Text = txtChequeDrawnBank.Text = "";
                    ddlDepositedBank.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
 protected   void BindDepositRequests()
    {
        //if (txtdate.Text == "")
        //{
        //    txtdate.Text = "1/1/1900";
        //}
        //if (txtrefno.Text == "")
        //{
        //    txtrefno.Text = "1/1/1900";
        //}
        //if (ddlagentname.SelectedItem.Text == "Please Select")
        //{
        //    ddlagentname.SelectedItem.Text = "";
        //}
        //if (ddldeposittype.SelectedItem.Text == "Please Select")
        //{
        //    ddldeposittype.SelectedItem.Text = "";
        //}

        ClsBAL obj = new ClsBAL();
        obj.FromDate = Convert.ToDateTime("1/1/1900");
        obj.ToDate = Convert.ToDateTime("1/1/1900");
        obj.name = Session["UserName"].ToString();
        obj.type = "";
        DataSet ds = obj.getDepositrequestsforseach();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {                 
                  
                    GridView1.DataSource = GetTopNRows(ds.Tables[0], 5); 
                    GridView1.DataBind();
                    ViewState["gv"] = ds;

                    GridView1.Visible = true;
                }
                else
                {
                    //trpaging.Visible = false;
                    //lblerrormsg.Text = "No Data Found";
                    //lblerrormsg.ForeColor = System.Drawing.Color.Red;
                    //lblerrormsg.Visible = true;
                    GridView1.Visible = false;
                }
            }
            else
            {
                //trpaging.Visible = false;
                //lblerrormsg.Text = "No Data Found";
                //lblerrormsg.ForeColor = System.Drawing.Color.Red;
                //lblerrormsg.Visible = true;
                GridView1.Visible = false;
            }
        }
        else
        {
            //trpaging.Visible = false;
            //lblerrormsg.Text = "No Data Found";
            //lblerrormsg.ForeColor = System.Drawing.Color.Red;
            //lblerrormsg.Visible = true;
            gvDeposits.Visible = false;
        }
        //if (txtdate.Text == "1/1/1900")
        //{
        //    txtdate.Text = "";
        //}
        //if (txtrefno.Text == "1/1/1900")
        //{
        //    txtrefno.Text = "";
        //}
        //if (ddlagentname.SelectedItem.Text == "")
        //{
        //    ddlagentname.SelectedItem.Text = "Please Select";
        //}
        //if (ddldeposittype.SelectedItem.Text == "")
        //{
        //    ddldeposittype.SelectedItem.Text = "Please Select";
        //}
    }

 public DataTable GetTopNRows(DataTable dt, int n)
 {
     DataTable result = dt.Clone();
     for (int i = 0; i < n; i++)
     {
         if(dt.Rows.Count > i)
         {
         result.ImportRow(dt.Rows[i]);
         }
     }
     return result;
 }
 protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
 {
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DepositAmount"));
             Label lblStatus = (Label)e.Row.FindControl("lblStatus");
             Label ddlStatus = (Label)e.Row.FindControl("ddlStatus");
             Label lblAmount1 = (Label)e.Row.FindControl("lblAmount");
             lblAmount1.Text =Convert.ToDouble(lblAmount1.Text).ToString("####0.00");
             if (lblStatus.Text == "Deposited")
             {
                 lblStatus.Visible = false;
                 ddlStatus.Visible = true;
                 ddlStatus.Text = "Approved";
                 ddlStatus.ForeColor = System.Drawing.Color.Green;
             }
             else
             {

                 lblStatus.Visible = false;
                 ddlStatus.Visible = true;
                 ddlStatus.Text = "Pending";
                 ddlStatus.ForeColor = System.Drawing.Color.Red;
             }


         }
         if (e.Row.RowType == DataControlRowType.Footer)
         {
             Label lblamount = (Label)e.Row.FindControl("lblTotal");
             lblamount.Text = total.ToString("####0.00");
         }
     }
 }
    protected void rbtnDepositType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDepositAmount.Text = txtMobileNumber.Text = txtTransactionId.Text =
        txtChequeNumber.Text = txtChequeIssueDate.Text = txtChequeDrawnBank.Text = "";
        ddlDepositedBank.SelectedIndex = 0;

        r1.Visible = r2.Visible = r3.Visible = c1.Visible = false;

        if (rbtnDepositType.SelectedItem.Text == "Cheque" || rbtnDepositType.SelectedItem.Text == "NetTransfer")
        {
            lbldeposit.Text = "Amount";
            lblbank.Text = "Transfered To";
            if (rbtnDepositType.SelectedItem.Text == "NetTransfer")
            {
                trnsferedfrom.Visible = true;
            }

        }
        else
        {
            lbldeposit.Text = "Deposited Amount";
        }

        if (rbtnDepositType.SelectedItem.Text == "Cheque")
        {
            lblChequeBank.Visible = lblChequeIssueDate.Visible = lblChequeNumber.Visible = true;
            txtChequeDrawnBank.Visible = txtChequeIssueDate.Visible = txtChequeNumber.Visible = true;
            r1.Visible = r2.Visible = r3.Visible = c1.Visible = true;
            ImageButton2.Visible = true;
            trtransid.Visible = false;
            rfv.Visible = false;
        }
        else
        {
            lblChequeBank.Visible = lblChequeIssueDate.Visible = lblChequeNumber.Visible = false;
            txtChequeDrawnBank.Visible = txtChequeIssueDate.Visible = txtChequeNumber.Visible = false;
            ImageButton2.Visible = false;
            trtransid.Visible = true;
            rfv.Visible = true;
        }
    }
    protected void lnlaxisbank_Click(object sender, EventArgs e)
    {
        try
        {

            //  GetDetailsForPrint(Refno);
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=AxisbankpayinSlip.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pnlaxis.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing

        }
    }
    protected void lnksbi_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Agent/Bus/SBIPaySlip.aspx?Name=" + Session["Name"].ToString() + "&Code=" + Session["UserName"].ToString(), false);
        //try
        //{

        //    //  GetDetailsForPrint(Refno);
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=SBIpayinSlip.doc");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-word";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    pnlsbi.RenderControl(hw);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();


        //}
        //catch (System.Threading.ThreadAbortException lException)
        //{

        //    // do nothing

        //}

        ClsBAL objBAL = new ClsBAL();
        System.Data.DataSet ds = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
        Session["Name"] = ds.Tables[0].Rows[0]["AgentName"].ToString();
        Response.Redirect("~/Agent/Bus/SBIPaySlip.aspx?Name=" + Session["Name"].ToString() + "&Code=" + Session["UserName"].ToString(), false);
    }
   
    protected void lnkAxis_Click(object sender, EventArgs e)
    {
        ClsBAL objBAL = new ClsBAL();
        System.Data.DataSet ds = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
        Session["Name"] = ds.Tables[0].Rows[0]["AgentName"].ToString();

        Response.Redirect("~/Agent/Bus/AxisBankPaySlip.aspx?Name=" + Session["Name"].ToString() + "&Code=" + Session["UserName"].ToString(), false);
    }
    protected void lnkICICI_Click(object sender, EventArgs e)
    {
        ClsBAL objBAL = new ClsBAL();
        System.Data.DataSet ds = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
        Session["Name"] = ds.Tables[0].Rows[0]["AgentName"].ToString();
        Response.Redirect("~/Agent/Bus/ICICIBankPaySlip.aspx?Name=" + Session["Name"].ToString() + "&Code=" + Session["UserName"].ToString(), false);
    }
}