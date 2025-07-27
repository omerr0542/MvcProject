using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class AuthorizationController : Controller
    {

        private readonly IAdminService _adminService;

        public AuthorizationController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View(_adminService.GetAll());
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            _adminService.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var admin = _adminService.GetById(id);
            return View(admin);
        }

        [HttpPost]
        public IActionResult EditAdmin(Admin admin)
        {
            _adminService.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}
