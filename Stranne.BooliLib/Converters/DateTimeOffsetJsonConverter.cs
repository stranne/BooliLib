using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Extension;

namespace Stranne.BooliLib.Converters
{
    internal class DateTimeOffsetJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var json = ((DateTimeOffset) value)
                .ConvertToBooliTimeZone()
                .ToString("yyyyMMdd");
            writer.WriteRawValue(json);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = DateTimeOffset.Parse(reader.Value.ToString());
            return data.AddBooliTimeSpan();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }
    }
}
