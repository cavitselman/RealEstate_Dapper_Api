using Dapper;
using RED.Api.DTOs.BottomGridDTOs;
using RED.Api.DTOs.ContactDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDTO createContactDTO)
        {
            string query = "INSERT INTO Contact (Name, Email, Subject, Message, SendDate, IsRead) " +
                           "VALUES (@Name, @Email, @Subject, @Message, @SendDate, @IsRead)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDTO.Name);
            parameters.Add("@Email", createContactDTO.Email);
            parameters.Add("@Subject", createContactDTO.Subject);
            parameters.Add("@Message", createContactDTO.Message);
            parameters.Add("@SendDate", DateTime.UtcNow); // Burada UTC kullanıyoruz
            parameters.Add("@IsRead", false); // IsRead'i false olarak gönderiyoruz

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "DELETE FROM Contact WHERE ContactID = @contactId";

            var parameters = new DynamicParameters();
            parameters.Add("@contactId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDTO>> GetAllContact()
        {
            string query = "SELECT ContactID, Name, Email, Subject, Message, SendDate, IsRead FROM Contact";

            using (var connection = _context.CreateConnection())
            {
                var contacts = await connection.QueryAsync<ResultContactDTO>(query);
                return contacts.ToList();
            }
        }

        public async Task<GetByIDContactReplyDTO> GetContact(int id)
        {
            string query = "Select * From Contact Where ContactID=@contactId";
            var parameters = new DynamicParameters();
            parameters.Add("@contactId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactReplyDTO>(query, parameters);
                return values;
            }
        }

        public async Task<List<Last4ContactResultDTO>> GetLast4Contact()
        {
            string query = "Select Top(4) * From Contact order by ContactID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDTO>(query);
                return values.ToList();
            }
        }
    }
}
