using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

using System.Web.UI.WebControls;


namespace BAL
{ 
    #region Enum

    public enum Masters
    {
        MobileID, Country, State, State1, CityType, City, UserMst, UserID, State_CountryCode, ImageUpload, Adv_Images, Advertisement, citilist,
        City_StateCode, UserName, CityGrid, GetUserName, Gain, Gain1, Mobile, GainMobile, Password, Commission, GetAdvertisement, LogError, D2H,
        service, SubServices, GetMobileDetails, getmobrechargebyID, GetMRByUserID, GetMRDBySearch, GetD2HBySearch, GetMRByID,
        GetMRDByAdminSearch, GetMRDByServiceSearch, GetD2Hdetails, GetImage, GetTarrif, InsertTarrif, MobileNumCheck,
        Mobilenew, paymentdetails, Operators, GetDTH, operatorsname, operatorsname1, EWallet, GetInfo, GetInfo1, bindUsers, Upstatus, DashBoardUser, Identify,
        Getreqdtls,GetData,  operatorsname2, Coupon,getticket,getimages,Dmr,
        bindIp,
        GetDataCardDetails,
        GetUserReqd,
        Guestreport,
        Guestreport1,
        Guestreport2,
        UserReport,
        UserReport1,
        UserReport2,
        GetTopRechargersofDTH,
        GetTopRechargersofDataCard,
        Getreqdtls1,
        UPMyprofile,
        gettime,
        D2Hnew,
        Failurereport,
        Failurereport1,
        Failurereport2,
        getrecharge,
        getrecharge1,
        getrechargeD2H,
        getrecharge2,
        DataCardnew,
        DataCard,
        getrecharge3,
        gettimeforusers,
        Identify1,
        getrechargeforusers,getadds,
        deduct, updateOfferContent, bindcontent, Insertcontent, gettopcontent, VisitorsReport, VisitorsReportd2h, VisitorsReportDatacard, Agentregistration, AgentName,
        GetRequests, getRequestID, UpdateStatus, GetAgentApprovedList, GetAmount, getbalance, UpdateBalance, AddAgentAmount, UpdateAdjustBalance, getbalanceAgent, GetAgentProfile,
        UPAgentprofile, AgentPassword, deductagentbalance, getrechargeD2Hagent, getagentrecharge2, getagentDatacardrecharge, getGuestrecharge1, getguestDatacardrecharge,
        UpdateGuestrecharge3, getadmintotalbalance, UpdateAdminonlyBalance, AgentForgotpwd, AgentReport, AgentReportBYID, AgentReportBYIDDatacard, AgentReportBYIDDTH,
        AgentReportdth, AgentReportDatacard, deductadminbalance, getoperators, ListOfAmounts, GetNetworkName, GetRechargeAmount, AgentCommission, GetCommisionByNetwork, GetAgentOnly,
        GetAdminReports, DailyReports, Ewalletbyrequestid, getewalletusers, addewalletamounttouser, adjustewalletamounttouser, AddAmounttoUsersRechargeFailed, GetDistributorsList,
        Distributorswisereports, getdisCommission, GetAdminCommission, loginDetails, GetFlights, GetFlights1, GetAgentAllReports, GetOpeartorByMobileSeries, Getservices, postpaid, landline
    }



    #endregion

    public class clsMasters
    {
        #region Global Variables
        private clsDataLayer _objDataLayer;
        private string _strDescription;
        private string _strIndicator;

        #endregion

        #region Properties

        public decimal ExtraCharges { get; set; }
        public string Date { get; set; }
        public string Accountholdername { get; set; }
        public string Accountnumber { get; set; }

        public string IFSCCode { get; set; }
        public string BankName { get; set; }

        public string BranchName { get; set; }
        public string SenderName { get; set; }
        public string MobileNumber { get; set; }
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

        public Masters ScreenInd { get; set; }
        public string IP { get; set; }
        public string Parameter { get; set; }
        public string Coupon { get; set; }
        public Decimal Discount { get; set; }
        public int OperatorsID { get; set; }
        public int Denomination { get; set; }
        public decimal TalkTime { get; set; }
        public string Validity { get; set; }
        public int RefID { get; set; }
        public int CityType { get; set; }
        public int CategoryID { get; set; }
        public int ServiceID { get; set; }

        public string Type { get; set; }

        public int ID { get; set; }
        public int Commission { get; set; }
        public int TDR { get; set; }
        public int ServiceTax { get; set; }
        public int CancelTicket { get; set; }
        public int TotalComm { get; set; }
        public int CancelTtalComm { get; set; }

        public string UCode { get; set; }
        public double Amount { get; set; }

        public string strUserInd { get; set; }
        public string strUserName { get; set; }
        public string strPassword { get; set; }
        public string strUserType { get; set; }
        public int intVBalance { get; set; }
        public int intActive { get; set; }


        public string EmailID { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int VBalance { get; set; }
        public int Active { get; set; }
        public string NetworkName { get; set; }
        public string OperatorKeyword { get; set; }
        public string OperatorType { get; set; }

        public int UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Fax { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string CountryName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string UT1 { get; set; }
        public DateTime From12 { get; set; }
        public DateTime To12 { get; set; }

        public string Company_Name { get; set; }
        public string Sub_Service { get; set; }
        public int ServiceCode { get; set; }
        public string Product_Type { get; set; }
        public int CompanyCode { get; set; }
        public string Model_Type { get; set; }
        public int ProductCode { get; set; }
        public int CategoryCode { get; set; }
        public int Company { get; set; }
        public int ModelCode { get; set; }
        public string Product { get; set; }
        public int Model { get; set; }
        public string Segment { get; set; }
        public string Segment_Cat { get; set; }
        public string Specification { get; set; }
        public double MRP { get; set; }
        public double Tirupathi_Price { get; set; }
        public double SPE_Price { get; set; }
        public string Request { get; set; }
        public string Name { get; set; }
        public string Mobile_Num { get; set; }
        public string Customer_ID { get; set; }
        public string E_Mail { get; set; }
        public string Payment { get; set; }
        public double Commission1 { get; set; }
        public string Provider_Name { get; set; }
        public string RequestID { get; set; }
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public string MethodName { get; set; }
        public DateTime Time { get; set; }
        public string Exception { get; set; }
        public string ScreenName { get; set; }
        public string ImageName { get; set; }
        public Image Image { get; set; }
        public string Advertisement { get; set; }
        public int imgID { get; set; }

        public string MerchantID { get; set; }
        public int SubscriberID { get; set; }
        public string TrxReferenceNo { get; set; }
        public string BankReferenceNo { get; set; }
        public string TxnAmount { get; set; }
        public string BankID { get; set; }
        public string BankMerchantID { get; set; }
        public string TCNTYpe { get; set; }
        public string CurrencyName { get; set; }
        public string ItemCode { get; set; }
        public string SecurityType { get; set; }
        public string SecurityID { get; set; }
        public string SecurityPassword { get; set; }
        public string TxnDate { get; set; }
        public string AuthStatus { get; set; }
        public string SettlementType { get; set; }
        public string AdditionalInfo1 { get; set; }
        public string AdditionalInfo2 { get; set; }
        public string AdditionalInfo3 { get; set; }
        public string AdditionalInfo4 { get; set; }
        public string AdditionalInfo5 { get; set; }
        public string AdditionalInfo6 { get; set; }
        public string AdditionalInfo7 { get; set; }
        public string ErrorStatus { get; set; }
        public string ErrorDescription { get; set; }
        public string CheckSum { get; set; }
        public string MobileNum { get; set; }
        public decimal Amount1 { get; set; }
        public string Description1 { get; set; }
        public string Statename { get; set; }
        public string cityname { get; set; }
        public decimal amountewallet { get; set; }

        public string Content { get; set; }
        public decimal A_Amount { get; set; }

        public decimal AgentCommission { get; set; }

        public string PostalCode { get; set; }
        public int DistributorID { get; set; }
        public int TypeOftransactionId { get; set; }

        #endregion

      

        #region Insert Record
        public bool fnInsertRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                //Parameters = {new SqlParameter("","");new SqlParameter("","");}

                switch (this.ScreenInd)
                {
                    case Masters.Dmr:
                        _objDataLayer.fnExecuteStoredProcedure("sp_dmr", new SqlParameter("@TableName", "Insertdmr"),
                                                                                   new SqlParameter("@Amount", this.Amount1),
                                                                                   new SqlParameter("@Date", this.Date),
                                                                                   new SqlParameter("@Accountholdername", this.Accountholdername),
                                                                                   new SqlParameter("@Accountnumber", this.Accountnumber),
                                                                                   new SqlParameter("@IFSCCode", this.IFSCCode),
                                                                                  new SqlParameter("@BankName", this.BankName),
                                                                                  new SqlParameter("@BranchName", this.BranchName),
                                                                                   new SqlParameter("@SenderName", this.SenderName),
                                                                                   new SqlParameter("@MobileNumber", this.MobileNumber),
                                                                                     new SqlParameter("@Status", this.Status),
                                                                                       new SqlParameter("@Createdby", this.CreatedBy),
                                                                                       new SqlParameter("@Extracharges", this.ExtraCharges),
                                                                                        new SqlParameter("@AgentId", this.ID)
                                                                                   );
                        break;


                    case Masters.loginDetails:
                        _objDataLayer.fnExecuteStoredProcedure("sp_LoginDetails", new SqlParameter("@TableName", "insertlogindetails"),
                                                                                   new SqlParameter("@UserID", this.UserID));
                                                                               
                                                                                    
                        break;
                    case Masters.AgentCommission:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentCommission", new SqlParameter("@TableName", "InsertCommission"),
                                                                                   new SqlParameter("@NetworkName", this.NetworkName),
                                                                                    new SqlParameter("@OperatorType", this.OperatorType),
                                                                                     new SqlParameter("@ID", this.DistributorID),
                                                                                    new SqlParameter("@Type",this.Type),
                                                                                     new SqlParameter("@AgentCommission", this.AgentCommission));
                                                                                   
                        break;


                    case Masters.ListOfAmounts:
                        _objDataLayer.fnExecuteStoredProcedure("sp_ListOfAmounts", new SqlParameter("@TableName", "InsertListOfAmount"),
                                                                                   new SqlParameter("@NetworkName", this.NetworkName),
                                                                                    new SqlParameter("@OperatorType", this.OperatorType),
                                                                                     new SqlParameter("@RechargeAmount", this.A_Amount),
                                                                                     new SqlParameter("@TalkTime", this.TalkTime));
                        break;


                    case Masters.AddAgentAmount:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AddAgentAmount",
                                                                                   new SqlParameter("@UserID", this.UserID),
                            // new SqlParameter("@AgentName",this.Agentname),
                                                                                     new SqlParameter("@Amount", this.A_Amount),
                                                                                     new SqlParameter("@Description", this.Description),
                                                                                     new SqlParameter("@CreatedBy", this.CreatedBy));
                        break;
                    case Masters.Agentregistration:
                        _objDataLayer.fnExecuteStoredProcedure("spAgentMst",
                                                   new SqlParameter("@UserID", this.UserID),
                                                   new SqlParameter("@EmailID", this.EmailID),
                                                   new SqlParameter("@Password", this.Password),
                                                   new SqlParameter("@Title", this.Title),
                                                   new SqlParameter("@FirstName", this.FirstName),
                                                   new SqlParameter("@LastName", this.LastName),
                                                   new SqlParameter("@Mobile", this.Mobile),
                                                   new SqlParameter("@DOB", this.DOB),
                                                   new SqlParameter("@Address", this.Address),
                            // new SqlParameter("@A_Amount",this.A_Amount),
                                                   new SqlParameter("@Pincode", this.Pincode),
                                                   new SqlParameter("@Landline", this.Landline),
                                                   new SqlParameter("@Fax", this.Fax),
                                                   new SqlParameter("@Country", this.CountryName),
                                                   new SqlParameter("@State", this.Statename),
                                                   new SqlParameter("@City", this.cityname),
                                                   new SqlParameter("@UserType",this.UserType),
                                                    new SqlParameter("@Status", this.Status),
                                                    new SqlParameter("@DistributorID", this.DistributorID)
                                                   );

                        break;
                    case Masters.Insertcontent:
                        _objDataLayer.fnExecuteStoredProcedure("sp_updateofferContent", new SqlParameter("@TableName", "InsertContent"),                                                                                       
                                                                                        new SqlParameter("@Content", this.Content),
                                                                                          new SqlParameter("@ImagePath", this.ImageName));
                        break;
                    case Masters.Country:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbCountryMst"),
                                                                            new SqlParameter("@Description", this.Description));
                        break;
                    case Masters.State:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbStateMst"),
                                                                            new SqlParameter("@Description", this.Description),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;

                    case Masters.CityType:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbCityTypeMst"),
                                                                            new SqlParameter("@Description", this.Description));
                        break;
                    case Masters.City:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbCityMst"),
                                                                            new SqlParameter("@Description", this.Description),
                                                                            new SqlParameter("@RefID", this.RefID),
                                                                            new SqlParameter("@CTTCode", this.CityType));
                        break;

                    case Masters.UserMst: _objDataLayer.fnExecuteStoredProcedure("spUserMst",
                                                   new SqlParameter("@UserID", this.UserID),
                                                   new SqlParameter("@EmailID", this.EmailID),
                                                   new SqlParameter("@Password", this.Password),
                                                   new SqlParameter("@MobileNumber", this.Mobile_Num),
                                                   new SqlParameter("@State", this.Statename),
                                                   new SqlParameter("@City", this.cityname),
                                                   new SqlParameter("@FirstName", this.FirstName),
                                                   new SqlParameter("@PostalCode", this.PostalCode),
                                                    new SqlParameter("@Country", this.CountryName),
                                                   new SqlParameter("@Address", this.Address)
                                                   );


                        break;

                    case Masters.Mobile:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbMobile"),
                                                                                      new SqlParameter("@MobileNo", this.Mobile_Num),
                                                                                      new SqlParameter("@RefID", this.UserID),
                                                                                      new SqlParameter("@Type",this.Type),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                      new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy),
                                                                                      new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                      new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                      );
                        break;


                    case Masters.Mobilenew:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbMobilefornonREG"),
                                                                                      new SqlParameter("@MobileNo", this.Mobile_Num),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                      new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                       new SqlParameter("@IP", this.IP),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                        new SqlParameter("@Name", this.Name),
                                                                                          new SqlParameter("@GuestAddress", this.Address),
                                                                                            new SqlParameter("@State", this.Statename),
                                                                                          new SqlParameter("@City", this.cityname),
                                                                                          new SqlParameter("@PostalCode",this.PostalCode),
                                                                                           new SqlParameter("@Country", this.CountryName),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy),
                                                                                      new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                      new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                      );
                        break;


                    case Masters.D2H:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbD2H"),
                                                                                      new SqlParameter("@Customer_ID", this.Customer_ID),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                        new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                       new SqlParameter("@Name", this.Name),
                                                                                          new SqlParameter("@GuestAddress", this.Address),
                                                                                            new SqlParameter("@State", this.Statename),
                                                                                          new SqlParameter("@City", this.cityname),
                                                                                          new SqlParameter("@PostalCode", this.PostalCode),
                                                                                            new SqlParameter("@Country", this.CountryName),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy),
                                                                                      new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                      new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                      );
                        break;



                    case Masters.D2Hnew:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbD2HRecharge"),
                                                                                      new SqlParameter("@Customer_ID", this.Customer_ID),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@RefID", this.UserID),
                                                                                        new SqlParameter("@Type", this.Type),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                        new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@Commission1", this.Commission1),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy));
                                                                                     // new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                     // new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                     
                        break;


                    case Masters.DataCardnew:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbDataCardforNonReg"),
                                                                                      new SqlParameter("@MobileNo", this.Mobile),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@RefID", this.UserID),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                       new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                       new SqlParameter("@Name", this.Name),
                                                                                          new SqlParameter("@GuestAddress", this.Address),
                                                                                            new SqlParameter("@State", this.Statename),
                                                                                          new SqlParameter("@City", this.cityname),
                                                                                          new SqlParameter("@PostalCode", this.PostalCode),
                                                                                            new SqlParameter("@Country", this.CountryName),
                            //new SqlParameter("@Commission1", this.Commission1),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy));
                                                                                     // new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                     // new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                     
                        break;


                    case Masters.DataCard:
                        _objDataLayer.fnExecuteStoredProcedure("spInsertMstData", new SqlParameter("@TableName", "tbDataCard"),
                                                                                      new SqlParameter("@MobileNo", this.Mobile),
                                                                                      new SqlParameter("@RefID", this.UserID),
                                                                                        new SqlParameter("@Type", this.Type),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.E_Mail),
                                                                                      new SqlParameter("@Payment", this.Payment),
                                                                                      new SqlParameter("@RequestID", this.RequestID),
                                                                                      new SqlParameter("@TransactionID", this.TransactionID),
                                                                                      new SqlParameter("@Status", this.Status),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy));
                                                                                     // new SqlParameter("@ModifiedBy", this.ModifiedBy),
                                                                                    //  new SqlParameter("@ModifiedDate", this.ModifiedDate)
                                                                                     
                        break;
                    case Masters.ImageUpload:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Insert_Adv_Images", new SqlParameter("@ImageName", this.ImageName),
                                                                                      new SqlParameter("@Image", SqlDbType.Image),
                                                                                      new SqlParameter("@CreatedBy", this.CreatedBy)
                                                                                    );
                        break;
                    case Masters.Advertisement:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Insert_Advertisement", new SqlParameter("@ScreenName", this.ScreenName),
                                                                                      new SqlParameter("@Advertisement", this.Advertisement),
                                                                                      new SqlParameter("@imgID", this.imgID)
                                                                                    );
                        break;
                    case Masters.InsertTarrif:

                        _objDataLayer.fnExecuteStoredProcedure("sp_insertTarrif", new SqlParameter("@OperatorsID", this.OperatorsID),
                                                                                      new SqlParameter("@Denomination", this.Denomination),
                                                                                      new SqlParameter("@TalkTime", this.TalkTime),
                                                                                      new SqlParameter("@Validity", this.Validity),
                                                                                      new SqlParameter("@Description", this.Description)
                                                                                    );
                        break;


                    case Masters.LogError:
                        _objDataLayer.fnExecuteStoredProcedure("sp_insert_LogError", new SqlParameter("@ScreenName", this.ScreenName),
                                                                                        new SqlParameter("@MethodName", this.MethodName),
                                                                                        new SqlParameter("@Time", this.Time),
                                                                                        new SqlParameter("@Exception", this.Exception)
                                                                                        );


                        break;

                    case Masters.paymentdetails:
                        _objDataLayer.fnExecuteStoredProcedure("sprechargepayment", new SqlParameter("@UserID", this.UserID),
                                                                   new SqlParameter("@MerchantID", this.MerchantID),
                                                                   new SqlParameter("@SubscriberID", this.SubscriberID),
                                                                   new SqlParameter("@TrxReferenceNO", this.TrxReferenceNo),
                                                                   new SqlParameter("@BankReferenceNO", this.BankReferenceNo),
                                                                   new SqlParameter("@TxnAmount", this.TxnAmount),
                                                                   new SqlParameter("@BankID", this.BankID),
                                                                   new SqlParameter("@BankMerchantID", this.BankMerchantID),
                                                                   new SqlParameter("@TCNTYpe", this.TCNTYpe),
                                                                   new SqlParameter("@CurrencyName", this.CurrencyName),
                                                                   new SqlParameter("@ItemCode", this.ItemCode),
                                                                   new SqlParameter("@SecurityType", this.SecurityType),
                                                                   new SqlParameter("@SecurityID", this.SecurityID),
                                                                   new SqlParameter("@SecurityPassword", this.SecurityPassword),
                                                                   new SqlParameter("@TxnDate", this.TxnDate),
                                                                   new SqlParameter("@AuthStatus", this.AuthStatus),
                                                                   new SqlParameter("@SettlementType", this.SettlementType),
                                                                   new SqlParameter("@AdditionalInfo1", this.AdditionalInfo1),
                                                                   new SqlParameter("@AdditionalInfo2", this.AdditionalInfo2),
                                                                   new SqlParameter("@AdditionalInfo3", this.AdditionalInfo3),
                                                                   new SqlParameter("@AdditionalInfo4", this.AdditionalInfo4),
                                                                   new SqlParameter("@AdditionalInfo5", this.AdditionalInfo5),
                                                                   new SqlParameter("@AdditionalInfo6", this.AdditionalInfo6),
                                                                   new SqlParameter("@AdditionalInfo7", this.AdditionalInfo7),
                                                                   new SqlParameter("@ErrorStatus", this.ErrorStatus),
                                                                   new SqlParameter("@ErrorDescription", this.ErrorDescription),
                                                                   new SqlParameter("@CheckSum", this.CheckSum)
                                                               );
                        break;



                    case Masters.Operators:
                        _objDataLayer.fnExecuteStoredProcedure("sp_OperatorsDetails", new SqlParameter("@TableName", "insertOPERATOR"),
                                                                                        new SqlParameter("@NetworkName", this.NetworkName),
                                                                                        new SqlParameter("@OperatorKeyword", this.OperatorKeyword),
                                                                                        new SqlParameter("@OperatorType", this.OperatorType),
                                                                                        new SqlParameter("@TypeOfTransaction",this.TypeOftransactionId)

                                                                                        );


                        break;



                    case Masters.EWallet:
                        _objDataLayer.fnExecuteStoredProcedure("sp_EWallet", new SqlParameter("@UserID", this.UserID),
                                                                                         new SqlParameter("@Parameter", this.Parameter),
                                                                                         new SqlParameter("@OrderID", this.RequestID),
                                                                                        new SqlParameter("@MobileNumber", this.MobileNum),
                                                                                        new SqlParameter("@Amount", this.Amount1)
                                                                                        );


                        break;
                    case Masters.Coupon:
                        _objDataLayer.fnExecuteStoredProcedure("spCouponCodes", new SqlParameter("@Type", "Insert"),
                                                                                        new SqlParameter("@CouponNumber", this.Coupon),
                                                                                        new SqlParameter("@Discount", this.Discount)
                                                                                        );


                        break;
                    case Masters.addewalletamounttouser:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AddEwalletAmounttoUser", new SqlParameter("@UserID", this.UserID),
                                                                                         new SqlParameter("@Parameter","Insert"),
                                                                                         new SqlParameter("@OrderID", this.RequestID),
                                                                                        new SqlParameter("@MobileNumber", this.MobileNum),
                                                                                        new SqlParameter("@Amount", this.Amount1),
                                                                                          new SqlParameter("@ID", this.ID)
                                                                                        );


                        break;
                    case Masters.adjustewalletamounttouser:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AddEwalletAmounttoUser", new SqlParameter("@UserID", this.UserID),
                                                                                         new SqlParameter("@Parameter", "InsertAdjustAmount"),
                                                                                         new SqlParameter("@OrderID", this.RequestID),
                                                                                        new SqlParameter("@MobileNumber", this.MobileNum),
                                                                                        new SqlParameter("@Amount", this.Amount1),
                                                                                          new SqlParameter("@ID", this.ID)
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

        #region Update Record

        public bool fnUpdateRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();

                switch (this.ScreenInd)
                {

                    case Masters.Getservices:
                        _objDataLayer.fnExecuteStoredProcedure("sp_Temporaryservices", new SqlParameter("@TableName", "UpdateServices"),
                                                                                 new SqlParameter("@Id", this.ID),
                                                                                   new SqlParameter("@Status", this.Status));
                        break;
                    case Masters.AddAmounttoUsersRechargeFailed:
                        _objDataLayer.fnExecuteStoredProcedure("AddAmounttoUsersRechargeFailed", new SqlParameter("@UserID", this.UserID),
                                                                                   new SqlParameter("@Amount", this.amountewallet));
                                                                                   

                        break;

                    case Masters.AgentCommission:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentCommission", new SqlParameter("@TableName", "UpdateCommission"),
                                                                                  new SqlParameter("@ID", this.RefID),
                                                                                   new SqlParameter("@NetworkName", this.NetworkName),
                                                                                    new SqlParameter("@OperatorType", this.OperatorType),
                                                                                     new SqlParameter("@AgentCommission", this.AgentCommission));
                                                                                     
                        break;
                    case Masters.ListOfAmounts:
                        _objDataLayer.fnExecuteStoredProcedure("sp_ListOfAmounts", new SqlParameter("@TableName", "UpdateListOfAmount"),
                                                                                  new SqlParameter("@ID", this.RefID),
                                                                                   new SqlParameter("@NetworkName", this.NetworkName),
                                                                                    new SqlParameter("@OperatorType", this.OperatorType),
                                                                                     new SqlParameter("@RechargeAmount", this.A_Amount),
                                                                                     new SqlParameter("@TalkTime", this.TalkTime));
                        break;

                    case Masters.deductadminbalance:
                        _objDataLayer.fnExecuteStoredProcedure("spdeductadminbalance", new SqlParameter("@Balance", this.A_Amount))

                          ;
                        break;

                    case Masters.UpdateAdminonlyBalance:
                        _objDataLayer.fnExecuteStoredProcedure("sp_UpdateonlyAdminBalance", new SqlParameter("@Amount", this.A_Amount),
                            new SqlParameter("@ID", this.ID),
                            new SqlParameter("@UserID", this.UserID));
                        break;


                    case Masters.UpdateGuestrecharge3:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                 new SqlParameter("@TransactionID", this.TransactionID),
                                                                                   new SqlParameter("@Status", this.Status),
                                                                                  new SqlParameter("@Type", "DataCard"),
                                                                              new SqlParameter("@ip", this.IP),
                                                                                new SqlParameter("@A_Amount", this.A_Amount),
                                                                              new SqlParameter("@parameter", this.Parameter))

                          ;
                        break;
                    case Masters.getGuestrecharge1:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                  new SqlParameter("@TransactionID", this.TransactionID),
                                                                                  new SqlParameter("@Status",this.Status),
                                                                                   new SqlParameter("@Type", "Mobile"),
                                                                               new SqlParameter("@ip", this.IP),
                                                                                new SqlParameter("@A_Amount", this.A_Amount),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                        break;

                    case Masters.getagentrecharge2:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                              new SqlParameter("@UserID", this.UserID),
                                                                                                new SqlParameter("@Status", this.Status),
                                                                                           new SqlParameter("@Amount", this.Amount),
                                                                                            new SqlParameter("@TransactionID", this.TransactionID),
                                                                                  new SqlParameter("@Commission",this.AgentCommission),
                                                                                   new SqlParameter("@Type", "DTH"),
                                                                               new SqlParameter("@ip", this.IP),
                                                                               new SqlParameter("@A_Amount",this.A_Amount),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                        break;

                    case Masters.deductagentbalance:
                        _objDataLayer.fnExecuteStoredProcedure("spdeductagentbalance", new SqlParameter("@UserID", this.UserID),
                                                                              new SqlParameter("@Balance", this.A_Amount),
                                                                              new SqlParameter("@DisComm",this.Amount)
                                                                               )

                          ;
                        break;

                    case Masters.UPAgentprofile:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Updateprofile", new SqlParameter("@TableName", "AgentProfile"),
                                                                                    new SqlParameter("@UserID", this.UserID),
                                                                                        new SqlParameter("@FirstName", this.FirstName),
                                                                                      new SqlParameter("@Address", this.Address),
                                                                                      new SqlParameter("@MobileNumber", this.Mobile),
                                                                                      new SqlParameter("@State", this.Statename),
                                                                                      new SqlParameter("@City", this.cityname),
                                                                                        new SqlParameter("@Country", this.CountryName),
                                                                                         new SqlParameter("@PostalCode", this.PostalCode)
                                                                                    );
                        break;
                    case Masters.UpdateAdjustBalance:
                        _objDataLayer.fnExecuteStoredProcedure("sp_UpdateAdjustBalance", new SqlParameter("@Amount", this.A_Amount),
                            new SqlParameter("@UserID", this.UserID),
                            new SqlParameter("@ID", this.ID));
                        break;
                    case Masters.UpdateBalance:
                        _objDataLayer.fnExecuteStoredProcedure("sp_UpdateBalance", new SqlParameter("@Amount", this.A_Amount),
                            new SqlParameter("@ID", this.ID),
                            new SqlParameter("@UserID", this.UserID));
                        break;
                    case Masters.UpdateStatus:
                        _objDataLayer.fnExecuteStoredProcedure("sp_UpdatestatusAgent", new SqlParameter("@UserID", this.UserID),
                            new SqlParameter("@Status", this.Status));
                        break;
                    case Masters.deduct:
                        _objDataLayer.fnExecuteStoredProcedure("spdeductewallectbalance", new SqlParameter("@UserID", this.UserID),

                                                                              new SqlParameter("@Balance", this.VBalance))

                          ;
                        break;


                    case Masters.getrecharge1:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                           new SqlParameter("@UserID",this.UserID),
                                                                                           new SqlParameter("@Amount",this.Amount),
                                                                                           new SqlParameter("@Status",this.Status),
                                                                                           new SqlParameter("@TransactionID", this.TransactionID),
                                                                                           new SqlParameter("@Type", "Mobile"),
                                                                                           new SqlParameter("@ip", this.IP),
                                                                                           new SqlParameter("@Commission", this.AgentCommission),
                                                                                           new SqlParameter("@A_Amount",this.A_Amount),
                                                                                           new SqlParameter("@parameter", this.Parameter))

                           ;
                        break;

                    case Masters.getrecharge2:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                 new SqlParameter("@TransactionID", this.TransactionID),
                                                                                   new SqlParameter("@Status", this.Status),
                                                                                  new SqlParameter("@Type", "DTH"),
                                                                              new SqlParameter("@ip", this.IP),
                                                                                  new SqlParameter("@A_Amount", this.A_Amount),
                                                                              new SqlParameter("@parameter", this.Parameter))

                          ;
                        break;
                        //R
                    case Masters.getrecharge3:
                        _objDataLayer.fnExecuteStoredProcedure("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                           new SqlParameter("@UserID", this.UserID),
                                                                                           new SqlParameter("@Amount", this.Amount),
                                                                                            new SqlParameter("@Status", this.Status),
                                                                                 new SqlParameter("@TransactionID", this.TransactionID),
                                                                                 new SqlParameter("@Commission",this.AgentCommission),
                                                                                  new SqlParameter("@Type", "DataCard"),
                                                                              new SqlParameter("@ip", this.IP),
                                                                               new SqlParameter("@A_Amount", this.A_Amount),
                                                                              new SqlParameter("@parameter", this.Parameter))

                          ;
                        break;
                    case Masters.Country:
                        _objDataLayer.fnExecuteStoredProcedure("spUpdateMstData", new SqlParameter("@TableName", "tbCountryMst"),
                                                                                                            new SqlParameter("@RefID", this.RefID),
                                                                                                            new SqlParameter("@Description", this.Description));
                        break;
                    case Masters.State:
                        _objDataLayer.fnExecuteStoredProcedure("spUpdateMstData", new SqlParameter("@TableName", "tbStateMst"),
                                                                            new SqlParameter("@Description", this.Description),
                                                                            new SqlParameter("@CTTCode", this.ServiceID),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;
                    case Masters.CityType:
                        _objDataLayer.fnExecuteStoredProcedure("spUpdateMstData", new SqlParameter("@TableName", "tbCityTypeMst"),
                                                                            new SqlParameter("@Description", this.Description),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;
                    case Masters.City:
                        _objDataLayer.fnExecuteStoredProcedure("spUpdateMstData", new SqlParameter("@TableName", "tbCityMst"),
                                                                            new SqlParameter("@Description", this.Description),
                                                                            new SqlParameter("@RefID", this.RefID),
                                                                            new SqlParameter("@Commission", this.Commission),
                                                                            new SqlParameter("@CTTCode", this.City));
                        break;
                    case Masters.UserMst: _objDataLayer.fnExecuteStoredProcedure("spUpdateUserDts",
                                                                  new SqlParameter("@UserId", this.UserID),
                                                                  new SqlParameter("@Title", this.Title),
                                                                  new SqlParameter("@FirstName", this.FirstName),
                                                                  new SqlParameter("@LastName", this.LastName),
                                                                  new SqlParameter("@DOB", this.DOB),
                                                                  new SqlParameter("@Address", this.Address),
                                                                  new SqlParameter("@Pincode", this.Pincode),
                                                                  new SqlParameter("@Mobile", this.Mobile),
                                                                  new SqlParameter("@Landline", this.Landline),
                                                                  new SqlParameter("@Country", this.Country),
                                                                  new SqlParameter("@State", this.State),
                                                                  new SqlParameter("@City", this.City)
                                              );


                        break;
                    case Masters.Commission: _objDataLayer.fnExecuteStoredProcedure("sp_Update_tbCommPer",
                                          new SqlParameter("@ID", this.ID),
                                          new SqlParameter("@Commission", this.Commission),
                                          new SqlParameter("@TDR", this.TDR),
                                          new SqlParameter("@ServiceTax", this.ServiceTax),
                                          new SqlParameter("@TotalComm", this.TotalComm),
                                          new SqlParameter("@CancelTicket", this.CancelTicket),
                                          new SqlParameter("@CancelTtlComm", this.CancelTtalComm)
                      );


                        break;


                    case Masters.UPMyprofile:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Updateprofile", new SqlParameter("@TableName", "UserProfile"),
                                                                                    new SqlParameter("@UserID", this.UserID),
                                                                                        new SqlParameter("@FirstName", this.FirstName),
                                                                                      new SqlParameter("@Address", this.Address),
                                                                                      new SqlParameter("@MobileNumber", this.Mobile),
                                                                                      new SqlParameter("@State", this.Statename),
                                                                                      new SqlParameter("@City", this.cityname),
                                                                                        new SqlParameter("@Country", this.CountryName),
                                                                                        new SqlParameter("@PostalCode", this.PostalCode)
                                                                                    );
                        break;


                    case Masters.Advertisement:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Update_Advertisement", new SqlParameter("@ID", this.ID),
                                                                                        new SqlParameter("@ScreenName", this.ScreenName),
                                                                                      new SqlParameter("@Advertisement", this.Advertisement),
                                                                                      new SqlParameter("@imgID", this.imgID)
                                                                                    );
                        break;


                    case Masters.Operators:

                        _objDataLayer.fnExecuteStoredProcedure("sp_OperatorsDetails", new SqlParameter("@TableName", "UPDATEOPERATOR"),
                                                                                        new SqlParameter("@NetworkName", this.NetworkName),
                                                                                      new SqlParameter("@OperatorKeyword", this.OperatorKeyword),
                                                                                      new SqlParameter("@RefId", this.RefID)
                                                                                    );
                        break;


                    case Masters.Upstatus:

                        _objDataLayer.fnExecuteStoredProcedure("sp_Updatestatus", new SqlParameter("@UserID", this.UserID)

                                                                                    );
                        break;

                    case Masters.EWallet:

                        _objDataLayer.fnExecuteStoredProcedure("sp_EWallet", new SqlParameter("@OrderID", this.RequestID),
                                                                                new SqlParameter("@Parameter", this.Parameter),
                                                                             new SqlParameter("@Amount", this.amountewallet)
                                                                                    );
                        break;

                    case Masters.updateOfferContent:
                        _objDataLayer.fnExecuteStoredProcedure("sp_updateofferContent", new SqlParameter("@TableName", "Updatecontent"),
                                                                                        new SqlParameter("@ID", this.ID),
                                                                                        new SqlParameter("@Content", this.Content),
                                                                                        new SqlParameter("@ImagePath", this.ImageName));
                        break;
                    case Masters.addewalletamounttouser:

                        _objDataLayer.fnExecuteStoredProcedure("sp_AddEwalletAmounttoUser", new SqlParameter("@Parameter","Update"),
                                                                                            new SqlParameter("@Amount", this.amountewallet),
                                                                                            new SqlParameter("@UserID",this.UserID)
                                                                                            );
                        break;
                    case Masters.adjustewalletamounttouser:

                        _objDataLayer.fnExecuteStoredProcedure("sp_AddEwalletAmounttoUser", new SqlParameter("@Parameter", "UpdateBalance"),
                                                                                            new SqlParameter("@Amount", this.amountewallet),
                                                                                            new SqlParameter("@UserID", this.UserID)
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

        #region Delete Record
        public bool fnDeleteRecord()
        {
            try
            {
                _objDataLayer = new clsDataLayer();

                switch (this.ScreenInd)
                {
                    case Masters.AgentCommission:
                        _objDataLayer.fnExecuteStoredProcedure("sp_AgentCommission", new SqlParameter("@TableName", "DeleteCommission"),
                                                                                  new SqlParameter("@ID", this.RefID));
                        break;
                    case Masters.ListOfAmounts:
                        _objDataLayer.fnExecuteStoredProcedure("sp_ListOfAmounts", new SqlParameter("@TableName", "DeleteListOfAmount"),
                                                                                  new SqlParameter("@ID", this.RefID));                                                                                 
                        break;
                    case Masters.Country:
                        _objDataLayer.fnExecuteStoredProcedure("spDeleteMstData", new SqlParameter("@TableName", "tbCountryMst"),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;
                    case Masters.State:
                        _objDataLayer.fnExecuteStoredProcedure("spDeleteMstData", new SqlParameter("@TableName", "tbStateMst"),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;
                    case Masters.CityType:
                        _objDataLayer.fnExecuteStoredProcedure("spDeleteMstData", new SqlParameter("@TableName", "tbCityTypeMst"),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;
                    case Masters.City:
                        _objDataLayer.fnExecuteStoredProcedure("spDeleteMstData", new SqlParameter("@TableName", "tbCityMst"),
                                                                            new SqlParameter("@RefID", this.RefID));
                        break;

                    case Masters.Advertisement:
                        _objDataLayer.fnExecuteStoredProcedure("spDeleteMstData", new SqlParameter("@TableName", "tbAdvertisement"),
                                                                            new SqlParameter("@RefID", this.ID));
                        break;
                    case Masters.Operators:
                        _objDataLayer.fnExecuteStoredProcedure("sp_OperatorsDetails", new SqlParameter("@TableName", "DeleteOperator"),
                                                                            new SqlParameter("@RefID", this.RefID));
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
                    case Masters.Dmr:
                        return _objDataLayer.fnExecuteDataset("sp_dmr", new SqlParameter("@TableName", "Getdmr"),
                                                                                     new SqlParameter("@UserID", this.UserID),
                                                                                       new SqlParameter("@ToDate", this.To12),
                                                                                       new SqlParameter("@FromDate", this.From12));
                    #region distributors
                    case Masters.loginDetails:
                        return _objDataLayer.fnExecuteDataset("sp_LoginDetails", new SqlParameter("@TableName", "getlogindetails"),
                                                                                     new SqlParameter("@UserID", this.UserID),
                                                                                       new SqlParameter("@ToDate", this.To12),
                                                                                       new SqlParameter("@LoginTime", this.From12));
                    case Masters.GetAdminCommission:
                        return _objDataLayer.fnExecuteDataset("sp_AgentCommission", new SqlParameter("@TableName", "getAdminCommission"),
                                                                                     new SqlParameter("@OperatorsName", this.NetworkName));
                    case Masters.getdisCommission:
                        return _objDataLayer.fnExecuteDataset("sp_AgentCommission", new SqlParameter("@TableName", "getDisCommission"),
                                                                                    new SqlParameter("@NetworkName", this.NetworkName),
                                                                                    new SqlParameter("@Type", this.Type));
                    case Masters.GetDistributorsList:
                        return _objDataLayer.fnExecuteDataset("sp_GetdistributorsList", new SqlParameter("@TableName", this.Parameter),
                                                                                        new SqlParameter("@DistributorID", this.DistributorID));

                    case Masters.Distributorswisereports:
                        return _objDataLayer.fnExecuteDataset("SpDistributorReports", new SqlParameter("@UserID", this.ID),
                                                                                                              new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));


                    #endregion
                    case Masters.getimages:
                        return _objDataLayer.fnExecuteDataset("sp_getimages", _params);
                    case Masters.Getservices:
                        return _objDataLayer.fnExecuteDataset("sp_Temporaryservices", new SqlParameter("@TableName","GetServices"));
                    case Masters.GetOpeartorByMobileSeries:
                        return _objDataLayer.fnExecuteDataset("Sp_MobileNoSeries",new SqlParameter("@Prefix",this.Parameter));
                    case Masters.getticket:
                        return _objDataLayer.fnExecuteDataset("SP_GetDetails", new SqlParameter("@PGMBRefNo", this.BankReferenceNo));
                                                                                   

                    case Masters.GetAgentAllReports:
                        return _objDataLayer.fnExecuteDataset("SpGetAgentAllReports", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@UserID", this.UserID));

                    case Masters.getadds:
                        return _objDataLayer.fnExecuteDataset("sp_getadds", _params);
                    case Masters.getewalletusers:
                        return _objDataLayer.fnExecuteDataset("sp_GetEwalletUsers", _params);

                    case Masters.GetAdminReports:
                        return _objDataLayer.fnExecuteDataset("sp_GetAdminReports", new SqlParameter("@Tablename", this.Parameter),
                                                                                 new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@UserID", this.UserID));

                    case Masters.GetAgentOnly:
                        return _objDataLayer.fnExecuteDataset("sp_GetMobileDetailsOfAgentBySearch", new SqlParameter("@Tablename", this.Parameter),
                                                                                 new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@UserID", this.UserID));


                    case Masters.GetCommisionByNetwork:
                        return _objDataLayer.fnExecuteDataset("sp_AgentCommission", new SqlParameter("@TableName", "GetCommissionByNetwork"),
                                                                                     new SqlParameter("@OperatorsName",this.NetworkName),
                                                                                       new SqlParameter("@Type", this.Type));

                    case Masters.AgentCommission:
                        return _objDataLayer.fnExecuteDataset("sp_AgentCommission", new SqlParameter("@TableName", "GetCommission"),
                                                                                      new SqlParameter("@Type",this.Type),
                                                                                        new SqlParameter("@ID",this.DistributorID));
                                                                                  

                    case Masters.GetRechargeAmount:
                        return _objDataLayer.fnExecuteDataset("sp_ListOfAmounts", new SqlParameter("@TableName", "GetRechargeAmount"),
                                                                                    new SqlParameter("@NetworkName", this.NetworkName));

                    case Masters.GetNetworkName:
                        return _objDataLayer.fnExecuteDataset("sp_ListOfAmounts", new SqlParameter("@TableName", "GetNetwork"),
                                                                                    new SqlParameter("@OperatorsType",this.OperatorType));
                    case Masters.ListOfAmounts:
                        return _objDataLayer.fnExecuteDataset("sp_ListOfAmounts", new SqlParameter("@TableName", "getListOfAmount"));
                                                                                  

                    case Masters.getoperators:
                        return _objDataLayer.fnExecuteDataset("sp_Getoperators", _params);
                    case Masters.AgentReportBYIDDTH:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgentsBYID", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@UserID", this.ID),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentReportBYIDDatacard:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgentsBYID", new SqlParameter("@From", this.From12),
                                                                                                          new SqlParameter("@UserID", this.ID),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentReportBYID:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgentsBYID", new SqlParameter("@UserID", this.ID),
                                                                                                              new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentReportDatacard:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgents", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                    new SqlParameter("@Type", this.Type),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentReportdth:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgents", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                      new SqlParameter("@Type", this.Type),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentReport:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfAgents", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                     new SqlParameter("@Type", this.Type),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.AgentForgotpwd:
                        return _objDataLayer.fnExecuteDataset("spCheckUserName", new SqlParameter("@TableName", "AgentForgotpwd"),
                                                                                 new SqlParameter("@EmailID", this.EmailID));
                    case Masters.getadmintotalbalance:
                        return _objDataLayer.fnExecuteDataset("sp_getadminTotalbalance", _params)

                           ;
                    case Masters.getguestDatacardrecharge:
                        return _objDataLayer.fnExecuteDataset("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "DataCard"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                    case Masters.getagentDatacardrecharge:
                        return _objDataLayer.fnExecuteDataset("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "DataCard"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                    case Masters.getrechargeD2Hagent:
                        return _objDataLayer.fnExecuteDataset("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "DTH"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                    case Masters.AgentPassword:
                        return _objDataLayer.fnExecuteDataset("spCheckPassword", new SqlParameter("@TableName", "Agentpassword"),
                                                                                 new SqlParameter("@EmailID", this.EmailID));

                    case Masters.GetAgentProfile:
                        return _objDataLayer.fnExecuteDataset("sp_GetAgentprofile", new SqlParameter("@UserID", this.UserID));
                    case Masters.getbalanceAgent:
                        return _objDataLayer.fnExecuteDataset("sp_GetBalanceAgent");

                    case Masters.getbalance:
                        return _objDataLayer.fnExecuteDataset("sp_GetBalance", new SqlParameter("@UserID", this.UserID));
                    case Masters.GetAmount:
                        return _objDataLayer.fnExecuteDataset("sp_GetAmount", new SqlParameter("@UserID", this.UserID));
                    case Masters.GetAgentApprovedList:
                        return _objDataLayer.fnExecuteDataset("sp_GetAgentApprovedList", _params);
                    case Masters.getRequestID:
                        return _objDataLayer.fnExecuteDataset("sp_GetRequestsID", new SqlParameter("@UserID", this.UserID));
                    case Masters.GetRequests:
                        return _objDataLayer.fnExecuteDataset("sp_GetRequests", _params);
                    case Masters.AgentName:
                        return _objDataLayer.fnExecuteDataset("spCheckAgentName", new SqlParameter("@EmailID", this.EmailID));



                    case Masters.bindcontent:
                        return _objDataLayer.fnExecuteDataset("sp_updateofferContent", new SqlParameter("@TableName", "getcontent"));
                    case Masters.gettopcontent:
                        return _objDataLayer.fnExecuteDataset("sp_updateofferContent", new SqlParameter("@TableName", "TopContent"));

                    case Masters.getrechargeforusers:
                        return _objDataLayer.fnExecuteDataset("spgetrechargeinfoforusers", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "Mobile"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;
                    case Masters.Identify1:
                        return _objDataLayer.fnExecuteDataset("sp_IdentifyRechargeofUsers", new SqlParameter("@OrderID", this.RequestID)
                                                                               );

                        ;

                    case Masters.Identify:
                        return _objDataLayer.fnExecuteDataset("sp_IdentifyRecharge", new SqlParameter("@OrderID", this.RequestID)
                                                                               );

                        ;
                    case Masters.GetFlights:
                        return _objDataLayer.fnExecuteDataset("sp_InternationalFlightSegments", new SqlParameter("@tableName", "GetFlights"),
                            new SqlParameter("@FlightBookingID", this.RequestID)
                                                                               );

                        ;
                    case Masters.GetFlights1:
                        return _objDataLayer.fnExecuteDataset("sp_DomesticFlightBooking", new SqlParameter("@tableName", "GetFlights"),
                            new SqlParameter("@ReferenceNo", this.RequestID)
                                                                               );

                        ;


                    case Masters.getrecharge:
                        return _objDataLayer.fnExecuteDataset("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "Mobile"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;

                    case Masters.getrechargeD2H:
                        return _objDataLayer.fnExecuteDataset("spgetrecharge", new SqlParameter("@RequestID", this.RequestID),
                                                                                new SqlParameter("@Type", "DTH"),
                                                                               new SqlParameter("@parameter", this.Parameter))

                           ;


                    case Masters.gettime:
                        return _objDataLayer.fnExecuteDataset("gettime", new SqlParameter("@MobileNO", this.MobileNum),
                                                                         new SqlParameter("@Parameter", this.Parameter)
                            );


                    case Masters.gettimeforusers:
                        return _objDataLayer.fnExecuteDataset("gettime", new SqlParameter("@MobileNO", this.MobileNum),
                                                                         new SqlParameter("@Parameter", this.Parameter)
                            );
                    case Masters.Getreqdtls:
                        return _objDataLayer.fnExecuteDataset("sp_Getreqdtls", new SqlParameter("@UserID", this.UserID));


                    case Masters.Getreqdtls1:
                        return _objDataLayer.fnExecuteDataset("sp_Getreqdtlsforprofile", new SqlParameter("@UserID", this.UserID));

                    case Masters.GetUserReqd:
                        return _objDataLayer.fnExecuteDataset("sp_getUserEmail", new SqlParameter("@UserID", this.UserID));


                    case Masters.GetTopRechargersofDTH:
                        return _objDataLayer.fnExecuteDataset("spgettoprechargersofDTH", new SqlParameter("@Type", this.From)
                                                                                 );

                    case Masters.GetTopRechargersofDataCard:
                        return _objDataLayer.fnExecuteDataset("spgettoprechargersofDataCard", new SqlParameter("@Type", this.From)
                                                                                 );
                    case Masters.GetMRDByServiceSearch:
                        return _objDataLayer.fnExecuteDataset("spGetTotalTopRechargers", new SqlParameter("@Type", this.From)
                                                                                 );

                    case Masters.GetMRDByAdminSearch:
                        return _objDataLayer.fnExecuteDataset("sp_GetMobileDetailsByAdminSearch", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To));


                    case Masters.GetMRByID:
                        return _objDataLayer.fnExecuteDataset("sp_GetMobileRechargeByID", new SqlParameter("@ID", this.ID));

                    case Masters.GetD2HBySearch:
                        return _objDataLayer.fnExecuteDataset("sp_GetD2HDetailsBySearch", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@Parameter", this.Parameter),
                                                                                  new SqlParameter("@UserID", this.UserID));

                    case Masters.GetMRDBySearch:
                        return _objDataLayer.fnExecuteDataset("sp_GetMobileDetailsBySearch", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@UserID", this.UserID));

                    case Masters.GetMRByUserID:
                        return _objDataLayer.fnExecuteDataset("sp_Getmobiledetailsbyid", new SqlParameter("@UserID", this.UserID));

                    case Masters.getmobrechargebyID:
                        return _objDataLayer.fnExecuteDataset("sp_GetmobrechargedtlsByName", new SqlParameter("@TableName", "getmobrechargebyID"),
                                                                                      new SqlParameter("@ID", this.ID));
                    case Masters.SubServices:
                        return _objDataLayer.fnExecuteDataset("sp_Getuserdetails", new SqlParameter("@TableName", "GetUser"));

                    case Masters.GetImage:
                        return _objDataLayer.fnExecuteDataset("sp_GetImage", new SqlParameter("TableName", "Mobile"));

                    case Masters.GetDTH:
                        return _objDataLayer.fnExecuteDataset("sp_GetImage", new SqlParameter("TableName", "DTH"));

                    case Masters.GetData:
                        return _objDataLayer.fnExecuteDataset("sp_GetImage", new SqlParameter("TableName", "DataCard"));
                    case Masters.GetTarrif:
                        return _objDataLayer.fnExecuteDataset("sp_GetTarrif", new SqlParameter("@OperatorsID", this.OperatorsID));

                    case Masters.Commission:
                        return _objDataLayer.fnExecuteDataset("spGetCommPer", _params);

                    case Masters.Failurereport:
                        return _objDataLayer.fnExecuteDataset("spGetMobRechargeFDtls", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.Failurereport1:
                        return _objDataLayer.fnExecuteDataset("spGetMobRechargeFDtls", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));


                    case Masters.Failurereport2:
                        return _objDataLayer.fnExecuteDataset("spGetMobRechargeFDtls", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.Guestreport:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfGuests", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.Guestreport1:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfGuests", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.Guestreport2:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfGuests", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.UserReport:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfUsers", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));





                    case Masters.UserReport1:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfUsers", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));

                    case Masters.UserReport2:
                        return _objDataLayer.fnExecuteDataset("SpGetMobileRechargeDetailsOfUsers", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.operatorsname:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsName", new SqlParameter("@TableName", "Mobile"));

                    case Masters.operatorsname1:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsName", new SqlParameter("@TableName", "DTH"));


                    case Masters.operatorsname2:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsName", new SqlParameter("@TableName", "NetConnect"));

                    case Masters.postpaid:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsName", new SqlParameter("@TableName", "PostPaid"));

                    case Masters.landline:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsName", new SqlParameter("@TableName", "LandLine"));

                    case Masters.Country:
                        return _objDataLayer.fnExecuteDataset("spGetCountryMst", _params);

                    case Masters.State:
                        return _objDataLayer.fnExecuteDataset("spGetStateMst", _params);

                    case Masters.State1:
                        return _objDataLayer.fnExecuteDataset("spGetStateMstOnly", _params);

                    case Masters.CityType:
                        return _objDataLayer.fnExecuteDataset("spGetCityType", _params);

                    case Masters.City:
                        return _objDataLayer.fnExecuteDataset("spGetCityMst", _params);

                    case Masters.UserMst:
                        return _objDataLayer.fnExecuteDataset("spGetUserMst", new SqlParameter("@UserId", this.UserID));

                    case Masters.Gain1:
                        return _objDataLayer.fnExecuteDataset("spGrid", _params);

                    case Masters.Gain:
                        return _objDataLayer.fnExecuteDataset("spGetGainGrid", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),
                                                                                  new SqlParameter("@ID", this.UserID),
                                                                                  new SqlParameter("@UT1", this.UserType),
                                                                                  new SqlParameter("@UT", this.UT1));
                    case Masters.UserID:
                        return _objDataLayer.fnExecuteDataset("spGetUserID_UserMst", _params);

                    case Masters.State_CountryCode:
                        return _objDataLayer.fnExecuteDataset("spGetState_CountryCode", new SqlParameter("@Country", this.Country));

                    case Masters.City_StateCode:
                        return _objDataLayer.fnExecuteDataset("spGetCity_StateCode", new SqlParameter("@State", this.State), new SqlParameter("@Country", this.Country));
                     //R
                    case Masters.UserName:
                        return _objDataLayer.fnExecuteDataset("spCheckUserName", new SqlParameter("@TableName", "UserForgotpwd"),
                                                                                 new SqlParameter("@EmailID", this.EmailID));

                    case Masters.Password:
                        return _objDataLayer.fnExecuteDataset("spCheckPassword", new SqlParameter("@TableName", "Userpassword"),
                                                                                 new SqlParameter("@EmailID", this.EmailID));

                    case Masters.CityGrid:
                        return _objDataLayer.fnExecuteDataset("spGetCityGrid", _params);

                    case Masters.GetUserName:
                        return _objDataLayer.fnExecuteDataset("spGetUserName", _params);

                    case Masters.GainMobile:
                        return _objDataLayer.fnExecuteDataset("spGetMobileGrid", new SqlParameter("@From", this.From),
                                                                                  new SqlParameter("@To", this.To),

                                                                                  new SqlParameter("@EmailID", this.EmailID),
                                                                                  new SqlParameter("@UT1", this.UserType),
                                                                                  new SqlParameter("@UT", this.UT1));

                    case Masters.EWallet:
                        return _objDataLayer.fnExecuteDataset("sp_EWallet", new SqlParameter("@OrderID", this.RequestID),

                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.GetD2Hdetails:
                        return _objDataLayer.fnExecuteDataset("sp_GetD2Hdetails", _params);

                    case Masters.GetDataCardDetails:
                        return _objDataLayer.fnExecuteDataset("sp_GetDataCardDetails", _params);

                    case Masters.GetMobileDetails:
                        return _objDataLayer.fnExecuteDataset("sp_Getmobrechargedtls", _params);
                    case Masters.Mobile:
                        return _objDataLayer.fnExecuteDataset("spGetMobile", _params);
                    case Masters.MobileNumCheck:
                        return _objDataLayer.fnExecuteDataset("spGetMobileRecharge", _params);

                    case Masters.D2H:
                        return _objDataLayer.fnExecuteDataset("spGetD2HRecharge", _params);

                    case Masters.Advertisement:
                        return _objDataLayer.fnExecuteDataset("sp_Get_Advertisement", new SqlParameter("@TableName", "All"));

                    case Masters.GetAdvertisement:
                        return _objDataLayer.fnExecuteDataset("sp_Get_Advertisement", new SqlParameter("@TableName", "Advertisement"),
                                                                                      new SqlParameter("@Advertisement", this.Advertisement));

                    case Masters.Adv_Images:
                        return _objDataLayer.fnExecuteDataset("sp_Get_Adv_Images", _params);

                    case Masters.citilist:
                        return _objDataLayer.fnExecuteDataset("spGetCitilist", _params);

                    case Masters.Operators:
                        return _objDataLayer.fnExecuteDataset("sp_OperatorsDetails", new SqlParameter("TableName", "GetOperator"));


                    case Masters.GetInfo:
                        return _objDataLayer.fnExecuteDataset("spGetDtls", new SqlParameter("@TableName", "UserName"),
                                                                            new SqlParameter("@UserID", this.UserID));


                    case Masters.GetInfo1:
                        return _objDataLayer.fnExecuteDataset("spGetDtls", new SqlParameter("@TableName", "Balance"),
                                                                            new SqlParameter("@UserID", this.UserID));

                    case Masters.bindUsers:
                        return _objDataLayer.fnExecuteDataset("sp_BindUsers", _params);

                    case Masters.bindIp:
                        return _objDataLayer.fnExecuteDataset("sp_GetIp", _params);


                    case Masters.DashBoardUser:
                        return _objDataLayer.fnExecuteDataset("sp_GetRechargesTop", new SqlParameter("@UserID", this.UserID));


                    case Masters.Coupon:
                        return _objDataLayer.fnExecuteDataset("spCouponCodes", new SqlParameter("@Type", "Get"));
                    case Masters.VisitorsReport:
                        return _objDataLayer.fnExecuteDataset("SpVisitorsOfGuestsMobileRecharge", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.VisitorsReportd2h:
                        return _objDataLayer.fnExecuteDataset("SpVisitorsOfGuestsMobileRecharge", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.VisitorsReportDatacard:
                        return _objDataLayer.fnExecuteDataset("SpVisitorsOfGuestsMobileRecharge", new SqlParameter("@From", this.From12),
                                                                                                                 new SqlParameter("@To", this.To12),
                                                                                                                  new SqlParameter("@Parameter", this.Parameter));
                    case Masters.DailyReports:
                        return _objDataLayer.fnExecuteDataset("SpGetDailyReports", new SqlParameter("@From", this.From12));
                                                                                  // new SqlParameter("@Parameter", this.Parameter));
                    case Masters.Ewalletbyrequestid:
                        return _objDataLayer.fnExecuteDataset("sp_Ewalletbyrequestid", new SqlParameter("@OrderID", this.RequestID)
                                                                               );

                        ;

                }
                return null;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return null;
            }
        }
        //public DataSet fnGetData(String Query)
        //{
        //    DataSet ds = new DataSet();
        //    string ds1 = Convert.ToString("SELECT * FROM dbo.tbCompanyMst where servicecode = 4 ORDER BY Code");
        //    return ds;
        //}
        #endregion

        #region Insert/Update User Info
        public bool fnUserInfo(ref int intUserID)
        {
            try
            {
                _objDataLayer = new clsDataLayer();

                if (this.strUserInd == "Insert")
                {
                    SqlParameter spUserID = new SqlParameter();
                    spUserID.ParameterName = "@NewID";
                    spUserID.SqlDbType = SqlDbType.Int;
                    spUserID.Direction = ParameterDirection.Output;
                    _objDataLayer.fnExecuteStoredProcedure("spUserMst", new SqlParameter("@UserID", 0),
                                                                           new SqlParameter("@UserName", this.strUserName),
                                                                           new SqlParameter("@Password", this.strPassword),
                                                                           new SqlParameter("@UserType", this.strUserType),
                                                                           new SqlParameter("@VBalance", this.intVBalance),
                                                                           new SqlParameter("@Active", this.intActive),
                                                                           spUserID);
                    intUserID = int.Parse(spUserID.Value.ToString());
                }
                else if (this.strUserInd == "Update")
                {
                    int len = 1;
                    if (this.strPassword != null)
                    {
                        len = len + 1;
                    }
                    if (this.strUserType != null)
                    {
                        len = len + 1;
                    }
                    if (this.intVBalance != -100)
                    {
                        len = len + 1;
                    }
                    if (this.intActive != -100)
                    {
                        len = len + 1;
                    }

                    SqlParameter[] _params = new SqlParameter[len];

                    len = 0;
                    if (this.strPassword != null)
                    {
                        _params[len] = new SqlParameter("@UserID", this.RefID);
                        len = len + 1;
                    }
                    if (this.strUserType != null)
                    {
                        _params[len] = new SqlParameter("@UserType", this.strUserType);
                        len = len + 1;
                    }
                    if (this.intVBalance != -100)
                    {
                        _params[len] = new SqlParameter("@VBalance", this.intVBalance);
                        len = len + 1;
                    }
                    if (this.intActive != -100)
                    {
                        _params[len] = new SqlParameter("@Active", this.intActive);
                        len = len + 1;
                    }

                    _objDataLayer.fnExecuteStoredProcedure("spUserMst", _params);
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

        #region Function to change password
        public bool fnChangePwd()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                string strQuery = "UPDATE dbo.tbUsers SET Password='" + this.strPassword + "' WHERE UserID=" + this.RefID.ToString();
                _objDataLayer.fnExecuteQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
            }
        }
        public bool fnAgentChangePwd()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                string strQuery = "UPDATE dbo.tbAgent SET Password='" + this.strPassword + "' WHERE UserID=" + this.RefID.ToString();
                _objDataLayer.fnExecuteQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
            }
        }
        #endregion

        #region Function to Forgot password
        public bool fnForgotPwd()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                string strQuery = "UPDATE dbo.tbUsers SET Password='" + this.strPassword + "' WHERE UserID=" + this.RefID.ToString();
                _objDataLayer.fnExecuteQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
            }
        }
        public bool fnAgentForgotPwd()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                string strQuery = "UPDATE dbo.tbAgent SET Password='" + this.strPassword + "' WHERE UserID=" + this.RefID.ToString();
                _objDataLayer.fnExecuteQuery(strQuery);
                return true;
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
            }
        }
        #endregion

        #region Active/Inactive
        public bool fnInactive()
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                switch (this.ScreenInd)
                {
                    case Masters.UserMst:
                        _objDataLayer.fnExecuteStoredProcedure("spInactiveMstData", new SqlParameter("@TableName", "tbUser"),
                                                                                     new SqlParameter("@RefID", this.RefID));
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
        }

        #endregion

        public static int GetValuebyIndex(string param, DropDownList paramname, string CompareBy)
        {
            int tempindex = -1;
            int index = -1;
            int item = 0;
            for (int i = 0; i < paramname.Items.Count; i++)
            {
                if (CompareBy == "Text")
                    item = paramname.Items[i].Text.CompareTo(param);
                else
                    item = paramname.Items[i].Value.CompareTo(param);
                tempindex++;
                if (item == 0)
                {
                    index = tempindex;
                    break;
                }
            }
            return index;
        }


        public DataSet GetOpeartorByMobileSeries(string Prefix)
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                return _objDataLayer.fnExecuteDataset("Sp_MobileNoSeries",new SqlParameter("@Prefix",Prefix));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCities(string Consumerkey,string Consumersecretkey,int value)
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@ConsumerKey", Consumerkey);
                p[1] = new SqlParameter("@ConsumerSecret", Consumersecretkey);
                p[2] = new SqlParameter("@Query", value);

                return _objDataLayer.fnExecuteDataset("SP_WebAPI_GetCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCitiesTours(string Consumerkey, string Consumersecretkey,int value)
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[3];
                p[0] = new SqlParameter("@ConsumerKey", Consumerkey);
                p[1] = new SqlParameter("@ConsumerSecret", Consumersecretkey);
                p[2] = new SqlParameter("@Query", value);

                return _objDataLayer.fnExecuteDataset("SP_WebAPI_GetCities", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetIgnoreList(int ProviderID)
        {
            try
            {
                _objDataLayer = new clsDataLayer();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@ProviderId", ProviderID);
                return _objDataLayer.fnExecuteDataset("SP_IgnoreOpr", p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
