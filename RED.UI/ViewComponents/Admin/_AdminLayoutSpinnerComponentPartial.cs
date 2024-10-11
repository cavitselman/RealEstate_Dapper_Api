using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutSpinnerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
