using System.Collections.Generic;

namespace Stranne.BooliLib.ApiModels
{
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
    }
}