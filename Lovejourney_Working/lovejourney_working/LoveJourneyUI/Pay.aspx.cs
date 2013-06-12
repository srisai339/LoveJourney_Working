using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APRWorld;
using BAL;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Web.Security;
using System.Drawing.Design;
using COM;
using System.Data.SqlClient;
using System;

public partial class Pay : clsBagePage
{
    #region Global Variables
    clsMasters _objMaster;
    clsMasters _objMasters;
    DataSet _objDataSet;
    clsUserAuthentication _objUserAuth;
    static string Checked = "null";
    static string ipaddr;
    static string Name;
    static string address;
    static string State;
    static string City;
    static string PostalCode;
    static string val;
    static string Email;
    static string Mobilenumber;
    static string Country;


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
              
            if (Request.QueryString["val"] != null)
            {
                val = Request.QueryString["val"].ToString();
                if (val == "true")
                {
                    FlightIntgetGuestDetails();
                }
                else if (val == "Dom")
                {
                    FlightgetGuestDetails();
                }
                else if (val == "bus")
                {
                    bus();
                }
                else if (val == "car")
                {
                    car();
                }
            }

            else if (Request.QueryString["service"] != null)
            {
                getUserDetailsHotels();
            }
            else if (Session["Role"] == null)
            {
                getGuestDetails();
            }
            else
            {
                getUserDetails();
            }
            if (val == "true")
            {
                string Url = "ebs_pay.aspx";
                string Method = "post";
                string FormName = "form1";

                //string str = GenerateRandomNumber(20);
                //Session["referenceId"] = str.ToString();


                NameValueCollection FormFields = new NameValueCollection();
                FormFields.Add("account_id", "11918"); //Change to Client Account ID                   11918
                //FormFields.Add("account_id", "5880");
                FormFields.Add("reference_no", Session["Order_Id"].ToString());

                FormFields.Add("amount", Session["Amount"].ToString());//Session["Amount"].ToString()
               // FormFields.Add("amount", "1");
                FormFields.Add("description", "TEST");
                // FormFields.Add("description", "LIVE"); //Change to LIVE
                FormFields.Add("name", Name);
                FormFields.Add("address", address);
                FormFields.Add("city", City);
                FormFields.Add("state", State);
                FormFields.Add("postal_code", PostalCode);
                FormFields.Add("country", Country);
                FormFields.Add("email", Email);
                FormFields.Add("phone", Mobilenumber);
                FormFields.Add("ship_name", Name);
                FormFields.Add("ship_address", address);
                FormFields.Add("ship_city", City);
                FormFields.Add("ship_state", State);
                FormFields.Add("ship_postal_code", PostalCode);
                FormFields.Add("ship_country", Country);
                FormFields.Add("ship_phone", Mobilenumber);
                // FormFields.Add("return_url", "http://localhost:24690/LoveJourneyUI/Response.aspx?DR={DR}");
                FormFields.Add("return_url", "http://lovejourney.in/Response.aspx?DR={DR}"); //Enable
                FormFields.Add("mode", mode.Value); //Change to mode LIVE  


                Response.Clear();
                Response.Write("<html><head>");
                Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < FormFields.Keys.Count; i++)
                {
                    Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", FormFields.Keys[i], FormFields[FormFields.Keys[i]]));
                }
                Response.Write("</form>");
                Response.Write("</body></html>");
                Response.End();
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            LogError("Pay.aspx", "Page_Load", DateTime.Now, ex.Message.ToString());
            throw ex;
        }



    }
    protected void EnabledFalse()
    {
        txtRechargeamount.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = false;
        txtprovidername.Enabled = false;
    }


    #region Generate Random Numbers
    int number;
    protected string GenerateRandomNumber(int count)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            number = random.Next(10);
            builder.Append(number);
        }

        return builder.ToString();
    }
    #endregion

    protected void hltermconds_Click(object sender, EventArgs e)
    {
        MpeInsert.Show();
    }

    protected void getGuestDetails()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.Identify;
        _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);
        _objDataSet = new DataSet();
        _objDataSet = (DataSet)_objMasters.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    Name = _objDataSet.Tables[0].Rows[0]["Name"].ToString();
                    address = _objDataSet.Tables[0].Rows[0]["Address"].ToString();
                    State = _objDataSet.Tables[0].Rows[0]["State"].ToString();
                    City = _objDataSet.Tables[0].Rows[0]["City"].ToString();
                    PostalCode = _objDataSet.Tables[0].Rows[0]["PostalCode"].ToString();
                    Email = Session["REmailMobile"].ToString();
                    Mobilenumber = Session["RMobileNumber"].ToString();
                    Country = _objDataSet.Tables[0].Rows[0]["Country"].ToString();
                    //address=
                    val = "true";
                }
            }
        }

    }
    protected void FlightIntgetGuestDetails()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.GetFlights;
        _objMasters.RequestID = Convert.ToString(Session["BookingID"]);
        _objDataSet = new DataSet();
        _objDataSet = (DataSet)_objMasters.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    Name = _objDataSet.Tables[0].Rows[0]["CustomerDetails"].ToString();
                    address = _objDataSet.Tables[0].Rows[0]["Address"].ToString();
                    string[] name = Name.ToString().Split('|');
                    Name = name[0].ToString() + name[1].ToString();

                    string[] add = address.ToString().Split(',');


                    State = add[1].ToString();
                    City = add[0].ToString();
                    PostalCode = add[3].ToString();
                    Email = _objDataSet.Tables[0].Rows[0]["EmailAddress"].ToString();
                    Mobilenumber = _objDataSet.Tables[0].Rows[0]["Telephone"].ToString();
                    Country = add[2].ToString();
                    //  address = add[0].ToString();
                    val = "true";
                }
            }
        }

    }
    protected void FlightgetGuestDetails()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.GetFlights1;
        _objMasters.RequestID = Convert.ToString(Session["Order_Id"]);
        _objDataSet = new DataSet();
        _objDataSet = (DataSet)_objMasters.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    Name = _objDataSet.Tables[0].Rows[0]["Customer_Details"].ToString();
                    address = _objDataSet.Tables[0].Rows[0]["address"].ToString();
                    string[] name = Name.ToString().Split('|');
                    Name = name[0].ToString() + name[1].ToString();

                    string[] add = address.ToString().Split(',');


                    State = add[1].ToString();
                    City = add[0].ToString();
                    PostalCode = add[3].ToString();
                    Email = _objDataSet.Tables[0].Rows[0]["emailAddress"].ToString();
                    Mobilenumber = _objDataSet.Tables[0].Rows[0]["telephone"].ToString();
                    Country = add[2].ToString();
                    //  address = add[0].ToString();
                    val = "true";
                }
            }
        }

    }


    protected void getUserDetails()
    {
        _objMasters = new clsMasters();
        _objMasters.ScreenInd = Masters.GetInfo;
        _objMasters.UserID = Convert.ToInt32(Session["UserID"]);
        _objDataSet = new DataSet();
        _objDataSet = (DataSet)_objMasters.fnGetData();

        if (_objDataSet != null)
        {
            if (_objDataSet.Tables.Count > 0)
            {
                if (_objDataSet.Tables[0].Rows.Count > 0)
                {
                    Name = _objDataSet.Tables[0].Rows[0]["AgentName"].ToString();
                    address = _objDataSet.Tables[0].Rows[0]["Address"].ToString();
                    State = _objDataSet.Tables[0].Rows[0]["State"].ToString();
                    City = _objDataSet.Tables[0].Rows[0]["City"].ToString();
                    PostalCode = _objDataSet.Tables[0].Rows[0]["PinCode"].ToString();
                    Email = _objDataSet.Tables[0].Rows[0]["EmailId"].ToString();
                    Mobilenumber = _objDataSet.Tables[0].Rows[0]["MobileNo"].ToString();
                    Country = "IND";


                    //if (Session["Ewallet"] != null)
                    //{
                    //    Email = Session["RechargeEmailID"].ToString();
                    //    Mobilenumber = _objDataSet.Tables[0].Rows[0]["MobileNumber"].ToString();
                    //}
                    //else
                    //{
                    Session["REmailMobile"] = Email;
                    //    Mobilenumber = Session["RMobileNumber"].ToString();
                    //}

                    val = "true";
                }
            }
        }

    }


    protected void getUserDetailsHotels()
    {
        HotelBAL objTicket = new HotelBAL();
        objTicket.ReferenceNo = Session["HotelRefNo"].ToString();
        Session["Order_Id"] = Session["HotelRefNo"].ToString();

        DataSet dsTicket = objTicket.GetHotelProvisional();

        if (dsTicket != null)
        {
            Name = dsTicket.Tables[0].Rows[0]["FirstName"].ToString();
            address = dsTicket.Tables[0].Rows[0]["CustAddressLine"].ToString();
            State = dsTicket.Tables[0].Rows[0]["CustState"].ToString();
            City = dsTicket.Tables[0].Rows[0]["CustCity"].ToString();
            PostalCode = dsTicket.Tables[0].Rows[0]["CustZipCode"].ToString();
            Email = dsTicket.Tables[0].Rows[0]["EmailId"].ToString();
            Mobilenumber = dsTicket.Tables[0].Rows[0]["MobileNumber"].ToString();
            Country = "IND";
            //address=
            val = "true";
        }
    }
    private void bus()
    {
        clsMasters objTicket = new clsMasters();
        objTicket.ScreenInd = Masters.getticket;
        objTicket.BankReferenceNo = Session["Order_Id"].ToString();
        DataSet dsTicket = objTicket.fnGetData();

        if (dsTicket != null)
        {
            Name = dsTicket.Tables[0].Rows[0]["FullName"].ToString();
            address = dsTicket.Tables[0].Rows[0]["Address"].ToString();
            State = "AP";
            City = "Hyderabad";
            PostalCode = "500004";
            Email = dsTicket.Tables[0].Rows[0]["EmailId"].ToString();
            Mobilenumber = dsTicket.Tables[0].Rows[0]["ContactNo"].ToString();
            Country = "IND";
            val = "true";
        }
    }

    private void car()
    {
        FlightBAL objTicket = new FlightBAL();
        DataSet dsFlights = new DataSet();
        Session["Order_Id"] = Session["refno"].ToString();
        objTicket.RefNo = Session["Order_Id"].ToString();
        DataSet dsTicket = objTicket.GetCarDetaisl(Session["refno"].ToString(), Session["CardetailsId"].ToString());

        if (dsTicket != null)
        {
            Name = dsTicket.Tables[0].Rows[0]["Name"].ToString();
            address = dsTicket.Tables[0].Rows[0]["Address"].ToString();
            State = "AP";
            City = "Hyderabad";
            PostalCode = "500004";
            Email = dsTicket.Tables[0].Rows[0]["EmailId"].ToString();
            Mobilenumber = dsTicket.Tables[0].Rows[0]["MobileNo"].ToString();
            Country = "IND";
            val = "true";
        }
    }

}