using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.MessageDTOs;
using RED.UI.Services.LoginService.LoginService;
using System.Text;

namespace RED.UI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageController(IHttpClientFactory httpClientFactory, ILoginService loginService, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InBox()
        {
            var id = _loginService?.GetUserId;
            if (id == null)
            {
                // Kullanıcı oturum açmamış, yönlendirme veya hata mesajı
                return RedirectToAction("SignIn", "Login");
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/Messages/GetInBoxByReceiver?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InBoxDetail(int id)
        {
            if (id == null)
            {
                // Kullanıcı oturum açmamış, yönlendirme veya hata mesajı
                return RedirectToAction("SignIn", "Login");
            }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/Messages/GetInBoxDetailByReceiver?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultInBoxMessageDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst("Email")?.Value;
            var userSenderId = _httpContextAccessor.HttpContext.User.FindFirst("UserId")?.Value;
            var userSenderName = _httpContextAccessor.HttpContext.User.FindFirst("Name")?.Value;

            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(createMessageDTO.ReceiverEmail))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı e-posta adresi veya alıcı e-posta adresi bulunamadı.");
                return View(createMessageDTO);
            }

            // Alıcı e-posta adresine göre kullanıcı ID'sini almak için API'ye istek gönder
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44383/api/Messages/GetUserIdByEmail?email={createMessageDTO.ReceiverEmail}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var receiverId = JsonConvert.DeserializeObject<int>(content);

                createMessageDTO.Sender = int.Parse(userSenderId);
                createMessageDTO.SenderEmail = userEmail;
                createMessageDTO.SenderName = userSenderName;
                createMessageDTO.Receiver = receiverId;
                createMessageDTO.SendDate = DateTime.Now;
                createMessageDTO.IsRead = false;

                // Mesaj gönderme işlemini yap
                var jsonData = JsonConvert.SerializeObject(createMessageDTO);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var sendMessageResponse = await client.PostAsync("https://localhost:44383/api/messages", stringContent);
                if (sendMessageResponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Mesajınız başarıyla gönderilmiştir!";
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = "Mesaj gönderimi sırasında bir hata oluştu.";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Alıcı e-posta adresi sistemde bulunamadı.");
            }

            return View(createMessageDTO);
        }
    }
}
