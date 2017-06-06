using System;
using System.Linq;
using System.Threading.Tasks;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Services;

namespace Stranne.BooliLib
{
    public class BooliService : IBooliService, IDisposable
    {
        internal readonly BaseService BaseService;

        public BooliService(string callerId, string key)
        {
            BaseService = new BaseService(callerId, key);
        }

        public async Task<ListedObject> GetListedAsync(int booliId)
        {
            var listingsRoot = await BaseService.GetAsync<ListingsRoot>("listings", booliId);
            return listingsRoot.Listings.FirstOrDefault();
        }

        public ListedObject GetListed(int booliId)
        {
            return GetListedAsync(booliId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            BaseService.Dispose();
        }
    }
}
