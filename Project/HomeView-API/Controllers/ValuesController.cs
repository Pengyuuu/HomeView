using Managers.Contracts;
using Managers.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
    
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id1}/{id2}")]
        public ActionResult<string> Get(int id1, int id2)
        {
            int result = id1 + id2;
            return Ok(result.ToString());
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
