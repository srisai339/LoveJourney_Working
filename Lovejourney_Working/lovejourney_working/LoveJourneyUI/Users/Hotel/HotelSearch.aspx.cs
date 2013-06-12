using System;
using System.Data;
using HotelAPILayer;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BAL;


public partial class Agent_Hotel_HotelSearch : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;
    clsMasters _objMasters;
    DataSet _objDataSet;
    static string val = "false";
    ClsBAL objManabusBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); return; }
        getservices();
        if (val != "true")
        {
            objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
            objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
            objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
            objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
            objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
            objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
            this.Page.Title = "LoveJourney - Hotel - Search";
            {
                if (Session["UserID"] != null && Session["Role"] != null)
                {
                    if (Session["UserID"].ToString() != "INVALID USER"
                        && (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE"))
                    {
                        if (Session["UserName"] != null)
                        {
                            showmenus();
                            lblUsername.Text = "Welcome <b>" + Session["UserName"].ToString() + "</b>";
                        }
                    }
                    else if (Session["Role"].ToString() == "User")
                    {
                        showmenus();
                        lblUsername.Text = "Welcome " + Session["UserName"].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }

                CheckPermission("Book Hotel Ticket", Session["Role"].ToString());
            }
        }
        else
        {
            tdmsg.Visible = true;
            lblMainMsg.Text = "This Service is temporarily unavaliable";
            lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
            pnlMain.Visible = false;
        }
    }

    protected void showmenus()
    {
        if (Session["Role"].ToString() == "Admin" || Session["Role"].ToString() == "CSE")
        {
            lidashboard.Visible = true;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = true;
            liagents.Visible = true;
            lipromocode.Visible = true;
            lifeedback.Visible = true;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenuprint.Visible = true;
            lisubmenucancel.Visible = true;
            lisubmenureports.Visible = true;
            lisubmenuAgentReports.Visible = true;
            liReports1.Visible = true;
            liuserinfo.Visible = true;
            Cashcoupon.Visible = true;
        }
        else if (Session["Role"].ToString() == "User")
        {
            lidashboard.Visible = false;
            libuses.Visible = true;
            liflights.Visible = true;
            lihotels.Visible = true;
            lirecharge.Visible = true;
            licse.Visible = false;
            liagents.Visible = false;
            lipromocode.Visible = false;
            lifeedback.Visible = false;
            lichangepassword.Visible = true;
            lisubmenuBooking.Visible = true;
            lisubmenuprint.Visible = true;
            lisubmenucancel.Visible = true;
            lisubmenureports.Visible = false;
            lisubmenuAgentReports.Visible = false;
            liReports1.Visible = false;
            li1.Visible = false;
            liuserinfo.Visible = false;
            utilities.Visible = true;
            movietickets.Visible = true;
            FeedBack.Visible = true;
            Cashcoupon.Visible = false;
        }
    }
    protected void getservices()
    {
        try
        {
            val = "false";
            _objMasters = new clsMasters();
            _objMasters.ScreenInd = Masters.Getservices;
            _objDataSet = (DataSet)_objMasters.fnGetData();
            if (_objDataSet != null)
            {
                if (_objDataSet.Tables.Count > 0)
                {
                    if (_objDataSet.Tables[0].Rows.Count > 0)
                    {
                        int i;
                        for (i = 0; i < _objDataSet.Tables[0].Rows.Count; i++)
                        {
                            if (_objDataSet.Tables[0].Rows[i]["Services"].ToString() == "Hotels" && _objDataSet.Tables[0].Rows[i]["Status"].ToString() == "1")
                            {
                                val = "true";
                            }
                        }

                    }
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void CheckPermission(string pageName, string role)
    {
        try
        {
            pnlMain.Visible = true;
            tdmsg.Visible = false;
            if (role == "CSE")
            {
                tdmsg.Visible = true;
                tdmsg.Style.Add("background-color:#E77471;", "");
                lblMainMsg.Text = "   No permission to this page. Please contact Administrator for further details.";
                lblMainMsg.ForeColor = System.Drawing.Color.Maroon;
                pnlMain.Visible = false;

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
                            pnlMain.Visible = true;
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


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["SearchParams"] = hdnValues.Value;
            Response.Redirect("Hotels.aspx", false);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    public static string ConvertDate1(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }
    protected void Menu2_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "LogOut")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void Menu3_MenuItemClick(object sender, System.Web.UI.WebControls.MenuEventArgs e)
    {
        if (e.Item.Text == "LogOut")
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    Session["UserID"] = null;
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void lbtnlogout_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
                Session.Abandon();
                Response.Redirect("~/Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            objManabusBAL = new ClsBAL();
            objManabusBAL.name = txtName.Text;
            objManabusBAL.emailId = txtEmail.Text;
            objManabusBAL.mobileNo = txtPhone.Text;
            objManabusBAL.comments = txtComments.Text;
            if (objManabusBAL.AddFeedback())
            {

                lblmsg.Text = "Feedback submitted successfully to admin. Thanks for your feedback.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                txtName.Text = txtEmail.Text = txtPhone.Text = txtComments.Text = "";
            }
            else
            {
                lblmsg.Text = "Failed to send feedback. Please find try again.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        catch (Exception ex)
        {
            throw ex;
        }
    }
}