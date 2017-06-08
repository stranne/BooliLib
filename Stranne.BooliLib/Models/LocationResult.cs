using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Location result
    /// </summary>
    public class LocationResult
    {
        /// <summary>
        /// Position
        /// </summary>
        public PositionResult Position { get; set; }

        /// <summary>
        /// Named areas
        /// </summary>
        public IEnumerable<string> NamedAreas { get; set; }

        /// <summary>
        ///  Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        public Distance Distance { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Distance == null) Distance = new Distance();
        }
    }
}