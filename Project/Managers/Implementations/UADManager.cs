using System;
using System.Collections.Generic;
using Core.Logging;
using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using System.Threading.Tasks;
using Core.UAD;

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
        public async Task<List<KeyValuePair<DateTime, int>>> GetRegistrationCountAsync()
        {
            var registrationList = new List<KeyValuePair<DateTime, int>>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var regCount = await _userService.GetRegistrationCountAsync(i);
                registrationList.Add(new KeyValuePair<DateTime, int>(i, regCount));

            }
            return registrationList;
        }

        /* Gets a list of the number of log ins per day within the span of 3 months
         * Returns a list of int
         */
        public async Task<List<KeyValuePair<DateTime, int>>> GetLogInCountAsync()
        {
            var loginList = new List<KeyValuePair<DateTime, int>>();
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
                loginList.Add(new KeyValuePair<DateTime, int>(i, dayCount));
            }
            return loginList;
        }

        /* Gets a list of the number of news articles created per day within the span of 3 months
         * Returns a list of int
         */
        public async Task<List<KeyValuePair<DateTime, int>>> GetNewsCountAsync()
        {
            var newsCount = new List<KeyValuePair<DateTime, int>>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var count = await _newsService.AsyncGetNewsDateCount(i);
                newsCount.Add(new KeyValuePair<DateTime, int>(i, count));
            }
            return newsCount;
        }

        /* Gets number of reviews made per day within 3 months
         * Returns an array to be used for trend chart in front end
         */
        public async Task<List<KeyValuePair<DateTime, int>>> GetReviewCountAsync()
        {
            var reviewCount = new List<KeyValuePair<DateTime, int>>();
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
                reviewCount.Add(new KeyValuePair<DateTime, int>(i, dayCount));
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

        public async Task<UADResponse> GetAllCountsAsync()
        {
            UADResponse response = new UADResponse();
            response.registrationCount = await GetRegistrationCountAsync();
            response.loginCount = await GetLogInCountAsync();
            response.newsCount = await GetNewsCountAsync();
            response.reviewCount = await GetReviewCountAsync();
            response.topViewCount = await GetTopMostVisitedViewAsync();
            response.durationViewCount = await GetTopViewDurationAsync();
            return response;
        }
    }
}
