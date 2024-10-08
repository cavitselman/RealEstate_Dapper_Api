using Dapper;
using RED.Api.DTOs.AppUserDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByPropertyIdDTO> GetAppUserByPropertyId(int id)
        {
            string query = "Select * From AppUser Where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByPropertyIdDTO>(query, parameters);
                return values;
            }
        }
    }
}
