using System.Collections.Generic;

namespace Stranne.BooliLib.ApiModels
{
    internal class ListingsRoot
    {
        public IEnumerable<ListedObject> Listings { get; set; }
    }
}
