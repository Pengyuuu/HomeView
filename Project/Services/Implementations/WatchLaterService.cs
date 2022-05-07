using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Logging;
using Data;
using Features.WatchLater;
using Services.Contracts;

namespace Services.Implementations
{
    public class WatchLaterService : IWatchLaterService
    {
        private readonly WatchLaterDAO _watchLaterDAO;
        private readonly ILoggingService _logging;

        public WatchLaterService()
        {
            SqlDataAccess db = new SqlDataAccess();

            _watchLaterDAO = new WatchLaterDAO(db);

            _logging = new LoggingService();
        }

        public async Task<bool> AddToWatchLaterAsync(WatchLaterTitle selectedTitle)
        {
            // Get user's Watch Later list to check if Title is already in there
            var isDuplicate = (List<WatchLaterTitle>) GetListAsync(selectedTitle.Email).Result;

            // If list is populated, check, if not then try to add Title to their Watch Later list
            if (isDuplicate.Count > 0)
            {
                foreach (var item in isDuplicate)
                {
                    // If the selected Title in the database matches the Title user is trying to add, then return false;
                    if (item.Title == selectedTitle.Title && item.Year == selectedTitle.Year)
                    {
                        Log info = new Log
                        {
                            Description = $"{selectedTitle.Title} ({selectedTitle.Year}) is already in {selectedTitle.Email}'s WatchLater",
                            Level = LogLevel.Info,
                            Category = LogCategory.Data,
                            timeStamp = DateTime.UtcNow
                        };

                        await _logging.LogDataAsync(info);

                        return false;
                    }
                }
            }
            // Add Title to database
            var result = await _watchLaterDAO.AddToWatchLaterAsync(selectedTitle);

            // If no rows were affected, then an error occurred
            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not added to {selectedTitle.Email}'s WatchLater",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                await _logging.LogDataAsync(error);

                return false;
            }

            // If more than one rows were affected, then an error occurred
            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later adding {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                await _logging.LogDataAsync(error);

                return false;
            }

            // Log successful insert
            Log success = new Log
            {
                Description = $"Successfully added {selectedTitle.Title} ({selectedTitle.Year}) to {selectedTitle.Email}",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            await _logging.LogDataAsync(success);

            return true;
        }

        public async Task<bool> RemoveFromListAsync(WatchLaterTitle selectedTitle)
        {
            // Remove Title from user's Watch Later database
            var result = _watchLaterDAO.RemoveFromListAsync(selectedTitle).Result;

            // If no rows were affected, an error occurred or the Title was not in there
            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not removed from {selectedTitle.Email}'s Watch Later",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                await _logging.LogDataAsync(error);

                return false;
            }

            // If more than one row was affected, an error occurred
            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later removing {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                await _logging.LogDataAsync(error);

                return false;
            }

            // Log success
            Log success = new Log
            {
                Description = $"Successfully removed {selectedTitle.Title} ({selectedTitle.Year}) from {selectedTitle.Email}'s Watch Later",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            await _logging.LogDataAsync(success);

            return true;
        }

        public async Task<IEnumerable<WatchLaterTitle>> GetListAsync(string userEmail)
        {
            // Return user's Watch Later list
            return await _watchLaterDAO.GetListAsync(userEmail);
        }
    }
}
