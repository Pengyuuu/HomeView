using Microsoft.AspNetCore.Mvc;
using Features.Ratings_and_Reviews;
using Managers.Contracts;
using Managers.Implementations;


namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingReviewController : ControllerBase
    {

        private readonly IRatingAndReviewManager _reviewManager;

        public RatingReviewController(IRatingAndReviewManager ratingAndReviewManager)
        {
            _reviewManager = ratingAndReviewManager;
        }

        // post: /submit a review
        [HttpPost("submit/{title}/{dispName}")]
        public ActionResult<string> SubmitReview(string title, string dispName, float rating, string review)
        {

            var result = _reviewManager.AsyncSubmitReviewRating(dispName, title, rating, review).Result;
            if (result == 1)
            {
                return Ok("Successfully created review.");
            }
            return BadRequest("Unable to submit review/rating. Database error.");
            
        }

        // post: update a user's review
        [HttpPost("update/{title}/{dispName}")]
        public ActionResult<string> UpdateReview(string title, string dispName, double rating, string review)
        {
 
            int result = _reviewManager.AsyncUpdateReviewRating(dispName, title, rating, review).Result;
            if (result == 1)
            {
                return Ok("Rating/Review updated.");
            }
            return BadRequest("Unable to update review/rating. Database error.");

        }
    
        // GET list of all reviews for the title
        [HttpGet("get/title/{title}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetTitleReviews(string title)
        {

            List<RatingAndReview> titleList = (List<RatingAndReview>)(_reviewManager.AsyncGetTitleReviewRating(title).Result);
            double avgRating = _reviewManager.AsyncGetAverageRating(title).Result;
            if ((titleList.Count != 0) && (avgRating > 0))
            {
                TitleInfo info = new TitleInfo();
                info.Rating = avgRating;
                info.RatingAndReviews = titleList;
                return Ok(info);
            }
            return BadRequest("Unable to get title's rating reviews information. Database error.");
                       
        }


        // GET a user's review for a selected title
        [HttpGet("get/title/user/{title}/{dispName}")]
        public ActionResult<RatingAndReview> GetUserTitleReview(string title, string dispName)
        {
            RatingAndReview review = _reviewManager.AsyncGetSpecificReviewRating(dispName, title).Result;
            if (review!= null)
            {
                return Ok(review);
            }
            return BadRequest("Unable to get user's specific title review information. Database error.");
  
        }

        // GET ALL of user's reviews
        [HttpGet("get/user/reviews/{dispName}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetUsersReview(string dispName)
        {

            IEnumerable<RatingAndReview> userList = _reviewManager.AsyncGetUserReviewRating(dispName).Result;
            List<RatingAndReview> userReviews = (List<RatingAndReview>)userList;
            if (userReviews.Count > 0)
            {
                return Ok(userReviews);
            }
             return BadRequest("No list of reviews found for user.");

        }


        // DELETE user's review for a title
        [HttpDelete("delete/title/user/{title}/{dispName}")]
        public ActionResult<bool> DeleteReview(string title, string dispName)
        {
            int result = _reviewManager.AsyncDeleteReviewRating(dispName, title).Result;
            if (result == 1)
            {
                return Ok("Rating review deleted.");
            }
            return BadRequest("Unable to delete the requested rating review. Database error.");

        }

    }
}
