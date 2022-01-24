using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            ViewBag.TotalCount = _blogService.TotalNumberOfBlogs();            
            ViewBag.AuthorsBlog = _blogService.NumberOfAuthorsBlogs(1);
            ViewBag.CategoriesBlog = _blogService.NumberOfBlogsInCategory(2);
            return View();
        }
    }
}
