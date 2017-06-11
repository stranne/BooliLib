using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Tests.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class BoxCoordinatesJsonConverterTest
    {
        public static TheoryData WriteJsonMemberData => new TheoryData<BoxCoordinatesSerializable, string>
        {
            { new BoxCoordinatesSerializable(1, 2, 3, 4), "1,2,3,4" }
        };

        [Theory]
        [MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(BoxCoordinatesSerializable value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new BoxCoordinatesJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new BoxCoordinatesJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new BoxCoordinatesJsonConverter().CanRead);
        }
    }
}
