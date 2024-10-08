using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("PropertyCountByEmployeeId")]
        public IActionResult PropertyCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.PropertyCountByEmployeeId(id));
        }

        [HttpGet("PropertyCountByStatusTrue")]
        public IActionResult PropertyCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.PropertyCountByStatusTrue(id));
        }

        [HttpGet("PropertyCountByStatusFalse")]
        public IActionResult ActiveCPropertyCountByStatusFalseategoryCount(int id)
        {
            return Ok(_statisticRepository.PropertyCountByStatusFalse(id));
        }

        [HttpGet("AllPropertyCount")]
        public IActionResult AllPropertyCount()
        {
            return Ok(_statisticRepository.AllPropertyCount());
        }
    }
}
