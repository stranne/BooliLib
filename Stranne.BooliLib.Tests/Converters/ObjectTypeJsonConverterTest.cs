using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;
using Stranne.BooliLib.Models;
using Xunit;

namespace Stranne.BooliLib.Tests.Converters
{
    [Trait("Area", "Converters")]
    public class ObjectTypeJsonConverterTest
    {
        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new ObjectTypeJsonConverter().WriteJson(null, null, null));
        }

        [Theory]
        [InlineData(@"""Lägenhet""", ObjectType.Lägenhet)]
        [InlineData(@"""Tomt/Mark""", ObjectType.TomtMark)]
        [InlineData(@"""Fritidshus""", ObjectType.Fritidshus)]
        [InlineData(@"""Gård""", ObjectType.Gård)]
        [InlineData(@"""Kedjehus""", ObjectType.Kedjehus)]
        [InlineData(@"""Parhus""", ObjectType.Parhus)]
        [InlineData(@"""Radhus""", ObjectType.Radhus)]
        [InlineData(@"""Villa""", ObjectType.Villa)]
        public void ReadJson(string value, ObjectType expected)
        {
            var actual = JsonConvert.DeserializeObject<ObjectType>(value, new ObjectTypeJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanWrite()
        {
            Assert.False(new ObjectTypeJsonConverter().CanWrite);
        }
    }
}
