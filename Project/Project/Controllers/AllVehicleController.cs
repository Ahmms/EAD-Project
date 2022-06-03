using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class AllVehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
