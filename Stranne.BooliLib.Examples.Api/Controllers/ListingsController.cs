using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Examples.Api.Controllers
{
    [Route("api/[controller]")]
    public class ListingsController : Controller
    {
        private readonly IBooliService _booliService;

        public ListingsController(IBooliService booliService)
        {
            _booliService = booliService;
        }
        
        // GET api/listings
        [HttpGet]
        [Produces(typeof(IEnumerable<ListedObject>))]
        public async Task<IActionResult> GetAll(ListedSearchOption searchOption)
        {
            return Ok(await _booliService.GetListedAsync(searchOption));
        }

        // GET api/listings/5
        [HttpGet("{booliId}")]
        [Produces(typeof(ListedObject))]
        public async Task<IActionResult> Get(int booliId)
        {
            return Ok(await _booliService.GetListedAsync(booliId));
        }
    }
}
