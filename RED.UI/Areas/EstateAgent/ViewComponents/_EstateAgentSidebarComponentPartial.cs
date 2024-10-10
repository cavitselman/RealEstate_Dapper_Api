using Microsoft.AspNetCore.Mvc;

namespace RED.UI.Areas.EstateAgent.ViewComponents
{
    public class _EstateAgentSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
