using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
