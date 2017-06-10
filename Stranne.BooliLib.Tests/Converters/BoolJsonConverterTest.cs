using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class BoolJsonConverterTest
    {
        [Theory]
        [InlineData(true, "1")]
        [InlineData(false, "0")]
        public void WriteJson(bool value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new BoolJsonConverter());

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new BoolJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new BoolJsonConverter().CanRead);
        }
    }
}
