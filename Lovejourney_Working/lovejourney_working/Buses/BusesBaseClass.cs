#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
 * Version          : 1.0
 */
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Data;
using System.Configuration;
using Newtonsoft.Json;

#endregion

namespace LJ.CLB.Buses
{
    /// <summary>
    /// BusesBaseClass Class has the common methods that different bus services uses
    /// </summary>
    public class BusesBaseClass
    {
        protected string invokeGetRequest(string requestUrl, string contentType)
        {
            string completeUrl = requestUrl;
            string responseString;
            try
            {
                HttpWebRequest request1 = WebRequest.Create(completeUrl) as HttpWebRequest;
                request1.ContentType = contentType;
                request1.Method = @"GET";
                HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse();
                using (BufferedStream buffer = new BufferedStream(httpWebResponse.GetResponseStream()))
                {
                    using (StreamReader reader = new StreamReader(buffer))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }
                //StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
                //string responseString = reader.ReadToEnd();
                return responseString;
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
                return "Failed with exception message:" + ex.Message;
            }
        }

        protected string invokePostRequest(string requestUrl, string requestBody, string contentType)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.ContentType = contentType;
                request.Method = @"POST";
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(requestBody);
                requestWriter.Close();
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

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


        /// <summary>
        /// easybus get station repones convert xml into dataset
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        /// 
        public DataSet convertXMLtoDataset(string XMLData)
        {
            try
            {
                StringReader stream = null;
                XmlTextReader reader = null;

                DataSet ds = new DataSet();
                XmlDocument xd = new XmlDocument();
                stream = new StringReader(XMLData);
                // Load the XmlTextReader from the stream
                reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

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

        protected String Time(string mins)
        {
            try
            {
                String s = mins;
                int i = int.Parse(s);

                TimeSpan f = new TimeSpan(0, i, 0);
                int hours = f.Hours;

                String AmOrPm = " AM";

                if (hours > 12 && hours < 24)
                {
                    hours = hours - 12;
                    AmOrPm = " PM";
                }
                if (hours >= 24 && hours <= 36)
                {
                    hours = hours - 24;
                    AmOrPm = " AM";
                    if (hours == 36)
                    {
                        hours = hours - 24;
                        AmOrPm = " PM";
                    }
                }
                if (hours > 36 && hours < 48)
                {
                    hours = hours - 36;
                    AmOrPm = " PM";
                }
                s = string.Format("{0:00}:{1:00}", hours, f.Minutes);
                return s + AmOrPm;
            }
            catch (Exception ex)
            {
                return "-";
            }
        }
        string hoursStr = string.Empty; string minutesStr = string.Empty;
        TimeSpan interval;

        protected String Duration(String dtime, String atime)
        {
            try
            {
                if (dtime.ToString().ToLower().Contains("pm") && atime.ToString().ToLower().Contains("am"))
                {
                    interval = DateTime.Parse(dtime) - DateTime.Parse(atime).AddHours(24);
                }
                else if (dtime.ToString().ToLower().Contains("pm") && atime.ToString().ToLower().Contains("pm"))
                {
                    interval = DateTime.Parse(dtime).AddHours(24) - DateTime.Parse(atime);

                }
                else if (dtime.ToString().ToLower().Contains("am") && atime.ToString().ToLower().Contains("am"))
                {
                    interval = DateTime.Parse(dtime) - DateTime.Parse(atime).AddHours(24);

                }
                else
                {
                    interval = DateTime.Parse(dtime) - DateTime.Parse(atime).AddHours(24);

                }
                int hours = 0; int minutes = 0;

                hours = interval.Hours > 0 ? interval.Hours : -(interval.Hours);
                if (interval.Days == 1)
                {
                    hours = hours + 24;
                }

                minutes = interval.Minutes > 0 ? interval.Minutes : -(interval.Minutes);

                hoursStr = Convert.ToString(hours).Length != 1 ? Convert.ToString(hours) : "0" + Convert.ToString(hours);
                minutesStr = Convert.ToString(minutes).Length != 1 ? Convert.ToString(minutes) : "0" + Convert.ToString(minutes);


                return hoursStr + ":" + minutesStr + " hrs";
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        /*** Currently not in use ***/
        //protected double TimeInMins(string date)
        //{
        //    try
        //    {
        //        DateTime d = DateTime.Parse(date);
        //        TimeSpan time = new TimeSpan(d.Hour, d.Minute, d.Second);
        //        return time.TotalMinutes;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
    }
}
