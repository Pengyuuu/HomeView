using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;
using Managers.Contracts;
using Features.ActWiki;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActWikiController : Controller
    {
        private readonly IActWikiManager _actManager;
        private string API_KEY = "82da0caf88a6e84985e9fe3d753d6f43";

        public ActWikiController()
        {
            _actManager = new ActWikiManager();
        }

        [HttpGet]
        public async Task <IActionResult> SearchAct(string searchAct)
        {
            HttpWebRequest request = WebRequest.Create("https://api.themoviedb.org/3/search/person?api_key=" + API_KEY 
                + "&language=en-US&query=" + searchAct + "&page=&include_adult=false") as HttpWebRequest;
            string response = "";
            using (HttpWebResponse apiResponse = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(apiResponse.GetResponseStream());
                response = reader.ReadToEnd();
                return Ok(response);
            }
            ActWiki act = JsonConvert.DeserializeObject<ActWiki>(response);
        }

        /*
        public ActionResult GetAct(int id)
        {
            HttpWebRequest request = WebRequest.Create("https://api.themoviedb.org/3/person/" +
                id + "?api_key=" + API_KEY + "&language=en-US") as HttpWebRequest;
            string response = "";
            using (HttpWebResponse apiResponse = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(apiResponse.GetResponseStream());
                response = reader.ReadToEnd();
            }
            ActWiki act = JsonConvert.DeserializeObject<ActWiki>(response);
            //_actManager.StoreAct(act.ActID,)
        }*/

    }
}