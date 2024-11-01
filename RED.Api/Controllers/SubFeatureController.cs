using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.SubFeatureRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeatureController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubFeatureList()
        {
            var values = await _subFeatureRepository.GetAllSubFeature();
            return Ok(values);
        }
    }
}
