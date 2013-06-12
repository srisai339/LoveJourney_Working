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
    public interface IKalladaAPILayer
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

    public class KalladaConstants
    {
        public const string URL = ""; //Demo
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetSources : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getSourceList")]
        object[] GetSources();
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetDestinations : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getDestinationList")]
        object[] GetDestinations(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetServices : IXmlRpcProxy
    {
        [XmlRpcMethod("select.bustojurney")]
        object[] GetServices(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetSeatLayout : IXmlRpcProxy
    {
        [XmlRpcMethod("index.busseating")]
        object[] GetSeatLayout(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaSeatBlocking : IXmlRpcProxy
    {
        [XmlRpcMethod("index.seatselection")]
        object[] SeatBlocking(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaCheckGender : IXmlRpcProxy
    {
        [XmlRpcMethod("index.checkgender")]
        object[] CheckGender(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaSeatBooking : IXmlRpcProxy
    {
        [XmlRpcMethod("index.seatbooking")]
        object[] SeatBooking(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaCheckFare : IXmlRpcProxy
    {
        [XmlRpcMethod("index.checkfare")]
        object[] CheckFare(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetStationsList : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getStationsList")]
        object[] GetStationsList(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaGetTicketInfo : IXmlRpcProxy
    {
        [XmlRpcMethod("index.getTicket_ref_num")]
        object[] GetTicketInfo(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaCancellationConfirmation : IXmlRpcProxy
    {
        [XmlRpcMethod("index.cancellationconfirmation")]
        object[] CancellationConfirmation(XmlRpcStruct xrs);
    }

    [XmlRpcUrl(KalladaConstants.URL)]
    public interface IKalladaTicketCancellation : IXmlRpcProxy
    {
        [XmlRpcMethod("index.ticketcancellation")]
        object[] TicketCancellation(XmlRpcStruct xrs);
    }
}
