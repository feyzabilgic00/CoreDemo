using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticTwo : ViewComponent
    {
        private readonly IBlogService _blogService;
        public StatisticTwo(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = _blogService.GetAll().OrderByDescending(x => x.Id).Select(x => x.Title).Take(1).First();
            return View();
        }
    }
}
