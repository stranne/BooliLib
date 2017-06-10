using Stranne.BooliLib.Attributes;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Area search option.
    /// </summary>
    public class AreaSearchOption : BaseSearchOptions
    {
        /// <summary>
        /// Gets or sets position.
        /// </summary>
        [BooliBaseSearchOption]
        public Position Position { get; set; }
        
        /// <summary>
        /// Gets or sets listings.
        /// </summary>
        public bool? Listings { get; set; }

        /// <summary>
        /// Gets or sets transactions.
        /// </summary>
        public bool? Transactions { get; set; }

    }
}