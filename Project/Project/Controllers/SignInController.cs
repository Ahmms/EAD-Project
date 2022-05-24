using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
namespace Project.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public ViewResult SignIn()
        {
            SignIn si = new SignIn();
            si.message = "";
            return View("SignInPage",si);
        }
        [HttpPost]
        public ViewResult SignIn(SignIn si)
        {
            bool check = SignIn_functions.credential_verification(si);
            if (check == true)
            {
                Home_Class hs = new Home_Class();
                return View("~/Views/Home/Home.cshtml", hs.DisplayUsers());
            }
            else
            {
                si.message = "Invalid UserName or Password!";
                return View("SignInPage",si);
            }
        }
    }
}
