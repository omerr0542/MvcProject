using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
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

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage(Message p)
        {
            return View();
        }

        public IActionResult GetInboxMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }
    }
}
