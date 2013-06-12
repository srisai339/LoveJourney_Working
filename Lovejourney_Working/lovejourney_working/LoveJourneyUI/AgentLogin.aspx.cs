using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Drawing.Design;
using COM;
using System.Data.SqlClient;
using System;

public partial class AgentLogin :clsBagePage
{
    #region Global Variables
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    #region FUNCTION
   

    public void checkAgent()
    {
        try
        {
            if (txtEmailIDAgent.Text != "")
            {
                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.AgentName;
                _objMasters.EmailID = txtEmailIDAgent.Text.Trim();
                _objDataSet = (DataSet)_objMasters.fnGetData();
                DataTable dt = _objDataSet.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblmsg.Text = "EmailId is already exists";
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Visible = true;
                    Checked = "null";
                }
                else
                {
                    lblmsg.ForeColor = Color.Green;
                    lblmsg.Text = "EmailId is Available";
                    lblmsg.Visible = true;
                    Checked = "Available";
                }
            }
            else
            {
                lblmsg.Text = "Please Enter Email ID";
                lblmsg.ForeColor = Color.Red;
                lblmsg.Visible = true;
                Checked = "null";
            }
        }
        catch (Exception ex)
        {
            LogError("AgentLogin", "checkUser", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }

    #endregion
    public void clearFields()
    {
        txtAddress.Text = "";
        // txtDOB.Text = "";
        txtFax.Text = "";
        txtFirstName.Text = "";
        txtLandLine.Text = "";
        txtLastName.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";
        txtPinCode.Text = "";
        txtEmailIDAgent.Text = "";
      //  ddlCity.Items.Clear();
       // ddlCountry.Items.Clear();
       // ddlState.Items.Clear();
        ddlTitle.SelectedValue = "-1";
        ddlState.Text = "";
        ddlCity.Text = "";
        ddltype.SelectedIndex = 0;
        ddlTitle.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;


    }


    protected String GeneratePassword()
    {
        int minPassSize = 4;
        int maxPassSize = 9;
        StringBuilder stringBuilder = new StringBuilder();
        char[] charArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()".ToCharArray();
        int newPassLength = new Random().Next(minPassSize, maxPassSize);
        char character;
        Random rnd = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < newPassLength; i++)
        {
            character = charArray[rnd.Next(0, (charArray.Length - 1))];
            stringBuilder.Append(character);
        }
        lblPWD.Text = stringBuilder.ToString();
        return stringBuilder.ToString();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            checkAgent();
            if (Checked == "Available")
            {
                System.DateTime today = System.DateTime.Now;
                if (Convert.ToDateTime(txtDOB.Text.Trim()) >= today)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "your DOB should be less than current date";
                    lblmsg.ForeColor = Color.Red;
                    lblMsg1.Text = "";
                    lblMsg2.Text = "";
                }
                else
                {
                    GeneratePassword();
                    Session["Password"] = txtPassword.Text;

                    _objMasters = new clsMasters();
                    _objMasters.ScreenInd = Masters.Agentregistration;
                    _objMasters.EmailID = txtEmailIDAgent.Text.Trim().ToLower();
                    _objMasters.Password = lblPWD.Text;
                    _objMasters.Title = ddlTitle.SelectedItem.Text;
                    _objMasters.FirstName = txtFirstName.Text.Trim();
                    _objMasters.LastName = txtLastName.Text.Trim();
                    _objMasters.DOB = Convert.ToDateTime(txtDOB.Text.Trim());
                    _objMasters.Address = txtAddress.Text.Trim();
                    _objMasters.Pincode = txtPinCode.Text.Trim();
                    _objMasters.Mobile = txtMobile.Text.Trim();
                    _objMasters.Landline = txtLandLine.Text.Trim();
                    _objMasters.Fax = txtFax.Text.Trim();
                    _objMasters.CountryName = ddlCountry.SelectedValue;
                    _objMasters.Statename = ddlState.Text;
                    _objMasters.cityname = ddlCity.Text;
                    _objMasters.Status ="0";
                    _objMasters.UserType = ddltype.SelectedValue;


                    if (_objMasters.fnInsertRecord() == true)
                    {
                        btnRegister.Visible = true;
                        pnlContact.Visible = true;
                        lblMsg1.ForeColor = Color.Green;
                        lblMsg2.ForeColor = Color.Green;
                        lblMsg1.Visible = lblMsg2.Visible = true;
                        lblMsg1.Text = "Confirmation: ";
                        lblMsg2.Text = "your details saved successfully,Please Wait for admin approval.";
                        lblmsg.Visible = false;
                        clearFields();

                    }

                    else
                    {
                        lblMsg1.Text = "<font color='red'> Error Notification: </font>";
                        lblMsg2.Text = "your registration is failed.";
                        lblmsg.Visible = false;
                    }
                }
            }
            else if (Checked == "null")
            {
                lblMsg1.ForeColor = Color.Red;
                lblMsg1.Text = " EmailID is Not available";
                lblMsg1.Visible = true;
                lblmsg.Visible = false;
                txtEmailID.Focus();
                //Reset(this);
            }
        }



        catch (Exception ex)
        {
            LogError("AgentLogin", "btnRegister_Click", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }


    protected void lnkbtnForgotPassword_Click(object sender, EventArgs e)
    {
        Session["Type"] = "AG";

        Response.Redirect("ForgotPassword.aspx", false);
    }
    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        System.DateTime today = System.DateTime.Now;
        if (Convert.ToDateTime(txtDOB.Text.Trim()) >= today)
        {
            lblmsg.Text = "your DOB should be less than current date";
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            _objUserAuth = new clsUserAuthentication();
            _objUserAuth.strEmailID = txtEmailID.Text.Trim().ToString().ToLower();
            _objUserAuth.strPassword = txtPassword.Text.Trim().ToString();

            if (_objUserAuth.fnCheckAgent() == true)
            {
                if (Session["RechargeUserType"].ToString() == "AG")
                {
                    if (Session["Status"].ToString() == "1")
                    {
                        Response.Redirect("~/Masters/HomePage.aspx", false);
                        // clearFields();
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Your Request has not been approved";
                    }
                }


                else if (Session["RechargeUserType"].ToString() == "AD")
                {
                    Session["Password"] = txtPassword.Text;
                    Response.Redirect("~/Masters/HomePage.aspx", false);
                    
                }
                else if (Session["RechargeUserType"].ToString() == "DB")
                {
                    if (Session["Status"].ToString() == "1")
                    {
                        Session["Password"] = txtPassword.Text;
                        Response.Redirect("~/Masters/HomePage.aspx", false);
                        // clearFields();
                       
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "Your Request has not been approved";
                    }
                   
                }

            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = " Enter Correct EmailId and Password";
            }
        }
        catch (Exception ex)
        {
            LogError("AgentLogin", "btnRegister_Click", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }
    protected void lBtnCheckUser_Click(object sender, EventArgs e)
    {
        checkAgent();
    }
}