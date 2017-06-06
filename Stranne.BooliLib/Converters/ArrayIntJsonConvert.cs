using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Converters
{
    internal class ArrayIntJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var integers = (int[]) value;
            if (integers.Length == 1)
            {
                writer.WriteValue(integers[0]);
            }
            else
            {
                writer.WriteValue(string.Join(",", integers));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return new[] {Convert.ToInt32(reader.Value)};
            }

            return serializer.Deserialize<List<int>>(reader).ToArray();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int[]);
        }
    }
}
