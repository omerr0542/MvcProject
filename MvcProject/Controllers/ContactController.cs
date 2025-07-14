using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
