using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoffeShop.DAL;
using CoffeShop.Helpers;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {

        private readonly IMenuService _menuService;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _db;
        public MenuController(IMenuService menuService, IWebHostEnvironment env, AppDbContext db)
        {
            _menuService = menuService;
            _env = env;
            _db = db;

        }
        public IActionResult Index()
        {
            List<Menu> menu = _db.Menus.Include(x => x.Category).ToList();


            return View(menu);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category = _db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Menu menu, int catId)
        {
            ViewBag.Category = _db.Categories.ToList();

            if (menu.Photo == null)
            {
                ModelState.AddModelError("Photo", "Shekil sech");
                return View();
            }
            if (!menu.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Shekil formati sech");
                return View();
            }
            if (menu.Photo.IsOlder2Mb())
            {
                ModelState.AddModelError("Photo", "Max 2Mb");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "img");
            menu.Image = await menu.Photo.SaveImageAsync(folder);


            menu.CategoryId = catId;
            _menuService.TCreate(menu);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            ViewBag.Cat= _db.Categories.ToList();
            if (id == null)
            {
                return BadRequest();
            }

            List<Menu> menu = _menuService.TGetAll();
            Menu? dbm = menu.FirstOrDefault(x => x.MenuID == id);
            if (dbm == null)
            {
                return NotFound();
            }
            return View(dbm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Menu menu, int? id, int catId)
        {
            ViewBag.Cat = _db.Categories.ToList();
            if (id == null)
            {
                return BadRequest();
            }

            List<Menu> dbmenu = _menuService.TGetAll();
            Menu? dbm = dbmenu.FirstOrDefault(x => x.MenuID == id);
            if (dbm == null)
            {
                return NotFound();
            }
            if (menu.Photo != null)
            {
                if (!menu.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Shekil formati sech");
                    return View();
                }
                if (menu.Photo.IsOlder2Mb())
                {
                    ModelState.AddModelError("Photo", "Max 2Mb");
                    return View();
                }
                string folder = Path.Combine(_env.WebRootPath, "img");
                menu.Image = await menu.Photo.SaveImageAsync(folder);
            }
           
            dbm.Photo = menu.Photo;
            dbm.SubCategoryName= menu.SubCategoryName;
            dbm.Description= menu.Description;
            dbm.Price= menu.Price;
            dbm.Icons= menu.Icons;
            dbm.CategoryId = catId;
            _menuService.TUpdate(dbm);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            List<Menu> menuList = _menuService.TGetAll();
            Menu? menu = menuList.FirstOrDefault(x => x.MenuID == id);
            if (menu == null)
            {
                return NotFound();
            }
            _menuService.TDelete(menu);
            return RedirectToAction("Index");
        }
    }
}
