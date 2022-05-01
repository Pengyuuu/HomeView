using Features.Blacklist;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IBlacklistManager
    {
        bool IsNull(string name);
        bool IsNull(string dispName, string blacklistItem);
        bool AddToBlacklist (string dispName, string blacklistItem);
        bool RemoveFromBlacklist (string dispName, string blacklistItem);
        IEnumerable<string> GetBlacklist (string dispName);
        bool ToggleBlacklist(string dispName, bool blacklistToggle);
        bool GetBlacklistToggle (string dispName);

    }
}
