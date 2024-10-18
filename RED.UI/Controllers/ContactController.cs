using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.ContactDTOs;
using RED.UI.DTOs.ContactReplyDTOs;
using RED.UI.Models;
using System.Net.Http;
using System.Text;

namespace RED.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            // TempData'dan başarı mesajını kontrol et
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactMessage(CreateContactDTO createContactDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44383/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Başarı mesajını ayarla
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderilmiştir!";
                return RedirectToAction("Index");
            }
            // Hata durumunda model ile geri dön
            return View(createContactDTO);
        }

        [HttpGet]
        public async Task<IActionResult> AdminContact()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/Contacts/GetAllContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44383/api/Contacts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminContact", "Contact");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContactDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Mesaj detaylarını al
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/Contacts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var contactDetails = JsonConvert.DeserializeObject<GetByIDContactDTO>(jsonData);

                // Cevapları almak için API çağrısı
                var repliesResponse = await client.GetAsync($"https://localhost:44383/api/ContactReplies/{id}");
                List<GetByIDContactReplyDTO> replies = new List<GetByIDContactReplyDTO>();

                if (repliesResponse.IsSuccessStatusCode)
                {
                    var repliesJsonData = await repliesResponse.Content.ReadAsStringAsync();
                    // JSON array olarak deserialize et
                    replies = JsonConvert.DeserializeObject<List<GetByIDContactReplyDTO>>(repliesJsonData) ?? new List<GetByIDContactReplyDTO>();
                }

                var replyDTO = new CreateContactReplyDTO
                {
                    ContactId = id,
                    ReceiverEmail = contactDetails.Email
                };

                ViewBag.sender = "Admin"; // Gönderen
                ViewBag.date = DateTime.Now; // Tarih

                var viewModel = new ContactDetailViewModel
                {
                    ContactDetails = contactDetails,
                    ReplyDTO = replyDTO,
                    Replies = replies // Cevapları ekleyin
                };

                return View(viewModel);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendReply(CreateContactReplyDTO createContactReplyDTO)
        {
            try
            {
                // Alıcı e-posta adresini DTO'dan al
                var adminReply = new CreateContactReplyDTO
                {
                    Email = "realestate@admin.com", // Adminin e-posta adresi
                    ContactId = createContactReplyDTO.ContactId, // Mesaj ID'si
                    ReceiverEmail = createContactReplyDTO.ReceiverEmail, // Alıcı emaili DTO'dan al
                    Date = DateTime.UtcNow,
                    Reply = createContactReplyDTO.Reply // Burada Reply'yi DTO'dan alıyoruz
                };

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(adminReply);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:44383/api/ContactReplies", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Cevabınız başarıyla gönderildi.";
                    return RedirectToAction("ContactDetail", new { id = createContactReplyDTO.ContactId });
                }

                TempData["ErrorMessage"] = "Cevap gönderilirken bir hata oluştu.";
                return RedirectToAction("ContactDetail", new { id = createContactReplyDTO.ContactId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Cevap gönderirken bir hata oluştu: {ex.Message}";
                return RedirectToAction("ContactDetail", new { id = createContactReplyDTO.ContactId });
            }
        }
    }
}
