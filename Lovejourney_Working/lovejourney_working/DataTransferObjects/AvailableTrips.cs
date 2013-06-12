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
    /// TripDetails class contains the common properties that store the details of AvailableTrips
    /// </summary>
    public class TripDetails
    {
        #region Constructor

        public TripDetails()
        {
        }

        #endregion

        #region Public Properties

        public String availableSeats
        {
            get;
            set;
        }

        public String arrivalTime
        {
            get;
            set;
        }

        public BoardingDroppingPoints boardingTimes
        {
            get;
            set;
        }

        public String busType
        {
            get;
            set;
        }

        public String cancellationPolicy
        {
            get;
            set;
        }

        public String departureTime
        {
            get;
            set;
        }

        public int destinationId
        {
            get;
            set;
        }

        public String duration
        {
            get;
            set;
        }

        public BoardingDroppingPoints droppingTimes
        {
            get;
            set;
        }

        public String fares
        {
            get;
            set;
        }

        public String id
        {
            get;
            set;
        }

        public String providerName
        {
            get;
            set;
        }
        
        public String partialCancellationAllowed
        {
            get;
            set;
        }

        public int sourceId
        {
            get;
            set;
        }

        public String travels
        {
            get;
            set;
        }
        public String SeatLayoutId
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// AvailableTrips is the list of TripDetails
    /// </summary>
    public sealed class AvailableTrips1 : TripDetails
    {
        public AvailableTrips1()
        { }
    }
    public sealed class  AvailableTrips : List<TripDetails>
    {
        public AvailableTrips()
        { }
    }
    
    /// <summary>
    /// BoardingDroppingDetails class contains the common properties that store the details of boarding and dropping points
    /// </summary>
    public class BoardingDroppingDetails
    {
        #region Constructor

        public BoardingDroppingDetails()
        {
        }

        public BoardingDroppingDetails(String pid, String loc, String timing)
        {   
            pointId = pid;         
            location = loc;
            time = timing;
        }

        public BoardingDroppingDetails(String addr, String contactnos, String contactpersons, String pid, String landmrk, String loc, String pointname, String timing)
        {
            address = addr;
            contactNumbers = contactnos;
            contactPersons = contactpersons;
            pointId = pid;
            landmark = landmrk;
            location = loc;
            name = pointname;
            time = timing;
        }
        #endregion

        #region Public Properties

        public String address
        {
            get;
            set;
        }

        public String contactNumbers
        {
            get;
            set;
        }

        public String contactPersons
        {
            get;
            set;
        }

        public String pointId
        {
            get;
            set;
        }

        public String landmark
        {
            get;
            set;
        }

        public String location
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public String time
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// BoardingDroppingPoints is the list of BoardingDroppingDetails
    /// </summary>
    public sealed class BoardingDroppingPoints : List<BoardingDroppingDetails>
    {
        public BoardingDroppingPoints()
        { }
    }
}
