using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.PropertyDTOs;
using RED.Api.Repositories.PropertyRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertysController : ControllerBase
    {
        private readonly IPropertyRepository _PropertyRepository;

        public PropertysController(IPropertyRepository PropertyRepository)
        {
            _PropertyRepository = PropertyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> PropertyList()
        {
            var values = await _PropertyRepository.GetAllPropertyAsync();
            return Ok(values);
        }

        [HttpGet("PropertyListWithCategory")]
        public async Task<IActionResult> PropertyListWithCategory()
        {
            var values = await _PropertyRepository.GetAllPropertyWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("PropertyDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToTrue(int id)
        {
            _PropertyRepository.PropertyDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi.");
        }

        [HttpGet("PropertyDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToFalse(int id)
        {
            _PropertyRepository.PropertyDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı.");
        }

        [HttpGet("Last5PropertyList")]
        public async Task<IActionResult> Last5PropertyList()
        {
            var values = await _PropertyRepository.GetLast5PropertyAsync();
            return Ok(values);
        }

        [HttpGet("PropertyAdvertListByEmployeeAsyncByTrue")]
        public async Task<IActionResult> PropertyAdvertListByEmployeeAsyncByTrue(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("PropertyAdvertListByEmployeeAsyncByFalse")]
        public async Task<IActionResult> PropertyAdvertListByEmployeeAsyncByFalse(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyDTO createPropertyDTO)
        {
            await _PropertyRepository.CreateProperty(createPropertyDTO);
            return Ok("İlan başarıyla eklendi.");
        }

        [HttpGet("GetPropertyByPropertyId")]
        public async Task<IActionResult> GetPropertyByPropertyId(int id)
        {
            var values = await _PropertyRepository.GetPropertyByPropertyId(id);
            return Ok(values);
        }

        [HttpGet("ResultPropertyWithSearchList")]
        public async Task<IActionResult> ResultPropertyWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _PropertyRepository.ResultPropertyWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetPropertyByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetPropertyByDealOfTheDayTrueWithCategory()
        {
            var values= await _PropertyRepository.GetPropertyByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetLast3Property")]
        public async Task<IActionResult> GetLast3Property()
        {
            var values = await _PropertyRepository.GetLast3PropertyAsync();
            return Ok(values);
        }
    }
}
