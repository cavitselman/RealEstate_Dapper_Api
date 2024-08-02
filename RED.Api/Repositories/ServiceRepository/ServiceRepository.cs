using Dapper;
using RED.Api.DTOs.ServiceDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public void CreateService(CreateServiceDTO createServiceDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDTO>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDTO>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDServiceDTO> GetService(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
