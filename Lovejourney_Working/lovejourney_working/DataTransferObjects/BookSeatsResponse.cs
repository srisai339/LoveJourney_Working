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
    /// BookSeatsResponse class contains the common properties that store the details of api response on booking seats
    /// </summary>
    public class BookSeatsResponse
    {
        #region Constructor

        public BookSeatsResponse()
        {
        }

        #endregion

        #region Public Properties

        public String APIPNR
        {
            get;
            set;
        }

        public String Message
        {
            get;
            set;
        }

        public String OperatorPNR
        {
            get;
            set;
        }

        public String Status
        {
            get;
            set;
        }
        public String OperaterNo
        {
            get;
            set;
        }
        public String extraseatinfo
        {
            get;
            set;
        }
       
        #endregion
    }

    /// <summary>
    /// BlockSeatsResponse class contains the common properties that store the details of api response on blocking seats
    /// </summary>
    public class BlockSeatsResponse
    {
        #region Constructor

        public BlockSeatsResponse()
        {
        }

        #endregion

        #region Public Properties

        public String BookingID
        {
            get;
            set;
        }

        public String Message
        {
            get;
            set;
        }

        public String Status
        {
            get;
            set;
        }

        #endregion
    }
}
