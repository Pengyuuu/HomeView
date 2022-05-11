using System;
using System.Collections.Generic;
using Core.Logging;
using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using System.Threading.Tasks;
using Core.UAD;
using System.Linq;

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
            const int LOG_VIEW_CATEGORY = 0;
            var dayLogs = await _loggingService.GetCategoryLogsAsync(LOG_VIEW_CATEGORY);

            foreach (Log i in dayLogs)
            {
                
                string[] descSplit = i.Description.Split(":");

                if (descSplit[0] == "Home Page View accessed.")
                {
                    homeViewCount++;
                }
                else if (descSplit[0] == "TV Shows View accessed.")
                {
                    tvViewCount++;
                }
                else if (descSplit[0] == "Movies View accessed.")
                {
                    movieViewCount++;
                }
                else if (descSplit[0] == "News View accessed.")
                {
                    newsViewCount++;
                }
                else if (descSplit[0] == "ActWiki View accessed.")
                {
                    actWikiViewCount++;
                }
                else if (descSplit[0] == "Streaming Services View accessed.")
                {
                    streamingViewCount++;
                }
                else if (descSplit[0] == "Account View accessed.")
                {
                    accountViewCount++;
                }
                
            }
            viewCount.Add(homeViewCount);
            viewCount.Add(accountViewCount);
            viewCount.Add(newsViewCount);
            viewCount.Add(movieViewCount);
            viewCount.Add(tvViewCount);
            viewCount.Add(streamingViewCount);
            viewCount.Add(actWikiViewCount);
            return viewCount;
        }

        /* Gets the top 5 average duration per view of all time
         * Returns an array to be used for bar chart in front end
         */
        public async Task<List<double>> GetTopViewDurationAsync()
        {
 
            List<double> viewCount = new List<double>(){};
            List<double> homeDuration = new List<double>() { };
            List<double> accountDuration = new List<double>() { };
            List<double> newsDuration = new List<double>() { };
            List<double> movieDuration = new List<double>() { };
            List<double> showDuration = new List<double>() { };
            List<double> actDuration = new List<double>() { };
            List<double> streamingDuration = new List<double>() { };
            List<string> userLog = new List<string>() { };


            //List<Log> dayLogs = (await _loggingService.GetAllLogsAsync()).ToList();
         
            const int LOG_VIEW_CATEGORY = 0;
            List<Log> dayLogs = (await _loggingService.GetCategoryLogsAsync(LOG_VIEW_CATEGORY)).ToList();
            for (int i = 0; i < dayLogs.Count-2; i++)
            {
                int count = i;
                Log tempLog = dayLogs[i];

                string[] descSplit = tempLog.Description.Split(":");

                // identifies user by logged token
                var user = descSplit[1];
                var check = userLog;
                if (!userLog.Contains(user)) {
                    userLog.Add(user);

                    // user's last accessed view, most recent
                    var currentView = descSplit[0];
                    var currentTime = tempLog.timeStamp;

                    // iterates through rest of logs to find user's access history
                    for (int j = i + 1; j < dayLogs.Count-1; j++)
                    {
 
                        Log nextLog = dayLogs[j];
                        string[] nextSplit = nextLog.Description.Split(":");
                        // identifies user by logged token
                        var checkUser = nextSplit[1];

                        // user's last accessed view, most recent
                        var recentView = nextSplit[0];
                        var recentTime = nextLog.timeStamp;

                        // checks if next recent log is from same user
                        if (user == checkUser)
                        {
                            if (currentView != recentView)
                            {
                                var duration = Math.Abs(currentTime.Subtract(recentTime).TotalMinutes);

                                if (currentView == "Home Page View accessed.")
                                {
                                    homeDuration.Add(duration);
                                }
                                else if (currentView == "TV Shows View accessed.")
                                {
                                    showDuration.Add(duration);
                                }
                                else if (currentView == "Movies View accessed.")
                                {
                                    movieDuration.Add(duration);
                                }
                                else if (currentView == "News View accessed.")
                                {
                                    newsDuration.Add(duration);
                                }
                                else if (currentView == "ActWiki View accessed.")
                                {
                                    actDuration.Add(duration);
                                }
                                else if (currentView == "Streaming Services View accessed.")
                                {
                                    streamingDuration.Add(duration);
                                }
                                else if (currentView == "Account View accessed.")
                                {
                                    accountDuration.Add(duration);
                                }
                                currentView = recentView;
                            }
                        }
                    }
                }               
            }
            List<List<double>> dList = new List<List<double>>();
            dList.Add(homeDuration);
            dList.Add(accountDuration);
            dList.Add(newsDuration);
            dList.Add(movieDuration);
            dList.Add(showDuration);
            dList.Add(streamingDuration);
            dList.Add(actDuration);

            foreach (var list in dList)
            {
                var avgDuration = GetAverageDuration(list);
                viewCount.Add(avgDuration);
            }
            return viewCount;
        }

        public double GetAverageDuration(List<double> durations)
        {
            double avgDuration = 0;
            if (durations.Count() > 0)
            {
                foreach (var d in durations)
                {
                    avgDuration += d;
                }
                avgDuration = avgDuration / (durations.Count());
            }
            return avgDuration;
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
