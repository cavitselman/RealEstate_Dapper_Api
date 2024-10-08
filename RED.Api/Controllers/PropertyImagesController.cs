using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.PropertyImageRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageRepository _PropertyImageRepository;

        public PropertyImagesController(IPropertyImageRepository PropertyImageRepository)
        {
            _PropertyImageRepository = PropertyImageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertyImageByPropertyId(int id)
        {
            var values = await _PropertyImageRepository.GetPropertyImageByPropertyId(id);
            return Ok(values);
        }
    }
}
