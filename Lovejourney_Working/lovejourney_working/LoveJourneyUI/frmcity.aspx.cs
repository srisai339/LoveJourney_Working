using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class frmcity : System.Web.UI.Page
{
    ClsCommands objCity = new ClsCommands();
    DataSet _objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //fnLoadPage();
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            BindDataCity();
        }

    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            objCity.ScreenInd = blossom.InsertCity;
            objCity.CityName = txtCityName.Text.ToString();
            objCity.CreatedBy = 1;
            if (objCity.fnInsertRecord() == true)
            {
                lblMsg.Text = "Record Inserted Successfully";
                BindDataCity();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }

    }





    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            objCity.ScreenInd = blossom.UpdateCity;
            objCity.CityId = Convert.ToInt32(lblCityId.Text);
            objCity.CityName = txtCityName.Text.ToString();
            objCity.ModifiedBy = 1;
            if (objCity.fnUpdateRecord() == true)
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
                lblMsg.Text = "Record Update Successfully";

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    private void BindDataCity()
    {
        try
        {
            objCity.ScreenInd = blossom.SelectCityName;
            _objDataSet = (DataSet)objCity.fnGetData();
            gvCityName.DataSource = _objDataSet;
            gvCityName.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }

    //private void BindDataCityDetails()
    //{
    //    try
    //    {
    //        objCity.ScreenInd = blossom.SelectAllCitys;
    //        _objDataSet = (DataSet)objCity.fnGetData();
    //        gvCityDetails.DataSource = _objDataSet;
    //        gvCityDetails.DataBind();
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    protected void gvCityName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCityName.PageIndex = e.NewPageIndex;
            gvCityName.DataSource = ViewState["CityName"];
            gvCityName.DataBind();
            BindDataCity();
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void gvCityName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCityId.Text = gvCityName.DataKeys[gvCityName.SelectedIndex].Values["CityId"].ToString();
            txtCityName.Text = gvCityName.DataKeys[gvCityName.SelectedIndex].Values["CityName"].ToString();
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            btnInsert.Visible = false;
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            objCity.ScreenInd = blossom.DeleteCity;
            objCity.CityId = Convert.ToInt32(lblCityId.Text);

            if (objCity.fnDeleteRecord() == true)
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
                lblMsg.Text = "Record Deleted Successfully";

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnCancel.Visible = false;
        btnInsert.Visible = true;
        txtCityName.Text = "";
        //fnLoadPage();
        BindDataCity();
    }
}