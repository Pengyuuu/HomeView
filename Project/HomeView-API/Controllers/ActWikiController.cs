using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;
using Managers.Contracts;
using Features.ActWiki;
using System.Net;


namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActWikiController : Controller
    {
        private readonly IActWikiManager _actManager;
        HttpClient client = new HttpClient();
        private string API_KEY = "82da0caf88a6e84985e9fe3d753d6f43";

        public ActWikiController()
        {
            _actManager = new ActWikiManager();
        }

        [HttpGet]
        public async Task GetAct(string name)
        {
            string[] parseName = name.Split(' ');
            HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/search/person?api_key=" +
                API_KEY + "&language=en-US&query=" + parseName[0] + "+" + parseName[1] + "&page=1&include_adult=false");
            if (response.IsSuccessStatusCode)
            {
                string responseAct = await response.Content.ReadAsStringAsync();
            }


        }
    }   
}