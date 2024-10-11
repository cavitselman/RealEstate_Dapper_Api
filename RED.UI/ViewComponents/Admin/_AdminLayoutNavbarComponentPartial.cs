using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
