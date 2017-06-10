using System;
using Stranne.BooliLib.Helpers;
using Xunit;

namespace Stranne.BooliLib.Tests.Helpers
{
    [Trait("Area", "Helpers")]
    public class ThumbnailUrlHelperTest
    {
        [Theory]
        [InlineData(2338291, null, null, null, "https://api.bcdn.se/cache/primary_2338291_140x94.jpg")]
        [InlineData(2338291, 1400, 940, null, "https://api.bcdn.se/cache/primary_2338291_1400x940.jpg")]
        [InlineData(2338291, null, null, 0.5f, "https://api.bcdn.se/cache/primary_2338291_70x47.jpg")]
        [InlineData(2338291, null, null, 10f, "https://api.bcdn.se/cache/primary_2338291_1400x940.jpg")]
        public void GetThumbnail(int booliId, int? width, int? height, float? size, string expected)
        {
            var actual = ThumbnailUrlHelper.GetThumbnailUrl(booliId, width, height, size);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetThumbnailWidthNegative()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ThumbnailUrlHelper.GetThumbnailUrl(1, -1, 1));

            Assert.Equal("width", exception.ParamName);
            Assert.Equal(-1, exception.ActualValue);
            Assert.Equal("Can't be a negative number\r\nParameter name: width\r\nActual value was -1.", exception.Message);
        }

        [Fact]
        public void GetThumbnailHeightNegative()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ThumbnailUrlHelper.GetThumbnailUrl(1, 1, -1));

            Assert.Equal("height", exception.ParamName);
            Assert.Equal(-1, exception.ActualValue);
            Assert.Equal("Can't be a negative number\r\nParameter name: height\r\nActual value was -1.", exception.Message);
        }

        [Fact]
        public void GetThumbnailSizeNegative()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ThumbnailUrlHelper.GetThumbnailUrl(1, null, null, -1));

            Assert.Equal("size", exception.ParamName);
            Assert.Equal(-1f, exception.ActualValue);
            Assert.Equal("Can't be a negative number\r\nParameter name: size\r\nActual value was -1.", exception.Message);
        }
    }
}
