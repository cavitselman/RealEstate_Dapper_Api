using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
