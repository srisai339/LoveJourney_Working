using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CookComputing;
using CookComputing.XmlRpc;

namespace BusAPILayer
{
    public interface IAbhiBusAPILayer
    {
        DataTable GetSources();
        DataTable GetDestinations(string sourceId);
        DataTable GetServices(string journeyDate, string sourceId, string destinationId);
        DataTable GetSeatLayout(string journeyDate, string sourceId, string destinationId, string serviceId, string seatSleeper);
        DataTable SeatBlocking(string journeyDate, string sourceId, string destinationId, string serviceId, string selectedSeats);
        DataTable SeatBooking(string journeyDate, string sourceId, string destinationId, string serviceId, string selectedSeats, string passengerGenderType
        , string passengerName, string boardingPointId, string custAddress, string custName, string custPhoneNo, string custEmailId, string referenceNo);
        DataTable GetTicketInfo(string bookingReferenceNumber);
        DataTable CancellationConfirmation(string ticketNo);
        DataTable TicketCancellation(string ticketNo);
    }

    public class AbhiBusConstants
    {
        public const string URL = "http://www.svrtravels.com/api/lovejourney/server.php?SecurityKey=LOVE@SVR";//LIVE  
        // "http://abhibus.net/svr/api/dev_api/server.php";//Demo
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetSources : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getSourceList")]
        object[] GetSources();
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetDestinations : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getDestinationList")]
        object[] GetDestinations(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetServices : IXmlRpcProxy
    {
        [XmlRpcMethod("select.bustojurney")]
        object[] GetServices(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetSeatLayout : IXmlRpcProxy
    {
        [XmlRpcMethod("index.busseating")]
        object[] GetSeatLayout(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusSeatBlocking : IXmlRpcProxy
    {
        [XmlRpcMethod("index.seatselection")]
        object[] SeatBlocking(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusCheckGender : IXmlRpcProxy
    {
        [XmlRpcMethod("index.checkgender")]
        object[] CheckGender(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusSeatBooking : IXmlRpcProxy
    {
        [XmlRpcMethod("index.seatbooking")]
        object[] SeatBooking(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusCheckFare : IXmlRpcProxy
    {
        [XmlRpcMethod("index.checkfare")]
        object[] CheckFare(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetStationsList : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getStationsList")]
        object[] GetStationsList(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusGetTicketInfo : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getTicket_ref_num")]
        object[] GetTicketInfo(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusCancellationConfirmation : IXmlRpcProxy
    {
        [XmlRpcMethod("index.cancellationconfirmation")]
        object[] CancellationConfirmation(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(AbhiBusConstants.URL)]
    public interface IAbhiBusTicketCancellation : IXmlRpcProxy
    {
        [XmlRpcMethod("index.ticketcancellation")]
        object[] TicketCancellation(XmlRpcStruct xrs);
    }
}