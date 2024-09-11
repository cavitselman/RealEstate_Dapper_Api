using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
