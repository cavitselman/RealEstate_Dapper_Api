using Dapper;
using RED.Api.DTOs.EmployeeDTOs;
using RED.Api.Models.DapperContext;

namespace RED.Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string query = "insert into Employee (Name,Title,Email,PhoneNumber,ImageUrl,Status) values (@name,@title,@email,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDTO.Name);
            parameters.Add("@title", createEmployeeDTO.Title);
            parameters.Add("@email", createEmployeeDTO.Email);
            parameters.Add("@phoneNumber", createEmployeeDTO.PhoneNumber);
            parameters.Add("@imageUrl", createEmployeeDTO.ImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDTO>> GetAllEmployee()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDTO>(query, parameters);
                return values;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            string query = "Update Employee Set Name=@name,Title=@title,Email=@email,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status where EmployeeID=@employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDTO.Name);
            parameters.Add("@title", updateEmployeeDTO.Title);
            parameters.Add("@email", updateEmployeeDTO.Email);
            parameters.Add("@phoneNumber", updateEmployeeDTO.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDTO.ImageUrl);
            parameters.Add("@status", updateEmployeeDTO.Status);
            parameters.Add("@employeeId", updateEmployeeDTO.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
