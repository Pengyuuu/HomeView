using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Features.Blacklist
{
    // CRUD for Blacklist
    public class BlacklistDAO
    {
        // SQLDataAccessObject, standardizes the use of stored procedures
        private readonly SqlDataAccess _db;

        // Constructor, pass SQLDataAccess
        public BlacklistDAO(SqlDataAccess db)
        {
            _db = db;
        }

        // returns int number of rows effected (pass = 1)
        public async Task<int> AsyncAddToBlacklist(Blacklist blacklistItem)
        {
            // get parameters from blacklistItem
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_AddItem", blacklistReq);
        }

        // returns int number of rows effected (pass = 1)
        public async Task<int> AsyncRemoveFromBlacklist(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_RemoveItem", blacklistReq);
        }

        // returns string list of a users blacklist items
        public async Task<IEnumerable<string>> AsyncGetBlacklist(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
            };
            return await _db.LoadData<string, dynamic>("dbo.Blacklist_ReadList", blacklistReq);
        }

        // returns int number of rows effected (pass = 1)
        public async Task<int> AsyncUpdateToggleBlacklist(Blacklist selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser.dispName,
                blacklistToggle = selectedUser.blacklistToggle,
            };
            return await _db.SaveData("dbo.Blacklist_UpdateToggle", blacklistReq);
        }

        // returns bool, the users current toggle setting (either on or off)
        public async Task<IEnumerable<bool>> AsyncGetBlacklistToggle(Blacklist selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser.dispName,
            };
            return await _db.LoadData<bool, dynamic>("dbo.Blacklist_ReadToggle", blacklistReq);
        }
    }

}
