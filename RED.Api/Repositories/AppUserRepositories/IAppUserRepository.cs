using RED.Api.DTOs.AppUserDTOs;

namespace RED.Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByPropertyIdDTO> GetAppUserByPropertyId(int id);
    }
}
