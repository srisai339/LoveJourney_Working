//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using BAL;
//using System.Web.Security;
//using System.Data;
//using System.Drawing;
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


public partial class MainMasterPage : System.Web.UI.MasterPage
{
    #region Global Variables
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    #endregion
    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showImage1("Advertisement1", "Index page");
            showImage2("Advertisement2", "Index page");
            showImage3("Advertisement3", "Index page");


            if (Session["RechargeUserType"] == null)
            {
                lnkGotomyaccount.Visible = false;
                lnklogout.Visible = false;
            }
            else if (Session["RechargeUserType"] != null)
            {
                if (Session["RechargeUserType"].ToString() == "User")
                {
                    lnkGotomyaccount.Visible = true;
                    lnklogout.Visible = true;
                }

                else if (Session["RechargeUserType"].ToString() == "AD")
                {
                    lnkGotomyaccount.Visible = true;
                    lnklogout.Visible = true;
                }
                else if (Session["RechargeUserType"].ToString() == "AG")
                {
                    lnkGotomyaccount.Visible = true;
                    lnklogout.Visible = true;
                }
            }



        }

    }
    protected void dlAdd2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (!IsPostBack)
        {
            ImageButton ibtn = (ImageButton)e.Item.FindControl("ibtnAddImage1");
            string url = ibtn.CommandArgument.ToString();
            if (url != "")
            {
                string fullURL = "window.open('" + url + "', '_blank', 'height=800,width=1000,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                ibtn.Attributes.Add("OnClick", fullURL);
            }
        }
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (!IsPostBack)
        {
            ImageButton ibtn = (ImageButton)e.Item.FindControl("ibtnAddImage2");
            string url = ibtn.CommandArgument.ToString();
            if (url != "")
            {
                string fullURL = "window.open('" + url + "', '_blank', 'height=800,width=1000,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                ibtn.Attributes.Add("OnClick", fullURL);
            }
        }
    }
    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (!IsPostBack)
        {
            ImageButton ibtn = (ImageButton)e.Item.FindControl("ibtnAddImage3");
            string url = ibtn.CommandArgument.ToString();
            if (url != "")
            {
                string fullURL = "window.open('" + url + "', '_blank', 'height=800,width=1000,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
                ibtn.Attributes.Add("OnClick", fullURL);
            }
        }
    }
    #region Advertisment datalist
    private void showImage1(string Advertisement1, string ScreenName)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = null;
            command = new SqlCommand("select img.ID,AD.Advertisement,Img.img,Img.url,Img.Script from Advertisement Ad Inner Join Adv_Images Img on img.ID = AD.imgID where AD.Advertisement='" + Advertisement1.ToString() + "' and AD.ScreenName='" + ScreenName.ToString() + "'", connection);
            SqlDataAdapter ada = new SqlDataAdapter(command);
            ada.Fill(dt);
            //dlAdd2.DataSource = dt;
           // dlAdd2.DataBind();
        }
        catch (Exception ex)
        {
            //LogError("ImageUpload", "showImage", DateTime.Now, ex.Message.ToString());
            //Response.Redirect("Error.aspx", false);
        }
    }
    private void showImage2(string Advertisement1, string ScreenName)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = null;
            command = new SqlCommand("select img.ID,AD.Advertisement,Img.img,Img.url,Img.Script from Advertisement Ad Inner Join Adv_Images Img on img.ID = AD.imgID where AD.Advertisement='" + Advertisement1.ToString() + "' and AD.ScreenName='" + ScreenName.ToString() + "'", connection);
            SqlDataAdapter ada = new SqlDataAdapter(command);
            ada.Fill(dt);
          //  DataList1.DataSource = dt;
          //  DataList1.DataBind();
        }
        catch (Exception ex)
        {
            //LogError("ImageUpload", "showImage", DateTime.Now, ex.Message.ToString());
            //Response.Redirect("Error.aspx", false);
        }
    }
    private void showImage3(string Advertisement1, string ScreenName)
    {
        try
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = null;
            command = new SqlCommand("select img.ID,AD.Advertisement,Img.img,Img.url,Img.Script from Advertisement Ad Inner Join Adv_Images Img on img.ID = AD.imgID where AD.Advertisement='" + Advertisement1.ToString() + "' and AD.ScreenName='" + ScreenName.ToString() + "'", connection);
            SqlDataAdapter ada = new SqlDataAdapter(command);
            ada.Fill(dt);
            // DataList2.DataSource = dt;
             //DataList2.DataBind();
        }
        catch (Exception ex)
        {
            //LogError("ImageUpload", "showImage", DateTime.Now, ex.Message.ToString());
            //Response.Redirect("Error.aspx", false);
        }
    }
    #endregion
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            _objUserAuth = new clsUserAuthentication();

            //string strEncryptPwd = string.Empty;
            //string strPassword = "¶¾±";
            //strPassword += txtPassword.Text.Trim().ToString().ToLower();
            //strPassword += "¶¾±";
            //strPassword += txtEmailID.Text.Trim().ToString().ToLower();
            //strPassword += "¶¾±";
            //strEncryptPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "md5");

            _objUserAuth.strEmailID = txtEmailID.Text.Trim().ToString().ToLower();


            _objUserAuth.strPassword = txtPassword.Text.Trim().ToString().ToLower();

            if (_objUserAuth.fnCheckAPRUser() == true)
            {
                Response.Redirect("Masters/HomePage.aspx", false);
            }
            else
            {
                txtEmailID.Focus();
                lbl1.Text = "Please recheck your UserName and Password";
                lbl1.ForeColor = Color.Red; 
                MpeSignIn.Show();
            }
        }
        catch (Exception ex)
        {
            //LogError("BusSearchPage", "btnLogin_Click", DateTime.Now, ex.Message.ToString());
            //Response.Redirect("Error.aspx", false);
        }
    }


    protected void lnkbtnSingUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx", false);
    }


    protected void btnLoginn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _objUserAuth = new clsUserAuthentication();
            //_objUserAuth.strEmailID = txtUserName.Text.Trim().ToString().ToLower();
           // _objUserAuth.strPassword = txtPasswordd.Text.Trim().ToString().ToLower();
            if (_objUserAuth.fnCheckAPRUser() == true)
            {
                Response.Redirect("Masters/HomePage.aspx", false);
            }
            else
            {
                txtEmailID.Focus();
                lblMessage.Text = "Please recheck your UserName and Password";
                Mpe1.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbuttonHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void lnkbtnsignup_click(object sender, EventArgs e)
    {
        MpeSignUP.Show();
    }
    protected void lnkmyaccount_Click(object sender, EventArgs e)
    {
        MpeSignIn.Show();
    }
    protected void lnkbtnforgotpassword_click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }

    public void checkUser()
    {
        if (txtEmailID1.Text != "")
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.UserName;
            _objMasters.EmailID = txtEmailID1.Text.Trim();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            DataTable dt = _objDataSet.Tables[0];
            if (dt.Rows.Count > 0)
            {

                lblMsg1.Text = "User name is not available";
                lblMsg1.ForeColor = Color.Red;
                lblMsg1.Visible = true;
                Checked = "null";
                // MpeSignUP.Show();
            }
            else
            {
                lblMsg1.ForeColor = Color.Blue;
                lblMsg1.Text = "User name is available";
                Checked = "available";
            }
        }
        else
        {
            lblMsg1.Text = "Please Enter Email ID";
            lblMsg1.ForeColor = Color.Red;
            lblMsg1.Visible = true;
            Checked = "null";
        }
    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        //if(txtEmailID1.Text =="" || txtFirstName.Text=="" || txtPassword1.Text=="" || txtMobileNum.Text=="" || txtaddress1.Text =="" ||txtState.Text == "" || txtCity.Text=="")
        //{
        //    return;
        //}
        //else
        //{
        checkUser();

        if (Checked == "available")
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.UserMst;
            _objMasters.EmailID = txtEmailID1.Text.Trim().ToString().ToLower();
            _objMasters.FirstName = txtFirstName.Text.Trim();
            _objMasters.Password = txtPassword1.Text.Trim().ToString().ToLower();
            _objMasters.Mobile_Num = txtMobileNum.Text.Trim();
            _objMasters.Address = txtaddress1.Text.Trim();
            _objMasters.Statename = txtState.Text.Trim();
            _objMasters.cityname = txtCity.Text.Trim();
            _objMasters.CountryName = ddlCountry.SelectedValue;
            _objMasters.PostalCode = txtUserpostalcode.Text.Trim();

            if (_objMasters.fnInsertRecord() == true)
            {
                lblMsg1.ForeColor = Color.Green;
                lblMsg2.ForeColor = Color.Green;
                MpeSignUP.Show();
                lblMsg1.Text = "Confirmation: ";
                lblMsg2.Text = "successfully. Registered";


                try
                {

                    string str = string.Empty;

                    string Body = "Dear <b>" + txtFirstName.Text + "</b>," +
                    "<br /><br />Let us welcome you recharge with lovejourney.in " +
                     "Following are your login details. <br/> <br/>" +
                    " Email ID :<b>" + txtEmailID1.Text.Trim() + "</b><br />" +
                    " Password : <b>" + txtPassword1.Text.Trim() + "</b><br/>" +
                    "<br /><br />you have successfully registered in www.lovejourney.in and please" +
                    "do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
                    "should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://lovejourney.in'> lovejourney.in</a>" +
                    "<br /><br />";

                    MailSender.SendEmail(txtEmailID1.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-login", Body);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                Login(txtEmailID1.Text.Trim().ToString(), txtPassword1.Text.Trim().ToString());

            }
            else
            {
                lblMsg1.Text = "<font color='red'> Error Notification: </font>";
                lblMsg2.Text = ".";
            }
        }
        else if (Checked == "null")
        {
            MpeSignUP.Show();
            lblMsg1.Text = "Email ID Already Exists";
            lblMsg1.ForeColor = Color.Red;
            lblMsg1.Visible = true;


            //lblMessage.Text = "Email ID Already Exists";
            //Mpe1.Show();
            //Clearfields();

        }
    }
    
    protected void Clearfields()
    {
        txtEmailID1.Text = "";
        txtFirstName.Text = "";
        txtPassword1.Text = "";
        txtMobileNum.Text = "";
        txtaddress1.Text = "";
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
                Response.Redirect("~/Masters/HomePage.aspx", false);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnsignup_Click(object sender, EventArgs e)
    {
        MpeSignUP.Show();
    }
    protected void btnLoginn_Click(object sender, EventArgs e)
    {
        MpeSignIn.Show();
    }
    protected void lnkGotomyaccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("Masters/HomePage.aspx", false);
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx", false);
        Session["RechargeUserType"] = null;
    }
}
