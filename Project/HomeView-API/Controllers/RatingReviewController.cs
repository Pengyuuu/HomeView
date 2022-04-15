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

        // GET: api/values
        [HttpPost("api/RatingReview/submit/{title}/{id}")]
        public ActionResult<bool> SubmitReview(string title, string id)
        {
            return true;
        }


        // GET: api/values
        [HttpGet("api/RatingReview/GetRatingReviews")]
        public ActionResult<IEnumerable<RatingAndReview>> Get()
        {
            return new RatingAndReview[] { new RatingAndReview() };        
        }

        // GET api/values/5
        [HttpGet("api/RatingReview/get/{title}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetTitleReviews(string title)
        {
            return new RatingAndReview[] { new RatingAndReview() };
        }


        // GET api/values/5
        [HttpGet("api/RatingReview/get/{title}/{id}")]
        public ActionResult<RatingAndReview> GetUserTitleReview(string title, string id)
        {
            return new RatingAndReview();
        }

        // GET api/values/5
        [HttpGet("api/RatingReview/get/{id}")]
        public ActionResult<IEnumerable<RatingAndReview>> GetUsersReview(string id)
        {
            return new RatingAndReview[] { new RatingAndReview() };
        }


        // DELETE api/values/5
        [HttpDelete("api/RatingReview/delete/{title}/{id}")]
        public ActionResult<bool> DeleteReview(string id)
        {
            return true;
        }
    }
}
