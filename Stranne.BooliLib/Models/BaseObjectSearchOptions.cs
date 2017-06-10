using System;
using Newtonsoft.Json;
using Stranne.BooliLib.Attributes;
using Stranne.BooliLib.Converters;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Base object search options.
    /// </summary>
    public abstract class BaseObjectSearchOptions : BaseSearchOptions
    {
        /// <summary>
        /// Gets or sets center.
        /// </summary>
        public Position Center { get; set; }

        /// <summary>
        /// Gets or sets dimension. This property requires Center to be provided or an argument exception will be thrown.
        /// </summary>
        [JsonProperty("dim")]
        [SerializeDependency(nameof(Center))]
        public Dimension Dimension { get; set; }

        /// <summary>
        /// Gets or sets box coordinates.
        /// </summary>
        [JsonProperty("Bbox")]
        public BoxCoordinates BoxCoordinates { get; set; }

        /// <summary>
        /// Gets or sets area id.
        /// </summary>
        [JsonConverter(typeof(IntArrayJsonConverter))]
        public int[] AreaId { get; set; }

        /// <summary>
        /// Gets or sets minimum list price.
        /// </summary>
        public double? MinListPrice { get; set; }

        /// <summary>
        /// Gets or sets maximum list price.
        /// </summary>
        public double? MaxListPrice { get; set; }

        /// <summary>
        /// Gets or sets minimum list square meter price.
        /// </summary>
        public double? MinListSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets maximum list square meter price.
        /// </summary>
        public double? MaxListSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets minimum number of rooms.
        /// </summary>
        public float? MinRooms { get; set; }

        /// <summary>
        /// Gets or sets maximum number of rooms.
        /// </summary>
        public float? MaxRooms { get; set; }

        /// <summary>
        /// Gets or sets maximum rent.
        /// </summary>
        public float? MaxRent { get; set; }

        /// <summary>
        /// Gets or sets minimum living area.
        /// </summary>
        public float? MinLivingArea { get; set; }

        /// <summary>
        /// Gets or sets maximum living area.
        /// </summary>
        public float? MaxLivingArea { get; set; }

        /// <summary>
        /// Gets or sets minimum plot area.
        /// </summary>
        public float? MinPlotArea { get; set; }

        /// <summary>
        /// Gets or sets maximum plot area.
        /// </summary>
        public float? MaxPlotArea { get; set; }

        /// <summary>
        /// Gets or sets object types.
        /// </summary>
        public string[] ObjectTypes { get; set; }

        /// <summary>
        /// Gets or sets minimum construction year.
        /// </summary>
        public int? MinConstructionYear { get; set; }

        /// <summary>
        /// Gets or sets maximum construction year.
        /// </summary>
        public int? MaxConstructionYear { get; set; }

        /// <summary>
        /// Gets or sets minimum published date.
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MinPublished { get; set; }

        /// <summary>
        /// Gets or sets maximum published date.
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MaxPublished { get; set; }

        /// <summary>
        /// Gets or sets if new construction.
        /// </summary>
        public bool? IsNewConstruction { get; set; }

        /// <summary>
        /// Gets or sets include unset.
        /// </summary>
        public bool? IncludeUnset { get; set; }

        /// <summary>
        /// Gets or sets offset.
        /// </summary>
        public int? Offset { get; set; }
    }
}