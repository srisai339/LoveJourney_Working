using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Globalization;

namespace LJ.CLB.DTO
{
    public class BlockSeats
    {
        #region Constructor

        public BlockSeats()
        {
        }

        #endregion

        #region Public Properties

        public string TripId { get; set; }
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public string JourneyDate { get; set; }
        public string BoardingId { get; set; }
        public int NoOfSeats { get; set; }

        public string SeatNo { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

        public string BookingRefNo { get; set; }
        public string IdCardType { get; set; }
        public string IdCardNo { get; set; }
        public string IdCardIssuedBy { get; set; }
        public string MobileNo { get; set; }
        public string EmergencyMobileNo { get; set; }
        public string EmailId { get; set; }
        public string ProviderName { get; set; }

        public string BookingId { get; set; }
        

        #endregion
    }
}
