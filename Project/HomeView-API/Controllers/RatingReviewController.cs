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

        // post: /submit
        [HttpPost("submit/{title}/{dispName}")]
        public ActionResult<bool> SubmitReview(string title, string dispName, float rating, string review)
        {
            return _reviewManager.SubmitReviewRating(dispName, title, rating, review);

        }

        // post: /update
        [HttpPost("update/{title}/{dispName}")]
        public ActionResult<bool> UpdateReview(string title, string dispName, float rating, string review)
        {
            return _reviewManager.UpdateReviewRating(dispName, title, rating, review);

        }

        // GET /get list of reviews for the title
        [HttpGet("get/{title}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetTitleReviews(string title)
        {
            var titleList = _reviewManager.GetTitleReviewRating("Power Rangers");
            List<RatingAndReview> titleReviews = (List<RatingAndReview>)titleList;
            return titleReviews;
        }


        // GET api/values/5
        [HttpGet("get/{title}/{dispName}")]
        public ActionResult<RatingAndReview> GetUserTitleReview(string title, string dispName)
        {
            return new RatingAndReview();
        }

        // GET api/values/5
        [HttpGet("get/{dispName}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetUsersReview(string dispName)
        {
            var userList = _reviewManager.GetUserReviewRating(dispName);
            List<RatingAndReview> userReviews = (List<RatingAndReview>)userList;
            return userReviews;
        }


        // DELETE api/values/5
        [HttpDelete("delete/{title}/{dispName}")]
        public ActionResult<bool> DeleteReview(string title, string dispName)
        {
            return _reviewManager.DeleteReviewRating(dispName, title);
        }
    }
}
