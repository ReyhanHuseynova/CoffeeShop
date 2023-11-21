using CoffeShop.DAL;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        public ContactController(AppDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            List<Contact> contacts=_db.Contacts.ToList();   
            return View(contacts);
        }
    }
}
