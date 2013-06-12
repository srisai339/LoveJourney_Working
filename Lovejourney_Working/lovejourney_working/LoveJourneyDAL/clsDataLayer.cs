using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    #region DataLayer
    public class clsDataLayer
    {
        #region Global Variables
        /// <summary>
        /// Variable for SQL Connection String
        /// </summary>
        /// <remarks></remarks>
        private string _strSqlConnection = string.Empty;
        /// <summary>
        /// Variable for Error Log path
        /// </summary>
        /// <remarks></remarks>
        private string _strErrorLogPath = string.Empty;
        /// <summary>
        /// Variable to track Current Login UserID
        /// </summary>
        /// <remarks></remarks>
        private string _strUserID = string.Empty;
        /// <summary>
        /// Object for DataSet 
        /// </summary>
        /// <remarks></remarks>
        private DataSet _objDataSet;
        /// <summary>
        /// Object for SQL Connection
        /// </summary>
        /// <remarks></remarks>
        private SqlConnection _objSQLConnection = new SqlConnection();
        /// <summary>
        /// Object to maintain Transaction
        /// </summary>
        /// <remarks></remarks>
        private SqlTransaction _objSQLTrans;
        /// <summary>
        /// Object for SQL Command
        /// </summary>
        /// <remarks></remarks>
        private SqlCommand _objSQLCommand;
        /// <summary>
        /// Object for SQL DataAdapter
        /// </summary>
        /// <remarks></remarks>
        private SqlDataAdapter _objSqlDataAdapter;
        /// <summary>
        /// Input SQLParameter Array
        /// </summary>
        /// <remarks></remarks>
        private SqlParameter[] Input_parameters = new SqlParameter[1];
        /// <summary>
        /// Output SQLParameter Array
        /// </summary>
        /// <remarks></remarks>
        public SqlParameter[] Output_parameters = new SqlParameter[1];
        /// <summary>
        /// SQLParameter return variable
        /// </summary>
        /// <remarks></remarks>
        public SqlParameter _objReturnParameter;
        /// <summary>
        /// Object for SQLParameter
        /// </summary>
        /// <remarks></remarks>

        public SqlParameter _objSQLParameter;

        #endregion

        #region Constructors
        public clsDataLayer()
        {
            try
            {
                _strSqlConnection = System.Configuration.ConfigurationSettings.AppSettings["AppSetting"];

                _strErrorLogPath = "";
            }
            catch (Exception)
            {
            }
        }

        //Sub New(ByVal strConn As String)
        //    'For Future Use    
        //End Sub
        #endregion

        #region Open Connection
        /// <summary>
        /// To assign the Connection String to the SQL Connection object and to ensure 
        /// whether the Connection object is open or not.
        /// </summary>
        /// <returns>Returns True/False</returns>
        /// <remarks></remarks>
        private bool fnOpenConnection()
        {
            try
            {
                if (!(_objSQLConnection.State == ConnectionState.Open))
                {
                    _objSQLConnection.ConnectionString = _strSqlConnection;
                    _objSQLConnection.Open();
                    return true;
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //End region of fnOpenConnection()
        #endregion

        #region Close Connection
        /// <summary>
        /// To close SQL Connection object and to ensure whether 
        /// the connection object id closed or not
        /// </summary>
        /// <returns>Returns True/False</returns>
        /// <remarks></remarks>
        private bool fnCloseConnection()
        {
            try
            {
                if (!(_objSQLConnection.State == ConnectionState.Closed))
                {
                    _objSQLConnection.Close();
                    return true;
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //End region of fnCloseConnection
        #endregion

        #region Execute Dataset
        /// <summary>
        /// To fetch data from database through Stored Procedure
        /// </summary>
        /// <param name="strStoredProcedureName">Stored Procedure Name</param>
        /// <param name="Parameters">SQLParameter ParamArray</param>
        /// <returns>Return DataSet</returns>
        /// <remarks></remarks>
        public DataSet fnExecuteDataset(string strStoredProcedureName, params SqlParameter[] Parameters)
        {
            try
            {
                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSqlDataAdapter = new SqlDataAdapter();
                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.StoredProcedure;
                    _objSQLCommand.CommandText = strStoredProcedureName;

                    foreach (SqlParameter objParamaeter in Parameters)
                    {
                        _objSQLCommand.Parameters.Add(objParamaeter);
                    }

                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(_objDataSet);

                    return _objDataSet;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _objDataSet = null;
                _objSqlDataAdapter = null;
                _objSQLCommand = null;
                fnCloseConnection();
            }
        }
        /// <summary>
        /// To fetch data from database through Stored Procedure
        /// </summary>
        /// <param name="strStoredProcedureName">Stored Procedure Name</param>
        /// <param name="objDS">Reference DataSet</param>
        /// <returns>DataSet</returns>
        public DataSet fnExecuteDataset(string strStoredProcedureName, ref DataSet objDS)
        {
            try
            {
                if (fnOpenConnection() == true)
                {
                    int i = 0;
                    _objSqlDataAdapter = new SqlDataAdapter();
                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.CommandText = strStoredProcedureName;
                    _objSQLCommand.CommandType = CommandType.StoredProcedure;

                    if (Input_parameters.Length > 1)
                    {
                        for (i = 1; i <= Input_parameters.Length - 1; i++)
                        {
                            _objSQLCommand.Parameters.Add(Input_parameters[i]);
                        }
                    }

                    if (Output_parameters.Length > 0 & (Output_parameters[0] != null))
                    {
                        for (i = 0; i <= Output_parameters.Length - 1; i++)
                        {
                            _objSQLCommand.Parameters.Add(Output_parameters[i]);
                        }
                    }

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(objDS, strStoredProcedureName);

                    return objDS;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException)
            {
                Input_parameters = new SqlParameter[1];
                return null;
            }
            catch (Exception)
            {
                Input_parameters = new SqlParameter[1];
                return null;
            }
            finally
            {
                _objSqlDataAdapter = null;
                _objSQLCommand = null;
                fnCloseConnection();
            }
        }

        //End region of fnExecuteDataset
        #endregion

        #region Execute DataTable
        /// <summary>
        /// To fetch data from database for particular single table
        /// </summary>
        /// <param name="strTableName">Table Name</param>
        /// <param name="strColumns">Column Names</param>
        /// <param name="strWhereCondition">Where Condition</param>
        /// <param name="strOrderBY">Order by</param>
        /// <returns>Returns DataTable</returns>
        public DataTable fnExecuteDataTable(string strTableName, string strColumns, string strWhereCondition = "", string strOrderBY = "")
        {
            try
            {
                string strSQLQuery = null;
                //Local Query String Variable


                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSQLCommand = new SqlCommand();
                    _objSqlDataAdapter = new SqlDataAdapter();

                    if (!string.IsNullOrEmpty(strWhereCondition) & !string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " WHERE " + strWhereCondition + " ORDER BY " + strOrderBY;
                    }
                    else if (!string.IsNullOrEmpty(strWhereCondition) & string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " WHERE " + strWhereCondition;
                    }
                    else if (string.IsNullOrEmpty(strWhereCondition) & !string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " ORDER BY " + strOrderBY;
                    }
                    else
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName;
                    }

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.Text;
                    _objSQLCommand.CommandText = strSQLQuery;

                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(_objDataSet);

                    if (_objDataSet.Tables.Count > 0)
                    {
                        return _objDataSet.Tables[0];
                    }
                    else
                    {
                        //If Dataset is Null
                        return null;
                    }
                }
                else
                {
                    //If SQL Connection is not Open
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _objDataSet = null;
                _objSQLCommand = null;
                _objSqlDataAdapter = null;
                fnCloseConnection();
            }
        }
        //End region of fnExecuteDataTable
        #endregion

        #region Execute DataSet
        /// <summary>
        /// To fetch data from database for particular single table
        /// </summary>
        /// <param name="strTableName">Table Name</param>
        /// <param name="strColumns">Column Names</param>
        /// <param name="strWhereCondition">Where Condition</param>
        /// <param name="strOrderBY">Order by</param>
        /// <returns>Returns DataTable</returns>
        public DataSet fnExeDataSet(string strTableName, string strColumns, string strWhereCondition = "", string strOrderBY = "")
        {
            try
            {
                string strSQLQuery = null;
                //Local Query String Variable


                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSQLCommand = new SqlCommand();
                    _objSqlDataAdapter = new SqlDataAdapter();

                    if (!string.IsNullOrEmpty(strWhereCondition) & !string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " WHERE " + strWhereCondition + " ORDER BY " + strOrderBY;
                    }
                    else if (!string.IsNullOrEmpty(strWhereCondition) & string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " WHERE " + strWhereCondition;
                    }
                    else if (string.IsNullOrEmpty(strWhereCondition) & !string.IsNullOrEmpty(strOrderBY))
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName + " ORDER BY " + strOrderBY;
                    }
                    else
                    {
                        strSQLQuery = "SELECT " + strColumns + " FROM " + strTableName;
                    }

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.Text;
                    _objSQLCommand.CommandText = strSQLQuery;

                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(_objDataSet);

                    if (_objDataSet.Tables.Count > 0)
                    {
                        return _objDataSet;
                    }
                    else
                    {
                        //If Dataset is Null
                        return null;
                    }
                }
                else
                {
                    //If SQL Connection is not Open
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _objDataSet = null;
                _objSQLCommand = null;
                _objSqlDataAdapter = null;
                fnCloseConnection();
            }
        }
        //End region of fnExecuteDataTable
        #endregion

        #region Execute StoredProcedure
        /// <summary>
        /// Function to perform Database Operations and return True/False
        /// </summary>
        /// <param name="strStoredProcedureName">Stored Procedure Name</param>
        /// <param name="Parameters">SQLParameter ParamArray</param>
        /// <returns>Return DataSet</returns>
        /// <remarks></remarks>
        public bool fnExecuteStoredProcedure(string strStoredProcedureName, params SqlParameter[] Parameters)
        {
            try
            {
                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSqlDataAdapter = new SqlDataAdapter();
                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.StoredProcedure;
                    _objSQLCommand.CommandText = strStoredProcedureName;

                    foreach (SqlParameter objParamaeter in Parameters)
                    {
                        _objSQLCommand.Parameters.Add(objParamaeter);
                    }

                    int i = _objSQLCommand.ExecuteNonQuery();

                    if ((i > 0))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _objDataSet = null;
                _objSqlDataAdapter = null;
                _objSQLCommand = null;
                fnCloseConnection();
            }
        }
        //End region of fnExecuteDataset
        #endregion

        #region Execute DataTable
        /// <summary>
        /// To fetch data from database for particular single table
        /// </summary>
        /// <param name="strQuery">Query</param>
        /// <returns>Returns DataTable</returns>
        public DataTable fnExecuteQuery(string strQuery)
        {
            //Local Query String Variable
            try
            {


                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSQLCommand = new SqlCommand();
                    _objSqlDataAdapter = new SqlDataAdapter();

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.Text;
                    _objSQLCommand.CommandText = strQuery;

                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(_objDataSet);

                    if (_objDataSet.Tables.Count > 0)
                    {
                        return _objDataSet.Tables[0];
                    }
                    else
                    {
                        //If Dataset is Null
                        return null;
                    }
                }
                else
                {
                    //If SQL Connection is not Open
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _objDataSet = null;
                _objSQLCommand = null;
                _objSqlDataAdapter = null;
                fnCloseConnection();
            }
        }
        //End region of fnExecuteDataTable
        #endregion

        #region Delete Query
        //Used to delete record(s) from a table
        public bool fnDelete(string tabname, string condition = "")
        {

            try
            {

                if (fnOpenConnection() == true)
                {
                    string delQuery = "";
                    bool @bool = false;

                    delQuery = "Delete from " + tabname;

                    if (!string.IsNullOrEmpty(condition))
                    {
                        delQuery += " WHERE " + condition;
                    }

                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.CommandType = CommandType.Text;
                    _objSQLCommand.CommandText = delQuery;
                    _objSQLCommand.Connection = _objSQLConnection;
                    //@bool = _objSQLCommand.ExecuteNonQuery();
                    _objSQLCommand.ExecuteNonQuery();
                    //if (@bool == true)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    return true;
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //End region of Delete Query
        #endregion

        #region Clear Input And Output Parameters
        public void fnClearInputParameters()
        {
            Input_parameters = new SqlParameter[1];
        }
        public void fnClearOutput_parameters()
        {
            Output_parameters = new SqlParameter[1];
        }
        //End region of Clear Input And Output Parameters
        #endregion

        #region fnAddInputParam
        /// <summary>
        /// To add Input SQLParameters
        /// </summary>
        /// <param name="strParameterName">Parameter Name</param>
        /// <param name="objParameterValue">Parameter Value</param>
        /// <remarks></remarks>
        public void fnAddInputParam(string strParameterName, object objParameterValue)
        {
            try
            {
                _objSQLParameter = new SqlParameter();
                _objSQLParameter.ParameterName = strParameterName;
                _objSQLParameter.Value = objParameterValue;

                Array.Resize(ref Input_parameters, Input_parameters.Length + 1);
                Input_parameters[Input_parameters.Length - 1] = _objSQLParameter;
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                _objSQLParameter = null;
            }
        }
        //End region of fnAddInputParam
        #endregion

        #region fnAddOutputParam
        /// <summary>
        /// To add Output SQLParameters
        /// </summary>
        /// <param name="strParameterName">Parameter Name</param>
        /// <param name="sqlDataType">Parameter Type</param>
        /// <param name="intSize">Parameter Size</param>
        /// <remarks></remarks>
        public void fnAddOutputParam(string strParameterName, SqlDbType sqlDataType, int intSize = 0)
        {
            try
            {
                _objSQLParameter = new SqlParameter();

                _objSQLParameter.ParameterName = strParameterName;
                _objSQLParameter.Direction = ParameterDirection.Output;
                _objSQLParameter.SqlDbType = sqlDataType;
                _objSQLParameter.Size = intSize;

                if (Output_parameters.Length == 1 & Output_parameters[0] == null)
                {
                    Output_parameters[0] = _objSQLParameter;
                }
                else
                {
                    Array.Resize(ref Output_parameters, Output_parameters.Length + 1);
                    Output_parameters[Output_parameters.Length - 1] = _objSQLParameter;
                }
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                _objSQLParameter = null;
            }
        }
        //End region of fnAddOutputParam
        #endregion

        #region fnExecuteStoredProcedure
        /// <summary>
        /// fnExecuteStoredProcedure, function used to manipulate DML Statements and returns Boolean value
        /// </summary>
        /// <param name="strStoredProcedureName">Stored Procedure Name</param>
        /// <returns>Return True/False</returns>
        /// <remarks>We use this function to execute DML statements through SP. 
        /// If we call this function we need to add SQLParameters by using fnAddInputParam and similarly 
        /// we need to use fnAddOutParam for Out SQLParameters</remarks>
        public bool fnExecuteStoredProcedure(string strStoredProcedureName)
        {
            int i = 0;
            //Local Loop Variable
            try
            {

                if (fnOpenConnection() == true)
                {
                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.CommandText = strStoredProcedureName;
                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.StoredProcedure;

                    if (Input_parameters.Length > 1)
                    {
                        for (i = 1; i <= Input_parameters.Length - 1; i++)
                        {
                            _objSQLCommand.Parameters.Add(Input_parameters[i]);
                        }
                    }
                    if (Output_parameters.Length > 0 & (Output_parameters[0] != null))
                    {
                        for (i = 0; i <= Output_parameters.Length - 1; i++)
                        {
                            _objSQLCommand.Parameters.Add(Output_parameters[i]);
                        }
                    }
                    if ((_objSQLCommand.ExecuteNonQuery() > 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Input_parameters = new SqlParameter[1];
                fnCloseConnection();
            }
        }
        //End region of fnExecuteStoredProcedure
        #endregion

        public DataSet fnExecuteDataSet(string p, params SqlParameter[] Parameters)
        {
            // throw new NotImplementedException();
            try
            {
                if (fnOpenConnection() == true)
                {
                    _objDataSet = new DataSet();
                    _objSqlDataAdapter = new SqlDataAdapter();
                    _objSQLCommand = new SqlCommand();

                    _objSQLCommand.Connection = _objSQLConnection;
                    _objSQLCommand.CommandType = CommandType.StoredProcedure;
                    _objSQLCommand.CommandText = p;

                    foreach (SqlParameter objParamaeter in Parameters)  
                    {
                        _objSQLCommand.Parameters.Add(objParamaeter);
                    }

                    _objSqlDataAdapter.SelectCommand = _objSQLCommand;
                    _objSqlDataAdapter.Fill(_objDataSet);

                    return _objDataSet;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _objDataSet = null;
                _objSqlDataAdapter = null;
                _objSQLCommand = null;
                fnCloseConnection();
            }
        }
    }
    #endregion
}



