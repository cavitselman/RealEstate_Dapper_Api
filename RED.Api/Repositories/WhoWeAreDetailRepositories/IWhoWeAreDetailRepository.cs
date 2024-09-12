using RED.Api.DTOs.WhoWeAreDetailDTOs;
using RED.Api.DTOs.WhoWeAreDTOs;

namespace RED.Api.Repositories.WhoWeAreDetailRepositories
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDTO>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDTO createWhoWeAreDetailDTO);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDTO updateWhoWeAreDetailDTO);
        Task<GetByIDWhoWeAreDetailDTO> GetWhoWeAreDetail(int id);
    }
}
