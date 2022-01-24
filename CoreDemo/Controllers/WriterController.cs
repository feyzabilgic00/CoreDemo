using AutoMapper;
using BusinessLayer.Abstract;
using CoreDemo.Models;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IValidator<Writer> _validator;
        private readonly IMapper _mapper;
        public WriterController(IWriterService writerService, IValidator<Writer> validator, IMapper mapper)
        {
            _writerService = writerService;
            _validator = validator;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterHeaderPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writerValues = _writerService.GetById(1); 
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            ValidationResult results = _validator.Validate(writer);
            if (results.IsValid)
            {
                writer.Image = "deneme";
                _writerService.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(AddProfileImage writer)
        {
            Writer w = new Writer();
            if (writer.Image != null)
            {
                var extension = Path.GetExtension(writer.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writer.Image.CopyTo(stream);
                w.Image = newImageName;
            }
            _writerService.Add(_mapper.Map<Writer>(writer));
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
