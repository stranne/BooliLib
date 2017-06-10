using System;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Sold object.
    /// </summary>
    public class SoldObject : BaseResult
    {
        /// <summary>
        /// Gets or sets sold date.
        /// </summary>
        public DateTimeOffset SoldDate { get; set; }

        /// <summary>
        /// Gets or sets sold price.
        /// </summary>
        public double SoldPrice { get; set; }
    }
}