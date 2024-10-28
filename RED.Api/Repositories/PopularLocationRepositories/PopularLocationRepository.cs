using Dapper;
using RED.Api.DTOs.PopularLocationDTOs;
using RED.Api.DTOs.PropertyDTOs;
using RED.Api.DTOs.ServiceDTOs;
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

        public async Task CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDTO.CityName);
            parameters.Add("@imageUrl", createPopularLocationDTO.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllPopularLocation()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }               

        public async Task<GetByIDPopularLocationDTO> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDTO>(query, parameters);
                return values;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO)
        {
            string query = "Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDTO.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDTO.ImageUrl);
            parameters.Add("@locationID", updatePopularLocationDTO.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }        
    }
}
