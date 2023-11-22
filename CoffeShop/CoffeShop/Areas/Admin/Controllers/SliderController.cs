using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
