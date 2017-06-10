using System;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Sold search option
    /// </summary>
    public class SoldSearchOption : BaseObjectSearchOptions
    {
        /// <summary>
        /// Gets or sets lowest sold price.
        /// </summary>
        public double? MinSoldPrice { get; set; }

        /// <summary>
        /// Gets or sets highest sold price.
        /// </summary>
        public double? MaxSoldPrice { get; set; }

        /// <summary>
        /// Gets or sets lowest sold square meter price.
        /// </summary>
        public double? MinSoldSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets highest sold square meter price.
        /// </summary>
        public double? MaxSoldSqmPrice { get; set; }

        /// <summary>
        /// Gets or sets lowest sold date.
        /// </summary>
        public DateTimeOffset? MinSoldDate { get; set; }

        /// <summary>
        /// Gets or sets highest sold date.
        /// </summary>
        public DateTimeOffset? MaxSoldDate { get; set; }
    }
}