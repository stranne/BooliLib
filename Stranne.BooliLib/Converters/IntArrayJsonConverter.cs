using System;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Converters
{
    internal class IntArrayJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var integers = (int[]) value;
            writer.WriteRawValue(integers.Length == 1
                ? integers[0].ToString()
                : string.Join(",", integers));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new[] {Convert.ToInt32(reader.Value)};
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int[]);
        }
    }
}
