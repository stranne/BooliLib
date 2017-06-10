﻿using System;

namespace Stranne.BooliLib.Models
{
    /// <summary>
    /// Sold object
    /// </summary>
    public class SoldObject : BaseResult
    {
        /// <summary>
        /// Sold date
        /// </summary>
        public DateTimeOffset SoldDate { get; set; }

        /// <summary>
        /// Sold price
        /// </summary>
        public double SoldPrice { get; set; }
    }
}