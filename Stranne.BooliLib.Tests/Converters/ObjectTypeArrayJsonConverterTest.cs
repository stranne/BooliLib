using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class ObjectTypeArrayJsonConverterTest
    {
        [Theory]
        [InlineData(new[] { ObjectType.Lägenhet }, "lägenhet")]
        [InlineData(new[] { ObjectType.Lägenhet, ObjectType.TomtMark }, "lägenhet,tomt-mark")]
        [InlineData(new[] { ObjectType.TomtMark }, "tomt-mark")]
        [InlineData(new[] { ObjectType.Fritidshus }, "fritidshus")]
        [InlineData(new[] { ObjectType.Gård }, "gård")]
        [InlineData(new[] { ObjectType.Kedjehus }, "kedjehus")]
        [InlineData(new[] { ObjectType.Parhus }, "parhus")]
        [InlineData(new[] { ObjectType.Radhus }, "radhus")]
        [InlineData(new[] { ObjectType.Villa }, "villa")]
        public void WriteJson(ObjectType[] value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new ObjectTypeArrayJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new ObjectTypeArrayJsonConverter().ReadJson(null, null, null, null));
        }

        [Fact]
        public void CanRead()
        {
            Assert.False(new ObjectTypeArrayJsonConverter().CanRead);
        }
    }
}
