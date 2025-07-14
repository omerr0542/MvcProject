using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ContentByHeading(int HeadingID)
        {
            return View();
        }
    }
}
