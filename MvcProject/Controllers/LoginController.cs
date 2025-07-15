using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            bool isAuthorized = _adminService.Authorization(p);

            if (isAuthorized)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.AdminUserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "AdminCookie");

                await HttpContext.SignInAsync(
                    "AdminCookie",
                    new ClaimsPrincipal(claimsIdentity)
                );

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }
    }
}
