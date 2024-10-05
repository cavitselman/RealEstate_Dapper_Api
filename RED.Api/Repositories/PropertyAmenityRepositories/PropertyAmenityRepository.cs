using Dapper;
using RED.Api.DTOs.PropertyAmenityDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDTO>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "Select PropertyAmenityId, Title From PropertyAmenity Inner Join Amenity On Amenity.AmenityId=PropertyAmenity.AmenityId Where PropertyId=@propertyId And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
