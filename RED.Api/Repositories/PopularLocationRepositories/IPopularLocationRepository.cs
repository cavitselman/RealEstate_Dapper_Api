using RED.Api.DTOs.PopularLocationDTOs;

namespace RED.Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO);
        Task<GetByIDPopularLocationDTO> GetPopularLocation(int id);
    }
}
