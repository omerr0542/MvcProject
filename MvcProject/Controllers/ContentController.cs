using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentManager;

        public ContentController(IContentService contentService)
        {
            _contentManager = contentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllContent(string p = "")
        {
            var contents = _contentManager.GetAllWithIncludes().ToList().Where(x => x.ContentValue.Contains(p));
            return View(contents);
        }

        public IActionResult ContentByHeading(int id)
        {
            var contents = _contentManager.GetListByHeadingID(id);
            return View(contents);
        }
    }
}
