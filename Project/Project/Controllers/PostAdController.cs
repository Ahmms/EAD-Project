using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Project.Controllers
{
    public class PostAdController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        public PostAdController(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
        public ViewResult Ads()
        {
            return View("Ads");
        }
        public IActionResult AdsView(Ads ad,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                ad.userName = Environment.GetEnvironmentVariable("userId");
                string str=AdsFunction.getId();
                if (image != null)
                {
                    string filename = "images/AdImages/" + str + ".png";
                    string Serverfilename = Path.Combine(_webHostEnvironment.WebRootPath, filename);
                    FileStream f = new FileStream(Serverfilename, FileMode.Create);
                    //ad.image1.CopyTo(f);
                    f.Close();
                    ad.image = filename;
                }
                else
                {
                    ad.image = "";
                }
                AdsFunction.uploadAd(ad);
                return View("Ads");
            }
            else
            {
                return View();
            }

        }

    }
}
