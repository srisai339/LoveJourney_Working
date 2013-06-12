#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 17-Dec-2012
 * Version          : 1.0
 */
#endregion

#region Imports

using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

using LJ.CLB.DTO;
#endregion

namespace LJ.CLB.BL
{
    public sealed class AccountManager : BLBaseClass
    {
        #region Private variables

        Utilities _ = new Utilities();
        static DataSet myDataSet = null;        
        static Object[,] par = null;

        #endregion

        #region StoredProcedures

        const String SP_ValidateUser = "SP_ValidateUser";
        const String SP_Save = "SP_Ins_User";

        #endregion

        #region Public Methods

        //public String NewReg_IsValidEmail(String Email, String ActivationCode)
        //{
        //    String Message = String.Empty;
            
        //        if (Email != String.Empty && ActivationCode != String.Empty)
        //        {
        //            if (_.IsValidString(Email))
        //            {
        //                par = new Object[,] 
        //                { 
        //                    { "@Email", Email },
        //                    { "@Code", ActivationCode }
        //                };

        //                myDataSet = ExecuteDataSet(SP_Activate_Account, par, CommandType.StoredProcedure);

        //                if (myDataSet != null && myDataSet.Tables.Count > 0 && myDataSet.Tables[0].Rows.Count > 0)
        //                {
        //                    switch (myDataSet.Tables[0].Rows[0]["Status"].ToString())
        //                    {
        //                        case "ACTIVATION_LINK_STATUS_ACTIVE":
        //                            Message = CustomMessage.ACTIVATION_LINK_STATUS_ACTIVE;
        //                            break;
        //                        case "Deleted":
        //                            Message = CustomMessage.Deleted;
        //                            break;
        //                        case "InActive":
        //                            Message = CustomMessage.InActive;
        //                            break;
        //                        case "SUCCESS":
        //                            Message = CustomMessage.SUCCESS;
        //                            break;
        //                        case "ACTIVATION_LINK_INVALID":
        //                            Message = CustomMessage.ACTIVATION_LINK_INVALID;
        //                            break;
        //                        case "USER_DOESNOT_EXIST":
        //                            Message = CustomMessage.USER_DOESNOT_EXIST;
        //                            break;                                    
        //                        default:
        //                            Message = CustomMessage.INVALID_SERVICE_REQUEST;
        //                            break;
        //                    }
        //                }
        //                else
        //                    Message = CustomMessage.INVALID_SERVICE_REQUEST;
        //            }
        //            else
        //                Message = CustomMessage.INVALID_CHARS;
        //        }
        //        else
        //            Message = CustomMessage.MANDATORY_FIELDS;
            
        //    return Message;
        //}

        //public String NewReg_IsValidEmail(String Email)
        //{
        //    String Message = String.Empty;        
        //        if (Email != String.Empty)
        //        {
        //            if (IsValidString(Email))
        //            {
        //                par = new Object[,] 
        //                { 
        //                    { "@Email", Email }
        //                };

        //                myDataSet = ExecuteDataSet(SP_Is_New_Email_Valid, par, CommandType.StoredProcedure);

        //                if (myDataSet != null && myDataSet.Tables.Count > 0 && myDataSet.Tables[0].Rows.Count > 0 &&
        //                    myDataSet.Tables[0].Rows[0]["Status"].ToString().ToUpper() != "SUCCESS")
        //                    Message = CustomMessage.USER_ALREADY_EXISTS(Email);
        //                else
        //                    Message = CustomMessage.SUCCESS;
        //            }
        //            else
        //                Message = CustomMessage.INVALID_CHARS;
        //        }
        //        else
        //            Message = CustomMessage.MANDATORY_FIELDS;        
        //    return Message;
        //}

        public String Authenticate(String Username, String Password, String IPAddress)
        {
            String Message = String.Empty;

            if (Username.Trim() != String.Empty && Password.Trim() != String.Empty)
            {
                if (_.IsValidString(Username))
                {
                    Username = Username.Trim().ToString().ToLower();

                    ////Satya hack to check jquery with wcf
                    //if (Username == "satya" && Decrypt(Password) == "satya")
                    //{
                    //    Message = "Success";
                    //}
                    //else
                    //    Message = "Failed";
                    //return Message;
                    par = new Object[,] 
                        { 
                            { "@Username", Username }, 
                            { "@Password", Password },
                            { "@LoginIP", IPAddress }
                        };

                    myDataSet = ExecuteDataSet(SP_ValidateUser, par, CommandType.StoredProcedure);

                    if (myDataSet != null && myDataSet.Tables.Count > 0 && myDataSet.Tables[0].Rows.Count > 0)
                    {
                        //Occurs if user is invalid
                        if (myDataSet.Tables[0].Rows[0]["ERROR"] != null || myDataSet.Tables[0].Rows[0]["ERROR"].ToString() != String.Empty)
                        {
                            switch (myDataSet.Tables[0].Rows[0]["ERROR"].ToString().ToUpper())
                            {
                                case "USER_CRED_INCORRECT":
                                    Message = CustomMessages.USER_CRED_INCORRECT;
                                    break;
                                case "USER_DOESNOT_EXIST":
                                    Message = CustomMessages.USER_DOESNOT_EXIST;
                                    break;
                                default:
                                    Message = CustomMessages.INVALID_SERVICE_REQUEST;
                                    break;
                            }
                        }
                        else
                        {
                            if ((Status)int.Parse(myDataSet.Tables[0].Rows[0]["User_Status"].ToString()) == Status.Active)
                            {
                                //if (ActiveUser.ActiveUserList.Count == 0)
                                //{
                                //    CurrentUser clsCurrentUser = new CurrentUser();
                                //    clsCurrentUser.Remove();
                                //}
                                //objActiveUser = new ActiveUser();

                                //System.Web.HttpContext.Current.Session["UserID"] = objActiveUser.ID = Int32.Parse(myDataSet.Tables[0].Rows[0]["ID"].ToString());
                                //objActiveUser.Username = myDataSet.Tables[0].Rows[0]["UserName"].ToString();
                                //objActiveUser.Password = myDataSet.Tables[0].Rows[0]["Password"].ToString();
                                //objActiveUser.Role = (Role)int.Parse(myDataSet.Tables[0].Rows[0]["User_Role"].ToString());

                                //if (ActiveUser.ActiveUserList.SingleOrDefault(p => p.ID == objActiveUser.ID) == null)
                                //    ActiveUser.ActiveUserList.Add(objActiveUser);
                                //else
                                //    System.Web.HttpContext.Current.Session["UserID"] = objActiveUser.ID;

                                //throw new Exception("A User has already logged in with this account. Details<br/>" +
                                //        " <b>IP Address- </b>" + System.Web.HttpContext.Current.Request.ServerVariables["remote_addr"] + "<br/>" +
                                //        " <b>Name - </b>" + System.Web.HttpContext.Current.Request.LogonUserIdentity.Name);
                                //DBTransaction.Income = tempIN.ToString().Remove(tempIN.ToString().Split('.')[0].Length + 2, 2);
                            }
                            else
                            {
                                switch ((Status)int.Parse(myDataSet.Tables[0].Rows[0]["User_Status"].ToString()))
                                {
                                    case Status.Deleted:
                                        Message = CustomMessages.Deleted;
                                        break;
                                    case Status.InActive:
                                        Message = CustomMessages.InActive;
                                        break;                                    
                                    default:
                                        Message = CustomMessages.INVALID_SERVICE_REQUEST;
                                        break;
                                }
                            }

                        }
                    }
                }
                else
                    Message = CustomMessages.INVALID_CHARS;
            }
            else
                Message = CustomMessages.MANDATORY_FIELDS;

            return Message;
        }       
        #endregion
    }
}
