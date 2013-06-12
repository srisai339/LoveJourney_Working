using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FilghtsAPILayer;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Data.OleDb;
using System.Globalization;
using BAL;
public partial class Sample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //string xmlRequest1 = "<PriceRequest><noadults>1</noadults><nochild>0</nochild><noinfant>0</noinfant><Clientid>77743504</Clientid><Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails><ActualBaseFare>1000</ActualBaseFare><Tax>5184</Tax><STax>13</STax><TCharge>0</TCharge><SCharge>0</SCharge><TDiscount>0</TDiscount><TMarkup>0</TMarkup><TPartnerCommission>0</TPartnerCommission><TSdiscount>0</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>ADT</PsgrType><BaseFare>1000</BaseFare><Tax>5184</Tax></Fare></FareAry></FareBreakup><ocTax>0</ocTax></FareDetails><onward><FlightSegments><FlightSegment><AirEquipType>319</AirEquipType><ArrivalAirportCode>BOM</ArrivalAirportCode><ArrivalAirportName>MUMBAI</ArrivalAirportName><ArrivalDateTime>2012-12-15T23:05:00</ArrivalDateTime><DepartureAirportCode>BLR</DepartureAirportCode><DepartureAirportName>BANGALORE</DepartureAirportName><DepartureDateTime>2012-12-15T21:40:00</DepartureDateTime><FlightNumber>57</FlightNumber><MarketingAirlineCode>AI</MarketingAirlineCode><OperatingAirlineCode>AI</OperatingAirlineCode><OperatingAirlineName>Air India </OperatingAirlineName><OperatingAirlineFlightNumber>57</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt></LinkSellAgrmnt><Conx>N</Conx><AirpChg>N</AirpChg><InsideAvailOption>C</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>NA</DaysOperates><JrnyTm>85</JrnyTm><EndDt></EndDt><StartTerminal></StartTerminal><EndTerminal></EndTerminal><FltTm>85</FltTm><LSAInd>R</LSAInd><Mile>0</Mile><BookingClass><Availability>9</Availability><BIC>E</BIC></BookingClass><BookingClassFare><bookingclass>E</bookingclass><classType>Economy</classType><farebasiscode>wOV2SPbPbKYens5pMtaPkYnDM963BJmv</farebasiscode><Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>ADT</PsgrType><BaseFare>1000</BaseFare><Tax>5184</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment></FlightSegments></onward><Return><FlightSegments><FlightSegment><AirEquipType>319</AirEquipType><ArrivalAirportCode>BLR</ArrivalAirportCode><ArrivalAirportName>BANGALORE</ArrivalAirportName><ArrivalDateTime>2012-12-16T07:50:00</ArrivalDateTime><DepartureAirportCode>BOM</DepartureAirportCode><DepartureAirportName>MUMBAI</DepartureAirportName><DepartureDateTime>2012-12-16T06:15:00</DepartureDateTime><FlightNumber>603</FlightNumber><MarketingAirlineCode>AI</MarketingAirlineCode><OperatingAirlineCode>AI</OperatingAirlineCode><OperatingAirlineName>Air India </OperatingAirlineName><OperatingAirlineFlightNumber>603</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt></LinkSellAgrmnt><Conx>N</Conx><AirpChg>N</AirpChg><InsideAvailOption>C</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>NA</DaysOperates><JrnyTm>95</JrnyTm><EndDt></EndDt><StartTerminal></StartTerminal><EndTerminal></EndTerminal><FltTm>95</FltTm><LSAInd>R</LSAInd><Mile>0</Mile><BookingClass><Availability>9</Availability><BIC>E</BIC></BookingClass><BookingClassFare><bookingclass>E</bookingclass><classType>Economy</classType><farebasiscode>wOV2SPbPbKaCDnbK4mqIXRihwzerI1ne</farebasiscode><Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule><PsgrBreakup><PsgrAry><Psgr><PsgrType>ADT</PsgrType><BaseFare>1000</BaseFare><Tax>5184</Tax><BagInfo></BagInfo></Psgr></PsgrAry></PsgrBreakup></BookingClassFare></FlightSegment></FlightSegments></Return><id>arzoo11</id><key>VPKmHGlQh9Nf68R2DgKcVEb0gG2ZuxB2FLqYOFDxMR3QweTiPhdGIWgoifR/a2CjF0y8ZIwbhDbDvXFXubDdI0yOy54o8SWMZ+Lq5Tx3+M+2Q/P5Ci0UbF/rxHYOApxUDGWf4lPayrbQweTiPhdGIWgoifR/a2Cj6xVBmZQfx+ONy3thiCpYihRRnjyQGrh7hXWLu9m7LCssMPJ4Xz20E7cCU/hS9xGE+mdK+SICvYvDvXFXubDdIyuoEEf9FbAN4z7uuUBbuJV0ouCOH4QaD+k2w/1qSPBE4z7uuUBbuJVNq/UVRvg/WtDB5OI+F0YhaCiJ9H9rYKNiGWZ6hnYEx2fi6uU8d/jPAJdXKqYIvc4G4/CnURsDDTRYOvT4LVSE6xVBmZQfx+ONy3thiCpYikgRopJOZai5w71xV7mw3SOesti0ItOrM+qV6E/q3ryX4z7uuUBbuJVda06JiVzmQUUgFFphcCIuvnVFO8AedynQweTiPhdGIWgoifR/a2Cj/x562eQ8mWGFdYu72bssKykPmE7e7Vckw71xV7mw3SMM4z/e5ecAlWfi6uU8d/jP6QTJIx7E7Cjbx5zXegGAqsFRya6sKP09Sl4PTujxTq6MdVbaZLgdZmfi6uU8d/jPc0vlJ6zY98Jf68R2DgKcVEq37Y9lij4K0MHk4j4XRiFoKIn0f2tgo51XOIbdOgzsjct7YYgqWIpMQTjfSsjs79DB5OI+F0YhjwQ49dcmD0Zf68R2DgKcVEb0gG2ZuxB2Ymljz7Jt+uxf68R2DgKcVIdXMpFp5ybFpzEnkkuqrQOFdYu72bssK8B/JXVs9wCQpsXbYPlh18e3AlP4UvcRhPszpM3pCk/Y8rOOQMBvKzF7N7wk78NqqWfi6uU8d/jPLmp2mCCDyS/6HY9WWHlNq43Le2GIKliKadxQ6KRNzfZf68R2DgKcVOG7Ak+7kG5iwEhReMn6OwqzU04tGMz9NQuxHamOEDbVhXWLu9m7LCux62ssK0JY7eM+7rlAW7iVfZJw+YOHO2pf68R2DgKcVMLEthddewVqJ7aSSWnh5fmFdYu72bssKwnJRP/BQ9ShWgiWz87bQd6dUa/9uomqs+7CdvGAl0R2K93ud9fi+3mFdYu72bssK/mKCFwKiLWJtwJT+FL3EYRUYaKc70aEusO9cVe5sN0jof5yvfPeDtPjPu65QFu4lUmyf7gwDarOZk6/VHXsuA9K+aSnWj/m/puvinZBp1sD8Be4EBVranF6OlZecQ402/y3byvX9EEQjct7YYgqWIoUUZ48kBq4e4V1i7vZuywrLDDyeF89tBPwF7gQFWtqcXo6Vl5xDjTbZAkUMnAhCee3AlP4UvcRhHiI8KrWfN9LX+vEdg4CnFRzilKpKQyGezvpme4elChwtwJT+FL3EYSnqucah/n2/F/rxHYOApxUoQF7zhL9jcRf68R2DgKcVCB0cQSVLEagq7GeXeeb+55n4urlPHf4zyNTdMhpz8OLZ+Lq5Tx3+M81gDZwUvU5ixRRnjyQGrh7OBqQFB0C1pien+rHTKbEQyzNx7W8ezRi/dTqd6KPbtDQweTiPhdGIbr9FdWgB5am</key></OriginDestinationOption></PriceRequest>";
        //string xmlRequest = "xmlRequest=%3cBookingrequest%3e%3cnoadults%3e1%3c%2fnoadults%3e%3cnochild%3e0%3c%2fnochild%3e%3cnoinfant%3e0%3c%2fnoinfant%3e%3cClientid%3e77743504%3c%2fClientid%3e%3cClientpassword%3e*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0%3c%2fClientpassword%3e%3cClienttype%3eArzooINTLWS1.0%3c%2fClienttype%3e%3ccreditcardno%3e1234567890123456%3c%2fcreditcardno%3e%3cPartnerreferenceID%3e100215%3c%2fPartnerreferenceID%3e%3cpersonName%3e%3cCustomerInfo%3e%3cgivenName%3eBindu%3c%2fgivenName%3e+%3csurName%3eB%3c%2fsurName%3e%3cnameReference%3eMrs.%3c%2fnameReference%3e%3cpsgrtype%3eadt%3c%2fpsgrtype%3e%3c%2fCustomerInfo%3e%3c%2fpersonName%3e%3ctelePhone%3e%3cphoneNumber%3e9701213996%3c%2fphoneNumber%3e%3c%2ftelePhone%3e%3cemail%3e%3cemailAddress%3ebindu.v%40i2space.com%3c%2femailAddress%3e%3c%2femail%3e%3cOriginDestinationOption%3e%3cFareDetails%3e%3cActualBaseFare%3e21250%3c%2fActualBaseFare%3e%3cTax%3e19675%3c%2fTax%3e%3cSTax%3e264%3c%2fSTax%3e%3cTCharge%3e0%3c%2fTCharge%3e%3cSCharge%3e0%3c%2fSCharge%3e%3cTDiscount%3e0%3c%2fTDiscount%3e%3cTMarkup%3e0%3c%2fTMarkup%3e%3cTPartnerCommission%3e0%3c%2fTPartnerCommission%3e%3cTSdiscount%3e0%3c%2fTSdiscount%3e%3cFareBreakup%3e%3cFareAry%3e%3cFare%3e%3cPsgrType%3eADT%3c%2fPsgrType%3e%3cBaseFare%3e21250%3c%2fBaseFare%3e%3cTax%3e19675%3c%2fTax%3e%3cTaxDataAry%3e%3cTaxData%3e%3cCountry%3eYQ%3c%2fCountry%3e%3cAmt%3e0%3c%2fAmt%3e%3c%2fTaxData%3e%3cTaxData%3e%3cCountry%3eWO%3c%2fCountry%3e%3cAmt%3e7108%3c%2fAmt%3e%3c%2fTaxData%3e%3cTaxData%3e%3cCountry%3eOther%3c%2fCountry%3e%3cAmt%3e12567%3c%2fAmt%3e%3c%2fTaxData%3e%3c%2fTaxDataAry%3e%3c%2fFare%3e%3c%2fFareAry%3e%3c%2fFareBreakup%3e%3cocTax%3e0%3c%2focTax%3e%3c%2fFareDetails%3e%3conward%3e%3cFlightSegments%3e%3cFlightSegment%3e%3cAirEquipType%3e744%3c%2fAirEquipType%3e%3cArrivalAirportCode%3eLHR%3c%2fArrivalAirportCode%3e%3cArrivalAirportName%3eLondon%3c%2fArrivalAirportName%3e%3cArrivalDateTime%3e2012-11-19T13%3a25%3a00%3c%2fArrivalDateTime%3e%3cDepartureAirportCode%3eBLR%3c%2fDepartureAirportCode%3e%3cDepartureAirportName%3eBANGALORE%3c%2fDepartureAirportName%3e%3cDepartureDateTime%3e2012-11-19T07%3a50%3a00%3c%2fDepartureDateTime%3e%3cFlightNumber%3e6656%3c%2fFlightNumber%3e%3cMarketingAirlineCode%3eAA%3c%2fMarketingAirlineCode%3e%3cOperatingAirlineCode%3eBA%3c%2fOperatingAirlineCode%3e%3cOperatingAirlineName%3eAmerican+Airlines+%3c%2fOperatingAirlineName%3e%3cOperatingAirlineFlightNumber%3e6656%3c%2fOperatingAirlineFlightNumber%3e%3cNumStops%3e0%3c%2fNumStops%3e%3cLinkSellAgrmnt+%2f%3e%3cConx%3eN%3c%2fConx%3e%3cAirpChg%3eN%3c%2fAirpChg%3e%3cInsideAvailOption%3eC%3c%2fInsideAvailOption%3e%3cGenTrafRestriction%3e%3f%3c%2fGenTrafRestriction%3e%3cDaysOperates%3eNA%3c%2fDaysOperates%3e%3cJrnyTm%3e665%3c%2fJrnyTm%3e%3cEndDt+%2f%3e%3cStartTerminal+%2f%3e%3cEndTerminal+%2f%3e%3cFltTm%3e665%3c%2fFltTm%3e%3cLSAInd%3eR%3c%2fLSAInd%3e%3cMile%3e0%3c%2fMile%3e%3cBookingClass%3e%3cAvailability%3e1%3c%2fAvailability%3e%3cBIC%3eS%3c%2fBIC%3e%3c%2fBookingClass%3e%3cBookingClassFare%3e%3cbookingclass%3eS%3c%2fbookingclass%3e%3cclassType%3eEconomy%3c%2fclassType%3e%3cfarebasiscode%3eZeHo17My7PSA3CBU2WO9J34bX8FEuX61F9zkShsUkYU%3d%3c%2ffarebasiscode%3e%3cRule%3eCancellation+Penalty%3a+All+bookings+done+are+subject+to+the+cancellation+penalty+levied+by+the+respective+airline.%26lt%3bbr%26gt%3bIn+addition+to+the+airline''s+cancellation+penalty%2c+we+charge+a+service+fee+of+Rs.+200+per+passenger+for+all+cancellations.%7cDate+Change+Penalty%3a+In+addition+to+the+airline''s+date+change+penalty%2c+we+charge+a+service+fee+of+Rs.+250+per+passenger+for+any+date+changes.%7c%3c%2fRule%3e%3cPsgrBreakup%3e%3cPsgrAry%3e%3cPsgr%3e%3cPsgrType%3eADT%3c%2fPsgrType%3e%3cBaseFare%3e21250%3c%2fBaseFare%3e%3cTax%3e19675%3c%2fTax%3e%3cBagInfo+%2f%3e%3c%2fPsgr%3e%3c%2fPsgrAry%3e%3c%2fPsgrBreakup%3e%3c%2fBookingClassFare%3e%3c%2fFlightSegment%3e%3cFlightSegment%3e%3cAirEquipType%3e777%3c%2fAirEquipType%3e%3cArrivalAirportCode%3eJFK%3c%2fArrivalAirportCode%3e%3cArrivalAirportName%3eNEW+YORK%3c%2fArrivalAirportName%3e%3cArrivalDateTime%3e2012-11-19T18%3a10%3a00%3c%2fArrivalDateTime%3e%3cDepartureAirportCode%3eLHR%3c%2fDepartureAirportCode%3e%3cDepartureAirportName%3eLondon%3c%2fDepartureAirportName%3e%3cDepartureDateTime%3e2012-11-19T15%3a15%3a00%3c%2fDepartureDateTime%3e%3cFlightNumber%3e6134%3c%2fFlightNumber%3e%3cMarketingAirlineCode%3eAA%3c%2fMarketingAirlineCode%3e%3cOperatingAirlineCode%3eBA%3c%2fOperatingAirlineCode%3e%3cOperatingAirlineName%3eAmerican+Airlines+%3c%2fOperatingAirlineName%3e%3cOperatingAirlineFlightNumber%3e6134%3c%2fOperatingAirlineFlightNumber%3e%3cNumStops%3e0%3c%2fNumStops%3e%3cLinkSellAgrmnt+%2f%3e%3cConx%3eN%3c%2fConx%3e%3cAirpChg%3eN%3c%2fAirpChg%3e%3cInsideAvailOption%3eC%3c%2fInsideAvailOption%3e%3cGenTrafRestriction%3e%3f%3c%2fGenTrafRestriction%3e%3cDaysOperates%3eNA%3c%2fDaysOperates%3e%3cJrnyTm%3e985%3c%2fJrnyTm%3e%3cEndDt+%2f%3e%3cStartTerminal+%2f%3e%3cEndTerminal+%2f%3e%3cFltTm%3e985%3c%2fFltTm%3e%3cLSAInd%3eR%3c%2fLSAInd%3e%3cMile%3e0%3c%2fMile%3e%3cBookingClass%3e%3cAvailability%3e7%3c%2fAvailability%3e%3cBIC%3eS%3c%2fBIC%3e%3c%2fBookingClass%3e%3cBookingClassFare%3e%3cbookingclass%3eS%3c%2fbookingclass%3e%3cclassType%3eEconomy%3c%2fclassType%3e%3cfarebasiscode%3eZeHo17My7PSA3CBU2WO9J34bX8FEuX61F9zkShsUkYU%3d%3c%2ffarebasiscode%3e%3cRule%3eCancellation+Penalty%3a+All+bookings+done+are+subject+to+the+cancellation+penalty+levied+by+the+respective+airline.%26lt%3bbr%26gt%3bIn+addition+to+the+airline''s+cancellation+penalty%2c+we+charge+a+service+fee+of+Rs.+200+per+passenger+for+all+cancellations.%7cDate+Change+Penalty%3a+In+addition+to+the+airline''s+date+change+penalty%2c+we+charge+a+service+fee+of+Rs.+250+per+passenger+for+any+date+changes.%7c%3c%2fRule%3e%3cPsgrBreakup%3e%3cPsgrAry%3e%3cPsgr%3e%3cPsgrType%3eADT%3c%2fPsgrType%3e%3cBaseFare%3e21250%3c%2fBaseFare%3e%3cTax%3e19675%3c%2fTax%3e%3cBagInfo+%2f%3e%3c%2fPsgr%3e%3c%2fPsgrAry%3e%3c%2fPsgrBreakup%3e%3c%2fBookingClassFare%3e%3c%2fFlightSegment%3e%3c%2fFlightSegments%3e%3c%2fonward%3e%3cReturn+%2f%3e%3cid%3earzoo13%3c%2fid%3e%3ckey%3ezWbxBFyA059f68R2DgKcVEb0gG2ZuxB2eOVHvZcIhsrrFUGZlB%2fH443Le2GIKliKcDol4S0eYt5n4urlPHf4zwkxESOCSurS2zJT2fsu8E6Ny3thiCpYihRRnjyQGrh7hXWLu9m7LCssMPJ4Xz20E7cCU%2fhS9xGE%2bmdK%2bSICvYvDvXFXubDdIyuoEEf9FbAN4z7uuUBbuJWfy8uNPG%2f9b2fi6uU8d%2fjPtkPz%2bQotFGxf68R2DgKcVAxln%2bJT2sq20MHk4j4XRiE%2bdv3J10pg7QerGRHTwDoP0MHk4j4XRiFoKIn0f2tgo%2f6%2fbBnC356utwJT%2bFL3EYQxhMrs9%2bLl73qUfflxOSlgjct7YYgqWIooknPUNPq0fsMbz0mCCnYdPxS%2fgiio89vDvXFXubDdI5p3QtIQ6TM%2bX%2bvEdg4CnFSHVzKRaecmxRqaN5ZXELxy0MHk4j4XRiFoKIn0f2tgo08iYOkW5WfDVAdtvjUETBAUbFQMZCvw%2frcCU%2fhS9xGEV%2fKirOjbVWVf68R2DgKcVIdXMpFp5ybFFnoP%2frNoJySNy3thiCpYinP52%2ba6dCWv4z7uuUBbuJUr4zgoGssePSsZx2FQz4QzMi4GIKZ%2fbQN5v2nhdWyUxWkXlLIRnKfWBOVnFhmDx7P%2bRkIizk8EmY3Le2GIKliKvHScqTjHzQGFdYu72bssK9yA%2fLGYY4DttwJT%2bFL3EYR8llOd%2fAvvBcO9cVe5sN0jaHWZ74lyniM%2bCXHuBVUeI0eCjTlyW%2bv3IvPKAXmAs%2fXjPu65QFu4lRIiMi13yfqv0MHk4j4XRiFoKIn0f2tgo3rxF%2fw%2fvseO0MHk4j4XRiFoKIn0f2tgo08iYOkW5WfDtBFngPW6tS4UbFQMZCvw%2frcCU%2fhS9xGEPmH%2brCYA9GVn4urlPHf4z%2fKpTLVv6TwZmq%2fOLBKU%2burDvXFXubDdI76GeeoT8f7%2fmZIC7bwXLBPEyJNwmQ0Hhl%2frxHYOApxUwsS2F117BWpVx8rwsmCp%2f7cCU%2fhS9xGEO2M3JTnaOUPjPu65QFu4lcYxXFxB1Lxm2zJT2fsu8E6Ny3thiCpYiskg7jRgjK6SgNO9QJL9N%2bkUA6rZxn6L2roVT2rwaaIHT9JeYXDjtB74LCthwRi6QuM%2b7rlAW7iVci%2fYXLUgYhtn4urlPHf4z0sauaT5dh0YX%2bvEdg4CnFRm6meIMgjYjdDB5OI%2bF0YhaCiJ9H9rYKMzmFBNkf0Z9F%2frxHYOApxU8q6B7%2ffP8qZn4urlPHf4z6xCf1SAy2vSGs5%2fDTSC7BXjPu65QFu4lXSi4I4fhBoPMaaYjNFAcsm3AlP4UvcRhPpnSvkiAr2Lw71xV7mw3SMrqBBH%2fRWwDeM%2b7rlAW7iVdKLgjh%2bEGg9kUDg3MAXg5eM%2b7rlAW7iV3nbymUm4szIU66LMw4VmWYV1i7vZuywr4wJX2WV2PV5f68R2DgKcVAxln%2bJT2sq20MHk4j4XRiEuvf9jqO9829DB5OI%2bF0YhE8ZmQzVYvJbgy4cv1MfIol%2frxHYOApxUuPBYmR6Sgw5f68R2DgKcVCB0cQSVLEagT%2be92o4%2fqz5f68R2DgKcVMcBF2dlbtCnrziqklPvBLLl8OEMpKE9Rrqlvng58vzQsS7VmIqni8k6cEhUG%2fjNng%3d%3d%3c%2fkey%3e%3c%2fOriginDestinationOption%3e%3c%2fBookingrequest%3e";
        //string xmlRequest = "xmlRequest=%3cEticketRequest%3e%3cClientid%3e77743504%3c%2fClientid%3e%3cClientpassword%3e*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0%3c%2fClientpassword%3e%3cClienttype%3eArzooINTLWS1.0%3c%2fClienttype%3e%3ctransid%3eA396009%3c%2ftransid%3e%3c%2fEticketRequest%3e";

        //StringBuilder stt = new StringBuilder();
        //stt.Append((xmlRequest));

        //byte[] requestData =
        //    UTF8Encoding.UTF8.GetBytes(stt.ToString());




        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/BookingStatus");


        //request.Method = "POST";
        //request.ContentType = "application/x-www-form-urlencoded";
        //request.Accept = "application/json";

        //request.ContentType = "multipart/form-data";
        //request.ContentLength = requestData.Length;

        //using (Stream requestStream = request.GetRequestStream())
        //{
        //    requestStream.Write(requestData, 0, requestData.Length);
        //}

        //DataSet ds = new DataSet();
        //string result = string.Empty;
        //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //{
        //    using (Stream stream = response.GetResponseStream())
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
        //            result = reader.ReadToEnd();
        //        XmlDocument doc = new XmlDocument();
        //        doc.LoadXml(result);
        //        XmlNodeReader xmlReader = new XmlNodeReader(doc);

        //        ds.ReadXml(xmlReader);
        //    }
        //}



      

        //#region unwanted Code
        //string xmlRequest1 = "<Bookingrequest>";
        //xmlRequest1 = xmlRequest1 + "<noadults>1</noadults>";
        //xmlRequest1 = xmlRequest1 + "<nochild>0</nochild>";
        //xmlRequest1 = xmlRequest1 + "<noinfant>0</noinfant>";
        //xmlRequest1 = xmlRequest1 + "<Clientid>77743504</Clientid>";
        //xmlRequest1 = xmlRequest1 + "<Clientpassword>*C6AB4F2C7F3C8C948CF18FBEA508B3E8830154D0</Clientpassword>";
        //xmlRequest1 = xmlRequest1 + "<Clienttype>ArzooINTLWS1.0</Clienttype>";
        //xmlRequest1 = xmlRequest1 + "<creditcardno />";
        //xmlRequest1 = xmlRequest1 + "<PartnerreferenceID>LJIF7585341</PartnerreferenceID>";
        //xmlRequest1 = xmlRequest1 + "<personName>";
        //xmlRequest1 = xmlRequest1 + "<CustomerInfo>";
        //xmlRequest1 = xmlRequest1 + "<givenName>Bindu</givenName>";
        //xmlRequest1 = xmlRequest1 + "<surName>Bhargavi</surName>";
        //xmlRequest1 = xmlRequest1 + "<nameReference>Mrs.</nameReference>";
        //xmlRequest1 = xmlRequest1 + "<psgrtype>adt</psgrtype>";
        //xmlRequest1 = xmlRequest1 + "</CustomerInfo>";
        //xmlRequest1 = xmlRequest1 + "</personName>";
        //xmlRequest1 = xmlRequest1 + "<telePhone>";
        //xmlRequest1 = xmlRequest1 + "<phoneNumber>9701213996</phoneNumber>";
        //xmlRequest1 = xmlRequest1 + "</telePhone>";
        //xmlRequest1 = xmlRequest1 + "<email>";
        //xmlRequest1 = xmlRequest1 + "<emailAddress>bindu.v@i2space.com</emailAddress>";
        //xmlRequest1 = xmlRequest1 + "</email>";
        //xmlRequest1 = xmlRequest1 + "<OriginDestinationOption>";
        //xmlRequest1 = xmlRequest1 + "<FareDetails>";
        //xmlRequest1 = xmlRequest1 + "<ActualBaseFare>47695</ActualBaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>39808</Tax>";
        //xmlRequest1 = xmlRequest1 + "<STax>592</STax>";
        //xmlRequest1 = xmlRequest1 + "<TCharge>0</TCharge>";
        //xmlRequest1 = xmlRequest1 + "<SCharge>5446</SCharge>";
        //xmlRequest1 = xmlRequest1 + "<TDiscount>1432</TDiscount>";
        //xmlRequest1 = xmlRequest1 + "<TMarkup>0</TMarkup>";
        //xmlRequest1 = xmlRequest1 + "<TPartnerCommission>0</TPartnerCommission>";
        //xmlRequest1 = xmlRequest1 + "<TSdiscount>0</TSdiscount>";
        //xmlRequest1 = xmlRequest1 + "<FareBreakup>";
        //xmlRequest1 = xmlRequest1 + "<FareAry>";
        //xmlRequest1 = xmlRequest1 + "<Fare>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>ADT</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>27210</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "</Fare>";
        //xmlRequest1 = xmlRequest1 + "<Fare>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>CH</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>20485</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "</Fare>";
        //xmlRequest1 = xmlRequest1 + "</FareAry>";
        //xmlRequest1 = xmlRequest1 + "</FareBreakup>";
        //xmlRequest1 = xmlRequest1 + "<ocTax>0</ocTax>";
        //xmlRequest1 = xmlRequest1 + "</FareDetails>";
        //xmlRequest1 = xmlRequest1 + "<onward>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegments>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<AirEquipType>333</AirEquipType>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportCode>MUC</ArrivalAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "MUNICH&lt;BR&gt; (FRANZ JOSEF STRAUSS)";
        //xmlRequest1 = xmlRequest1 + "</ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalDateTime>2010-03-26T05:55:00</ArrivalDateTime>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportCode>BOM</DepartureAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "MUMBAI&lt;BR&gt; (CHHATRAPATI SHIVAJI INTERNATIONAL)";
        //xmlRequest1 = xmlRequest1 + "</DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "<DepartureDateTime>2010-03-26T01:50:00</DepartureDateTime>";
        //xmlRequest1 = xmlRequest1 + "<FlightNumber>765</FlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<MarketingAirlineCode>LH</MarketingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineCode>LH</OperatingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineName>Lufthansa </OperatingAirlineName>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineFlightNumber>765</OperatingAirlineFlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<NumStops>0</NumStops>";
        //xmlRequest1 = xmlRequest1 + "<LinkSellAgrmnt></LinkSellAgrmnt>";
        //xmlRequest1 = xmlRequest1 + "<Conx>N</Conx>";
        //xmlRequest1 = xmlRequest1 + "<AirpChg>N</AirpChg>";
        //xmlRequest1 = xmlRequest1 + "<InsideAvailOption>C</InsideAvailOption>";
        //xmlRequest1 = xmlRequest1 + "<GenTrafRestriction>?</GenTrafRestriction>";
        //xmlRequest1 = xmlRequest1 + "<DaysOperates>NA</DaysOperates>";
        //xmlRequest1 = xmlRequest1 + "<JrnyTm></JrnyTm>";
        //xmlRequest1 = xmlRequest1 + "<EndDt></EndDt>";
        //xmlRequest1 = xmlRequest1 + "<StartTerminal></StartTerminal>";
        //xmlRequest1 = xmlRequest1 + "<EndTerminal></EndTerminal>";
        //xmlRequest1 = xmlRequest1 + "<FltTm>0</FltTm>";
        //xmlRequest1 = xmlRequest1 + "<LSAInd>R</LSAInd>";
        //xmlRequest1 = xmlRequest1 + "<Mile>0</Mile>";
        //xmlRequest1 = xmlRequest1 + "<BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<Availability>9</Availability>";
        //xmlRequest1 = xmlRequest1 + "<BIC>V</BIC>";
        //xmlRequest1 = xmlRequest1 + "</BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "<bookingclass>V</bookingclass>";
        //xmlRequest1 = xmlRequest1 + "<classType>Economy</classType>";
        //xmlRequest1 = xmlRequest1 + "<farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "yqM5v0NYhXsaIN1nmxAEWRgIoQLXTIV0";
        //xmlRequest1 = xmlRequest1 + "</farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "<Rule></Rule>";
        //xmlRequest1 = xmlRequest1 + "<PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "<PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>ADT</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>27210</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>CH</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>20485</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "</PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "</PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "</BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<AirEquipType>320</AirEquipType>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportCode>LHR</ArrivalAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "LONDON&lt;BR&gt; (HEATHROW)";
        //xmlRequest1 = xmlRequest1 + "</ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalDateTime>2010-03-26T12:30:00</ArrivalDateTime>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportCode>MUC</DepartureAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "MUNICH&lt;BR&gt; (FRANZ JOSEF STRAUSS)";
        //xmlRequest1 = xmlRequest1 + "</DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "<DepartureDateTime>2010-03-26T11:25:00</DepartureDateTime>";
        //xmlRequest1 = xmlRequest1 + "<FlightNumber>4754</FlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<MarketingAirlineCode>LH</MarketingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineCode>LH</OperatingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineName>Lufthansa </OperatingAirlineName>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineFlightNumber>4754</OperatingAirlineFlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<NumStops>0</NumStops>";
        //xmlRequest1 = xmlRequest1 + "<LinkSellAgrmnt></LinkSellAgrmnt>";
        //xmlRequest1 = xmlRequest1 + "<Conx>N</Conx>";
        //xmlRequest1 = xmlRequest1 + "<AirpChg>N</AirpChg>";
        //xmlRequest1 = xmlRequest1 + "<InsideAvailOption>C</InsideAvailOption>";
        //xmlRequest1 = xmlRequest1 + "<GenTrafRestriction>?</GenTrafRestriction>";
        //xmlRequest1 = xmlRequest1 + "<DaysOperates>NA</DaysOperates>";
        //xmlRequest1 = xmlRequest1 + "<JrnyTm></JrnyTm>";
        //xmlRequest1 = xmlRequest1 + "<EndDt></EndDt>";
        //xmlRequest1 = xmlRequest1 + "<StartTerminal></StartTerminal>";
        //xmlRequest1 = xmlRequest1 + "<EndTerminal></EndTerminal>";
        //xmlRequest1 = xmlRequest1 + "<FltTm>0</FltTm>";
        //xmlRequest1 = xmlRequest1 + "<LSAInd>R</LSAInd>";
        //xmlRequest1 = xmlRequest1 + "<Mile>0</Mile>";
        //xmlRequest1 = xmlRequest1 + "<BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<Availability>9</Availability>";
        //xmlRequest1 = xmlRequest1 + "<BIC>V</BIC>";
        //xmlRequest1 = xmlRequest1 + "</BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "<bookingclass>V</bookingclass>";
        //xmlRequest1 = xmlRequest1 + "<classType>Economy</classType>";
        //xmlRequest1 = xmlRequest1 + "<farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "yqM5v0NYhXsaIN1nmxAEWRgIoQLXTIV0";
        //xmlRequest1 = xmlRequest1 + "</farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "<Rule></Rule>";
        //xmlRequest1 = xmlRequest1 + "<PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "<PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>ADT</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>27210</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>CH</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>20485</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "</PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "</PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "</BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegments>";
        //xmlRequest1 = xmlRequest1 + "</onward>";
        //xmlRequest1 = xmlRequest1 + "<Return>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegments>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<AirEquipType>321</AirEquipType>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportCode>FRA</ArrivalAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "FRANKFURT&lt;BR&gt; (RHEIN-MAIN INTERNATIONAL)";
        //xmlRequest1 = xmlRequest1 + "</ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalDateTime>2010-04-02T12:15:00</ArrivalDateTime>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportCode>LHR</DepartureAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "LONDON&lt;BR&gt; (HEATHROW)";
        //xmlRequest1 = xmlRequest1 + "</DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "<DepartureDateTime>2010-04-02T09:45:00</DepartureDateTime>";
        //xmlRequest1 = xmlRequest1 + "<FlightNumber>4725</FlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<MarketingAirlineCode>LH</MarketingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineCode>LH</OperatingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineName>Lufthansa </OperatingAirlineName>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineFlightNumber>4725</OperatingAirlineFlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<NumStops>0</NumStops>";
        //xmlRequest1 = xmlRequest1 + "<LinkSellAgrmnt></LinkSellAgrmnt>";
        //xmlRequest1 = xmlRequest1 + "<Conx>N</Conx>";
        //xmlRequest1 = xmlRequest1 + "<AirpChg>N</AirpChg>";
        //xmlRequest1 = xmlRequest1 + "<InsideAvailOption>C</InsideAvailOption>";
        //xmlRequest1 = xmlRequest1 + "<GenTrafRestriction>?</GenTrafRestriction>";
        //xmlRequest1 = xmlRequest1 + "<DaysOperates>NA</DaysOperates>";
        //xmlRequest1 = xmlRequest1 + "<JrnyTm></JrnyTm>";
        //xmlRequest1 = xmlRequest1 + "<EndDt></EndDt>";
        //xmlRequest1 = xmlRequest1 + "<StartTerminal></StartTerminal>";
        //xmlRequest1 = xmlRequest1 + "<EndTerminal></EndTerminal>";
        //xmlRequest1 = xmlRequest1 + "<FltTm>0</FltTm>";
        //xmlRequest1 = xmlRequest1 + "<LSAInd>R</LSAInd>";
        //xmlRequest1 = xmlRequest1 + "<Mile>0</Mile>";
        //xmlRequest1 = xmlRequest1 + "<BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<Availability>9</Availability>";
        //xmlRequest1 = xmlRequest1 + "<BIC>U</BIC>";
        //xmlRequest1 = xmlRequest1 + "</BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "<bookingclass>U</bookingclass>";
        //xmlRequest1 = xmlRequest1 + "<classType>Economy</classType>";
        //xmlRequest1 = xmlRequest1 + "<farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "WUE4MEEYPYSZLA+s0/6mnYnDM963BJmv</farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "<Rule></Rule>";
        //xmlRequest1 = xmlRequest1 + "<PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "<PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>ADT</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>27210</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>CH</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>20485</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "</PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "</PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "</BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "<AirEquipType>744</AirEquipType>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportCode>BOM</ArrivalAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "MUMBAI&lt;BR&gt; (CHHATRAPATI SHIVAJI INTERNATIONAL)";
        //xmlRequest1 = xmlRequest1 + "</ArrivalAirportName>";
        //xmlRequest1 = xmlRequest1 + "<ArrivalDateTime>2010-04-03T01:00:00</ArrivalDateTime>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportCode>FRA</DepartureAirportCode>";
        //xmlRequest1 = xmlRequest1 + "<DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "FRANKFURT&lt;BR&gt; (RHEIN-MAIN INTERNATIONAL)";
        //xmlRequest1 = xmlRequest1 + "</DepartureAirportName>";
        //xmlRequest1 = xmlRequest1 + "<DepartureDateTime>2010-04-02T13:30:00</DepartureDateTime>";
        //xmlRequest1 = xmlRequest1 + "<FlightNumber>756</FlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<MarketingAirlineCode>LH</MarketingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineCode>LH</OperatingAirlineCode>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineName>Lufthansa </OperatingAirlineName>";
        //xmlRequest1 = xmlRequest1 + "<OperatingAirlineFlightNumber>756</OperatingAirlineFlightNumber>";
        //xmlRequest1 = xmlRequest1 + "<NumStops>0</NumStops>";
        //xmlRequest1 = xmlRequest1 + "<LinkSellAgrmnt></LinkSellAgrmnt>";
        //xmlRequest1 = xmlRequest1 + "<Conx>N</Conx>";
        //xmlRequest1 = xmlRequest1 + "<AirpChg>N</AirpChg>";
        //xmlRequest1 = xmlRequest1 + "<InsideAvailOption>C</InsideAvailOption>";
        //xmlRequest1 = xmlRequest1 + "<GenTrafRestriction>?</GenTrafRestriction>";
        //xmlRequest1 = xmlRequest1 + "<DaysOperates>NA</DaysOperates>";
        //xmlRequest1 = xmlRequest1 + "<JrnyTm></JrnyTm>";
        //xmlRequest1 = xmlRequest1 + "<EndDt></EndDt>";
        //xmlRequest1 = xmlRequest1 + "<StartTerminal></StartTerminal>";
        //xmlRequest1 = xmlRequest1 + "<EndTerminal></EndTerminal>";
        //xmlRequest1 = xmlRequest1 + "<FltTm>0</FltTm>";
        //xmlRequest1 = xmlRequest1 + "<LSAInd>R</LSAInd>";
        //xmlRequest1 = xmlRequest1 + "<Mile>0</Mile>";
        //xmlRequest1 = xmlRequest1 + "<BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<Availability>9</Availability>";
        //xmlRequest1 = xmlRequest1 + "<BIC>U</BIC>";
        //xmlRequest1 = xmlRequest1 + "</BookingClass>";
        //xmlRequest1 = xmlRequest1 + "<BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "<bookingclass>U</bookingclass>";
        //xmlRequest1 = xmlRequest1 + "<classType>Economy</classType>";
        //xmlRequest1 = xmlRequest1 + "<farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "WUE4MEEYPYSZLA+s0/6mnYnDM963BJmv";
        //xmlRequest1 = xmlRequest1 + "</farebasiscode>";
        //xmlRequest1 = xmlRequest1 + "<Rule></Rule>";
        //xmlRequest1 = xmlRequest1 + "<PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "<PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>ADT</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>27210</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "<Psgr>";
        //xmlRequest1 = xmlRequest1 + "<PsgrType>CH</PsgrType>";
        //xmlRequest1 = xmlRequest1 + "<BaseFare>20485</BaseFare>";
        //xmlRequest1 = xmlRequest1 + "<Tax>19904</Tax>";
        //xmlRequest1 = xmlRequest1 + "<BagInfo></BagInfo>";
        //xmlRequest1 = xmlRequest1 + "</Psgr>";
        //xmlRequest1 = xmlRequest1 + "</PsgrAry>";
        //xmlRequest1 = xmlRequest1 + "</PsgrBreakup>";
        //xmlRequest1 = xmlRequest1 + "</BookingClassFare>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegment>";
        //xmlRequest1 = xmlRequest1 + "</FlightSegments>";
        //xmlRequest1 = xmlRequest1 + "</Return>";
        //xmlRequest1 = xmlRequest1 + "<id>arzoo100</id>";
        //xmlRequest1 = xmlRequest1 + "<key>";
        //xmlRequest1 = xmlRequest1 + "ayCbutV8CZjQweTiPhdGIT52/cnXSmDtW0+odNovIFOF8un5";
        //xmlRequest1 = xmlRequest1 + "AJPBb7V2tDREqpGU0xnw71xV7mw3SP/kC8yBwxIOl/rxHYOApxURZOpRI/EzoF";
        //xmlRequest1 = xmlRequest1 + "d7dK7fhve+hILDZeewhkbrcFyMeloNkLDvXFXubDdI3dYiTg2zkNgIHhU4iQld3Fl";
        //xmlRequest1 = xmlRequest1 + "ClCzmIhe3l/rxHY/W9n4urlPHf4z+njlwFtB3IO6xVBmZQfx+ONy3thiCpYihRRnjy";
        //xmlRequest1 = xmlRequest1 + "QGrh7hXWLu9m7LCssMPJ4Xz20E/AXuBAVa2pxejpWXnEONNsWMLyOaJ/46rcC";
        //xmlRequest1 = xmlRequest1 + "U/hS9xGEPmH+rCYA9GVn4urlPHf4z41sVU7IkWB1idvC1SOSkJo8Clq4QtPJH5e";
        //xmlRequest1 = xmlRequest1 + "OG+w/Tp6htwJT+FL3EYRl9UiNoisc9HyTOZugcDuuD6wCvTuWoqZn4urlPHf4zy";
        //xmlRequest1 = xmlRequest1 + "5qdpggg8kv+h2PVlh5TauNy3thiCpYimncUOikTc32qTDxvbKXRkDNVdEncBXTyf";
        //xmlRequest1 = xmlRequest1 + "wRxKcdia+BmFbl5xc5AzXW3zphRsDlX1/rxHYOApxU4bsCT7uQbmIrac8w85dt";
        //xmlRequest1 = xmlRequest1 + "W7V5rv0yg1HCC7EdqY4QNtWFdYu72bssK4zVZNpWlHODZ+Lq5Tx3+M95+o/T";
        //xmlRequest1 = xmlRequest1 + "OJ/CBNDB5OI+F0YhaCiJ9H9rYKPC8MQS0HHvuMO9cVe5sN0jovQ2S6OQ3ufQ";
        //xmlRequest1 = xmlRequest1 + "mgf2Il4HzuNFPw3awHH5z+Y3IOM/UTyGQfP5W/7HecO9cVe5sN0jwh2QYDQazt";
        //xmlRequest1 = xmlRequest1 + "jjPu65QFu4lWZp0ICotvbLZ+Lq5Tx3+M9IEf8zMi+Fm1/rxHYOApxUSrftj2WKPg";
        //xmlRequest1 = xmlRequest1 + "ozrhjxOHyuKGfi6uU8d/jPgGO60OqILA7QweTiPhdGIWgoifR/a2CjkIThVrkAvqG3";
        //xmlRequest1 = xmlRequest1 + "AlP4UvcRhDKnfx36LGjsnKBVHMf4TZhhf/d6g0XR7quCWXdxw6/CkpXKP6Yc0bv";
        //xmlRequest1 = xmlRequest1 + "jPu65QFu4lV1rTomJXOZBCXxoVW8LhSSKpD2toj/Wf9DB5OI+F0YhaCiJ9H9rYK";
        //xmlRequest1 = xmlRequest1 + "P+v2wZwt+errcCU/hS9xGEsEPWeqQOQ+x7X3kobL84XAtD2ApLfOtn0MHk4j4";
        //xmlRequest1 = xmlRequest1 + "XRiFoKIn0f2tgo9VvT6P2JVxHWG/ThsKfQLEUbFQMZCvw/rcCU/hS9xGE1lb8XeE";
        //xmlRequest1 = xmlRequest1 + "H6pdf68R2DgKcVIBWKDaHLUsEbsrlvDwzO6mNy3thiCpYipiWCrDARrV04z7uuU";
        //xmlRequest1 = xmlRequest1 + "BbuJWM+ajbeG1zEHBqb5AoGvBY2JxE7jZebWp/khFJiE2pyBUWR4ycou2a4z7u";
        //xmlRequest1 = xmlRequest1 + "uUBbuJUHwyZQ7PU8hS9xGEsEPWeqQOQ+x7X3kobL84XAtD2ApLfOtn0MHk4j";
        //xmlRequest1 = xmlRequest1 + "4XRiFoKIn0f2tgo9VvT6P2JVxHWG/ThsKfQLEUbFQMZCvw/rcCU/hS9xGE1lb8Xe";
        //xmlRequest1 = xmlRequest1 + "EH6pdf68R2DgKcVIBWKDaHLhS9xGEsEPWeqQOQ+x7X3kobL84XAtD2ApLfOtn";
        //xmlRequest1 = xmlRequest1 + "0MHk4j4XRiFoKIn0f2tgo9VvT6P2JVxHWG/ThsKfQLEUbFQMZCvw/rcCU/hS9xG";
        //xmlRequest1 = xmlRequest1 + "E1lb8XeEH6pdf68R2DgKcVIBWKDaHLUsEbsrlvDwzO6mNy3thiCpYipiWCrDARr";
        //xmlRequest1 = xmlRequest1 + "V04z7uuUBbuJWM+ajbeG1zEHBqb5AoGvBY2JxE7jZebWpUsEbsrlvDwzO6mNy";
        //xmlRequest1 = xmlRequest1 + "3thiCpYipiWCrDARrV04z7uuUBbuJWM+ajbeG1zEHBqb5AoGvBY2JxE7jZebWpL";
        //xmlRequest1 = xmlRequest1 + "Gfi6uU8d/jPuRH7HSVhDktf68R2DgKcVEWTqUSPxM6B0MHk4j4XRiFoKIn0f2tgo";
        //xmlRequest1 = xmlRequest1 + "zOYUE2R/Rn0X+vEdg4CnFTyroHv98/ypmfi OApxUzm3JG/E8ydN69zaM+";
        //xmlRequest1 = xmlRequest1 + "</key>";
        //xmlRequest1 = xmlRequest1 + "</OriginDestinationOption>";
        //xmlRequest1 = xmlRequest1 + "</Bookingrequest>";
        //#endregion


       string XmlPricingRequest = "<PriceRequest> <noadults>1</noadults> <nochild>0</nochild> <noinfant>0</noinfant> <Clientid>43838</Clientid><Clientpassword>*DC0500F443C3062D74DD92EBB0C396B1E13DCEC6</Clientpassword>";
        XmlPricingRequest = XmlPricingRequest + "<Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails>  <ActualBaseFare>25800</ActualBaseFare><Tax>17890</Tax> <STax>176</STax> <TCharge>0</TCharge><SCharge>0</SCharge><TDiscount>1423</TDiscount><TMarkup>0</TMarkup><TPartnerCommission>0</TPartnerCommission><TSdiscount>0</TSdiscount><FareBreakup><FareAry><Fare> <PsgrType>ADT</PsgrType><BaseFare>25800</BaseFare> <Tax>17890</Tax><TaxDataAry><TaxData><Country>IN</Country>      <Amt>00000260</Amt></TaxData><TaxData> <Country>JN</Country> <Amt>00001946</Amt> </TaxData> <TaxData><Country>WO</Country><Amt>00000225</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>US</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00000926</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>XA</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00000277</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>XY</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00000388</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>YC</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00000305</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>YQ</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00013243</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>YR</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>00000300</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<TaxData>";
        XmlPricingRequest = XmlPricingRequest + "<Country>Other</Country>";
        XmlPricingRequest = XmlPricingRequest + "<Amt>20</Amt>";
        XmlPricingRequest = XmlPricingRequest + "</TaxData>";
        XmlPricingRequest = XmlPricingRequest + "</TaxDataAry>";
        XmlPricingRequest = XmlPricingRequest + "</Fare>";
        XmlPricingRequest = XmlPricingRequest + "</FareAry>";
        XmlPricingRequest = XmlPricingRequest + "</FareBreakup>";
        XmlPricingRequest = XmlPricingRequest + "<ocTax>0</ocTax>";
        XmlPricingRequest = XmlPricingRequest + "</FareDetails>";
        XmlPricingRequest = XmlPricingRequest + "<onward>";
        XmlPricingRequest = XmlPricingRequest + "<FlightSegments>";
        XmlPricingRequest = XmlPricingRequest + "<FlightSegment>";
        XmlPricingRequest = XmlPricingRequest + "<AirEquipType>788</AirEquipType>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalAirportCode>DEL</ArrivalAirportCode>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalAirportName>NEW DELHI</ArrivalAirportName>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalDateTime>2012-12-29T22:45:00</ArrivalDateTime>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureAirportCode>BLR</DepartureAirportCode>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureAirportName>BANGALORE</DepartureAirportName>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureDateTime>2012-12-29T20:05:00</DepartureDateTime>";
        XmlPricingRequest = XmlPricingRequest + "<FlightNumber>404</FlightNumber>";
        XmlPricingRequest = XmlPricingRequest + "<MarketingAirlineCode>AI</MarketingAirlineCode>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineCode>AI</OperatingAirlineCode>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineName>Air India </OperatingAirlineName>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineFlightNumber>404</OperatingAirlineFlightNumber>";
        XmlPricingRequest = XmlPricingRequest + "<NumStops>0</NumStops>";
        XmlPricingRequest = XmlPricingRequest + "<LinkSellAgrmnt>SS</LinkSellAgrmnt>";
        XmlPricingRequest = XmlPricingRequest + "<Conx>Y</Conx>";
        XmlPricingRequest = XmlPricingRequest + "<AirpChg>N</AirpChg>";
        XmlPricingRequest = XmlPricingRequest + "<InsideAvailOption>L</InsideAvailOption>";
        XmlPricingRequest = XmlPricingRequest + "<GenTrafRestriction>?</GenTrafRestriction>";
        XmlPricingRequest = XmlPricingRequest + "<DaysOperates>NNNNNNY</DaysOperates>";
        XmlPricingRequest = XmlPricingRequest + "<JrnyTm>1260</JrnyTm>";
        XmlPricingRequest = XmlPricingRequest + "<EndDt>20121229</EndDt>";
        XmlPricingRequest = XmlPricingRequest + "<StartTerminal>?</StartTerminal>";
        XmlPricingRequest = XmlPricingRequest + "<EndTerminal>3</EndTerminal>";
        XmlPricingRequest = XmlPricingRequest + "<FltTm>160</FltTm>";
        XmlPricingRequest = XmlPricingRequest + "<LSAInd>N</LSAInd>";
        XmlPricingRequest = XmlPricingRequest + "<Mile>1063</Mile>";
        XmlPricingRequest = XmlPricingRequest + "<BookingClass>";
        XmlPricingRequest = XmlPricingRequest + "<Availability>009</Availability>";
        XmlPricingRequest = XmlPricingRequest + "<BIC>V</BIC>";
        XmlPricingRequest = XmlPricingRequest + "</BookingClass>";
        XmlPricingRequest = XmlPricingRequest + "<BookingClassFare>";
        XmlPricingRequest = XmlPricingRequest + "<bookingclass>V</bookingclass>";
        XmlPricingRequest = XmlPricingRequest + "<classType>Economy</classType>";
        XmlPricingRequest = XmlPricingRequest + "<farebasiscode>sFum/ZEojgraGwaWWxpMCA==</farebasiscode>";
        XmlPricingRequest = XmlPricingRequest + "<Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline's cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline's date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule>";
        XmlPricingRequest = XmlPricingRequest + "</BookingClassFare>";
        XmlPricingRequest = XmlPricingRequest + "</FlightSegment>";
        XmlPricingRequest = XmlPricingRequest + "<FlightSegment>";
        XmlPricingRequest = XmlPricingRequest + "<AirEquipType>77W</AirEquipType>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalAirportCode>JFK</ArrivalAirportCode>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalAirportName>NEW YORK</ArrivalAirportName>";
        XmlPricingRequest = XmlPricingRequest + "<ArrivalDateTime>2012-12-30T06:35:00</ArrivalDateTime>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureAirportCode>DEL</DepartureAirportCode>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureAirportName>NEW DELHI</DepartureAirportName>";
        XmlPricingRequest = XmlPricingRequest + "<DepartureDateTime>2012-12-30T01:35:00</DepartureDateTime>";
        XmlPricingRequest = XmlPricingRequest + "<FlightNumber>101</FlightNumber>";
        XmlPricingRequest = XmlPricingRequest + "<MarketingAirlineCode>AI</MarketingAirlineCode>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineCode>AI</OperatingAirlineCode>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineName>Air India </OperatingAirlineName>";
        XmlPricingRequest = XmlPricingRequest + "<OperatingAirlineFlightNumber>101</OperatingAirlineFlightNumber>";
        XmlPricingRequest = XmlPricingRequest + "<NumStops>0</NumStops>";
        XmlPricingRequest = XmlPricingRequest + "<LinkSellAgrmnt>SS</LinkSellAgrmnt>";
        XmlPricingRequest = XmlPricingRequest + "<Conx>N</Conx>";
        XmlPricingRequest = XmlPricingRequest + "<AirpChg>N</AirpChg>";
        XmlPricingRequest = XmlPricingRequest + "<InsideAvailOption>L</InsideAvailOption>";
        XmlPricingRequest = XmlPricingRequest + "<GenTrafRestriction>?</GenTrafRestriction>";
        XmlPricingRequest = XmlPricingRequest + "<DaysOperates>YNNNNNN</DaysOperates>";
        XmlPricingRequest = XmlPricingRequest + "<JrnyTm>1260</JrnyTm>";
        XmlPricingRequest = XmlPricingRequest + "<EndDt>20121230</EndDt>";
        XmlPricingRequest = XmlPricingRequest + "<StartTerminal>3</StartTerminal>";
        XmlPricingRequest = XmlPricingRequest + "<EndTerminal>4</EndTerminal>";
        XmlPricingRequest = XmlPricingRequest + "<FltTm>930</FltTm>";
        XmlPricingRequest = XmlPricingRequest + "<LSAInd>N</LSAInd>";
        XmlPricingRequest = XmlPricingRequest + "<Mile>7305</Mile>";
        XmlPricingRequest = XmlPricingRequest + "<BookingClass>";
        XmlPricingRequest = XmlPricingRequest + "<Availability>009</Availability>";
        XmlPricingRequest = XmlPricingRequest + "<BIC>U</BIC>";
        XmlPricingRequest = XmlPricingRequest + "</BookingClass>";
        XmlPricingRequest = XmlPricingRequest + "<BookingClassFare>";
        XmlPricingRequest = XmlPricingRequest + "<bookingclass>U</bookingclass>";
        XmlPricingRequest = XmlPricingRequest + "<classType>Economy</classType>";
        XmlPricingRequest = XmlPricingRequest + "<farebasiscode>sFum/ZEojgpfTZ6ZnChMcg==</farebasiscode>";
        XmlPricingRequest = XmlPricingRequest + "<Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline's cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline's date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule>";
        XmlPricingRequest = XmlPricingRequest + "</BookingClassFare>";
        XmlPricingRequest = XmlPricingRequest + "</FlightSegment>";
        XmlPricingRequest = XmlPricingRequest + "</FlightSegments>";
        XmlPricingRequest = XmlPricingRequest + "</onward>";
        XmlPricingRequest = XmlPricingRequest + "<Return />";
        XmlPricingRequest = XmlPricingRequest + "<id>arzoo20</id>";
        XmlPricingRequest = XmlPricingRequest + "<key>";
        XmlPricingRequest = XmlPricingRequest + "jT9o8XSks4Bf68R2DgKcVEb0gG2ZuxB2dAtSUvDyEiXrFUGZlB/H443Le2GIKliK1+IxT5Jdd6Fn";
        XmlPricingRequest = XmlPricingRequest + "4urlPHf4zxD8QTDQfGjoBj9z7v8mh1yNy3thiCpYihRRnjyQGrh7hXWLu9m7LCssMPJ4Xz20E7cC";
        XmlPricingRequest = XmlPricingRequest + "U/hS9xGEC7b/0X1r309f68R2DgKcVAxln+JT2sq20MHk4j4XRiFoKIn0f2tgo+sVQZmUH8fjjct7";
        XmlPricingRequest = XmlPricingRequest + "YYgqWIoUUZ48kBq4e4V1i7vZuywrLDDyeF89tBPwF7gQFWtqcXo6Vl5xDjTboJMfYCoEGU63AlP4";
        XmlPricingRequest = XmlPricingRequest + "UvcRhKqEsvx45gkOZ+Lq5Tx3+M/NfRPEeZ+vSTJ8MsOj03doX+vEdg4CnFThuwJPu5BuYiAqobdQ";
        XmlPricingRequest = XmlPricingRequest + "e4cRFsX9UI2964kLsR2pjhA21YV1i7vZuywr3W2lKbmCvwzjPu65QFu4lddTHJZfHE9MInpVWQlr";
        XmlPricingRequest = XmlPricingRequest + "c15n4urlPHf4zwCXVyqmCL3Oyc5Dqj4xCNQRuH89aE+uV+sVQZmUH8fjjct7YYgqWIpcdThEZ41q";
        XmlPricingRequest = XmlPricingRequest + "o8O9cVe5sN0jLySZ32oU3TNn4urlPHf4z2NDQuv6NOBd2zJT2fsu8E6Ny3thiCpYip/OMyAe6P6A";
        XmlPricingRequest = XmlPricingRequest + "ujuL6ITNQ9eTcyC2UaC7jv5GQiLOTwSZjct7YYgqWIpjZrpPm50dZsO9cVe5sN0jW+Z6qJFt2tTj";
        XmlPricingRequest = XmlPricingRequest + "Pu65QFu4lUQ0KBTmijXcZ+Lq5Tx3+M9LWLpCi2LfC2gmgv1kTiXqsS7VmIqni8k4kywQAk+zK1/r";
        XmlPricingRequest = XmlPricingRequest + "xHYOApxUrWUZMCdI/FKX0clSDP54L4V1i7vZuywrM0CpLGyFtZGsIHOguwMYS4V1i7vZuywrepvj";
        XmlPricingRequest = XmlPricingRequest + "ewkAKBwu6QxzJB5R4JxqjbV0Pdej4z7uuUBbuJUUiRbdnppDXdDB5OI+F0YhaCiJ9H9rYKOXuNwG";
        XmlPricingRequest = XmlPricingRequest + "q53u14u2IEZPqlsRjct7YYgqWIoVLJu1YyUkJRj3IUHplYRjPxS/giio89vDvXFXubDdI5Vl3JcL";
        XmlPricingRequest = XmlPricingRequest + "jRh3X+vEdg4CnFTHjOYAlluBWou2IEZPqlsRjct7YYgqWIpXfC4pn5KKsMO9cVe5sN0j/FBgGM7S";
        XmlPricingRequest = XmlPricingRequest + "vpd/dfSuALUKz2seKYY6qtlWPYdjWiFRFpLDvXFXubDdI3WCs5v7MChBX+vEdg4CnFQcBUSXUAnc";
        XmlPricingRequest = XmlPricingRequest + "KtDB5OI+F0YhaCiJ9H9rYKMGdVt1F/d6w43Le2GIKliKTEE430rI7O/QweTiPhdGIY8EOPXXJg9G";
        XmlPricingRequest = XmlPricingRequest + "X+vEdg4CnFRG9IBtmbsQdv6XPm9NQecjZ+Lq5Tx3+M+sQn9UgMtr0j7apZTWr4idw71xV7mw3SMr";
        XmlPricingRequest = XmlPricingRequest + "qBBH/RWwDeM+7rlAW7iVn8vLjTxv/W9n4urlPHf4z6xCf1SAy2vSn9IL2tLxTktn4urlPHf4z0HX";
        XmlPricingRequest = XmlPricingRequest + "zlqxlv3h4rYDll/+Pwq3AlP4UvcRhK4wWDnzRGtf0MHk4j4XRiFoKIn0f2tgo161VZVvSXB90MHk";
        XmlPricingRequest = XmlPricingRequest + "4j4XRiEhPwkxP+1/6dDB5OI+F0YhE8ZmQzVYvJYYJKrcHuPYJJUgaT8utUVocKxceCT8ZcM+U+Ja";
        XmlPricingRequest = XmlPricingRequest + "aL+4KnCsXHgk/GXD4rPAuuMbP187Se8Ni7NgzGfi6uU8d/jPI1N0yGnPw4tn4urlPHf4zzWANnBS";
        XmlPricingRequest = XmlPricingRequest + "9TmLrBkjRt+2EXIGP3Pu/yaHXGN79eHghyxmpBal2nQlGVq5KmPKJOYJlYCMyqRKZf0wvCdH4oPW";
        XmlPricingRequest = XmlPricingRequest + "Id59r9ByVqdVqsUdVs/YZ9T4fa/QclanVaquAY6if9fHxJarQXZsX8bKX+vEdg4CnFSwdDskLGeL";
        XmlPricingRequest = XmlPricingRequest + "f1/rxHYOApxUIHRxBJUsRqAszUbBSPx0CIOP2Hm+YIP0OBqQFB0C1phfPXcYamWomeXw4QykoT1G";
        XmlPricingRequest = XmlPricingRequest + "1chOxdOP8mKWiB4ljlVCkCzNx7W8ezRikH3WkQQIL6Eszce1vHs0Yv3U6neij27Q4YwZArw+YyPQ";
        XmlPricingRequest = XmlPricingRequest + "weTiPhdGIebUJ2nE62zI0MHk4j4XRiETxmZDNVi8lpXlMQ6SdIk/LM3Htbx7NGIz69HaxiMED9DB";
        XmlPricingRequest = XmlPricingRequest + "5OI+F0YhE8ZmQzVYvJaFSfPE2vt6fEeCjTlyW+v3NanJYhNiFV4=";
        XmlPricingRequest = XmlPricingRequest + "</key>";
        XmlPricingRequest = XmlPricingRequest + "</OriginDestinationOption>";
        XmlPricingRequest = XmlPricingRequest + "</PriceRequest>";


        XmlPricingRequest = "<PriceRequest><noadults>1</noadults><nochild>0</nochild><noinfant>0</noinfant><Clientid>43838</Clientid><Clientpassword>*DC0500F443C3062D74DD92EBB0C396B1E13DCEC6</Clientpassword><Clienttype>ArzooINTLWS1.0</Clienttype><OriginDestinationOption><FareDetails><ActualBaseFare>25800</ActualBaseFare><Tax>17890</Tax><STax>176</STax><TCharge>0</TCharge><SCharge>0</SCharge><TDiscount>1423</TDiscount><TMarkup>0</TMarkup><TPartnerCommission>0</TPartnerCommission><TSdiscount>0</TSdiscount><FareBreakup><FareAry><Fare><PsgrType>ADT</PsgrType><BaseFare>25800</BaseFare><Tax>17890</Tax><TaxDataAry><TaxData><Country>IN</Country><Amt>00000260</Amt></TaxData><TaxData><Country>JN</Country><Amt>00001946</Amt></TaxData><TaxData><Country>WO</Country><Amt>00000225</Amt></TaxData><TaxData><Country>US</Country><Amt>00000926</Amt></TaxData><TaxData><Country>XA</Country><Amt>00000277</Amt></TaxData><TaxData><Country>XY</Country><Amt>00000388</Amt></TaxData><TaxData><Country>YC</Country><Amt>00000305</Amt></TaxData><TaxData><Country>YQ</Country><Amt>00013243</Amt></TaxData><TaxData><Country>YR</Country><Amt>00000300</Amt></TaxData><TaxData><Country>Other</Country><Amt>20</Amt></TaxData></TaxDataAry></Fare></FareAry></FareBreakup><ocTax>0</ocTax></FareDetails><onward><FlightSegments><FlightSegment><AirEquipType>788</AirEquipType><ArrivalAirportCode>DEL</ArrivalAirportCode><ArrivalAirportName>NEW DELHI</ArrivalAirportName><ArrivalDateTime>2012-12-29T22:45:00</ArrivalDateTime><DepartureAirportCode>BLR</DepartureAirportCode><DepartureAirportName>BANGALORE</DepartureAirportName><DepartureDateTime>2012-12-29T20:05:00</DepartureDateTime><FlightNumber>404</FlightNumber><MarketingAirlineCode>AI</MarketingAirlineCode><OperatingAirlineCode>AI</OperatingAirlineCode><OperatingAirlineName>Air India </OperatingAirlineName><OperatingAirlineFlightNumber>404</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt>SS</LinkSellAgrmnt><Conx>Y</Conx><AirpChg>N</AirpChg><InsideAvailOption>S</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>NNNNNNY</DaysOperates><JrnyTm>1260</JrnyTm><EndDt>20121229</EndDt><StartTerminal>?</StartTerminal><EndTerminal>3</EndTerminal><FltTm>160</FltTm><LSAInd>N</LSAInd><Mile>1063</Mile><BookingClass><Availability>009</Availability><BIC>V</BIC></BookingClass><BookingClassFare><bookingclass>V</bookingclass><classType>Economy</classType><farebasiscode>sFum/ZEojgraGwaWWxpMCA==</farebasiscode><Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule></BookingClassFare></FlightSegment><FlightSegment><AirEquipType>77W</AirEquipType><ArrivalAirportCode>JFK</ArrivalAirportCode><ArrivalAirportName>NEW YORK</ArrivalAirportName><ArrivalDateTime>2012-12-30T06:35:00</ArrivalDateTime><DepartureAirportCode>DEL</DepartureAirportCode><DepartureAirportName>NEW DELHI</DepartureAirportName><DepartureDateTime>2012-12-30T01:35:00</DepartureDateTime><FlightNumber>101</FlightNumber><MarketingAirlineCode>AI</MarketingAirlineCode><OperatingAirlineCode>AI</OperatingAirlineCode><OperatingAirlineName>Air India </OperatingAirlineName><OperatingAirlineFlightNumber>101</OperatingAirlineFlightNumber><NumStops>0</NumStops><LinkSellAgrmnt>SS</LinkSellAgrmnt><Conx>N</Conx><AirpChg>N</AirpChg><InsideAvailOption>S</InsideAvailOption><GenTrafRestriction>?</GenTrafRestriction><DaysOperates>YNNNNNN</DaysOperates><JrnyTm>1260</JrnyTm><EndDt>20121230</EndDt><StartTerminal>3</StartTerminal><EndTerminal>4</EndTerminal><FltTm>930</FltTm><LSAInd>N</LSAInd><Mile>7305</Mile><BookingClass><Availability>009</Availability><BIC>V</BIC></BookingClass><BookingClassFare><bookingclass>V</bookingclass><classType>Economy</classType><farebasiscode>sFum/ZEojgraGwaWWxpMCA==</farebasiscode><Rule>Cancellation Penalty: All bookings done are subject to the cancellation penalty levied by the respective airline.&lt;br&gt;In addition to the airline''s cancellation penalty, we charge a service fee of Rs. 200 per passenger for all cancellations.|Date Change Penalty: In addition to the airline''s date change penalty, we charge a service fee of Rs. 250 per passenger for any date changes.|</Rule></BookingClassFare></FlightSegment></FlightSegments></onward><Return></Return><id>arzoo20</id><key>jT9o8XSks4Bf68R2DgKcVEb0gG2ZuxB2dAtSUvDyEiXrFUGZlB/H443Le2GIKliK1+IxT5Jdd6Fn4urlPHf4zxD8QTDQfGjoBj9z7v8mh1yNy3thiCpYihRRnjyQGrh7hXWLu9m7LCssMPJ4Xz20E7cCU/hS9xGEC7b/0X1r309f68R2DgKcVAxln+JT2sq20MHk4j4XRiFoKIn0f2tgo+sVQZmUH8fjjct7YYgqWIoUUZ48kBq4e4V1i7vZuywrLDDyeF89tBPwF7gQFWtqcXo6Vl5xDjTboJMfYCoEGU63AlP4UvcRhKqEsvx45gkOZ+Lq5Tx3+M/NfRPEeZ+vSTJ8MsOj03doX+vEdg4CnFThuwJPu5BuYiAqobdQe4cRFsX9UI2964kLsR2pjhA21YV1i7vZuywr3W2lKbmCvwzjPu65QFu4lddTHJZfHE9MInpVWQlrc15n4urlPHf4zwCXVyqmCL3Oyc5Dqj4xCNQRuH89aE+uV+sVQZmUH8fjjct7YYgqWIpcdThEZ41qo8O9cVe5sN0jLySZ32oU3TNn4urlPHf4z2NDQuv6NOBd2zJT2fsu8E6Ny3thiCpYip/OMyAe6P6AujuL6ITNQ9eTcyC2UaC7jv5GQiLOTwSZjct7YYgqWIpjZrpPm50dZsO9cVe5sN0jW+Z6qJFt2tTjPu65QFu4lUQ0KBTmijXcZ+Lq5Tx3+M9LWLpCi2LfC2gmgv1kTiXqsS7VmIqni8k4kywQAk+zK1/rxHYOApxUrWUZMCdI/FKX0clSDP54L4V1i7vZuywrM0CpLGyFtZGsIHOguwMYS4V1i7vZuywrepvjewkAKBwu6QxzJB5R4JxqjbV0Pdej4z7uuUBbuJUUiRbdnppDXdDB5OI+F0YhaCiJ9H9rYKOXuNwGq53u14u2IEZPqlsRjct7YYgqWIoVLJu1YyUkJRj3IUHplYRjPxS/giio89vDvXFXubDdI5Vl3JcLjRh3X+vEdg4CnFTHjOYAlluBWou2IEZPqlsRjct7YYgqWIpXfC4pn5KKsMO9cVe5sN0j/FBgGM7Svpd/dfSuALUKz2seKYY6qtlWPYdjWiFRFpLDvXFXubDdI3WCs5v7MChBX+vEdg4CnFQcBUSXUAncKtDB5OI+F0YhaCiJ9H9rYKMGdVt1F/d6w43Le2GIKliKTEE430rI7O/QweTiPhdGIY8EOPXXJg9GX+vEdg4CnFRG9IBtmbsQdv6XPm9NQecjZ+Lq5Tx3+M+sQn9UgMtr0j7apZTWr4idw71xV7mw3SMrqBBH/RWwDeM+7rlAW7iVn8vLjTxv/W9n4urlPHf4z6xCf1SAy2vSn9IL2tLxTktn4urlPHf4z0HXzlqxlv3h4rYDll/+Pwq3AlP4UvcRhK4wWDnzRGtf0MHk4j4XRiFoKIn0f2tgo161VZVvSXB90MHk4j4XRiEhPwkxP+1/6dDB5OI+F0YhE8ZmQzVYvJYYJKrcHuPYJJUgaT8utUVocKxceCT8ZcM+U+JaaL+4KnCsXHgk/GXD4rPAuuMbP187Se8Ni7NgzGfi6uU8d/jPI1N0yGnPw4tn4urlPHf4zzWANnBS9TmLrBkjRt+2EXIGP3Pu/yaHXGN79eHghyxmpBal2nQlGVq5KmPKJOYJlYCMyqRKZf0wvCdH4oPWId59r9ByVqdVqsUdVs/YZ9T4fa/QclanVaquAY6if9fHxJarQXZsX8bKX+vEdg4CnFSwdDskLGeLf1/rxHYOApxUIHRxBJUsRqAszUbBSPx0CIOP2Hm+YIP0OBqQFB0C1phfPXcYamWomeXw4QykoT1G1chOxdOP8mKWiB4ljlVCkCzNx7W8ezRikH3WkQQIL6Eszce1vHs0Yv3U6neij27Q4YwZArw+YyPQweTiPhdGIebUJ2nE62zI0MHk4j4XRiETxmZDNVi8lpXlMQ6SdIk/LM3Htbx7NGIz69HaxiMED9DB5OI+F0YhE8ZmQzVYvJaFSfPE2vt6fEeCjTlyW+v3NanJYhNiFV4=</key></OriginDestinationOption></PriceRequest>";
        string result = string.Empty;
        DataSet ds = new DataSet();

        StringBuilder stt = new StringBuilder();

        stt.Append("xmlRequest");
        stt.Append("=");
        stt.Append(Server.UrlEncode(XmlPricingRequest));

        byte[] requestData = Encoding.UTF8.GetBytes(stt.ToString());

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://live.arzoo.com:9302/Pricing");
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Accept = "application/json";

        request.ContentLength = requestData.Length;

        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(requestData, 0, requestData.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                    result = reader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlNodeReader xmlReader = new XmlNodeReader(doc);

                ds.ReadXml(xmlReader);
            }
        }

        
    }
}