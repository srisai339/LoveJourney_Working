using System;
using System.Web;
using System.Text;
using BAL;

public static class Common 
{
    public static void AddCache(string key, object value, int hours)
    {
        try
        {
            HttpContext.Current.Cache.Add(key, value, null, DateTime.MaxValue,
                         new TimeSpan(hours, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static object GetCache(string key)
    {
        try
        {
            object obj = HttpContext.Current.Cache.Get(key);
            return obj;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static string GenerateHotelRefNo()
    {
        try
        {
            int minPassSize = 4;
            int maxPassSize = 4;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = "0123456789".ToCharArray();
            int newPassLength = new Random().Next(minPassSize, maxPassSize);
            char character;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < newPassLength; i++)
            {
                character = charArray[rnd.Next(0, (charArray.Length - 1))];
                stringBuilder.Append(character);
            }
            string refno = "LJH" + stringBuilder.ToString();

            ClsBAL objBAL = new ClsBAL();
            string strUniqueId = objBAL.GetUniqueId();
            return refno + strUniqueId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static string GetFlightsReferenceNo(string DomInt)
    {
        try
        {
            int minPassSize = 4; int maxPassSize = 4;
            StringBuilder stringBuilder = new StringBuilder();
            char[] charArray = "0123456789".ToCharArray();
            int newPassLength = new Random().Next(minPassSize, maxPassSize);
            char character;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < newPassLength; i++)
            {
                character = charArray[rnd.Next(0, (charArray.Length - 1))];
                stringBuilder.Append(character);
            }
            //string refno = "MBRS" + stringBuilder.ToString();
            string refno = DomInt + stringBuilder.ToString();

            ClsBAL objBAL = new ClsBAL();
            string strUniqueId = objBAL.GetUniqueId();
            //if (objManabusBAL.CheckManabusRefNoAvailability(refno) == false)
            //{
            //    GenerateManabusRefNo();
            //}
            return refno + strUniqueId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

public class BaseClass
{
    //Code changes  14-Jul-2012
    //Store user search info
    /* 0 - Soruce Id
     * 1 - Dest Id
     * 2 - OnJourneyDate
     * 3 - ReturnJourneyDate
     * 4 - SourceName
     * 5 - DestName
     * 6 - TripType
    */
    public String[] preLoadParams = new String[7];
}