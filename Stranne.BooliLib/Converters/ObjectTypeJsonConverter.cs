using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Converters
{
    internal class ObjectTypeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = reader.Value
                .ToString()
                .Replace("/", "");
            Enum.TryParse(json, out ObjectType ot);
            return ot;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectType);
        }

        public override bool CanWrite => false;
    }
}
