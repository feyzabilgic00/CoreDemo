using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogLastThreePost : ViewComponent
    {
        private readonly IBlogService _blogService;
        public BlogLastThreePost(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetLastThreeBlog();
            return View(values);
        }
    }
}
