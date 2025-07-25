using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentManager;
        private readonly IWriterService _writerService;
        private readonly IHeadingService _headingService;

        public WriterPanelContentController(IContentService contentService, IWriterService writerService, IHeadingService headingService)
        {
            _contentManager = contentService;
            _writerService = writerService;
            _headingService = headingService;
        }

        public IActionResult MyContent()
        {
            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi
            var writer = _writerService.GetList().FirstOrDefault(x => x.WriterMail == userMail);
            if (writer == null)
            {
                return NotFound();
            }

            var contents = _contentManager.GetListByWriterID(writer.WriterID);
            return View(contents);
        }

        [HttpGet]
        public IActionResult AddContent(int id)
        {
            ViewBag.headingID = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddContent(Content p)
        {
            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi
            var writer = _writerService.GetList().FirstOrDefault(x => x.WriterMail == userMail);

            p.ContentDate = DateTime.Now;
            p.ContentStatus = true;
            p.WriterID = writer.WriterID;

            _contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public IActionResult ToDoList()
        {
            return View();
        }

    }
}
