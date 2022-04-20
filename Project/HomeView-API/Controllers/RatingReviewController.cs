using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Features.Ratings_and_Reviews;
using Managers.Contracts;
using Managers.Implementations;


namespace HomeView_API.Controllers
{
    [Route("api/RatingReview")]
    [ApiController]
    public class RatingReviewController : ControllerBase
    {

        private readonly IRatingAndReviewManager _reviewManager;

        public RatingReviewController()
        {
            _reviewManager = new RatingAndReviewManager();
        }

        // post: /submit a review
        [HttpPost("submit/{title}/{dispName}")]
        public ActionResult<bool> SubmitReview(string title, string dispName, float rating, string review)
        {
            return _reviewManager.SubmitReviewRating(dispName, title, rating, review);

        }

        // post: update a user's review
        [HttpPost("update/{title}/{dispName}")]
        public ActionResult<bool> UpdateReview(string title, string dispName, float rating, string review)
        {
            return _reviewManager.UpdateReviewRating(dispName, title, rating, review);

        }
    
        // GET list of all reviews for the title
        [HttpGet("get/title/{title}")]
        public ActionResult<List<(double avg, IEnumerable<RatingAndReview> list)>> GetTitleReviews(string title)
        {
            var titleInfo = new List<(double avg, IEnumerable<RatingAndReview> list)>();
            List<RatingAndReview> titleList = (List<RatingAndReview>)(_reviewManager.GetTitleReviewRating(title));
            double avgRating = _reviewManager.GetAverageRating(title);
            titleInfo.Add((avgRating, titleList));
            return titleInfo;
        }


        // GET a user's review for a selected title
        [HttpGet("get/title/user/{title}/{dispName}")]
        public ActionResult<RatingAndReview> GetUserTitleReview(string title, string dispName)
        {
            return _reviewManager.GetSpecificReviewRating(dispName, title);
        }

        // GET ALL of user's reviews
        [HttpGet("get/user/reviews/{dispName}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetUsersReview(string dispName)
        {
            var userList = _reviewManager.GetUserReviewRating(dispName);
            List<RatingAndReview> userReviews = (List<RatingAndReview>) userList;
            return userReviews;
        }


        // DELETE user's review for a title
        [HttpDelete("delete/title/user/{title}/{dispName}")]
        public ActionResult<bool> DeleteReview(string title, string dispName)
        {
            return _reviewManager.DeleteReviewRating(dispName, title);
        }
    }
}
