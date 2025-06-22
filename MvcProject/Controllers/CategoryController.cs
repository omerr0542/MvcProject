using BusinessLayer.Concrete;
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
            List<Category> categories = _categoryManager.GetAllBL();
            return View(categories);
        }
    }
}
