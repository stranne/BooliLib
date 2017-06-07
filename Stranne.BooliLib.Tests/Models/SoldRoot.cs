using System.Collections;
using System.Collections.Generic;
using Stranne.BooliLib.ApiModels;

namespace Stranne.BooliLib.Tests.Models
{
    public class SoldRoot
    {
        public IEnumerable<SoldObject> Sold { get; set; }
    }
}
