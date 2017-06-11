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

        //[Theory]
        //[InlineData("lägenhet", ObjectType.Lägenhet)]
        //[InlineData("tomt-mark", ObjectType.TomtMark)]
        //[InlineData("fritidshus", ObjectType.Fritidshus)]
        //[InlineData("gård", ObjectType.Gård)]
        //[InlineData("kedjehus", ObjectType.Kedjehus)]
        //[InlineData("parhus", ObjectType.Parhus)]
        //[InlineData("radhus", ObjectType.Radhus)]
        //[InlineData("villa", ObjectType.Villa)]
        //public void ReadJson(string value, ObjectType expected)
        //{
        //    var actual = JsonConvert.DeserializeObject<ObjectType>(value, new ObjectTypeArrayJsonConverter());

        //    Assert.Equal(expected, actual);
        //}

        [Fact]
        public void CanRead()
        {
            Assert.False(new ObjectTypeArrayJsonConverter().CanRead);
        }
    }
}
