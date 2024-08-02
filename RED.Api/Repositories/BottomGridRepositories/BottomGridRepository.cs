using Dapper;
using RED.Api.DTOs.BottomGridDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDTO>(query);
                return values.ToList();
            }
        }

        public Task<GetBottomGridDTO> GetBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            throw new NotImplementedException();
        }
    }
}
