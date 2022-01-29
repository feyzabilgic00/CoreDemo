using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticFour : ViewComponent
    {
        private readonly IAdminService _adminService;
        public StatisticFour(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = _adminService.GetById(2).Name;
            ViewBag.ImageUrl = _adminService.GetById(2).ImageURL;
            ViewBag.Description = _adminService.GetById(2).ShortDescription;
            return View();
        }
    }
}
