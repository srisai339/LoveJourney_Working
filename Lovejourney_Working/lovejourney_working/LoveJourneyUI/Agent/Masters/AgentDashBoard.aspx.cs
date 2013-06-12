using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using HotelAPILayer;
using System.IO;
using System.Text;
using System.Web.Services;
using FilghtsAPILayer;
using BusAPILayer;
using System.Xml;
using System.Net;
using System.Data.OleDb;



public partial class Agent_Masters_AgentDashBoard : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    Class1 objBal;
    DataSet objDataset;
    DataTable _ObjDataTable;
    StringBuilder str = new StringBuilder();
    #region BusGlobalVariables
    ClsBAL objBAL;
    DataSet objDataSet;
    KesineniDetails kesineniDetails;
    AbhiBusDetails abhiBusDetails;
    BitlaDetails bitlaDetails;
    KABCommon objCommon;
    #endregion
    #region DomesticFlightsGlobalVariable

    FlightsAPILayer objFlights = new FlightsAPILayer();
    static DataSet dsFilghts = null;
    static DataSet dsIntFlights = null;
    static int adultcnt = 0;
    static int childCnt = 0;
    static int infantCnt = 0;
    static int adultCntInt = 0;
    static int childCntInt = 0;
    static int infantCntInt = 0;
    static string transId = "";



    #endregion
    DataTable dtNewFlightSegmentOnward = new DataTable();
    DataTable dtNewFlightSegmentReturn = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }

        BindNotices();
        BindRemainder();
        if (!IsPostBack)
        {
            lblagentname.Text =" Welcome " + " "+ Session["UserName"].ToString();
            Panel pnl = (Panel)this.Master.FindControl("Menu1");
            pnl.Visible = false;

        }

    }

    #region AgentDashBoard
    
    private void BindNotices()
    {
        try
        {
            objBal = new Class1();
            objDataSet = new DataSet();

            objBal.ScreenInd = Master123.GetAdminNotice;
            objDataSet = (DataSet)objBal.fnGetData();
            if (objDataSet.Tables[0] != null)
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {


                    //gvRemainders.Visible = false;
                    gvNotices.DataSource = objDataSet.Tables[0];
                    gvNotices.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void BindRemainder()
    {
        try
        {
            objBal = new Class1();
            objDataset = new DataSet();

            objBal.ScreenInd = Master123.GetRemainder;
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
  
    protected void lbtnRemainder_Click(object sender, EventArgs e)
    {
        Response.Redirect("RemaindersMasters.aspx?id=1");
    }
   
    #endregion


}