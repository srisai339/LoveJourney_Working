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

public partial class Agent_Agents : System.Web.UI.Page
{
    ClsBAL objBal;
    string Userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.InnerHtml = "";
        //lblMainMsg.InnerHtml = "";
        this.Page.Title = "LoveJourney - Agents";

        if (Session["Role"] != null)
        {

            //if (Session["Role"].ToString() == "Admin")
            //{
            if (!IsPostBack)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    lbtnViewDbs.Visible = true;
                    trrole.Visible = true;
                    //  trstatus.Visible = true;
                    lbtnDistributorsDeposits.Visible = true;
                    lbtnRegisterAgent.Text = "Register Agent / Distributor";

                    CheckPermission("Agents", Session["Role"].ToString());

                    gvAgents.DataSource = GetAgents();
                    gvAgents.DataBind();
                    ViewState["Link"] = "View Agents";
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    lbtnViewDbs.Visible = false;
                    getagentsbydistributors();
                    trrole.Visible = false;
                    // trstatus.Visible = false;
                    lbtnDistributorsDeposits.Visible = false;
                    lbtnRegisterAgent.Text = "Register Agent";
                }
                Panel pnl = (Panel)this.Master.FindControl("pnl");
                pnl.Visible = false;
                ViewState["SortDirection"] = " ASC";


                //CheckPermission("Agents", Session["Role"].ToString());
                //ViewState["SortDirection"] = " ASC";
                //DataSet ds = new DataSet();
                //ds=GetAgents();
                //gvAgents.DataSource = ds;

                //ViewState["Users1"] = ds.Tables[0];
                // gvAgents.DataBind();

            }

            //}
            //else
            //{

            //    CheckPermission("Agents", Session["Role"].ToString());

            //}
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
    DataSet GetAgents()
    {
        try
        {
            objBal = new ClsBAL();

            return objBal.GetAgents();

        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    DataSet GetAgentById(int id)
    {
        try
        {
            objBal = new ClsBAL();
            return objBal.GetAgentById(id);
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
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
                if (Session["UserID"] != null)
                {

                    if (Session["Role"].ToString() == "Distributor")
                    {
                        ddlRole.SelectedItem.Text = "Agent";


                    }
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
                    Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(txtCommissionPercentage.Text.ToString()), ddlRole.SelectedItem.Text, "",
                    lblDomesticFlights.Text.ToString(),
                    lblInterNationalFlights.Text.ToString(),
                    lblBuses.Text.ToString(),
                    lblHotels.Text.ToString(),
                    lblRecharge.Text.ToString(),
                      txtDistrict.Text.Trim().ToString()

                    );

                if (message == "Agent registration is completed successfully.")
                {
                    mail();

                    lblDomesticFlights.Visible = false;
                    lblInterNationalFlights.Visible = false;
                    lblBuses.Visible = false;
                    lblHotels.Visible = false;
                    lblRecharge.Visible = false;
                    lblMsg.InnerHtml = message;
                    if (ddlRole.SelectedItem.Text == "Agent")
                    {
                        lblMsg.InnerHtml = message;
                    }
                    else if (ddlRole.SelectedItem.Text == "Distributor")
                    {
                        lblMsg.InnerHtml = "Distributor Registration  is completed successfully.";
                    }

                }


            }
            else if (btnRegister.Text == "Update")
            {
                if (txtDateOfBirth.Text == "")
                {
                    txtDateOfBirth.Text = "1/1/1990";
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




                message = objBal.UpdateAgent(txtAgentName.Text.Trim().ToString(),
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
                    txtPassword.Text.Trim().ToString(),
                    Convert.ToInt32(btnRegister.CommandArgument.ToString()),
                    Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(txtCommissionPercentage.Text.ToString()),
                    lblDomesticFlights.Text.ToString(),
                    lblInterNationalFlights.Text.ToString(),
                    lblBuses.Text.ToString(),
                    lblHotels.Text.ToString(),
                    lblRecharge.Text.ToString()

                    );
            }
            //  lblMsg.InnerHtml = message;
            lblDomesticFlights.Visible = false;
            lblInterNationalFlights.Visible = false;
            lblBuses.Visible = false;
            lblHotels.Visible = false;
            lblRecharge.Visible = false;

        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }

    protected void mail()
    {

        //string Body = "Dear <b>" + txtAgentName.Text + "</b>," +
        //"<br /><br />Let us welcome you  with lovejourney.in . " +
        // "Following are your login details. <br/> <br/>" +
        //" Email ID :<b>" + txtEmailId.Text.Trim() + "</b><br />" +
        //" Password : <b>" + txtPassword.Text.Trim() + "</b><br/>" +
        //"<br /><br />you have successfully registered in www.lovejourney.in by the admin  and please" +
        //"do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
        //"should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://info@lovejourney.in'> lovejourney.in</a>" +
        //"<br /><br />";

        //MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);




        string Body = "<html><head><title>LOVE JOURNEY - Registry Creation Account Mail</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding:0;       margin:0;font-family:Arial, Helvetica, sans-serif;font-size:12px;font-weight:normal;color:#000;'>" +
                                         "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/images/logo.gif' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                         "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Buses * Hotels * Recharge</td></tr>" +
                                         "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>you have successfully registered in www.lovejourney.in by the admin  </strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td align='center' valign='middle'><strong>Your New Agent Account Login Information</strong><br />Please keep the following information for your records:<br /><strong>User Name:</strong> <a href='#'>" + txtUsername.Text.Trim().ToString() + "</a><br /><strong>Password:</strong> " + txtPassword.Text.Trim().ToString() + "<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>Please use this  username/password combination the next time you log on.<br />If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr> <tr><td height='30' align='center' valign='middle'><strong>Login to your account  online using the following link:</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><strong><a href='http://lovejourney.in/Login.aspx'>http://lovejourney.in/Login.aspx&nbsp;</a></strong><br /><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                         "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                         "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                         "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);





    }
    protected void lbtnViewDbs_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["Link"] = "View Distributors";

            divAgents.Visible = true; divAgentRegistration.Visible = false; divDeposits.Visible = false;
            lbtnViewAgents.Font.Bold = true;
            lbtnRegisterAgent.Font.Bold = false;
            lbtnDeposits.Font.Bold = false;
            ClsBAL obj = new ClsBAL();
            DataSet ds = (DataSet)obj.GetAllTYpes("Distributor");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvAgents.DataSource = ds.Tables[0];
                        gvAgents.DataBind();
                    }
                }
            }


        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }

    protected void lbtnDistributorsDeposits_Click(object sender, EventArgs e)
    {
        try
        {
            txtAgents.Text = "";
            lbtnViewAgents.Font.Bold = false;
            lbtnRegisterAgent.Font.Bold = false;
            lbtnDeposits.Font.Bold = true;
            divAgents.Visible = false; divAgentRegistration.Visible = false; divDeposits.Visible = true;
            txtAmount.Text = txtDepositDetails.Text = "";

            ClsBAL obj = new ClsBAL();
            DataSet ds = (DataSet)obj.GetAllTYpes("Distributor");

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Deposits"] = "DisDeposits";
                        ddlAgents.DataSource = ds;
                        ddlAgents.DataTextField = "Username";
                        ddlAgents.DataValueField = "AgentId";
                        ddlAgents.DataBind();
                        ddlAgents.Items.Insert(0, "Please Select");
                        gvDeposits.DataSource = null; gvDeposits.DataBind();
                    }
                }
            }

            txtTransactionNo.Text = ""; rbtnType.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            // throw;
        }
    }
    protected void gvAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAgents.PageIndex = e.NewPageIndex; gvAgents.DataSource = GetAgents(); gvAgents.DataBind();
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
            if (Session["Role"].ToString() == "Admin")
            {

                if (ViewState["Link"].ToString() == "View Distributors")
                {

                    ClsBAL obj = new ClsBAL();
                    DataSet ds = (DataSet)obj.GetAllTYpes("Distributor");
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataTable dt = ds.Tables[0];
                                DataView dv = new DataView(dt);
                                dv.Sort = strExpression + strDirection;
                                gvAgents.DataSource = dv;
                                gvAgents.DataBind();
                            }
                        }
                    }
                }

                else
                {
                    DataTable dt = GetAgents().Tables[0];
                    DataView dv = new DataView(dt);
                    dv.Sort = strExpression + strDirection;
                    gvAgents.DataSource = dv;
                    gvAgents.DataBind();
                }
            }
            else
            {
                ClsBAL obj = new ClsBAL();
                DataSet ds = (DataSet)obj.GetAgentsbyDistributorID(Convert.ToInt32(Session["UserID"].ToString()));
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = strExpression + strDirection;
                gvAgents.DataSource = dv;
                gvAgents.DataBind();

            }
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
                Button btnViewAgent = (Button)e.Row.FindControl("btnViewAgent");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                RadioButton rbtnApproved = (RadioButton)e.Row.FindControl("rbtnApproved");
                RadioButton rbtnHold = (RadioButton)e.Row.FindControl("rbtnHold");
                //Label lblBalance = (Label)e.Row.FindControl("lblBalance");
                //lblBalance.Text = Convert.ToDouble(lblBalance.Text).ToString("####0.00");

                if (Session["Role"].ToString() == "Admin")
                {
                    btnViewAgent.Visible = true;

                    rbtnApproved.Checked = rbtnHold.Checked = lblStatus.Visible = false;
                    if (lblStatus.Text.ToString() == "Approved") { rbtnApproved.Checked = true; }
                    else if (lblStatus.Text.ToString() == "Hold") { rbtnHold.Checked = true; }


                }
                else if (Session["Role"].ToString() == "Distributor"|| Session["Role"].ToString()=="BSD")
                {
                    btnViewAgent.Visible = false;
                    lblStatus.Visible = false;
                    rbtnApproved.Visible = false;
                    rbtnHold.Visible = false;
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
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    double total = 0;
    protected void gvDeposits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("lblTotal");
                lblamount.Text = total.ToString();
            }
        }
    }
    protected void gvAgents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewAgent")
            {

                DataTable dt = GetAgentById(Convert.ToInt32(e.CommandArgument.ToString())).Tables[0];
                DataRow dr = dt.Rows[0];

                DateTime dateTime = Convert.ToDateTime(dr["DOB"].ToString());
                string date = dateTime.ToString("MM/dd/yyyy");

                txtAgentName.Text = dr["AgentName"].ToString();
                ddlType.SelectedValue = ddlType.Items.FindByText(dr["Type"].ToString()).Value;
                txtDateOfBirth.Text = date;
                txtCity.Text = dr["City"].ToString();
                ddlState.SelectedValue = ddlState.Items.FindByText(dr["State"].ToString()).Value;
                txtAddress.Text = dr["Address"].ToString();
                txtPinCode.Text = dr["PinCode"].ToString();
                txtMobileNo.Text = dr["MobileNo"].ToString();
                txtAlternateMobileNo.Text = dr["AlternateMobileNo"].ToString();
                txtLandlineNo.Text = dr["LandlineNo"].ToString();
                txtEmailId.Text = dr["EmailId"].ToString();
                txtPAN.Text = dr["PANNo"].ToString();
                txtCommissionPercentage.Text = dr["CommisionPercentage"].ToString();
                txtDetails.Text = dr["Details"].ToString();
                ddlStatus.SelectedValue = ddlStatus.Items.FindByText(dr["Status"].ToString()).Value;
                txtUsername.Text = dr["Username"].ToString();


                txtUsername.Enabled = false;

                txtPassword.Text = dr["Password"].ToString();
                txtConfirmPassword.Text = dr["Password"].ToString();

                btnRegister.Text = "Update"; btnRegister.CommandArgument = e.CommandArgument.ToString();
                legendAgentRegistration.InnerHtml = "View / Update Agent";
                btnCancel.Visible = true;

                divAgentRegistration.Visible = true; divAgents.Visible = false;
                checkBox.Visible = true;
                lblRecharge.Visible = lblDomesticFlights.Visible = lblInterNationalFlights.Visible = lblHotels.Visible = lblRecharge.Visible = false;
                if (dr["DomesticFlighs"].ToString() == "1")
                {
                    chkDomesticFlights.Checked = true;

                }
                if (dr["InterNationalFlights"].ToString() == "1")
                {
                    chkInternationalFlights.Checked = true;
                }
                if (dr["Buses"].ToString() == "1")
                {
                    chkBuses.Checked = true;
                }
                if (dr["Hotels"].ToString() == "1")
                {
                    chkHotels.Checked = true;
                }
                if (dr["Recharge"].ToString() == "1")
                {
                    chkRecharge.Checked = true;
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnRegister.Text = "Register"; btnRegister.CommandArgument = ""; btnCancel.Visible = false; txtUsername.Enabled = true;
            legendAgentRegistration.InnerHtml = "Registration";
            ClearVlaues();
            divAgentRegistration.Visible = false; divAgents.Visible = true;
            if (ViewState["Link"].ToString() == "View Agents")
            {
                gvAgents.DataSource = GetAgents();
                gvAgents.DataBind();
            }
            else if (ViewState["Link"].ToString() == "View Distributors")
            {
                getdistributors();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void getdistributors()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = (DataSet)obj.GetAllTYpes("Distributor");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvAgents.DataSource = ds.Tables[0];
                        gvAgents.DataBind();
                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    void ClearVlaues()
    {
        txtAgentName.Text = txtDateOfBirth.Text = txtCity.Text = txtAddress.Text = txtPinCode.Text = txtMobileNo.Text
            = txtAlternateMobileNo.Text = txtLandlineNo.Text = txtEmailId.Text = txtPAN.Text = txtDetails.Text = txtUsername.Text
            = txtPassword.Text = txtConfirmPassword.Text = txtCommissionPercentage.Text = "";
        ddlState.SelectedIndex = ddlStatus.SelectedIndex = ddlType.SelectedIndex = 0;
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
    protected void getagentsbydistributors()
    {
        try
        {
            ClsBAL obj = new ClsBAL();
            DataSet ds = (DataSet)obj.GetAgentsbyDistributorID(Convert.ToInt32(Session["UserID"].ToString()));
            if (ds != null)

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvAgents.DataSource = ds.Tables[0];
                        gvAgents.DataBind();
                    }
                }
        }

        catch (Exception ex)
        {
        }
    }
    protected void lbtnViewAgents_Click(object sender, EventArgs e)
    {
        try
        {

            ViewState["Link"] = "View Agents";
            divAgents.Visible = true; divAgentRegistration.Visible = false; divDeposits.Visible = false;
            lbtnViewAgents.Font.Bold = true;
            lbtnRegisterAgent.Font.Bold = false;
            lbtnDeposits.Font.Bold = false;

            if (Session["Role"].ToString() == "Admin")
            {
                gvAgents.DataSource = GetAgents();
                gvAgents.DataBind();
            }
            else if (Session["Role"].ToString() == "Distributor")
            {
                getagentsbydistributors();
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void lbtnRegisterAgent_Click(object sender, EventArgs e)
    {
        try
        {
            divAgents.Visible = false; divAgentRegistration.Visible = true; divDeposits.Visible = false;
            btnRegister.Text = "Register"; btnCancel.Visible = false; txtUsername.Enabled = true;
            legendAgentRegistration.InnerHtml = "Registration";
            ClearVlaues();
            lbtnViewAgents.Font.Bold = false;
            lbtnRegisterAgent.Font.Bold = true;
            lbtnDeposits.Font.Bold = false;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
        }
    }
    protected void lbtnDeposits_Click(object sender, EventArgs e)
    {
        try
        {
            txtAgents.Text = "";
            lbtnViewAgents.Font.Bold = false;
            lbtnRegisterAgent.Font.Bold = false;
            lbtnDeposits.Font.Bold = true;
            divAgents.Visible = false; divAgentRegistration.Visible = false; divDeposits.Visible = true;
            txtAmount.Text = txtDepositDetails.Text = "";

            if (Session["Role"].ToString() == "Admin")
            {
                Session["Deposits"] = "AgentDeposits";
                DataSet ds = GetAgents();
                ddlAgents.DataSource = ds;
                ddlAgents.DataTextField = "Username";
                ddlAgents.DataValueField = "AgentId";
                ddlAgents.DataBind();
                ddlAgents.Items.Insert(0, "Please Select");
                gvDeposits.DataSource = null; gvDeposits.DataBind();
            }
            else if (Session["Role"].ToString() == "Distributor")
            {
                ClsBAL objbal = new ClsBAL();
                Session["Deposits"] = "DistributorAgentDeposits";
                DataSet ds = objbal.GetAgentsbyDistributorID(Convert.ToInt32(Session["UserID"].ToString()));
                ddlAgents.DataSource = ds;
                ddlAgents.DataTextField = "Username";
                ddlAgents.DataValueField = "AgentId";
                ddlAgents.DataBind();
                ddlAgents.Items.Insert(0, "Please Select");
                gvDeposits.DataSource = null; gvDeposits.DataBind();
            }


            BindDepositRequests();

            txtTransactionNo.Text = ""; rbtnType.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void ddlAgents_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAgents.SelectedIndex != 0)
            {
                //BindDeposits();
            }
            else { gvDeposits.DataSource = null; gvDeposits.DataBind(); }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    void BindDeposits()
    {
        objBal = new ClsBAL();
        DataSet ds = objBal.GetAgentDeposits(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));
        Userid = ds.Tables[0].Rows[0]["UserId"].ToString();
        gvDeposits.DataSource = ds;
        gvDeposits.DataBind();
    }
    protected void btnDepositSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new ClsBAL();

            ListItem value = ddlAgents.Items.FindByText(txtAgents.Text.ToString());

            if (value == null)
            {
                ddlAgents.SelectedIndex = 0;
                lblMsg.InnerHtml = "The Agent Username does not exists.";

                txtAgentName.Focus();
                txtAgentName.Text = "";
            }
            else
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    ddlAgents.SelectedItem.Value = value.Value;
                    string msg = objBal.AddAgentDeposit(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString())
                        , Convert.ToDouble(txtAmount.Text.ToString()), txtDepositDetails.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString())
                        , rbtnType.SelectedItem.Text.ToString(), txtTransactionNo.Text.Trim().ToString(), txtReason.Text.Trim());


                    System.Data.DataSet ds = objBal.GetAgentById(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));

                    string body = "Dear " + ds.Tables[0].Rows[0]["UserName"].ToString() + ", <br/> " + "Rs. " + txtAmount.Text.ToString() + "/- amount has been credited in your account. <br/><br/> Thanks, <br/>Love Journey Team";
                    bool res = Mailsender.SendEmail(ds.Tables[0].Rows[0]["EmailId"].ToString(), "", "", "Deposit Details", body);

                    lblMsg.InnerHtml = msg;
                    BindDeposits(); txtAmount.Text = txtDepositDetails.Text = txtTransactionNo.Text = txtReason.Text = ""; rbtnType.SelectedIndex = -1;
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    if (Convert.ToDouble(Session["Balance"].ToString()) >= Convert.ToDouble(txtAmount.Text.ToString()))
                    {
                        ddlAgents.SelectedItem.Value = value.Value;
                        string msg = objBal.AddAgentDeposit(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString())
                            , Convert.ToDouble(txtAmount.Text.ToString()), txtDepositDetails.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString())
                            , rbtnType.SelectedItem.Text.ToString(), txtTransactionNo.Text.Trim().ToString(), txtReason.Text.Trim());


                        System.Data.DataSet ds = objBal.GetAgentById(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));

                        string body = "Dear " + ds.Tables[0].Rows[0]["UserName"].ToString() + ", <br/> " + "Rs. " + txtAmount.Text.ToString() + "/- amount has been credited in your account. <br/><br/> Thanks, <br/>Love Journey Team";
                        bool res = Mailsender.SendEmail(ds.Tables[0].Rows[0]["EmailId"].ToString(), "", "", "Deposit Details", body);

                        lblMsg.InnerHtml = msg;
                        if (msg == "Inserted Successfully.")
                        {
                            objBal.deductDistributorbalance(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDouble(txtAmount.Text.ToString()), "Deduct");

                            ClsBAL objBAL = new ClsBAL();
                            System.Data.DataSet dataset = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                            Session["Balance"] = dataset.Tables[0].Rows[0]["Balance"].ToString();

                            Label balance = (Label)this.Master.FindControl("lblDbBal");
                            balance.Text = "Your balance is : " + " " + Session["Balance"].ToString();

                        }



                        BindDeposits(); txtAmount.Text = txtDepositDetails.Text = txtTransactionNo.Text = txtReason.Text = ""; rbtnType.SelectedIndex = -1;
                    }
                    else
                    {
                        lblMsg.InnerHtml = "Your balance should be greater than the adding amount.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;

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
            string strExpression = e.SortExpression;
            string strDirection = ViewState["SortDirection"].ToString();
            objBal = new ClsBAL();
            DataSet ds = objBal.GetAgentDeposits(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));
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

    void BindDepositRequests()
    {
        //ClsBAL obj = new ClsBAL();
        //DataSet ds = obj.GetDepositUpdateRequests();
        //gvDepositRequests.DataSource = ds;
        //gvDepositRequests.DataBind();
    }
    protected void gvDepositRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDepositRequests.PageIndex = e.NewPageIndex;
            BindDepositRequests();
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void gvDepositRequests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void gvDepositRequests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void gvDepositRequests_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            try
            {
                string strExpression = e.SortExpression;
                string strDirection = ViewState["SortDirection"].ToString();
                objBal = new ClsBAL();
                DataSet ds = objBal.GetDepositUpdateRequests();
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = strExpression + strDirection;
                gvDepositRequests.DataSource = dv;
                gvDepositRequests.DataBind();
                if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }
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
    protected void btnDeductAmt_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new ClsBAL();
            ListItem value = ddlAgents.Items.FindByText(txtAgents.Text.ToString());

            if (value == null)
            {
                ddlAgents.SelectedIndex = 0;
                lblMsg.InnerHtml = "The Agent Username does not exists.";
                txtAgentName.Focus();
                txtAgentName.Text = "";
            }
            else
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    ddlAgents.SelectedItem.Value = value.Value;
                    string msg = objBal.DeductAgentDeposit(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString())
                        , Convert.ToDouble(txtAmount.Text.ToString()), txtDepositDetails.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString())
                        , rbtnType.SelectedItem.Text.ToString(), txtTransactionNo.Text.Trim().ToString(), txtReason.Text);


                    System.Data.DataSet ds = objBal.GetAgentById(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));

                    string body = "Dear " + ds.Tables[0].Rows[0]["UserName"].ToString() + ", <br/> " + "Rs. " + txtAmount.Text.ToString() + "/- amount has been deducted in your account. <br/><br/> Thanks, <br/>Love Journey Team";
                    bool res = Mailsender.SendEmail(ds.Tables[0].Rows[0]["EmailId"].ToString(), "", "", "Deposit Deduct Details", body);

                    lblMsg.InnerHtml = msg;
                    BindDeposits(); txtAmount.Text = txtDepositDetails.Text = txtTransactionNo.Text = txtReason.Text = ""; rbtnType.SelectedIndex = -1;
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    ddlAgents.SelectedItem.Value = value.Value;
                    System.Data.DataSet ds = objBal.GetAgentById(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString()));


                    if (Convert.ToDouble(ds.Tables[0].Rows[0]["Balance"].ToString()) >= Convert.ToDouble(txtAmount.Text.ToString()))
                    {


                        string msg = objBal.DeductAgentDeposit(Convert.ToInt32(ddlAgents.SelectedItem.Value.ToString())
                         , Convert.ToDouble(txtAmount.Text.ToString()), txtDepositDetails.Text.Trim().ToString(), Convert.ToInt32(Session["UserID"].ToString())
                         , rbtnType.SelectedItem.Text.ToString(), txtTransactionNo.Text.Trim().ToString(), txtReason.Text);




                        string body = "Dear " + ds.Tables[0].Rows[0]["UserName"].ToString() + ", <br/> " + "Rs. " + txtAmount.Text.ToString() + "/- amount has been deducted in your account. <br/><br/> Thanks, <br/>Love Journey Team";
                        bool res = Mailsender.SendEmail(ds.Tables[0].Rows[0]["EmailId"].ToString(), "", "", "Deposit Details", body);

                        lblMsg.InnerHtml = msg;
                        if (msg == "Updated Successfully.")
                        {
                            objBal.deductDistributorbalance(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToDouble(txtAmount.Text.ToString()), "Add");

                            ClsBAL objBAL = new ClsBAL();
                            System.Data.DataSet dataset = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                            Session["Balance"] = dataset.Tables[0].Rows[0]["Balance"].ToString();

                            Label balance = (Label)this.Master.FindControl("lblDbBal");
                            balance.Text = "Your balance is : " + " " + Session["Balance"].ToString();

                        }

                        BindDeposits(); txtAmount.Text = txtDepositDetails.Text = txtTransactionNo.Text = txtReason.Text = ""; rbtnType.SelectedIndex = -1;
                    }
                    else
                    {
                        lblMsg.InnerHtml = "Your cant deduct this amount,If you deduct this amount, agent balance will be in negative.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.InnerHtml = ex.Message;
            // throw;
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


            if (HttpContext.Current.Session["Deposits"].ToString() == "AgentDeposits")
            {
                ds = objBal.GetAgents();
                string filteringquery = "Username LIKE '" + prefixText + "%'";
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

            else if (HttpContext.Current.Session["Deposits"].ToString() == "DisDeposits")
            {
                ds = objBal.GetAllTYpes("Distributor");
                string filteringquery = "Username LIKE '" + prefixText + "%'";
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
            else
            {
                ds = objBal.GetAgentsbyDistributorID(Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString()));
                string filteringquery = "Username LIKE '" + prefixText + "%'";
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


        }
        catch (Exception)
        {
            throw;

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
    protected void lbtnXport2Xcel_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvAgents);
            // gvDeposits.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Agents.xls");
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            tdmsg.Visible = false;

            // lblMainMsg.Text = "";
            if (txtSearch.Text == "")
            {
                GetAgents();

            }
            else
            {
                if (ViewState["Users1"] != null)
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("AgentName");
                    dtt.Columns.Add("Type");
                    dtt.Columns.Add("DOB");
                    dtt.Columns.Add("City");
                    dtt.Columns.Add("District");
                    dtt.Columns.Add("MobileNo");
                    dtt.Columns.Add("EmailId");
                    dtt.Columns.Add("UserName");
                    dtt.Columns.Add("Password");
                    dtt.Columns.Add("Balance");
                    dtt.Columns.Add("CommisionPercentage");
                    dtt.Columns.Add("AgentId");
                    dtt.Columns.Add("UserId");
                    dtt.Columns.Add("Status");



                    DataTable DtCommission = (DataTable)ViewState["Users1"];
                    DataRow[] dr = DtCommission.Select("AgentName like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Type like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "MobileNo like '" + "%" + txtSearch.Text + "%" + "'" + "or " + "Status like '" + "%" + txtSearch.Text + "%" + "'");
                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            DataRow ddd = dtt.NewRow();
                            ddd["AgentName"] = row["AgentName"].ToString();
                            ddd["Type"] = row["Type"].ToString();
                            ddd["DOB"] = row["DOB"].ToString();
                            ddd["City"] = row["City"].ToString();
                            ddd["District"] = row["District"].ToString();
                            ddd["MobileNo"] = row["MobileNo"].ToString();
                            ddd["EmailId"] = row["EmailId"].ToString();
                            ddd["UserName"] = row["UserName"].ToString();
                            ddd["Password"] = row["Password"].ToString();
                            ddd["Balance"] = row["Balance"].ToString();
                            ddd["CommisionPercentage"] = row["CommisionPercentage"].ToString();
                            ddd["AgentId"] = row["AgentId"].ToString();
                            ddd["UserId"] = row["UserId"].ToString();
                            ddd["Status"] = row["Status"].ToString();
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

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (ddlPageSize.SelectedValue == "Please Select")
            {

            }
            else
            {
                if (ViewState["Users1"] != null)
                {
                    gvAgents.PageSize = Convert.ToInt32(ddlPageSize.SelectedItem.Text);
                    gvAgents.DataSource = ViewState["Users1"];
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