using Stranne.BooliLib.Models;
using Xunit.Abstractions;

namespace Stranne.BooliLib.Tests.Models
{
    public class BoxCoordinatesSerializable : BoxCoordinates, IXunitSerializable
    {
        public BoxCoordinatesSerializable()
        {
        }

        public BoxCoordinatesSerializable(
            double latitudeSouthWest,
            double longitudeSouthWest,
            double latitudeNorthEast,
            double longitudeNorthEast)
            : base(
                  latitudeSouthWest,
                  longitudeSouthWest,
                  latitudeNorthEast,
                  longitudeNorthEast)
        {   
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            LatitudeSouthWest = info.GetValue<double>(nameof(LatitudeSouthWest));
            LongitudeSouthWest = info.GetValue<double>(nameof(LongitudeSouthWest));
            LatitudeNorthEast = info.GetValue<double>(nameof(LatitudeNorthEast));
            LongitudeNorthEast = info.GetValue<double>(nameof(LongitudeNorthEast));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(LatitudeSouthWest), LatitudeSouthWest);
            info.AddValue(nameof(LongitudeSouthWest), LongitudeSouthWest);
            info.AddValue(nameof(LatitudeNorthEast), LatitudeNorthEast);
            info.AddValue(nameof(LongitudeNorthEast), LongitudeNorthEast);
        }
    }
}
