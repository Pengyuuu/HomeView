using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HomeView.Models;
using Core.User;

namespace HomeView.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly IUserManager _userManager;

        public UserHomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(HomeModel userLoggedIn)
        {
           
            return View();
        }
    }
}
