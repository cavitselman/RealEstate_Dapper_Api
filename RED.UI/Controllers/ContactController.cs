using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {//https://localhost:44383/api/Contacts
            return View();
        }
    }
}
