using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _db;
        public MenuController(AppDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            List<Category> cat= _db.Categories.Include(x=>x.Menus).ToList();
            return View(cat);
        }


    }
}
