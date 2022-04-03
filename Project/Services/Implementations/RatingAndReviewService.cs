using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Ratings_and_Reviews;
using Services.Contracts;
using Core.Logging;

namespace Services.Implementations
{
    public class RatingAndReviewService : IRatingAndReviewService
    {
        private RatingAndReviewDAO _rrDAO;
        private ILoggingService _loggingService;

        public RatingAndReviewService()
        {

        }

        public bool CreateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncCreateRatingReview(userRatingAndReview).Result;
            }
            catch
            {
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

        public RatingAndReview GetRatingReview(string dispName, string titleSelected)
        {
            RatingAndReview fetchRatingReview = new();

            fetchRatingReview = _rrDAO.AsyncGetUserTitleRatingsReviews(dispName, titleSelected).Result;


            return fetchRatingReview;

        }

        public bool DeleteRatingReview(string dispName, string titleSelected)
        {
            RatingAndReview userTitleReview = GetRatingReview(dispName, titleSelected);
            bool isDeleted = false;

            if (userTitleReview is not null)
            {
                try
                {
                    isDeleted = _rrDAO.AsyncDeleteRatingReview(dispName, titleSelected).Result;
                    if (isDeleted)
                    {
                        Log reviewLogTrue = new("Review successfully deleted.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                        _loggingService.LogData(reviewLogTrue);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            Log reviewLogFalse = new("Unsuccessful delete review.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
            _loggingService.LogData(reviewLogFalse);
            return isDeleted;

        }


    }
}
