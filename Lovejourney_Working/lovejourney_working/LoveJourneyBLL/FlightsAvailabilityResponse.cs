using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.DTO
{


    public class AvailableFlights
    {
        public FareDetails FareDetails { get; set; }
        public FlightSegments FlightSegments { get; set; }
        public OriginDestinationoptionId OriginDestinationoptionId { get; set; }

    }

    /// <summary>
    /// Stores the list of available flights of Domestic one way 
    /// </summary>
    public class FlightsAvailabilityResponse : List<AvailableFlights>
    {
        public FlightsAvailabilityResponse()
        {
        }

    }

    public class FlightSegments : List<FlightSegment>
    {
        public FlightSegments()
        {
        }

    }
    public class FareDetails
    {
        public ChargeableFares ChargeableFares { get; set; }
        public NonchargeableFares NonchargeableFares { get; set; }

        public double TotalFare
        {
            get
            {
                return ChargeableFares.ActualBaseFare + ChargeableFares.STax + ChargeableFares.Tax + NonchargeableFares.TMarkup + NonchargeableFares.TCharge;
            }
            set
            {
                TotalFare = value;
            }
        }
    }
    public class ChargeableFares
    {
        public double ActualBaseFare { get; set; }
        public double Tax { get; set; }
        public double STax { get; set; }
        public double SCharge { get; set; }
        public double TDiscount { get; set; }
        public double TPartnerCommission { get; set; }
    }
    public class NonchargeableFares
    {
        public double TCharge { get; set; }
        public double TMarkup { get; set; }
        public double TSdiscount { get; set; }
    }
    public class Request
    {
        public String Origin { get; set; }
        public String Destination { get; set; }
        public String DepartDate { get; set; }
    }
    public class BookingClass
    {
        public String Availability { get; set; }
        public String ResBookDesigCode { get; set; }
    }
    public class BookingClassFare
    {
        public String adultFare { get; set; }
        public String bookingclass { get; set; }
        public String classType { get; set; }
        public String farebasiscode { get; set; }
        public String Rule { get; set; }
        public String adultCommission { get; set; }
        public String childCommission { get; set; }
        public String commissionOnTCharge { get; set; }
    }
    public class FlightSegment
    {
        public String AirEquipType { get; set; }
        public String ArrivalAirportCode { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public String DepartureAirportCode { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public String FlightNumber { get; set; }
        public String OperatingAirlineCode { get; set; }
        public String OperatingAirlineFlightNumber { get; set; }
        public String RPH { get; set; }
        public String StopQuantity { get; set; }
        public String airLineName { get; set; }
        public String airportTax { get; set; }
        public String imageFileName { get; set; }
        public String viaFlight { get; set; }
        public String Discount { get; set; }
        public String airportTaxChild { get; set; }
        public String airportTaxInfant { get; set; }
        public String adultTaxBreakup { get; set; }
        public String childTaxBreakup { get; set; }
        public String infantTaxBreakup { get; set; }
        public String octax { get; set; }
        public BookingClass BookingClass { get; set; }
        public BookingClassFare BookingClassFare { get; set; }
    }
    public class OriginDestinationoptionId
    {
        public String id { get; set; }
        public String key { get; set; }
    }
    public class InternationalAvalibleFlights
    {
    }
}
