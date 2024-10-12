using Dapper;
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
            string query = "INSERT INTO Contact (Name, Email, Subject, Message, SendDate) " +
                   "VALUES (@Name, @Email, @Subject, @Message, @SendDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDTO.Name);
            parameters.Add("@Email", createContactDTO.Email);
            parameters.Add("@Subject", createContactDTO.Subject);
            parameters.Add("@Message", createContactDTO.Message);
            parameters.Add("@SendDate", DateTime.UtcNow); // Burada UTC kullanıyoruz

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultContactDTO>> GetAllContact()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIDContactDTO> GetContact(int id)
        {
            throw new NotImplementedException();
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
