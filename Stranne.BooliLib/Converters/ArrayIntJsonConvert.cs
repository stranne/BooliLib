﻿using System;
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
            return new[] {Convert.ToInt32(reader.Value)};
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int[]);
        }
    }
}
