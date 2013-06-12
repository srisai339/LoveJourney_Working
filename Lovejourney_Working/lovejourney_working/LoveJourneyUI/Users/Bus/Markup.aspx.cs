using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;


public partial class Agent_Bus_Markup : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDispaly.Text = "";
        if (!IsPostBack)
        {
            //Panel pnl = (Panel)this.Master.FindControl("Menu1");
            //pnl.Visible = false;
            BindMarkUp();
            //btnAd_Click(sender, e);

           
        }

    }
   
    private void BindMarkUp()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();           
            objBal.ScreenInd = Master123.GetAgentMarkup;
            objBal.Agentid = Convert.ToInt32(Session["UserID"].ToString());
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables.Count > 0)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {                   
                    gvMarkUp.DataSource = objDataSet.Tables[0];
                    gvMarkUp.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



    protected void gvMarkUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvMarkUp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow row = ctl.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(e.CommandArgument);
            lblid.Text = id.ToString();
            //Label lblFlightsName = (Label)row.FindControl("lblFlightsName");
            btnAd.Visible = false;
            lblDispaly.Text = "";

            Label Type = (Label)row.FindControl("lblType");
            Label lblMarkupAmount = (Label)row.FindControl("lblMarkupAmount");
           // Label lblMarkupPercentage = (Label)row.FindControl("lblMarkupPercentage");

            txtAmount.Text = lblMarkupAmount.Text;
            ddltype.SelectedItem.Text = Type.Text;
            typed.Visible = false;
            btnUpdate.Visible = true;
         
            btnCancel.Visible = true;
        }
        if (e.CommandName == "Delete")
        {
            Control ct2 = e.CommandSource as Control;
            GridViewRow row1 = ct2.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(e.CommandArgument);
            lblid.Text = id.ToString();
            Label Type = (Label)row1.FindControl("lblType");
            Label lblMarkupAmount = (Label)row1.FindControl("lblMarkupAmount");
            Label lblMarkupPercentage = (Label)row1.FindControl("lblMarkupPercentage");
           // Label 

            id = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.DeleteAgentMarkup;
            objBal.id = id;
            if (objBal.fnDeleteRecord() == true)
            {
                BindMarkUp();
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int id1 = Convert.ToInt32(lblid.Text);
            objBal = new Class1();
            objBal.ScreenInd = Master123.UpdateAgentMarkUp;
            objBal.Modifyby = Convert.ToInt32(Session["UserID"]);
            objBal.id = id1;
            int Agentid = Convert.ToInt32(Session["UserId"]);
            objBal.Agentid = Agentid;
           


           // objBal.Type = ddltype.SelectedItem.Text;
            objBal.MarkupAmount = txtAmount.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                //flights.Visible = false;
                txtAmount.Text = "";
                typed.Visible = true;
                //txtPercentage.Text = "";
                //ddlFlightType.ClearSelection();
                //ddlDomestic.ClearSelection();
                //ddlInterNational.ClearSelection();
                BindMarkUp();
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnAd.Visible = true;
                lblDispaly.Text = "You have Successfully Updated Markup Price";
                ddltype.SelectedItem.Text = "Please Select";

            }



        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddltype.Items.Clear();
        //  txtPercentage.Text = "";
        txtAmount.Text = "";
    }
    protected void gvMarkUp_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnMarkupback_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentDashBoard.aspx");
    }
    


    protected void btnAd_Click(object sender, EventArgs e)
    {
        //if (ddltype.SelectedItem.Text == "Domestic Flights")
        //{
        //    try
        //    {

        //        objBal = new Class1();
        //        string message = "";
        //        int id = Convert.ToInt32(Session["UserID"]);
        //        objBal.MarkupAmount = txtAmount.Text;
        //       // objBal.subType = ddlDomesticType.SelectedItem.Text;
        //        objBal.id = id;
        //        message = objBal.AddMarkup();
        //        if (message == "You have Successfully Entered Your Details")
        //        {
        //            //tdmsg.Visible = true;

        //            lblDispaly.Text = "You have Successfully Entered Your Details";
        //            BindMarkUp();
        //            txtAmount.Text = "";
        //            ddltype.ClearSelection();
        //            //domestic.Visible = false;

        //        }
        //        else
        //        {
        //            //mp3.Show();
        //            //lblcomment.Text = message;
        //            // tdmsg.Visible = true;
        //            lblDispaly.Text = message;
        //            ddltype.ClearSelection();
        //            txtAmount.Text = "";
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //}
        //else
        //{
            try
            {

                objBal = new Class1();
                string message = "";
                int id = Convert.ToInt32(Session["UserID"]);
                objBal.MarkupAmount = txtAmount.Text;
                objBal.Type = ddltype.SelectedItem.Text;
                objBal.id = id;
                message = objBal.AddMarkup();
                if (message == "Insert Mark up Successfully")
                {
                   

                    lblDispaly.Text = "You have Successfully Entered Your Details";
                    
                    BindMarkUp();
                    txtAmount.Text = "";
                    ddltype.ClearSelection();

                }
                else
                {
                    
                    lblDispaly.Text = message;
                    ddltype.ClearSelection();
                    txtAmount.Text = "";

                }
            }

            catch (Exception ex)
            {

            }

        
    }


   
}