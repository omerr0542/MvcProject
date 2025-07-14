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

        public IActionResult ContentByHeading(int id)
        {
            var contents = _contentManager.GetListByHeadingID(id);
            return View(contents);
        }
    }
}
