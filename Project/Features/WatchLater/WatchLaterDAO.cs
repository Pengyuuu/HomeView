using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Features.WatchLater
{
    public class WatchLaterDAO
    {
        private readonly SqlDataAccess _db;

        public WatchLaterDAO(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> AsyncAddToWatchLater(WatchLaterTitle selectedTitle)
        {
            var insertToList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            return await _db.SaveData("dbo.WatchLater_AddToList", insertToList);
        }

        public async Task<int> AsyncRemoveFromList(WatchLaterTitle selectedTitle)
        {
            var deleteFromList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            return await _db.SaveData("dbo.WatchLater_RemoveFromList", deleteFromList);
        }

        public async Task<IEnumerable<WatchLaterTitle>> AsyncGetList(string userEmail)
        {
            var targetUser = new
            {
                email = userEmail
            };

            return await _db.LoadData<WatchLaterTitle, dynamic>("dbo.WatchLater_GetList", targetUser);
        }
    }
}
