﻿using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Stranne.BooliLib.Services;
using Stranne.BooliLib.Tests.Helpers;
using Stranne.BooliLib.Tests.Json;
using Xunit;

namespace Stranne.BooliLib.Tests.JsonParsing
{
    public abstract class BaseJsonTest
    {
        protected abstract JsonFile JsonFile { get; }
        private static JsonSerializerSettings JsonSerializerSettings => new BaseService(TestConstants.CallerId, TestConstants.Key).JsonSerializerSettings;

        protected void TestValue<T>(string property, object expected)
        {
            var json = JsonHelper.GetJson(JsonFile);
            var sut = JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);

            var actual = GetValue(sut, property);

            if (actual is IList && expected is int)
            {
                var count = actual.GetType().GetProperty("Count").GetValue(actual);
                Assert.Equal(expected, count);
                return;
            }

            Assert.Equal(expected, actual);
        }

        private static object GetValue(object sut, string property)
        {
            var steps = Regex.Split(property, @"\[|\]\.?|\.")
                .Where(step => !string.IsNullOrWhiteSpace(step));
            var currentProperty = sut;
            foreach (var step in steps)
            {
                if (int.TryParse(step, out int arrayIndex))
                {
                    currentProperty = currentProperty.GetType().GetProperty("Item").GetValue(currentProperty, new object[] { arrayIndex });
                    continue;
                }

                currentProperty = currentProperty.GetType().GetProperty(step, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(currentProperty);
            }

            return currentProperty;
        }
    }
}
