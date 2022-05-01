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

        // check if blacklistItem or dispName is null
        public bool IsNull(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            return false;
        }

        // check if dispName and blacklistItem is null
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
            if (IsNull(dispName, blacklistItem))
            {
                return false;
            }

            Blacklist addItem = new Blacklist(dispName, blacklistItem);
            return (_blacklistService.AddToBlacklist(addItem));
        }

        public IEnumerable<string> GetBlacklist(string dispName)
        {
            if (IsNull(dispName))
            {
                return null;
            }
            Blacklist getList = new Blacklist(dispName);
            return (_blacklistService.GetBlacklist(getList));
        }

        public bool GetBlacklistToggle(string dispName)
        {
            Blacklist getToggle = new Blacklist(dispName);
            var result = _blacklistService.GetBlacklistToggle(getToggle);

            return result;
        }

        public bool RemoveFromBlacklist(string dispName, string blacklistItem)
        {
            if (IsNull(dispName, blacklistItem))
            {
                return false;
            }
            Blacklist removeItem = new Blacklist(dispName, blacklistItem);
            return _blacklistService.RemoveFromBlacklist(removeItem);
        }

        public bool ToggleBlacklist(string dispName, bool blacklistToggle)
        {
            if (IsNull(dispName))
            {
                return false;
            }
            Blacklist toggleUser = new Blacklist(dispName, blacklistToggle);
            return _blacklistService.UpdateToggleBlacklist(toggleUser);
        }
    }
}
