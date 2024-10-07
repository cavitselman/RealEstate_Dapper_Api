using RED.Api.DTOs.ServiceDTOs;

namespace RED.Api.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllService();
        Task CreateService(CreateServiceDTO createServiceDTO);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDTO updateServiceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
