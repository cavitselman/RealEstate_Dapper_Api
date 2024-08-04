using RED.Api.DTOs.CategoryDTOs;
using RED.Api.DTOs.EmployeeDTOs;

namespace RED.Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync();
        void CreateEmployee(CreateEmployeeDTO createEmployeeDTO);
        void DeleteEmployee(int id);
        void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }
}
