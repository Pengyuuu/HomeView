using System;
using System.Collections.Generic;
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

        public bool AddToWatchLater(WatchLaterTitle selectedTitle)
        {
            var isDuplicate = (List<WatchLaterTitle>) GetList(selectedTitle.Email);

            if (isDuplicate.Count > 0)
            {
                foreach (var item in isDuplicate)
                {
                    if (item.Title == selectedTitle.Title && item.Year == selectedTitle.Year)
                    {
                        Log info = new Log
                        {
                            Description = $"{selectedTitle.Title} ({selectedTitle.Year}) is already in {selectedTitle.Email}'s WatchLater",
                            Level = LogLevel.Info,
                            Category = LogCategory.Data,
                            timeStamp = DateTime.UtcNow
                        };

                        _logging.LogDataAsync(info);

                        return false;
                    }
                }
            }
            var result = _watchLaterDAO.AsyncAddToWatchLater(selectedTitle).Result;

            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not added to {selectedTitle.Email}'s WatchLater",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogDataAsync(error);

                return false;
            }

            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later adding {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogDataAsync(error);

                return false;
            }

            Log success = new Log
            {
                Description = $"Successfully added {selectedTitle.Title} ({selectedTitle.Year}) to {selectedTitle.Email}",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            _logging.LogDataAsync(success);

            return true;
        }

        public bool RemoveFromList(WatchLaterTitle selectedTitle)
        {
            var result = _watchLaterDAO.AsyncRemoveFromList(selectedTitle).Result;

            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not removed from {selectedTitle.Email}'s Watch Later",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogDataAsync(error);

                return false;
            }

            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later removing {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogDataAsync(error);

                return false;
            }

            Log success = new Log
            {
                Description = $"Successfully removed {selectedTitle.Title} ({selectedTitle.Year}) from {selectedTitle.Email}'s Watch Later",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            _logging.LogDataAsync(success);

            return true;
        }

        public IEnumerable<WatchLaterTitle> GetList(string userEmail)
        {
            return _watchLaterDAO.AsyncGetList(userEmail).Result;
        }
    }
}
