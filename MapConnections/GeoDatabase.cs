using System;
using MaxMind.GeoIP;

namespace MapConnections
{
    public static class GeoDatabase
    {
        static readonly string GeoipDb = new Uri(@"Assets\Database\GeoLiteCity.dat", UriKind.Relative).ToString();
        private static LookupService ls = new LookupService(GeoipDb, LookupService.GEOIP_MEMORY_CACHE);
        public static void GetPosition(string ip, out double? longitude, out double? latitude)
        {
            longitude = null;
            latitude = null;
            try
            {
                Location l = ls.getLocation(ip);
                longitude = l?.latitude;
                latitude = l?.longitude;
            }
            catch (System.Exception e)
            {
                Console.Write("Error" + e.Message + "\n");
            }
        }
    }
}
