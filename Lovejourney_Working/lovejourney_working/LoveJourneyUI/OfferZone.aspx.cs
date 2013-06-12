using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using APRWorld;

public partial class OfferZone : clsBagePage
{
    #region Global Variables
    DataSet _objDataSet;
    clsMasters _objMasters;
    private bool includeGridLines;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.gettopcontent;
            //_objMasters.Content = "Hi";
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows[0]["Content"].ToString() != "")
                    {
                        lblContent.Text = _objDataSet.Tables[0].Rows[0]["Content"].ToString();
                    }
                    else
                    {
                        lblContent.Text = "There is no information";
                    }
                }
            }
        }

    }
}