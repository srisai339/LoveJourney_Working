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
    /// BusesSearchFilter class contains the common properties that store the details of bussearch parameters
    /// </summary>
    [Serializable]
    public class BusesSearchFilter
    {
        #region Constructor

        public BusesSearchFilter()
        {
        }

        public BusesSearchFilter(Int32 sourceId, Int32 destinationId, String journeyDate)
        {
            SourceID = sourceId;
            DestinationID = destinationId;
            JourneyDate = journeyDate;
        }

        #endregion

        #region Public Properties

        public Int32 SourceID
        {
            get;
            set;
        }

        public Int32 DestinationID
        {
            get;
            set;
        }

        public String JourneyDate
        {
            get;
            set;
        }
      
        #endregion
    }
}
