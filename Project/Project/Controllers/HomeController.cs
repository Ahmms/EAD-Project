using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using CacheManager.Core;
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        
        public ViewResult Home()
        {
            return View("Home");
        }
        public ViewResult LoginHome()
        {
            List<Ads> ads = new List<Ads>();
            ads = HomeFunctions.getCars();

            return View(ads);
        }
    }
    public class LoginHomeController : Controller
    {
        
    }
}
