using Dapper;
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
        public async Task<GetByIDContactReplyDTO> GetReply(int id)
        {
            string query = "SELECT ReplyId, Email, ContactId, ReceiverEmail, Reply, Date " +
                   "FROM ContactReply WHERE ReplyId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDContactReplyDTO>(query, parameters);
                return value;
            }
        }

        public async Task PostReply(CreateContactReplyDTO createContactReplyDTO)
        {
            string query = "INSERT INTO ContactReply (ContactId, Email, ReceiverEmail, Date, Reply) " +
                   "VALUES (@ContactId, @Email, @ReceiverEmail, @Date, @Reply)";

            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", createContactReplyDTO.ContactId);
            parameters.Add("@Email", createContactReplyDTO.Email);
            parameters.Add("@ReceiverEmail", createContactReplyDTO.ReceiverEmail);
            parameters.Add("@Date", createContactReplyDTO.Date);
            parameters.Add("@Reply", createContactReplyDTO.Reply);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
