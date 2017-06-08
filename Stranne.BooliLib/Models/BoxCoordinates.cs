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
    }
}