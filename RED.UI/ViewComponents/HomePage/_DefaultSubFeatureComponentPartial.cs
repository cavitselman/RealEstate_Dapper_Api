using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
