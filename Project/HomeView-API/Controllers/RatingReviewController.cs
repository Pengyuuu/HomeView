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
            try
            {
                bool result = _reviewManager.CheckReviewFields(title, rating, review);
                if (result)
                {
                    result = _reviewManager.SubmitReviewRating(dispName, title, rating, review);
                    if (result)
                    {
                        return Ok("Rating/Review submitted");
                    }
                    return BadRequest("Unable to submit review/rating. Database error.");
                }
                return BadRequest("Please enter valid fields.");
            }
            catch
            {
                return BadRequest("Cannot submit rating review. System error.");
            }
        }

        // post: update a user's review
        [HttpPost("update/{title}/{dispName}")]
        public ActionResult<bool> UpdateReview(string title, string dispName, double rating, string review)
        {
            try
            {
                bool result = _reviewManager.CheckReviewFields(title, rating, review);
                if (result)
                {
                    result = _reviewManager.UpdateReviewRating(dispName, title, rating, review);
                    if (result)
                    {
                        return Ok("Rating/Review updated.");
                    }
                    return BadRequest("Unable to update review/rating. Database error.");
                }
                return BadRequest("Please enter valid fields.");
            }
            catch
            {
                return BadRequest("Cannot update rating review. System Error.");
            }

        }
    
        // GET list of all reviews for the title
        [HttpGet("get/title/{title}")]
        public ActionResult<TitleInfo> GetTitleReviews(string title)
        {
            try
            {
                List<RatingAndReview> titleList = (List<RatingAndReview>)(_reviewManager.GetTitleReviewRating(title));
                double avgRating = _reviewManager.GetAverageRating(title);
                if ((titleList.Count != 0) && (avgRating > 0))
                {
                    TitleInfo info = new TitleInfo();
                    info.Rating = avgRating;
                    info.RatingAndReviews = titleList;
                    return Ok(info);
                }
                return BadRequest("Unable to get title's rating reviews information. Database error.");
            }
            catch
            {
                return BadRequest("Unable to get title's rating reviews information. System error.");
            }
        }


        // GET a user's review for a selected title
        [HttpGet("get/title/user/{title}/{dispName}")]
        public ActionResult<RatingAndReview> GetUserTitleReview(string title, string dispName)
        {
            try {
                RatingAndReview review = _reviewManager.GetSpecificReviewRating(dispName, title);
                if (review!= null)
                {
                    return Ok(review);
                }
                return BadRequest("Unable to get user's specific title review information. Database error.");
            }
            catch
            {
                return BadRequest("Unable to get user's specific title review information. System error.");
            }
        }

        // GET ALL of user's reviews
        [HttpGet("get/user/reviews/{dispName}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetUsersReview(string dispName)
        {
            try
            {
                IEnumerable<RatingAndReview> userList = _reviewManager.GetUserReviewRating(dispName);
                List<RatingAndReview> userReviews = (List<RatingAndReview>)userList;
                if (userReviews.Count > 0)
                {
                    return Ok(userReviews);
                }
                return BadRequest("No list of reviews found for user.");
            }
            catch
            {
                return BadRequest("Unable to get user's list of reviews. System error.");
            }
        }


        // DELETE user's review for a title
        [HttpDelete("delete/title/user/{title}/{dispName}")]
        public ActionResult<bool> DeleteReview(string title, string dispName)
        {
            try {
                bool result = _reviewManager.DeleteReviewRating(dispName, title);
                if (result)
                {
                    return Ok("Rating review deleted.");
                }
                return BadRequest("Unable to delete the requested rating review. Database error.");
            }
            catch
            {
                return BadRequest("Unable to delete the requested rating review. System error.");
            }
        }

    }
}
