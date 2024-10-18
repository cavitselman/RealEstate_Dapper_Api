using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.PropertyDTOs;

namespace RED.UI.Controllers
{
    public class DealOfTheDayController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DealOfTheDayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/GetPropertyByDealOfTheDayTrueWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> List()
        {
            var client = _httpClientFactory.CreateClient();
            var trueResponse = await client.GetAsync("https://localhost:44383/api/Propertys/GetPropertyByDealOfTheDayTrueWithCategory");
            var falseResponse = await client.GetAsync("https://localhost:44383/api/Propertys/GetPropertyByDealOfTheDayFalseWithCategory");

            List<ResultPropertyDTO> values = new List<ResultPropertyDTO>();

            if (trueResponse.IsSuccessStatusCode)
            {
                var trueJsonData = await trueResponse.Content.ReadAsStringAsync();
                var trueValues = JsonConvert.DeserializeObject<List<ResultPropertyDTO>>(trueJsonData);
                values.AddRange(trueValues);
            }

            if (falseResponse.IsSuccessStatusCode)
            {
                var falseJsonData = await falseResponse.Content.ReadAsStringAsync();
                var falseValues = JsonConvert.DeserializeObject<List<ResultPropertyDTO>>(falseJsonData);
                values.AddRange(falseValues);
            }

            return View(values);
        }
    }
}
