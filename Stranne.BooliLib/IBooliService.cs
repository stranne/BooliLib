using System.Threading.Tasks;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib
{
    /// <summary>
    /// A service to access information from Booli's Api.
    /// </summary>
    public interface IBooliService
    {
        /// <summary>
        /// Get a single listed object.
        /// </summary>
        /// <param name="booliId">Boolid id.</param>
        /// <returns>Single listed object.</returns>
        Task<ListedObject> GetListedAsync(int booliId);

        /// <summary>
        /// Get a single listed object.
        /// </summary>
        /// <param name="booliId">Boolid id.</param>
        /// <returns>Single listed object.</returns>
        ListedObject GetListed(int booliId);

        /// <summary>
        /// Get matching listed objects.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of mathcing listed objects.</returns>
        Task<BooliResult<ListedObject, ListedSearchOption>> GetListedAsync(ListedSearchOption searchOptions);

        /// <summary>
        /// Get matching listed objects.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of mathcing listed objects.</returns>
        BooliResult<ListedObject, ListedSearchOption> GetListed(ListedSearchOption searchOptions);

        /// <summary>
        /// Get a single sold object.
        /// </summary>
        /// <param name="booliId">Booli id.</param>
        /// <returns>Single sold object.</returns>
        Task<SoldObject> GetSoldAsync(int booliId);

        /// <summary>
        /// Get a single sold object.
        /// </summary>
        /// <param name="booliId">Booli id.</param>
        /// <returns>Single sold object.</returns>
        SoldObject GetSold(int booliId);

        /// <summary>
        /// Get matching sold objects.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of mathcing sold objects.</returns>
        Task<BooliResult<SoldObject, SoldSearchOption>> GetSoldAsync(SoldSearchOption searchOptions);

        /// <summary>
        /// Get matching sold objects.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of mathcing sold objects.</returns>
        BooliResult<SoldObject, SoldSearchOption> GetSold(SoldSearchOption searchOptions);

        /// <summary>
        /// Get matching areas.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of matching areas.</returns>
        Task<BooliResult<Area, AreaSearchOption>> GetAreaAsync(AreaSearchOption searchOptions);

        /// <summary>
        /// Get matching areas.
        /// </summary>
        /// <param name="searchOptions">Search options.</param>
        /// <returns>List of matching areas.</returns>
        BooliResult<Area, AreaSearchOption> GetArea(AreaSearchOption searchOptions);

        /// <summary>
        /// Get thumbnail url with default size of 140x94 pixels.
        /// </summary>
        /// <param name="booliId">Booli id.</param>
        /// <returns>Thumbnail url for booli id.</returns>
        string GetThumbnailUrl(int booliId);

        /// <summary>
        /// Get thumbnail url with a scaled size from default size.
        /// </summary>
        /// <param name="booliId">Booli id.</param>
        /// <param name="size">Scale size.</param>
        /// <returns>Thumbnail url for booli id.</returns>
        string GetThumbnailUrl(int booliId, float size);

        /// <summary>
        /// Get thumbnail url with specified size.
        /// </summary>
        /// <param name="booliId">Booli id.</param>
        /// <param name="width">Width in pixels.</param>
        /// <param name="height">Height in pixels.</param>
        /// <returns>Thumbnail url for booli id.</returns>
        string GetThumbnailUrl(int booliId, int width, int height);
    }
}
