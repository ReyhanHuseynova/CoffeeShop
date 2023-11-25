using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _db;
        public ReservationController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            reservation.IsDeactive = false;
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

