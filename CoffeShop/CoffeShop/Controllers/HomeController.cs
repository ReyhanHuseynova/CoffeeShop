using CoffeShop.DAL;
using CoffeShop.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
                _db = db;
        }

        public IActionResult Index()
        {
            List<Slider>slider= _db.Sliders.ToList();
            return View(slider);
        }

        

       
    }
}