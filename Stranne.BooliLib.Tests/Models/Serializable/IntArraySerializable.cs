using System;
using System.Linq;
using Stranne.BooliLib.Tests.Models.Serializable.Interfaces;
using Xunit.Abstractions;

namespace Stranne.BooliLib.Tests.Models.Serializable
{
    public class IntArraySerializable : ISerializableValue, IXunitSerializable
    {
        private int[] _value;

        public IntArraySerializable()
        {
        }

        public IntArraySerializable(int[] value)
        {
            _value = value;
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            _value = info.GetValue<string>("Value")
                .TrimStart('[')
                .TrimEnd(']')
                .Split(',')
                .Select(value => Convert.ToInt32(value))
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
