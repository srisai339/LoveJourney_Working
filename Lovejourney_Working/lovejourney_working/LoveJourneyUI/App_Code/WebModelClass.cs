using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Threading;
using System.Web.SessionState;
using LJ.CLB.Buses;
using LJ.CLB.DTO;
using System.Web.UI.WebControls;
using System.Web.Caching;
using BAL;


/// <summary>
/// Summary description for WebModelClass
/// </summary>
namespace LJ.WebAPI.Models
{
    /// <summary>
    /// BusesViewModel contains the methods that exposes bus api service
    /// </summary>
    public class BusesViewModel
    {
        #region Declarations
        String ConnectionString = ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
        SqlConnection Connection;
        SqlCommand command;
        AvailableTrips bus = new AvailableTrips();
        AvailableTrips Tbus = new AvailableTrips();
        AvailableTrips Kbus = new AvailableTrips();
        AvailableTrips tripdetails = new AvailableTrips();
        #endregion

        #region Public Methods

        public string GetCities(String ConsumerKey, String ConsumerSecret)
        {
            cities objCities = new cities();
            try
            {
                Connection = new SqlConnection(ConnectionString);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_WebAPI_GetCities";
                command.Parameters.Add("@ConsumerKey", SqlDbType.VarChar).Value = ConsumerKey;
                command.Parameters.Add("@ConsumerSecret", SqlDbType.VarChar).Value = ConsumerSecret;
                command.Connection = Connection;
                Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        objCities.Add(new city(int.Parse(item["id"].ToString()), item["name"].ToString()));
                    }
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                // throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return objCities.ToString();
        }

        List<AvailableTrips> objarry = new List<AvailableTrips>();
        Thread[] objthread = new Thread[1];
        #region backup available method trips

        public string GetAvailableTrips1(int sourceId, int destinationId, String dateofjourney, Int16 resultSetIndex, String ConsumerKey, String ConsumerSecret)
        {
            try
            {

                ClientAPIList objClientAPIList = new ClientAPIList();

                BusesAvailabilityResponse objBusesAvailabilityResponse = new BusesAvailabilityResponse();

                //Check if Cache already contains the Providers API List
                //Else get it from database        
                // if (HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] == null)
                GetAPIProvidersList(ConsumerKey, ConsumerSecret);

                objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];

                //Check if atleast one provider is accessible
                if (objClientAPIList != null && objClientAPIList.Count > 0)
                {
                    BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter();
                    for (int i = 0; i < objClientAPIList.Count; i++)
                    {

                        objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[i], sourceId, destinationId, dateofjourney);
                        //check if resultset index exceeds accessible providers list call the requested api
                        if (resultSetIndex > 0 && resultSetIndex <= objClientAPIList.Count)
                        {
                            //Check if request has valid source and destination ids
                            if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                            {
                                //check if valid available trips are fetched
                                try
                                {

                                    objBusesAvailabilityResponse.availableTrips = GetAvailableTripsByProviderName(objClientAPIList[i], objBusesSearchFilter);
                                    objBusesAvailabilityResponse.responseStatus = HttpStatusCode.OK;

                                }
                                catch (Exception ex)
                                {
                                    //return the exception
                                    objBusesAvailabilityResponse.availableTrips = null;
                                    objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                                    objBusesAvailabilityResponse.message = ex.Message;
                                }
                            }
                            else
                            {
                                //objBusesAvailabilityResponse.availableTrips = "No results found.";
                                // objBusesAvailabilityResponse.responseStatus = HttpStatusCode.NoContent;
                                objBusesAvailabilityResponse.availableTrips = null;
                            }
                            objBusesAvailabilityResponse.providersCount = objClientAPIList.Count - resultSetIndex;
                        }
                        else
                        {
                            //objBusesAvailabilityResponse.availableTrips = "Invalid request. Please correct resultSetIndex value";
                            objBusesAvailabilityResponse.providersCount = 0;
                            objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                        }

                        if (objBusesAvailabilityResponse.availableTrips != null)
                        {
                            if (HttpContext.Current.Session["AvailResponse"] == null)
                            {
                                HttpContext.Current.Session["AvailResponse"] = objBusesAvailabilityResponse;
                                bus = trips(objBusesAvailabilityResponse.availableTrips);
                                //HttpContext.Current.Session["AvailResponseTrips"] = bus;
                                //bus = trips(bus);
                            }
                            else
                            {
                                //bus = trips((AvailableTrips)HttpContext.Current.Session["AvailResponseTrips"]);
                                bus = trips(objBusesAvailabilityResponse.availableTrips);
                            }
                        }
                    }
                    /*** Uncomment this if available trips of all providers should be fetched in one go ***/

                }
                else
                {

                    objBusesAvailabilityResponse.providersCount = 0;
                    objBusesAvailabilityResponse.responseStatus = HttpStatusCode.NoContent;
                }


                objBusesAvailabilityResponse.availableTrips = bus;
                HttpContext.Current.Session["AvailResponse"] = objBusesAvailabilityResponse;
                return JsonConvert.SerializeObject(objBusesAvailabilityResponse);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region testing code
        #region declare
        string source_ids = string.Empty;
        string Destination_Ids = string.Empty;

        string Tsource_ids = string.Empty;
        string TDestination_Ids = string.Empty;
        string Msource_ids = string.Empty;
        string MDestination_Ids = string.Empty;
        string SSsource_ids = string.Empty;
        string SSDestination_Ids = string.Empty;
        string Ssource_ids = string.Empty;
        string SDestination_Ids = string.Empty;
        string Ksource_ids = string.Empty;
        string KDestination_Ids = string.Empty;
        string KDsource_ids = string.Empty;
        string KDDestination_Ids = string.Empty;
        string Rsource_ids = string.Empty;
        string RDestination_Ids = string.Empty;
        /// <summary>
        /// Easy bus 
        /// </summary>
        string Esource_ids = string.Empty;
        string EDestination_Ids = string.Empty;

        bool b = false;
        bool c = true;
        int i = 0;
        int threadcount = 0;
        Thread[] thread;
        int TSID;
        int TDID;
        string TDate = string.Empty;
        string TURL = string.Empty;
        string TConsumerKey = string.Empty;
        string TCOnsumerSecretKey = string.Empty;
        int TPID;
        int KSID;
        int KDID;
        string KDate = string.Empty;
        string KURL = string.Empty;
        string KConsumerKey = string.Empty;
        string KCOnsumerSecretKey = string.Empty;
        string KProviderName;
        int SSID;
        int SDID;
        string SDate = string.Empty;
        string SURL = string.Empty;
        string SConsumerKey = string.Empty;
        string SCOnsumerSecretKey = string.Empty;
        string SProviderName;

        int SVSID;
        int SVDID;
        string SVDate = string.Empty;
        string SVURL = string.Empty;
        string SVConsumerKey = string.Empty;
        string SVCOnsumerSecretKey = string.Empty;
        string SVProviderName;

        int RSID;
        int RDID;
        string RDate = string.Empty;
        string RURL = string.Empty;
        string RConsumerKey = string.Empty;
        string RCOnsumerSecretKey = string.Empty;
        string RProviderName;
        int KDSID;
        int KDDID;
        string KDDate = string.Empty;
        string KDURL = string.Empty;
        string KDConsumerKey = string.Empty;
        string KDCOnsumerSecretKey = string.Empty;
        string KDProviderName;

        int MSID;
        int MDID;
        string MDate = string.Empty;
        string MURL = string.Empty;
        string MConsumerKey = string.Empty;
        string MCOnsumerSecretKey = string.Empty;
        int MPID;
        string MProviderName = string.Empty;

        int BSID;
        int BDID;
        string BDate = string.Empty;
        string BURL = string.Empty;
        string BConsumerKey = string.Empty;
        string BCOnsumerSecretKey = string.Empty;
        int BPID;
        string BProviderName = string.Empty;
        /// <summary>
        /// Easy Bus
        /// </summary>
        int ESID;
        int EDID;
        string EDate = string.Empty;
        string EURL = string.Empty;
        string EConsumerKey = string.Empty;
        string ECOnsumerSecretKey = string.Empty;
        int EPID;
        string EProviderName = string.Empty;

        #endregion
        public string GetAvailableTrips(int sourceId, int destinationId, String dateofjourney, Int16 resultSetIndex, String ConsumerKey, String ConsumerSecret)
        {
            try
            {
                ClientAPIList objClientAPIList = new ClientAPIList();
                BusesAvailabilityResponse objBusesAvailabilityResponse = new BusesAvailabilityResponse();
                if (resultSetIndex != 2)
                {
                    HttpContext.Current.Session["AvailResponse"] = null;
                    HttpRuntime.Cache["bus"] = "";

                    //Check if Cache already contains the Providers API List
                    //Else get it from database        
                    GetAPIProvidersList(ConsumerKey, ConsumerSecret);
                    objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                    //Check if atleast one provider is accessible
                    if (objClientAPIList != null && objClientAPIList.Count > 0)
                    {
                        BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter();
                        threadcount = Convert.ToInt32(objClientAPIList.Count());
                        thread = new Thread[threadcount];
                        for (i = 0; i < thread.Count(); i++)
                        {
                            thread[i] = new Thread(() =>
                            {
                                if (objClientAPIList[i].ProviderName == "TICKETGOOSE")
                                {
                                    int T = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[T], sourceId, destinationId, dateofjourney);
                                    if (Tsource_ids.ToString() != "" && TDestination_Ids.ToString() != "")
                                    {
                                        string[] Tsu = Tsource_ids.Split(',');
                                        string[] Tdu = TDestination_Ids.Split(',');
                                        string[] TSdr = Tsu.Distinct().ToArray();
                                        string[] TDdr = Tdu.Distinct().ToArray();
                                        foreach (string Tsr in TSdr)
                                        {
                                            foreach (string Tdr in TDdr)
                                            {
                                                TSID = Convert.ToInt32(Tsr);
                                                TDID = Convert.ToInt32(Tdr);
                                                TDate = objBusesSearchFilter.JourneyDate;
                                                TURL = objClientAPIList[T].APIURL;
                                                TConsumerKey = objClientAPIList[T].ConsumerKey;
                                                TCOnsumerSecretKey = objClientAPIList[T].ConsumerSecret;
                                                TPID = objClientAPIList[T].ProviderID;
                                                Tbus = Ticketgoose(TURL, TConsumerKey, TCOnsumerSecretKey, TPID, TSID, TDID, TDate);
                                                if (Tbus != null)
                                                {
                                                    if (Tbus.Count() > 0)
                                                    {
                                                        bus = trips(Tbus);
                                                        HttpRuntime.Cache["bus"] = Tbus;
                                                        objBusesAvailabilityResponse.providersCount = 10;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "MORNINGSTAR")
                                {
                                    int M = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[M], sourceId, destinationId, dateofjourney);
                                    if (Msource_ids.ToString() != "" && MDestination_Ids.ToString() != "")
                                    {
                                        string[] Msu = Msource_ids.Split(',');
                                        string[] Mdu = MDestination_Ids.Split(',');
                                        string[] MSdr = Msu.Distinct().ToArray();
                                        string[] MDdr = Mdu.Distinct().ToArray();
                                        foreach (string Msr in MSdr)
                                        {
                                            foreach (string Mdr in MDdr)
                                            {
                                                MSID = Convert.ToInt32(Msr);
                                                MDID = Convert.ToInt32(Mdr);
                                                MDate = objBusesSearchFilter.JourneyDate;
                                                MURL = objClientAPIList[M].APIURL + "/";
                                                MConsumerKey = objClientAPIList[M].ConsumerKey;
                                                MCOnsumerSecretKey = objClientAPIList[M].ConsumerSecret;
                                                MPID = objClientAPIList[M].ProviderID;
                                                MProviderName = objClientAPIList[M].ProviderName;
                                                Tbus = MORNINGSTAR(MURL, MConsumerKey, MCOnsumerSecretKey, MPID, MProviderName, MSID, MDID, MDate);
                                                if (Tbus != null)
                                                {
                                                    if (Tbus.Count() > 0)
                                                    {
                                                        bus = trips(Tbus);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "BITLA")
                                {
                                    //objBusesSearchFilter.SourceID = Sdr.ToString() == "" ? 0 : int.Parse(Sdr.ToString());
                                    //objBusesSearchFilter.DestinationID = Ddr.ToString() == "" ? 0 : Convert.ToInt32(Ddr.ToString());
                                    //objBusesSearchFilter.JourneyDate = dateofjourney;
                                    int B = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[B], sourceId, destinationId, dateofjourney);
                                    if (source_ids.ToString() != "" && Destination_Ids.ToString() != "")
                                    {
                                        string[] su = source_ids.Split(',');
                                        string[] du = Destination_Ids.Split(',');
                                        string[] SSdr = su.Distinct().ToArray();
                                        string[] DDdr = du.Distinct().ToArray();
                                        foreach (string Sdr in SSdr)
                                        {
                                            foreach (string Ddr in DDdr)
                                            {
                                                BSID = Convert.ToInt32(Sdr);
                                                BDID = Convert.ToInt32(Ddr);
                                                BDate = objBusesSearchFilter.JourneyDate;
                                                BURL = objClientAPIList[B].APIURL + "/";
                                                BConsumerKey = objClientAPIList[B].ConsumerKey;
                                                BCOnsumerSecretKey = objClientAPIList[B].ConsumerSecret;
                                                BPID = objClientAPIList[B].ProviderID;
                                                BProviderName = objClientAPIList[B].ProviderName;
                                                Tbus = BITLA(BURL, BConsumerKey, BCOnsumerSecretKey, BPID, BProviderName, BSID, BDID, BDate);
                                                if (Tbus != null)
                                                {
                                                    if (Tbus.Count() > 0)
                                                    {
                                                        bus = trips(Tbus);
                                                    }
                                                }

                                            }
                                        }
                                    }



                                }
                                else if (objClientAPIList[i].ProviderName == "KALLADA")
                                {
                                    int kD = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[kD], sourceId, destinationId, dateofjourney);
                                    if (KDsource_ids.ToString() != "" && KDDestination_Ids.ToString() != "")
                                    {
                                        string[] KDsu = KDsource_ids.Split(',');
                                        string[] KDdu = KDDestination_Ids.Split(',');
                                        string[] KSdr = KDsu.Distinct().ToArray();
                                        string[] KDdr = KDdu.Distinct().ToArray();
                                        foreach (string Ksr in KSdr)
                                        {
                                            foreach (string Kdr in KDdr)
                                            {

                                                KDSID = Convert.ToInt32(Ksr);
                                                KDDID = Convert.ToInt32(Kdr);
                                                KDDate = objBusesSearchFilter.JourneyDate;
                                                KDURL = objClientAPIList[kD].APIURL;
                                                KDConsumerKey = objClientAPIList[kD].ConsumerKey;
                                                KDCOnsumerSecretKey = objClientAPIList[kD].ConsumerSecret;
                                                KDProviderName = objClientAPIList[kD].ProviderName;
                                                Kbus = KALLADA(KDURL, KDConsumerKey, KDCOnsumerSecretKey, KDProviderName, KDSID, KDDID, KDDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "SAIANJANA")
                                {
                                    int s = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[s], sourceId, destinationId, dateofjourney);
                                    if (SSsource_ids.ToString() != "" && SSDestination_Ids.ToString() != "")
                                    {
                                        string[] SSsu = SSsource_ids.Split(',');
                                        string[] SSdu = SSDestination_Ids.Split(',');
                                        string[] SSdr = SSsu.Distinct().ToArray();
                                        string[] SDdr = SSdu.Distinct().ToArray();
                                        foreach (string Ssr in SSdr)
                                        {
                                            foreach (string Sdr in SDdr)
                                            {
                                                SSID = Convert.ToInt32(Ssr);
                                                SDID = Convert.ToInt32(Sdr);
                                                SDate = objBusesSearchFilter.JourneyDate;
                                                SURL = objClientAPIList[s].APIURL;
                                                SConsumerKey = objClientAPIList[s].ConsumerKey;
                                                SCOnsumerSecretKey = objClientAPIList[s].ConsumerSecret;
                                                SProviderName = objClientAPIList[s].ProviderName;
                                                Kbus = SAIANJANA(SURL, SConsumerKey, SCOnsumerSecretKey, SProviderName, SSID, SDID, SDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);

                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "SVR")
                                {
                                    int sv = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[sv], sourceId, destinationId, dateofjourney);
                                    if (Ssource_ids.ToString() != "" && SDestination_Ids.ToString() != "")
                                    {
                                        string[] sssu = Ssource_ids.Split(',');
                                        string[] ssdu = SDestination_Ids.Split(',');
                                        string[] SSSdr = sssu.Distinct().ToArray();
                                        string[] SSDdr = ssdu.Distinct().ToArray();
                                        foreach (string SSsr in SSSdr)
                                        {
                                            foreach (string SSdr in SSDdr)
                                            {

                                                SVSID = Convert.ToInt32(SSsr);
                                                SVDID = Convert.ToInt32(SSdr);
                                                SVDate = objBusesSearchFilter.JourneyDate;
                                                SVURL = objClientAPIList[sv].APIURL;
                                                SVConsumerKey = objClientAPIList[sv].ConsumerKey;
                                                SVCOnsumerSecretKey = objClientAPIList[sv].ConsumerSecret;
                                                SVProviderName = objClientAPIList[sv].ProviderName;
                                                Kbus = GETSVR(SVURL, SVConsumerKey, SVCOnsumerSecretKey, SVProviderName, SVSID, SVDID, SVDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "RAJESH")
                                {
                                    int r = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[r], sourceId, destinationId, dateofjourney);
                                    if (Rsource_ids.ToString() != "" && RDestination_Ids.ToString() != "")
                                    {
                                        string[] Rsu = Rsource_ids.Split(',');
                                        string[] Rdu = RDestination_Ids.Split(',');
                                        string[] RSdr = Rsu.Distinct().ToArray();
                                        string[] RDdr = Rdu.Distinct().ToArray();
                                        foreach (string Rsr in RSdr)
                                        {
                                            foreach (string Rdr in RDdr)
                                            {
                                                RSID = Convert.ToInt32(Rsr);
                                                RDID = Convert.ToInt32(Rdr);
                                                RDate = objBusesSearchFilter.JourneyDate;
                                                RURL = objClientAPIList[r].APIURL;
                                                RConsumerKey = objClientAPIList[r].ConsumerKey;
                                                RCOnsumerSecretKey = objClientAPIList[r].ConsumerSecret;
                                                RProviderName = objClientAPIList[r].ProviderName;
                                                Kbus = Rajesh(RURL, RConsumerKey, RCOnsumerSecretKey, RProviderName, RSID, RDID, RDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);
                                                        //HttpRuntime.Cache["bus"] = Tbus;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "KAVERI")
                                {
                                    int k = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[k], sourceId, destinationId, dateofjourney);
                                    if (Ksource_ids.ToString() != "" && KDestination_Ids.ToString() != "")
                                    {
                                        string[] Ksu = Ksource_ids.Split(',');
                                        string[] Kdu = KDestination_Ids.Split(',');
                                        string[] KSdr = Ksu.Distinct().ToArray();
                                        string[] KDdr = Kdu.Distinct().ToArray();
                                        foreach (string Ksr in KSdr)
                                        {
                                            foreach (string Kdr in KDdr)
                                            {
                                                KSID = Convert.ToInt32(Ksr);
                                                KDID = Convert.ToInt32(Kdr);
                                                KDate = objBusesSearchFilter.JourneyDate;
                                                KURL = objClientAPIList[i].APIURL;
                                                KConsumerKey = objClientAPIList[k].ConsumerKey;
                                                KCOnsumerSecretKey = objClientAPIList[k].ConsumerSecret;
                                                KProviderName = objClientAPIList[k].ProviderName;
                                                Kbus = KAVERI(KURL, KConsumerKey, KCOnsumerSecretKey, KProviderName, KSID, KDID, KDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);
                                                        //HttpRuntime.Cache["Kbus"] = Kbus;

                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                //easy bus 17-05-2013
                                else if (objClientAPIList[i].ProviderName == "EASYBUS")
                                {
                                    int E = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[E], sourceId, destinationId, dateofjourney);
                                    if (Esource_ids.ToString() != "" && EDestination_Ids.ToString() != "")
                                    {
                                        string[] Esu = Esource_ids.Split(',');
                                        string[] Edu = EDestination_Ids.Split(',');
                                        string[] ESdr = Esu.Distinct().ToArray();
                                        string[] EDdr = Edu.Distinct().ToArray();
                                        foreach (string Esr in ESdr)
                                        {
                                            foreach (string Edr in EDdr)
                                            {

                                                ESID = Convert.ToInt32(Esr);
                                                EDID = Convert.ToInt32(Edr);
                                                EDate = dateofjourney;
                                                EURL = objClientAPIList[E].APIURL;
                                                EConsumerKey = objClientAPIList[E].ConsumerKey;
                                                ECOnsumerSecretKey = objClientAPIList[E].ConsumerSecret;
                                                EProviderName = objClientAPIList[E].ProviderName;
                                                Kbus = EASY(EURL, EConsumerKey, ECOnsumerSecretKey, EProviderName, ESID, EDID, EDate);
                                                if (Kbus != null)
                                                {
                                                    if (Kbus.Count() > 0)
                                                    {
                                                        bus = trips(Kbus);
                                                    }
                                                }

                                            }
                                        }
                                    }

                                }
                            });
                            // threat initialisation ends

                            if (c == true)
                            {
                                thread[i].Start();
                                thread[i].Join(500);
                                if (i == thread.Count() - 1)
                                {
                                    i = thread.Count() - 1;
                                    break;
                                }
                            }

                        }
                    }
                }

                if (resultSetIndex != 2)
                {

                Found:
                    int j = 0;
                    foreach (var thd in thread)
                    {
                        if (thd.IsAlive)
                        {
                            thd.Join(1000);
                            b = false;
                        }
                        else
                        {
                            j++;
                        }
                        if (j == threadcount)
                        {
                            b = true;
                            i = 0;
                            break;
                        }


                    }

                    if (c == true)
                    {
                        c = false;
                    }
                    if (b == false)
                    {
                        goto Found;
                    }
                    else
                    {
                        b = false;
                        //check if resultset index exceeds accessible providers list call the requested api
                        if (resultSetIndex > 0 && resultSetIndex <= objClientAPIList.Count)
                        {
                            try
                            {
                                // objBusesAvailabilityResponse.availableTrips = GetAvailableTripsByProviderName(objClientAPIList[i], objBusesSearchFilter);
                                objBusesAvailabilityResponse.responseStatus = HttpStatusCode.OK;

                            }
                            catch (Exception ex)
                            {
                                //return the exception
                                objBusesAvailabilityResponse.availableTrips = null;
                                objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                                objBusesAvailabilityResponse.message = ex.Message;
                            }
                            if (objBusesAvailabilityResponse.providersCount == 10)
                            {
                                objBusesAvailabilityResponse.providersCount = 0;
                            }
                            else
                            {
                                objBusesAvailabilityResponse.providersCount = 0;
                                //  objBusesAvailabilityResponse.providersCount = objClientAPIList.Count - resultSetIndex;
                            }
                        }
                        else
                        {
                            objBusesAvailabilityResponse.providersCount = 0;
                            objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                        }
                    }
                }
                if (HttpContext.Current.Session["AvailResponse"] == null)
                {
                    objBusesAvailabilityResponse.availableTrips = bus;
                    HttpContext.Current.Session["AvailResponse"] = objBusesAvailabilityResponse;
                    HttpRuntime.Cache["bus"] = "";
                }
                else
                {
                bump:
                    if (HttpRuntime.Cache["bus"].ToString() != "")
                    {
                        Tbus = (AvailableTrips)HttpRuntime.Cache["bus"];

                        if (Tbus.Count() > 0)
                        {
                            BusesAvailabilityResponse busback = new BusesAvailabilityResponse();
                            Tbus = (AvailableTrips)HttpRuntime.Cache["bus"];
                            busback = (BusesAvailabilityResponse)HttpContext.Current.Session["AvailResponse"];
                            bus = trips((AvailableTrips)busback.availableTrips);
                            bus = trips(Tbus);
                            busback.availableTrips = bus;
                            busback.responseStatus = HttpStatusCode.OK;
                            busback.providersCount = 0;
                            HttpContext.Current.Session["AvailResponse"] = busback;
                            objBusesAvailabilityResponse.availableTrips = Tbus;
                            objBusesAvailabilityResponse.responseStatus = HttpStatusCode.OK;
                            objBusesAvailabilityResponse.providersCount = 0;
                            HttpRuntime.Cache["bus"] = "";

                        }

                    }
                    else
                    {
                        objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                        if (objClientAPIList[1].ProviderName == "TICKETGOOSE")
                        {
                            goto bump;
                        }
                        else
                        {

                        }
                    }

                }
                return JsonConvert.SerializeObject(objBusesAvailabilityResponse);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        AvailableTrips AvailBuses = new AvailableTrips();
        public string GetAvailableTrips2(int sourceId, int destinationId, String dateofjourney, Int16 resultSetIndex, String ConsumerKey, String ConsumerSecret)
        {
            try
            {
                ClientAPIList objClientAPIList = new ClientAPIList();
                BusesAvailabilityResponse objBusesAvailabilityResponse = new BusesAvailabilityResponse();
                if (resultSetIndex != 2)
                {
                    HttpContext.Current.Session["AvailResponse"] = null;
                    HttpRuntime.Cache["bus"] = "";

                    //Check if Cache already contains the Providers API List
                    //Else get it from database        
                    GetAPIProvidersList(ConsumerKey, ConsumerSecret);
                    objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                    //Check if atleast one provider is accessible
                    if (objClientAPIList != null && objClientAPIList.Count > 0)
                    {
                        BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter();
                        threadcount = Convert.ToInt32(objClientAPIList.Count());
                        thread = new Thread[threadcount];
                        for (i = 0; i < thread.Count(); i++)
                        {
                            thread[i] = new Thread(() =>
                            {
                                if (objClientAPIList[i].ProviderName == "TICKETGOOSE")
                                {
                                    int T = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[T], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        TSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        TDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        TDate = objBusesSearchFilter.JourneyDate;
                                        TURL = objClientAPIList[T].APIURL;
                                        TConsumerKey = objClientAPIList[T].ConsumerKey;
                                        TCOnsumerSecretKey = objClientAPIList[T].ConsumerSecret;
                                        TPID = objClientAPIList[T].ProviderID;
                                        Tbus = Ticketgoose(TURL, TConsumerKey, TCOnsumerSecretKey, TPID, TSID, TDID, TDate);
                                        if (Tbus != null)
                                        {
                                            if (Tbus.Count() > 0)
                                            {
                                                bus = trips(Tbus);
                                                HttpRuntime.Cache["bus"] = Tbus;
                                                objBusesAvailabilityResponse.providersCount = 10;
                                            }

                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "MORNINGSTAR")
                                {
                                    int M = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[M], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        MSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        MDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        MDate = objBusesSearchFilter.JourneyDate;
                                        MURL = objClientAPIList[M].APIURL + "/";
                                        MConsumerKey = objClientAPIList[M].ConsumerKey;
                                        MCOnsumerSecretKey = objClientAPIList[M].ConsumerSecret;
                                        MPID = objClientAPIList[M].ProviderID;
                                        MProviderName = objClientAPIList[M].ProviderName;
                                        Tbus = MORNINGSTAR(MURL, MConsumerKey, MCOnsumerSecretKey, MPID, MProviderName, MSID, MDID, MDate);
                                        if (Tbus != null)
                                        {
                                            if (Tbus.Count() > 0)
                                            {
                                                bus = trips(Tbus);
                                            }

                                            // b = true;
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "BITLA")
                                {
                                    int B = i;
                                    bus = GETBITLROUTES(objBusesSearchFilter, objClientAPIList[B], sourceId, destinationId, dateofjourney);

                                }
                                else if (objClientAPIList[i].ProviderName == "KALLADA")
                                {
                                    int kD = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[kD], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        KDSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        KDDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        KDDate = objBusesSearchFilter.JourneyDate;
                                        KDURL = objClientAPIList[kD].APIURL;
                                        KDConsumerKey = objClientAPIList[kD].ConsumerKey;
                                        KDCOnsumerSecretKey = objClientAPIList[kD].ConsumerSecret;
                                        KDProviderName = objClientAPIList[kD].ProviderName;
                                        Kbus = KALLADA(KDURL, KDConsumerKey, KDCOnsumerSecretKey, KDProviderName, KDSID, KDDID, KDDate);
                                        if (Kbus != null)
                                        {
                                            if (Kbus.Count() > 0)
                                            {
                                                bus = trips(Kbus);
                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "SAIANJANA")
                                {
                                    int s = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[s], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        SSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        SDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        SDate = objBusesSearchFilter.JourneyDate;
                                        SURL = objClientAPIList[s].APIURL;
                                        SConsumerKey = objClientAPIList[s].ConsumerKey;
                                        SCOnsumerSecretKey = objClientAPIList[s].ConsumerSecret;
                                        SProviderName = objClientAPIList[s].ProviderName;
                                        Kbus = SAIANJANA(SURL, SConsumerKey, SCOnsumerSecretKey, SProviderName, SSID, SDID, SDate);
                                        if (Kbus != null)
                                        {
                                            if (Kbus.Count() > 0)
                                            {
                                                bus = trips(Kbus);

                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "SVR")
                                {
                                    int sv = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[sv], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        SVSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        SVDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        SVDate = objBusesSearchFilter.JourneyDate;
                                        SVURL = objClientAPIList[sv].APIURL;
                                        SVConsumerKey = objClientAPIList[sv].ConsumerKey;
                                        SVCOnsumerSecretKey = objClientAPIList[sv].ConsumerSecret;
                                        SVProviderName = objClientAPIList[sv].ProviderName;
                                        Kbus = GETSVR(SVURL, SVConsumerKey, SVCOnsumerSecretKey, SVProviderName, SVSID, SVDID, SVDate);
                                        if (Kbus != null)
                                        {
                                            if (Kbus.Count() > 0)
                                            {
                                                bus = trips(Kbus);
                                            }
                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "RAJESH")
                                {
                                    int r = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[r], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        RSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        RDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        RDate = objBusesSearchFilter.JourneyDate;
                                        RURL = objClientAPIList[r].APIURL;
                                        RConsumerKey = objClientAPIList[r].ConsumerKey;
                                        RCOnsumerSecretKey = objClientAPIList[r].ConsumerSecret;
                                        RProviderName = objClientAPIList[r].ProviderName;
                                        Kbus = Rajesh(RURL, RConsumerKey, RCOnsumerSecretKey, RProviderName, RSID, RDID, RDate);
                                        if (Kbus != null)
                                        {
                                            if (Kbus.Count() > 0)
                                            {
                                                bus = trips(Kbus);
                                                //HttpRuntime.Cache["bus"] = Tbus;
                                            }

                                        }
                                    }
                                }
                                else if (objClientAPIList[i].ProviderName == "KAVERI")
                                {
                                    int k = i;
                                    objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIList[k], sourceId, destinationId, dateofjourney);
                                    if (objBusesSearchFilter.SourceID > 0 && objBusesSearchFilter.DestinationID > 0)
                                    {
                                        KSID = Convert.ToInt32(objBusesSearchFilter.SourceID);
                                        KDID = Convert.ToInt32(objBusesSearchFilter.DestinationID);
                                        KDate = objBusesSearchFilter.JourneyDate;
                                        KURL = objClientAPIList[i].APIURL;
                                        KConsumerKey = objClientAPIList[k].ConsumerKey;
                                        KCOnsumerSecretKey = objClientAPIList[k].ConsumerSecret;
                                        KProviderName = objClientAPIList[k].ProviderName;
                                        Kbus = KAVERI(KURL, KConsumerKey, KCOnsumerSecretKey, KProviderName, KSID, KDID, KDate);
                                        if (Kbus != null)
                                        {
                                            if (Kbus.Count() > 0)
                                            {
                                                bus = trips(Kbus);
                                                //HttpRuntime.Cache["Kbus"] = Kbus;

                                            }

                                        }
                                    }
                                }
                            });
                            // threat initialisation ends

                            if (c == true)
                            {
                                thread[i].Start();
                                thread[i].Join(500);
                                if (i == thread.Count() - 1)
                                {
                                    i = thread.Count() - 1;
                                    break;
                                }
                            }

                        }
                    }
                }

                if (resultSetIndex != 2)
                {

                Found:
                    int j = 0;
                    foreach (var thd in thread)
                    {
                        if (thd.IsAlive)
                        {
                            thd.Join(1000);
                            b = false;
                        }
                        else
                        {
                            j++;
                        }
                        if (j == threadcount)
                        {
                            b = true;
                            i = 0;
                            break;
                        }


                    }

                    if (c == true)
                    {
                        c = false;
                    }
                    if (b == false)
                    {
                        goto Found;
                    }
                    else
                    {
                        b = false;
                        //check if resultset index exceeds accessible providers list call the requested api
                        if (resultSetIndex > 0 && resultSetIndex <= objClientAPIList.Count)
                        {
                            try
                            {
                                // objBusesAvailabilityResponse.availableTrips = GetAvailableTripsByProviderName(objClientAPIList[i], objBusesSearchFilter);
                                objBusesAvailabilityResponse.responseStatus = HttpStatusCode.OK;

                            }
                            catch (Exception ex)
                            {
                                //return the exception
                                objBusesAvailabilityResponse.availableTrips = null;
                                objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                                objBusesAvailabilityResponse.message = ex.Message;
                            }
                            if (objBusesAvailabilityResponse.providersCount == 10)
                            {
                                objBusesAvailabilityResponse.providersCount = 0;
                            }
                            else
                            {
                                objBusesAvailabilityResponse.providersCount = objClientAPIList.Count - resultSetIndex;
                            }
                        }
                        else
                        {
                            objBusesAvailabilityResponse.providersCount = 0;
                            objBusesAvailabilityResponse.responseStatus = HttpStatusCode.BadRequest;
                        }
                    }
                }
                if (HttpContext.Current.Session["AvailResponse"] == null)
                {
                    objBusesAvailabilityResponse.availableTrips = bus;
                    HttpContext.Current.Session["AvailResponse"] = objBusesAvailabilityResponse;
                    HttpRuntime.Cache["bus"] = "";
                }
                else
                {
                bump:
                    if (HttpRuntime.Cache["bus"].ToString() != "")
                    {
                        Tbus = (AvailableTrips)HttpRuntime.Cache["bus"];

                        if (Tbus.Count() > 0)
                        {
                            BusesAvailabilityResponse busback = new BusesAvailabilityResponse();
                            Tbus = (AvailableTrips)HttpRuntime.Cache["bus"];
                            busback = (BusesAvailabilityResponse)HttpContext.Current.Session["AvailResponse"];
                            bus = trips((AvailableTrips)busback.availableTrips);
                            bus = trips(Tbus);
                            busback.availableTrips = bus;
                            busback.responseStatus = HttpStatusCode.OK;
                            busback.providersCount = 0;
                            HttpContext.Current.Session["AvailResponse"] = busback;
                            objBusesAvailabilityResponse.availableTrips = Tbus;
                            objBusesAvailabilityResponse.responseStatus = HttpStatusCode.OK;
                            objBusesAvailabilityResponse.providersCount = 0;
                            HttpRuntime.Cache["bus"] = "";

                        }

                    }
                    else
                    {
                        objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                        if (objClientAPIList[1].ProviderName == "TICKETGOOSE")
                        {
                            goto bump;
                        }
                        else
                        {

                        }
                    }

                }
                return JsonConvert.SerializeObject(objBusesAvailabilityResponse);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private AvailableTrips SVR(string SVRAPIURL, string SVRConsumerKey, string SVRConsumerSecret, string SVRProviderName, int SVRsourceid, int SVRdestinationid, string SVRdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            List<object> objlist = new List<object>();
            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(SVRsourceid
                                , SVRdestinationid
                                , SVRdate
                                , 6
                                , "0"
                                , SVRAPIURL
                                , SVRConsumerKey
                                , SVRProviderName
                                );
            return objAvailableTrips;
        }
        private AvailableTrips SAIANJANA(string SAIAPIURL, string SAIConsumerKey, string SAIConsumerSecret, string SAIProviderName, int SAIsourceid, int SAIdestinationid, string SAIdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            List<object> objlist = new List<object>();

            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(SAIsourceid
                                , SAIdestinationid
                                , SAIdate
                                , 6
                                , "0"
                                , SAIAPIURL
                                , SAIConsumerKey
                                , SAIProviderName
                                );
            return objAvailableTrips;
        }
        private AvailableTrips Rajesh(string RAJESHAPIURL, string RAJESHConsumerKey, string RAJESHConsumerSecret, string RAJESHProviderName, int RAJESHsourceid, int RAJESHdestinationid, string RAJESHdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            List<object> objlist = new List<object>();

            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(RAJESHsourceid
                                , RAJESHdestinationid
                                , RAJESHdate
                                , 6
                                , "0"
                                , RAJESHAPIURL
                                , RAJESHConsumerKey
                                , RAJESHProviderName);


            return objAvailableTrips;
        }
        private AvailableTrips KALLADA(string KALLADAAPIURL, string KALLADAConsumerKey, string KALLADAConsumerSecret, string KALLADAProviderName, int KALLADAsourceid, int KALLADAdestinationid, string KALLADAdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(KALLADAsourceid
                                , KALLADAdestinationid
                                , KALLADAdate
                                , 6
                                , "0"
                                , KALLADAAPIURL
                                , KALLADAConsumerKey
                                , KALLADAProviderName);
            return objAvailableTrips;
        }
        private AvailableTrips KAVERI(string KAVERIAPIURL, string KAVERIConsumerKey, string KAVERIConsumerSecret, string KAVERIProviderName, int KAVERIsourceid, int KAVERIdestinationid, string KAVERIdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(KAVERIsourceid
                                , KAVERIdestinationid
                                , KAVERIdate
                                , 6
                                , "0"
                                , KAVERIAPIURL
                                , KAVERIConsumerKey
                                , KAVERIProviderName);
            return objAvailableTrips;
        }
        private AvailableTrips Ticketgoose(string TAPIURL, string TConsumerKey, string TConsumerSecret, int TPID, int Tsourceid, int Tdestinationid, string Tdate)
        {
            BusesAvailabilityResponse objBusesAvailabilityResponse = new BusesAvailabilityResponse();
            BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter();
            AvailableTrips objAvailableTrips = new AvailableTrips();

            TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
            objAvailableTrips = clsTicketGooseAPI.getTripListV2(Tsourceid
                                , Tdestinationid
                                , Tdate
                                , TAPIURL
                                , TConsumerKey
                                , TConsumerSecret, TPID);

            return objAvailableTrips;
        }
        private AvailableTrips GETSVR(string SVRAPIURL, string SVRConsumerKey, string SVRConsumerSecret, string SVRProviderName, int SVRsourceid, int SVRdestinationid, string SVRdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            List<object> objlist = new List<object>();

            AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
            objAvailableTrips = clsAbhibusAPI.getBusAvailability(SVRsourceid
                                , SVRdestinationid
                                , SVRdate
                                , 6
                                , "0"
                                , SVRAPIURL
                                , SVRConsumerKey
                                , SVRProviderName
                                );
            return objAvailableTrips;
        }
        private AvailableTrips MORNINGSTAR(string MAPIURL, string MConsumerKey, string MConsumerSecret, int MRPID, string MpName, int Msourceid, int Mdestinationid, string Mdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            BitlaAPI clsBitlaAPI = new BitlaAPI();
            objAvailableTrips = clsBitlaAPI.MRgetAvailableRoutes(Msourceid
                                , Mdestinationid
                                , Mdate
                                , MAPIURL
                                , MConsumerKey, MRPID, MpName);
            return objAvailableTrips;
        }
        private AvailableTrips BITLA(string BAPIURL, string BConsumerKey, string BConsumerSecret, int BPID, string BPName, int Bsourceid, int Bdestinationid, string Bdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            BitlaAPI clsBitlaAPI = new BitlaAPI();
            objAvailableTrips = clsBitlaAPI.getAvailableRoutes(Convert.ToInt32(Bsourceid), Convert.ToInt32(Bdestinationid), Bdate, BAPIURL, BConsumerKey, BPID);
            return objAvailableTrips;
        }
        //easy bus 17-05-2013
        private AvailableTrips EASY(string EASYAPIURL, string EASYConsumerKey, string EASYConsumerSecret, string EASYProviderName, int EASYsourceid, int EASYdestinationid, string EASYdate)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            EasybusAPI clsEasyBusAPI = new EasybusAPI();
            objAvailableTrips = clsEasyBusAPI.getAvailableServices(EASYsourceid
                                , EASYdestinationid
                                , EASYdate
                                , EASYAPIURL
                                , EASYConsumerKey
                                , EASYProviderName);
            return objAvailableTrips;
        }
        #endregion

        public AvailableTrips trips(AvailableTrips objavailtrips)
        {
            BusesAvailabilityResponse objBusesAvailabilityResponse = new BusesAvailabilityResponse();
            foreach (var t in objavailtrips)
            {
                AvailableTrips1 trip = new AvailableTrips1();
                trip.arrivalTime = t.arrivalTime;
                trip.availableSeats = t.availableSeats;
                trip.boardingTimes = t.boardingTimes;
                trip.busType = t.busType;
                trip.cancellationPolicy = t.cancellationPolicy;
                trip.departureTime = t.departureTime;
                trip.destinationId = t.destinationId;
                trip.droppingTimes = t.droppingTimes;
                trip.duration = t.duration;
                trip.fares = t.fares;
                trip.id = t.id;
                trip.SeatLayoutId = t.SeatLayoutId;
                trip.partialCancellationAllowed = t.partialCancellationAllowed;
                trip.providerName = t.providerName;
                trip.sourceId = t.sourceId;
                trip.travels = t.travels;
                tripdetails.Add(trip);
            }

            return tripdetails;
        }


        public string GetTripDetails(String tripId, int sourceId, int destinationId, String markUpFare, String SeatLayoutId, String journeyDate, String provider, String ConsumerKey, String ConsumerSecret)
        {
            try
            {
                if (HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] == null)
                    GetAPIProvidersList(ConsumerKey, ConsumerSecret);

                ClientAPIList objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                ClientAPIDetails objClientAPIDetails = objClientAPIList.SingleOrDefault(element => element.ProviderName == provider); //objClientAPIList.ElementAt(resultSet - 1)
                BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter(sourceId, destinationId, journeyDate);

                SeatsInfo objSeatsInfo = GetTripDetailsByProviderName(objClientAPIDetails, objBusesSearchFilter, tripId, markUpFare, SeatLayoutId);
                if (provider == "TICKETGOOSE")
                {
                    //objSeatsInfo = GetSeatLayoutTG(objSeatsInfo);
                    objSeatsInfo = TestGetSeatLayout(objSeatsInfo);
                }
                else if (provider == "BITLA" || provider == "MORNINGSTAR")
                {
                    //objSeatsInfo = GetSeatLayoutTG(objSeatsInfo);
                    objSeatsInfo = BITLAGetSeatLayout(objSeatsInfo);
                }
                //easy bus 18-05-2013
                else if (provider == "EASYBUS")
                {
                    objSeatsInfo = GetSeatLayout(objSeatsInfo);
                }
                else
                {
                    objSeatsInfo = GetSeatLayout(objSeatsInfo);
                }
                //return JsonConvert.SerializeObject(GetSeatLayout(objSeatsInfo));
                return JsonConvert.SerializeObject(objSeatsInfo);

            }
            catch (Exception ex)
            {
                throw ex;
                // throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
                //to do
                //Log Exception
            }
        }

        public string BlockTicket(BlockSeats blockSeats, String ConsumerKey, String ConsumerSecret)
        {
            if (ValidateRequest(ConsumerKey, ConsumerSecret))
            {
                ClientAPIList objClientAPIList = new ClientAPIList();

                if (HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] == null)
                    GetAPIProvidersList(ConsumerKey, ConsumerSecret);


                objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                ClientAPIDetails objClientAPIDetails = objClientAPIList.SingleOrDefault(element => element.ProviderName == blockSeats.ProviderName);
                //BusesSearchFilter objBusesSearchFilter = new BusesSearchFilter();
                //objBusesSearchFilter = GetCityIDsOfProviders(objBusesSearchFilter, objClientAPIDetails, blockSeats.SourceId, blockSeats.DestinationId, blockSeats.JourneyDate);

                BlockSeatsResponse objBlockResponse = new BlockSeatsResponse();
                try
                {
                    switch (blockSeats.ProviderName)
                    {
                        case "BITLA":
                        case "MORNINGSTAR":
                            BitlaAPI clsBitlaAPI = new BitlaAPI();
                            objBlockResponse = clsBitlaAPI.validateTicket(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.TripId,
                                objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, blockSeats.NoOfSeats, blockSeats.BoardingId.ToString(), blockSeats.SeatNo, blockSeats.Title, blockSeats.Name,
                                blockSeats.Age, blockSeats.Sex, blockSeats.Address, blockSeats.BookingRefNo, blockSeats.IdCardType, blockSeats.IdCardNo, blockSeats.IdCardIssuedBy,
                                blockSeats.MobileNo, blockSeats.EmergencyMobileNo, blockSeats.EmailId);
                            break;
                        case "TICKETGOOSE":
                            TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                            objBlockResponse = clsTicketGooseAPI.blockSeatsForBooking(blockSeats.TripId, blockSeats.JourneyDate, blockSeats.SourceId.ToString(), blockSeats.DestinationId.ToString(), blockSeats.BoardingId,
                                blockSeats.EmailId, blockSeats.MobileNo, blockSeats.Address[0].ToString(), objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, objClientAPIDetails.ConsumerSecret,
                                blockSeats.NoOfSeats, blockSeats.SeatNo, blockSeats.Title, blockSeats.Name, blockSeats.Age, blockSeats.Sex);
                            break;
                        case "ABHIBUS":
                        case "SVR":
                        case "KALLADA":
                        case "KAVERI":
                        case "RAJESH":
                        case "SAIANJANA":
                            AbhibusAPI clsAbhiBusAPI = new AbhibusAPI();
                            objBlockResponse = clsAbhiBusAPI.getBlockTicket(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.JourneyDate, blockSeats.TripId, blockSeats.SeatNo, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey);
                            break;
                        case "EASYBUS":
                            EasybusAPI clsEasyBusAPI = new EasybusAPI();
                            objBlockResponse = clsEasyBusAPI.getBlockTicket(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.JourneyDate, blockSeats.TripId, blockSeats.SeatNo, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey);

                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    //
                }
                return JsonConvert.SerializeObject(objBlockResponse);
            }
            else
            {
                return null;
                //throw new http exception
                //throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        public string BookTicket(BlockSeats blockSeats, String ConsumerKey, String ConsumerSecret)
        {
            if (ValidateRequest(ConsumerKey, ConsumerSecret))
            {
                ClientAPIList objClientAPIList = new ClientAPIList();

                //if (HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] == null)
                GetAPIProvidersList(ConsumerKey, ConsumerSecret);
                objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];
                ClientAPIDetails objClientAPIDetails = objClientAPIList.SingleOrDefault(element => element.ProviderName == blockSeats.ProviderName);
                BookSeatsResponse objBookResponse = new BookSeatsResponse();
                if (objClientAPIDetails != null)
                {
                    try
                    {
                        switch (blockSeats.ProviderName)
                        {
                            case "BITLA":
                            case "MORNINGSTAR":
                                BitlaAPI clsBitlaAPI = new BitlaAPI();
                                objBookResponse = clsBitlaAPI.bookTicket(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.TripId,
                                    objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, blockSeats.NoOfSeats, blockSeats.BoardingId.ToString(), blockSeats.SeatNo, blockSeats.Title, blockSeats.Name,
                                    blockSeats.Age, blockSeats.Sex, blockSeats.Address, blockSeats.BookingRefNo, blockSeats.IdCardType, blockSeats.IdCardNo, blockSeats.IdCardIssuedBy,
                                    blockSeats.MobileNo, blockSeats.EmergencyMobileNo, blockSeats.EmailId);
                                break;
                            case "TICKETGOOSE":
                                TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                                objBookResponse = clsTicketGooseAPI.BookTicket(blockSeats.BookingId, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, objClientAPIDetails.ConsumerSecret);
                                break;
                            case "ABHIBUS":
                            case "SVR":
                            case "KALLADA":
                            case "KAVERI":
                            case "RAJESH":
                            case "SAIANJANA":
                                AbhibusAPI clsAbhiBusAPI = new AbhibusAPI();
                                objBookResponse = clsAbhiBusAPI.bookSeats(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.JourneyDate
                                    , blockSeats.TripId, blockSeats.SeatNo, blockSeats.Title, blockSeats.Name, blockSeats.BoardingId, blockSeats.Address
                                    , blockSeats.Name, blockSeats.MobileNo, blockSeats.EmailId, blockSeats.BookingRefNo, objClientAPIDetails.APIURL
                                    , objClientAPIDetails.ConsumerKey);

                                objBookResponse.extraseatinfo = blockSeats.SourceId + "," + blockSeats.DestinationId + "," + blockSeats.JourneyDate
                              + "," + blockSeats.TripId + "," + blockSeats.SeatNo + "," + blockSeats.Title + "," + blockSeats.Name + "," + blockSeats.BoardingId + "," + blockSeats.Address
                              + "," + blockSeats.Name + "," + blockSeats.MobileNo + "," + blockSeats.EmailId + "," + blockSeats.BookingRefNo;
                                break;

                            case "EASYBUS":
                                EasybusAPI clsEasyBusAPI = new EasybusAPI();
                                objBookResponse = clsEasyBusAPI.bookSeats(blockSeats.SourceId, blockSeats.DestinationId, blockSeats.JourneyDate
                                    , blockSeats.TripId, blockSeats.SeatNo, blockSeats.Sex, blockSeats.Name, blockSeats.BoardingId, blockSeats.Address
                                    , blockSeats.Name, blockSeats.MobileNo, blockSeats.EmailId, blockSeats.BookingRefNo, objClientAPIDetails.APIURL
                                    , objClientAPIDetails.ConsumerKey);

                                objBookResponse.extraseatinfo = blockSeats.SourceId + "," + blockSeats.DestinationId + "," + blockSeats.JourneyDate
                              + "," + blockSeats.TripId + "," + blockSeats.SeatNo + "," + blockSeats.Title + "," + blockSeats.Name + "," + blockSeats.BoardingId + "," + blockSeats.Address
                              + "," + blockSeats.Name + "," + blockSeats.MobileNo + "," + blockSeats.EmailId + "," + blockSeats.BookingRefNo;

                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        objBookResponse.Message = ex.ToString();
                    }
                }
                else
                {
                    objBookResponse.Message = "no api found";
                }
                return JsonConvert.SerializeObject(objBookResponse);
            }
            else
            {
                return null;
                //throw new http exception
                //throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);

            }
        }

        public String CancelTicket(String bookingId, String seatNos, String ProviderName, String ConsumerKey, String ConsumerSecret)
        {
            if (ValidateRequest(ConsumerKey, ConsumerSecret))
            {
                ClientAPIList objClientAPIList = new ClientAPIList();

                if (HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] == null)
                    GetAPIProvidersList(ConsumerKey, ConsumerSecret);

                objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];

                ClientAPIDetails objClientAPIDetails = objClientAPIList.SingleOrDefault(element => element.ProviderName == ProviderName);

                String strCancelResponse = String.Empty;
                try
                {
                    switch (ProviderName)
                    {
                        case "BITLA":
                        case "MORNINGSTAR":
                            BitlaAPI clsBitlaAPI = new BitlaAPI();
                            strCancelResponse = clsBitlaAPI.cancelTicket(bookingId, seatNos, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey);
                            break;
                        case "TICKETGOOSE":
                            TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                            strCancelResponse = clsTicketGooseAPI.confirmTicketCancellation(bookingId, seatNos, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, objClientAPIDetails.ConsumerSecret);
                            break;
                        case "ABHIBUS":
                        case "SVR":
                        case "KALLADA":
                        case "KAVERI":
                        case "RAJESH":
                        case "SAIANJANA":
                            AbhibusAPI clsAbhiBusAPI = new AbhibusAPI();
                            strCancelResponse = "";//clsAbhiBusAPI.cancelTicket(objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, bookingId);
                            break;
                        case "EASYBUS":
                            EasybusAPI clsEasyBusAPI = new EasybusAPI();
                            strCancelResponse = "";//  clsEasyBusAPI.cancelTicket(bookingId, seatNos, objClientAPIDetails.APIURL, objClientAPIDetails.ConsumerKey, objClientAPIDetails.ConsumerSecret);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    //
                }
                return strCancelResponse;
            }
            else
            {
                return null;
                //throw new http exception
                // throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        public String StoreBitlaTrips(String URL, String fromDate, String toDate, String ConsumerKey)
        {
            BitlaAPI clsBitlaAPI = new BitlaAPI();
            return clsBitlaAPI.storeBitlaTrips(URL, fromDate, toDate, ConsumerKey);
        }

        public DataSet GetcallBack(string Resrvation_Id, string url, string ConsumerKey, string ConsumerSecret, string doj)
        {

            DataSet ds = new DataSet();
            ClientAPIList objClientAPIList = new ClientAPIList();
            GetAPIProvidersList(ConsumerKey, ConsumerSecret);

            objClientAPIList = (ClientAPIList)HttpContext.Current.Cache["ClientAPI-" + ConsumerKey];

            //Check if atleast one provider is accessible
            if (objClientAPIList != null && objClientAPIList.Count > 0)
            {
                objClientAPIList.Where(e => e.ProviderName == Convert.ToString("BITLA"));
                BitlaAPI bitla = new BitlaAPI();
                SeatsInfo seat = new SeatsInfo();
                seat = bitla.getServiceDetails(Resrvation_Id, objClientAPIList[0].APIURL, objClientAPIList[0].ConsumerKey);
                ds = convertJsonStringToDataSet(JsonConvert.SerializeObject(seat));

            }
            return ds;

        }

        #endregion
        public DataSet convertJsonStringToDataSet(string jsonString)
        {
            try
            {
                DataSet ds = new DataSet();
                XmlDocument xd = new XmlDocument();
                jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
                ds.ReadXml(new XmlNodeReader(xd));
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region Private Methods

        /// <summary>
        /// Method to get available trips for given provider
        /// </summary>
        /// <param name="ProviderName"></param>
        /// <param name="objClientAPIDetails"></param>
        /// <returns>Returns JSON string with list of available trips</returns>
        private AvailableTrips GetAvailableTripsByProviderName(ClientAPIDetails objClientAPIDetails, BusesSearchFilter objBusesSearchFilter)
        {
            AvailableTrips objAvailableTrips = new AvailableTrips();
            List<object> objlist = new List<object>();
            switch (objClientAPIDetails.ProviderName)
            {

                case "ABHIBUS":
                case "SVR":
                case "KALLADA":
                case "KAVERI":
                case "RAJESH":
                case "SAIANJANA":
                    AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
                    objAvailableTrips = clsAbhibusAPI.getBusAvailability(objBusesSearchFilter.SourceID
                                        , objBusesSearchFilter.DestinationID
                                        , objBusesSearchFilter.JourneyDate
                                        , 6
                                        , "0"
                                        , objClientAPIDetails.APIURL
                                        , objClientAPIDetails.ConsumerKey
                                        , objClientAPIDetails.ProviderName);
                    break;
                case "BITLA":
                case "MORNINGSTAR":
                    BitlaAPI clsBitlaAPI = new BitlaAPI();
                    objAvailableTrips = clsBitlaAPI.getAvailableRoutes(objBusesSearchFilter.SourceID
                                        , objBusesSearchFilter.DestinationID
                                        , objBusesSearchFilter.JourneyDate
                                        , objClientAPIDetails.APIURL
                                        , objClientAPIDetails.ConsumerKey, objClientAPIDetails.ProviderID);
                    break;
                case "TICKETGOOSE":
                    TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                    objAvailableTrips = clsTicketGooseAPI.getTripListV2(objBusesSearchFilter.SourceID
                                        , objBusesSearchFilter.DestinationID
                                        , objBusesSearchFilter.JourneyDate
                                        , objClientAPIDetails.APIURL
                                        , objClientAPIDetails.ConsumerKey
                                        , objClientAPIDetails.ConsumerSecret, objClientAPIDetails.ProviderID);
                    break;
                //easybus
                case "EASYBUS":
                    EasybusAPI clsEasyBusAPI = new EasybusAPI();

                    break;
                default:
                    break;

            }

            return objAvailableTrips;
        }

        /// <summary>
        /// Method to get available trips for given provider
        /// </summary>
        /// <param name="ProviderName"></param>
        /// <param name="objClientAPIDetails"></param>
        /// <returns>Returns JSON string with list of available trips</returns>
        private SeatsInfo GetTripDetailsByProviderName(ClientAPIDetails objClientAPIDetails, BusesSearchFilter objBusesSearchFilter, String tripId, String markUpFare, String SeatLayoutId)
        {
            SeatsInfo objSeatsInfo = new SeatsInfo();
            try
            {
                switch (objClientAPIDetails.ProviderName)
                {

                    case "ABHIBUS":
                    case "SVR":
                    case "KALLADA":
                    case "KAVERI":
                    case "RAJESH":
                    case "SAIANJANA":
                        AbhibusAPI clsAbhibusAPI = new AbhibusAPI();
                        objSeatsInfo = clsAbhibusAPI.getBusSeatLayout(objBusesSearchFilter.SourceID
                                            , objBusesSearchFilter.DestinationID
                                            , objBusesSearchFilter.JourneyDate
                                            , tripId
                                            , "0"
                                            , objClientAPIDetails.APIURL
                                            , objClientAPIDetails.ConsumerKey);
                        break;
                    case "BITLA":
                    case "MORNINGSTAR":
                        BitlaAPI clsBitlaAPI = new BitlaAPI();
                        objSeatsInfo = clsBitlaAPI.getServiceDetails(tripId
                                            , objClientAPIDetails.APIURL
                                            , objClientAPIDetails.ConsumerKey);

                        break;
                    case "TICKETGOOSE":
                        TicketGooseAPI clsTicketGooseAPI = new TicketGooseAPI();
                        objSeatsInfo = clsTicketGooseAPI.getTripDetailsV2(objBusesSearchFilter.SourceID
                                            , objBusesSearchFilter.DestinationID
                                            , objBusesSearchFilter.JourneyDate
                                            , tripId
                                            , objClientAPIDetails.APIURL
                                            , objClientAPIDetails.ConsumerKey
                                            , objClientAPIDetails.ConsumerSecret);
                        break;
                    //easy bus 18-05-2013
                    case "EASYBUS":
                        EasybusAPI clsEasyBusAPI = new EasybusAPI();
                        objSeatsInfo = clsEasyBusAPI.getLayoutDetails(objBusesSearchFilter.SourceID
                                            , objBusesSearchFilter.DestinationID
                                            , objBusesSearchFilter.JourneyDate
                                            , tripId
                                            , SeatLayoutId
                                            , markUpFare
                                            , "0"
                                            , objClientAPIDetails.APIURL
                                            , objClientAPIDetails.ConsumerKey);
                        break;
                    default:
                        break;
                }
                objSeatsInfo.providerName = objClientAPIDetails.ProviderName;
            }
            catch (Exception ex)
            {
                //to do
                //Log Exception
            }
            return objSeatsInfo;
        }

        /// <summary>
        /// Method to build seat layout HTML 
        /// </summary>
        /// <param name="objSeatsInfo"></param>
        /// <returns></returns>

        string number = string.Empty;


        DataRow[] drArrayMain;
        private SeatsInfo GetSeatLayout(SeatsInfo objSeatsInfo)
        {
            SeatsInfo objSeatsInfoResponse = new SeatsInfo();
            objSeatsInfoResponse = objSeatsInfo;

            BusesBaseClass _ = new BusesBaseClass();
            //Convert it to string and then to dataset
            //Supposed to use objSeatsInfo.Seats as it is. 
            DataSet dsMain = _.convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsInfo));

            if (dsMain != null)
            {
                DataTable dtMain = dsMain.Tables["seats"];
                StringBuilder sbSeatLayout = new StringBuilder();
                String[] response = new String[3];
                try
                {
                    if (dtMain.Rows.Count > 0)
                    {
                        #region Code to convert "Row" & "Column" columns to integer datatype

                        //create a copy of main table
                        DataTable dt = dtMain.Clone();
                        //set column datatypes for int values
                        dt.Columns["row"].DataType = Type.GetType("System.Int16");
                        dt.Columns["column"].DataType = Type.GetType("System.Int16");
                        dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");

                        DataRow[] drArray1 = dtMain.Select(String.Empty, "row ASC, column ASC, zIndex DESC");
                        // DataRow[] drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");
                        if (drArray1.Length > 0)
                        {
                            foreach (DataRow dr in drArray1)
                                dt.ImportRow(dr);
                        }

                        dt.AcceptChanges();

                        #endregion

                        var lengthCount = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().ToList();
                        var widthcount = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().ToList();
                        var rows = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                        //sleeper test
                        if (rows.Count() == 2 || rows.Count() == 3)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToInt32(row["column"]) >= 12)
                                {
                                    row["column"] = Convert.ToInt32(row["column"]) - 12;
                                    row["row"] = Convert.ToInt32(row["row"]) + 3;

                                }
                            }
                            dt.AcceptChanges();
                            var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();
                            var zindex = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();
                            var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();

                            //Used in exceptional cases where a bus has both seats and sleeper coaches
                            //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                            int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                            int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();
                            //sleeper test end
                            String strSeatType = String.Empty;
                            String strSeatCssSuffix = String.Empty;

                            if (rows.Count() == 2 || rows.Count() == 3)
                                sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                            else
                                sbSeatLayout.Append("<table align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 3px; margin: 3px; \"><tr><td colspan=\"2\">");

                            foreach (Int16 index in ColumnCount)
                            {
                                if (rows.Count() == 2 || rows.Count() == 3)
                                {
                                    //div tag is added to show border with same size for upper and lower decks
                                    sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 7px; margin: 3px; \">");
                                    //add steering image only once
                                    if (ColumnCount.IndexOf(index) == 1)
                                        sbSeatLayout.Append("<span class=\"steering_sl\" style=\"margin-top: 10px; \"/>");
                                    sbSeatLayout.Append("<table>");
                                }
                                else
                                    sbSeatLayout.Append("<div><span class=\"steering\"/><table>");

                                foreach (Int16 row in RowCount)
                                {
                                    #region Create datarow array

                                    //Get the actual row count to drArrayMain 
                                    if (rows.Count() == 2 || rows.Count() == 3)
                                    {
                                        drArrayMain = dt.Select("row = " + row, "column ASC");
                                    }

                                    //Create another array which is based on ColumnCount
                                    //This array will be used in below code
                                    DataRow[] drArray;//= new DataRow[ColumnCount.Count];

                                    ColumnCount.Sort();


                                    drArray = drArrayMain;


                                    #endregion

                                    //check if bus has different seat layouts. If so, do not float seats right
                                    if (maxLength == 1 || maxWidth == 1)
                                        sbSeatLayout.Append("<tr><td>");
                                    else
                                        sbSeatLayout.Append("<tr><td style=\"float: right\">");

                                    sbSeatLayout.Append("<ul class=\"seat_map\">");

                                    #region loop array and add seats

                                    if (rows.Count() == 3)
                                    {

                                        foreach (DataRow dr in drArray)
                                        {
                                            #region Set seat type seat/sleeper_v/sleeper_h

                                            // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                            if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                            {
                                                if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                                {
                                                    strSeatType = "Seat";
                                                    strSeatCssSuffix = "seat";
                                                }
                                                else if (int.Parse(dr["width"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_v";
                                                    strSeatCssSuffix = "sleeper_v";
                                                }
                                                else if (int.Parse(dr["length"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_h";
                                                    strSeatCssSuffix = "sleeper_h";
                                                }
                                            }

                                            #endregion

                                            //Check if datarow has empty seats, if so add empty spaces
                                            if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                            {
                                                //set appropriate class based on seat availability
                                                if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                                {
                                                    if (dr["number"] != "")
                                                    {
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                                    }
                                                }
                                                else
                                                {
                                                    if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                    else
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                    sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                    sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                    sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                    //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                                }

                                                //Seat number is properly displayed in Chrome and Firefox except IE. 
                                                //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                                //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                                sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                                sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                            }
                                            else
                                            {
                                                //check if drArray has no seats. If so, add li element to create walking bay
                                                if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                    sbSeatLayout.Append("<li>&nbsp;</li>");
                                            }
                                        }

                                    }
                                    else
                                    {


                                        foreach (DataRow dr in drArray)
                                        {
                                            #region Set seat type seat/sleeper_v/sleeper_h

                                            // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                            if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                            {
                                                if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                                {
                                                    strSeatType = "Seat";
                                                    strSeatCssSuffix = "seat";
                                                }
                                                else if (int.Parse(dr["width"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_v";
                                                    strSeatCssSuffix = "sleeper_v";
                                                }
                                                else if (int.Parse(dr["length"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_h";
                                                    strSeatCssSuffix = "sleeper_h";
                                                }
                                            }

                                            #endregion

                                            //Check if datarow has empty seats, if so add empty spaces
                                            if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                            {
                                                //set appropriate class based on seat availability
                                                if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                                {
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                                }
                                                else
                                                {
                                                    if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                    else
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                    sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                    sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                    sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                    //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                                }

                                                //Seat number is properly displayed in Chrome and Firefox except IE. 
                                                //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                                //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                                sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                                sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                            }
                                            else
                                            {
                                                //check if drArray has no seats. If so, add li element to create walking bay
                                                if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                    sbSeatLayout.Append("<li>&nbsp;</li>");
                                            }
                                        }
                                    }

                                    #endregion

                                    sbSeatLayout.Append("</ul>");
                                    sbSeatLayout.Append("</td></tr>");
                                }
                                sbSeatLayout.Append("</table></div>");
                            }


                        }
                        else
                        {


                            var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();

                            var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                            var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();




                            //Used in exceptional cases where a bus has both seats and sleeper coaches
                            //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                            int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                            int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();

                            String strSeatType = String.Empty;
                            String strSeatCssSuffix = String.Empty;

                            if (zIndexCount.Count > 1)
                                sbSeatLayout.Append("<table  align=\"center\"><tr><td colspan=\"2\">");
                            else
                                sbSeatLayout.Append("<table  align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 1px; margin: 3px; \"><tr><td colspan=\"2\">");

                            foreach (Int16 index in zIndexCount)
                            {
                                if (zIndexCount.Count > 1)
                                {
                                    //div tag is added to show border with same size for upper and lower decks
                                    sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 0px; margin: 1px; \">");
                                    //add steering image only once
                                    if (zIndexCount.IndexOf(index) > 0)
                                        sbSeatLayout.Append("<span class=\"steering_sl\" style=\"margin-top: 10px; \"/>");//class=\"steering\"
                                    sbSeatLayout.Append("<table >");
                                }
                                else
                                    sbSeatLayout.Append("<div><span class=\"steering\"/> <table >");//<span class=\"steering\"/>
                                foreach (Int16 row in RowCount)
                                {
                                    #region Create datarow array

                                    //Get the actual row count to drArrayMain 
                                    DataRow[] drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index, "column ASC");

                                    //Create another array which is based on ColumnCount
                                    //This array will be used in below code
                                    DataRow[] drArray;// = new DataRow[ColumnCount.Count];

                                    ColumnCount.Sort();

                                    //if (drArrayMain.Length != ColumnCount.Count)
                                    //{
                                    //    for (int i = 0; i < ColumnCount.Count; i++)
                                    //    {
                                    //        try
                                    //        {
                                    //            //check if main array contains a row with given column name
                                    //            //If so, assign it to other row else create a new row
                                    //            drArray[i] = drArrayMain.Single(p => int.Parse(p["column"].ToString()) == int.Parse(ColumnCount[i].ToString()));
                                    //        }
                                    //        catch
                                    //        {
                                    //            drArray[i] = dt.NewRow();
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    drArray = drArrayMain;
                                    // }

                                    #endregion

                                    //check if bus has different seat layouts. If so, do not float seats right
                                    if (maxLength == 2 && maxWidth == 2)
                                        sbSeatLayout.Append("<tr><td>");
                                    else
                                        sbSeatLayout.Append("<tr><td style=\"float: right\">");//style=\"float: right\"

                                    sbSeatLayout.Append("<ul class=\"seat_map\">");

                                    #region loop array and add seats

                                    foreach (DataRow dr in drArray)
                                    {
                                        #region Set seat type seat/sleeper_v/sleeper_h

                                        // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                        if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                        {
                                            if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                            {
                                                strSeatType = "Seat";
                                                strSeatCssSuffix = "seat";
                                            }
                                            else if (int.Parse(dr["width"].ToString()) == 2)
                                            {
                                                strSeatType = "Sleeper_v";
                                                strSeatCssSuffix = "sleeper_v";
                                            }
                                            else if (int.Parse(dr["length"].ToString()) == 2)
                                            {
                                                strSeatType = "Sleeper_h";
                                                strSeatCssSuffix = "sleeper_h";
                                            }
                                        }

                                        #endregion

                                        //Check if datarow has empty seats, if so add empty spaces
                                        if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                        {
                                            //set appropriate class based on seat availability
                                            if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                            {
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                            }
                                            else
                                            {
                                                if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                else
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                            }

                                            //Seat number is properly displayed in Chrome and Firefox except IE. 
                                            //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                            //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                            sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                            sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                            sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                            //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                        }
                                        else
                                        {
                                            //check if drArray has no seats. If so, add li element to create walking bay
                                            if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                sbSeatLayout.Append("<li>&nbsp;</li>");
                                        }
                                    }

                                    #endregion

                                    sbSeatLayout.Append("</ul>");
                                    sbSeatLayout.Append("</td></tr>");
                                }
                                sbSeatLayout.Append("</table></div>");
                            }
                        }

                        sbSeatLayout.Append("</td></tr></table>");
                    }
                }
                catch (Exception ex)
                {
                    // only for development purpose
                }

                objSeatsInfoResponse.SeatsScript = sbSeatLayout.ToString();
                return objSeatsInfoResponse;
            }
            else
                return null;
        }
        DataRow[] drArray1;

        private SeatsInfo GetSeatLayoutTG(SeatsInfo objSeatsInfo)
        {
            SeatsInfo objSeatsInfoResponse = new SeatsInfo();
            objSeatsInfoResponse = objSeatsInfo;

            BusesBaseClass _ = new BusesBaseClass();
            //Convert it to string and then to dataset
            //Supposed to use objSeatsInfo.Seats as it is. 
            DataSet dsMain = _.convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsInfo));

            if (dsMain != null)
            {

                DataTable dtMain = dsMain.Tables["seats"];
                StringBuilder sbSeatLayout = new StringBuilder();
                String[] response = new String[3];
                try
                {
                    if (dtMain.Rows.Count > 0)
                    {
                        #region Code to convert "Row" & "Column" columns to integer datatype

                        //create a copy of main table
                        DataTable dt = dtMain.Clone();
                        //set column datatypes for int values
                        dt.Columns["row"].DataType = Type.GetType("System.Int16");
                        dt.Columns["column"].DataType = Type.GetType("System.Int16");
                        dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");
                        var lengthCount1 = (from dr in dtMain.AsEnumerable() select dr["length"]).Distinct().ToList();
                        var rowss = (from dr in dtMain.AsEnumerable() select dr["row"]).Distinct().ToList();
                        if (rowss.Count() != 3 && rowss.Count() != 7 && rowss.Count() != 5)
                        {
                            if (lengthCount1.Count() == 2)
                            {


                                drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");
                                if (drArray1.Length > 0)
                                {
                                    foreach (DataRow dr in drArray1)
                                    {
                                        if (Convert.ToInt32(dr[0]) > 11)
                                        {
                                            dr[0] = Convert.ToInt32(dr[0]) - 11;
                                        }
                                        dt.ImportRow(dr);
                                    }
                                }

                                dt.AcceptChanges();
                            }
                            else
                            {
                                drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");
                                if (drArray1.Length > 0)
                                {
                                    foreach (DataRow dr in drArray1)
                                        dt.ImportRow(dr);
                                }

                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            // DataRow[] drArray1 = dtMain.Select(String.Empty, "row ASC, column ASC, zIndex DESC");
                            drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");
                            if (drArray1.Length > 0)
                            {
                                foreach (DataRow dr in drArray1)
                                    dt.ImportRow(dr);
                            }

                            dt.AcceptChanges();
                        }


                        #endregion

                        var lengthCount = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().ToList();
                        var widthcount = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().ToList();
                        var rows = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                        //sleeper test
                        if (rows.Count() == 3)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToInt32(row["column"]) >= 12)
                                {
                                    row["column"] = Convert.ToInt32(row["column"]) - 12;
                                    row["row"] = Convert.ToInt32(row["row"]) + 3;

                                }
                            }
                            dt.AcceptChanges();
                            var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();
                            var zindex = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();
                            var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();

                            //Used in exceptional cases where a bus has both seats and sleeper coaches
                            //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                            int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                            int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();
                            //sleeper test end
                            String strSeatType = String.Empty;
                            String strSeatCssSuffix = String.Empty;

                            if (rows.Count() == 2 || rows.Count() == 3)
                                sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                            else
                                sbSeatLayout.Append("<table align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 3px; margin: 3px; \"><tr><td colspan=\"2\">");

                            foreach (Int16 index in ColumnCount)
                            {
                                if (rows.Count() == 2 || rows.Count() == 3)
                                {
                                    //div tag is added to show border with same size for upper and lower decks
                                    sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 4px; padding: 7px; margin: 3px; \">");
                                    //add steering image only once
                                    if (ColumnCount.IndexOf(index) == 1)
                                        sbSeatLayout.Append("<span class=\"steering_sl\" style=\"margin-top: 10px; \"/>");
                                    sbSeatLayout.Append("<table>");
                                }
                                else
                                    sbSeatLayout.Append("<div><span class=\"steering\"/><table >");

                                foreach (Int16 row in RowCount)
                                {
                                    #region Create datarow array

                                    //Get the actual row count to drArrayMain 
                                    if (rows.Count() == 2 || rows.Count() == 3)
                                    {
                                        drArrayMain = dt.Select("row = " + row, "column ASC");
                                    }

                                    //Create another array which is based on ColumnCount
                                    //This array will be used in below code
                                    DataRow[] drArray;//= new DataRow[ColumnCount.Count];

                                    ColumnCount.Sort();


                                    drArray = drArrayMain;


                                    #endregion

                                    //check if bus has different seat layouts. If so, do not float seats right
                                    if (maxLength == 1 || maxWidth == 1)
                                        sbSeatLayout.Append("<tr><td>");
                                    else
                                        sbSeatLayout.Append("<tr><td style=\"float: right\">");

                                    sbSeatLayout.Append("<ul class=\"seat_map\">");

                                    #region loop array and add seats

                                    if (rows.Count() == 3)
                                    {

                                        foreach (DataRow dr in drArray)
                                        {
                                            #region Set seat type seat/sleeper_v/sleeper_h

                                            // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                            if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                            {
                                                if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                                {
                                                    strSeatType = "Seat";
                                                    strSeatCssSuffix = "seat";
                                                }
                                                else if (int.Parse(dr["width"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_v";
                                                    strSeatCssSuffix = "sleeper_v";
                                                }
                                                else if (int.Parse(dr["length"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_h";
                                                    strSeatCssSuffix = "sleeper_h";
                                                }
                                            }

                                            #endregion

                                            //Check if datarow has empty seats, if so add empty spaces
                                            if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                            {
                                                //set appropriate class based on seat availability
                                                if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                                {
                                                    if (dr["number"] != "")
                                                    {
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                                    }
                                                }
                                                else
                                                {
                                                    if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                    else
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                    sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                    sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                    sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                    //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                                }

                                                //Seat number is properly displayed in Chrome and Firefox except IE. 
                                                //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                                //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                                sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                                sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                            }
                                            else
                                            {
                                                //check if drArray has no seats. If so, add li element to create walking bay
                                                if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                    sbSeatLayout.Append("<li>&nbsp;</li>");
                                            }
                                        }

                                    }
                                    else
                                    {


                                        foreach (DataRow dr in drArray)
                                        {
                                            #region Set seat type seat/sleeper_v/sleeper_h

                                            // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                            if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                            {
                                                if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                                {
                                                    strSeatType = "Seat";
                                                    strSeatCssSuffix = "seat";
                                                }
                                                else if (int.Parse(dr["width"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_v";
                                                    strSeatCssSuffix = "sleeper_v";
                                                }
                                                else if (int.Parse(dr["length"].ToString()) == 2)
                                                {
                                                    strSeatType = "Sleeper_h";
                                                    strSeatCssSuffix = "sleeper_h";
                                                }
                                            }

                                            #endregion

                                            //Check if datarow has empty seats, if so add empty spaces
                                            if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                            {
                                                //set appropriate class based on seat availability
                                                if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                                {
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                                }
                                                else
                                                {
                                                    if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                    else
                                                        sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                    sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                    sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                    sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                    //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                                }

                                                //Seat number is properly displayed in Chrome and Firefox except IE. 
                                                //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                                //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                                sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                                sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                                //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                            }
                                            else
                                            {
                                                //check if drArray has no seats. If so, add li element to create walking bay
                                                if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                    sbSeatLayout.Append("<li>&nbsp;</li>");
                                            }
                                        }
                                    }

                                    #endregion

                                    sbSeatLayout.Append("</ul>");
                                    sbSeatLayout.Append("</td></tr>");
                                }
                                sbSeatLayout.Append("</table></div>");
                            }


                        }
                        else
                        {


                            var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();

                            var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();

                            var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();




                            //Used in exceptional cases where a bus has both seats and sleeper coaches
                            //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                            int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                            int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();

                            String strSeatType = String.Empty;
                            String strSeatCssSuffix = String.Empty;

                            if (zIndexCount.Count > 1)
                                if (lengthCount1.Count() == 2)
                                {
                                    sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                                }
                                else
                                {
                                    sbSeatLayout.Append("<table width=\"600\" align=\"left\"><tr><td colspan=\"2\">");
                                }
                            else
                                sbSeatLayout.Append("<table  align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 1px; margin: 0px; \"><tr><td colspan=\"2\">");

                            foreach (Int16 index in zIndexCount)
                            {
                                if (zIndexCount.Count > 1)
                                {
                                    //div tag is added to show border with same size for upper and lower decks
                                    sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 3px; margin: 3px;margin-top:10px; \">");
                                    //add steering image only once
                                    if (zIndexCount.IndexOf(index) > 0)
                                        sbSeatLayout.Append("<span class=\"steering_sl\" style=\"margin-top: 10px; \"/>");//class=\"steering\"

                                    if (RowCount.Count() == 6 || RowCount.Count() == 2 || RowCount.Count() == 5 || RowCount.Count() == 8)
                                    {
                                        sbSeatLayout.Append("<table width=\"670\" >");
                                    }
                                    else
                                    {
                                        sbSeatLayout.Append("<table>");
                                    }

                                }
                                else
                                    sbSeatLayout.Append("<div><span class=\"steering\"/> <table >");//<span class=\"steering\"/>
                                foreach (Int16 row in RowCount)
                                {
                                    #region Create datarow array

                                    //Get the actual row count to drArrayMain 
                                    //DataRow[] drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index, "column ASC");
                                    if (rowss.Count() != 7 && rowss.Count() != 5)
                                    {
                                        if (lengthCount1.Count() == 2)
                                        {
                                            drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index + " AND length=2", "column ASC").Distinct().ToArray();
                                        }
                                        else
                                        {
                                            drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index);
                                        }
                                    }
                                    else
                                    {
                                        drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index);
                                    }


                                    //Create another array which is based on ColumnCount
                                    //This array will be used in below code
                                    DataRow[] drArray;// = new DataRow[ColumnCount.Count];
                                    drArray = drArrayMain;
                                    #endregion

                                    //check if bus has different seat layouts. If so, do not float seats right
                                    if (maxLength == 2 && maxWidth == 2)
                                        sbSeatLayout.Append("<tr><td>");
                                    else
                                        if (rowss.Count() != 7 && rowss.Count() != 5)
                                        {
                                            if (lengthCount1.Count() == 2)
                                            {
                                                sbSeatLayout.Append("<tr><td style=\"float: left\">");
                                            }
                                            else
                                            {
                                                sbSeatLayout.Append("<tr><td style=\"float: right\">");//style=\"float: right\"
                                            }
                                        }
                                        else
                                        {
                                            sbSeatLayout.Append("<tr><td style=\"float: right\">");//style=\"float: right\"
                                        }

                                    sbSeatLayout.Append("<ul class=\"seat_map\">");

                                    #region loop array and add seats

                                    foreach (DataRow dr in drArray)
                                    {
                                        #region Set seat type seat/sleeper_v/sleeper_h

                                        // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                        if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                        {
                                            if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                            {
                                                strSeatType = "Seat";
                                                strSeatCssSuffix = "seat";
                                            }
                                            else if (int.Parse(dr["width"].ToString()) == 2)
                                            {
                                                strSeatType = "Sleeper_v";
                                                strSeatCssSuffix = "sleeper_v";
                                            }
                                            else if (int.Parse(dr["length"].ToString()) == 2)
                                            {
                                                strSeatType = "Sleeper_h";
                                                strSeatCssSuffix = "sleeper_h";
                                            }
                                        }

                                        #endregion

                                        //Check if datarow has empty seats, if so add empty spaces
                                        if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                        {
                                            //set appropriate class based on seat availability
                                            if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                            {
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                            }
                                            else
                                            {
                                                if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                                else
                                                    sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");

                                                sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                                sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                                sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");
                                                //sb.Append("<a href='#' id='seat" + dr["Seat"].ToString() + "'>" + dr["Seat"].ToString() + "</a></li>");
                                            }

                                            //Seat number is properly displayed in Chrome and Firefox except IE. 
                                            //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                            //sbSeatLayout.Append("<a id='seat" + dr["Seat"].ToString() + "'>"+ "&nbsp;" +"</a></li>");
                                            sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");

                                            sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                            sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                            //sbSeatLayout.Append("<input id=\"isSelected" + dr["Seat"].ToString() + "\" type=\"hidden\" name=\"isSelected\"/>");
                                        }
                                        else
                                        {
                                            //check if drArray has no seats. If so, add li element to create walking bay
                                            if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                                sbSeatLayout.Append("<li>&nbsp;</li>");
                                        }
                                    }

                                    #endregion

                                    sbSeatLayout.Append("</ul>");
                                    sbSeatLayout.Append("</td></tr>");
                                }
                                sbSeatLayout.Append("</table></div>");
                            }
                        }

                        sbSeatLayout.Append("</td></tr></table>");
                    }
                }
                catch (Exception ex)
                {
                    // only for development purpose
                }

                objSeatsInfoResponse.SeatsScript = sbSeatLayout.ToString();
                return objSeatsInfoResponse;
            }
            else
                return null;
        }
        private SeatsInfo TestGetSeatLayout(SeatsInfo objSeatsInfo)
        {
            SeatsInfo objSeatsInfoResponse = new SeatsInfo();
            objSeatsInfoResponse = objSeatsInfo;

            BusesBaseClass _ = new BusesBaseClass();
            //Convert it to string and then to dataset
            //Supposed to use objSeatsInfo.Seats as it is. 
            DataSet dsMain = _.convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsInfo));

            if (dsMain != null)
            {

                DataTable dtMain = dsMain.Tables["seats"];
                StringBuilder sbSeatLayout = new StringBuilder();
                String[] response = new String[3];
                try
                {
                    if (dtMain.Rows.Count > 0)
                    {
                        #region Code to convert "Row" & "Column" columns to integer datatype

                        //create a copy of main table
                        DataTable dt = dtMain.Clone();
                        //set column datatypes for int values
                        dt.Columns["row"].DataType = Type.GetType("System.Int16");
                        dt.Columns["column"].DataType = Type.GetType("System.Int16");
                        dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");
                        var lengthCount1 = (from dr in dtMain.AsEnumerable() select dr["length"]).Distinct().ToList();

                        drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");
                        if (drArray1.Length > 0)
                        {
                            foreach (DataRow dr in drArray1)
                                dt.ImportRow(dr);
                        }

                        dt.AcceptChanges();

                        #endregion

                        var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();
                        var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();
                        var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();
                        //Used in exceptional cases where a bus has both seats and sleeper coaches
                        //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                        int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                        int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();

                        String strSeatType = String.Empty;
                        String strSeatCssSuffix = String.Empty;

                        if (zIndexCount.Count > 1)
                            //sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                            if (lengthCount1.Count() != 2)
                            {
                                sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"><tr><td colspan=\"2\">");
                            }
                            else
                            {
                                if (ColumnCount.Count() != 22 && ColumnCount.Count() != 10 && ColumnCount.Count() != 8 && ColumnCount.Count() != 11 && ColumnCount.Count() != 6 && ColumnCount.Count() != 9 && ColumnCount.Count() != 7 && ColumnCount.Count() != 13 && ColumnCount.Count() != 10 && ColumnCount.Count() != 12)
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"680\" align=\"left\"><tr><td colspan=\"2\">");
                                }
                                else
                                {
                                    if (RowCount.Count() == 2 && zIndexCount.Count() == 2)
                                    {
                                        sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"680\" align=\"left\"><tr><td colspan=\"2\">");
                                    }
                                    else
                                    {
                                        sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"><tr><td colspan=\"2\">");

                                    }
                                }
                            }
                        else
                            sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 1px; margin: 0px; \"><tr><td colspan=\"2\">");

                        foreach (Int16 index in zIndexCount)
                        {
                            if (zIndexCount.Count > 1)
                            {
                                //div tag is added to show border with same size for upper and lower decks
                                sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 2px; margin: 2px;margin-top:3px; \">");
                                //add steering image only once
                                if (zIndexCount.IndexOf(index) > 0)
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><span  />");//class=\"lowerLabel\" style=\"float:left;height:55px;\"
                                }
                                else
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><span >");//class=\"upperLabel\" style=\"height:50px;\"
                                }
                            }
                            else
                                sbSeatLayout.Append("<div><span class=\"steering\"/> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" >");//<span class=\"steering\"/>
                            foreach (Int16 row in RowCount)
                            {
                                #region Create datarow array

                                //Get the actual row count to drArrayMain 
                                drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index, "column ASC");
                                //Create another array which is based on ColumnCount
                                //This array will be used in below code
                                DataRow[] drArray = new DataRow[ColumnCount.Count];
                                // drArray = drArrayMain;
                                #endregion

                                //check if bus has different seat layouts. If so, do not float seats right
                                if (maxLength == 2 && maxWidth == 2)
                                    sbSeatLayout.Append("<tr><td>");
                                else
                                    sbSeatLayout.Append("<tr><td style=\"float: right\">");//style=\"float: right\"
                                sbSeatLayout.Append("<ul class=\"seat_map\">");

                                #region loop array and add seats

                                foreach (DataRow dr in drArrayMain)
                                {
                                    #region Set seat type seat/sleeper_v/sleeper_h

                                    // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                    if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                    {
                                        if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                        {
                                            strSeatType = "Seat";
                                            strSeatCssSuffix = "seat";
                                        }
                                        else if (int.Parse(dr["width"].ToString()) == 2)
                                        {
                                            strSeatType = "Sleeper_v";
                                            strSeatCssSuffix = "sleeper_v";
                                        }
                                        else if (int.Parse(dr["length"].ToString()) == 2)
                                        {
                                            strSeatType = "Sleeper_h";
                                            strSeatCssSuffix = "sleeper_h";
                                        }
                                    }

                                    #endregion

                                    //Check if datarow has empty seats, if so add empty spaces
                                    if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                    {
                                        //set appropriate class based on seat availability
                                        if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                        {
                                            sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                        }
                                        else
                                        {
                                            if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                            else
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");
                                            sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                            sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                            sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");

                                        }

                                        //Seat number is properly displayed in Chrome and Firefox except IE. 
                                        //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                        sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");
                                        sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                        sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");

                                    }
                                    else
                                    {
                                        //check if drArray has no seats. If so, add li element to create walking bay
                                        //if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                        //    sbSeatLayout.Append("<li>&nbsp;</li>");
                                    }

                                }

                                #endregion

                                sbSeatLayout.Append("</ul>");
                                sbSeatLayout.Append("</td></tr>");
                            }
                            sbSeatLayout.Append("</table></div>");

                        }

                        sbSeatLayout.Append("</td></tr></table>");
                    }
                }
                catch (Exception ex)
                {
                    // only for development purpose
                }

                objSeatsInfoResponse.SeatsScript = sbSeatLayout.ToString();
                return objSeatsInfoResponse;
            }
            else
                return null;
        }
        private SeatsInfo BITLAGetSeatLayout(SeatsInfo objSeatsInfo)
        {
            SeatsInfo objSeatsInfoResponse = new SeatsInfo();
            objSeatsInfoResponse = objSeatsInfo;

            BusesBaseClass _ = new BusesBaseClass();
            //Convert it to string and then to dataset
            //Supposed to use objSeatsInfo.Seats as it is. 
            DataSet dsMain = _.convertJsonStringToDataSet(JsonConvert.SerializeObject(objSeatsInfo));

            if (dsMain != null)
            {

                DataTable dtMain = dsMain.Tables["seats"];
                StringBuilder sbSeatLayout = new StringBuilder();
                String[] response = new String[3];
                try
                {
                    if (dtMain.Rows.Count > 0)
                    {
                        #region Code to convert "Row" & "Column" columns to integer datatype

                        //create a copy of main table
                        DataTable dt = dtMain.Clone();
                        //set column datatypes for int values
                        dt.Columns["row"].DataType = Type.GetType("System.Int16");
                        dt.Columns["column"].DataType = Type.GetType("System.Int16");
                        dt.Columns["zIndex"].DataType = Type.GetType("System.Int16");
                        var lengthCount1 = (from dr in dtMain.AsEnumerable() select dr["length"]).Distinct().ToList();

                        drArray1 = dtMain.Select(String.Empty, "row DESC, column ASC, zIndex DESC");

                        if (drArray1.Length > 0)
                        {
                            foreach (DataRow dr in drArray1)
                                dt.ImportRow(dr);
                        }

                        dt.AcceptChanges();

                        #endregion

                        var zIndexCount = (from dr in dt.AsEnumerable() select dr["zIndex"]).Distinct().ToList();
                        var RowCount = (from dr in dt.AsEnumerable() select dr["row"]).Distinct().ToList();
                        var ColumnCount = (from dr in dt.AsEnumerable() select dr["column"]).Distinct().ToList();
                        //Used in exceptional cases where a bus has both seats and sleeper coaches
                        //int maxLength = Convert.ToInt32(dt.Compute("max(Length)", string.Empty));
                        int maxLength = (from dr in dt.AsEnumerable() select dr["length"]).Distinct().Count();
                        int maxWidth = (from dr in dt.AsEnumerable() select dr["width"]).Distinct().Count();

                        String strSeatType = String.Empty;
                        String strSeatCssSuffix = String.Empty;

                        if (zIndexCount.Count > 1)
                            //sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                            if (lengthCount1.Count() != 2 && lengthCount1.Count() != 3)
                            {
                                sbSeatLayout.Append("<table align=\"center\"><tr><td colspan=\"2\">");
                            }
                            else
                            {
                                if (ColumnCount.Count() != 14 && ColumnCount.Count() != 15 && ColumnCount.Count() != 22 && ColumnCount.Count() != 10 && ColumnCount.Count() != 8 && ColumnCount.Count() != 11 && ColumnCount.Count() != 6 && ColumnCount.Count() != 9 && ColumnCount.Count() != 7 && ColumnCount.Count() != 13 && ColumnCount.Count() != 10 && ColumnCount.Count() != 12)
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"680\" align=\"left\"><tr><td colspan=\"2\">");
                                }
                                else
                                {
                                    if (RowCount.Count() == 2 && zIndexCount.Count() == 2)
                                    {
                                        sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"680\" align=\"left\"><tr><td colspan=\"2\">");
                                    }
                                    else
                                    {
                                        sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"><tr><td colspan=\"2\">");

                                    }
                                }
                            }
                        else
                            sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 3px; margin: 3px; \"><tr><td colspan=\"2\">");

                        foreach (Int16 index in zIndexCount)
                        {
                            if (zIndexCount.Count > 1)
                            {
                                //div tag is added to show border with same size for upper and lower decks
                                sbSeatLayout.Append("<div style=\"border: 1px solid #D3D3D3; border-radius: 2px; padding: 2px; margin: 2px;margin-top:3px; \">");
                                //add steering image only once
                                if (zIndexCount.IndexOf(index) > 0)
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" ><span   />");//class=\"lowerLabel\" style=\"position:position;\"
                                }
                                else
                                {
                                    sbSeatLayout.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" ><span />");//class=\"upperLabel\"
                                }
                            }
                            else
                                sbSeatLayout.Append("<div><span class=\"steering\"/> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");//<span class=\"steering\"/>
                            //  RowCount.Sort();
                            foreach (Int16 row in RowCount)
                            {
                                #region Create datarow array

                                int row1;
                                if (ColumnCount.Count() == 15)
                                {
                                    if (index == 1)
                                    {
                                        if (row == 4)
                                        {
                                            row1 = row;
                                        }
                                        else
                                        {
                                            row1 = Convert.ToInt32(row) + 1;
                                        }
                                        drArrayMain = dt.Select("row = " + row1 + " AND zIndex = " + index, "column ASC");
                                    }
                                    else
                                    {
                                        //Get the actual row count to drArrayMain 
                                        drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index, "column ASC");
                                    }
                                }
                                else
                                {
                                    //Get the actual row count to drArrayMain 
                                    drArrayMain = dt.Select("row = " + row + " AND zIndex = " + index, "column ASC");
                                }

                                //Create another array which is based on ColumnCount
                                //This array will be used in below code
                                DataRow[] drArray = new DataRow[ColumnCount.Count];
                                // drArray = drArrayMain;
                                #endregion

                                //check if bus has different seat layouts. If so, do not float seats right
                                if (maxLength == 2 && maxWidth == 2)
                                    sbSeatLayout.Append("<tr><td>");
                                else
                                    sbSeatLayout.Append("<tr><td style=\"float: right\">");//style=\"float: right\"
                                sbSeatLayout.Append("<ul class=\"seat_map\">");

                                #region loop array and add seats

                                foreach (DataRow dr in drArrayMain)
                                {
                                    #region Set seat type seat/sleeper_v/sleeper_h

                                    // dr["length"] or dr["width"] will be empty strings only if there is no seat in dr of drArray
                                    if (dr["length"].ToString() != String.Empty && dr["width"].ToString() != String.Empty)
                                    {
                                        if (int.Parse(dr["width"].ToString()) == 1 && int.Parse(dr["length"].ToString()) == 1)
                                        {
                                            strSeatType = "Seat";
                                            strSeatCssSuffix = "seat";
                                        }
                                        else if (int.Parse(dr["width"].ToString()) == 2)
                                        {
                                            strSeatType = "Sleeper_v";
                                            strSeatCssSuffix = "sleeper_v";
                                        }
                                        else if (int.Parse(dr["length"].ToString()) == 2)
                                        {
                                            strSeatType = "Sleeper_h";
                                            strSeatCssSuffix = "sleeper_h";
                                        }
                                    }

                                    #endregion

                                    //Check if datarow has empty seats, if so add empty spaces
                                    if (dr["isAvailableSeat"] != null && dr["isAvailableSeat"].ToString() != String.Empty)
                                    {
                                        //set appropriate class based on seat availability
                                        if (dr["isAvailableSeat"].ToString().ToUpper() == "FALSE")
                                        {
                                            sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString() + "\" class=\"booked_" + strSeatCssSuffix + "\" title='Booked'> ");
                                        }
                                        else
                                        {
                                            if (dr["isLadiesSeat"].ToString().ToUpper() == "TRUE")
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"availableladies_" + strSeatCssSuffix + "\" ");
                                            else
                                                sbSeatLayout.Append("<li id=\"li" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" class=\"available_" + strSeatCssSuffix + "\" ");
                                            sbSeatLayout.Append("onclick=\"doUndoSelect('" + dr["number"].ToString() + "', '" + dr["fare"].ToString() + "," + strSeatType + ",0', 'available')\" ");
                                            sbSeatLayout.Append("onmouseout=\"fnClosePanel('seat_info');\" ");
                                            sbSeatLayout.Append("onmouseover=\"fnShowPanel(event,'seat_info','" + dr["number"].ToString() + "," + dr["fare"].ToString() + "," + strSeatType + "');\">");

                                        }

                                        //Seat number is properly displayed in Chrome and Firefox except IE. 
                                        //check with designer. If it doesn't work, uncomment below line and comment the line next to it.
                                        sbSeatLayout.Append("<a id='seat" + dr["number"].ToString() + "'>" + "" + "</a></li>");
                                        sbSeatLayout.Append("<input id=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelected" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");
                                        sbSeatLayout.Append("<input id=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty).Replace(" ", String.Empty) + "\" type=\"hidden\" name=\"isSelectedRet" + dr["number"].ToString().Replace("(", String.Empty).Replace(")", String.Empty) + "\" />");

                                    }
                                    else
                                    {
                                        //check if drArray has no seats. If so, add li element to create walking bay
                                        //if (drArray.Where(p => p.RowState == DataRowState.Detached).Count() == drArray.Count())
                                        //    sbSeatLayout.Append("<li>&nbsp;</li>");
                                    }

                                }

                                #endregion

                                sbSeatLayout.Append("</ul>");
                                sbSeatLayout.Append("</td></tr>");
                            }
                            sbSeatLayout.Append("</table></div>");

                        }

                        sbSeatLayout.Append("</td></tr></table>");
                    }
                }
                catch (Exception ex)
                {
                    // only for development purpose
                }

                objSeatsInfoResponse.SeatsScript = sbSeatLayout.ToString();
                return objSeatsInfoResponse;
            }
            else
                return null;
        }

        /// <summary>
        /// Method to get API providers list for given client credentials
        /// </summary>
        /// <param name="ConsumerKey"></param>
        /// <param name="ConsumerSecret"></param>
        private void GetAPIProvidersList(String ConsumerKey, String ConsumerSecret)
        {
            ClientAPIList objClientAPIList = new ClientAPIList();
            DataSet dsProviders = new DataSet();
            Connection = new SqlConnection(ConnectionString);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_WebAPI_GetProviders";
            command.Parameters.Add("@ConsumerKey", SqlDbType.VarChar).Value = ConsumerKey;
            command.Parameters.Add("@ConsumerSecret", SqlDbType.VarChar).Value = ConsumerSecret;
            command.Connection = Connection;
            Connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dsProviders);
            Connection.Close();

            //Check if atleast one provider is accessible
            if (dsProviders != null && dsProviders.Tables.Count > 0 && dsProviders.Tables[0].Rows.Count > 0)
            {
                //Loop each record, get the provider api details and add to objClientAPIList
                foreach (DataRow drProvider in dsProviders.Tables[0].Rows)
                {
                    ClientAPIDetails objClientAPIDetails = new ClientAPIDetails();
                    objClientAPIDetails.ClientID = int.Parse(drProvider["Client_ID"].ToString());
                    objClientAPIDetails.ProviderID = int.Parse(drProvider["Provider_ID"].ToString());
                    objClientAPIDetails.APIURL = drProvider["API_URL"].ToString();
                    objClientAPIDetails.ConsumerKey = drProvider["API_ConsumerKey"].ToString();
                    objClientAPIDetails.ConsumerSecret = drProvider["API_ConsumerSecret"].ToString();
                    objClientAPIDetails.DomainIP = drProvider["Domain_IP"].ToString();
                    objClientAPIDetails.ProviderName = drProvider["Provider_Name"].ToString();
                    objClientAPIList.Add(objClientAPIDetails);
                }
                //Set cache to expire after 20 minutes,i.e., the object expires 
                //  and is removed from the cache 20 minutes after it is last accessed.
                HttpContext.Current.Cache.Add("ClientAPI-" + ConsumerKey, objClientAPIList, null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                        new TimeSpan(0, 10, 0), System.Web.Caching.CacheItemPriority.Default, null);
                //HttpContext.Current.Cache["ClientAPI-" + ConsumerKey] = objClientAPIList;
            }
        }

        private DataSet ExecuteDataSet(String sqlQuery)
        {
            DataSet dsResult = new DataSet();
            String ConnectionString = ConfigurationManager.ConnectionStrings["LoveJourney"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, Connection);
                Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsResult);
                Connection.Close();

                da.Dispose();
                command.Dispose();
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
            return dsResult;
        }

        /// <summary>
        /// Method to validate http request
        /// </summary>
        /// <param name="ConsumerKey"></param>
        /// <param name="ConsumerSecret"></param>
        /// <returns></returns>
        private Boolean ValidateRequest(String ConsumerKey, String ConsumerSecret)
        {
            Boolean result = false;
            Connection = new SqlConnection(ConnectionString);
            try
            {
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_WebAPI_ValidateRequest";
                command.Parameters.Add("@ConsumerKey", SqlDbType.VarChar).Value = ConsumerKey;
                command.Parameters.Add("@ConsumerSecret", SqlDbType.VarChar).Value = ConsumerSecret;
                command.Connection = Connection;
                Connection.Open();

                if (command.ExecuteScalar().ToString().ToUpper().Equals("SUCCESS"))
                    result = true;
            }
            catch (Exception ex)
            {
                //to do
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Method to get the respective cityids of providers
        /// </summary>
        /// <param name="objBusesSearchFilter"></param>
        /// <param name="objClientAPIDetails"></param>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="dateofjourney"></param>
        /// <returns></returns>
        /// 

        protected void getdatafromXMl()
        {
            try
            {
                DataTable DtMsources = new DataTable();
                DataSet DsSources = new DataSet();
                DsSources.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + "Buses.xml"));
                //IEnumerable<DataRow> SubData = from i in DsSub.Tables[0].AsEnumerable()
                //                               where i.Field<string>("Type") == "D" || i.Field<string>("Type") == "C"
                //                               select i;

                //if (SubData.Count() > 0)  
                //{
                // DtLocSub = SubData.CopyToDataTable();
                // DataSet ds = new DataSet();
                // ds.Tables.Add(DtLocSub);

                //}


            }
            catch (Exception)
            {
                //  throw;
            }
        }

        private BusesSearchFilter GetCityIDsOfProviders(BusesSearchFilter objBusesSearchFilter, ClientAPIDetails objClientAPIDetails,
            int sourceId, int destinationId, String dateofjourney)
        {
            DataSet dsProviders = new DataSet();
            if (objClientAPIDetails.ProviderName != "MORNINGSTAR")
            {
                ClsBAL bal = new ClsBAL();
                bal.ProviderID = objClientAPIDetails.ProviderID;
                bal.sourceId = sourceId;
                bal.destionationId = destinationId;
                dsProviders = bal.GetAPIID();


                //DataTable DtRSources = new DataTable();
                //DataSet DsRSources = new DataSet();
                //DsRSources.ReadXml(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + "SourcesAPI.xml"));
                //IEnumerable<DataRow> API_Source_ID = from i in DsRSources.Tables[0].AsEnumerable()
                //                                     where i.Field<string>("Source_ID") == sourceId.ToString() && i.Field<string>("Provider_Id") == objClientAPIDetails.ProviderID.ToString()
                //                                     select i;
                //if (API_Source_ID.Count() > 0)
                //{
                //    DtRSources = API_Source_ID.CopyToDataTable();
                //    DataSet ds = new DataSet();
                //    ds.Tables.Add(DtRSources);

                //}


            }
            else
            {
                ClsBAL bal = new ClsBAL();
                bal.ProviderID = 102;
                bal.sourceId = sourceId;
                bal.destionationId = destinationId;
                dsProviders = bal.GetAPIID();
            }

            //DataSet dsProviders = ExecuteDataSet("SELECT " + objClientAPIDetails.ProviderName + " FROM dbo.tbl_Sources WHERE Source_ID = '" + sourceId + "' " +
            //                                       "SELECT " + objClientAPIDetails.ProviderName + " FROM dbo.tbl_Sources WHERE Source_ID = '" + destinationId + "'");

            if (dsProviders.Tables[0].Rows.Count > 0 && dsProviders.Tables[1].Rows.Count > 0)
            {
            if (objClientAPIDetails.ProviderName == "BITLA")
            {
                foreach (DataRow bsdr in dsProviders.Tables[0].Rows)
                {
                    if (source_ids.ToString() == "")
                    {
                        source_ids = bsdr[0].ToString();
                    }
                    else
                    {
                        source_ids = source_ids + "," + bsdr[0].ToString();
                    }
                }
                foreach (DataRow bddr in dsProviders.Tables[1].Rows)
                {
                    if (Destination_Ids.ToString() == "")
                    {
                        Destination_Ids = bddr[0].ToString();
                    }
                    else
                    {
                        Destination_Ids = Destination_Ids + "," + bddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "TICKETGOOSE")
            {
                foreach (DataRow tsdr in dsProviders.Tables[0].Rows)
                {
                    if (Tsource_ids.ToString() == "")
                    {
                        Tsource_ids = tsdr[0].ToString();
                    }
                    else
                    {
                        Tsource_ids = Tsource_ids + "," + tsdr[0].ToString();
                    }
                }
                foreach (DataRow tddr in dsProviders.Tables[1].Rows)
                {
                    if (TDestination_Ids.ToString() == "")
                    {
                        TDestination_Ids = tddr[0].ToString();
                    }
                    else
                    {
                        TDestination_Ids = TDestination_Ids + "," + tddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "MORNINGSTAR")
            {
                foreach (DataRow msdr in dsProviders.Tables[0].Rows)
                {
                    if (Msource_ids.ToString() == "")
                    {
                        Msource_ids = msdr[0].ToString();
                    }
                    else
                    {
                        Msource_ids = Msource_ids + "," + msdr[0].ToString();
                    }
                }
                foreach (DataRow mddr in dsProviders.Tables[1].Rows)
                {
                    if (MDestination_Ids.ToString() == "")
                    {
                        MDestination_Ids = mddr[0].ToString();
                    }
                    else
                    {
                        MDestination_Ids = MDestination_Ids + "," + mddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "RAJESH")
            {
                foreach (DataRow rsdr in dsProviders.Tables[0].Rows)
                {
                    if (Rsource_ids.ToString() == "")
                    {
                        Rsource_ids = rsdr[0].ToString();
                    }
                    else
                    {
                        Rsource_ids = Rsource_ids + "," + rsdr[0].ToString();
                    }
                }
                foreach (DataRow rddr in dsProviders.Tables[1].Rows)
                {
                    if (RDestination_Ids.ToString() == "")
                    {
                        RDestination_Ids = rddr[0].ToString();
                    }
                    else
                    {
                        RDestination_Ids = RDestination_Ids + "," + rddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "KALLADA")
            {
                foreach (DataRow kdsdr in dsProviders.Tables[0].Rows)
                {
                    if (KDsource_ids.ToString() == "")
                    {
                        KDsource_ids = kdsdr[0].ToString();
                    }
                    else
                    {
                        KDsource_ids = KDsource_ids + "," + kdsdr[0].ToString();
                    }
                }
                foreach (DataRow kdddr in dsProviders.Tables[1].Rows)
                {
                    if (KDDestination_Ids.ToString() == "")
                    {
                        KDDestination_Ids = kdddr[0].ToString();
                    }
                    else
                    {
                        KDDestination_Ids = KDDestination_Ids + "," + kdddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "KAVERI")
            {
                foreach (DataRow ksdr in dsProviders.Tables[0].Rows)
                {
                    if (Ksource_ids.ToString() == "")
                    {
                        Ksource_ids = ksdr[0].ToString();
                    }
                    else
                    {
                        Ksource_ids = Ksource_ids + "," + ksdr[0].ToString();
                    }
                }
                foreach (DataRow kddr in dsProviders.Tables[1].Rows)
                {
                    if (KDestination_Ids.ToString() == "")
                    {
                        KDestination_Ids = kddr[0].ToString();
                    }
                    else
                    {
                        KDestination_Ids = KDestination_Ids + "," + kddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "SAIANJANA")
            {
                foreach (DataRow ssdr in dsProviders.Tables[0].Rows)
                {
                    if (SSsource_ids.ToString() == "")
                    {
                        SSsource_ids = ssdr[0].ToString();
                    }
                    else
                    {
                        SSsource_ids = SSsource_ids + "," + ssdr[0].ToString();
                    }
                }
                foreach (DataRow ssddr in dsProviders.Tables[1].Rows)
                {
                    if (SSDestination_Ids.ToString() == "")
                    {
                        SSDestination_Ids = ssddr[0].ToString();
                    }
                    else
                    {
                        SSDestination_Ids = SSDestination_Ids + "," + ssddr[0].ToString();
                    }
                }
            }
            else if (objClientAPIDetails.ProviderName == "SVR")
            {
                foreach (DataRow sdr in dsProviders.Tables[0].Rows)
                {
                    if (Ssource_ids.ToString() == "")
                    {
                        Ssource_ids = sdr[0].ToString();
                    }
                    else
                    {
                        Ssource_ids = Ssource_ids + "," + sdr[0].ToString();
                    }
                }
                foreach (DataRow sddr in dsProviders.Tables[1].Rows)
                {
                    if (SDestination_Ids.ToString() == "")
                    {
                        SDestination_Ids = sddr[0].ToString();
                    }
                    else
                    {
                        SDestination_Ids = SDestination_Ids + "," + sddr[0].ToString();
                    }
                }
            }
            //easybus
            else if (objClientAPIDetails.ProviderName == "EASYBUS")
            {
                foreach (DataRow Edr in dsProviders.Tables[0].Rows)
                {
                    if (Esource_ids.ToString() == "")
                    {
                        Esource_ids = Edr[0].ToString();
                        //Esource_ids = "38";
                    }
                    else
                    {
                        Esource_ids = Esource_ids + "," + Edr[0].ToString();
                    }
                }
                foreach (DataRow Eddr in dsProviders.Tables[1].Rows)
                {
                    if (EDestination_Ids.ToString() == "")
                    {
                        EDestination_Ids = Eddr[0].ToString();
                       // EDestination_Ids = "32";
                    }
                    else
                    {
                        EDestination_Ids = EDestination_Ids + "," + Eddr[0].ToString();
                    }
                }
                //EDestination_Ids=38+","+32;
            }

            objBusesSearchFilter.SourceID = 0;
            // objBusesSearchFilter.DestinationID = int.Parse(dsProviders.Tables[1].Rows[0][0].ToString());
            objBusesSearchFilter.DestinationID = 0;
            objBusesSearchFilter.JourneyDate = dateofjourney;
            }
            dsProviders.Dispose();
            return objBusesSearchFilter;
        }
        private AvailableTrips GETBITLROUTES(BusesSearchFilter objBusesSearchFilter, ClientAPIDetails objClientAPIDetails,
           int sourceId, int destinationId, String dateofjourney)
        {
            ClsBAL bal = new ClsBAL();
            bal.ProviderID = objClientAPIDetails.ProviderID;
            bal.sourceId = sourceId;
            bal.destionationId = destinationId;
            DataSet dsProviders = bal.GetAPIID();

            //DataSet dsProviders = ExecuteDataSet("SELECT " + objClientAPIDetails.ProviderName + " FROM dbo.tbl_Sources WHERE Source_ID = '" + sourceId + "' " +
            //                                       "SELECT " + objClientAPIDetails.ProviderName + " FROM dbo.tbl_Sources WHERE Source_ID = '" + destinationId + "'");

            if (dsProviders.Tables[0].Rows.Count > 0 && dsProviders.Tables[1].Rows.Count > 0)
            {
                if (objClientAPIDetails.ProviderName == "BITLA")
                {
                    for (int k = 0; k < dsProviders.Tables.Count; k++)
                    {

                        BSID = dsProviders.Tables[0].Rows[k][0].ToString() == "" ? 0 : int.Parse(dsProviders.Tables[0].Rows[k][0].ToString());
                        BDID = dsProviders.Tables[1].Rows[k][0].ToString() == "" ? 0 : Convert.ToInt32(dsProviders.Tables[1].Rows[k][0]);
                        if (BSID > 0 && BDID > 0)
                        {
                            BDate = dateofjourney;
                            BURL = objClientAPIDetails.APIURL + "/";
                            BConsumerKey = objClientAPIDetails.ConsumerKey;
                            BCOnsumerSecretKey = objClientAPIDetails.ConsumerSecret;
                            BPID = objClientAPIDetails.ProviderID;
                            BProviderName = objClientAPIDetails.ProviderName;
                            Tbus = BITLA(BURL, BConsumerKey, BCOnsumerSecretKey, BPID, BProviderName, BSID, BDID, BDate);
                            bus = trips(Tbus);
                        }
                    }
                }
            }

            dsProviders.Dispose();
            return bus;
        }
        #endregion

    }
}