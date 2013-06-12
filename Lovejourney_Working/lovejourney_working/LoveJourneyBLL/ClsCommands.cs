using System;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Web.UI.WebControls;

namespace BAL
{

    public enum blossom
    {
        InsertEmployee, InsertHotelPolicy, InsertCab, InsertCar, InsertCity, InsertCarDetailsForCity,InsertPassengerDetails,
        SelectEmployee, AllSelectRecord, SelectHotelPolicy, SelectCab, SelectAllCab, SelectCar, SelectCityName, SelectCarDetails, SelectAllCitys,SelectAllCars,SelectAllCarDetailsForCity,SelectCarResult,SelectPsgDtls,SelectGetMailDetails,
        DelectEmployee, DeleteCab, DeleteCar, DeleteCity, DeleteCarDetailsForCity,
        UpdateEmployee, UpdateHotelPolicy, UpdateCab, UpdateCar, UpdateCity, UpdateCarDetailsForCity,GetCabDetails,
        Operators,CarDetails,GetCarTicketDetais,GetAgentTicketDetaisl,GetUserTicketDetaisl,GetGuestTicketDetail,GetIndividualAgentTicketDetaisl,GetCancellationdetails
        
        
        
        
    }

    public class ClsCommands
    {
        DataSet ObjDataset;
        private clsDataLayer _objDataLayer;

       

        public blossom ScreenInd { get; set; }
        public string EmpName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int EmpId { get; set; }
        public string HotelDetails { get; set; }
        public int HotelId { get; set; }
        public int CarId { get; set;}
        public int CabId { get; set; }
        public string CabType { get; set; }
        public string Travels { get; set; }
        public int Price {get; set;}
        public string City { get; set;}
        public string HiringFor{ get;set;}
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CarName { get; set; }
        public double BasicPrice { get; set; }
        public int ExtarHours { get; set; }
        public int ExtarKilometers { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Status { get; set; }
        public int CarDetailsId { get; set; }
        public int PassengerId { get; set; }
        public string TravelDate { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string LandMark { get; set; }
        public string ReferanceId {get;set;}
        public Panel pnlTicket { get; set; }
        public string BookingType { get; set; }
        public string PickUpTime { get; set; }
        public string usage { get; set; }
        public string Limit { get; set; }
        public string carimagepath { get; set;}
        public string Basicfare { get; set; }
        public string AgentId{ get; set; }
        public string AgentName{ get; set; }
        public string Role{ get; set; }
        public string city_car { get; set; }
        public string TotalFare { get; set; }

        
        public bool fnInsertRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();


                switch (this.ScreenInd)
                {
                    case blossom.InsertEmployee:
                        _objDataLayer.fnExecuteStoredProcedure("SP_Employee", new SqlParameter("@Query", "Insert"),
                                                                               new SqlParameter("@EmpName", this.EmpName),
                                                                               new SqlParameter("@phoneNo", this.PhoneNo),
                                                                               new SqlParameter("@Email", this.Email),
                                                                               new SqlParameter("@Address", this.Address));
                        break;

                    case blossom.InsertHotelPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("SP_HotelPolicy", new SqlParameter("@Query", "Insert"),
                                                                                 new SqlParameter("@Details", this.HotelDetails));
                                                                             
                        break;
                    case blossom.InsertCab:
                        _objDataLayer.fnExecuteStoredProcedure("SP_Cab", new SqlParameter("@Query", "Insert"),
                                                                               new SqlParameter("@CabType", this.CabType),
                                                                               new SqlParameter("@Travels", this.Travels),
                                                                               new SqlParameter("@Price", this.Price),
                                                                               new SqlParameter("@City", this.City),
                                                                               new SqlParameter("@HiringFor", this.HiringFor));
                        break;
                    case blossom.InsertCity:
                        _objDataLayer.fnExecuteStoredProcedure("SP_City", new SqlParameter("@Query", "Insert"),
                                                                              new SqlParameter("@CityName", this.CityName),
                                                                              new SqlParameter("@CreatedBy", this.CreatedBy));
                                                                             
                                                                             
                        break;
                    case blossom.InsertCar:
                        _objDataLayer.fnExecuteStoredProcedure("SP_Car", new SqlParameter("@Query", "Insert"),
                                                                             new SqlParameter("@CarName", this.CarName),
                                                                             new SqlParameter("@CarImagePath",this.carimagepath),
                                                                             new SqlParameter("@CreatedBy", this.CreatedBy));
                                                                             
                                                                             
                                                                                                                                 
                        break;
                    case blossom.InsertCarDetailsForCity:
                        _objDataLayer.fnExecuteStoredProcedure("SP_CarDetailsForCity", new SqlParameter("@Query", "Insert"),
                                                                                       new SqlParameter("@CityId",this.CityId),
                                                                                       new SqlParameter("@CarId",this.CarId),
                                                                                        new SqlParameter("@BasicPrice", this.BasicPrice),
                                                                                        new SqlParameter("@ExtarHours", this.ExtarHours),
                                                                                        new SqlParameter("@ExtarKilometers", this.ExtarKilometers),
                                                                                        new SqlParameter("@Usage",this.usage),
                                                                                        new SqlParameter("@Capacity",this.Limit),
                                                                                        new SqlParameter("@Status",this.Status),
                                                                                        new SqlParameter("@BookingType",this.BookingType),
                                                                                        new SqlParameter("@CreatedBy", this.CreatedBy));                                                    
                        break;
                    case blossom.InsertPassengerDetails:
                        _objDataLayer.fnExecuteStoredProcedure("sp_CarProvisional", new SqlParameter("@Query", "Insert"),
                                                                                        new SqlParameter("@TravelDate", this.TravelDate),
                                                                                        new SqlParameter("@CarDetailsId", this.CarDetailsId),
                                                                                        new SqlParameter("@Name", this.Name),
                                                                                        new SqlParameter("@Address", this.Address),
                                                                                        new SqlParameter("@City", this.City),
                                                                                        new SqlParameter("@State", this.State),
                                                                                        new SqlParameter("@ZipCode", this.ZipCode),
                                                                                        new SqlParameter("@Country", this.Country),
                                                                                        new SqlParameter("@EmailId", this.EmailId),
                                                                                        new SqlParameter("@MobileNo", this.MobileNo),
                                                                                        new SqlParameter("@LandMark", this.LandMark),
                                                                                        new SqlParameter("@Status",this.Status),
                                                                                        new SqlParameter("@PickupTime", this.PickUpTime),
                                                                                         new SqlParameter("@CarName", this.CarName),
                                                                                         new SqlParameter("@BasicFare", this.Basicfare),
                                                                                         new SqlParameter("@AgentId", this.AgentId),
                                                                                         new SqlParameter("@AgentName", this.AgentName),
                                                                                         new SqlParameter("@Role", this.Role),
                                                                                           new SqlParameter("@TotalFare",this.TotalFare),

                                                                                        new SqlParameter("@ReferanceId",this.ReferanceId),
                                                                                        new SqlParameter("@CreatedBy", this.CreatedBy));
                        break;

                }
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }

        }

        public bool fnUpdateRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();


                switch (this.ScreenInd)
                {
                    case blossom.UpdateEmployee:
                        _objDataLayer.fnExecuteStoredProcedure("SP_Employee", new SqlParameter("@Query", "Update"),
                                                                               new SqlParameter("@EmpId", this.EmpId),
                                                                               new SqlParameter("@EmpName", this.EmpName),
                                                                               new SqlParameter("@phoneNo", this.PhoneNo),
                                                                               new SqlParameter("@Email", this.Email),
                                                                               new SqlParameter("@Address", this.Address));
                     break;
                    case blossom.UpdateHotelPolicy:
                     _objDataLayer.fnExecuteStoredProcedure("SP_HotelPolicy", new SqlParameter("@Query", "Update"),
                                                                           new SqlParameter("@HotelId", this.HotelId),
                                                                           new SqlParameter("@Details", this.HotelDetails));
                     break;
                    case blossom.UpdateCab:
                        _objDataLayer.fnExecuteStoredProcedure("SP_Cab", new SqlParameter("@Query", "Update"),
                                                                         new SqlParameter("@CabId", this.CarId),
                                                                         new SqlParameter("@CabType", this.CabType),
                                                                         new SqlParameter("@Travels", this.Travels),
                                                                         new SqlParameter("@Price", this.Price),
                                                                         new SqlParameter("@City", this.City),
                                                                         new SqlParameter("@HiringFor", this.HiringFor));
                     break;
                    case blossom.UpdateCity:
                     _objDataLayer.fnExecuteStoredProcedure("SP_City", new SqlParameter("@Query", "Update"),
                                                                           new SqlParameter("@CityName", this.CityName),
                                                                           new SqlParameter("@CityId", this.CityId),
                                                                           new SqlParameter("@ModifiedBy", this.ModifiedBy));
                                                                          
                                                                           
                     break;
                    case blossom.UpdateCar:
                     _objDataLayer.fnExecuteStoredProcedure("SP_Car", new SqlParameter("@Query", "Update"),
                                                                          new SqlParameter("@CarName", this.CarName),
                                                                          new SqlParameter("@CarImagePath",this.carimagepath),
                                                                          new SqlParameter("@CarId", this.CarId),
                                                                          new SqlParameter("@ModifiedBy", this.ModifiedBy));
                                                                         
                     break;
                    case blossom.UpdateCarDetailsForCity:
                     _objDataLayer.fnExecuteStoredProcedure("SP_CarDetailsForCity", new SqlParameter("@Query", "Update"),
                                                                                    new SqlParameter("@CityId", this.CityId),
                                                                                    new SqlParameter("@CarId", this.CarId),
                                                                                    new SqlParameter("@BasicPrice", this.BasicPrice),
                                                                                    new SqlParameter("@ExtarHours", this.ExtarHours),
                                                                                    new SqlParameter("@ExtarKilometers", this.ExtarKilometers),
                                                                                    new SqlParameter("@Usage", this.usage),
                                                                                    new SqlParameter("@Capacity", this.Limit),
                                                                                       new SqlParameter("@CarDetailsId", this.CarDetailsId),

                                                                                    new SqlParameter("@ModifiedBy", this.ModifiedBy));
                     break; 
                }
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }

        }

        public DataSet fnGetData()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] _params = new SqlParameter[0];

                switch (this.ScreenInd)
                {

                    case blossom.GetCabDetails:
                        return _objDataLayer.fnExecuteDataset("SP_PassengerDetails", new SqlParameter("@Query", "SelectAll"),
                                                                               new SqlParameter("@ReferanceId", this.ReferanceId));
                      
                    case blossom.SelectEmployee:
                        return _objDataLayer.fnExecuteDataset("SP_Employee", new SqlParameter("@Query", "Select"),
                                                                            new SqlParameter("@EmpId", this.EmpId));
                 

                    case blossom.AllSelectRecord:
                        return _objDataLayer.fnExecuteDataset("SP_Employee", new SqlParameter("@Query", "AllSelect"));
                

                    case blossom.SelectHotelPolicy:
                        return _objDataLayer.fnExecuteDataset("SP_HotelPolicy", new SqlParameter("@Query", "Select"));
                 
                    case blossom.SelectCab:
                        return _objDataLayer.fnExecuteDataset("SP_Cab", new SqlParameter("@Query", "Select"),
                                                                                new SqlParameter("@CabId", this.CarId));
                   
                    case blossom.SelectAllCab:
                        return _objDataLayer.fnExecuteDataset("SP_Cab", new SqlParameter("@Query", "AllSelect"));
                
                    case blossom.SelectCityName:
                        return _objDataLayer.fnExecuteDataset("SP_City", new SqlParameter("@Query", "Select"));
                 
                    case blossom.SelectAllCitys:
                        return _objDataLayer.fnExecuteDataset("SP_City", new SqlParameter("@Query", "SelectALL"));
           
                    case blossom.SelectCar:
                        return _objDataLayer.fnExecuteDataset("SP_Car", new SqlParameter("@Query", "Select"));                                                 
            
                    case blossom.SelectAllCars:
                        return _objDataLayer.fnExecuteDataset("SP_Car", new SqlParameter("@Query", "AllSelect"));
            
                    case blossom.SelectCarDetails:
                        return _objDataLayer.fnExecuteDataset("SP_CarDetailsForCity", new SqlParameter("@Query", "Select"),
                                                                         new SqlParameter("@CabId", this.CarId));
            
                    case blossom.SelectAllCarDetailsForCity:
                        return _objDataLayer.fnExecuteDataset("SP_CarDetailsForCity", new SqlParameter("@Query", "SelectAll"));
              
                    case blossom.SelectCarResult:
                        return _objDataLayer.fnExecuteDataset("SP_CarDetailsForCity", new SqlParameter("@Query", "CarResult"),
                                                                                      new SqlParameter("@CityId", this.CityId));
            
                    case blossom.SelectPsgDtls:
                        return _objDataLayer.fnExecuteDataset("SP_PassengerDetails", new SqlParameter("@Query", "SelectAll"));                                                             
            
                    case blossom.SelectGetMailDetails:
                        return _objDataLayer.fnExecuteDataset("SP_PassengerDetails", new SqlParameter("@Query", "GetMailDetails"),
                                                                                     new SqlParameter("@ReferanceId",this.ReferanceId));
                    case blossom.GetCarTicketDetais:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "GetCarProvisonal"));

                    case blossom.GetAgentTicketDetaisl:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "GetAgentBookings"));

                    case blossom.GetUserTicketDetaisl:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "GetUserBookings"));
                    case blossom.GetGuestTicketDetail:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "GetGuestBookings"));

                    case blossom.GetIndividualAgentTicketDetaisl:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "Individual Agent Bookings"),
                                                                                      new SqlParameter("@Role", this.Role),
                                                                                      new SqlParameter("@AgentId", this.AgentId));

                    case blossom.GetCancellationdetails:
                        return _objDataLayer.fnExecuteDataset("sp_CarProvisional", new SqlParameter("@Query", "Cancellation"),
                                                                                      new SqlParameter("@ReferenceId", this.ReferanceId),
                                                                                      new SqlParameter("@EmailId", this.EmailId));



                    case blossom.CarDetails:
                        return _objDataLayer.fnExecuteDataset("SP_CarDetailsForCity", new SqlParameter("@Query", "CarDetails"),
                                                                                     new SqlParameter("@CarDetailsId", this.CarDetailsId));

                }
                return null;
            }

            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return null;
            }

        }

        public bool fnDeleteRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                

                switch (this.ScreenInd)
                {
                    case blossom.DelectEmployee:
                        return _objDataLayer.fnExecuteStoredProcedure("SP_Employee", new SqlParameter("@Query", "Delete"),
                                                                            new SqlParameter("@EmpId", this.EmpId));
                        break;
                    case blossom.DeleteCab:
                        return _objDataLayer.fnExecuteStoredProcedure("SP_Cab", new SqlParameter("@Query", "Delete"),
                                                                            new SqlParameter("@CabId", this.CabId));
                        break;
                    case blossom.DeleteCity:
                        return _objDataLayer.fnExecuteStoredProcedure("SP_City", new SqlParameter("@Query", "Delete"),
                                                                            new SqlParameter("@CityId", this.CityId));
                        break;
                    case blossom.DeleteCar:
                        return _objDataLayer.fnExecuteStoredProcedure("SP_Car", new SqlParameter("@Query", "Delete"),
                                                                            new SqlParameter("@CarId", this.CarId));
                        break;
                    case blossom.DeleteCarDetailsForCity:
                        return _objDataLayer.fnExecuteStoredProcedure("SP_CarDetailsForCity", new SqlParameter("@Query", "Delete"),
                                                                            new SqlParameter("@CarDetailsId", this.CarDetailsId));
                        break;
                }
                return true;
            }

            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }

        }
           
    }
   
}
