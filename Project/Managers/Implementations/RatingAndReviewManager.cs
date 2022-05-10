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

        /** Checks review fields to ensure validity
         * Ensures reviews are <= 2500 characters, rating is between 1-5, allowing for increments of 0.5 only
         * Reviews are optional to enter. Ratings are mandatory in order to submit
         * Returns true if valid, false if invalid
         */
        public bool CheckReviewFields(string titleSelected, double uRating, string uReview)
        {
            double[] VALID_VALUES = new double[] { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 };

            const int MAX_REVIEW_CHARACTERS = 2500;

            if (VALID_VALUES.Contains(uRating))
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

        /** Submits a valid review - calls RR service to submit review
         * Takes in user's display name, title selected, user's rating, and their review
         * Returns an int (1 if succeeded, if not 1, then the task failed)
         */
        public async Task<int> AsyncSubmitReviewRating(string dispName, string titleSelected, double uRating, string uReview)
        {
            RatingAndReview userReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
            bool isValidReview = CheckReviewFields(titleSelected, uRating, uReview);
            if (isValidReview)
            {
                var existingReview = await AsyncGetSpecificReviewRating(dispName, titleSelected);
                if (existingReview != null)
                {
                    return await _ratingAndReviewService.AsyncUpdateRatingReview(userReview);
                }
                else
                {
                    return await _ratingAndReviewService.AsyncCreateRatingReview(userReview);
                }
            }
            // -1 if invalid fields
            return -1;
        }

        /** Deletes a review - calls RR service to delete review
         * Takes in user's display name, title selected
         * Returns an int (1 if succeeded, if not 1, then the task failed)
         */
        public async Task<int> AsyncDeleteReviewRating(string dispName, string titleSelected)
        {
            RatingAndReview deleteReview = new RatingAndReview();
            deleteReview.DispName = dispName;
            deleteReview.Title = titleSelected;
            return await _ratingAndReviewService.AsyncDeleteRatingReview(deleteReview);


        }

        /** Updates a valid review - calls RR service to update review
         * Takes in user's display name, title selected, user's rating, and their review
         * Returns an int (1 if succeeded, if not 1, then the task failed)
         */
        public async Task<int> AsyncUpdateReviewRating(string dispName, string titleSelected, double uRating, string uReview)
        {
            RatingAndReview updateReview = new RatingAndReview(dispName, titleSelected, uRating, uReview);
            var oldReview = (await _ratingAndReviewService.AsyncGetRatingReview(updateReview)).FirstOrDefault();
            return await _ratingAndReviewService.AsyncUpdateRatingReview(updateReview);
        }

        /** Gets a specific review - calls RR service to get user's review for a specific title
         * Takes in user's display name, title selected
         * Returns an the review if found
         */
        public async Task<RatingAndReview> AsyncGetSpecificReviewRating(string dispName, string selectedTitle)
        {
            RatingAndReview specificReview = new RatingAndReview();
            specificReview.DispName = dispName;
            specificReview.Title = selectedTitle;
            return (await _ratingAndReviewService.AsyncGetRatingReview(specificReview)).FirstOrDefault();

        }

        /** Gets all reviews for a title
         * Takes in title selected
         * Returns list of reviews if found
         */
        public async Task<IEnumerable<RatingAndReview>> AsyncGetTitleReviewRating(string selectedTitle)
        {
            RatingAndReview titleReviews = new RatingAndReview();
            titleReviews.Title = selectedTitle;
            return await _ratingAndReviewService.AsyncGetRatingReview(titleReviews);
        }

        /** Gets all reviews and average rating of all reviews for a title
         * Takes in title selected
         * Returns a TitleInfo Response (contains list of reviews and the average rating based on its reviews)
         */
        public async Task<TitleInfo> AsyncGetTitleReviews(string title)
        {
            TitleInfo info = new TitleInfo();
            var titleList = (List<RatingAndReview>) (await (AsyncGetTitleReviewRating(title)));
            if (titleList != null)
            {
                var avgRating = await AsyncGetAverageRating(title);
                if (avgRating > 0)
                {                   
                    info.Rating = avgRating;
                    info.RatingAndReviews = titleList;                   
                }
            }
            return info;
        }

        /** Gets all reviews a user has made
         * Takes in user's display name
         * Returns a list of reviews
         */
        public async Task<IEnumerable<RatingAndReview>> AsyncGetUserReviewRating(string dispName)
        {
            RatingAndReview userReviews = new RatingAndReview();
            userReviews.DispName = dispName;
            return await _ratingAndReviewService.AsyncGetRatingReview(userReviews);
        }

        /** Gets average review rating for a title
         * Takes in title selected
         * Returns average rating as a double
         */
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
