using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;

public partial class Users_Bus_StopServices : System.Web.UI.Page
{
    #region Global Variables
    clsMasters _objmasters;
    DataSet ObjDataset;
   
    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnl = (Panel)this.Master.FindControl("pnl");
        pnl.Visible = false;
        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    tblmain.Visible = true;
                    getservices();
                }

                else
                {
                    tdmsg.Visible = true; tdmsg.Style.Add("background-color:#E77471;", ""); tblmain.Visible = false;
                    lblMainMsg.Text = "  No access permission to this page. Please contact the Administrator for further details. ";
                    CheckPermission("Stop Services", Session["Role"].ToString());
                    getservices();


                }
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
            tblmain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                tblmain.Visible = false;

                ClsBAL objBAL = new ClsBAL();
                objBAL.ID = Convert.ToInt32(Session["UserID"]);
                objBAL.screenName = pageName;
                DataSet objDataSet = (DataSet)objBAL.GetPerByUser();
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
                            tblmain.Visible = true;
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
    protected void btnSavePermissions_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvstopservices.Rows)
            {
                _objmasters = new clsMasters();
                Label lblScrnID = (Label)row.FindControl("lblScreenID");
                Label lblScrnName = (Label)row.FindControl("lblScreenName");
                CheckBox ChkAdd1 = (CheckBox)row.FindControl("ChkAdd");
                _objmasters.ScreenInd = Masters.Getservices;
                _objmasters.ID = Convert.ToInt32(lblScrnID.Text.Trim());
                if (ChkAdd1.Checked == true)
                {
                    _objmasters.Status = "1";
                }
                else
                {
                    _objmasters.Status = "0";
                }
                if (_objmasters.fnUpdateRecord() == true)
                {
                    lblmsg.Text = "Selected services Stopped succesfully";
                    lblmsg.Visible = true;
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void getservices()
    {
        try
        {
            _objmasters = new clsMasters();
            _objmasters.ScreenInd = Masters.Getservices;
            ObjDataset = (DataSet)_objmasters.fnGetData();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        gvstopservices.DataSource = ObjDataset.Tables[0];
                        ViewState["Services"] = ObjDataset.Tables[0];
                        gvstopservices.DataBind();
                      

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void gvstopservices_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblScreenID1 = (Label)e.Row.FindControl("lblScreenID");
            Label lblScreenName1 = (Label)e.Row.FindControl("lblScreenName");
            CheckBox ChkAdd1 = (CheckBox)e.Row.FindControl("ChkAdd");
            DataTable dt = (DataTable)ViewState["Services"];
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (lblScreenName1.Text == dt.Rows[i]["Services"].ToString() && dt.Rows[i]["Status"].ToString() == "1")
                {
                    ChkAdd1.Checked = true;
                }
            }
        }
    }
}