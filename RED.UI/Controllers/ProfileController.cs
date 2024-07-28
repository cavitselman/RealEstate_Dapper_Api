using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
