using System.Collections.Generic;
using System.Linq;
using Services.Contracts;
using Features.Blacklist;
using Services.Implementations;
using Managers.Contracts;
using System;

namespace Managers.Implementations
{
    public class BlacklistManager : IBlacklistManager
    {

        private IBlacklistService _blacklistService;
        private ILoggingManager _loggingManager;

        public BlacklistManager()
        {
            _blacklistService = new BlacklistService();
            _loggingManager = new LoggingManager();
        }

        public bool IsNull(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            return false;
        }
        public bool IsNull(string dispName, string blacklistItem)
        {
            if (string.IsNullOrWhiteSpace(dispName) && string.IsNullOrWhiteSpace(blacklistItem))
            {
                return true;
            }
            return false;
        }

        public bool AddToBlacklist(string dispName, string blacklistItem)
        {
            Console.WriteLine("manager add to blacklist");
            if (IsNull(dispName, blacklistItem))
            {
                return false;
            }

            Blacklist AddItem = new Blacklist(dispName, blacklistItem);
            return (_blacklistService.AddToBlacklist(AddItem));
        }

        public IEnumerable<string> GetBlacklist(string dispName)
        {
            if (IsNull(dispName))
            {
                return null;
            }
            Blacklist GetList = new Blacklist(dispName);
            return (_blacklistService.GetBlacklist(GetList));
        }

        public bool? GetBlacklistToggle(string dispName)
        {
            if (IsNull(dispName))
            {
                return null;
            }
            Blacklist GetToggle = new Blacklist(dispName);
            var result = _blacklistService.GetBlacklistToggle(GetToggle);

            return result;
        }

        public bool RemoveFromBlacklist(string dispName, string blacklistItem)
        {
            if (IsNull(dispName, blacklistItem))
            {
                return false;
            }
            Blacklist RemoveItem = new Blacklist(dispName, blacklistItem);
            return _blacklistService.RemoveFromBlacklist(RemoveItem);
        }

        public bool ToggleBlacklist(string dispName, bool blacklistToggle)
        {
            if (IsNull(dispName))
            {
                return false;
            }
            Blacklist Toggle = new Blacklist(dispName, blacklistToggle);
            return _blacklistService.UpdateToggleBlacklist(Toggle);
        }
    }
}
