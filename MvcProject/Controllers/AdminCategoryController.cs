using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public AdminCategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var categories = _categoryManager.GetList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if(result.IsValid)
            {
                _categoryManager.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int ID)
        {
            var category = _categoryManager.GetByID(ID);
            if (category != null)
            {
                _categoryManager.DeleteCategory(category);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int ID)
        {
            var category = _categoryManager.GetByID(ID);
            if (category != null)
            {
                return View(category);
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                _categoryManager.UpdateCategoty(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
