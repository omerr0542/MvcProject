using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentManager;
        private readonly IWriterService _writerService;

        public WriterPanelContentController(IContentService contentService, IWriterService writerService)
        {
            _contentManager = contentService;
            _writerService = writerService;
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
    }
}
