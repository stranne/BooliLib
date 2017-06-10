using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Examples.Api.Controllers
{
    [Route("api/[controller]")]
    public class SoldController : Controller
    {
        private readonly IBooliService _booliService;

        public SoldController(IBooliService booliService)
        {
            _booliService = booliService;
        }

        // GET api/sold
        [HttpGet]
        [Produces(typeof(IEnumerable<SoldObject>))]
        public async Task<IActionResult> Get(SoldSearchOption searchOption)
        {
            return Ok(await _booliService.GetSoldAsync(searchOption));
        }

        // GET api/sold/5
        [HttpGet("{booliId}")]
        [Produces(typeof(SoldObject))]
        public async Task<IActionResult> Get(int booliId)
        {
            return Ok(await _booliService.GetSoldAsync(booliId));
        }
    }
}
