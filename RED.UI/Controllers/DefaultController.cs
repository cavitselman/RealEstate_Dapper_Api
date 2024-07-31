using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
