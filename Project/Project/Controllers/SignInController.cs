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
        public IActionResult SignIn(SignIn si)
        {
            if (ModelState.IsValid)
            {
                bool check = SignIn_functions.credential_verification(si);
                if (check == true)
                {
                    // return View("~/Views/Home/LoginHome.cshtml", hs.DisplayUsers());
                    return RedirectToAction("LoginHome", "Home");
                }
                else
                {
                    si.message = "Invalid UserName or Password!";
                    return View("SignInPage", si);
                }
            }
            else
            {
                return View("SignInPage");
            }
        }
    }
}
