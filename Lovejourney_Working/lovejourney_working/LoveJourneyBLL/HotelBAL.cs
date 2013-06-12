using System;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Web.UI.WebControls;

namespace BAL
{
    public class HotelBAL
    {
        #region Global Variables
        clsDataLayer ObjDAL;
        DataSet ObjDataset;
        #endregion
        public int ProvisionalId { get; set; }
        public string ReferenceNo { get; set; }
        public string HotelCity { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelStar { get; set; }
        public string HotelTotalFare { get; set; }
        public string HotelTotlaFareDetails { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int NoOfRooms { get; set; }
        public int? NoOfAdults { get; set; }
        public int? NoOfChildren { get; set; }
        public int? AgentId{ get; set; }
        public int? UserId { get; set; }
        public string RoomStayCandidate { get; set; }
        public string HotelId { get; set; }
        public string WebService { get; set; }
        public string RatePlanType { get; set; }
        public string RoomTypeCode { get; set; }
        public string FromAllocation { get; set; }
        public string AllocationId { get; set; }
        public string RoomType { get; set; }
        public string WsKey { get; set; }
        public string RoomBasis { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string CustAddressLine { get; set; }
        public string CustCity { get; set; }
        public string CustZipCode { get; set; }
        public string CustState { get; set; }
        public string CustCountry { get; set; }
        public string Comment { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public int BookingId { get; set; }
        public string ExtGuestTotal { get; set; }
        public string RoomTotal { get; set; }
        public string ServiceTaxTotal { get; set; }
        public string BookingStatus { get; set; }
        public string BookingRemarks { get; set; }
        public string BookingRefNo { get; set; }
        public string BookingTrn { get; set; }
        public string Discount { get; set; }
        public string ContactNumbers { get; set; }
        public string FaxNumbers { get; set; }

        public double RefundAmount { get; set; }
        public double CancellationCharges { get; set; }
        public string Status { get; set; }
        public string HotelCancellationId { get; set; }
        

        public bool AddHotelProvisional()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[37];
                p[0] = new SqlParameter("@ReferenceNo", ReferenceNo);
                p[1] = new SqlParameter("@HotelCity", HotelCity);
                p[2] = new SqlParameter("@CheckIn", CheckIn);
                p[3] = new SqlParameter("@CheckOut", CheckOut);
                p[4] = new SqlParameter("@NoOfRooms", NoOfRooms);
                p[5] = new SqlParameter("@NoOfAdults", NoOfAdults);
                p[6] = new SqlParameter("@NoOfChildren", NoOfChildren);
                p[7] = new SqlParameter("@RoomStayCandidate", RoomStayCandidate);
                p[8] = new SqlParameter("@HotelId", HotelId);
                p[9] = new SqlParameter("@WebService", WebService);
                p[10] = new SqlParameter("@RatePlanType", RatePlanType);
                p[11] = new SqlParameter("@RoomTypeCode", RoomTypeCode);
                p[12] = new SqlParameter("@FromAllocation", FromAllocation);
                p[13] = new SqlParameter("@AllocationId", AllocationId);
                p[14] = new SqlParameter("@RoomType", RoomType);
                p[15] = new SqlParameter("@WsKey", WsKey);
                p[16] = new SqlParameter("@RoomBasis", RoomBasis);
                p[17] = new SqlParameter("@Title", Title);
                p[18] = new SqlParameter("@FirstName", FirstName);
                p[19] = new SqlParameter("@MiddleName", MiddleName);
                p[20] = new SqlParameter("@LastName", LastName);
                p[21] = new SqlParameter("@MobileNumber", MobileNumber);
                p[22] = new SqlParameter("@EmailId", EmailId);
                p[23] = new SqlParameter("@CustAddressLine", CustAddressLine);
                p[24] = new SqlParameter("@CustCity", CustCity);
                p[25] = new SqlParameter("@CustZipCode", CustZipCode);
                p[26] = new SqlParameter("@CustState", CustState);
                p[27] = new SqlParameter("@CustCountry", CustCountry);
                p[28] = new SqlParameter("@Comment", Comment);
                p[29] = new SqlParameter("@CreatedBy", CreatedBy);
                p[30] = new SqlParameter("@ModifiedBy", ModifiedBy);
                p[31] = new SqlParameter("@Status", "InsertHotelProvisional");
                p[32] = new SqlParameter("@HotelName", HotelName);
                p[33] = new SqlParameter("@HotelAddress", HotelAddress);
                p[34] = new SqlParameter("@HotelStar", HotelStar);
                p[35] = new SqlParameter("@HotelTotalFare", HotelTotalFare);
                p[36] = new SqlParameter("@HotelTotlaFareDetails", HotelTotlaFareDetails);



                return ObjDAL.fnExecuteStoredProcedure("sp_HotelProvisional", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddHotelProvisionalAgent(string hotelTotalFareAgent, string hotelTotalFareDetailsAgent, string markUpFareAgent)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[40];
                p[0] = new SqlParameter("@ReferenceNo", ReferenceNo);
                p[1] = new SqlParameter("@HotelCity", HotelCity);
                p[2] = new SqlParameter("@CheckIn", CheckIn);
                p[3] = new SqlParameter("@CheckOut", CheckOut);
                p[4] = new SqlParameter("@NoOfRooms", NoOfRooms);
                p[5] = new SqlParameter("@NoOfAdults", NoOfAdults);
                p[6] = new SqlParameter("@NoOfChildren", NoOfChildren);
                p[7] = new SqlParameter("@RoomStayCandidate", RoomStayCandidate);
                p[8] = new SqlParameter("@HotelId", HotelId);
                p[9] = new SqlParameter("@WebService", WebService);
                p[10] = new SqlParameter("@RatePlanType", RatePlanType);
                p[11] = new SqlParameter("@RoomTypeCode", RoomTypeCode);
                p[12] = new SqlParameter("@FromAllocation", FromAllocation);
                p[13] = new SqlParameter("@AllocationId", AllocationId);
                p[14] = new SqlParameter("@RoomType", RoomType);
                p[15] = new SqlParameter("@WsKey", WsKey);
                p[16] = new SqlParameter("@RoomBasis", RoomBasis);
                p[17] = new SqlParameter("@Title", Title);
                p[18] = new SqlParameter("@FirstName", FirstName);
                p[19] = new SqlParameter("@MiddleName", MiddleName);
                p[20] = new SqlParameter("@LastName", LastName);
                p[21] = new SqlParameter("@MobileNumber", MobileNumber);
                p[22] = new SqlParameter("@EmailId", EmailId);
                p[23] = new SqlParameter("@CustAddressLine", CustAddressLine);
                p[24] = new SqlParameter("@CustCity", CustCity);
                p[25] = new SqlParameter("@CustZipCode", CustZipCode);
                p[26] = new SqlParameter("@CustState", CustState);
                p[27] = new SqlParameter("@CustCountry", CustCountry);
                p[28] = new SqlParameter("@Comment", Comment);
                p[29] = new SqlParameter("@CreatedBy", CreatedBy);
                p[30] = new SqlParameter("@ModifiedBy", ModifiedBy);
                p[31] = new SqlParameter("@Status", "InsertHotelProvisionalAgent");
                p[32] = new SqlParameter("@HotelName", HotelName);
                p[33] = new SqlParameter("@HotelAddress", HotelAddress);
                p[34] = new SqlParameter("@HotelStar", HotelStar);
                p[35] = new SqlParameter("@HotelTotalFare", HotelTotalFare);
                p[36] = new SqlParameter("@HotelTotlaFareDetails", HotelTotlaFareDetails);

                p[37] = new SqlParameter("@HotelTotalFare_Agent", hotelTotalFareAgent);
                p[38] = new SqlParameter("@HotelTotlaFareDetails_Agent", hotelTotalFareDetailsAgent);
                p[39] = new SqlParameter("@MarkUpFare_Agent", markUpFareAgent);

                return ObjDAL.fnExecuteStoredProcedure("sp_HotelProvisional", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public DataSet GetHotelProvisional()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Status", "GetHotelProvisional");
                p[1] = new SqlParameter("@ReferenceNo", ReferenceNo);
                return ObjDAL.fnExecuteDataSet("sp_HotelProvisional", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddHotelBooking()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[14];
                p[0] = new SqlParameter("@ProvisionalId", ProvisionalId);
                p[1] = new SqlParameter("@WsKey", WsKey);
                p[2] = new SqlParameter("@ExtGuestTotal", ExtGuestTotal);
                p[3] = new SqlParameter("@RoomTotal", RoomTotal);
                p[4] = new SqlParameter("@ServiceTaxTotal", ServiceTaxTotal);
                p[5] = new SqlParameter("@BookingStatus", BookingStatus);
                p[6] = new SqlParameter("@BookingRemarks", BookingRemarks);
                p[7] = new SqlParameter("@BookingRefNo", BookingRefNo);
                p[8] = new SqlParameter("@BookingTrn", BookingTrn);
                p[9] = new SqlParameter("@Discount", Discount);
                p[10] = new SqlParameter("@ContactNumbers", ContactNumbers);
                p[11] = new SqlParameter("@FaxNumbers", FaxNumbers);
                p[12] = new SqlParameter("@CreatedBy", CreatedBy);
                p[13] = new SqlParameter("@Status", "InsertHotelBooking");

                return ObjDAL.fnExecuteStoredProcedure("sp_HotelBooking", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public bool AddHotelCancellation()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@ProvisionalId", ProvisionalId);
                p[1] = new SqlParameter("@Status", "AddHotelCancellation");
                p[2] = new SqlParameter("@CreatedBy", CreatedBy);
                p[3] = new SqlParameter("@BookingId", BookingId);
                p[4] = new SqlParameter("@RefundAmount", RefundAmount);
                p[5] = new SqlParameter("@CancellationCharges", CancellationCharges);
                p[6] = new SqlParameter("@HotelCancellationId", HotelCancellationId);

                return ObjDAL.fnExecuteStoredProcedure("sp_HotelCancellation", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet SearchAgentBookedTickets()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@CheckIn", CheckIn);
                p[1] = new SqlParameter("@CheckOut", CheckOut);
                p[2] = new SqlParameter("@HotelCity", HotelCity);
                p[3] = new SqlParameter("@EmailId", EmailId);
                p[4] = new SqlParameter("@RefNo", ReferenceNo);
                p[5] = new SqlParameter("@UserId", UserId);
                p[6] = new SqlParameter("@Name", FirstName);
                p[7] = new SqlParameter("@MobileNo", MobileNumber);
                p[8] = new SqlParameter("@Flag", "SearchAgentBookedTickets");
                p[9] = new SqlParameter("@Status", Status);

                return ObjDAL.fnExecuteDataSet("sp_HotelAgents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet SearchHotelTickets()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@CheckIn", CheckIn);
                p[1] = new SqlParameter("@CheckOut", CheckOut);
                p[2] = new SqlParameter("@HotelCity", HotelCity);
                p[3] = new SqlParameter("@EmailId", EmailId);
                p[4] = new SqlParameter("@RefNo", ReferenceNo);
                p[5] = new SqlParameter("@UserId", UserId);
                p[6] = new SqlParameter("@Name", FirstName);
                p[7] = new SqlParameter("@MobileNo", MobileNumber);
                p[8] = new SqlParameter("@Flag", "SearchTickets");
                p[9] = new SqlParameter("@Status", Status);

                return ObjDAL.fnExecuteDataSet("sp_HotelAgents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet SearchAllAgentsBookedTickets()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@CheckIn", CheckIn);
                p[1] = new SqlParameter("@CheckOut", CheckOut);
                p[2] = new SqlParameter("@HotelCity", HotelCity);
                p[3] = new SqlParameter("@EmailId", EmailId);
                p[4] = new SqlParameter("@RefNo", ReferenceNo);
                p[5] = new SqlParameter("@UserId", UserId);
                p[6] = new SqlParameter("@Name", FirstName);
                p[7] = new SqlParameter("@MobileNo", MobileNumber);
                p[8] = new SqlParameter("@Flag", "SearchAllAgentsBookedTickets");
                p[9] = new SqlParameter("@Status", Status);

                return ObjDAL.fnExecuteDataSet("sp_HotelAgents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet SearchAllAgentsBookedTicketsUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[10];

                p[0] = new SqlParameter("@CheckIn", CheckIn);
                p[1] = new SqlParameter("@CheckOut", CheckOut);
                p[2] = new SqlParameter("@HotelCity", HotelCity);
                p[3] = new SqlParameter("@EmailId", EmailId);
                p[4] = new SqlParameter("@RefNo", ReferenceNo);
                p[5] = new SqlParameter("@UserId", UserId);
                p[6] = new SqlParameter("@Name", FirstName);
                p[7] = new SqlParameter("@MobileNo", MobileNumber);
                p[8] = new SqlParameter("@Flag", "SearchAllAgentsBookedTicketsUser");
                p[9] = new SqlParameter("@Status", Status);

                return ObjDAL.fnExecuteDataSet("sp_HotelAgents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
    

}
