using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;

        public WriterPanelController(IHeadingService headingService)
        {
            _headingService = headingService;
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult MyHeading(int id)
        {
            id = 1;

            var values = _headingService.GetListByWriter(id); 
            return View(values);
        }
    }
}
