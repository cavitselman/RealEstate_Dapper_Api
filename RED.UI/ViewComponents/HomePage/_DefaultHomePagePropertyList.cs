using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.PropertyDTOs;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultHomePagePropertyList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePagePropertyList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/GetPropertyByDealOfTheDayTrueWithCategory");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDTO>> (jsonData);
                return View(values);
            }
            return View();
        }
    }
}
