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
    /// travelOperator class contains the common properties that store the details of operator
    /// </summary>
    [Serializable]
    public class travelOperator
    {
        /// <summary>
        /// unique id generated for every operator
        /// </summary>
        public Int32 operatorId
        {
            get;
            set;
        }

        /// <summary>
        /// provider id associated with every operator
        /// </summary>
        public Int32 providerId
        {
            get;
            set;
        }

        /// <summary>
        /// operator name
        /// </summary>
        public String operatorName
        {
            get;
            set;
        }

        //status of operator
        public Status operatorStatus
        {
            get;
            set;
        }
    }

    /// <summary>
    /// travelOperatorList is the list of travelOperators
    /// </summary>
    [Serializable]
    public sealed class travelOperatorList : List<travelOperator>
    {
        public travelOperatorList()
        { }
    }
}