using Dapper;
using RED.Api.DTOs.PropertyImageDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.PropertyImageRepositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly Context _context;

        public PropertyImageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<GetPropertyImageByPropertyIdDTO>> GetPropertyImageByPropertyId(int id)
        {
            string query = "Select * From PropertyImage Where PropertyID=@PropertyID";
            var parameters = new DynamicParameters();
            parameters.Add("@PropertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPropertyImageByPropertyIdDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
