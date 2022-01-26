using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    /* CategoryController içerisinde oluşturulmuş olan action ların area dan 
     geldiğini belirtmiş oluyorum. */

    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
