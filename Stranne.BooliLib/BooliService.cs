using System;
using System.Threading.Tasks;
using Stranne.BooliLib.Helpers;
using Stranne.BooliLib.Models;
using Stranne.BooliLib.Services;

namespace Stranne.BooliLib
{
    /// <summary>
    /// A service to access information from Booli's Api.
    /// </summary>
    public class BooliService : IBooliService, IDisposable
    {
        internal readonly BaseService BaseService;

        /// <summary>
        /// Creates a new Booli service instance.
        /// </summary>
        /// <param name="callerId">Caller id provided by Booli.</param>
        /// <param name="key">Kep provided by Booli.</param>
        public BooliService(string callerId, string key)
        {
            BaseService = new BaseService(callerId, key);
        }

        /// <inheritdoc />
        public async Task<ListedObject> GetListedAsync(int booliId)
        {
            return await BaseService.GetAsync<ListedObject>("listings", booliId);
        }

        /// <inheritdoc />
        public ListedObject GetListed(int booliId)
        {
            return GetListedAsync(booliId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<BooliResult<ListedObject, ListedSearchOption>> GetListedAsync(ListedSearchOption searchOptions)
        {
            return await BaseService.GetAsync<ListedObject, ListedSearchOption>("listings", searchOptions);
        }

        /// <inheritdoc />
        public BooliResult<ListedObject, ListedSearchOption> GetListed(ListedSearchOption searchOptions)
        {
            return GetListedAsync(searchOptions).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<SoldObject> GetSoldAsync(int booliId)
        {
            return await BaseService.GetAsync<SoldObject>("sold", booliId);
        }

        /// <inheritdoc />
        public SoldObject GetSold(int booliId)
        {
            return GetSoldAsync(booliId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<BooliResult<SoldObject, SoldSearchOption>> GetSoldAsync(SoldSearchOption searchOptions)
        {
            return await BaseService.GetAsync<SoldObject, SoldSearchOption>("sold", searchOptions);
        }

        /// <inheritdoc />
        public BooliResult<SoldObject, SoldSearchOption> GetSold(SoldSearchOption searchOptions)
        {
            return GetSoldAsync(searchOptions).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<BooliResult<Area, AreaSearchOption>> GetAreaAsync(AreaSearchOption searchOptions)
        {
            return await BaseService.GetAsync<Area, AreaSearchOption>("areas", searchOptions);
        }

        /// <inheritdoc />
        public BooliResult<Area, AreaSearchOption> GetArea(AreaSearchOption searchOptions)
        {
            return GetAreaAsync(searchOptions).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public string GetThumbnailUrl(int booliId)
        {
            return ThumbnailUrlHelper.GetThumbnailUrl(booliId);
        }

        /// <inheritdoc />
        public string GetThumbnailUrl(int booliId, float size)
        {
            return ThumbnailUrlHelper.GetThumbnailUrl(booliId, size: size);
        }
        
        /// <inheritdoc />
        public string GetThumbnailUrl(int booliId, int width, int height)
        {
            return ThumbnailUrlHelper.GetThumbnailUrl(booliId, width, height);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            BaseService.Dispose();
        }
    }
}
