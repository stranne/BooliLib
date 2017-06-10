using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Location result.
    /// </summary>
    public class LocationResult
    {
        /// <summary>
        /// Gets or sets position.
        /// </summary>
        public PositionResult Position { get; set; }

        /// <summary>
        /// Gets or sets named areas.
        /// </summary>
        public IEnumerable<string> NamedAreas { get; set; }

        /// <summary>
        ///  Gets or sets address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets distance.
        /// </summary>
        public Distance Distance { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Distance == null) Distance = new Distance();
        }
    }
}