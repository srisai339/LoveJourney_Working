using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BusAPILayer;
using BAL;
using System.Data;
using System.Globalization;

public partial class Users_Bus_Search : System.Web.UI.Page
{
    ClsBAL objBAL;
    DataSet objDataSet;
    KesineniDetails kesineniDetails;
    AbhiBusDetails abhiBusDetails;
    BitlaDetails bitlaDetails;
    KABCommon objCommon;
    clsMasters _objMasters;
    DataSet _objDataSet;
    static string val ="false";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            kesineniDetails = new KesineniDetails();
            kesineniDetails.LoginId = KesineniConstants.LoginId;
            kesineniDetails.PassWord = KesineniConstants.Password;

            abhiBusDetails = new AbhiBusDetails();
            abhiBusDetails.Url = AbhiBusConstants.URL;

            bitlaDetails = new BitlaDetails();
            bitlaDetails.ApiKey = BitlaConstants.API_KEY;
            bitlaDetails.Url = BitlaConstants.URL;

            objCommon = new KABCommon(kesineniDetails, abhiBusDetails, bitlaDetails);
            this.Page.Title = "LoveJourney - Bus - Search";

            if (!IsPostBack)
            {
                getservices();
                if (val != "true")
                {
                    if (Session["Role"] != null)
                    {
                        CheckPermission("Book Ticket", Session["Role"].ToString());

                        objDataSet = null;
                        if (objDataSet == null)
                        {
                            objBAL = new ClsBAL();
                            objDataSet = objBAL.GetCities();
                            //HttpContext.Current.Session["Cities"] = objDataSet;

                        }
                        if (objDataSet != null)
                        {
                            if (objDataSet.Tables.Count > 0)
                            {
                                if (objDataSet.Tables[0].Rows.Count > 0)
                                {
                                    ddlSources.DataSource = objDataSet.Tables[0];
                                    ddlSources.DataTextField = "SourceName";
                                    ddlSources.DataValueField = "ID";
                                    ddlSources.DataBind();

                                    ddlDestinations.Items.Clear();
                                    ddlDestinations.DataSource = objDataSet.Tables[0];
                                    ddlDestinations.DataTextField = "SourceName";
                                    ddlDestinations.DataValueField = "ID";
                                    ddlDestinations.DataBind();

                                    if (Request.QueryString.Count == 0)
                                    {
                                        ddlSources.SelectedValue = ddlSources.Items.FindByText("Hyderabad").Value;
                                        ddlDestinations.SelectedValue = ddlDestinations.Items.FindByText("Bangalore").Value;
                                    }

                                    if (ddlSources.SelectedItem != null)
                                    {
                                        Session["From"] = ddlSources.SelectedItem.Text.ToString();
                                        Session["To"] = ddlDestinations.SelectedItem.Text.ToString();
                                    }
                                }
                            }
                        }

                        Session["DOJ"] = txtFromDate.Text.ToString();
                        Session["From"] = ddlSources.SelectedItem.Text.ToString();
                        Session["To"] = ddlDestinations.SelectedItem.Text.ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx", false);
                    }
                }
                else
                {
                    lblMainMsg.Text = "This Service is temporarily unavaliable";
                    lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                    tdmsg.Visible = true;
                    pnlBook.Visible = false;
                   
                }
            }
        }
        catch (Exception)
        {
            throw;
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
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "Buses" && _objDataSet.Tables[0].Rows[i]["Status"].ToString() == "1")
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
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlBook.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlBook.Visible = false;

                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                objDataSet = (DataSet)objBAL.GetPerByUser();
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
                            pnlBook.Visible = true;
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
    protected void ddlSources_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ddlDestinations.Items.Clear();
            //ddlDestinations.Items.Insert(0, "----------");
            if (ddlSources.SelectedIndex != 0 && ddlSources.SelectedItem.Value != "----------")
            {
                string str = ddlSources.SelectedItem.Value.ToString();
                //objBAL = new ClsBAL();
                //objDataSet = objBAL.GetDestinations(str);
                //if (objDataSet != null)
                //{
                //    if (objDataSet.Tables.Count > 0)
                //    {
                //        if (objDataSet.Tables[0].Rows.Count > 0)
                //        {
                //            Session["sesDTDestinations"] = objDataSet.Tables[0];
                //            ddlDestinations.Items.Clear();
                //            ddlDestinations.DataSource = objDataSet.Tables[0];
                //            ddlDestinations.DataTextField = "DestinationName";
                //            ddlDestinations.DataValueField = "ID";
                //            ddlDestinations.DataBind();
                //            ddlDestinations.Items.Insert(0, "----------");
                //            ddlDestinations.Focus();
                //        }
                //    }
                //}
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = ""; string ssreturn = "";
            if (Convert.ToDateTime(txtFromDate.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Travel Date should not be less than Current Date." + "');</script>", false);
                lblMsg.Text = "Travel Date should not be less than Current Date.";
                return;
            }
            if (rbtnRoundTrip.Checked)
            {
                if (Convert.ToDateTime(txtReturnDate.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Return Journey Date should not be less than Current Date." + "');</script>", false);
                    lblMsg.Text = "Return Journey Date should not be less than Current Date.";
                    return;
                }
                if (Convert.ToDateTime(txtReturnDate.Text.ToString()) > Convert.ToDateTime(txtReturnDate.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Return Journey Date should  be greater than Onward Journey Date." + "');</script>", false);
                    lblMsg.Text = "Return Journey Date should  be greater than Onward Journey Date.";
                    return;
                }
                CultureInfo culturereturn = new CultureInfo("pt-BR");
                string datereturn = Convert.ToDateTime(txtReturnDate.Text, culturereturn).ToString();
                DateTime dtreturn = Convert.ToDateTime(txtReturnDate.Text, culturereturn);
                ssreturn = dtreturn.ToString("dd-MMMM-yyyy");
            }
            CultureInfo culture = new CultureInfo("pt-BR");
            string date = Convert.ToDateTime(txtFromDate.Text, culture).ToString();
            DateTime dt = Convert.ToDateTime(txtFromDate.Text, culture);
            string ss = dt.ToString("dd-MMMM-yyyy");

            //if (HttpContext.Current.Session["FromCityId"] == null || HttpContext.Current.Session["ToCityId"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Please enter valid cities." + "');</script>", false);
            //    return;
            //}

            BaseClass basecls = new BaseClass();
            basecls.preLoadParams[0] = ddlSources.SelectedItem.Value.ToString(); //HttpContext.Current.Session["FromCityId"].ToString();//ddlSources.SelectedItem.Value.ToString();
            basecls.preLoadParams[1] = ddlDestinations.SelectedItem.Value.ToString(); //HttpContext.Current.Session["ToCityId"].ToString();//ddlDestinations.SelectedItem.Value.ToString();
            basecls.preLoadParams[2] = ss;
            basecls.preLoadParams[3] = ssreturn;
            basecls.preLoadParams[4] = ddlSources.SelectedItem.Text.ToString(); //txtFrom.Text.ToString();//ddlSources.SelectedItem.Text.ToString();
            basecls.preLoadParams[5] = ddlDestinations.SelectedItem.Text.ToString(); //txtTo.Text.ToString();//ddlDestinations.SelectedItem.Text.ToString();
            basecls.preLoadParams[6] = rbtnOneWay.Checked ? "OneWay" : "RoundTrip";

            HttpContext.Current.Session["Parameters"] = basecls;

            if (basecls.preLoadParams[6].ToString() == "RoundTrip")
            {
                if (Convert.ToDateTime(txtFromDate.Text.ToString()) >= Convert.ToDateTime(txtReturnDate.Text.ToString()))
                {
                   // ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "ReturnDate should be greater than TravelingDate." + "');</script>", false);
                    lblMsg.Text = "ReturnDate should be greater than TravelingDate.";
                    return;
                }
            }
            Response.Redirect("~/Users/Bus/Show_Trips.aspx", false);
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void rbtnOneWay_CheckedChanged(object sender, EventArgs e)
    {
        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = false;
        txtReturnDate.Attributes.Remove("class");
        RequiredReturn.Visible = false; txtReturnDate.Text = ""; lblMsg.Text = "";
        tblReturn.Visible = false;

    }
    protected void rbtnRoundTrip_CheckedChanged(object sender, EventArgs e)
    {
        lblReturningOn.Visible = txtReturnDate.Visible = true;
        txtReturnDate.Enabled = true;
        RequiredReturn.Visible = true; lblMsg.Text = "";
        txtReturnDate.Attributes.Add("class", "datepicker");
        tblReturn.Visible = true;
    }
    void BitlaDestinations()
    {
        try
        {
            BitlaAPILayer o = new BitlaAPILayer();
            o.ApiKey = BitlaConstants.API_KEY;
            o.URL = BitlaConstants.URL;
            DataSet dB = o.GetDestinationPairs();

            DataTable dtOrigin = dB.Tables["origin"];
            DataTable dtDestination = dB.Tables["destination"];

            objBAL = new ClsBAL();
            foreach (DataRow dataRow1 in dtOrigin.Rows)
            {
                DataRow[] drArray2 = dtDestination.Select("destination_pair_Id = '" + dataRow1["destination_pair_Id"].ToString() + "'");
                foreach (DataRow dataRow2 in drArray2)
                {
                    objBAL.AddBitlaDestinations(dataRow2["id"].ToString(), dataRow2["name"].ToString(),
                        dataRow1["id"].ToString());
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void BitlaCities()
    {
        try
        {
            BitlaAPILayer o = new BitlaAPILayer();
            o.ApiKey = BitlaConstants.API_KEY;
            o.URL = BitlaConstants.URL;
            DataSet dB = o.GetCities();
            objBAL = new ClsBAL();
            foreach (DataRow item in dB.Tables[0].Rows)
            {
                objBAL.AddBitlaCities(item["id"].ToString(), item["name"].ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void Sources(DataTable dtSources)
    {
        try
        {
            objBAL = new ClsBAL();
            DataView dv = new DataView(dtSources);
            DataRow[] dr = dtSources.Select("SourceName IN ('AHMEDABAD','BANGALORE','CHENNAI','COIMBATORE','DELHI','GOA','HYDERABAD','MUMBAI','PUNE')");
            foreach (DataRow item1 in dr)
            {
                objBAL.ticketId = item1["AllIds"].ToString();
                objBAL.name = item1["SourceName"].ToString();
                objBAL.AddSources();
            }
            if (dr.Length != 0)
            {
                objBAL.ticketId = "----------";
                objBAL.name = "----------";
                objBAL.AddSources();
            }
            foreach (DataRow item2 in dtSources.Rows)
            {
                objBAL.ticketId = item2["AllIds"].ToString();
                objBAL.name = item2["SourceName"].ToString();
                objBAL.AddSources();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    void DestinationsBySource(string sourceId, DataTable dtDestinations)
    {
        try
        {
            objBAL = new ClsBAL();
            DataView dv = new DataView(dtDestinations);
            DataRow[] dr = dtDestinations.Select("DestinationName IN ('AHMEDABAD','BANGALORE','CHENNAI','COIMBATORE','DELHI','GOA','HYDERABAD','MUMBAI','PUNE')");
            foreach (DataRow item1 in dr)
            {
                objBAL.AddDestinations(item1["AllIds"].ToString(), item1["DestinationName"].ToString(), sourceId);
            }
            foreach (DataRow item in dtDestinations.Rows)
            {
                objBAL.AddDestinations(item["AllIds"].ToString(), item["DestinationName"].ToString(), sourceId);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetCities(string prefixText)
    {
        try
        {
            DataSet ds = null;
            if (HttpContext.Current.Session["Cities"] != null)
            {
                ds = (DataSet)HttpContext.Current.Session["Cities"];
            }
            else
            {
                ClsBAL objBAL = new ClsBAL();
                ds = objBAL.GetSourcess();
            }

            string filteringquery = "SourceName LIKE'" + prefixText + "%'";
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            DataTable dtNew = new DataTable();
            dtNew = ds.Tables[0].Clone();
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["SourceName"].ToString().Trim());//+ " ||| " + dtNew.Rows[i]["ID"].ToString().Trim().ToString());
            }
            return airports;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = null;
        if (HttpContext.Current.Session["Cities"] != null)
        {
            ds = (DataSet)HttpContext.Current.Session["Cities"];
        }
        else
        {
            ClsBAL objBAL = new ClsBAL();
            ds = objBAL.GetSourcess();
        }


        string filteringquery = "SourceName LIKE'" + txtFrom.Text.ToString() + "%'";
        DataRow[] dr = ds.Tables[0].Select(filteringquery);
        DataTable dtNew = new DataTable();
        dtNew = ds.Tables[0].Clone();
        foreach (DataRow drNew in dr)
        {
            dtNew.ImportRow(drNew);
        }

        if (dtNew.Rows.Count >= 1)
        {
            HttpContext.Current.Session["FromCityId"] = dtNew.Rows[0]["ID"].ToString();
            txtTo.Focus();
        }
        else
        {
            HttpContext.Current.Session["FromCityId"] = null;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Please enter valid city." + "');</script>", false);
            return;
        }
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = null;
        if (HttpContext.Current.Session["Cities"] != null)
        {
            ds = (DataSet)HttpContext.Current.Session["Cities"];
        }
        else
        {
            ClsBAL objBAL = new ClsBAL();
            ds = objBAL.GetSourcess();
        }


        string filteringquery = "SourceName LIKE'" + txtTo.Text.ToString() + "%'";
        DataRow[] dr = ds.Tables[0].Select(filteringquery);
        DataTable dtNew = new DataTable();
        dtNew = ds.Tables[0].Clone();
        foreach (DataRow drNew in dr)
        {
            dtNew.ImportRow(drNew);
        }

        if (dtNew.Rows.Count >= 1)
        {
            HttpContext.Current.Session["ToCityId"] = dtNew.Rows[0]["ID"].ToString();
            txtFromDate.Focus();
        }
        else
        {
            HttpContext.Current.Session["ToCityId"] = null;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "Please enter valid city." + "');</script>", false);
            return;
        }
    }
}