using System.Linq;
using Stranne.BooliLib.Tests.Models.Serializable.Interfaces;
using Xunit.Abstractions;

namespace Stranne.BooliLib.Tests.Models.Serializable
{
    public class StringArraySerializable : ISerializableValue, IXunitSerializable
    {
        private string[] _value;

        public StringArraySerializable()
        {
        }

        public StringArraySerializable(string[] value)
        {
            _value = value;
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            _value = info.GetValue<string>("Value")
                .TrimStart('[')
                .TrimEnd(']')
                .Split(',')
                .Select(value => value)
                .ToArray();
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("Value", ToString());
        }

        public object GetValue()
        {
            return _value;
        }

        public override string ToString()
        {
            return $"[{string.Join(",", _value)}";
        }
    }
}
