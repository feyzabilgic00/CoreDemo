using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IActionResult InBox()
        {
            var values = _messageService.GetInboxListByWriter(3);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var messageId = _messageService.GetById(id);
            return View(messageId);
        }
    }
}
