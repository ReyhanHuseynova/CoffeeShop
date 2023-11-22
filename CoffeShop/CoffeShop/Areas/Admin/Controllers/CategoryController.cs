using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoffeShop.DAL;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService= categoryService;  
        }
        public IActionResult Index()
        {
            List<Category> categories = _categoryService.TGetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            List<Category> catList=_categoryService.TGetAll();
            bool isExist=catList.Any(x=>x.CategoryName==category.CategoryName); 
            if(isExist)
            {
                ModelState.AddModelError("CategoryName", "This category already exists!");
                return View();
            }

            try
            {
                _categoryService.TCreate(category);
                return RedirectToAction("Index");

            }catch (Exception)
            {
                string errorMessage = "Could not be created!";
                ViewBag.error = errorMessage;
                return View("Create");
            };
        }
     
    }
}
