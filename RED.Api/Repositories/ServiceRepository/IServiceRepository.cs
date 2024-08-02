using RED.Api.DTOs.ServiceDTOs;

namespace RED.Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDTO>> GetAllServiceAsync();
        void CreateService(CreateServiceDTO createServiceDTO);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDTO updateServiceDTO);
        Task<GetByIDServiceDTO> GetService(int id);
    }
}
