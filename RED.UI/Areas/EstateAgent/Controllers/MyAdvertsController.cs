using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RED.UI.DTOs.CategoryDTOs;
using RED.UI.DTOs.PropertyDTOs;
using RED.UI.Services;
using System.Text;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
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
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreatePropertyDTO createPropertyDTO)
        {
            createPropertyDTO.DealOfTheDay = false;
            createPropertyDTO.AdvertisementDate = DateTime.Now;
            createPropertyDTO.PropertyStatus = true;

            var id = _loginService.GetUserId;
            createPropertyDTO.EmployeeID = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPropertyDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44383/api/Propertys", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
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
                return Redirect("/EstateAgent/MyAdverts/ActiveAdverts");
            }
            return View();
        }

        public async Task<IActionResult> ChangePassive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Propertys/PropertyStatusChangeToFalse/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/EstateAgent/MyAdverts/PassiveAdverts");
            }
            return View();
        }
    }
}
