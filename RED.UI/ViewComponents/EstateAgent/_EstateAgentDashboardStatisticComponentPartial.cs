using Microsoft.AspNetCore.Mvc;

namespace RED.UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - ToplamİlanSayısı
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData;
            #endregion

            #region Statistics2 - EmlakçınınToplamİlanSayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=1");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = jsonData2;
            #endregion

            #region Statistics3 - AktifİlanSayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=1");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeStatusTrue = jsonData3;
            #endregion

            #region Statistics4 - PasifİlanSayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44383/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=1");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeStatusFalse = jsonData4;
            #endregion

            return View();
        }
    }
}
