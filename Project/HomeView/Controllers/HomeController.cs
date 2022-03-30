using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HomeView.Models;
using Core.User;
using Managers.Contracts;

namespace HomeView.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        {
            
        }       

        public IActionResult Index()
        {
            return View();
            
        }
        
        public ActionResult LogIn(HomeModel homeM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IUserManager userManager = null;
                    var userInfo = userManager.GetUser(homeM._userEmail);
                    if (userInfo.Role == Role.Admin)
                    {
                        return View("../UAD/Index");
                    }
                    return View("../HomePage/Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
