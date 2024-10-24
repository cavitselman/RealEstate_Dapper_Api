using RED.Api.DTOs.ContactReplyDTOs;

namespace RED.Api.Repositories.ContactReplyRepositories
{
    public interface IContactReplyRepository
    {
        Task PostReply(CreateContactReplyDTO createContactReplyDTO);
        Task<List<GetByIDContactReplyDTO>> GetReply(int id);
    }
}
