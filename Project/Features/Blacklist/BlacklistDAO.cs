using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Features.Blacklist
{
    public class BlacklistDAO
    {
        private readonly SqlDataAccess _db;

        public BlacklistDAO(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> AsyncAddToBlacklist(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_AddItem", blacklistReq);
        }

        public async Task<int> AsyncRemoveFromBlacklist(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
                blacklistItem = blacklistItem.blacklistItem,
            };
            return await _db.SaveData("dbo.Blacklist_RemoveItem", blacklistReq);
        }

        public async Task<IEnumerable<string>> AsyncGetBlacklist(Blacklist blacklistItem)
        {
            var blacklistReq = new
            {
                dispName = blacklistItem.dispName,
            };
            return await _db.LoadData<string, dynamic>("dbo.Blacklist_ReadList", blacklistReq);
        }

        public async Task<int> AsyncUpdateToggleBlacklist(Blacklist selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser.dispName,
                blacklistToggle = selectedUser.blacklistToggle,
            };
            return await _db.SaveData("dbo.Blacklist_UpdateToggle", blacklistReq);
        }

        public async Task<int> AsyncGetBlacklistToggle(Blacklist selectedUser)
        {
            var blacklistReq = new
            {
                dispName = selectedUser.dispName,
            };
            return await _db.SaveData("dbo.Blacklist_ReadToggle", blacklistReq);
        }
    }

}
