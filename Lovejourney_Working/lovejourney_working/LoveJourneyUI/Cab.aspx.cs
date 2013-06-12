using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class Cab : System.Web.UI.Page
{
    ClsCommands objSearch = new ClsCommands();
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

        }
    }
    private void BindCitydropdown()
    {

        objSearch.ScreenInd = blossom.SelectCityName;
        _objDataSet = (DataSet)objSearch.fnGetData();
        DDLCity.DataSource = _objDataSet.Tables[0];
        DDLCity.DataTextField = "CityName";
        DDLCity.DataValueField = "CityId";
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CityId"] = Convert.ToInt32(DDLCity.SelectedValue);
            Session["CityName"] = Convert.ToString(DDLCity.SelectedItem.Text);

            Session["TravelDate"] = txtDate.Text.ToString();
            Response.Redirect("CarResult.aspx");


        }
        catch (Exception)
        {

            throw;
        }
    }
}