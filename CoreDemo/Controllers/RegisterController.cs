using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IValidator<Writer> _validator;
        public RegisterController(IWriterService writerService, IValidator<Writer> validator)
        {
            _writerService = writerService;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            //WriterValidator validationRules = new WriterValidator();
            ValidationResult result = _validator.Validate(writer);

            if (result.IsValid)
            {
                writer.Status = true;
                writer.About = "Deneme Test";
                _writerService.Add(writer);
                return RedirectToAction("Index", "Blog");
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
