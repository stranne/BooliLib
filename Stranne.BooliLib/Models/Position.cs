using System.Globalization;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Position
    /// </summary>
    public class Position
    {
        // TODO add validation?

        /// <summary>
        /// Latitude in WGS84 decimal form
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in WGS84 decimal form
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Create a new position.
        /// </summary>
        public Position()
        { }

        /// <summary>
        /// Create a position with latitude and longitude pre defined.
        /// </summary>
        /// <param name="latitude">Latitude in WGS84 decimal form</param>
        /// <param name="longitude">Longitude in WGS84 decimal form</param>
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Latitude.ToString(new CultureInfo("en-US"))},{Longitude.ToString(new CultureInfo("en-US"))}";
        }
    }
}