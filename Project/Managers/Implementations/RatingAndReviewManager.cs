using System.Collections.Generic;
using System.Linq;
using Services.Contracts;
using Features.Ratings_and_Reviews;
using Services.Implementations;
using Managers.Contracts;

namespace Managers.Implementations
{
    public class RatingAndReviewManager : IRatingAndReviewManager
    {

        private IRatingAndReviewService _ratingAndReviewService;

        public RatingAndReviewManager()
        {
            this._ratingAndReviewService = new RatingAndReviewService();
        }

        // Checks valid review fields
        public bool CheckReviewFields(string titleSelected, float uRating, string uReview)
        {

            const int MAX_REVIEW_CHARACTERS = 2500;
            try
            {
                if ((uRating <= 5) & (uRating >= 1))
                {
                    if ((uReview is null) || (uReview.Length <= MAX_REVIEW_CHARACTERS))
                    {
                        if (titleSelected is not null)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;

        }

        public bool SubmitReviewRating(string dispName, string titleSelected, float uRating, string uReview)
        {
            try
            {
                RatingAndReview userReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
                bool isValidReview = CheckReviewFields(titleSelected, uRating, uReview);
                if (isValidReview)
                {
                    return _ratingAndReviewService.CreateRatingReview(userReview);
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool DeleteReviewRating(string dispName, string titleSelected)
        {
            try
            {
                RatingAndReview deleteReview = new RatingAndReview();
                deleteReview.DispName = dispName;
                deleteReview.Title = titleSelected;
                return _ratingAndReviewService.DeleteRatingReview(deleteReview);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReviewRating(string dispName, string titleSelected, float uRating, string uReview)
        {
            RatingAndReview updateReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
            bool isValidReview = CheckReviewFields(titleSelected, uRating, uReview);
            RatingAndReview oldReview = _ratingAndReviewService.GetRatingReview(updateReview).FirstOrDefault();
            if (oldReview is not null && (isValidReview))
            {
                return _ratingAndReviewService.UpdateRatingReview(updateReview);
            }

            return false;

        }

        public RatingAndReview GetSpecificReviewRating(string dispName, string selectedTitle)
        {
            RatingAndReview specificReview = new RatingAndReview();
            specificReview.DispName = dispName;
            specificReview.Title = selectedTitle;
            return _ratingAndReviewService.GetRatingReview(specificReview).FirstOrDefault();

        }

        public IEnumerable<RatingAndReview> GetTitleReviewRating(string selectedTitle)
        {
            RatingAndReview titleReviews = new RatingAndReview();
            titleReviews.Title = selectedTitle;
            return _ratingAndReviewService.GetRatingReview(titleReviews);
        }

        public IEnumerable<RatingAndReview> GetUserReviewRating(string dispName)
        {
            RatingAndReview userReviews = new RatingAndReview();
            userReviews.DispName = dispName;
            return _ratingAndReviewService.GetRatingReview(userReviews);
        }

    }
}
