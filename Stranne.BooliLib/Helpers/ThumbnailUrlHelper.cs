using System;

namespace Stranne.BooliLib.Helpers
{
    internal static class ThumbnailUrlHelper
    {
        public static string GetThumbnailUrl(int booliId, int? width = null, int? height = null, float? size = null)
        {
            if (width == null)
            {
                width = 140;
            }
            else if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), width, "Can't be a negative number");
            }

            if (height == null)
            {
                height = 94;
            }
            else if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), height, "Can't be a negative number");
            }

            if (size != null)
            {
                if (size < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(size), size, "Can't be a negative number");
                }

                width = Convert.ToInt32(Math.Round(width.Value * size.Value));
                height = Convert.ToInt32(Math.Round(height.Value * size.Value));
            }

            var absoluteUrl = $"https://api.bcdn.se/cache/primary_{booliId}_{width}x{height}.jpg";
            return absoluteUrl;
        }
    }
}
