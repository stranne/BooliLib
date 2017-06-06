using System;

namespace Stranne.BooliLib.Extension
{
    internal static class DateTimeOffsetExtension
    {
        private const string TimeZoneName = "W. Europe Standard Time";

        public static DateTimeOffset ConvertToBooliTimeZone(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.ConvertTime(dateTimeOffset, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName));
        }

        public static DateTimeOffset AddBooliTimeSpan(this DateTimeOffset dateTimeOffset)
        {
            var timeOffset = dateTimeOffset.GetBooliTimeOffset();
            return new DateTimeOffset(dateTimeOffset.DateTime, timeOffset);
        }

        public static TimeSpan GetBooliTimeOffset(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName).GetUtcOffset(dateTimeOffset);
        }
    }
}
