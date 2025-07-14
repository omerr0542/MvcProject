using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        WriterValidator writerValidator = new WriterValidator();

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            var writers = _writerService.GetList(); 
            return View(writers);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            var result = writerValidator.Validate(p);
            
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(p); // Return the view with validation errors
            }

            _writerService.WriterAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writer = _writerService.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            var result = writerValidator.Validate(p);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(p); // Return the view with validation errors
            }

            _writerService.WriterUpdate(p);
            return RedirectToAction("Index"); 
        }
    }
}
