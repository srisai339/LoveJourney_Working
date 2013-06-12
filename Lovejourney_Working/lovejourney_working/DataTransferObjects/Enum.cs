#region Developer Note
/*
 * Created by       : Satya
 * Created Date     : 15-Dec-2012
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
 
    #region Status
    /// <summary>
    /// Determines the Status of User
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Indicates as Active state
        /// </summary>
        Active = 1,
        /// <summary>
        /// Indicates as InActive state
        /// </summary>
        InActive = 0,
        /// <summary>
        /// Indicates as Deleted state
        /// </summary>
        Deleted = 2,
        /// <summary>
        /// Indicates an unidentified value
        /// </summary>
        NotSet = -1

    }
    #endregion
 
    #region Transaction Type

    /// <summary>
    /// Determines the Type of Transaction being performed
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Indicates as insertion
        /// </summary>
        INSERT = 0,
        /// <summary>
        /// Indicates as updating
        /// </summary>
        UPDATE = 1,
        /// <summary>
        /// Indicates as deletion
        /// </summary>
        DELETE = -1        
    }

    #endregion
}
