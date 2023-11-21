using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;    
        }
        public IActionResult Index()
        {
            ViewBag.About2=_db.Abouts2.ToList();
            List<About> abouts= _db.Abouts.ToList();    
            return View(abouts);
        }
    }
}
