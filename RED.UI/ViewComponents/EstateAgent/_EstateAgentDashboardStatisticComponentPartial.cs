using Microsoft.AspNetCore.Mvc;
using RED.UI.Services;

namespace RED.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region Statistics1 - ToplamİlanSayısı
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/AllPropertyCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.PropertyCount = jsonData;
            #endregion

            #region Statistics2 - EmlakçınınToplamİlanSayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/PropertyCountByEmployeeId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByPropertyCount = jsonData2;
            #endregion

            #region Statistics3 - AktifİlanSayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/PropertyCountByStatusTrue?id=" + id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.PropertyCountByEmployeeStatusTrue = jsonData3;
            #endregion

            #region Statistics4 - PasifİlanSayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/PropertyCountByStatusFalse?id=" + id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.PropertyCountByEmployeeStatusFalse = jsonData4;
            #endregion

            return View();
        }
    }
}
