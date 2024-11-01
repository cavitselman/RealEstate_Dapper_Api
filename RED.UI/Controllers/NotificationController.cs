using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateNotificationSettings(bool announcement, bool message, bool announcementNotification, bool taskNotification)
        {
            // Burada ayarları kaydetmek için gerekli işlemleri yapın
            // Örneğin, kullanıcı ayarlarını veritabanına kaydedebilirsiniz.

            // Örnek: Ayarları loglamak
            // LogAyarlari(announcement, message, announcementNotification, taskNotification);

            return RedirectToAction("Index");
        }
    }
}
