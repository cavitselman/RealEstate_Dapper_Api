using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Areas.EstateAgent.ViewComponents
{
    public class _EstateAgentNavbarMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
