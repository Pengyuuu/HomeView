using Features.Ratings_and_Reviews;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IRatingAndReviewManager
    {
        bool CheckReviewFields(string titleSelected, float uRating, string uReview);
        bool DeleteReviewRating(string dispName, string titleSelected);
        RatingAndReview GetSpecificReviewRating(string dispName, string selectedTitle);
        IEnumerable<RatingAndReview> GetTitleReviewRating(string selectedTitle);
        IEnumerable<RatingAndReview> GetUserReviewRating(string dispName);
        bool SubmitReviewRating(string dispName, string titleSelected, float uRating, string uReview);
        bool UpdateReviewRating(string dispName, string titleSelected, float uRating, string uReview);
    }
}