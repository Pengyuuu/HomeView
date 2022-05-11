using Managers.Implementations;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core.UAD;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UADController : ControllerBase
    {

        private readonly IUADManager _uadManager;
        public UADController(IUADManager uadManager)
        {
            _uadManager = uadManager;
        }

        // GET api/<NewsController>

        /* adjust endpoint to handle large requests
         * always cap, or partition requests that involve getting all rows from db
         * 
         * pagination - set limit per page and every subsequent "show more" (ie load 20 every time)
         */
        [HttpGet]
        public async Task<ActionResult<UADResponse>> GetUADAsync()
        {
            var result = await _uadManager.GetAllCountsAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
