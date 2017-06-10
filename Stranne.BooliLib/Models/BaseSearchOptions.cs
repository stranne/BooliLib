using Newtonsoft.Json;
using Stranne.BooliLib.Attributes;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Base search options.
    /// </summary>
    public abstract class BaseSearchOptions
    {
        /// <summary>
        /// Gets or sets search query.
        /// </summary>
        [BooliBaseSearchOption]
        [JsonProperty("q")]
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets maximum number of results when returning a list.
        /// </summary>
        public int? Limit { get; set; }
    }
}