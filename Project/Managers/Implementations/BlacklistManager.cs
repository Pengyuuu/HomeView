using System.Collections.Generic;
using System.Linq;
using Services.Contracts;
using Features.Blacklist;
using Services.Implementations;
using Managers.Contracts;
using System;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class BlacklistManager : IBlacklistManager
    {

        private readonly IBlacklistService _blacklistService;
        private readonly ILoggingManager _loggingManager;

        public BlacklistManager()
        {
            _blacklistService = new BlacklistService();
            _loggingManager = new LoggingManager();
        }

        // need to check if already in list
        // check if list null, false return null, true return list
        // no need to return for POST request
        // handle dups in db
        // take out 34-41
        public async Task<IEnumerable<Blacklist>> AddToBlacklistAsync(Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return null;
            }
            var res = await _blacklistService.GetBlacklistAsync(blacklistItem.dispName);
            foreach (var item in res)
            {
                if (item.blacklistItem == blacklistItem.blacklistItem)
                {
                    return null;
                }
            }

            return await _blacklistService.AddToBlacklistAsync(blacklistItem);
            
        }

        // check if list null, false return null, true return list
        public async Task<IEnumerable<Blacklist>> RemoveFromBlacklistAsync(Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return null;
            }
            return await _blacklistService.RemoveFromBlacklistAsync(blacklistItem);

        }

        // check null, false return null, true return list
        public async Task<IEnumerable<Blacklist>> GetBlacklistAsync(string selectedUser)
        {
            // check string null/empty
            if (string.IsNullOrEmpty(selectedUser))
            {
                return null;
            }
            return await _blacklistService.GetBlacklistAsync(selectedUser);
            
        }

        // check null, false return null, true return blacklist obj
        public async Task<Blacklist> UpdateToggleBlacklistAsync(Blacklist selectedUser)
        {
            if (selectedUser == null)
            {
                return null;
            }
            return await _blacklistService.UpdateToggleBlacklistAsync(selectedUser);

        }

        // check null, false return null, true return blacklist obj
        public async Task<Blacklist> GetBlacklistToggleAsync(string selectedUser)
        {
            // check string null/empty
            if (string.IsNullOrEmpty(selectedUser))
            {
                return null;
            }
            return await _blacklistService.GetBlacklistToggleAsync(selectedUser);
        }




    }
}
