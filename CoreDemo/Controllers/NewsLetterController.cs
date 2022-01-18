using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsletterService;
        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsletterService = newsLetterService;
        }
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.Status = true;
            _newsletterService.Add(newsLetter);
            return PartialView();
        }
    }
}
