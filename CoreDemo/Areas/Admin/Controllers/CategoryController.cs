using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    /* CategoryController içerisinde oluşturulmuş olan action ların area dan 
     geldiğini belirtmiş oluyorum. */

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        public CategoryController(ICategoryService categoryService, IValidator<Category> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }
        public IActionResult Index(int page = 1)
        {
            /*ToPagedList metodu iki parametre almaktadır. İlk parametre sayfalamanın
             kaçıncı sayfadan itibaren yapılacağını belirtir. İkinci parametre her sayfada
             kaç tane değerin olacağını belirtiyorsun.*/

            var categories = _categoryService.GetAll().ToPagedList(page,3);
            return View(categories);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            ValidationResult result = _validator.Validate(category);
            if (result.IsValid)
            {
                category.Status = true;
                _categoryService.Add(category);
                return RedirectToAction("Index");
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
        public IActionResult PassiveCategory(int id)
        {
            _categoryService.EditStatus(id);
            return RedirectToAction("Index");
        }
        public IActionResult ActiveCategory(int id)
        {
            _categoryService.EditStatus(id);
            return RedirectToAction("Index");
        }
    }
}
