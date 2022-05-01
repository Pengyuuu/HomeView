using Features.Blacklist;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IBlacklistService
    {
        bool AddToBlacklist(Blacklist blacklistItem);
        bool RemoveFromBlacklist(Blacklist blacklistItem);
        IEnumerable<string> GetBlacklist(Blacklist selectedUser);
        bool UpdateToggleBlacklist(Blacklist selectedUser);
        bool GetBlacklistToggle(Blacklist selectedUser);
    }
}
