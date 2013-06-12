using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

using LJ.CLB.Buses;

public partial class MapProviderCities : System.Web.UI.Page
{
    #region Declarations

    String ConnectionString = ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
    SqlConnection Connection;
    SqlCommand command;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadProviders();
    }

    protected void ddlProviders_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProviders.SelectedValue != "0")
        {
            MapCities(ddlProviders.SelectedItem.Text);
        }
        else
        {
            gvUnmappedItems.DataSource = null;
            gvUnmappedItems.DataBind();
        }
    }

    private void MapCities(String ProviderName)
    {
        ProviderName = ProviderName.ToUpper();
        String strCities = String.Empty;
        DataTable dtCities = new DataTable();
        switch (ProviderName)
        {
            case "ABHIBUS":
            case "SVR":
            case "KALLADA":
            case "KAVERI":
            case "RAJESH":
            case "SAIANJANA":
                AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
                if (ProviderName == "ABHIBUS")
                    strCities = clsAbhibusAPI.getSources("http://www.abhibus.com/api/manabus_kld/server.php", "BUSMANAHY05HBAI");
                else if (ProviderName == "SVR")
                    strCities = clsAbhibusAPI.getSources("http://www.svrtravels.com/api/lovejourney/server.php", "LOVE@SVR");
                else if (ProviderName == "KALLADA")
                    strCities = clsAbhibusAPI.getSources("http://kalladatravels.com/api/lovejourney/server.php", "LVOEJOURNEYAPI");
                else if (ProviderName == "KAVERI")
                    strCities = clsAbhibusAPI.getSources("http://kaveribus.com/api/lovejourney/server.php", "LVOEJOURNEYAPI");
                else if (ProviderName == "RAJESH")
                    strCities = clsAbhibusAPI.getSources("http://rajeshtravels.in/api/lovejourney/server.php", "LOVRAJESHAPI");
                else if (ProviderName == "SAIANJANA")
                    strCities = clsAbhibusAPI.getSources("http://saianjanatravels.in/api/lovejourney/server.php", "LOVEANJANAAPI");
                break;
            case "BITLA":
                BitlaAPI clsBitlaAPI = new BitlaAPI();
                strCities = clsBitlaAPI.getSources("http://api.ticketsimply.com/api", "TSAPI*854LOVEJOURNEY");
                break;
            case "MORNINGSTAR":
                BitlaAPI clsBitlaAPI2 = new BitlaAPI();
                strCities = clsBitlaAPI2.getSources("http://api.ticketsimply.com/api", "TSAPI*1648LOVEJOURNEYDIR");
                break;
            case "TICKETGOOSE":
                TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                strCities = clsTicketGooseAPI.getSources("http://ticketgoose.com/bookbustickets/services/TGSWS", "ssdtech", "prasadsir");
                break;
            case "EASYBUS":
                EasybusAPI clsEasyBusAPI = new EasybusAPI();
                strCities = clsEasyBusAPI.getSources("http://demoapi.easybus.in/server.aspx", "easybus@123");
                break;
            default:
                break;
        }

        List<KeyValuePair<int, string>> UnmappedItemList = new List<KeyValuePair<int, string>>();
        dtCities = JsonConvert.DeserializeObject<DataTable>(strCities);
        if (dtCities != null && dtCities.Rows.Count > 0)
        {
            Connection = new SqlConnection(ConnectionString);
            try
            {
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_Insert_SourceCity";
                command.Connection = Connection;
                Connection.Open();
                foreach (DataRow row in dtCities.Rows)
                {
                    //command for sources table
                    command.Parameters.Add("@ID", SqlDbType.VarChar).Value = row["id"];
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = row["name"];
                    command.Parameters.Add("@ProviderName", SqlDbType.VarChar).Value = ProviderName;
                    Object result = command.ExecuteScalar();

                    if (!result.ToString().ToUpper().Equals("SUCCESS"))
                    {
                        UnmappedItemList.Add(new KeyValuePair<int, String>(int.Parse(row["id"].ToString()), row["name"].ToString()));
                    }
                    command.Parameters.Clear();

                }

                Connection.Close();
            }
            catch (Exception ex)
            {
                //to do
                //Log Exception
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        lblCount.InnerText = (UnmappedItemList != null) ? UnmappedItemList.Count.ToString() : "0";
        gvUnmappedItems.DataSource = UnmappedItemList;
        gvUnmappedItems.DataBind();
    }

    private void LoadProviders()
    {
        Connection = new SqlConnection(ConnectionString);
        DataTable dt = new DataTable();
        try
        {
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Connection;
            Connection.Open();
            command.CommandText = "SELECT * FROM tbl_API_Providers where provider_status=1";
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            Connection.Close();
        }
        catch (Exception ex)
        {
            //to do
            //Log Exception
        }
        finally
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        ddlProviders.DataSource = dt;
        ddlProviders.DataTextField = "Provider_Name";
        ddlProviders.DataValueField = "Provider_ID";
        ddlProviders.DataBind();
        ddlProviders.Items.Insert(0, new ListItem("Please select", "0"));
    }

    //Only for one time use
    //private void InsertCities()
    //{
    //    RedbusAPI clsRedbusAPI = new RedbusAPI();
    //    String strCities = clsRedbusAPI.getSources("http://api.seatseller.travel", "9RDkOz1UxrtOwW3XICXhM51esepahb", "x2ZuoR49Pp68E9YufnIGrK4m1orA1a");
    //    DataSet dsSourceCities = JsonConvert.DeserializeObject<DataSet>(strCities);


    //    Connection = new SqlConnection(ConnectionString);
    //    try
    //    {
    //        command = new SqlCommand();
    //        command.CommandType = CommandType.Text;
    //        command.Connection = Connection;
    //        Connection.Open();

    //        foreach (DataRow row in dsSourceCities.Tables[0].Rows)
    //        {
    //            command.CommandText = "INSERT INTO tbl_Destinations (Destination_Name, Created_By, Modified_By) VALUES ('" + row["name"] + "',1,1)";
    //            command.ExecuteNonQuery();
    //            command.CommandText = "INSERT INTO tbl_Sources (Destination_Name, Created_By, Modified_By) VALUES ('" + row["name"] + "',1,1)";
    //            command.ExecuteNonQuery();
    //        }

    //        Connection.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        //to do
    //        //Log Exception
    //    }
    //    finally
    //    {
    //        if (Connection.State == ConnectionState.Open)
    //            Connection.Close();
    //    }
    //}
}