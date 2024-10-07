using RED.Api.DTOs.WhoWeAreDetailDTOs;
using RED.Api.DTOs.WhoWeAreDTOs;

namespace RED.Api.Repositories.WhoWeAreDetailRepositories
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetail();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        Task DeleteWhoWeAreDetail(int id);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO);
        Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
    }
}
