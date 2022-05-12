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
        private readonly IAuthenticationManager _authenticationManager;

        public RatingReviewController(IRatingAndReviewManager ratingAndReviewManager, IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
            _reviewManager = ratingAndReviewManager;
        }

        // post: /submit a review
        [HttpPost("submit/{title}/{dispName}")]
        public IActionResult SubmitReview(string title, string dispName, float rating, string review)
        {
            bool headerTry = Request.Headers.TryGetValue("Authorization", out var token);
            if ( headerTry && _authenticationManager.ValidateToken(token)) {
                var result = _reviewManager.AsyncSubmitReviewRating(dispName, title, rating, review).Result;
                if (result == 1)
                {
                    return Ok("Successfully created/modified review.");
                }
                return BadRequest("Unable to submit review/rating. Database error.");
            }
            else
            {
                return Unauthorized("Failed to validate token");
            }
        }

        // put: update a user's review
        [HttpPut("update/{title}/{dispName}")]
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
        public ActionResult<TitleInfo> GetTitleReviews(string title)
        {

            var titleReviewInfo = _reviewManager.AsyncGetTitleReviews(title).Result;
            return Ok(titleReviewInfo);                      
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
            return BadRequest("No reviw for this title to delete.");

        }

    }
}
