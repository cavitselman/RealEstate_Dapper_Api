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
        public async Task<List<GetAppUserByPropertyIdDTO>> GetAppUserWithLast3Properties(int id)
        {
            string query = @"
        SELECT TOP 3 
    u.UserId, 
    u.Name, 
    u.Email, 
    u.PhoneNumber, 
    u.UserImageUrl,
    p.PropertyId, 
    p.Title, 
    p.CoverImage, 
    p.AdvertisementDate 
FROM AppUser u
JOIN Property p ON u.UserId = p.AppUserId
WHERE u.UserId = @UserId 
AND p.PropertyStatus = 1
ORDER BY p.AdvertisementDate DESC, p.PropertyId DESC";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetAppUserByPropertyIdDTO>(query, parameters);
                return values.ToList();
            }
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
