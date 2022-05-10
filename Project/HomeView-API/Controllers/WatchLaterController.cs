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

        // Use object as parameter
        // Code for many
        [HttpPost("/{title}/{year}")]
        public async void AddToWatchLaterAsync(string email, string title, string year)
        {
            // isSucceeded better name
            bool result = await _watchLaterManager.AddToWatchLaterAsync(email, title, year);

            if (!result)
            {
                // Other reasosn for failure
                BadRequest("Error inserting into database. Please check logs");
            }

            Ok($"{title} ({year}) successfully added");
        }

        [HttpDelete("delete/{email}/{title}/{year}")]
        public async void RemoveFromListAsync(string email, string title, string year)
        {
            bool result = await _watchLaterManager.RemoveFromListAsync(email, title, year);

            if (!result)
            {
                BadRequest($"Error removing {title} ({year}). Please check logs");
            }

            Ok($"{title} ({year}) successfully removed");
        }

        [HttpGet("{email}")]
        public async Task<IEnumerable<WatchLaterTitle>> GetListAsync(string email)
        {
            var result = await _watchLaterManager.GetListAsync(email);

            return result;
        }
    }
}
