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

        public async Task<int> AddToWatchLaterAsync(WatchLaterTitle selectedTitle)
        {
            // Variable to store arguments for stored procedure
            var insertToList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            // Executes stored procedure to store a Title to the Watch Later database
            return await _db.SaveData("dbo.WatchLater_AddToList", insertToList);
        }

        public async Task<int> RemoveFromListAsync(WatchLaterTitle selectedTitle)
        {
            // Variable to store arguments for stored procedure
            var deleteFromList = new
            {
                email = selectedTitle.Email,
                title = selectedTitle.Title,
                year = selectedTitle.Year
            };

            // Executes stored procedure to remove a Title from the user's Watch Later database
            return await _db.SaveData("dbo.WatchLater_RemoveFromList", deleteFromList);
        }

        public async Task<IEnumerable<WatchLaterTitle>> GetListAsync(string userEmail)
        {
            // Variable to store arguments for stored procedure
            var targetUser = new
            {
                email = userEmail
            };

            // Executes stored procedure to get a user's Watch Later database
            return await _db.LoadData<WatchLaterTitle, dynamic>("dbo.WatchLater_GetList", targetUser);
        }
    }
}
