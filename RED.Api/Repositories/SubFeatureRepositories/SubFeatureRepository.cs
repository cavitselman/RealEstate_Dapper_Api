using Dapper;
using RED.Api.DTOs.SubFeatureDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultSubFeatureDTO>> GetAllSubFeatureAsync()
        {
            string query = "Select * From SubFeature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDTO>(query);
                return values.ToList();
            }
        }
    }
}
