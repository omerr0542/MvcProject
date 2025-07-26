using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // ../Views/Home/Index.cshtml dosyas� ile e�le�ir bu fonksiyon tetiklendi�inde Index.cshtml dosyas� render edilir
        {
            return View();
        }

        public IActionResult Privacy() // ../Views/Home/Privacy.cshtml dosyas� ile e�le�ir
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
