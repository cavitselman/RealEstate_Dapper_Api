using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
