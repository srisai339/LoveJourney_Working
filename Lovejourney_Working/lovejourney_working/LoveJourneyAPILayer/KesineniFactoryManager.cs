
namespace BusAPILayer
{
    public class KesineniFactoryManager
    {
        #region Kesineni APILayer Object
        private static IKesineniAPILayer m_KesineniAPILayer = null;
        public static IKesineniAPILayer GetKesineniAPILayerObject()
        {
            if (m_KesineniAPILayer == null)
            {
                m_KesineniAPILayer = new KesineniAPILayer();
            }
            return m_KesineniAPILayer; 
        }
        #endregion
    }
}
 