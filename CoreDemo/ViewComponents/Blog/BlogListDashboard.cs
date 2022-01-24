using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        private readonly IBlogService _blogService;
        public BlogListDashboard(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke(DateTime createDate)
        {
            var values = _blogService.GetBlogListWithCategory().Take(10).OrderByDescending(x => x.CreateDate);
            return View(values);
        }
    }
}
