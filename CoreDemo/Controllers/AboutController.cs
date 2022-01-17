﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;  
        }
        public IActionResult Index()
        {
            var abouts = _aboutService.GetAbouts();
            return View(abouts);
        }
        public PartialViewResult SocialMediaAbout()
        {            
            return PartialView();
        }
    }
}
