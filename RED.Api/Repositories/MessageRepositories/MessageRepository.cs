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

        public async Task SendMessage(CreateMessageDTO createContactMessageDTO)
        {
            string query = "INSERT INTO Message (Sender, Receiver, SenderName, SenderEmail, ReceiverEmail, Subject, MessageContent, SendDate, IsRead) " +
                           "VALUES (@Sender, @Receiver, @SenderName, @SenderEmail, @ReceiverEmail, @Subject, @MessageContent, @SendDate, @IsRead)";

            var parameters = new DynamicParameters();
            parameters.Add("@Sender", createContactMessageDTO.Sender);
            parameters.Add("@Receiver", createContactMessageDTO.Receiver);
            parameters.Add("@SenderName", createContactMessageDTO.SenderName);
            parameters.Add("@SenderEmail", createContactMessageDTO.SenderEmail);
            parameters.Add("@ReceiverEmail", createContactMessageDTO.ReceiverEmail);
            parameters.Add("@Subject", createContactMessageDTO.Subject);
            parameters.Add("@MessageContent", createContactMessageDTO.MessageContent);
            parameters.Add("@SendDate", DateTime.Now);
            parameters.Add("@IsRead", false);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteMessage(int id)
        {
            string query = "DELETE FROM Message WHERE MessageId = @MessageId";

            var parameters = new DynamicParameters();
            parameters.Add("@MessageId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "Select Top(3) MessageId,SenderName,Subject,MessageContent,SendDate,IsRead,UserImageUrl From Message Inner Join AppUser On Message.Sender=AppUser.UserId Where Receiver=@receiverId Order By MessageId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxByReceiver(int id)
        {
            string query = "Select MessageId, SenderName, Subject, MessageContent, SendDate, IsRead, UserImageUrl, AppUser.Email AS SenderEmail From Message Inner Join AppUser On Message.Sender=AppUser.UserId Where Receiver=@receiverId Order By MessageId Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultInBoxMessageDTO>> GetInBoxBySender(int id)
        {
            string query = @"
                    SELECT MessageId, 
                           Receiver AS ReceiverId, 
                           Subject, 
                           MessageContent, 
                           SendDate, 
                           IsRead, 
                           ReceiverEmail, 
                           AppUser.Email AS ReceiverEmail 
                    FROM Message 
                    INNER JOIN AppUser ON Message.Receiver = AppUser.UserId 
                    WHERE Sender = @senderId 
                    ORDER BY MessageId DESC";

            var parameters = new DynamicParameters();
            parameters.Add("@senderId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDTO>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<ResultInBoxMessageDTO> GetInBoxDetailByReceiver(int id)
        {
            string query = "SELECT MessageId, SenderName, Subject, MessageContent, SendDate, IsRead, UserImageUrl, AppUser.Email AS SenderEmail " +
                           "FROM Message INNER JOIN AppUser ON Message.Sender = AppUser.UserId WHERE MessageId = @messageId";
            var parameters = new DynamicParameters();
            parameters.Add("@messageId", id); // Mesaj ID'sini kullanarak sorgula

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultInBoxMessageDTO>(query, parameters);
                return values;
            }
        }

        public async Task<int?> GetUserIdByEmail(string email)
        {
            string query = "SELECT UserId FROM AppUser WHERE Email = @Email";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int?>(query, parameters);
            }
        }
    }
}
