
namespace HotelAPILayer
{
    public class ArzooHotelFactoryManager
    {
        private static IArzooHotelAPILayer m_ArzooHotelAPILayer = null;
        public static IArzooHotelAPILayer GetArzooHotelAPILayerObject()
        {
            if (m_ArzooHotelAPILayer == null)
            {
                m_ArzooHotelAPILayer = new ArzooHotelAPILayer();
            }
            return m_ArzooHotelAPILayer;
        }
    }
}
