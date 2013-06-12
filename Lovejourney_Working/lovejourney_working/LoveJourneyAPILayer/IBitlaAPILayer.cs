using System.Data;

namespace BusAPILayer
{ 
    public interface IBitlaAPILayer
    {
        string ApiKey { set; get; }
        string URL { set; get; }
        /// <summary>
        /// Format Should Be YYYY-MM-DD
        /// </summary>
        string Date { set; get; }
        string ReservationId { set; get; }
        string OriginId { set; get; }
        string DestinationId { set; get; }
        string BoardingAt { set; get; }
        string NoOfSeats { set; get; }
        string TicketNumber { set; get; } 
        string SeatNumbers { set; get; }
        book_ticket TicketDetails { set; get; }
        string RefNumber { set; get; }

        DataSet GetCities();
        DataSet GetOperators();
        DataSet GetDestinationPairs();
        DataTable GetDestinations(string sourceId);
        DataSet GetBusCategories();
        DataSet GetBusTypes();
        DataSet GetAllAvailableRoutes();
        DataSet GetServiceDetails();
        DataSet ValidateBookTicket();
        DataSet BookTicket();
        DataSet CancelTicket();
        DataSet CancelPartialTicket();
        DataSet IsTicketCancellable();
        DataSet GetTicketDetails();
        DataSet GetDefaultStages();
        DataSet GetTransactionLog();

        DataSet TentativeBooking();
        DataSet ConfirmTentativeBooking();
    }
}
