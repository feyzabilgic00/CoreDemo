using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetBlogListWithCategory();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            var blog = _blogService.GetBlogById(id);
            return View(blog);
        }
    }
}
