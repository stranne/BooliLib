using Newtonsoft.Json;
using Stranne.BooliLib.Attributes;

namespace Stranne.BooliLib.ApiModels
{
    /// <summary>
    /// Base search options
    /// </summary>
    public abstract class BaseSearchOptions
    {
        /// <summary>
        /// Search query
        /// </summary>
        [BooliBaseSearchOption]
        [JsonProperty("q")]
        public string Query { get; set; }

        /// <summary>
        /// Maximum number of results when returning a list
        /// </summary>
        public int? Limit { get; set; }
    }
}