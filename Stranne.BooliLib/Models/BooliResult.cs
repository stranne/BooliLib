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
        /// </summary>
        [JsonProperty("searchParams")]
        public TSearchParameters SearchParameters { get; set; }
    }
}
