using RED.Api.DTOs.ContactDTOs;

namespace RED.Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task<List<Last4ContactResultDTO>> GetLast4Contact();
        void CreateContact(CreateContactDTO createContactDTO);
        void DeleteContact(int id);
        Task<GetByIDContactDTO> GetContact(int id);
    }
}
