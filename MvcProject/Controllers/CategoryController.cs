using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            List<Category> categories = _categoryManager.GetList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            var result = categoryValidator.Validate(p);

            if(result.IsValid)
            {
                _categoryManager.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(); // Return the view with validation errors
            }
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
    }
}
