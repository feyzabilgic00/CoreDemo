using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly INotificationService _notificationService;
        public WriterNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IViewComponentResult Invoke(bool status = true)
        {
            var values = _notificationService.GetAllStatusTrue(status);
            return View(values);
        }
    }
}
