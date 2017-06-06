using System;
using System.Linq;
using System.Threading.Tasks;
using Stranne.BooliLib.ApiModels;
using Stranne.BooliLib.Services;

namespace Stranne.BooliLib
{
    public class BooliService : IBooliService, IDisposable
    {
        private readonly BaseService _baseService;

        public BooliService(string callerId, string key)
        {
            _baseService = new BaseService(callerId, key);
        }

        public async Task<ListedObject> GetListedAsync(int booliId)
        {
            var listingsRoot = await _baseService.GetAsync<ListingsRoot>("listings", booliId);
            return listingsRoot.Listings.FirstOrDefault();
        }

        public ListedObject GetListed(int booliId)
        {
            return GetListedAsync(booliId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}
