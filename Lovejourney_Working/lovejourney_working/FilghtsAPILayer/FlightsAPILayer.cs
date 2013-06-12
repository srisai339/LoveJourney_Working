using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using FilghtsAPILayer.SrvDomesticFlightAvailability;
using FilghtsAPILayer.SrvDomesticFlightPricing;
using FilghtsAPILayer.SrvDomesticFlightBookingRequest;
using FilghtsAPILayer.SrvDomesticFlightBookingStatus;
using FilghtsAPILayer.SrvDomesticFlightCancellation;
using FilghtsAPILayer.SrvDomesticFlightCancellationStatus;


namespace FilghtsAPILayer
{

   public class FlightsAPILayer : IFlightsAPILayer
    {
       
       DOMFlightAvailabilityPortTypeClient objSrvClient = new DOMFlightAvailabilityPortTypeClient();
       DOMFlightPricingPortTypeClient objSrvPricing = new DOMFlightPricingPortTypeClient();
       DOMFlightBookingPortTypeClient objSrvbookingRequest = new DOMFlightBookingPortTypeClient();
       DOMFlightBookingStatusPortTypeClient objSrvbookingStatus = new DOMFlightBookingStatusPortTypeClient();
       DOMFlightCancellationPortTypeClient objSrvCancellation = new DOMFlightCancellationPortTypeClient();
       DOMFlightCancellationStatusPortTypeClient objSrvCancellationStatus = new DOMFlightCancellationStatusPortTypeClient();

       public String GetAvailabilityfn(String xmlRequestData)
       {
           try
           {
               string result = objSrvClient.getAvailability(xmlRequestData);
               XmlDocument doc = new XmlDocument();
               doc.LoadXml(result);
               XmlNodeList xmlNodes = doc.SelectNodes("/Response__Depart/OriginDestinationOptions");
               foreach (XmlNode item in xmlNodes)
               {
                   Console.WriteLine(item.Value);
               }
               // XmlNodeReader xmlReader = new XmlNodeReader(doc);

               return result;
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvClient = null; }
       }

       public DataSet GetAvailability(String xmlRequestData)
       {
           try
           {  
                string result =  objSrvClient.getAvailability(xmlRequestData);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNodeList xmlNodes = doc.SelectNodes("/Response__Depart/OriginDestinationOptions");
                foreach (XmlNode  item in xmlNodes)
                {
                    Console.WriteLine(item.Value);
                }
               // XmlNodeReader xmlReader = new XmlNodeReader(doc);

                return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvClient = null; }
       }


       public String GetAvailabilityResponseString(String xmlRequestData)
       {
           try
           {
               return objSrvClient.getAvailability(xmlRequestData);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvClient = null; }
       }

       public DataSet GetPricingDetails(String xmlRequestData)
       //String xmlRequestData
       {
           try
           {
               //string res = "<pricingrequest><onwardFlights><OriginDestinationOption> <FareDetails><ChargeableFares> <ActualBaseFare>4040</ActualBaseFare><Tax>7387</Tax> <STax>26</STax><SCharge>30</SCharge> <TDiscount>0</TDiscount><TPartnerCommission>0</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>0</TCharge> <TMarkup>0</TMarkup><TSdiscount>0</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>320</AirEquipType><ArrivalAirportCode>DEL</ArrivalAirportCode><ArrivalDateTime>2010-08-20T10:20:00</ArrivalDateTime><DepartureAirportCode>BOM</DepartureAirportCode><DepartureDateTime>2010-08-20T08:05:00</DepartureDateTime><FlightNumber>3132</FlightNumber><OperatingAirlineCode>IT</OperatingAirlineCode><OperatingAirlineFlightNumber>3132</OperatingAirlineFlightNumber><RPH></RPH> <StopQuantity>1</StopQuantity><airLineName>Kingfisher</airLineName><airportTax>3579</airportTax><imageFileName>http://live.arzoo.com/FlightWS/image/KingFisher.gif</imageFileName> <BookingClass><Availability>7</Availability><ResBookDesigCode>T</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>2020</adultFare><bookingclass>T</bookingclass> <childFare>2020</childFare><classType>Economy</classType><farebasiscode>xN1zdEqLmKRsmxJvB/Kgzj7UOSzszdjV</farebasiscode><infantfare>1</infantfare> <Rule>This fare is Refundable|Booking Class : T|Re-Schedule Charges: Rs. 750 per sector + Faredifference (If any) + Service Fee of Rs. 250|Cancellation Charges : Basicfare of the tkt + Service Charges 250 Per Passenger Per Sector .|</Rule><adultCommission>0</adultCommission><childCommission>0</childCommission><commissionOnTCharge>0</commissionOnTCharge></BookingClassFare> <Discount>0</Discount><airportTaxChild>3579</airportTaxChild><airportTaxInfant>229</airportTaxInfant><adultTaxBreakup>3200,329,50</adultTaxBreakup><childTaxBreakup>3200,329,50</childTaxBreakup><infantTaxBreakup>0,229,0</infantTaxBreakup><octax>0</octax> </FlightSegment> </FlightSegments><id>arzoo522</id><key>NB3karb+zGFhWFSOTFWg8uvYJ89rnzkTT8mFR2the/SgRsmw+WicTJzH+TWN+pNURIyTJYKOWO8yH8+0tzpA4t8aEEvzaOE6ZnTtBotFDwLtSiN0xXjLziXqx3ygGRwt/h3zLRHjxTgfh9d8ZSmFYVI5MVaDylGwlJAs6+3xzqWDbQb1E1E9CVl/oieHRc6lg20G9RNQbftJqVylOP5Y7zIfz7S3O4J6mG25LJItzqWDbQb1E1E9CVl/oieHRc6lg20G9RNRPQlZf6Inh0XOpYNtBvUTUkeXcnTeD0zTR3uryFy1m9ApmdQdUHje0ThgZv6ARhgstoSe7i7sB3r9fDhZYRaCP13kbUZxiYlWWO8yH8+0tzrxyVouo+y8iljvMh/PtLc7PHVwsZ8mdWUdO2n4GWCb+m22xm149WdCjnlWX3YIqIycTJzH+TWN+QGbfvsGDYViWO8yH8+0tzkqHFkq24fdwljvMh/PtLc5KhxZKtuH3cJY7zIfz7S3OSocWSrbh93CWO8yH8+0tzkqHFkq24fdwljvMh/PtLc4KbvocyPcp2iNfBKKGuqmszaEuVisWRglDwLtSiN0xXi1l+aCMG0UUpX6qj4iV8Z1hWFSOTFWg8mrWSiOGehk6zaEuVisWRglDwLtSiN0xXs2hLlYrFkYJyvlWMJHTjCD9d2ZWMwwsaM2hLlYrFkYJQ8C7UojdMV5fVnNu/pKz679fDhZYRaCP+E1jInS751+WO8yH8+0tzlSOohPrIyZCQ/zni8QE42gY/7Uq8y16gc2hLlYrFkYJQ8C7UojdMV7NoS5WKxZGCUPAu1KI3TFeCNTliagjHDuLmtqjP0i6ABEVJ8T4jMBQrC3yeG8ID70=</key> </OriginDestinationOption></onwardFlights><returnFlights/> <telePhone/><email/> <creditcardno></creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>1</AdultPax><ChildPax>1</ChildPax><InfantPax>1</InfantPax></pricingrequest>";
               string result = objSrvPricing.getPricingDetails(xmlRequestData);
               return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvClient = null; }
       }

       public DataSet GetBookingDetails(String xmlRequestData)
           //
       {
           try
           {
              //string res = "<Bookingrequest><onwardFlights> <OriginDestinationOption><FareDetails> <ChargeableFares><ActualBaseFare>4040</ActualBaseFare> <Tax>7387</Tax><STax>26</STax> <SCharge>30</SCharge><TDiscount>0</TDiscount><TPartnerCommission>0</TPartnerCommission></ChargeableFares> <NonchargeableFares><TCharge>0</TCharge> <TMarkup>0</TMarkup><TSdiscount>0</TSdiscount> </NonchargeableFares></FareDetails> <FlightSegments> <FlightSegment><AirEquipType>320</AirEquipType><ArrivalAirportCode>DEL</ArrivalAirportCode><ArrivalDateTime>2010-08-20T10:20:00</ArrivalDateTime><DepartureAirportCode>BOM</DepartureAirportCode><DepartureDateTime>2010-08-20T08:05:00</DepartureDateTime><FlightNumber>3132</FlightNumber><OperatingAirlineCode>IT</OperatingAirlineCode><OperatingAirlineFlightNumber>3132</OperatingAirlineFlightNumber><RPH></RPH> <StopQuantity>1</StopQuantity><airLineName>Kingfisher</airLineName><airportTax>3579</airportTax><imageFileName>http://live.arzoo.com/FlightWS/image/KingFisher.gif</imageFileName> <BookingClass><Availability>7</Availability><ResBookDesigCode>T</ResBookDesigCode> </BookingClass><BookingClassFare> <adultFare>2020</adultFare><bookingclass>T</bookingclass> <childFare>2020</childFare><classType>Economy</classType><farebasiscode>xN1zdEqLmKRsmxJvB/Kgzj7UOSzszdjV</farebasiscode><infantfare>1</infantfare> <Rule>This fare is Refundable|Booking Class : T|Re-Schedule Charges: Rs. 750 per sector + Faredifference (If any) + Service Fee of Rs. 250|Cancellation Charges : Basicfare of the tkt + Service Charges 250 Per Passenger Per Sector .|</Rule><adultCommission>0</adultCommission><childCommission>0</childCommission><commissionOnTCharge>0</commissionOnTCharge></BookingClassFare> <Discount>0</Discount><airportTaxChild>3579</airportTaxChild><airportTaxInfant>229</airportTaxInfant><adultTaxBreakup>3200,329,50</adultTaxBreakup><childTaxBreakup>3200,329,50</childTaxBreakup><infantTaxBreakup>0,229,0</infantTaxBreakup><octax>0</octax> </FlightSegment> </FlightSegments><id>arzoo522</id><key>NB3karb+zGFhWFSOTFWg8uvYJ89rnzkTT8mFR2the/SgRsmw+WAu9icTJzH+TWN+pNURIyTJYKOWO8yH8+0tzpA4t8aEEvzaOE6ZnTtBotFDwLtSiN0xXjLziXqx3ygGRwt/h3zLRHjxTgfh9d8ZSmFYVI5MVaDylGwlJAs6+3xzqWDbQb1E1E9CVl/oieHRc6lg20G9RNQbftJqVylOP5Y7zIfz7S3O4J6mG25LJItzqWDbQb1E1E9CVl/oieHRc6lg20G9RNRPQlZf6Inh0XOpYNtBvUTUkeXcnTeD0zTR3uryFy1m9ApmdQdUHje0ThgZv6ARhgstoSe7i7sB3r9fDhZYRaCP13kbUZxiYlWWO8yH8+0tzrxyVouo+y8iljvMh/PtLc7PHVwsZ8mdWUdO2n4GWCb+m22xm149WdCjnlWX3YIqIycTJzH+TWN+QGbfvsGDYViWO8yH8+0tzkqHFkq24fdwljvMh/PtLc5KhxZKtuH3cJY7zIfz7S3OSocWSrbh93CWO8yH8+0tzkqHFkq24fdwljvMh/PtLc4KbvocyPcp2iNfBKKGuqmszaEuVisWRglDwLtSiN0xXi1l+aCMG0UUpX6qj4iV8Z1hWFSOTFWg8mrWSiOGehk6zaEuVisWRglDwLtSiN0xXs2hLlYrFkYJyvlWMJHTjCD9d2ZWMwwsaM2hLlYrFkYJQ8C7UojdMV5fVnNu/pKz679fDhZYRaCP+E1jInS751+WO8yH8+0tzlSOohPrIyZCQ/zni8QE42gY/7Uq8y16gc2hLlYrFkYJQ8C7UojdMV7NoS5WKxZGCUPAu1KI3TFeCNTliagjHDuLmtqjP0i6ABEVJ8T4jMBQrC3yeG8ID70=</key> </OriginDestinationOption></onwardFlights><returnFlights/><personName><CustomerInfo><givenName>jayesh</givenName><surName>patel</surName><nameReference>Mr.</nameReference><psgrtype>adt</psgrtype></CustomerInfo><CustomerInfo><givenName>rahul</givenName><surName>mae</surName><nameReference>Mstr.</nameReference><dob>11-Mar-2009</dob><age>1</age><psgrtype>inf</psgrtype></CustomerInfo><CustomerInfo><givenName>mahesh</givenName><surName>patel</surName><nameReference>Mstr.</nameReference><dob>21-Mar-2007</dob><age>03</age><psgrtype>chd</psgrtype></CustomerInfo></personName><telePhone><phoneNumber>9979920443</phoneNumber></telePhone><email><emailAddress>info@mavencorp.com</emailAddress></email><creditcardno>4111111111111111</creditcardno><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword> <partnerRefId>100200</partnerRefId> <Clienttype>ArzooFWS1.1</Clienttype><AdultPax>1</AdultPax><ChildPax>1</ChildPax><InfantPax>1</InfantPax></Bookingrequest>";
               string result = objSrvbookingRequest.getBookingDetails(xmlRequestData);
               return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvbookingRequest = null; }
       }

       public DataSet GetBookingStatusDetails(String xmlRequestData)
       //String xmlRequestData
       {
           DOMFlightBookingStatusPortTypeClient objSrvbookingStatus = new DOMFlightBookingStatusPortTypeClient();
           try
           {
              
             // string res = "<EticketRequest><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype> ArzooFWS1.0/ ArzooFWS1.1</Clienttype><transid>1513</transid><partnerRefId>100200</partnerRefId></EticketRequest>";
              string result = objSrvbookingStatus.getBookingStatus(xmlRequestData);
              // string result = "<EticketDetails><requestedPNR><origindestinationoptions><OriDestPNRRequest><origin>BOM</origin><destin>DEL</destin><depttime>2009-07-23T08:05:00</depttime><arrivaltime>2009-07-23T10:05:00</arrivaltime><flightno>3301</flightno><airline>IT</airline><cabin>T</cabin><noofpassengers>1</noofpassengers><eticketdto><Eticket><givenName>vimal</givenName><surName>lad</surName><nameReference>Mr.</nameReference><eticketno>4656876846</eticketno><flightuid>45972</flightuid><passuid>83027</passuid></Eticket></eticketdto><farebasiscode>adsdsR5AzSfNCYif+taX7/x6U5RlG4bCvs1rC3yeG8ID70=</farebasiscode><confirmationid>adfa</confirmationid><pnrnumber>adfa</pnrnumber></OriDestPNRRequest><OriDestPNRRequest><origin>DEL</origin><destin>BOM</destin><depttime>2009-07-24T21:25:00</depttime><arrivaltime>2009-07-24T23:25:00</arrivaltime><flightno>3348</flightno><airline>IT</airline><cabin>T</cabin><noofpassengers>1</noofpassengers><eticketdto><Eticket><givenName>vimal</givenName><surName>lad</surName><nameReference>Mr.</nameReference><eticketno>57686846465</eticketno><flightuid>45973</flightuid><passuid>83028</passuid></Eticket></eticketdto><farebasiscode>dsR5AzSfNCYif+taX7/x6U5RlG4bCvs1rC3yeG8ID70=</farebasiscode><confirmationid>sfgsgf</confirmationid><pnrnumber>sfgsgf</pnrnumber></OriDestPNRRequest></origindestinationoptions><personName><CustomerInfo><givenName>vimal</givenName><surName>lad</surName><nameReference>Mr.</nameReference><dob></dob><age>0</age></CustomerInfo></personName><telePhone><phoneNumber>9967517706</phoneNumber></telePhone><email><emailAddress>bhavik.m@navin.com</emailAddress></email><Clientid> Given by Arzoo.com</Clientid><Clienttype>ArzooFWS1.1</Clienttype><AdultPax>1</AdultPax><ChildPax>0</ChildPax><InfantPax>0</InfantPax><transid>A001721</transid><status>SuccessTkd</status></requestedPNR></EticketDetails>";

               return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvbookingStatus = null; }
       }
       public DataSet CancelTicket(String xmlRequestData)
       //
       {
           try
           {
               //string res = "<CancelationDetails><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.1</Clienttype><transid>A554944</transid><status>Successtkd</status><remarks>Hi transaction</remarks><eticketdto><Eticket><givenName>SABJE</givenName><surName>YL</surName><nameReference>Mr</nameReference><eticketno>0903735642632C1</eticketno><flightuid>587139</flightuid><passuid>796859</passuid></Eticket><Eticket><givenName>KUMAR</givenName><surName>SAGAR</surName><nameReference>Mr.</nameReference><eticketno>0903735642633C1</eticketno><flightuid>587139</flightuid><passuid>796860</passuid></Eticket></eticketdto></CancelationDetails>";
              string result = objSrvCancellation.getCancelation(xmlRequestData);
              return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvCancellation = null; }
       }
       public DataSet GetCancelTicketStatus(String xmlRequestData)
       //String xmlRequestData
       {
           try
           {
              // string res = "<EticketCanStatusReq><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooFWS1.0</Clienttype><transid>A419044</transid><partnerRefId></partnerRefId><CancellationId></CancellationId></EticketCanStatusReq>";
               string result = objSrvCancellationStatus.getCancelationStatus(xmlRequestData);
               return ConvertXMLStringToDataSet(result);
           }
           catch (System.Exception)
           {
               throw;
           }
           finally { objSrvCancellationStatus = null; }
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
