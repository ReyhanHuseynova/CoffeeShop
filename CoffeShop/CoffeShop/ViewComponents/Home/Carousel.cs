using CoffeShop.DAL;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.ViewComponents.Home
{
    public class Carousel:ViewComponent
    {
       private readonly AppDbContext _db;
        public Carousel(AppDbContext db)
        {
            _db = db;  
        }
        public IViewComponentResult Invoke()
        {
            var values= _db.Sliders.ToList();
            return View(values);
        }

    }
}
