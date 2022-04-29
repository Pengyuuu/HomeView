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

        public async Task<bool> AsyncAddToWatchLater(WatchLaterTitle selectedTitle)
        {
            var insertToList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            int result = await _db.SaveData("dbo.WatchLater_AddToList", insertToList);

            if (result != 1)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AsyncRemoveFromList(WatchLaterTitle selectedTitle)
        {
            var deleteFromList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            int result = await _db.SaveData("dbo.WatchLater_RemoveFromList", deleteFromList);

            if (result != 1)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<WatchLaterTitle>> AsyncGetList(string userEmail)
        {
            var targetUser = new
            {
                email = userEmail
            };

            List<WatchLaterTitle> result = (List<WatchLaterTitle>) await _db.LoadData<WatchLaterTitle, dynamic>("dbo.WatchLater_GetList", targetUser);

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }
    }
}
