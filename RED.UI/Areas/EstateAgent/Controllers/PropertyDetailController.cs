using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.PropertyDetailDTOs;
using RED.UI.Services.LoginService.LoginService;
using System.Text;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Authorize]
    public class PropertyDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public PropertyDetailController(ILoginService loginService, IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreatePropertyDetail(int propertyId)
        {
            if (propertyId <= 0)
            {
                return BadRequest("Geçersiz PropertyID");
            }

            try
            {
                ViewBag.PropertyId = propertyId; // PropertyId'yi ViewBag'e ekle
                return View(); // Detay ekleme görünümünü döndür
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return BadRequest("Bir hata oluştu.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePropertyDetail(CreatePropertyDetailDTO createPropertyDetailDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPropertyDetailDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44383/api/PropertyDetails/CreatePropertyDetail", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }

            return View(createPropertyDetailDTO);
        }
    }
}
