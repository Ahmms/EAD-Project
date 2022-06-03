using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class PostAdController : Controller
    {
        public ViewResult Ads()
        {
            return View("Ads");
        }
        public IActionResult AdsView(Ads ad)
        {

            return View("");

        }

    }
}
