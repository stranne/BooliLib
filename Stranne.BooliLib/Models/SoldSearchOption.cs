using System;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Sold search option
    /// </summary>
    public class SoldSearchOption : BaseObjectSearchOptions
    {
        /// <summary>
        /// Gets or sets minimum sold price.
        /// </summary>
        public double? MinSoldPrice { get; set; }

        /// <summary>
        /// Gets or sets maximum sold price.
        /// </summary>
        public double? MaxSoldPrice { get; set; }

        /// <summary>
        /// Gets or sets minimal sold square meter price.
        /// </summary>
        public double? MinSoldSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets maximum sold square meter price.
        /// </summary>
        public double? MaxSoldSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets minimum sold date.
        /// </summary>
        public DateTimeOffset? MinSoldDate { get; set; }

        /// <summary>
        /// Gets or sets maximum sold date.
        /// </summary>
        public DateTimeOffset? MaxSoldDate { get; set; }
    }
}