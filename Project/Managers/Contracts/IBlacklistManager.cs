using Features.Blacklist;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IBlacklistManager
    {
        bool AddToBlacklist (string blacklistItem);
        bool RemoveFromBlacklist (string blacklistItem);
        IEnumerable<string> GetBlacklist (string dispName);
        bool ToggleBlacklist(string dispName);


    }
}
