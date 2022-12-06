using Microsoft.AspNetCore.Mvc;

namespace booklib.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
