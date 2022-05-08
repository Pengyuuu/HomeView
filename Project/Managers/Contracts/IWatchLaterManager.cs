using System.Collections.Generic;
using System.Threading.Tasks;
using Features.WatchLater;

namespace Managers.Contracts
{
    public interface IWatchLaterManager
    {
        Task<bool> AddToWatchLaterAsync(string email, string title, string year);

        Task<bool> RemoveFromListAsync(string email, string title, string year);

        Task<IEnumerable<WatchLaterTitle>> GetListAsync(string userEmail);
    }
}
