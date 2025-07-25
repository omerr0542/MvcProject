using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IWriterService _writerService;

        public LoginController(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
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

        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterLogin(Writer w)
        {
            bool isAuthorized = _writerService.Authorization(w);

            if (isAuthorized)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, w.WriterMail)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "UserCookie");
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("AdminCookie");
            HttpContext.SignOutAsync("UserCookie");
            return RedirectToAction("Headings", "Default");
        }
    }
}
