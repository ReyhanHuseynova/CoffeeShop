using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _db;
        public TestimonialController(AppDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            List<Testimonial> testimonials= _db.Testimonials.ToList();
            return View(testimonials);
        }
    }
}
