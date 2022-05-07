using Managers.Contracts;
using Services.Contracts;
using Services.Implementations;
using Features.WatchLater;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class WatchLaterManager : IWatchLaterManager
    {
        private IWatchLaterService _watchLaterService;

        public WatchLaterManager()
        {
            _watchLaterService = new WatchLaterService();
        }

        public async Task<bool> AddToWatchLaterAsync(string email, string title, string year)
        {
            // Creates a WatchLaterTitle with given arguments
            WatchLaterTitle targetTitle = new WatchLaterTitle
            {
                Title = title,
                Year = year,
                Email = email
            };

            // Calls service method
            return await _watchLaterService.AddToWatchLaterAsync(targetTitle);
        }

        public async Task<bool> RemoveFromListAsync(string email, string title, string year)
        {
            // Creates a WatchLaterTitle with given arguments
            WatchLaterTitle targetTitle = new WatchLaterTitle
            {
                Title = title,
                Year = year,
                Email = email,
            };

            // Calls service method
            return await _watchLaterService.RemoveFromListAsync(targetTitle);
        }

        public async Task<IEnumerable<WatchLaterTitle>> GetListAsync(string userEmail)
        {
            // Calls service method
            return await _watchLaterService.GetListAsync(userEmail);
        }
    }
}
