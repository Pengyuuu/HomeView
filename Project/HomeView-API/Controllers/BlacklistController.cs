using Microsoft.AspNetCore.Mvc;
using Features.Blacklist;
using Managers.Contracts;
using Managers.Implementations;


namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistManager _blacklistManager;

        public BlacklistController(IBlacklistManager blacklistManager)
        {
            _blacklistManager = blacklistManager;
        }

        // IActionResult, framework handles return type

        // POST api/<BlacklistController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return BadRequest("Null value. Could not add to Blacklist.");
            }
            else
            {
                var res = await _blacklistManager.AddToBlacklistAsync(blacklistItem);
                if (res.LastOrDefault() == null)
                {
                    return NotFound("Could not find Blacklist.");
                }
                return Ok("Add " + res.LastOrDefault().blacklistItem + " to Blacklist.");
            }
        }

        // DELETE api/<BlacklistController>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return BadRequest("Null value. Could not remove from Blacklist.");
            }
            else
            {
                var res = await _blacklistManager.RemoveFromBlacklistAsync(blacklistItem);
                if (res.LastOrDefault() == null)
                {
                    return NotFound("Could not find Blacklist. Or no items in Blacklist.");
                }
                return Ok("Removed " + blacklistItem.blacklistItem + " from Blacklist.");
            }
        }

        // GET api/<BlacklistController>/blacklist
        [HttpGet("{selectedUser}")]
        public async Task<IActionResult> GetBlacklist(string selectedUser)
        {
            var res = await _blacklistManager.GetBlacklistAsync(selectedUser);
            if (res.LastOrDefault() == null)
            {
                return NotFound("Could not find Blacklist. Or no items in Blacklist.");
            }
            return Ok(res);
        }
        // GET api/<BlacklistController>/toggle
        [HttpGet("toggle/{selectedUser}")]
        public async Task<IActionResult> GetToggle(string selectedUser)
        {

            var res = await _blacklistManager.GetBlacklistToggleAsync(selectedUser);
            if (res == null)
            {
                return NotFound("Unable to find user.");
            }
            return Ok(res);

        }

        // PUT api/<BlacklistController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Blacklist selectedUser)
        {
            if (selectedUser == null)
            {
                return BadRequest("Null value.");
            }
            else
            {
                var res = await _blacklistManager.UpdateToggleBlacklistAsync(selectedUser);
                if (res == null)
                {
                    return NotFound("Unable to find user.");
                }
                return Ok(res);
            }
        }
        
        
        
    }
}
