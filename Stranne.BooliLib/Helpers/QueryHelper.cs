using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Stranne.BooliLib.Attributes;
using Stranne.BooliLib.Extension;
using Stranne.BooliLib.Services;

namespace Stranne.BooliLib.Helpers
{
    internal static class QueryHelper
    {
        public static IDictionary<string, string> GetQuery<TSearchOptions>(TSearchOptions searchOptions)
        {
            var properties = typeof(TSearchOptions).GetRuntimeProperties().ToList();
            if (properties
                .Where(prop => prop.GetCustomAttribute<BooliBaseSearchOptionAttribute>() != null)
                .All(prop => GetValue(prop, searchOptions).IsNull()))
            {
                throw new ArgumentException($"Make sure to always specify a value for at least one of the following properties; {string.Join(", ", properties.Where(prop => prop.GetCustomAttribute<BooliBaseSearchOptionAttribute>() != null).Select(prop => prop.Name))}");
            }

            var dictionary = new Dictionary<string, string>();
            
            foreach (var property in properties)
            {
                var propertyValue = GetValue(property, searchOptions);

                if (propertyValue.IsNull())
                {
                    continue;
                }

                var serializeDependency = property.GetCustomAttribute<SerializeDependencyAttribute>();
                if (serializeDependency != null)
                {
                    var dependentProperty = properties.Single(prop => prop.Name == serializeDependency.DependentUpon);

                    if (GetValue(dependentProperty, searchOptions).IsNull())
                    {
                        throw new ArgumentException($"'{dependentProperty.Name}' can't be null since it is dependent by '{property.Name}'");
                    }
                }

                var propertyName = GetName(property);

                dictionary.Add(propertyName, Convert.ToString(propertyValue));
            }

            return dictionary;
        }

        private static object GetValue<TSearchOptions>(PropertyInfo property, TSearchOptions searchOptions)
        {
            var value = property.GetValue(searchOptions);
            if (value == null)
            {
                return null;
            }

            var settings = new BaseService(null, null).JsonSerializerSettings;
            return JsonConvert.SerializeObject(value, settings).Trim('"');
        }

        private static string GetName(MemberInfo property)
        {
            var jsonProperyt = property.GetCustomAttribute<JsonPropertyAttribute>();
            return !string.IsNullOrWhiteSpace(jsonProperyt?.PropertyName)
                ? jsonProperyt.PropertyName.ToCamelCase()
                : property.Name.ToCamelCase();
        }
    }
}
