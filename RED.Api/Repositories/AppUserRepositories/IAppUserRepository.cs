using RED.Api.DTOs.AppUserDTOs;

namespace RED.Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDTO> GetAppUserByProductId(int id);
    }
}
