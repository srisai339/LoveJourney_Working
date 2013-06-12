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
    /// client class contains the common properties that store the details of client
    /// </summary>
    [Serializable]
    public class client
    {
        /// <summary>
        /// unique id generated for every client
        /// </summary>
        public Int32 clientId
        {
            get;
            set;
        }
    
        /// <summary>
        /// indicates client name
        /// </summary>
        public String clientName
        {
            get;
            set;
        }

        /// <summary>
        /// indicates domain name
        /// </summary>
        public String domainName
        {
            get;
            set;
        }

        /// <summary>
        /// indicates domain ip
        /// </summary>
        public String domainIp
        {
            get;
            set;
        }

        /// <summary>
        /// indicates consumer key
        /// </summary>
        public String consumerKey
        {
            get;
            set;
        }

        /// <summary>
        /// indicates consumer secret
        /// </summary>
        public String consumerSecret
        {
            get;
            set;
        }

        /// <summary>
        /// indicates client color template
        /// </summary>
        public String clientColorTemplate
        {
            get;
            set;
        }

        //status of client
        public Status clientStatus
        {
            get;
            set;
        }
    }

    /// <summary>
    /// clientList is the list of clients
    /// </summary>
    [Serializable]
    public sealed class clientList : List<client>
    {
        public clientList()
        { }
    }
}