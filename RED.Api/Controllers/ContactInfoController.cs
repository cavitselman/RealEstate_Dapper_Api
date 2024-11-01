using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.ContactInfoDTOs;
using RED.Api.Repositories.ContactInfoRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoRepository _contactInfoRepository;

        public ContactInfoController(IContactInfoRepository contactInfoRepository)
        {
            _contactInfoRepository = contactInfoRepository;
        }

        [HttpGet("GetAllContactInfo")]
        public async Task<IActionResult> GetAllContactInfo()
        {
            var values = await _contactInfoRepository.GetAllContactInfo();
            return Ok(values);
        }

        [HttpGet("GetContactInfo")]
        public async Task<IActionResult> GetContactInfo(int id)
        {
            var values = await _contactInfoRepository.GetContactInfo(id);
            return Ok(values);
        }

        [HttpPut("UpdateContactInfo")]
        public async Task<IActionResult> UpdateContactInfo(ResultContactInfoDTO resultContactInfoDTO)
        {
            await _contactInfoRepository.UpdateContactInfo(resultContactInfoDTO);
            return Ok("Veri Başarıyla Güncellendi");
        }
    }
}
