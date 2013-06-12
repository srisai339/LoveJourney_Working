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

public partial class Users_Bus_EmpRequests : System.Web.UI.Page
{
    ClsBAL objBal;
    string Userid;
    string role;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            Panel pnl = (Panel)this.Master.FindControl("pnl"); ;
            pnl.Visible = false;
        }
    }
    void BindData()
    {
        try
        {
            if (Session["Role"].ToString() == "Admin")
            {
                ClsBAL obj = new ClsBAL();
                DataSet ds = obj.GetEmpRequests();
                gvAgentRequests.DataSource = ds;
                ViewState["Users1"] = ds.Tables[0];
                gvAgentRequests.DataBind();
            }
            else if (Session["Role"].ToString() == "BSD")
            {
                ClsBAL obj = new ClsBAL();
                DataSet ds = obj.GetState(Convert.ToInt32(Session["UserId"]));
                string str = ds.Tables[0].Rows[0]["State"].ToString();
                ds = obj.GetStatewiseemprequests(str);
                gvAgentRequests.DataSource = ds;
                ViewState["Users1"] = ds.Tables[0];
                gvAgentRequests.DataBind();

                
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string filePath = gvAgentRequests.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }

    protected void lnkDownload1_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn1 = sender as LinkButton;
        GridViewRow gvrow = lnkbtn1.NamingContainer as GridViewRow;
        string filePath = gvAgentRequests.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }

   

    protected void gvAgentRequests_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAgentRequests_RowCommand(object sender, GridViewCommandEventArgs e)
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

            ddlState.SelectedValue = ddlState.Items.FindByText(dr["State"].ToString()).Value;
            ddlBSD.SelectedItem.Text = "Employee";
            ddlStatus.SelectedItem.Text = "Approved";
            ddlType.SelectedItem.Text = "Others";
           
         
            


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
            lblMsg.Text= ex.Message;
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
                    lblMsg.Text = "Employee Registration is compleated successfully";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
}

    private void updaterc(string id)
    {
        try
        {
            objBal = new ClsBAL();

            objBal.updaterc(id);
            ClsBAL obj = new ClsBAL();
            DataSet ds = obj.GetState(Convert.ToInt32(Session["UserId"]));
            string str = ds.Tables[0].Rows[0]["State"].ToString();
            ds = obj.GetStatewiseemprequests(str);
            gvAgentRequests.DataSource = ds;
            ViewState["Users1"] = ds.Tables[0];
            gvAgentRequests.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void gvAgentRequests_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}