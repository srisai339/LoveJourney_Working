using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilghtsAPILayer
{
   public class FlightsFactoryManager
    {
        #region Kallada APILayer Object
       private static IFlightsAPILayer m_FilghtsAPILayer = null;
       public static IFlightsAPILayer GetFlightsAPILayerObject()
        {
            if (m_FilghtsAPILayer == null)
            {
                m_FilghtsAPILayer = new FlightsAPILayer();
            }
            return m_FilghtsAPILayer;
        }
        #endregion
    }
}
