#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
 * Version          : 1.0
 */
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LJ.CLB.DP;
using LJ.CLB.DTO;

#endregion

namespace LJ.CLB.BL
{
    /// <summary>
    /// BLBaseClass Class is responsible for pass queries to provider and retrieve resultsets
    /// </summary>
    public class BLBaseClass
    {
        #region Private Variables

        static Object[,] par = null;
        static Int32 effectedRows = -1;

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to delete details from database
        /// </summary>
        public Boolean Delete(Object[,] par, String Command, out String Message)
        {
            try
            {
                effectedRows = DPBaseClass.ExecuteNonQuery(Command, par);
                Message = CustomMessages.DELETE_SUCESS.ToString();

                if (effectedRows > 0)
                    return true;
            }
            catch (Exception ex)
            {
                DPBaseClass.LogException(ex);
                Message = CustomMessages.DELETE_FAILED.ToString();
            }
            return false;
        }

        /// <summary>
        /// Method to execute query and retutn dataset against database
        /// </summary>        
        public DataSet ExecuteDataSet(String Command, Object[,] par, CommandType CommandType)
        {
            try
            {
                return DPBaseClass.ExecuteDataSet(Command, par, CommandType);
            }
            catch (Exception ex)
            {
                DPBaseClass.LogException(ex);
            }
            return null;
        }

        /// <summary>
        /// Method to execute query and retutn Boolean value against database
        /// </summary>        
        public Boolean ExecuteNonQuery(Object[,] par, String Command, out String Message)
        {
            try
            {
                Message = String.Empty;
                effectedRows = DPBaseClass.ExecuteNonQuery(Command, par);
                if (effectedRows > 0)
                    return true;
            }
            catch (Exception ex)
            {
                DPBaseClass.LogException(ex);
                Message = CustomMessages.UNKNOWN_ERROR.ToString();
            }
            return false;
        }

        /// <summary>
        /// Method to execute query and return datatable against database
        /// </summary>
        public DataTable ExecuteReader(String Command, Object[,] par, CommandType CommandType, out String Message)
        {
            try
            {
                Message = String.Empty;
                return DPBaseClass.Executereader(Command, par, CommandType.Text);
            }
            catch (Exception ex)
            {
                DPBaseClass.LogException(ex);
                Message = CustomMessages.UNKNOWN_ERROR.ToString();
            }
            return null;
        }

        /// <summary>
        /// Method to retrive list of records from database
        /// </summary>
        public DataSet GetList(String Command)
        {
            return ExecuteDataSet(Command, par, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Method to retrive list of records from database
        /// </summary>
        public DataSet GetListByFilter(String param, String Command)
        {

            Object[,] par = new Object[,] { { "@param", param } };
            return ExecuteDataSet(Command, par, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Method to save details to database
        /// </summary>
        public Boolean Save(Object[,] par, String Command, out String Message)
        {
            try
            {
                effectedRows = DPBaseClass.ExecuteNonQuery(Command, par);
                if ((TransactionType)(par.GetValue((par.Length / 2) - 1, (par.Length / 2) - 1)) == TransactionType.INSERT)
                    Message = CustomMessages.INSERT_SUCESS.ToString();
                else
                    Message = CustomMessages.UPDATE_SUCESS.ToString();
                if (effectedRows > 0)
                    return true;
            }
            catch (Exception ex)
            {
                DPBaseClass.LogException(ex);
                if ((TransactionType)(par.GetValue((par.Length / 2) - 1, (par.Length / 2) - 1)) == TransactionType.INSERT)
                    Message = CustomMessages.INSERT_FAILED.ToString();
                else
                    Message = CustomMessages.UPDATE_FAILED.ToString();
            }
            return false;
        }

        #endregion
    }
}
