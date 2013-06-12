using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Net.Mail;
public partial class Agent_Masters_AgentQueries : System.Web.UI.Page
{
    #region Declarations

    static string QueryID = "";
    static string ToID = "";
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb = new StringBuilder();
    string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
    static int ReceiveMsgsReadCnt = 0;
    //static int ReceiveMsgsUnReadCnt = 0;
    static int SendMsgs = 0;
    static string MType = "";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
     {
        try
        {
            if (Session["UserID"] != null && Session["UserID"] != "")
            {
                if (!Page.IsPostBack)
                {
                    Panel pnl = (Panel)this.Master.FindControl("Menu1");
                    pnl.Visible = false;
                    lbtnShowtTxtbox.Visible = true;
                    tbGrid.Visible = true;
                    lblMsg.Text = "";
                    //txtSolution.Visible = false;
                    btnSave.Visible = false;
                    tbMain.Visible = false;
                    lblError.Text = "Please enter your Message";
                    string content;
                    content = "";
                    content = content + "---From " + Session["UserName"].ToString() + "---";
                    Session["sb"] = content.Length;
                    txtSolution.Text = content;
                }
                DataTable dtAdminQueries = new DataTable();
                dtAdminQueries = ClsMessaging.LoadAssociateOtherQueries(Session["UserID"].ToString());
                ViewState["dtQueries"] = dtAdminQueries;
                grddetails.DataSource = dtAdminQueries;
                grddetails.DataBind();

                if (Request.QueryString["Flag"] != null && Request.QueryString["Flag"] != "")
                {
                    if (Request.QueryString["Flag"].ToString() == "NewMsgs")
                        lnkMessages.Visible = false;
                    else
                    {
                        //DataTable dtAssoNewQueries = new DataTable();
                        //dtAssoNewQueries = ClsMessaging.LoadAssociateNewQueries(Session["UserID"].ToString());
                        //if (dtAssoNewQueries.Rows.Count > 0)
                        //{
                        //    lnkMessages.Visible = true;
                        //    lnkMessages.Text = "You have " + dtAdminQueries.Rows.Count + " new Message(s)";
                        //}
                        //dtAssoNewQueries.Dispose();
                    }
                }
                //else
                //    Response.Redirect("index.aspx");
            }
            else
                Response.Redirect("AgentDashBoard.aspx");
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    #region ControlEvents

    protected void grddetails_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in grddetails.Rows)
        {
            if (gvr.Cells[6].Text == "1")
            {
                gvr.Font.Bold = true;
                gvr.ForeColor = System.Drawing.Color.Brown;
                for (int i = 0; i < gvr.Cells.Count; i++)
                    gvr.Cells[i].ForeColor = System.Drawing.Color.Brown;
                //ReceiveMsgsUnReadCnt += 1;
                //gvr.BackColor = System.Drawing.Color.AliceBlue;
            }
            else
            {
                for (int i = 0; i < gvr.Cells.Count; i++)
                    gvr.Cells[i].ForeColor = System.Drawing.Color.Gray;
                ReceiveMsgsReadCnt += 1;
            }
        }
        //if (e.Row.Cells[7].Text == "1")
        //    e.Row.Font.Bold = true;
    }

    protected void grddetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
           
            lblError.Text = "";
            lbtnShowtTxtbox.Visible = true;
            if (grddetails.Rows.Count > 0 && e.CommandName != "Page")
            {
                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(ConnectionString);
                // SqlCommand command = new SqlCommand("SELECT Membership.ReceiveMsgs, Membership.SendMsgs, Membership.Type FROM [Tbl_Users] INNER JOIN Membership ON [Tbl_Users].Status = Membership.Id WHERE [Tbl_Users].Status = " + Session["UserID"].ToString(), connection);
                SqlCommand command = new SqlCommand("SELECT Membership.ReceiveMsgs, Membership.SendMsgs, Membership.Type FROM [Tbl_Users] INNER JOIN Membership ON [Tbl_Users].Status = Membership.Id WHERE [Tbl_Users].Id =  " + Session["UserID"].ToString(), connection);


                SqlDataAdapter ada = new SqlDataAdapter(command);
                ada.Fill(dt);

                if (e.CommandName == "Update")
                {
                    //code to restrict user to see message body                   
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["SendMsgs"] != "")
                            SendMsgs = Convert.ToInt32(dt.Rows[0]["SendMsgs"].ToString());
                        if (dt.Rows[0]["Type"] != "")
                            MType = dt.Rows[0]["Type"].ToString();
                        if (dt.Rows[0]["ReceiveMsgs"] != "")
                        {
                            if (ReceiveMsgsReadCnt <= Convert.ToInt32(dt.Rows[0]["ReceiveMsgs"].ToString()) || grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString() == "1")
                            {
                                for (int i = 0; i < grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells.Count; i++)
                                    grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[i].ForeColor = System.Drawing.Color.Gray;

                                grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold = false;
                                QueryID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text.ToString();
                                //ToID = ((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[3].FindControl("Label3"))).Text.ToString();
                                ToID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString();
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine(((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].FindControl("Label2"))).Text.ToString());
                                //sb.AppendLine("---From " + Session["FullName"].ToString() + "---");
                                sb.AppendLine(" " + Session["UserName"].ToString() + " says, ");
                                txtSolution.Text = sb.ToString();
                                txtSolution.Visible = true;
                                btnSave.Visible = true;
                                txtSolution.ReadOnly = false;
                                txtSolution.Focus();
                                SqlConnection conn = new SqlConnection(ConnectionString);
                                conn.Open();
                                SqlCommand comm = new SqlCommand("UPDATE tbl_AdminQueries SET Read_UnRead = '0' WHERE (QueryID = '" + grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text + "')", conn);
                                comm.ExecuteNonQuery();
                                conn.Close();
                                comm.Dispose();
                                conn.Dispose();

                                txtSolution.Visible = true;
                                tbMain.Visible = true;
                            }
                            else
                            {
                                if (grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold == false)
                                {
                                    for (int i = 0; i < grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells.Count; i++)
                                        grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[i].ForeColor = System.Drawing.Color.Gray;

                                    grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold = false;
                                    QueryID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text.ToString();
                                    //ToID = ((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[3].FindControl("Label3"))).Text.ToString();
                                    ToID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString();
                                    StringBuilder sb = new StringBuilder();
                                    sb.AppendLine(((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].FindControl("Label2"))).Text.ToString());
                                    //sb.AppendLine("---From " + Session["FullName"].ToString() + "---");
                                    sb.AppendLine(" " + Session["UserName"].ToString() + " says, ");
                                    txtSolution.Text = sb.ToString();
                                    txtSolution.Visible = true;
                                    btnSave.Visible = true;
                                    txtSolution.ReadOnly = false;
                                    txtSolution.Focus();
                                }
                                else
                                {
                                    tdTypeChk.InnerHtml = "You have exceeded your messages limit. As a " + dt.Rows[0]["Type"].ToString() +
                                        " user you can only send a maximum of " + dt.Rows[0]["ReceiveMsgs"].ToString() +
                                        " number of messages. Please upgrade your membership " +
                                        "<a href='Confirmation.aspx?Flag=MSEnroll'>here</a> to increase this limit.";
                                    mpeTypeCheck.Show();
                                    mpeTypeCheck.Focus();
                                }
                            }
                        }
                    }
                    //code to restrict user to see mesg body ends

                }

                if (e.CommandName == "View")
                {
                    //code to restrict user to see message body                   
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ReceiveMsgs"] != "")
                        {
                            if (ReceiveMsgsReadCnt <= Convert.ToInt32(dt.Rows[0]["ReceiveMsgs"].ToString()) || grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString() == "1")
                            {
                                for (int i = 0; i < grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells.Count; i++)
                                    grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[i].ForeColor = System.Drawing.Color.Gray;

                                grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold = false;
                                QueryID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text.ToString();
                                //ToID = ((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[3].FindControl("Label3"))).Text.ToString();
                                ToID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString();
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine(((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].FindControl("Label2"))).Text.ToString());
                                txtSolution.Text = sb.ToString();
                                txtSolution.ReadOnly = true;
                                txtSolution.Visible = true;
                                //txtSolution.Visible = true;                    
                                btnSave.Visible = false;
                                txtSolution.Focus();
                                SqlConnection conn = new SqlConnection(ConnectionString);
                                conn.Open();
                                SqlCommand comm = new SqlCommand("UPDATE tbl_AdminQueries SET Read_UnRead = '0' WHERE (QueryID = '" + grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text + "')", conn);
                                comm.ExecuteNonQuery();
                                conn.Close();
                                comm.Dispose();
                                conn.Dispose();

                                txtSolution.Visible = true;
                                tbMain.Visible = true;
                            }
                            else
                            {
                                if (grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold == false)
                                {
                                    for (int i = 0; i < grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells.Count; i++)
                                        grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[i].ForeColor = System.Drawing.Color.Gray;

                                    grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Font.Bold = false;
                                    QueryID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text.ToString();
                                    //ToID = ((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[3].FindControl("Label3"))).Text.ToString();
                                    ToID = grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text.ToString();
                                    StringBuilder sb = new StringBuilder();
                                    sb.AppendLine(((Label)(grddetails.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].FindControl("Label2"))).Text.ToString());
                                    txtSolution.Text = sb.ToString();
                                    txtSolution.ReadOnly = true;
                                    txtSolution.Visible = true;
                                    btnSave.Visible = false;
                                    tbMain.Visible = true;
                                    txtSolution.Focus();
                                }
                                else
                                {
                                    tdTypeChk.InnerHtml = "You have exceeded your messages limit. As a " + dt.Rows[0]["Type"].ToString() +
                                        " user you can only receive/read a maximum of " + dt.Rows[0]["ReceiveMsgs"].ToString() +
                                        " number of messages. Please upgrade to your membership " +
                                        "<a href='Confirmation.aspx?Flag=MSEnroll'>here</a> to increase this limit.";
                                    mpeTypeCheck.Show();
                                    mpeTypeCheck.Focus();
                                }
                            }
                        }
                    }
                    //code to restrict user to see mesg body ends                   
                }

            }
            ReceiveMsgsReadCnt = 0;
        }
        catch(Exception ex)
        {

        }
       

    }

    protected void grddetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = "";
        string sortOrder = "";

        DataView dvdetails = new DataView();
        DataTable dtdetails = new DataTable();

        if (ViewState["dtQueries"] != null)
        {
            dtdetails = (DataTable)ViewState["dtQueries"];
            dvdetails = dtdetails.DefaultView;
        }
        else
        {
            grddetails.DataSource = (DataTable)ViewState["dtQueries"];
            grddetails.DataBind();
            dvdetails = (DataView)ViewState["dtQueries"];
        }

        sortExpression = e.SortExpression;
        if (ViewState["SortExp"] != null && ViewState["SortExp"].ToString() == sortExpression)
            sortOrder = "DESC";
        else
            sortOrder = "ASC";

        ViewState["SortExp"] = sortExpression;
        dvdetails.Sort = sortExpression + " " + sortOrder;
        grddetails.DataSource = dvdetails;
        grddetails.DataBind();
        grddetails.Visible = true;
    }

    protected void grddetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grddetails.PageIndex = e.NewPageIndex;
            grddetails.DataSource = (DataTable)Session["dtAdminQueries"];
            grddetails.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void grddetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType.ToString() != "EmptyDataRow")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = ((Label)(e.Row.Cells[2].FindControl("Label1")));
                    string str = lbl.Text;
                    if (str.Length > 40)
                    {
                        lbl.Text = "";
                        lbl.Text = str.Substring(0, 40) + "....";
                    }
                }
                if (e.Row.RowType.ToString() != "Pager")
                {
                    e.Row.Cells[6].Visible = false;//make Read_UnRead column hidden
                    e.Row.Cells[7].Visible = false;//make ResponseSequence column hidden
                    e.Row.Cells[8].Visible = false;//make FromID column hidden
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void grddetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //donot delete this. its required
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    //code to restrict user to see message body
        //    if (SendMsgs == null || SendMsgs == 0)
        //    {
        //        DataTable dt = new DataTable();
        //        SqlConnection connection = new SqlConnection(ConnectionString);
        //        SqlCommand command = new SqlCommand("SELECT Membership.ReceiveMsgs, Membership.SendMsgs, Membership.Type FROM [User] INNER JOIN Membership ON [User].Type = Membership.Id WHERE [User].Id = " + Session["UserID"].ToString(), connection);
        //        SqlDataAdapter ada = new SqlDataAdapter(command);
        //        ada.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["SendMsgs"] != "")
        //                SendMsgs = Convert.ToInt32(dt.Rows[0]["SendMsgs"].ToString());
        //            MType = dt.Rows[0]["Type"].ToString();
        //        }
        //        dt.Clear();
        //        dt.Dispose();
        //        ada.Dispose();
        //        command.Dispose();
        //        connection.Dispose();
        //    }
        try
        {

            DataTable dt1 = new DataTable();
            SqlConnection connection1 = new SqlConnection(ConnectionString);
            SqlCommand command1 = new SqlCommand("SELECT COUNT(*) AS [SentMsgs] FROM tbl_adminqueries WHERE FromID = '" + Session["UserID"].ToString() + "'", connection1);
            SqlDataAdapter da = new SqlDataAdapter(command1);
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["SentMsgs"] != null && dt1.Rows[0]["SentMsgs"].ToString() != "")
                {
                    if (Convert.ToInt32(dt1.Rows[0]["SentMsgs"].ToString()) <= SendMsgs || ToID == "1")
                    {
                        lbtnShowtTxtbox.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Enabled = false;
                        tbMain.Visible = true;
                        lblError.Text = "";
                        txtSolution.Visible = false;
                        if (txtSolution.Text.Length == 0)
                        {
                            lblError.Text = "Please enter your Message";
                            return;
                        }
                        sb1.AppendLine(txtSolution.Text);
                        if (ToID == "1" || ToID == "")
                            ClsMessaging.SaveAssociateOtherQueries(QueryID, Session["UserID"].ToString(), Session["Role"].ToString(), sb1.ToString(), "1");
                        else
                            ClsMessaging.ReplyAssociateOtherQueries(QueryID, Session["UserID"].ToString(), Session["Role"].ToString(), sb1.ToString(), ToID);

                        lblMsg.Text = "Message Sent Successfully...";
                    }
                    else
                    {
                        tdTypeChk.InnerHtml = "You have exceeded your messages limit. As a " + MType +
                                    " user you can only send a maximum of " + SendMsgs.ToString() +
                                    " number of messages. Please upgrade to your membership " +
                                    "<a href='Confirmation.aspx?Flag=MSEnroll'>here</a> to increase this limit.";
                        mpeTypeCheck.Show();
                        mpeTypeCheck.Focus();
                    }
                }
            }
            else
            {
                //code to restrict user to see mesg body ends
                lbtnShowtTxtbox.Visible = true;
                btnSave.Visible = false;
                btnSave.Enabled = false;
                tbMain.Visible = true;
                lblError.Text = "";
                txtSolution.Visible = false;
                if (txtSolution.Text.Length == 0)
                {
                    lblError.Text = "Please enter your Message";
                    return;
                }
                sb1.AppendLine(txtSolution.Text);
                if (ToID == "1" || ToID == "")
                    ClsMessaging.SaveAssociateOtherQueries(QueryID, Session["UserID"].ToString(), Session["Role"].ToString(), sb1.ToString(), "1");
                else
                    ClsMessaging.ReplyAssociateOtherQueries(QueryID, Session["UserID"].ToString(), Session["Role"].ToString(), sb1.ToString(), ToID);

                lblMsg.Text = "Message Sent Successfully...";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lnkMessages_Click(object sender, EventArgs e)
    {
        tbGrid.Visible = true;
        txtSolution.Text = "";
        tbMain.Visible = false;
    }

    protected void lbtnShowtTxtbox_Click(object sender, EventArgs e)
    {
        lbtnShowtTxtbox.Visible = false;
        btnSave.Visible = true;
        btnSave.Enabled = true;
        tbMain.Visible = true;
        lblMsg.Text = "";
        lblError.Text = "Please enter your Message";
        string content;
        content = "";
        //content = content + "---From " + Session["FullName"].ToString() + "---";
        content = content + " " + Session["UserName"].ToString() + " says, ";
        Session["sb"] = content.Length;
        txtSolution.Text = content;
        txtSolution.Visible = true;
        txtSolution.ReadOnly = false;
        ToID = "1";
    }

    #endregion
    protected void lnkButtonBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgentDashBoard.aspx");
    }
} 