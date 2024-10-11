using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
