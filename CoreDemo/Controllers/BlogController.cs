using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Blog> _validator;
        public BlogController(IBlogService blogService, ICategoryService categoryService, IValidator<Blog> validator)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var blogs = _blogService.GetBlogListWithCategory();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            var blog = _blogService.GetBlogById(id);
            return View(blog);
        }
        public IActionResult BlogListByWriter()
        {
            var values = _blogService.GetListWithCategoryByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categories = (from c in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = c.CategoryName,
                                                   Value =  c.Id.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            ViewData["CategoryId"] = ViewBag.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            ViewBag.Categories = ViewData["CategoryId"];
            ValidationResult result = _validator.Validate(blog);    
            if (result.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;                
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
