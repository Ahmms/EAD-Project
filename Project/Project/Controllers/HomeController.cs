using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Home()
        {
            return View("Home");
        }

    }
}
