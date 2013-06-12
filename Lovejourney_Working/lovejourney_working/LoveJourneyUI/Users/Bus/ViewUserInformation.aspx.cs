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


public partial class Users_Bus_ViewUserInformation : System.Web.UI.Page
{
    ClsBAL objBal;
   
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        lblMsg.InnerHtml = "";    
        this.Page.Title = "LoveJourney - Users";
        if (Session["Role"] != null)
        {
            if (!IsPostBack)
            {
                CheckPermission("View Users", Session["Role"].ToString());
                ViewState["SortDirection"] = " ASC";
                getusers();

            }           
        }
        else
        {
            Response.Redirect("~/Default.aspx", false);
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
    protected void getusers()
    {
        try
        {
            objBal = new ClsBAL();
            DataSet ds = objBal.GetAllTYpes("User");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {

                    gvAgents.DataSource = ds.Tables[0];
                    ViewState["Users"] = ds.Tables[0];
                    gvAgents.DataBind();
                }
            }
            else
            {
                lblMsg.InnerHtml = "No Data Found";
            }
           
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void rbtnStatus_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton rbtn = sender as RadioButton;
            //GridViewRow row = (GridViewRow)rbtn.NamingContainer;
            objBal = new ClsBAL();
            string msg = objBal.UpdateAgentStatus(Convert.ToInt32(rbtn.ValidationGroup.ToString()), rbtn.Text);
            lblMsg.InnerText = msg;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
 
    }
    protected void gvAgents_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string strExpression = e.SortExpression;
            string strDirection = ViewState["SortDirection"].ToString();
            DataTable dt =(DataTable)ViewState["Users"];
            DataView dv = new DataView(dt);
            dv.Sort = strExpression + strDirection;
            gvAgents.DataSource = dv;
            gvAgents.DataBind();
            if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void gvAgents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                RadioButton rbtnApproved = (RadioButton)e.Row.FindControl("rbtnApproved");
                RadioButton rbtnHold = (RadioButton)e.Row.FindControl("rbtnHold");
                rbtnApproved.Checked = rbtnHold.Checked = lblStatus.Visible = false;
                if (lblStatus.Text.ToString() == "Approved") 
                { 
                    rbtnApproved.Checked = true; 
                }
                else if (lblStatus.Text.ToString() == "Hold") 
                { 
                    rbtnHold.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void gvAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAgents.PageIndex = e.NewPageIndex;
            gvAgents.DataSource = ViewState["Users"].ToString();
            gvAgents.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

           // lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                getusers();
            }
            else
            {
                if (ViewState["Users"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("AgentName");
                    dtt.Columns.Add("City");
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("EmailId");
                    dtt.Columns.Add("UserName");
                    dtt.Columns.Add("Password");
                    dtt.Columns.Add("Status");
                    dtt.Columns.Add("AgentId");
                    dtt.Columns.Add("UserId");

                    

                    DataTable DtCommission = (DataTable)ViewState["Users"];
                    DataRow[] dr = DtCommission.Select("AgentName like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "City like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "MobileNo like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["AgentName"] = row["AgentName"].ToString();
                            ddd["City"] = row["City"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                            ddd["UserName"] = row["UserName"].ToString();
                            ddd["Password"] = row["Password"].ToString();
                            ddd["Status"] = row["Status"].ToString();
                            ddd["AgentId"] = row["AgentId"].ToString();
                            ddd["UserId"] = row["UserId"].ToString(); 
                            dtt.Rows.Add(ddd);
                        }
                    }
                    if (dtt.Rows.Count > 0)
                    {
                        lbtnXport2Xcel.Enabled = true;
                    }
                    else
                    {
                        lbtnXport2Xcel.Enabled = false;
                    }
                    gvAgents.DataSource = dtt;
                    gvAgents.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvAgents);
            // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvAgents.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvAgents);
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
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           // tdmsg.Visible = false;
            //lblMainMsg.Text = "";
            gvAgents.AllowPaging = true;
            if (ViewState["Feedbacks"] != null)
            {
                if (ddlPageSize.SelectedValue == "0")
                {
                    gvAgents.PageSize = 40;
                    gvAgents.PageIndex = 0;
                    gvAgents.DataSource = ViewState["Feedbacks"];
                    gvAgents.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "1")
                {
                    gvAgents.PageSize = 40;
                    gvAgents.PageIndex = 0;
                    gvAgents.DataSource = ViewState["Feedbacks"];
                    gvAgents.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "2")
                {
                    gvAgents.PageSize = 80;
                    gvAgents.PageIndex = 0;
                    gvAgents.DataSource = ViewState["Feedbacks"];
                    gvAgents.DataBind();
                }
                else if (ddlPageSize.SelectedValue == "3")
                {
                    gvAgents.PageSize = 120;
                    gvAgents.PageIndex = 0;
                    gvAgents.DataSource = ViewState["Feedbacks"];
                    gvAgents.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}