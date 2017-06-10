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
        /// Gets or sets center coordinate.
        /// </summary>
        public Position Center { get; set; }

        /// <summary>
        /// Gets or sets dimension. This property requires Center to be provided or an argument exception will be thrown. Specified in meters.
        /// </summary>
        [JsonProperty("dim")]
        [SerializeDependency(nameof(Center))]
        public Dimension Dimension { get; set; }

        /// <summary>
        /// Gets or sets box coordinates. Used togheter with Center.
        /// </summary>
        [JsonProperty("Bbox")]
        public BoxCoordinates BoxCoordinates { get; set; }

        /// <summary>
        /// Gets or sets area id.
        /// </summary>
        [JsonConverter(typeof(IntArrayJsonConverter))]
        public int[] AreaId { get; set; }

        /// <summary>
        /// Gets or sets lowest price.
        /// </summary>
        public double? MinListPrice { get; set; }

        /// <summary>
        /// Gets or sets highest price.
        /// </summary>
        public double? MaxListPrice { get; set; }

        /// <summary>
        /// Gets or sets lowest square meter price.
        /// </summary>
        public double? MinListSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets highest square meter price.
        /// </summary>
        public double? MaxListSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets lowest number of rooms.
        /// </summary>
        public float? MinRooms { get; set; }

        /// <summary>
        /// Gets or sets highest number of rooms.
        /// </summary>
        public float? MaxRooms { get; set; }

        /// <summary>
        /// Gets or sets highest rent.
        /// </summary>
        public float? MaxRent { get; set; }

        /// <summary>
        /// Gets or sets highest living area.
        /// </summary>
        public float? MinLivingArea { get; set; }

        /// <summary>
        /// Gets or sets highest living area.
        /// </summary>
        public float? MaxLivingArea { get; set; }

        /// <summary>
        /// Gets or sets lowest plot area.
        /// </summary>
        public float? MinPlotArea { get; set; }

        /// <summary>
        /// Gets or sets highest plot area.
        /// </summary>
        public float? MaxPlotArea { get; set; }

        /// <summary>
        /// Gets or sets accommodation types.
        /// </summary>
        public string[] ObjectTypes { get; set; }

        /// <summary>
        /// Gets or sets lowest construction year.
        /// </summary>
        public int? MinConstructionYear { get; set; }

        /// <summary>
        /// Gets or sets highest construction year.
        /// </summary>
        public int? MaxConstructionYear { get; set; }

        /// <summary>
        /// Gets or sets lowest published date.
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MinPublished { get; set; }

        /// <summary>
        /// Gets or sets highest published date.
        /// </summary>
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset? MaxPublished { get; set; }

        /// <summary>
        /// Gets or sets if new construction.
        /// </summary>
        public bool? IsNewConstruction { get; set; }

        /// <summary>
        /// Gets or sets include unset. Controlls if other search options should include accomodations that are missing search options, default true.
        /// </summary>
        public bool? IncludeUnset { get; set; }

        /// <summary>
        /// Gets or sets offset.
        /// </summary>
        public int? Offset { get; set; }
    }
}