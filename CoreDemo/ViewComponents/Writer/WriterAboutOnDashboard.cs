using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;
        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IViewComponentResult Invoke()
        {
            /* Aktif kullanıcının Name değerini almak için kullandık.  */
            var userMail = User.Identity.Name;
            var writerId = _writerService.GetWriter(userMail);
            var values = _writerService.GetById(writerId);
            return View(values);
        }
    }
}
