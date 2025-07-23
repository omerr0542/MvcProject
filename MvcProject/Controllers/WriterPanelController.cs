using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;
        HeadingValidator headingValidator = new HeadingValidator();
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult MyHeading(int id)
        {
            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi
            var writer = _writerService.GetList().FirstOrDefault(x => x.WriterMail == userMail);
            if (writer == null)
            {
                return NotFound();
            }

            var values = _headingService.GetListByWriterWithIncludes(writer.WriterID).Where(x => x.HeadingStatus == true).ToList(); 
            return View(values);
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

            ViewBag.CategoryList = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult AddHeading(Heading p)
        {

            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi
            var writer = _writerService.GetList().FirstOrDefault(x => x.WriterMail == userMail);

            p.WriterID = writer.WriterID;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;

            var result = headingValidator.Validate(p);

            if (!result.IsValid)
            {
                ViewBag.CategoryList = _categoryService.GetList()
                    .Select(x => new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }).ToList();

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(p);
            }

            _headingService.HeadingAdd(p);

            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            var heading = _headingService.GetByIdWithIncludes(id);
            if (heading == null)
            {
                return NotFound();
            }

            var categoryList = _categoryService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();


            ViewBag.CategoryList = categoryList;
            return View(heading);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading p)
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

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View(p);
            }

            _headingService.HeadingUpdate(p);

            return RedirectToAction("MyHeading");
        }

        public IActionResult DeleteHeading(int id)
        {
            var heading = _headingService.GetById(id);
            if (heading == null)
            {
                return NotFound();
            }
            heading.HeadingStatus = false; // Başlığı silmek yerine durumunu false yapıyoruz
            _headingService.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
    }
}
