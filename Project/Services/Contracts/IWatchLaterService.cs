using System.Collections.Generic;
using System.Threading.Tasks;
using Features.WatchLater;

namespace Services.Contracts
{
    public interface IWatchLaterService
    {
        Task<bool> AddToWatchLaterAsync(WatchLaterTitle selectedTitle);

        Task<bool> RemoveFromListAsync(WatchLaterTitle selectedTitle);

        Task<IEnumerable<WatchLaterTitle>> GetListAsync(string userEmail);
    }
}
