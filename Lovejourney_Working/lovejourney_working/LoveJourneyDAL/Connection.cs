
namespace DAL
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["AppSetting"].ToString();
        }
    }
}
 