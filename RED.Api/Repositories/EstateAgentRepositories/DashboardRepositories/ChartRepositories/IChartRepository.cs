using RED.Api.DTOs.ChartDTOs;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDTO>> Get5CityForChart();
    }
}
