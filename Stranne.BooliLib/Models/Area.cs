using System.Collections.Generic;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Area
    /// </summary>
    public class Area : IBooliId
    {
        /// <inheritdoc />
        public int BooliId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Types
        /// </summary>
        public IEnumerable<string> Types { get; set; }

        /// <summary>
        /// Parent booli id
        /// </summary>
        public int ParentBooliId { get; set; }

        /// <summary>
        /// Parent name
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// Parent types
        /// </summary>
        public IEnumerable<string> ParentTypes { get; set; }

        /// <summary>
        /// Url friendly name
        /// </summary>
        public string UrlFriendlyName { get; set; }
    }
}