#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 12-Dec-2012
 * Version          : 1.0
 * Functionality    : Performs DML operations of Categories records against database
 */
#endregion

#region Imports

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

using LJ.CLB.DP;
using LJ.CLB.DTO;

#endregion

namespace LJ.CLB.BL
{
    public class ProviderManager : BLBaseClass
    {
        #region Private Variables

        Utilities _ = new Utilities();
        static Object[,] par = null;
        static DataSet myDataSet = null;

        #endregion

        #region StoredProcedures

        const String SP_Insert_Update_Delete = "SP_Provider";

        #endregion

        #region Public Methods

        public providerList GetProviderList()
        {
            provider objProvider = null;
            providerList objProviderList = null;
            myDataSet = ExecuteDataSet("SELECT * FROM tbl_Providers", null, CommandType.Text);

            if (myDataSet.Tables.Count > 0 && myDataSet.Tables[0].Rows.Count > 0)
            {
                objProviderList = new providerList();
                foreach (DataRow myDataRow in myDataSet.Tables[0].Rows)
                {
                    objProvider =
                        new provider(
                            Int32.Parse(myDataRow["Provider_ID"].ToString())
                            , myDataRow["Provider_Name"].ToString()
                            , Int16.Parse(myDataRow["Provider_Order"].ToString())
                            , (Status)int.Parse(myDataRow["Provider_Status"].ToString()));
                    objProviderList.Add(objProvider);
                }
            }
            return objProviderList;
        }

        public Boolean SaveProvider(out String Message, providerList providerlist, provider objProvider)
        {
            Message = String.Empty;
            //Check if duplicate records exists in the category list
            if (providerlist.Select(element => element.providerName = objProvider.providerName).Count() > 1)
            {
                Message = CustomMessages.DUPLICATE("Provider", "Name");
                return false;
            }
            else
            {
                par = new Object[,] 
                { 
                    { "@ID", objProvider.providerId }
                    , { "@Name", objProvider.providerName }
                    , { "@Order", objProvider.providerOrder }
                    , { "@Status", objProvider.providerStatus }
                    , { "@CreatedBy",  HttpContext.Current.Session["UserID"] }
                    , { "@ModifiedBy",  HttpContext.Current.Session["UserID"] }
                    , { "@TxnType",  (objProvider.providerId>0 ? TransactionType.UPDATE: TransactionType.INSERT) }
                };
                return Save(par, SP_Insert_Update_Delete, out Message);
            }
        }

        public Boolean DeleteProvider(out String Message, provider objProvider)
        {
            Message = String.Empty;

            par = new Object[,] 
                { 
                    { "@ID", objProvider.providerId }, 
                    { "@TxnType", TransactionType.DELETE } 
                };
            return Delete(par, SP_Insert_Update_Delete, out Message);
        }

        #endregion
    }
}