using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BAL
{
    #region Enum

    public enum Master123
    {
        InsertAdminMarkup, GetAdminMarkup, InsertAgentMarkUp, Remainders, GetRemainder, InsertNotices, UpdateNotices, GetNotices, UpdateRemainder, GetMarkup,DeleteNotices,UpdateMarkup,DeleteMarkup,DeleteRemainders,GetType,GetNationalFlights,GetInterNationalFlights,InsertMarkup,UpdateMarkUp,DeleteMarkUp,GetCheckBalance,GetAgentMarkup,UpdateAgentMarkUp,DeleteAgentMarkup,
        InsertAdminNotice, UpdateAdminNotice, DeleteAdminNotice, GetAdminNotice, InsertAdminRemainder, UpdateAdminRemainder, GetAdminRemainder, DeleteAdminRemainder, GetDashBoard, GetDynamicGraph, DeleteAdminMarkUp, UpdateAdminMarkUp, InsertRole, UpdateRole, DeleteRole, GetRole, InsertPomocode, UpdatePromocode, DeletePromocode, GetPromocode, InsertCashCoupon, UpdateCashCoupon, DeleteCashCoupon, GetCashCoupon, AddAgentMarkup, GetAgentMarkup1,GetHotel,GetBus,GetInterNationalFlight,
        UpdateBus,UpdateHotel,UpdateFlight,
        SpiceJet, KingFisher, AirIndiaExpress, GoAir, AirIndia, Indigo, JetAirways, UpdateBusMark, GetBusMark, InsertBusMarkup, GetAllMark1, GetAllMark2, InsertNewMarkup,gettopmarkup,InsertHotelPolicy,GetHotelPolicy,UpdateHotelPolicy,DeleteHotelPolicy,InsertCarPolicy,GetCarPolicy,UpdateCarPolicy,DeleteCarPolicy


    }



    #endregion
    public class Class1
    {
        #region Global Variables
        DataSet ObjDataset;
        bool b;
        private clsDataLayer _objDataLayer;
        private string _strDescription;
        private string _strIndicator;

        #endregion
        #region Properties

        public string Indicator
        {
            get
            {
                return _strIndicator;
            }
            set
            {
                _strIndicator = value;
            }
        }


        public string Description
        {
            get
            {
                return _strDescription;
            }
            set
            {
                _strDescription = value;
            }
        }

        public Master123 ScreenInd { get; set; }
        public string Percentage { get; set; }
        public string Type { get; set; }
        public string AddSubtract { get; set; }
        public int id { get; set; }
        public int Agentid { get; set; }
        public string Description1 { get; set; }
        public string Notices { get; set; }
        public int Createdby { get; set; }
        public int Modifyby { get; set; }
        public int Remainder { get; set; }
        public string MarkupAmount { get; set; }
        public string MarkupPercentage { get; set; }
        public string FlightName { get; set; }
        public string subType{get;set;}
        public string domesticflights{get;set;}
        public string internationalFlights { get; set; }
        public int Percentage1 { get; set; }
        public string AdminRemainder { get; set; }
        public string Role { get; set; }
        public string operatorName { get; set; }
        public string promocode { get; set; }
        public string Amount { get; set; }
        public string DaystoExpiry { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public string MobileNo { get; set; }
        public string Emailid { get; set; }

       

       
        



        #endregion
        #region Insert Record
        public bool fnInsertRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();


                switch (this.ScreenInd)
                {
                    case Master123.InsertAdminMarkup:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "Insert"),
                                                                               new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                               new SqlParameter("@Type", this.Type),
                                                                               new SqlParameter("@AddSubtract",this.AddSubtract),
                                                                               new SqlParameter("@Role",this.Role),
                                                                               new SqlParameter("@CreatedBy",this.id)

                   

                                                                 );
                     
                      

                        break;
                        
                    case Master123.InsertAgentMarkUp:
                     _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "Insert"),
                                                                                  new SqlParameter("@SubType",this.subType),
                                                                                  new SqlParameter("@MarkUpPercentage", this.Percentage1),
                                                                                  new SqlParameter("@MarkUpAmount",this.MarkupAmount),
                                                                                 
                                                                                 new SqlParameter("@FlightName",this.FlightName),
                                                                                  new SqlParameter("@Type", this.Type),
                                                                                  new SqlParameter("@Createdby", this.id),
                                                                                  new SqlParameter("@AgentId",this.Agentid) 


                                                                );
                        break;

                    case Master123.Remainders:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Remainder", new SqlParameter("@Query", "insert"),
                                                                              new SqlParameter("@Description", this.Description1),
                                                                              new SqlParameter("@Createdby", this.id)


                                                                );
                        break;


                    case Master123.InsertBusMarkup:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_DomesticFlights", new SqlParameter("@Query", "insert"),
                                                                              new SqlParameter("@Buses", this.MarkupAmount),
                                                                              new SqlParameter("@AgentId", this.id)


                                                                );
                        break;


                    case Master123.InsertNotices:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Notices", new SqlParameter("@Query", "insert"),
                                                                             new SqlParameter("@Notices", this.Notices),
                                                                              new SqlParameter("@Createdby", this.id)


                                                                );

                        break;

                    case Master123.InsertMarkup:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Markupmanagement",new SqlParameter("@Query","insert"),
                                                                                     new SqlParameter("@FlightsName",this.FlightName),
                                                                                     new SqlParameter("@MarkupAmount",this.MarkupAmount),
                                                                                     new SqlParameter("@MarkupPercentage",this.MarkupPercentage),
                                                                                     new SqlParameter("@Createdby",this.id)

                                                                );
                        break;

                    case Master123.InsertHotelPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_HotelPolicy", new SqlParameter("@Query", "insert"),
                                                                                     new SqlParameter("@HotelPolicy", this.AdminRemainder),
                                                                                     new SqlParameter("@Createdby", this.id)

                                                                );
                        break;

                    case Master123.InsertCarPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_CarPolicy", new SqlParameter("@Query", "insert"),
                                                                                     new SqlParameter("@CarPolicy", this.AdminRemainder),
                                                                                     new SqlParameter("@Createdby", this.id)

                                                                );
                        break;


                    case Master123.InsertAdminNotice:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminNotices", new SqlParameter("@Query", "Insert"),
                                                                                 new SqlParameter("@AdminNotice", this.Notices),
                                                                                 new SqlParameter("@Createdby ", this.id)

                                                                );

                        break;

                    case Master123.InsertAdminRemainder:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminRemainder", new SqlParameter("@Query", "insert"),
                                                                                   new SqlParameter("@Remainder", this.AdminRemainder),
                                                                                   new SqlParameter("@Createdby", this.id)

                                                                );
                        break;


                    case Master123.InsertRole:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_RoleMaster", new SqlParameter("@Query", "Insert"),
                                                                               new SqlParameter("@Role", this.Role),
                                                                               new SqlParameter("@Createdby", this.Createdby)

                                                                    );

                        break;

                    case Master123.InsertPomocode:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_PomocodeMaster",new SqlParameter("@Query", "insert"),
                                                                                   new SqlParameter("@Operator",this.operatorName),
                                                                                   new SqlParameter("@Promocode",this.promocode),
                                                                                   new SqlParameter("@Amount",this.Amount),
                                                                                   new SqlParameter("@DaystoExpiry",this.DaystoExpiry),
                                                                                   new SqlParameter("@MinValue", this.MinValue),
                                                                                   new SqlParameter("@MaxValue",this.MaxValue),
                                                                                   new SqlParameter("@Createdby",this.Createdby)
                                                                                  

                                                                );
                        break;


                    case Master123.InsertCashCoupon:

                         _objDataLayer.fnExecuteStoredProcedure("Sp_CashCoupon1",new SqlParameter("@Query", "insert"),
                                                                                   new SqlParameter("@Operator", this.operatorName),
                                                                                   new SqlParameter("@CashCoupon", this.promocode),
                                                                                   new SqlParameter("@Amount",this.Amount),
                                                                                   new SqlParameter("@DaystoExpiry",this.DaystoExpiry),
                                                                                   new SqlParameter("@MinValue", this.MinValue),
                                                                                   new SqlParameter("@MaxValue",this.MaxValue),
                                                                                   new SqlParameter("@EmailId",this.Emailid),
                                                                                   new SqlParameter("@MobileNo",this.MobileNo),
                                                                                   new SqlParameter("@Createdby",this.Createdby)
                                                                                   
                                                                );
                        break;





                    case Master123.InsertNewMarkup:

                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "insert"),
                                                                                  new SqlParameter("@SubType",this.subType),
                                                                                  new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                  new SqlParameter("@CreatedBy", this.Createdby),
                                                                                  new SqlParameter("@Type",this.Type)


                                                                   );
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
        #endregion
        #region Get Records
        public DataSet fnGetData()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] _params = new SqlParameter[0];
                switch (this.ScreenInd)
                {

                    case Master123.GetRemainder:
                        return _objDataLayer.fnExecuteDataset("Sp_Remainder", new SqlParameter("@Query", "Get")

                          );



                    case Master123.GetNotices:
                        return _objDataLayer.fnExecuteDataSet("Sp_Notices", new SqlParameter("@Query", "get")
                        );


                    case Master123.GetMarkup:
                        return _objDataLayer.fnExecuteDataSet("Sp_Markupmanagement", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetHotelPolicy:
                        return _objDataLayer.fnExecuteDataSet("Sp_HotelPolicy", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetCarPolicy:
                        return _objDataLayer.fnExecuteDataSet("Sp_CarPolicy", new SqlParameter("@Query", "Get")
                        );


                    case Master123.GetType:
                        return _objDataLayer.fnExecuteDataSet("Sp_Flights", new SqlParameter("@Query", "GetFlightsType")
                        );


                    case Master123.GetNationalFlights:
                        return _objDataLayer.fnExecuteDataSet("Sp_Flights", new SqlParameter("@Query", "GetDomesticFlights")
                        );

                    case Master123.GetInterNationalFlights:
                        return _objDataLayer.fnExecuteDataSet("Sp_Flights", new SqlParameter("@Query", "GetInternationalFlights")
                        );
                    case Master123.GetCheckBalance:
                        return _objDataLayer.fnExecuteDataSet("SP_AgentCheckBalance", new SqlParameter("@AgentId", this.id)
                        );

                    case Master123.GetAgentMarkup:
                        return _objDataLayer.fnExecuteDataset("sp_AgentMarkup1", new SqlParameter("@Query", "get"),
                                                                                  new SqlParameter("@AgentID", this.Agentid)
                        );
                    case Master123.gettopmarkup:
                        return _objDataLayer.fnExecuteDataset("sp_AgentMarkup1", new SqlParameter("@Query", "topmarkup"),
                                                                                  new SqlParameter("@AgentID", this.Agentid),
                                                                                   new SqlParameter("@Type", this.Type)
                        );
                    
                    case Master123.GetAgentMarkup1:
                        return _objDataLayer.fnExecuteDataset("sp_AgentMarkup1", new SqlParameter("@Query", "getMark")
                        );



                    case Master123.GetAdminNotice:
                        return _objDataLayer.fnExecuteDataSet("Sp_AdminNotices", new SqlParameter("@Query", "Get")
                        );


                    case Master123.GetAdminRemainder:
                        return _objDataLayer.fnExecuteDataset("Sp_AdminRemainder", new SqlParameter("@Query", "get")
                        );

                    case Master123.GetDashBoard:
                        return _objDataLayer.fnExecuteDataSet("Sp_DashBoard", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetDynamicGraph:
                        return _objDataLayer.fnExecuteDataset("Sp_DynamicGraph", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetAdminMarkup:
                        return _objDataLayer.fnExecuteDataset("sp_AgentMarkup1", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetRole:
                        return _objDataLayer.fnExecuteDataSet("Sp_RoleMaster", new SqlParameter("@Query", "Get")
                        );

                    case Master123.GetPromocode:
                        return _objDataLayer.fnExecuteDataSet("Sp_PomocodeMaster", new SqlParameter("@Query", "get")
                        );

                    case Master123.GetCashCoupon:

                        return _objDataLayer.fnExecuteDataSet("Sp_CashCoupon1", new SqlParameter("@Query", "get")
                       );

                    case Master123.GetHotel:

                        return _objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", new SqlParameter("@Query", "getHotel"),
                                                                                 new SqlParameter("@Type","Hotel")
                       );
                    case Master123.GetBus:

                        return _objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", new SqlParameter("@Query", "getBus")
                       );

                    case Master123.GetInterNationalFlight:

                        return _objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", new SqlParameter("@Query", "getFlights")
                       );

                    case Master123.GetBusMark:
                        return _objDataLayer.fnExecuteDataSet("Sp_DomesticFlights", new SqlParameter("@Query", "Get"),
                                                                                    new SqlParameter("@AgentId",this.id)
                      );
                    case Master123.GetAllMark1:
                        return _objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", new SqlParameter("@Query", "getstaticmarkups")                                                                                   
                      );

                    case Master123.GetAllMark2:
                        return _objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", new SqlParameter("@Query", "getmarkupsbyagentwise"),
                                                                                 new SqlParameter("@AgentId", this.Agentid), 
                                                                                 new SqlParameter("@Type", this.Type)
                      );
                }
                return null;
            }
            catch (Exception ex)
            {
                ////Logger.Log(Logger.LogType.Log_In_DB, ex, true);"
                return null;
            }
        }

        #endregion
        #region Update Record

        public bool fnUpdateRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();

                switch (this.ScreenInd)
                {


                    case Master123.UpdateNotices:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Notices", new SqlParameter("@Query", "update"),
                                                                             new SqlParameter("@Notices", this.Notices),
                                                                             new SqlParameter("@Modifyby", this.Modifyby),
                                                                             new SqlParameter("@NId", this.id)
                                                                                  );


                        break;

                    case Master123.UpdateRemainder:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Remainder", new SqlParameter("@Description", this.Description1),
                                                                               new SqlParameter("@Rid",this.id),
                                                                               new SqlParameter("@Modifyby",this.Modifyby),
                                                                               new SqlParameter("@Query", "update"));
                              

                        break;


                    case Master123.UpdateMarkUp:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Markupmanagement", new SqlParameter("@Query", "Update"),
                                                                                     new SqlParameter("@Mid", this.id),
                                                                                     new SqlParameter("@FlightsName", this.FlightName),
                                                                                     new SqlParameter("@MarkupAmount", this.MarkupAmount),
                                                                                     new SqlParameter("@MarkupPercentage", this.MarkupPercentage),
                                                                                     new SqlParameter("@Modifyby", this.Modifyby));


                        break;



                    case Master123.UpdateAgentMarkUp:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "update"),
                                                                                  new SqlParameter("@SubType", this.subType),
                                                                                  new SqlParameter("@MarkUpPercentage", this.Percentage1),
                                                                                  new SqlParameter("@MarkUpAmount", this.MarkupAmount),

                                                                                 new SqlParameter("@FlightName", this.FlightName),
                                                                                  new SqlParameter("@Type", this.Type),
                                                                                  new SqlParameter("@ModifiedBy", this.Modifyby),
                                                                                  new SqlParameter("@Id",this.id),
                                                                                  new SqlParameter("@AgentId", this.Agentid));


                        break; 


                    case Master123.UpdateAdminNotice:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminNotices", new SqlParameter("@Query", "Update"),
                                                                                  new SqlParameter("@ANid", this.id),
                                                                                  new SqlParameter("@AdminNotice", this.Notices),
                                                                                  new SqlParameter("@ModifyBy", this.Modifyby));


                        break;

                    case Master123.UpdateAdminRemainder:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminRemainder", new SqlParameter("@Query", "update"),
                                                                                   new SqlParameter("@ARid", this.id),
                                                                                   new SqlParameter("@Remainder", this.AdminRemainder),
                                                                                   new SqlParameter("@Modifyby", this.Modifyby));



                        break;


                    case Master123.UpdateHotelPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_HotelPolicy", new SqlParameter("@Query", "Update"),
                                                                                   new SqlParameter("@Id", this.id),
                                                                                   new SqlParameter("@HotelPolicy", this.AdminRemainder),
                                                                                   new SqlParameter("@Modifyby", this.Modifyby));



                        break;

                    case Master123.UpdateCarPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_CarPolicy", new SqlParameter("@Query", "Update"),
                                                                                   new SqlParameter("@Id", this.id),
                                                                                   new SqlParameter("@CarPolicy", this.AdminRemainder),
                                                                                   new SqlParameter("@Modifyby", this.Modifyby));



                        break;


                    case Master123.UpdateAdminMarkUp:
                        _objDataLayer.fnExecuteStoredProcedure("sp_Adminmarkup", new SqlParameter("@Query", "update"),
                                                                                new SqlParameter("@Id", this.id),
                                                                                new SqlParameter("@MarkUpPrice", this.MarkupAmount),
                                                                                //new SqlParameter("@Type", this.Type),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;



                    case Master123.UpdateBus:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "updateBus"),
                                                                               // new SqlParameter("@Id", this.id),
                                                                                new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;



                    case Master123.UpdateBusMark:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_DomesticFlights", new SqlParameter("@Query", "Insert"),
                            // new SqlParameter("@Id", this.id),
                                                                                new SqlParameter("@Buses", this.MarkupAmount),
                                                                                new SqlParameter("@AgentId ", this.id)
                                                                               
                                                                                );




                        break;







                    case Master123.UpdateHotel:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "updateHotel"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;




                    case Master123.UpdateFlight:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "updateFlight"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;


                    case Master123.SpiceJet:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "updatedomesticflight"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),                                                                                 
                                                                                   new SqlParameter("@SubType", this.subType),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;

                    case Master123.KingFisher:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "updateKingFisher"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;


                    case Master123.AirIndiaExpress:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "UpdateAirIndia"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;


                    case Master123.GoAir:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "GoAir"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;

                    case Master123.AirIndia:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "AirIndia"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;

                    case Master123.Indigo:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "Indigo"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;


                    case Master123.JetAirways:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1", new SqlParameter("@Query", "JetAirways"),
                                                                                 new SqlParameter("@MarkUpAmount", this.MarkupAmount),
                                                                                new SqlParameter("@ModifiedBy ", this.Modifyby));




                        break;












                    case Master123.UpdateRole:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_RoleMaster", new SqlParameter("@Query", "Update"),
                                                                               new SqlParameter("@ID", this.id),
                                                                               new SqlParameter("@Role", this.Role),
                                                                               new SqlParameter("@ModifiedBy", this.Modifyby));



                        break;


                    case Master123.UpdateCashCoupon:


                        _objDataLayer.fnExecuteStoredProcedure("Sp_CashCoupon1", new SqlParameter("@Query", "update"),
                                                                             new SqlParameter("@Operator", this.operatorName),
                                                                                   new SqlParameter("@CashCoupon", this.promocode),
                                                                                   new SqlParameter("@Amount", this.Amount),
                                                                                   new SqlParameter("@DaystoExpiry", this.DaystoExpiry),
                                                                                   new SqlParameter("@MinValue", this.MinValue),
                                                                                   new SqlParameter("@MaxValue", this.MaxValue),
                                                                                   new SqlParameter("@EmailId", this.Emailid),
                                                                                   new SqlParameter("@MobileNo", this.MobileNo),
                                                                                   new SqlParameter("@Modifyby ", this.Modifyby));




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
        #endregion

        #region Delete Record
        public bool fnDeleteRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();

                switch (this.ScreenInd)
                {
                    case  Master123.DeleteNotices:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Notices", new SqlParameter("@Query", "Delete"),
                                                                                  new SqlParameter("@Nid", this.id));



                        break;


                    case Master123.DeleteRemainders:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Remainder", new SqlParameter("@Query", "delete"),
                                                                              new SqlParameter("@Rid", this.id));
                        break;

                    case Master123.DeleteMarkup:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_Markupmanagement", new SqlParameter("@Query", "Delete"),
                                                                                     new SqlParameter("@Mid", this.id));


                        break;



                    case Master123.DeleteAgentMarkup:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentMarkup1",new SqlParameter("@Query","delete"),
                                                                                 new SqlParameter("@Id",this.id));
                        break;

                    case Master123.DeleteAdminNotice:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminNotices", new SqlParameter("@Query", "Delete"),
                                                                                 new SqlParameter("@ANid", this.id));
                        break;

                    case Master123.DeleteAdminRemainder:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_AdminRemainder", new SqlParameter("@Query", "delete"),
                                                                                   new SqlParameter("@ARid", this.id));
                        break;


                    case Master123.DeleteHotelPolicy:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_HotelPolicy", new SqlParameter("@Query", "delete"),
                                                                                   new SqlParameter("@id", this.id));
                        break;

                    case Master123.DeleteAdminMarkUp:
                        _objDataLayer.fnExecuteStoredProcedure("sp_Adminmarkup", new SqlParameter("@Query", "Delete"),
                                                                                new SqlParameter("@Id", this.id));
                        break;


                    case Master123.DeleteRole:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_RoleMaster", new SqlParameter("@Query", "Delete"),

                                                                              new SqlParameter("@Id", this.id));
                        break;


                    case Master123.DeletePromocode:
                        _objDataLayer.fnExecuteStoredProcedure("Sp_PomocodeMaster",new SqlParameter("@Query","delete"),
                                                                                   new SqlParameter("@Pid",this.id));
                        break;


                    case Master123.DeleteCashCoupon:

                        _objDataLayer.fnExecuteStoredProcedure("Sp_CashCoupon1", new SqlParameter("@Query", "delete"),
                                                                                   new SqlParameter("@Cid",this.id));
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
          #endregion





        # region AgentMarkUp
        public string AddMarkup()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[9];

                p[0] = new SqlParameter("@Type",this.Type );
                p[1] = new SqlParameter("@SubType", this.subType);

                p[2] = new SqlParameter("@MarkUpAmount", this.MarkupAmount);
                p[3] = new SqlParameter("@AgentId", this.id);

                p[4] = new SqlParameter("@CreatedBy", this.id);
                p[5] = new SqlParameter("@Query", "Insert");
                p[6] = new SqlParameter("@AddSubtract", this.AddSubtract);
                p[7] = new SqlParameter("@Role", this.Role);
                p[8] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
                p[8].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)_objDataLayer.fnExecuteDataSet("sp_AgentMarkup1", p);
              
             
               return Convert.ToString(p[8].Value.ToString());
                //return ObjDataset;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        # region AdminMarkUp
        public string AddAgentMarkup()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[5];

                p[0] = new SqlParameter("@Type", this.Type);
                p[1] = new SqlParameter("@MarkUpAmount", this.MarkupAmount);
                p[2] = new SqlParameter("@CreatedBy", this.id);
                p[3] = new SqlParameter("@Query", "Insert");
                p[4] = new SqlParameter("@Message", SqlDbType.NVarChar, 4000);
                p[4].Direction = ParameterDirection.Output;
                ObjDataset = (DataSet)_objDataLayer.fnExecuteDataSet("sp_Adminmarkup", p);
                return Convert.ToString(p[4].Value.ToString());
                //return ObjDataset;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        

        

    }
}
