using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultOurClientsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
