using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BAL;

public partial class Agent_Masters_CheckBalance : System.Web.UI.Page
{
    Class1 objBal;
    DataSet objDataset;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;
            BindCheckBalance();
          
        }
    }
    private void BindCheckBalance()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();
            //int id = Convert.ToInt32(Session["UserID"]);
           // int id = Convert.ToInt32(Session["Role"]);
            objBal.id = 4;

            objBal.ScreenInd = Master123.GetCheckBalance;
            objDataset = (DataSet)objBal.fnGetData();
            if (objDataset.Tables[0] != null)
            {
                if (objDataset.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;

                    gvRemainders.DataSource = objDataset.Tables[0];
                    gvRemainders.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAvailabilityBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentDashBoard.aspx");
    }
}