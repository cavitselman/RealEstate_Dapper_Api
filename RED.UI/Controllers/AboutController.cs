using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
