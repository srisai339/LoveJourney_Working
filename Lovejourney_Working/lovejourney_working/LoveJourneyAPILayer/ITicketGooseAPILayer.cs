using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusAPILayer.TicketGooseNamespace;

namespace BusAPILayer
{
    public interface ITicketGooseAPILayer
    {
        string UserId { get; set; }
        string Password { get; set; }

        DataTable GetStationList();
        DataTable GetFromToStation();
        DataTable GetDestinations(string sourceId);
        DataTable GetTripList(string FromStationId, string ToStationId, string TravelDate);
        DataSet GetTripDetails(string FromStationId, string ToStationId, string TravelDate, string scheduleId);
        DataTable BlockSeatsForBooking(string scheduleId, string TravelDate, string FromStationId,
            string ToStationId, string boardingPointId, string emailId, string mobileNbr, string address, PassengerDetailDTO[] PassengerDetailDTO);
        DataTable BookTicket(string bookingId);
        DataTable CancelTicket(string bookingId, String[] SeatNo);
        DataTable ConfirmTicketCancellation(string bookingId, String[] SeatNo);
    }
}
