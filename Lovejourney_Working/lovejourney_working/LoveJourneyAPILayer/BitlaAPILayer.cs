using System.Text;
using System.IO;
using System.Data;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace BusAPILayer
{
    public class BitlaAPILayer : IBitlaAPILayer
    {
        #region Variables
        private string m_apikey;
        private string m_url;
        private string m_date;
        private string m_reservationid;
        private string m_originid;
        private string m_destinationid;
        private string m_boardingat;
        private string m_noofseats;
        private string m_ticketnumber;
        private string m_seatnumbers;
        private book_ticket m_ticketdetails;
        private string m_refNumber;
        #endregion

        #region Properties
        public string ApiKey
        {
            get
            {
                return m_apikey;
            }
            set
            {
                m_apikey = value;
            }
        }
        public string URL
        {
            get
            {
                return m_url;
            }
            set
            {
                m_url = value;
            }
        }
        /// <summary>
        /// Format Should Be YYYY-MM-DD
        /// </summary>
        public string Date
        {
            get
            {
                return m_date;
            }
            set
            {
                m_date = value;
            }
        }
        public string ReservationId
        {
            get
            {
                return m_reservationid;
            }
            set
            {
                m_reservationid = value;
            }
        }
        public string OriginId
        {
            get
            {
                return m_originid;
            }
            set
            {
                m_originid = value;
            }
        }
        public string DestinationId
        {
            get
            {
                return m_destinationid;
            }
            set
            {
                m_destinationid = value;
            }
        }
        public string BoardingAt
        {
            get
            {
                return m_boardingat;
            }
            set
            {
                m_boardingat = value;
            }
        }
        public string NoOfSeats
        {
            get
            {
                return m_noofseats;
            }
            set
            {
                m_noofseats = value;
            }
        }
        public string TicketNumber
        {
            get
            {
                return m_ticketnumber;
            }
            set
            {
                m_ticketnumber = value;
            }
        }
        public string SeatNumbers
        {
            get
            {
                return m_seatnumbers;
            }
            set
            {
                m_seatnumbers = value;
            }
        }
        public book_ticket TicketDetails
        {
            get
            {
                return m_ticketdetails;
            }
            set
            {
                m_ticketdetails = value;
            }
        }
        public string RefNumber
        {
            get
            {
                return m_refNumber;
            }
            set
            {
                m_refNumber = value;
            }
        }
        #endregion

        #region Methods
        public DataSet GetCities()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "cities.xml" + "?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetOperators()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "operators.xml" + "?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetDestinationPairs()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "destination_pairs.xml" + "?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataTable GetDestinations(string sourceId)
        {
            try
            {
                DataSet dsGetDestinationPairs = GetDestinationPairs();
                DataTable dtDestinations = null;
                if (dsGetDestinationPairs.Tables.Count > 1)
                {
                    DataTable dtOrigin = dsGetDestinationPairs.Tables["origin"];
                    DataTable dtDestination = dsGetDestinationPairs.Tables["destination"];

                    dtDestinations = new DataTable();
                    dtDestinations.Columns.Add("DestinationId");
                    dtDestinations.Columns.Add("DestinationName");

                    DataRow[] drArray1 = dtOrigin.Select("id ='" + sourceId + "'");
                    foreach (DataRow dataRow1 in drArray1)
                    {
                        DataRow[] drArray2 = dtDestination.Select("destination_pair_Id = '" + dataRow1["destination_pair_Id"].ToString() + "'");
                        foreach (DataRow dataRow2 in drArray2)
                        {
                            DataRow drNew = dtDestinations.NewRow();
                            drNew["DestinationId"] = dataRow2["id"].ToString();
                            drNew["DestinationName"] = dataRow2["name"].ToString();
                            dtDestinations.Rows.Add(drNew);
                        }
                    }
                }
                return dtDestinations;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetBusCategories()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "bus_categories.xml" + "?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetBusTypes()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "bus_types.xml" + "?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetAllAvailableRoutes()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "all_available_routes/" + Date + ".xml?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public DataSet GetServiceDetails()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "service_details/" + ReservationId + ".xml?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet ValidateBookTicket()
        {
            try
            {
                HttpWebResponse webResponse = null;

                string postData = "";
                string responseData = "";

                MemoryStream mstream = null;
                TextWriter twriter = null;

                using (mstream = new MemoryStream())
                {
                    using (twriter = new StreamWriter(mstream, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(book_ticket));
                        serializer.Serialize(twriter, TicketDetails);
                        int count = (int)mstream.Length;
                        byte[] arr = new byte[count];
                        mstream.Seek(0, SeekOrigin.Begin);
                        mstream.Read(arr, 0, count);
                        UTF8Encoding utf = new UTF8Encoding();
                        postData = utf.GetString(arr).Trim();
                    }
                }

                HttpWebRequest webRequest = WebRequest.Create
                    (
                    URL + "validate_book_ticket.xml?api_key=" + ApiKey
                    + "&reservation_id=" + ReservationId
                    + "&origin_id=" + OriginId
                    + "&destination_id=" + DestinationId
                    + "&boarding_at=" + BoardingAt
                    + "&no_of_seats=" + NoOfSeats
                    + "&agent_ref_number=" + RefNumber
                    ) as HttpWebRequest;

                webRequest.Accept = @"text/plain,application/xml";
                webRequest.ContentType = @"application/xml";
                webRequest.Method = @"POST";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = buffer.Length;

                using (Stream requestWriter = webRequest.GetRequestStream())
                {
                    requestWriter.Write(buffer, 0, buffer.Length);
                }

                DataSet ds = null;
                using (webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            responseData = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseData);
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);
                        ds = new DataSet();
                        ds.ReadXml(xmlReader);
                    }
                }

                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet BookTicket()
        {
          //  return null;
            string requestForMailForward = ""; string responseForMailForward = "";
            try
            {
                HttpWebResponse webResponse = null;

                string postData = "";
                string responseData = "";

                MemoryStream mstream = null;
                TextWriter twriter = null;
                using (mstream = new MemoryStream())
                {
                    using (twriter = new StreamWriter(mstream, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(book_ticket));
                        serializer.Serialize(twriter, TicketDetails);
                        int count = (int)mstream.Length;
                        byte[] arr = new byte[count];
                        mstream.Seek(0, SeekOrigin.Begin);
                        mstream.Read(arr, 0, count);
                        UTF8Encoding utf = new UTF8Encoding();
                        postData = utf.GetString(arr).Trim();
                    }
                }
                HttpWebRequest webRequest = WebRequest.Create
                    (
                    URL + "book_ticket.xml?api_key=" + ApiKey
                    + "&reservation_id=" + ReservationId
                    + "&origin_id=" + OriginId
                    + "&destination_id=" + DestinationId
                    + "&boarding_at=" + BoardingAt
                    + "&no_of_seats=" + NoOfSeats
                    + "&agent_ref_number=" + RefNumber
                    ) as HttpWebRequest;

                webRequest.Accept = @"text/plain,application/xml";
                webRequest.ContentType = @"application/xml";
                webRequest.Method = @"POST";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = buffer.Length;

                requestForMailForward = postData;

                using (Stream requestWriter = webRequest.GetRequestStream())
                {
                    requestWriter.Write(buffer, 0, buffer.Length);
                }

                DataSet ds = null;

                using (webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            responseData = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseData); responseForMailForward = responseData;
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);
                        ds = new DataSet();
                        ds.ReadXml(xmlReader);
                    }
                }
                bool res = Mailsender.SendMail("raju.katare@gmail.com", "", "", "Request&Response Success LJ --- Bitla book_ticket on " + System.DateTime.Now.Date.ToShortDateString(),
                  "'" + requestForMailForward + "' <br/> ###***### <br/>  '" + responseForMailForward + "'");
                return ds;
            }
            catch (System.Exception ex)
            {
                bool res = Mailsender.SendMail("raju.katare@gmail.com", "", "", "Request&Response Failure LJ --- Bitla book_ticket on " + System.DateTime.Now.Date.ToShortDateString(),
                 "'" + requestForMailForward + "' <br/> ###***### <br/>  '" + responseForMailForward + "' <br/> ###***### <br/>  " +
                 ex.Message.ToString() + ex.StackTrace.ToString() + ex.Source.ToString());
                throw;
            }
        }
        public DataSet TentativeBooking()
        {
            try
            {
                HttpWebResponse webResponse = null;

                string postData = "";
                string responseData = "";

                MemoryStream mstream = null;
                TextWriter twriter = null;

                using (mstream = new MemoryStream())
                {
                    using (twriter = new StreamWriter(mstream, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(book_ticket));
                        serializer.Serialize(twriter, TicketDetails);
                        int count = (int)mstream.Length;
                        byte[] arr = new byte[count];
                        mstream.Seek(0, SeekOrigin.Begin);
                        mstream.Read(arr, 0, count);
                        UTF8Encoding utf = new UTF8Encoding();
                        postData = utf.GetString(arr).Trim();
                    }
                }

                HttpWebRequest webRequest = WebRequest.Create
                    (
                    URL + "tentative_booking.xml?api_key=" + ApiKey
                    + "&reservation_id=" + ReservationId
                    + "&origin_id=" + OriginId
                    + "&destination_id=" + DestinationId
                    + "&boarding_at=" + BoardingAt
                    + "&no_of_seats=" + NoOfSeats
                    + "&agent_ref_number=" + RefNumber
                    ) as HttpWebRequest;

                webRequest.Accept = @"text/plain,application/xml";
                webRequest.ContentType = @"application/xml";
                webRequest.Method = @"POST";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = buffer.Length;

                using (Stream requestWriter = webRequest.GetRequestStream())
                {
                    requestWriter.Write(buffer, 0, buffer.Length);
                }

                DataSet ds = null;
                using (webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            responseData = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseData);
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);
                        ds = new DataSet();
                        ds.ReadXml(xmlReader);
                    }
                }

                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet ConfirmTentativeBooking()
        {
            try
            {
                HttpWebResponse webResponse = null;

                string postData = "";
                string responseData = "";

                MemoryStream mstream = null;
                TextWriter twriter = null;

                using (mstream = new MemoryStream())
                {
                    using (twriter = new StreamWriter(mstream, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(book_ticket));
                        serializer.Serialize(twriter, TicketDetails);
                        int count = (int)mstream.Length;
                        byte[] arr = new byte[count];
                        mstream.Seek(0, SeekOrigin.Begin);
                        mstream.Read(arr, 0, count);
                        UTF8Encoding utf = new UTF8Encoding();
                        postData = utf.GetString(arr).Trim();
                    }
                }

                HttpWebRequest webRequest = WebRequest.Create
                    (
                    URL + "confirm_tentative_booking.xml?api_key=" + ApiKey
                    + "&booking_pnr_number=" + ReservationId
                    ) as HttpWebRequest;

                webRequest.Accept = @"text/plain,application/xml";
                webRequest.ContentType = @"application/xml";
                webRequest.Method = @"POST";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(postData);
                webRequest.ContentLength = buffer.Length;

                using (Stream requestWriter = webRequest.GetRequestStream())
                {
                    requestWriter.Write(buffer, 0, buffer.Length);
                }

                DataSet ds = null;
                using (webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            responseData = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseData);
                        XmlNodeReader xmlReader = new XmlNodeReader(doc);
                        ds = new DataSet();
                        ds.ReadXml(xmlReader);
                    }
                }

                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet CancelTicket()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "cancel_ticket.xml?api_key=" + ApiKey
                    + "&ticket_number=" + TicketNumber);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet CancelPartialTicket()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "cancel_partial_ticket.xml?api_key=" + ApiKey
                    + "&ticket_number=" + TicketNumber + "&seat_numbers=" + SeatNumbers);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet IsTicketCancellable()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "is_ticket_cancellable.xml?api_key=" + ApiKey
                    + "&ticket_number=" + TicketNumber + "&seat_numbers=" + SeatNumbers);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        } 
        public DataSet GetTicketDetails()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "ticket_details.xml?api_key=" + ApiKey
                    + "&ticket_number=" + TicketNumber);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetDefaultStages()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "default_stages.xml?api_key=" + ApiKey);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataSet GetTransactionLog()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "transaction_log.xml?api_key=" + ApiKey
                    + "&trans_date=" + Date);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                DataSet ds = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());
                    string responseData = responseReader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseData);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
