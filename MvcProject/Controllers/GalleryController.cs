using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImageFileService _imageFileService;

        public GalleryController(IImageFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        public IActionResult Index()
        {
            return View(_imageFileService.GetList());
        }
    }
}
