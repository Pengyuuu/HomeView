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
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetArticleById(int id)
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
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var ret = await _newsManager.AsyncDeleteArticleById(id);
            if (ret != 0)
            {
                return Ok(ret);
            }
            return NotFound("could not delete article with id" + id);
        }
    }
}
