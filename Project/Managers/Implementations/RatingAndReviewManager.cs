using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;
using Services.Contracts;
using Features.Ratings_and_Reviews;
using Services.Implementations;

namespace Managers.Implementations
{
    public class RatingAndReviewManager
    {
       
        private IRatingAndReviewService _ratingAndReviewService;

        public RatingAndReviewManager()
        {
            this._ratingAndReviewService = new RatingAndReviewService();
        }

        // Checks valid review fields
        public bool CheckReviewFields(string titleSelected, int uRating, string uReview)
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

        public bool SubmitReviewRating(string dispName, string titleSelected, int uRating, string uReview)
        {
            try
            {

                RatingAndReview userReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
                return _ratingAndReviewService.CreateRatingReview(userReview);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteReviewRating(string dispName, string titleSelected)
        {
            try
            {

                return _ratingAndReviewService.DeleteRatingReview(dispName, titleSelected);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReviewRating(RatingAndReview updatedReview)
        {
            RatingAndReview oldReview = _ratingAndReviewService.GetRatingReview(updatedReview.DispName, updatedReview.Title);
            _ratingAndReviewService.GetRatingReview(updatedReview.DispName);

        }

        public bool ReadReviewRating(RatingAndReview updatedReview)
        {
            RatingAndReview oldReview = _ratingAndReviewService.GetRatingReview(updatedReview.DispName, updatedReview.Title);
            _ratingAndReviewService.GetRatingReview(updatedReview.DispName);

        }

    }
}
