using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Agent_Bus_AdminMarkUp : System.Web.UI.Page
{
    Class1 objBal;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new Class1();

            objBal.ScreenInd = Master123.InsertAdminMarkup;
            

            objBal.Percentage = txtMarkUpPercentage.Text; 
            objBal.Type = ddlType.SelectedValue;
           
            if (objBal.fnInsertRecord() == true)
            {
                lblStatus.Text = "You have sucessfully Inserted";
                txtMarkUpPercentage.Text = "";
                ddlType.ClearSelection();
            }
        }
        catch (Exception ex)
        {


        }

    }
}