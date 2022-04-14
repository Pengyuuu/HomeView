using System;
using System.Collections.Generic;
using System.Linq;
using Features.Ratings_and_Reviews;
using Services.Contracts;
using Core.Logging;
using Data;

namespace Services.Implementations
{
    public class RatingAndReviewService : IRatingAndReviewService
    {
        private RatingAndReviewDAO _rrDAO;
        private ILoggingService _loggingService;

        public RatingAndReviewService()
        {
            _rrDAO = new RatingAndReviewDAO(new SqlDataAccess());
            _loggingService = new LoggingService();
        }

        public bool CreateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncCreateRatingReview(userRatingAndReview).Result;
                Log reviewLogTrue = new("Review successfully created to database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogTrue);
            }
            catch
            {
                Log reviewLogFalse = new("Cannot create review to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return false;
            }
            return isCreated;

        }

        public bool UpdateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isUpdated = false;
            try
            {
                isUpdated = _rrDAO.AsyncUpdateRateReview(userRatingAndReview).Result;
                
            }
            catch
            {
                return false;
            }
            return isUpdated;

        }

        public IEnumerable<RatingAndReview> GetRatingReview(RatingAndReview getReview)
        {

            try
            {
                //IEnumerable<RatingAndReview> fetchRatingReview = Enumerable.Empty<RatingAndReview>(); ;
                var ffetchRatingReview = _rrDAO.AsyncGetRatingReviews(getReview).Result;
                Log reviewLogTrue = new("Review successfully fetched from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogTrue);
                return ffetchRatingReview;

            }
            catch
            {
                Log reviewLogFalse = new("Cannot fetch review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return null;
            }
        }

        public bool DeleteRatingReview(RatingAndReview selectedReview)
        {
            bool isDeleted = false;
            try
            {
                RatingAndReview userTitleReview = GetRatingReview(selectedReview).FirstOrDefault();
                if (userTitleReview is not null)
                {
                    try
                    {
                        isDeleted = _rrDAO.AsyncDeleteRatingReview(selectedReview).Result;
                        if (isDeleted)
                        {
                            Log reviewLogTrue = new("Review successfully deleted from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                            _loggingService.LogData(reviewLogTrue);
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                Log reviewLogFalse = new("Unsuccessful delete review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return isDeleted;
            }
            catch
            {
                return false;
            }
        }

    }
}
