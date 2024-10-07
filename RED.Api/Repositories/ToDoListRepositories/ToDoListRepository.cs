using Dapper;
using RED.Api.DTOs.ToDoListDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public Task CreateToDoList(CreateToDoListDTO ToDoListDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDTO>> GetAllToDoList()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDTO>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDToDoListDTO> GetToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoList(UpdateToDoListDTO ToDoListDTO)
        {
            throw new NotImplementedException();
        }
    }
}
