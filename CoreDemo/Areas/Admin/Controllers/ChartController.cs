using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel { CategoryCount = 10, CategoryName = "Teknoloji" });
            list.Add(new CategoryModel { CategoryCount = 14, CategoryName = "Yazılım" });
            list.Add(new CategoryModel { CategoryCount = 5, CategoryName = "Spor" });

            return Json(new { jsonList = list });
        }
    }
}
