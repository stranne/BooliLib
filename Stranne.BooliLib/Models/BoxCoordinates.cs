namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Box coordinates
    /// </summary>
    public class BoxCoordinates
    {
        /// <summary>
        /// Latitude south west
        /// </summary>
        public double LatitudeSouthWest { get; set; }

        /// <summary>
        /// Longitude south west
        /// </summary>
        public double LongitudeSouthWest { get; set; }

        /// <summary>
        /// Latitude north east
        /// </summary>
        public double LatitudeNorthEast { get; set; }

        /// <summary>
        /// Longitude north east
        /// </summary>
        public double LongitudeNorthEast { get; set; }

        /// <summary>
        /// Create a box coordinate.
        /// </summary>
        public BoxCoordinates()
        {
        }

        /// <summary>
        /// Create a box coordinate.
        /// </summary>
        /// <param name="latitudeSouthWest">Latitude south west</param>
        /// <param name="longitudeSouthWest">Longitude south west</param>
        /// <param name="latitudeNorthEast">Longitude north east</param>
        /// <param name="longitudeNorthEast">Longitude north east</param>
        public BoxCoordinates(
            double latitudeSouthWest,
            double longitudeSouthWest,
            double latitudeNorthEast,
            double longitudeNorthEast)
        {
            LatitudeSouthWest = latitudeSouthWest;
            LongitudeSouthWest = longitudeSouthWest;
            LatitudeNorthEast = latitudeNorthEast;
            LongitudeNorthEast = longitudeNorthEast;
        }
    }
}