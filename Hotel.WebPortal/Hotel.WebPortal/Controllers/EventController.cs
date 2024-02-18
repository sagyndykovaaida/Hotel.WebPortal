using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebPortal.Controllers
{
    public class EventController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
