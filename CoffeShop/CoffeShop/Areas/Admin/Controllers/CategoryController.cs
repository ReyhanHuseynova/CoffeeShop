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
            _categoryService = categoryService;
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

            List<Category> catList = _categoryService.TGetAll();
            bool isExist = catList.Any(x => x.CategoryName == category.CategoryName);
            if (isExist)
            {
                ModelState.AddModelError("CategoryName", "This category already exists!");
                return View();
            }

            try
            {
                _categoryService.TCreate(category);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                string errorMessage = "Could not be created!";
                ViewBag.error = errorMessage;
                return View("Create");
            };
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Category> catList = _categoryService.TGetAll();
            Category? dbCategory = catList.FirstOrDefault(x => x.CategoryID == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }
            return View(dbCategory);
        }

        [HttpPost]
        public IActionResult Update(Category category, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Category> catList = _categoryService.TGetAll();
            Category? dbCategory = catList.FirstOrDefault(x => x.CategoryID == id );
            if (dbCategory == null)
            {
                return BadRequest();
            }
            bool isExist = catList.Any(x => x.CategoryName == category.CategoryName && x.CategoryID != id);
            if (isExist)
            {
                ModelState.AddModelError("CategoryName", "This category is already exist");
                return View();

            }

            dbCategory.CategoryName = category.CategoryName;
            _categoryService.TUpdate(dbCategory);

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            List<Category> catDelete = _categoryService.TGetAll();
            Category? dbCategory = catDelete.FirstOrDefault(x => x.CategoryID == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }
            _categoryService.TDelete(dbCategory);
            return RedirectToAction("Index");
            //if(dbCategory.IsDeactive)
            //{
            //    dbCategory.IsDeactive = false;
            //}
            //else
            //{
            //    dbCategory.IsDeactive = true;   
            //}

            //return RedirectToAction("Index");
        }
    }
}

