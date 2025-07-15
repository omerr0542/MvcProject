using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        ContactValidator contactValidator = new ContactValidator();

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        public IActionResult GetContactDetails(int id)
        {
            var contactValue = _contactService.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}
