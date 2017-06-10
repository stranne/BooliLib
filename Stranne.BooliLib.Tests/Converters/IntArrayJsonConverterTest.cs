using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Tests.Models.Serializable;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class IntArrayJsonConverterTest
    {
        public static TheoryData WriteJsonMemberData => new TheoryData<IntArraySerializable, string>
        {
            {new IntArraySerializable(new[] {1}), "1"},
            {new IntArraySerializable(new[] {1, 2}), "1,2"}
        };

        [Theory]
        [MemberData(nameof(WriteJsonMemberData))]
        public void WriteJson(IntArraySerializable value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value.GetValue(), new IntArrayJsonConverter());

            Assert.Equal(expected, actual);
        }

        public static TheoryData ReadJsonData => new TheoryData<string, int[]>
        {
            {"1", new[] {1} }
        };

        [Theory]
        [MemberData(nameof(ReadJsonData))]
        public void ReadJson(string value, int[] expected)
        {
            var actual = JsonConvert.DeserializeObject<int[]>(value, new IntArrayJsonConverter());

            Assert.Equal(expected, actual);
        }
    }
}
