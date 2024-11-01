using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RED.UI.DTOs.ContactDTOs;
using RED.UI.DTOs.ContactInfoDTOs;
using RED.UI.DTOs.ContactReplyDTOs;
using RED.UI.Models;
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

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/ContactInfo/GetAllContactInfo");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultContactInfoDTO>(jsonData);
            ViewBag.Description = values.Description;
            ViewBag.Email = values.Email;
            ViewBag.Address = values.Address;
            ViewBag.Phone = values.Phone;
            // TempData'dan başarı mesajını kontrol et
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContactInfo()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44383/api/ContactInfo/GetAllContactInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactInfoDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContactInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44383/api/ContactInfo/GetContactInfo?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactInfoDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(ResultContactInfoDTO resultContactInfoDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultContactInfoDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44383/api/ContactInfo/UpdateContactInfo", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact");
            }
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

            var responseMessage = await client.GetAsync($"https://localhost:44383/api/Contacts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var contactDetails = JsonConvert.DeserializeObject<GetByIDContactDTO>(jsonData);

                if (contactDetails == null)
                {
                    TempData["ErrorMessage"] = "Mesaj detayları alınamadı.";
                    return RedirectToAction("Index");
                }

                var repliesResponse = await client.GetAsync($"https://localhost:44383/api/ContactReplies/{id}");
                List<GetByIDContactReplyDTO> replies = new List<GetByIDContactReplyDTO>();

                if (repliesResponse.IsSuccessStatusCode)
                {
                    var repliesJsonData = await repliesResponse.Content.ReadAsStringAsync();
                    replies = JsonConvert.DeserializeObject<List<GetByIDContactReplyDTO>>(repliesJsonData) ?? new List<GetByIDContactReplyDTO>();
                }

                var replyDTO = new CreateContactReplyDTO
                {
                    ContactID = id,
                    SenderEmail = contactDetails.Email
                };

                var viewModel = new ContactDetailViewModel
                {
                    ContactDetails = contactDetails,
                    ReplyDTO = replyDTO,
                    Replies = replies
                };

                return View(viewModel);
            }

            TempData["ErrorMessage"] = "Mesaj detayları alınamadı.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> ContactDetail(CreateContactReplyDTO createContactReplyDTO, int messageId, string replyContent, string contactEmail)
        {
            try
            {
                createContactReplyDTO.ContactID = messageId;
                createContactReplyDTO.SenderEmail = "realestate@destek.com";
                createContactReplyDTO.Email = contactEmail;
                createContactReplyDTO.Reply = replyContent;
                createContactReplyDTO.Date = DateTime.Now;

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createContactReplyDTO);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:44383/api/ContactReplies", stringContent);

                // API yanıtını kontrol et
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Cevabınız başarıyla gönderildi.";
                    return RedirectToAction("ContactDetail", "Contact", new { id = createContactReplyDTO.ContactID });
                }
                else
                {
                    // Hata durumunda içeriği oku ve kullanıcıya göster
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    TempData["ErrorMessage"] = $"Cevap gönderilirken bir hata oluştu: {content}";
                    return RedirectToAction("ContactDetail", "Contact", new { id = createContactReplyDTO.ContactID });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Bir hata oluştu: {ex.Message}";
                return RedirectToAction("ContactDetail", "Contact", new { id = createContactReplyDTO.ContactID });
            }
        }
    }
}
