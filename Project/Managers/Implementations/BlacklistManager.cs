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

        private IBlacklistService _blacklistService;
        private ILoggingManager _loggingManager;

        public BlacklistManager()
        {
            _blacklistService = new BlacklistService();
            _loggingManager = new LoggingManager();
        }

        // add logs
        public async Task<IEnumerable<Blacklist>> AddToBlacklistAsync(Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return null;
            }
            return await _blacklistService.AddToBlacklistAsync(blacklistItem);
            
        }
        public async Task<IEnumerable<Blacklist>> RemoveFromBlacklistAsync(Blacklist blacklistItem)
        {
            if (blacklistItem == null)
            {
                return null;
            }
            return await _blacklistService.RemoveFromBlacklistAsync(blacklistItem);

        }

        public async Task<IEnumerable<Blacklist>> GetBlacklistAsync(Blacklist selectedUser)
        {
            if (selectedUser == null)
            {
                return null;
            }
            return await _blacklistService.GetBlacklistAsync(selectedUser);
            
        }
        public async Task<Blacklist> UpdateToggleBlacklistAsync(Blacklist selectedUser)
        {
            if (selectedUser == null)
            {
                return null;
            }
            return await _blacklistService.UpdateToggleBlacklistAsync(selectedUser);

        }

        public async Task<Blacklist> GetBlacklistToggleAsync(Blacklist selectedUser)
        {
            if (selectedUser == null)
            {
                return null;
            }
            return await _blacklistService.GetBlacklistToggleAsync(selectedUser);
        }




    }
}
