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
    /// Provider class contains the common properties that store the details of provider
    /// </summary>
    [Serializable]
    public class provider
    {
        public provider()
        {}

        public provider(Int32 providerid, String providername, Int16 providerorder, Status providerstatus)
        {
            providerId = providerid;
            providerName = providername;
            providerOrder = providerorder;
            providerStatus = providerstatus;
        }

        /// <summary>
        /// unique id generated for every provider
        /// </summary>
        public Int32 providerId
        {
            get;
            set;
        }

        /// <summary>
        /// provider name
        /// </summary>
        public String providerName
        {
            get;
            set;
        }

        /// <summary>
        /// order in which provider should be called
        /// </summary>
        public Int16 providerOrder
        {
            get;
            set;
        }

        //status of provider
        public Status providerStatus
        {
            get;
            set;
        }
    }

    /// <summary>
    /// providerList is the list of providers
    /// </summary>
    [Serializable]
    public sealed class providerList : List<provider>
    {
        public providerList()
        { }
    }
}