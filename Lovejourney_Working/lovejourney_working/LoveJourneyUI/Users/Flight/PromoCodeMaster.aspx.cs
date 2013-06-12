using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Users_Flight_PromoCodeMaster : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            

            BindPromoCode();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        objBal=new Class1();
        try
        {
            int id = Convert.ToInt32(Session["UserID"]);
            objBal = new Class1();
            objBal.operatorName = ddlserviceName.SelectedItem.Text;
            objBal.promocode = txtpromocode.Text;
            objBal.Amount = txtAmount.Text;
            objBal.DaystoExpiry = txtDaystoexpire.Text;
            objBal.MinValue = txtminamt.Text;
            objBal.MaxValue = txtmaxamt.Text;

            objBal.ScreenInd = Master123.InsertPomocode;
            objBal.id = id;

            if (objBal.fnInsertRecord() == true)
            {


                BindPromoCode();
                ddlserviceName.ClearSelection();
                txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text = "";

            }
            else
            {
                lblMsg.Text = "You can not to be saved your details";
                
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    private void BindPromoCode()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetPromocode;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvPromocode.DataSource = objDataset.Tables[0];
                    gvPromocode.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvPromocode_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Control ctl = e.CommandSource as Control;
                GridViewRow row = ctl.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                Label lblOperator = (Label)row.FindControl("lblOperator");
                ddlserviceName.SelectedValue = lblOperator.Text;

                Label lblPromocode = (Label)row.FindControl("lblPromocode");
                txtpromocode.Text = lblPromocode.Text;

                Label lblAmount = (Label)row.FindControl("lblAmount");
                txtAmount.Text = lblAmount.Text;

                Label lblDaystoExpiry = (Label)row.FindControl("lblDaystoExpiry");
                txtDaystoexpire.Text = lblDaystoExpiry.Text;


                Label lblMinValue = (Label)row.FindControl("lblMinValue");
                txtminamt.Text = lblMinValue.Text;


                Label lblMaxValue = (Label)row.FindControl("lblMaxValue");
                txtmaxamt.Text = lblMaxValue.Text;




                btnUpdate.Visible = true;
                btnAdd.Visible = false;
                btnCancel.Visible = true;

            }
            if (e.CommandName == "Delete")
            {
                Control ct2 = e.CommandSource as Control;
                GridViewRow row1 = ct2.NamingContainer as GridViewRow;
                int id = Convert.ToInt32(e.CommandArgument);
                lblid.Text = id.ToString();
                // Label lblAdminRemainders = (Label)row1.FindControl("lblAdminRemainders");
                id = Convert.ToInt32(lblid.Text);
                objBal = new Class1();
                objBal.ScreenInd = Master123.DeletePromocode;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    // lblmsg.Text = "You have successfully deleted Your Record";
                    BindPromoCode();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvPromocode_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvPromocode_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdatePromocode;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.operatorName=ddlserviceName.SelectedItem.Text;
            objBal.promocode = txtpromocode.Text;
            objBal.Amount = txtAmount.Text;
            objBal.DaystoExpiry = txtDaystoexpire.Text;
            objBal.MinValue = txtminamt.Text;
            objBal.MaxValue = txtmaxamt.Text;


           
            if (objBal.fnUpdateRecord() == true)
            {
                ddlserviceName.ClearSelection();
                txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text = "";
                


            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlserviceName.ClearSelection();
        txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text = "";
                
    }
}