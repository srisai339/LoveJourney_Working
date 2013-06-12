
namespace BusAPILayer
{ 
    public class BitlaFactoryManager
    {
        #region Bitla APILayer Object
        private static IBitlaAPILayer m_BitlaAPILayer = null;
        public static IBitlaAPILayer GetBitlaAPILayerObject()
        {
            if (m_BitlaAPILayer == null) 
            {
                m_BitlaAPILayer = new BitlaAPILayer();
            }
            return m_BitlaAPILayer;
        } 
        #endregion
    }
}
