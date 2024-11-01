using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RED.UI.DTOs.CategoryDTOs;
using RED.UI.DTOs.PropertyDTOs;
using RED.UI.Services.LoginService.LoginService;
using System.Text;

namespace RED.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public ProductController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyListWithCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyDTO>>(jsonData);

                // Toplam ilan sayısını ViewBag'e ekle
                ViewBag.TotalCount = values.Count;

                // Sayfalamayı uygula
                var pagedValues = values.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                // Mevcut sayfa ve sayfa boyutunu ViewBag'e ekle
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

                return View(pagedValues);
            }

            return View(new List<ResultPropertyDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
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
        public async Task<IActionResult> CreateProduct(CreatePropertyDTO createPropertyDTO)
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
                return RedirectToAction("Index");
            }

            // Hata durumunda yeniden formu göster
            return View(createPropertyDTO);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44383/api/Propertys/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyDealOfTheDayStatusChangeToFalse/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyDealOfTheDayStatusChangeToTrue/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
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
        public async Task<IActionResult> UpdateProduct(UpdatePropertyDTO updatePropertyDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePropertyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44383/api/Propertys", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangeActive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyStatusChangeToTrue/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ChangePassive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyStatusChangeToFalse/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
