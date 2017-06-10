using System;
using System.Reflection;
using Newtonsoft.Json;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Converters
{
    internal class BoxCoordinatesJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var boxCoordinates = (BoxCoordinates) value;
            writer.WriteRawValue($"{boxCoordinates.LatitudeSouthWest},{boxCoordinates.LongitudeSouthWest},{boxCoordinates.LatitudeNorthEast},{boxCoordinates.LongitudeNorthEast}");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(BoxCoordinates) ||
                objectType.GetTypeInfo().BaseType == typeof(BoxCoordinates);
        }

        public override bool CanRead => false;
    }
}
