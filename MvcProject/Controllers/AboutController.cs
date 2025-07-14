using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutManager;

        public AboutController(IAboutService aboutService)
        {
            _aboutManager = aboutService;
        }

        public IActionResult Index()
        {
            var aboutValues = _aboutManager.GetAll();

            return View(aboutValues);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About p)
        {
            _aboutManager.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}
