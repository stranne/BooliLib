using System;
using System.Threading.Tasks;
using Stranne.BooliLib.Helpers;
using Stranne.BooliLib.Models;
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
            return await BaseService.GetAsync<ListedObject>("listings", booliId);
        }

        public ListedObject GetListed(int booliId)
        {
            return GetListedAsync(booliId).GetAwaiter().GetResult();
        }

        public async Task<BooliResult<ListedObject, ListedSearchOption>> GetListedAsync(ListedSearchOption searchOptions)
        {
            return await BaseService.GetAsync<ListedObject, ListedSearchOption>("listings", searchOptions);
        }

        public BooliResult<ListedObject, ListedSearchOption> GetListed(ListedSearchOption searchOption)
        {
            return GetListedAsync(searchOption).GetAwaiter().GetResult();
        }

        public async Task<SoldObject> GetSoldAsync(int booliId)
        {
            return await BaseService.GetAsync<SoldObject>("sold", booliId);
        }

        public SoldObject GetSold(int booliId)
        {
            return GetSoldAsync(booliId).GetAwaiter().GetResult();
        }

        public async Task<BooliResult<SoldObject, SoldSearchOption>> GetSoldAsync(SoldSearchOption searchOption)
        {
            return await BaseService.GetAsync<SoldObject, SoldSearchOption>("sold", searchOption);
        }

        public BooliResult<SoldObject, SoldSearchOption> GetSold(SoldSearchOption searchOption)
        {
            return GetSoldAsync(searchOption).GetAwaiter().GetResult();
        }

        public async Task<BooliResult<Area, AreaSearchOption>> GetAreaAsync(AreaSearchOption searchOption)
        {
            return await BaseService.GetAsync<Area, AreaSearchOption>("areas", searchOption);
        }

        public BooliResult<Area, AreaSearchOption> GetArea(AreaSearchOption searchOption)
        {
            return GetAreaAsync(searchOption).GetAwaiter().GetResult();
        }

        public string GetThumbnailUrl(int booliId)
        {
            return ThumbnailUrlHelper.GetThumbnailUrl(booliId);
        }

        public string GetThumbnailUrl(int booliId, float size)
        {
            return ThumbnailUrlHelper.GetThumbnailUrl(booliId, size: size);
        }


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
