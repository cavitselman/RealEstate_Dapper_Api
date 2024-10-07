using RED.Api.DTOs.CategoryDTOs;
using RED.Api.DTOs.EmployeeDTOs;

namespace RED.Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDTO createEmployeeDTO);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }
}
