using Microsoft.AspNetCore.Mvc;
using RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get5CityForChart()
        {
            var values = await _chartRepository.Get5CityForChart();
            return Ok(values);
        }
    }
}
