#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 9-Jan-2012
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
    /// city class contains the common properties that store the details of city
    /// </summary>
    public class city
    {
        #region Constructor

        public city()
        {}

        public city(int cityId, String cityName)
        {
            id = cityId;
            name = cityName;
        }

        #endregion

        #region Punlic Methods

        /// <summary>
        /// unique id generated for every city
        /// </summary>
        public Int32 id
        {
            get;
            set;
        }
    
        /// <summary>
        /// indicates city name
        /// </summary>
        public String name
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// cities is the list of cities
    /// </summary>    
    public sealed class cities : List<city>
    {
        public cities()
        { }
    }
}