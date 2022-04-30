using Managers.Implementations;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(result.ToString());
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
        public void Delete(int id)
        {
        }
    }
}
