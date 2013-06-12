using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BAL.DTO;
using FilghtsAPILayer;

namespace BAL
{
   public class FlightsAvailabilityManager
    {
        FlightsAPILayer objFlights = new FlightsAPILayer();
       /// <summary>
       /// Get the flights avalibility response and assigning the values to the params 
       /// </summary>
       /// <param name="xmlRequestData"></param>
       /// <returns></returns>

        public FlightsAvailabilityResponse GetAvailableFlights(String xmlRequestData)
        {
            FlightsAvailabilityResponse objFlightsAvailabilityResponse = new FlightsAvailabilityResponse();
            AvailableFlights objAvailableFlights = null;
            try
            {
                string result = objFlights.GetAvailabilityfn(xmlRequestData);
                BookingClass objBookingClass = null;
                BookingClassFare objBookingClassFare = null;
                ChargeableFares objChargeableFares = null;
                FareDetails objFareDetails = null;
                FlightSegment objFlightSegment = null;
                FlightSegments objFlightSegments = null;
                NonchargeableFares objNonchargeableFares = null;
                OriginDestinationoptionId objOriginDestinationoptionId = null;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNodeList xmlNodes = doc.SelectNodes("//Response__Depart/OriginDestinationOptions/OriginDestinationOption");

                foreach (XmlNode node in xmlNodes)
                {
                    objAvailableFlights = new AvailableFlights();
                    objChargeableFares = new ChargeableFares();
                    objNonchargeableFares = new NonchargeableFares();
                    objFareDetails = new FareDetails();
                    objOriginDestinationoptionId=new OriginDestinationoptionId();
                    
                    //ChargeableFares
                    objChargeableFares.ActualBaseFare = double.Parse(node["FareDetails"]["ChargeableFares"]["ActualBaseFare"].InnerXml);
                    objChargeableFares.Tax = double.Parse(node["FareDetails"]["ChargeableFares"]["Tax"].InnerXml);
                    objChargeableFares.STax = double.Parse(node["FareDetails"]["ChargeableFares"]["STax"].InnerXml);
                    objChargeableFares.SCharge = double.Parse(node["FareDetails"]["ChargeableFares"]["SCharge"].InnerXml);
                    objChargeableFares.TDiscount = double.Parse(node["FareDetails"]["ChargeableFares"]["TDiscount"].InnerXml);
                    objChargeableFares.TPartnerCommission = double.Parse(node["FareDetails"]["ChargeableFares"]["TPartnerCommission"].InnerXml);
                    objFareDetails.ChargeableFares = objChargeableFares;

                    //Non ChargeableFares
                    objNonchargeableFares.TCharge = double.Parse(node["FareDetails"]["NonchargeableFares"]["TCharge"].InnerXml);
                    objNonchargeableFares.TMarkup = double.Parse(node["FareDetails"]["NonchargeableFares"]["TMarkup"].InnerXml);
                    objNonchargeableFares.TSdiscount = double.Parse(node["FareDetails"]["NonchargeableFares"]["TSdiscount"].InnerXml);
                    objFareDetails.NonchargeableFares = objNonchargeableFares;

                    objFlightSegments = new FlightSegments();

                    foreach (XmlNode childnode in node["FlightSegments"].ChildNodes)
                    {
                        objFlightSegment = new FlightSegment();
                        //Flight Segment
                        objFlightSegment.AirEquipType = childnode["AirEquipType"].InnerXml;
                        objFlightSegment.ArrivalAirportCode = childnode["ArrivalAirportCode"].InnerXml;
                        objFlightSegment.ArrivalDateTime = Convert.ToDateTime(childnode["ArrivalDateTime"].InnerXml);
                        objFlightSegment.DepartureAirportCode = childnode["DepartureAirportCode"].InnerXml;
                        objFlightSegment.DepartureDateTime = Convert.ToDateTime(childnode["DepartureDateTime"].InnerXml);
                        objFlightSegment.FlightNumber = childnode["FlightNumber"].InnerXml;
                        objFlightSegment.OperatingAirlineCode = childnode["OperatingAirlineCode"].InnerXml;
                        objFlightSegment.OperatingAirlineFlightNumber = childnode["OperatingAirlineFlightNumber"].InnerXml;
                        objFlightSegment.RPH = childnode["RPH"].InnerXml;
                        objFlightSegment.StopQuantity = childnode["StopQuantity"].InnerXml;
                        objFlightSegment.airLineName = childnode["airLineName"].InnerXml;
                        objFlightSegment.airportTax = childnode["airportTax"].InnerXml;
                        objFlightSegment.imageFileName = childnode["imageFileName"].InnerXml;
                        objFlightSegment.viaFlight = childnode["viaFlight"].InnerXml;
                        objFlightSegment.Discount = childnode["Discount"].InnerXml;
                        objFlightSegment.airportTaxChild = childnode["airportTaxChild"].InnerXml;
                        objFlightSegment.airportTaxInfant = childnode["airportTaxInfant"].InnerXml;
                        objFlightSegment.adultTaxBreakup = childnode["adultTaxBreakup"].InnerXml;
                        objFlightSegment.childTaxBreakup = childnode["childTaxBreakup"].InnerXml;
                        objFlightSegment.infantTaxBreakup = childnode["infantTaxBreakup"].InnerXml;
                        objFlightSegment.octax = childnode["octax"].InnerXml;
                        //BookingClass
                        objBookingClass = new BookingClass();
                        objBookingClass.Availability = childnode["BookingClass"]["Availability"].InnerXml;
                        objBookingClass.ResBookDesigCode = childnode["BookingClass"]["ResBookDesigCode"].InnerXml;
                        objFlightSegment.BookingClass = objBookingClass;

                        //BookingClassFare
                        objBookingClassFare = new BookingClassFare();
                        objBookingClassFare.adultFare = childnode["BookingClassFare"]["adultFare"].InnerXml;
                        objBookingClassFare.bookingclass = childnode["BookingClassFare"]["bookingclass"].InnerXml;
                        objBookingClassFare.classType = childnode["BookingClassFare"]["classType"].InnerXml;
                        objBookingClassFare.farebasiscode = childnode["BookingClassFare"]["farebasiscode"].InnerXml;
                        objBookingClassFare.Rule = childnode["BookingClassFare"]["Rule"].InnerXml;
                        objBookingClassFare.adultCommission = childnode["BookingClassFare"]["adultCommission"].InnerXml;
                        objBookingClassFare.childCommission = childnode["BookingClassFare"]["childCommission"].InnerXml;
                        objBookingClassFare.commissionOnTCharge = childnode["BookingClassFare"]["commissionOnTCharge"].InnerXml;
                        objFlightSegment.BookingClassFare = objBookingClassFare;

                        objFlightSegments.Add(objFlightSegment);
                    }
                    

                    //OrigindestinationOptionId
                    objOriginDestinationoptionId.id = node["id"].InnerXml;
                    objOriginDestinationoptionId.key = node["key"].InnerXml;

                    objAvailableFlights.FareDetails = objFareDetails;
                    objAvailableFlights.FlightSegments = objFlightSegments;
                    objAvailableFlights.OriginDestinationoptionId = objOriginDestinationoptionId;
                    objFlightsAvailabilityResponse.Add(objAvailableFlights);
                }
            }
            catch (Exception ex)
            {
            }
            return objFlightsAvailabilityResponse;

            List<AvailableFlights> AvailableFlights = objFlightsAvailabilityResponse.Where(e => e.FlightSegments.Count > 1).ToList();
            foreach (AvailableFlights item in AvailableFlights)
            {
               // item.FlightSegments.
            }
        }
       
    }
}
