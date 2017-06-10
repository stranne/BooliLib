using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Tests.Models.Serializable;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class StringArrayJsonConverterTest
    {
        public static TheoryData WriteJsonMemberData => new TheoryData<StringArraySerializable, string>
        {
            {new StringArraySerializable(new[] { "1" }), "1"},
            {new StringArraySerializable(new[] { "1", "2" }), "1,2"}
        };

        [Theory]
        [MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(StringArraySerializable value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value.GetValue(), new StringArrayJsonConverter());

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new StringArrayJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new StringArrayJsonConverter().CanRead);
        }
    }
}
