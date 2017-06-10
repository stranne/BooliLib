using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class DimensionJsonConverterTest
    {
        public static TheoryData WriteJsonMemberData => new TheoryData<DimensionSerializable, string>
        {
            {new DimensionSerializable(1, 2), "1,2"}
        };

        [Theory]
        [MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(DimensionSerializable value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new DimensionJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new DimensionJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new DimensionJsonConverter().CanRead);
        }
    }
}
