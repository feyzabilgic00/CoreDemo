using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IWriterService _writerService;
        public WriterMessageNotification(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
