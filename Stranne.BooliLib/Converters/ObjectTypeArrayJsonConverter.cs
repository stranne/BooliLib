using System;
using System.Linq;
using Newtonsoft.Json;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Converters
{
    internal class ObjectTypeArrayJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectTypes = (ObjectType[]) value;
            var jsons = objectTypes.Select(objectType => objectType
                .ToString()
                .ToLower()
                .Replace("tomtmark", "tomt-mark"));

            writer.WriteRawValue(string.Join(",", jsons));
        }

        public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectType[]);
        }

        public override bool CanRead => false;
    }
}
