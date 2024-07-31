using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
