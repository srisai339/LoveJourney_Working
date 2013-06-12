using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FilghtsAPILayer;
using BAL;
public partial class Users_Flight_frmCancelTicketStatus : System.Web.UI.Page
{

    FlightsAPILayer objFlights = new FlightsAPILayer();
    string transId = string.Empty;
    FlightBAL objFlightBal = new FlightBAL();
    DataSet objDataSet;
    ClsBAL objBAL;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
            CheckPermission("FlightsCancelTicketStatus", Session["Role"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
     protected void CheckPermission(string pageName, string role)
    {
        try
        {
            panelBookingStatus.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                panelBookingStatus.Visible = false;

                objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                objDataSet = (DataSet)objBAL.GetPerByUser();
                if (objDataSet != null)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        ViewState["UserPermissions"] = objDataSet.Tables[0];
                        ViewState["Book"] = objDataSet.Tables[0].Rows[0]["Book"].ToString();
                    }
                    else { ViewState["UserPermissions"] = null; }
                }
                else { ViewState["UserPermissions"] = null; }

                if (ViewState["UserPermissions"] != null)
                {
                    if (ViewState["Book"] != null)
                    {
                        if (ViewState["Book"].ToString() == "1")
                        {
                            panelBookingStatus.Visible = true;
                            tdmsg.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsGetTransId = new DataSet();
            dsGetTransId = objFlightBal.GetTransID(txtBookingReferenceNo.Text);
            transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();

            if (transId != "")
            {

                String xmlCancelReqStatus = "<EticketCanStatusReq><Clientid>"+ FlightsConstants.USERID +"</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>" + transId + "</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
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
                    ClsBAL objBAL = new ClsBAL();
                    objBAL.AdjustAgentBalance(txtBookingReferenceNo.Text.Trim().ToString(),
                        Convert.ToDouble(objFlightBal.FinalRefundAmount), Convert.ToDouble(objFlightBal.CancellationCharges),
                        Convert.ToInt32(Session["UserID"].ToString()));

                    DataSet dsBalance = objBAL.GetAgentByUserId(Convert.ToInt32(Session["UserID"].ToString()));

                    string balance = dsBalance.Tables[0].Rows[0]["Balance"].ToString();
                    Label lbl = (Label)this.Master.FindControl("lblBalance");
                    lbl.Text = balance;
                    Session["Balance"] = balance;
                    if (res)
                    {
                        lblStatus.Text = "Updated the status";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Visible = true;
                    }
                }
            }
            else
            {
                lblStatus.Text = "Invalid Request";
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnGetInt_Click(object sender, EventArgs e)
    {
        DataSet dsGetTransId = new DataSet();
        DataSet ds = new DataSet();
        dsGetTransId = objFlightBal.GetIntTransID(txtBookingReferenceNo.Text);
        transId = dsGetTransId.Tables[0].Rows[0]["transid"].ToString();


        String xmlCancelReqStatus = "<CanStatusIntRequest><Clientid>"+ FlightsConstants.USERID +"</Clientid><Clientpassword>" + FlightsConstants.PASSWORD + "</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><Transid>" + transId + "</Transid><PartnerRefId></PartnerRefId><CancellationId></CancellationId></CanStatusIntRequest>";

        // ds.ReadXml("F:\\Projects\\Love Journey\\Cancel_International_Static_Response.xml");
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
}