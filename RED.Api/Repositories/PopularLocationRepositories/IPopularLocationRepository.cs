using RED.Api.DTOs.BottomGridDTOs;
using RED.Api.DTOs.PopularLocationDTOs;

namespace RED.Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllPopularLocationAsync();
    }
}
