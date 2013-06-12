using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using APRWorld;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Drawing.Design;
using COM;
using System.Data.SqlClient;
using System;
using System.Xml;
using System.Collections.Generic;




public partial class Users_Recharge_Recharge : System.Web.UI.Page
{
    #region Global Variables
    ClsBAL objBAL;
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    string ipaddr;
    decimal Commission;
    decimal DistributorCommission;
    static string val = "false";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getservices();
            if (val != "true")
           {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No Permission to Recharge mobile,DTH,dataCard. Please Contact Administrator for further details...";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                tdmob.Visible = false;

                if (Session["Role"] != null)
                {
                    if (Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "BSD"||Session["Role"].ToString() == "Employee")
                    {
                        chkonbehalfof.Visible = true;
                        chkDthonbehalfof.Visible = true;
                        chkdataonbehalfof.Visible = true;
                        //CheckPermission();
                        //if (ViewState["UserPermissions"] != null)
                        //{
                        //    if (ViewState["Book"] != null)
                        //    {
                        //        if (ViewState["Book"].ToString() == "1")
                        //        {
                                    tdmsg.Visible = false;
                                    tdmob.Visible = true;
                                    loadDropdown();
                                    LoadDropdown1();
                                    LoadDropdown2();
                                    rfvagentname.Visible = false;
                                    btnMobileRecharge.Visible = btnD2HRecharge.Visible = btnNetConnectRecharge.Visible = false;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        chkonbehalfof.Visible = false;
                        chkDthonbehalfof.Visible = false;
                        chkdataonbehalfof.Visible = false;
                        tdmsg.Visible = false;
                        tdmob.Visible = true;
                        loadDropdown();
                        LoadDropdown1();
                        LoadDropdown2();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
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
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "Recharge" && _objDataSet.Tables[0].Rows[i]["Status"].ToString()=="1")
                            {
                                val = "true";
                            }
                            if (Session["Role"] != null)
                            {
                                if (Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
                                {
                                    val = "false";
                                }
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
    protected void CheckPermission()
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.ID = Convert.ToInt32(Session["UserID"]);
            objBAL.screenName = "Recharge";
            _objDataSet = (DataSet)objBAL.GetPerByUser();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    ViewState["UserPermissions"] = _objDataSet.Tables[0];
                    ViewState["Book"] = _objDataSet.Tables[0].Rows[0]["Book"].ToString();
                }
                else
                {
                    ViewState["UserPermissions"] = null;
                }
            }
            else
            {
                ViewState["UserPermissions"] = null;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    #region LoadingDropdowns
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

    #region loading amounts

    protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    _objMasters = new clsMasters();
        //    _objMasters.ScreenInd = Masters.GetRechargeAmount;
        //    _objMasters.NetworkName = ddlProvider.SelectedItem.Text;

        //    Session["NetWorkName"] = ddlProvider.SelectedItem.Text;

        //    _objDataSet = (DataSet)_objMasters.fnGetData();
        //    if (_objDataSet != null)
        //    {

        //        if (_objDataSet.Tables.Count > 0)
        //        {
        //            if (_objDataSet.Tables[0].Rows.Count > 0)
        //            {
        //                ddlMobilerechargeamount.DataSource = _objDataSet.Tables[0];
        //                ddlMobilerechargeamount.DataTextField = "RechargeAmount";
        //                ddlMobilerechargeamount.DataValueField = "ID";
        //                ddlMobilerechargeamount.DataBind();
        //                ddlMobilerechargeamount.Items.Insert(0, "Please Select");

        //                Session["TypeOfTranscation"] = _objDataSet.Tables[0].Rows[0]["TypeOfTransaction"].ToString();

        //            }
        //            else
        //            {
        //                ddlMobilerechargeamount.Items.Clear();
        //                ddlMobilerechargeamount.Items.Insert(0, "Please Select");
        //            }
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

        //    //MpeNetconnect.Show();
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
                mpeagentproceed.Show();
                txtagentMob.Text = Session["RMobileNumber"].ToString();
                txtagentrec.Text = Session["RRechargeAmount"].ToString();
                txtagentprovider.Text = ddlProvider.SelectedItem.Text;
                //imgbtnGuest_Click(sender, e);
            }
            else if (Session["Role"].ToString() == "Distributor")
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
            else if (Session["Role"].ToString() == "CSE")
            {
                if (chkonbehalfof.Checked == true)
                {
                    ListItem value = ddlagent1.Items.FindByText(txtagentname.Text.ToString());
                    if (value != null)
                    {
                        ddlagent1.SelectedItem.Value = value.Value;                    
                        Session["AgentId_Agent"] = ddlagent1.SelectedItem.Value;
                        lblcommonmsg.Visible = false;
                        txtagentMob.Text = Session["RMobileNumber"].ToString();
                        txtagentrec.Text = Session["RRechargeAmount"].ToString();
                        txtagentprovider.Text = ddlProvider.SelectedItem.Text;
                        mpeagentproceed.Show();
                    }
                    else
                    {
                        lblcommonmsg.Text = "Agent username does not exists";
                        lblcommonmsg.Visible = true;
                        lblcommonmsg.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    txtagentMob.Text = Session["RMobileNumber"].ToString();
                    txtagentrec.Text = Session["RRechargeAmount"].ToString();
                    txtagentprovider.Text = ddlProvider.SelectedItem.Text;
                    mpeagentproceed.Show();
                }
            }


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
            //   Session["RRechargeAmount"] = txtD2HAmount.Text.Trim();
            Session["RRechargeAmount"] = ddlD2HAmount.Text.Trim();
            Session["REmailMobile"] = txtEmailD2H.Text.Trim();

            Session["NetWorkName"] = ddlD2HProvider.SelectedItem.Text;


            if (Session["Role"].ToString() == "User")
            {
                // MpLogin1.Show();
              //  imgbtnGuest1_Click(sender, e);
                mpeagentD2h.Show();
                txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                txtagntd2hprovider.Text = ddlD2HProvider.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "Distributor")
            {
                mpeagentD2h.Show();
                txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                txtagntd2hprovider.Text = ddlD2HProvider.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "Admin")
            {
                mpeagentD2h.Show();
                txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                txtagntd2hprovider.Text = ddlD2HProvider.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "CSE")
            {
                if (chkDthonbehalfof.Checked == true)
                {
                    ListItem value = ddlagentnameDTH.Items.FindByText(txtagentnameDTH.Text.ToString());
                    if (value != null)
                    {
                        ddlagentnameDTH.SelectedItem.Value = value.Value;
                        Session["AgentId_Agent"] = ddlagentnameDTH.SelectedItem.Value;
                        lblcommonmsgdth.Visible = false;
                        mpeagentD2h.Show();
                        txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                        txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                        txtagntd2hprovider.Text = ddlD2HProvider.SelectedItem.Text;
                    }
                    else
                    {
                        lblcommonmsgdth.Text = "Agent username does not exists";
                        lblcommonmsgdth.Visible = true;
                        lblcommonmsgdth.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    lblcommonmsgdth.Visible = false;
                    mpeagentD2h.Show();
                    txtagntd2hcustomerid.Text = Session["RMobileNumber"].ToString();
                    txtagntd2hamount.Text = Session["RRechargeAmount"].ToString();
                    txtagntd2hprovider.Text = ddlD2HProvider.SelectedItem.Text;
                }

            }

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
            Session["RMobileNumber"] = TextBox123.Text.Trim();
            Session["ProviderDataCard"] = ddlNetConnect.SelectedItem.Text;
            //Session["RRechargeAmount"] = txtRechargeAmount.Text.Trim();
            Session["RRechargeAmount"] = ddlDatacardRechargeAmount.Text.Trim();
            Session["REmailMobile"] = txtEmailnet.Text.Trim();

            Session["NetWorkName"] = ddlNetConnect.SelectedItem.Text;


            if (Session["Role"].ToString() == "User")
            {
                mpeagentdatacard.Show();
                txtagntdtcdMob.Text = Session["RMobileNumber"].ToString();
                txtagntdtcdamount.Text = Session["RRechargeAmount"].ToString();
                txtagntdtcdprovider.Text = ddlNetConnect.SelectedItem.Text;
               // imgbtnGuest2Data_Click(sender, e);
                //MpLogin2.Show();
            }
            else if (Session["Role"].ToString() == "Distributor")
            {
                mpeagentdatacard.Show();
                txtagntdtcdMob.Text = Session["RMobileNumber"].ToString();
                txtagntdtcdamount.Text = Session["RRechargeAmount"].ToString();
                txtagntdtcdprovider.Text = ddlNetConnect.SelectedItem.Text;

            }
            else if (Session["Role"].ToString() == "Admin")
            {
                mpeagentdatacard.Show();
                txtagntdtcdMob.Text = Session["RMobileNumber"].ToString();
                txtagntdtcdamount.Text = Session["RRechargeAmount"].ToString();
                txtagntdtcdprovider.Text = ddlNetConnect.SelectedItem.Text;
            }
            else if (Session["Role"].ToString() == "CSE")
            {
                if (chkdataonbehalfof.Checked == true)
                {
                    ListItem value = ddlagentnameDTCD.Items.FindByText(txtagentnameDTCD.Text.ToString());
                    if (value != null)
                    {
                        ddlagentnameDTCD.SelectedItem.Value = value.Value;
                        Session["AgentId_Agent"] = ddlagentnameDTCD.SelectedItem.Value;
                        lblcommonmsgDTCD.Visible = false;
                        mpeagentdatacard.Show();
                        txtagntdtcdMob.Text = Session["RMobileNumber"].ToString();
                        txtagntdtcdamount.Text = Session["RRechargeAmount"].ToString();
                        txtagntdtcdprovider.Text = ddlNetConnect.SelectedItem.Text;
                    }
                    else
                    {
                        lblcommonmsgDTCD.Text = "Agent username does not exists";
                        lblcommonmsgDTCD.Visible = true;
                        lblcommonmsgDTCD.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    mpeagentdatacard.Show();
                    txtagntdtcdMob.Text = Session["RMobileNumber"].ToString();
                    txtagntdtcdamount.Text = Session["RRechargeAmount"].ToString();
                    txtagntdtcdprovider.Text = ddlNetConnect.SelectedItem.Text;
                }
            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "btnNetConnectRecharge_Click", DateTime.Now, ex.Message.ToString());
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



    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetOpeartorByMobileSeries(string prefixText)
    {
        try
        {
            DataSet ds = new DataSet();
            clsMasters _objmasters = new clsMasters();
            ds = _objmasters.GetOpeartorByMobileSeries(prefixText);

        

            List<string> Operator = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Operator.Add(ds.Tables[0].Rows[i]["MobileOperator"].ToString());
                System.Web.HttpContext.Current.Session["MobileOperator"] = ds.Tables[0].Rows[i]["MobileOperator"].ToString();
            }

            return Operator.ToArray();

       

            //FlightBAL objFlightBal = new FlightBAL();
            //ds = objFlightBal.GetAirportCodes();

            //string filteringquery = "CityName LIKE'" + prefixText + "%'";
            ////Select always return array,thats why we store it into array of Datarow
            //DataRow[] dr = ds.Tables[0].Select(filteringquery);
            ////create new table
            //DataTable dtNew = new DataTable();
            ////create a clone of datatable dt and store it into new datatable
            //dtNew = ds.Tables[0].Clone();
            ////fetching all filtered rows add add into new datatable
            //foreach (DataRow drNew in dr)
            //{
            //    dtNew.ImportRow(drNew);
            //}
            ////return dtAirportCodes;

            //List<string> airports = new List<string>();
            //for (int i = 0; i < dtNew.Rows.Count; i++)
            //{
            //    airports.Add(dtNew.Rows[i]["CityName"].ToString().Trim() + "," + dtNew.Rows[i]["AirportDesc"].ToString().Trim() + " - (" + dtNew.Rows[i]["AirportCode"].ToString().Trim() + ")");
            //}
            //return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }

    protected void MobOpeartor()
    {
        
       
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
    #endregion

    #region Porceed to recharge click events
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

                if (Session["Role"].ToString() == "CSE")
                {
                    if (chkonbehalfof.Checked == true)
                    {
                        ListItem value = ddlagent1.Items.FindByText(txtagentname.Text.ToString());
                        if (value != null)
                        {
                            ddlagent1.SelectedItem.Value = value.Value;
                            _objMaster.UserID = Convert.ToInt32(ddlagent1.SelectedValue);
                            Session["AgentId_Agent"] = ddlagent1.SelectedItem.Value;
                        }
                        else
                        {
                           
                        }
                        _objMaster.Type = "AG";
                    }
                    else
                    {
                        _objMaster.Type = "CSE";
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    _objMaster.Type = "AD";
                }
                else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    _objMaster.Type = "Distributor";
                }

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

                


                if (Session["Role"].ToString() == "User")
                {

                   // Response.Redirect("../User/PaymentMethod.aspx", false);

                     Response.Redirect("~/Pay.aspx", false);
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    getbalance();
                    if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                    {

                        lbllowbalance.Text = "";
                         mobilerecharge();
                    }
                    else
                    {
                        mpeagentproceed.Show();
                        lbllowbalance.Visible = true;
                        lbllowbalance.Text = "Insufficient funds to recharge";
                        lbllowbalance.ForeColor = Color.Red;
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    lbllowbalance.Text = "";
                    adminmobilerecharge();
                }
                else if (Session["Role"].ToString() == "CSE")
                {
                    lbllowbalance.Text = "";
                    adminmobilerecharge();
                }
                else if (Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
                {
                    lbllowbalance.Text ="please contact administrator";
                    
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

                    if (Session["Role"].ToString() == "CSE")
                    {
                        if (chkonbehalfof.Checked == true)
                        {
                            ListItem value = ddlagent1.Items.FindByText(txtagentname.Text.ToString());
                            if (value != null)
                            {
                                ddlagent1.SelectedItem.Value = value.Value;
                                _objMaster.UserID = Convert.ToInt32(ddlagent1.SelectedValue);
                                Session["AgentId_Agent"] = ddlagent1.SelectedItem.Value;
                            }
                            else
                            {

                            }
                            _objMaster.Type = "AG";
                        }
                        else
                        {
                            _objMaster.Type = "CSE";
                        }
                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                        _objMaster.Type = "AD";
                    }
                      else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        _objMaster.Type = "Distributor";
                    }
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
                    //getbalance();
                    if (Session["Role"].ToString() == "User")
                    {
                        Response.Redirect("~/Pay.aspx", false);
                        // Response.Redirect("../Pay.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        getbalance();

                        if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                        {


                            lbllowbalance.Text = "";
                             mobilerecharge();
                        }
                        else
                        {
                            mpeagentproceed.Show();
                            lbllowbalance.Visible = true;
                            lbllowbalance.Text = "Insufficient funds to recharge";
                            lbllowbalance.ForeColor = Color.Red;
                        }

                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                         adminmobilerecharge();
                    }
                    else if (Session["Role"].ToString() == "CSE")
                    {
                       
                        adminmobilerecharge();
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
            _objMaster.Customer_ID = txtCustID.Text.Trim();
            _objMaster.Parameter = "DTH";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {

                _objMaster.ScreenInd = Masters.D2Hnew;
                Session["RMobileNumber"] = txtCustID.Text.Trim();
                Session["RProviderName"] = ddlD2HProvider.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                //  Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                Session["RRechargeAmount"] = Convert.ToDouble(ddlD2HAmount.Text.Trim());
                lblOrderID.Text = GenerateRandomNumber(11);
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.D2Hnew;
                _objMaster.Customer_ID = txtCustID.Text.Trim();
                _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Value;
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);


                if (Session["Role"].ToString() == "CSE")
                {
                    if (chkDthonbehalfof.Checked == true)
                    {
                        ListItem value = ddlagentnameDTH.Items.FindByText(txtagentnameDTH.Text.ToString());
                        if (value != null)
                        {
                            ddlagentnameDTH.SelectedItem.Value = value.Value;
                            _objMaster.UserID = Convert.ToInt32(ddlagentnameDTH.SelectedValue);
                            Session["AgentId_Agent"] = ddlagentnameDTH.SelectedItem.Value;
                        }
                        else
                        {

                        }
                        _objMaster.Type = "AG";
                    }
                    else
                    {
                        _objMaster.Type = "CSE";
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    _objMaster.Type = "AD";
                }
                else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    _objMaster.Type = "Distributor";
                }
                _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.Text.Trim());
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
                //getbalance();
                if (Session["Role"].ToString() == "User")
                {
                    Response.Redirect("~/Pay.aspx", false);
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    getbalance();
                    if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                    {
                        lbllowbalance.Text = "";
                         D2HRecharge();
                    }
                    else
                    {
                        mpeagentD2h.Show();
                        lnlLowd2hbalance.Visible = true;
                        lnlLowd2hbalance.Text = "Insufficient funds to recharge";
                        lnlLowd2hbalance.ForeColor = Color.Red;
                    }

                }
                else if (Session["Role"].ToString() == "Admin")
                {
                     adminD2HRecharge();
                }
                else if (Session["Role"].ToString() == "CSE")
                {

                    adminD2HRecharge();
                }

            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {

                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.D2Hnew;
                    Session["RMobileNumber"] = txtCustID.Text.Trim();
                    Session["RProviderName"] = ddlD2HProvider.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailD2H.Text.Trim();
                    //Session["RRechargeAmount"] = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlD2HAmount.Text.Trim());
                    lblOrderID.Text = GenerateRandomNumber(11);
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting
                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.D2Hnew;
                    _objMaster.Customer_ID = txtCustID.Text.Trim();

                    if (Session["Role"].ToString() == "CSE")
                    {
                        if (chkDthonbehalfof.Checked == true)
                        {
                            ListItem value = ddlagentnameDTH.Items.FindByText(txtagentnameDTH.Text.ToString());
                            if (value != null)
                            {
                                ddlagentnameDTH.SelectedItem.Value = value.Value;
                                _objMaster.UserID = Convert.ToInt32(ddlagentnameDTH.SelectedValue);
                                Session["AgentId_Agent"] = ddlagentnameDTH.SelectedItem.Value;
                            }
                            else
                            {

                            }
                            _objMaster.Type = "AG";
                        }
                        else
                        {
                            _objMaster.Type = "CSE";
                        }
                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                        _objMaster.Type = "AD";
                    }
                     else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        _objMaster.Type = "Distributor";
                    }
                    _objMaster.Provider_Name = ddlD2HProvider.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmailD2H.Text.Trim();
                    _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                    // _objMaster.Amount = Convert.ToDouble(txtD2HAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlD2HAmount.Text.Trim());
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
                    //getbalance();

                    if (Session["Role"].ToString() == "User")
                    {
                        Response.Redirect("~/Pay.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                        {
                            lbllowbalance.Text = "";
                            D2HRecharge();
                        }
                        else
                        {
                            mpeagentD2h.Show();
                            lnlLowd2hbalance.Visible = true;
                            lnlLowd2hbalance.Text = "Insufficient funds to recharge";
                            lnlLowd2hbalance.ForeColor = Color.Red;
                        }

                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                         adminD2HRecharge();
                    }
                    else if (Session["Role"].ToString() == "CSE")
                    {

                        adminD2HRecharge();
                    }


                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }
        }

        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "imgbtnGuest1_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }

    }

    protected void imgbtnGuest2Data_Click(object sender, EventArgs e)
    {
        try
        {
            int check;
            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.gettimeforusers;
            _objMaster.MobileNum = TextBox123.Text.Trim();
            _objMaster.Parameter = "DataCard";
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMaster.fnGetData();

            if (_objDataSet.Tables[0].Rows.Count == 0)
            {

                _objMaster.ScreenInd = Masters.DataCard;
                Session["RMobileNumber"] = TextBox123.Text.Trim();
                Session["RProviderName"] = ddlNetConnect.SelectedItem.Value;
                Session["REmailMobile"] = txtEmailnet.Text.Trim();
                // Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.Text.Trim());
                lblOrderID.Text = GenerateRandomNumber(11);
                Session["Order_Id"] = lblOrderID.Text;

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.DataCard;
                _objMaster.Mobile = TextBox123.Text.Trim();
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                if (Session["Role"].ToString() == "CSE")
                {
                    if (chkdataonbehalfof.Checked == true)
                    {
                        ListItem value = ddlagentnameDTCD.Items.FindByText(txtagentnameDTCD.Text.ToString());
                        if (value != null)
                        {
                            ddlagentnameDTCD.SelectedItem.Value = value.Value;
                            _objMaster.UserID = Convert.ToInt32(ddlagentnameDTCD.SelectedValue);
                            Session["AgentId_Agent"] = ddlagentnameDTCD.SelectedItem.Value;
                        }
                        else
                        {

                        }
                        _objMaster.Type = "AG";
                    }
                    else
                    {
                        _objMaster.Type = "CSE";
                    }
                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    _objMaster.Type = "AD";
                }
                else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    _objMaster.Type = "Distributor";
                }
                _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                _objMaster.E_Mail = txtEmailnet.Text.Trim();
                //_objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.Text.Trim());
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

                //getbalance();
                if (Session["Role"].ToString() == "User")
                {
                    Response.Redirect("~/Pay.aspx", false);
                }
                else if (Session["Role"].ToString() == "Distributor")
                {
                    if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                    {
                        lbllowbalance.Text = "";
                         DataCardRecharge();
                    }
                    else
                    {
                        mpeagentdatacard.Show();
                        lbldacdLowbalance.Visible = true;
                        lbldacdLowbalance.Text = "Insufficient funds to recharge";
                        lbldacdLowbalance.ForeColor = Color.Red;
                    }

                }
                else if (Session["Role"].ToString() == "Admin")
                {
                    adminDataCardRecharge();
                }
                else if (Session["Role"].ToString() == "CSE")
                {

                    adminDataCardRecharge();
                }


            }
            else if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                check = Convert.ToInt32(_objDataSet.Tables[0].Rows[0]["Allow"]);
                if (check > 0)
                {
                    _objMaster.ScreenInd = Masters.DataCard;
                    Session["RMobileNumber"] = TextBox123.Text.Trim();
                    Session["RProviderName"] = ddlNetConnect.SelectedItem.Value;
                    Session["REmailMobile"] = txtEmailnet.Text.Trim();
                    // Session["RRechargeAmount"] = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    Session["RRechargeAmount"] = Convert.ToDouble(ddlDatacardRechargeAmount.Text.Trim());

                    lblOrderID.Text = GenerateRandomNumber(11);
                    Session["Order_Id"] = lblOrderID.Text;
                    #region inserting

                    _objMaster = new clsMasters();
                    _objMaster.ScreenInd = Masters.DataCard;
                    _objMaster.Mobile = TextBox123.Text.Trim();
                    _objMaster.UserID = Convert.ToInt32(Session["UserID"]);

                    if (Session["Role"].ToString() == "CSE")
                    {
                        if (chkdataonbehalfof.Checked == true)
                        {
                            ListItem value = ddlagentnameDTCD.Items.FindByText(txtagentnameDTCD.Text.ToString());
                            if (value != null)
                            {
                                ddlagentnameDTCD.SelectedItem.Value = value.Value;
                                _objMaster.UserID = Convert.ToInt32(ddlagentnameDTCD.SelectedValue);
                                Session["AgentId_Agent"] = ddlagentnameDTCD.SelectedItem.Value;
                            }
                            else
                            {

                            }
                            _objMaster.Type = "AG";
                        }
                        else
                        {
                            _objMaster.Type = "CSE";
                        }
                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                        _objMaster.Type = "AD";
                    }
                      else if (Session["Role"].ToString() == "User")
                {
                    _objMaster.Type = "User";
                }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        _objMaster.Type = "Distributor";
                    }
                    _objMaster.Provider_Name = ddlNetConnect.SelectedItem.Value;
                    _objMaster.E_Mail = txtEmailnet.Text.Trim();
                    //  _objMaster.Amount = Convert.ToDouble(txtRechargeAmount.Text.Trim());
                    _objMaster.Amount = Convert.ToDouble(ddlDatacardRechargeAmount.Text.Trim());
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
                    //getbalance();
                    if (Session["Role"].ToString() == "User")
                    {
                        Response.Redirect("~/Pay.aspx", false);
                    }
                    else if (Session["Role"].ToString() == "Distributor")
                    {
                        if (Convert.ToDecimal(Session["AgentBalance"].ToString()) > Convert.ToInt32(Session["RRechargeAmount"]))
                        {
                            lbllowbalance.Text = "";
                             DataCardRecharge();
                        }
                        else
                        {
                            mpeagentdatacard.Show();
                            lbldacdLowbalance.Visible = true;
                            lbldacdLowbalance.Text = "Insufficient funds to recharge";
                            lbldacdLowbalance.ForeColor = Color.Red;
                        }

                    }
                    else if (Session["Role"].ToString() == "Admin")
                    {
                         adminDataCardRecharge();
                    }
                    else if (Session["Role"].ToString() == "CSE")
                    {

                        adminDataCardRecharge();
                    }

                }
                else
                {
                    lblMessage.Text = "please Try Again after 15 minutes";
                    Mpe1.Show();
                }
            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "imgbtnGuest2Data_Click", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
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
          " &nbsp;<img  src='http://lovejourney.in/images/ban.jpg'  /></td> </tr></table> </td></tr>" + " <tr><td align='left' valign='top' style='height: 0px; background-color: #860f2b;'></td></tr>" +
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


                Response.Redirect("~/Users/Recharge/RechargeSucces.aspx", false);


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

                Response.Redirect("~/Users/Recharge/Failure.aspx", false);

            }

        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "mobilerecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void D2HRecharge()
    {
        try
        {
            getip();
            string CustomerID, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getrechargeD2Hagent;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        CustomerID = _objDataSet.Tables[0].Rows[0]["Customer_ID"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();

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

                            _objMasters.ScreenInd = Masters.getagentrecharge2;
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
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Customer ID:</span>" + CustomerID + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
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
                            _objMasters.ScreenInd = Masters.getagentrecharge2;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(Session["TranscationId"]);
                            Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                            _objMasters.Amount = Convert.ToDouble(balance);
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
                    }
                }
                else
                {
                    Mpe1.Show();
                    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                }
            }

            else
            {
                Mpe1.Show();
                lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
                        #endregion

        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "D2HRecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    protected void DataCardRecharge()
    {

        try
        {
            getip();
            string MobileNumber, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getagentDatacardrecharge;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        MobileNumber = _objDataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();

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
                                Commission = Convert.ToDecimal(_objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString());
                            }
                        }

                        decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
                        decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
                        decimal deductamount = rechargeAmount - DeductAmountOnCommission;

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
                            #region Insert Data into Database
                            //getstatus();
                            //if (Session["GetStatus"].ToString() == "Success ")
                            //{
                            AdminiBalance();
                            Session["TranscationId"] = s[1].ToString();
                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getrecharge3;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());

                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                            _objMasters.AgentCommission = DeductAmountOnCommission;


                            _objMasters.Status = "SUCCESS";
                            Session["Status"] = "Recharge successfully";
                            _objMasters.IP = ipaddr;

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
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
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
                                    //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                    // Response.Redirect("Error.aspx", false);

                                }

                                try
                                {
                                    //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                    //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
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
                                    //  Response.Redirect("Error.aspx", false);
                                }



                                //_objMaster = new clsMasters();
                                //_objMaster.ScreenInd = Masters.deductagentbalance;
                                //_objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                                //_objMaster.A_Amount = deductamount;
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
                            // }


                        }
                        else
                        {
                            AdminiBalance();

                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getrecharge3;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());

                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                            _objMasters.Status = "Failure";
                            Session["Status"] = "Recharge Failure";

                            _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                            _objMasters.IP = ipaddr;


                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();

                            _objMasters.fnUpdateRecord();

                            Response.Redirect("~/Agent/Recharge/Failure.aspx", false);
                        }
                    }
                }

                else
                {
                    Mpe1.Show();
                    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                }
                        #endregion
            }
            else
            {
                Mpe1.Show();
                lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "DataCardRecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    #endregion

    #region adminrecharge
  

    protected void adminmobilerecharge()
    {

        try
        {
            getip();

            _objMaster = new clsMasters();
            _objMaster.ScreenInd = Masters.GetCommisionByNetwork;
            _objMaster.NetworkName = Session["NetWorkName"].ToString();


            if (Session["Role"].ToString() == "CSE")
            {
                if (chkonbehalfof.Checked == true)
                {
                    _objMaster.Type = "AG";
                }
                else
                {
                    _objMaster.Type = "CSE";
                }
            }
           

            _objDataSet = (DataSet)_objMaster.fnGetData();
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    Commission = Convert.ToDecimal(_objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString());
                }
            }

            decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
            decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
            decimal deductamount = rechargeAmount - DeductAmountOnCommission;

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

                #region Insert Data into Database
                AdminiBalance();
                Session["TranscationId"] = s[1].ToString();

                Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                #region inserting
                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.getrecharge1;
                _objMaster.Mobile_Num = Convert.ToString(Session["RMobileNumber"]);
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                _objMaster.Provider_Name = Convert.ToString(Session["RProviderName"]);
               // _objMaster.E_Mail = Convert.ToString(Session["REmailMobile"]);
                _objMaster.Amount = Convert.ToDouble(Session["RRechargeAmount"]);
                _objMaster.Payment = "Deposit";
                _objMaster.RequestID = Session["Order_Id"].ToString();
                _objMaster.TransactionID = Convert.ToString(Session["TransactionID"]);

                _objMaster.AgentCommission = DeductAmountOnCommission;


                _objMaster.Parameter = "update";

                _objMaster.IP = ipaddr;
                _objMaster.Status = "SUCCESS";
                Session["Status"] = "Recharge Successfully";
                _objMaster.CreatedBy = "NA";
                _objMaster.ModifiedBy = "NA";
                _objMaster.ModifiedDate = "NA";
                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                _objMaster.fnUpdateRecord();
                #endregion

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
          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + Session["RMobileNumber"] + "</td>" +
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
                if (Session["Role"].ToString() == "CSE")
                {
                    if (chkonbehalfof.Checked == true)
                    {
                        getbalance();
                        DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(deductamount),
                                     Convert.ToInt32(Session["AgentId_Agent"].ToString()), Session["TransactionID"].ToString(), Convert.ToDouble(Session["RRechargeAmount"].ToString()),
                                     Convert.ToDouble(DeductAmountOnCommission), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));
                    }
                    else
                    {
                    }

                }

                _objMaster = new clsMasters();
                _objMaster.ScreenInd = Masters.deductadminbalance;
                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                _objMaster.A_Amount = deductamount;
                _objMaster.fnUpdateRecord();


                Response.Redirect("~/Users/Recharge/RechargeSucces.aspx", false);

                #endregion
                // }
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

                Session["errorcode"] = s[0].ToString();
                Session["errorDecsription"] = s[4].ToString();

                _objMaster.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                _objMaster.fnUpdateRecord();

                Response.Redirect("~/Users/Recharge/Failure.aspx", false);

            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "adminmobilerecharge", DateTime.Now, ex.Message.ToString());
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
    protected void adminD2HRecharge()
    {
        try
        {

            getip();
            string CustomerID, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getrechargeD2Hagent;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        CustomerID = _objDataSet.Tables[0].Rows[0]["Customer_ID"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();

                        //-----------Gettinh the commission of agent for a network-----

                        // _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.GetCommisionByNetwork;
                        _objMaster.NetworkName = Session["NetWorkName"].ToString();


                        if (Session["Role"].ToString() == "CSE")
                        {
                            if (chkDthonbehalfof.Checked == true)
                            {
                                _objMaster.Type = "AG";
                            }
                            else
                            {
                                _objMaster.Type = "CSE";
                            }
                        }
                        _objDataSet = (DataSet)_objMaster.fnGetData();
                        if (_objDataSet.Tables.Count > 0)
                        {
                            if (_objDataSet.Tables[0].Rows.Count > 0)
                            {
                                Commission = Convert.ToDecimal(_objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString());
                            }
                        }

                        decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
                        decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
                        decimal deductamount = rechargeAmount - DeductAmountOnCommission;

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


                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getagentrecharge2;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(Session["TranscationId"]);
                            Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                            _objMasters.AgentCommission = DeductAmountOnCommission;

                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                            _objMasters.IP = ipaddr;
                            _objMasters.Status = "SUCCESS";
                            Session["Status"] = "Recharge Successfully";

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
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Customer ID:</span>" + CustomerID + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
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

                                    MailSender.SendEmail("info@lovejourney.in", "info@lovejourney.in", "info@lovejourney.in", "LoveJourney-Recharge", body);

                                }
                                catch (Exception ex)
                                {
                                    //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                    //  Response.Redirect("Error.aspx", false);

                                }
                                if (Session["Role"].ToString() == "CSE")
                                {
                                    if (chkDthonbehalfof.Checked == true)
                                    {
                                        getbalance();
                                        DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(deductamount),
                                                     Convert.ToInt32(Session["AgentId_Agent"].ToString()), Session["TransactionID"].ToString(), Convert.ToDouble(Session["RRechargeAmount"].ToString()),
                                                     Convert.ToDouble(DeductAmountOnCommission), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));
                                    }
                                    else
                                    {
                                    }

                                }


                                _objMaster = new clsMasters();
                                _objMaster.ScreenInd = Masters.deductadminbalance;
                                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                                _objMaster.A_Amount = deductamount;
                                _objMaster.fnUpdateRecord();


                                Response.Redirect("~/Users/Recharge/RechargeSucces.aspx", false);
                        #endregion
                            }
                        }
                        else
                        {
                            AdminiBalance();


                            _objMasters = new clsMasters();
                            _objMasters.ScreenInd = Masters.getagentrecharge2;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(Session["TranscationId"]);
                            Session["TransactionID"] = Convert.ToString(Session["TranscationId"]);

                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                            _objMasters.IP = ipaddr;
                            _objMasters.Status = "Failure";
                            Session["Status"] = "Recharge Failure";
                            _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();


                            _objMasters.fnUpdateRecord();
                            Response.Redirect("~/Users/Recharge/Failure.aspx", false);
                        }
                    }
                }
                else
                {
                    Mpe1.Show();
                    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                }
            }

            else
            {
                Mpe1.Show();
                lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "adminD2HRecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }


    }
    protected void adminDataCardRecharge()
    {
        try
        {
            getip();
            string MobileNumber, Provider, balance, Email;
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.getagentDatacardrecharge;
            _objMasters.Parameter = "RequestID";
            _objMasters.RequestID = Session["Order_Id"].ToString();
            _objDataSet = new DataSet();
            _objDataSet = (DataSet)_objMasters.fnGetData();

            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        MobileNumber = _objDataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                        Provider = _objDataSet.Tables[0].Rows[0]["Provider_Name"].ToString();
                        balance = _objDataSet.Tables[0].Rows[0]["Amount"].ToString();
                        Email = _objDataSet.Tables[0].Rows[0]["E_Mail"].ToString();
                        //-----------Gettinh the commission of agent for a network-----

                        // _objMaster = new clsMasters();
                        _objMaster.ScreenInd = Masters.GetCommisionByNetwork;
                        _objMaster.NetworkName = Session["NetWorkName"].ToString();
                        if (Session["Role"].ToString() == "CSE")
                        {
                            if (chkonbehalfof.Checked == true)
                            {
                                _objMaster.Type = "AG";
                            }
                            else
                            {
                                _objMaster.Type = "CSE";
                            }
                        }
                        _objDataSet = (DataSet)_objMaster.fnGetData();
                        if (_objDataSet.Tables.Count > 0)
                        {
                            if (_objDataSet.Tables[0].Rows.Count > 0)
                            {
                                Commission = Convert.ToDecimal(_objDataSet.Tables[0].Rows[0]["AgentCommission"].ToString());
                            }
                        }

                        decimal rechargeAmount = Convert.ToDecimal(Session["RRechargeAmount"]);
                        decimal DeductAmountOnCommission = (rechargeAmount * Commission) / (100);
                        decimal deductamount = rechargeAmount - DeductAmountOnCommission;

                        //----------end-------

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
                            #region Insert Data into Database

                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getrecharge3;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());
                            _objMasters.AgentCommission = DeductAmountOnCommission;


                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);

                            _objMasters.IP = ipaddr;

                            _objMasters.Status = "SUCCESS";
                            Session["Status"] = "Recharge Successfully";
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
                          "<tr><td><table><tr><td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'> Mobile Number:</span>" + MobileNumber + "</td>" +
                          "<td align='right' valign='top' style='padding-right: 100px; background-color: #F1F1F1'><span style='color: #860f2b; font-weight: 600;'>Amount:</span>" + balance + "</td></tr></table></td></tr>" +
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
                                    //LogError("redirect.aspx", "Mail", DateTime.Now, ex.Message.ToString());
                                    //  Response.Redirect("Error.aspx", false);

                                }

                                try
                                {
                                    //string strUrl = "http://sms.i2space.in/WebServiceSMS.aspx?User=i2space1&passwd=smsc&mobilenumber=" + MobileNumber +
                                    //"&message= Thank You for using lovejourney.in to Recharge Mobile no" + MobileNumber + " for Rs" + " " + balance + "& your order Num is" + "" + Session["TransactionID"] + "" + "for Queries ,Email us at info@lovejourney.in" +
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


                                if (Session["Role"].ToString() == "CSE")
                                {
                                    if (chkdataonbehalfof.Checked == true)
                                    {
                                        getbalance();
                                        DeductAgentBalance(Convert.ToInt32(Session["AgentId_Agent"].ToString()), Convert.ToDouble(deductamount),
                                                     Convert.ToInt32(Session["AgentId_Agent"].ToString()), Session["TransactionID"].ToString(), Convert.ToDouble(Session["RRechargeAmount"].ToString()),
                                                     Convert.ToDouble(DeductAmountOnCommission), Convert.ToInt32(Session["CommisionPercentage_Agent"].ToString()));
                                    }
                                    else
                                    {
                                    }

                                }
                                _objMaster = new clsMasters();
                                _objMaster.ScreenInd = Masters.deductadminbalance;
                                _objMaster.UserID = Convert.ToInt32(Session["UserID"]);
                                _objMaster.A_Amount = deductamount;
                                _objMaster.fnUpdateRecord();

                                Response.Redirect("~/Users/Recharge/RechargeSucces.aspx", false);

                            #endregion
                            }
                        }
                        else
                        {
                            AdminiBalance();

                            _objMasters = new clsMasters();

                            _objMasters.ScreenInd = Masters.getrecharge3;
                            _objMasters.Parameter = "update";
                            _objMasters.RequestID = Session["Order_Id"].ToString();
                            _objMasters.TransactionID = Convert.ToString(s[1].ToString());
                            Session["TransactionID"] = Convert.ToString(s[1].ToString());

                            _objMasters.Amount = Convert.ToDouble(balance);
                            _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
                            _objMasters.Status = "Failure";
                            Session["Status"] = "Recharge Failure";

                            Session["errorcode"] = s[0].ToString();
                            Session["errorDecsription"] = s[4].ToString();


                            _objMasters.IP = ipaddr;
                            _objMasters.A_Amount = Convert.ToDecimal(Session["FinalAdminBalance"].ToString());

                            _objMasters.fnUpdateRecord();
                            Response.Redirect("~/Users/Recharge/Failure.aspx", false);
                        }
                    }
                }
                else
                {
                    Mpe1.Show();
                    lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

                }

            }
            else
            {
                Mpe1.Show();
                lblMessage.Text = "Recharge Has Been Failed Please Try Again Later";

            }
        }
        catch (Exception ex)
        {
            //LogError("Masters/Recharge.aspx", "adminDataCardRecharge", DateTime.Now, ex.Message.ToString());
            throw ex;
        }
    }

    #endregion

    #region cancel

    protected void imgbtnGuestcancel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            Response.Redirect("~/Users/Recharge/Recharge.aspx", false);
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
            Response.Redirect("~/Users/Recharge/Recharge.aspx", false);

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

            Response.Redirect("~/Users/Recharge/Recharge.aspx", false);
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

            //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            //    ("http://api.buysmart.co.in/hydrasales/services/thirdpartyapi.asmx/BalanceCheck?GUID=" + "FCC4FE618FD28CE4");
            //request.Method = "GET";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //DataSet ds1 = null;
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    StreamReader responseReader = new StreamReader(response.GetResponseStream());
            //    string responseData = responseReader.ReadToEnd();
            //    XmlDocument doc = new XmlDocument();
            //    doc.LoadXml(responseData);
            //    XmlNodeReader xmlReader = new XmlNodeReader(doc);
            //    ds1 = new DataSet();
            //    ds1.ReadXml(xmlReader);

            //    Session["FinalAdminBalance"] = ds1.Tables["basket"].Rows[0]["balance"].ToString();

            //HttpWebRequest oReq1 = null;
            //HttpWebResponse oRes1 = null;
            //StreamReader oStream1 = null;

            //oReq1 = (HttpWebRequest)WebRequest.Create("http://www.bulksel.com/api_reach_bulksel.php?user=kass9378&pass=bus80111&mobileno=918008419101&message=BS BL");


            //oReq1.Method = "GET";
            //oReq1.Timeout = 10000;
            //oRes1 = (HttpWebResponse)oReq1.GetResponse();
            //oStream1 = new StreamReader(oRes1.GetResponseStream(), Encoding.GetEncoding(1252));
            //string strMessage1 = oStream1.ReadToEnd().ToString();            

            //string[] s = strMessage1.Split('.');

            //string balance = s[1].ToString();

            //Session["FinalAdminBalance"] = balance;

            // }

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

        if (txtMobile.Text != "")
        {
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
    }


    protected void chkonbehalfof_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkonbehalfof.Checked == true)
            {
                getagents();
                tragentname.Visible = true;
                rfvagentname.Visible = true;
            }
            else
            {
                tragentname.Visible = false;
                rfvagentname.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void getagents()
    {
        DataSet ds = new DataSet();
        ds = GetAgents();
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlagent1.DataSource = ds;
                ddlagent1.DataTextField = "Username";
                ddlagent1.DataValueField = "ID";
                ddlagent1.DataBind();
                ddlagent1.Items.Insert(0, "-Please Select-");
            }

        }
    }
    DataSet GetAgents()
    {
        try
        {
            ClsBAL objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
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
            ds = objBal.GetAgents();

            string filteringquery = "Username LIKE'" + prefixText + "%'";
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
        catch (Exception)
        {
            throw;

        }
    }
    
    protected void chkDthonbehalfof_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkDthonbehalfof.Checked == true)
            {
                DataSet ds = new DataSet();
                ds = GetAgents();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlagentnameDTH.DataSource = ds;
                        ddlagentnameDTH.DataTextField = "Username";
                        ddlagentnameDTH.DataValueField = "ID";
                        ddlagentnameDTH.DataBind();
                        ddlagentnameDTH.Items.Insert(0, "-Please Select-");
                    }

                }
                tr2.Visible = true;
                rfvtxtagentnameDTH.Visible = true;
            }
            else
            {
                tr2.Visible = false;
                rfvtxtagentnameDTH.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void chkdataonbehalfof_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkdataonbehalfof.Checked == true)
            {
                DataSet ds = new DataSet();
                ds = GetAgents();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlagentnameDTCD.DataSource = ds;
                        ddlagentnameDTCD.DataTextField = "Username";
                        ddlagentnameDTCD.DataValueField = "ID";
                        ddlagentnameDTCD.DataBind();
                        ddlagentnameDTCD.Items.Insert(0, "-Please Select-");
                    }

                }
                tr4.Visible = true;
                rfvtxtagentnameDTCD.Visible = true;
            }
            else
            {
                tr4.Visible = false;
                rfvtxtagentnameDTCD.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }
}

