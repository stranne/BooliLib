using Stranne.BooliLib.Models;
using Xunit.Abstractions;

namespace Stranne.BooliLib.Tests.Models
{
    public class PositionSerializable : Position, IXunitSerializable
    {
        public PositionSerializable()
        {
        }

        public PositionSerializable(double latitude, double longitude)
            : base (latitude, longitude)
        {
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            Latitude = info.GetValue<double>(nameof(Latitude));
            Longitude = info.GetValue<double>(nameof(Longitude));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Latitude), Latitude);
            info.AddValue(nameof(Longitude), Longitude);
        }
    }
}
