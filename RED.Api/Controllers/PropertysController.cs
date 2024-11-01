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
            var values = await _PropertyRepository.GetAllProperty();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _PropertyRepository.DeleteProperty(id);
            return Ok("İlan başarılı bir şekilde silindi!");
        }

        [HttpGet("PropertyListWithCategory")]
        public async Task<IActionResult> PropertyListWithCategory()
        {
            var values = await _PropertyRepository.GetAllPropertyWithCategory();
            return Ok(values);
        }

        [HttpGet("GetCategoryByVilla")]
        public async Task<IActionResult> GetCategoryByVilla()
        {
            var values = await _PropertyRepository.GetCategoryByVilla();
            return Ok(values);
        }

        [HttpGet("GetCategoryByDaire")]
        public async Task<IActionResult> GetCategoryByDaire()
        {
            var values = await _PropertyRepository.GetCategoryByDaire();
            return Ok(values);
        }

        [HttpGet("GetCategoryByYazlik")]
        public async Task<IActionResult> GetCategoryByYazlik()
        {
            var values = await _PropertyRepository.GetCategoryByYazlik();
            return Ok(values);
        }

        [HttpGet("PropertyDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToTrue(int id)
        {
            await _PropertyRepository.PropertyDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi.");
        }

        [HttpGet("PropertyDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToFalse(int id)
        {
            await _PropertyRepository.PropertyDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı.");
        }

        [HttpGet("Last5PropertyList")]
        public async Task<IActionResult> Last5PropertyList()
        {
            var values = await _PropertyRepository.GetLast5Property();
            return Ok(values);
        }

        [HttpGet("PropertyAdvertListByAppUserByTrue")]
        public async Task<IActionResult> PropertyAdvertListByAppUserByTrue(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByAppUserByTrue(id);
            return Ok(values);
        }

        [HttpGet("PropertyAdvertListByAppUserByFalse")]
        public async Task<IActionResult> PropertyAdvertListByAppUserByFalse(int id)
        {
            var values = await _PropertyRepository.GetPropertyAdvertListByAppUserByFalse(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyDTO createPropertyDTO)
        {
            await _PropertyRepository.CreateProperty(createPropertyDTO);
            return Ok("İlan başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyDTO updatePropertyDTO)
        {
            await _PropertyRepository.UpdateProperty(updatePropertyDTO);
            return Ok("İlan başarıyla güncellendi.");
        }

        [HttpGet("GetPropertyByPropertyId")]
        public async Task<IActionResult> GetPropertyByPropertyId(int id)
        {
            var values = await _PropertyRepository.GetPropertyByPropertyId(id);
            return Ok(values);
        }

        [HttpGet("GetPropertyByAdvertId")]
        public async Task<IActionResult> GetPropertyByAdvertId(int id)
        {
            var values = await _PropertyRepository.GetPropertyByAdvertId(id);
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
            var values = await _PropertyRepository.GetPropertyByDealOfTheDayTrueWithCategory();
            return Ok(values);
        }

        [HttpGet("GetLast3Property")]
        public async Task<IActionResult> GetLast3Property()
        {
            var values = await _PropertyRepository.GetLast3Property();
            return Ok(values);
        }

        [HttpGet("PropertyStatusChangeToTrue/{id}")]
        public async Task<IActionResult> PropertyStatusChangeToTrue(int id)
        {
            await _PropertyRepository.PropertyStatusChangeToTrue(id);
            return Ok("İlan Aktif Yapıldı.");
        }

        [HttpGet("PropertyStatusChangeToFalse/{id}")]
        public async Task<IActionResult> PropertyStatusChangeToFalse(int id)
        {
            await _PropertyRepository.PropertyStatusChangeToFalse(id);
            return Ok("İlan Pasif Yapıldı.");
        }

        [HttpGet("GetAllAnkaraProperty")]
        public async Task<IActionResult> GetAllAnkaraProperty()
        {
            var value = await _PropertyRepository.GetAllAnkaraProperty();
            return Ok(value);
        }

        [HttpGet("GetAllIzmirProperty")]
        public async Task<IActionResult> GetAllIzmirProperty()
        {
            var value = await _PropertyRepository.GetAllIzmirProperty();
            return Ok(value);
        }
    }
}
