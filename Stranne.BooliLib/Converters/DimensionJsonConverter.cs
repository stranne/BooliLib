using System;
using System.Reflection;
using Newtonsoft.Json;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Converters
{
    internal class DimensionJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dimension = (Dimension) value;
            writer.WriteRawValue($"{dimension.Height},{dimension.Width}");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return 
                objectType == typeof(Dimension) ||
                objectType.GetTypeInfo().BaseType == typeof(Dimension);
        }

        public override bool CanRead => false;
    }
}
