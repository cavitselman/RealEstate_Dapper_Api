using RED.Api.DTOs.BottomGridDTOs;

namespace RED.Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO);
        Task<GetBottomGridDTO> GetBottomGrid(int id);
    }
}
