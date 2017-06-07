using System;

namespace Stranne.BooliLib.ApiModels
{
    /// <summary>
    /// Sold search option
    /// </summary>
    public class SoldSearchOption : BaseObjectSearchOptions
    {
        /// <summary>
        /// Minimum sold price
        /// </summary>
        public double? MinSoldPrice { get; set; }

        /// <summary>
        /// Maximum sold price
        /// </summary>
        public double? MaxSoldPrice { get; set; }

        /// <summary>
        /// Minimal sold square meter price
        /// </summary>
        public double? MinSoldSqmPrice { get; set; }

        /// <summary>
        /// Maximum sold square meter price
        /// </summary>
        public double? MaxSoldSqmPrice { get; set; }

        /// <summary>
        /// Minimum sold date
        /// </summary>
        public DateTimeOffset? MinSoldDate { get; set; }

        /// <summary>
        /// Maximum sold date
        /// </summary>
        public DateTimeOffset? MaxSoldDate { get; set; }
    }
}