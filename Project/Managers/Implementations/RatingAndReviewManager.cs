using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;
using Services.Contracts;
using Features.Ratings_and_Reviews;

namespace Managers.Implementations
{
    public class RatingAndReviewManager
    {
       
        private IRatingAndReviewService _ratingAndReviewService;

        public RatingAndReviewManager()
        {

        }

        // Checks valid review fields (reviews are optional when making a rating; making a review requires a rating)
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

        public bool SubmitReviewRating(string username, string titleSelected, int uRating, string uReview)
        {
            try
            {

                RatingAndReview userReview = new RatingAndReview(username, titleSelected, uRating, uReview);
                return _ratingAndReviewService.CreateRatingReview(userReview);
            }
            catch
            {
                return false;
            }
        }
    }
}
