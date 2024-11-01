using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.AppUserDTOs;
using RED.UI.Services.LoginService.LoginService;

namespace RED.UI.ViewComponents.Admin
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _AdminLayoutSidebarComponentPartial(ILoginService loginService, IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId; // Kullanıcı ID'sini al
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/AppUsers/GetAppUserInfo?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<GetAppUserInfoDTO>(jsonData); // Tek bir nesne döndüğünü varsayıyoruz

                // ViewBag'e verileri ekle
                ViewBag.UserImageUrl = user?.UserImageUrl ?? "~/dashmin-1.0.0/img/user.jpg"; // Varsayılan resim
                ViewBag.UserName = user?.UserName ?? "Kullanıcı"; // Varsayılan kullanıcı adı
            }
            else
            {
                // Hata durumunda varsayılan değerler
                ViewBag.UserImageUrl = "~/dashmin-1.0.0/img/user.jpg";
                ViewBag.UserName = "Kullanıcı";
            }

            return View();
        }
    }
}
