using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.BooliLib.Models;

namespace Stranne.BooliLib.Examples.Api.Controllers
{
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        private readonly IBooliService _booliService;

        public AreaController(IBooliService booliService)
        {
            _booliService = booliService;
        }

        // GET api/area
        [HttpGet]
        [Produces(typeof(IEnumerable<Area>))]
        public async Task<IActionResult> Get(AreaSearchOption searchOption)
        {
            return Ok(await _booliService.GetAreaAsync(searchOption));
        }
    }
}
