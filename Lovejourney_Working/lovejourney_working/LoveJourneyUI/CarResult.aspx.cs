using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class CarResult : System.Web.UI.Page
{
    ClsCommands objResult = new ClsCommands();
    DataSet _objDataSet;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {

                this.MasterPageFile = "UserMasterPage.master";
            }
            else if (Session["Role"].ToString() == "Agent")
            {

                this.MasterPageFile = "AgentMasterPage.master";
            }

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCitydropdown();
            lblText.Text = "Cars in" + Session["CityName"].ToString() + "On" + Session["TravelDate"].ToString();
            DDLCity.SelectedItem.Text = Session["CityName"].ToString();
            txtDate.Text = Session["TravelDate"].ToString();
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Agent")
                {
                    lnkSNFFare.Visible = true;
                }
                else 
                {
                    lnkSNFFare.Visible = false;
                }

            }
            else
            {
                lnkSNFFare.Visible = false;
            }

            if (Session["CityId"].ToString() != null)
            {
                ViewState["SortDirection"] = "ASC";
                ViewState["Data"] = null;
                BindDataCarResult();
            }
        }

    }
    private void BindCitydropdown()
    {

        objResult.ScreenInd = blossom.SelectCityName;
        _objDataSet = (DataSet)objResult.fnGetData();
        DDLCity.DataSource = _objDataSet.Tables[0];
        DDLCity.DataTextField = "CityName";
        DDLCity.DataValueField = "CityId";
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    private void BindDataCarResult()
    {
        try
        {
            objResult.ScreenInd = blossom.SelectCarResult;
            objResult.CityId = Convert.ToInt32(Session["CityId"].ToString());
            _objDataSet = (DataSet)objResult.fnGetData();
            gvCarresult.DataSource = _objDataSet;
            ViewState["Data"] = _objDataSet;
            gvCarresult.DataBind();
            gvCarresult.EmptyDataText = "No Cars Found";
        }
        catch (Exception)
        {

            throw;
        }
    }



    protected void gvCarresult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "BookNow")
            {

                Session["CardetailsId"] = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Passenger Info.aspx");

            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkCarPolicy_Click(object sender, EventArgs e)
    {
        try
        {
            Class1 objBal;
            DataSet objDataSet;
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetCarPolicy;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvAdminRemainders.DataSource = objDataSet.Tables[0];
                  
                    gvAdminRemainders.DataBind();
                    modalpopuphotelpolicy.Show();



                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    protected void gvCarresult_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (true)
            {
                string strExpression = e.SortExpression;
                string strDirection = ViewState["SortDirection"].ToString();
                if (ViewState["Data"] != null)
                {
                    DataTable ds = (DataTable)ViewState["Data"];
                    DataTable dt = ds;
                    DataView dv = new DataView(dt);
                    dv.Sort = strExpression + strDirection;
                    gvCarresult.DataSource = dv;
                    gvCarresult.DataBind();
                    if (strDirection == " ASC") { ViewState["SortDirection"] = " DESC"; } else { ViewState["SortDirection"] = " ASC"; }
                }
                else { BindDataCarResult(); }
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    private void SortGridView(string sortExpression, string direction)
    {
        //  You can cache the DataTable for improving performance
        DataTable dt = ((DataTable)Session["GvReports"]);
        //GetData().Tables[0];
        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + direction;

        gvCarresult.DataSource = dv;
        gvCarresult.DataBind();

    }
    double total;
    protected void gvCarresult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
         
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Session["UserID"] != null)
                {
                    if (Session["Role"].ToString() == "Agent")
                    {
                        ClsBAL objBAL = new ClsBAL();
                        DataSet dsCommSlab = objBAL.GetCommissionSlab(Session["Role"].ToString(), "Car", "");
                        string commisionPercentage = string.Empty;
                        if (dsCommSlab != null)
                        {
                            if (dsCommSlab.Tables[0].Rows.Count > 0)
                            {
                                commisionPercentage = dsCommSlab.Tables[0].Rows[0]["Commission"].ToString();
                            }
                            else
                            {
                                commisionPercentage = "0";
                            }
                        }
                        else
                        {
                            commisionPercentage = "0";
                        }
                      

                        Label lblHNFFare = (Label)e.Row.FindControl("lblHNFFare");
                        Label lblBasicPrice = (Label)e.Row.FindControl("lblBasicPrice");
                        total = Convert.ToDouble(lblBasicPrice.Text);
                        

                        double CommissionFare = ((total * Convert.ToDouble(commisionPercentage)) / 100);
                        double DeductAmount = total - CommissionFare;
                        lblHNFFare.Text = Convert.ToDouble(DeductAmount).ToString();
                        double newcomm = total - Convert.ToDouble(DeductAmount);
                        int newcomm1 = Convert.ToInt32(newcomm);

                        Label lblagentcomm1 = (Label)e.Row.FindControl("lblagentcomm1");
                        lblagentcomm1.Text = "com:" + newcomm1.ToString();



                        #region Markupfarefor Individual agents
                        Class1 objBal = new Class1();
                        DataSet objDataSet = new DataSet();
                        objBal.ScreenInd = Master123.gettopmarkup;
                        objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
                        objBal.Type = "Cabs";
                        objDataSet = (DataSet)objBal.fnGetData();
                        string markUpAmount = "0";
                        ViewState["MarkUp"] = markUpAmount;
                        if (objDataSet != null)
                        {
                            if (objDataSet.Tables.Count > 0)
                            {
                                markUpAmount = objDataSet.Tables[0].Rows[0]["MarkUpAmount"].ToString();
                                ViewState["MarkUp"] = markUpAmount;
                            }
                        }
                        double markupfare = Convert.ToDouble(ViewState["MarkUp"]);
                        total += markupfare;
                        lblBasicPrice.Text = total.ToString();

                        #endregion




                    }
                }
       
            }
            else
            {
                e.Row.Visible = false;
            }
       
        
        }

    protected void lnkbtn_Click(object sender, EventArgs e)
    {
       
        GridView gdv = (GridView)this.FindControl("gvCarresult");

        

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["CityId"] = Convert.ToInt32(DDLCity.SelectedValue);
        Session["CityName"] = Convert.ToString(DDLCity.SelectedItem.Text);

        Session["TravelDate"] = txtDate.Text.ToString();
        lblText.Text = "Cars in" + Session["CityName"].ToString() + "On" + Session["TravelDate"].ToString();
        if (Session["Role"] != null)
        {
            if (Session["Role"].ToString() == "Agent")
            {
                lnkSNFFare.Visible = true;
            }
            else
            {
                lnkSNFFare.Visible = false;
            }

        }
        else
        {
            lnkSNFFare.Visible = false;
        }

        if (Session["CityId"].ToString() != null)
        {
            ViewState["SortDirection"] = "ASC";
            ViewState["Data"] = null;
            BindDataCarResult();
        }
    }
}
   

