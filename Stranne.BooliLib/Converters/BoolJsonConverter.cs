using System;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Converters
{
    internal class BoolJsonConverter : JsonConverter

    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool)value ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(bool) ||
                objectType == typeof(bool?);
        }

        public override bool CanRead => false;
    }
}
