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
            var messages = _messageService.GetListInbox();
            return View(messages);
        }

        public IActionResult Outbox()
        {
            var messages = _messageService.GetListOutbox();
            return View(messages);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}
