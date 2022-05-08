using Managers.Implementations;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public async Task<IActionResult> GetLogInCountAsync()
        {
            var result = await _uadManager.GetLogInCountAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<NewsController>/id
        /*
         * use IActionResult, no need to Serialize, framework will handle return type
         * Async must be suffix
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<List<int>>> AsyncGetRegistrationCount()
        {
            var result = await _uadManager.GetLogInCountAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
