using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebPortal.Controllers
{
    public class LocationController : Controller
    {
  
        public IActionResult Index()
        {
            return View();
        }
    }
}
