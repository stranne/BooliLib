using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Booli list result
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    /// <typeparam name="TSearchParameters">Search parameter type</typeparam>
    public class BooliResult<TResult, TSearchParameters>
        where TResult : IBooliId
    {
        /// <summary>
        /// Result
        /// </summary>
        public IEnumerable<TResult> Result { get; set; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Limit
        /// Maximum value allowed is 500
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Offset
        /// Not given when acquiring areas
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Search parameters
        /// These are not nessesarily the same that where sent in but a parsed version.
        /// If you use a search option with query, this will contain area id that the query matched with while query property is null.
        /// </summary>
        [JsonProperty("searchParams")]
        public TSearchParameters SearchParameters { get; set; }
    }
}
