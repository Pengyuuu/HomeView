using System;
using System.Collections.Generic;
using System.Linq;
using Features.Blacklist;
using Services.Contracts;
using Core.Logging;
using Data;
using System.Threading.Tasks;


namespace Services.Implementations
{
    public class BlacklistService : IBlacklistService
    {
        private BlacklistDAO _bDAO;
        private ILoggingService _loggingService;

        public BlacklistService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _bDAO = new BlacklistDAO(db);
            _loggingService = new LoggingService();
        }

        // return what was added
        // return true if rowsEffected = 1, else return false
        // add logs
        public async Task<IEnumerable<Blacklist>> AddToBlacklistAsync(Blacklist blacklistItem)
        {
            int rowsEffected = await _bDAO.AddToBlacklistAsync(blacklistItem);
            if (rowsEffected != 1)
            {
                return null;
            }

            var res = await _bDAO.GetBlacklistAsync(blacklistItem.dispName);
            return res;
        }

        // return true if rowsEffected = 1, else return false
        public async Task<IEnumerable<Blacklist>> RemoveFromBlacklistAsync(Blacklist blacklistItem)
        {
            int rowsEffected = await _bDAO.RemoveFromBlacklistAsync(blacklistItem);
            if (rowsEffected != 1)
            {
                return null;
            }
            var res = await _bDAO.GetBlacklistAsync(blacklistItem.dispName);
            return res;
        }

        // return what was deleted
        // return true if successfully fetched from db and contains anything, else return null
        public async Task<IEnumerable<Blacklist>> GetBlacklistAsync(string selectedUser)
        {
            return await _bDAO.GetBlacklistAsync(selectedUser);
        }

        // return update
        // return true if rowsEffected = 1, else return false
        public async Task<Blacklist> UpdateToggleBlacklistAsync(Blacklist selectedUser)
        {
            int rowsEffected = await _bDAO.UpdateToggleBlacklistAsync(selectedUser);
            if (rowsEffected != 1)
            {
                return null;
            }
            var res = await _bDAO.GetBlacklistToggleAsync(selectedUser.dispName);
            // Should only be one blacklist obj here
            return res.FirstOrDefault();
        }

        // return user's blacklist toggle option (true/false or on/off)
        public async Task<Blacklist> GetBlacklistToggleAsync(string selectedUser)
        {
            var res = await _bDAO.GetBlacklistToggleAsync(selectedUser);
            return res.FirstOrDefault();

        }
    }
}
