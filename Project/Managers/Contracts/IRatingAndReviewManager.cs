using Features.Ratings_and_Reviews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IRatingAndReviewManager
    {
        Task<int> AsyncDeleteReviewRating(string dispName, string titleSelected);
        Task<double> AsyncGetAverageRating(string selectedTitle);
        Task<RatingAndReview> AsyncGetSpecificReviewRating(string dispName, string selectedTitle);
        Task<IEnumerable<RatingAndReview>> AsyncGetTitleReviewRating(string selectedTitle);
        Task<IEnumerable<RatingAndReview>> AsyncGetUserReviewRating(string dispName);
        Task<int> AsyncSubmitReviewRating(string dispName, string titleSelected, double uRating, string uReview);
        Task<int> AsyncUpdateReviewRating(string dispName, string titleSelected, double uRating, string uReview);
        bool CheckReviewFields(string titleSelected, double uRating, string uReview);
    }
}