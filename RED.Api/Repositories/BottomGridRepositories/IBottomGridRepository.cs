using RED.Api.DTOs.BottomGridDTOs;

namespace RED.Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllBottomGrid();
        Task CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO);
        Task<GetBottomGridDTO> GetBottomGrid(int id);
    }
}
