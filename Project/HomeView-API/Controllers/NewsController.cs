using Features.News;
using Managers.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase {

        private readonly INewsManager _newsManager;
        public NewsController(INewsManager newsManager) {
            _newsManager = newsManager;
        }

        // GET api/<NewsController>

        /* adjust endpoint to handle large requests
         * always cap, or partition requests that involve getting all rows from db
         * 
         * pagination - set limit per page and every subsequent "show more" (ie load 20 every time)
         */
        [HttpGet]
        public async Task<ActionResult<string>> GetNews()
        {
            var result = await _newsManager.AsyncGetNews();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                string response = JsonSerializer.Serialize(result);
                return Ok(response);
            }
        }

        // GET api/<NewsController>/id
        /*
         * use IActionResult, no need to Serialize, framework will handle return type
         * Async must be suffix
         */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var result = await _newsManager.AsyncGetArticleById(id);
            if (result == null)
            {
                return NotFound("Could not find article with id " + id);
            }
            else
            {
                string response = JsonSerializer.Serialize(result);
                return Ok(response);
            }
        }
        
        // POST api/<NewsController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Could not create Article, received null value");
            }
            else {
                Article ret = await _newsManager.AsyncCreateArticle(article);
                return Ok("Created article with id " + ret.ArticleId);
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Could not create Article, received null value");
            }
            else
            {
                Article ret = await _newsManager.AsyncUpdateArticleById(article);
                return Ok("Updated article with id " + ret.ArticleId);
            }
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var ret = await _newsManager.AsyncDeleteArticleById(id);
            if (ret != 0)
            {
                return Ok("Successfully deleted article with id " + id);
            }
            return NotFound("could not delete article with id" + id);
        }
    }
}
