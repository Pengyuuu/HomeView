using System;
using System.Collections.Generic;
using Core.Logging;
using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class UADManager : IUADManager
    {
        private readonly INewsService _newsService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;
        private readonly IRatingAndReviewService _ratingAndReviewService;
        public UADManager()
        {
            _newsService = new NewsService(new Features.News.NewsDAO(new Data.SqlDataAccess()));
            _userService = new UserService();
            _loggingService = new LoggingService();
            _ratingAndReviewService = new RatingAndReviewService();

        }

        /* Gets a list of the number of registrations per day within the span of 3 months
         * Returns a list of int
         */
        public async Task<List<int>> GetRegistrationCountAsync()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                registrationCount.Add(await _userService.GetRegistrationCountAsync(i));
            }
            return registrationCount;
        }

        /* Gets a list of the number of log ins per day within the span of 3 months
         * Returns a list of int
         */
        public async Task<List<int>> GetLogInCountAsync()
        {
            List<int> loginCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = await _loggingService.GetLogAsync(i);
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Successfully created user session.")
                    {
                        dayCount++;
                    }
                }
                loginCount.Add(dayCount);
            }
            return loginCount;
        }

        /* Gets a list of the number of news articles created per day within the span of 3 months
         * Returns a list of int
         */
        public async Task<List<int>> GetNewsCountAsync()
        {
            List<int> newsCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                newsCount.Add(await _newsService.AsyncGetNewsDateCount(i));
            }
            return newsCount;
        }

        /* Gets number of reviews made per day within 3 months
         * Returns an array to be used for trend chart in front end
         */
        public async Task<List<int>> GetReviewCountAsync()
        {
            List<int> reviewCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = await _loggingService.GetLogAsync(i);
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Review successfully created to database.")
                    {
                        dayCount++;
                    }
                }
                reviewCount.Add(dayCount);
            }
            return reviewCount;

            /**
            List<int> reviewCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                reviewCount.Add(_ratingAndReviewService.AsyncGetReviewDateCount(i).Result);
            }
            return reviewCount;**/

        }

        /* Gets the top 5 most visited view of all time
         * Returns an array to be used for bar chart in front end
         */
        public async Task<List<int>> GetTopMostVisitedViewAsync()
        {
            int homeViewCount = 0;
            int tvViewCount = 0;
            int movieViewCount = 0;
            int newsViewCount = 0;
            int actWikiViewCount = 0;
            int streamingViewCount = 0;
            int accountViewCount = 0;
            List<int> viewCount = new List<int>()
            {

            };

            var dayLogs = await _loggingService.GetAllLogsAsync();

            foreach (Log i in dayLogs)
            {
                if (i.Category == 0)
                {
                    if (i.Description == "Home Page View accessed.")
                    {
                        homeViewCount++;
                    }
                    else if (i.Description == "TV Shows View accessed.")
                    {
                        tvViewCount++;
                    }
                    else if (i.Description == "Movies View accessed.")
                    {
                        movieViewCount++;
                    }
                    else if (i.Description == "News View accessed.")
                    {
                        newsViewCount++;
                    }
                    else if (i.Description == "ActWiki View accessed.")
                    {
                        actWikiViewCount++;
                    }
                    else if (i.Description == "Streaming Services View accessed.")
                    {
                        streamingViewCount++;
                    }
                    else if (i.Description == "Account View accessed.")
                    {
                        accountViewCount++;
                    }
                }
            }
            return viewCount;
        }

        /* Gets the top 5 average duration per view of all time
         * Returns an array to be used for bar chart in front end
         */
        public async Task<List<int>> GetTopViewDurationAsync()
        {
            List<int> loginCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = await _loggingService.GetLogAsync(i);
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Successfully created user session.")
                    {
                        dayCount++;
                    }
                }
                loginCount.Add(dayCount);
            }
            return loginCount;
        }
    }
}
