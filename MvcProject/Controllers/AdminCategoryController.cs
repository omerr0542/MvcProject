using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
