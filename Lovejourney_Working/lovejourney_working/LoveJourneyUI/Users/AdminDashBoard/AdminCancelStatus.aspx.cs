using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FilghtsAPILayer;
using BAL;

public partial class AdminDashBoard_AdminCancelStatus : System.Web.UI.Page
{
    FlightsAPILayer objFlights = new FlightsAPILayer();
    string transId = string.Empty;
    FlightBAL objFlightBal = new FlightBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("pnl");
            pnl.Visible = false;
        }
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


            String xmlCancelReqStatus = "<EticketCanStatusReq><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>" + transId + "</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
             DataSet dsCancelStatusResponse = objFlights.GetCancelTicketStatus(xmlCancelReqStatus);
            //DataSet dsCancelStatusResponse = new DataSet();
            //dsCancelStatusResponse.ReadXml("F:\\Projects\\Love Journey\\Cancel_Domestic_Static_Response.xml");
            if (dsCancelStatusResponse != null)
            {
                objFlightBal.Status = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["CancellationStatus"].ToString();
                objFlightBal.TransId = dsCancelStatusResponse.Tables["EticketCanStatusRes"].Rows[0]["transid"].ToString();
                objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;

                objFlightBal.CancellationProcessDateTime = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["CancellationProcessDateTime"].ToString();
                objFlightBal.CancellationCharges = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["CancellationCharges"].ToString();
                objFlightBal.RefundStatus = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["RefundStatus"].ToString();
                objFlightBal.FinalRefundAmount = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["FinalRefundAmount"].ToString();
                objFlightBal.RefundDateTime = dsCancelStatusResponse.Tables["Cancellation"].Rows[0]["RefundDateTime"].ToString();


                bool res = objFlightBal.UpdateDomesticFlightCancelStatus(objFlightBal);
                //ClsBAL objBAL = new ClsBAL();
                //objBAL.AdjustAgentBalance(txtBookingReferenceNo.Text.Trim().ToString(),
                //    Convert.ToDouble(objFlightBal.FinalRefundAmount), Convert.ToDouble(objFlightBal.CancellationCharges),
                //    Convert.ToInt32(Session["UserID"].ToString()));

                //DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                //string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                //Label lbl = (Label)this.Master.FindControl("lblBalance");
                //lbl.Text = balance;
                //Session["Balance"] = balance;
                if (res)
                {
                    lblStatus.Text = "Updated the status";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void rbtnDomesticInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnDomesticInt.SelectedValue == "0")
        {
            btnGet.Visible = true;
            btnGetInt.Visible = false;
        }
        else
        {
            btnGet.Visible = false;
            btnGetInt.Visible = true;
        }
    }
    protected void btnGetInt_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();
        DataSet ds = new DataSet();
        dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


        String xmlCancelReqStatus = "<CanStatusIntRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><Transid>" + transId + "</Transid><PartnerRefId></PartnerRefId><CancellationId></CancellationId></CanStatusIntRequest>";

        //ds.ReadXml("F:\\Projects\\Love Journey\\Cancel_International_Static_Response.xml");
       ds = objFlightBal.GetDatasetFromAPI(xmlCancelReqStatus, "http://live.arzoo.com:9302/CancellationStatus");

        if (ds != null)
        {

            objFlightBal.Status = ds.Tables["Cancellation"].Rows[0]["CancellationStatus"].ToString();
            objFlightBal.TransId = ds.Tables["CanStatusInResponse"].Rows[0]["transid"].ToString();
            objFlightBal.ReferenceNo = txtBookingReferenceNo.Text;

            objFlightBal.CancellationProcessDateTime = ds.Tables["Cancellation"].Rows[0]["CancellationProcessDateTime"].ToString();
            objFlightBal.CancellationCharges = ds.Tables["Cancellation"].Rows[0]["CancellationCharges"].ToString();
            objFlightBal.RefundStatus = ds.Tables["Cancellation"].Rows[0]["RefundStatus"].ToString();
            objFlightBal.FinalRefundAmount = ds.Tables["Cancellation"].Rows[0]["FinalRefundAmount"].ToString();
            objFlightBal.RefundDateTime = ds.Tables["Cancellation"].Rows[0]["RefundDateTime"].ToString();
            objFlightBal.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());

            bool res = objFlightBal.UpdateDomesticFlightCancelStatus(objFlightBal);
            //ClsBAL objBAL = new ClsBAL();
            //objBAL.AdjustAgentBalance(txtBookingReferenceNo.Text.Trim().ToString(),
            //    Convert.ToDouble(refundTotalAmount), Convert.ToDouble(cancellationAmount),
            //    Convert.ToInt32(Session["UserID"].ToString()));

            //DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

            //string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
            //Label lbl = (Label)this.Master.FindControl("lblBalance");
            //lbl.Text = balance;
            //Session["Balance"] = balance;
        }
    }
    protected void btnCancelstatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashBoard.aspx");
    }
}