using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllNotifications()
        {
            var notifications = _notificationService.GetAll();
            return View(notifications);
        }
    }
}
