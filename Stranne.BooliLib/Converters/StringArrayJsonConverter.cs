using System;
using System.Linq;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Converters
{
    internal class StringArrayJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stringArray = (string[]) value;
            stringArray = stringArray.Select(str => str.ToLower()).ToArray();
            writer.WriteRawValue(string.Join(",", stringArray));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string[]);
        }

        public override bool CanRead => false;
    }
}
