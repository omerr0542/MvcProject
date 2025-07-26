using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public WriterPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Inbox()
        {
            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi

            var messages = _messageService.GetListInbox(userMail);
            return View(messages);
        }

        public IActionResult Outbox()
        {
            string userMail = User.Identity.Name; // Login olan kullanıcının mail adresi

            var messages = _messageService.GetListOutbox(userMail);
            return View(messages);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}
