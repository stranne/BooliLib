﻿using System.Threading.Tasks;
using Stranne.BooliLib.ApiModels;

namespace Stranne.BooliLib
{
    public interface IBooliService
    {
        Task<ListedObject> GetListedAsync(int booliId);

        ListedObject GetListed(int booliId);

        Task<BooliResult<ListedObject, ListedSearchOption>> GetListedAsync(ListedSearchOption searchOptions);

        BooliResult<ListedObject, ListedSearchOption> GetListed(ListedSearchOption searchOption);
    }
}
