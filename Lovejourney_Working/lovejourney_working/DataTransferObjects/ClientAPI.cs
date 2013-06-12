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
    /// clientAPI class contains the common properties that store the list of providers associated with client
    /// </summary>
    [Serializable]
    public class clientAPI
    {
        /// <summary>
        /// indicates clientid
        /// </summary>
        public Int32 clientId
        {
            get;
            set;
        }

        /// <summary>
        /// indicates providerid
        /// </summary>
        public Int32 providerId
        {
            get;
            set;
        }
    
        /// <summary>
        /// indicates provider api url
        /// </summary>
        public String url
        {
            get;
            set;
        }
      
        /// <summary>
        /// indicates provider api key
        /// </summary>
        public String apiKey
        {
            get;
            set;
        }

        /// <summary>
        /// indicates provider api secret
        /// </summary>
        public String apiSecret
        {
            get;
            set;
        }        
    }

    /// <summary>
    /// clientAPIList is the list of clientAPI
    /// </summary>
    [Serializable]
    public sealed class clientAPIList : List<clientAPI>
    {
        public clientAPIList()
        { }
    }
}