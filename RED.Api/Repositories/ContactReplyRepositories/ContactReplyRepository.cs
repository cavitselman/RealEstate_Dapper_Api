using Dapper;
using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.ContactReplyDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.ContactReplyRepositories
{
    public class ContactReplyRepository : IContactReplyRepository
    {
        private readonly Context _context;

        public ContactReplyRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<GetByIDContactReplyDTO>> GetReply(int contactId)
        {
            string query = "SELECT ReplyId, Email, ContactID, SenderEmail, Reply, Date " +
                           "FROM ContactReply WHERE ContactID = @ContactId"; // Burayı değiştirdik

            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", contactId); // @Id yerine @ContactId

            using (var connection = _context.CreateConnection())
            {
                var replies = await connection.QueryAsync<GetByIDContactReplyDTO>(query, parameters);
                return replies.ToList();
            }
        }

        public async Task PostReply(CreateContactReplyDTO createContactReplyDTO)
        {
            string query = "INSERT INTO ContactReply (ContactID, Email, SenderEmail, Date, Reply) " +
                           "VALUES (@ContactId, @Email, @SenderEmail, @Date, @Reply)";

            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", createContactReplyDTO.ContactID);
            parameters.Add("@Email", createContactReplyDTO.Email);
            parameters.Add("@SenderEmail", createContactReplyDTO.SenderEmail);
            parameters.Add("@Date", DateTime.UtcNow);
            parameters.Add("@Reply", createContactReplyDTO.Reply);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
