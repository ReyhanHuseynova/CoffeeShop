using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            List<Reservation> reservations= _reservationService.TGetAll().Where(x => x.IsDeactive == false).ToList();
            return View(reservations);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
             
            _reservationService.TCreate(reservation);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Reservation> r=_reservationService.TGetAll();
            Reservation ?dbr=r.FirstOrDefault(x=>x.ReservationID==id);
            if (dbr == null)
            {
                return NotFound();
            }
            return View(dbr);
        }
        [HttpPost]
        public IActionResult Update(Reservation reservation, int?id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Reservation> r = _reservationService.TGetAll();
            Reservation? dbr = r.FirstOrDefault(x => x.ReservationID == id);
            if (dbr == null)
            {
                return NotFound();
            }
            dbr.Name= reservation.Name;
            dbr.Surname= reservation.Surname;
            dbr.Date= reservation.Date;
            dbr.PersonCount= reservation.PersonCount;
            _reservationService.TUpdate(dbr);
            return RedirectToAction("Index");   
        }

        public IActionResult Delete(int ?id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Reservation>r= _reservationService.TGetAll();
            Reservation ?res=r.FirstOrDefault(x=>x.ReservationID==id);
            if(res == null)
            {
                return NotFound();
            }
            _reservationService.TDelete(res);
            return RedirectToAction("Index");   
        }
    }
}
