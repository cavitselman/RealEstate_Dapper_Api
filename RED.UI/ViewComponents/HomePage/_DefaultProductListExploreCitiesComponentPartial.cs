using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultProductListExploreCitiesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
