using RED.Api.DTOs.MessageDTOs;

namespace RED.Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id);
        Task<List<ResultInBoxMessageDTO>> GetInBoxByReceiver(int id);
        Task<List<ResultInBoxMessageDTO>> GetInBoxBySender(int id);
        Task<ResultInBoxMessageDTO> GetInBoxDetailByReceiver(int id);
        Task SendMessage(CreateMessageDTO createMessageDTO);
        Task<int?> GetUserIdByEmail(string email);
        Task DeleteMessage(int id);
    }
}
