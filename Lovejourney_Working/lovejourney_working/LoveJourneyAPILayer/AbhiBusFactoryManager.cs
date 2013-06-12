
namespace BusAPILayer
{
    public class AbhiBusFactoryManager 
    {
        #region AbhiBus APILayer Object
        private static IAbhiBusAPILayer m_AbhiBusAPILayer = null;
        public static IAbhiBusAPILayer GetAbhiBusAPILayerObject()
        {
            if (m_AbhiBusAPILayer == null)
            {
                m_AbhiBusAPILayer = new AbhiBusAPILayer();
            }
            return m_AbhiBusAPILayer;
        }
        #endregion
    }
}
 