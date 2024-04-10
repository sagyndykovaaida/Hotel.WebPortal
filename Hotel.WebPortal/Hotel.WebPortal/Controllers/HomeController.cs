using Hotel.WebPortal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;

namespace Hotel.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
        }
        //[TimeElaps]
        [CatchError]
        public IActionResult Index(string culture)
        {
            throw new Exception(" error");


            if (!string.IsNullOrEmpty(culture))
            {
                CultureInfo.CurrentCulture = new CultureInfo(culture);
                CultureInfo.CurrentUICulture = new CultureInfo(culture);
            }
          

            HttpContext.Session.SetString(".ATR.IIN", "5678909876");
            var data = HttpContext.Session.GetString(".ATR.IIN");


            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Append("IIN", "0212220551268");

            _httpContext.HttpContext.Response.Cookies.Append("IIN2", "345423");

            //---------------
            var data1 = Request.Cookies["IIN"];
            var data2 = _httpContext.HttpContext.Request.Cookies["IIN2"];

            //--------- delete cookies

            Response.Cookies.Delete("IIN");
            _httpContext.HttpContext.Response.Cookies.Delete("IIN2");

            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if(login == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , login)
                };
            var claimIdentity = new ClaimsIdentity(claims, "Login");

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity)
                    );

            }
            return RedirectToAction("Index");   
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();


            return RedirectToAction("Index");   
        }
    }
}