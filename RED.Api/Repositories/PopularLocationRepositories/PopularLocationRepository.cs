using Dapper;
using RED.Api.DTOs.PopularLocationDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }
    }
}
