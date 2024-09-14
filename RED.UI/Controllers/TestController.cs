using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
