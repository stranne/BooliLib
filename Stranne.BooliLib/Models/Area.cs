using System.Collections.Generic;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Area.
    /// </summary>
    public class Area : IBooliId
    {
        /// <inheritdoc />
        public int BooliId { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets types.
        /// </summary>
        public IEnumerable<string> Types { get; set; }

        /// <summary>
        /// Gets or sets parent booli id.
        /// </summary>
        public int ParentBooliId { get; set; }

        /// <summary>
        /// Gets or sets parent name.
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// Gets or sets parent types.
        /// </summary>
        public IEnumerable<string> ParentTypes { get; set; }

        /// <summary>
        /// Gets or sets url friendly name.
        /// </summary>
        public string UrlFriendlyName { get; set; }
    }
}