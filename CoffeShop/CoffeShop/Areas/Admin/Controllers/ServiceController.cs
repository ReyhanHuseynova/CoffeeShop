using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
