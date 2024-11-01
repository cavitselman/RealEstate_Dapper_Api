using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.PropertyDetailDTOs;
using RED.Api.Repositories.PropertyRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyDetailsController : ControllerBase
    {
        private readonly IPropertyRepository _PropertyRepository;

        public PropertyDetailsController(IPropertyRepository PropertyRepository)
        {
            _PropertyRepository = PropertyRepository;
        }

        [HttpGet("GetPropertyDetailByPropertyId")]
        public async Task<IActionResult> GetPropertyDetailByPropertyId(int id)
        {
            var values = await _PropertyRepository.GetPropertyDetailByPropertyId(id);
            return Ok(values);
        }

        [HttpPost("CreatePropertyDetail")]
        public async Task<IActionResult> CreatePropertyDetail(CreatePropertyDetailDTO createPropertyDetailDTO)
        {
            await _PropertyRepository.CreatePropertyDetail(createPropertyDetailDTO);
            return Ok("İlan detayı başarıyla eklendi.");
        }
    }
}
