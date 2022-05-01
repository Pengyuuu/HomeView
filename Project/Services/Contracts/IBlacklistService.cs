using Features.Blacklist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBlacklistService
    {
        Task<IEnumerable<Blacklist>> AddToBlacklistAsync(Blacklist blacklistItem);
        Task<IEnumerable<Blacklist>> RemoveFromBlacklistAsync(Blacklist blacklistItem);
        Task<IEnumerable<Blacklist>> GetBlacklistAsync(Blacklist selectedUser);
        Task<Blacklist> UpdateToggleBlacklistAsync(Blacklist selectedUser);
        Task<Blacklist> GetBlacklistToggleAsync(Blacklist selectedUser);
    }
}
