using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;



public partial class Cab_Cancel : System.Web.UI.Page
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

    }
    double comm;
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objResult.ReferanceId = txtBookingRefNo.Text;
        objResult.EmailId = txtEmailId.Text;
        objResult.ScreenInd = blossom.GetCancellationdetails;

        _objDataSet = (DataSet)objResult.fnGetData();
        if (_objDataSet != null)
        {
            if (_objDataSet.Tables[0].Rows[0]["Status"].ToString() == "Canceled")
            {
                lblCancel.Text = "Ticket Has been already cancelled";
                lblCancel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            string actualfare = _objDataSet.Tables[0].Rows[0]["BasicFare"].ToString();
            comm = 10.0;
            double cancellationAmount = Convert.ToDouble(actualfare) * comm / 100;
            double refundTotalAmount = Convert.ToDouble(actualfare) - cancellationAmount;
            ClsBAL objBAL;
            objBAL = new ClsBAL();
            objBAL.AdjustAgentBalance1(txtBookingRefNo.Text.Trim().ToString(),
                Convert.ToDouble(refundTotalAmount), Convert.ToDouble(cancellationAmount),
                Convert.ToInt32(Session["UserID"].ToString()));

            DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
            Label lbl = (Label)this.Master.FindControl("lblBalance");
            lbl.Text = balance.ToString();
            Session["Balance"] = balance;
            
           
            string str=objBAL.Updatecancelstatus(txtBookingRefNo.Text,"Canceled");
            lblCancel.Text = str;
            lblCancel.ForeColor = System.Drawing.Color.Green;
          
            txtEmailId.Text = txtBookingRefNo.Text = "";










        }
        else
        {
            lblCancel.Text = "Invalid Ref/EmailId";
        }
    }
}