using System;

namespace DashAPI.Helpers
{
    internal static class CommonHelpers
    {
        public static DateTime FromUnixTime(double unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var result = epoch.AddMilliseconds(unixTime);
            return result;
        }

        public static double ToUnixTime(this DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixTime = dateTime.Subtract(epoch).TotalMilliseconds;
            return unixTime;
        }
    }
}
