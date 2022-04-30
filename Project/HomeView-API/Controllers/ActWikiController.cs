using Microsoft.AspNetCore.Mvc;

using Features.Ratings_and_Reviews;
using Managers.Contracts;
using Managers.Implementations;
using Features.ActWiki;

namespace HomeView_API.Controllers
{
    public class ActWikiController : Controller
    {
        private readonly IActWikiManager _actManager;
        //private readonly ActWikiManager _actManager;
        
        public ActWikiController()
        {
         //   _actManager = new ActWikiManager();
        }
    }
}