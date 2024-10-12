using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.ContactDTOs;
using RED.Api.DTOs.MessageDTOs;
using RED.Api.Repositories.ContactRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _contactRepository.CreateContact(createContactDTO);
            return Ok("Mesaj başarıyla gönderildi.");
        }
    }
}
