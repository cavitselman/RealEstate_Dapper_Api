using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    public class MyAdvertsController : Controller
    {
        [Area("EstateAgent")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
