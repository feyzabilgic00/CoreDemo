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
        private readonly IWriterService _writerService;
        private readonly IValidator<Blog> _validator;
        public BlogController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService, IValidator<Blog> validator)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _writerService = writerService;
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
            var userMail = User.Identity.Name;
            var writerUser = _writerService.GetWriter(userMail);
            var values = _blogService.GetListWithCategoryByWriter(writerUser);
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

            var userMail = User.Identity.Name;
            var writerId = _writerService.GetWriter(userMail);

            if (result.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;                
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
        public IActionResult DeleteBlog(int id)
        {
            var deleteBlog = _blogService.GetById(id);
            if (deleteBlog != null)
            {
                _blogService.Delete(deleteBlog);
                return RedirectToAction("BlogListByWriter");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> categories = (from c in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = c.CategoryName,
                                                   Value = c.Id.ToString()
                                               }).ToList();

            //TempData["BlogCreateDate"] = blogValue.CreateDate;

            ViewBag.Categories = categories;
            var blogValue = _blogService.GetById(id);
            
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = _writerService.GetWriter(userMail);
            blog.WriterId = writerId;
            //ViewBag.BlogCreateDate = TempData["BlogCreateDate"];
            //blog.CreateDate = ViewBag.BlogCreateDate;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
