using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class ShortDateJsonConverterTest
    {
        public static IEnumerable<object[]> WriteJsonData => new[]
        {
            new object[] { new DateTimeOffset(2014, 1, 10, 0, 0, 0, new TimeSpan(0)), "20140110" },
            new object[] { null, "null" }
        };
        
        [Theory]
        [MemberData(nameof(WriteJsonData))]
        public void WriuteJson(DateTimeOffset? value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new ShortDateJsonConverter()).Trim('"');

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new ShortDateJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new ShortDateJsonConverter().CanRead);
        }
    }
}
