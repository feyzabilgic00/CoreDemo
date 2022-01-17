using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    /*Proje seviyesinde tanımlamış olduğum bütün kurallardan
    muaf olması için tanımladık.*/

    //[AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var dataValue = _loginService.Login(writer);
            if (dataValue != null)
            {
                //HttpContext.Session.SetString("username", writer.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writer.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "username");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }            
        }
    }
}
