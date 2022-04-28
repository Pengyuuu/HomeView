using Microsoft.AspNetCore.Mvc;
using Managers.Contracts;
using Managers.Implementations;
using Features.ActWiki;

namespace HomeView_API.Controllers
{
    public class ActWikiController : Controller
    {
        private readonly IActWikiManager _actManager;
        
        public ActWikiController()
        {
            _actManager = new ActWikiManager();
        }
    }
}