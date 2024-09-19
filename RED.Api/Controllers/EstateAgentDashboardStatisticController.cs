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

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ActiveCProductCountByStatusFalseategoryCount(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticRepository.AllProductCount());
        }
    }
}
