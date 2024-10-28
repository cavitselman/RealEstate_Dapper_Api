using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.ContactDTOs;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("GetAllContact")]
        public async Task<IActionResult> GetAllContact()
        {
            var values = await _contactRepository.GetAllContact();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _contactRepository.GetContact(id);
            return Ok(value);
        }
    }
}
