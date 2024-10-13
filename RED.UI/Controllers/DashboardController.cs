using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolü olan kullanıcılar erişebilir
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
