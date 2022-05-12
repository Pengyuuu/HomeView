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
