using Microsoft.AspNetCore.Mvc;

namespace CheckersProject.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
