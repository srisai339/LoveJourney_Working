#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 16-Dec-2012
 * Version          : 1.0
 */
#endregion

#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace LJ.CLB.DTO
{
    /// <summary>
    /// ClientAPIDetails class contains the common properties that store the details of client api
    /// </summary>
    [Serializable]
    public class ClientAPIDetails
    {
        #region Constructor

        public ClientAPIDetails()
        {
        }

        #endregion

        #region Public Properties

        public String APIURL
        {
            get;
            set;
        }

        public Int32 ClientID
        {
            get;
            set;
        }

        public String ConsumerKey
        {
            get;
            set;
        }

        public String ConsumerSecret
        {
            get;
            set;
        }

        public String DomainIP
        {
            get;
            set;
        }

        public Int32 ProviderID
        {
            get;
            set;
        }

        public String ProviderName
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// ClientAPIList is the list of ClientAPIDetails
    /// </summary>
    [Serializable]
    public sealed class ClientAPIList : List<ClientAPIDetails>
    {
        public ClientAPIList()
        { }
    }
}
