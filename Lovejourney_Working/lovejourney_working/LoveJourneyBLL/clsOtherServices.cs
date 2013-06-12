using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BAL
{
    #region Enum
    public enum OtherServices
    {
        Mobile, Insurance, Electricity, Packers, Other, HomeAppliances, Commodities
    }
    #endregion
    public class clsOtherServices
    {
        #region Global Variables
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

        public OtherServices ScreenInd { get; set; }

        public string Name;
        public string MobileNo;
        public string Email;
        public string Address;
        public string City;
        public string State;
        public string ServiceType;
        public string Message;
        public string Provider_Name;
        public decimal Amount;
        public string PolicyNo;
        public string PortfolioNo;
        public string AccountNo;
        public DateTime Billdate;
        public string Other;
        public string Requirement;
        public string ServiceFrom;
        public string ServiceUpto;
        public DateTime ServiceDate;
        public int Company;
        public int Product;
        public int Model;
        public int Amountddl;


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
                    //case Masters.Country:
                    //    _objDataLayer.fnExecuteStoredProcedure("spAPRInsertMstData", new SqlParameter("@TableName", "tbAPRCountryMst"),
                    //                                                        new SqlParameter("@Description", this.Description));
                    //    break;

                    case OtherServices.Mobile:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRMobileRecharge", new SqlParameter("@MobileNo", this.MobileNo),
                                                                                      new SqlParameter("@Provider_Name", this.Provider_Name),
                                                                                      new SqlParameter("@Amount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.Email),
                                                                                      new SqlParameter("@Message", this.Message)
                                                                                      );
                        break;

                    case OtherServices.Electricity:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRElectricityBill", new SqlParameter("@Type", this.ServiceType),
                                                                                      new SqlParameter("@Account_No", this.AccountNo),
                                                                                      new SqlParameter("@BillDate", this.Billdate),
                                                                                      new SqlParameter("@BillAmount", this.Amount),
                                                                                      new SqlParameter("@E_Mail", this.Email),
                                                                                      new SqlParameter("@Address", this.Address),
                                                                                      new SqlParameter("@Others", this.Other)
                                                                                      );
                        break;

                    case OtherServices.Insurance:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRInsurance", new SqlParameter("@Policy_No", this.PolicyNo),
                                                                                new SqlParameter("@Portfolio_No", this.PortfolioNo),
                                                                                new SqlParameter("@Pay_Amount", this.Amount),
                                                                                new SqlParameter("@Mobile_No", this.MobileNo),
                                                                                new SqlParameter("@E_Mail", this.Email),
                                                                                new SqlParameter("@Address", this.Address)
                                                                                                );
                        break;
                    case OtherServices.Other:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRInsertOtherService", new SqlParameter("@Name", this.Name),
                                                                                        new SqlParameter("@MobileNo", this.MobileNo),
                                                                                        new SqlParameter("@Email", this.Email),
                                                                                        new SqlParameter("@Address", this.Address),
                                                                                        new SqlParameter("@City", this.City),
                                                                                        new SqlParameter("@State", this.State),
                                                                                        new SqlParameter("@ServiceType", this.ServiceType),
                                                                                        new SqlParameter("@Message", this.Message)
                                                                                         );
                        break;
                    case OtherServices.HomeAppliances:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRInsertHomeAppliances",
                                                                                        new SqlParameter("@Company", this.Company),
                                                                                        new SqlParameter("@Product", this.Product),
                                                                                        new SqlParameter("@Model", this.Model),
                                                                                        new SqlParameter("@Amount", this.Amountddl),
                                                                                        new SqlParameter("@Name", this.Name),
                                                                                        new SqlParameter("@Mobile_Num", this.MobileNo),
                                                                                        new SqlParameter("@E_mail", this.Email),
                                                                                        new SqlParameter("@Address", this.Address)
                                                                                         );
                        break;
                    case OtherServices.Commodities:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRInsertCommodities",
                                                                                        new SqlParameter("@Company", this.Company),
                                                                                        new SqlParameter("@Product", this.Product),
                                                                                        new SqlParameter("@Model", this.Model),
                                                                                        new SqlParameter("@Amount", this.Amountddl),
                                                                                        new SqlParameter("@Name", this.Name),
                                                                                        new SqlParameter("@Mobile_Num", this.MobileNo),
                                                                                        new SqlParameter("@E_mail", this.Email),
                                                                                        new SqlParameter("@Address", this.Address)
                                                                                         );
                        break;
                    case OtherServices.Packers:
                        _objDataLayer.fnExecuteStoredProcedure("spAPRInsertPackers", new SqlParameter("@ServiceType", this.ServiceType),
                                                                                    new SqlParameter("@ServiceFrom", this.ServiceFrom),
                                                                                    new SqlParameter("@ServiceUpto", this.ServiceUpto),
                                                                                    new SqlParameter("@ServiceDate", this.ServiceDate),
                                                                                    new SqlParameter("@Name", this.Name),
                                                                                    new SqlParameter("@Mobile", this.MobileNo),
                                                                                    new SqlParameter("@Email", this.Email),
                                                                                    new SqlParameter("@Requirement", this.Requirement)
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
                    //case Masters.Country:
                    //    _objDataLayer.fnExecuteStoredProcedure("spAPRUpdateMstData", new SqlParameter("@TableName", "tbAPRCountryMst"),
                    //                                                        new SqlParameter("@Description", this.Description));
                    //    break;

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
                    //case Masters.Country:
                    //    _objDataLayer.fnExecuteStoredProcedure("spAPRDeleteMstData", new SqlParameter("@TableName", "tbAPRCountryMst"),
                    //                                                        new SqlParameter("@RefID", this.RefID));
                    //    break;

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
                    //case Masters.Country:
                    //    return _objDataLayer.fnExecuteDataset("spAPRGetCountryMst", _params);



                }
                return null;
            }
            catch (Exception ex)
            {
               // Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return null;
            }
        }
        #endregion
    }
}
