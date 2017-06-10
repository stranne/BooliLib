using Stranne.BooliLib.Models;
using Xunit.Abstractions;

namespace Stranne.BooliLib.Tests.Models
{
    public class DimensionSerializable : Dimension, IXunitSerializable
    {
        public DimensionSerializable()
        {
        }

        public DimensionSerializable(int height, int width)
            : base(height, width)
        {
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            Height = info.GetValue<int>(nameof(Height));
            Width = info.GetValue<int>(nameof(Width));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Height), Height);
            info.AddValue(nameof(Width), Width);
        }
    }
}
