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

public partial class Users_AgentRequests : System.Web.UI.Page
{
    ClsBAL objBal;
    string Userid;
    string role;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Panel pnl = (Panel)this.Master.FindControl("pnlHeader");
        //pnl.Visible = false;
        if (Session["UserID"] != null)
        {
            string page = Request.Url.ToString().ToLower();
           

            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {
                if (page.Contains("agentrequests.aspx"))
                {

                    string url = "MasterPage.master";
                    this.MasterPageFile = url;
                    //  HtmlGenericControl div = (HtmlGenericControl)this.Master.FindControl("divid");                }
                }
            }
           

             else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl1 = (Panel)this.Master.FindControl("pnl");
        pnl1.Visible = false;
        lblMsg.Text = ""; this.Page.Title = "LoveJourney - AgentRequests";
        if (!IsPostBack) 
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    BindData();
                    lbtnBack.Visible =false;
                }
                else if (Session["Role"].ToString() == "BSD")
                {
                    BindData1();
                    lbtnBack.Visible = true;
                }
                else if (Session["Role"].ToString() == "Employee")
                {
                    BindData2();
                    lbtnBack.Visible = false;
                }
                else
                {

                    tdmsg.Visible = true;
                    tdmsg.Style.Add("background-color:#E77471;", "");
                    lblMainMsg.Text = "    No permission to this page. Please contact Administrator for further details.";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    pnlMain.Visible = false;
                    CheckPermission("Agent Requests", Session["Role"].ToString());
                    BindData();
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
            pnlMain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                pnlMain.Visible = false;

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
                            pnlMain.Visible = true;
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
    void BindData()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetAgentRequests();
            gvAgentRequests.DataSource = ds;
            ViewState["Users1"] = ds.Tables[0];
            gvAgentRequests.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    void BindData1()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetAgentRequestFromEmp(Session["UserId"].ToString());
            gvAgentRequestfromemp.DataSource = ds;
            ViewState["Users1"] = ds.Tables[0];
            gvAgentRequestfromemp.DataBind();

            
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    void BindData2()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetAgentRequestFromEmp1(Convert.ToInt32(Session["UserId"]));
            gvAgentrequestfromemp1.DataSource = ds;
            ViewState["Users1"] = ds.Tables[0];
            gvAgentrequestfromemp1.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void gvAgentRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAgentRequests.PageIndex = e.NewPageIndex;
            BindData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void lbtnRegisterAgent_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Bus/Agents.aspx",false);
    }
    protected void lbtnViewAgents_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Bus/Agents.aspx", false);
    }
    protected void lbtnDeposits_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Bus/Agents.aspx", false);
    }
    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvAgentrequestfromemp1);
            // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Agents.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvAgentRequests.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvAgentrequestfromemp1);
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
            lblMsg.Text= ex.Message;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

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
                    dtt.Columns.Add("Organization");
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("City");
                    dtt.Columns.Add("State");
                    dtt.Columns.Add("Comments");
                    dtt.Columns.Add("district");
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
                            ddd["Organization"] = row["Organization"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["City"] = row["City"].ToString();
                            ddd["State"] = row["State"].ToString();
                            ddd["Comments"] = row["Comments"].ToString();
                            ddd["district"] = row["district"].ToString();

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
                    if (Session["Role"].ToString()== "Employee")
                    {
                        gvAgentrequestfromemp1.DataSource = dtt;
                        gvAgentrequestfromemp1.DataBind();

                    }
                    else
                    {
                        gvAgentRequests.DataSource = dtt;
                        gvAgentRequests.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            if (ddlPageSize.SelectedIndex == 0)
            {
                gvAgentRequests.PageSize = 100;
                gvAgentRequests.DataSource = ViewState["Users1"];
                gvAgentRequests.DataBind();
            }
            else if (ddlPageSize.SelectedValue == "1")
            {

                gvAgentRequests.PageSize = 200;
                gvAgentRequests.DataSource = ViewState["Users1"];
                gvAgentRequests.DataBind();
            }

            else if (ddlPageSize.SelectedValue == "2")
            {
                gvAgentRequests.PageSize = 400;
                gvAgentRequests.DataSource = ViewState["Users1"];
                gvAgentRequests.DataBind();

            }
            else if (ddlPageSize.SelectedValue == "3")
            {
                gvAgentRequests.PageSize = 600;
                gvAgentRequests.DataSource = ViewState["Users1"];
                gvAgentRequests.DataBind();

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvAgentRequests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int id = Convert.ToInt32( e.CommandArgument);
            try {
                ClsBAL obj = new ClsBAL();
                DataSet ds = obj.DeleteAgentRequests(id);
                BindData();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
    protected void gvAgentRequestfromemp_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAgentRequestfromemp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Register")
        {

            updaterc(e.CommandArgument.ToString());
           
            mp3.Show();
            divAgentRegistration.Visible = true;
            DataTable dt = GetAgentById(Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
            DataRow dr = dt.Rows[0];

            txtAgentName.Text = dr["Name"].ToString();
            txtEmailId.Text = dr["EmailId"].ToString();
            txtMobileNo.Text = dr["MobileNo"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtPinCode.Text = dr["Pincode"].ToString();
            txtDistrict.Text = dr["District"].ToString();

            ddlState.SelectedValue = ddlState.Items.FindByText(dr["State"].ToString()).Value;
            ddlBSD.SelectedItem.Text = "Agent";
            ddlStatus.SelectedItem.Text = "Approved";
            ddlType.SelectedItem.Text = "Others";
            
         
            




        }
    }

    private void updaterc(string id)
    {
        try
        {
            objBal = new ClsBAL();

            objBal.updaterc(id);
            //ClsBAL obj = new ClsBAL();
            //DataSet ds = obj.GetState(Convert.ToInt32(Session["UserId"]));
            //string str = ds.Tables[0].Rows[0]["State"].ToString();
            //ds = obj.GetStatewiseemprequests(str);
            //gvAgentRequests.DataSource = ds;
            //ViewState["Users1"] = ds.Tables[0];
            //gvAgentRequests.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    DataSet GetAgentById(int id)
    {
        try
        {
            objBal = new ClsBAL();
            return objBal.GetAgentById1(id);
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {

            objBal = new ClsBAL();

            string message = "";
            if (btnRegister.Text == "Register")
            {
                if (txtDateOfBirth.Text == "")
                {
                    txtDateOfBirth.Text = "1/1/1990";
                }
                if (txtCommissionPercentage.Text == "")
                {
                    txtCommissionPercentage.Text = "0";
                }
                if (chkDomesticFlights.Checked == false)
                {
                    lblDomesticFlights.Text = "0";

                }
                else
                {
                    lblDomesticFlights.Text = "1";
                }
                if (chkInternationalFlights.Checked == false)
                {
                    lblInterNationalFlights.Text = "0";
                }
                else
                {
                    lblInterNationalFlights.Text = "1";
                }
                if (chkInternationalFlights.Checked == false)
                {
                    lblInterNationalFlights.Text = "0";
                }
                else
                {
                    lblInterNationalFlights.Text = "1";
                }
                if (chkBuses.Checked == false)
                {
                    lblBuses.Text = "0";
                }
                else
                {
                    lblBuses.Text = "1";

                }
                if (chkHotels.Checked == false)
                {
                    lblHotels.Text = "0";
                }
                else
                {
                    lblHotels.Text = "1";
                }
                if (chkRecharge.Checked == false)
                {
                    lblRecharge.Text = "0";
                }
                else
                {
                    lblRecharge.Text = "1";


                }





                message = objBal.AddAgent(txtAgentName.Text.Trim().ToString(),
                    ddlType.SelectedItem.Text.ToString(),
                    Convert.ToDateTime(txtDateOfBirth.Text.ToString()),
                    txtCity.Text.Trim().ToString(),
                    ddlState.SelectedItem.Text.ToString(),
                    txtAddress.Text.Trim().ToString(),
                    txtPinCode.Text.Trim().ToString(),
                    txtMobileNo.Text.Trim().ToString(),
                    txtAlternateMobileNo.Text.Trim().ToString(),
                    txtLandlineNo.Text.Trim().ToString(),
                    txtEmailId.Text.Trim().ToString(),
                    txtPAN.Text.Trim().ToString(),
                    txtDetails.Text.Trim().ToString(),
                    ddlStatus.SelectedItem.Text.ToString(),

                    txtUsername.Text.Trim().ToString(),
                    txtPassword.Text.Trim().ToString(),
                    Convert.ToInt32(Session["UserID"].ToString()),
                    Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(txtCommissionPercentage.Text.ToString()), ddlBSD.SelectedItem.Text, "",
                    lblDomesticFlights.Text.ToString(),
                    lblInterNationalFlights.Text.ToString(),
                    lblBuses.Text.ToString(),
                    lblHotels.Text.ToString(),
                    lblRecharge.Text.ToString(),
                      txtDistrict.Text.Trim().ToString()

                    );
                if (message == "Agent registration is completed successfully.")
                {
                    lblMsg.Text = "Agent Registration is compleated successfully";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}