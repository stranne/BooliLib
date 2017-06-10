using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Booli list result.
    /// </summary>
    /// <typeparam name="TResult">Result type.</typeparam>
    /// <typeparam name="TSearchParameters">Search parameter type.</typeparam>
    public class BooliResult<TResult, TSearchParameters>
        where TResult : IBooliId
    {
        /// <summary>
        /// Gets or sets result.
        /// </summary>
        public IEnumerable<TResult> Result { get; set; }

        /// <summary>
        /// Gets or sets total count.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets limit. Maximum value allowed is 500.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets offset. Not given when acquiring areas.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets search parameters. These are not nessesarily the same that where sent in but a parsed version. If you use a search option with query, this will contain area id that the query matched with while query property is null.
        /// </summary>
        [JsonProperty("searchParams")]
        public TSearchParameters SearchParameters { get; set; }
    }
}
