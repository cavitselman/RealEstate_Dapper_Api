using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastPropertysRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastPropertysController : ControllerBase
    {
        private readonly ILast5PropertysRepository _lastPropertyRepository;

        public EstateAgentLastPropertysController(ILast5PropertysRepository lastPropertyRepository)
        {
            _lastPropertyRepository = lastPropertyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5PropertyAsync(int id)
        {
            var values= await _lastPropertyRepository.GetLast5Property(id);
            return Ok(values);
        }
    }
}
