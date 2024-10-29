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

        public async Task<GetAppUserInfoDTO> GetAppUserInfo(int id)
        {
            string query = "Select * From AppUser Where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserInfoDTO>(query, parameters);
                return values;
            }
        }

        public async Task UpdateAppUser(GetAppUserInfoDTO getAppUserInfoDTO)
        {
            string query = @"
                        UPDATE AppUser
                        SET 
                            UserName = @UserName,
                            Name = @Name,
                            Email = @Email,
                            UserImageUrl = @UserImageUrl,
                            PhoneNumber = @PhoneNumber
                        WHERE 
                            UserId = @UserId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", getAppUserInfoDTO.UserId);
            parameters.Add("@UserName", getAppUserInfoDTO.UserName);
            parameters.Add("@Name", getAppUserInfoDTO.Name);
            parameters.Add("@Email", getAppUserInfoDTO.Email);
            parameters.Add("@UserImageUrl", getAppUserInfoDTO.UserImageUrl);
            parameters.Add("@PhoneNumber", getAppUserInfoDTO.PhoneNumber);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateAppUserRole(UpdateAppUserRoleDTO updateAppUserRoleDTO)
        {
            string query = @"
                        UPDATE AppUser
                        SET             
                            UserRole = @UserRole
                        WHERE 
                            UserId = @UserId";

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", updateAppUserRoleDTO.UserId);
            parameters.Add("@UserRole", updateAppUserRoleDTO.UserRole);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<UpdateAppUserRoleDTO>> GetAppUserRole()
        {
            string query = @"
                           SELECT UserId, UserName, UserRole
                           FROM AppUser";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<UpdateAppUserRoleDTO>(query);
                return result.ToList();
            }
        }

        public async Task<UpdateAppUserRoleDTO> GetAppUserRoleId(int id)
        {
            string query = "Select * From AppUser Where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UpdateAppUserRoleDTO>(query,parameters);
                return values;
            }            
        }

        public async Task DeleteAppUser(int id)
        {
            string query = "Delete From AppUser Where UserId=@UserId";
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
