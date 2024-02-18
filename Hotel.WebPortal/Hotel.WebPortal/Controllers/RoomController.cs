using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebPortal.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment host;
        public RoomController(IWebHostEnvironment host)
        {
            this.host = host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]

        public IActionResult SubscribeClient(IFormFile userFile)
        {
            string path = Path.Combine(host.WebRootPath,"UserFiles", userFile.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                userFile.CopyTo(stream);
            }

            return View();
        }


    }
}
