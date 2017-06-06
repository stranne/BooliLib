using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class DateTimeOffsetJsonConverterTest
    {
        public static IEnumerable<object[]> WriteJsonMemberData => new[]
        {
            new object[] { new DateTimeOffset(2014, 1, 10, 0, 0, 0, new TimeSpan(0)), "20140110" },
            new object[] { null, "null" }
        };
        
        [Theory, MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(DateTimeOffset? value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new DateTimeOffsetJsonConverter());

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ReadJsonMemberData => new[]
        {
            new object[] { @"""2014-01-10 01:06:04""", new DateTimeOffset(2014, 1, 10, 1, 6, 4, new TimeSpan(1, 0, 0)) }
        };

        [Theory, MemberData(nameof(ReadJsonMemberData))]
        public void ReadJson(string json, DateTimeOffset expected)
        {
            var actual = JsonConvert.DeserializeObject<DateTimeOffset>(json, new DateTimeOffsetJsonConverter());

            Assert.Equal(expected, actual);
        }
    }
}
