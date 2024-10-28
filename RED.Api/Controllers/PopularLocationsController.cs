using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.PopularLocationDTOs;
using RED.Api.Repositories.PopularLocationRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var value = await _locationRepository.GetAllPopularLocation();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO)
        {
            await _locationRepository.CreatePopularLocation(createPopularLocationDTO);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _locationRepository.DeletePopularLocation(id);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO)
        {
            await _locationRepository.UpdatePopularLocation(updatePopularLocationDTO);
            return Ok("Lokasyon Kısmı Başarıyla Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _locationRepository.GetPopularLocation(id);
            return Ok(value);
        }        
    }
}
