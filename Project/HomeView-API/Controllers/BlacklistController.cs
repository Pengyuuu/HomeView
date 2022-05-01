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

        // POST blacklist
        [HttpPost]
        public async ActionResult<bool> PostBlacklist(string dispName, string blacklistItem)
        {

        }
        // DELETE from blacklist
        [HttpDelete]
        public async ActionResult<bool> Delete(string dispName, string blacklistItem)
        {

        }
        // GET 
        [HttpGet]
        public async ActionResult<IEnumerable<string>> GetBlacklist(string dispName)
        {

        }
        // GET api/<BlacklistController>
        [HttpGet]
        public async ActionResult<bool> GetToggle(string dispName)
        {

        }

        // POST blacklist toggle
        [HttpPost]
        public async ActionResult<bool> PostToggle(string dispName, bool userToggle)
        {

        }
    }
}
