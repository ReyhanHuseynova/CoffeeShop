using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
