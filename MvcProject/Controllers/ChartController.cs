using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            return Json(BlogList());
        }

        public List<Models.CategoryClass> BlogList()
        {
            var categories = new List<Models.CategoryClass>
            {
                new Models.CategoryClass { CategoryName = "Category 1", CategoryCount = 10 },
                new Models.CategoryClass { CategoryName = "Category 2", CategoryCount = 20 },
                new Models.CategoryClass { CategoryName = "Category 3", CategoryCount = 30 }
            };
            return categories;
        }

    }
}
