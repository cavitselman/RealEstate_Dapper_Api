using Dapper;
using RED.Api.DTOs.ChartDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDTO>> Get5CityForChart()
        {
            string query = "Select top(5) City,Count(*) as 'CityCount' From Property Group By City order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDTO>(query);
                return values.ToList();
            }
        }
    }
}
