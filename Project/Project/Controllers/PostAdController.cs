using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace Project.Controllers
{
    public class PostAdController : Controller
    {
        public ViewResult Ads()
        {
            return View("Ads");
        }
        public IActionResult AdsView(Ads ad,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                ad.userName = Environment.GetEnvironmentVariable("userId");
                if (image != null)
                {
                    Byte[] fileBytes;
                    //MemoryStream memoryStream = new MemoryStream();
                    //image.OpenReadStream().CopyTo(memoryStream);
                    //ad.image = Convert.ToBase64String(memoryStream.ToArray());
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                    ad.photo = fileBytes;
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
