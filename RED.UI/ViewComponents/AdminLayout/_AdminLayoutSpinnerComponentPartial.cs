using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSpinnerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
