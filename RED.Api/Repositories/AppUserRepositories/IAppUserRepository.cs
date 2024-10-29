using RED.Api.DTOs.AppUserDTOs;

namespace RED.Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByPropertyIdDTO> GetAppUserByPropertyId(int id);
        Task<List<GetAppUserByPropertyIdDTO>> GetAppUserWithLast3Properties(int id);
        Task<GetAppUserInfoDTO> GetAppUserInfo(int id);
        Task DeleteAppUser(int id);
        Task UpdateAppUser(GetAppUserInfoDTO getAppUserInfoDTO);
        Task UpdateAppUserRole(UpdateAppUserRoleDTO updateAppUserRoleDTO);
        Task<List<UpdateAppUserRoleDTO>> GetAppUserRole();
        Task<UpdateAppUserRoleDTO> GetAppUserRoleId(int id);        
    }
}
