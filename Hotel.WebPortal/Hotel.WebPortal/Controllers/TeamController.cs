using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebPortal.Controllers
{
    public class TeamController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
