using Managers.Implementations;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core.UAD;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {

        private readonly ILoggingManager _loggingManager;
        public LoggingController(ILoggingManager logManager)
        {
            _loggingManager = logManager;
        }
        
        // POST api/<LoggingController>/viewId/token
        [HttpPost]
        public async Task<IActionResult> GetUADAsync(int viewId, string token)
        {
            var result = await _loggingManager.LogDataAsync(viewId, token);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
