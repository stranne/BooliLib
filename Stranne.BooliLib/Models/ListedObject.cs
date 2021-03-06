﻿namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Listed object.
    /// </summary>
    public class ListedObject : BaseResult
    {
        /// <summary>
        /// Gets or sets pageviews. Only populated when getting a specific object with booli id.
        /// </summary>
        public int? Pageviews { get; set; }
    }
}