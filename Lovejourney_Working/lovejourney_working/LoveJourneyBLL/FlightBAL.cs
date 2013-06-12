using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;

namespace BAL
{
    public class FlightBAL
    {
        #region GlobalVariables
        clsDataLayer ObjDAL;
        DataSet ObjDataset;
       

        #endregion
        #region Variables
        public string ReferenceNo { get; set; }
        public string TransId { get; set; }
        public string Status { get; set; }
        public int AdultPax { get; set; }
        public int InfantPax { get; set; }
        public int ChildPax { get; set; }
        public string Origin_Destination_Id { get; set; }
        public string Origin_Destination_Key { get; set; }
        public decimal ActualBasefare { get; set; }
        public decimal Tax { get; set; }
        public decimal STax { get; set; }
        public decimal Scharge { get; set; }
        public decimal TDiscount { get; set; }
        public decimal TPartnerCommission { get; set; }
        public decimal TCharge { get; set; }
        public decimal TMarkUp { get; set; }
        public decimal TSDiscount { get; set; }
        public decimal ActualBasefareRet { get; set; }
        public decimal TaxRet { get; set; }
        public decimal STaxRet { get; set; }
        public decimal SchargeRet { get; set; }
        public decimal TDiscountRet { get; set; }
        public decimal TPartnerCommissionRet { get; set; }
        public decimal TChargeRet { get; set; }
        public decimal TMarkUpRet { get; set; }
        public decimal TSDiscountRet { get; set; }
        public string AirEquipType { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string ArrivalAirportName { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalDateTime { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DepartureDateTime { get; set; }
        public string FlightNumber { get; set; }
        public string OperatingAirlineCode { get; set; }
        public string OperatingAirlineFlightNumber { get; set; }
        public string RPH { get; set; }
        public string StopQuantity { get; set; }
        public string airlineName { get; set; }
        public string airportTax { get; set; }
        public string imageFileName { get; set; }
        public string Discount { get; set; }
        public string airportTaxChild { get; set; }
        public string airportTaxInfant { get; set; }
        public string adultTaxBreakUp { get; set; }
        public string ChildTaxBreakUp { get; set; }
        public string InfantTaxBreakUp { get; set; }
        public string ocTax { get; set; }
        public string Availability { get; set; }
        public string ResBookingCode { get; set; }
        public string adultFare { get; set; }
        public string bookingClass { get; set; }
        public string ChildFare { get; set; }
        public string ClassType { get; set; }
        public string farebasisCode { get; set; }
        public string infantFare { get; set; }
        public string Fare_Rule { get; set; }
        public string adultCommission { get; set; }
        public string childCommission { get; set; }
        public string CommissionOnTCharge { get; set; }
        public string Customer_Details { get; set; }
        public string telephone { get; set; }
        public string emailAddress { get; set; }
        public string remarks { get; set; }
        public string TicketDetails { get; set; }
        public string MarketingAirlineCode { get; set; }
        public string OperatingAirlineName { get; set; }
        public string NumStops { get; set; }
        public string LinkSellAgrmnt { get; set; }
        public string Conx { get; set; }
        public string AirpChg { get; set; }
        public string InsideAvailOption { get; set; }
        public string GenTrafRestriction { get; set; }
        public string DaysOperates { get; set; }
        public string EndDt { get; set; }
        public string StartTerminal { get; set; }
        public string EndTerminal { get; set; }
        public string FltTm { get; set; }
        public string LSAInd { get; set; }
        public string Mile { get; set; }
        public string BIC { get; set; }
        public string classType { get; set; }
        public string bookingclass { get; set; }
        public string PsgrType { get; set; }
        public string BaseFare { get; set; }
        public string JrnyTm { get; set; }
        public string psgrTax { get; set; }
        public string BagInfo { get; set; }
        public string FlightBookingID { get; set; }
        public int CreatedBy { get; set; }
        public string Source { get; set; }
        public string Destinations { get; set; }
        public DateTime? DateOfJourney { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string RefNo { get; set; }
        public string Operator { get; set; }
        public string ContactNo { get; set; }
       
        public string PageSize { get; set; }
        public string TableName { get; set; }

        public string FlightName { get; set; }
        public string Address { get; set; }
        public string CancelId { get; set; }

        public string CancellationProcessDateTime { get; set; }
        public string CancellationCharges { get; set; }
        public string RefundStatus { get; set; }
        public string FinalRefundAmount { get; set; }
        public string RefundDateTime { get; set; }
        public string Reason { get; set; }
        public string TripMode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int agentId { get; set; }


        public string FarePsgrType { get; set; }
        public string Return { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string idRet { get; set; }
        public string keyRet { get; set; }
        public string Type { get; set; }
        public string AirlinePNR { get; set; }
        public string GDFPNRNo { get; set; }
        public string eticketNo { get; set; }
        public string Flightuid { get; set; }
        public string passuid { get; set; }

        #endregion

        #region Domestic Methods

        public DataTable AddDomesticFlightBooking(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[38];
                p[0] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@AdultPax", objFlightBAL.AdultPax);
                p[4] = new SqlParameter("@InfantPax", objFlightBAL.InfantPax);
                p[5] = new SqlParameter("@ChildPax", objFlightBAL.ChildPax);
                p[6] = new SqlParameter("@Origin_Destination_Id", objFlightBAL.Origin_Destination_Id);
                p[7] = new SqlParameter("@Origin_Destination_Key", objFlightBAL.Origin_Destination_Key);
                p[8] = new SqlParameter("@ActualBasefare", objFlightBAL.ActualBasefare);
                p[9] = new SqlParameter("@Tax", objFlightBAL.Tax);
                p[10] = new SqlParameter("@STax", objFlightBAL.STax);
                p[11] = new SqlParameter("@Scharge", objFlightBAL.Scharge);
                p[12] = new SqlParameter("@TDiscount", objFlightBAL.TDiscount);
                p[13] = new SqlParameter("@TPartnerCommission", objFlightBAL.TPartnerCommission);
                p[14] = new SqlParameter("@TCharge", objFlightBAL.TCharge);
                p[15] = new SqlParameter("@TMarkUp", objFlightBAL.TMarkUp);
                p[16] = new SqlParameter("@TSDiscount", objFlightBAL.TSDiscount);              
                p[17] = new SqlParameter("@Customer_Details", objFlightBAL.Customer_Details);
                p[18] = new SqlParameter("@telephone", objFlightBAL.telephone);
                p[19] = new SqlParameter("@emailAddress", objFlightBAL.emailAddress);
                p[20] = new SqlParameter("@tableName", "InsertDomFlightBooking");
                p[21] = new SqlParameter("@CreatedBy", objFlightBAL.CreatedBy);
                p[22] = new SqlParameter("@TripMode", objFlightBAL.TripMode);
                p[23] = new SqlParameter("@address", objFlightBAL.Address);
                p[24] = new SqlParameter("@Type", objFlightBAL.Type);
                p[25] = new SqlParameter("@id", objFlightBAL.id);
                p[26] = new SqlParameter("@key", objFlightBAL.key);
                p[27] = new SqlParameter("@ActualBasefareRet", objFlightBAL.ActualBasefareRet);
                p[28] = new SqlParameter("@TaxRet", objFlightBAL.TaxRet);
                p[29] = new SqlParameter("@STaxRet", objFlightBAL.STaxRet);
                p[30] = new SqlParameter("@SchargeRet", objFlightBAL.SchargeRet);
                p[31] = new SqlParameter("@TDiscountRet", objFlightBAL.TDiscountRet);
                p[32] = new SqlParameter("@TPartnerCommissionRet", objFlightBAL.TPartnerCommissionRet);
                p[33] = new SqlParameter("@TChargeRet", objFlightBAL.TChargeRet);
                p[34] = new SqlParameter("@TMarkUpRet", objFlightBAL.TMarkUpRet);
                p[35] = new SqlParameter("@TSDiscountRet", objFlightBAL.TSDiscountRet);
                p[36] = new SqlParameter("@idRet", objFlightBAL.idRet);
                p[37] = new SqlParameter("@keyRet", objFlightBAL.keyRet);
                return ObjDAL.fnExecuteDataSet("sp_DomesticFlightBooking", p).Tables[0];
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool AddDomesticFlightBookingsegments(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[35];              
                p[0] = new SqlParameter("@AirEquipType", objFlightBAL.AirEquipType);
                p[1] = new SqlParameter("@ArrivalAirportCode", objFlightBAL.ArrivalAirportCode);
                p[2] = new SqlParameter("@ArrivalDateTime", objFlightBAL.ArrivalDateTime);
                p[3] = new SqlParameter("@DepartureAirportCode", objFlightBAL.DepartureAirportCode);
                p[4] = new SqlParameter("@DepartureDateTime", objFlightBAL.DepartureDateTime);
                p[5] = new SqlParameter("@FlightNumber", objFlightBAL.FlightNumber);
                p[6] = new SqlParameter("@OperatingAirlineCode", objFlightBAL.OperatingAirlineCode);
                p[7] = new SqlParameter("@OperatingAirlineFlightNumber", objFlightBAL.OperatingAirlineFlightNumber);
                p[8] = new SqlParameter("@RPH", objFlightBAL.RPH);
                p[9] = new SqlParameter("@StopQuantity", objFlightBAL.StopQuantity);
                p[10] = new SqlParameter("@airlineName", objFlightBAL.airlineName);
                p[11] = new SqlParameter("@airportTax", objFlightBAL.airportTax);
                p[12] = new SqlParameter("@imageFileName", objFlightBAL.imageFileName);
                p[13] = new SqlParameter("@Discount", objFlightBAL.Discount);
                p[14] = new SqlParameter("@airportTaxChild", objFlightBAL.airportTaxChild);
                p[15] = new SqlParameter("@airportTaxInfant", objFlightBAL.airportTaxInfant);
                p[16] = new SqlParameter("@adultTaxBreakUp", objFlightBAL.adultTaxBreakUp);
                p[17] = new SqlParameter("@ChildTaxBreakUp", objFlightBAL.ChildTaxBreakUp);
                p[18] = new SqlParameter("@InfantTaxBreakUp", objFlightBAL.InfantTaxBreakUp);
                p[19] = new SqlParameter("@ocTax", objFlightBAL.ocTax);
                p[20] = new SqlParameter("@Availability", (objFlightBAL.Availability == "") ? 0 : Convert.ToInt32(objFlightBAL.Availability));
                p[21] = new SqlParameter("@ResBookingCode", objFlightBAL.ResBookingCode);
                p[22] = new SqlParameter("@adultFare",(objFlightBAL.adultFare == "") ? 0 : Convert.ToDecimal(objFlightBAL.adultFare));
                p[23] = new SqlParameter("@bookingClass", objFlightBAL.bookingClass);
                p[24] = new SqlParameter("@ChildFare", (objFlightBAL.ChildFare == "") ? 0 : Convert.ToDecimal(objFlightBAL.ChildFare));
                p[25] = new SqlParameter("@ClassType", objFlightBAL.ClassType);
                p[26] = new SqlParameter("@farebasisCode", objFlightBAL.farebasisCode);
                p[27] = new SqlParameter("@infantFare", (objFlightBAL.infantFare == "" ) ? 0 : Convert.ToDecimal(objFlightBAL.infantFare));
                p[28] = new SqlParameter("@Fare_Rule", objFlightBAL.Fare_Rule);
                p[29] = new SqlParameter("@adultCommission",(objFlightBAL.adultCommission == "") ?  0 : Convert.ToDecimal(objFlightBAL.adultCommission));
                p[30] = new SqlParameter("@childCommission", (objFlightBAL.childCommission == "") ? 0 : Convert.ToDecimal(objFlightBAL.childCommission));
                p[31] = new SqlParameter("@CommissionOnTCharge", (objFlightBAL.CommissionOnTCharge == "") ? 0 :Convert.ToDecimal(objFlightBAL.CommissionOnTCharge));
                p[32] = new SqlParameter("@FlightBookingID", Convert.ToInt32(objFlightBAL.FlightBookingID));
                p[33] = new SqlParameter("@tableName", "InsertDomFlightBookingsements");
                p[34] = new SqlParameter("@CreatedBy", objFlightBAL.CreatedBy);
              
                return ObjDAL.fnExecuteStoredProcedure("sp_DomesticFlightBookingsegments", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool CancelDomesticFlightBooking(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@tableName", "InsertDomFlightCancel");
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@remarks", objFlightBAL.remarks);
                p[4] = new SqlParameter("@TicketDetails", objFlightBAL.TicketDetails);
                p[5] = new SqlParameter("@CancelId", objFlightBAL.CancelId);
                p[6] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[7] = new SqlParameter("@CreatedBy", objFlightBAL.CreatedBy);
                p[8] = new SqlParameter("@Reason", objFlightBAL.Reason);
                return ObjDAL.fnExecuteStoredProcedure("sp_DomesticFlightCancel", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public bool UpdateDomesticFlightBookingStatus(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@tableName", "UpdateBookingStatus");
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[4] = new SqlParameter("@AirlinePNR", objFlightBAL.AirlinePNR);
                p[5] = new SqlParameter("@GDFPNRNo", objFlightBAL.GDFPNRNo);
                p[6] = new SqlParameter("@eticketNo", objFlightBAL.eticketNo);
                p[7] = new SqlParameter("@Flightuid", objFlightBAL.Flightuid);
                p[8] = new SqlParameter("@passuid", objFlightBAL.passuid);
                return ObjDAL.fnExecuteStoredProcedure("sp_DomesticFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool UpdateDomesticFlightCancelStatus(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@tableName", "UpdateCancelStatus");
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@CancellationProcessDateTime", objFlightBAL.CancellationProcessDateTime);
                p[4] = new SqlParameter("@CancellationCharges", objFlightBAL.CancellationCharges);
                p[5] = new SqlParameter("@RefundStatus", objFlightBAL.RefundStatus);
                p[6] = new SqlParameter("@FinalRefundAmount", objFlightBAL.FinalRefundAmount);
                p[7] = new SqlParameter("@RefundDateTime", objFlightBAL.RefundDateTime);
                p[8] = new SqlParameter("@ModifiedBy", objFlightBAL.CreatedBy);

                return ObjDAL.fnExecuteStoredProcedure("sp_DomesticFlightCancel", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
       
        public DataSet GetTransID(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetTransIdByRefNo");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_DomesticFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetIntTransID(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetTransIdByRefNo");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetDomesticFlightDetails(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetDetails");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_DomesticFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        #endregion

        #region  International Flights
        public DataTable AddDInternationalFlightBooking(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[24];
                p[0] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@AdultPax", objFlightBAL.AdultPax);
                p[4] = new SqlParameter("@InfantPax", objFlightBAL.InfantPax);
                p[5] = new SqlParameter("@ChildPax", objFlightBAL.ChildPax);
                p[6] = new SqlParameter("@Origin_Destination_Id", objFlightBAL.Origin_Destination_Id);
                p[7] = new SqlParameter("@Origin_Destination_Key", objFlightBAL.Origin_Destination_Key);
                p[8] = new SqlParameter("@ActualBasefare", objFlightBAL.ActualBasefare);
                p[9] = new SqlParameter("@Tax", objFlightBAL.Tax);
                p[10] = new SqlParameter("@STax", objFlightBAL.STax);
                p[11] = new SqlParameter("@Scharge", objFlightBAL.Scharge);
                p[12] = new SqlParameter("@TDiscount", objFlightBAL.TDiscount);
                p[13] = new SqlParameter("@TPartnerCommission", objFlightBAL.TPartnerCommission);
                p[14] = new SqlParameter("@TCharge", objFlightBAL.TCharge);
                p[15] = new SqlParameter("@TMarkUp", objFlightBAL.TMarkUp);
                p[16] = new SqlParameter("@TSDiscount", objFlightBAL.TSDiscount);
                p[17] = new SqlParameter("@tableName", "InsertIntFlightBooking");
                p[18] = new SqlParameter("@CreatedBy", objFlightBAL.CreatedBy);
                p[19] = new SqlParameter("@TripMode", objFlightBAL.TripMode);
                p[20] = new SqlParameter("@Octax", objFlightBAL.ocTax);

                p[21] = new SqlParameter("@Return1", objFlightBAL.Return);
                p[22] = new SqlParameter("@id", objFlightBAL.id);
                p[23] = new SqlParameter("@Key", objFlightBAL.key);
                //p[18] = new SqlParameter("@FlightBookingID",SqlDbType.Int);
                //p[18].Direction = ParameterDirection.Output;                
                return ObjDAL.fnExecuteDataSet("sp_InternationalFlightBooking", p).Tables[0];
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet UpdateDInternationalFlightBooking(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);               
                p[3] = new SqlParameter("@tableName", "UpdateIntFlightBooking");
                return ObjDAL.fnExecuteDataset("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet UpdateDomesticFlightBooking(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@tableName", "UpdateDomFlightBooking");
                return ObjDAL.fnExecuteDataset("sp_DomesticFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool AddInternationalFlightSegment(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[44];
                p[0] = new SqlParameter("@AirEquipType", objFlightBAL.AirEquipType);
                p[1] = new SqlParameter("@ArrivalAirportCode", objFlightBAL.ArrivalAirportCode);
                p[2] = new SqlParameter("@ArrivalDateTime", objFlightBAL.ArrivalDateTime);
                p[3] = new SqlParameter("@DepartureAirportCode", objFlightBAL.DepartureAirportCode);
                p[4] = new SqlParameter("@DepartureDateTime", objFlightBAL.DepartureDateTime);
                p[5] = new SqlParameter("@FlightNumber", objFlightBAL.FlightNumber);
                p[6] = new SqlParameter("@MarketingAirlineCode", objFlightBAL.MarketingAirlineCode);
                p[7] = new SqlParameter("@OperatingAirlineCode", objFlightBAL.OperatingAirlineCode);
                p[8] = new SqlParameter("@OperatingAirlineName", objFlightBAL.OperatingAirlineName);
                p[9] = new SqlParameter("@OperatingAirlineFlightNumber", objFlightBAL.OperatingAirlineFlightNumber);
                p[10] = new SqlParameter("@NumStops", objFlightBAL.NumStops);
                p[11] = new SqlParameter("@LinkSellAgrmnt", objFlightBAL.LinkSellAgrmnt);
                p[12] = new SqlParameter("@Conx", objFlightBAL.Conx);
                p[13] = new SqlParameter("@AirpChg", objFlightBAL.AirpChg);
                p[14] = new SqlParameter("@InsideAvailOption", objFlightBAL.InsideAvailOption);
                p[15] = new SqlParameter("@GenTrafRestriction", objFlightBAL.GenTrafRestriction);
                p[16] = new SqlParameter("@DaysOperates", objFlightBAL.DaysOperates);
                p[17] = new SqlParameter("@JrnyTm", objFlightBAL.JrnyTm);
                p[18] = new SqlParameter("@EndDt", objFlightBAL.EndDt);
                p[19] = new SqlParameter("@StartTerminal", objFlightBAL.StartTerminal);
                p[20] = new SqlParameter("@EndTerminal", objFlightBAL.EndTerminal);
                p[21] = new SqlParameter("@FltTm", objFlightBAL.FltTm);
                p[22] = new SqlParameter("@LSAInd", objFlightBAL.LSAInd);
                p[23] = new SqlParameter("@Mile", objFlightBAL.Mile);
                p[24] = new SqlParameter("@Availability", objFlightBAL.Availability);
                p[25] = new SqlParameter("@BIC", objFlightBAL.BIC);
                p[26] = new SqlParameter("@bookingclass", objFlightBAL.bookingClass);
                p[27] = new SqlParameter("@classType", objFlightBAL.ClassType);
                p[28] = new SqlParameter("@farebasiscode", objFlightBAL.farebasisCode);
                p[29] = new SqlParameter("@Fare_Rule", objFlightBAL.Fare_Rule);
                p[30] = new SqlParameter("@PsgrType", objFlightBAL.PsgrType);
                p[31] = new SqlParameter("@BaseFare", objFlightBAL.BaseFare);
                p[32] = new SqlParameter("@psgrTax", objFlightBAL.psgrTax);
                p[33] = new SqlParameter("@BagInfo", objFlightBAL.BagInfo);
                p[34] = new SqlParameter("@FlightBookingID", objFlightBAL.FlightBookingID);
                p[35] = new SqlParameter("@tableName", "InsertIntFlightSegment");
                p[36] = new SqlParameter("@ArrivalAirportName", objFlightBAL.ArrivalAirportName);
                p[37] = new SqlParameter("@DepartureAirportName", objFlightBAL.DepartureAirportName);
                p[38] = new SqlParameter("@Telephone", objFlightBAL.telephone);
                p[39] = new SqlParameter("@CustomerDetails", objFlightBAL.Customer_Details);
                p[40] = new SqlParameter("@EmailAddress", objFlightBAL.emailAddress);
                p[41] = new SqlParameter("@CreatedBy", objFlightBAL.CreatedBy);
                p[42] = new SqlParameter("@Address", objFlightBAL.Address);           
                p[43] = new SqlParameter("@FarePsgrType", objFlightBAL.FarePsgrType);
                return ObjDAL.fnExecuteStoredProcedure("sp_InternationalFlightSegments", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public bool UpdateInternationalFlightSegment(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@bookingclass", objFlightBAL.bookingClass);
                p[1] = new SqlParameter("@classType", objFlightBAL.ClassType);
                p[2] = new SqlParameter("@farebasiscode", objFlightBAL.farebasisCode);
                p[3] = new SqlParameter("@Fare_Rule", objFlightBAL.Fare_Rule);
                p[4] = new SqlParameter("@PsgrType", objFlightBAL.PsgrType);
                p[5] = new SqlParameter("@BaseFare", objFlightBAL.BaseFare);
                p[6] = new SqlParameter("@psgrTax", objFlightBAL.psgrTax);
                p[7] = new SqlParameter("@BagInfo", objFlightBAL.BagInfo);
                p[8] = new SqlParameter("@FlightBookingID", objFlightBAL.FlightBookingID);
                p[9] = new SqlParameter("@tableName", "UpdateIntFlightSegment");               
                return ObjDAL.fnExecuteStoredProcedure("sp_InternationalFlightSegments", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public DataSet GetDatasetFromAPI(string xmlRequest, string url)
        {
            string result = string.Empty;
            DataSet ds = new DataSet();
            try
            {

                StringBuilder stt = new StringBuilder();

                stt.Append("xmlRequest");
                stt.Append("=");
                stt.Append(HttpUtility.UrlEncode(xmlRequest));


                byte[] requestData =
                    UTF8Encoding.UTF8.GetBytes(stt.ToString());


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

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
            catch (Exception ex)
            {

            }
            return ds;

        }
        public DataSet GetFlights(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@TableName", objFlightBAL.FlightName);
                p[1] = new SqlParameter("@userid", objFlightBAL.CreatedBy);
                return ObjDAL.fnExecuteDataset("Sp_IFReports", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAgentFlights(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@TableName", objFlightBAL.FlightName);
                p[1] = new SqlParameter("@userid", objFlightBAL.CreatedBy);
                return ObjDAL.fnExecuteDataset("SP_GetAgentReport", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
   
        public DataSet FlightSearch(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[13];
                p[0] = new SqlParameter("@Source", objFlightBAL.Source);
                p[1] = new SqlParameter("@Destinations", objFlightBAL.Destinations);
                p[2] = new SqlParameter("@DateOfJourney", objFlightBAL.DateOfJourney);
                p[3] = new SqlParameter("@DateOfIssue", objFlightBAL.DateOfIssue);
                p[4] = new SqlParameter("@Name", objFlightBAL.Name);
                p[5] = new SqlParameter("@EmailId", objFlightBAL.EmailId);
                p[6] = new SqlParameter("@RefNo", objFlightBAL.RefNo);
                p[7] = new SqlParameter("@Operator", objFlightBAL.Operator);
                p[8] = new SqlParameter("@ContactNo", objFlightBAL.ContactNo);
                p[9] = new SqlParameter("@Status", objFlightBAL.Status);
                //p[10] = new SqlParameter("@PageSize", objFlightBAL.PageSize);
                p[10] = new SqlParameter("@TableName", objFlightBAL.TableName);
                p[11] = new SqlParameter("@FlightName", objFlightBAL.FlightName);
                p[12] = new SqlParameter("@userid", objFlightBAL.CreatedBy);
                return ObjDAL.fnExecuteDataset("Sp_IFReports", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet CarSearch(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@ReferenceId ", objFlightBAL.RefNo);
                p[1] = new SqlParameter("@AgentName", objFlightBAL.Name);
                p[2] = new SqlParameter("@DateOfJourney", objFlightBAL.DateOfJourney);
                p[3] = new SqlParameter("@DateOfIssue", objFlightBAL.DateOfIssue);
                p[4] = new SqlParameter("@Query", objFlightBAL.TableName);
                p[5] = new SqlParameter("@AgentId", objFlightBAL.agentId);
               
              
                //p[10] = new SqlParameter("@PageSize", objFlightBAL.PageSize);
              
                //p[5] = new SqlParameter("@userid", objFlightBAL.CreatedBy);
                return ObjDAL.fnExecuteDataset("sp_CarProvisional", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetAgentFlightSearch(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[13];
                p[0] = new SqlParameter("@Source", objFlightBAL.Source);
                p[1] = new SqlParameter("@Destinations", objFlightBAL.Destinations);
                p[2] = new SqlParameter("@DateOfJourney", objFlightBAL.DateOfJourney);
                p[3] = new SqlParameter("@DateOfIssue", objFlightBAL.DateOfIssue);
                p[4] = new SqlParameter("@Name", objFlightBAL.Name);
                p[5] = new SqlParameter("@EmailId", objFlightBAL.EmailId);
                p[6] = new SqlParameter("@RefNo", objFlightBAL.RefNo);
                p[7] = new SqlParameter("@Operator", objFlightBAL.Operator);
                p[8] = new SqlParameter("@ContactNo", objFlightBAL.ContactNo);
                p[9] = new SqlParameter("@Status", objFlightBAL.Status);
                //p[10] = new SqlParameter("@PageSize", objFlightBAL.PageSize);
                p[10] = new SqlParameter("@TableName", objFlightBAL.TableName);
                p[11] = new SqlParameter("@FlightName", objFlightBAL.FlightName);
                p[12] = new SqlParameter("@userid", objFlightBAL.CreatedBy);
                return ObjDAL.fnExecuteDataset("SP_GetAgentReport", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetInternationalFlightDetails(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetDetails");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCarDetaisl(string RefNo,string carid)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@Query", "getpassengerdetails");
                p[1] = new SqlParameter("@ReferanceId", RefNo);
                p[2] = new SqlParameter("@CarDetailsId", carid);
                return ObjDAL.fnExecuteDataSet("sp_CarProvisional", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FGetInternationalFlightDetails(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetFDetails");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet IGetInternationalFlightDetails(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetFlights");
                p[1] = new SqlParameter("@ReferenceNo", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_DomesticFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInternationalFlightDetails1(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetFlights");
                p[1] = new SqlParameter("@FlightBookingID", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_InternationalFlightSegments", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInternationalFlightDetailsI1(string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@tableName", "GetFlights");
                p[1] = new SqlParameter("@FlightBookingID", RefNo);
                return ObjDAL.fnExecuteDataSet("sp_DomesticFlightBookingsegments", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateInternationalFlightBookingStatus(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@tableName", "UpdateBookingStatus");
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);
                p[3] = new SqlParameter("@ReferenceNo", objFlightBAL.ReferenceNo);
                p[4] = new SqlParameter("@AirlinePNR", objFlightBAL.AirlinePNR);
                p[5] = new SqlParameter("@GDFPNRNo", objFlightBAL.GDFPNRNo);
                p[6] = new SqlParameter("@eticketNo", objFlightBAL.eticketNo);
                p[7] = new SqlParameter("@Flightuid", objFlightBAL.Flightuid);
                p[8] = new SqlParameter("@passuid", objFlightBAL.passuid);
                return ObjDAL.fnExecuteStoredProcedure("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool UpdateInternationalFlightCancelStatus(FlightBAL objFlightBAL)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@tableName", "UpdateCancelStatus");
                p[1] = new SqlParameter("@TransId", objFlightBAL.TransId);
                p[2] = new SqlParameter("@Status", objFlightBAL.Status);

                return ObjDAL.fnExecuteStoredProcedure("sp_InternationalFlightBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public DataSet GetFlightSalesReport()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Flag", "FlightSalesReport");
                p[1] = new SqlParameter("@FromDate", FromDate);
                p[2] = new SqlParameter("@ToDate", ToDate);
                p[3] = new SqlParameter("@agentId", agentId);

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_FlightsSalesReport", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion
        //Get Airport Codes from Database
        public DataSet GetGuestReports(FlightBAL objFlightBAL)
        {

            try
            {

                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@DateOfJourney", objFlightBAL.DateOfJourney);

                p[1] = new SqlParameter("@RefNo", objFlightBAL.RefNo);

                p[2] = new SqlParameter("@TableName", objFlightBAL.TableName);

                p[3] = new SqlParameter("@DateOfIssue", objFlightBAL.DateOfIssue);



                return ObjDAL.fnExecuteDataset("sp_AllGuestReports", p);

            }

            catch (Exception ex)
            {

                throw ex;

            }

        }
        public DataSet GetAirportCodes()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@tableName", "AirportCodes");               
                return ObjDAL.fnExecuteDataSet("Sp_IFReports", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDomAirportCodes()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@tableName", "DomAirportCodes");
                return ObjDAL.fnExecuteDataSet("Sp_IFReports", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
