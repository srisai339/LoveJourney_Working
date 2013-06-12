using System.Data;
using BusAPILayer.KesineniNamespace;
using System.Xml;

namespace BusAPILayer
{
    public class KesineniAPILayer : IKesineniAPILayer
    {
        public string LoginId { set; get; }
        public string Password { set; get; }

        common objKesineni;
         
        public DataSet GetSourceStations()
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetSourceStations(LoginId, Password);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        public DataSet GetDestinationStations(int sourceStationID)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetDestinationStations(LoginId, Password, sourceStationID);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        public DataSet GetSchedules()
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetSchedules(LoginId, Password);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="seatType">0 – Any Seat, 1 – Seat & 2 – Sleeper Coaches</param>
        /// <returns></returns>
        public DataSet GetServices(int sourceStationId, int destinationStationId, string journeyDate, int seatType)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetServices(LoginId, Password, sourceStationId, destinationStationId, journeyDate, seatType);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public DataSet GetServicesDetails(int sourceStationId, int destinationStationId, string journeyDate, long serviceId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetServicesDetails(LoginId, Password, sourceStationId, destinationStationId, journeyDate, serviceId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <returns></returns>
        public DataSet GetBoardingPoints(string journeyDate, long serviceId, int sourceStationId, int destinationStationId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetBoardingPoints(LoginId, Password, journeyDate, serviceId, sourceStationId, destinationStationId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <returns></returns>
        public DataSet GetDroppingPoints(string journeyDate, long serviceId, int sourceStationId, int destinationStationId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetDroppingPoints(LoginId, Password, journeyDate, serviceId, sourceStationId, destinationStationId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="coachTypeId"></param>
        /// <returns></returns>
        public DataSet GetSeatLayout(int sourceStationId, int destinationStationId, string journeyDate, long serviceId, int coachTypeId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.GetSeatLayout(LoginId, Password, sourceStationId, destinationStationId, journeyDate, serviceId, coachTypeId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate"></param>
        /// <param name="serviceId"></param>
        /// <param name="coachTypeId"></param>
        /// <param name="noOfSeats"></param>
        /// <param name="seatNumbersList"></param>
        /// <param name="firstNameList"></param>
        /// <param name="lastNameList"></param>
        /// <param name="genderList"></param>
        /// <param name="ageList"></param>
        /// <param name="contactNumberList"></param>
        /// <param name="boardingPointIdList"></param>
        /// <param name="droppingPointId"></param>
        /// <param name="ticketFare"></param>
        /// <param name="emailId"></param>
        /// <param name="address"></param>
        /// <param name="photoIdType"></param>
        /// <param name="photoIdNo"></param>
        /// <param name="photoIdIssuingAuthority"></param>
        /// <param name="totalBasicFare"></param>
        /// <param name="serviceTaxPercentage"></param>
        /// <param name="discountcode"></param>
        /// <returns></returns>
        public DataSet BookTicketsOnwardJourney
            (
            int sourceStationId, int destinationStationId, string journeyDate,
            long serviceId, int coachTypeId, int noOfSeats, string seatNumbersList, string firstNameList,
            string lastNameList, string genderList, string ageList, string contactNumberList, string boardingPointIdList,
            string droppingPointId, string ticketFare, string emailId, string address, string photoIdType, string photoIdNo,
            string photoIdIssuingAuthority, decimal totalBasicFare, decimal serviceTaxPercentage, string discountcode
            )
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.BookTicketsOnwardJourney(LoginId, Password, sourceStationId,
                    destinationStationId, journeyDate, serviceId, coachTypeId, noOfSeats, seatNumbersList, firstNameList,
                    lastNameList, genderList, ageList, contactNumberList, boardingPointIdList, droppingPointId, ticketFare,
                    emailId, address, photoIdType, photoIdNo, photoIdIssuingAuthority, totalBasicFare, serviceTaxPercentage, discountcode);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate"></param>
        /// <param name="serviceId"></param>
        /// <param name="serviceTransId"></param>
        /// <param name="noOfSeats"></param>
        /// <param name="blockedTicketId"></param>
        /// <param name="transactionId">Gateway transaction id from Aggregator’s PaymentGateway</param>
        /// <param name="referenceCode">Gateway reference code from Aggregator’s PaymentGateway</param>
        /// <returns></returns>
        public DataSet BookTicketsConfirmationOnwardJourney
            (
             int sourceStationId, int destinationStationId

            , string journeyDate, long serviceId, int serviceTransId

            , int noOfSeats, long blockedTicketId

            , string transactionId, string referenceCode
            )
        {
            string requestForMailForward = ""; string responseForMailForward = "";
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.BookTicketsConfirmationOnwardJourney
                    (
                    LoginId, Password

                    , sourceStationId, destinationStationId

                    , journeyDate, serviceId, serviceTransId

                    , noOfSeats, blockedTicketId

                    , transactionId, referenceCode
                    );
                responseForMailForward = responseData;
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="onwardJourneyDate"></param>
        /// <param name="onwardServiceId"></param>
        /// <param name="onwardCoachTypeId"></param>
        /// <param name="onwardNoOfSeats"></param>
        /// <param name="onwardSeatNumbersList"></param>
        /// <param name="onwardFirstNameList"></param>
        /// <param name="onwardLastNameList"></param>
        /// <param name="onwardGenderList"></param>
        /// <param name="onwardAgeList"></param>
        /// <param name="onwardContactNumberList"></param>
        /// <param name="onwardBoardingPointIdList"></param>
        /// <param name="onwardDroppingPointId"></param>
        /// <param name="onwardTicketFare"></param>
        /// <param name="onwardTotalBasicFare"></param>
        /// <param name="onwardServiceTaxPercentage"></param>
        /// <param name="onwardDiscountcode"></param>
        /// <param name="returnJourneyDate"></param>
        /// <param name="returnServiceId"></param>
        /// <param name="returnCoachTypeId"></param>
        /// <param name="returnNoOfSeats"></param>
        /// <param name="returnSeatNumbersList"></param>
        /// <param name="returnFirstNameList"></param>
        /// <param name="returnLastNameList"></param>
        /// <param name="returnGenderList"></param>
        /// <param name="returnAgeList"></param>
        /// <param name="returnContactNumberList"></param>
        /// <param name="returnBoardingPointIdList"></param>
        /// <param name="returnDroppingPointId"></param>
        /// <param name="returnTicketFare"></param>
        /// <param name="returnTotalBasicFare"></param>
        /// <param name="returnServiceTaxPercentage"></param>
        /// <param name="returnDiscountcode"></param>
        /// <param name="emailId"></param>
        /// <param name="address"></param>
        /// <param name="photoIdType"></param>
        /// <param name="photoIdNo"></param>
        /// <param name="photoIdIssuingAuthority"></param>
        /// <returns></returns>
        public DataSet BookTicketsRoundTripJourney
            (
            int sourceStationId, int destinationStationId

            , string onwardJourneyDate, long onwardServiceId, int onwardCoachTypeId, int onwardNoOfSeats,
            string onwardSeatNumbersList, string onwardFirstNameList, string onwardLastNameList, string onwardGenderList,
            string onwardAgeList, string onwardContactNumberList, string onwardBoardingPointIdList,
            string onwardDroppingPointId, string onwardTicketFare, decimal onwardTotalBasicFare,
            decimal onwardServiceTaxPercentage, string onwardDiscountcode

            , string returnJourneyDate, long returnServiceId, int returnCoachTypeId, int returnNoOfSeats,
            string returnSeatNumbersList, string returnFirstNameList, string returnLastNameList, string returnGenderList,
            string returnAgeList, string returnContactNumberList, string returnBoardingPointIdList,
            string returnDroppingPointId, string returnTicketFare, decimal returnTotalBasicFare,
            decimal returnServiceTaxPercentage, string returnDiscountcode

            , string emailId, string address, string photoIdType, string photoIdNo, string photoIdIssuingAuthority
            )
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.BookTicketsRoundTripJourney
                    (
                    LoginId, Password

                    , sourceStationId, destinationStationId

                    , onwardJourneyDate, onwardServiceId, onwardCoachTypeId, onwardNoOfSeats,
                    onwardSeatNumbersList, onwardFirstNameList, onwardLastNameList, onwardGenderList,
                    onwardAgeList, onwardContactNumberList, onwardBoardingPointIdList,
                    onwardDroppingPointId, onwardTicketFare, onwardTotalBasicFare,
                    onwardServiceTaxPercentage, onwardDiscountcode

                    , returnJourneyDate, returnServiceId, returnCoachTypeId, returnNoOfSeats,
                    returnSeatNumbersList, returnFirstNameList, returnLastNameList, returnGenderList,
                    returnAgeList, returnContactNumberList, returnBoardingPointIdList,
                    returnDroppingPointId, returnTicketFare, returnTotalBasicFare,
                    returnServiceTaxPercentage, returnDiscountcode

                    , emailId, address, photoIdType, photoIdNo, photoIdIssuingAuthority
                    );
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="onwardJourneyDate"></param>
        /// <param name="onwardServiceId"></param>
        /// <param name="onwardServiceTransId"></param>
        /// <param name="onwardNoOfSeats"></param>
        /// <param name="onwardBlockedTicketId"></param>
        /// <param name="returnJourneyDate"></param>
        /// <param name="returnServiceId"></param>
        /// <param name="returnServiceTransId"></param>
        /// <param name="returnNoOfSeats"></param>
        /// <param name="returnBlockedTicketId"></param>
        /// <param name="transactionId">Gateway transaction id from Aggregator’s PaymentGateway</param>
        /// <param name="referenceCode">Gateway reference code from Aggregator’s PaymentGateway</param>
        /// <returns></returns>
        public DataSet BookTicketsConfirmationRoundTripJourney
            (
            int sourceStationId, int destinationStationId

            , string onwardJourneyDate, long onwardServiceId, int onwardServiceTransId

            , int onwardNoOfSeats, long onwardBlockedTicketId

            , string returnJourneyDate, long returnServiceId, int returnServiceTransId

            , int returnNoOfSeats, long returnBlockedTicketId

            , string transactionId, string referenceCode
            )
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.BookTicketsConfirmationRoundTripJourney
                    (
                    LoginId, Password

                    , sourceStationId, destinationStationId

                    , onwardJourneyDate, onwardServiceId, onwardServiceTransId

                    , onwardNoOfSeats, onwardBlockedTicketId

                    , returnJourneyDate, returnServiceId, returnServiceTransId

                    , returnNoOfSeats, returnBlockedTicketId

                    , transactionId, referenceCode
                    );
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate"></param>
        /// <returns></returns> 
        public DataSet CheckFare(int sourceStationId, int destinationStationId, string journeyDate)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.CheckFare(LoginId, Password, sourceStationId, destinationStationId, journeyDate);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PNRNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateofJourney"></param>
        /// <param name="seatNumbersList"></param>
        /// <returns></returns>
        public DataSet CancelTickets(string PNRNumber, string firstName, string lastName, string dateofJourney, string seatNumbersList)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.CancelTickets(LoginId, Password, PNRNumber, firstName, lastName, dateofJourney, seatNumbersList);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PNRNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateofJourney"></param>
        /// <param name="seatNumbersList"></param>
        /// <returns></returns>
        public DataSet ConfirmCancelTickets(string PNRNumber, string firstName, string lastName, string dateofJourney, string seatNumbersList)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.ConfirmCancelTickets(LoginId, Password, PNRNumber, firstName, lastName, dateofJourney, seatNumbersList);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockedTicketId"></param>
        /// <param name="serviceTransId"></param>
        /// <returns></returns>
        public DataSet CancelBlockedTicketsOnwardJourney(long blockedTicketId, int serviceTransId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.CancelBlockedTicketsOnwardJourney(LoginId, Password, blockedTicketId, serviceTransId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onwardBlockedTicketId"></param>
        /// <param name="onwardServiceTransId"></param>
        /// <param name="returnBlockedTicketId"></param>
        /// <param name="returnServiceTransId"></param>
        /// <returns></returns>
        public DataSet CancelBlockedTicketsRoundTripJourney(long onwardBlockedTicketId, int onwardServiceTransId, long returnBlockedTicketId, int returnServiceTransId)
        {
            try
            {
                objKesineni = new common();
                string responseData = objKesineni.CancelBlockedTicketsRoundTripJourney(LoginId, Password, onwardBlockedTicketId, onwardServiceTransId, returnBlockedTicketId, returnServiceTransId);
                return ConvertXMLStringToDataSet(responseData);
            }
            catch (System.Exception)
            {
                throw;
            }
            finally { objKesineni = null; }
        }
        DataSet ConvertXMLStringToDataSet(string xmlString)
        {
            try
            {
                DataSet ds = null;
                string sss = xmlString.Substring(0, 1);
                if (sss == "<")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlString);
                    XmlNodeReader xmlReader = new XmlNodeReader(doc);
                    ds = new DataSet();
                    ds.ReadXml(xmlReader);
                }
                else
                {
                    ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Message");
                    DataRow dr = dt.NewRow();
                    dr["Message"] = xmlString;
                    dt.Rows.Add(dr);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
