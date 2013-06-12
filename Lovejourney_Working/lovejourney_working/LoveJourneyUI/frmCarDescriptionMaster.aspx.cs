using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

public partial class frmCarDescriptionMaster : System.Web.UI.Page
{
    ClsCommands objCarDtl = new ClsCommands();
    DataSet _objDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            BindDataCarDetails();
            BindCitydropdown();
            BindCardropdown();
        }
    }

    private void BindCitydropdown()
    {

        objCarDtl.ScreenInd = blossom.SelectCityName;
        _objDataSet = (DataSet)objCarDtl.fnGetData();
        DDLCity.DataSource = _objDataSet.Tables[0];
        DDLCity.DataTextField = "CityName";
        DDLCity.DataValueField = "CityId";
        DDLCity.DataBind();
        DDLCity.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    private void BindCardropdown()
    {

        objCarDtl.ScreenInd = blossom.SelectCar;
        _objDataSet = (DataSet)objCarDtl.fnGetData();
        DDLCar.DataSource = _objDataSet.Tables[0];
        DDLCar.DataTextField = "CarName";
        DDLCar.DataValueField = "CarId";
        DDLCar.DataBind();
        DDLCar.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            objCarDtl.ScreenInd = blossom.InsertCarDetailsForCity;
            objCarDtl.CityId = Convert.ToInt32(DDLCity.SelectedValue.ToString());
            objCarDtl.CarId = Convert.ToInt32(DDLCar.SelectedValue.ToString());
            objCarDtl.BasicPrice = Convert.ToDouble(txtBasicPrice.Text.ToString());
            objCarDtl.ExtarHours = Convert.ToInt32(txtExtraHours.Text.ToString());
            objCarDtl.ExtarKilometers = Convert.ToInt32(txtExtraKM.Text.ToString());
            objCarDtl.usage = txtUsage.Text;
            objCarDtl.Limit = txtCapacity.Text;
            objCarDtl.CreatedBy = 1;
            if (objCarDtl.fnInsertRecord() == true)
            {
                lblMsg.Text = "Record Inserted Successfully";
                DDLCar.ClearSelection();
                DDLCity.ClearSelection();
                txtBasicPrice.Text = txtExtraHours.Text = txtExtraKM.Text = txtUsage.Text=txtCapacity.Text="";
                BindDataCarDetails();
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
            objCarDtl.ScreenInd = blossom.UpdateCarDetailsForCity;
            objCarDtl.CarDetailsId = Convert.ToInt32(lblCarDetailsId.Text);
            objCarDtl.CityId = Convert.ToInt32(DDLCity.SelectedValue.ToString());
            objCarDtl.CarId = Convert.ToInt32(DDLCar.SelectedValue.ToString());
            objCarDtl.BasicPrice = Convert.ToDouble(txtBasicPrice.Text.ToString());
            
            objCarDtl.ExtarHours = Convert.ToInt32(txtExtraHours.Text.ToString());
            objCarDtl.ExtarKilometers = Convert.ToInt32(txtExtraKM.Text.ToString());
            objCarDtl.usage = txtUsage.Text.ToString();
            objCarDtl.Limit = txtCapacity.Text.ToString();
            objCarDtl.ExtarKilometers = Convert.ToInt32(txtExtraKM.Text.ToString());
            





            objCarDtl.ModifiedBy = 1;
            if (objCarDtl.fnUpdateRecord() == true)
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
                lblMsg.Text = "Record Updated Successfully";
                DDLCar.ClearSelection();
                DDLCity.ClearSelection();
                txtBasicPrice.Text = txtExtraHours.Text = txtExtraKM.Text = txtUsage.Text = txtCapacity.Text = "";
                BindDataCarDetails();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            objCarDtl.ScreenInd = blossom.DeleteCarDetailsForCity;
            objCarDtl.CarId = Convert.ToInt32(lblCarDetailsId.Text);

            if (objCarDtl.fnDeleteRecord() == true)
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
                lblMsg.Text = "Record Deleted Successfully";
                BindDataCarDetails();

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
        txtBasicPrice.Text = "";
        txtExtraHours.Text = "";
        txtExtraKM.Text = "";
        BindDataCarDetails();
    }

    private void BindDataCarDetails()
    {
        try
        {
            objCarDtl.ScreenInd = blossom.SelectAllCarDetailsForCity;
            _objDataSet = (DataSet)objCarDtl.fnGetData();
            gvCarDetails.DataSource = _objDataSet;
            gvCarDetails.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void gvCarDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCarDetails.PageIndex = e.NewPageIndex;
            gvCarDetails.DataSource = ViewState["CityName"];
            gvCarDetails.DataSource = ViewState["CarName"];
            gvCarDetails.DataSource = ViewState["BasicPrice"];
            gvCarDetails.DataSource = ViewState["ExtarHours"];
            gvCarDetails.DataSource = ViewState["ExtarKiloMeters"];
            gvCarDetails.DataSource = ViewState["Usage"];
            gvCarDetails.DataSource = ViewState["Capacity"];
            gvCarDetails.DataBind();
            BindDataCarDetails();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void gvCarDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCarDetailsId.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["CarDetailsId"].ToString();
            DDLCar.SelectedValue = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["CarId"].ToString();
            DDLCity.SelectedValue = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["CityId"].ToString();
            // DDLCar.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["CarName"].ToString();
            txtBasicPrice.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["BasicPrice"].ToString();
            txtExtraHours.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["ExtarHours"].ToString();
            txtExtraKM.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["ExtarKiloMeters"].ToString();
            txtUsage.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["Usage"].ToString();
            txtCapacity.Text = gvCarDetails.DataKeys[gvCarDetails.SelectedIndex].Values["Capacity"].ToString();
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
}