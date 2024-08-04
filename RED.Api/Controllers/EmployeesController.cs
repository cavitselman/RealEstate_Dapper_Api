using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RED.Api.DTOs.CategoryDTOs;
using RED.Api.DTOs.EmployeeDTOs;
using RED.Api.Repositories.CategoryRepository;
using RED.Api.Repositories.EmployeeRepositories;

namespace RED.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            _employeeRepository.CreateEmployee(createEmployeeDTO);
            return Ok("Personel Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("Personel Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            _employeeRepository.UpdateEmployee(updateEmployeeDTO);
            return Ok("Personel Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }
    }
}
