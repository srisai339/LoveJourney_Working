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


public partial class Users_Bus_coorporaterequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
        }


    }
    void BindData()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetAgentRequests2();
            gvEmpRequests.DataSource = ds;

            ViewState["Users1"] = ds;
            gvEmpRequests.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            

            // lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                BindData();

            }
            else
            {
                if (ViewState["Users1"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("CreatedDate");
                    dtt.Columns.Add("Name");
                    dtt.Columns.Add("EmailId");
                  
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("City");
                    dtt.Columns.Add("State");
                   
                  
                    dtt.Columns.Add("Id");
                   





                    DataTable DtCommission = (DataTable)ViewState["Users1"];
                    DataRow[] dr = DtCommission.Select("Name like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "EmailId like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "MobileNo like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "District like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["CreatedDate"] = row["CreatedDate"].ToString();
                            ddd["Name"] = row["Name"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                          
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["City"] = row["City"].ToString();
                            ddd["State"] = row["State"].ToString();
                           

                            ddd["Id"] = row["Id"].ToString();


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

                    gvEmpRequests.DataSource = dtt;
                    gvEmpRequests.DataBind();

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
            ChangeControlsToValue(gvEmpRequests);
            // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Agents.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvEmpRequests.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvEmpRequests);
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