using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RED.UI.DTOs.CategoryDTOs;
using RED.UI.DTOs.PropertyDTOs;
using RED.UI.Services.LoginService.LoginService;
using System.Text;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    [Authorize]
    public class MyAdvertsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyAdvertListByAppUserByTrue?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PassiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyAdvertListByAppUserByFalse?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAdvertListWithCategoryByEmployeeDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();

            // Kategorileri API'den al
            var categoryResponseMessage = await client.GetAsync("https://localhost:44383/api/Categories");
            if (categoryResponseMessage.IsSuccessStatusCode)
            {
                var categoryJsonData = await categoryResponseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoryJsonData);

                // Kategori listesini oluştur
                ViewBag.categoryList = categories.Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryID.ToString()
                }).ToList();
            }

            // İlan türlerini tanımla
            var propertyTypes = new List<SelectListItem>
    {
        new SelectListItem { Text = "Satılık", Value = "Satılık" },
        new SelectListItem { Text = "Kiralık", Value = "Kiralık" }
    };

            ViewBag.typeList = propertyTypes; // İlan türlerini ViewBag'e ekle

            return View(); // Yeni ilan oluşturma görünümünü döndür
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreatePropertyDTO createPropertyDTO)
        {
            // Varsayılan değerleri ayarlama
            createPropertyDTO.DealOfTheDay = false;
            createPropertyDTO.AdvertisementDate = DateTime.Now;
            createPropertyDTO.PropertyStatus = true;

            // Kullanıcı ID'sini alma
            var id = _loginService.GetUserId;
            createPropertyDTO.AppUserId = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPropertyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // API'ye POST isteği gönderme
            var responseMessage = await client.PostAsync("https://localhost:44383/api/Propertys", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Başarılı ise yönlendirme yap
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }

            // Hata durumunda yeniden formu göster
            return View(createPropertyDTO);
        }
        public async Task<IActionResult> DeleteActiveAdvert(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44383/api/Propertys/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }
            return View();
        }
        public async Task<IActionResult> DeletePassiveAdvert(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44383/api/Propertys/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/PassiveAdverts");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAdvert(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // İlan bilgilerini al
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/Propertys/GetPropertyByAdvertId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePropertyDTO>(jsonData);

                // Kategorileri API'den al
                var categoryResponseMessage = await client.GetAsync("https://localhost:44383/api/Categories");
                if (categoryResponseMessage.IsSuccessStatusCode)
                {
                    var categoryJsonData = await categoryResponseMessage.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoryJsonData);

                    // Kategori listesini oluştur
                    ViewBag.categoryList = categories.Select(c => new SelectListItem
                    {
                        Text = c.CategoryName,
                        Value = c.CategoryID.ToString()
                    }).ToList();
                }

                // İlan türlerini tanımla
                var propertyTypes = new List<SelectListItem>
        {
            new SelectListItem { Text = "Satılık", Value = "Satılık" },
            new SelectListItem { Text = "Kiralık", Value = "Kiralık" }
        };

                ViewBag.typeList = propertyTypes; // İlan türlerini ViewBag'e ekle

                return View(values); // Property bilgilerini View'a gönder
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdvert(UpdatePropertyDTO updatePropertyDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePropertyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44383/api/Propertys", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }
            return View();
        }

        public async Task<IActionResult> ChangeActive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyStatusChangeToTrue/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/PassiveAdverts");
            }
            return View();
        }

        public async Task<IActionResult> ChangePassive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyStatusChangeToFalse/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }
            return View();
        }
    }
}
