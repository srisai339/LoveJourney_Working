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

public partial class PrivacyStatement : System.Web.UI.Page
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
        if (!IsPostBack)
        {

        }
    }


    protected void lnkbtnloginhow_Click(object sender, EventArgs e)
    {
       // MpeSignIn.Show();
    }
    protected void lnkbtnsignup_Click(object sender, EventArgs e)
    {
      //  MpeSignUP.Show();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //_objUserAuth = new clsUserAuthentication();


            //_objUserAuth.strEmailID = txtEmailID.Text.Trim().ToString().ToLower();


            //_objUserAuth.strPassword = txtPassword.Text.Trim().ToString().ToLower();

            //if (_objUserAuth.fnCheckAPRUser() == true)
            //{
            //    Response.Redirect("Masters/HomePage.aspx", false);
            //}
            //else
            //{
            //    txtEmailID.Focus();
            //    lblMessage.Text = "Please recheck your UserName and Password";
            //    MpeSignIn.Show();
            //}
        }
        catch (Exception ex)
        {
            //LogError("BusSearchPage", "btnLogin_Click", DateTime.Now, ex.Message.ToString());
            //Response.Redirect("Error.aspx", false);
        }
    }


    public void checkUser()
    {
        //if (txtEmailID1.Text != "")
        //{
        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.UserName;
        //    _objMasters.EmailID = txtEmailID1.Text.Trim();
        //    _objDataSet = (DataSet)_objMasters.fnGetData();
        //    DataTable dt = _objDataSet.Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {

        //        lblMsg1.Text = "User name is not available";
        //        lblMsg1.ForeColor = Color.Red;
        //        lblMsg1.Visible = true;
        //        Checked = "null";
        //        MpeSignUP.Show();
        //    }
        //    else
        //    {
        //        lblMsg1.ForeColor = Color.Blue;
        //        lblMsg1.Text = "User name is available";
        //        Checked = "available";
        //    }
        //}
        //else
        //{
        //    lblMsg1.Text = "Please Enter Email ID";
        //    lblMsg1.ForeColor = Color.Red;
        //    lblMsg1.Visible = true;
        //    Checked = "null";
        //}
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {

        checkUser();

        if (Checked == "available")
        {
        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.UserMst;
        //    _objMasters.EmailID = txtEmailID1.Text.Trim().ToString().ToLower();
        //    _objMasters.FirstName = txtFirstName.Text.Trim();
        //    _objMasters.Password = txtPassword1.Text.Trim().ToString().ToLower();
        //    _objMasters.Mobile_Num = txtMobileNum.Text.Trim();
        //    _objMasters.Address = txtaddress1.Text.Trim();
        //    // _objMasters.Mobile = Session["MobileNumber"].ToString();
        //    _objMasters.Statename = txtState.Text.Trim();
        //    _objMasters.cityname = txtCity.Text.Trim();
        //    if (_objMasters.fnInsertRecord() == true)
        //    {
        //        lblMsg1.ForeColor = Color.Green;
        //        lblMsg2.ForeColor = Color.Green;
        //        MpeSignUP.Show();
        //        lblMsg1.Text = "Confirmation: ";
        //        lblMsg2.Text = "successfully. Registered";
        //        Login(txtEmailID1.Text.Trim().ToString(), txtPassword1.Text.Trim().ToString());
        //    }
        //    else
        //    {
        //        lblMsg1.Text = "<font color='red'> Error Notification: </font>";
        //        lblMsg2.Text = ".";
        //    }
        //}
        //else if (Checked == "null")
        //{
        //    lblMsg1.ForeColor = Color.Red;
        //    lblMsg1.Text = "Email Id Already Exists";
        //    lblMsg1.Visible = true;

        //    txtEmailID1.Focus();
        }

    }

    protected void Login(string emailid, string password)
    {

        try
        {
            _objUserAuth = new clsUserAuthentication();
            _objUserAuth.strEmailID = emailid.Trim().ToString();
            _objUserAuth.strPassword = password.Trim().ToString();

            if (_objUserAuth.fnCheckAPRUser() == true)
            {
                Response.Redirect("~/Masters/HomePage.aspx",false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbuttonHome_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnLoginn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //_objUserAuth = new clsUserAuthentication();
            //_objUserAuth.strEmailID = txtUserName.Text.Trim().ToString().ToLower();
            //_objUserAuth.strPassword = txtPasswordd.Text.Trim().ToString().ToLower();
            //if (_objUserAuth.fnCheckAPRUser() == true)
            //{
            //    Response.Redirect("Masters/HomePage.aspx", false);
            //}
            //else
            //{
            //    txtEmailID.Focus();
            //    lblMessage.Text = "Please recheck your UserName and Password";
            //    Mpe1.Show();
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnforgotpassword_click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
    protected void lnkbtnsignup_Click1(object sender, EventArgs e)
    {
      //  MpeSignUP.Show();
    }
    protected void lnkmyaccount_Click(object sender, EventArgs e)
    {
       // MpeSignIn.Show();
    }
}