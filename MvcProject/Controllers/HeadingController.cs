using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingManager;
        HeadingValidator headingValidator = new HeadingValidator();
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public HeadingController(IHeadingService headingManager, ICategoryService categoryService, IWriterService writerService)
        {
            _headingManager = headingManager;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            var headings = _headingManager.GetAllWithIncludes();
            return View(headings);
        }

        [HttpGet]
        public IActionResult AddHeading()
        {
            var categoryList = _categoryService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();

            var writerList = _writerService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.WriterName,
                    Value = x.WriterID.ToString()
                }).ToList();

            ViewBag.CategoryList = categoryList;
            ViewBag.WriterList = writerList;

            return View();
        }

        [HttpPost]
        public IActionResult AddHeading(Heading p)
        {
            var result = headingValidator.Validate(p);

            if (!result.IsValid)
            {
                ViewBag.CategoryList = _categoryService.GetList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }).ToList();

                ViewBag.WriterList = _writerService.GetList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.WriterName,
                        Value = x.WriterID.ToString()
                    }).ToList();

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(p);
            }

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.HeadingAdd(p);

            return RedirectToAction("Index");
        }

    }
}
