using Stranne.BooliLib.Attributes;

namespace Stranne.BooliLib.ApiModels
{
    /// <summary>
    /// Area search option
    /// </summary>
    public class AreaSearchOption : BaseSearchOptions
    {
        /// <summary>
        /// Position
        /// </summary>
        [BooliBaseSearchOption]
        public Position Position { get; set; }
        
        /// <summary>
        /// Listings
        /// </summary>
        public bool? Listings { get; set; }

        /// <summary>
        /// Transactions
        /// </summary>
        public bool? Transactions { get; set; }

    }
}