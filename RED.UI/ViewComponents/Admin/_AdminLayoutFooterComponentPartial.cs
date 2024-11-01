using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
