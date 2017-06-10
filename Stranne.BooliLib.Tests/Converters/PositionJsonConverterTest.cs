using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Models;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class PositionJsonConverterTest
    {
        public static TheoryData WriteJsonMemberData => new TheoryData<PositionSerializable, string>
        {
            {new PositionSerializable(57, 12), "57,12"}
        };

        [Theory]
        [MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(PositionSerializable value, string expected)
        {
            var actual = JsonConvert.SerializeObject((Position)value, new PositionJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new PositionJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new PositionJsonConverter().CanRead);
        }
    }
}
