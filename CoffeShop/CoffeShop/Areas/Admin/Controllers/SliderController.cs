using BusinessLayer.Abstract;
using CoffeShop.DAL;
using CoffeShop.Helpers;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;
        public SliderController(ISliderService sliderService, IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _sliderService.TGetAll();
            return View(sliders);
        }

        public async Task<IActionResult> Create()
        {
          return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider s)
        {
            if (s.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil sech");
                return View();
            }
            if (!s.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil formati sech");
                return View();
            }
            if (s.Photo.IsOlder2Mb())
            {
                ModelState.AddModelError("Photo", "Max 2Mb");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "img");
            s.Image = await s.Photo.SaveImageAsync(folder);

            _sliderService.TCreate(s);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Slider> slider = _sliderService.TGetAll();
            Slider? dbs = slider.FirstOrDefault(x => x.SliderID == id);
            if (dbs == null)
            {
                return NotFound();
            }
            return View(dbs);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Slider slider, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Slider> dbSlider = _sliderService.TGetAll();
            Slider? dbs = dbSlider.FirstOrDefault(x => x.SliderID == id);
            if (dbs== null)
            {
                return NotFound();
            }
            if (slider.Photo != null)
            {
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil formati sech");
                    return View();
                }
                if (slider.Photo.IsOlder2Mb())
                {
                    ModelState.AddModelError("Photo", "Max 2Mb");
                    return View();
                }
                string folder = Path.Combine(_env.WebRootPath, "img");
                dbs.Image = await slider.Photo.SaveImageAsync(folder);
            }

            dbs.SinceText = slider.SinceText ;
            dbs.ServingText = slider.ServingText;
            dbs.CoffeeHeading = slider.CoffeeHeading;
           
            _sliderService.TUpdate(dbs);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            List<Slider> sList = _sliderService.TGetAll();
            Slider? slider = sList.FirstOrDefault(x => x.SliderID == id);
            if (slider == null)
            {
                return NotFound();
            }
            _sliderService.TDelete(slider);
            return RedirectToAction("Index");
        }
    }
}
