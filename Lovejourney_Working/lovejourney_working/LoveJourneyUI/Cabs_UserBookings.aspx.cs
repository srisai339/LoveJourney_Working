using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Cabs_UserBookings : System.Web.UI.Page
{
    ClsCommands objResult = new ClsCommands();
    DataSet _objDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataCarResult();
        }
    }
    private void BindDataCarResult()
    {
        try
        {
            objResult.ScreenInd = blossom.GetUserTicketDetaisl;

            _objDataSet = (DataSet)objResult.fnGetData();
            gvBookings.DataSource = _objDataSet;
            ViewState["Data"] = _objDataSet;
            gvBookings.DataBind();
            gvBookings.EmptyDataText = "No Bookings  Found";
        }
        catch (Exception)
        {

            throw;
        }
    }
}