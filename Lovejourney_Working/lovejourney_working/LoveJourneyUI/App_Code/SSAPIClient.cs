using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Web;
using System.Data;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

using LJ.WebAPI.Models;
using LJ.CLB.DTO;



public sealed class SSAPIClient
{

    //private string baseUrl = "http://api.seatseller.travel:9191";//"http://api.seatseller.travel";
    //private string consumerKey = "DcRrokcjYDxHOuXB2xVJQd8EtEvZgY";//"yR4nYkmynVr5bK37B5v2Pc7qpZooCd";//
    //private string consumerSecret = "9OppAP2oh1ue3gyQ3piYaacUo9sFhn";//"dcyMi6n36z6WxcDP4xgVSUu0gWrVy0";//
    // BusesViewModel busesAPI = new BusesViewModel();
    private string baseUrl = ConfigurationManager.AppSettings["I2SBus_BaseURL"];
    private string ConsumerKey = ConfigurationManager.AppSettings["I2SBus_ConsumerKey"];
    private string ConsumerSecret = ConfigurationManager.AppSettings["I2SBus_ConsumerSecret"];

    String jsonResponse = String.Empty;

    public SSAPIClient()
    { }


    public SSAPIClient(string baseUrl, string consumerKey, string consumerSecret)
    {
        this.baseUrl = baseUrl;
        this.ConsumerKey = consumerKey;
        this.ConsumerSecret = consumerSecret;
    }

    private string formHeader(string requestUrl, string methodType)
    {
        OAuthBase oauthBase = new OAuthBase();
        string normalisedUrl = string.Empty;
        string normalisedParams = string.Empty;
        string authHeader = string.Empty;
        string timeStamp = oauthBase.GenerateTimeStamp();
        string nonce = oauthBase.GenerateNonce();
        string requestWithAuth = oauthBase.GenerateSignature(new Uri(requestUrl), this.ConsumerKey, this.ConsumerSecret,
            "", "", methodType, timeStamp, nonce, OAuthBase.SignatureTypes.HMACSHA1, out normalisedUrl, out normalisedParams, out authHeader);
        string finalAuthHeader = "OAuth oauth_nonce=\"" + nonce + "\",oauth_consumer_key=\"" + this.ConsumerKey + "\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\""
           + timeStamp + "\",oauth_version=\"1.0\",oauth_signature=\"" + HttpUtility.UrlEncode(requestWithAuth) + "\"";
        return finalAuthHeader;

    }

    private string invokeGetRequest(string requestUrl)
    {
        string completeUrl = baseUrl + requestUrl + "ConsumerKey=" + this.ConsumerKey + "&ConsumerSecret=" + this.ConsumerSecret;
        string header = "";
        try
        {

            HttpWebRequest request1 = WebRequest.Create(completeUrl) as HttpWebRequest;
            request1.ContentType = @"application/json";
            request1.Method = @"GET";

            //   header = formHeader(completeUrl, "GET");
            //  request1.Headers.Add(HttpRequestHeader.Authorization, header);

            HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse();
            StreamReader reader = new
            StreamReader(httpWebResponse.GetResponseStream());
            string responseString = reader.ReadToEnd();
            return responseString;
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                //reading the custom messages sent by the server
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            else
                return ex.Message;
        }
        catch (Exception ex)
        {
            return "Failed with exception message:" + ex.Message;
        }
    }

    private string invokePostRequest(string requestUrl, string requestBody)
    {

        string completeUrl = baseUrl + requestUrl;
        String ResponseType = "application/json";
        String RequestType = "application/json";
        try
        {
            byte[] buffer = Encoding.ASCII.GetBytes(requestBody);
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(completeUrl);
            //Our method is post, otherwise the buffer (postvars) would be useless
            WebReq.Method = "POST";
            WebReq.ContentType = RequestType;
            WebReq.Accept = ResponseType;
            WebReq.Headers.Add("ConsumerKey", "12345");
            WebReq.Headers.Add("ConsumerSecret", "12345");

            //The length of the buffer (postvars) is used as contentlength.
            WebReq.ContentLength = buffer.Length;
            //We open a stream for writing the postvars
            Stream PostData = WebReq.GetRequestStream();
            //Now we write, and afterwards, we close. Closing is always important!
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();

            //HttpWebRequest request = WebRequest.Create(completeUrl) as HttpWebRequest;
            //request.ContentType = @"application/json";
            //request.Method = @"POST";
            //request.Headers.Add(HttpRequestHeader.Authorization, formHeader(completeUrl, "POST"));
            //requestWithAuth.Context.GenerateOAuthParametersForHeader() //alternative did not work

            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(requestBody);
            //requestWriter.Close();
            HttpWebResponse webResponse = (HttpWebResponse)WebReq.GetResponse();

            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            return responseReader.ReadToEnd();

        }
        catch (WebException ex)
        {
            //reading the custom messages sent by the server
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            return ex.Message + ex.InnerException + "--error" + "requestString:::::::::::: " + requestBody;
        }
    }


    public string getAllSources()
    {
        return invokeGetRequest("api/sources?");

    }

    public string getAllDestinations(string sourceId)
    {

        return invokeGetRequest("api/destinations?source=" + sourceId);
    }

    public string getAvailableTrips(string sourceId, string DestinationId, string DateOfJourny, int resultSetIndex)
    {
        try
        {
            var obj = new BusesViewModel();

            return obj.GetAvailableTrips(Convert.ToInt32(sourceId), Convert.ToInt32(DestinationId), DateOfJourny, Convert.ToInt16(resultSetIndex), ConsumerKey, ConsumerSecret).ToString();
            // return invokeGetRequest("api/availabletrips?source=" + sourceId + "&destination=" + DestinationId + "&doj=" + DateOfJourny + "&resultSetIndex=" + resultSetIndex + "&");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public string getTripDetails(string tripId, string sourceId, string destinationId, string SeatLayoutId, string markUpFare, string journeyDate, string providerName)
    {
        // return invokeGetRequest("api/TripDetails?tripId=" + tripId + "&source=" + sourceId + "&destination=" + destinationId + "&doj=" + journeyDate + "&provider=" + providerName + "&");
        var obj = new BusesViewModel();
        return obj.GetTripDetails(tripId, Convert.ToInt32(sourceId), Convert.ToInt32(destinationId), markUpFare, SeatLayoutId, journeyDate, providerName, ConsumerKey, ConsumerSecret).ToString();
    }
    protected DataSet convertJsonStringToDataSet(string jsonString)
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
    public string getBoardingPoint(string bordingPointString)
    {
        return invokeGetRequest("/boardingPoint?id=" + bordingPointString);
    }

    public string getTicket(string tinString)
    {
        return invokeGetRequest("/ticket?tin=" + tinString);
    }

    public string getCancellationData(string cancellationTinString)
    {
        return invokeGetRequest("api/cancellationdata?tin=" + cancellationTinString);
    }

    public string blockTicket(BlockSeats requestString)
    {
        // return invokePostRequest("api/BlockTicket", requestString);
        var obj = new BusesViewModel();
        return obj.BlockTicket(requestString, ConsumerKey, ConsumerSecret);
    }

    public string bookTicket(BlockSeats tentativeresponsekey)
    {
        // return invokePostRequest("api/BookTicket" , tentativeresponsekey);
        var obj = new BusesViewModel();
        return obj.BookTicket(tentativeresponsekey, ConsumerKey, ConsumerSecret);
    }

    public string cancelTicket(string makeCancellationRequest)
    {
        return invokePostRequest("api/cancelticket", makeCancellationRequest);
    }
}
