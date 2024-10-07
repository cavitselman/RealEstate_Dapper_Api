using RED.Api.DTOs.ContactDTOs;

namespace RED.Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDTO>> GetAllContact();
        Task<List<Last4ContactResultDTO>> GetLast4Contact();
        Task CreateContact(CreateContactDTO createContactDTO);
        Task DeleteContact(int id);
        Task<GetByIDContactDTO> GetContact(int id);
    }
}
