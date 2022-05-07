using Features.Ratings_and_Reviews;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRatingAndReviewService
    {
        Task<int> AsyncCreateRatingReview(RatingAndReview userRatingAndReview);
        Task<int> AsyncDeleteRatingReview(RatingAndReview selectedReview);
        Task<IEnumerable<RatingAndReview>> AsyncGetRatingReview(RatingAndReview getReview);
        Task<int> AsyncUpdateRatingReview(RatingAndReview userRatingAndReview);
        Task<int> AsyncGetReviewDateCount(DateTime date);

    }
}