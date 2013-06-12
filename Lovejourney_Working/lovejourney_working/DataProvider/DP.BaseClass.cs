#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
 * Version          : 1.0
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

#endregion

namespace LJ.CLB.DP
{
    /// <summary>
    /// DPBaseClass Class is responsible for executing queries against database and retrieve resultsets
    /// </summary>
    public sealed class DPBaseClass
    {
        #region StoredProcedures

        const String SP_SaveErrorLog = "SP_Save_Error_Log";

        #endregion

        #region Private variables

        private static String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static SqlConnection myConnection = null;
        static SqlCommand myCommand = null;
        static SqlDataAdapter myDataAdaptor = null;
        static SqlDataReader myDataReader = null;
        static DataSet myDataSet = null;
        static DataTable myDataTable = null;
        static Int32 effectedRows = 0;

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to execute query against database and return dataset
        /// </summary>        
        /// <returns></returns>
        public static DataSet ExecuteDataSet(String sql, Object[,] par, CommandType CommandType)
        {
            CreateConn();
            try
            {
                myCommand = GenerateSQLCommand(sql, CommandType, par);
                myCommand.Connection = myConnection;
                OpenConn(myConnection);
                myDataAdaptor = new SqlDataAdapter(myCommand);
                myDataSet = new DataSet();
                myDataAdaptor.Fill(myDataSet);
                myDataAdaptor.Dispose();
                return myDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(myConnection);
            }
        }

        /// <summary>
        /// Method to accept paramaters andcreate sql command
        /// </summary>        
        public static SqlCommand GenerateSQLCommand(String sql, CommandType cmdType, Object[,] sqlParams)
        {
            try
            {
                myCommand = new SqlCommand(sql, myConnection);
                myCommand.CommandType = cmdType;
                if (sqlParams != null)
                {
                    for (int i = 0; i < sqlParams.GetLength(0); ++i)
                    {
                        Object pr = null;
                        //occurs if sqlparams itself is declared null
                        if (sqlParams[i, 1] == null)
                            continue;
                        else if (sqlParams[i, 1] == "-1")
                            pr = DBNull.Value;
                        else if (sqlParams[i, 1] == "")
                            pr = DBNull.Value;
                        else
                            pr = sqlParams[i, 1];

                        myCommand.Parameters.AddWithValue(sqlParams[i, 0].ToString(), pr);
                    }
                }
                return myCommand;
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Method to execute query against database and return number of rows effected
        /// </summary>        
        public static Int32 ExecuteNonQuery(String sql, Object[,] sqlParams)
        {
            CreateConn();
            try
            {
                myCommand = GenerateSQLCommand(sql, CommandType.StoredProcedure, sqlParams);
                myCommand.Connection = myConnection;
                OpenConn(myConnection);
                effectedRows = myCommand.ExecuteNonQuery();
                return effectedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(myConnection);
            }
        }

        /// <summary>
        /// Method to execute query against database and return datareader
        /// </summary>
        public static DataTable Executereader(String sql, Object[,] sqlParams, CommandType CommandType)
        {
            CreateConn();
            try
            {
                myDataTable = new DataTable();
                myCommand = GenerateSQLCommand(sql, CommandType, sqlParams);
                myCommand.Connection = myConnection;
                OpenConn(myConnection);
                myDataReader = myCommand.ExecuteReader();
                if (myDataReader.HasRows)
                    myDataTable.Load(myDataReader);
                return myDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(myConnection);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to open existing sql connection
        /// </summary>
        private static void OpenConn(SqlConnection myConnection)
        {
            if (myConnection.State == ConnectionState.Closed)
                myConnection.Open();
        }

        /// <summary>
        /// Method to create new sql connection
        /// </summary>
        private static void CreateConn()
        {
            myConnection = new SqlConnection(ConnectionString);
        }
        
        /// <summary>
        /// Method to close existing sql connection
        /// </summary>
        public static void CloseConn(SqlConnection myConnection)
        {
            using (myConnection)
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                    myConnection.Dispose();
                }
            }
        }

        #endregion

        #region LogException

        public static void LogException(Exception ex)
        {
            //Hack - Development environment
            return;
            Object[,] par = new Object[,] 
            { 
                { "@Message", ex.Message }, 
                { "@Location", ex.StackTrace}, 
                { "@FullPath", HttpContext.Current.Session["HTTP_REFERER"] }, 
                { "@UserName", HttpContext.Current.Session["REMOTE_USER"] }, 
                { "@IPAddress", HttpContext.Current.Session["LOCAL_ADDR"] }, 
                { "@USERID", HttpContext.Current.Session["UserID"] } 
            };
            ExecuteNonQuery(SP_SaveErrorLog, par);
        }

        #endregion
    }
}
