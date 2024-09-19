using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
