using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Attributes;
using Stranne.BooliLib.Converters;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Base object search options
    /// </summary>
    public abstract class BaseObjectSearchOptions : BaseSearchOptions
    {
        /// <summary>
        /// Center
        /// </summary>
        public Position Center { get; set; }

        /// <summary>
        /// Dimension 
        /// This property requires Center to be provided
        /// or an argument exception will be thrown.
        /// </summary>
        [JsonProperty("dim")]
        [SerializeDependency(nameof(Center))]
        public Dimension Dimension { get; set; }

        /// <summary>
        /// Box
        /// </summary>
        [JsonProperty("Bbox")]
        public BoxCoordinates BoxCoordinates { get; set; }

        /// <summary>
        /// Area id
        /// </summary>
        [JsonConverter(typeof(IntArrayJsonConverter))]
        public int[] AreaId { get; set; }

        /// <summary>
        /// Minimum list price
        /// </summary>
        public double? MinListPrice { get; set; }

        /// <summary>
        /// Maximum list price
        /// </summary>
        public double? MaxListPrice { get; set; }

        /// <summary>
        /// Minimum list square meter price
        /// </summary>
        public double? MinListSqmPrice { get; set; }

        /// <summary>
        /// Maximum list square meter price
        /// </summary>
        public double? MaxListSqmPrice { get; set; }

        /// <summary>
        /// Minimum number of rooms
        /// </summary>
        public float? MinRooms { get; set; }

        /// <summary>
        /// Maximum number of rooms
        /// </summary>
        public float? MaxRooms { get; set; }

        /// <summary>
        /// Maximum rent
        /// </summary>
        public float? MaxRent { get; set; }

        /// <summary>
        /// Minimum living area
        /// </summary>
        public float? MinLivingArea { get; set; }

        /// <summary>
        /// Maximum living area
        /// </summary>
        public float? MaxLivingArea { get; set; }

        /// <summary>
        /// Minimum plot area
        /// </summary>
        public float? MinPlotArea { get; set; }

        /// <summary>
        /// Maximum plot area
        /// </summary>
        public float? MaxPlotArea { get; set; }

        /// <summary>
        /// Object types
        /// </summary>
        public string[] ObjectTypes { get; set; }

        /// <summary>
        /// Minimum construction year
        /// </summary>
        public int? MinConstructionYear { get; set; }

        /// <summary>
        /// Maximum construction year
        /// </summary>
        public int? MaxConstructionYear { get; set; }

        /// <summary>
        /// Minimum published date
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MinPublished { get; set; }

        /// <summary>
        /// Maximum published date
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MaxPublished { get; set; }

        /// <summary>
        /// Include unset
        /// Gets or sets if new construction.
        /// </summary>
        public bool? IsNewConstruction { get; set; }

        /// <summary>
        /// </summary>
        public bool? IncludeUnset { get; set; }

        /// <summary>
        /// Offset
        /// </summary>
        public int? Offset { get; set; }
    }
}