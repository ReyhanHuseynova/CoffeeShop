using BusinessLayer.Abstract;
using CoffeShop.Helpers;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceTableService _serviceTableService;
        private readonly IWebHostEnvironment _env;
        public ServiceController(IServiceTableService serviceTableService, IWebHostEnvironment env)
        {
            _serviceTableService = serviceTableService;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Service>services=_serviceTableService.TGetAll();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (service.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil sech");
                return View();
            }
            if (!service.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil formati sech");
                return View();
            }
            if (service.Photo.IsOlder2Mb())
            {
                ModelState.AddModelError("Photo", "Max 2Mb");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "img");
            service.Image = await service.Photo.SaveImageAsync(folder);

            _serviceTableService.TCreate(service);
            return RedirectToAction("Index");       
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Service> services = _serviceTableService.TGetAll();
            Service? dbs = services.FirstOrDefault(x => x.ServiceId == id);
            if (dbs == null)
            {
                return NotFound();
            }
            return View(dbs);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Service service, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Service> dbService = _serviceTableService.TGetAll();
            Service? dbs = dbService.FirstOrDefault(x => x.ServiceId == id);
            if (dbs == null)
            {
                return NotFound();
            }
            if (service.Photo != null)
            {
                if (!service.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil formati sech");
                    return View();
                }
                if (service.Photo.IsOlder2Mb())
                {
                    ModelState.AddModelError("Photo", "Max 2Mb");
                    return View();
                }
                string folder = Path.Combine(_env.WebRootPath, "img");
                dbs.Image = await service.Photo.SaveImageAsync(folder);
            }

            dbs.Header = service.Header;
            dbs.Description = service.Description;
            dbs.Icons = service.Icons;
           

            _serviceTableService.TUpdate(dbs);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            List<Service> sList = _serviceTableService.TGetAll();
            Service? service = sList.FirstOrDefault(x => x.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }
            _serviceTableService.TDelete(service);
            return RedirectToAction("Index");
        }
    }
}
