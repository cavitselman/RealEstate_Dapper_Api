using Dapper;
using RED.Api.DTOs.MessageDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task SendMessage(CreateContactMessageDTO createContactMessageDTO)
        {
            string query = "INSERT INTO Message (Sender, Receiver, Email, Subject, Detail, SendDate, IsRead) " +
                   "VALUES (@Sender, @Receiver, @Email, @Subject, @Detail, @SendDate, @IsRead)";

            var parameters = new DynamicParameters();
            parameters.Add("@Sender", createContactMessageDTO.Sender);
            parameters.Add("@Receiver", createContactMessageDTO.Receiver);
            parameters.Add("@Email", createContactMessageDTO.Email);
            parameters.Add("@Subject", createContactMessageDTO.Subject);
            parameters.Add("@Detail", createContactMessageDTO.MessageDetail);
            parameters.Add("@SendDate", DateTime.UtcNow);
            parameters.Add("@IsRead", false);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "Select Top(3) MessageId,Name,Subject,Detail,SendDate,IsRead,UserImageUrl From Message Inner Join AppUser On Message.Sender=AppUser.UserId Where Receiver=@receiverId Order By MessageId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }
    }
}
