using System;
using System.Data;

namespace HotelAPILayer
{
    public interface IArzooHotelAPILayer
    {
        #region Properties
        string UserName { set; get; }
        string UserType { set; get; }
        string UserId { set; get; }
        string Password { set; get; }
        string PartnerId { set; get; }
        #endregion

        #region Methods
        DataSet GetHotelAvailSearch(string startDate, string endDate, int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom,
            int[] firstChildAge, int[] secondChildAge, string cityName, string hotelName, string area, string rating);
        DataSet GetHotelDetails(string hotelId, string webService, string cityName);
        DataSet GetHotelPolicy(string hotelId, string webService, string ratePlanType, string roomTypeCode, string checkInDate, string checkOutDate);
        DataSet HotelProvisional(string hotelId, string roomType, string webService, string fromDate, string toDate, string roomTypeCode, string ratePlanCode
            , string validDays, string wsKey, string extGuestTotal, string roomTotal, string serviceTaxTotal, string discount, string commission, string title
            , string firstName, string middleName, string lastName, string phNoCountryCode, string phNoAreaCode, string phoneNumber
            , string phNoExtension, string emailId, string custAddressLine, string custCity, string custZipCode, string custState, string custCountry
            , int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom, int[] firstChildAge, int[] secondChildAge);
        DataSet HotelBooking(string hotelId, string webService, string ratePlanType, string roomTypeCode, string hotelCity
            , string fromAllocation, string allocId, string fromDate, string toDate, string roomType, string wsKey, string roomBasis, string title
            , string firstName, string middleName, string lastName
            , int noOfRooms, int[] noOfAdultsInARoom, int[] noOfChildsInARoom, int[] firstChildAge, int[] secondChildAge);
        DataSet HotelCancellation(string emailId, string lastName, string bookingRef, string webService, string cancellationDate, string cancellationDate2);
        #endregion
    }
}
