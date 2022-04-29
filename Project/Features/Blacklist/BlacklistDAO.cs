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

        public async Task<int> AsyncAddToBlacklist(string blacklistItem)
        {
            return await _db.SaveData("dbo.Blacklist_AddItem", blacklistItem);

        }

        public async Task<int> AsyncRemoveFromBlacklist(string blacklistItem)
        {
            return await _db.SaveData("dbo.Blacklist_RemoveItem", blacklistItem);
        }

        public async Task<IEnumerable<string>> AsyncGetBlacklist(string dispName)
        {
            return await _db.LoadData<string, dynamic>("dbo.Blacklist_ReadList", dispName);
        }

        public async Task<int> AsyncToggleBlacklist(bool toggle)
        {
            return await _db.SaveData("dbo.Blacklist_UpdateToggle", toggle);
        }

        public async Task<int> AsyncGetBlacklistToggle(string dispName)
        {
            return await _db.SaveData("dbo.Blacklist_ReadToggle", dispName);
        }
    }

}
