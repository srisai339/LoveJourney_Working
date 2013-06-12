using System.Data;

namespace BusAPILayer
{ 
    public interface IKesineniAPILayer
    {
        string LoginId { set; get; }
        string Password { set; get; }

        DataSet GetSourceStations();
        DataSet GetDestinationStations(int sourceStationID);
        DataSet GetSchedules();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="seatType">0 – Any Seat, 1 – Seat & 2 – Sleeper Coaches</param>
        /// <returns></returns> 
        DataSet GetServices(int sourceStationId, int destinationStationId, string journeyDate, int seatType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        DataSet GetServicesDetails(int sourceStationId, int destinationStationId, string journeyDate, long serviceId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <returns></returns>
        DataSet GetBoardingPoints(string journeyDate, long serviceId, int sourceStationId, int destinationStationId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <returns></returns>
        DataSet GetDroppingPoints(string journeyDate, long serviceId, int sourceStationId, int destinationStationId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate">Format Should Be MM/DD/YYYY</param>
        /// <param name="serviceId"></param>
        /// <param name="coachTypeId"></param>
        /// <returns></returns>
        DataSet GetSeatLayout(int sourceStationId, int destinationStationId, string journeyDate, long serviceId, int coachTypeId);
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
        DataSet BookTicketsOnwardJourney
            (
            int sourceStationId, int destinationStationId, string journeyDate,
            long serviceId, int coachTypeId, int noOfSeats, string seatNumbersList, string firstNameList,
            string lastNameList, string genderList, string ageList, string contactNumberList, string boardingPointIdList,
            string droppingPointId, string ticketFare, string emailId, string address, string photoIdType, string photoIdNo,
            string photoIdIssuingAuthority, decimal totalBasicFare, decimal serviceTaxPercentage, string discountcode
            );
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
        DataSet BookTicketsRoundTripJourney
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
            );
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
        DataSet BookTicketsConfirmationOnwardJourney
            (
             int sourceStationId, int destinationStationId

            , string journeyDate, long serviceId, int serviceTransId

            , int noOfSeats, long blockedTicketId

            , string transactionId, string referenceCode
            );
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
        DataSet BookTicketsConfirmationRoundTripJourney
            (
            int sourceStationId, int destinationStationId

            , string onwardJourneyDate, long onwardServiceId, int onwardServiceTransId

            , int onwardNoOfSeats, long onwardBlockedTicketId

            , string returnJourneyDate, long returnServiceId, int returnServiceTransId

            , int returnNoOfSeats, long returnBlockedTicketId

            , string transactionId, string referenceCode
            );
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStationId"></param>
        /// <param name="destinationStationId"></param>
        /// <param name="journeyDate"></param>
        /// <returns></returns>
        DataSet CheckFare(int sourceStationId, int destinationStationId, string journeyDate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PNRNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateofJourney"></param>
        /// <param name="seatNumbersList"></param>
        /// <returns></returns>
        DataSet CancelTickets(string PNRNumber, string firstName, string lastName, string dateofJourney, string seatNumbersList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PNRNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateofJourney"></param>
        /// <param name="seatNumbersList"></param>
        /// <returns></returns>
        DataSet ConfirmCancelTickets(string PNRNumber, string firstName, string lastName, string dateofJourney, string seatNumbersList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockedTicketId"></param>
        /// <param name="serviceTransId"></param>
        /// <returns></returns>
        DataSet CancelBlockedTicketsOnwardJourney(long blockedTicketId, int serviceTransId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onwardBlockedTicketId"></param>
        /// <param name="onwardServiceTransId"></param>
        /// <param name="returnBlockedTicketId"></param>
        /// <param name="returnServiceTransId"></param>
        /// <returns></returns>
        DataSet CancelBlockedTicketsRoundTripJourney(long onwardBlockedTicketId, int onwardServiceTransId, long returnBlockedTicketId, int returnServiceTransId);
    }
}
