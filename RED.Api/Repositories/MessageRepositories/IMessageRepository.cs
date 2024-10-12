using RED.Api.DTOs.MessageDTOs;

namespace RED.Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id);
        Task SendMessage(CreateContactMessageDTO createContactMessageDTO);
    }
}
