using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;
using Features.ActWiki;
using Managers.Contracts;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActWikiController : Controller
    {
        private readonly IActWikiManager _actManager;

        public ActWikiController()
        {
            _actManager = new ActWikiManager();
        }
        [HttpGet]
        public async Task<ActionResult<int>> GetAct(ActWiki act)
        {
            var found = await _actManager.AsyncGetAct(act);
            if(found != null)
            {
                return Ok(found);
            }
            else
            {
                return NotFound(act.ActName);
            }
        }
 
    }
}