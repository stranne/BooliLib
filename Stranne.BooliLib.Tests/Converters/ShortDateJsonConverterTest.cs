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
            new object[] { new DateTime(2014, 1, 10), "20140110" }
        };


        [Theory]
        [MemberData(nameof(WriteJsonData))]
        public void WriuteJson(DateTime value, string expected)
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
