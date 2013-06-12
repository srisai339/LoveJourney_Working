using System;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Web.UI.WebControls;

namespace BAL
{
    public class ClsBAL
    {
        #region Global Variables
        clsDataLayer ObjDAL;
        DataSet ObjDataset;
        #endregion
        
        #region Properties
        public Double Commission { get; set; }
        public string boardingpointinfo { get; set; }
        public int ID { set; get; }
        public string role { set; get; }
        public string Title { set; get; }
        public string TripID { set; get; }
        public string ProviderName { set; get; }
        public int ProviderID { set; get; }
        public string APIName { set; get; }
        public int Hours { set; get; }
        public int? createdBy { set; get; }
        public int modifiedBy { set; get; }
        public string userName { set; get; }
        public string password { set; get; }
        public string name { set; get; }
        public int roleId { set; get; }
        public int screenID { set; get; }
        public int edit { set; get; }
        public int delete { set; get; }
        public int cancel { set; get; }
        public int view { set; get; }
        public int permissions { set; get; }
        public int book { set; get; }
        public int add { set; get; }
        public bool Res { set; get; }
        public string Message { set; get; }

        public string api { set; get; }
        public string percentage { set; get; }
        public string screenName { set; get; }

        public string couponNo { set; get; }
        public string emailId { set; get; }
        public string Amount { set; get; }
        public string MinAmount { set; get; }
        public string MaxAmount { set; get; }

        public int bookingId { set; get; }
        public string bookingIds { set; get; }
        public string manabusRefNo { set; get; }
        public string ticketId { set; get; }
        public string travelName { set; get; }
        public string busType { set; get; }
        public string sourceName { set; get; }
        public string destinationName { set; get; }
        public int sourceId { set; get; }
        public int destionationId { set; get; }
        public DateTime? dateOFJourney { set; get; }
        public DateTime? dateOFBooking { set; get; }
        public string boardingPoint { set; get; }
        public string bookedSeats { set; get; }
        public string totalFare { set; get; }
        public string fullName { set; get; }
        public string passengersName { set; get; }
        public int age { set; get; }
        public string mobileNo { set; get; }
        public string alternativeMobileNo { set; get; }
        public string addrress { set; get; }
        public string gender { set; get; }
        public string deliveryType { set; get; }
        public string paymentType { set; get; }
        public string status { set; get; }
        public DateTime? from { set; get; }
        public DateTime? to { set; get; }
        public string address { get; set; }

        public DateTime? requestfrom { set; get; }
        public DateTime? requestto { set; get; }
        public DateTime requestedDate { set; get; }
        public int noOfSeats { set; get; }
        public string dateFilter { get; set; }
        public string commissionStatus { get; set; }

        public string comments { get; set; }

        public string blockedId { get; set; }
        public string serviceId { get; set; }
        public string serviceTranDateId { get; set; }
        public int? coachTypeId { get; set; }
        public int? boardingPointId { get; set; }
        public string Boarding_Id { get; set; }
        public string droppointName { get; set; }
        public int droppointNameId { get; set; }
        public DateTime? responsedatetime { get; set; }
        public int? cashcouponId { get; set; }
        public decimal totalbasicFare { set; get; }

        public string PNRNumber { set; get; }
        public string PNRTicketIDs { set; get; }
        public string message { set; get; }

        public string promoCode { get; set; }
        public int monthsToExpire { get; set; }

        public int tentativeId { get; set; }
        public string cancelSeats { get; set; }
        public string refundAmount { get; set; }
        public string cancellationCharges { get; set; }

        public string OnewayMBRefNo { get; set; }

        public string RoundtripMBRefNo { get; set; }

        public string PGMBRefNo { get; set; }

        public string type { get; set; }


        public string deliveredBy { get; set; }

        public string amountrecievedBy { get; set; }

        public string beforeTime { get; set; }

        public string deliveryAddress { get; set; }
        public string paidTo { get; set; }
        public string saleType { get; set; }
        public int? promoCodeId { get; set; }


        public string serviceNumber { get; set; }

        public string passengerDetails { get; set; }

        public string IDType { get; set; }

        public string IDNumber { get; set; }

        public string IDIssuedBy { get; set; }

        public string PrimaryPassengerSeat { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }



        public string MarkupAmount { get; set; }
        public string Type { get; set; }
        public int id { get; set; }

        public decimal markup { set; get; }




        #endregion

        #region Log Error

        public bool Logerror(string pageUrl, string methodName, string exception, string exceptionDetails, string ipAddress, DateTime date)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@PageURL", pageUrl);
                p[1] = new SqlParameter("@Exception", exception);
                p[2] = new SqlParameter("@ExceptionDetails", exceptionDetails);
                p[3] = new SqlParameter("@IPAddress", ipAddress);
                p[4] = new SqlParameter("@Date", date);
                p[5] = new SqlParameter("@MethodName", methodName);
                return ObjDAL.fnExecuteStoredProcedure("Sp_LogError", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Role

        public bool AddRole()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@Role", role);
                p[1] = new SqlParameter("@CreatedBy", createdBy);
                p[2] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_RoleMaster", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRoles()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_RoleMaster", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateRole()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Role", role);
                p[1] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[2] = new SqlParameter("@Query", "Update");
                p[3] = new SqlParameter("@ID", ID);
                return ObjDAL.fnExecuteStoredProcedure("Sp_RoleMaster", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteRole()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@ID", ID);
                p[1] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[2] = new SqlParameter("@Query", "Delete");
                return ObjDAL.fnExecuteStoredProcedure("Sp_RoleMaster", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetLocalIP
        public string GetLocalIP()
        {
            string _IP = null;

            // Resolves a host name or IP address to an IPHostEntry instance.
            // IPHostEntry - Provides a container class for Internet host address information.
            System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            // IPAddress class contains the address of a computer on an IP network.
            foreach (System.Net.IPAddress _IPAddress in _IPHostEntry.AddressList)
            {
                // InterNetwork indicates that an IP version 4 address is expected
                // when a Socket connects to an endpoint
                //  if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                // {

                _IP = _IPAddress.ToString();
                // }
            }
            return _IP;
        }
        #endregion

        #region Users

        public string CheckUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@UserName", userName);
                p[1] = new SqlParameter("@Password", password);
                p[2] = new SqlParameter("@Result", SqlDbType.VarChar, 100);
                p[2].Direction = ParameterDirection.Output;
                p[3] = new SqlParameter("@Query", "CheckUser");

                p[4] = new SqlParameter("@Role", SqlDbType.VarChar, 100);
                p[4].Direction = ParameterDirection.Output;

                ObjDataset = ObjDAL.fnExecuteDataset("Sp_Users", p);
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables[0].Rows.Count > 0)
                    {
                        System.Web.HttpContext.Current.Session["UserID"] = ObjDataset.Tables[0].Rows[0]["ID"].ToString();
                        System.Web.HttpContext.Current.Session["UserName"] = ObjDataset.Tables[0].Rows[0]["UserName"].ToString();
                        System.Web.HttpContext.Current.Session["Name"] = ObjDataset.Tables[0].Rows[0]["Name"].ToString();
                        System.Web.HttpContext.Current.Session["Role"] = ObjDataset.Tables[0].Rows[0]["Role"].ToString();

                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["UserID"] = null;
                        System.Web.HttpContext.Current.Session["UserName"] = null;
                        System.Web.HttpContext.Current.Session["Name"] = null;
                    }
                }
                string role = p[4].Value.ToString();
                //if (role != null && role != "")
                //{
                //    System.Web.HttpContext.Current.Session["Role"] = role;
                //}
                //else
                //{ 
                //    System.Web.HttpContext.Current.Session["Role"] = null; 
                //}
                return Convert.ToString(p[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@UserName", userName);
                p[1] = new SqlParameter("@Password", password);
                p[2] = new SqlParameter("@Name", name);
                p[3] = new SqlParameter("@RoleID", roleId);
                p[4] = new SqlParameter("@CreatedBy", createdBy);
                p[5] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Users", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet GetUsers()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_Users", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetAPIID()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@SourceID", this.sourceId);
                p[1] = new SqlParameter("@DestinationID", this.destionationId);
                p[2] = new SqlParameter("@ProviderID", this.ProviderID);
                return ObjDAL.fnExecuteDataSet("SP_Webapi", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@ID", ID);
                p[1] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[2] = new SqlParameter("@Query", "Delete");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Users", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool UpdateUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@ID", ID);
                p[1] = new SqlParameter("@UserName", userName);
                p[2] = new SqlParameter("@Password", password);
                p[3] = new SqlParameter("@Name", name);
                p[4] = new SqlParameter("@RoleID", roleId);
                p[5] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[6] = new SqlParameter("@Query", "Update");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Users", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #endregion

        #region Permissions

        public bool AddPermissions()
        {
            try
            {

                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[12];
                p[0] = new SqlParameter("@UserID", ID);
                p[1] = new SqlParameter("@ScreenID", screenID);
                p[2] = new SqlParameter("@Book", book);
                p[3] = new SqlParameter("@Cancel", cancel);
                p[4] = new SqlParameter("@Edit", edit);
                p[5] = new SqlParameter("@View", view);
                p[6] = new SqlParameter("@Add", add);
                p[7] = new SqlParameter("@Delete", delete);
                p[8] = new SqlParameter("@Permissions", permissions);
                p[9] = new SqlParameter("@CreatedBy", createdBy);
                p[10] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[11] = new SqlParameter("@Query", "Update");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Permissions", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet GetUserPermissions()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Query", "Get");
                p[1] = new SqlParameter("@UserID", ID);
                return ObjDAL.fnExecuteDataSet("Sp_Permissions", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetPerByUser()
        {
            try
            {

                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@Query", "CheckUserPer");
                p[1] = new SqlParameter("@UserID", ID);
                p[2] = new SqlParameter("@ScreenName", screenName);
                return ObjDAL.fnExecuteDataSet("Sp_Permissions", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet getscreenbyservice(string Type)
        {
            ObjDAL = new clsDataLayer();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Query", "getscreensbyservice");
            p[1] = new SqlParameter("@Type", Type);
            return ObjDAL.fnExecuteDataSet("Sp_Permissions", p);
        }

        #endregion

        #region Screens

        public DataSet GetScreens()
        {
            try
            {

                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[0];
                return ObjDAL.fnExecuteDataSet("Sp_Screen", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Commissions

        public bool AddCommission()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Api", api);
                p[1] = new SqlParameter("@Percentage", percentage);
                p[2] = new SqlParameter("@CreatedBy", createdBy);
                p[3] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Commission", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool UpdateCommission()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@CommisssionId", ID);
                p[1] = new SqlParameter("@Api", api);
                p[2] = new SqlParameter("@Percentage", percentage);
                p[3] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[4] = new SqlParameter("@Query", "Update");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Commission", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool DeleteCommission()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@CommisssionId", ID);

                p[1] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[2] = new SqlParameter("@Query", "Delete");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Commission", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet GetCommissionApis()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_Commission", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Cash Coupon

        public bool AddCashCoupon(ref Label lblMsg)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@CouponNo", couponNo);
                p[1] = new SqlParameter("@EmailId", emailId);
                p[2] = new SqlParameter("@Amount", Amount);
                p[3] = new SqlParameter("@CreatedBy", createdBy);
                p[4] = new SqlParameter("@Result", SqlDbType.VarChar, 100);
                p[4].Direction = ParameterDirection.Output;
                p[5] = new SqlParameter("@Query", "Insert");
                p[6] = new SqlParameter("@OperaterName", name);
                p[7] = new SqlParameter("@MinAmount", MinAmount);
                p[8] = new SqlParameter("@MaxAmount", MaxAmount);
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CashCoupon", p);
                lblMsg.Text = Convert.ToString(p[4].Value);
                return Res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCashCoupons()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_CashCoupon", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public bool UpdateCashCoupon()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@CouponId", ID);
                p[1] = new SqlParameter("@Amount", Amount);
                p[2] = new SqlParameter("@Query", "UpdateCashCoupon");
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CashCoupon", p);

                return Res;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool UpdateCashCouponStatus()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@CouponId", ID);
                p[1] = new SqlParameter("@Status", status);
                p[2] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[3] = new SqlParameter("@Query", "Update");
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CashCoupon", p);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet GetUpdatedCouponDetails()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@PGMBRefNo", manabusRefNo);

                p[1] = new SqlParameter("@Query", "UpdateAfterBooking");
                return ObjDAL.fnExecuteDataSet("Sp_CashCoupon", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet CheckCashCoupon()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@CouponNo", couponNo);
                p[1] = new SqlParameter("@Query", "CheckCashCoupon");
                return ObjDAL.fnExecuteDataSet("Sp_CashCoupon", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion

        #region Booking

        public bool AddBookings()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[27];
                p[0] = new SqlParameter("@ManabusRefNo", manabusRefNo);
                p[1] = new SqlParameter("@TicketId", ticketId);
                p[2] = new SqlParameter("@APIName", api);
                p[3] = new SqlParameter("@TravelName", travelName);
                p[4] = new SqlParameter("@BusType", busType);
                p[5] = new SqlParameter("@SourceId", sourceId);
                p[6] = new SqlParameter("@DestinationId", destionationId);
                p[7] = new SqlParameter("@SourceName", sourceName);
                p[8] = new SqlParameter("@DestinationName", destinationName);
                p[9] = new SqlParameter("@DateOfJourney", dateOFJourney);
                p[11] = new SqlParameter("@BoardingPoint", boardingPoint);
                p[12] = new SqlParameter("@BookedSeats", bookedSeats);
                p[13] = new SqlParameter("@TotalFare", totalFare);
                p[14] = new SqlParameter("@FullName", fullName);
                p[15] = new SqlParameter("@Age", age);
                p[16] = new SqlParameter("@MobileNo", mobileNo);
                p[17] = new SqlParameter("@AlternativeMobileNo", alternativeMobileNo);
                p[18] = new SqlParameter("@EmailId", emailId);
                p[19] = new SqlParameter("@Address", addrress);
                p[20] = new SqlParameter("@PassengersNames", passengersName);
                p[21] = new SqlParameter("@Gender", gender);
                p[22] = new SqlParameter("@DeliveryType", deliveryType);
                p[23] = new SqlParameter("@PaymentType", paymentType);
                p[24] = new SqlParameter("@CashCouponNo", couponNo);
                p[25] = new SqlParameter("@CreatedBy", createdBy);
                p[26] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Bookings", p);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetBookingDetails()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetBookingDetailsByUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@CreatedBy", createdBy);
                p[1] = new SqlParameter("@Query", "GetByUser");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetSearchResults()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@APIName", api);
                p[1] = new SqlParameter("@TravelName", travelName);
                p[2] = new SqlParameter("@from", from);
                p[3] = new SqlParameter("@To", to);

                p[4] = new SqlParameter("@CommissionStatus", status);


                return ObjDAL.fnExecuteDataSet("Sp_BookingsSearch", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetSearchResultsByUser()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[12];
                p[0] = new SqlParameter("@from", from);
                p[1] = new SqlParameter("@To", to);
                p[2] = new SqlParameter("@TravelOpName", travelName);
                p[3] = new SqlParameter("@FullName", fullName);
                p[4] = new SqlParameter("@SourceName", sourceName);
                p[5] = new SqlParameter("@DestinationName", destinationName);
                p[6] = new SqlParameter("@ContactNo", mobileNo);
                p[7] = new SqlParameter("@EmailId", emailId);
                p[8] = new SqlParameter("@CommissionStatus", status);
                p[9] = new SqlParameter("@CreatedBy", createdBy);
                p[10] = new SqlParameter("@Query", "ExecutiveSearch");
                p[11] = new SqlParameter("@DateFilter", dateFilter);
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetTicketIdByEmail()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@EmailID", emailId);
                p[1] = new SqlParameter("@MBRefNo", manabusRefNo);
                // p[2] = new SqlParameter("@Query", "GetByMBRefNo");
                return ObjDAL.fnExecuteDataSet("Sp_PartialCancellation1", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetTicketIdByrefnoforcancel()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@MBRefNo", manabusRefNo);
                p[1] = new SqlParameter("@createdBy", createdBy);
                return ObjDAL.fnExecuteDataSet("Sp_PartialCancellationAdmin", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetTicketIdByManabusRefNo()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[1] = new SqlParameter("@Query", "GetByMBRefNo");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTicketIdByOnewayManabusRefNo()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[1] = new SqlParameter("@Query", "GetByOnewayMBRefNo");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool UpdateCommissionPayStatus()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@BIds", bookingIds);
                p[1] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[2] = new SqlParameter("@Query", "updateComStatus");
                p[3] = new SqlParameter("@CommissionComment", comments);
                p[4] = new SqlParameter("@CommissionPaidTo", paidTo);
                return ObjDAL.fnExecuteStoredProcedure("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        #endregion

        #region Cancellations

        public DataSet AddCancellation()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@BookingId", bookingId);
                p[1] = new SqlParameter("@TentativeId", tentativeId);
                p[2] = new SqlParameter("@CancelledSeats", cancelSeats);
                p[3] = new SqlParameter("@EmailId", emailId);
                p[4] = new SqlParameter("@RefundAmount", refundAmount);
                p[5] = new SqlParameter("@CancellationCharges", cancellationCharges);
                p[6] = new SqlParameter("@CouponNo", couponNo);
                p[7] = new SqlParameter("@Query", "Insert");
                p[8] = new SqlParameter("@CreatedBy", createdBy);
                p[9] = new SqlParameter("@APIName", APIName);
                p[10] = new SqlParameter("@Time", Hours);
                return ObjDAL.fnExecuteDataSet("Sp_Cancellation", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AddAgentCancellation()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@BookingId", bookingId);
                p[1] = new SqlParameter("@TentativeId", tentativeId);
                p[2] = new SqlParameter("@CancelledSeats", cancelSeats);
                p[3] = new SqlParameter("@EmailId", emailId);
                p[4] = new SqlParameter("@RefundAmount", refundAmount);
                p[5] = new SqlParameter("@CancellationCharges", cancellationCharges);
                p[6] = new SqlParameter("@CouponNo", couponNo);
                p[7] = new SqlParameter("@Query", "InsertForAgent");
                p[8] = new SqlParameter("@CreatedBy", createdBy);
                p[9] = new SqlParameter("@APIName", APIName);
                p[10] = new SqlParameter("@Time", Hours);
                return ObjDAL.fnExecuteDataSet("Sp_Cancellation", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCancellations()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@CancelledSeats", cancelSeats);
                p[1] = new SqlParameter("@CancellationId", ID);
                p[2] = new SqlParameter("@RefundAmount", refundAmount);
                p[3] = new SqlParameter("@CancellationCharges", cancellationCharges);
                p[4] = new SqlParameter("@Query", "Update");
                p[8] = new SqlParameter("@ModifiedBy", modifiedBy);
                return ObjDAL.fnExecuteStoredProcedure("Sp_Cancellation", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCancellationsDetails()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_Cancellation", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCancellationsDetailsBySearch()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@DOJ", from);
                p[1] = new SqlParameter("@DOI", to);
                p[2] = new SqlParameter("@TravelOpName", travelName);
                p[3] = new SqlParameter("@FullName", fullName);
                p[4] = new SqlParameter("@SourceName", sourceName);
                p[5] = new SqlParameter("@DestinationName", destinationName);
                p[6] = new SqlParameter("@ContactNo", mobileNo);
                p[7] = new SqlParameter("@EmailId", emailId);
                p[8] = new SqlParameter("@Query", "CancelSearch");
                return ObjDAL.fnExecuteDataSet("Sp_Cancellation", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Sources

        public bool AddSources()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@ID", ticketId);
                p[1] = new SqlParameter("@SourceName", name);
                p[2] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Sources", p);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public DataSet GetSourcess()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_Sources", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetCities()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "GetCities");
                return ObjDAL.fnExecuteDataSet("Sp_Sources", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetSourceswithprefix()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Query", "Getwithprefix");
                p[1] = new SqlParameter("@SourceName", name);
                return ObjDAL.fnExecuteDataSet("Sp_Sources", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet UpdateSourceStatus(string status, string id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@Query", "UpdateStatus");
                p[1] = new SqlParameter("@Status", status);
                p[2] = new SqlParameter("@ID", id);
                return ObjDAL.fnExecuteDataSet("Sp_Sources", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet UpdateSource(string status, string originalId, string modifiedId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Query", "UpdateSource");
                p[1] = new SqlParameter("@Status", status);
                p[2] = new SqlParameter("@ID", originalId);
                p[3] = new SqlParameter("@ModifiedID", modifiedId);
                return ObjDAL.fnExecuteDataSet("Sp_Sources", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Destinations
        public bool AddDestinations(string id, string destinationName, string sourceId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@ID", id);
                p[1] = new SqlParameter("@DestinationName", destinationName);
                p[2] = new SqlParameter("@SourceId", sourceId);
                p[3] = new SqlParameter("@Query", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("Sp_Destinations", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDestinations(string sourceId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@SourceId", sourceId);
                p[1] = new SqlParameter("@Query", "GetBySourceId");
                return ObjDAL.fnExecuteDataSet("Sp_Destinations", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Customer Requests

        public bool AddCusRequest()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@Name", name);
                p[1] = new SqlParameter("@EmailId", emailId);
                p[2] = new SqlParameter("@TravelName", travelName);
                p[3] = new SqlParameter("@BusType", busType);
                p[4] = new SqlParameter("@DOJ", dateOFJourney);
                p[5] = new SqlParameter("@NoOFSeats", noOfSeats);
                p[6] = new SqlParameter("@Address", address);
                p[7] = new SqlParameter("@Query", "Insert");
                p[8] = new SqlParameter("@PhoneNo", mobileNo);
                return ObjDAL.fnExecuteStoredProcedure("Sp_CustomerRequests", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetCusRequests()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_CustomerRequests", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetCusRequestsBySearch()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Travelfrom", from);
                p[1] = new SqlParameter("@TravelTo", to);
                p[2] = new SqlParameter("@Requestedfrom", requestfrom);
                p[3] = new SqlParameter("@RequestedTo", requestto);
                p[4] = new SqlParameter("@Query", "Search");
                return ObjDAL.fnExecuteDataSet("Sp_CustomerRequests", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetCusEnquiryBySearch()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@DOJ", dateOFJourney);
                p[1] = new SqlParameter("@DOI", dateOFBooking);
                p[2] = new SqlParameter("@SourceName", sourceName);
                p[3] = new SqlParameter("@DestinationName", destinationName);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@OnewayMBRefNo", manabusRefNo);
                p[6] = new SqlParameter("@TravelOpName", travelName);
                p[7] = new SqlParameter("@ContactNo", mobileNo);
                p[8] = new SqlParameter("@FullName", fullName);
                p[9] = new SqlParameter("@Query", "CusEnquirySearch");
                p[10] = new SqlParameter("@Status", status);
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetCusEnquiryByID()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@BookingId", bookingId);
                p[1] = new SqlParameter("@Query", "GetCusEnqByID");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion

        #region Home Or Office Pickups

        public DataSet GetHomeOfficePickups()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@DeliveryType", deliveryType);
                p[1] = new SqlParameter("@Query", "DeliveryType");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetHomeOfficePickupsBySearch()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@from", from);
                p[1] = new SqlParameter("@To", to);
                p[2] = new SqlParameter("@DateFilter", dateFilter);
                p[3] = new SqlParameter("@DeliveryType", deliveryType);
                p[4] = new SqlParameter("@SourceName", sourceName);
                //p[5] = new SqlParameter("@CommissionStatus", commissionStatus);
                p[5] = new SqlParameter("@DeliveryStatus", status);
                p[6] = new SqlParameter("@Query", "HomeDeliverySearch");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateHMDeliveryStatus()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];

                p[0] = new SqlParameter("@BookingId", bookingId);
                p[1] = new SqlParameter("@DeliveryStatus", status);
                p[2] = new SqlParameter("@DeliveredBy", deliveredBy);
                p[3] = new SqlParameter("@AmountRecievedBy", amountrecievedBy);
                p[4] = new SqlParameter("@Query", "UpdateHomeDelivery");
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_TicketBookings", p);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #endregion

        #region Feedback

        public bool AddFeedback()
        {
            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Name", name);
                p[1] = new SqlParameter("@EmailId", emailId);
                p[2] = new SqlParameter("@MobileNo", mobileNo);
                p[3] = new SqlParameter("@Comments", comments);
                p[4] = new SqlParameter("@Query", "Insert");

                return ObjDAL.fnExecuteStoredProcedure("Sp_Feedback", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetFeedbacks()
        {

            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[1];

                p[0] = new SqlParameter("@Query", "Get");

                return ObjDAL.fnExecuteDataSet("Sp_Feedback", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region BusHire

        public bool AddBusHire(string description)
        {
            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[8];
                p[0] = new SqlParameter("@Name", name);
                p[1] = new SqlParameter("@EmailId", emailId);
                p[2] = new SqlParameter("@MobileNo", mobileNo);
                p[3] = new SqlParameter("@Source", sourceName);
                p[4] = new SqlParameter("@Destination", destinationName);
                p[5] = new SqlParameter("@NoOfSeats", noOfSeats);
                p[6] = new SqlParameter("@Query", "Insert");
                p[7] = new SqlParameter("@Description", description);

                return ObjDAL.fnExecuteStoredProcedure("Sp_BusHire", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public DataSet GetBusHireDetails()
        {

            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[1];

                p[0] = new SqlParameter("@Query", "Get");

                return ObjDAL.fnExecuteDataSet("Sp_BusHire", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Tentative Booking

        public bool AddTentativeBooking()
        {

            try
            {
               ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[52];
                p[0] = new SqlParameter("@OnewayMBRefNo", OnewayMBRefNo);
                p[1] = new SqlParameter("@Address", address);
                p[2] = new SqlParameter("@PGMBRefNo", PGMBRefNo);
                p[3] = new SqlParameter("@Type", type);
                p[4] = new SqlParameter("@BlockedId", blockedId);
                p[5] = new SqlParameter("@TicketNumber", ticketId);
                p[6] = new SqlParameter("@ServiceID", serviceId);
                p[7] = new SqlParameter("@ServiceTranDateID", serviceTranDateId);
                p[8] = new SqlParameter("@CoachTypeId", coachTypeId);
                p[9] = new SqlParameter("@APIName", api);
                p[10] = new SqlParameter("@TravelOPName", travelName);
                p[11] = new SqlParameter("@BusType", busType);
                p[12] = new SqlParameter("@DateOfJourney", dateOFJourney);
                p[13] = new SqlParameter("@SourceId", sourceId);
                p[14] = new SqlParameter("@DestinationId", destionationId);
                p[15] = new SqlParameter("@SourceName", sourceName);
                p[16] = new SqlParameter("@DestinationName", destinationName);
                p[17] = new SqlParameter("@SeatNos", bookedSeats);
                p[18] = new SqlParameter("@NoOfSeats", noOfSeats);
                p[19] = new SqlParameter("@TotalFare", totalbasicFare);
                p[20] = new SqlParameter("@BoardingPointID", boardingPointId);
                p[21] = new SqlParameter("@BoardingPointName", boardingPoint);
                p[22] = new SqlParameter("@DroppingPointId", droppointNameId);
                p[23] = new SqlParameter("@DroppingPointName", droppointName);
                p[24] = new SqlParameter("@FullName", fullName);
                p[25] = new SqlParameter("@Age", age);
                p[26] = new SqlParameter("@Gender", gender);
                p[27] = new SqlParameter("@ContactNo", mobileNo);
                p[28] = new SqlParameter("@EmailId", emailId);
                p[29] = new SqlParameter("@Status", status);
                p[30] = new SqlParameter("@ResponseDatetime", responsedatetime);
                p[31] = new SqlParameter("@CashCouponId", cashcouponId);
                p[32] = new SqlParameter("@DeliveryType", deliveryType);
                p[33] = new SqlParameter("@PaymentType", paymentType);
                p[34] = new SqlParameter("@CreatedBy", createdBy);
                p[35] = new SqlParameter("@Query", "Insert");
                p[36] = new SqlParameter("@BoardingInfo", boardingpointinfo);
                p[37] = new SqlParameter("@DeliveryAddress", deliveryAddress);
                p[38] = new SqlParameter("@SaleType", saleType);
                p[39] = new SqlParameter("@PromoCodeId", promoCodeId);
                p[40] = new SqlParameter("@ServiceNumber", serviceNumber);
                p[41] = new SqlParameter("@PassengerDetails", passengerDetails);
                p[42] = new SqlParameter("@IDType", IDType);
                p[43] = new SqlParameter("@IDNumber", IDNumber);
                p[44] = new SqlParameter("@PrimaryPassengerSeat", PrimaryPassengerSeat);
                p[45] = new SqlParameter("@Comment", comments);
                p[46] = new SqlParameter("@IDIssuedBy", IDIssuedBy);
                p[47] = new SqlParameter("@Commission", Commission);
                p[48] = new SqlParameter("@TripID", TripID);
                p[49] = new SqlParameter("@Title", Title);
                p[50] = new SqlParameter("@Boarding_Id", Boarding_Id);
                p[51] = new SqlParameter("@Markup", markup);
                return ObjDAL.fnExecuteStoredProcedure("Sp_TentativeBooking", p);


            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        public DataSet GetTentativeBooking()
        {

            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_TentativeBooking", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataSet GetTentativeBookingsBySearch()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@DateOfJourney", dateOFJourney);
                p[1] = new SqlParameter("@SourceName", sourceName);
                p[2] = new SqlParameter("@DestinationName", destinationName);
                p[3] = new SqlParameter("@EmailId", emailId);
                p[4] = new SqlParameter("@TravelOPName", travelName);
                p[5] = new SqlParameter("@ContactNo", mobileNo);
                p[6] = new SqlParameter("@FullName", fullName);
                p[7] = new SqlParameter("@Query", "TentativeSearch");
                p[8] = new SqlParameter("@Status", status);
                return ObjDAL.fnExecuteDataSet("Sp_TentativeBooking", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion

        #region Get ticket Details By ManabusRefNo

        public DataSet GetTcktDetByMRefNo()
        {

            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[1] = new SqlParameter("@Query", "GetdetailsByMRefNo");

                return ObjDAL.fnExecuteDataSet("Sp_TentativeBooking", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #endregion

        #region Get booked ticket details

        public DataSet GetBookedTcktDetByMRefNo()
        {

            try
            {
                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@PNRNumber", PNRNumber);
                p[1] = new SqlParameter("@PNRTicketIDs", PNRTicketIDs);
                p[2] = new SqlParameter("@Message", message);
                p[3] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[4] = new SqlParameter("@Query", "Insert");
                p[5] = new SqlParameter("@APIName", api);
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool AddBooking_TicketDetails()
        {
            try
            {


                ObjDAL = new clsDataLayer();

                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@PNRNumber", PNRNumber);
                p[1] = new SqlParameter("@PNRTicketIDs", PNRTicketIDs);
                p[2] = new SqlParameter("@Message", message);
                p[3] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[4] = new SqlParameter("@Query", "Insert1");
                p[5] = new SqlParameter("@APIName", api);
                return ObjDAL.fnExecuteStoredProcedure("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        #endregion

        #region Promo Code

        public bool AddPromoCode(ref Label lblMsg)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@PromoCode", promoCode);
                p[1] = new SqlParameter("@Amount", Amount);
                p[2] = new SqlParameter("@MonthsToExpire", monthsToExpire);
                p[3] = new SqlParameter("@CreatedBy", createdBy);
                p[4] = new SqlParameter("@Result", SqlDbType.VarChar, 200);
                p[4].Direction = ParameterDirection.Output;
                p[5] = new SqlParameter("@Query", "Insert");
                p[6] = new SqlParameter("@OperaterName", name);
                p[7] = new SqlParameter("@MinAmount", MinAmount);
                p[8] = new SqlParameter("@MaxAmount", MaxAmount);
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_PromoCode", p);
                lblMsg.Text = Convert.ToString(p[4].Value);
                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet GetPromoCodes()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_PromoCode", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public bool UpdatePromoCodeStatus()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@PromoCodeId", ID);
                p[1] = new SqlParameter("@Status", status);
                p[2] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[3] = new SqlParameter("@Query", "Update");
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_PromoCode", p);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataSet CheckPromoCode()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@PromoCode", promoCode);
                p[1] = new SqlParameter("@Query", "CheckPromoCode");
                return ObjDAL.fnExecuteDataSet("Sp_PromoCode", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion

        #region Cancellation Policy

        public bool AddCancelPolicy()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] q = new SqlParameter[5];
                q[0] = new SqlParameter("@APIName", api);
                q[1] = new SqlParameter("@CancelPercentage", percentage);
                q[2] = new SqlParameter("@Query", "Insert");
                q[3] = new SqlParameter("@BeforeTime", beforeTime);
                q[4] = new SqlParameter("@OperatorID", ID);
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CancelPolicy", q);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteCancelPolicy()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] q = new SqlParameter[2];
                q[0] = new SqlParameter("@Id", ID);
                q[1] = new SqlParameter("@Query", "Delete");
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CancelPolicy", q);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool UpdateCancelPolicy()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] q = new SqlParameter[6];
                q[0] = new SqlParameter("@Id", ID);
                q[1] = new SqlParameter("@APIName", api);
                q[2] = new SqlParameter("@CancelPercentage", percentage);
                q[3] = new SqlParameter("@Query", "update");
                q[4] = new SqlParameter("@BeforeTime", beforeTime);
                q[5] = new SqlParameter("@OperatorID", sourceId);
                Res = ObjDAL.fnExecuteStoredProcedure("Sp_CancelPolicy", q);

                return Res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataSet GetCancelPercentageByAPI()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Query", "GetByAPI");
                //if (api.Length >= 5)
                //{
                //    p[1] = new SqlParameter("@APIName", api.Substring(0, 2));
                //}
                //else { p[1] = new SqlParameter("@APIName", api); }
                p[1] = new SqlParameter("@APIName", api);
                return ObjDAL.fnExecuteDataSet("Sp_CancelPolicy", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataSet GetCancelPercentage()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];

                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_CancelPolicy", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region unique Sources/Destinations from Database


        public DataSet GetSourcesDests()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "GetSourcesDests");
                return ObjDAL.fnExecuteDataSet("Sp_TentativeBooking", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        #endregion

        #region Bitla

        public bool BitlaCallback(string travel_id, string sync_reservation_ids)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@travel_id", travel_id);
                p[1] = new SqlParameter("@sync_reservation_ids", sync_reservation_ids);
                return ObjDAL.fnExecuteStoredProcedure("sp_BitlaCallback", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBitlaCities(string id, string name)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@id", id);
                p[1] = new SqlParameter("@name", name);
                p[2] = new SqlParameter("@flag", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("sp_BitlaCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBitlaCities()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@flag", "Get");
                return ObjDAL.fnExecuteDataSet("sp_BitlaCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBitlaCityById(string id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@flag", "GetCityById");
                p[1] = new SqlParameter("@id", id);
                return ObjDAL.fnExecuteDataSet("sp_BitlaCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddSvrCities(string id, string name)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@id", id);
                p[1] = new SqlParameter("@name", name);
                p[2] = new SqlParameter("@flag", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("sp_SvrCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSvrCities()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@flag", "Get");
                return ObjDAL.fnExecuteDataSet("sp_SvrCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSvrCityById(string id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@flag", "GetCityById");
                p[1] = new SqlParameter("@id", id);
                return ObjDAL.fnExecuteDataSet("sp_SvrCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddTicketGooseCities(string id, string name)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@id", id);
                p[1] = new SqlParameter("@name", name);
                p[2] = new SqlParameter("@flag", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("sp_TicketGooseCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTicketGooseCities()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@flag", "Get");
                return ObjDAL.fnExecuteDataSet("sp_TicketGooseCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTicketGooseCityById(string id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@flag", "GetCityById");
                p[1] = new SqlParameter("@id", id);
                return ObjDAL.fnExecuteDataSet("sp_TicketGooseCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddBitlaDestinations(string id, string name, string cityId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@id", id);
                p[1] = new SqlParameter("@name", name);
                p[2] = new SqlParameter("@cityid", cityId);
                p[3] = new SqlParameter("@flag", "Insert");
                return ObjDAL.fnExecuteStoredProcedure("sp_BitlaDestinations", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBitlaDestinations(string cityId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@cityid", cityId);
                p[1] = new SqlParameter("@flag", "GetBycityid");
                return ObjDAL.fnExecuteDataSet("sp_BitlaDestinations", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBitlaRoutes
            (
          string id, string number, string name
        , string operator_service_name, string origin, string destination
        , string origin_id, string destination_id, string reservation_id
        , string operator_route_id, string travel_id, string travels
        , string bus_type, string bus_type_id, string dep_time
        , string arr_time, string duration, string available_seats
        , string total_seats, string seat_type_detail, string fare_str
        , string is_cancellable, string commission, string status
        , string JourneyDate
            )
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[26];

                p[0] = new SqlParameter("@id", id);
                p[1] = new SqlParameter("@number", number);
                p[2] = new SqlParameter("@name", name);
                p[3] = new SqlParameter("@operator_service_name", operator_service_name);
                p[4] = new SqlParameter("@origin", origin);
                p[5] = new SqlParameter("@destination", destination);
                p[6] = new SqlParameter("@origin_id", origin_id);
                p[7] = new SqlParameter("@destination_id", destination_id);
                p[8] = new SqlParameter("@reservation_id", reservation_id);
                p[9] = new SqlParameter("@operator_route_id", operator_route_id);
                p[10] = new SqlParameter("@travel_id", travel_id);
                p[11] = new SqlParameter("@travels", travels);
                p[12] = new SqlParameter("@bus_type", bus_type);
                p[13] = new SqlParameter("@bus_type_id", bus_type_id);
                p[14] = new SqlParameter("@dep_time", dep_time);
                p[15] = new SqlParameter("@arr_time", arr_time);
                p[16] = new SqlParameter("@duration", duration);
                p[17] = new SqlParameter("@available_seats", available_seats);
                p[18] = new SqlParameter("@total_seats", total_seats);
                p[19] = new SqlParameter("@seat_type_detail", seat_type_detail);
                p[20] = new SqlParameter("@fare_str", fare_str);
                p[21] = new SqlParameter("@is_cancellable", is_cancellable);
                p[22] = new SqlParameter("@commission", commission);
                p[23] = new SqlParameter("@status", status);
                p[24] = new SqlParameter("@JourneyDate", JourneyDate);

                p[25] = new SqlParameter("@flag", "Insert");

                return ObjDAL.fnExecuteStoredProcedure("sp_BitlaRoutes", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBitlaRoutes(string journeyDate, string originId, string destinationId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@JourneyDate", journeyDate);
                p[1] = new SqlParameter("@origin_id", originId);
                p[2] = new SqlParameter("@destination_id", destinationId);
                p[3] = new SqlParameter("@flag", "Get");
                return ObjDAL.fnExecuteDataSet("sp_BitlaRoutes", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTicketGooseDestinations(string sourceId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@SourceId", sourceId);
                return ObjDAL.fnExecuteDataSet("sp_GetTicketGooseDestinations", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public bool UpdateAgentBalance(int agentID, Double Deductamount, Double commisionFare)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@AgentId", agentID);
                p[1] = new SqlParameter("@RefundAmount", Deductamount);
                p[2] = new SqlParameter("@Flag", "UpdateagentBalance");
                return ObjDAL.fnExecuteStoredProcedure("sp_Agents", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool deductDistributorbalance(int agentId, double amount, string AmountType)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Flag", "UpdateDistributorBalance");
                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@Amount", amount);
                p[3] = new SqlParameter("@AmountType", AmountType);
                return ObjDAL.fnExecuteStoredProcedure("sp_Agents", p);

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAgentsbyDistributorID(int DistributorID)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAgentByDistributorWise");
                p[1] = new SqlParameter("@DistributorID", DistributorID);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetempbybsdID(int DistributorID)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetEmployeeByBsdWise");
                p[1] = new SqlParameter("@DistributorID", DistributorID);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentsbyBSDID(int DistributorID)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAgentByDistributorWise");
                p[1] = new SqlParameter("@DistributorID", DistributorID);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetTicketIdByTicketrefNo()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@PGMBRefNo", manabusRefNo);
                p[1] = new SqlParameter("@Query", "GetByMBRefNo");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AddCustRequestInsert(string name, string emailId, string phoneNo, string travelName, string busType, DateTime doj, int noOfSeats, DateTime requestedDate)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[8];

                p[0] = new SqlParameter("@Name", name);
                p[1] = new SqlParameter("@EmailId", emailId);
                p[2] = new SqlParameter("@PhoneNo", phoneNo);
                p[3] = new SqlParameter("@TravelName", travelName);
                p[4] = new SqlParameter("@BusType", busType);
                p[5] = new SqlParameter("@DOJ", doj);
                p[6] = new SqlParameter("@NoOFSeats", noOfSeats);
                p[7] = new SqlParameter("@RequestedDate", requestedDate);

                return ObjDAL.fnExecuteStoredProcedure("sp_CustRequestInsert", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region BusOperators
        public bool AddBusOperator(string name, string apiName)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@BusOperatorName", name);
                p[1] = new SqlParameter("@Query", "Insert");
                p[2] = new SqlParameter("@APIName", apiName);
                return ObjDAL.fnExecuteStoredProcedure("Sp_BusOperator", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBusOperators()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_BusOperator", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetBusOperatorsByAPI()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Query", "GetByAPI");
                p[1] = new SqlParameter("@APIName", api);
                return ObjDAL.fnExecuteDataSet("Sp_BusOperator", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateBusOperator(string name, int id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@BusOperatorName", name);
                p[1] = new SqlParameter("@BusOperatorId", id);
                p[2] = new SqlParameter("@Query", "Update");

                return ObjDAL.fnExecuteStoredProcedure("Sp_BusOperator", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRating(int id, int rating)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@BusOperatorId", id);
                p[1] = new SqlParameter("@Rating", rating);
                p[2] = new SqlParameter("@Query", "Insert");

                return ObjDAL.fnExecuteStoredProcedure("Sp_Rating", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRatings()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "Get");
                return ObjDAL.fnExecuteDataSet("Sp_Rating", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRatingByOperatorId(int operatorId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@Query", "GetByBusOperatorId");
                p[1] = new SqlParameter("@BusOperatorId", operatorId);

                return ObjDAL.fnExecuteDataSet("Sp_Rating", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRatingByRatingId(int ratingId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@Query", "GetByBusRatingId");
                p[1] = new SqlParameter("@Id", ratingId);

                return ObjDAL.fnExecuteDataSet("Sp_Rating", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateRating(int rating, int id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@Id", id);
                p[1] = new SqlParameter("@Rating", rating);
                p[2] = new SqlParameter("@Query", "Update");

                return ObjDAL.fnExecuteStoredProcedure("Sp_Rating", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Payment Details

        public DataSet GetPaymentDetials()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@APIName", api);
                return ObjDAL.fnExecuteDataSet("Sp_GetPayDetailsByAPI", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        #endregion

        #region Get Online Sales

        public DataSet GetOnlineSales()
        {

            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Query", "GetByOnlineSales");
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public DataSet GetOnlineSaleBySearch()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[11];
                p[0] = new SqlParameter("@from", from);
                p[1] = new SqlParameter("@To", to);
                p[2] = new SqlParameter("@TravelOpName", travelName);
                p[3] = new SqlParameter("@FullName", fullName);
                p[4] = new SqlParameter("@SourceName", sourceName);
                p[5] = new SqlParameter("@DestinationName", destinationName);
                p[6] = new SqlParameter("@ContactNo", mobileNo);
                p[7] = new SqlParameter("@EmailId", emailId);
                p[8] = new SqlParameter("@CommissionStatus", status);

                p[9] = new SqlParameter("@Query", "OnlineSaleSearch");
                p[10] = new SqlParameter("@DateFilter", dateFilter);
                return ObjDAL.fnExecuteDataSet("Sp_TicketBookings", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Check ManabusRef No

        public bool CheckCashCouponAvailability(string code)
        {

            try
            {
                bool available = false;
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@CouponNo", code);
                p[1] = new SqlParameter("@Query", "CheckCashCoupon");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("Sp_CashCoupon", p);
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows.Count == 0)
                        {
                            available = true;
                        }
                        else { available = false; }
                    }
                }
                return available;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                if (ObjDataset != null)
                {

                    ObjDataset = null;

                }

            }





        }

        public bool CheckManabusRefNoAvailability(string code)
        {

            try
            {
                bool available = false;
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@OnewayMBRefNo", code);
                p[1] = new SqlParameter("@Query", "CheckManabusrefno");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("Sp_TentativeBooking", p);
                if (ObjDataset != null)
                {
                    if (ObjDataset.Tables.Count > 0)
                    {
                        if (ObjDataset.Tables[0].Rows.Count == 0)
                        {
                            available = true;
                        }
                        else { available = false; }
                    }
                }
                return available;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public string GetUniqueId()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                p[0].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_GetId", p);
                return Convert.ToString(p[0].Value.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Agents
        public string AddAgent(string agentName, string type, DateTime dateOfBirth, string city, string state, string address, string pinCode
            , string mobileNo, string alternateMobileNo, string landlineNo, string emailId, string panNo, string details, string status, string username
            , string password, int createdBy, int modifiedBy, int commisionPercentage, string Role, string Country, string DomesticFlights, string InterNationalFlights, string Buses, string Hotels, string Recharge, string District)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[29];

                p[0] = new SqlParameter("@AgentName", agentName);
                p[1] = new SqlParameter("@Type", type);
                p[2] = new SqlParameter("@DateOfBirth", dateOfBirth);
                p[3] = new SqlParameter("@City", city);
                p[4] = new SqlParameter("@State", state);
                p[5] = new SqlParameter("@Address", address);
                p[6] = new SqlParameter("@PinCode", pinCode);
                p[7] = new SqlParameter("@MobileNo", mobileNo);

                p[8] = new SqlParameter("@AlternateMobileNo", alternateMobileNo);
                p[9] = new SqlParameter("@LandlineNo", landlineNo);
                p[10] = new SqlParameter("@EmailId", emailId);
                p[11] = new SqlParameter("@PANNo", panNo);
                p[12] = new SqlParameter("@Details", details);
                p[13] = new SqlParameter("@Status", status);
                p[14] = new SqlParameter("@Username", username);
                p[15] = new SqlParameter("@Password", password);

                p[16] = new SqlParameter("@CreatedBy", createdBy);
                p[17] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[18] = new SqlParameter("@Flag", "Insert");
                p[19] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[19].Direction = ParameterDirection.Output;
                p[20] = new SqlParameter("@CommisionPercentage", commisionPercentage);
                p[21] = new SqlParameter("@Role", Role);
                p[22] = new SqlParameter("@Country", Country);




                p[23] = new SqlParameter("@DomesticFlights", DomesticFlights);
                p[24] = new SqlParameter("@InterNationalFlights", InterNationalFlights);
                p[25] = new SqlParameter("@Buses", Buses);
                p[26] = new SqlParameter("@Hotels", Hotels);
                p[27] = new SqlParameter("@Recharge", Recharge);
                p[28] = new SqlParameter("@District", District);

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[19].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgents()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Flag", "Get");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAllTYpes(string Type)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAlltypes");
                p[1] = new SqlParameter("@Type", Type);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentById(int agentId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", agentId);
                p[1] = new SqlParameter("@Flag", "GetById");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentById1(int agentId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Id", agentId);
                p[1] = new SqlParameter("@Flag", "Getagents");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentByUserId(int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", userId);
                p[1] = new SqlParameter("@Flag", "GetByUserId");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public string Updatecancelstatus(string  Id,string status)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Query", "updatestatus");
                p[1] = new SqlParameter("@ReferanceId", Id);
                p[2] = new SqlParameter("@Status", status);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);  
                p[3].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_CarProvisional", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string Updatedmr(int Id, string status)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@TableName", "Updatedmrstatus");
                p[1] = new SqlParameter("@Id", Id);
                p[2] = new SqlParameter("@Status", status);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_dmr", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public void  updaterc(string  Id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "updaterc");
                p[1] = new SqlParameter("@Id", Id);


                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
               
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string UpdateAgentStatus(int agentId, string status)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Flag", "UpdateAgentStaus");
                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@Status", status);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string UpdateAgent(string agentName, string type, DateTime dateOfBirth, string city, string state, string address, string pinCode
            , string mobileNo, string alternateMobileNo, string landlineNo, string emailId, string panNo, string details, string status
            , string password, int agentId, int modifiedBy, int commisionPercentage, string DomesticFlights, string InterNationalFlights, string Buses, string Hotels, string Recharge)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[26];

                p[0] = new SqlParameter("@AgentName", agentName);
                p[1] = new SqlParameter("@Type", type);
                p[2] = new SqlParameter("@DateOfBirth", dateOfBirth);
                p[3] = new SqlParameter("@City", city);
                p[4] = new SqlParameter("@State", state);
                p[5] = new SqlParameter("@Address", address);
                p[6] = new SqlParameter("@PinCode", pinCode);
                p[7] = new SqlParameter("@MobileNo", mobileNo);

                p[8] = new SqlParameter("@AlternateMobileNo", alternateMobileNo);
                p[9] = new SqlParameter("@LandlineNo", landlineNo);
                p[10] = new SqlParameter("@EmailId", emailId);
                p[11] = new SqlParameter("@PANNo", panNo);
                p[12] = new SqlParameter("@Details", details);
                p[13] = new SqlParameter("@Status", status);
                p[14] = new SqlParameter("@Username", "");
                p[15] = new SqlParameter("@Password", password);

                p[16] = new SqlParameter("@AgentId", agentId);
                p[17] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[18] = new SqlParameter("@Flag", "UpdateAgent");
                p[19] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[19].Direction = ParameterDirection.Output;
                p[20] = new SqlParameter("@CommisionPercentage", commisionPercentage);
                p[21] = new SqlParameter("@DomesticFlights", DomesticFlights);
                p[22] = new SqlParameter("@InterNationalFlights", InterNationalFlights);
                p[23] = new SqlParameter("@Buses", Buses);
                p[24] = new SqlParameter("@Hotels", Hotels);
                p[25] = new SqlParameter("@Recharge", Recharge);



                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[19].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string UpdateAgentByAgent(string agentName, string type, DateTime dateOfBirth, string city, string state, string address, string pinCode
           , string mobileNo, string alternateMobileNo, string landlineNo, string emailId, string panNo, string details, string status
           , string password, int agentId, int modifiedBy, int commisionPercentage)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[21];

                p[0] = new SqlParameter("@AgentName", agentName);
                p[1] = new SqlParameter("@Type", type);
                p[2] = new SqlParameter("@DateOfBirth", dateOfBirth);
                p[3] = new SqlParameter("@City", city);
                p[4] = new SqlParameter("@State", state);
                p[5] = new SqlParameter("@Address", address);
                p[6] = new SqlParameter("@PinCode", pinCode);
                p[7] = new SqlParameter("@MobileNo", mobileNo);

                p[8] = new SqlParameter("@AlternateMobileNo", alternateMobileNo);
                p[9] = new SqlParameter("@LandlineNo", landlineNo);
                p[10] = new SqlParameter("@EmailId", emailId);
                p[11] = new SqlParameter("@PANNo", panNo);
                p[12] = new SqlParameter("@Details", details);
                p[13] = new SqlParameter("@Status", status);
                p[14] = new SqlParameter("@Username", "");
                p[15] = new SqlParameter("@Password", password);

                p[16] = new SqlParameter("@AgentId", agentId);
                p[17] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[18] = new SqlParameter("@Flag", "UpdateAgentByAgent");
                p[19] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[19].Direction = ParameterDirection.Output;
                p[20] = new SqlParameter("@CommisionPercentage", commisionPercentage);


                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[19].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string ChangePassword(int userId, string password, int modifiedBy, string currentPassword)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@Flag", "ChangePWD");
                p[1] = new SqlParameter("@AgentId", userId);
                p[2] = new SqlParameter("@Password", password);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;
                p[4] = new SqlParameter("@ModifiedBy", modifiedBy);
                p[5] = new SqlParameter("@Username", currentPassword);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string AddAgentDeposit(int agentId, double amount, string details, int createdBy, string depositType, string transactionNumber, string reason)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@Flag", "InsertAgentBalance");

                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@Amount", amount);

                p[3] = new SqlParameter("@Details", details);
                p[4] = new SqlParameter("@CreatedBy", createdBy);

                p[5] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[5].Direction = ParameterDirection.Output;

                p[6] = new SqlParameter("@DepositType", depositType);
                p[7] = new SqlParameter("@TransactionNumber", transactionNumber);
                p[8] = new SqlParameter("@Reason", reason);

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string DeductAgentDeposit(int agentId, double amount, string details, int createdBy, string depositType, string transactionNumber, string reason)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@Flag", "DedAgentBalance");

                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@Amount", amount);

                p[3] = new SqlParameter("@Details", details);
                p[4] = new SqlParameter("@CreatedBy", createdBy);

                p[5] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[5].Direction = ParameterDirection.Output;

                p[6] = new SqlParameter("@DepositType", depositType);
                p[7] = new SqlParameter("@TransactionNumber", transactionNumber);
                p[8] = new SqlParameter("@Reason", reason);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentDeposits(int agentId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", agentId);
                p[1] = new SqlParameter("@Flag", "GetAgentBalance");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string DeductAgentBalance(int agentId, double deductAmount, int createdBy, string mbRefNo, double actualFare,
            double commisionFare, double commisionPercentage)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];
                p[0] = new SqlParameter("@Flag", "DeductAgentBalance");

                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@Amount", deductAmount);

                p[3] = new SqlParameter("@MBRefNo", mbRefNo);
                p[4] = new SqlParameter("@CreatedBy", createdBy);

                p[5] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[5].Direction = ParameterDirection.Output;

                p[6] = new SqlParameter("@ActualFare", actualFare);
                p[7] = new SqlParameter("@CommisionFare", commisionFare);
                p[8] = new SqlParameter("@CommisionPercentage", commisionPercentage);

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string AdjustAgentBalance(string mbRefNo, double refundAmount, double cancellationCharges, int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@Flag", "AdjustAgentBalance");
                p[1] = new SqlParameter("@MBRefNo", mbRefNo);
                p[2] = new SqlParameter("@RefundAmount", refundAmount);
                p[3] = new SqlParameter("@CancellationCharges", cancellationCharges);
                p[4] = new SqlParameter("@AgentId", userId);
                p[5] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[5].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string AdjustAgentBalance1(string mbRefNo, double refundAmount, double cancellationCharges, int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@Flag", "AdjustAgentBalance1");
                p[1] = new SqlParameter("@MBRefNo", mbRefNo);
                p[2] = new SqlParameter("@RefundAmount", refundAmount);
                p[3] = new SqlParameter("@CancellationCharges", cancellationCharges);
                p[4] = new SqlParameter("@AgentId", userId);
                p[5] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[5].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[5].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentDepositsByUserId(int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", userId);
                p[1] = new SqlParameter("@Flag", "GetAgentBalanceByUserId");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentBookedTickets(int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", userId);
                p[1] = new SqlParameter("@Flag", "GetAgentBookedTickets");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentBookedTicketsForAdmin(int? userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", userId);
                p[1] = new SqlParameter("@Flag", "GetAgentBookedTicketsForAdmin");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAgentBookedTicketsForAdminUser(int? userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@AgentId", userId);
                p[1] = new SqlParameter("@Flag", "GetAgentBookedTicketsForAdminUser");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet SearchAgentBookedTickets(int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[12];

                p[0] = new SqlParameter("@DOJ", dateOFJourney);
                p[1] = new SqlParameter("@DOI", dateOFBooking);
                p[2] = new SqlParameter("@SourceName", sourceName);
                p[3] = new SqlParameter("@DestinationName", destinationName);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@OnewayMBRefNo", manabusRefNo);
                p[6] = new SqlParameter("@TravelOpName", travelName);
                p[7] = new SqlParameter("@ContactNo", mobileNo);
                p[8] = new SqlParameter("@FullName", fullName);

                p[9] = new SqlParameter("@Flag", "SearchAgentBookedTickets");
                p[10] = new SqlParameter("@AgentId", userId);
                p[11] = new SqlParameter("@Status", status);

                return ObjDAL.fnExecuteDataSet("sp_Agents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet SearchAgentBookedTicketsForAdmin(int? userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[12];

                p[0] = new SqlParameter("@DOJ", dateOFJourney);
                p[1] = new SqlParameter("@DOI", dateOFBooking);
                p[2] = new SqlParameter("@SourceName", sourceName);
                p[3] = new SqlParameter("@DestinationName", destinationName);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@OnewayMBRefNo", manabusRefNo);
                p[6] = new SqlParameter("@TravelOpName", travelName);
                p[7] = new SqlParameter("@ContactNo", mobileNo);
                p[8] = new SqlParameter("@FullName", fullName);

                p[9] = new SqlParameter("@Flag", "SearchAgentBookedTicketsForAdmin");
                p[10] = new SqlParameter("@AgentId", userId);
                p[11] = new SqlParameter("@Status", status);

                return ObjDAL.fnExecuteDataSet("sp_Agents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet SearchAgentBookedTicketsForAdminUser(int? userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[12];

                p[0] = new SqlParameter("@DOJ", dateOFJourney);
                p[1] = new SqlParameter("@DOI", dateOFBooking);
                p[2] = new SqlParameter("@SourceName", sourceName);
                p[3] = new SqlParameter("@DestinationName", destinationName);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@OnewayMBRefNo", manabusRefNo);
                p[6] = new SqlParameter("@TravelOpName", travelName);
                p[7] = new SqlParameter("@ContactNo", mobileNo);
                p[8] = new SqlParameter("@FullName", fullName);

                p[9] = new SqlParameter("@Flag", "SearchAgentBookedTicketsForAdminUser");
                p[10] = new SqlParameter("@AgentId", userId);
                p[11] = new SqlParameter("@Status", status);

                return ObjDAL.fnExecuteDataSet("sp_Agents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string ForgotPassword(string userName, string emailId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Flag", "ForgotPassword");
                p[1] = new SqlParameter("@Username", userName);
                p[2] = new SqlParameter("@EmailId", emailId);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string InsertDepositUpdateRequest(int userId, double depositAmount, string mobileNo, string transactionId, string type, string depositBank,
            string chequeDrawnBank, DateTime? chequeIssueDate, string chequeNo, int createdBy, string status)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[14];

                p[0] = new SqlParameter("@Flag", "Insert");
                p[2] = new SqlParameter("@UserId", userId);
                p[4] = new SqlParameter("@DepositAmount", depositAmount);
                p[5] = new SqlParameter("@MobileNo", mobileNo);
                p[6] = new SqlParameter("@TransactionId", transactionId);
                p[7] = new SqlParameter("@Type", type);
                p[8] = new SqlParameter("@DepositBank", depositBank);
                p[9] = new SqlParameter("@ChequeDrawnBank", chequeDrawnBank);
                p[10] = new SqlParameter("@ChequeIssueDate", chequeIssueDate);
                p[11] = new SqlParameter("@ChequeNo", chequeNo);
                p[12] = new SqlParameter("@CreatedBy", createdBy);
                p[1] = new SqlParameter("@ModifiedBy", createdBy);
                p[13] = new SqlParameter("@status", status);
                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string InsertAgentRequest(string name, string emailId, string org, string mobileNo, string city, string state, string comments, string District,string Type,string createdby,string appointmentdate,string status,string username,string Address,string pincode)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[17];

                p[0] = new SqlParameter("@Flag", "Insert");
                p[2] = new SqlParameter("@Name", name);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@Organization", org);
                p[6] = new SqlParameter("@MobileNo", mobileNo);
                p[7] = new SqlParameter("@City", city);
                p[8] = new SqlParameter("@State", state);
                p[1] = new SqlParameter("@Comments", comments);
                p[9] = new SqlParameter("@District", District);
                p[10] = new SqlParameter("@Type", Type);
                p[11] = new SqlParameter("@CreatedBy", createdby);
                p[12] = new SqlParameter("@appointmentdate", appointmentdate);
                p[13] = new SqlParameter("@status", status);
                p[14] = new SqlParameter("@Username", username);
                p[15] = new SqlParameter("@Address", Address);
                p[16] = new SqlParameter("@Pincode", pincode);

                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public string InsertEmpRequest(string name, string emailId, string org, string mobileNo, string city, string state, string comments, string District, string Type, string createdby, string appointmentdate, string status, string filename, string pathname, string filename1, string pathname1,string qualification,string address)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[20];

                p[0] = new SqlParameter("@Flag", "Insert");
                p[2] = new SqlParameter("@Name", name);
                p[4] = new SqlParameter("@EmailId", emailId);
                p[5] = new SqlParameter("@Organization", org);
                p[6] = new SqlParameter("@MobileNo", mobileNo);
                p[7] = new SqlParameter("@City", city);
                p[8] = new SqlParameter("@State", state);
                p[1] = new SqlParameter("@Comments", comments);
                p[9] = new SqlParameter("@District", District);
                p[10] = new SqlParameter("@Type", Type);
                p[11] = new SqlParameter("@CreatedBy", createdby);
                p[12] = new SqlParameter("@appointmentdate", appointmentdate);
                p[13] = new SqlParameter("@status", status);
                p[14] = new SqlParameter("@FileName", filename);
                p[15] = new SqlParameter("@FilePath", pathname);
                p[16] = new SqlParameter("@DocName", filename1);
                p[17] = new SqlParameter("@DocPath", pathname);
                p[18] = new SqlParameter("@Qualification", qualification);
                p[19] = new SqlParameter("@Address", address);

                p[3] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[3].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return Convert.ToString(p[3].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentRequests()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Flag", "Get");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetEmpRequests()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Flag", "Emprequests");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetStatewiseemprequests(string state)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "Getstatewiseemprequests");
                p[1] = new SqlParameter("@State", state);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetState(int id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetState");
                p[1] = new SqlParameter("@Id", id);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetPendingRequests()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Flag", "PendingRequests");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAgentRequests1()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetEmployee");
                p[1] = new SqlParameter("@Type", "Emp");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAgentRequests2()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetEmployee");
                p[1] = new SqlParameter("@Type", "coorporate");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentRequestFromEmp(string createdby)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAgentRequestsByemp");
                p[1] = new SqlParameter("@CreatedBy", createdby);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentRequestFromEmp1( int id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "Emprequests1");
             
                p[1] = new SqlParameter("@Id",id);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet DeleteAgentRequests(int id)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "Delete");
                p[1] = new SqlParameter("@Id", id);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetDepositUpdateRequests()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@Flag", "Get");
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet getDepositrequestsforseach()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Flag", "FundtransferReport");
                p[1] = new SqlParameter("@FromDate", FromDate);
                p[2] = new SqlParameter("@ToDate", ToDate);
                p[3] = new SqlParameter("@AgentName", name);
                p[4] = new SqlParameter("@Type", type);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet getdmr()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@TableName", "Getdmr");
                p[1] = new SqlParameter("@FromDate", FromDate);
                p[2] = new SqlParameter("@ToDate", ToDate);
                p[3] = new SqlParameter("@CreatedBy", createdBy);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_dmr", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet getdmrbyid()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@TableName", "getdmrbyid");
                p[1] = new SqlParameter("@Id", createdBy);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_dmr", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string InsertAgentLogo(int userId, byte[] agentLogo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@Flag", "InsertAgentLogo");
                p[1] = new SqlParameter("@AgentId", userId);
                p[3] = new SqlParameter("@AgentLogo", agentLogo);
                p[2] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[2].Direction = ParameterDirection.Output;

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return Convert.ToString(p[2].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public DataSet GetAgentLogo(int userId)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAgentLogo");
                p[1] = new SqlParameter("@AgentId", userId);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_Agents", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string UpdateDepositRequest(int agentId, double depositAmount, string transactionId, string type, string depositBank,
        string chequeDrawnBank, DateTime? chequeIssueDate, string chequeNo, int createdBy, int DepositedId, string details, string status)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[15];

                p[0] = new SqlParameter("@Flag", "UpdateStatus");
                p[1] = new SqlParameter("@AgentId", agentId);
                p[2] = new SqlParameter("@DepositAmount", depositAmount);
                p[3] = new SqlParameter("@TransactionId", transactionId);
                p[4] = new SqlParameter("@Type", type);
                p[5] = new SqlParameter("@DepositBank", depositBank);
                p[6] = new SqlParameter("@ChequeDrawnBank", chequeDrawnBank);
                p[7] = new SqlParameter("@ChequeIssueDate", chequeIssueDate);
                p[8] = new SqlParameter("@ChequeNo", chequeNo);
                p[9] = new SqlParameter("@CreatedBy", createdBy);
                p[10] = new SqlParameter("@ModifiedBy", createdBy);
                p[11] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[11].Direction = ParameterDirection.Output;
                p[12] = new SqlParameter("@Id", DepositedId);
                p[13] = new SqlParameter("@Details", details);
                p[14] = new SqlParameter("@Status", status);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return Convert.ToString(p[11].Value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public string Upstatus(int UserId, double Amount)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];

                p[0] = new SqlParameter("@Flag", "upstatus");
                p[1] = new SqlParameter("@UserId", UserId);
                p[2] = new SqlParameter("@DepositAmount", Amount);

                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return ObjDataset.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet getDepositsByAdminForAgents()
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@Flag", "AgentDepositsReport");
                p[1] = new SqlParameter("@FromDate", FromDate);
                p[2] = new SqlParameter("@ToDate", ToDate);
                p[3] = new SqlParameter("@AgentName", name);
                p[4] = new SqlParameter("@Type", type);
                ObjDataset = (DataSet)ObjDAL.fnExecuteDataSet("sp_AgentDepositRequests", p);
                return ObjDataset;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion



        //ravi


        public bool Commissionslab(string strrole, string strservicename, decimal commission, string strcreatedBy, string operatorName)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@Role", strrole);
                p[1] = new SqlParameter("@ServiceName", strservicename);
                p[2] = new SqlParameter("@Commission", commission);
                p[3] = new SqlParameter("@CreatedBy", strcreatedBy);
                p[4] = new SqlParameter("@tablename", "insert");
                p[5] = new SqlParameter("@OperatorName", operatorName);
                return ObjDAL.fnExecuteStoredProcedure("SP_CommissionSlab", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet AllReports(string strservicename, int AgentID, DateTime fromdate, DateTime todate, string Agent, string RefNo)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@AgentId", AgentID);
                p[1] = new SqlParameter("@tablename", strservicename);
                p[2] = new SqlParameter("@FromDate", fromdate);
                p[3] = new SqlParameter("@ToDate", todate);
                p[4] = new SqlParameter("@Agent", Agent);
                p[5] = new SqlParameter("@RefNo", RefNo);
                return ObjDAL.fnExecuteDataset("SP_ALLReports", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataSet GetCommisssions1(string strtablename)
        //{
        //    try
        //    {
        //        ObjDAL = new clsDataLayer();
        //        SqlParameter[] p = new SqlParameter[1];
        //        p[0] = ~ew SqlParameter("@tablename", strtablename);
        //        return ObjDAL.fnExecuteDataset("SP_CommissionSlab", p);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //bindu
        public DataSet GetAirlineNames(string type)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Flag", "GetAirlineNames");
                p[1] = new SqlParameter("@Type", type);
                return ObjDAL.fnExecuteDataset("sp_Agents", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetCommissionSlab(string role, string serviceName, string operatorName)
        {
            try
            {
                ObjDAL = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[4];
                p[0] = new SqlParameter("@tablename", "Getdata");
                p[1] = new SqlParameter("@Role", role);
                p[2] = new SqlParameter("@ServiceName", serviceName);
                p[3] = new SqlParameter("@OperatorName", operatorName);
                return ObjDAL.fnExecuteDataset("SP_CommissionSlab", p);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }






    }
}
