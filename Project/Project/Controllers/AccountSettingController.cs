using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class AccountSettingController : Controller
    {
        public ViewResult Index()
        {
            return View("changePassword");
        }
        public IActionResult changePassword(AccountSetting AS)
        {
            AccountSettingFunctions.changePassword(AS);
            return View("changePassword");
        }
    }
}
