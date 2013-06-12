using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusAPILayer;
using BAL;
using System.Text;
using System.IO;

public partial class Agent_PrintTicket : System.Web.UI.Page
{
    ClsBAL objBAL;
    DataSet ObjDataset;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "LoveJourney - Bus - PrintTicket";
        if (Session["BusAgentStatus"] == null || Session["UserID"] == null || Session["Role"] == null) { Response.Redirect("~/Default.aspx", false); return; }


    }

    protected void GetCancellationPolicy(string travelname)
    {
        try
        {
            objBAL = new ClsBAL();
            if (travelname.Length >= 5)
            {
                objBAL.api = travelname.Substring(0, 5);
            }
            else { objBAL.api = travelname; }
            ObjDataset = (DataSet)objBAL.GetCancelPercentageByAPI();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables[0].Rows.Count > 0)
                {
                    gvCancellationDetails.DataSource = ObjDataset.Tables[0];
                    gvCancellationDetails.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (ObjDataset != null)
            {
                ObjDataset = null;
            }
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            objBAL = new ClsBAL();
            objBAL.manabusRefNo = txtMBRefNo.Text.Trim().ToString();
            ObjDataset = (DataSet)objBAL.GetTicketIdByOnewayManabusRefNo();
            if (ObjDataset != null)
            {
                if (ObjDataset.Tables.Count > 0)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        string travelName = ObjDataset.Tables[0].Rows[0]["TravelOPName"].ToString();
                        string api = ObjDataset.Tables[0].Rows[0]["APIName"].ToString();
                        gvView.DataSource = ObjDataset.Tables[0];
                        foreach (DataRow item in ObjDataset.Tables[0].Rows)
                        {
                            //item["Comment"] = Convert.ToDecimal(item["Comment"].ToString()).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            //item["TotalWithMarkPrice"] =
                            //    Convert.ToDecimal(
                            //    Convert.ToDecimal(item["Comment"].ToString())
                            //    +
                            //    Convert.ToDecimal(item["TotalFare"].ToString())
                            //    ).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
                            //    ;
                        }

                        GetCancellationPolicy(travelName);
                        if (api == "Kesineni")
                        {
                            
                        }
                        else {  }

                       

                        gvView.DataBind();
                        Panel1.Visible = false;
                        pnlViewticket.Visible = true;
                    }
                    else
                    {
                        lblMsg.Text = "Invalid Ref No";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        Panel1.Visible = true;
                        pnlViewticket.Visible = false;
                    }
                }
                else
                {
                    lblMsg.Text = "Invalid Ref No";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    Panel1.Visible = true;
                    pnlViewticket.Visible = false;
                }
            }
            else
            {
                lblMsg.Text = "Invalid Ref No";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                Panel1.Visible = true;
                pnlViewticket.Visible = false;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (ObjDataset != null)
            {
                ObjDataset = null;
            }
        }
    }

    protected void lbtnback_Click(object sender, EventArgs e)
    {
        try
        {
            txtMBRefNo.Text = "";
            Panel1.Visible = true;
            pnlViewticket.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
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

    protected void lbtnmail_Click1(object sender, EventArgs e)
    {
        try
        {
            GridView gvView = (GridView)pnlmail.FindControl("gvView");
            Label lblEmailID = (Label)gvView.Rows[0].FindControl("lblEmailID");
            if (lblEmailID != null)
            {
                string body = getHTML(pnlmail);
                bool res = Mailsender.SendEmail(lblEmailID.Text, "", "", "Ticket Details", body);
                if (res)
                {
                    lblMainMSg.Text = "Mail has been sent successfully";
                    lblMainMSg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMainMSg.Text = "Failed to send Mail ";
                    lblMainMSg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region Seats
                string finalseats = string.Empty;
                Label lblSeats = (Label)e.Row.FindControl("lblPassengerDetails");
                if (lblSeats != null && lblSeats.Text != "")
                {
                    string[] seats = lblSeats.Text.Split(',');
                    if (seats.Length > 0)
                    {
                        finalseats += "<table width='300px' border='1px Solid Black'  cellpadding='0' cellspacing='0'>";
                        finalseats += "<th width='100px' align='Center'>Seat</th><th align='Center' width='100px'>Name</th><th align='Center' width='100px'>Age</th>";
                        foreach (string item in seats)
                        {
                            string[] details = item.Split('-');
                            if (details.Length > 0)
                            {
                                finalseats += "<tr><td width='100px' align='Center'>";
                                finalseats += details[0] + "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[1] + " " + details[2] + "</p>";
                                finalseats += "</td>";
                                finalseats += "<td width='100px' align='Center' ><p> " + details[3] + "</p>";
                                finalseats += "</td></tr>";
                            }
                        }
                        finalseats += "</table>";
                        lblSeats.Text = finalseats;
                    }
                }
                #endregion

                #region Cancellation Details
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus.Text == "Cancelled")
                {
                    Panel pnlCancellationDetails = (Panel)e.Row.FindControl("pnlCancellationDetails");
                    pnlCancellationDetails.Visible = true;
                    Label lblCancelledBY = (Label)pnlCancellationDetails.FindControl("lblCancelledBY");
                    if (lblCancelledBY.Text == "")
                    {
                        lblCancelledBY.Text = "Online";
                    }
                }
                #endregion
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
}