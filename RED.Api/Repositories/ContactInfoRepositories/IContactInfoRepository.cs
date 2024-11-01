using RED.Api.DTOs.ContactInfoDTOs;

namespace RED.Api.Repositories.ContactInfoRepositories
{
    public interface IContactInfoRepository
    {
        Task<ResultContactInfoDTO> GetAllContactInfo();
        Task<ResultContactInfoDTO> GetContactInfo(int id);
        Task UpdateContactInfo(ResultContactInfoDTO resultContactInfoDTO);
    }
}
