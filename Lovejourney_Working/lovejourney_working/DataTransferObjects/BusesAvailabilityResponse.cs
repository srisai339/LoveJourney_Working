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
using System.Net;

#endregion

namespace LJ.CLB.DTO
{
    /// <summary>
    /// BusesAvailabilityResponse class contains the common properties that store the details of availabletrips and resultset
    /// </summary>
    public class BusesAvailabilityResponse
    {
        #region Constructor

        public BusesAvailabilityResponse()
        {
        }

        #endregion

        #region Public Properties

        public AvailableTrips availableTrips
        {
            get;
            set;
        }
       

        public Int32 providersCount
        {
            get;
            set;
        }

        public HttpStatusCode responseStatus
        {
            get;
            set;
        }

        public String message
        {
            get;
            set;
        }
        public BusesAvailabilityResponse ad
        {
            get;
            set;
        }

        #endregion

     
    }
   
       
  

    public sealed class AvailableTripsdetailsresponse : List<BusesAvailabilityResponse>
    {
        public AvailableTripsdetailsresponse()
        { }
    }
}

