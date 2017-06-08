using System.Collections;
using System.Collections.Generic;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Tests.Models
{
    public class ListingsRoot
    {
        public IEnumerable<ListedObject> Listings { get; set; }
    }
}
