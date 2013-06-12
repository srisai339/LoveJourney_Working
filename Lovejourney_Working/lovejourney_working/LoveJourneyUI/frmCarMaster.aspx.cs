using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class frmCarMaster : System.Web.UI.Page
{
    ClsCommands objCar = new ClsCommands();
    DataSet _objDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            BindDataCar();
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            objCar.ScreenInd = blossom.InsertCar;
            objCar.CarName = txtCarName.Text.ToString();
           string filename = Path.GetFileName(fuImage.PostedFile.FileName);
           fuImage.SaveAs(Server.MapPath("~/Cars/" + filename));
            string pathname = "~/Cars/" + filename;
            objCar.carimagepath = pathname;

            objCar.CreatedBy = 1;
            if (objCar.fnInsertRecord() == true)
            {
                lblMsg.Text = "Record Inserted Successfully";
                BindDataCar();
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
            objCar.ScreenInd = blossom.UpdateCar;
            objCar.CarId = Convert.ToInt32(lblCarId.Text);
            objCar.CarName = txtCarName.Text.ToString();
            string filename = Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath("Cars" + filename));
            string pathname = "Cars" + filename;
            objCar.carimagepath = pathname;

            objCar.ModifiedBy = 1;
            if (objCar.fnUpdateRecord() == true)
            {
                btnInsert.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
                lblMsg.Text = "Record Update Successfully";
                BindDataCar();

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
            objCar.ScreenInd = blossom.DeleteCar;
            objCar.CarId = Convert.ToInt32(lblCarId.Text);

            if (objCar.fnDeleteRecord() == true)
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
        txtCarName.Text = "";
        BindDataCar();
    }
    protected void gvCarName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCarName.PageIndex = e.NewPageIndex;
            gvCarName.DataSource = ViewState["CarName"];
            gvCarName.DataBind();
            BindDataCar();
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void gvCarName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblCarId.Text = gvCarName.DataKeys[gvCarName.SelectedIndex].Values["CarId"].ToString();
            txtCarName.Text = gvCarName.DataKeys[gvCarName.SelectedIndex].Values["CarName"].ToString();

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

    private void BindDataCar()
    {
        try
        {
            objCar.ScreenInd = blossom.SelectCar;
            _objDataSet = (DataSet)objCar.fnGetData();
            gvCarName.DataSource = _objDataSet;
            gvCarName.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
}