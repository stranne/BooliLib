using System;
using System.Reflection;
using Newtonsoft.Json;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Converters
{
    internal class PositionJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var position = (Position) value;
            writer.WriteRawValue($"{position.Latitude},{position.Longitude}");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(Position) ||
                objectType.GetTypeInfo().BaseType == typeof(Position);
        }

        public override bool CanRead => false;
    }
}
