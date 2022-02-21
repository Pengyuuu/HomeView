using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeView.Models;

namespace HomeView.Controllers
{
    public class UADController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
