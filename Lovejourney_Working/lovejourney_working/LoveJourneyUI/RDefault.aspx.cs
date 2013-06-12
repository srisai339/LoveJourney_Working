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
using System.Xml;

public partial class RDefault : clsBagePage
{
    #region Global Variablesc
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    static string ipaddr;
    static string val = "false";
    #endregion
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                getservices();
                if (val != "true")
                {
                    if (Session["IsFlagged"] != null)
                    {
                        lblMessage.Text = "Your transaction is Kept on hold";
                        Mpe1.Show();
                        Session["IsFlagged"] = null;

                    }
                    else if (Session["Transaction"] != null)
                    {
                        lblMessage.Text = "Your transaction fail, please try again !!";
                        Mpe1.Show();
                        Session["Transaction"] = null;
                    }
                    clearfields();
                    loadDropdown();
                    LoadDropdown1();
                    LoadDropdown2();
                    tdmsg.Visible = false;
                    tdmob.Visible = true;
                }
                else
                {
                    lblMainMsg.Text = "This Service is temporarily unavailable";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    tdmsg.Visible = true;
                    tdmob.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "Page_Load", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }

    protected void getservices()
    {
        try
        {
            val = "false";
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Getservices;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < _objDataSet.Tables[0].Rows.Count; i++)
                        {
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "Recharge" && _objDataSet.Tables[0].Rows[i]["Status"].ToString() == "1")
                            {
                                val = "true";
                            }
                        }

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }


    protected void clearfields()
    {
        lblMsg1.Text = "";
        lblMsg2.Text = "";
        txtEmailID1.Text = "";
        txtPassword1.Text = "";
        txtFirstName.Text = "";
        txtaddress1.Text = "";
        txtMobile.Text = "";
        txtMobileNum.Text = "";
        //txtEmailID.Text = "";
       // txtPassword.Text = "";
        txtMobile.Text = "";
        ddlrechargeamount.SelectedItem.Text = "Please Select";
        // txtRecAmount.Text = "";
       // txtEmailID.Text = "";
        txtCustID.Text = "";
        txtEmailD2H.Text = "";
        //txtD2HAmount.Text = "";
        // ddlD2HAmount.SelectedItem.Text = "Please Select";
        txtState.Text = "";
        txtCity.Text = "";

    }
    //#endregion

   

    #region Click Event iN Recharge
    protected void btnMobileRecharge_Click(object sender, EventArgs e)
    {
        try
        {
            Session["RMobileNumber"] = txtMobile.Text.Trim();
            Session["ProviderName"] = ddlProvider.SelectedItem.Text;
            // Session["RRechargeAmount"] = txtRecAmount.Text.Trim();
            Session["RRechargeAmount"] = ddlrechargeamount.SelectedItem.Text;
            Session["REmailMobile"] = txtEmailMobile.Text.Trim();
            ViewState["Address"] = txtmobileguestaddress.Text;
            ViewState["Name"] = txtGuestname.Text;
            ViewState["City"] = txtMobileCity.Text;
            ViewState["State"] = txtMobileState.Text;
            ViewState["Country"] = ddlmobileguestscountry.SelectedValue;
            ViewState["PostalCode"] = txtMobilePostalCode.Text;
            MpeSignUP.Hide();
            MpLogin.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnD2HRecharge_Click(object sender, EventArgs e)
    {
        try
        {
            Session["RMobileNumber"] = txtCustID.Text.Trim();
            Session["ProviderNameDTH"] = ddlD2HProvider.SelectedItem.Text;
            // Session["RRechargeAmount"] = txtD2HAmount.Text.Trim();
            Session["RRechargeAmount"] = ddlD2HAmount.SelectedItem.Text;

            Session["REmailMobile"] = txtEmailD2H.Text.Trim();

            ViewState["Address"] = txtdthguestaddress.Text;
            ViewState["Name"] = txtGusetdthname.Text;
            ViewState["City"] = txtDTHCity.Text;
            ViewState["State"] = txtDTHState.Text;
            ViewState["Country"] = ddlDTHguestscountry.SelectedValue;
            ViewState["PostalCode"] = txtPostalCodeDTH.Text;
            MpeSignUP.Hide();
            MpLogin1.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnNetConnectRecharge_Click(object sender, EventArgs e)
    {
        try
        {
            Session["DataConnectNumber"] = TextBox123.Text.Trim();
            Session["RMobileNumber"] = TextBox123.Text.Trim();
            Session["DataConncetprovider"] = ddlNetConnect.SelectedItem.Text;
            // Session["RRechargeAmount"] = txtRechargeAmount.Text.Trim();
            Session["RRechargeAmount"] = ddlDatacardRechargeAmount.SelectedItem.Text;
            Session["REmailMobile"] = txtEmailnet.Text.Trim();



            ViewState["Address"] = txtdcguestadddress.Text;
            ViewState["Name"] = txtdcguestname.Text;
            ViewState["City"] = txtDataCardCity.Text;
            ViewState["State"] = txtdatacardState.Text;
            ViewState["Country"] = ddlDatacardcountry.SelectedValue;
            ViewState["PostalCode"] = txtDataCardPostalCode.Text;

            MpeSignUP.Hide();
            MpLogin2.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region LoadingDropdowns in Popups
    protected void loadDropdown()
    {
        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.operatorsname;
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlProvider.DataSource = _objDataSet.Tables[0];
                    ddlProvider.DataTextField = "NetworkName";
                    ddlProvider.DataValueField = "OperatorKeyword";
                    ddlProvider.DataBind();

                    ddlProvider.Items.Insert(0, "Please Select");
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LoadDropdown1()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.operatorsname1;
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlD2HProvider.DataSource = _objDataSet.Tables[0];
                    ddlD2HProvider.DataTextField = "NetworkName";
                    ddlD2HProvider.DataValueField = "OperatorKeyword";
                    ddlD2HProvider.DataBind();
                    ddlD2HProvider.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void LoadDropdown2()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.operatorsname2;
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlNetConnect.DataSource = _objDataSet.Tables[0];
                    ddlNetConnect.DataTextField = "NetworkName";
                    ddlNetConnect.DataValueField = "OperatorKeyword";
                    ddlNetConnect.DataBind();
                    ddlNetConnect.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Recharging Code
    protected string GenerateRandomNumber(int count)
    {
        try
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            int number;
            for (int i = 0; i < count; i++)
            {
                number = random.Next(11);
                builder.Append(number);
            }

            return builder.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void imgbtnGuest_Click(object sender, ImageClickEventArgs e)
    {

        try
        {

            int check;
            Session["Role"] = null;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.MobileNum = txtMobile.Text.Trim();
            _objMaster.Parameter = "Mobile";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {
                Session["RMobileNumber"] = txtMobile.Text.Trim();
                Session["RProviderName"] = ddlProvider.SelectedValue;
                Session["REmailMobile"] = txtEmailMobile.Text.Trim();
                // Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                Session["RRechargeAmount"] = ddlrechargeamount.SelectedItem.Text;
                lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.Mobilenew;
                _objMaster.Mobile_Num = txtMobile.Text.Trim();
                _objMaster.Provider_Name = ddlProvider.SelectedValue;
                _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);

                _objMaster.Name = txtGuestname.Text;
                _objMaster.Address = txtmobileguestaddress.Text;
                _objMaster.Statename = txtMobileState.Text;
                _objMaster.cityname = txtMobileCity.Text;
                _objMaster.PostalCode = txtMobilePostalCode.Text;
                _objMaster.CountryName = ddlmobileguestscountry.SelectedValue;

                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion
              
                Response.Redirect("Pay.aspx", false);
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = txtMobile.Text.Trim();
                    Session["RProviderName"] = ddlProvider.SelectedValue;
                    Session["REmailMobile"] = txtEmailMobile.Text.Trim();
                    //Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);
                    lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;

                    //  MobileRecharge();

                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    _objMaster.Mobile_Num = txtMobile.Text.Trim();
                    _objMaster.Provider_Name = ddlProvider.SelectedValue;
                    _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                    // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);

                    _objMaster.Name = txtGuestname.Text;
                    _objMaster.Address = txtmobileguestaddress.Text;
                    _objMaster.Statename = txtMobileState.Text;
                    _objMaster.cityname = txtMobileCity.Text;
                    _objMaster.PostalCode = txtMobilePostalCode.Text;
                    _objMaster.CountryName = ddlmobileguestscountry.SelectedValue;

                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion
                  
                    Response.Redirect("Pay.aspx", false);

                }
                else
                {
                    lblMessage.Text = "Please Try Again After 15 Minutes";
                    Mpe1.Show();

                }

            }
        }

        catch (Exception ex)
        {
            LogError("Default.aspx", "imgbtnGuest_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
        finally
        {

            _objDataSet = null;
        }
    }

    protected void ImgbtnDTHguests_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int check;
            Session["Role"] = null;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.Customer_ID = txtCustID.Text.Trim();
            _objMaster.Parameter = "DTH";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {

                _objMaster.ScreenInd = Masters.Mobilenew;
                Session["RMobileNumber"] = txtCustID.Text.Trim();
                Session["Rd2hProviderName"] = ddlD2HProvider.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                //Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                Session["RRechargeAmount"] = ddlD2HAmount.SelectedItem.Text;
                lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.D2H;
                _objMaster.Customer_ID = txtCustID.Text.Trim();
                _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Text;
                _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim())
                _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);

                _objMaster.Name = txtGusetdthname.Text;
                _objMaster.Address = txtdthguestaddress.Text;
                _objMaster.Statename = txtDTHState.Text;
                _objMaster.cityname = txtDTHCity.Text;
                _objMaster.PostalCode = txtPostalCodeDTH.Text;
                _objMaster.CountryName = ddlDTHguestscountry.SelectedValue;

                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion
               
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);

                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = txtCustID.Text.Trim();
                    Session["Rd2hProviderName"] = ddlD2HProvider.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                    // Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);
                    lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.D2H;
                    _objMaster.Customer_ID = txtCustID.Text.Trim();
                    _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Text;
                    _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                    //  _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);

                    _objMaster.Name = txtGusetdthname.Text;
                    _objMaster.Address = txtdthguestaddress.Text;
                    _objMaster.Statename = txtDTHState.Text;
                    _objMaster.cityname = txtDTHCity.Text;
                    _objMaster.PostalCode = txtPostalCodeDTH.Text;
                    _objMaster.CountryName = ddlDTHguestscountry.SelectedValue;



                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion
                 
                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }
         
            Response.Redirect("Pay.aspx", false);
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "ImgbtnDTHguests_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void ImgbtnNetguests_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int check;
            Session["Role"] = null;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.MobileNum = Session["RMobileNumber"].ToString();// txtMobile.Text.Trim();
            _objMaster.Parameter = "DataCard";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();
            if (_objDataSet.Tables[0].Rows.Count == 0)
            {
                _objMaster.ScreenInd = Masters.DataCardnew;
                Session["RMobileNumber"] = TextBox123.Text.Trim();
                Session["DRProviderName"] = ddlNetConnect.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailnet.Text.Trim();
                //Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.DataCardnew;
                _objMaster.Mobile = TextBox123.Text.Trim();
                _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                _objMaster.E_Mail = txtEmailnet.Text.Trim();
                //  _objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                _objMaster.Name = txtdcguestname.Text;
                _objMaster.Address = txtdcguestadddress.Text;
                _objMaster.Statename = txtdatacardState.Text;
                _objMaster.cityname = txtDataCardCity.Text;
                _objMaster.PostalCode = txtDataCardPostalCode.Text;
                _objMaster.CountryName = ddlDatacardcountry.SelectedValue;


                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion
              
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);

                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = TextBox123.Text.Trim();
                    Session["DRProviderName"] = ddlNetConnect.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailnet.Text.Trim();
                    //  Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);
                    lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.DataCardnew;
                    _objMaster.Mobile_Num = TextBox123.Text.Trim();
                    _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmailnet.Text.Trim();
                    // _objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                    _objMaster.Name = txtdcguestname.Text;
                    _objMaster.Address = txtdcguestadddress.Text;
                    _objMaster.Statename = txtdatacardState.Text;
                    _objMaster.cityname = txtDataCardCity.Text;
                    _objMaster.PostalCode = txtDataCardPostalCode.Text;
                    _objMaster.CountryName = ddlDatacardcountry.SelectedValue;


                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion
                  
                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }
          
            Response.Redirect("Pay.aspx", false);
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "ImgbtnNetguests_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void mobileguests()
    {
        try
        {
            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.MobileNum = txtMobile.Text.Trim();
            _objMaster.Parameter = "Mobile";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {
                Session["RMobileNumber"] = txtMobile.Text.Trim();
                Session["RProviderName"] = ddlProvider.SelectedValue;
                Session["REmailMobile"] = txtEmailMobile.Text.Trim();
                // Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                Session["RRechargeAmount"] = ddlrechargeamount.SelectedItem.Text;
                lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.Mobilenew;
                _objMaster.Mobile_Num = txtMobile.Text.Trim();
                _objMaster.Provider_Name = ddlProvider.SelectedValue;
                _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);

                _objMaster.Name = txtGuestname.Text;
                _objMaster.Address = txtmobileguestaddress.Text;
                _objMaster.Statename = txtMobileState.Text;
                _objMaster.cityname = txtMobileCity.Text;
                _objMaster.PostalCode = txtMobilePostalCode.Text;

                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion

                // Response.Redirect("Pay.aspx", false);
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = txtMobile.Text.Trim();
                    Session["RProviderName"] = ddlProvider.SelectedValue;
                    Session["REmailMobile"] = txtEmailMobile.Text.Trim();
                    //Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);
                    lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;

                    //  MobileRecharge();

                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    _objMaster.Mobile_Num = txtMobile.Text.Trim();
                    _objMaster.Provider_Name = ddlProvider.SelectedValue;
                    _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                    // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlrechargeamount.SelectedItem.Text);

                    _objMaster.Name = txtGuestname.Text;
                    _objMaster.Address = txtmobileguestaddress.Text;
                    _objMaster.Statename = txtMobileState.Text;
                    _objMaster.cityname = txtMobileCity.Text;
                    _objMaster.PostalCode = txtMobilePostalCode.Text;

                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion

                    // Response.Redirect("Pay.aspx", false);

                }
                else
                {
                    lblMessage.Text = "Please Try Again After 15 Minutes";
                    Mpe1.Show();

                }

            }
        }

        catch (Exception ex)
        {
            LogError("Default.aspx", "mobileguests", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
        finally
        {

            _objDataSet = null;
        }
    }

    protected void DThGuests()
    {
        try
        {
            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.Customer_ID = txtCustID.Text.Trim();
            _objMaster.Parameter = "DTH";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {

                _objMaster.ScreenInd = Masters.Mobilenew;
                Session["RMobileNumber"] = txtCustID.Text.Trim();
                Session["Rd2hProviderName"] = ddlD2HProvider.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                //Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                Session["RRechargeAmount"] = ddlD2HAmount.SelectedItem.Text;
                lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.D2H;
                _objMaster.Customer_ID = txtCustID.Text.Trim();
                _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Text;
                _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim())
                _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);

                _objMaster.Name = txtGusetdthname.Text;
                _objMaster.Address = txtdthguestaddress.Text;
                _objMaster.Statename = txtDTHState.Text;
                _objMaster.cityname = txtDTHCity.Text;
                _objMaster.PostalCode = txtPostalCodeDTH.Text;


                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion
                //Response.Redirect("Checkout.aspx");
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);

                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = txtCustID.Text.Trim();
                    Session["Rd2hProviderName"] = ddlD2HProvider.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                    // Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);
                    lblOrderID.Text = Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.D2H;
                    _objMaster.Customer_ID = txtCustID.Text.Trim();
                    _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Text;
                    _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                    //  _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.SelectedItem.Text);

                    _objMaster.Name = txtGusetdthname.Text;
                    _objMaster.Address = txtdthguestaddress.Text;
                    _objMaster.Statename = txtDTHState.Text;
                    _objMaster.cityname = txtDTHCity.Text;
                    _objMaster.PostalCode = txtPostalCodeDTH.Text;


                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion

                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }

            // Response.Redirect("Pay.aspx", false);
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "DThGuests", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void DataCardguests()
    {
        try
        {
            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettime;
            _objMaster.MobileNum = Session["RMobileNumber"].ToString();// txtMobile.Text.Trim();
            _objMaster.Parameter = "DataCard";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();
            if (_objDataSet.Tables[0].Rows.Count == 0)
            {
                _objMaster.ScreenInd = Masters.DataCardnew;
                Session["RMobileNumber"] = TextBox123.Text.Trim();
                Session["DRProviderName"] = ddlNetConnect.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailnet.Text.Trim();
                //Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.DataCardnew;
                _objMaster.Mobile = TextBox123.Text.Trim();
                _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                _objMaster.E_Mail = txtEmailnet.Text.Trim();
                //  _objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                _objMaster.Name = txtdcguestname.Text;
                _objMaster.Address = txtdcguestadddress.Text;
                _objMaster.Statename = txtdatacardState.Text;
                _objMaster.cityname = txtDataCardCity.Text;
                _objMaster.PostalCode = txtDataCardPostalCode.Text;


                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = lblOrderID.Text.Trim();
                _objMaster.TransactionID = Convert.ToString(1111);
                _objMaster.IP = ipaddr;
                _objMaster.Status = "PENDING";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.fnInsertRecord();
                #endregion
                //Response.Redirect("Checkout.aspx");
            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);

                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobilenew;
                    Session["RMobileNumber"] = TextBox123.Text.Trim();
                    Session["DRProviderName"] = ddlNetConnect.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailnet.Text.Trim();
                    //  Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);
                    lblOrderID.Text =  Convert.ToString(GenerateRandomNumber(11));
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.DataCardnew;
                    _objMaster.Mobile_Num = TextBox123.Text.Trim();
                    _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmailnet.Text.Trim();
                    // _objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.SelectedItem.Text);

                    _objMaster.Name = txtdcguestname.Text;
                    _objMaster.Address = txtdcguestadddress.Text;
                    _objMaster.Statename = txtdatacardState.Text;
                    _objMaster.cityname = txtDataCardCity.Text;
                    _objMaster.PostalCode = txtDataCardPostalCode.Text;


                    _objMaster.Payment = "Deposit";
                    _objMaster.RequestID = lblOrderID.Text.Trim();
                    _objMaster.TransactionID = Convert.ToString(1111);
                    _objMaster.IP = ipaddr;
                    _objMaster.Status = "PENDING";
                    _objMaster.CreatedBy = "NA";
                    _objMaster.ModifiedBy = "NA";
                    _objMaster.ModifiedDate = "NA";
                    _objMaster.fnInsertRecord();
                    #endregion

                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }

            // Response.Redirect("Pay.aspx");
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "DataCardguests", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }


    #endregion

    #region Login&SignUp
    protected void Imagebtnsignup_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignUP.Show();
        txtEmailID1.Text = Session["REmailMobile"].ToString();
        txtFirstName.Text = ViewState["Name"].ToString();
        txtaddress1.Text = ViewState["Address"].ToString();
        txtState.Text = ViewState["State"].ToString();
        txtCity.Text = ViewState["City"].ToString();
        txtPassword1.Text = "";
        txtConformPassword.Text = "";
        ddlCountry.SelectedValue = ViewState["Country"].ToString();
        txtMobileNum.Text = Session["RMobileNumber"].ToString();
        txtUserpostalcode.Text = ViewState["PostalCode"].ToString();
    }

    protected void imgbtnsignup1_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignUP.Show();
        txtEmailID1.Text = Session["REmailMobile"].ToString();
        txtFirstName.Text = ViewState["Name"].ToString();
        txtaddress1.Text = ViewState["Address"].ToString();
        txtState.Text = ViewState["State"].ToString();
        txtCity.Text = ViewState["City"].ToString();
        txtPassword1.Text = "";
        txtConformPassword.Text = "";
        txtMobileNum.Text = "";
        ddlCountry.SelectedValue = ViewState["Country"].ToString();
        txtUserpostalcode.Text = ViewState["PostalCode"].ToString();
    }

    protected void imgbtnsignupNet_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignUP.Show();
        txtEmailID1.Text = Session["REmailMobile"].ToString();
        txtFirstName.Text = ViewState["Name"].ToString();
        txtaddress1.Text = ViewState["Address"].ToString();
        txtState.Text = ViewState["State"].ToString();
        txtCity.Text = ViewState["City"].ToString();
        txtPassword1.Text = "";
        txtConformPassword.Text = "";
        txtMobileNum.Text = Session["RMobileNumber"].ToString();

        ddlCountry.SelectedValue = ViewState["Country"].ToString();
        txtUserpostalcode.Text = ViewState["PostalCode"].ToString();
        lblMsg1.Text = "";
    }

    public void checkUser()
    {
        try
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
        catch (Exception ex)
        {
            LogError("Default.aspx", "CheckUser", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {

            checkUser();

            if (Checked == "available")
            {

                _objMasters = new clsMasters();
                _objMasters.ScreenInd = Masters.UserMst;
                _objMasters.EmailID = txtEmailID1.Text.Trim().ToString();
                _objMasters.FirstName = txtFirstName.Text.Trim();
                _objMasters.Mobile_Num = txtMobileNum.Text.Trim();
                _objMasters.Password = txtPassword1.Text.Trim().ToString();
                _objMasters.Address = txtaddress1.Text.Trim();
                _objMasters.Statename = txtState.Text.Trim();
                _objMasters.cityname = txtCity.Text.Trim();
                _objMasters.CountryName = ddlCountry.SelectedValue;
                _objMasters.PostalCode = txtUserpostalcode.Text.Trim();
                if (_objMasters.fnInsertRecord() == true)
                {
                    lblMsg1.ForeColor = Color.Green;
                    lblMsg2.ForeColor = Color.Green;
                    //     MpeSignUP.Show();
                    lblMsg1.Text = "Confirmation: ";
                    lblMsg2.Text = "Successfully Registered";

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
                    clearfields();
                }
            }
            else if (Checked == "null")
            {
                MpeSignUP.Show();
                lblMsg1.Text = "Email Id Already Exists";
                lblMsg1.Visible = true;
                lblMsg1.ForeColor = Color.Red;

                //lblMessage.Text = "Email Id Already Exists";
                //Mpe1.Show();
                //clearfields();
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "btnSignUp_Click", DateTime.Now, ex.Message.ToString());
            // Response.Redirect("Error.aspx", false);
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
                Response.Redirect("~/Masters/HomePage.aspx", false);
            }

        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "Login", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }
    protected void methodcall()
    {
        // MpeSignIn.Show();
    }

    protected void btnLogin11_Click1(object sender, EventArgs e)
    {
        try
        {
            _objUserAuth = new clsUserAuthentication();
            _objUserAuth.strEmailID = txtEmailID11.Text.Trim().ToString().ToLower();
            _objUserAuth.strPassword = txtpassword11.Text.Trim().ToString().ToLower();

            if (_objUserAuth.fnCheckAPRUser() == true)
            {
                if (ViewState["type"].ToString() == "Mobile")
                {
                    mobileguests();

                    Response.Redirect("User/PaymentMethod.aspx", false);
                    //imgbtnGuest.Click+-new ImageClickEventHandler(imgbtnGuest_Click);
                    //Buttonname.click + -new ImageClickEventHandler(Buttonname_click);
                }
                else if (ViewState["type"].ToString() == "DTH")
                {
                    DThGuests();
                    //ImgbtnDTHguests_Click(sender, e);
                    Response.Redirect("User/PaymentMethod1.aspx", false);
                }
                else if (ViewState["type"].ToString() == "DataCard")
                {
                    DataCardguests();
                    // ImgbtnNetguests_Click(sender, e);
                    Response.Redirect("User/PaymentMethod2.aspx", false);
                }
            }
            else
            {
               // txtEmailID.Focus();
                lblErrormesg.Text = "Please recheck your UserName and Password";
                MpeSignIn1.Show();
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "btnLogin11_Click1", DateTime.Now, ex.Message.ToString());
            Response.Redirect("Error.aspx", false);
        }
    }
    protected void imgbtnsignin_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignIn1.Show();
        ViewState["type"] = "Mobile";
    }


    protected void imgbtnsignin1_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignIn1.Show();
        ViewState["type"] = "DTH";
    }


    protected void imgbtnsigninNet_Click(object sender, ImageClickEventArgs e)
    {
        MpeSignIn1.Show();
        ViewState["type"] = "DataCard";
    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        _objUserAuth = new clsUserAuthentication();

    //        //string strEncryptPwd = string.Empty;
    //        //string strPassword = "¶¾±";
    //        //strPassword += txtPassword.Text.Trim().ToString().ToLower();
    //        //strPassword += "¶¾±";
    //        //strPassword += txtEmailID.Text.Trim().ToString().ToLower();
    //        //strPassword += "¶¾±";
    //        //strEncryptPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "md5");

    //        _objUserAuth.strEmailID = txtEmailID.Text.Trim().ToString().ToLower();

    //        //_objUserAuth.strUserType = UserType.ToString();
    //        _objUserAuth.strPassword = txtPassword.Text.Trim().ToString().ToLower();

    //        if (_objUserAuth.fnCheckAPRUser() == true)
    //        {
    //            Session["Password"] = txtPassword.Text.Trim();
    //            Response.Redirect("Masters/HomePage.aspx", false);
    //        }
    //        else
    //        {
    //            txtEmailID.Focus();
    //            lblErrormsg1.Text = "Please recheck your UserName and Password";
    //            MpeSignIn.Show();
    //            clearfields();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError("Default.aspx", "btnLogin_Click", DateTime.Now, ex.Message.ToString());
    //        Response.Redirect("Error.aspx", false);
    //    }
    //}

   
    protected void lnkbtnsignup_Click(object sender, EventArgs e)
    {
        MpeSignUP.Show();
        txtEmailID1.Text = "";
        txtFirstName.Text = "";
        txtaddress1.Text = "";
        txtState.Text = "";
        txtCity.Text = "";
        txtPassword1.Text = "";
        txtConformPassword.Text = "";
        txtMobileNum.Text = "";
    }

    protected void lnkmyaccount_click(object sender, EventArgs e)
    {
       // MpeSignIn.Show();
    }

    protected void btnLoginn_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _objUserAuth = new clsUserAuthentication();
            //  _objUserAuth.strEmailID = txtUserName.Text.Trim().ToString().ToLower();
            // _objUserAuth.strPassword = txtPasswordd.Text.Trim().ToString().ToLower();
            if (_objUserAuth.fnCheckAPRUser() == true)
            {
                Response.Redirect("Masters/HomePage.aspx", false);
            }
            else
            {
                //txtEmailID.Focus();
                lblMessage.Text = "Please recheck your UserName and Password";
                Mpe1.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

    protected void lnkbtnforgotpassword_click(object sender, EventArgs e)
    {
        Session["Type"] = "User";
        Response.Redirect("ForgotPassword.aspx", false);
    }
    protected void lnkbtnHowtoRecharge_Click(object sender, EventArgs e)
    {
        Response.Redirect("HowToRecharge.aspx", false);
    }
    protected void lnkbtnContactUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs.aspx", false);
    }

    protected void lnkmyaccount_Click(object sender, EventArgs e)
    {

    }

    protected void btnLoginn_Click(object sender, EventArgs e)
    {
        //MpeSignIn.Show();
    }
    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetRechargeAmount;
            _objMasters.NetworkName = ddlProvider.SelectedItem.Text;
            Session["NetWorkName"] = ddlProvider.SelectedItem.Text;

            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlrechargeamount.DataSource = _objDataSet.Tables[0];
                    ddlrechargeamount.DataTextField = "RechargeAmount";
                    ddlrechargeamount.DataValueField = "ID";
                    ddlrechargeamount.DataBind();
                    ddlrechargeamount.Items.Insert(0, "Please Select");


                }
                else
                {
                    ddlrechargeamount.Items.Clear();
                    ddlrechargeamount.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "ddlProvider_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }
    protected void ddlD2HProvider_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            // mpDTH.Show();
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetRechargeAmount;
            _objMasters.NetworkName = ddlD2HProvider.SelectedItem.Text;

            Session["NetWorkName"] = ddlD2HProvider.SelectedItem.Text;

            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlD2HAmount.DataSource = _objDataSet.Tables[0];
                    ddlD2HAmount.DataTextField = "RechargeAmount";
                    ddlD2HAmount.DataValueField = "ID";
                    ddlD2HAmount.DataBind();
                    ddlD2HAmount.Items.Insert(0, "Please Select");
                }
                else
                {
                    ddlD2HAmount.Items.Clear();
                    ddlD2HAmount.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "ddlD2HProvider_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }
    protected void ddlNetConnect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            // MpeNetconnect.Show();
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetRechargeAmount;
            _objMasters.NetworkName = ddlNetConnect.SelectedItem.Text;

            Session["NetWorkName"] = ddlNetConnect.SelectedItem.Text;

            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddlDatacardRechargeAmount.DataSource = _objDataSet.Tables[0];
                    ddlDatacardRechargeAmount.DataTextField = "RechargeAmount";
                    ddlDatacardRechargeAmount.DataValueField = "ID";
                    ddlDatacardRechargeAmount.DataBind();
                    ddlDatacardRechargeAmount.Items.Insert(0, "Please Select");
                }
                else
                {
                    ddlDatacardRechargeAmount.Items.Clear();
                    ddlDatacardRechargeAmount.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            LogError("Default.aspx", "ddlNetConnect_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
            throw ex;
        }

    }
}