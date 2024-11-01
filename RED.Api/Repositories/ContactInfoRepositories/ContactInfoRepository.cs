using Dapper;
using RED.Api.DTOs.ContactInfoDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.ContactInfoRepositories
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly Context _context;

        public ContactInfoRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResultContactInfoDTO> GetAllContactInfo()
        {
            string query = "SELECT ContactInfoId, Description, Email, Address, Phone FROM ContactInfo";

            using (var connection = _context.CreateConnection())
            {
                var contacts = await connection.QueryFirstOrDefaultAsync<ResultContactInfoDTO>(query);
                return contacts;
            }
        }

        public async Task<ResultContactInfoDTO> GetContactInfo(int id)
        {
            string query = "Select * From ContactInfo Where ContactInfoId=@contactInfoId";
            var parameters = new DynamicParameters();
            parameters.Add("@contactInfoId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultContactInfoDTO>(query, parameters);
                return values;
            }
        }

        public async Task UpdateContactInfo(ResultContactInfoDTO resultContactInfoDTO)
        {
            string query = "Update ContactInfo Set Description=@description,Email=@email, Address=@address, Phone=@phone where ContactInfoId=@contactInfoId";
            var parameters = new DynamicParameters();
            parameters.Add("@description", resultContactInfoDTO.Description);
            parameters.Add("@email", resultContactInfoDTO.Email);
            parameters.Add("@address", resultContactInfoDTO.Address);
            parameters.Add("@phone", resultContactInfoDTO.Phone);
            parameters.Add("@contactInfoId", resultContactInfoDTO.ContactInfoId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
