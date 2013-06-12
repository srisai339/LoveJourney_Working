using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using DAL;

namespace BAL
{
    public class clsUserAuthentication
    {

        #region Global Variables
        clsDataLayer _objDataLayer;
        DataSet dsUserInfo;
        #endregion

        #region Properties
        public string strEmailID { get; set; }
        public string strPassword { get; set; }
        public string strUserType { get; set; }
        #endregion

        #region Check Users

        public bool fnCheckAPRUser()
        {
            try
            {
                dsUserInfo = new DataSet();
                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@Result";
                spUserID.SqlDbType = SqlDbType.VarChar;
                spUserID.Size = 20;
                spUserID.Direction = ParameterDirection.Output;

                _objDataLayer = new clsDataLayer();
                dsUserInfo = _objDataLayer.fnExecuteDataset("spCheckUsers", new SqlParameter("@EmailID", this.strEmailID),
                                                                               new SqlParameter("@Password", this.strPassword), spUserID);
                if (spUserID.Value.ToString() == "VALID USER" && dsUserInfo.Tables[0].Rows[0]["Status"].ToString()=="1")
                {
                    if (dsUserInfo.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Session["RechargeUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["RechargeUserType"] = dsUserInfo.Tables[0].Rows[0]["UserType"].ToString();
                        HttpContext.Current.Session["RechargeEmailID"] = dsUserInfo.Tables[0].Rows[0]["EmailID"].ToString();
                      //  HttpContext.Current.Session["RechargeTotalComm"] = dsUserInfo.Tables[1].Rows[0]["TotalComm"].ToString();
                       // HttpContext.Current.Session["RechargeCancelComm"] = dsUserInfo.Tables[1].Rows[0]["CancelTtlComm"].ToString();

                        //if (dsUserInfo.Tables[1].Rows.Count > 0)
                        //{
                        //   HttpContext.Current.Session["APRBusCom"] = dsUserInfo.Tables[1].Rows[0][3].ToString();
                        //}

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (spUserID.Value.ToString() == "INVALID USER")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
                dsUserInfo.Dispose();
            }
        }

        public bool fnCheckAPRUser1()
        {
            try
            {
                dsUserInfo = new DataSet();
                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@Result";
                spUserID.SqlDbType = SqlDbType.VarChar;
                spUserID.Size = 20;
                spUserID.Direction = ParameterDirection.Output;

                _objDataLayer = new clsDataLayer();
                dsUserInfo = _objDataLayer.fnExecuteDataset("spCheckUsers1", new SqlParameter("@EmailID", this.strEmailID),
                                                                               new SqlParameter("@Password", this.strPassword),
                                                                               new SqlParameter("@UserType", this.strUserType), spUserID);
                if (spUserID.Value.ToString() == "VALID USER")
                {
                    if (dsUserInfo.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Session["RechargeUserID"] = dsUserInfo.Tables[0].Rows[0][0].ToString();
                        HttpContext.Current.Session["RechargeEmailID"] = dsUserInfo.Tables[0].Rows[0][1].ToString();

                        //if (dsUserInfo.Tables[1].Rows.Count > 0)
                        //{
                        //   HttpContext.Current.Session["APRBusCom"] = dsUserInfo.Tables[1].Rows[0][3].ToString();
                        //}
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (spUserID.Value.ToString() == "INVALID USER")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
                dsUserInfo.Dispose();
            }
        }

        public bool fnCheckAgent()
        {
            try
            {
                dsUserInfo = new DataSet();
                SqlParameter spUserID = new SqlParameter();
                spUserID.ParameterName = "@Result";
                spUserID.SqlDbType = SqlDbType.VarChar;
                spUserID.Size = 20;
                spUserID.Direction = ParameterDirection.Output;

                _objDataLayer = new clsDataLayer();
                dsUserInfo = _objDataLayer.fnExecuteDataset("spCheckAgent", new SqlParameter("@EmailID", this.strEmailID),
                                                                               new SqlParameter("@Password", this.strPassword), spUserID);
                if (spUserID.Value.ToString() == "VALID USER")
                {
                    if (dsUserInfo.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Session["RechargeUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["RechargeUserType"] = dsUserInfo.Tables[0].Rows[0]["UserType"].ToString();
                        HttpContext.Current.Session["RechargeEmailID"] = dsUserInfo.Tables[0].Rows[0]["EmailID"].ToString();
                        //HttpContext.Current.Session["TravelTotalComm"] = dsUserInfo.Tables[1].Rows[0]["TotalComm"].ToString();
                        //HttpContext.Current.Session["TravelCancelComm"] = dsUserInfo.Tables[1].Rows[0]["CancelTtlComm"].ToString();
                        HttpContext.Current.Session["Status"] = dsUserInfo.Tables[0].Rows[0]["Status"].ToString();

                        //if (dsUserInfo.Tables[1].Rows.Count > 0)
                        //{
                        //   HttpContext.Current.Session["APRBusCom"] = dsUserInfo.Tables[1].Rows[0][3].ToString();
                        //}

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (spUserID.Value.ToString() == "INVALID USER")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogType.Log_In_DB, ex, true);
                return false;
            }
            finally
            {
                _objDataLayer = null;
                dsUserInfo.Dispose();
            }
        }

        #endregion

    }
}
