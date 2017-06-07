using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Converters;

namespace Stranne.BooliLib.ApiModels
{
    /// <summary>
    /// Base result
    /// </summary>
    public abstract class BaseResult : IBooliId
    {
        /// <summary>
        /// Booli id
        /// </summary>
        public int BooliId { get; set; }

        /// <summary>
        /// List price
        /// </summary>
        public double ListPrice { get; set; }

        /// <summary>
        /// Published date
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset Published { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public LocationResult Location { get; set; }

        /// <summary>
        /// Object type
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Estate agent
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Rooms
        /// </summary>
        public float? Rooms { get; set; }

        /// <summary>
        /// Living area
        /// </summary>
        public float? LivingArea { get; set; }

        /// <summary>
        /// Additional area
        /// </summary>
        public float? AdditionalArea { get; set; }

        /// <summary>
        /// Rent
        /// </summary>
        public float? Rent { get; set; }

        /// <summary>
        /// Floor
        /// </summary>
        public float? Floor { get; set; }

        /// <summary>
        /// Apartment number
        /// </summary>
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// Plot area
        /// </summary>
        public int? PlotArea { get; set; } // TODO test (check also on sold) (double check type)

        /// <summary>
        /// Construction year
        /// </summary>
        public int? ConstructionYear { get; set; }

        /// <summary>
        /// Is a new construction
        /// </summary>
        public bool? IsNewConstruction { get; set; } // TODO test (check also on sold)

        /// <summary>
        /// Booli url
        /// </summary>
        public string Url { get; set; }
    }
}