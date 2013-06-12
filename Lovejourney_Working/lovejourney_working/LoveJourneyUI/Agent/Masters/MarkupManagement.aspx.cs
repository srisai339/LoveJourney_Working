using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;


public partial class Agent_Masters_MarkupManagement : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;
            BindMarkUp();
           // BindFlightType();
           // BindDomesticFlights();
            //BindInterNationalFlights();
           // ddlInterNational.Visible = false;
            //ddlDomestic.Visible = false;
            //ddlFlightType.Visible = false;
          






        }
    }
    //private void BindFlightType()
    //{
    //    try
    //    {
    //        objBal = new Class1();
    //        objBal.ScreenInd = Master123.GetType;

    //        objDataSet = (DataSet)objBal.fnGetData();
    //        if (objDataSet != null)
    //        {
    //            if (objDataSet.Tables[0].Rows.Count > 0)
    //            {
    //                //ddlFlightType
    //                ddlFlightType.DataSource = objDataSet.Tables[0];
    //                ddlFlightType.DataValueField = "FlightsId";
    //                ddlFlightType.DataTextField = "FlightType";
    //                ddlFlightType.DataBind();

    //                ddlFlightType.Items.Insert(0, "--Select--");
    //            }
    //        }


    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }

    //}


    //private void BindDomesticFlights()
    //{
    //    try
    //    {
    //        objBal = new Class1();
    //        objBal.ScreenInd = Master123.GetNationalFlights;

    //        objDataSet = (DataSet)objBal.fnGetData();
    //        if (objDataSet != null)
    //        {
    //            if (objDataSet.Tables[0].Rows.Count > 0)
    //            {
    //                //ddlFlightType
    //                ddlDomestic.DataSource = objDataSet.Tables[0];
    //                ddlDomestic.DataValueField = "FlightsId";
    //                ddlDomestic.DataTextField = "FlightsName";
    //                ddlDomestic.DataBind();

    //                ddlDomestic.Items.Insert(0, "--Select--");
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //    }



    //}
    //private void BindInterNationalFlights()
    //{
    //    try
    //    {
    //        objBal = new Class1();
    //        objBal.ScreenInd = Master123.GetInterNationalFlights;

    //        objDataSet = (DataSet)objBal.fnGetData();
    //        if (objDataSet != null)
    //        {
    //            if (objDataSet.Tables[0].Rows.Count > 0)
    //            {
    //                //ddlFlightType
    //                ddlInterNational.DataSource = objDataSet.Tables[0];
    //                ddlInterNational.DataValueField = "FlightsId";
    //                ddlInterNational.DataTextField = "FlightsName";
    //                ddlInterNational.DataBind();

    //                ddlInterNational.Items.Insert(0, "--Select--");
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //    }


    //}






    //protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddltype.SelectedItem.Value == "Flights")
    //    {
    //        flights.Visible = true;
    //        Buses.Visible = false;
    //        Amount.Visible = true;
    //        Percentage.Visible = true; 
            

    //    }
    //    else if (ddltype.SelectedItem.Value == "Bus")
    //    {
    //        Buses.Visible = true;
    //        flights.Visible = false;
    //        InterNationalFlights.Visible = false;
    //        DomesticFlights.Visible = false;
    //        Amount.Visible = false;
    //        Percentage.Visible = true;

    //    }
    //    else if (ddltype.SelectedItem.Value == "Hotels")
    //    {
    //        Buses.Visible = false;
    //        Percentage.Visible = false;
    //        Amount.Visible =true ;
    //    }
    //    else
    //    {
    //        Buses.Visible = false;
    //        flights.Visible = false;
    //    }
    //}
    //protected void ddlFlightType_SelectedIndexChanged(object sender, EventArgs e)
    //  {
    //      if (ddlFlightType.SelectedItem.Value == "Domestic")
    //    {

    //        DomesticFlights.Visible = true;
    //        InterNationalFlights.Visible = false;
    //    }
    //      else if (ddlFlightType.SelectedItem.Value == "International")
    //    {

    //        InterNationalFlights.Visible = true;
    //        DomesticFlights.Visible = false;
    //    }
    //    else
    //    {
    //        Buses.Visible = false;
    //    }
       

    //}
    protected void btnAdd_Click(object sender, EventArgs e)
     {
        try
        {
            objBal = new Class1();
            objBal.ScreenInd = Master123.InsertAgentMarkUp;

            //if (ddltype.SelectedValue == "Bus")
            //{
            //    objBal.Type = ddltype.SelectedItem.Text;
            //   // objBal.subType = ddlBusesTypes.SelectedItem.Text;
            //    objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text); 
            //}
            //else if (ddltype.SelectedValue== "Hotels") 
            //{
            //    objBal.Type = ddltype.SelectedItem.Text;
            //    objBal.MarkupAmount = txtAmount.Text;
            //}
          
            //else if (ddltype.SelectedValue=="Flights")
            //{
            //    if (ddlFlightType.SelectedValue == "Domestic")
            //    {
            //        objBal.Type = ddltype.SelectedItem.Text;
            //        objBal.subType = ddlFlightType.SelectedItem.Text;
            //        objBal.FlightName = ddlDomestic.SelectedItem.Text;
            //        objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text);
            //        objBal.MarkupAmount = txtAmount.Text;

            //    }
            //    else
            //    {
            //        objBal.FlightName = ddlInterNational.SelectedItem.Text;
            //        objBal.Type = ddltype.SelectedItem.Text;
            //        objBal.subType = ddlFlightType.SelectedItem.Text;
            //        objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text);
            //        objBal.MarkupAmount = txtAmount.Text;
            //    }

            //}
            //else
            //{

            //    lblType1.Text = "please select the Type";
            //}
            
             objBal.Type = ddltype.SelectedItem.Text;
           objBal.MarkupAmount = txtAmount.Text;

            int id = Convert.ToInt32(Session["UserID"]);
            int Agentid=Convert.ToInt32(Session["UserId"]);
            objBal.Agentid = Agentid;
           
            objBal.id = id;
            if (objBal.fnInsertRecord() == true)
            {
               // flights.Visible = false;
                txtAmount.Text = "";
                //txtPercentage.Text = "";
               // ddlFlightType.ClearSelection();
              //  ddlDomestic.ClearSelection();
              //  ddlInterNational.ClearSelection();
                BindMarkUp();

            }
            else
            {
                lblmsg.Text = "You have alredy entered your details";
            }
            

        }
         catch (Exception ex)
        {

        }
             

    }

    private void BindMarkUp()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetAgentMarkup;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvMarkUp.DataSource = objDataSet.Tables[0];
                    gvMarkUp.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
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
            Label Type = (Label)row.FindControl("lblType");
            Label lblMarkupAmount = (Label)row.FindControl("lblMarkupAmount");
            Label lblMarkupPercentage = (Label)row.FindControl("lblMarkupPercentage");
            
            txtAmount.Text = lblMarkupAmount.Text;
            //txtPercentage.Text = lblMarkupPercentage.Text;
            //flights.Visible = false;
            //DomesticFlights.Visible = false;
            //InterNationalFlights.Visible = false;
            //Buses.Visible = false;
            
           // txtNotices.Text = lblHotelName.Text;
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
            Label Type  = (Label)row1.FindControl("lblType");
            Label lblMarkupAmount = (Label)row1.FindControl("lblMarkupAmount");
            Label lblMarkupPercentage = (Label)row1.FindControl("lblMarkupPercentage");
            
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
            //if (ddltype.SelectedValue == "Bus")
            //{
            //    objBal.Type = ddltype.SelectedItem.Text;
            //    objBal.subType = ddlBusesTypes.SelectedItem.Text;
            //    objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text);
            //}
            //else if (ddltype.SelectedValue == "Hotels")
            //{
            //    objBal.Type = ddltype.SelectedItem.Text;
            //    objBal.MarkupAmount = txtAmount.Text;
            //}

            //else if (ddltype.SelectedValue == "Flights")
            //{
            //    if (ddlFlightType.SelectedValue == "Domestic")
            //    {
            //        objBal.Type = ddltype.SelectedItem.Text;
            //        objBal.subType = ddlFlightType.SelectedItem.Text;
            //        objBal.FlightName = ddlDomestic.SelectedItem.Text;
            //        objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text);
            //        objBal.MarkupAmount = txtAmount.Text;

            //    }
            //    else
            //    {
            //        objBal.FlightName = ddlInterNational.SelectedItem.Text;
            //        objBal.Type = ddltype.SelectedItem.Text;
            //        objBal.subType = ddlFlightType.SelectedItem.Text;
            //        objBal.Percentage1 = Convert.ToInt32(txtPercentage.Text);
            //        objBal.MarkupAmount = txtAmount.Text;
            //    }

            //}
           // objBal.MarkupAmount = txtAmount.Text;
            //objBal.MarkupPercentage = txtPercentage.Text;
            //else
            //{

            //    lblType1.Text = "please select the Type";
            //}



            objBal.Type = ddltype.SelectedItem.Text;
            objBal.MarkupAmount = txtAmount.Text;
            if (objBal.fnUpdateRecord() == true)
            {
                //flights.Visible = false;
                txtAmount.Text = "";
                //txtPercentage.Text = "";
                //ddlFlightType.ClearSelection();
                //ddlDomestic.ClearSelection();
                //ddlInterNational.ClearSelection();
                BindMarkUp();

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
}
   

      

        
