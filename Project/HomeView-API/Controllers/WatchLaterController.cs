using Microsoft.AspNetCore.Mvc;
using Features.WatchLater;
using Managers.Contracts;

namespace HomeView_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WatchLaterController : ControllerBase
    {
        private readonly IWatchLaterManager _watchLaterManager;

        public WatchLaterController(IWatchLaterManager watchLaterManager)
        {
            _watchLaterManager = watchLaterManager;
        }

        [HttpPost("watchlater/{email}/{title}/{year}")]
        public ActionResult<bool> AddToWatchLater(string email, string title, string year)
        {
            bool result = _watchLaterManager.AddToWatchLater(email, title, year);

            if (!result)
            {
                return BadRequest("Error inserting into database. Please check logs");
            }

            return Ok($"{title} ({year}) successfully added");
        }

        [HttpDelete("watchlater/delete/{email}/{title}/{year}")]
        public ActionResult<bool> RemoveFromList(string email, string title, string year)
        {
            bool result = _watchLaterManager.RemoveFromList(email, title, year);

            if (!result)
            {
                return BadRequest($"Error removing {title} ({year}). Please check logs");
            }

            return Ok($"{title} ({year}) successfully removed");
        }

        [HttpGet("watchlater/{email}")]
        public ActionResult<IEnumerable<WatchLaterTitle>> GetList(string email)
        {
            var result = _watchLaterManager.GetList(email);

            return Ok(result);
        }
    }
}
