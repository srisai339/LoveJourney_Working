
namespace BusAPILayer
{
    public class KalladaFactoryManager
    {
        #region Kallada APILayer Object
        private static IKalladaAPILayer m_KalladaAPILayer = null;
        public static IKalladaAPILayer GetKalladaAPILayerObject()
        {
            if (m_KalladaAPILayer == null)
            {
                m_KalladaAPILayer = new KalladaAPILayer();
            }
            return m_KalladaAPILayer;
        }
        #endregion
    }
}
 