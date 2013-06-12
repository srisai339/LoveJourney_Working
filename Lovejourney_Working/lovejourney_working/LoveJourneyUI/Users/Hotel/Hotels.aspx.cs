using System;
using System.Web.UI.WebControls;
using System.Data;
using HotelAPILayer;
using System.Web.UI.HtmlControls;
using System.Web.UI;

public partial class Agent_Hotel_Hotels : System.Web.UI.Page
{
    IArzooHotelAPILayer objArzooHotelAPILayer;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null) { Response.Redirect("~/Default.aspx", false); }

        try
        {
            objArzooHotelAPILayer = ArzooHotelFactoryManager.GetArzooHotelAPILayerObject();
            objArzooHotelAPILayer.UserName = ArzooHotelConstants.USERNAME;
            objArzooHotelAPILayer.UserId = ArzooHotelConstants.USERID;
            objArzooHotelAPILayer.UserType = ArzooHotelConstants.USERTYPE;
            objArzooHotelAPILayer.Password = ArzooHotelConstants.PASSWORD;
            objArzooHotelAPILayer.PartnerId = ArzooHotelConstants.PARTNERID;
            lblMsg.Text = ""; this.Page.Title = "LoveJourney - Hotel - SelectHotel";

            if (!IsPostBack)
            {
                ViewState["SortDirection"] = " ASC";
                ViewState["SortExpressionFilter"] = "";
                ViewState["SortDirectionFilter"] = "";

                if (Session["SearchParams"] != null)
                {
                    string[] strValues = Session["SearchParams"].ToString().Split(':');

                    string startDate = strValues[1].ToString();
                    string endDate = strValues[2].ToString();

                    int noOfRooms = Convert.ToInt32(strValues[3].ToString());

                    int[] noOfAdultsInARoom = new int[noOfRooms];
                    int[] noOfChildsInARoom = new int[noOfRooms];
                    int[] firstChildAge = new int[noOfRooms];
                    int[] secondChildAge = new int[noOfRooms];
                    int j = 0;
                    for (int i = 0; i < noOfRooms; i++)
                    {
                        if (i == 0)
                        {
                            j = 0;
                        }
                        else
                        {
                            j = 4 * i;
                        }

                        noOfAdultsInARoom[i] = Convert.ToInt32(strValues[4 + j].ToString());
                        noOfChildsInARoom[i] = Convert.ToInt32(strValues[5 + j].ToString());
                        firstChildAge[i] = Convert.ToInt32(strValues[6 + j].ToString());
                        secondChildAge[i] = Convert.ToInt32(strValues[7 + j].ToString());
                    }

                    string cityName = strValues[0].ToString();
                    string hotelName = "";
                    string area = "";
                    string rating = "";

                    ddlCity.Items.FindByValue(strValues[0].ToString().Trim().ToString()).Selected = true;
                    check_Inhotel.Text = strValues[1].ToString();
                    check_Outhotel.Text = strValues[2].ToString();

                    //rajini

                    TimeSpan timespan = Convert.ToDateTime(strValues[2].ToString()).Subtract(Convert.ToDateTime(strValues[1].ToString()));
                    int NOofdays = timespan.Days;

                    ViewState["NoOfdays"] = NOofdays;

                    //Rajini end

                    DataSet dsHotelAvailSearch = objArzooHotelAPILayer.GetHotelAvailSearch(ConvertDate(startDate), ConvertDate(endDate), noOfRooms, noOfAdultsInARoom, noOfChildsInARoom,
                    firstChildAge, secondChildAge, cityName, hotelName, area, rating);
                    if (dsHotelAvailSearch != null && dsHotelAvailSearch.Tables.Count > 1)
                    {
                        Session["Hotels"] = dsHotelAvailSearch;
                        gvHotels.DataSource = dsHotelAvailSearch;
                        gvHotels.DataBind();
                        gvHotels.Visible = true; 
                        DataView dvOptions = new DataView(dsHotelAvailSearch.Tables[0]);
                        dvOptions.Sort = "hotelname";
                        ddlHotelName.DataSource = dvOptions;
                        ddlHotelName.DataTextField = "hotelname";
                        ddlHotelName.DataBind();
                        ddlHotelName.Items.Insert(0, "ALL");
                    }
                    else { lblMsg.Text = "No Hotels Found. Please try again."; gvHotels.Visible = false; }
                }
                else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    public string ConvertDate(string date)
    {
        DateTime dt = Convert.ToDateTime(date);
        date = dt.ToString("dd/MM/yyyy");
        return date;
    }

    protected void gvHotels_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string hotelid =
                Convert.ToString(gvHotels.DataKeys[e.Row.RowIndex].Values["hotelid"].ToString());
                if (Session["Hotels"] != null)
                {
                    DataSet ds = (DataSet)Session["Hotels"];
                    DataTable dtHotelRooms = ds.Tables["HotelRooms"];
                    DataRow[] drRooms = dtHotelRooms.Select("hotelid = '" + hotelid + "'");
                    DataTable dtRooms = dtHotelRooms.Clone();
                    foreach (DataRow item in drRooms)
                    {
                        dtRooms.ImportRow(item);
                    }
                    GridView gvHotelRooms = (GridView)e.Row.FindControl("gvHotelRooms");
                    gvHotelRooms.DataSource = dtRooms;
                    gvHotelRooms.DataBind();
                }
                else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
                //rajini
                Label lblfacilities = (Label)e.Row.FindControl("lblfacilities");
                //lblfacilities.Text = lblfacilities.Text.Replace(",", "<br/>");
                //rajini end

                string[] strHH = lblfacilities.Text.ToString().Split(',');
                string sH = "<table  width=\"100px\" >";
                int ii = 0;
                foreach (string item in strHH)
                {
                    if (ii == 0) { sH = sH + "<tr  width=\"100px\" >"; }
                    if (ii <= 5)
                    {
                        sH = sH + " <td width=\"20px\" > " + item.ToString() + "&nbsp;&nbsp;&nbsp;" + " </td>";
                    }
                    ii += 1;
                    if (ii == 6) { ii = 0; sH = sH + " </tr> "; }
                }
                lblfacilities.Text = sH + " </table>";

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void gvHotels_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (Session["SearchParams"] != null)
            {
                if (e.CommandName == "HotelDetails")
                {
                    Button lbtnHotelDetails = (Button)e.CommandSource;
                    GridViewRow row = (GridViewRow)lbtnHotelDetails.NamingContainer;

                    string[] strValues = Session["SearchParams"].ToString().Split(':');

                    string cityName = strValues[0].ToString();
                    string hotelId = e.CommandArgument.ToString();
                    string webService = gvHotels.DataKeys[row.RowIndex].Values["webService"].ToString();

                    DataSet dsHotelDetails = objArzooHotelAPILayer.GetHotelDetails(hotelId, webService, cityName);

                    if (dsHotelDetails.Tables.Contains("HotelImages"))
                    {
                        dlPhotos.DataSource = dsHotelDetails.Tables["HotelImages"];
                        dlPhotos.DataBind();
                        modalPopUp.Show();
                    }

                }
                else if (e.CommandName == "ViewHotelRooms")
                {
                    //foreach (GridViewRow item in gvHotels.Rows)
                    //{
                    //    Panel pnl = (Panel)item.FindControl("pnlHotelRooms");
                    //    pnl.Visible = false;
                    //}

                    Button lbtnHotelDetails = (Button)e.CommandSource;
                    GridViewRow row = (GridViewRow)lbtnHotelDetails.NamingContainer;
                    Panel panel = (Panel)row.FindControl("pnlHotelRooms");
                    if (lbtnHotelDetails.Text == "View Rooms")
                    {
                        panel.Visible = true;
                        lbtnHotelDetails.Text = "Close Rooms";
                    }
                    else { panel.Visible = false; lbtnHotelDetails.Text = "View Rooms"; }
                }
            }
            else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void gvHotelRooms_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridView gv = sender as GridView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string extGuestTotal = ""; string roomTotal = ""; string servicetaxTotal = ""; string discount = ""; string commission = "";
                extGuestTotal = Convert.ToString(gv.DataKeys[e.Row.RowIndex].Values["extGuestTotal"].ToString());

                roomTotal = Convert.ToString(gv.DataKeys[e.Row.RowIndex].Values["roomTotal"].ToString());

                //Rajini ...Added for calculating  the total amount based on no of days
                double RoomTtl = Convert.ToDouble(roomTotal.ToString()) * Convert.ToDouble(ViewState["NoOfdays"].ToString());
                //Rajiniend

                RoomTtl = RoomTtl + ((RoomTtl * 10) / 100);

                servicetaxTotal = Convert.ToString(gv.DataKeys[e.Row.RowIndex].Values["servicetaxTotal"].ToString());
                discount = Convert.ToString(gv.DataKeys[e.Row.RowIndex].Values["discount"].ToString());
                commission = Convert.ToString(gv.DataKeys[e.Row.RowIndex].Values["commission"].ToString());

                // Changed roomTotal to RoomTtl by rajini
                LinkButton lbtnFare = (LinkButton)e.Row.FindControl("lbtnFare");
                lbtnFare.ToolTip = "RoomRate: " + RoomTtl + " \n Extra Guest Charge: " + extGuestTotal + " \n Service Tax: "
                    + servicetaxTotal; //+ " \n Discount: " + discount + " \n Commission: " + commission;
                double total = 0;
                total = (Convert.ToDouble(RoomTtl) + Convert.ToDouble(extGuestTotal) + Convert.ToDouble(servicetaxTotal));// -(Convert.ToDouble(discount) + Convert.ToDouble(commission));
                lbtnFare.Text = total.ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void gvHotelRooms_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (Session["SearchParams"] != null)
            {
                if (e.CommandName == "BookRoom")
                {
                    Button btnBook = (Button)e.CommandSource;
                    GridViewRow row = (GridViewRow)btnBook.NamingContainer;
                    GridView gvHotelRooms = (GridView)row.NamingContainer;
                    GridViewRow gvHotelRow = (GridViewRow)gvHotelRooms.NamingContainer;

                    string hotelId = e.CommandArgument.ToString();

                    string roomType = gvHotelRooms.DataKeys[row.RowIndex].Values["roomtype"].ToString();

                    string webService = gvHotels.DataKeys[gvHotelRow.RowIndex].Values["webService"].ToString();

                    string roomTypeCode = gvHotelRooms.DataKeys[row.RowIndex].Values["roomTypeCode"].ToString();
                    string ratePlanCode = gvHotelRooms.DataKeys[row.RowIndex].Values["ratePlanCode"].ToString();
                    string validDays = gvHotelRooms.DataKeys[row.RowIndex].Values["validdays"].ToString();
                    string wsKey = gvHotelRooms.DataKeys[row.RowIndex].Values["wsKey"].ToString();

                    string extGuestTotal = gvHotelRooms.DataKeys[row.RowIndex].Values["extGuestTotal"].ToString();
                    string roomTotal = gvHotelRooms.DataKeys[row.RowIndex].Values["roomTotal"].ToString();
                    string serviceTaxTotal = gvHotelRooms.DataKeys[row.RowIndex].Values["servicetaxTotal"].ToString();
                    string discount = gvHotelRooms.DataKeys[row.RowIndex].Values["discount"].ToString();
                    string commission = gvHotelRooms.DataKeys[row.RowIndex].Values["commission"].ToString();

                    string hotelName = gvHotels.DataKeys[gvHotelRow.RowIndex].Values["hotelname"].ToString();
                    string hotelAddress = gvHotels.DataKeys[gvHotelRow.RowIndex].Values["address"].ToString();
                    string hotelStar = gvHotels.DataKeys[gvHotelRow.RowIndex].Values["starrating"].ToString();
                    string totalINR = "";

                    string roomBasis = gvHotelRooms.DataKeys[row.RowIndex].Values["roombasis"].ToString();

                    LinkButton lbtnFare = (LinkButton)row.FindControl("lbtnFare");
                    totalINR = lbtnFare.Text.ToString();
                    string fareDetails = lbtnFare.ToolTip.ToString();

                    DataTable dtSelectedHotelDetails = new DataTable();
                    dtSelectedHotelDetails.Columns.Add("hotelId");
                    dtSelectedHotelDetails.Columns.Add("roomType");
                    dtSelectedHotelDetails.Columns.Add("webService");
                    dtSelectedHotelDetails.Columns.Add("roomTypeCode");
                    dtSelectedHotelDetails.Columns.Add("ratePlanCode");
                    dtSelectedHotelDetails.Columns.Add("validDays");
                    dtSelectedHotelDetails.Columns.Add("wsKey");
                    dtSelectedHotelDetails.Columns.Add("extGuestTotal");
                    dtSelectedHotelDetails.Columns.Add("roomTotal");
                    dtSelectedHotelDetails.Columns.Add("serviceTaxTotal");
                    dtSelectedHotelDetails.Columns.Add("discount");
                    dtSelectedHotelDetails.Columns.Add("commission");
                    dtSelectedHotelDetails.Columns.Add("hotelName");
                    dtSelectedHotelDetails.Columns.Add("hotelAddress");
                    dtSelectedHotelDetails.Columns.Add("hotelStar");
                    dtSelectedHotelDetails.Columns.Add("totalINR");
                    dtSelectedHotelDetails.Columns.Add("roomBasis");
                    dtSelectedHotelDetails.Columns.Add("noOfAdults");
                    dtSelectedHotelDetails.Columns.Add("noOfChilds");

                    DataRow dr = dtSelectedHotelDetails.NewRow();
                    dr["hotelId"] = hotelId;
                    dr["roomType"] = roomType;
                    dr["webService"] = webService;
                    dr["roomTypeCode"] = roomTypeCode;
                    dr["ratePlanCode"] = ratePlanCode;
                    dr["validDays"] = validDays;
                    dr["wsKey"] = wsKey;
                    dr["extGuestTotal"] = extGuestTotal;
                    dr["roomTotal"] = roomTotal;
                    dr["serviceTaxTotal"] = serviceTaxTotal;
                    dr["discount"] = discount;
                    dr["commission"] = commission;
                    dr["hotelName"] = hotelName;
                    dr["hotelAddress"] = hotelAddress;
                    dr["hotelStar"] = hotelStar;
                    dr["totalINR"] = totalINR + "~(" + fareDetails.Replace("\n", ";") + ")";
                    dr["roomBasis"] = roomBasis;
                    dr["noOfAdults"] = "";
                    dr["noOfChilds"] = "";


                    dtSelectedHotelDetails.Rows.Add(dr);

                    Session["SelectedHotelParams"] = dtSelectedHotelDetails;

                    Response.Redirect("HotelInfo.aspx", false);
                }
                else if (e.CommandName == "HotelPolicy")
                {
                    LinkButton lbtnHotelPolicy = (LinkButton)e.CommandSource;
                    GridViewRow row = (GridViewRow)lbtnHotelPolicy.NamingContainer;
                    GridView gvHotelRooms = (GridView)row.NamingContainer;
                    GridViewRow gvHotelRow = (GridViewRow)gvHotelRooms.NamingContainer;

                    string[] strValues = Session["SearchParams"].ToString().Split(':');

                    string hotelId = e.CommandArgument.ToString();
                    string webService = gvHotels.DataKeys[gvHotelRow.RowIndex].Values["webService"].ToString();
                    string roomTypeCode = gvHotelRooms.DataKeys[row.RowIndex].Values["roomTypeCode"].ToString();
                    string ratePlanType = gvHotelRooms.DataKeys[row.RowIndex].Values["ratePlanCode"].ToString();

                    string startDate = strValues[1].ToString();
                    string endDate = strValues[2].ToString();

                    DataSet dsHotelPolicy = objArzooHotelAPILayer.GetHotelPolicy(hotelId, webService, ratePlanType, roomTypeCode, ConvertDate(startDate), ConvertDate(endDate));
                }
            }
            else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void gvHotels_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (Session["Hotels"] != null)
            {
                gvHotels.PageIndex = e.NewPageIndex;
                gvHotels.DataSource = Filter();
                gvHotels.DataBind();
            }
            else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void lbtnHotelNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Hotels"] != null)
            {
                DataSet ds = (DataSet)Session["Hotels"];
                string strExpression = "hotelname";
                string strDirection = ViewState["SortDirection"].ToString();

                ViewState["SortExpressionFilter"] = strExpression;

                DataView dv = new DataView(Filter());
                dv.Sort = strExpression + strDirection;

                gvHotels.PageIndex = 0;
                gvHotels.DataSource = dv;
                gvHotels.DataBind();

                if (strDirection == " ASC")
                { ViewState["SortDirection"] = " DESC"; ViewState["SortDirectionFilter"] = " ASC"; }
                else { ViewState["SortDirection"] = " ASC"; ViewState["SortDirectionFilter"] = " DESC"; }
            }
            else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void lbtnHotelRatingSort_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Hotels"] != null)
            {
                DataSet ds = (DataSet)Session["Hotels"];
                string strExpression = "starrating";
                string strDirection = ViewState["SortDirection"].ToString();

                ViewState["SortExpressionFilter"] = strExpression;

                DataView dv = new DataView(Filter());
                dv.Sort = strExpression + strDirection;

                gvHotels.PageIndex = 0;
                gvHotels.DataSource = dv;
                gvHotels.DataBind();

                if (strDirection == " ASC")
                { ViewState["SortDirection"] = " DESC"; ViewState["SortDirectionFilter"] = " ASC"; }
                else { ViewState["SortDirection"] = " ASC"; ViewState["SortDirectionFilter"] = " DESC"; }
            }
            else { Response.Redirect("~/Users/Hotel/HotelSearch.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void lbtnHotelMinRateSort_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Hotels"] != null)
            {
                DataSet ds = (DataSet)Session["Hotels"];
                string strExpression = "minRate";
                string strDirection = ViewState["SortDirection"].ToString();

                ViewState["SortExpressionFilter"] = strExpression;

                DataTable dtFilter = Filter();
                DataTable dt = dtFilter.Clone();
                dt.Columns["minRate"].DataType = Type.GetType("System.Decimal");
                foreach (DataRow item in dtFilter.Rows)
                {
                    DataRow dr = item;
                    dr["minRate"] = Convert.ToDecimal(item["minRate"].ToString().Trim().ToString());
                    dt.ImportRow(dr);
                }

                DataView dv1 = new DataView(dt);
                dv1.Sort = strExpression + strDirection;

                gvHotels.PageIndex = 0;
                gvHotels.DataSource = dv1;
                gvHotels.DataBind();

                if (strDirection == " ASC")
                { ViewState["SortDirection"] = " DESC"; ViewState["SortDirectionFilter"] = " ASC"; }
                else { ViewState["SortDirection"] = " ASC"; ViewState["SortDirectionFilter"] = " DESC"; }
            }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["SearchParams"] != null)
            {
                if (Convert.ToDateTime(check_Inhotel.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "CheckIn Date should not be less than Current Date." + "');</script>", false);
                    return;
                }
                if (Convert.ToDateTime(check_Outhotel.Text.ToString()) < Convert.ToDateTime(System.DateTime.Now.Date.ToShortDateString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "CheckOut Date should not be less than Current Date." + "');</script>", false);
                    return;
                }
                if (Convert.ToDateTime(check_Inhotel.Text.ToString()) >= Convert.ToDateTime(check_Outhotel.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + "CheckOut Date should be greater than CheckIn Date." + "');</script>", false);
                    return;
                }

                string[] strValues = Session["SearchParams"].ToString().Split(':');

                string startDate = check_Inhotel.Text.ToString();
                string endDate = check_Outhotel.Text.ToString();

                //rajini

                TimeSpan timespan = Convert.ToDateTime(check_Outhotel.Text.ToString()).Subtract(Convert.ToDateTime(check_Inhotel.Text.ToString()));
                int NOofdays = timespan.Days;

                ViewState["NoOfdays"] = NOofdays;

                //Rajini end

                int noOfRooms = Convert.ToInt32(strValues[3].ToString());

                int[] noOfAdultsInARoom = new int[noOfRooms];
                int[] noOfChildsInARoom = new int[noOfRooms];
                int[] firstChildAge = new int[noOfRooms];
                int[] secondChildAge = new int[noOfRooms];
                int j = 0;
                for (int i = 0; i < noOfRooms; i++)
                {
                    if (i == 0)
                    {
                        j = 0;
                    }
                    else
                    {
                        j = 4 * i;
                    }

                    noOfAdultsInARoom[i] = Convert.ToInt32(strValues[4 + j].ToString());
                    noOfChildsInARoom[i] = Convert.ToInt32(strValues[5 + j].ToString());
                    firstChildAge[i] = Convert.ToInt32(strValues[6 + j].ToString());
                    secondChildAge[i] = Convert.ToInt32(strValues[7 + j].ToString());
                }

                string cityName = ddlCity.SelectedValue.ToString();
                string hotelName = "";
                string area = "";
                string rating = "";

                string searchParams = ddlCity.SelectedValue.ToString() + ":" + check_Inhotel.Text.ToString() + ":" + check_Outhotel.Text.ToString() + ":"
                + noOfRooms.ToString()

                + ":" + strValues[4].ToString() + ":" + strValues[5].ToString() + ":"
                + strValues[6].ToString() + ":" + strValues[7].ToString()

                + ":" + strValues[8].ToString() + ":" + strValues[9].ToString() + ":"
                + strValues[10].ToString() + ":" + strValues[11].ToString()

                + ":" + strValues[12].ToString() + ":" + strValues[13].ToString() + ":"
                + strValues[14].ToString() + ":" + strValues[15].ToString()

                + ":" + strValues[16].ToString() + ":" + strValues[17].ToString() + ":"
                + strValues[18].ToString() + ":" + strValues[19].ToString();

                Session["SearchParams"] = searchParams;

                DataSet dsHotelAvailSearch = objArzooHotelAPILayer.GetHotelAvailSearch(ConvertDate(startDate), ConvertDate(endDate), noOfRooms, noOfAdultsInARoom, noOfChildsInARoom,
                  firstChildAge, secondChildAge, cityName, hotelName, area, rating);
                if (dsHotelAvailSearch != null && dsHotelAvailSearch.Tables.Count > 1)
                {
                    Session["Hotels"] = dsHotelAvailSearch;
                    gvHotels.DataSource = dsHotelAvailSearch;
                    gvHotels.DataBind();
                    gvHotels.Visible = true; 
                    DataView dvOptions = new DataView(dsHotelAvailSearch.Tables[0]);
                    dvOptions.Sort = "hotelname";
                    ddlHotelName.DataSource = dvOptions;
                    ddlHotelName.DataTextField = "hotelname";
                    ddlHotelName.DataBind();
                    ddlHotelName.Items.Insert(0, "ALL");
                }
                else { lblMsg.Text = "No Hotels Found. Please try again."; gvHotels.Visible = false; }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void ddlHotelName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvHotels.PageIndex = 0;
            gvHotels.DataSource = Filter();
            gvHotels.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    protected void ddlHotelStar_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvHotels.PageIndex = 0;
            gvHotels.DataSource = Filter();
            gvHotels.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    DataTable Filter()
    {
        try
        {
            DataSet dsHotels = null;
            DataView dv = null;
            DataTable dts = null;
            if (Session["Hotels"] != null)
            {
                dsHotels = (DataSet)Session["Hotels"];
                dts = dsHotels.Tables[0].Clone();
                dv = new DataView(dsHotels.Tables[0]);
                dv.RowFilter = Expression();

                string sortDirection = ViewState["SortDirectionFilter"].ToString();
                string sortExpression = ViewState["SortExpressionFilter"].ToString();

                if (sortExpression != "" && sortDirection != "")
                {
                    dv.Sort = sortExpression + sortDirection;
                }

                return dv.ToTable();
            }
            else { return null; }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            throw;
        }
    }
    string Expression()
    {
        string str = "";
        string strHotelName = "";
        string strHotelStar = "";
        if (ddlHotelName.SelectedIndex != 0)
        {
            strHotelName = "(hotelname LIKE '%" + ddlHotelName.SelectedItem.Text.Trim().ToString().Replace("'", "''") + "%')";
        }
        if (ddlHotelStar.SelectedIndex != 0)
        {
            strHotelStar = "(starrating >=" + ddlHotelStar.SelectedItem.Value.Trim().ToString() + ")";
        }

        if (strHotelName == "" && strHotelStar == "")
        {
            str = "";
        }
        else if (strHotelName != "" && strHotelStar == "")
        {
            str = strHotelName;
        }
        else if (strHotelName == "" && strHotelStar != "")
        {
            str = strHotelStar;
        }
        else if (strHotelName != "" && strHotelStar != "")
        {
            str = strHotelName + " AND " + strHotelStar;
        }

        return str;
    }
}