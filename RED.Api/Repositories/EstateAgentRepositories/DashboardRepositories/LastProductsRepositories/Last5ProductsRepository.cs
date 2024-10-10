using Dapper;
using RED.Api.DTOs.PropertyDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastPropertysRepositories
{
    public class Last5PropertysRepository : ILast5PropertysRepository
    {
        private readonly Context _context;

        public Last5PropertysRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5PropertyWithCategoryDTO>> GetLast5Property(int id)
        {
            string query = "Select Top(5) PropertyID,Title,Price,City,District,PropertyCategory,CategoryName,AdvertisementDate From Property Inner Join Category On Property.PropertyCategory=Category.CategoryID Where AppUserId=@appUserId Order By PropertyID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5PropertyWithCategoryDTO>(query,parameters);
                return values.ToList();
            }
        }
    }
}
