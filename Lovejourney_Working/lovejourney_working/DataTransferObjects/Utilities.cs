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
using System.Security.Cryptography;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion


namespace LJ.CLB.DTO
{
    /// <summary>
    /// Utilities Class contains the general methods used in all pages
    /// </summary>
    public class Utilities
    {
        #region Private Variables

        private const String SHARED_SECRET = "Hash";
        private String sharedSecret = String.Empty;
        private Byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");        

        #endregion

        #region Public Methods

        public Utilities()
        {
            sharedSecret = "abcd1234";
        }

        /// <summary>
        /// Holds the session[userid] value
        /// </summary>
        public Int32 CurrentUserID
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserID"] != null)
                    return Int32.Parse(System.Web.HttpContext.Current.Session["UserID"].ToString());
                else
                    return 0;
            }
        }

        /// <summary>
        /// Method which does the encryption using Rijndeal algorithm
        /// </summary>
        /// <param name="InputText">Data to be encrypted</param>
        /// <param name="Password">The string to used for making the key.The same string
        /// should be used for making the decrpt key</param>
        /// <returns>Encrypted Data</returns>
        public String Encrypt(String InputText)
        {
            RijndaelManaged RijndaelCipher = null;
            try
            {
                String Password = ConfigurationManager.AppSettings["ENCRYPT_DECRYPT_PWD"];
                RijndaelCipher = new RijndaelManaged();

                Byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
                Byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

                //This class uses an extension of the PBKDF1 algorithm defined in the PKCS#5 v2.0 
                //standard to derive bytes suitable for use as key material from a password. 
                //The standard is documented in IETF RRC 2898.

                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric encryptor object. 
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                //Defines a stream that links data streams to cryptographic transformations
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);
                //Writes the final state and clears the buffer
                cryptoStream.FlushFinalBlock();
                Byte[] CipherBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                String EncryptedData = Convert.ToBase64String(CipherBytes);
                return EncryptedData;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
            finally
            {
                // Clear the RijndaelManaged object. 
                if (RijndaelCipher != null)
                    RijndaelCipher.Clear();
            }

        }

        /// <summary>
        /// Method which does the encryption using Rijndeal algorithm.This is for decrypting the data
        /// which has orginally being encrypted using the above method
        /// </summary>
        /// <param name="InputText">The encrypted data which has to be decrypted</param>
        /// <param name="Password">The string which has been used for encrypting.The same string
        /// should be used for making the decrypt key</param>
        /// <returns>Decrypted Data</returns>
        public String Decrypt(String InputText)
        {
            RijndaelManaged RijndaelCipher = null;
            try
            {
                if (InputText != String.Empty)
                {
                    String Password = ConfigurationManager.AppSettings["ENCRYPT_DECRYPT_PWD"];
                    RijndaelCipher = new RijndaelManaged();
                    Byte[] EncryptedData = Convert.FromBase64String(InputText);
                    Byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                    //Making of the key for decryption
                    PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                    //Creates a symmetric Rijndael decryptor object.
                    ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                    MemoryStream memoryStream = new MemoryStream(EncryptedData);
                    //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                    Byte[] PlainText = new byte[EncryptedData.Length];
                    Int32 DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                    memoryStream.Close();
                    cryptoStream.Close();
                    //Converting to string
                    String DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                    return DecryptedData;
                }
                return String.Empty;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
            finally
            {
                // Clear the RijndaelManaged object. 
                if (RijndaelCipher != null)
                    RijndaelCipher.Clear();
            }
        }

        /// <summary>
        /// Validate string and return true if string is valid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean IsValidString(String value)
        {
            Boolean result = true;
            String validChars = CustomMessages.VALID_CHARS;
            Char[] charArray = value.ToCharArray();
            for (Int16 i = 0; i < value.Length; i++)
            {
                if (validChars.IndexOf(charArray[i]) < 0 || validChars.IndexOf(charArray[i]) > validChars.Length)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        #endregion
    }

    /// <summary>
    /// CustomMessage class contains all the custom messages
    /// </summary>
    public static class CustomMessages
    {  
        public static String SUCCESS = String.Empty;
        public static String VALID_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.!@#%^*_-/";
        public static String INVALID_CHARS = "Field(s) contains invalid characters, please correct and try again.";
        public static String MANDATORY_FIELDS = "Please fill in all mandatory fields.";
        public static String USER_ALREADY_EXISTS(String value)
        {
            return "An account already exists with " + value;
        }
        public static String USER_DOESNOT_EXIST = "Account does not exist. Please signup <label class=\"login_link\" title=\"Click here to signup for new account\" onclick=\"loadusercontrol('dynamicControl', 'Signup');\">here</label>.";
        public static String USER_CRED_INCORRECT = "Username or password entered is incorrect.";
        public static String ACCOUNT_INSERT_SUCCESS(String value)
        {
            return "Your account has been successfully created and an activation link is mailed to your email. Please click on the link to activate your account. Your email : " + value;
        }
        public static String ACCOUNT_INSERT_FALIED(String value)
        {
            return "Account creation failed for " + value;
        }
        public static String InActive = "Your account is currently inactive.";
        public static String Deleted = "Your account doesnot exist or has been deleted.";
        public static String Pending = "Your account is yet to be approved by adminstrator.";
        public static String INVALID_SERVICE_REQUEST = "Invalid service request.";
        public static String INVALID_CAPTCHA = "Incorrect verification code.";

        //Used in SP_Activate_Account
        public static String ACTIVATION_LINK_INVALID = "Invalid confirmation code. Please check the verification code message we sent you and click the link in the message. If you cannot find the email containing your verification code, click the Re-send Verification Code link below.";
        public static String ACTIVATION_LINK_STATUS_ACTIVE = "Your account has already been activated, please log in. If you have any questions, please contact us.";

        public static String UNKNOWN_ERROR = "Operation failed. Please contact administrator.";

        public static String INFO_SUCESS = "Information saved successfully.";
        public static String INFO_FAILED = "Failed to save information. Please contact administrator.";
        public static String INSERT_SUCESS = "Record inserted successfully.";
        public static String INSERT_FAILED = "Failed to insert record. Please contact administrator.";
        public static String UPDATE_SUCESS = "Record updated successfully.";
        public static String UPDATE_FAILED = "Failed to update record. Please contact administrator.";
        public static String DELETE_SUCESS = "Record deleted successfully.";
        public static String DELETE_FAILED = "Failed to delete record. Please contact administrator.";        
        public static String DUPLICATE(String table, String column)
        {
            return table + " with this " + column + " already exists. Please try a different " + column + ".";
        }
        
    }
}
