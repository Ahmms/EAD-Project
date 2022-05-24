using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
namespace Project.Controllers
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public ViewResult SignUp()
        {
            return View("SignUpPage");
        }
        [HttpPost]
        public ViewResult SignUp(SignUp su)
        {
            users_repository.Add_Users(su);
            SignIn si = new SignIn();
            si.message = "";
            return View("~/Views/SignIn/SignInPage.cshtml",si);
        }
    }
}
