using System;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Base result.
    /// </summary>
    public abstract class BaseResult : IBooliId
    {
        /// <summary>
        /// Gets or sets booli id.
        /// </summary>
        public int BooliId { get; set; }

        /// <summary>
        /// Gets or sets list price.
        /// </summary>
        public double ListPrice { get; set; }

        /// <summary>
        /// Gets or sets published date.
        /// </summary>
        public DateTimeOffset Published { get; set; }

        /// <summary>
        /// Gets or sets location.
        /// </summary>
        public LocationResult Location { get; set; }

        /// <summary>
        /// Gets or sets object type.
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets estate agent.
        /// </summary>
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets rooms.
        /// </summary>
        public float? Rooms { get; set; }

        /// <summary>
        /// Gets or sets living area.
        /// </summary>
        public float? LivingArea { get; set; }

        /// <summary>
        /// Gets or sets additional area.
        /// </summary>
        public float? AdditionalArea { get; set; }

        /// <summary>
        /// Gets or sets rent.
        /// </summary>
        public float? Rent { get; set; }

        /// <summary>
        /// Gets or sets floor.
        /// </summary>
        public float? Floor { get; set; }

        /// <summary>
        /// Gets or sets apartment number.
        /// </summary>
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// Gets or sets plot area.
        /// </summary>
        public float? PlotArea { get; set; }

        /// <summary>
        /// Gets or sets construction year.
        /// </summary>
        public int? ConstructionYear { get; set; }

        /// <summary>
        /// Gets or sets if a new construction.
        /// </summary>
        public bool? IsNewConstruction { get; set; }

        /// <summary>
        /// Booli url
        /// </summary>
        public string Url { get; set; }
    }
}