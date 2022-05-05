using System.Collections.Generic;
using System.Linq;
using Services.Contracts;
using Features.Ratings_and_Reviews;
using Services.Implementations;
using Managers.Contracts;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class RatingAndReviewManager : IRatingAndReviewManager
    {

        private readonly IRatingAndReviewService _ratingAndReviewService;

        public RatingAndReviewManager()
        {
            _ratingAndReviewService = new RatingAndReviewService();
        }

        // Checks valid review fields
        public bool CheckReviewFields(string titleSelected, double uRating, string uReview)
        {

            const int MAX_REVIEW_CHARACTERS = 2500;

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
            return false;

        }

        public async Task<int> AsyncSubmitReviewRating(string dispName, string titleSelected, double uRating, string uReview)
        {
            RatingAndReview userReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
            bool isValidReview = CheckReviewFields(titleSelected, uRating, uReview);
            return await _ratingAndReviewService.AsyncCreateRatingReview(userReview);

        }

        public async Task<int> AsyncDeleteReviewRating(string dispName, string titleSelected)
        {
            RatingAndReview deleteReview = new RatingAndReview();
            deleteReview.DispName = dispName;
            deleteReview.Title = titleSelected;
            return await _ratingAndReviewService.AsyncDeleteRatingReview(deleteReview);


        }

        public async Task<int> AsyncUpdateReviewRating(string dispName, string titleSelected, double uRating, string uReview)
        {
            RatingAndReview updateReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
            bool isValidReview = CheckReviewFields(titleSelected, uRating, uReview);
            var oldReview = (await _ratingAndReviewService.AsyncGetRatingReview(updateReview)).FirstOrDefault();
            return await _ratingAndReviewService.AsyncUpdateRatingReview(updateReview);

        }

        public async Task<RatingAndReview> AsyncGetSpecificReviewRating(string dispName, string selectedTitle)
        {
            RatingAndReview specificReview = new RatingAndReview();
            specificReview.DispName = dispName;
            specificReview.Title = selectedTitle;
            return (await _ratingAndReviewService.AsyncGetRatingReview(specificReview)).FirstOrDefault();

        }

        public async Task<IEnumerable<RatingAndReview>> AsyncGetTitleReviewRating(string selectedTitle)
        {
            RatingAndReview titleReviews = new RatingAndReview();
            titleReviews.Title = selectedTitle;
            return await _ratingAndReviewService.AsyncGetRatingReview(titleReviews);
        }

        public async Task<IEnumerable<RatingAndReview>> AsyncGetUserReviewRating(string dispName)
        {
            RatingAndReview userReviews = new RatingAndReview();
            userReviews.DispName = dispName;
            return await _ratingAndReviewService.AsyncGetRatingReview(userReviews);
        }

        public async Task<double> AsyncGetAverageRating(string selectedTitle)
        {
            double totalRating = 0;
            var titleReviews = await AsyncGetTitleReviewRating(selectedTitle);
            if (titleReviews.Count() > 0)
            {
                foreach (var review in titleReviews)
                {
                    totalRating += review.Rating;
                }
                double averageRating = totalRating / (titleReviews.Count());
                return averageRating;
            }
            return totalRating;
        }

    }
}
