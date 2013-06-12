using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusAPILayer.TicketGooseNamespace;

namespace BusAPILayer
{
    public class TicketGooseFactoryManager
    {
        #region TicketGoose APILayer Object
        private static ITicketGooseAPILayer m_TicketGooseAPILayer = null;
        public static ITicketGooseAPILayer GetTicketGooseAPILayerObject()
        {
            if (m_TicketGooseAPILayer == null)
            {
                m_TicketGooseAPILayer = new TicketGooseAPILayer();
            }
            return m_TicketGooseAPILayer;
        }
        #endregion
    }
}
