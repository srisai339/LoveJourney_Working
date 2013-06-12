using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;

public partial class Users_Flight_CashCouponMaster : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCashCoupon();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        objBal = new Class1();
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
            objBal.Emailid = txtEmailId.Text;
            objBal.MobileNo = txtMobileNo.Text;

            objBal.ScreenInd = Master123.InsertCashCoupon;
            objBal.id = id;

            if (objBal.fnInsertRecord() == true)
            {

                mail();
                BindCashCoupon();
                ddlserviceName.ClearSelection();
                txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text = txtEmailId.Text=txtMobileNo.Text="";

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


    private void BindCashCoupon()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetCashCoupon;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvCashCoupon.DataSource = objDataset.Tables[0];
                    gvCashCoupon.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            int id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateCashCoupon;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id;
            objBal.operatorName = ddlserviceName.SelectedItem.Text;
            objBal.promocode = txtpromocode.Text;
            objBal.Amount = txtAmount.Text;
            objBal.DaystoExpiry = txtDaystoexpire.Text;
            objBal.MinValue = txtminamt.Text;
            objBal.MaxValue = txtmaxamt.Text;
            objBal.MobileNo = txtMobileNo.Text;
            objBal.Emailid = txtEmailId.Text;



            if (objBal.fnUpdateRecord() == true)
            {
                btnAdd.Visible = true;
                ddlserviceName.ClearSelection();
                txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text=txtMobileNo.Text=txtEmailId.Text = "";



            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void gvCashCoupon_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvCashCoupon_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvCashCoupon_RowCommand(object sender, GridViewCommandEventArgs e)
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


                Label lblMobileNo = (Label)row.FindControl("lblMobileNo");
                txtMobileNo.Text = lblMobileNo.Text;

                Label lblEmailId = (Label)row.FindControl("lblEmailId");
                txtEmailId.Text = lblEmailId.Text;




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
                objBal.ScreenInd = Master123.DeleteCashCoupon;
                objBal.id = id;
                if (objBal.fnDeleteRecord() == true)
                {
                    // lblmsg.Text = "You have successfully deleted Your Record";
                    BindCashCoupon();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlserviceName.ClearSelection();
        txtpromocode.Text = txtminamt.Text = txtmaxamt.Text = txtDaystoexpire.Text = txtAmount.Text = txtMobileNo.Text = txtEmailId.Text = "";


    }
    protected void mail()
    {

        //string Body = "Dear <b>" + txtName.Text + "</b>," +
        //"<br /><br />Let us welcome you recharge with lovejourney.in . " +
        // "Following are your login details. <br/> <br/>" +
        //" Email ID :<b>" + txtEmailId.Text.Trim() + "</b><br />" +
        //" Password : <b>" + txtPassword.Text.Trim() + "</b><br/>" +
        //"<br /><br />you have successfully registered in www.lovejourney.in and please" +
        //"do not hesitate<br /> to write to us at <a href='mailto:info@lovejourney.in'>Mail</a> " + " " +
        //"should you have any questions. <br /><br />Best Regards,<br />Administrator <br /> <a href='http://info@lovejourney.in'> lovejourney.in</a>" +
        //"<br /><br />";

        //MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-login", Body);


        string Body = "<html><head><title>LOVE JOURNEY - Registry Creation Account Mail</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='padding:0;       margin:0;font-family:Arial, Helvetica, sans-serif;font-size:12px;font-weight:normal;color:#000;'>" +
                                         "<tr><td height='50' align='center' valign='top'>&nbsp;</td></tr><tr><td align='center' valign='top'><img src='http://lovejourney.in/images/logo.gif' width='214' height='53' /></td> </tr> <tr><td align='center' valign='top'><table width='860' border='0' cellspacing='0' cellpadding='0'>" +
            //Add down this line to every tempuser
                                         "<tr><td height='60' align='center' valign='middle' style='border-bottom: 1px solid #666;border-top: 1px solid #666; font-size: 14px; font-weight:bold;'>Welcome to <strong> <a href='www.lovejourney.in'>lovejourney.in</a></strong><br /><br />Love Journey Makes to Book OnLineTicket.<br />Enjoy discounts on all Festivels For<br /><br />Flights *Buses * Hotels * Recharge</td></tr>" +
                                         "<tr><td align='left' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle' style='border-bottom:1px solid #666; border-top:1px solid #666; font-size:14px;'><strong>Thank you for registering with LoveJourney!</strong></td></tr>" +


                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr><tr><td height='60' align='center' valign='middle'>You have successfuly won the cash Coupon.<br />Your cash coupon is " + txtpromocode.Text + "<br/>If you have questions about your <strong>LOVE JOURNEY</strong>&nbsp;account,  please email<strong> <a href='mailto:info@lovejourney.com'>info@lovejourney.com</a></strong><br />It is recommended that you print, then destroy this email afterwards for added  security.<br /></td></tr>" +
                                         "<tr><td height='25' align='center' valign='middle'>&nbsp;</td></tr> <tr><td height='30' align='center' valign='middle'><strong>Login to your account  online using the following link:</strong></td></tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td></tr><tr><td height='40' align='center' valign='middle'><strong><a href='http://lovejourney.in/Login.aspx'>http://lovejourney.in/Login.aspx&nbsp;</a></strong><br /><br />Sincerely,<br /><br />        <strong><a href='http://WWW.LOVEJOURNEY.in'>WWW.LOVEJOURNEY.IN</a></strong></td>   </tr>" +
                                         "<tr><td align='center' valign='middle'>&nbsp;</td> </tr>   <tr>     <td align='center' valign='middle'>&nbsp;</td>    </tr>     " +
                                         "<tr>  <td align='center' valign='middle'>.........................................................................................................................................................................................................</td>  </tr>" +
                                         "<tr>    <td align='center' valign='middle'>&nbsp;</td>    </tr>" +
                                         "<tr>   <td align='center' valign='middle'>&nbsp;</td>   </tr>  </table></td> </tr></table></body></html><br /><br />";
        MailSender.SendEmail(txtEmailId.Text.Trim(), "info@lovejourney.in", "info@lovejourney.in", "lovejourney-Cash Coupon", Body);

    }
}