using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.PropertyDTOs;

namespace RED.UI.ViewComponents.HomePage
{
    public class _DefaultDiscountOfDayComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultDiscountOfDayComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/GetLast3Property");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3PropertyWithCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
