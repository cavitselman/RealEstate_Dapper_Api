using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.AppUserDTOs;
using RED.UI.Services.LoginService.LoginService;
using System.Text;

namespace RED.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public ProfileController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/AppUsers/GetAppUserInfo?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAppUserInfoDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(GetAppUserInfoDTO updateUserDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUserDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44383/api/AppUsers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
