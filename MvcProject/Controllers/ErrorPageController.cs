using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403; // Forbidden
            return View();
        }

        public IActionResult Page404()
        {
            Response.StatusCode = 404; // Forbidden
            return View();
        }
    }
}
