using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Features.Ratings_and_Reviews;
using Managers.Contracts;


namespace HomeView_API.Controllers
{
    [Route("api/RatingReview")]
    public class RatingReviewController : ControllerBase
    {
        // GET: api/values
        [HttpGet(Name = "GetRatingReviews")]
        public IEnumerable<RatingAndReview> Get()
        {

            

            return new RatingAndReview[] { new RatingAndReview() };
           
        }

        // GET api/values/5
        [HttpGet("{title}")]
        public IEnumerable<RatingAndReview> Get(string title)
        {



            return new RatingAndReview[] { new RatingAndReview() };


        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
