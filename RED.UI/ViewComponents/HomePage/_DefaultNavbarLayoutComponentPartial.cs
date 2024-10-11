using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultNavbarLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
