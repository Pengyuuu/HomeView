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
        public async Task<int> AddToBlacklistAsync(Blacklist blacklistItem)
        {
            // get parameters from blacklistItem
            // try catch here
            // handle multiple items
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_AddItem", blacklistReq);
        }

        // returns int number of rows effected (pass = 1)
        public async Task<int> RemoveFromBlacklistAsync(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_RemoveItem", blacklistReq);
        }

        // returns list of a user's blacklist items
        public async Task<IEnumerable<Blacklist>> GetBlacklistAsync(string selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser,
            };
            return await _db.LoadData<Blacklist, dynamic>("dbo.Blacklist_ReadList", blacklistReq);
        }

        // returns int number of rows effected (pass = 1)
        public async Task<int> UpdateToggleBlacklistAsync(Blacklist selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser.dispName,
                blacklistToggle = selectedUser.blacklistToggle,
            };
            return await _db.SaveData("dbo.Blacklist_UpdateToggle", blacklistReq);
        }

        // returns blacklist obj containing toggle (bool) value
        public async Task<IEnumerable<Blacklist>> GetBlacklistToggleAsync(string selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser,
            };
            return await _db.LoadData<Blacklist, dynamic>("dbo.Blacklist_ReadToggle", blacklistReq);
        }
    }

}
