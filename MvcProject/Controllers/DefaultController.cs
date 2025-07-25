using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;
        private readonly IWriterService _writerService;

        public DefaultController(IHeadingService headingService, IContentService contentService, IWriterService writerService)
        {
            _headingService = headingService;
            _contentService = contentService;
            _writerService = writerService;
        }

        [AllowAnonymous]
        public IActionResult Headings(int id = 0)
        {
            var headings = _headingService.GetAllWithIncludes();

            var contents = _contentService.GetListByHeadingID(id);
            ViewBag.Contents = contents;
            return View(headings);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contents = _contentService.GetListByHeadingID(id);
            return PartialView(contents);
        }
        
    }
}
