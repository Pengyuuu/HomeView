using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using Features.Ratings_and_Reviews;
>>>>>>> 5fe1b6b8fa68adc322adea14f5088bcf1b114003
using Managers.Contracts;
using Managers.Implementations;
using Features.ActWiki;

namespace HomeView_API.Controllers
{
    public class ActWikiController : Controller
    {
<<<<<<< HEAD
        private readonly IActWikiManager _actManager;
=======
        //private readonly ActWikiManager _actManager;
>>>>>>> 5fe1b6b8fa68adc322adea14f5088bcf1b114003
        
        public ActWikiController()
        {
         //   _actManager = new ActWikiManager();
        }
    }
}