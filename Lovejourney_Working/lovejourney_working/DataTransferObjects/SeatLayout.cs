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
    /// SeatLayout class contains the common properties that store the details of bus seat layout
    /// </summary>   
    public class SeatLayout
    {
        #region Constructor

        public SeatLayout()
        {
        }

        #endregion

        #region Public Properties

        public int column
        {
            get;
            set;
        }

        public String fare
        {
            get;
            set;
        }

        public String isAvailableSeat
        {
            get;
            set;
        }

        public String isLadiesSeat
        {
            get;
            set;
        }

        public int length
        {
            get;
            set;
        }

        public String number
        {
            get;
            set;
        }

        public int row
        {
            get;
            set;
        }

        public int width
        {
            get;
            set;
        }

        public int zIndex
        {
            get;
            set;
        }
      
        public String id
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// Seats is the list of SeatLayout
    /// </summary>    
    public sealed class SeatsInfo
    {
        public SeatsInfo()
        { }

        public String availableSeatsCount
        {
            get;
            set;
        }

        public String availableSeats
        {
            get;
            set;
        }

        //Used to build seat layout in LJ.API.Buses
        public List<SeatLayout> Seats
        {
            get;
            set;
        }

        //Used to build html script using List<SeatLayout> and return string
        public String SeatsScript
        {
            get;
            set;
        }

        public BoardingDroppingPoints boardingTimes
        {
            get;
            set;
        }

        public BoardingDroppingPoints droppingTimes
        {
            get;
            set;
        }

        public String providerName
        {
            get;
            set;
        }
    }   
}
