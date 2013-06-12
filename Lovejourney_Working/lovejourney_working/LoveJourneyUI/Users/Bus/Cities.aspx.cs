using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using BAL;
using BusAPILayer;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

public partial class Cities : System.Web.UI.Page
{
    ClsBAL objBal = null; int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Cities";
        if (!IsPostBack)
        {
            HttpContext.Current.Session["Cities"] = null;
            btnSubmit.Visible = false;
            DataSet ds = GetCitiesByLetter("A");
            gvCities.DataSource = ds;
            gvCities.DataBind();
        }
    }
    DataSet GetCitiesByLetter(string letter)
    {
        objBal = new ClsBAL();
        objBal.name = letter;
        return objBal.GetSourceswithprefix();
    }
    protected void ddlLetter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = GetCitiesByLetter(ddlLetter.SelectedItem.Text.ToString());
            gvCities.DataSource = ds;
            gvCities.DataBind();
            gv.Visible = false;
            btnSubmit.Visible = false;
            HttpContext.Current.Session["Cities"] = null;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void gvCities_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "TRUEorFALSE")
            {
                LinkButton lbtn = (LinkButton)e.CommandSource;
                string status = "";
                if (lbtn.ToolTip == "TRUE") { status = "FALSE"; } else { status = "TRUE"; }

                objBal = new ClsBAL();
                objBal.UpdateSourceStatus(status, e.CommandArgument.ToString());

                DataSet ds = GetCitiesByLetter(ddlLetter.SelectedItem.Text.ToString());
                gvCities.DataSource = ds;
                gvCities.DataBind();
            }
            else if (e.CommandName == "OriginalIDtoID")
            {
                LinkButton lbtn = (LinkButton)e.CommandSource;
                //string status = "";
                //if (lbtn.ToolTip == "TRUE") { status = "FALSE"; } else { status = "TRUE"; }

                objBal = new ClsBAL();
                objBal.UpdateSource(lbtn.ToolTip.ToString(), e.CommandArgument.ToString(), e.CommandArgument.ToString());

                DataSet ds = GetCitiesByLetter(ddlLetter.SelectedItem.Text.ToString());
                gvCities.DataSource = ds;
                gvCities.DataBind();
            }
            else if (e.CommandName == "SELECT")
            {
                LinkButton lbtn = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)lbtn.NamingContainer;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblOriginalID = (Label)row.FindControl("lblOriginalID");
                Label lblSourceName = (Label)row.FindControl("lblSourceName");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                LinkButton lbtnMakeIt = (LinkButton)row.FindControl("lbtnMakeIt");

                DataTable dtSources = null;

                if (HttpContext.Current.Session["Cities"] == null)
                {
                    dtSources = new DataTable();
                    dtSources.Columns.Add("ID");
                    dtSources.Columns.Add("OriginalID");
                    dtSources.Columns.Add("SourceName");
                    dtSources.Columns.Add("Status");

                    DataRow dr = dtSources.NewRow();
                    dr["ID"] = lblID.Text.ToString();
                    dr["OriginalID"] = lblOriginalID.Text.ToString();
                    dr["SourceName"] = lblSourceName.Text.ToString();
                    dr["Status"] = lblStatus.Text.ToString();

                    dtSources.Rows.Add(dr);

                    HttpContext.Current.Session["Cities"] = dtSources;
                }
                else
                {
                    dtSources = (DataTable)HttpContext.Current.Session["Cities"];
                    DataRow dr = dtSources.NewRow();
                    dr["ID"] = lblID.Text.ToString();
                    dr["OriginalID"] = lblOriginalID.Text.ToString();
                    dr["SourceName"] = lblSourceName.Text.ToString();
                    dr["Status"] = lblStatus.Text.ToString();

                    dtSources.Rows.Add(dr);

                    HttpContext.Current.Session["Cities"] = dtSources;
                }
                gv.Visible = true;
                gv.DataSource = dtSources;
                gv.DataBind();
                if (gv.Rows.Count > 1) { btnSubmit.Visible = true; } else { btnSubmit.Visible = false; }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void gvCities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus.Text == "FALSE") { lblStatus.ForeColor = System.Drawing.Color.Red; lblStatus.Font.Bold = true; }
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            i = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if (lblStatus.Text == "FALSE") { lblStatus.ForeColor = System.Drawing.Color.Red; lblStatus.Font.Bold = true; }
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddl");
            ddl.SelectedIndex = 1;
            if (i == 0) { ddl.SelectedIndex = 0; }
            i += 1;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objBal = new ClsBAL();

            string lblFirstOriginalId = "";
            string lblModifiedId = "";

            string Bit = "";
            string Tig = "";
            string Abh = "";
            string BitIds = "";
            string TigIds = "";
            string AbhIds = "";

            string[] lblIDs = new string[gv.Rows.Count];
            string[] lblOriginalIDs = new string[gv.Rows.Count];
            string[] lblSourceNames = new string[gv.Rows.Count];
            string[] lblStatuss = new string[gv.Rows.Count];

            foreach (GridViewRow row in gv.Rows)
            {
                Label lblID = (Label)row.FindControl("lblID");
                Label lblOriginalID = (Label)row.FindControl("lblOriginalID");
                Label lblSourceName = (Label)row.FindControl("lblSourceName");
                Label lblStatus = (Label)row.FindControl("lblStatus");

                lblIDs[row.RowIndex] = lblID.Text.ToString();
                lblOriginalIDs[row.RowIndex] = lblOriginalID.Text.ToString();
                lblSourceNames[row.RowIndex] = lblSourceName.Text.ToString();
                lblStatuss[row.RowIndex] = lblStatus.Text.ToString();

                if (row.RowIndex > 0)
                {
                    objBal.UpdateSource("FALSE", lblOriginalID.Text.ToString(), lblOriginalID.Text.ToString());
                }
                if (row.RowIndex == 0) { lblFirstOriginalId = lblOriginalID.Text.ToString(); }
            }

            foreach (string item in lblOriginalIDs)
            {
                foreach (string item1 in item.Split(':'))
                {
                    foreach (string item2 in item1.Split('-'))
                    {
                        if (item2 == "Bit")
                        {
                            Bit = item2 + "-"; if (BitIds == "")
                            { BitIds = item1.Split('-')[1].ToString(); }
                            else { BitIds = BitIds + "," + item1.Split('-')[1].ToString(); }
                        }

                        if (item2 == "Tig")
                        {
                            Tig = item2 + "-"; if (TigIds == "")
                            { TigIds = item1.Split('-')[1].ToString(); }
                            else { TigIds = TigIds + "," + item1.Split('-')[1].ToString(); }
                        }

                        if (item2 == "Abh")
                        {
                            Abh = item2 + "-"; if (AbhIds == "")
                            { AbhIds = item1.Split('-')[1].ToString(); }
                            else { AbhIds = AbhIds + "," + item1.Split('-')[1].ToString(); }
                        }
                    }
                }
            }

            lblModifiedId = Bit + BitIds + ":" + Tig + TigIds + ":" + Abh + AbhIds;

            objBal.UpdateSource("TRUE", lblFirstOriginalId, lblModifiedId);

            ddlLetter_SelectedIndexChanged(sender, e);
        }
        catch (Exception)
        {
            throw;
        }
    }
}