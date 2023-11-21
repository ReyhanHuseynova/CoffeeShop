using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;
        public ServiceController(AppDbContext db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
            List<Service>services=_db.Services.ToList();
            return View(services);
        }
    }
}
