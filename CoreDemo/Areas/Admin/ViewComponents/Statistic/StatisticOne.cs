using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticOne : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IContactService _contactService;
        private readonly ICommentService _commentService;
        public StatisticOne(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = _blogService.GetAll().Count();
            ViewBag.ContactCount = _contactService.GetAll().Count();
            ViewBag.CommentCount = _commentService.GetAll().Count();

            string api = "49e1ad9a2e937f12d08addda6819fc37";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Temparature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.Weather = document.Descendants("weather").ElementAt(0).Attribute("value").Value;
            ViewBag.WeatherIcon = document.Descendants("weather").ElementAt(0).Attribute("icon").Value;
            return View();
        }
    }
}
