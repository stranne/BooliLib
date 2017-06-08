using System.Collections;
using System.Threading.Tasks;
using Stranne.BooliLib.ApiModels;

namespace Stranne.BooliLib
{
    public interface IBooliService
    {
        Task<ListedObject> GetListedAsync(int booliId);

        ListedObject GetListed(int booliId);

        Task<BooliResult<ListedObject, ListedSearchOption>> GetListedAsync(ListedSearchOption searchOptions);

        BooliResult<ListedObject, ListedSearchOption> GetListed(ListedSearchOption searchOption);

        Task<SoldObject> GetSoldAsync(int booliId);

        SoldObject GetSold(int booliId);

        Task<BooliResult<SoldObject, SoldSearchOption>> GetSoldAsync(SoldSearchOption searchOption);

        BooliResult<SoldObject, SoldSearchOption> GetSold(SoldSearchOption searchOption);

        Task<BooliResult<Area, AreaSearchOption>> GetAreaAsync(AreaSearchOption searchOption);

        BooliResult<Area, AreaSearchOption> GetArea(AreaSearchOption searchOption);

        string GetThumbnailUrl(int booliId);

        string GetThumbnailUrl(int booliId, float size);

        string GetThumbnailUrl(int booliId, int width, int height);
    }
}
