using Managers.Contracts;
using Managers.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase {

        // GET api/<NewsController>?id1={}&id2={}
        [HttpGet("add2")]
        public ActionResult<string> Get(int id1, int id2)
        {
            int result = id1 + id2;
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
