using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
using HotelAPILayer;

public partial class Agent_Recharge_Utilities : System.Web.UI.Page
{
    #region Global Variables
    IArzooHotelAPILayer objArzooHotelAPILayer;
    ClsBAL objBAL;
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    string ipaddr;
    static string val = "false";
    decimal Commission;
    decimal DistributorCommission;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            if (!IsPostBack)
            {
                Panel tblsubmenu = (Panel)this.Master.FindControl("RechargeSubmenu");
                tblsubmenu.Visible = false;
                
                if (Session["UserID"] != null)
                {
                    //if (Session["RechargeAgentStatus"].ToString() != "0")
                    //{
                        getservices();
                        if (val != "true")
                        {
                            loadDropdown();
                            LoadDropdown1();
                          
                            tdmsg.Visible = false;
                            tdmob.Visible = true;
                        }
                        else
                        {
                            lblMainMsg.Text = "This Service is temporarily unavaliable";
                            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                            tdmsg.Visible = true;
                            tdmob.Visible = false;
                        }
                    //}
                    //else
                    //{
                    //    lblMainMsg.Text = "This Service is temporarily unavaliable";
                    //    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    //    tdmsg.Visible = true;
                    //    tdmob.Visible = false;
                    //}
                }
            }
        }
        catch (Exception ex)
        {
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

    #region LoadingDropdowns
    protected void loadDropdown()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.postpaid;
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
            _objMasters.ScreenInd = Masters.landline;
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ddllandlineProvider.DataSource = _objDataSet.Tables[0];
                    ddllandlineProvider.DataTextField = "NetworkName";
                    ddllandlineProvider.DataValueField = "OperatorKeyword";
                    ddllandlineProvider.DataBind();
                    ddllandlineProvider.Items.Insert(0, "Please Select");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


  

    #endregion

    #region Loading Amounts

    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{

        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.GetRechargeAmount;
        //    _objMasters.NetworkName = ddlProvider.SelectedItem.Text;

        //    Session["NetWorkName"] = ddlProvider.SelectedItem.Text;

        //    _objDataSet = (DataSet)_objMasters.fnGetData();


        //    if (_objDataSet.Tables.Count > 0)
        //    {
        //        if (_objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            ddlMobilerechargeamount.DataSource = _objDataSet.Tables[0];
        //            ddlMobilerechargeamount.DataTextField = "RechargeAmount";
        //            ddlMobilerechargeamount.DataValueField = "ID";
        //            ddlMobilerechargeamount.DataBind();
        //            ddlMobilerechargeamount.Items.Insert(0, "Please Select");

        //            Session["TypeOfTranscation"] = _objDataSet.Tables[0].Rows[0]["TypeOfTransaction"].ToString();

        //        }
        //        else
        //        {
        //            ddlMobilerechargeamount.Items.Clear();
        //            ddlMobilerechargeamount.Items.Insert(0, "Please Select");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //LogError("Masters/Recharge.aspx", "ddlProvider_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
        //    throw ex;
        //}
    }
    protected void ddlD2HProvider_SelectedIndexChanged(object sender, EventArgs e)
    {

        //try
        //{

        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.GetRechargeAmount;
        //    _objMasters.NetworkName = ddlD2HProvider.SelectedItem.Text;
        //    Session["NetWorkName"] = ddlD2HProvider.SelectedItem.Text;

        //    _objDataSet = (DataSet)_objMasters.fnGetData();
        //    if (_objDataSet.Tables.Count > 0)
        //    {
        //        if (_objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            ddlD2HAmount.DataSource = _objDataSet.Tables[0];
        //            ddlD2HAmount.DataTextField = "RechargeAmount";
        //            ddlD2HAmount.DataValueField = "ID";
        //            ddlD2HAmount.DataBind();
        //            ddlD2HAmount.Items.Insert(0, "Please Select");


        //            Session["TypeOfTranscation"] = _objDataSet.Tables[0].Rows[0]["TypeOfTransaction"].ToString();

        //        }
        //        else
        //        {
        //            ddlD2HAmount.Items.Clear();
        //            ddlD2HAmount.Items.Insert(0, "Please Select");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //LogError("Masters/Recharge.aspx", "ddlD2HProvider_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
        //    throw ex;
        //}

    }
    protected void ddlNetConnect_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{


        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.GetRechargeAmount;
        //    _objMasters.NetworkName = ddlNetConnect.SelectedItem.Text;
        //    Session["NetWorkName"] = ddlNetConnect.SelectedItem.Text;

        //    _objDataSet = (DataSet)_objMasters.fnGetData();
        //    if (_objDataSet.Tables.Count > 0)
        //    {
        //        if (_objDataSet.Tables[0].Rows.Count > 0)
        //        {
        //            ddlDatacardRechargeAmount.DataSource = _objDataSet.Tables[0];
        //            ddlDatacardRechargeAmount.DataTextField = "RechargeAmount";
        //            ddlDatacardRechargeAmount.DataValueField = "ID";
        //            ddlDatacardRechargeAmount.DataBind();
        //            ddlDatacardRechargeAmount.Items.Insert(0, "Please Select");
        //        }
        //        else
        //        {
        //            ddlDatacardRechargeAmount.Items.Clear();
        //            ddlDatacardRechargeAmount.Items.Insert(0, "Please Select");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //LogError("Masters/Recharge.aspx", "ddlNetConnect_SelectedIndexChanged", DateTime.Now, ex.Message.ToString());
        //    throw ex;
        //}
    }

    #endregion

    #region Click Event iN Recharge
    protected void btnMobileRecharge_Click(object sender, EventArgs e)
    {
        try
        {
            Session["RMobileNumber"] = txtMobile.Text.Trim();
            Session["ProviderName"] = ddlProvider.SelectedItem.Text;
            Session["RRechargeAmount"] = ddlMobilerechargeamount.Text.Trim();
            Session["REmailMobile"] = txtEmailMobile.Text.Trim();


            Session["NetWorkName"] = ddlProvider.SelectedItem.Text;

            if (Session["Role"].ToString() == "User")
            {
                //MpLogin.Show();
                imgbtnGuest_Click(sender, e);
            }
            else if (Session["Role"].ToString() == "Agent")
            {
                mpeagentproceed.Show();
                txtagentMob.Text = Session["RMobileNumber"].ToString();
                txtagentrec.Text = Session["RRechargeAmount"].ToString();
                txtagentprovider.Text = ddlProvider.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "Admin")
            {
                txtagentMob.Text = Session["RMobileNumber"].ToString();
                txtagentrec.Text = Session["RRechargeAmount"].ToString();
                txtagentprovider.Text = ddlProvider.SelectedItem.Text;
                mpeagentproceed.Show();
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnlandlineRecharge_Click(object sender, EventArgs e)
    {
        try
        {
            Session["RMobileNumber"] = txtCustID.Text.Trim();
            Session["ProviderNameDTH"] = ddllandlineProvider.SelectedItem.Text;
            //   Session["RRechargeAmount"] = txtD2HAmount.Text.Trim();
            Session["RRechargeAmount"] = ddllandlineAmount.Text.Trim();
            Session["REmailMobile"] = txtEmaillandline.Text.Trim();

            Session["NetWorkName"] = ddllandlineProvider.SelectedItem.Text;


            if (Session["Role"].ToString() == "User")
            {
                // MpLogin1.Show();
                imgbtnGuest1_Click(sender, e);

            }
            else if (Session["Role"].ToString() == "Agent")
            {
                mpeagentD2h.Show();
                txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                txtagntd2hprovider.Text = ddllandlineProvider.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "Admin")
            {
                mpeagentD2h.Show();
                txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                txtagntd2hprovider.Text = ddllandlineProvider.SelectedItem.Text;

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    #endregion

    #region Common methods
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

    protected void getip()
    {

        ipaddr = Page.Request.UserHostAddress;

    }

    protected void getbalance()
    {
        try
        {

            objBAL = new ClsBAL();
            DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            Session["AgentBalance"] = Convert.ToDecimal(dsBalance.Tables[0].Rows[0]["Balance"].ToString());
            Session["CommisionPercentage_Agent"] = dsBalance.Tables[0].Rows[0]["CommisionPercentage"].ToString();
            Session["AgentId_Agent"] = dsBalance.Tables[0].Rows[0]["AgentId"].ToString();
        }
        catch (Exception ex)
        {
        }
    }

    protected void getstatus()
    {
        try
        {
            //("http://api.buysmart.co.in/hydrasales/services/thirdpartyapi.asmx/TransactionStatus?GUID=" + "FCC4FE618FD28CE4" + "&UID=" + Session["Order_Id"].ToString());
            //      HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            //                ("http://www.payintegra.com/RealStatus?PartnerID=" + "10118" + "&TransId=" + "12342342345" + "&Hash=" + "A8JW8FX7KQ7PY5ZT2S1V12342342345love@123");
            //request.Method = "GET";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //DataSet ds4 = null;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    StreamReader responseReader = new StreamReader(response.GetResponseStream());
            //    string responseData = responseReader.ReadToEnd();
            //    XmlDocument doc = new XmlDocument();
            //    doc.LoadXml(responseData);
            //    XmlNodeReader xmlReader = new XmlNodeReader(doc);
            //    ds4 = new DataSet();
            //    ds4.ReadXml(xmlReader);

            //    Session["GetStatus"] = ds4.Tables["TransactionDetails"].Rows[0]["TransactionStatus"].ToString();
            //    Session["TranscationId"] = ds4.Tables["TransactionDetails"].Rows[0]["TransactionId"].ToString();
            //Session["Serial"] = ds4.Tables["TransactionDetails"].Rows[0]["Serial"].ToString();
            //Session["Pin"] = ds4.Tables["TransactionDetails"].Rows[0]["Pin"].ToString();


            //LogError("Recharge.aspx", "Status", DateTime.Now, Session["GetStatus"].ToString());


            //LogError("Redirect.aspx", "Pageload3", DateTime.Now, "Pageload2");       
            string URL1 = "http://www.payintegra.com/RealStatus?PartnerID=" + "10118" + "&TransId=" + "12342342345" + "&Hash=" + "A8JW8FX7KQ7PY5ZT2S1V12342342345love@123";
            HttpWebRequest oReq2 = null;
            HttpWebResponse oRes2 = null;
            StreamReader oStream2 = null;
            oReq2 = (HttpWebRequest)WebRequest.Create(URL1);
            oReq2.Method = "GET";
            oReq2.Timeout = 10000;
            oRes2 = (HttpWebResponse)oReq2.GetResponse();
            oStream2 = new StreamReader(oRes2.GetResponseStream(), Encoding.GetEncoding(1252));
            string strMessage2 = oStream2.ReadToEnd().ToString();
            //string[] s1 = strMessage2.Split('|');        
            //Session["GetStatus"] = s1[0].ToString();
            //if (s1[0].ToString() == "Pending")
            //{
            //    LogError("Redirect.aspx", "Pending", DateTime.Now, strMessage2.ToString());
            //    getstatus();
            //}
            //else
            //{
            //    LogError("Redirect.aspx", "Success", DateTime.Now, strMessage2.ToString());
            //}
            // }


        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "getstatus", DateTime.Now, ex.Message.ToString());
            throw ex;
        }


    }


    public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare, double commisionFare, int commisionPercentage)
    {
        try
        {
            objBAL = new ClsBAL();
            return objBAL.DeductAgentBalance(agentId, deductAmount, createdBy, mbRefNo,
                actualFare, commisionFare, commisionPercentage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Proceed to recharge click events
    protected void imgbtnGuest_Click(object sender, EventArgs e)
    {
        try
        {

            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettimeforusers;
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
                Session["RRechargeAmount"] = Convert.ToDouble(ddlMobilerechargeamount.Text.Trim());
                lblOrderID.Text = GenerateRandomNumber(11);
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.Mobile;
                _objMaster.Mobile_Num = txtMobile.Text.Trim();
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);

                _objMaster.Type = "AG";

                _objMaster.Provider_Name = ddlProvider.SelectedItem.Value;
                _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlMobilerechargeamount.Text.Trim());
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

                getbalance();
                if (Session["Role"].ToString() == "User")
                {

                    Response.Redirect("../User/PaymentMethod.aspx", false);

                    // Response.Redirect("../Pay.aspx", false);
                }
                else if (Session["Role"].ToString() == "Agent")
                {

                    if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                    {

                        lbllowbalance.Text = "";
                        mobilerecharge();
                    }
                    else
                    {
                        mpeagentproceed.Show();
                        lbllowbalance.Visible = true;
                        lbllowbalance.Text = "Recharge failed.Please contact administrator.";
                        lbllowbalance.ForeColor = Color.Red;
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    lbllowbalance.Text = "";
                    //  adminmobilerecharge();
                }

            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobile;
                    Session["RMobileNumber"] = txtMobile.Text.Trim();
                    Session["RProviderName"] = ddlProvider.SelectedValue;
                    Session["REmailMobile"] = txtEmailMobile.Text.Trim();
                    // Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlMobilerechargeamount.Text.Trim());
                    lblOrderID.Text = GenerateRandomNumber(11);
                    Session["Order_Id"] = lblOrderID.Text;

                    //  MobileRecharge();

                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.Mobile;
                    _objMaster.Mobile_Num = txtMobile.Text.Trim();
                    _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                    _objMaster.Type = "AG";
                    _objMaster.Provider_Name = ddlProvider.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmailMobile.Text.Trim();
                    //  _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlMobilerechargeamount.Text.Trim());
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
                    getbalance();
                    if (Session["Role"].ToString() == "User")
                    {
                        Response.Redirect("../User/PaymentMethod.aspx", false);
                        // Response.Redirect("../Pay.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Agent")
                    {
                        if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                        {


                            lbllowbalance.Text = "";
                            mobilerecharge();
                        }
                        else
                        {
                            mpeagentproceed.Show();
                            lbllowbalance.Visible = true;
                            lbllowbalance.Text = "Recharge failed.Please contact administrator.";
                            lbllowbalance.ForeColor = Color.Red;
                        }

                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                        //adminmobilerecharge();
                    }

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
            //LogError("Masters/Recharge.aspx", "imgbtnGuest_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
        finally
        {

            _objDataSet = null;
        }

    }

    protected void imgbtnGuest1_Click(object sender, EventArgs e)
    {
        try
        {

            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettimeforusers;
            _objMaster.MobileNum = txtCustID.Text.Trim();
            _objMaster.Parameter = "DTH";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {
                Session["RMobileNumber"] = txtCustID.Text.Trim();
                Session["RProviderName"] = ddllandlineProvider.SelectedValue;
                Session["REmailMobile"] = txtEmaillandline.Text.Trim();
                // Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                Session["RRechargeAmount"] = Convert.ToDouble(ddllandlineAmount.Text.Trim());
                lblOrderID.Text = GenerateRandomNumber(11);
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.Mobile;
                _objMaster.Mobile_Num = txtCustID.Text.Trim();
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);

                _objMaster.Type = "AG";

                _objMaster.Provider_Name = ddllandlineProvider.SelectedItem.Value;
                _objMaster.E_Mail = txtEmaillandline.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddllandlineAmount.Text.Trim());
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

                getbalance();
                if (Session["Role"].ToString() == "User")
                {

                    Response.Redirect("../User/PaymentMethod.aspx", false);

                    // Response.Redirect("../Pay.aspx", false);
                }
                else if (Session["Role"].ToString() == "Agent")
                {

                    if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                    {

                        lbllowbalance.Text = "";
                        landline();
                    }
                    else
                    {
                        mpeagentproceed.Show();
                        lbllowbalance.Visible = true;
                        lbllowbalance.Text = "Recharge failed.Please contact administrator.";
                        lbllowbalance.ForeColor = Color.Red;
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    lbllowbalance.Text = "";
                    //  adminmobilerecharge();
                }

            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.Mobile;
                    Session["RMobileNumber"] = txtCustID.Text.Trim();
                    Session["RProviderName"] = ddllandlineProvider.SelectedValue;
                    Session["REmailMobile"] = txtEmaillandline.Text.Trim();
                    // Session["RRechargeAmount"] = Convert.ToDouble(txtRecAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddllandlineAmount.Text.Trim());
                    lblOrderID.Text = GenerateRandomNumber(11);
                    Session["Order_Id"] = lblOrderID.Text;

                    //  MobileRecharge();

                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.Mobile;
                    _objMaster.Mobile_Num = txtCustID.Text.Trim();
                    _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                    _objMaster.Type = "AG";
                    _objMaster.Provider_Name = ddllandlineProvider.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmaillandline.Text.Trim();
                    //  _objMaster.Amount = Convert.ToDouble(txtRecAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddllandlineAmount.Text.Trim());
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
                    getbalance();
                    if (Session["Role"].ToString() == "User")
                    {
                        Response.Redirect("../User/PaymentMethod.aspx", false);
                        // Response.Redirect("../Pay.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Agent")
                    {
                        if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                        {


                            lbllowbalance.Text = "";
                            landline();
                        }
                        else
                        {
                            mpeagentproceed.Show();
                            lbllowbalance.Visible = true;
                            lbllowbalance.Text = "Recharge failed.Please contact administrator.";
                            lbllowbalance.ForeColor = Color.Red;
                        }

                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                        //adminmobilerecharge();
                    }

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
            //LogError("Masters/Recharge.aspx", "imgbtnGuest_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
        finally
        {

            _objDataSet = null;
        }

        //try
        //{
        //    int check;
        //    _objMaster = new clsMasters();
        //    _objMaster.ScreenInd = Masters.gettimeforusers;
        //    _objMaster.Customer_ID = txtCustID.Text.Trim();
        //    _objMaster.Parameter = "DTH";
        //    _objDataSet = new DataSet();
        //    _objDataSet = (DataSet)_objMaster.fnGetData();

        //    if (_objDataSet.Tables[0].Rows.Count == 0)
        //    {

        //        _objMaster.ScreenInd = Masters.D2Hnew;
        //        Session["RMobileNumber"] = txtCustID.Text.Trim();
        //        Session["RProviderName"] = ddllandlineProvider.SelectedItem.Value;
        //        Session["REmailMobile"] = txtEmaillandline.Text.Trim();
        //        //  Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
        //        Session["RRechargeAmount"] = Convert.ToDouble(ddllandlineAmount.Text.Trim());
        //        lblOrderID.Text = GenerateRandomNumber(11);
        //        Session["Order_Id"] = lblOrderID.Text;

        //        #region inserting
        //        _objMaster = new clsMasters();
        //        _objMaster.ScreenInd = Masters.D2Hnew;
        //        _objMaster.Customer_ID = txtCustID.Text.Trim();
        //        _objMaster.Provider_Name = ddllandlineProvider.SelectedItem.Value;
        //        _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
        //        _objMaster.Type = "AG";
        //        _objMaster.E_Mail = txtEmaillandline.Text.Trim();
        //        // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
        //        _objMaster.Amount = Convert.ToDouble(ddllandlineAmount.Text.Trim());
        //        _objMaster.Payment = "Deposit";
        //        _objMaster.RequestID = lblOrderID.Text.Trim();
        //        _objMaster.TransactionID = Convert.ToString(1111);
        //        _objMaster.IP = ipaddr;
        //        _objMaster.Status = "PENDING";
        //        _objMaster.CreatedBy = "NA";
        //        _objMaster.ModifiedBy = "NA";
        //        _objMaster.ModifiedDate = "NA";
        //        _objMaster.fnInsertRecord();
        //        #endregion

        //        getbalance();
        //        if (Session["Role"].ToString() == "User")
        //        {
        //            Response.Redirect("../User/Paymentmethod1.aspx", false);
        //        }
        //        else if (Session["Role"].ToString() == "Agent")
        //        {
        //            if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
        //            {
        //                lbllowbalance.Text = "";
        //                landline();
        //            }
        //            else
        //            {
        //                mpeagentD2h.Show();
        //                lnlLowd2hbalance.Visible = true;
        //                lnlLowd2hbalance.Text = "Recharge failed.Please contact administrator.";
        //                lnlLowd2hbalance.ForeColor = Color.Red;
        //            }

        //        }
        //        else if (Session["Role"].ToString() == "Admin")
        //        {
        //            // adminD2HRecharge();
        //        }

        //    }
        //    else if (_objDataSet.Tables[0].Rows.Count > 0)
        //    {

        //        check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
        //        if (check > 0)
        //        {
        //            _objMaster.ScreenInd = Masters.D2Hnew;
        //            Session["RMobileNumber"] = txtCustID.Text.Trim();
        //            Session["RProviderName"] = ddllandlineProvider.SelectedItem.Value;
        //            Session["REmailMobile"] = txtEmaillandline.Text.Trim();
        //            //Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
        //            Session["RRechargeAmount"] = Convert.ToDouble(ddllandlineAmount.Text.Trim());
        //            lblOrderID.Text = GenerateRandomNumber(11);
        //            Session["Order_Id"] = lblOrderID.Text;
        //            #region inserting
        //            _objMaster = new clsMasters();
        //            _objMaster.ScreenInd = Masters.D2Hnew;
        //            _objMaster.Customer_ID = txtCustID.Text.Trim();
        //            _objMaster.Type = "AG";
        //            _objMaster.Provider_Name = ddllandlineProvider.SelectedItem.Value;
        //            _objMaster.E_Mail = txtEmaillandline.Text.Trim();
        //            _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
        //            // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
        //            _objMaster.Amount = Convert.ToDouble(ddllandlineAmount.Text.Trim());
        //            _objMaster.Payment = "Deposit";
        //            _objMaster.RequestID = lblOrderID.Text.Trim();
        //            _objMaster.TransactionID = Convert.ToString(1111);
        //            _objMaster.IP = ipaddr;
        //            _objMaster.Status = "PENDING";
        //            _objMaster.CreatedBy = "NA";
        //            _objMaster.ModifiedBy = "NA";
        //            _objMaster.ModifiedDate = "NA";
        //            _objMaster.fnInsertRecord();
        //            #endregion
        //            getbalance();
        //            if (Session["Role"].ToString() == "User")
        //            {
        //                Response.Redirect("../User/Paymentmethod1.aspx", false);
        //            }
        //            else if (Session["Role"].ToString() == "Agent")
        //            {
        //                if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
        //                {
        //                    lbllowbalance.Text = "";
        //                    landline();
        //                }
        //                else
        //                {
        //                    mpeagentD2h.Show();
        //                    lnlLowd2hbalance.Visible = true;
        //                    lnlLowd2hbalance.Text = "Recharge failed.Please contact administrator.";
        //                    lnlLowd2hbalance.ForeColor = Color.Red;
        //                }

        //            }
        //            else if (Session["Role"].ToString() == "Admin")
        //            {
        //                //adminD2HRecharge();
        //            }


        //        }
        //        else
        //        {
        //            lblMessage.Text = "please Try Again after 15 minutes";
        //            Mpe1.Show();
        //        }
        //    }
        //}

        //catch (Exception ex)
        //{
        //    //LogError("Masters/Recharge.aspx", "imgbtnGuest1_Click", DateTime.Now, ex.Message.ToString());
        //    throw ex;
        //}

    }

  

    #endregion

    #region Agent Recharge

    protected void mobilerecharge()
    {

        try
        {
            getip();

            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.GetCommisionByNetwork;
            _objMaster.NetworkName = Session["NetWorkName"].ToString();

            if (Session["Role"].ToString() == "Agent")
            {
                _objMaster.Type = "AG";
            }

            _objMaster.UserID = Convert.ToInt32(Session["UserID"].ToString());
            _objDataSet = (DataSet)_objMaster.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)_objDataSet.Tables[0];

                    int i;
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Type"].ToString() == "AG")
                        {
                            Commission = Convert.ToDecimal(dt.Rows[i]["AgentCommission"].ToString());
                        }
                        else if (dt.Rows[i]["Type"].ToString() == "DB")
                        {
                            DistributorCommission = Convert.ToDecimal(dt.Rows[i]["AgentCommission"].ToString());
                        }
                    }

                }
            }

            decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
            decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
            decimal deductamount = rechargeAmount - DeductAmountOnCommission;

            decimal DisComm = (rechargeAmount * DistributorCommission) / (100);


            # region Mobile code


            string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


            string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();

            string[] s = result.Split('|');


            stream.Dispose();
            reader.Dispose();


            if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
            {
                AdminiBalance();

                Session["TranscationId"] = s[1].ToString();
                Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);
                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.getrecharge1;
                _objMaster.Mobile_Num = Convert.ToString(Session["RMobileNumber"]);
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                _objMaster.Provider_Name = Convert.ToString(Session["RProviderName"]);
                //  _objMaster.E_Mail = Convert.ToString(Session["REmailMobile"]);
                _objMaster.Amount = Convert.ToDouble(Session["RRechargeAmount"]);
                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = Session["Order_Id"].ToString();
                _objMaster.TransactionID = Convert.ToString(Session["TranscationId"]);

                _objMaster.AgentCommission = DeductAmountOnCommission;

                _objMaster.Parameter = "update";

                _objMaster.IP = ipaddr;
                _objMaster.Status = "SUCCESS";
                Session["Status"] = "Recharge Succesfully";

                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";

                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());


                _objMaster.fnUpdateRecord();
                #endregion
                //LogError("Redirect.aspx", "Pageload7", DateTime.Now, "Pageload7");
                Mpe1.Show();

                lbllowbalance.Text = "Recharge has Been Success";
                lbllowbalance.Visible = true;

                try
                {
                    string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
           "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
           "<td valign='top' width='100%'>" +
           "<table width='100%'><tr><td valign='top'" +
          " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + "& Your RequestId is" + Session["Order_Id"] + " </span></td></tr>" +
          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + Session["RMobileNumber"] + "</td>" +
          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + Session["RRechargeAmount"] + "</td></tr></table></td></tr>" +
           "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
           "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
           "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
         "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
         "<td align='left' valign='top'></td></tr>" +
          "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
          "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
          "</table></body></html>" +
          "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
           "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                    MailSender.SendEmail("info@lovejourney.in", "info@lovejourney.in", "info@lovejourney.in", "Love Journey-Recharge", body);

                }
                catch (Exception ex)
                {
                    //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                    //  Response.Redirect("Error.aspx", false);

                }

                try
                {
                    //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + Session["RMobileNumber"] +
                    //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + Session["RMobileNumber"] + " for Rs" + " " + Session["RRechargeAmount"] + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
                    //"&sid=LoveJourney&mtype=N";
                    //HttpWebRequest oReq1 = null;
                    //HttpWebResponse oRes1 = null;
                    //StreamReader oStream1 = null;
                    //oReq1 = (HttpWebRequest)WebRequest.Create(strUrl);
                    //oReq1.Method = "GET";
                    //oReq1.Timeout = 10000;
                    //oRes1 = (HttpWebResponse)oReq1.GetResponse();
                    //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
                    //string strMessage1 = oStream1.ReadToEnd().ToString();
                }
                catch (ArgumentException ex)
                {
                    //LogError("redirect.aspx", "sms", DateTime.Now, ex.Message.ToString());
                    // Response.Redirect("Error.aspx", false);
                }

                //_objMaster = new clsMasters();
                //_objMaster.ScreenInd = Masters.deductagentbalance;
                //_objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                ////  _objMaster.VBalance = Convert.ToInt32(Session["RRechargeAmount"]);
                //_objMaster.A_Amount = deductamount;
                //_objMaster.Amount =Convert.ToDouble(DisComm);
                //_objMaster.fnUpdateRecord();




                DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(deductamount),
                                   Convert.ToInt32(Session["UserID"].ToString()), Session["TransactionID"].ToString().Trim(), Convert.ToDouble(Session["RRechargeAmount"].ToString()),
                                   Convert.ToDouble(DeductAmountOnCommission), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));

                objBAL = new ClsBAL();
                DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                Label lbl = (Label)this.Master.FindControl("lblBalance");
                lbl.Text = balanceAgent;
                Session["Balance"] = balanceAgent;


                Response.Redirect("~/Agent/Recharge/RechargeSucces.aspx", false);


            #endregion

            }
            else
            {


                AdminiBalance();

                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.getrecharge1;
                _objMaster.Parameter = "update";
                _objMaster.RequestID = Session["Order_Id"].ToString();
                _objMaster.TransactionID = Convert.ToString(Session["TranscationId"]);
                Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);
                _objMaster.Status = "Failure";
                Session["Status"] = "Recharge Failure";
                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());


                Session["errorcode"] = s[0].ToString();
                Session["errorDecsription"] = s[4].ToString();

                _objMaster.fnUpdateRecord();

                Response.Redirect("~/Agent/Recharge/Failure.aspx", false);

            }

        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "mobilerecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void landline()
    {
        try
        {
            getip();
            //string CustomerID, Provider, balance, Email;
            //_objMasters = new clsMasters();
            //_objMasters.ScreenInd = Masters.getrechargeD2Hagent;
            //_objMasters.Parameter = "RequestID";
            //_objMasters.RequestID = Session["Order_Id"].ToString();
            //_objDataSet = new DataSet();
            //_objDataSet = (DataSet)_objMasters.fnGetData();

            //if (_objDataSet != null)
            //{
                //if (_objDataSet.Tables.Count > 0)
                //{
                    //if (_objDataSet.Tables[0].Rows.Count > 0)
                    //{
                        //CustomerID = _objDataSet.Tables[0].Rows[0]["Customer_ID"].ToString();
                        //Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        //balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        //Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();

                        //-----------Gettinh the commission of agent for a network-----

                        // _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.GetCommisionByNetwork;
                        _objMaster.NetworkName = Session["NetWorkName"].ToString();
                        if (Session["Role"].ToString() == "Agent")
                        {
                            _objMaster.Type = "AG";
                        }
                        _objMaster.UserID = Convert.ToInt32(Session["UserID"].ToString());
                        _objDataSet = (DataSet)_objMaster.fnGetData();
                        if (_objDataSet.Tables.Count > 0)
                        {
                            if (_objDataSet.Tables[0].Rows.Count > 0)
                            {

                                DataTable dt = new DataTable();
                                dt = (DataTable)_objDataSet.Tables[0];

                                int i;
                                for (i = 0; i < dt.Rows.Count; i++)
                                {

                                    if (dt.Rows[i]["Type"].ToString() == "AG")
                                    {
                                        Commission = Convert.ToDecimal(dt.Rows[i]["AgentCommission"].ToString());
                                    }
                                    else if (dt.Rows[i]["Type"].ToString() == "DB")
                                    {
                                        DistributorCommission = Convert.ToDecimal(dt.Rows[i]["AgentCommission"].ToString());
                                    }
                                }
                            }
                        }

                        decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
                        decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
                        decimal deductamount = rechargeAmount - DeductAmountOnCommission;

                        decimal DisComm = (rechargeAmount * DistributorCommission) / (100);


                        //----------end-------
                        # region Mobile code


                        string all = "10118" + Session["Order_Id"] + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "A8JW8FX7KQ7PY5ZT2S1V";


                        string pwhash = FormsAuthentication.HashPasswordForStoringInConfigFile(all, "sha1");

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/RechargeService");
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        string postData = "PartnerId=10118&TransId=" + Session["Order_Id"] + "&Message=" + Session["RProviderName"] + "|" + Session["RMobileNumber"] + "|" + Session["RRechargeAmount"] + "&Hash=" + pwhash;
                        byte[] bytes = Encoding.UTF8.GetBytes(postData);
                        request.ContentLength = bytes.Length;

                        Stream requestStream = request.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);

                        WebResponse response = request.GetResponse();
                        Stream stream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(stream);

                        var result = reader.ReadToEnd();

                        string[] s = result.Split('|');


                        stream.Dispose();
                        reader.Dispose();


                        if (s[0].ToString().Trim() == "100" && s[4].ToString().Trim() == "Transaction Successful")
                        {

                            Session["TranscationId"] = s[1].ToString();
                            AdminiBalance();
                            #region Insert Data into Database

                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getrecharge1;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(Session["TranscationId"]);

                            Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                            _objMasters.IP = ipaddr;
                            _objMasters.AgentCommission = DeductAmountOnCommission;

                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                            _objMasters.Amount = Convert.ToInt32(Session["RRechargeAmount"]);
                            _objMasters.Status = "SUCCESS";

                            Session["Status"] = "Recharge succesfully";

                            _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                            if (_objMasters.fnUpdateRecord() == true)
                            {

                                Mpe1.Show();


                                lblMessage.Text = "Recharge has Been Success";

                                try
                                {
                                    string body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                           "<table width='700' border='0' cellspacing='0' cellpadding='0' style='font-family: Verdana;font-size: smaller; margin-left: 1px; margin-right: 1px; padding-bottom: 10px;'><tr>" +
                           "<td valign='top' width='100%'>" +
                           "<table width='100%'><tr><td valign='top'" +
                          " &nbsp;<img src='http://lovejourney.in/images/ban.jpg' /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Dear User, </td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 10px;'>Your TransactionID .<span style='font-weight: 600;'>" + Session["TransactionID"] + " " + "& Your request Id is " + "" + Session["Order_Id"] + " </span></td></tr>" +
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Customer ID:</span>" + Session["RMobileNumber"] + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + Session["RRechargeAmount"] + "</td></tr></table></td></tr>" +
                           "<tr><td align='left' width='100%' valign='top'><table><tr><td align='center' width='100%' valign='top' style='background-color: #860f2b; color: White;' colspan='2'><b>Contact Us</b></td></tr>" +
                           "<tr><td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='right' valign='top'><span style='color: #860f2b;'>Support</span> </td>  " + "<td align='left' valign='top'>  &nbsp;Visit our Knowledge Base / FAQs for quick answers Log a query or problem at  My Helpdesk </td></tr> " +
                           "<tr><td align='right' valign='top'></td>&quot;</tr></table></td>" +
                         "<td align='left' valign='top' style='background-color: #EFEFEF;'><table><tr><td align='left' valign='top'> <span style='color: #860f2b;'>Sales Support</span></td> " +
                         "<td align='left' valign='top'> </td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px;'></td></tr>" +
                          "<tr><td align='left' valign='top' style='padding-left: 20px; background-color: #860f2b color: White;'></td></tr>" +
                          "</table></body></html>" +
                          "<br />Again, we thank you for registering with <b>www.lovejourney.in</b> and please " +
                           "do not hesitate to write to us at <a href='mailto:info@lovejourney.in'>Mail</a>" + "if you have any questions.<br /><br />Best Regards,<br /><a href='http://www.lovejourney.in'>lovejourney.in</a> " + "<br /><br />";

                                    MailSender.SendEmail("info@lovejourney.in", "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                }
                                catch (Exception ex)
                                {
                                    // LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                    // Response.Redirect("Error.aspx", false);

                                }


                                //_objMaster = new clsMasters();
                                //_objMaster.ScreenInd = Masters.deductagentbalance;
                                //_objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                                //_objMaster.A_Amount = deductamount;
                                //_objMaster.Amount = Convert.ToDouble(DisComm);
                                //_objMaster.fnUpdateRecord();



                                DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(deductamount),
                                      Convert.ToInt32(Session["UserID"].ToString()), Session["TransactionID"].ToString().Trim(), Convert.ToDouble(Session["RRechargeAmount"].ToString()),
                                      Convert.ToDouble(DeductAmountOnCommission), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));

                                objBAL = new ClsBAL();
                                DataSet dsBalanceA = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                                string balanceAgent = dsBalanceA.Tables[0].Rows[0]["Balance"].ToString();
                                Label lbl = (Label)this.Master.FindControl("lblBalance");
                                lbl.Text = balanceAgent;
                                Session["Balance"] = balanceAgent;


                                Response.Redirect("~/Agent/Recharge/RechargeSucces.aspx", false);


                            #endregion
                            }
                        }
                        else
                        {
                            AdminiBalance();
                            _objMasters = new clsMasters();
                            _objMasters.ScreenInd = Masters.getrecharge1;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(Session["TranscationId"]);
                            Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                            _objMasters.Amount = Convert.ToDouble(Session["RRechargeAmount"].ToString());
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                            _objMasters.IP = ipaddr;
                            _objMasters.Status = "Failure";
                            Session["Status"] = "Recharge Failure";
                            _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());



                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();

                            _objMasters.fnUpdateRecord();
                            Response.Redirect("~/Agent/Recharge/Failure.aspx", false);
                            //LogError("redirect.aspx", "API", DateTime.Now, Session["strMessage"].ToString());


                        }
                   // }
                //}
                //else
                //{
                //    Mpe1.Show();
                //    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                //}
            //}

            //else
            //{
            //    Mpe1.Show();
            //    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            //}
                        #endregion

        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "D2HRecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

  

    #endregion

    #region cancel

    protected void imgbtnGuestcancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            Response.Redirect("~/Agent/Recharge/Utilities.aspx", false);
        }

        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "imgbtnGuestcancel_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }


    }
    protected void btnD2HRechargecancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("~/Agent/Recharge/Utilities.aspx", false);

        }

        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "btnD2HRechargecancel_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }


    }
    protected void btnNetConnectRechargecancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            Response.Redirect("~/Agent/Recharge/Utilities.aspx", false);
        }

        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "btnNetConnectRechargecancel_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }


    }

    #endregion

    #region Admin Balance
    protected void AdminiBalance()
    {
        try
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.payintegra.com/PartnerBalance");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = "PartnerId=10118&Hash=428EC1E88E87E1FEADB2F8FFBD2260E7C8FEDB3B";
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            var result = reader.ReadToEnd();
            Session["FinalAdminBalance"] = result;

            stream.Dispose();
            reader.Dispose();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion



    protected void txtMobile_TextChanged(object sender, EventArgs e)
    {
        clsMasters _objmasters = new clsMasters();
        _objmasters.ScreenInd = Masters.GetOpeartorByMobileSeries;

        string Mobile = txtMobile.Text.Trim();
        string prefix = Mobile.Substring(0, 4);
        _objmasters.Parameter = prefix;
        _objDataSet = (DataSet)_objmasters.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows[0]["MobileOperator"].ToString() == "")
                    {

                    }
                    else
                    {
                        ddlProvider.SelectedValue = _objDataSet.Tables[0].Rows[0]["MobileOperator"].ToString();
                    }
                }
            }
        }
    }

    #region Popular Recharges

    #region Mobile
    protected void lnkpopularrecharges_Click(object sender, EventArgs e)
    {
        mpepopularrecharges.Show();
        fnLoadPage();
        btnRegisterpopular_Click(sender, e);
    }

    private void fnLoadPage()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getoperators;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ddlpopular.DataSource = _objDataSet.Tables[0];
                        ddlpopular.DataValueField = "OperatorsID";
                        ddlpopular.DataTextField = "OperatorsName";
                        ddlpopular.DataBind();
                        ddlpopular.Items.Insert(0, "Please Select");

                        if (ddlProvider.SelectedValue != "Please Select")
                        {

                            DataTable dt = _objDataSet.Tables[0];
                            DataRow[] dr = dt.Select("OperatorsName = '" + ddlProvider.SelectedItem.Text + "'");

                            DataTable dt1 = new DataTable();
                            dt1.Columns.Add("OperatorsID");
                            dt1.Columns.Add("OperatorsName");

                            foreach (DataRow row in dr)
                            {
                                dt1.ImportRow(row);
                            }
                            ddlpopular.SelectedValue = dt1.Rows[0]["OperatorsID"].ToString();
                        }
                    }
                    else
                    {
                        lblmsg.Text = "No data found";
                    }
                }
                else
                {
                    lblmsg.Text = "No data found";
                }
            }
            else
            {
                lblmsg.Text = "No data found";
            }
        }
        catch (Exception ex)
        {


        }
        finally
        {
            _objMasters = null;
            if (_objDataSet != null)
            {
                _objDataSet.Dispose();
            }
        }
    }

    protected void btnRegisterpopular_Click(object sender, EventArgs e)
    {
        try
        {
            mpepopularrecharges.Show();
            _objMasters = new clsMasters();


            if (ddlpopular.SelectedValue == "Please Select")
            {

            }
            else
            {
                getpopularrecharges();
            }

        }
        catch (Exception ex)
        {


        }
    }
    protected void getpopularrecharges()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetTarrif;
            _objMasters.OperatorsID = Convert.ToInt32(ddlpopular.SelectedValue);
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        lblmsg.Text = "";
                        gvMobile.DataSource = _objDataSet.Tables[0];
                        gvMobile.DataBind();
                        gvMobile.Visible = true;

                    }
                    else
                    {
                        lblmsg.Text = "No data found";
                        lblmsg.Visible = true;
                        lblmsg.ForeColor = Color.Red;
                        gvMobile.Visible = false;
                    }
                }
                else
                {
                    lblmsg.Text = "No data found";
                    gvMobile.Visible = false;
                }
            }
            else
            {
                gvMobile.Visible = false;
                lblmsg.Text = "No data found";
            }
        }
        catch (Exception ex)
        {

        }
    }
    #endregion
    #region DTH
    private void fnLoadPageDTH()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getoperators;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ddlpopDTH.DataSource = _objDataSet.Tables[0];
                        ddlpopDTH.DataValueField = "OperatorsID";
                        ddlpopDTH.DataTextField = "OperatorsName";
                        ddlpopDTH.DataBind();
                        ddlpopDTH.Items.Insert(0, "Please Select");

                        if (ddllandlineProvider.SelectedValue != "Please Select")
                        {

                            DataTable dt = _objDataSet.Tables[0];
                            DataRow[] dr = dt.Select("OperatorsName = '" + ddllandlineProvider.SelectedItem.Text + "'");

                            DataTable dt1 = new DataTable();
                            dt1.Columns.Add("OperatorsID");
                            dt1.Columns.Add("OperatorsName");

                            foreach (DataRow row in dr)
                            {
                                dt1.ImportRow(row);
                            }
                            ddlpopDTH.SelectedValue = dt1.Rows[0]["OperatorsID"].ToString();

                        }
                    }
                    else
                    {
                        lblmsg.Text = "No data found";
                    }
                }
                else
                {
                    lblmsg.Text = "No data found";
                }
            }
            else
            {
                lblmsg.Text = "No data found";
            }
        }
        catch (Exception ex)
        {


        }
        finally
        {
            _objMasters = null;
            if (_objDataSet != null)
            {
                _objDataSet.Dispose();
            }
        }
    }


    protected void btnDTHpop_Click(object sender, EventArgs e)
    {
        try
        {
            mpepopDTH.Show();
            _objMasters = new clsMasters();
            if (ddllandlineProvider.SelectedValue == "Please Select")
            {

            }
            else
            {
                getpopularrechargesDTH();
            }

        }
        catch (Exception ex)
        {


        }
    }

    protected void getpopularrechargesDTH()
    {
        try
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.GetTarrif;
            _objMasters.OperatorsID = Convert.ToInt32(ddlpopDTH.SelectedValue);
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        lbldthpop.Text = "";
                        gvdthpopo.DataSource = _objDataSet.Tables[0];
                        gvdthpopo.DataBind();
                        gvdthpopo.Visible = true;

                    }
                    else
                    {
                        lbldthpop.Text = "No data found";
                        lbldthpop.Visible = true;
                        lblmsg.ForeColor = Color.Red;
                        gvdthpopo.Visible = false;
                    }
                }
                else
                {
                    lbldthpop.Text = "No data found";
                    gvdthpopo.Visible = false;
                }
            }
            else
            {
                gvdthpopo.Visible = false;
                lbldthpop.Text = "No data found";
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lnldthpop_Click(object sender, EventArgs e)
    {
        mpepopDTH.Show();
        fnLoadPageDTH();
        btnDTHpop_Click(sender, e);
    }
    #endregion
 
    #endregion

}