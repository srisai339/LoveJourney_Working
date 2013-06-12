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
using System.Globalization;

public partial class Cab_AgentBookins : System.Web.UI.Page
{
    ClsCommands objResult = new ClsCommands();
    DataSet _objDataSet;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE" || Session["Role"].ToString() == "User" || Session["Role"].ToString() == "Distributor" || Session["Role"].ToString() == "BSD" || Session["Role"].ToString() == "Employee")
            {

                this.MasterPageFile = "UserMasterPage.master";
            }
            else if (Session["Role"].ToString() == "Agent")
            {

                this.MasterPageFile = "AgentMasterPage.master";
            }

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserId"] != null)
            {
                if (Session["Role"].ToString() == "Admin")
                {
                   // BindDataCarResult();
                }
                else
                {
                   BindAgentcarResult();
                }
            }
        }
    }
    private void BindDataCarResult()
    {
        try
        {
            objResult.ScreenInd = blossom.GetAgentTicketDetaisl;

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
    private void BindAgentcarResult()
    {
        try
        {
            objResult.ScreenInd = blossom.GetIndividualAgentTicketDetaisl;
            objResult.AgentId = Session["UserId"].ToString();
            objResult.Role = Session["Role"].ToString();

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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ChangeControlsToValue(gvBookings);
           // gvBookings.Columns[13].Visible = false;
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=AgentBookings.xls");
            Response.ContentType = "application/excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
            HtmlForm hForm = new HtmlForm();
            gvBookings.Parent.Controls.Add(hForm);
            hForm.Attributes["runat"] = "server";
            hForm.Controls.Add(gvBookings);
            hForm.RenderControl(hTextWriter);
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=windows-1252\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>ExportToExcel</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>");
            sBuilder.Append(sWriter + "</body></html>");
            Response.Write(sBuilder.ToString());
            Response.End();
           // gvBookings.Columns[13].Visible = true;
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
    protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            string refno;
            refno = e.CommandArgument.ToString();
            pnlSearchResults.Visible = false;
            pnlSearch.Visible = false;
            pnlViewTicket.Visible = true;
            BindTicketDetails(refno);
        }

    }
    protected void gvBookings_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    private void BindTicketDetails(string refno)
    {

        FlightBAL objFlightsBAL = new FlightBAL();
        DataSet dsFlights = new DataSet();
        dsFlights = objFlightsBAL.GetCarDetaisl(refno, "");
        if (dsFlights.Tables[0].Rows.Count > 0)
        {

            //lblCarName.Text = dsFlights.Tables[0].Rows[1]["CarName"].ToString();
            lblCarRefNo.Text = dsFlights.Tables[0].Rows[0]["ReferanceId"].ToString();
            lblStatus.Text = dsFlights.Tables[0].Rows[0]["Status"].ToString();
            //if (dsFlights.Tables[0].Rows[0]["ReferenceNo"].ToString() == "1")
            //{
            //    lblStatus.Text ="Booked";
            //}

            lblAddress.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
            lblCity1.Text = dsFlights.Tables[0].Rows[0]["City_Car"].ToString();
            lblJourneyDate.Text = dsFlights.Tables[0].Rows[0]["TravelDate"].ToString();
            lblFirstName.Text = dsFlights.Tables[0].Rows[0]["Name"].ToString();
            lblMobileNo.Text = dsFlights.Tables[0].Rows[0]["MobileNo"].ToString();
            lblEmailId.Text = dsFlights.Tables[0].Rows[0]["EmailId"].ToString();
            lblAdd.Text = dsFlights.Tables[0].Rows[0]["Address"].ToString();
            lblCity.Text = dsFlights.Tables[0].Rows[0]["City"].ToString();
            lblPinCode.Text = dsFlights.Tables[0].Rows[0]["ZipCode"].ToString();
            lblState.Text = dsFlights.Tables[0].Rows[0]["State"].ToString();
            lblPickupTime.Text = dsFlights.Tables[0].Rows[0]["PickupTime"].ToString();
            lblCarName.Text = dsFlights.Tables[0].Rows[0]["CarName"].ToString();

        }
    }
    protected void lbtnMail_Click(object sender, EventArgs e)
    {
        string body = getHTML(pnlTicket);
        bool res = MailSender.SendEmail(lblEmailId.Text, "info@lovejourney.in", "info@lovejourney.in", "Ticket Details", body);
        // downlink.Visible = true;
        if (res)
        {
            tdmsg.Visible = true;
            lblMainMsg.Text = "Mail has been sent successfully";
            lblMainMsg.ForeColor = System.Drawing.Color.Green;

        }
        else
        {

            lblMainMsg.Text = "Failed to send Mail ";
            lblMainMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    private string getHTML(Panel Pnl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter textwriter = new StringWriter(sb);
        HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
        Pnl.RenderControl(htmlwriter);
        htmlwriter.Flush();
        textwriter.Flush();
        htmlwriter.Dispose();
        textwriter.Dispose();
        return sb.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
        /* -----------------------------------
         If you forget to write this method you will get an exception The server control must be placed inside a form tag with runat=”serve” 
            -------------------------------------------  */
    }
    protected void lbtnback_Click(object sender, EventArgs e)
    {
        pnlViewTicket.Visible = false;
        pnlSearchResults.Visible = false;
        pnlSearch.Visible = true;
    }
    double actualfare=0.0;
    protected void gvBookings_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            actualfare += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicFare"));
        }
        if(e.Row.RowType==DataControlRowType.Footer)
        {
            Label lblActualFareTotal = (Label)e.Row.FindControl("lblActualFareTotal");
            lblActualFareTotal.Text = actualfare.ToString("####0.00");

        }
    }
   
         protected void btnSearch_Click(object sender, EventArgs e)
    {
        FlightBAL objFlightBal = new FlightBAL();
        if (txtRefNo.Text != "")
        {
            objFlightBal.RefNo = txtRefNo.Text;
        }
        else
        {
            objFlightBal.RefNo = null;
        }
        if (txtfromdate.Text != "")
        {
            DateTime dt = DateTime.Parse(txtfromdate.Text, CultureInfo.GetCultureInfo("en-gb"));

            objFlightBal.DateOfJourney = Convert.ToDateTime(dt.ToShortDateString());
        }
        else
        {
            objFlightBal.DateOfJourney = null;
        }
        if (txttodate.Text != "")
        {
            DateTime dt = DateTime.Parse(txttodate.Text, CultureInfo.GetCultureInfo("en-gb"));

            objFlightBal.DateOfIssue= Convert.ToDateTime(dt.ToShortDateString());

        }
        else
        {
            objFlightBal.DateOfIssue = null;
        }
        if (txtName.Text != "")
        {
            objFlightBal.Name =txtName.Text;
        }
        else
        {
            objFlightBal.Name = null;
        }


        if (Session["Role"].ToString() == "Admin")
        {
            objFlightBal.TableName = "GetAgentBookings";
        }
        else
        {
            objFlightBal.TableName = "Individual Agent Bookings";
            objFlightBal.agentId = Convert.ToInt32(Session["UserId"]);
        }
        _objDataSet = objFlightBal.CarSearch(objFlightBal);
        if (_objDataSet != null)
        {
            if (_objDataSet.Tables[0].Rows.Count > 0)
            {

             

                gvBookings.DataSource = _objDataSet;
                Session["GvReports"] = _objDataSet.Tables[0];
                gvBookings.DataBind();

            }
        }
        else
        {
            gvBookings.EmptyDataText = "No Records found";
            
        }

       


    }
    
}