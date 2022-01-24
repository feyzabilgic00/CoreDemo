using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageService _messageService;
        public WriterMessageNotification(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IViewComponentResult Invoke()
        {
            string receiver;
            receiver = "feyzabilgic00@gmail.com";
            var values = _messageService.GetInboxListByWriter(receiver);
            return View(values);
        }
    }
}
