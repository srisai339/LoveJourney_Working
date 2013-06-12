using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;

public partial class Users_Flight_UserReports : System.Web.UI.Page
{
    FlightBAL objFlightBal = new FlightBAL();
    DataSet dsFlight;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = GetAgents();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlagent1.DataSource = ds;
                    ddlagent1.DataTextField = "Username";
                    ddlagent1.DataValueField = "ID";
                    ddlagent1.DataBind();

                    ddlagent1.Items.Insert(0, "-Please Select-");
                }

            }

        }

    }
    DataSet GetAgents()
    {
        try
        {
            ClsBAL objbal = new ClsBAL();
            return objbal.GetAgents();
        }
        catch (Exception ex)
        {
            // lblMsg.InnerHtml = ex.Message;
            throw;
        }
    }
    protected void rdlflights_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            source3.Visible = true;
            Button1_Click(sender, e);
            if (rdlflights.SelectedItem.Text == "Domestic Flights")
            {
                IF.Visible = false;
                Domestic.Visible = true;

                objFlightBal.FlightName = "DomesticUser";
                ViewState["Flight"] = "DomesticUser";

            }
            else if (rdlflights.SelectedItem.Text == "International Flights")
            {
                IF.Visible = true;
                Domestic.Visible = false;
                objFlightBal.FlightName = "IFUser";
                ViewState["Flight"] = "IFUser";
            }
            objFlightBal.CreatedBy = Convert.ToInt32(Session["UserID"]);
            dsFlight = objFlightBal.GetAgentFlights(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                }
                else
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    double actualfare;
    double commission;
    double scharge;
    double discount;
    double Charge;
    double markup;
    double refund;
    double ccharge;
    double closebal;
    protected void GvFlightsReports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDepartureDateTime = (Label)e.Row.FindControl("lblDepartureDateTime");
                if (lblDepartureDateTime.Text.Contains('T'))
                {
                    string[] s = lblDepartureDateTime.Text.Split('T');
                    DateTime dt = Convert.ToDateTime(s[0].ToString());
                    lblDepartureDateTime.Text = dt.ToString("dd-MM-yyyy");
                }
                Label lblArrivalAirportName = (Label)e.Row.FindControl("lblArrivalAirportName");

                actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                commission += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TPartnerCommission"));
                scharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Scharge"));
                discount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDiscount"));
                Charge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TCharge"));
                markup += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TMarkUp"));

                refund += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RefundAmount"));
                ccharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));
                closebal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ClosingBalance"));

                Label lblCustomerDetails = (Label)e.Row.FindControl("lblCustomerDetails");
                if (lblCustomerDetails.Text != "")
                {
                    string[] strCusDet = lblCustomerDetails.Text.Split('|');
                    lblCustomerDetails.Text = strCusDet[0] + " " + strCusDet[1] + " " + strCusDet[2];
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {


                Label lblcharge = (Label)e.Row.FindControl("lblcharge");
                lblcharge.Text = Charge.ToString("####0.00");

                Label lblcomm = (Label)e.Row.FindControl("lblcomm");
                lblcomm.Text = commission.ToString("####0.00");
                Label lbldiscount = (Label)e.Row.FindControl("lbldiscount");
                lbldiscount.Text = discount.ToString("####0.00");
                Label lblScharge = (Label)e.Row.FindControl("lblScharge");
                lblScharge.Text = scharge.ToString("####0.00");
                Label lblactulafare = (Label)e.Row.FindControl("lblactulafare");
                lblactulafare.Text = actualfare.ToString("####0.00");
                Label lblmarkup = (Label)e.Row.FindControl("lblmarkup");
                lblmarkup.Text = markup.ToString("####0.00");


                Label lblRefundAmount1 = (Label)e.Row.FindControl("lblRefundAmount1");
                lblRefundAmount1.Text = refund.ToString("####0.00");
                Label lblCancellationCharges1 = (Label)e.Row.FindControl("lblCancellationCharges1");
                lblCancellationCharges1.Text = ccharge.ToString("####0.00");
                Label lblClosingBalance1 = (Label)e.Row.FindControl("lblClosingBalance1");
                lblClosingBalance1.Text = closebal.ToString("####0.00");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    int AgentId;
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtname.Text != "")
            {
                ListItem value = ddlagent1.Items.FindByText(txtname.Text.ToString());
                if (value != null)
                {
                    ddlagent1.SelectedItem.Value = value.Value;
                    AgentId = Convert.ToInt32(ddlagent1.SelectedValue);
                }
                else
                {
                    AgentId = -1;
                }

            }
            if (ViewState["Flight"].ToString() == "DomesticUser")
            {
                objFlightBal.FlightName = "DomesticUser";
                if (ddlsource.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Source = ddlsource.SelectedValue;
                }
                if (ddldestinations.SelectedItem.Text != "Please Select")
                {
                    objFlightBal.Destinations = ddldestinations.SelectedValue;
                }
            }
            else if (ViewState["Flight"].ToString() == "IFUser")
            {
                objFlightBal.FlightName = "IFUser";
                objFlightBal.Source = txtFrom.Text.Trim();
                objFlightBal.Destinations = txtTo.Text.Trim();
            }


            if (txtfromdate.Text != "")
            {
                objFlightBal.DateOfJourney = Convert.ToDateTime(txtfromdate.Text);
            }
            else
            {
                objFlightBal.DateOfJourney = null;
            }
            if (txttodate.Text != "")
            {
                objFlightBal.DateOfIssue = Convert.ToDateTime(txttodate.Text);
            }
            else
            {
                objFlightBal.DateOfIssue = null;
            }
            objFlightBal.Name = txtname.Text.Trim();
            objFlightBal.EmailId = txtemailId.Text.Trim();
            objFlightBal.RefNo = txtrefno.Text.Trim();
            // objFlightBal.Operator = ddloperator.SelectedValue;
            objFlightBal.ContactNo = txtcontactno.Text.Trim();
            objFlightBal.Status = ddlstatus.SelectedValue;
            // objFlightBal.PageSize = ddlpagesize.SelectedValue;
            objFlightBal.TableName = "SearchUser";
            objFlightBal.CreatedBy = AgentId;
            dsFlight = objFlightBal.GetAgentFlightSearch(objFlightBal);
            if (dsFlight != null)
            {
                if (dsFlight.Tables[0].Rows.Count > 0)
                {

                    GvFlightsReports.PageSize = Convert.ToInt32(ddlpagesize.SelectedValue);

                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();

                }
                else
                {
                    GvFlightsReports.DataSource = dsFlight;
                    Session["GvReports"] = dsFlight.Tables[0];
                    GvFlightsReports.DataBind();
                }
            }


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ddldestinations.ClearSelection();
        ddlpagesize.ClearSelection();
        ddlsource.ClearSelection();
        ddlstatus.ClearSelection();
        txtcontactno.Text = "";
        txtdate.Text = "";
        txtemailId.Text = "";
        txtname.Text = "";
        txtrefno.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = "";
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string[] GetAirportCodes(string prefixText)
    {
        try
        {

            //string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=F:\\LoveJourney\\LoveJourneyCode\\LoveJourneyUI\\DOCS\\International_AirportCodes.xlsx;Extended Properties=Excel 12.0;HDR=YES;IMEX=1";

            string connstr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\21082012 Onwards\\Test1\\DOCS\\International_AirportCodes.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES""");
            OleDbConnection conn = new OleDbConnection(connstr);
            string strSQL = "SELECT * FROM [Sheet1$]";


            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            string filteringquery = "CityName_ LIKE'" + prefixText + "%'";
            //Select always return array,thats why we store it into array of Datarow
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            //create new table
            DataTable dtNew = new DataTable();
            //create a clone of datatable dt and store it into new datatable
            dtNew = ds.Tables[0].Clone();
            //fetching all filtered rows add add into new datatable
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }
            //return dtAirportCodes;

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["CityName_"].ToString() + "," + dtNew.Rows[i]["AirportDesc_"].ToString() + " - (" + dtNew.Rows[i]["AirportCode_"].ToString() + ")");
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    private void SortGridView(string sortExpression, string direction)
    {
        //  You can cache the DataTable for improving performance
        DataTable dt = ((DataTable)Session["GvReports"]);
        //GetData().Tables[0];
        DataView dv = new DataView(dt);
        dv.Sort = sortExpression + direction;

        GvFlightsReports.DataSource = dv;
        GvFlightsReports.DataBind();

    }
    protected void GvFlightsReports_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            string sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GvFlightsReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvFlightsReports.PageIndex = e.NewPageIndex;
            if (Session["GvReports"] != null)
            {
                GvFlightsReports.DataSource = Session["GvReports"];
                GvFlightsReports.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]

    public static string[] GetAgentNames(string prefixText)
    {
        try
        {


            DataSet ds = new DataSet();

            ClsBAL objBal = new ClsBAL();
            ds = objBal.GetAgents();

            string filteringquery = "Username LIKE'" + prefixText + "%'";
            //Select always return array,thats why we store it into array of Datarow
            DataRow[] dr = ds.Tables[0].Select(filteringquery);
            //create new table
            DataTable dtNew = new DataTable();
            //create a clone of datatable dt and store it into new datatable
            dtNew = ds.Tables[0].Clone();
            //fetching all filtered rows add add into new datatable
            foreach (DataRow drNew in dr)
            {
                dtNew.ImportRow(drNew);
            }
            //return dtAirportCodes;

            List<string> airports = new List<string>();
            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                airports.Add(dtNew.Rows[i]["Username"].ToString().Trim());
            }
            return airports.ToArray();
        }
        catch (Exception)
        {
            throw;

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(GvFlightsReports);
            GvFlightsReports.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Tickets.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            GvFlightsReports.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(GvFlightsReports);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
            GvFlightsReports.Columns[13].Visible = true;
        }
        catch (Exception ex)
        {
            //lblMsg.InnerHtml = ex.Message;
            throw ex;
        }
    }
    private void ChangeControlsToValue(Control gridView)
    {
        Literal literal = new Literal();
        for (int i = 0; i < gridView.Controls.Count; i++)
        {
            if (gridView.Controls[i].GetType() == typeof(Button))
            {
                literal.Text = (gridView.Controls[i] as Button).Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(DropDownList))
            {
                literal.Text = (gridView.Controls[i] as DropDownList).SelectedItem.Text;
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            else if (gridView.Controls[i].GetType() == typeof(CheckBox))
            {
                literal.Text = (gridView.Controls[i] as CheckBox).Checked ? "True" : "False";
                gridView.Controls.Remove(gridView.Controls[i]);
                gridView.Controls.AddAt(i, literal);
            }
            if (gridView.Controls[i].HasControls())
            {
                ChangeControlsToValue(gridView.Controls[i]);
            }
        }
    }
}