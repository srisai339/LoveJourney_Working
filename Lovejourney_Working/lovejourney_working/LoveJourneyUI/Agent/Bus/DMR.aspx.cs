using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Agent_Bus_DMR : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             Panel pnl=(Panel)this.Master.FindControl("Menu1");
            pnl.Visible=false;

        }
    }
    protected void btnDepositUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ClsBAL objBAL = new ClsBAL();
            System.Data.DataSet ds1 = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
            string balance = ds1.Tables[0].Rows[0]["Balance"].ToString();
            if ((Convert.ToDecimal(balance)) > ((Convert.ToDecimal(txtDepositAmount.Text.ToString()) + 25)))
            {

                if ((Convert.ToDecimal(txtDepositAmount.Text.ToString()) >= Convert.ToDecimal("1000"))
                    && (Convert.ToDecimal(txtDepositAmount.Text.ToString())) <= Convert.ToDecimal("25000"))
                {

                    clsMasters _objmasters = new clsMasters();
                    _objmasters.ScreenInd = Masters.Dmr;
                    _objmasters.Amount1 = (Convert.ToDecimal(txtDepositAmount.Text.ToString()));
                    _objmasters.ExtraCharges = Convert.ToDecimal("25");
                    _objmasters.Date = txtChequeIssueDate.Text.ToString();
                    _objmasters.Accountholdername = txtholdername.Text;
                    _objmasters.Accountnumber = txtaccountnumber.Text;
                    _objmasters.IFSCCode = ifsccode.Text;
                    _objmasters.BankName = txtbankname.Text;
                    _objmasters.BranchName = txtbranchname.Text;
                    _objmasters.SenderName = txtsendername.Text;
                    _objmasters.MobileNumber = txtMobileNumber.Text;
                    _objmasters.Status = "No";
                    _objmasters.CreatedBy = Session["UserID"].ToString();

                    ClsBAL objBAL1 = new ClsBAL();
                    System.Data.DataSet ds = objBAL1.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                    _objmasters.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["AgentId"].ToString());

                    if (_objmasters.fnInsertRecord() == true)
                    {
                        lblmsg.Text = "Your request submitted  succesfully.";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        ClsBAL objBAL2 = new ClsBAL();
                        System.Data.DataSet ds2 = objBAL2.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));
                        Session["Balance"] = ds2.Tables[0].Rows[0]["Balance"].ToString();

                        Label lbl = (Label)this.Master.FindControl("lblBalance");
                        lbl.Text = Session["Balance"].ToString();

                    //    ClsBAL objBal1 = new ClsBAL();
                    //    string msg = objBal1.DeductAgentDeposit(Convert.ToInt32(Session["UserID"].ToString())
                    //, Convert.ToDouble(txtDepositAmount.Text.ToString()), "", Convert.ToInt32(Session["UserID"].ToString())
                    //, "Dmr", "", "");
                    }
                }
                else
                {
                    lblmsg.Text = "Your transaction amount should be minimum 1000 and maximum 25000.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblmsg.Text = "Your balance  should be greater than the transfer amount. ";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }



    }
}